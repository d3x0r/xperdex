using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BingoGameInterfaces;

namespace BingoGameCore4.CardMaster
{
	public class UPickFactory : CardData
	{
		int upickem_size;
		int random_offset;    // how many balls have been used in this set.
		int[] balls;
		BallDataInterface random_source;

		public UPickFactory( int upick_size )
		{
			this.upickem_size = upick_size;
			random_source = new BallData_Random75();
			random_source.DropBalls();
			random_offset = 75;
		}

		public UPickFactory()
		{
			random_source = new BallData_Random75();
			random_source.DropBalls();
			random_offset = 75;
		}

		public int CardSize
		{
			set
			{
				upickem_size = value;
			}
			get
			{
				return upickem_size;
			}
		}

		byte[, ,] MakeCard()
		{
			byte[, ,] card = new byte[1, 1, upickem_size];
			int n;
			if( ( upickem_size + random_offset ) > 75 )
			{
				random_offset = 0;
				balls = random_source.CallBalls( 75 );
			}
			for( n = 0; n < upickem_size; n++ )
			{
				card[0, 0, n] = (byte)balls[random_offset++];
			}
			return card;
		}

		byte[, ,] CardData.Create( int starting_card, int faces, bool starburst )
		{
			return MakeCard();
		}

		byte[, ,] CardData.Create( int starting, int faces, int skip, int minrange, int maxrange, bool starburst )
		{
			return MakeCard();
		}

		string CardData.name
		{
			get { return "UPickem Cards";  }
		}

		string CardData.file_name
		{
			get { return "NoFile"; }
		}
	}
}
