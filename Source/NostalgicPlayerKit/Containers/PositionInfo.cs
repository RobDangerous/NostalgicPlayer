﻿/******************************************************************************/
/* This source, or parts thereof, may be used in any software as long the     */
/* license of NostalgicPlayer is keep. See the LICENSE file for more          */
/* information.                                                               */
/******************************************************************************/
using System;

namespace Polycode.NostalgicPlayer.Kit.Containers
{
	/// <summary>
	/// Holds information about a single position
	/// </summary>
	public class PositionInfo
	{
		/********************************************************************/
		/// <summary>
		/// Constructor (used by module players)
		/// </summary>
		/********************************************************************/
		public PositionInfo(byte speed, ushort bpm, TimeSpan time, int subSong, object extra = null)
		{
			Speed = speed;
			Bpm = bpm;
			Time = time;
			SubSong = subSong;
			ExtraInfo = extra;
		}



		/********************************************************************/
		/// <summary>
		/// Constructor (used by sample players)
		/// </summary>
		/********************************************************************/
		public PositionInfo(TimeSpan time, object extra = null)
		{
			Time = time;
			ExtraInfo = extra;
		}



		/********************************************************************/
		/// <summary>
		/// Holds the speed at the current position
		/// </summary>
		/********************************************************************/
		public byte Speed
		{
			get;
		}



		/********************************************************************/
		/// <summary>
		/// Holds the BPM at the current position
		/// </summary>
		/********************************************************************/
		public ushort Bpm
		{
			get;
		}



		/********************************************************************/
		/// <summary>
		/// Holds the time at the current position
		/// </summary>
		/********************************************************************/
		public TimeSpan Time
		{
			get;
		}



		/********************************************************************/
		/// <summary>
		/// Holds the current sub-song
		/// </summary>
		/********************************************************************/
		public int SubSong
		{
			get;
		}



		/********************************************************************/
		/// <summary>
		/// Holds some extra information if needed
		/// </summary>
		/********************************************************************/
		public object ExtraInfo
		{
			get;
		}
	}
}
