using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FantasyFighterArena
{
	public static class FantasyServer
	{
		public static LinkedList<FantasyFighterPlayer> fighters = new LinkedList<FantasyFighterPlayer>();
		public static LinkedList<FantasyFighterPlayer> lobby_fighters = new LinkedList<FantasyFighterPlayer>();
	}
}
