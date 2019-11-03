using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FantasyFighterProtocol
{
	[Serializable]
	public class FantasyLoginMessage : MessageCommon
	{
		public string username;

		public FantasyLoginMessage( string username )
		{
			message_type = FantasyFighterMessage.Login;
			this.username = username;
		}
	}
}
