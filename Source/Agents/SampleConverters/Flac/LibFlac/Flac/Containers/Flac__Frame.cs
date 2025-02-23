﻿/******************************************************************************/
/* This source, or parts thereof, may be used in any software as long the     */
/* license of NostalgicPlayer is keep. See the LICENSE file for more          */
/* information.                                                               */
/******************************************************************************/
using Polycode.NostalgicPlayer.Kit.Utility;

namespace Polycode.NostalgicPlayer.Agent.SampleConverter.Flac.LibFlac.Flac.Containers
{
	/// <summary>
	/// FLAC frame structure
	/// </summary>
	internal class Flac__Frame
	{
		public Flac__FrameHeader Header = new Flac__FrameHeader();
		public Flac__SubFrame[] SubFrames = ArrayHelper.InitializeArray<Flac__SubFrame>((int)Constants.Flac__Max_Channels);
		public Flac__FrameFooter Footer = new Flac__FrameFooter();
	}
}
