using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FantasyFighterArena;

namespace FantasyFighterProtocol
{
	[Serializable]
	public class FantasyArenaList : MessageCommon
	{
		public String[] arenas;
		public FantasyArenaList( String[] arenas )
		{
			this.arenas = arenas;
			this.message_type = FantasyFighterMessage.ArenaList;
		}
	}
	[Serializable]
	public class FantasyArenaAdded : MessageCommon
	{
		public String arenas;
		public FantasyArenaAdded( String arenas )
		{
			this.arenas = arenas;
			this.message_type = FantasyFighterMessage.ArenaAdded;
		}
	}


	[Serializable]
	public class FantasyArenaJoined : MessageCommon
	{
		public String arena;
		public FantasyArenaJoined( String arenas )
		{
			this.arena = arenas;
			this.message_type = FantasyFighterMessage.ArenaJoined;
		}
	}


	[Serializable]
	public class FantasyPlayerList : MessageCommon
	{
		public FighterState[] fighters;
		public FantasyPlayerList( FighterState[] fighters )
		{
			this.fighters = fighters;
			this.message_type = FantasyFighterMessage.FighterList;
		}
	}

}
