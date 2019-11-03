using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FantasyFighterProtocol
{
	[Serializable]
	public class FantasyArenaRequest : MessageCommon
	{

		public FantasyArenaRequest()
		{
			this.message_type = FantasyFighterMessage.ListArenas;
		}
	}
}
