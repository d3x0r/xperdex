using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using xperdex.classes;

namespace BingoGameCore4
{
	/// <summary>
	/// This structure is used by rate-rank code to track points/card
	/// </summary>
	public class CardPoints
	{
		public int away;
		public int points;
	}

	
	public class BingoPackState
	{
		public int[] combination;
		public int best_away;  // total away for this pack card-group
		public int best_card_away; // used for how many balls to get...
		public int group_size;
	}

	public class PlayerPack
	{
		public Guid ID;
		public PlayerTransaction transaction;
		public BingoPack pack_info;
        public List<BingoGameGroupPrizeLevel> game_group_prize_levels;

		public BingoDealer dealer;

        public int start_card;
        public bool electronic;
		public bool paper;
		public bool played;
        public int pack_set; // 'Manager's Special.'  set identifier.
		
		public BingoPlayer player;

        /// <summary>
		/// indexed with[game][card], pages, list of cards
        /// </summary> 
		public List<List<BingoCardState>> Cards = new List<List<BingoCardState>>();
		/// <summary>
		/// indexed with[game][card], get points and away status per-card within this pack (as it was played in this game)
		/// </summary>
		public List<List<CardPoints>> card_away_count = new List<List<CardPoints>>();

		public int unit_number;

		/// <summary>
		/// Tracks the pack's matching state per game.  (index same as above Cards with game ID)
		/// </summary>
		public List<BingoPackState> state; 


		public override string ToString()
		{
            return pack_info.ToString() + "(" + start_card.ToString() + ")";
		}

		public PlayerPack() 
		{
			ID = Guid.NewGuid();
		}
	}


	public class PackSet: List<BingoPack>
	{
		/// <summary>
		/// unique set ID per-player...
		/// </summary>
		public int set_id;
		/// <summary>
		/// This controls how far along the PackDNA sequence this has matched.
		/// </summary>
		public int match_pos;
		/// <summary>
		/// first index is pack, second index is card within pack 
		/// </summary>
		public List<int[]> card_away; 
		public List<int> scores; // each game's score of this pack.

		public void Set( int index, BingoPack pack )
		{
			while( index >= this.Count )
				this.Add( null );
			this[index] = pack;
		}
	}

	public class BingoPlayer
	{
		public Guid ID;
		/// <summary>
		/// per-pack cards actually played by this player. this is updated as games change?
		/// </summary>
		public List<List<BingoCardState>> _played_cards; // this would have to be a 2d array...

		public int CardCount
		{
			get
			{
                //throw new Exception( "what is it you're asking?" );
				int count = 0;
                //foreach( PlayerPack player_pack in played_packs )
                foreach( List<BingoCardState> pack2 in _played_cards )
					    count += pack2.Count;
				return count;
			}
		}

		/// <summary>
		/// by pack, list of cards this player played... list of specific pack instance with minor additional information.
		/// </summary> 
		public List<PlayerPack> played_packs;
		public List<PlayerTransaction> transactions;
		//public List<int> transnum;
		public string card;
		public List<PackSet> pack_sets;
		/// <summary>
		/// Score on sets of packs this player is playing.
		/// </summary>
		//public List<PackScore> pack_scores;
		void Init()
		{
			transactions = new List<PlayerTransaction>();
			played_packs = new List<PlayerPack>();
			_played_cards = new List<List<BingoCardState>>();
			pack_sets = new List<PackSet>();
		}

		public BingoPlayer()
		{
			Init();
		}

		public BingoPlayer( String player_card )
		{
			Init();
			card = player_card;
		}

		static Random r = new Random( Convert.ToInt32(DateTime.Now.Ticks & 0x7FFFFFFF ) );

		public BingoPlayer( Guid id )
		{
			Init();
			card = (DateTime.Now.Ticks + r.Next(10000)).ToString();
			ID = id;
		}
		public override string ToString()
		{
			return card;
		}

		public void PlayPack( PlayerTransaction transaction, BingoPack pack )
		{
			throw new Exception( "Packs have multiple dealers; have to figure a way to use just one" );
			PlayerPack played_pack = new PlayerPack();
			played_pack.pack_info = pack;
			played_pack.player = this;
			//if( pack._dealer == null )
			//	pack._dealer = BingoDealers.nodealer;
			//played_pack.start_card = pack._dealer.Deal( pack.rows, pack.cols, pack.count );
			played_packs.Add( played_pack );
			transaction.Add( played_pack );
		}

	}


	public class BingoPlayers : List<BingoPlayer>
	{
		/// <summary>
		/// If players_loaded is set to true, then paper and electronic sales are only loaded for players that already exist.
		/// </summary>
		bool players_loaded = false;
		/// <summary>
		/// Can set this if player_track table is not available... allows ANY player... (uses transnum as cardnum)
		/// </summary>
		bool allow_any_player = false;
		int max_player_id;
		//BingoGameList _games;
		BingoSessionEvent session_event;
		static bool bDoLogCards = Options.File( "raterank.ini" )["Bingo Players"]["Log starting cards loaded", "0"].Bool;
		static bool bAccessDbCorrection = xperdex.classes.Options.File( "raterank.ini" )["Access DB"]["Access db writes mini.ini base sales", "1"].Bool;
		// need games so we know how much and when packs play.
		public BingoPlayers( BingoSessionEvent session )
		{
			session_event = session;
			LoadElectronics( session, session_event.session.GameList.pack_list );
			LoadPaper( session, session_event.session.GameList.pack_list, null );
			//_games = session.session.GameList;
		}


		public BingoPlayers( BingoSessionEvent session, List<String> rated_packs )
		{
			string misc_item = Options.File( "raterank.ini" )[Options.ProgramName]["Misc Item To Select Sale", "none"].Value;
			string misc_dept = Options.File( "raterank.ini" )[Options.ProgramName]["Misc Dept To Select Sale", "none"].Value;
			
			session_event = session;
			LoadPlayers();

			if( misc_dept != "none" )
			{
				LoadMisc( session, misc_dept, misc_item );
				// lock more players from getting loaded.
				players_loaded = true;
			}
			allow_any_player = true;
				// load players...
			LoadElectronics( session, session_event.session.GameList.pack_list, rated_packs );
			LoadPaper( session, session_event.session.GameList.pack_list, rated_packs );
			//LoadPlayers( bingoday, session );
		}

		public BingoPlayers( BingoSessionEvent session, PackDNA rated_packs )
		{
			session_event = session;
			LoadPlayers();

			Log.log( "Begin loading players..." );

			string misc_item = Options.File( "raterank.ini" )[Options.ProgramName]["Misc Item To Select Sale", "none"].Value;
			string misc_dept = Options.File( "raterank.ini" )[Options.ProgramName]["Misc Dept To Select Sale", "none"].Value;
			//MySQLDataTable table;
			if( misc_dept != "none" )
			{
				LoadMisc( session, misc_dept, misc_item );
				// lock more players from getting loaded.
				players_loaded = true;
			}
			allow_any_player = true;
			
			//LoadElectronics( bingoday, session, games.pack_list, rated_packs );

			LoadElectronics( session, session_event.session.GameList.pack_list );
			LoadPaper( session, session_event.session.GameList.pack_list, null );
			Log.log( "Done loading players..." );
		}

		public BingoPlayers()
		{
		}

		public List<PlayerTransaction> LoadPlayers()
		{
			List<PlayerTransaction> new_players = null;
			if( this.Count == 0 )
			{
				PlayerTransaction transaction;
				DbDataReader r = StaticDsnConnection.KindExecuteReader( "select card,transnum,ID from player_track where session=" + session_event.session_number + " and bingoday=" + DsnSQLUtil.MakeDateOnly( StaticDsnConnection.dsn, session_event.bingoday ) );
				max_player_id = 0;
				if( r != null && r.HasRows )
				{
					String player_card = r.GetString( 0 );
					int transnum = r.GetInt32( 1 );
					int player_id = r.GetInt32( 2 );
					if( player_id > max_player_id )
						max_player_id = player_id;
					BingoPlayer player = this.Find( delegate( BingoPlayer p ) { return String.Compare( p.card, player_card ) == 0; } );
					if( player != null )
					{
						transaction = player.transactions.Find( delegate( PlayerTransaction p ) { return p.transnum == transnum; } );
						if( transaction == null )
							player.transactions.Add( transaction = new PlayerTransaction( player, transnum ) );
						// new transaction on player....
						if( new_players == null )
							new_players = new List<PlayerTransaction>();
						new_players.Add( transaction );
					}
					else
					{
						player = new BingoPlayer();
						player.transactions.Add( transaction = new PlayerTransaction( player, transnum ) );
						player.card = player_card;
						player.ID = Guid.NewGuid();
						Add( player );

						if( new_players == null )
							new_players = new List<PlayerTransaction>();
						new_players.Add( transaction );
					}
				}
			}
			else
			{
				PlayerTransaction transaction;
				DbDataReader r = StaticDsnConnection.KindExecuteReader( "select card,transnum,ID from player_track where session=" 
					+ session_event.session_number 
					+ " and bingoday=" + DsnSQLUtil.MakeDateOnly( StaticDsnConnection.dsn, session_event.bingoday ) 
					+ " and ID>" + max_player_id);
				if( r != null && r.HasRows )
				{
					String player_card = r.GetString( 0 );
					int transnum = r.GetInt32( 1 );
					int player_id = r.GetInt32( 2 );

					if( player_id > max_player_id )
						max_player_id = player_id;

					BingoPlayer player = this.Find( delegate( BingoPlayer p ) { return String.Compare( p.card, player_card ) == 0; } );
					if( player != null )
					{
						transaction = player.transactions.Find( delegate( PlayerTransaction p ) { return p.transnum == transnum; } );
						if( transaction == null )
							player.transactions.Add( transaction = new PlayerTransaction( player, transnum ) );
						// new transaction on player....
						if( new_players == null )
							new_players = new List<PlayerTransaction>();
						new_players.Add( transaction );
					}
					else
					{
						player = new BingoPlayer();
						player.transactions.Add( transaction = new PlayerTransaction( player, transnum ) );
						player.card = player_card;
						player.ID = Guid.NewGuid();
						Add( player );
						if( new_players == null )
							new_players = new List<PlayerTransaction>();
						new_players.Add( transaction );
					}
				}
			}
			return new_players;
		}



		BingoPlayer GetPlayer( DateTime bingoday, int transnum, ref PlayerTransaction transaction )
		{
			BingoPlayer player = this.Find( delegate( BingoPlayer p ) { foreach( PlayerTransaction t in p.transactions ) if( t.transnum == transnum ) { return true; } return false; } );

			if( !players_loaded && player == null )
			{
				DbDataReader r = StaticDsnConnection.KindExecuteReader( "select card,id from player_track where transnum=" + transnum.ToString() + " and bingoday=" +DsnSQLUtil.MakeDateOnly( StaticDsnConnection.dsn, bingoday ) );
				if( r != null && r.HasRows )
				{
					r.Read();
					String player_card = r.GetString( 0 );
					int ID = r.GetInt32( 1 );
					if( max_player_id < ID )
						max_player_id = ID;
					StaticDsnConnection.EndReader( r );
					player = this.Find( delegate( BingoPlayer p ) { return String.Compare( p.card, player_card ) == 0; } );
					if( player != null )
					{
						player.transactions.Add( transaction = new PlayerTransaction( player, transnum ) );
					}
					if( player == null )
					{
						player = new BingoPlayer();
						player.transactions.Add( transaction = new PlayerTransaction( player, transnum ) );
						player.card = player_card;
						player.ID = Guid.NewGuid();// this.Count;
						Add( player );
					}
				}
				else
				{
					if( allow_any_player )
					{
						String player_card = transnum.ToString();
						player = this.Find( delegate( BingoPlayer p ) { return String.Compare( p.card, player_card ) == 0; } );
						if( player != null )
							player.transactions.Add( transaction = new PlayerTransaction( player, transnum ) );
						if( player == null )
						{
							player = new BingoPlayer();
							player.transactions.Add( transaction = new PlayerTransaction( player, transnum ) );
							player.card = player_card;
							player.ID = Guid.NewGuid();//this.Count;
							Add( player );
						}
					}
				}
			}
			else
				foreach( PlayerTransaction t in player.transactions ) 
					if( t.transnum == transnum ) 
						transaction = t;
			return player;
		}

		void LoadMisc( BingoSessionEvent session, String misc_dept, String misc_item )
		{
			MySQLDataTable specials = new MySQLDataTable( StaticDsnConnection.dsn
				, "select transnum,sum(quantity) as count,bingoday from misc_trans join misc_item using(item_id) join misc_dept using(dept_id)"
				+ " where misc_item.name='" + misc_item + "' and misc_dept.name='" + misc_dept + "'"
				+ " and misc_trans.bingoday=cast( " + DsnSQLUtil.MakeDate( StaticDsnConnection.dsn, session.bingoday ) + " as date)"
				+ " and misc_trans.session=" + session.session.session
				+ " and misc_trans.void=0"
				+ " group by transnum"
				);
			PlayerTransaction transaction = null;
			foreach( DataRow row in specials.Rows )
			{
				GetPlayer( Convert.ToDateTime( row["bingoday"]), Convert.ToInt32( row["transnum"] ), ref transaction );
			}
			specials.Dispose();
		}

		void LoadPaper( BingoSessionEvent session, BingoPacks pack_list, List<String> rated_packs )
		{
			MySQLDataTable paper_table = new MySQLDataTable( StaticDsnConnection.dsn
				, "select * from pos_paper_barcode_master"
				+ " join pos_paper_barcode_item on pos_paper_barcode_master.pos_paper_barcode_master_id=pos_paper_barcode_item.pos_paper_barcode_master_id"
				+ " join item_descriptions on item_descriptions.item_description_id=pos_paper_barcode_item.item_description_id"
				+ " join floor_paper_names on floor_paper_names.floor_paper_name_id=pos_paper_barcode_item.floor_paper_name_id"
				+ " where pos_paper_barcode_master.bingoday=cast( " + DsnSQLUtil.MakeDate( StaticDsnConnection.dsn, session.bingoday ) + " as date) and pos_paper_barcode_master.session=" + session.session.session
				+ " order by transnum" //start_card"
				);

			foreach( DataRow row in paper_table.Rows )
			{
				string packname = row["name"].ToString();
				if( rated_packs != null )
				{
					bool found = false;
					foreach( String rated_packname in rated_packs )
					{
						if( String.Compare( packname, rated_packname, true ) == 0 )
						{
							found = true;
							break;
						}
					}
					// ignore loading this pack.  it's not allowed.
					if( !found )
						continue;
				}
				int transnum = Convert.ToInt32( row["transnum"] );
				if( transnum == 0 )
				{
					// these are special case packs (paper usage tracking only)
					continue;
				}
				PlayerTransaction transaction = null;
				BingoPlayer player = GetPlayer( Convert.ToDateTime( row["bingoday"] ), transnum, ref transaction );
				if( player != null )
				{
					PlayerPack pack = new PlayerPack();
                    pack.electronic = false;
					pack.transaction = transaction;
					pack.start_card = Convert.ToInt32( row["start_card"] );
					pack.pack_info = pack_list.GetPack( packname );
					if( pack.pack_info != null )
					{
						//pack.pack_info.game_list = _games;
						pack.player = player;
						pack.unit_number = Convert.ToInt32( row["packnum"] );
						pack.dealer = pack_list.GetDealer( pack.pack_info, pack.start_card );
						pack.paper = true;
						pack.pack_info.ID = player.played_packs.Count;
						{
							// fix the starting card....
							// need to figure this out ( sam's town )
							if( bDoLogCards )
								Log.log( "paper pack starting card " + pack.start_card );

							pack.unit_number = Convert.ToInt32( row["packnum"] );
							player.played_packs.Add( pack );
						}
						transaction.Add( pack );
					}
				}
			}
			paper_table.Dispose();
		}




		void LoadElectronics( BingoSessionEvent session, BingoPacks pack_list )
		{
			MySQLDataTable table = new MySQLDataTable( StaticDsnConnection.dsn
				, "select access_db_sale.transnum,pack_type,start_card,pack_type_name,unit_num,access_db_sale.bingoday from access_db_sale"
				+ " join access_db_packs on access_db_sale.electronic_id=access_db_packs.electronic_id"
				+ " where void=0 and access_db_sale.bingoday=cast( " + DsnSQLUtil.MakeDate( StaticDsnConnection.dsn, session.bingoday ) + " as date) and access_db_packs.session=" + session.session_number
				+ " order by mod(start_card,50),start_card/50"
				);
			foreach( DataRow row in table.Rows )
			{
				int start_card = Convert.ToInt32( row["start_card"] );
				if( start_card == 0 )
				{
					// these are special case macro label place holders... no real cards.
					continue;
				}
				int transnum = Convert.ToInt32( row["transnum"] );

				PlayerTransaction transaction = null;
				BingoPlayer player = GetPlayer( Convert.ToDateTime( row["bingoday"] ), transnum, ref transaction );
				if( player != null )
				{
					int packnum = Convert.ToInt32( row["pack_type"] );

					if( packnum < 100 )
					{
						PlayerPack pack = new PlayerPack();
						pack.electronic = true;
						pack.start_card = start_card;
						pack.transaction = transaction;
						try
						{
							pack.pack_info = pack_list.GetPack( row["pack_type_name"].ToString() );
							pack.dealer = pack.pack_info.GetRangeDealer( start_card );
						}
						catch( Exception e ) {
							//System.Windows.Forms.MessageBox.Show( e.Message );
                            throw new Exception( "Fail loading packs." );
							continue;
						}
						if( pack.pack_info == null )
							continue;  // fail loading this.

						pack.paper = false;
						//pack.game_list = _games;

						pack.player = player;
						pack.unit_number = Convert.ToInt32( row["unit_num"] );
#if each_pack_has_counts
					foreach( BingoGame game in _games )
					{
						int x;
						// pack doesn't play in this game.
						if( pack.pack_info.ID >= game.pack_card_counts.Count )
						{
							pack.game_card_count[game.game_ID] = 0;
							continue;
						}
						x = pack.game_card_count[game.game_ID] = game.pack_card_counts[pack.pack_info.ID-1];
						if( x > pack.most_game_card_count )
						{
							if( pack.least_game_card_count == 0 )
								pack.least_game_card_count = x;
							pack.most_game_card_count = x;
						}
						if( x > 0 && x < pack.least_game_card_count )
							pack.least_game_card_count = x;
					}
#endif
						if( bDoLogCards )
							Log.log( "electronic pack starting card " + pack.start_card );
						//pack.pack_info.ID = player.played_packs.Count;
						transaction.Add( pack );
						player.played_packs.Add( pack );
					}
					else
					{
						// ignore macros
					}
				}
			}
			table.Dispose();
		}


		void LoadElectronics( BingoSessionEvent session, BingoPacks pack_list, List<String> rated_packs )
		{
			MySQLDataTable table = new MySQLDataTable( StaticDsnConnection.dsn
				, "select access_db_sale.transnum,pack_type,start_card,pack_type_name,unit_num,pos_num from access_db_sale"
				+ " join access_db_packs on access_db_sale.electronic_id=access_db_packs.electronic_id"
				+ " where void=0 and access_db_sale.bingoday=cast( " + DsnSQLUtil.MakeDate( StaticDsnConnection.dsn, session.bingoday ) + " as date) and access_db_packs.session=" + session
                + " and matched=0"
                + " order transnum" /*by mod(start_card,50),start_card/50"*/ 
				);
			foreach( DataRow row in table.Rows )
			{
				if( rated_packs != null )
				{
					bool found = false;
					string packname = row["pack_type_name"].ToString();
					foreach( String rated_packname in rated_packs )
					{
						if( String.Compare( packname, rated_packname, true ) == 0 )
						{
							found = true;
							break;
						}
					}
					// ignore loading this pack.  it's not allowed.
					if( !found )
						continue;
				}
				int transnum = Convert.ToInt32( row["transnum"] );
				PlayerTransaction transaction = null;
				BingoPlayer player = GetPlayer( Convert.ToDateTime( row["bingoday"] ), transnum, ref transaction );
				int packnum = Convert.ToInt32( row["pack_type"] );

				if( packnum < 100 )
				{
					PlayerPack pack = new PlayerPack();
                    pack.electronic = true;
                    pack.start_card =  Convert.ToInt32( row["start_card"] );
                    pack.pack_info = pack_list.GetPack( row["pack_type_name"].ToString(), "Pos " + row["pos_num"].ToString() );
					if( pack.pack_info == null )
						continue;  // fail loading this.

					pack.paper = false;
					//pack.game_list = _games;

					pack.player = player;
					pack.unit_number = Convert.ToInt32( row["unit_num"] );
#if each_pack_has_counts
					foreach( BingoGame game in _games )
					{
						int x;
						// pack doesn't play in this game.
						if( pack.pack_info.ID >= game.pack_card_counts.Count )
						{
							pack.game_card_count[game.game_ID] = 0;
							continue;
						}
						x = pack.game_card_count[game.game_ID] = game.pack_card_counts[pack.pack_info.ID-1];
						if( x > pack.most_game_card_count )
						{
							if( pack.least_game_card_count == 0 )
								pack.least_game_card_count = x;
							pack.most_game_card_count = x;
						}
						if( x > 0 && x < pack.least_game_card_count )
							pack.least_game_card_count = x;
					}
#endif
					//pack.pack_info.ID = player.played_packs.Count;
					player.played_packs.Add( pack );
				}
			}

		}

		void LoadElectronics( BingoSessionEvent session, BingoPacks pack_list, PackDNA rated_packs )
		{
			string misc_item = Options.Default["Rate Rank"]["Misc Item To Select Sale", "none"].Value;
			string misc_dept = Options.Default["Rate Rank"]["Misc Dept To Select Sale", "none"].Value;
			MySQLDataTable table;
			if( misc_dept != "none" )
			{
				MySQLDataTable specials = new MySQLDataTable( StaticDsnConnection.dsn
					, "select transnum,sum(quantity) as count from misc_trans join misc_item using(item_id) join misc_dept using(dept_id)"
					+ " where misc_item.name='" + misc_item + "' and misc_dept.name='" + misc_dept + "'"
					+ " and misc_trans.bingoday=cast( " + DsnSQLUtil.MakeDate( StaticDsnConnection.dsn, session.bingoday ) + " as date)"
					+ " and misc_trans.session=" + session
					+ " and misc_trans.void=0"
					+ " group by transnum"
					);
				table = new MySQLDataTable( StaticDsnConnection.dsn
					, "select access_db_sale.transnum,pack_type,start_card,pack_type_name,unit_num from access_db_sale"
					+ " join access_db_packs on access_db_sale.electronic_id=access_db_packs.electronic_id"
					+ " where void=0 and access_db_sale.bingoday=cast( " + DsnSQLUtil.MakeDate( StaticDsnConnection.dsn, session.bingoday ) + " as date) and access_db_packs.session=" + session
                    + " and matched=0"
                    + " order by transnum,access_db_packs.id"
					);

				foreach( DataRow row in specials.Rows )
				{
					int transnum = Convert.ToInt32( row["transnum"] );
					PlayerTransaction transaction = null;
					BingoPlayer player = GetPlayer( Convert.ToDateTime( row["bingoday"] ), transnum, ref transaction );
					int count = Convert.ToInt32( row["count"] ) + player.pack_sets.Count;
					for( int n = player.pack_sets.Count; n < count; n++ )
					{
						PackSet tmp;
						player.pack_sets.Add( tmp = new PackSet() );
						tmp.set_id = n + 1;
					}

				}
			}
			else
			{
				table = new MySQLDataTable( StaticDsnConnection.dsn
					, "select access_db_sale.transnum,pack_type,start_card,pack_type_name,unit_num,pos_num from access_db_sale"
					+ " join access_db_packs on access_db_sale.electronic_id=access_db_packs.electronic_id"
					+ " where void=0 and access_db_sale.bingoday=cast( " + DsnSQLUtil.MakeDate( StaticDsnConnection.dsn, session.bingoday ) + " as date) and access_db_packs.session=" + session
                    + " and matched=0"
                    + " order by transnum,access_db_packs.id"
					);


			}

			foreach( DataRow row in table.Rows )
			{
				int transnum = Convert.ToInt32( row["transnum"] );

				PlayerTransaction transaction = null;
				BingoPlayer player = GetPlayer( Convert.ToDateTime( row["bingoday"] ), transnum, ref transaction );

				//Log.log( "Player : " + player.card );
				int packnum = Convert.ToInt32( row["pack_type"] );

				// ignore the macro pack labels.
				if( packnum < 100 )
				{
					PlayerPack pack = new PlayerPack();

					transaction.Add( pack );
                    pack.start_card = Convert.ToInt32( row["start_card"] );
					pack.pack_info = pack_list.GetPack( row["pack_type_name"].ToString(), "Pos " + row["pos_num"].ToString() );
					if( pack.pack_info == null )
						continue;  // fail loading this.

					//pack.game_list = _games;
					pack.player = player;
					pack.unit_number = Convert.ToInt32( row["unit_num"] );

					if( rated_packs != null )
					{
						bool found = false;
						string packname = row["pack_type_name"].ToString();
						//Log.log( "Looking for pack to stack: " + packname );
						foreach( PackSet check_pack_set in player.pack_sets )
						{
							if( check_pack_set.Count == rated_packs.pack_sequence.Count )
							{
								bool empty_slot = false;
								int tmp_pos = 0;
								foreach( BingoPack seq_pack in rated_packs.pack_sequence )
								{
									if( check_pack_set.Count > tmp_pos && check_pack_set[tmp_pos] == null )
									{
										empty_slot = true;
										break;
									}
									tmp_pos++;
								}
								if( !empty_slot )
								{
									// this pack set is already full.
									//Log.log( "(all manager packs already loaded)stack is full... skipping..." );
									continue;
								}
							}
							int pos = 0;
							foreach( BingoPack seq_pack in rated_packs.pack_sequence )
							{
								if( check_pack_set.Count > pos && check_pack_set[pos] != null )
								{
									//Log.log( "slot is full... skipping..." );
									pos++;
									continue;
								}
								//Log.log( "Comparing " + seq_pack.name +" vs " + packname );
								if( ( ( check_pack_set.Count <= pos )
									||( check_pack_set.Count > pos && check_pack_set[pos] == null ) )
									&& String.Compare( packname, seq_pack.name, true ) == 0 )
								{
									//Log.log( "Steppig match_pos... setting id " + check_pack_set.set_id );
									check_pack_set.match_pos++;
									pack.pack_set = check_pack_set.set_id;
									check_pack_set.Set( pos, pack.pack_info );
									found = true;
									break;
								}
								pos++;
							}
							if( found )
							{
								//Log.log( "located..." );
								break;
							}
						}
						if( !found )
						{
							//if( player.card == "000000015200000761" )
							//	Log.log( "something bad." );
						}
					}
					Log.log( "electronic pack starting card " + pack.start_card );

					player.played_packs.Add( pack );
				}
			}
			//if( match_pos > 0 )
			foreach( BingoPlayer player in this )
			{
				foreach( PackSet check_pack_set in player.pack_sets )
				{
					if( check_pack_set.Count == rated_packs.pack_sequence.Count )
					{

					}
					else
					{
						Log.log( "Incomplete pack sequence?" );
					}
				}
			}
		}
	}
}
