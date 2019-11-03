using System;
using System.Collections.Generic;
using System.Data;
using System.Threading;
using BingoGameInterfaces;
using xperdex.classes;

namespace BingoGameCore4
{
	/// <summary>
	/// this is a specific instance of a session
	/// contains players and game events
	/// Returns BingoGameStates ... this EventSession can be used to StepTo a game, which results in a BingoGameState
	/// </summary>
	public class BingoSessionEvent
	{

		public BallDataInterface ball_data;

		public BingoSession session;

        BingoGameEvent prior_game_event;

		bool my_store_to_database;

		// these numbers may change while the session is the same.
		/// <summary>
		/// this session event's bingoday - may differ from session.bingoday
		/// </summary>
		public DateTime bingoday;

		/// <summary>
		/// this is the session number on the day in question.
		/// </summary>
		public int session_number;

		public object step_lock = new object();

		int current_game_index;

		/// <summary>
		/// progressive second/third chance games are skipped.
		/// </summary>
		///public bool ignore_same_pattern_progressives;

		//public List<BingoGameState> states = new List<BingoGameState>();
		// number of times a win happened also on the starburst...
		public int hotwins;

		// for simulation - track bestwin's hotball wins....
		public int besthotwins;


		public int[] trigger_balls;   // list of balls that trigger another ball
		public int[] triggered_balls; // list of balls that have been triggered
		public bool[] triggered_ball_won;

		//List<int> game_group_list;
		//DateTime my_bingoday;
		//public int session_number;

		/// <summary>
		/// this is basicially one for each schedule (played) game. (session.GameList)
		/// </summary> 
		public List<BingoGameState> BingoGameEvents = new List<BingoGameState>();
		/// <summary>
		/// These are actively playing games.
		/// </summary>
		public List<BingoGameState> active_games = new List<BingoGameState>();

		public BingoSessionEvent( BingoSession base_session, bool create_playerlist )
		{
			session = base_session;

			//game_group_list = game_groups;
			session_number = base_session.session;
			bingoday = base_session.bingoday;
			if( create_playerlist )
			{
				_PlayerList = new BingoPlayers( this );
			}
		}

		public BingoSessionEvent( BingoSession base_session, BallDataInterface bdi )
		{
			session = base_session;
			ball_data = bdi;

			//game_group_list = game_groups;

			session_number = base_session.session;

			bingoday = base_session.bingoday;

			_PlayerList = new BingoPlayers( this );

		}

		public BingoPlayers _PlayerList;
		/// <summary>
		/// assigning player list makes sure the cards are in play in this session, that we will have enough froom for all cards a player will play at a time.
		/// </summary>
		public BingoPlayers PlayerList
		{
			get
			{
				return _PlayerList;
			}
			set
			{
				_PlayerList = value;
			}
		}

		public void LoadPlayers( )
		{
			List<PlayerTransaction> new_players = _PlayerList.LoadPlayers();

            if( new_players != null )
            {
				foreach( BingoPlayer player in _PlayerList )
					foreach( PlayerTransaction player_transaction in player.transactions )
					{
						// for all previously played games, we found a new player, update him with all of his 
						// cards for all game states...
						if( active_games != null )
						{
							foreach( BingoGameState game_state in active_games )
								LoadPlayerCards( player_transaction, null, game_state );
						}
					}
            }
		}


		public void StoreCards( int game_index )
		{
			foreach( BingoPlayer player in PlayerList )
			{
				foreach( PlayerTransaction transnum in player.transactions )
				{
					foreach( PlayerPack pack in player.played_packs )
					{
						foreach( BingoCardState card in pack.Cards[game_index] )
						{
						}
					}
				}
			}

		}
		// all cards in the session? the game lists should maintain this good enough?
		//public card_list playing_cards;



		/// <summary>
		/// This completes final initialization fo a bingo game state, including loading the cards for each player
		/// </summary>
		/// <param name="game_index">if game== null, index will be used to get the GameList entry at the index.</param>
		/// <param name="result">this is the partial state we're going to use...</param>
		/// <returns>result or NULL if fails</returns>
		public BingoGameState StepToUsing( int game_index, BingoGameState result, BallDataInterface bdi = null )
		{
			// setup a play state for an absolute game number...
			// get one game of all the ones defined in the bingo core state...

			lock( this.step_lock )
			{
				BingoGame game = null;
				result.game_needs_balls = false;

				// no games in state.
				if( session.GameList == null || session.GameList.Count == 0 )
					// return an early result (no process)
					return result;

				result.session_event = this;
				{
					{
						// if game is already set, no reason to use game_index
						if( result.game == null )
						{
							if( game_index >= session.GameList.Count )
							{
								Log.log( "StepTo passed a game number beyond the current list." );
								return result;
								// need to do a step of session.
								// setup some hotballs ....
							}

							// new session, played all players and all their cards
							game = session.GameList[game_index];
						}
						else
							game = result.game;
						// should wait before running the NEXT game...
						// for that game to finish... 
						while( game.playing )
							Thread.SpinWait( 1 );

						if( result.game == null )
						{
							// though at this point I should have result.session_event... and we should have 
							// been progressing through that...


							// with events, I need to know the prior event ....
							// but the threaded nature of this makes this impossible... since we are
							// not really within a session container... it's really an observation of 
							// game by game... 

							if( prior_game_event != null && game.prior_game != null && game.into )
							{
								result.game_event = BingoGameEvent.Continue( prior_game_event, game );
								result.game_event_index = result.game_event.games.Count - 1;
							}
							else
							{
								result.game_event = new BingoGameEvent( game, bdi );
								prior_game_event = result.game_event;
							}

							string[ ] str = game.Name.Split( '\t' );
							if( my_store_to_database )
								game.ID = Local.bingo_tracking.OpenGame( game_index + 1, game.ballset_number, str[1] ); //game.Name );

							if( game.number_colored > 0 )
							{
								int[] newballs = new int[game.number_colored];
								int n;
								for( n = 0; n < game.number_colored; n++ )
									newballs[n] = -1 - n;
								result.game_event.balls.AddExtraBalls( newballs );
							}
                            if( game.cashballs == 5 )
							{
								byte[] card = result.game_event.card_factory.Create5Card();
								result.game_event.playing_hotballs = new int[card.Length];
								for( int n = 0; n < card.Length; n++ )
									result.game_event.playing_hotballs[n] = card[n];
							}
                            else 
                            {
                                result.game_event.playing_hotballs = result.game_event.balls.CallBalls( game.cashballs );
                            }
						}
					}
				}

				result.bestwin = session.max_balls;// game.bestwin; // start at more than any level...

				// this is indexed with -1... soo [card, ball-1] == count away.
				result.winning_cards = new List<wininfo>();
				// this resultset is the whole sess's cards?
				result.playing_cards = new List<BingoCardState>();  // playing_cards;
				result.playing_packs = new List<PlayerPack>();

				result.valid = true;

				result.session_event = this;

                List<object> game_pack_set_ids = new List<object>();
				if( opened )
				{
					if( my_store_to_database )
						//foreach( BingoGameGroup group in result.game.game_groups )
						{
							game_pack_set_ids.Add( result.game.game_group.group_pack_set_id = Local.bingo_tracking.AddPackSetToGame( result.game.game_group.pack_set_id ) );
						}
				}
				else
					game_pack_set_ids.Add( Guid.Empty );

				/*
				if( _PlayerList != null )
				{
					foreach( BingoPlayer player in _PlayerList )
					{
						LoadPlayerCards( player, game_pack_set_ids, result );
					}
				}
				*/
				// return this state so we can unlock it.
				// with these balls and cards referenced
				// we should not have a problem with multi-threading this.
				return result;
			}
		}

		public BingoGameState StepTo( int game_index )
		{
			BingoGameState result;
			result = new BingoGameState();

			active_games.Add( result );

			return StepToUsing( game_index, result );
		}

		public BingoGameState[] StepToReplay( DataRow row )
		{
			BingoGameState[] results = null;
			int game_number=  (int)row["game_id"];
			int found = 0;
			foreach( BingoGame game in session.GameList )
			{
				if( game_number == game.game_number )
					found++;
			}
			Log.log( "Found " + found + " games using game number " + game_number );
			if( found > 0 )
			{
				results = new BingoGameState[found];
				found = 0;
				foreach( BingoGame game in session.GameList )
				{
					if( game.game_number == game_number )
					{
						results[found] = new BingoGameState();
						//results[found].game = game;
						results[found].game_event = new BingoGameEvent( ( row.Table as MySQLDataTable ).Connection
							, this, row );
						results[found].game_event.games.Add( game );

						//results[found].game_event.playing_balls = new byte[0];
						// fill in the remaininig common info
						StepToUsing( 0, results[found] );

						found++;
					}
				}				
			}
			return results;
		}

		public BingoGameState StepToReplay( int game_index )
		{
			BingoGameState result;
			if( game_index < this.BingoGameEvents.Count && this.BingoGameEvents[game_index] != null )
			{
				result = this.BingoGameEvents[game_index];
				return StepToUsing( game_index, result );
			}

			result = new BingoGameState();

			if( game_index >= session.GameList.Count )
				return result;
			// setup this ahead of time.
			//result.game = session.GameList[game_index];
			result.game_event = new BingoGameEvent( Local.dsn, this, game_index );
			result.game_event.games.Add( result.game );

			while( game_index >= BingoGameEvents.Count )
				BingoGameEvents.Add( null );

			BingoGameEvents[game_index] = result;

			return StepToUsing( game_index, result );
		}

		public void BeginPlay()
		{
			current_game_index = 0;
		}

		public BingoGameState Step()
		{
			// get one game of all the ones defined in the bingo core state...
			BingoGameState result = new BingoGameState();
			lock( this.step_lock )
			{
				BingoGame game = null;

				if( session.GameList == null )
				{
					return result;
				}

				if( session.GameList.Count == 0 )
					// return an early result (no process)
					return result;

				{
					if( game != null && game.prior_game != null )
					{
						// game we're coming from has to finish playing...
						while( game.prior_game.playing )
						{
							Thread.SpinWait( 1 );
						}
					}
				}
				return StepTo( current_game_index++ );
			}
		}

		public BingoGameState StepReplay( bool use_blower )
		{
			// get one game of all the ones defined in the bingo core state...
			lock( this.step_lock )
			{
				BingoGame game = null;
				if( session.GameList == null )
				{
					return null;
				}

				if( session.GameList.Count == 0 )
					// return an early result (no process)
					return null;

				{
					if( game != null && game.prior_game != null )
					{
						// game we're coming from has to finish playing...
						while( game.prior_game.playing )
						{
							Thread.SpinWait( 1 );
						}
					}
				}

				return StepToReplay( current_game_index++ );
			}
		}

		/// <summary>
		/// This literally loads the packs each player is playing into the bingo game state
		/// </summary>
		/// <param name="_Player"></param>
		/// <param name="s"></param>
		void LoadPlayerCards( PlayerTransaction transaction, List<object> game_pack_set_ids, BingoGameState s )
		{
			bool pack_pattern = BingoMatchEngine.IsPackPattern( s );
			int pack_pattern_size = BingoMatchEngine.GetPackCardGroupSize( s );
			int pack_number = 0;
			BingoGameGroup game_group = s.game.game_group;
			BingoPlayer _Player = transaction.player;

			while( _Player._played_cards.Count <= game_group.game_group_ID )
			{
				_Player._played_cards.Add( new List<BingoCardState>() );
			}

			List<BingoCardState> player_card_list = _Player._played_cards[game_group.game_group_ID];

			// already loaded these cards?
			while( game_group.game_group_ID >= transaction.loaded.Count )
				transaction.loaded.Add( false );
			if( transaction.loaded[game_group.game_group_ID] )
			{
				foreach( BingoCardState card in _Player._played_cards[game_group.game_group_ID] )
				{

					s.playing_cards.Add( card.Clone() );
				}
				return;
			}
			//player_card_list.Clear();


			//foreach( PlayerTransaction trans in _Player.transactions )
			{
				foreach( PlayerPack _pack in transaction )
				{
					bool skip_pack = true;
					if( _pack.pack_info.game_groups.Count > 0 )
					{
						foreach( BingoGameGroup group in _pack.pack_info.game_groups )
							if( group.Contains( s.game ) )
							{
								// this pack is in this game, load cards for it.
								game_group = group;
								skip_pack = false;
								break;
							}
						if( skip_pack )
							continue;
					}
					while( _pack.Cards.Count <= game_group.game_group_ID )
					{
						_pack.Cards.Add( new List<BingoCardState>() );
					}

					pack_number++;

					_pack.played = true;

					int card_count = _pack.pack_info.count;// s.game.GetCardCount( _pack.pack_info );
					if( _pack.pack_info.count == 0 )
					{
						// pack does not play this game, skip it.
						continue;
					}

					s.playing_packs.Add( _pack );

					List<BingoCardState> game_cards = _pack.Cards[game_group.game_group_ID];

					if( game_cards.Count < card_count )
					{
						if( _pack.dealer == null )
						{
							if( _pack.pack_info.dealers.Count == 1 )
								_pack.dealer = _pack.pack_info.dealers[0];
							else
							{
								Log.log( "Fatality, dealer not assigned on pack." );
								continue;
							}
						}

						int base_real_card = _pack.dealer.Add( ( _pack.start_card ),
							!_pack.paper
								? s.game.ballset_number
								: s.game.page_skip );

						//if( base_real_card > 320000 )
						{
							//	MessageBox.Show( "Card is out of range!" );
						}


						int col = 0;
						int row = 0;
						for( int card = 0; card < card_count; card++ )
						{
							byte[, ,] card_faces;
							row++;
							if( row >= _pack.pack_info.rows )
							{
								col++;
								row = 0;
							}
							//if( col == _pack.pack_info.
							// dealer does a subtract 1, this is a 0 based physical card index.
							int unit_card = _pack.dealer.GetNext( base_real_card, row, col, card );
							int real_card = _pack.dealer.GetPhysicalNext( base_real_card, row, col, card );

							if( _pack.dealer.card_data == null )
							{
								card_faces = new byte[1, 5, 5] { { { 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0 } } };
							}
							else
								card_faces = _pack.dealer.card_data.Create(
									 real_card
									 , _pack.pack_info.flags.double_action ? 2 : 1
									, _pack.pack_info.flags.starburst
									);


							BingoCardState cs = new BingoCardState( card_faces
								, _Player, _pack, unit_card, real_card
								, s.game_event );
							//cs.player = _Player;
							//cs.pack = _pack;
							//cs.unit_card_number = unit_card;
							//cs.cardset_card_number = real_card;
							//cs.game = s.game_event;

							// this is actually PlayerPack.Cards.Add()...
							game_cards.Add( cs );
							cs.pack_card_index = game_cards.IndexOf( cs );

							player_card_list.Add( cs );
							s.playing_cards.Add( cs );

							if( s.session_event.opened )
							{
								cs.ID = Local.bingo_tracking.AddCard( game_group.group_pack_set_id, _pack.ID, s.game.ballset_number, cs.unit_card_number, cs.CardData );
							}
						}
					}
					else
					{
						for( int card = 0; card < card_count; card++ )
						{
							BingoCardState cs = _pack.Cards[game_group.game_group_ID][card];
							s.playing_cards.Add( cs );
							player_card_list.Add( cs );
							if( s.session_event.opened )
							{
								cs.ID = Local.bingo_tracking.AddCard( null, _pack.ID, s.game.ballset_number, cs.unit_card_number, cs.CardData );
							}
						}
					}
				}
				transaction.loaded[game_group.game_group_ID] = true;
			}
		}

		/// <summary>
		/// This literally loads the packs each player is playing into the bingo game state
		/// </summary>
		/// <param name="_Player"></param>
		/// <param name="s"></param>
		void LoadPlayerCards( BingoPlayer _Player, List<object> game_pack_set_ids, BingoGameState s )
		{
			int pack_number = 0;
			BingoGameGroup game_group = s.game.game_group;
			while( _Player._played_cards.Count <= game_group.game_group_ID )
			{
				_Player._played_cards.Add( new List<BingoCardState>() );
			}

			List<BingoCardState> player_card_list = _Player._played_cards[game_group.game_group_ID];

			// already loaded these cards?
			if( player_card_list.Count > 0 )
				return;
			//player_card_list.Clear();

			//foreach( PlayerTransaction trans in _Player.transactions )
			{
				foreach( PlayerPack _pack in _Player.played_packs )
				{
					bool skip_pack = true;
					if( _pack.pack_info.game_groups.Count > 0 )
					{
						foreach( BingoGameGroup group in _pack.pack_info.game_groups )
							if( group.Contains( s.game ) )
							{
								// this pack is in this game, load cards for it.
								game_group = group;
								skip_pack = false;
								break;
							}
						if( skip_pack )
							continue;
					}
					while( _pack.Cards.Count <= s.game.game_ID )
					{
						_pack.Cards.Add( new List<BingoCardState>() );
					}

					pack_number++;

					_pack.played = true;

					int card_count = _pack.pack_info.count;// s.game.GetCardCount( _pack.pack_info );
					if( _pack.pack_info.count == 0 )
					{
						// pack does not play this game, skip it.
						continue;
					}

					s.playing_packs.Add( _pack );

					List<BingoCardState> game_cards = _pack.Cards[s.game.game_ID];

					if( game_cards.Count < card_count )
					{
						if( _pack.dealer == null )
						{
							Log.log( "Fatality, dealer not assigned on pack." );
							continue;
						}

						int base_real_card = _pack.dealer.Add( ( _pack.start_card ),
							!_pack.paper
								? s.game.ballset_number
								: s.game.page_skip );

						//if( base_real_card > 320000 )
						{
							//	MessageBox.Show( "Card is out of range!" );
						}


						int col = 0;
						int row = 0;
						for( int card = 0; card < card_count; card++ )
						{
							byte[, ,] card_faces;
							row++;
							if( row >= _pack.pack_info.rows )
							{
								col++;
								row = 0;
							}
							//if( col == _pack.pack_info.
							// dealer does a subtract 1, this is a 0 based physical card index.
							if( base_real_card == 512301 )
							{
								int a = 3;
							}
							int unit_card = _pack.dealer.GetNext( base_real_card, row, col, card );
							int real_card = _pack.dealer.GetPhysicalNext( base_real_card, row, col, card );

							if( _pack.dealer.card_data == null )
							{
								card_faces = new byte[1, 5, 5] { { { 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0 } } };
							}
							else
							{
								if( _pack.pack_info.name == "Double Double" || _pack.pack_info.name == "Dual Daub" )
								{
									int a = 3;
								}
								card_faces = _pack.dealer.card_data.Create(
									 real_card
									 , _pack.pack_info.flags.double_action ? 2 : 1
									, _pack.pack_info.flags.starburst
									);
							}

							BingoCardState cs = new BingoCardState( card_faces );
							cs.player = _Player;
							cs.pack = _pack;
							//cs.prize_level_id = _pack.pack_info._dealer.prize_level_id;
							cs.unit_card_number = unit_card;
							cs.cardset_card_number = real_card;
							cs.game = s.game_event;
							game_cards.Add( cs );
							cs.pack_card_index = game_cards.IndexOf( cs );

							player_card_list.Add( cs );
							s.playing_cards.Add( cs );

							if( s.session_event.opened )
							{
								cs.ID = Local.bingo_tracking.AddCard( game_group.group_pack_set_id, _pack.ID, s.game.ballset_number, cs.unit_card_number, cs.CardData );
							}
						}
					}
					else
					{
						for( int card = 0; card < card_count; card++ )
						{
							BingoCardState cs = _pack.Cards[s.game.game_ID][card];
							s.playing_cards.Add( cs );
							player_card_list.Add( cs );
							if( s.session_event.opened )
							{
								cs.ID = Local.bingo_tracking.AddCard( null, _pack.ID, s.game.ballset_number, cs.unit_card_number, cs.CardData );
							}
						}
					}
				}
			}
		}

		public void LoadPlayerCards( BingoGameState game_event )
		{
			foreach( BingoPlayer player in _PlayerList )
				foreach( PlayerTransaction player_transaction in player.transactions )
					LoadPlayerCards( player_transaction, null, game_event );

		}

		public void DoPlayState( object param )
		{
			BingoGameState s = param as BingoGameState;
			if( s.valid )
			{
				session.UpdateStatus( "Playing game " + s.game.game_number + "(" + s.game.game_ID + ")" + " in session " + session_number + " on " + bingoday.Date + "..." );
				BingoMatchEngine.Play( s );
				session.UpdateStatus( "Game completed " + s.game.game_number + "(" + s.game.game_ID + ")" + " in session " + session_number + " on " + bingoday.Date + "..." );
			}
			else
				session.UpdateStatus( "Invalid state. Ignoring." );
		}

		void DoPlay()
		{
			BingoGameState s;
			while( true )
			{
				s = this.Step();
				BingoGameEvents.Add( s );
				if( s.valid )
				{
					session.UpdateStatus( "Checking game " + s.game.game_number + "("+s.game.game_ID+")"+ " in session " + session_number + " on " + bingoday.Date + "..." );
					if( StateWriter.CheckState( ref s ) )
					{
						session.UpdateStatus( "Playing game " + s.game.game_number + "(" + s.game.game_ID + ")" + " in session " + session_number + " on " + bingoday.Date + "..." );
						//status.Refresh();
						BingoMatchEngine.Play( s );
					}
					else
					{
						//MessageBox.Show( "Game:" + s.game.game_number + " in Session:" + ( GameList.session ) + " on " + GameList.bingoday + " has already been rated...\nIgnoring" );
					}
				}
				else
					break;
			}
			if( s.game != null )
				session.UpdateStatus( "Game completed " + s.game.game_number + "(" + s.game.game_ID + ")" + " in session " + session_number + " on " + bingoday.Date + "..." );
			//status.Refresh();
		}

#if no_play_one
		void DoPlayOne( object param )
		{
			int game = Convert.ToInt32( param );
			BingoGameState s;
			//while( true )
			{
				s = this.StepTo( game );
				if( s.valid )
				{
					session.UpdateStatus( "Checking game " + s.game.game_number + "(" + s.game.game_ID + ")" + " in session " + session_number + " on " + bingoday.Date + "..." );
					if( StateWriter.CheckState( ref s ) )
					{
						session.UpdateStatus( "Playing game " + s.game.game_number + "(" + s.game.game_ID + ")" + " in session " + session_number + " on " + bingoday.Date + "..." );
						Play( s );
					}
					else
					{
						//MessageBox.Show( "Game:" + s.game.game_number + " in Session:" + ( GameList.session ) + " on " + GameList.bingoday + " has already been rated...\nIgnoring" );
					}
				}
				//else
				//	break;
			}
			session.UpdateStatus( "Rating completed..." );
			//status.Refresh();
		}

#endif
		Thread t;
		public bool Active
		{
			get
			{
				if( t != null )
					return t.IsAlive;
				return false;
			}
		}

		//static int play_lock;
		public void Play(  )
		{
			t = new Thread( DoPlay );
			t.Start();
		}

		//static int play_lock;
		/// <summary>
		/// Plays a single bingo event.
		/// </summary>
		/// <param name="State">the state to play - should have used a 'Step' function to get this</param>
		public void PlayGame( BingoGameState State )
		{
			BingoMatchEngine.Play( State );
			if( opened )
			{
				BingoPrize.ComputePrizes( State.game_event, State.game, State.winning_cards );
				foreach( wininfo win in State.winning_cards )
					Local.bingo_tracking.AddWinner( win.playing_card.ID, win.mask, win.amount );
			}
		}

		public void PlayGameCurrentBalls( BingoGameState State )
		{
			BingoMatchEngine.PlayNow( State );
			if( State.bestwincount > 0 )
			{
				if( opened )
				{
					BingoPrize.ComputePrizes( State.game_event, State.game, State.winning_cards );
					foreach( wininfo win in State.winning_cards )
						Local.bingo_tracking.AddWinner( win.playing_card.ID, win.mask, win.amount );
				}
			}
		}

		BingoGameState current_state;
		public void BeginGame( BingoGameState state )
		{
			//state.session_event.ball_data.BallCalled += new BingoEvents.SimpleIntEvent( ball_data_BallCalled );
		}

		public void EndGame( BingoGameState state )
		{
			//state.session_event.ball_data.BallCalled -= new BingoEvents.SimpleIntEvent( ball_data_BallCalled );
		}

		void ball_data_BallCalled( object sender,BingoEvents.BingoSimpleIntEventArgs e )
		{
			PlayGameCurrentBalls( current_state );
		}

		/// <summary>
		/// Plays a single bingo event; in a thread.
		/// </summary>
		/// <param name="State">the state to play - should have used a 'Step' function to get this</param>
		public void Play( BingoGameState State )
		{
			Log.log( "Starting new state... game:" + State.game );
			t = new Thread( DoPlayState );
			t.Start(State);
		}

		public void CloseGame( BingoGameState state )
		{
			active_games.Remove( state );
		}

		public void Open( DateTime bingoday, int session_number )
		{
			if( my_store_to_database )
				Local.bingo_tracking.OpenSession( bingoday, session_number, session.ToString() );
		}

		internal bool opened;
		public void Open(  )
		{
			if( my_store_to_database )
				Local.bingo_tracking.OpenSession( bingoday, session_number, session.session_name );
			opened = true;
		}

		public void Close()
		{
			if( my_store_to_database )
				Local.bingo_tracking.CloseSession();

		}

		public void StorePlayers()
		{
			if( !my_store_to_database )
				return;
			if( opened )
			{
				foreach( BingoGameGroup group in session.GameGroups )
				{
					if( group.pack_set_id == Guid.Empty )
					{
						group.pack_set_id = Local.bingo_tracking.DefinePackSet();
					}
				}
				foreach( BingoPlayer player in PlayerList )
				{
					player.ID = Local.bingo_tracking.AddPlayer();
					foreach( PlayerTransaction trans in player.transactions )
					{
						Guid transid = Local.bingo_tracking.AddTransaction( player.ID, trans.transnum );
						foreach( PlayerPack _pack in trans )
						{
							foreach( BingoGameGroup group in _pack.pack_info.game_groups )
							{
								_pack.ID = Local.bingo_tracking.AddPack( group.pack_set_id, trans.ID );
							}
						}
					}
				}
			}
		}


		public bool SaveToDatabase
		{
			get
			{
				return Local.StoreToDatabase;
			}
			set
			{
				my_store_to_database = value;
				Local.StoreToDatabase = value;
			}
		}
	}
}
