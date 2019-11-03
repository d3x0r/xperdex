using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FantasyFighterProtocol;

namespace FantasyFighterArena
{
	public class FighterState
	{
		public String name;
		public Guid ID;
		public FighterStates.Stance stance;
		public FighterStates.WieldedWeapon weapon;


		public override string ToString()
		{
			return name;
		}
		public static implicit operator Guid( FighterState fighter )
		{
			return fighter.ID;
		}

	}
}
