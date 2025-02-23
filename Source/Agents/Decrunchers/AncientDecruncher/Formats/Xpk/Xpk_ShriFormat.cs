﻿/******************************************************************************/
/* This source, or parts thereof, may be used in any software as long the     */
/* license of NostalgicPlayer is keep. See the LICENSE file for more          */
/* information.                                                               */
/******************************************************************************/
using System.IO;
using Polycode.NostalgicPlayer.Agent.Decruncher.AncientDecruncher.Formats.Streams.Xpk;
using Polycode.NostalgicPlayer.Kit.Streams;

namespace Polycode.NostalgicPlayer.Agent.Decruncher.AncientDecruncher.Formats.Xpk
{
	/// <summary>
	/// Can decrunch XPK (SHRI) crunched files
	/// </summary>
	internal class Xpk_ShriFormat : XpkFormatBase
	{
		/********************************************************************/
		/// <summary>
		/// Constructor
		/// </summary>
		/********************************************************************/
		public Xpk_ShriFormat(string agentName) : base(agentName)
		{
		}



		/********************************************************************/
		/// <summary>
		/// Return a stream holding the decrunched data
		/// </summary>
		/********************************************************************/
		public override DecruncherStream OpenStream(Stream crunchedDataStream)
		{
			return new Xpk_ShriStream(agentName, crunchedDataStream);
		}



		/********************************************************************/
		/// <summary>
		/// Return the cruncher ID
		/// </summary>
		/********************************************************************/
		protected override uint CruncherId => 0x53485249;		// SHRI
	}
}
