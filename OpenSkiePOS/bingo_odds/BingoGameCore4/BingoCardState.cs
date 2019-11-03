using System;
using System.Collections.Generic;

namespace BingoGameCore4
{
	public class BingoCardState
	{

		public class BingoCardPatternMarkInfo
		{
			// as each number on a card is marked... compute the mask
			public int[] card_masks = new int[24];
			// when a number on a card is marked, save the ball index that did it.
			internal byte[] real_ball_index = new byte[24];
			internal byte[] ball_index = new byte[24];
			internal byte[] balls = new byte[24];
			internal int best_away = 25; // per marked ball location...
			internal int best_away_pattern_mask; // which pattern the count matched
			public int mark_index = 0; // ends at the highest used card_mask/ball_idnex


		}

		public Guid ID;
		public BingoPlayer player;
		public PlayerPack pack;
		public BingoGameEvent game;

		/// <summary>
		/// numeric face offset of pack 0-n faces in pack.
		/// </summary>
		public int pack_card_index;
		internal byte[, ,] card;
		/// <summary>
		/// this is filled in externall...
		/// </summary>
		public int cardset_card_number; // first card in cardset is 1 (this is the physical card ID, auto_increment if random)
		public int unit_card_number; // first card is 1. (this number is shown to players)

		// marks are per-pattern that this card is checked against.
		public List<BingoCardPatternMarkInfo> marks = new List<BingoCardPatternMarkInfo>();
		
		public List<object> prize_levels;  // these are the levels that the card won on

		public BingoGame WinningGame;
		public BingoGameEvent WinningGameEvent;
		public int Lastball;

		/// <summary>
		/// Returns the last ball that made a mark on the card (not game lastball)
		/// </summary>
		public int xLastMarkedBall
		{
			get
			{
				//if( mark_index > 0 )
				//	return balls[mark_index - 1];
				return 0;
			}
		}

		int last_best = 75;

		public override string ToString()
		{
			return player.ToString() + " " + pack.ToString() + " card " + unit_card_number + "(" + pack_card_index + ")";
			//return base.ToString();
		}
		public int BallCount
		{
			get
			{
				if( marks.Count == 0 )
					return 0;
				if( marks[0].mark_index == 0 )
					return 0;
				return marks[0].real_ball_index[marks[0].mark_index - 1] + 1;
			}
		}

		/// <summary>
		/// This returns the pattern mask that best matched this card.
		/// </summary>
		public int BestMask()
		{
			{
				// if nothing marked, nothing can be best mask.
				if( marks.Count == 0 )
					return 0;
				if( marks[0].mark_index == 0 )
					return 0;
				return marks[0].best_away_pattern_mask;
			}
		}

		public int BestMask( int pattern_index )
		{
			{
				// if nothing marked, nothing can be best mask.
				if( marks.Count == 0 )
					return 0;
				if( marks[pattern_index].mark_index == 0 )
					return 0;
				return marks[pattern_index].best_away_pattern_mask;
			}
		}
		public int BestAway()
		{
			{
				return BestAway( 0 );
			}
		}
		public int BestAway( int pattern_index )
		{
			{
				return ( marks.Count == 0 ) ? 0 : marks[pattern_index].best_away;
			}
		}

		/// <summary>
		/// This is the last mark mask on the card (all marks on the card marked)
		/// </summary>
		public int MarkMask()
		{
			//get
			{
				return MarkMask( 0 );
			}
		}

		/// <summary>
		/// This is the last mark mask on the card (all marks on the card marked)
		/// </summary>
		public int MarkMask( int pattern_index )
		{
			{
				if( marks.Count > pattern_index )
					if( marks[pattern_index].mark_index > 0 )
						return marks[pattern_index].card_masks[marks[pattern_index].mark_index - 1];
				return 0;
			}
		}
		/// <summary>
        /// use this to get the card data outside this class..
        /// </summary>
		public byte[, ,] CardData
		{
			get
			{
				return card;
			}
		}

		public BingoCardState( byte[, ,] CardData )
		{
			card = CardData;
		}

		public BingoCardState( byte[, ,] CardData, BingoPlayer _Player, PlayerPack pack, int unit_card, int real_card, BingoGameEvent game )
		{
			this.card = CardData;
			this.player = _Player;
			this.pack = pack;
			this.unit_card_number = unit_card;
			this.cardset_card_number = real_card;
			this.game = game;
		}

		bool MarkOne( BingoCardPatternMarkInfo marks, int faces, int columns, int ball )
		{
			bool marked = false;
			int card_bits = 0;

			if( ball < 1 || ball > 75 )
				return false;

			Lastball = ball;

			if( columns == 3 )
			{
				int j = 0;
				card_bits = ( marks.mark_index == 0 ) ? ( 0 ) : marks.card_masks[marks.mark_index - 1]; // 1 << 12 (the center free spot)
				for( int i = 0; i < 3; i++ )
				{
					for( int face = 0; face < faces; face++ )
					{
						if( card[face, j, i] == ball )
						{
							int thisbit = 1 << ( i );
							if( ( card_bits & thisbit ) == 0 )
							{
								// don't re-mark the same spot  (dual action cards)
								marked = true;
								card_bits |= thisbit;
							}
							break;
						}
					}
					// have to check for not_changed later...
				}
			}
			else if( columns > 5 && card.GetLength(1) == 1 )
			{
				card_bits = ( marks.mark_index == 0 ) ? ( 0 ) : marks.card_masks[marks.mark_index - 1]; // 1 << 12 (the center free spot)
				// 6x1,7x1,8x1,9x1,10x1... columns are treated as upickem cards.
				for( int j = 0; j < columns; j++ )
				{
					if( card[0, 0, j] == ball )
					{
						int thisbit = 1 << ( j );
						if( ( card_bits & thisbit ) == 0 )
						{
							// don't re-mark the same spot  (dual action cards)
							marked = true;
							card_bits |= thisbit;
						}
						break;
					}
				}
			}
			else
			{

				card_bits = ( marks.mark_index == 0 ) ? ( 1 << 12 ) : marks.card_masks[marks.mark_index - 1]; // 1 << 12 (the center free spot)
				int i = ( ball - 1 ) / 15;
				for( int j = 0; j < 5; j++ )
				{
					if( i == 2 && j == 2 )
						continue;
					for( int face = 0; face < faces; face++ )
					{
						if( card[face, i, j] == ball )
						{
							int thisbit = 1 << ( ( i * 5 + j ) );
							if( ( card_bits & thisbit ) == 0 )
							{
								// don't re-mark the same spot  (dual action cards)
								marked = true;
								card_bits |= thisbit;
							}
							break;
						}
					}
					// have to check for not_changed later...
				}
			}
			if( marked )
			{
				marks.balls[marks.mark_index] = (byte)ball;
				marks.card_masks[marks.mark_index++] = card_bits;
			}
			return marked;
		}

		internal BingoCardPatternMarkInfo GetCurrentMark( int pattern_index )
		{
			if( pattern_index >= marks.Count )
			{
				marks.Add( new BingoCardPatternMarkInfo() );
			}
			BingoCardPatternMarkInfo current_marks = marks[pattern_index];
			return current_marks;
		}

		internal bool MarkNew( BingoCardPatternMarkInfo marks, int faces, int columns, int[] balls )
		{
			byte ball_num;
			bool marked = false;
			byte start;

			if( marks.mark_index > 0 )
			{
				ball_num = marks.real_ball_index[marks.mark_index - 1];
				ball_num++;
				start = marks.ball_index[marks.mark_index - 1];
				start++;
			}
			else
			{
				ball_num = 0;
				start = 0;
			}

			for( byte n = start; n < balls.Length; n++ )
			{
				if( balls[n] < 1 || balls[n] > 75 )
					continue;
				if( MarkOne( marks, faces, columns, balls[n] ) )
				{
					marked = true;
					marks.real_ball_index[marks.mark_index - 1] = ball_num;
					marks.ball_index[marks.mark_index - 1] = n;
				}
				ball_num++;
			}
			return marked;
		}

		internal bool MarkAll( int[] balls, int pattern_index )
		{
			int faces = card.GetLength( 0 );
			int columns = card.GetLength( 2 );
			BingoCardPatternMarkInfo current_marks = GetCurrentMark( pattern_index );
			current_marks.mark_index = 0;
			return MarkNew( current_marks, faces, columns, balls );
		}


		static int[] bitcounts;
		internal static int checkbits( int mask )
		{
			if( bitcounts == null )
			{
				int n;
				int count;
				bitcounts = new int[256];
				for( n = 0; n < 256; n++ )
				{
					count = 0;
					for( int b = 0; b < 8; b++ )
						if( ( n & ( 1 << b ) ) != 0 )
						{
							count++;
						}
					bitcounts[n] = count;
				}
			}
			{
				int count = 0;
				for( int m = 0; m < 4; m++ )
				{
					count += bitcounts[( mask >> ( m * 8 ) ) & 0xFF];
				}
				return count;
			}
		}

		public bool CheckPattern( BingoCardPatternMarkInfo marks, List<int> pattern_masks )
		{
			int card_mask;

			if( bitcounts == null )
			{
				int n;
				int count;
				bitcounts = new int[256];
				for( n = 0; n < 256; n++ )
				{
					count = 0;
					for( int b = 0; b < 8; b++ )
						if( ( n & ( 1 << b ) ) != 0 )
						{
							count++;
						}
					bitcounts[n] = count;
				}
			}

			if( marks.mark_index > 0 )
				card_mask = marks.card_masks[marks.mark_index - 1];
			else
				card_mask = 0x400;
			if( marks.mark_index > 0 )
			{
				foreach( int pattern_mask in pattern_masks )
				{
					int count = 0;
					int test_mask = ( pattern_mask & ~card_mask );

					count += bitcounts[( test_mask >> ( 0 * 8 ) ) & 0xFF];
					count += bitcounts[( test_mask >> ( 1 * 8 ) ) & 0xFF];
					count += bitcounts[( test_mask >> ( 2 * 8 ) ) & 0xFF];
					count += bitcounts[( test_mask >> ( 3 * 8 ) ) & 0xFF];

					if( count < marks.best_away )
					{
						marks.best_away_pattern_mask = pattern_mask;
						marks.best_away = count;
					}
					if( count == 0 )
						return true;
				}
			}
			return false;
		}

		public bool CheckCrazy( BingoCardPatternMarkInfo marks, int count )
        {
			marks.best_away = count - marks.mark_index;
			if( marks.best_away == 0 )
                return true;
            return false;
        }

		public bool CheckBig3( BingoCardPatternMarkInfo marks )
		{
			if( marks.mark_index > 0 )
			{
				int count = checkbits( 0x7 & ~marks.card_masks[marks.mark_index - 1] );
				if( count < marks.best_away )
				{
					marks.best_away_pattern_mask = 0x7;
					marks.best_away = count;
				}
				if( count == 0 )
					return true;
			}
			return false;
		}

		public BingoCardState Clone()
		{
			BingoCardState card = new BingoCardState( this.card );
			card.player = player;
			card.pack = pack;
			card.unit_card_number = unit_card_number;
			card.game = game;
			card.pack_card_index = pack_card_index;
			card.ID = ID;// Local.bingo_tracking.AddCard( game_group.group_pack_set_id, pack.ID, game.ballset_number, unit_card_number, this.card );
			//card.ID = original.ID;
			//card.
			return card;
		}

	}
}
