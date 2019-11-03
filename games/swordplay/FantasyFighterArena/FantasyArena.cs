using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FantasyFighterArena
{
	public class FantasyArena : List<FantasyFighterPlayer>
	{
		internal string name;

		public FantasyArena()
		{
		}

		public FantasyArena( string name )
		{
			// TODO: Complete member initialization
			this.name = name;
		}

		public void NotifyPeers( FantasyFighterPlayer fa )
		{
			foreach( FantasyFighterPlayer fighter in this )
			{
				if( fighter == fa )
					continue;
				fighter.PlayerChangedWeapon( fa );

			}
		}

	}
}
