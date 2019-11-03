using System.Collections.Generic;
using BingoGameCore4;
using xperdex.classes;
using OpenSkieScheduler3;
using System;

namespace BingoGameCore4
{
    public static class BingoMatchEngine
    {

        // double action determines whether card[X,,] goes from 0-0 or 0-1 (triple action? 0-2?)
        // check one card, get the best mask, and the best count_away
        // return the number of balls in ball array it won on.
        public static bool check_single_card( 
            BingoCardState card
            , BingoGameEvent game_event
			, int game_index
            , int[] playing_balls
            , int faces
            , int columns
            , int pattern_index
             )
        {
			int mark_count = 0;
			if( card.pack.pack_info.flags.big3 )
			{
				card.CheckBig3( card.marks[0] );
			}
			else
			{
				//foreach( BingoGame game in game_event.games )
				BingoGame game = game_event.games[game_index];
				{
					foreach( Pattern pattern in game.patterns )
					{
						BingoCardState.BingoCardPatternMarkInfo marks = card.GetCurrentMark( pattern_index );
						switch( pattern.algorithm )
						{
						case PatternDescriptionTable.match_types.ExternalJavaEngine:
							break;
						default:
							if( card.MarkNew( marks, faces, columns, playing_balls ) )
								mark_count++;
							break;
						}
					}
				}
				if( mark_count == 0 )
					return false;

	            {
                    // get last marked cardmask
                    //foreach( BingoGame game in game_event.games )
                    {
                        if ( game.patterns[0].algorithm == PatternDescriptionTable.match_types.CrazyMark )
                        {
                            return card.CheckCrazy( card.marks[0], game.patterns[0].repeat_count );
                        }
                        else if (game.patterns[0].algorithm == PatternDescriptionTable.match_types.ExternalJavaEngine)
                        {
                            //return 
                        }
                        else
                        {
                            List<int> patterns = game.pattern_list.pattern_bitmask_list;
                            //foreach ( int check_mask in patterns )
                            {
								if( card.CheckPattern( card.marks[0], patterns ) )
                                {
                                    card.WinningGame = game;
                                    card.WinningGameEvent = game_event;
                                    return true;
                                }
                            } // end of foreach( pattern )
                        }
                    }
                }
            }
			return false;
            
        }

        public static bool check_pack( PlayerPack pack, int game, Pattern pattern )
        {
			int num_patterns;
			int num_cards;
            int pattern_index;
			int card_index;

			if( pattern.sub_patterns.Count < 1 )
				return false;

			CombinationIterator ci = ( ( pattern.mode_mod & Pattern.mode_modifications.OrderMatters ) != 0 ) 
				? null
				: new CombinationIterator( pattern.sub_patterns.Count );
			bool iterator_done;

			List<BingoCardState> cards = pack.Cards[game];

			int cardsets = cards.Count;
			/*
			 * this check should be done somewhere; maybe when cards are dealt for packs to games?
			 * 
			if( cardsets % pattern.sub_patterns.Count != 0 )
			{
				throw new Exception( "Pack is incompatible with pattern.  Mismatch integral card count" );
			}
			*/
			num_patterns = pattern.sub_patterns.Count;
		
			cardsets = cardsets / ( num_patterns );
			if( cardsets > 1 )
			{
				Log.log( "Pattern-packsize mismatch" );

			}

			int[] best_combination = null;
			//int[,] bests = new int[ cardsets, ci.GetCombinations() ];
			int combination = 0;
			if( pattern.pattern_masks == null )
			{
				pattern.pattern_masks = new List<Pattern.PatternMasks>();
				foreach( Pattern sub_pattern in pattern.sub_patterns )
				{
					List<Pattern> tmplist = new List<Pattern>();
					tmplist.Add( sub_pattern );
					Pattern.PatternMasks masks = new Pattern.PatternMasks();
					Pattern.ExpandGamePatterns( tmplist, masks );
					pattern.pattern_masks.Add( masks );
				}
			}

			foreach( Pattern sub_pattern in pattern.sub_patterns )
			{
				int sub_pattern_index = pattern.sub_patterns.IndexOf( sub_pattern );
				foreach( BingoCardState card in cards )
				{
					// get last marked cardmask
					{
						if( sub_pattern.algorithm == PatternDescriptionTable.match_types.CrazyMark )
						{
							return card.CheckCrazy( card.marks[0], sub_pattern.repeat_count );
						}
						else if( sub_pattern.algorithm == PatternDescriptionTable.match_types.ExternalJavaEngine )
						{
							//return 
						}
						else
						{
							List<int> patterns = pattern.pattern_masks[sub_pattern_index].pattern_bitmask_list;
							{
								if( card.CheckPattern( card.marks[sub_pattern_index], patterns ) )
								{
									//card.WinningGame = game;
									//card.WinningGameEvent = game_event;
									//return true;
								}
							} // end of foreach( pattern )
						}
					}
				}
			}

			int cardset;
			int best_away = 75;
			int worst_card_away = 75;
			int best_cardset;
			for( cardset = 0; cardset < cardsets; cardset++ )
			{

				iterator_done = false;
				while( !iterator_done )
				{
					int[] this_order;
					if( ci == null )
					{
						iterator_done = true;
						this_order = new int[pattern.sub_patterns.Count];
						for( int n = 0; n < pattern.sub_patterns.Count; n++ )
							this_order[n] = n;
					}
					else
						iterator_done = ci.IterateCombination( out this_order );
					int total_away = 0;
					int card_offset = 0;
					foreach( int index in this_order )
					{
						int card_away = cards[cardset * num_patterns + card_offset].BestAway( index );
						if( card_away < 24 && card_away < worst_card_away )
							worst_card_away = card_away;
						total_away += card_away;
						card_offset++;
					}
					if( total_away < best_away )
					{
						best_away = total_away;
						best_combination = (int[])this_order.Clone();
						best_cardset = cardset;
					}
					//bests[cardset, combination] = total_away;
				}
				combination++;
			}
			if( best_away > 0 && worst_card_away == 0 )
				worst_card_away = 1;
			pack.state = pack.state ?? new List<BingoPackState>();
			if( pack.state.Count <= game )
				pack.state.Add( new BingoPackState() );
			pack.state[game].best_away = best_away;
			pack.state[game].best_card_away = worst_card_away;
			pack.state[game].combination = best_combination;
			pack.state[game].group_size = pattern.sub_patterns.Count;
			if( pack.state[game].best_away == 0 )
				return true;
            return false;
        }

        public static int check_5ball( int pattern_mask, ref byte[, ,] card, ref int[] balls, int check_balls, int lastball, ref bool won_lastball )
        {
            int count = 0;
            if( balls == null )
                return 0;
            for( int col = 0; col < 5; col++ )
            {
                for( int row = 0; row < 5; row++ )
                {
                    if( row == 2 && col == 2 )
                        continue;
                    if( ( pattern_mask & ( 1 << ( col * 5 + row ) ) ) != 0 )
                    {
                        // ball are the hotballs..
                        // this is in the current pattern...
                        if( lastball == card[0, col, row] )
                        {
                            // we don't check last ball in the next part...
                            // but that is a count of balls that hit.
                            won_lastball = true;
                            count++;
                        }
                        for( int ball = 0; ball < check_balls; ball++ )
                        {
                            if( balls[ball] == card[0, col, row] )
                                count++;
                        }
                    } // was spot marked on card...
                } // row loop
            } // col loop
            return count;
        }

        public static void CountStarburst( BingoGameState s )
        {
            bool do_starburst = false;
            if( s.game != null && s.game.starburst )
                do_starburst = true;

            if( do_starburst )
            {
                foreach( wininfo card in s.winning_cards )
                {
					byte[, ,] playing_card = card.playing_card.CardData;
                    if( playing_card[0, 2, 2] == s.game_event.playing_balls[s.bestwin] )
                    {
                        card.starburst = true;
                        lock( s.game_event )
                            s.game_event.starburst_wins++;
                    }
                    else
                        for( int ball = 0; ball < ( s.bestwin - 1 ); ball++ )
                            if( s.game_event.playing_balls[ball] == playing_card[0, 2, 2] )
                            {
                                lock( s.game_event )
                                    s.game_event.starburst_marks++;
                                card.starburst_marked = true;
                            }
                }
            }
        }

        public static void CountHotball( ref BingoGameState s, int[] playing_balls )
        {
            int check_balls = 0;
            if( s.game == null )
                return;

            check_balls = s.game.cashballs;

            if( check_balls > 0 )
            {
                foreach( wininfo info in s.winning_cards )
                {
                    int card = info.card_index;
                    int mask = info.mask;
					byte[, ,] playing_card = info.playing_card.CardData;
                    bool didwin = false;
                    int hot_match = check_5ball( mask, ref playing_card
                                                , ref s.game_event.playing_hotballs
                                                , check_balls
                                                , playing_balls[s.bestwin - 1], ref didwin );
                    if( didwin )
                    {
                        //s.best
                        //hotball_wins[s.game.game_ID, hot_match - 1]++;
                        info.hotball = true;
                        info.hotball_count = hot_match;
                    }
                }
            }
        }
#if null
        /// <summary>
        /// Checks to see if the game ended with the last 5 balls being from
        /// specific and in order columns 'B', 'I', 'N', 'G', 'O' and if so,
        /// checks to see if any of the winning cards matched on the last
        /// five ball picks.
        /// </summary>
        /// <param name="s"></param>
        /// <param name="playing_balls"></param>
        public static void CountLastLettersBINGO( ref BingoGameState s, int[] playing_balls )
        {
            if (s.game != null && s.game.last_letter_bingo)
            {
                int     last = playing_balls.Length - 5;
                int     idx = 0;

                if ( last < 0)
                    return;

                // Check to see if last 5 called balls spelled BINGO (in order)
                if( ( ( ( playing_balls[last++] - 1) / 15 ) != 0 ) ||
                    ( ( ( playing_balls[last++] - 1) / 15 ) != 1 ) ||
                    ( ( ( playing_balls[last++] - 1) / 15 ) != 2 ) ||
                    ( ( ( playing_balls[last++] - 1) / 15 ) != 3 ) ||
                    (((playing_balls[last] - 1) / 15) != 4))
                    return;

                // We already know that the last ball is in the last column,
                // let's find out what row it appears in for a given winning card.
                foreach (wininfo card in s.winning_cards)
                {
                    for( idx = 0; idx < 5; idx++ )
                    {
                        if( card.playing_card.CardData[0,4,idx] == playing_balls[last] )
                            break;
                    }

                    if( ( card.mask & ( 0x01F00000 >> ( idx * 5 ) ) ) == ( 0x01F00000 >> ( idx * 5 ) ) )
                    {
                        card.bingo_match = true;
                        lock (s.game_event)
                        {
                            s.game_event.bingo_match_wins++;
                            s.game_event.wins++;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Counts BINGOs when the entire BINGO is the same random generated color;
        /// </summary>
        /// <param name="s"></param>
        /// <param name="playing_balls"></param>
        public static int CountRandomColorBingo( ref BingoGameState s, int[] playing_balls )
        {
            int num_matches = 0;

            if( s != null )
            {
                int     row = 0;
                int     col = 0;
                char    color;
                int     cardGridValue = 0;
                int     bitMask;
                bool    matches;

                char[] randomColors = s.game_event.balls.GetRandomColors();
                
                // Check the mask against the card, get the number from the card,
                // and look up the color in the random color table.

                foreach( wininfo card in s.winning_cards )
                {
                    color   = (char)0x00;
                    matches = true;
                    bitMask = 0x01000000;

                    for( row = 0; matches && row < 5; row++ )
                    {
                        for( col = 0; matches && col < 5; col++ )
                        {
                            if( ( card.mask & bitMask ) == bitMask )
                            {
                                cardGridValue = card.playing_card.CardData[ 0, col, row ];
                                if( color == 0x00 )
                                    color = randomColors[cardGridValue-1];
                                else if( color != randomColors[cardGridValue-1] )
                                    matches = false;
                            }
                            bitMask /= 2;
                        }
                    }

                    if( matches )
                    {
                        card.random_color_match = true;
                        num_matches++;
                    }

                }

                if( num_matches > 0 )
                {
                    lock (s.game_event)
                    {
                        s.game_event.random_color_wins += num_matches;
                        s.game_event.wins += num_matches;
                    }
                }
            }

            return num_matches;
        }
#endif

        /// <summary>
        /// Plays a single state of bingo, uses the balls specified in playing_balls.
        /// </summary>
        /// <param name="s"></param>
        static void Play( BingoGameState s, bool single_ball )
        {
            BingoGameInterfaces.BallDataInterface bdi;
            if( s.session_event.ball_data != null )
                bdi = s.session_event.ball_data;
            else
                bdi = s.game_event.balls;
            if ( bdi == null )
                return;

            if ( s.winning_cards == null )
                return;
            if ( s.playing_cards.Count == 0 )
                return;

            s.winning_cards.Clear();

            int[] playing_balls;

            playing_balls = bdi.GetBalls( s.game.ignore_b_balls, s.game.ignore_i_balls, s.game.ignore_n_balls, s.game.ignore_g_balls, s.game.ignore_o_balls );
			s.starting_balls = playing_balls.Length;
            if ( playing_balls.Length == 0 )
            {
                if( !single_ball )
                {
					// draw ball should be written as wait mode.... and throw exceptions I suppose
                    bdi.DrawBall();
                    bdi.WaitForBall();
                    playing_balls = bdi.GetBalls( s.game.ignore_b_balls, s.game.ignore_i_balls, s.game.ignore_n_balls, s.game.ignore_g_balls, s.game.ignore_o_balls );
                }
                else
                    return; // balls need to be setup ahead of time 
            }
            // so this plays a single game.
            lock( s.game )
            {
                if( playing_balls == null || playing_balls.Length == 0 )
                {
                    // Check to see if we are ignoring a column.  If so, Length == 0
                    // is a legitimate length and we should continue calling balls.
                    if( ( !s.game.ignore_b_balls &&
                          !s.game.ignore_i_balls &&
                          !s.game.ignore_n_balls &&
                          !s.game.ignore_g_balls &&
                          !s.game.ignore_o_balls ) ||
                        playing_balls == null )
                    {
                        // this is used to skip ball counts... return just 1 ball needed.
                        s.bestaway = 1;
                        return;
                    }
                }

                int faces = s.playing_cards[0].card.GetLength( 0 );
                int columns = s.playing_cards[0].card.GetLength( 2 );

                do
                {
                    // int pack_number = 0;
                    int card_id = 0;

					s.game_event.playing_balls = playing_balls;
					s.bestaway = s.session_event.session.max_balls;
                    s.bestwin = playing_balls.Length;

					foreach( PlayerPack pack in s.playing_packs )
					{
						int away;
						if( !pack.pack_info.flags.upickem )
							continue;
                        int face_size = pack.pack_info.face_size;
						foreach( BingoCardState card in pack.Cards[s.game.game_ID] )
						{
							int mark_count = 0;
							BingoCardState.BingoCardPatternMarkInfo marks = card.GetCurrentMark( 0 );
							if( card.MarkNew( marks, faces, columns, playing_balls ) )
								mark_count++;

							if( card.CheckCrazy( marks, face_size ) )
							{
								away = 0;
							}
							else
								away = face_size - marks.mark_index;

							if( away < s.bestaway )
								s.bestaway = away;

							if( away == 0 )
							{
								int ball_count = 0;
								for( int n = 0; n < playing_balls.Length; n++ )
									if( playing_balls[n] > 0 )
										ball_count++;
								// this card is a winner.
								// there is also a game.bestwin now
								// perhaps we should remove s.bestwin?
								// but I thik maybe we need a lock on the game?
								//
								{
									// this is in a ball-length check mode.
									if( card.BallCount < ball_count )
									{
										// had this as a message box... but ... should silence it... it is a flaw somewhere.
										Log.log( "Sleeper bingo found on card " + card.unit_card_number + " in " + card.BallCount + " balls instead of " + playing_balls.Length + " balls" );
									}
									wininfo tmpwin;
									s.AddWinner( tmpwin = new wininfo( card_id, card ) );
									if( Local.StoreToDatabase )
										Local.bingo_tracking.StoreVerifiedCard( card.player.ID, card.pack.pack_info.ID, card.cardset_card_number, tmpwin.mask, card.card );
								}
							}
						}
					}


                    foreach( BingoGame game in s.game_event.games )
                    {
						if( game.upick_size > 0 )
						{
                            /*
                            foreach( BingoCardState card in s.playing_cards )
                            {
                                BingoCardState.BingoCardPatternMarkInfo cardmarks;
                                card.MarkNew( cardmarks = card.GetCurrentMark( 0 ), faces, columns, playing_balls );
                                int away = game.upick_size - cardmarks.mark_index;
                                if( away < s.bestaway )
                                    s.bestaway = away;
                            }
                            */
						}
                        else foreach( Pattern pattern in game.patterns )
                        {
                            if( pattern.algorithm == PatternDescriptionTable.match_types.CrazyMultiCard ||
								pattern.algorithm == PatternDescriptionTable.match_types.TopMiddleBottom ||
								pattern.algorithm == PatternDescriptionTable.match_types.TopMiddleBottomCrazy 
								)
                            {
									
                                foreach( BingoCardState card in s.playing_cards )
                                {
									foreach( Pattern sub_pattern in pattern.pattern_list )
									{
										int sub_pattern_index = pattern.pattern_list.IndexOf( sub_pattern );
										card.MarkNew( card.GetCurrentMark(sub_pattern_index), faces, columns, playing_balls );
									}
								}

                                foreach( PlayerPack pack in s.playing_packs )
                                {
                                    int away;


									if( check_pack( pack, game.ballset_number, pattern ) )
                                    {
										s.AddWinner( new wininfo( card_id, pack.Cards[game.ballset_number][0] ) );
										away = 0;
                                    }
                                    else
                                    {
										if( pack.state != null )
											away = pack.state[game.ballset_number].best_card_away;
										else
											away = 75;
                                    }
									if( away < s.bestaway )
										s.bestaway = away;
								}
							}
                            else if( pattern.algorithm == PatternDescriptionTable.match_types.CrazyMark )
                            {
                                foreach( BingoCardState card in s.playing_cards )
                                {
                                    int away;
									faces = card.pack.pack_info.flags.double_action ? 2 : 1;
                                    if( !card.MarkNew( card.GetCurrentMark(0), faces, columns, playing_balls ) )
                                    {
                                        continue;
                                    }
                                    if( card.marks[0].mark_index == pattern.repeat_count )
                                    {
                                        away = 0;
                                    }
                                    else
                                    {
                                        away = pattern.repeat_count - card.marks[0].mark_index;
                                    }
                                    if( away < s.bestaway )
                                        s.bestaway = away;
                                }
                            }
                            if (pattern.algorithm == PatternDescriptionTable.match_types.ExternalJavaEngine )
                            {
                                foreach( BingoCardState card in s.playing_cards )
                                {
                                    int away;
									faces = card.pack.pack_info.flags.double_action ? 2 : 1;
                                    
                                    if( check_single_card( card, s.game_event, s.game_event_index, playing_balls, faces, columns, 0 ) )
                                    {
                                        away = 0;
                                    }
                                    else
                                    {
										away = card.BestAway();
                                    }
                                    if( away < s.bestaway )
                                        s.bestaway = away;

                                    // count is the count of balls that this card won in.
                                    // compared with one of the above matchings.
                                    // these are common to all prior code.
                                    if( away == 0 )
                                    {
										int ball_count = 0;
										for( int n = 0; n < playing_balls.Length; n++ )
											if( playing_balls[n] > 0 )
												ball_count++;

										// this card is a winner.
                                        //if( s.game.game_number == 10 )
#if null
                                        if( false )
                                        {
                                            xperdex.classes.Log.log( "winner on start:" + card.pack.start_card + " face:" + card );
                                            xperdex.classes.Log.log( "player: " + card.player.card + "  unit:" + card.pack.unit_number );
                                            xperdex.classes.Log.log( "game " + s.game.game_number + " card:" + ( card.unit_card_number )
                                                );
                                        }
#endif
                                        // there is also a game.bestwin now
                                        // perhaps we should remove s.bestwin?
                                        // but I thik maybe we need a lock on the game?
                                        //
                                        {
                                            // this is in a ball-length check mode.
                                            if( card.BallCount < ball_count )
                                            {
                                                // had this as a message box... but ... should silence it... it is a flaw somewhere.
                                                Log.log( "Sleeper bingo found on card " + card.unit_card_number + " in " + card.BallCount + " balls instead of " + playing_balls.Length + " balls" );
                                            }
                                            wininfo tmpwin;
                                            s.AddWinner( tmpwin = new wininfo( card_id, card ) );
											if( Local.StoreToDatabase )
												Local.bingo_tracking.StoreVerifiedCard( card.player.ID, card.pack.pack_info.ID, card.cardset_card_number, tmpwin.mask, card.card );
                                        }
                                    }
                                    //card_number++;
                                }
                                card_id++;
                            } // end or cards
                            else if( ( pattern.algorithm == PatternDescriptionTable.match_types.Normal )
								||( pattern.algorithm == PatternDescriptionTable.match_types.TwoGroups )
								||( pattern.algorithm == PatternDescriptionTable.match_types.TwoGroupsPrime )
								||( pattern.algorithm == PatternDescriptionTable.match_types.TwoGroupsNoOver )
								||( pattern.algorithm == PatternDescriptionTable.match_types.TwoGroupsPrimeNoOver ) )

                            {
                                foreach( BingoCardState card in s.playing_cards )
                                {
                                    int away;
									faces = card.pack.pack_info.flags.double_action ? 2 : 1;

									if( check_single_card( card, s.game_event, s.game_event_index, playing_balls, faces, columns, 0 ) )
                                    {
                                        away = 0;
                                    }
                                    else
                                    {
										away = card.BestAway();
                                    }
                                    if( away < s.bestaway )
                                        s.bestaway = away;

                                    // count is the count of balls that this card won in.
                                    // compared with one of the above matchings.
                                    // these are common to all prior code.
                                    if( away == 0 )
                                    {
										int ball_count = 0;
										for( int n = 0; n < playing_balls.Length; n++ )
											if( playing_balls[n] > 0 )
												ball_count++;
                                        // this card is a winner.
                                        // there is also a game.bestwin now
                                        // perhaps we should remove s.bestwin?
                                        // but I thik maybe we need a lock on the game?
                                        //
                                        {
                                            // this is in a ball-length check mode.
											if( card.BallCount < ball_count )
                                            {
                                                // had this as a message box... but ... should silence it... it is a flaw somewhere.
                                                Log.log( "Sleeper bingo found on card " + card.unit_card_number + " in " + card.BallCount + " balls instead of " + playing_balls.Length + " balls" );
                                            }
                                            wininfo tmpwin;
                                            s.AddWinner( tmpwin = new wininfo( card_id, card ) );
											if( Local.StoreToDatabase )
												Local.bingo_tracking.StoreVerifiedCard( card.player.ID, card.pack.pack_info.ID, card.cardset_card_number, tmpwin.mask, card.card );
                                        }
                                    }
                                    //card_number++;
                                }
                                card_id++;
                            } // end or cards
                        }
                    }


                    if ( s.bestwincount == 0 )
                    {
                        if( !single_ball )
                        {
                            // no cards I guess... somehow we called all balls and got no winners.
                            int maxBallsInPlay =
                                s.session_event.session.max_balls -
                                ( ( s.game.ignore_b_balls ) ? 15 : 0 ) -
                                ( ( s.game.ignore_i_balls ) ? 15 : 0 ) -
                                ( ( s.game.ignore_n_balls ) ? 15 : 0 ) -
                                ( ( s.game.ignore_g_balls ) ? 15 : 0 ) -
                                ( ( s.game.ignore_o_balls ) ? 15 : 0 );

                            //if( playing_balls != null && playing_balls.Length == s.session_event.session.max_balls )
                            if( playing_balls != null && playing_balls.Length == maxBallsInPlay )
                                break;

                            // need at least this many more balls anyhow...
                            for( int skip = 0; skip < s.bestaway; skip++ )
                            {
                                bdi.DrawBall();
                                bdi.WaitForBall();
                            }
                            playing_balls = bdi.GetBalls( s.game.ignore_b_balls, s.game.ignore_i_balls, s.game.ignore_n_balls, s.game.ignore_g_balls, s.game.ignore_o_balls );
                        }
                    }
                    else
                        break;
                }  // end for players
                while( !single_ball );

				if( !s.game.progressive )
					bdi.DropBalls();  // game finished?
            }

            if( s.bestwincount > 0 )
            {
                // this bit of code is run 
                // after all players and all cards have been played
                // we compute stats for the game.

                CountStarburst( s );

                CountHotball( ref s, playing_balls );

                if ( s.bestwin <= playing_balls.Length )
                {
                    lock( s.game_event )
                    {
                        s.game_event.wins += s.bestwincount;
                        //s.game_event.best_wins[s.bestwin] += s.bestwincount;
                    }
                }
            }

            s.game_event.playing_balls = playing_balls;
            
            // certain modes don't set s.game
            if( s.game != null )
            {
                //Local.bingo_tracking.SaveWinners( s.wining_cards );

                //Local.bingo_tracking.CloseGame();

                s.game.playing = false; // all done playign this game... all stats updates appropriately.
            }
        }


        public static void Play( BingoGameState s )
        {
            Play( s, false );
        }

        /// <summary>
        /// this just plays the current state, it doesn't attempt to call more balls.  It's a one-shot, expecting balls to be updated externally.
        /// </summary>
        /// <param name="s">the state to play</param>
        public static void PlayNow( BingoGameState s )
        {
            Play( s, true );
        }

		public static bool IsPackPattern( BingoGameState s )
		{
			Pattern pattern = s.game.patterns[0];
			if( pattern.algorithm == PatternDescriptionTable.match_types.CrazyMultiCard ||
				pattern.algorithm == PatternDescriptionTable.match_types.TopMiddleBottom ||
				pattern.algorithm == PatternDescriptionTable.match_types.TopMiddleBottomCrazy 
				)
				return true;
			return false;
		}

		public static int GetPackCardGroupSize( BingoGameState s )
		{
			Pattern pattern = s.game.patterns[0];
			if( pattern.algorithm == PatternDescriptionTable.match_types.CrazyMultiCard ||
				pattern.algorithm == PatternDescriptionTable.match_types.TopMiddleBottom ||
				pattern.algorithm == PatternDescriptionTable.match_types.TopMiddleBottomCrazy
				)
				return pattern.sub_patterns.Count;
			return 1;
		}

    }
}
