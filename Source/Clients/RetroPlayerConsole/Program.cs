﻿/******************************************************************************/
/* This source, or parts thereof, may be used in any software as long the     */
/* license of RetroPlayer is keep. See the LICENSE file for more information. */
/*                                                                            */
/* Copyright (C) 2021 by Polycode / RetroPlayer team.                         */
/* All rights reserved.                                                       */
/******************************************************************************/
using System;
using System.IO;
using Polycode.RetroPlayer.RetroPlayerKit.Containers;
using Polycode.RetroPlayer.RetroPlayerKit.Interfaces;
using Polycode.RetroPlayer.RetroPlayerKit.Streams;
using Polycode.RetroPlayer.RetroPlayerLibrary.Agent;
using Polycode.RetroPlayer.RetroPlayerLibrary.Containers;
using Polycode.RetroPlayer.RetroPlayerLibrary.Players;

namespace Polycode.RetroPlayer.RetroPlayerConsole
{
	/// <summary>
	/// RetroPlayer console player. Mainly used to easily test players
	/// </summary>
	public static class Program
	{
		/********************************************************************/
		/// <summary>
		/// Main entry point
		/// </summary>
		/********************************************************************/
		public static void Main(string[] args)
		{
			if (args.Length == 0)
			{
				Console.WriteLine("Music player to play old-school Amiga and PC modules.");
				Console.WriteLine();
				Console.WriteLine("Syntax: RetroPlayerConsole file");
				return;
			}

			try
			{
				string errorMessage;

				string fileName = args[0];

				// Load needed agents
				Manager agentManager = new Manager();
				agentManager.LoadSpecificAgents(Manager.AgentType.Output);
				agentManager.LoadSpecificAgents(Manager.AgentType.Players);

				// First make sure that the file exists
				if (!File.Exists(fileName))
				{
					Console.WriteLine("File does not exists");
					return;
				}

				// Load the file
				Loader loader = new Loader(agentManager);
				if (!loader.Load(new PlayerFileInfo(fileName, new ModuleStream(new FileStream(args[0], FileMode.Open, FileAccess.Read))), out errorMessage))
				{
					Console.WriteLine("Could not load the module. Failed with error:");
					Console.WriteLine(errorMessage);
					return;
				}

				// Find the output agent to use
				IOutputAgent outputAgent = FindOutputAgent(agentManager);
				if (outputAgent == null)
				{
					Console.WriteLine("Could not find CoreAudio output agent");
					return;
				}

				// Initialize output agent so its ready for use
				if (outputAgent.Initialize(out errorMessage) == AgentResult.Error)
				{
					Console.WriteLine("Cannot initialize output device.");
					Console.WriteLine(errorMessage);
					return;
				}

				try
				{
					IPlayer player = loader.Player;

					if (!player.InitPlayer(new PlayerConfiguration(outputAgent, loader, new MixerConfiguration
						{
							EnableAmigaFilter = true,
							StereoSeparator = 100
						}), out errorMessage))
					{
						Console.WriteLine("Cannot initialize player.");
						Console.WriteLine(errorMessage);
						return;
					}

					try
					{
						// Start to play the music
						player.SelectSong(0);
						player.StartPlaying();

						try
						{
							Console.WriteLine("Playing file: " + Path.GetFileName(fileName));
							Console.WriteLine("Module format: " + player.ModuleFormat);
							Console.WriteLine("Player name: " + player.PlayerName);
							Console.WriteLine("Module size: " + player.ModuleSize);
							Console.WriteLine();
							Console.WriteLine("Module name: " + (string.IsNullOrEmpty(player.ModuleName) ? "Unknown" : player.ModuleName));
							Console.WriteLine("Author: " + (string.IsNullOrEmpty(player.Author) ? "Unknown" : player.Author));
							Console.WriteLine("Total time: " + player.TotalTime.ToString(@"mm\:ss"));

							// Output extra information
							foreach (string info in player.ModuleInformation)
							{
								string[] parts = info.Split('\t');
								Console.WriteLine(parts[0] + ": " + parts[1]);
							}

							Console.WriteLine();
							Console.WriteLine("Press enter to stop playing");
							Console.ReadLine();
						}
						finally
						{
							player.StopPlaying();
						}
					}
					finally
					{
						player.CleanupPlayer();
					}
				}
				finally
				{
					outputAgent.Shutdown();
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine("Program failed with exception: " + ex);
			}
		}



		/********************************************************************/
		/// <summary>
		/// Will find the output agent to use
		/// </summary>
		/********************************************************************/
		private static IOutputAgent FindOutputAgent(Manager agentManager)
		{
			IAgent agent = agentManager.GetAgent(Manager.AgentType.Output, new Guid("b9cef7e4-c74c-4af0-b01d-802f0d1b4cc7"));
			if (agent == null)
				return null;

			return (IOutputAgent)agent.CreateInstance();
		}
	}
}
