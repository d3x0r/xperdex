using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FantasyFighterProtocol
{
	[Serializable]
	public class FantasyFighterStance : MessageCommon
	{
		public FighterStates.Stance stance;
		public Guid id;
		public FantasyFighterStance( FighterStates.Stance s )
		{
			message_type = FantasyFighterMessage.ChangeStance;
			stance = s;
			id = Guid.Empty;
		}

		public FantasyFighterStance( Guid ID, FighterStates.Stance s )
		{
			message_type = FantasyFighterMessage.ChangeStance;
			stance = s;
			id = ID;
		}

	}
}
