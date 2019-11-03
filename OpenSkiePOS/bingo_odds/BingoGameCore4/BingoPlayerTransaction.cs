using System;
using System.Collections.Generic;

namespace BingoGameCore4
{
	public class PlayerTransaction : List<PlayerPack>
	{
		public int transnum;
		public Guid ID;
		public List<bool> loaded;  // we might have a transaction reference but not have loaded appropriate info.
		public BingoPlayer player;
		public PlayerTransaction( BingoPlayer player, int transnum )
		{
			this.player = player;
			this.transnum = transnum;
			this.ID = Guid.NewGuid();
			loaded = new List<bool>();
		}

	}
}
