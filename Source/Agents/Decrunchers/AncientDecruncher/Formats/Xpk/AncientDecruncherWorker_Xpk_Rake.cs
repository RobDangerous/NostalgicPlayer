﻿/******************************************************************************/
/* This source, or parts thereof, may be used in any software as long the     */
/* license of NostalgicPlayer is keep. See the LICENSE file for more          */
/* information.                                                               */
/*                                                                            */
/* Copyright (C) 2021-2022 by Polycode / NostalgicPlayer team.                */
/* All rights reserved.                                                       */
/******************************************************************************/
using System.IO;
using Polycode.NostalgicPlayer.Agent.Decruncher.AncientDecruncher.Formats.Streams.Xpk;
using Polycode.NostalgicPlayer.Kit.Streams;

namespace Polycode.NostalgicPlayer.Agent.Decruncher.AncientDecruncher.Formats.Xpk
{
	/// <summary>
	/// Can decrunch XPK (RAKE) crunched files
	/// </summary>
	internal class AncientDecruncherWorker_Xpk_Rake : AncientDecruncherWorker_Xpk
	{
		/********************************************************************/
		/// <summary>
		/// Constructor
		/// </summary>
		/********************************************************************/
		public AncientDecruncherWorker_Xpk_Rake(string agentName) : base(agentName)
		{
		}



		/********************************************************************/
		/// <summary>
		/// Return a stream holding the decrunched data
		/// </summary>
		/********************************************************************/
		public override DecruncherStream OpenStream(Stream crunchedDataStream)
		{
			return new Xpk_RakeStream(agentName, crunchedDataStream);
		}



		/********************************************************************/
		/// <summary>
		/// Return the cruncher ID
		/// </summary>
		/********************************************************************/
		protected override uint CruncherId => 0x52414b45;		// RAKE
	}
}
