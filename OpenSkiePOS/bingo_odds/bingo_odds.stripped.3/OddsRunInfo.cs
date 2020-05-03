using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Data.Common;
using System.Xml;
using System.Xml.XPath;
using BingoGameCore4;
using xperdex.classes;
using BingoGameInterfaces;

namespace bingo_odds
{

	public class OddsRunInfo
	{
		
		public class state : BingoGameState {
			//public byte[, ,] playing_card;
			public int Year;
			public int Day;
			// there ws 'session' in this list, but it's been promted ... day and year should be bingnoday.
			public int Game;
			public int Hall;

			public bool stepped;  // is a valid state.

			public int prior_bestwin; // the prior game played had this as an end... 
		};

		public class BingoTriggerBallStats
		{
			public bool enabled;
			public int max_triggered;
			public int[] triggered;
			public int[] trigger_wins;
		}

		public bool end; // set this to end the running...
		public struct OddsRunFlags
		{
			public bool starburst;
			public bool simulate;
			public bool only_simulate;
			public bool hotball;
			public bool _5cashball;
			public bool double_action;
			public bool cardfile; // using a card file for game data...
			public bool database_run; // don't do early skips...
			public bool save_winning_cards;
			public bool use_blower;
			public bool quickshot;
			public bool Count_BINGO_Calls;
            public bool countColorBINGO;
            public bool lastBall;
		};

		/// <summary>
		/// This stores accumulated values by game_ID (matchign pattern sets)
		/// </summary>
		public class GameTypeInfo
		{
			public int plays;
			public int wins;
			public int games;
			public int[] best_wins;
			public int[] aways;
			public int starburst_marks;
			public int starburst_wins;
			public string name;
			public int BINGO_Call_Wins;         // added when the last 5 balls are B,I,N,G,O in any order
			public int BINGO_Call_Wins_ordered; // added when the last 5 balls are B,I,N,G,O in order
			public int BINGO_Call_Wins_on_card; // added when the last 5 balls are B,I,N,G,O
            public int BINGO_Same_Color;        // added when BINGO pattern is all same Random Color
            public int[] lastBalls;             // added with tracking last ball called, or BINGO ball

			public int[] colored_ball_hit; // 0 = 1ball, 1=2... 
			public int colored_ball_before_win;
		};

		public class GameInfo: BingoGame {
			public int prior_bestwin;
			public GameTypeInfo stats = new GameTypeInfo();
		};

		public List<GameTypeInfo> GameTypeList;
		public BingoTriggerBallStats trigger_stats = new BingoTriggerBallStats();
		public OddsRunFlags flags = new OddsRunFlags();
		//public CardFactory card_factory; 

		public int TotalCount;
		public int TotalCards;
		public int played;
		public int TotalWins;

		/// <summary>
		///  target counters... 
		/// </summary>
		public int Years;
		public int Days;
		public int Sessions;
		public int Halls;
		public int Games;

		public int Players;
		public int Cards;
		public int PackSize;
		public int MaxMarks; // or keno mode... number of marks to pick...
		public int colored_balls;

		/// <summary>
		///  active counters... _ counters are current...
		/// 
		/// </summary>
		public int _years;
		public int _days;
		public int _sessions;
		public int _total_sessions;
		public int _games;
		public int _total_games;
		public int _halls;
		public int _players;
		public int _cards;
		//public object step_lock = new object();

		public int maxgameid; // max game ID for creating hotball array... otherwise we have to check by going through all gaems.

		public List<BitVector32> patterns;

		// number of times a win happened also on the starburst...
		public int hotwins;

		// for simulation - track bestwin's hotball wins....
		public int besthotwins;

		public int ball_count;
		// number of times per count of balls that a card won...
		public int[] wins;
		public int[] aways;
		public int[] bestwins;
		/// <summary>
		/// indexed by game_number, ball_count
		/// </summary>
		public int[,] hotball_wins;

		DateTime base_date;
		public BingoSession bingo_session;

		internal BallDataInterface ball_data_interface; 
		//List<int> game_group_list;

		public OddsRunInfo( )
//			: base( session, allow_game_groups )
		{
			aways = new int[5];
			//game_group_list = allow_game_groups;
			hotwins = 0;
			ball_count = 75;
			wins = new int[ball_count+1];
			bestwins = new int[wins.Length];
			//balls = new BallData1();
			Years = 1;
			Days = 31;  // days in year to play... (subtract 104 (52*2) for no weekends for instance)
			Sessions = 8;
			Halls = 1;
			Players = 50;
			Cards = 18;
			Games = 12;
			PackSize = 6;
			flags.database_run = false;
			flags.simulate = true;
			//playing_cards = new card_list();
			//hotball_wins = new int[max_balls];
			//hotball_wins = null;// new int[(ball_count+1), wins.Length];
		}

		~OddsRunInfo()
		{
			//db.Dispose();
		}

		public void BeginRun()
		{
			_years = -1;
			_days = Days;
			_sessions = Sessions;
			_halls = Halls;
			_games = Games;
			_players = Players;
			_cards = Cards * Players;
			hotwins = 0;
			besthotwins = 0;
			TotalWins = 0;
			TotalCount = 0;
			played = 0;
			wins = new int[ball_count + 1];
			bestwins = new int[wins.Length];
			//hotball_wins = new int[max_balls];
			// 
			//card_factory = new CardFactory(ball_count);
			end = false;

			if (flags.database_run)
			{
				try
				{
					DbDataReader reader = StaticDsnConnection.KindExecuteReader( "select max(bingoday) from bingo_events_session_tracking" );
					if( reader != null && reader.HasRows )
					{
						reader.Read();
						if( !reader.IsDBNull( 0 ) )
						{
							DateTime val_time = DateTime.Now;
							try
							{
								base_date = reader.GetDateTime( 0 );
							}
							catch
							{
								String val = reader.GetString( 0 );
								base_date = Convert.ToDateTime( val ).AddDays( 1 );
							}
						}
						else
							base_date = new DateTime( 1972, 1, 1 );
					}
					else
						base_date = new DateTime( 1972, 1, 1 );
				}
				catch
				{
					base_date = DateTime.Now;
				}
			}
			else
				base_date = new DateTime(1972, 1, 1);

		}

		object step_lock = new object();

		// this is just the last session_event...
		BingoSessionEvent session_event;

		//GameInfo prior_game = null;
		public state Step()
		{
			state result = new state();
			//Log.log( "Begin Step" );
			lock( this.step_lock )
			{
				// check to see if we're trying to end this.
				if( end )
				{
					// valid will already be false.
					return result;
				}

				// check to see if the total duration is complete...
				if( _years == Years )
					return result;

				{
					{
						_total_games++;
						_games++;

						if( _games >= Games ) {
							// need to do a step of session.
							// setup some hotballs ....
							_total_sessions++;
							_sessions++;
							if( _sessions >= Sessions ) {
								_halls++;
								if( _halls >= Halls ) {
                                    _days++;
                                    if( _days >= Days ) {
										_years++;
										if( _years >= Years ) return result;// here, result is not stepped.
										_days = 0;
									}
									_halls = 0;
								}
								_sessions = 0;
							}
							_games = 0;

							/// have counted the session, and now session is correct.
							/// 
							// new session, create a new session event.
							session_event = new BingoSessionEvent( bingo_session, false );
							if( trigger_stats.enabled )
							{
								ball_data_interface.DropBalls();
								session_event.trigger_balls = ball_data_interface.CallBalls( 1 );
								ball_data_interface.DropBalls();
								session_event.triggered_balls = new int[trigger_stats.max_triggered];
								session_event.triggered_ball_won = new bool[trigger_stats.max_triggered];
							}
							session_event.SaveToDatabase = flags.database_run;
							session_event.Open( base_date.AddDays( _days ), _sessions + 1 );

                            // We need to add _days to the session_event.bingoday 
                            // here so StateWriter (in BingoGameCore, which knows
                            // nothing about the OddsRunInfo.state) will assign 
                            // the correct date to the records written to table 
                            // called_game_player_rank2.

                            session_event.bingoday = session_event.bingoday.AddDays( _days );

							{
								BingoPlayers players = new BingoPlayers(); // create some players.
								for( int p = 0; p < Players; p++ )
								{
									BingoPlayer player;
									players.Add( player = new BingoPlayer( Guid.NewGuid() ) );
									PlayerTransaction transaction;
									player.transactions.Add( transaction = new PlayerTransaction( player, p ) );
									foreach( BingoGameGroup bgg in session_event.session.GameGroups )
									{
										foreach( BingoPack pack in bgg.packs )
										{
											// something like this... so we can sell so many packs for players 
											// but now players are not just sets of cards.
											for( int n = 0; n < Cards/PackSize; n++ )
											{
												PlayerPack played;
												player.played_packs.Add( played = new PlayerPack() );
												played.transaction = transaction;
												played.pack_info = pack;
												played.start_card = pack.AutoDeal();
												played.pack_set = 1;
												played.player = player;
												played.pack_info.game_list = bingo_session.GameList;
												transaction.Add( played );
											}
										}
									}
								}
								session_event.PlayerList = players;
							}
						}

						/// have counted the games and the game is correct.
						session_event.StepToUsing( _games, (BingoGameState)result, ball_data_interface ); // this is passed game index... 

						session_event.LoadPlayerCards( result );
						result.Year = _years;
						result.Day = _days;

						result.Hall = _halls;
						result.Game = _games;

                        // here we can keep going, it's counting... maybe
						// something like skipping a game for some reason causes invalidity...
						// which is not terminal.
						result.stepped = true;
					}
				}
				//Log.log( "Created session evnet and players in session" );

				// return this state so we can unlock it.
				// with these balls and cards referenced
				// we should not have a problem with multi-threading this.
				return result;
			}
		}

        /// <summary>
        /// Counts BINGOs when the entire BINGO is the same random generated color;
        /// </summary>
        /// <param name="s"></param>
        /// <param name="playing_balls"></param>
        //public static int CountRandomColorBingo( ref BingoGameState s, int[] playing_balls )
        int CountRandomColorBingo( state s )
        {
            int[] ball_array = s.game_event.playing_balls;
            int num_matches = 0;

            if (s != null)
            {
                int row = 0;
                int col = 0;
				int color;
                int cardGridValue = 0;
                int bitMask;
                bool matches;

				char[] randomColors = s.game_event.balls.GetRandomColors();

                // Check the mask against the card, get the number from the card,
                // and look up the color in the random color table.

                foreach (wininfo card in s.winning_cards)
                {
					color = (int)0x00;
                    matches = true;
                    bitMask = 0x01000000;

                    for (row = 0; matches && row < 5; row++)
                    {
                        for (col = 0; matches && col < 5; col++)
                        {
                            if ((card.mask & bitMask) == bitMask)
                            {
                                cardGridValue = card.playing_card.CardData[0, col, row];
                                if (color == 0x00)
                                    color = randomColors[cardGridValue - 1];
                                else if (color != randomColors[cardGridValue - 1])
                                    matches = false;
                            }
                            bitMask /= 2;
                        }
                    }

                    if (matches)
                    {
                        card.random_color_match = true;
                        num_matches++;
                    }
                }
            }

            return num_matches;
        }

        /// <summary>
        /// Add to the counts in game.stats.
        /// Check for the five last ball calls coming from the B, I, N, G, O columns.
        /// Check for the bingo pattern matching the same color code from the random color table.
        /// </summary>
        /// <param name="s"> bingo_odds.OddsRunInfo.state value</param>
        void CountStats( state s )
		{
			GameInfo game = s.game as GameInfo;
            int winners = s.winning_cards.Count;

			for (int cn = 0; cn < s.playing_cards.Count; cn++) {
				BingoCardState card = s.playing_cards[cn];
				if (card.marks.Count != 0 ) {
					BingoCardState.BingoCardPatternMarkInfo cs = card.marks[card.marks.Count - 1];
					if (cs.best_away < 5 && cs.best_away > 0 ) {
						game.stats.aways[cs.best_away-1]++;
					}
				}
			}

            game.stats.wins += winners;
            game.stats.best_wins[ s.bestwin ] += winners;
            game.stats.plays++;

			if( s.game_event.playing_balls != null 
				&& s.game_event.playing_balls.Length > 0 )
			{
				int lastball = s.game_event.playing_balls[s.game_event.playing_balls.Length - 1] - 1;
				if( lastball >= 0 )
					game.stats.lastBalls[lastball] += 1;
			}
            wins[s.bestwin] += winners;
            bestwins[s.bestwin] += s.bestwincount;
            TotalWins += winners;
            TotalCards += s.Cards;
            TotalCount += winners;

			if( colored_balls > 0 )
			{
				int[ ] ball_array = s.game_event.playing_balls;
				int balls = ball_array.Length;
				int n;
				int step = 0;
				for( n = 0; n < balls; n++ )
				{
					if( ball_array[n] < 0 )
						game.stats.colored_ball_hit[step++]++;
				}
				if( balls > 2 )
					if( ball_array[balls - 2] < 0 )
						game.stats.colored_ball_before_win++;
			}

            if( flags.Count_BINGO_Calls )
            {
                // If we're ignoring a column, we won't match on
                // the last five calls containing the BINGO letters.
                if( !s.game.ignore_b_balls &&
                    !s.game.ignore_i_balls &&
                    !s.game.ignore_n_balls &&
                    !s.game.ignore_g_balls &&
                    !s.game.ignore_o_balls )
                {
                    int[ ] ball_array = s.game_event.playing_balls;
                    int balls = ball_array.Length;
                    int counter;
                    int bits = 0;
                    int ordered_bits = 0;

                    for( counter = balls - 1; counter > ( balls - 6 ) && counter >= 0; counter-- )
                    {
                        int bit = ( 1 << ( ( ball_array[ counter ] - 1 ) / 15 ) );
                        switch( bit )
                        {
                            case 1:
                                if( ordered_bits == 0x1E )
                                    ordered_bits |= bit;
                                break;
                            case 2:
                                if( ordered_bits == 0x01C )
                                    ordered_bits |= bit;
                                break;
                            case 4:
                                if( ordered_bits == 0x018 )
                                    ordered_bits |= bit;
                                break;
                            case 8:
                                if( ordered_bits == 0x010 )
                                    ordered_bits |= bit;
                                break;
                            case 16:
                                if( ordered_bits == 0 )
                                    ordered_bits |= bit;
                                break;
                        }
                        bits |= bit;
                    }
                    if( ordered_bits == 0x1f )
                        game.stats.BINGO_Call_Wins_ordered++;
                    if( bits == 0x1F )
                        game.stats.BINGO_Call_Wins++;
                }
            }

            if( flags.countColorBINGO )
            {
                // CHECK FOR SAME COLOR BINGO USING RANDOM COLOR GENERATOR
                int color_count = CountRandomColorBingo( s );

                if (color_count > 0)
                {
                    game.stats.BINGO_Same_Color += color_count;
                }
            }
		}

        public void Play( state s )
		{

			//do
			{
				//Log.log( "Play" );
				try
				{
					BingoMatchEngine.Play( s as BingoGameState );
				}
				catch( Exception e )
				{
					Log.log( e.Message );
				}
				// collect addtional local stats...
				// should consider moving some of what got put into the lower
				// core levels up to here....
			}
			//while( s.bestwincount == 0 );
			//Log.log( "Calculate..." );

            CountStats( s );

            // really this part should be an application feature...
			//Log.log( "Completed..." );
		}

		class initialized
		{
			public bool binitialized;
		}
		initialized i = new initialized();
        public BingoDealer dealer;


		public void WriteXml( String name )
		{
			// save runinfo state here... years, days, sessions, players....
			XmlWriter w = XmlWriter.Create( name );
			w.WriteStartDocument( true );
			w.WriteDocType( "odds_runinfo", null, null, null );
			w.WriteRaw( "\r\n" );
			w.WriteStartElement( "runinfo" );
			w.WriteAttributeString( "Years", Years.ToString() );
			w.WriteAttributeString( "Days", Days.ToString() );
			w.WriteAttributeString( "Sessions", Sessions.ToString() );
			w.WriteAttributeString( "Halls", Halls.ToString() );
			w.WriteAttributeString( "Games", Games.ToString() );
			w.WriteAttributeString( "Players", Players.ToString() );
			w.WriteAttributeString( "Cards", Cards.ToString() );
			w.WriteAttributeString( "PackSize", PackSize.ToString() );
			if( dealer != null )
				w.WriteAttributeString( "cardset_range", dealer.ToString() );
			w.WriteAttributeString( "trigger", trigger_stats.enabled.ToString() );
			if( trigger_stats.enabled )
				w.WriteAttributeString( "trigger_balls", trigger_stats.max_triggered.ToString() );

			// xperdex wrapper so we have one root.  local is it's own section.
			w.WriteEndElement();
			w.WriteRaw( "\r\n" );
			w.Close();

		}

		public void ReadXml( string name, DataTable ranges )
		{
			XmlDocument xd = new XmlDocument();
			if( !System.IO.File.Exists( name ) )
				return;
			xd.Load( name );
			// the xd loader ends up with a full pathname with successful load
			// grab this so we can save to the same file.
			//local.ConfigName = xd.BaseURI.Substring( 8 );

			XPathNavigator xn = xd.CreateNavigator();
			//XPathNavigator xn2 = xn.CreateNavigator();
			xn.MoveToFirst();
			xn.MoveToFirstChild();
			if( xn.NodeType == XPathNodeType.Element )
			{
				if( String.Compare( xn.Name, "runinfo" ) == 0 )
				{
					bool okay;
					for( okay = xn.MoveToFirstAttribute();
						okay;
						okay = xn.MoveToNextAttribute() )
					{
						switch( xn.Name )
						{
                        case "cardset_range":
                            //DataRow[] rows = ranges.Select( OpenSkieScheduler.BingoGameDefs.CardsetRange.NameColumn +"='"+xn.Value  +"'");
                            //if( rows.Length > 0 )
                            //    cardreader = new CardReader( rows[0] );
                            break;
						case "Years":
							Years = Convert.ToInt32( xn.Value );
							break;
						case "Days":
							Days = Convert.ToInt32( xn.Value );
							break;
						case "Halls":
							Halls = Convert.ToInt32( xn.Value );
							break;
						case "Sessions":
							Sessions = Convert.ToInt32( xn.Value );
							break;
						case "Games":
							Games = Convert.ToInt32( xn.Value );
							break;
						case "Players":
							Players = Convert.ToInt32( xn.Value );
							break;
						case "Cards":
							 Cards= Convert.ToInt32( xn.Value );
							break;
						case "PackSize":
							PackSize = Convert.ToInt32( xn.Value );
							break;
						case "trigger":
							if( String.Compare( xn.Value, "True", true ) == 0 )
								trigger_stats.enabled = true;
							else
								trigger_stats.enabled = false;
							break;
						case "trigger_balls":
							trigger_stats.max_triggered = xn.ValueAsInt;
							break;
						}
					}
					xn.MoveToParent();
				}
				xn.MoveToParent();
			}
			// dispose of xml reader resources...
			xn = null;
			xd = null;
		}

		public bool SaveToDatabase
		{
			get
			{
				return session_event.SaveToDatabase;
			}
			set
			{
				session_event.SaveToDatabase = value;
			}
		}
	}
}
