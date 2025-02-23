﻿/******************************************************************************/
/* This source, or parts thereof, may be used in any software as long the     */
/* license of NostalgicPlayer is keep. See the LICENSE file for more          */
/* information.                                                               */
/******************************************************************************/
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Polycode.NostalgicPlayer.Agent.SampleConverter.Flac.LibFlac.Private;

namespace Polycode.NostalgicPlayer.Agent.Player.Flac.Test.LibFlac
{
	/// <summary>
	/// 
	/// </summary>
	[TestClass]
	public class TestMd5
	{
		private static readonly Flac__byte[,][] target_Digests =
		{
			// 1 channel
			{
				// 1 byte per sample
				new Flac__byte[] { 0xc1, 0x9a, 0x5b, 0xeb, 0x57, 0x8f, 0x26, 0xeb, 0xfb, 0x34, 0x7c, 0xef, 0x04, 0x31, 0x6d, 0x7d },
				// 2 bytes per sample
				new Flac__byte[] { 0xd4, 0x78, 0x90, 0xd3, 0xa9, 0x17, 0x4e, 0x76, 0xca, 0x4d, 0x27, 0x20, 0x98, 0x36, 0x8b, 0x2e },
				// 3 bytes per sample
				new Flac__byte[] { 0x5a, 0x4b, 0xd6, 0xac, 0xa1, 0x70, 0x84, 0x19, 0x7c, 0x0d, 0xfb, 0x5b, 0xa9, 0x7b, 0xcb, 0x54 },
				// 4 bytes per sample
				new Flac__byte[] { 0x79, 0xd5, 0x7a, 0x32, 0x06, 0x0b, 0xfe, 0x46, 0xa3, 0xe7, 0xba, 0xc5, 0xf7, 0x48, 0x6f, 0x50 }
			},

			// 2 channels
			{
				new Flac__byte[] { 0x89, 0xac, 0xcf, 0x91, 0xf1, 0x8c, 0xea, 0xab, 0x46, 0x12, 0x74, 0xbc, 0x4e, 0x82, 0xbe, 0x7d },
				new Flac__byte[] { 0xb9, 0x17, 0x16, 0x5b, 0xd8, 0x1c, 0xc8, 0x4e, 0x5a, 0x28, 0xfb, 0xba, 0x87, 0x74, 0x76, 0x44 },
				new Flac__byte[] { 0xec, 0x63, 0x92, 0xca, 0x4f, 0x6b, 0x9e, 0xb1, 0x9f, 0xec, 0x3b, 0x2c, 0x15, 0x30, 0xfd, 0x2a },
				new Flac__byte[] { 0x05, 0x4d, 0xfd, 0xb8, 0x9d, 0x8a, 0xa2, 0xdd, 0x26, 0x47, 0xc6, 0xfb, 0x4f, 0x23, 0x67, 0x6d }
			},

			// 3 channels
			{
				new Flac__byte[] { 0xad, 0x05, 0xda, 0xf3, 0x7a, 0xa1, 0x94, 0xdb, 0x0c, 0x61, 0x06, 0xb2, 0x94, 0x39, 0x6c, 0xa9 },
				new Flac__byte[] { 0x8b, 0xcc, 0x41, 0x4d, 0xe9, 0xe3, 0xc2, 0x61, 0x61, 0x8a, 0x8b, 0x22, 0xc6, 0x4e, 0xac, 0xa7 },
				new Flac__byte[] { 0x8a, 0xce, 0x97, 0xc1, 0x86, 0xae, 0xbc, 0x73, 0x88, 0x8b, 0x35, 0x5a, 0x37, 0x33, 0xf9, 0xcf },
				new Flac__byte[] { 0x69, 0x59, 0xe8, 0x38, 0x29, 0x80, 0x80, 0x21, 0xb1, 0xd2, 0xba, 0xf6, 0x28, 0xd6, 0x6a, 0x83 }
			},

			// 4 channels
			{
				new Flac__byte[] { 0x61, 0x40, 0x75, 0xef, 0x22, 0xf1, 0x0f, 0xa6, 0x08, 0x6c, 0x88, 0xff, 0x2c, 0x4e, 0x98, 0x0b },
				new Flac__byte[] { 0xa0, 0x77, 0x3a, 0x59, 0x4a, 0xbf, 0xd0, 0x5c, 0xcc, 0xe3, 0xb9, 0x83, 0x2b, 0xf3, 0xdf, 0x1a },
				new Flac__byte[] { 0xdb, 0xd7, 0xf1, 0x82, 0x13, 0x60, 0x42, 0x7c, 0x84, 0xe6, 0xcf, 0x30, 0xab, 0xa2, 0x64, 0xf1 },
				new Flac__byte[] { 0x4a, 0x9a, 0xad, 0x53, 0x05, 0x74, 0xb1, 0x1c, 0xb8, 0xd4, 0xae, 0x78, 0x13, 0xf6, 0x2a, 0x11 }
			},

			// 5 channels
			{
				new Flac__byte[] { 0xcc, 0xca, 0x44, 0xc0, 0x54, 0xe2, 0xc9, 0xba, 0x99, 0x32, 0xc9, 0x65, 0xf3, 0x3e, 0x44, 0x34},
				new Flac__byte[] { 0x40, 0x38, 0x6a, 0xdd, 0xde, 0x89, 0x10, 0x3c, 0x8e, 0xec, 0xdf, 0x15, 0x53, 0x4c, 0x2c, 0x92 },
				new Flac__byte[] { 0xc8, 0x95, 0x0a, 0x7c, 0x17, 0x30, 0xc0, 0xac, 0x8e, 0x34, 0xdb, 0x79, 0x76, 0x64, 0x7c, 0x6e },
				new Flac__byte[] { 0x3f, 0x06, 0x11, 0x8a, 0x8d, 0x80, 0xb5, 0x4f, 0x8b, 0xb5, 0x8e, 0xb3, 0x27, 0x3e, 0x41, 0xe8 }
			},

			// 6 channels
			{
				new Flac__byte[] { 0x61, 0xe4, 0xbd, 0xb1, 0xc0, 0x2f, 0xf4, 0x4c, 0x6e, 0x09, 0x5a, 0xbd, 0x90, 0x18, 0x8b, 0x62 },
				new Flac__byte[] { 0x47, 0xe7, 0x6e, 0x3b, 0x18, 0x86, 0x60, 0x1b, 0x09, 0x62, 0xc6, 0xc9, 0x7c, 0x4c, 0x03, 0xb5 },
				new Flac__byte[] { 0x70, 0x57, 0xbf, 0x67, 0x66, 0x0f, 0xe3, 0x0a, 0x6c, 0xd2, 0x97, 0x66, 0xa2, 0xd2, 0xe4, 0x79 },
				new Flac__byte[] { 0xaa, 0x3f, 0xc7, 0xf5, 0x7a, 0xa5, 0x46, 0xf7, 0xea, 0xe3, 0xd5, 0x1a, 0xa4, 0x62, 0xbe, 0xfa }
			},

			// 7 channels
			{
				new Flac__byte[] { 0x7c, 0x8d, 0xd2, 0x8c, 0xfd, 0x91, 0xbb, 0x77, 0x6f, 0x0e, 0xf0, 0x39, 0x1f, 0x39, 0xc4, 0xac },
				new Flac__byte[] { 0xfb, 0xab, 0x18, 0x3f, 0x1e, 0x1d, 0xa5, 0x77, 0xe0, 0x5c, 0xea, 0x45, 0x6f, 0x64, 0xa4, 0x64 },
				new Flac__byte[] { 0xe3, 0xac, 0x33, 0x50, 0xc1, 0xb1, 0x93, 0xfb, 0xca, 0x4b, 0x15, 0xcb, 0x2d, 0xcd, 0xd5, 0xef },
				new Flac__byte[] { 0x10, 0xfb, 0x02, 0x83, 0x76, 0x0d, 0xe5, 0xd2, 0x3b, 0xb1, 0x4c, 0x78, 0x3b, 0x73, 0xf7, 0x1a }
			},

			// 8 channels
			{
				new Flac__byte[] { 0x65, 0x7b, 0xe5, 0x92, 0xe2, 0x1c, 0x95, 0x3e, 0xd7, 0x2f, 0x64, 0xa0, 0x86, 0xec, 0x1a, 0xed },
				new Flac__byte[] { 0x9d, 0x04, 0x8f, 0xa4, 0xea, 0x10, 0xec, 0xb8, 0xa3, 0x88, 0xe2, 0x5d, 0x3c, 0xe2, 0xfb, 0x94 },
				new Flac__byte[] { 0x5a, 0xd3, 0xd2, 0x75, 0x6a, 0xfa, 0xa7, 0x42, 0xf3, 0xbf, 0x0e, 0xbc, 0x90, 0x2a, 0xf8, 0x5f },
				new Flac__byte[] { 0x76, 0xe1, 0xe5, 0xf6, 0xe3, 0x44, 0x08, 0x29, 0xae, 0x79, 0x19, 0xeb, 0xa8, 0x57, 0x16, 0x2a }
			}
		};

		/********************************************************************/
		/// <summary>
		/// 
		/// </summary>
		/********************************************************************/
		[TestMethod]
		public void Test_Md5_No_Data()
		{
			Flac__byte[] target = { 0xd4, 0x1d, 0x8c, 0xd9, 0x8f, 0x00, 0xb2, 0x04, 0xe9, 0x80, 0x09, 0x98, 0xec, 0xf8, 0x42, 0x7e };

			Md5 md5 = new Md5();
			Flac__byte[] digest = md5.Flac__Md5Final();
			CollectionAssert.AreEqual(target, digest);
		}



		/********************************************************************/
		/// <summary>
		/// 
		/// </summary>
		/********************************************************************/
		[TestMethod]
		public void Test_Md5_Codec()
		{
			const int Max_Channel_Count = 8;
			const int Md5_Sample_Count = 64;

			Flac__int32[][] arrays = new Flac__int32[Max_Channel_Count][];
			uint32_t seed = 0x12345679;

			// Setup signal data using a trivial Linear Congruent PRNG
			for (uint32_t chan = 0; chan < Max_Channel_Count; chan++)
			{
				arrays[chan] = new int[Md5_Sample_Count];

				for (uint32_t k = 0; k < Md5_Sample_Count; k++)
				{
					seed = seed * 1103515245 + 12345;
					arrays[chan][k] = (Flac__int32)seed;
				}
			}

			for (uint32_t chan = 1; chan <= Max_Channel_Count; chan++)
			{
				for (uint32_t byte_Size = 1; byte_Size <= 4; byte_Size++)
					Md5_Accumulate(arrays, chan, Md5_Sample_Count, byte_Size, target_Digests[chan - 1, byte_Size - 1]);
			}
		}

		#region Private methods
		/********************************************************************/
		/// <summary>
		/// 
		/// </summary>
		/********************************************************************/
		private void Md5_Accumulate(Flac__int32[][] signal, uint32_t channels, uint32_t samples, uint32_t bytes_Per_Sample, Flac__byte[] target_Digest)
		{
			Console.WriteLine($"Testing MD5Accumulate (samples={samples}, channels={channels}, bytes_per_sample={bytes_Per_Sample})");

			Md5 md5 = new Md5();
			md5.Flac__Md5Accumulate(signal, channels, samples, bytes_Per_Sample);
			Flac__byte[] digest = md5.Flac__Md5Final();
			CollectionAssert.AreEqual(target_Digest, digest);
		}
		#endregion
	}
}
