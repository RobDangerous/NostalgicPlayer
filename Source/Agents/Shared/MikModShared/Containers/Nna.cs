﻿/******************************************************************************/
/* This source, or parts thereof, may be used in any software as long the     */
/* license of NostalgicPlayer is keep. See the LICENSE file for more          */
/* information.                                                               */
/******************************************************************************/
namespace Polycode.NostalgicPlayer.Agent.Shared.MikMod.Containers
{
	/// <summary>
	/// New note action flags (NNA_)
	/// </summary>
	public enum Nna : byte
	{
		/// <summary></summary>
		Cut = 0,
		/// <summary></summary>
		Continue,
		/// <summary></summary>
		Off,
		/// <summary></summary>
		Fade,

		/// <summary></summary>
		Mask = 3
	}
}
