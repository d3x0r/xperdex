using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FantasyFighterArena
{
	public static class FantasyArenaList
	{
		static List<FantasyArena> arenas = new List<FantasyArena>();

		public static String[] GetNames()
		{
			String[] names = new String[arenas.Count];
			int n = 0;
			foreach( FantasyArena arena in arenas )
				names[n++] = arena.name;
			return names;
		}

		public static FantasyArena JoinArena( FantasyFighterPlayer fighter, string name )
		{
			FantasyArena arena = GetArena( name );
			if( arena != null )
			{
				arena.Add( fighter );
				FantasyServer.lobby_fighters.Remove( fighter );
			}
			return arena;
		}

		public static FantasyArena GetArena( string name )
		{
			if( arenas == null )
			{
				arenas = new List<FantasyArena>();
			}
			foreach( FantasyArena arena in arenas )
			{
				if( arena.name == name )
					return arena;
			}
			return null;
		}

		internal static FantasyArena CreateArena( string name )
		{
			FantasyArena arena = GetArena( name );
			if( arena == null )
			{
				arena = new FantasyArena( name );
				arenas.Add( arena );
			}
			return arena;
		}
	}
}
