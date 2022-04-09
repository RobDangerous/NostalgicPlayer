﻿/******************************************************************************/
/* This source, or parts thereof, may be used in any software as long the     */
/* license of NostalgicPlayer is keep. See the LICENSE file for more          */
/* information.                                                               */
/*                                                                            */
/* Copyright (C) 2021-2022 by Polycode / NostalgicPlayer team.                */
/* All rights reserved.                                                       */
/******************************************************************************/
using System;
using System.Collections.Generic;
using Polycode.NostalgicPlayer.Kit.Containers;
using Polycode.NostalgicPlayer.Kit.Interfaces;

namespace Polycode.NostalgicPlayer.Kit.Bases
{
	/// <summary>
	/// Base class that can be used for module player agents
	/// </summary>
	public abstract class ModulePlayerAgentBase : PlayerAgentBase, IModulePlayerAgent
	{
		private static readonly SubSongInfo subSongInfo = new SubSongInfo(1, 0);

		/// <summary>
		/// Holds the mixer frequency. It is only set if BufferMode is set in the SupportFlags.
		/// </summary>
		protected uint mixerFreq;

		/// <summary>
		/// Holds the number of channels to output. It is only set if BufferMode is set in the SupportFlags.
		/// </summary>
		protected int mixerChannels;

		/********************************************************************/
		/// <summary>
		/// Constructor
		/// </summary>
		/********************************************************************/
		protected ModulePlayerAgentBase()
		{
			VirtualChannels = null;
			PlayingFrequency = 50.0f;
		}



		/********************************************************************/
		/// <summary>
		/// Return some flags telling what the player supports
		/// </summary>
		/********************************************************************/
		public virtual ModulePlayerSupportFlag SupportFlags => ModulePlayerSupportFlag.None;



		/********************************************************************/
		/// <summary>
		/// Will load the file into memory
		/// </summary>
		/********************************************************************/
		public abstract AgentResult Load(PlayerFileInfo fileInfo, out string errorMessage);



		/********************************************************************/
		/// <summary>
		/// Initializes the player
		/// </summary>
		/********************************************************************/
		public virtual bool InitPlayer(out string errorMessage)
		{
			errorMessage = string.Empty;

			return true;
		}



		/********************************************************************/
		/// <summary>
		/// Cleanup the player
		/// </summary>
		/********************************************************************/
		public virtual void CleanupPlayer()
		{
		}



		/********************************************************************/
		/// <summary>
		/// Initializes the current song
		/// </summary>
		/********************************************************************/
		public virtual bool InitSound(int songNumber, DurationInfo durationInfo, out string errorMessage)
		{
			errorMessage = string.Empty;

			return true;
		}



		/********************************************************************/
		/// <summary>
		/// Cleanup the current song
		/// </summary>
		/********************************************************************/
		public virtual void CleanupSound()
		{
		}



		/********************************************************************/
		/// <summary>
		/// Calculate the duration for all sub-songs
		/// </summary>
		/********************************************************************/
		public virtual DurationInfo[] CalculateDuration()
		{
			return null;
		}



		/********************************************************************/
		/// <summary>
		/// Is only called if BufferMode is set in the SupportFlags. It tells
		/// your player what frequency the NostalgicPlayer mixer is using.
		/// You can use it if you want or you can use your own output
		/// frequency, but if you also using BufferDirect, you need to use
		/// this frequency and number of channels
		/// </summary>
		/********************************************************************/
		public virtual void SetOutputFormat(uint mixerFrequency, int channels)
		{
			mixerFreq = mixerFrequency;
			mixerChannels = channels;
		}



		/********************************************************************/
		/// <summary>
		/// This is the main player method
		/// </summary>
		/********************************************************************/
		public abstract void Play();



		/********************************************************************/
		/// <summary>
		/// Will add DSP effect to the mixed output
		/// </summary>
		/********************************************************************/
		public virtual void DoDspEffects(int[] dest, int todo, uint mixerFrequency, bool stereo)
		{
		}



		/********************************************************************/
		/// <summary>
		/// Return the number of channels the module want to reserve
		/// </summary>
		/********************************************************************/
		public virtual int VirtualChannelCount => ModuleChannelCount;



		/********************************************************************/
		/// <summary>
		/// Return the number of channels the module use
		/// </summary>
		/********************************************************************/
		public virtual int ModuleChannelCount => 4;



		/********************************************************************/
		/// <summary>
		/// Return information about sub-songs
		/// </summary>
		/********************************************************************/
		public virtual SubSongInfo SubSongs => subSongInfo;



		/********************************************************************/
		/// <summary>
		/// Return the length of the current song
		/// </summary>
		/********************************************************************/
		public virtual int SongLength => 0;



		/********************************************************************/
		/// <summary>
		/// Return the current position of the song
		/// </summary>
		/********************************************************************/
		public virtual int GetSongPosition()
		{
			return 0;
		}



		/********************************************************************/
		/// <summary>
		/// Set a new position of the song
		/// </summary>
		/********************************************************************/
		public virtual void SetSongPosition(int position, PositionInfo positionInfo)
		{
		}



		/********************************************************************/
		/// <summary>
		/// Returns all the instruments available in the module. If none,
		/// null is returned
		/// </summary>
		/********************************************************************/
		public virtual InstrumentInfo[] Instruments => null;



		/********************************************************************/
		/// <summary>
		/// Returns all the samples available in the module. If none, null
		/// is returned
		/// </summary>
		/********************************************************************/
		public virtual SampleInfo[] Samples => null;



		/********************************************************************/
		/// <summary>
		/// Holds all the virtual channel instances used to play the samples
		/// </summary>
		/********************************************************************/
		public virtual IChannel[] VirtualChannels
		{
			get; set;
		}



		/********************************************************************/
		/// <summary>
		/// Return the current playing frequency
		/// </summary>
		/********************************************************************/
		public virtual float PlayingFrequency
		{
			get; protected set;
		}



		/********************************************************************/
		/// <summary>
		/// Return the current state of the Amiga filter
		/// </summary>
		/********************************************************************/
		public bool AmigaFilter
		{
			get; protected set;
		} = false;



		/********************************************************************/
		/// <summary>
		/// Event called when the player change position
		/// </summary>
		/********************************************************************/
		public event EventHandler PositionChanged;

		#region Helper methods
		/********************************************************************/
		/// <summary>
		/// Call this every time your player change it's position
		/// </summary>
		/********************************************************************/
		protected void OnPositionChanged()
		{
			if (PositionChanged != null)
				PositionChanged(this, EventArgs.Empty);
		}



		/********************************************************************/
		/// <summary>
		/// Calculates the frequency to the BPM you give and change the
		/// playing speed
		/// </summary>
		/********************************************************************/
		protected void SetBpmTempo(ushort bpm)
		{
			PlayingFrequency = bpm / 2.5f;
		}
		#endregion

		#region Duration calculation helpers
		/********************************************************************/
		/// <summary>
		/// Calculate the duration of each sub-song. The sub-songs are found
		/// by using the same position array for all songs
		/// </summary>
		/********************************************************************/
		protected DurationInfo[] CalculateDurationBySongPosition(bool playerTellsWhenToStop = false)
		{
			List<DurationInfo> result = new List<DurationInfo>();

			int songStartPos = 0;
			DateTime startTime = DateTime.Now;

			do
			{
				songStartPos = InitDurationCalculationByStartPos(songStartPos);
				if (songStartPos < 0)
					break;

				int prevPos = -1;
				float total = 0.0f;

				byte currentSpeed = GetCurrentSpeed();
				ushort currentBpm = GetCurrentBpm();
				object extraInfo = GetExtraPositionInfo();

				List<PositionInfo> positionTimes = new List<PositionInfo>();

				// Well, fill the position time list with empty times until
				// we reach the sub-song position
				for (int i = 0; i < songStartPos; i++)
					positionTimes.Add(new PositionInfo(currentSpeed, currentBpm, new TimeSpan(0), extraInfo));

				HasEndReached = false;

				for (;;)
				{
					if (prevPos < GetSongPosition())
					{
						prevPos = GetSongPosition();

						// Add position information to the list
						PositionInfo posInfo = new PositionInfo(currentSpeed, currentBpm, new TimeSpan((long)total * TimeSpan.TicksPerMillisecond), extraInfo);

						// Need to make a while, in case there is a position jump
						// that jumps forward, then we're missing some items in the list
						while (prevPos >= positionTimes.Count)
							positionTimes.Add(posInfo);
					}

					// "Play" a single tick
					Play();

					// Update information
					currentSpeed = GetCurrentSpeed();
					currentBpm = GetCurrentBpm();
					extraInfo = GetExtraPositionInfo();

					if (HasEndReached)
						break;

					// Add the tick time
					total += 1000.0f / PlayingFrequency;

					// Check for time out
					if ((DateTime.Now - startTime).Seconds >= 5)
						throw new Exception(Resources.IDS_ERR_DURATION_TIMEOUT);
				}

				// Calculate the total time of the song
				TimeSpan totalTime = new TimeSpan((long)total * TimeSpan.TicksPerMillisecond);

				// Find new start position
				int newStartPosition = positionTimes.Count;

				// Fill the rest of the list with total time
				for (int i = positionTimes.Count; i < SongLength; i++)
					positionTimes.Add(new PositionInfo(currentSpeed, currentBpm, totalTime, extraInfo));

				// Remember the song
				result.Add(new DurationInfo(totalTime, positionTimes.ToArray(), songStartPos));

				songStartPos = newStartPosition;

				CleanupDurationCalculation();
			}
			while (playerTellsWhenToStop || (songStartPos < SongLength));

			// Clear the "end" flag again, so the module don't stop playing immediately
			HasEndReached = false;

			return result.ToArray();
		}



		/********************************************************************/
		/// <summary>
		/// Calculate the duration of each sub-song
		/// </summary>
		/********************************************************************/
		protected DurationInfo[] CalculateDurationBySubSongs()
		{
			List<DurationInfo> result = new List<DurationInfo>();

			int numSongs = SubSongs.Number;
			DateTime startTime = DateTime.Now;

			for (int song = 0; song < numSongs; song++)
			{
				InitDurationCalculationBySubSong(song);

				int prevPos = -1;
				float total = 0.0f;

				byte currentSpeed = GetCurrentSpeed();
				ushort currentBpm = GetCurrentBpm();
				object extraInfo = GetExtraPositionInfo();

				List<PositionInfo> positionTimes = new List<PositionInfo>();

				HasEndReached = false;

				for (;;)
				{
					if (prevPos < GetSongPosition())
					{
						prevPos = GetSongPosition();

						// Add position information to the list
						PositionInfo posInfo = new PositionInfo(currentSpeed, currentBpm, new TimeSpan((long)total * TimeSpan.TicksPerMillisecond), extraInfo);

						// Need to make a while, in case there is a position jump
						// that jumps forward, then we're missing some items in the list
						while (prevPos >= positionTimes.Count)
							positionTimes.Add(posInfo);
					}

					// "Play" a single tick
					Play();

					// Update information
					currentSpeed = GetCurrentSpeed();
					currentBpm = GetCurrentBpm();
					extraInfo = GetExtraPositionInfo();

					if (HasEndReached)
						break;

					// Add the tick time
					total += 1000.0f / PlayingFrequency;

					// Check for time out
					if ((DateTime.Now - startTime).Seconds >= 5)
						throw new Exception(Resources.IDS_ERR_DURATION_TIMEOUT);
				}

				// Calculate the total time of the song
				TimeSpan totalTime = new TimeSpan((long)total * TimeSpan.TicksPerMillisecond);

				// Fill the rest of the list with total time
				for (int i = positionTimes.Count; i < SongLength; i++)
					positionTimes.Add(new PositionInfo(currentSpeed, currentBpm, totalTime, extraInfo));

				// Remember the song
				result.Add(new DurationInfo(totalTime, positionTimes.ToArray(), 0));

				CleanupDurationCalculation();
			}

			// Clear the "end" flag again, so the module don't stop playing immediately
			HasEndReached = false;

			return result.ToArray();
		}



		/********************************************************************/
		/// <summary>
		/// Initialize all internal structures when beginning duration
		/// calculation on a new sub-song
		/// </summary>
		/********************************************************************/
		protected virtual int InitDurationCalculationByStartPos(int startPosition)
		{
			return startPosition;
		}



		/********************************************************************/
		/// <summary>
		/// Initialize all internal structures when beginning duration
		/// calculation on a new sub-song
		/// </summary>
		/********************************************************************/
		protected virtual void InitDurationCalculationBySubSong(int subSong)
		{
		}



		/********************************************************************/
		/// <summary>
		/// Cleanup needed stuff after a sub-song calculation
		/// </summary>
		/********************************************************************/
		protected virtual void CleanupDurationCalculation()
		{
		}



		/********************************************************************/
		/// <summary>
		/// Return the current speed
		/// </summary>
		/********************************************************************/
		protected virtual byte GetCurrentSpeed()
		{
			return 6;
		}



		/********************************************************************/
		/// <summary>
		/// Return the current BPM
		/// </summary>
		/********************************************************************/
		protected virtual ushort GetCurrentBpm()
		{
			return 125;
		}



		/********************************************************************/
		/// <summary>
		/// Return extra information for the current position
		/// </summary>
		/********************************************************************/
		protected virtual object GetExtraPositionInfo()
		{
			return null;
		}
		#endregion
	}
}
