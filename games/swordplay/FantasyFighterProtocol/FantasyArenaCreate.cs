using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FantasyFighterProtocol
{
	[Serializable]
	public class FantasyArenaCreate: MessageCommon
	{
		public string arena_name;
		public FantasyArenaCreate( string name )
		{
			arena_name = name;
			this.message_type = FantasyFighterMessage.CreateArena;
		}
	}

	[Serializable]
	public class FantasyArenaJoin : MessageCommon
	{
		public string arena_name;
		public FantasyArenaJoin( string name )
		{
			arena_name = name;
			this.message_type = FantasyFighterMessage.JoinArena;
		}
	}
}
