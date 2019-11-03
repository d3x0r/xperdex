using System.Collections.Generic;
using xperdex.classes;

namespace BingoGameCore4
{
	public class BingoPrize
	{
		public object level;
		public Money amount;
		public BingoPrize( object level_id, Money amount )
		{
			this.level = level_id;
			this.amount = amount;

		}
		public static void ComputePrizes( BingoGameEvent game_event, BingoGame game, List<wininfo> winners )
		{
			foreach( wininfo winner in winners )
			{
				foreach( BingoPrize prize in winner.prize_levels )
				{
					int total = 0;
					foreach( wininfo winner_with_prize in winners )
					{
						if( winner == winner_with_prize )
							continue;
						foreach( BingoPrize winner2_prize in winner.prize_levels )
						{
							if( winner2_prize.level.Equals( prize.level ) )
							{
								total++;
								break;
							}
						}
					}
					long change;
					long value = prize.amount / total;

					if( ( change = value % 100 ) > 0 )
					{
						value += 100;
						value -= change;
					}
					winner.amount += value;
					
				}
			}
		}
	}
}
