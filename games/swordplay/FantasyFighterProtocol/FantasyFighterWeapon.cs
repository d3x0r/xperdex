using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FantasyFighterProtocol
{
	[Serializable]
	public class FantasyFighterWeapon : MessageCommon
	{
		public FighterStates.WieldedWeapon weapon;
		public Guid   id;
		public FantasyFighterWeapon( FighterStates.WieldedWeapon w )
		{
			message_type = FantasyFighterMessage.ChangeWeapon;
			weapon = w;
			id = Guid.Empty;
		}
		public FantasyFighterWeapon( Guid player_id, FighterStates.WieldedWeapon w )
		{
			message_type = FantasyFighterMessage.ChangeWeapon;
			this.id = player_id;
			weapon = w;
		}

	}
}
