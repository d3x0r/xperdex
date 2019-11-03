using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FantasyFighterArena;

namespace FantasyFighter
{
	public class FantasyArena : List<FighterState>
	{

		public FighterState GetFighter( Guid id )
		{
			foreach( FighterState fighter in this )
			{
				if( fighter.ID == id )
					return fighter;
			}
			return null;
		}
	}
}
