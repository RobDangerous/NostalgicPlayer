﻿/******************************************************************************/
/* This source, or parts thereof, may be used in any software as long the     */
/* license of RetroPlayer is keep. See the LICENSE file for more information. */
/*                                                                            */
/* Copyright (C) 2021 by Polycode / RetroPlayer team.                         */
/* All rights reserved.                                                       */
/******************************************************************************/
using Polycode.RetroPlayer.RetroPlayerKit.Containers;
using Polycode.RetroPlayer.RetroPlayerKit.Interfaces;
using Polycode.RetroPlayer.RetroPlayerLibrary.Agent;

namespace Polycode.RetroPlayer.RetroPlayerLibrary.Players
{
	/// <summary>
	/// Factory class to create the right player based on the data given
	/// </summary>
	public static class PlayerFactory
	{
		/********************************************************************/
		/// <summary>
		/// Will search all players to see if a match could be found based
		/// on the data given.
		///
		/// This method takes ownership of the stream, so it will be closed
		/// when needed, even if no player could be found
		/// </summary>
		/********************************************************************/
		public static IPlayer FindPlayer(PlayerFileInfo fileInfo, Manager agentManager)
		{
			IAgent[] allPlayers = agentManager.GetAllAgents(Manager.AgentType.Players);

			foreach (IAgent agent in allPlayers)
			{
				IPlayerAgent player = agent.CreateInstance() as IPlayerAgent;
				if (player != null)
				{
					AgentResult result = player.Identify(fileInfo);
					if (result == AgentResult.Ok)
					{

					}
				}
			}
			return new ModulePlayer();
		}
	}
}
