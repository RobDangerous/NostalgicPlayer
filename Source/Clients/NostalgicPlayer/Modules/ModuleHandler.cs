﻿/******************************************************************************/
/* This source, or parts thereof, may be used in any software as long the     */
/* license of NostalgicPlayer is keep. See the LICENSE file for more          */
/* information.                                                               */
/*                                                                            */
/* Copyright (C) 2021 by Polycode / NostalgicPlayer team.                     */
/* All rights reserved.                                                       */
/******************************************************************************/
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Krypton.Toolkit;
using Polycode.NostalgicPlayer.NostalgicPlayer.Containers.Settings;
using Polycode.NostalgicPlayer.NostalgicPlayer.MainWindow;
using Polycode.NostalgicPlayer.NostalgicPlayerKit.Containers;
using Polycode.NostalgicPlayer.NostalgicPlayerKit.Interfaces;
using Polycode.NostalgicPlayer.NostalgicPlayerLibrary.Agent;
using Polycode.NostalgicPlayer.NostalgicPlayerLibrary.Containers;
using Polycode.NostalgicPlayer.NostalgicPlayerLibrary.Players;

namespace Polycode.NostalgicPlayer.NostalgicPlayer.Modules
{
	/// <summary>
	/// This class handles all the loading and playing of modules
	/// </summary>
	public class ModuleHandler
	{
		private class ModuleItem
		{
			public ModuleListItem ListItem;
			public Loader Loader;
		}

		private MainWindowForm mainWindowForm;
		private Manager agentManager;
		private SoundSettings soundSettings;

		private IOutputAgent outputAgent;

		private List<ModuleItem> loadedFiles;

		private volatile bool isPlaying = false;
		private int currentMasterVolume;
		private bool isMuted = false;

		/********************************************************************/
		/// <summary>
		/// Event called when the player change position
		/// </summary>
		/********************************************************************/
		public event EventHandler PositionChanged;



		/********************************************************************/
		/// <summary>
		/// Event called when the player reached the end
		/// </summary>
		/********************************************************************/
		public event EventHandler EndReached;



		/********************************************************************/
		/// <summary>
		/// Initialize and start the module handler thread
		/// </summary>
		/********************************************************************/
		public void Initialize(MainWindowForm mainWindow, Manager manager, SoundSettings soundSettings, int startVolume)
		{
			// Remember the arguments
			mainWindowForm = mainWindow;
			agentManager = manager;
			this.soundSettings = soundSettings;

			currentMasterVolume = startVolume;

			// Initialize the loader
			loadedFiles = new List<ModuleItem>();

			// Find the output agent to use
			FindOutputAgent();
		}



		/********************************************************************/
		/// <summary>
		/// Shutdown and cleanup
		/// </summary>
		/********************************************************************/
		public void Shutdown()
		{
			isPlaying = false;
			loadedFiles = null;

			// Close down the output agent
			outputAgent?.Shutdown();
			outputAgent = null;

			soundSettings = null;
			agentManager = null;
		}

		#region Properties
		/********************************************************************/
		/// <summary>
		/// Tells if the module is playing or not at the moment
		/// </summary>
		/********************************************************************/
		public bool IsPlaying
		{
			get
			{
				return isPlaying;
			}

			set
			{
				isPlaying = value;
			}
		}



		/********************************************************************/
		/// <summary>
		/// Return all the static module information
		/// </summary>
		/********************************************************************/
		public ModuleInfoStatic StaticModuleInformation
		{
			get
			{
				return GetActivePlayer()?.StaticModuleInformation ?? new ModuleInfoStatic();
			}
		}



		/********************************************************************/
		/// <summary>
		/// Return all the information about the module which changes while
		/// playing
		/// </summary>
		/********************************************************************/
		public ModuleInfoFloating PlayingModuleInformation
		{
			get
			{
				return GetActivePlayer()?.PlayingModuleInformation ?? new ModuleInfoFloating();
			}
		}
		#endregion

		#region Public methods
		/********************************************************************/
		/// <summary>
		/// Will load and play the module at the index given
		/// </summary>
		/********************************************************************/
		public bool LoadAndPlayModule(ModuleListItem listItem, int subSong = -1, int startPos = -1)
		{
			// Start to free all loaded modules
			FreeAllModules();

			// Now load and play the first module
			return LoadAndInitModule(listItem, subSong, startPos);
		}



		/********************************************************************/
		/// <summary>
		/// Will stop and free the playing module if any
		/// </summary>
		/********************************************************************/
		public void StopAndFreeModule()
		{
			lock (loadedFiles)
			{
				// Did we have any modules loaded at all?
				if (loadedFiles.Count > 0)
				{
					// Get the first one
					ModuleItem item = loadedFiles[0];

					IPlayer player = item.Loader.Player;

					if (IsPlaying)
					{
						// Stop the playing
						player.StopPlaying();

						if (player is IModulePlayer modulePlayer)
						{
							// Unsubscribe to position changes
							modulePlayer.PositionChanged -= Player_PositionChanged;
						}

						// Unsubscribe to end notifications
						player.EndReached -= Player_EndReached;

						IsPlaying = false;
					}

					// Cleanup the player
					player.CleanupPlayer();

					// Unload the module
					item.Loader.Unload();

					// Remove the file from our list
					loadedFiles.RemoveAt(0);
				}
			}
		}



		/********************************************************************/
		/// <summary>
		/// Will free all loaded modules
		/// </summary>
		/********************************************************************/
		public void FreeAllModules()
		{
			lock (loadedFiles)
			{
				foreach (ModuleItem item in loadedFiles)
				{
					// Cleanup the player
					item.Loader.Player.CleanupPlayer();

					// Unload the module
					item.Loader.Unload();
				}

				// Empty the list
				loadedFiles.Clear();
			}
		}



		/********************************************************************/
		/// <summary>
		/// Will start to play the song given
		/// </summary>
		/********************************************************************/
		public void StartSong(int newSong)
		{
			IPlayer player = GetActivePlayer();

			if (player != null)
			{
				// Stop the playing
				player.StopPlaying();

				// Switch song if possible
				if (player is IModulePlayer modulePlayer)
					modulePlayer.SelectSong(newSong);

				// And start playing again
				player.StartPlaying();
			}
		}



		/********************************************************************/
		/// <summary>
		/// Will tell the player to change to the position given
		/// </summary>
		/********************************************************************/
		public void SetSongPosition(int newPosition)
		{
			IPlayer player = GetActivePlayer();

			if (player != null)
			{
				if (player is IModulePlayer modulePlayer)
					modulePlayer.SetSongPosition(newPosition);
			}
		}



		/********************************************************************/
		/// <summary>
		/// Will remember the mute status
		/// </summary>
		/********************************************************************/
		public void SetMuteStatus(bool muted)
		{
			isMuted = muted;
			SetVolume(currentMasterVolume);
		}



		/********************************************************************/
		/// <summary>
		/// Will tell the mixer to change the volume
		/// </summary>
		/********************************************************************/
		public void SetVolume(int newVolume)
		{
			IPlayer player = GetActivePlayer();

			if (player != null)
				player.SetMasterVolume(isMuted ? 0 : newVolume);

			currentMasterVolume = newVolume;
		}



		/********************************************************************/
		/// <summary>
		/// Will pause the player
		/// </summary>
		/********************************************************************/
		public void PausePlaying()
		{
			IPlayer player = GetActivePlayer();

			if (player != null)
			{
				player.PausePlaying();
				IsPlaying = false;
			}
		}



		/********************************************************************/
		/// <summary>
		/// Will resume the player
		/// </summary>
		/********************************************************************/
		public void ResumePlaying()
		{
			IPlayer player = GetActivePlayer();

			if (player != null)
			{
				player.ResumePlaying();
				IsPlaying = true;
			}
		}



		/********************************************************************/
		/// <summary>
		/// Return the time on the position given
		/// </summary>
		/********************************************************************/
		public TimeSpan GetPositionTime(int position)
		{
			TimeSpan[] positionTimes = PlayingModuleInformation.PositionTimes;
			return positionTimes == null ? new TimeSpan(0) : positionTimes[position];
		}
		#endregion

		#region Event handlers
		/********************************************************************/
		/// <summary>
		/// Is called every time the player changed position
		/// </summary>
		/********************************************************************/
		private void Player_PositionChanged(object sender, EventArgs e)
		{
			// Just call the next event handler
			if (PositionChanged != null)
				PositionChanged(sender, e);
		}



		/********************************************************************/
		/// <summary>
		/// Is called when the player has reached the end
		/// </summary>
		/********************************************************************/
		private void Player_EndReached(object sender, EventArgs e)
		{
			// Just call the next event handler
			if (EndReached != null)
				EndReached(sender, e);
		}
		#endregion

		#region Private methods
		/********************************************************************/
		/// <summary>
		/// Will show an error message to the user
		/// </summary>
		/********************************************************************/
		private void ShowSimpleErrorMessage(string message)
		{
			mainWindowForm.Invoke(new Action(() =>
			{
				KryptonMessageBox.Show(message, Properties.Resources.IDS_MAIN_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}));
		}



		/********************************************************************/
		/// <summary>
		/// Will show an error message to the user with options
		/// </summary>
		/********************************************************************/
		private void ShowErrorMessage(string message)//XX
		{
			mainWindowForm.Invoke(new Action(() =>
			{
				KryptonMessageBox.Show(message, Properties.Resources.IDS_MAIN_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}));
		}



		/********************************************************************/
		/// <summary>
		/// Will find the configured or default output agent and initialize it
		/// </summary>
		/********************************************************************/
		private void FindOutputAgent()
		{
			Guid agentId = soundSettings.OutputAgent;

			IAgent agent = agentManager.GetAgent(Manager.AgentType.Output, agentId);
			if (agent == null)
			{
				// Selected output agent could not be loaded, try with the default one if not already that one
				if (agentId != soundSettings.DefaultOutputAgent)
				{
					agent = agentManager.GetAgent(Manager.AgentType.Output, soundSettings.DefaultOutputAgent);
					if (agent == null)
						ShowSimpleErrorMessage(Properties.Resources.IDS_ERR_NOOUTPUTAGENT);
				}
			}

			if (agent != null)
			{
				outputAgent = (IOutputAgent)agent.CreateInstance();
				if (outputAgent.Initialize(out string errorMessage) == AgentResult.Error)
					ShowSimpleErrorMessage(string.Format(Properties.Resources.IDS_ERR_INITOUTPUTAGENT, errorMessage));
			}
		}



		/********************************************************************/
		/// <summary>
		/// Load and/or initialize module
		/// </summary>
		/********************************************************************/
		private bool LoadAndInitModule(ModuleListItem listItem, int? subSong = null, int? startPos = null, bool showError = true)
		{
			// Should we load a module?
			if (listItem != null)
			{
				string errorMessage;

				ModuleItem item = new ModuleItem();
				item.ListItem = listItem;

				// Get the file name
				string fileName = listItem.ShortText;

				// Create new loader
				item.Loader = new Loader(agentManager);

				// Load the module
				if (!item.Loader.Load(new PlayerFileInfo(fileName, listItem.OpenFile()), out errorMessage))
				{
					if (showError)
						ShowErrorMessage(string.Format(Properties.Resources.IDS_ERR_LOAD_FILE, errorMessage));

					return false;
				}

				// Setup mixer settings
				MixerConfiguration mixerConfig = new MixerConfiguration();
				mixerConfig.EnableAmigaFilter = true;
				mixerConfig.StereoSeparator = 100;

				// Setup player settings
				PlayerConfiguration playerConfig = new PlayerConfiguration(outputAgent, item.Loader, mixerConfig);

				// Initialize the module
				if (!item.Loader.Player.InitPlayer(playerConfig, out errorMessage))
				{
					if (showError)
						ShowErrorMessage(string.Format(Properties.Resources.IDS_ERR_INIT_PLAYER, errorMessage));

					item.Loader.Unload();
					return false;
				}

				lock (loadedFiles)
				{
					// Add the new module to the list
					loadedFiles.Add(item);
				}
			}

			// Should we start playing the module?
			if (subSong.HasValue)
			{
				if (!startPos.HasValue)
					startPos = -1;

				// Start to play the module
				StartPlaying(subSong.Value, startPos.Value);
			}

			return true;
		}



		/********************************************************************/
		/// <summary>
		/// Will start to play the song number given
		/// </summary>
		/********************************************************************/
		private void StartPlaying(int subSong, int startPos)
		{
			IPlayer player = GetActivePlayer();

			// Is there any modules loaded?
			if (player != null)
			{
				// Change the volume
				SetVolume(currentMasterVolume);

				// Initialize the module
				if (player is IModulePlayer modulePlayer)
				{
					modulePlayer.SelectSong(subSong);

					if (startPos != -1)
						modulePlayer.SetSongPosition(startPos);

					// Subscribe to position changes
					modulePlayer.PositionChanged += Player_PositionChanged;
				}

				// Subscribe to end notifications
				player.EndReached += Player_EndReached;

				// The module is playing
				IsPlaying = true;

				// Start playing the song
				player.StartPlaying();
			}
		}



		/********************************************************************/
		/// <summary>
		/// Return current active player or null
		/// </summary>
		/********************************************************************/
		private IPlayer GetActivePlayer()
		{
			lock (loadedFiles)
			{
				return loadedFiles.Count > 0 ? loadedFiles[0].Loader.Player : null;
			}
		}
		#endregion
	}
}
