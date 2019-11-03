


	// just use int for simple math ( precision is only a count 0-8 )	
		static int bitcounts[256];

		int checkbits( int mask )
		{
			if( bitcounts == null )
			{
				// initialize bits... then look up by bytes.
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
					count += bitcounts[ ((P_8)mask)[m] ];
				}
				return count;
			}
		}


		// pointer to a flat array of ints
		// it may have faces (2x25 ) cards of rows of columns
		//
		void PlayPattern( int *card_face )
		{
				int card_bits = 0;
				int bestcount = 24;
				int bestmask = 0;
				int skip_ahead = 0;
				lastball = 0;
				// mark free spot as marked.
				// card_bits |= 1 << ( 12 );
				// game contains important things
				// we cannot have two threds in the same game...
				// that's why I have a state?
				//lock( game )
				{
					// game.bestwin will be less than 75 or it will be 75
					//if( !marked )
					//	continue;

					// init the counters to 0,1,2,3...
					counters[0] = 0;
					for( int x = 1; x < pattern.repeat_count; x++ )
					{
						counters[x] = counters[x - 1] + 1;
					}

					//for( counters[0] = 0; counters[0] < max; counters[0]++ )
					bool is_another = true;
					int rcount = pattern.repeat_count;
					while( is_another )
					{
						bool valid_mask = true;
						int check_mask = 0;

						// grab the current pattern's configuration...
						for( int x = 0; x < rcount; x++ )
						{
							int j;

							if( ( j = counters[x] ) >= max )
							{
								valid_mask = false;
								break;
							}
							check_mask |= pattern.masks[j].Data;
						}

						// returns true if valid numbers...
						// else false, and next time we don't have another pattern...
						is_another = StepCounters( ref counters, max, rcount );

						if( !valid_mask )
							continue;
						//foreach( BitVector32 check_mask in pattern.masks )
						for( int ball = 0; ball < 24; ball++ )
						{
							// only count marked balls..
							//if( card_bits == card_masks[ball] )
							//	continue;
							if( ball_index[ball] == 0 && ball > 0 )
								break;
							if( ball < 23 && skip_ahead > 0 )
							{
								skip_ahead--;
								continue;
							}

							if( ball_index[ball] < s.prior_bestwin )
								continue; // don't bother checking yet... 
							// we're not gonna have a win on this card...
							if( ball_index[ball] > s.bestwin )
								break;
							// didn't get another mark...
							card_bits = card_masks[ball];

							if( ( check_mask & card_bits ) == check_mask )
							{
								if( ball_index[ball] < s.bestwin )
								{
									s.bestwin = ball_index[ball];
									s.bestwincount = 1;
								}
								else if( ball_index[ball] == s.bestwin )
								{
									s.bestwincount++;
								}
								mask = check_mask;
								count_away = 0;
								lastball = s.playing_balls[ball_index[ball]];
								return ball_index[ball];
							}
							else
							{
								int count;
								count = checkbits( check_mask & ~card_bits );
								if( count < bestcount )
								{
									bestmask = check_mask;
									bestcount = count;
								}
							}
							// for this card... we need at least this many more marks.
							skip_ahead = bestcount - 1;
						}
					}
		}


		void PlayDatabase( void )
		{
			CTEXTSTR *results;
			int game_id;
			// select game_id,in_progress from play_games where played=0
			for( DoSQLQueryf( "select pattern_id from play_game_patterns where game_id=%d", game_id );
				results;
				GetSQLResult( &results ) )
			{
				// select initial counters from database if selected in progress
			}
		}

