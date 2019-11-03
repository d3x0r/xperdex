using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xperdex.classes;
using OpenSkieScheduler3.BingoGameDefs;

namespace BingoCardsetCreator
{
    public class BingoCardset
    {
		public class BingoCard
		{
			byte[,,,] cardset_data;
			//public static void SetCard( int card, byte[,,] card_data );
		}

		byte[, , ,] data;

        public static void SaveFile( String filename )
        {

        }

		public void StoreCards( OpenSkieScheduler3.ScheduleDataSet schedule, DataRow cardset )
		{
			DataRow card;
			int n;
			for( n = 0; n < data.GetLength( 0 ); n++ )
			{

				card = schedule.cardset_cards.NewRow();
				card["card_number"] = n + 1;
				card["b1"] = data[n, 0, 0, 0];
				card["b2"] = data[n, 0, 0, 1];
				card["b3"] = data[n, 0, 0, 2];
				card["b4"] = data[n, 0, 0, 3];
				card["b5"] = data[n, 0, 0, 4];
				card["i1"] = data[n, 0, 1, 0];
				card["i2"] = data[n, 0, 1, 1];
				card["i3"] = data[n, 0, 1, 2];
				card["i4"] = data[n, 0, 1, 3];
				card["i5"] = data[n, 0, 1, 4];
				card["n1"] = data[n, 0, 2, 0];
				card["n2"] = data[n, 0, 2, 1];
				card["n3"] = data[n, 0, 2, 2];
				card["n4"] = data[n, 0, 2, 3];
				card["g1"] = data[n, 0, 3, 0];
				card["g2"] = data[n, 0, 3, 1];
				card["g3"] = data[n, 0, 3, 2];
				card["g4"] = data[n, 0, 3, 3];
				card["g5"] = data[n, 0, 3, 4];
				card["o1"] = data[n, 0, 4, 0];
				card["o2"] = data[n, 0, 4, 1];
				card["o3"] = data[n, 0, 4, 2];
				card["o4"] = data[n, 0, 4, 3];
				card["o5"] = data[n, 0, 4, 4];
				card[CardsetInfo.PrimaryKey] = cardset[CardsetInfo.PrimaryKey];
				schedule.cardset_cards.Rows.Add( card );
			}
		}

		// generic routine hard coded to make single faced 5x5 bingo
		// keeps N spot for extra bingo line...
		public static BingoCardset Create( int cards )
		{
			BingoCardset cardset = new BingoCardset();
			cardset.data = new byte[3*((cards+2)/3), 1, 5, 5];
			byte[] card_data = ShuffleSpots.get_list( 75 );
			int[] column_counts = new int[5];
			int n;
			for( n = 0; n < ( (cards + 2) / 3 ); n++ )
			{
				int num;
				for( num = 0; num < column_counts.Length; num++ )
					column_counts[num] = 0;
				for( num = 0; num < 75; num++ )
				{
					int ball = card_data[num];
					int col = ( ball - 1 ) / 15;
					if( column_counts[col] < 15 )
						cardset.data[n * 3 + column_counts[col] / 5, 0, col, column_counts[col] % 5] = (byte)ball;
					column_counts[col]++;
				}
				ShuffleSpots.shuffle_list( ref card_data );
			}
			return cardset;
		}

		public int Count
		{
			get
			{
				return data.GetLength( 0 );
			}
		}

	}
}
