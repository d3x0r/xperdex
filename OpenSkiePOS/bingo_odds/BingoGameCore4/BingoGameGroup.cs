using System;
using System.Collections.Generic;

namespace BingoGameCore4
{
	public class BingoGameGroup: List<BingoGame>
	{
        public List<BingoPrize> prizes;
		public List<BingoPack> packs;
		public object ID;
		public string name;
		public Guid pack_set_id;
		public int game_group_ID;
		/// <summary>
		/// This is a temporary set during SessionEvent.Step, and used during play
		/// </summary>
		public Guid group_pack_set_id;
		public BingoGameGroup( object id )
		{
			packs = new List<BingoPack>();
			ID = id;
		}
		public override string ToString()
		{
			return name + " has " + this.Count + " games";
		}
		public BingoPrize GetPrize( object key )
		{
			if( prizes == null )
				prizes = new List<BingoPrize>();
			foreach( BingoPrize prize in prizes )
			{
				if( prize.level.Equals( key ) )
					return prize;
			}
			{
				BingoPrize prize;
				prizes.Add( prize = new BingoPrize( key, 0 ) );
				return prize;
			}
		}
	}
}
