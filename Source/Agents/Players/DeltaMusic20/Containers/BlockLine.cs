﻿/******************************************************************************/
/* This source, or parts thereof, may be used in any software as long the     */
/* license of NostalgicPlayer is keep. See the LICENSE file for more          */
/* information.                                                               */
/******************************************************************************/
namespace Polycode.NostalgicPlayer.Agent.Player.DeltaMusic20.Containers
{
	/// <summary>
	/// Holds information about a single block line
	/// </summary>
	internal class BlockLine
	{
		public byte Note;
		public byte Instrument;
		public Effect Effect;
		public byte EffectArg;
	}
}