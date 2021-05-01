﻿/******************************************************************************/
/* This source, or parts thereof, may be used in any software as long the     */
/* license of NostalgicPlayer is keep. See the LICENSE file for more          */
/* information.                                                               */
/*                                                                            */
/* Copyright (C) 2021 by Polycode / NostalgicPlayer team.                     */
/* All rights reserved.                                                       */
/******************************************************************************/
using System.IO;
using Polycode.NostalgicPlayer.Kit.Interfaces;
using Polycode.NostalgicPlayer.Kit.Streams;

namespace Polycode.NostalgicPlayer.PlayerLibrary.Players
{
	/// <summary>
	/// Helper class for loader implementations
	/// </summary>
	public abstract class FileLoaderBase : ILoader
	{
		private readonly string fileName;

		/********************************************************************/
		/// <summary>
		/// Constructor
		/// </summary>
		/********************************************************************/
		protected FileLoaderBase(string fileName)
		{
			this.fileName = fileName;
		}



		/********************************************************************/
		/// <summary>
		/// Will try to open the file given
		/// </summary>
		/********************************************************************/
		public Stream OpenFile()
		{
			return OpenFile(fileName);
		}



		/********************************************************************/
		/// <summary>
		/// Will try to open a file with the same name as the current module,
		/// but with a different extension. It will also try to use the
		/// extension as a prefix. You need to dispose the returned stream
		/// when done
		/// </summary>
		/********************************************************************/
		public ModuleStream OpenExtraFile(string newExtension)
		{
			if (string.IsNullOrEmpty(newExtension))
				return null;

			// First change the extension
			string newFileName = Path.ChangeExtension(fileName, newExtension);
			Stream stream = OpenFile(newFileName);
			if (stream == null)
			{
				// Now try to append the extension
				newFileName = fileName + $".{newExtension}";
				stream = OpenFile(newFileName);
				if (stream == null)
				{
					// Try with prefix
					string directory = Path.GetDirectoryName(fileName);
					string name = Path.GetFileName(fileName);

					int index = name.IndexOf('.');
					if (index != -1)
					{
						name = name.Substring(index + 1);

						newFileName = Path.Combine(directory, $"{newExtension}.{name}");
						stream = OpenFile(newFileName);
					}
				}
			}

			return stream != null ? new ModuleStream(stream, false) : null;
		}



		/********************************************************************/
		/// <summary>
		/// Return the full path to the file
		/// </summary>
		/********************************************************************/
		public virtual string FullPath => fileName;



		/********************************************************************/
		/// <summary>
		/// Will try to open the file given
		/// </summary>
		/********************************************************************/
		protected abstract Stream OpenFile(string fileName);
	}
}
