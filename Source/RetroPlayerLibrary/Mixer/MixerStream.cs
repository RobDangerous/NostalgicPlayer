﻿/******************************************************************************/
/* This source, or parts thereof, may be used in any software as long the     */
/* license of RetroPlayer is keep. See the LICENSE file for more information. */
/*                                                                            */
/* Copyright (C) 2021 by Polycode / RetroPlayer team.                         */
/* All rights reserved.                                                       */
/******************************************************************************/
using System;
using Polycode.RetroPlayer.RetroPlayerKit.Containers;
using Polycode.RetroPlayer.RetroPlayerKit.Streams;
using Polycode.RetroPlayer.RetroPlayerLibrary.Containers;

namespace Polycode.RetroPlayer.RetroPlayerLibrary.Mixer
{
	/// <summary>
	/// This stream do the playing of the modules and mix the channels
	/// </summary>
	internal class MixerStream : SoundStream
	{
		private int bytesPerSampling;

		private Mixer mixer;

		/********************************************************************/
		/// <summary>
		/// Initialize the stream
		/// </summary>
		/********************************************************************/
		public bool Initialize(PlayerConfiguration playerConfiguration, out string errorMessage)
		{
			mixer = new Mixer();
			return mixer.InitMixer(playerConfiguration, out errorMessage);
		}



		/********************************************************************/
		/// <summary>
		/// Cleanup the stream
		/// </summary>
		/********************************************************************/
		public void Cleanup()
		{
			mixer?.CleanupMixer();
			mixer = null;
		}



		/********************************************************************/
		/// <summary>
		/// Set the output format
		/// </summary>
		/********************************************************************/
		public override void SetOutputFormat(OutputInfo outputInformation)
		{
			bytesPerSampling = outputInformation.BytesPerSample;

			mixer.SetOutputFormat(outputInformation);
		}



		/********************************************************************/
		/// <summary>
		/// Start the playing
		/// </summary>
		/********************************************************************/
		public override void Start()
		{
			mixer.StartMixer();
		}



		/********************************************************************/
		/// <summary>
		/// Stop the playing
		/// </summary>
		/********************************************************************/
		public override void Stop()
		{
			mixer.StopMixer();
		}



		/********************************************************************/
		/// <summary>
		/// Read mixed data
		/// </summary>
		/********************************************************************/
		
		public override int Read(byte[] buffer, int offset, int count)
		{
			try
			{
				int samplesMixed = mixer.Mixing(buffer, offset, count / bytesPerSampling);
				return samplesMixed * bytesPerSampling;
			}
			catch(Exception)
			{
				return 0;
			}
		}
	}
}
