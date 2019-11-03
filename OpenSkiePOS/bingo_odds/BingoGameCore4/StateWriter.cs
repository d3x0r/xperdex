using System;
using System.Collections.Generic;
using System.Text;
using xperdex.classes;
using System.Data.Common;
using System.Windows.Forms;

namespace BingoGameCore4
{
	public static class StateWriter
	{
		/// <summary>
		/// This controls writing called_game_win_info
		/// </summary>
		public static bool WritePlayerWinDetails = true;

		/// <summary>
		/// Write pack away status, if NO pack status, per-card stats are not written either.
		/// </summary>
		public static bool WritePlayerPackBreakdown = false;

		/// <summary>
		/// Option to write 'limited=0' entries...
		/// </summary>
		public static bool WriteTrueTotals = true;

		/// <summary>
		/// If pack breakdown is enabled, this disables writing the per-card information.
		/// </summary>
		public static bool WritePerCardStatistics = false;

		/// <summary>
		/// Option if reading physical cardfile, or using random cards, to write cards into cardset_info for later reference.
		/// </summary>
		public static bool UpdateCardsetInfoCards = false;

		/// <summary>
		/// Set to write called_game_player_pack_away_status (which may be processed into called_game_player_rank
		/// </summary>
		public static bool WritePackRateDetails = false;

		class initialized
		{

			public bool binitialized;

		}

		static initialized i = new initialized();

        static bool disable_sql_logging;

		static void init( DsnConnection db )
		{
			lock( i )
			{
				if( !i.binitialized )
				{
                    disable_sql_logging = Options.File( "raterank.ini" )["Config"]["Disable SQL Logging for StateWriter", "1"].Bool;

					List<MySQLDataTable> tables = new List<MySQLDataTable>();
					MySQLDataTable table;
					StringBuilder sb = new StringBuilder();
					int n;
					sb.Append( "bingo_game_id int," );
					sb.Append( "won_in_balls int," );
					sb.Append( "first_pattern_name varchar(150)," );
					sb.Append( "bingoday date," );
					sb.Append( "year int," );
					sb.Append( "day int," );
					sb.Append( "hall int," );
					sb.Append( "session int," );
					sb.Append( "game int," );
					sb.Append( "real_game int," );
					sb.Append( "into_game int," );
					sb.Append( "progressive int," );
					sb.Append( "extension int," );
					sb.Append( "hotball int," );
					sb.Append( "hotball_1 int," );
					sb.Append( "hotball_2 int," );
					sb.Append( "hotball_3 int," );
					sb.Append( "hotball_4 int," );
					sb.Append( "hotball_5 int," );
					for( n = 1; n <= 75; n++ )
						sb.Append( "ball_" + n + " int," );
					sb.Append( "all_balls varchar( 225 )," );
					sb.Append( "PRIMARY KEY (`called_game_id`) ) ENGINE=MyISAM" );

					tables.Add( table = new MySQLDataTable( db ) );
					DsnSQLUtil.MatchCreate( db, table, "Create table called_game_balls (called_game_id int auto_increment,"
										+ sb.ToString() );
					//xperdex.classes.MySQLDataTable.
					//xperdex.classes.SQL_U

					sb.Length = 0;


					sb.Append( "called_game_id int," );
					sb.Append( "limited int," );
					sb.Append( "total int," );
					for( n = 0; n <= 25; n++ )
						sb.Append( "away_" + n + " int," );
					sb.Append( "PRIMARY KEY (`card_status_id`) )" );
					tables.Add( table = new MySQLDataTable( db ) );
					DsnSQLUtil.MatchCreate( db, table, "Create table called_game_card_away_status (card_status_id int auto_increment,"
										+ sb.ToString() );
					if( WritePlayerPackBreakdown )
					{
						sb.Length = 0;

						sb.Append( "called_game_id int," );
						sb.Append( "player_id int, " );
						sb.Append( "pack_id int," );
						sb.Append( "pack_type int," );
						sb.Append( "card varchar(25), " );
						sb.Append( "pack_name varchar(32)," );
						for( n = 0; n <= 25; n++ )
							sb.Append( "away_" + n + " int," );
						sb.Append( "PRIMARY KEY (`card_player_pack_status_id`) )" );

						tables.Add( table = new MySQLDataTable( db ) );
						DsnSQLUtil.MatchCreate( db, table, "Create table called_game_player_pack_away_status (card_player_pack_status_id int auto_increment,"
											+ sb.ToString() );
					}
					sb.Length = 0;
					sb.Append( "called_game_id int," );
					sb.Append( "player_id int, " );
					sb.Append( "limited int, " );
					sb.Append( "total_cards int, " );
					sb.Append( "card varchar(25), " );
					for( n = 0; n <= 25; n++ )
						sb.Append( "away_" + n + " int," );
					sb.Append( "PRIMARY KEY (`player_away_status_id`) )" );

					tables.Add( table = new MySQLDataTable( db ) );
					DsnSQLUtil.MatchCreate( db, table, "Create table called_game_player_away_status (player_away_status_id int auto_increment,"
										+ sb.ToString() );

					sb.Length = 0;
					sb.Append( "called_game_id int," );
					sb.Append( "card_id int," );
					sb.Append( "player_id char(34)," );
					sb.Append( "card varchar(25)," );
					sb.Append( "pack_id int," );
					sb.Append( "pack_name varchar(25)," );
					sb.Append( "pack_type int," );
					sb.Append( "pattern_mask int," );
					sb.Append( "pattern_mask_bits varchar(26)," );
					sb.Append( "starburst_number int," ); // the number that was the spot on the card.
					sb.Append( "starburst int," );
					sb.Append( "starburst_marked int," );
					sb.Append( "hotball int," );
					sb.Append( "multiple_hotball int," );
					sb.Append( "PRIMARY KEY (`winning_card_id`) )" );

					tables.Add( table = new MySQLDataTable( db ) );
					DsnSQLUtil.MatchCreate( db, table, "create table called_game_winning_card_info ( winning_card_id int auto_increment,"
						+ sb.ToString() );

#if include_card_wins
					sb.Length = 0;
					sb.Append( "winning_called_game_pattern_id int," );
					sb.Append( "card_id int," );
					sb.Append( "game_id int," );
					sb.Append( "card_win_id int," );
					sb.Append( "pattern_id int," );
					sb.Append( "won_in_ball_count int," );
					sb.Append( "key `ballcount` ( `won_in_ball_count` )," );
					sb.Append( "PRIMARY KEY (`called_game_card_win_id`) )" );

					tables.Add( table = new MySQLDataTable( db ) ); 
					table.MatchCreate( "create table called_game_card_wins ( called_game_card_win_id int auto_increment,"
						+ sb.ToString() );
#endif
					if( WritePerCardStatistics )
					{

						sb.Length = 0;
						sb.Append( "card_id int," );
						sb.Append( "pack_id int," );
						sb.Append( "cardset_id int," );
						sb.Append( "cardset_card_number int," );
						sb.Append( "played_card_number int, " );
						sb.Append( "away_count int," );
						sb.Append( "points int," );
						//sb.Append( "player_id int," );
						//sb.Append( "card varchar(25)," );
						sb.Append( "bestmask int," );
						sb.Append( "called_game_id int," );
						sb.Append( "PRIMARY KEY (`called_game_card_id`) )" );

						tables.Add( table = new MySQLDataTable( db ) );
						DsnSQLUtil.MatchCreate( db, table, "create table called_game_cards ( called_game_card_id int auto_increment,"
							+ sb.ToString(), true );


						sb.Length = 0;
						sb.Append( "card_id int," );
						sb.Append( "pack_id int," );
						sb.Append( "cardset_id int," );
						sb.Append( "cardset_card_number int," );
						sb.Append( "played_card_number int, " );
						sb.Append( "away_count int," );
						sb.Append( "points int," );
						//sb.Append( "player_id int," );
						//sb.Append( "card varchar(25)," );
						sb.Append( "bestmask int," );
						sb.Append( "called_game_id int," );
						sb.Append( "PRIMARY KEY (`called_game_card_id`) )" );

						tables.Add( table = new MySQLDataTable( db ) );
						DsnSQLUtil.MatchCreate( db, table, "create table called_game_cards_limited ( called_game_card_id int auto_increment,"
							+ sb.ToString(), true );
					}


					tables.Add( table = new MySQLDataTable( db ) );
					DsnSQLUtil.MatchCreate( db, table, "create table called_game_player_pack_status( called_game_player_pack_status_id int auto_increment"
						+ ",card varchar(25)"
						+ ",session int"
						+ ",bingoday date"
						+ ",called_game_id int"
						+ ",pack_id int"
						+ ",pack_set_id int"
						+ ",card_id int"
						+ ",face int"
						+ ",away int"
						+ ",points int"
						+ ",PRIMARY KEY( called_game_player_pack_status_id )) engine=myisam", true );

					tables.Add( table = new MySQLDataTable( db ) );
					DsnSQLUtil.MatchCreate( db, table, "create table called_game_player_rank2( called_game_player_rank_id int auto_increment"
						+ ",card varchar(25)"
						+ ",session int"
						+ ",game int"
						+ ",bingoday date"
						+ ",called_game_id int"
						+ ",pack_set_id int"
                        + ",game_group_id int"
						+ ",pack_name varchar(64)" 
						+ ",pack_count int"
						+ ",card_count int"
						+ ",total_points int"
						+ ",away_0 int"
						+ ",away_1 int"
						+ ",away_2 int"
						+ ",away_3 int"
						+ ",away_4 int"
						+ ",away_5 int"
						+ ",away_24 int"
						+ ",away_other int"
						+ ",PRIMARY KEY( called_game_player_rank_id ),unique packid(`pack_set_id`,`card`,`session`,`bingoday`,`called_game_id`)) ENGINE=MyISAM", true );

					tables.Add( table = new MySQLDataTable( db ) );
					DsnSQLUtil.MatchCreate( db, table, "create table called_game_player_rank_partial( called_game_player_rank_partial_id int auto_increment"
						+ ",card varchar(25)"
						+ ",session int"
						+ ",bingoday date"
						+ ",week_id int"
						+ ",total_points int"
						+ ",PRIMARY KEY( called_game_player_rank_partial_id ),unique packid(`card`,`week_id`)) ENGINE=MyISAM", true );


					tables.Add( table = new MySQLDataTable( db ) );
					DsnSQLUtil.MatchCreate( db, table, "create table called_game_weeks( week_id int auto_increment"
						+ ",bingoday_start date"
						+ ",bingoday_end date"
						+ ",PRIMARY KEY( week_id )) ENGINE=MyISAM", true );

					tables.Add( table = new MySQLDataTable( db ) );
					DsnSQLUtil.MatchCreate( db, table, "create table called_game_player_rank( called_game_player_rank_id int auto_increment"
						+ ",card varchar(25)"
						+ ",game_count int"
						+ ",pack_set_id int"
						+ ",session int"
						+ ",bingoday date"
						+ ",week_id int"
						+ ",total_points int"
						+ ",PRIMARY KEY( called_game_player_rank_id ),unique packid(`card`,`session`,`bingoday`,`pack_set_id`)) ENGINE=MyISAM", true );

					tables.Add( table = new MySQLDataTable( db ) );
					DsnSQLUtil.MatchCreate( db, table, "create table called_game_player_rank_bonus( called_game_player_rank_bonus_id int auto_increment"
						+ ",card varchar(25)"
						+ ",session int"
						+ ",bingoday date"
						+ ",week_id int"
						+ ",bonus_points int"
						+ ",PRIMARY KEY( called_game_player_rank_bonus_id ),unique packid(`card`,`session`,`bingoday`,`week_id`)) ENGINE=MyISAM", true );



					string x = "CREATE TABLE `cardset_cards` ( " +
								 " `ID` int(11) NOT NULL auto_increment," +
							"  `cardset_id` int(11) NOT NULL default '0'," +
							"  `card_number` int(11) NOT NULL default '0'," +
							"  `b1` tinyint(2) NOT NULL default '0'," +
							"  `b2` tinyint(2) NOT NULL default '0',  `b3` tinyint(2) NOT NULL default '0',  `b4` tinyint(2) NOT NULL default '0',  `b5` tinyint(2) NOT NULL default '0',  `i1` tinyint(2) NOT NULL default '0',  `i2` tinyint(2) NOT NULL default '0',  `i3` tinyint(2) NOT NULL default '0',  `i4` tinyint(2) NOT NULL default '0',  `i5` tinyint(2) NOT NULL default '0',  `n1` tinyint(2) NOT NULL default '0',  `n2` tinyint(2) NOT NULL default '0',  `n4` tinyint(2) NOT NULL default '0',  `n5` tinyint(2) NOT NULL default '0',  `g1` tinyint(2) NOT NULL default '0',  `g2` tinyint(2) NOT NULL default '0',  `g3` tinyint(2) NOT NULL default '0',  `g4` tinyint(2) NOT NULL default '0',  `g5` tinyint(2) NOT NULL default '0',  `o1` tinyint(2) NOT NULL default '0',  `o2` tinyint(2) NOT NULL default '0',  `o3` tinyint(2) NOT NULL default '0',  `o4` tinyint(2) NOT NULL default '0',`o5` tinyint(2) NOT NULL default '0',PRIMARY KEY  (`ID`),KEY `cardset_id` (`cardset_id`),KEY `card_number` (`card_number`))"
					;
					tables.Add( table = new MySQLDataTable( db ) );
					DsnSQLUtil.MatchCreate( db, table, x );


					// type == enum('Electronic','Paper','Double','Starburst','Bonus Line') NOT NULL default 'Paper'
					//tables.Add( table = new MySQLDataTable( db ) ); 
					//table.MatchCreate( "CREATE TABLE `cardset_info` (`cardset_id` int(11) NOT NULL auto_increment,`name` varchar(100) NOT NULL default '',`friendly_name` varchar(100) NOT NULL default '',`type` int(11),`base` int(11) NOT NULL default '0',`cards` int(11) NOT NULL default '0',`manufacturer_id` varchar(100) NOT NULL default '',PRIMARY KEY  (`cardset_id`))" );




#if asdfasdf
// one to one relation with cardset_cards
CREATE TABLE `cardset_card_stats` (
  `cardset_card_stats_id` int(11) NOT NULL auto_increment,
  `cardset_id` int(11) NOT NULL default '0',
  `card_number` int(11) NOT NULL default '0',
  `combo_1` int(11) NOT NULL default '0',
  `perm_1` int(11) NOT NULL default '0',
  `combo_2` int(11) NOT NULL default '0',
  `perm_2` int(11) NOT NULL default '0',
  `combo_3` int(11) NOT NULL default '0',
  `perm_3` int(11) NOT NULL default '0',
  `combo_4` int(11) NOT NULL default '0',
  `perm_4` int(11) NOT NULL default '0',
  `combo_5` int(11) NOT NULL default '0',
  `perm_5` int(11) NOT NULL default '0',
  `evens_1` int(11) NOT NULL default '0',
  `odds_1` int(11) NOT NULL default '0',
  `evens_2` int(11) NOT NULL default '0',
  `odds_2` int(11) NOT NULL default '0',
  `evens_3` int(11) NOT NULL default '0',
  `odds_3` int(11) NOT NULL default '0',
  `evens_4` int(11) NOT NULL default '0',
  `odds_4` int(11) NOT NULL default '0',
  `evens_5` int(11) NOT NULL default '0',
  `odds_5` int(11) NOT NULL default '0',
  `evens` int(11) NOT NULL default '0',
  `odds` int(11) NOT NULL default '0',
  PRIMARY KEY  (`cardset_card_stats_id`),
  KEY `cardset_id_key` (`cardset_id`),
  KEY `card_number_key` (`card_number`)
) TYPE=MyISAM COMMENT="one to one relation with cardset_cards, related by cardset_id,card_number";

CREATE TABLE `cardset_card_unordered_numbers` (
  `combination_id` int(11) NOT NULL,
  `size` tinyint(2) NOT NULL default '5',
  `a` tinyint(2) NOT NULL default '0',
  `b` tinyint(2) NOT NULL default '0',
  `c` tinyint(2) NOT NULL default '0',
  `d` tinyint(2) NOT NULL default '0',
  `e` tinyint(2) NOT NULL default '0',
  `evens` tinyint(2) NOT NULL default '0',
  `odds` tinyint(2) NOT NULL default '0',
  PRIMARY KEY  (`combination_id`,`size`),
) TYPE=MyISAM COMMENT="base numbers to expand combinations of 'size' numbers, where size is 4 or 5";

CREATE TABLE `cardset_combo_allowed_mates` (
  `combination_id` int(11) NOT NULL,
  `another_combination_id` int(11) NOT NULL,
  `size` tinyint(2) NOT NULL default '5',
  PRIMARY KEY  (`combination_id`,`another_combination_id`,`size`),
) TYPE=MyISAM COMMENT="base numbers to expand combinations of 'size' numbers, where size is 4 or 5";

CREATE TABLE `cardset_card_number_orders` (
  `permutation_id` int(11) NOT NULL,
  `size` tinyint(2) NOT NULL default '5',
  `a` tinyint(2) NOT NULL default '0',
  `b` tinyint(2) NOT NULL default '0',
  `c` tinyint(2) NOT NULL default '0',
  `d` tinyint(2) NOT NULL default '0',
  `e` tinyint(2) NOT NULL default '0',
  PRIMARY KEY  (`permutation_id`,`size`),
) TYPE=MyISAM COMMENT="base numbers to expand combination order of 'size' numbers, where size is 4 or 5";



;

CREATE TABLE `card_ram` (
  `ID` varchar(100) NOT NULL default '',
  `low` int(11) NOT NULL default '0',
  `high` int(11) NOT NULL default '0',
  `skip` int(11) NOT NULL default '0',
  `card` int(11) NOT NULL default '0',
  PRIMARY KEY  (`ID`)
) TYPE=MyISAM;
#endif
					i.binitialized = true;
				}
			}
		}

		public static bool CheckState( ref BingoGameState s )
		{

			//lock( i )
			{
				// might check to see if dsn moved...
				// and re-init with new tables....
				init( Local.dsn );

				DateTime date = s.session_event.bingoday;
				DbDataReader reader = Local.dsn.KindExecuteReader( "select count(*) from called_game_balls where bingoday="
						+ "'" + date.Year + "-" + date.Month + "-" + date.Day + " " + date.Hour + ":" + date.Minute + ":" + date.Second + "'"
					//+xperdex.classes.MySQLDataTable.MakeDateOnly(date)
						+ " and session=" + ( s.session_event.session_number )
						+ " and game=" + ( s.game.game_number ) );
				//db.Dispose();
				//db = null;
				if( !reader.HasRows || reader.GetInt32( 0 ) == 0 )
					return true;
				return false;

			}
		}

		static void CleanState( DsnConnection dsn, BingoGameState s )
		{
			//lock( i )
			{
				init( dsn );

				DateTime date = s.session_event.bingoday;
				DbDataReader reader = dsn.KindExecuteReader( "select called_game_id from called_game_balls where bingoday="
						+ "'" + date.Year + "-" + date.Month + "-" + date.Day + " " + date.Hour + ":" + date.Minute + ":" + date.Second + "'"
					//+xperdex.classes.MySQLDataTable.MakeDateOnly(date)
						+ " and session=" + ( s.session_event.session_number )
						+ " and game=" + ( s.game.game_number ) 
						+ " and real_game=" + ( s.game.game_ID )
						);
				if( reader ==null || !reader.HasRows || reader.GetInt32( 0 ) == 0 )
				{
					dsn.EndReader( reader );
					return;
				}
				while( reader.Read() )
				{
					int id = reader.GetInt32( reader.GetOrdinal( "called_game_id" ) );
					DsnConnection dsn2 = GetConnection();
					dsn2.KindExecuteNonQuery( "delete from called_game_balls where called_game_id=" + id );
					dsn2.KindExecuteNonQuery( "delete from called_game_player_rank2 where called_game_id=" + id );
					dsn2.KindExecuteNonQuery( "delete from called_game_player_pack_status where called_game_id=" + id );
					dsn2.KindExecuteNonQuery( "delete from called_game_card_away_status where called_game_id=" + id );
					dsn2.KindExecuteNonQuery( "delete from called_game_player_away_status where called_game_id=" + id );
					dsn2.KindExecuteNonQuery( "delete from called_game_winning_card_info where called_game_id=" + id );
					DropConnection( dsn2 );
				}
				dsn.EndReader( reader );
			}
		}

		class pack_set_info
		{
			/// <summary>
			/// away 25 is still possible if the card had 0 marks and the pattern did not have the free spot.  Away 24 will be what coveralls report as, since free is in the pattern. (and that will be marked, subtracting one)
			/// away 25 will reflectt 'other' for pack based patterns.  Technically we need to go to... 75-minimum marks possible...
			/// </summary>
			public int[] away = new int[26]; 
			public string pack_name;
			public int points;
			public object id;
			//public int count;
			public int packs;
            public bool electronic;
			public int cards;
			public BingoPlayer player;
		}

		static DsnConnection GetConnection()
		{
			DsnConnection db;
			lock( available )
			{

				if( available.Count > 0 )
				{
					Log.log( "Getting an existing available database connection..." );
					db = available.Dequeue();
					if( db == null )
					{
                        db = new DsnConnection( Local.output_dsn );
                        db.disable_logging = disable_sql_logging;
					}
				}
				else
				{
					Log.log( "Getting a new database connection..." );
					do
					{
                        db = new DsnConnection( Local.output_dsn );
                        db.disable_logging = disable_sql_logging;
					}
					while( db == null );
				}
			}
			return db;
		}

		static void DropConnection( DsnConnection db )
		{
			lock( available )
			{
				Log.log( "Done with connection... adding to available." );
				available.Enqueue( db );
			}
		}

		public static long GetWeekID( DateTime bingoday, int session )
		{
			long week_id = 0;
			DateTime start, end;

			String_Utilities.BuildSessionRangeCondition( null, bingoday, session, out start, out end );
			//lock( i )
			{
				DsnConnection db = GetConnection();
				init( db );
				{
					DbDataReader r = db.KindExecuteReader( "select week_id from called_game_weeks where bingoday_start=" + start.ToString( "yyyyMMdd" ) + " and bingoday_end=" + end.ToString( "yyyyMMdd" ) );
					if( r != null && r.HasRows )
					{
						if( r.Read() )
							week_id = r.GetInt32( 0 );
						db.EndReader( r );
					}
					else
					{
						week_id = db.KindExecuteInsert( "insert into called_game_weeks (bingoday_start,bingoday_end)values(" 
							+ start.ToString( "yyyyMMdd" ) + "," 
							+ end.ToString( "yyyyMMdd" ) + ")" );
					}
				}
				DropConnection( db );
			}
			return week_id;

		}

		static Queue<DsnConnection> available = new Queue<DsnConnection>();

		public static void DumpState( BingoGameState s, bool WriteCards, bool WriteWinningCards )
		{
			//lock( i )
			{
				Log.log( "Writing state output!" );
				try
				{
					DsnConnection db = null;
					// grab a new dsn
					{
						db = GetConnection();
						init( db );
					}
					{
						StringBuilder sb = new StringBuilder();
						int game_id;
						int card_win_id;
						db.BeginTransaction();

						CleanState( db, s );
						// insert the game's balls, and get a game_id for them.
						if( s.game_event.playing_balls != null )
						{
							sb.Length = 0;
							sb.Append( "insert into called_game_balls (" );
                            if( s.game_event.game_event_row != null )
                                sb.Append( "bingo_game_id," );
							for( int ball = 1; ball <= s.game_event.playing_balls.Length; ball++ )
							{
								sb.Append( "ball_" + ball + "," );
							}
							sb.Append( "first_pattern_name," );
							sb.Append( "bingoday," );
							sb.Append( "year," );
							sb.Append( "day," );
							sb.Append( "hall," );
							sb.Append( "session," );
							sb.Append( "game," );
							sb.Append( "real_game, " );
							sb.Append( "extension," );
							sb.Append( "into_game," );
							sb.Append( "progressive," );
							sb.Append( "hotball," );
							sb.Append( "hotball_1," );
							sb.Append( "hotball_2," );
							sb.Append( "hotball_3," );
							sb.Append( "hotball_4," );
							sb.Append( "hotball_5," );

							sb.Append( "won_in_balls," );

							sb.Append( "all_balls" );
							sb.Append( ")values(" );
                            if( s.game_event.game_event_row != null )
							    sb.Append( s.game_event.game_event_row["bingo_game_id"].ToString() + ",");
							for( int ball = 1; ball <= s.game_event.playing_balls.Length; ball++ )
							{
								sb.Append( s.game_event.playing_balls[ball - 1] + "," );
							}

							DateTime date = s.session_event.bingoday;
							// game name is the first pattern, unless there are no patterns, then write 'no pattern'
							sb.Append( "'" + s.game.ToString() + "'," );
							sb.Append( "'" + date.Year + "-" + date.Month + "-" + date.Day + " " + date.Hour + ":" + date.Minute + ":" + date.Second + "'," );
							sb.Append( 0 /*s.Year*/ + "," );
							sb.Append( 0 /*s.Day*/ + "," );
							sb.Append( 0 /*s.Hall*/ + "," );
							sb.Append( s.session_event.session_number + "," );
							sb.Append( ( s.game.game_number ) + "," );
							sb.Append( ( s.game.game_ID ) + "," );
							sb.Append( s.game.extension ? "1," : "0," );
							sb.Append( s.game.into ? "1," : "0," );
							sb.Append( s.game.progressive ? "1," : "0," );
							sb.Append( (s.game.cashballs==1) ? "1," : "0," );
							sb.Append( s.game_event.playing_hotballs == null || (s.game_event.playing_hotballs.Length < 1)?"0," : s.game_event.playing_hotballs[0] + "," );
                            sb.Append( s.game_event.playing_hotballs == null || ( s.game_event.playing_hotballs.Length < 2 ) ? "0," : s.game_event.playing_hotballs[1] + "," );
                            sb.Append( s.game_event.playing_hotballs == null || ( s.game_event.playing_hotballs.Length < 3 ) ? "0," : s.game_event.playing_hotballs[2] + "," );
                            sb.Append( s.game_event.playing_hotballs == null || ( s.game_event.playing_hotballs.Length < 4 ) ? "0," : s.game_event.playing_hotballs[3] + "," );
                            sb.Append( s.game_event.playing_hotballs == null || ( s.game_event.playing_hotballs.Length < 5 ) ? "0," : s.game_event.playing_hotballs[4] + "," );
							sb.Append( s.bestwin + ",'" );
							for( int ball = 1; ball <= s.game_event.playing_balls.Length; ball++ )
							{
								sb.Append( s.game_event.playing_balls[ball - 1] + " " );
							}
							sb.Append( "')" );

							game_id = (int)db.KindExecuteInsert( sb.ToString() );
						}
						else
							game_id = -1;

						// might not have any ranks for this game...
						// noone won... 
						// out of range to get an away count... ( ranks will be on the prior game, this is probably an extension)
#if not_obsolete
						if( s.playing_card_away_totals != null )
						{
							sb.Length = 0;
							sb.Append( "insert into called_game_card_away_status (" );
							for( int ball = 0; ball <= 25; ball++ )
							{
								sb.Append( "away_" + ball + "," );
							}

							int total = 0;
							sb.Append( "called_game_id,limited,total)values(" );
							for( int ball = 0; ball <= 25; ball++ )
							{
								sb.Append( s.playing_card_away_totals[ball] + "," );
								total += s.playing_card_away_totals[ball];
							}

							sb.Append( game_id.ToString() +",0,"+total.ToString() );
							sb.Append( ")" );

							db.KindExecuteInsert( sb.ToString() );

							
							sb.Length = 0;
							sb.Append( "insert into called_game_card_away_status (" );
							for( int ball = 0; ball <= 25; ball++ )
							{
								sb.Append( "away_" + ball + "," );
							}

							sb.Append( "called_game_id,limited,total)values(" );
							total = 0;
							for( int ball = 0; ball <= 25; ball++ )
							{
								total += s.playing_card_away_totals_limited[ball];
								sb.Append( s.playing_card_away_totals_limited[ball] + "," );
							}

							sb.Append( game_id.ToString() +",1,"+total.ToString() );
							sb.Append( ")" );

							db.KindExecuteInsert( sb.ToString() );

							//game_id = db.last_insert_id();
						}
#endif
						if( game_id >= 0 )
						{
							foreach( wininfo info in s.winning_cards )
							{
								int card_id = 0;
								if( WriteWinningCards && false )
								{
									{
										// write the card data itself.
										sb.Length = 0;
										sb.Append( "insert into cardset_cards (cardset_id," );
										for( int ball = 0; ball < 5; ball++ )
											for( int num = 0; num < 5; num++ )
											{
												if( ( ball == 2 ) && ( num == 2 ) )
													continue;
												sb.Append( "bingo".Substring( ball, 1 ) + ( num + 1 ).ToString() + "," );
											}
										sb.Append( "card_number)values(" );
										sb.Append( "0," ); // cardset_id
										for( int ball = 0; ball < 5; ball++ )
											for( int num = 0; num < 5; num++ )
											{
												if( ( ball == 2 ) && ( num == 2 ) )
													continue;
												sb.Append( info.playing_card.CardData[0, ball, num].ToString() ); sb.Append( "," );
											}
										sb.Append( ( info.card_number + 1 ).ToString() ); sb.Append( ")" );
										card_id = (int)db.KindExecuteInsert( sb.ToString() );
									}
								}

								if( WritePlayerWinDetails )
								{
									sb.Length = 0;
									sb.Append( "insert into called_game_winning_card_info(called_game_id,card_id,player_id,card,pack_id,pack_name,pack_type"
										); sb.Append( ",pattern_mask"
										); sb.Append( ",pattern_mask_bits"
										); sb.Append( ",starburst"
										); sb.Append( ",starburst_marked"
										); sb.Append( ",starburst_number"
										); sb.Append( ",hotball"
										); sb.Append( ",multiple_hotball"
										); sb.Append( ")values(" );
                                    sb.Append( "'" );
									sb.Append( game_id );
                                    sb.Append( "'," );

									if( info.mask == 0 )
										Console.WriteLine( "bad!" );

									sb.Append( info.card_number );

									sb.Append( "," );

                                    sb.Append( "'" );
                                    sb.Append( info.player.ID );
									sb.Append( "'," );
									sb.Append( "'" + info.player.card + "'" );
									sb.Append( "," );
									sb.Append( info.pack.pack_info.pack_type );
									sb.Append( "," );
									sb.Append( "'" + info.pack.pack_info.name + "'" );
									sb.Append( "," );
									sb.Append( info.pack.pack_info.pack_type );
									sb.Append( "," );
									sb.Append( info.mask );
									sb.Append( ",'" );
									for( int bit = 0; bit < 25; bit++ )
										if( ( info.mask & ( 1 << bit ) ) != 0 )
											sb.Append( "1" );
										else
											sb.Append( "0" );
									sb.Append( "'," );
									sb.Append( info.pack.pack_info.flags.starburst ? "1," : "0," );
									sb.Append( info.starburst_marked ? "1," : "0," );
									sb.Append( info.playing_card.CardData[0, 2, 2] );
									sb.Append( "," );
									sb.Append( info.hotball ? "1," : "0," );
									sb.Append( info.hotball_count );
									sb.Append( ")" );
									db.KindExecuteInsert( sb.ToString() );
								}

							}
						}

						// dump the cards... assuming they didn't come from the database to start?
						//if(false)


						if( game_id >= 0 )
						{
							int card_id;
							//foreach( BingoCardState card in s.playing_cards )
							//foreach( BingoPlayer player in s.session_event._PlayerList )
							{



								{
									List<pack_set_info> pack_sets = new List<pack_set_info>();

									int game_index = s.game.game_ID;

									foreach( BingoPlayer player in s.session_event._PlayerList )
									//s.playing_packs
									//foreach( PlayerPack pack in  s.game_event.playing_packs )
									//foreach( BingoCardState card in s.playing_cards )
									//foreach( BingoCardState	card in pack.Cards )
									{
									
										//PlayerPack pack = card.pack;
										//foreach( PlayerPack pack in player.played_packs )
										{
											// pack did not play in this game. (no cards in this game)
											//new_pack_set.count++;
											foreach( PlayerPack pack in player.played_packs )
											{
												if( pack.Cards.Count <= game_index )
												{
													// no cards for this pack in this game... check later.
													continue;
												}
												List<BingoCardState> game_cards;
												game_cards = pack.Cards[game_index];
												int card_count = game_cards.Count;
												if( card_count == 0 )
													continue;

												pack_set_info new_pack_set;
												new_pack_set = pack_sets.Find( delegate(pack_set_info p)
													{ return !( pack.electronic ^ p.electronic ) 
																&& String.Compare( p.pack_name, pack.pack_info.name, true ) == 0; } );
												if( new_pack_set == null )
												{
													new_pack_set = new pack_set_info();
													new_pack_set.electronic = pack.electronic;
													new_pack_set.id = pack.pack_info.ID;
													new_pack_set.player = player;
													pack_sets.Add( new_pack_set );
												}

                                                if( pack.electronic )
                                                {
                                                    //if( pack.
                                                    new_pack_set.packs++;
                                                    new_pack_set.cards += card_count;
                                                    foreach( BingoCardState card in game_cards )
                                                    {
														new_pack_set.away[card.BestAway()]++;
                                                        new_pack_set.points
                                                            += pack.card_away_count[game_index][card.pack_card_index].points;
                                                    }
                                                }
                                                else
                                                {
													new_pack_set.packs++;
													new_pack_set.cards += card_count;
                                                    foreach( BingoCardState card in game_cards )
                                                    {
														new_pack_set.away[card.BestAway()]++;
														new_pack_set.points
                                                            += pack.card_away_count[game_index][card.pack_card_index].points;
                                                    }
                                                }
											}
                                        }
									}

									if( pack_sets.Count > 0 )
									{
										int block = 0;
										bool first = true;
										foreach( pack_set_info pack_set in pack_sets )
										{
											if( block == 0 )
											{
												sb.Length = 0;
												sb.Append( "insert into called_game_player_rank2 "
														+ "( card,bingoday,session,game,called_game_id,pack_set_id,pack_name,pack_count,card_count,total_points"
														+ ",away_0,away_1,away_2,away_3,away_4,away_5,away_24,away_other"
													//,game_group_id"
														+ ")values" );
											}
											else
												sb.Append( "," );
											sb.Append( "('" );
											first = false;
											sb.Append( pack_set.player.card + "'," );
											DateTime date = s.session_event.bingoday;
											sb.Append( DsnSQLUtil.MakeDateOnly( db, date ) + "," );
											sb.Append( s.session_event.session_number + "," );
											sb.Append( s.game.game_number + "," );
											sb.Append( game_id + "," );
											sb.Append( (pack_set.electronic?1:0).ToString() + "," );
											sb.Append( pack_set.packs + "," );

											sb.Append( pack_set.cards +"," );
											sb.Append( pack_set.points + "," );
											sb.Append( pack_set.away[0] + "," );
											sb.Append( pack_set.away[1] + "," );
											sb.Append( pack_set.away[2] + "," );
											sb.Append( pack_set.away[3] + "," );
											sb.Append( pack_set.away[4] + "," );
											sb.Append( pack_set.away[5] + "," );
											sb.Append( ( pack_set.away[25] + pack_set.away[24] ) + "," );
											int tmp = 0;
											for( int n = 6; n < 23; n++ )
												tmp += pack_set.away[n];

											sb.Append( tmp );
                                            //sb.Append( s.game.game_group_id );

											sb.Append( ")" );
											if( block == 32 )
											{
												db.KindExecuteInsert( sb.ToString() );
												block = 0;
											}
											else
												block++;											
										}
										if( block > 0 )
											db.KindExecuteInsert( sb.ToString() );

									}
								}
							}
							if( s.session_event._PlayerList != null )
								foreach( BingoPlayer player in s.session_event._PlayerList )
								{

									int pack_number = 0;
									foreach( PlayerPack pack in player.played_packs )
									{
										int pack_id;
										if( !pack.played )
											continue;
										//if( RateRank.max_rated_packs > 0 && pack_number >= RateRank.max_rated_packs )
										//continue;
										int cardcount = 0;

										//for( int away = 0; away < 26; away++ )
										{
											//player_totals[away] += s.playing_card_away_pack_player_totals[player.ID, pack_number, away];
											//player_totals_limited[away] += s.playing_card_away_pack_player_totals_limited[player.ID, pack_number, away];
										}
										// pack doesn't play in this game.
										if( ( s.game.pack_card_counts.Count <= pack.pack_info.pack_type )
											|| s.game.pack_card_counts[pack.pack_info.pack_type] == 0 )
										{
											// don't write packs that didn't play in this game.
											continue;
										}



										if( WritePackRateDetails )
										{
											cardcount = s.game.pack_card_counts[pack.pack_info.pack_type];
											int game_index = s.game.game_ID;
											sb.Length = 0;
											if( pack.Cards[game_index].Count > 0 )
											{

												sb.Append( "insert into called_game_player_pack_status "
													+ "( card,bingoday,session,called_game_id,pack_id,pack_set_id,card_id,face,away,points)values" );
												for( int card = 0; card < cardcount; card++ )
												{
													if( card > 0 )
														sb.Append( "," );
													sb.Append( "('" + player.card + "'," );
													DateTime date = s.session_event.bingoday;
													sb.Append( DsnSQLUtil.MakeDateOnly( db, date ) + "," );
													sb.Append( s.session_event.session_number + "," );
													sb.Append( game_id + "," );
													sb.Append( pack_number + "," );
													sb.Append( pack.pack_set + "," );
													sb.Append( card + "," );
													sb.Append( pack.Cards[game_index][card].unit_card_number + "," );
													sb.Append( pack.card_away_count[game_index][card].away + "," );
													sb.Append( pack.card_away_count[game_index][card].points + ")" );
												}
												db.KindExecuteInsert( sb.ToString() );
											}
										}



										if( WritePlayerPackBreakdown )
										{
											if( WriteTrueTotals )
											{
												sb.Length = 0;
												sb.Append( "insert into called_game_player_pack_away_status (" );
												sb.Append( "player_id,card,pack_id,pack_type,pack_name," );

												for( int ball = 0; ball <= 25; ball++ )
												{
													//sb.Append( "away_" + ball + "," );
												}

												sb.Append( "called_game_id)values(" );
												sb.Append( player.ID + "," );
												sb.Append( "'" + player.card + "'," );
												sb.Append( pack.pack_info.pack_type + "," );
												sb.Append( pack.pack_info.pack_type + "," );
												sb.Append( "'" + pack.pack_info.name + "'," );
												for( int ball = 0; ball <= 25; ball++ )
												{
													//sb.Append( pack.
													//sb.Append( s.playing_card_away_pack_player_totals[player.ID, pack_number, ball] + "," );
												}

												sb.Append( game_id.ToString() );
												sb.Append( ")" );
												pack_id = (int)db.KindExecuteInsert( sb.ToString() );


												if( UpdateCardsetInfoCards || WritePerCardStatistics )
													for( int card = 0; card < cardcount; card++ )
													{
														if( UpdateCardsetInfoCards )
														{
															// write the card data itself.
															sb.Length = 0;
															sb.Append( "replace into cardset_cards (cardset_id," );
															for( int ball = 0; ball < 5; ball++ )
																for( int num = 0; num < 5; num++ )
																{
																	if( ( ball == 2 ) && ( num == 2 ) )
																		continue;
																	sb.Append( "bingo".Substring( ball, 1 ) + ( num + 1 ).ToString() + "," );
																}
															sb.Append( "card_number)values(" );
															sb.Append( "0," ); // cardset_id
															for( int ball = 0; ball < 5; ball++ )
																for( int num = 0; num < 5; num++ )
																{
																	if( ( ball == 2 ) && ( num == 2 ) )
																		continue;
																	sb.Append( s.playing_cards[card].CardData[0, ball, num].ToString() + "," );
																}
															sb.Append( ( card + 1 ).ToString() + ")" );
															//card_id = (int)db.KindExecuteInsert( sb.ToString() );
														}


														if( WritePerCardStatistics )
															if( pack.dealer.card_data != null )
															{
																MessageBox.Show( "Broken code." );
																int base_real_card = pack.dealer.Add( ( pack.start_card ),
																	!pack.paper
																		? s.game.ballset_number
																		: s.game.page_skip );
																int card_number = 0;
																int physical_card_number = 0;
#if asdf
																int card_number = pack.pack_info.dealer.GetNext( base_real_card, card );
																int physical_card_number = pack.pack_info.dealer.GetPhysicalNext( base_real_card, card );
#endif
																sb.Length = 0;
																sb.Append( "insert into called_game_cards (" );
																sb.Append( "pack_id,card_id,cardset_id,cardset_card_number,played_card_number,away_count,points,called_game_id)values(" );
																sb.Append( pack_id + "," );
																//sb.Append( card_counter + "," );
																object cardset_id = 0;// pack.dealer.cardset.ID;
																sb.Append( cardset_id + "," );
																sb.Append( physical_card_number + "," );
																sb.Append( card_number + "," );
																//sb.Append( s.playing_card_away[card_counter, s.bestwin - 1] + "," );
																int point_multiplier = 0;
																/*
																DataRow[] rows = Local.points.Select( "away_count=" + s.playing_card_away[card_counter, s.bestwin - 1] );
																if( rows.Length > 0 )
																	point_multiplier = Convert.ToInt32( rows[0]["points"] );
																else
																	point_multiplier = 0;
																 */
																sb.Append( point_multiplier + "," );
																sb.Append( game_id.ToString() );
																sb.Append( ")" );

																db.KindExecuteNonQuery( sb.ToString() );

																//game_id = db.last_insert_id();
															}
															else
															{
																Log.log( "That failed pack is failed again." );
															}
														//card_counter++;
													}
											}

											if( false )
											{
												sb.Length = 0;
												sb.Append( "insert into called_game_player_pack_away_status_limited (" );
												sb.Append( "player_id,card,pack_id,pack_type,pack_name," );

												for( int ball = 0; ball <= 25; ball++ )
												{
													sb.Append( "away_" + ball + "," );
												}

												sb.Append( "called_game_id)values(" );
												sb.Append( player.ID + "," );
												sb.Append( "'" + player.card + "'," );
												sb.Append( pack.pack_info.pack_type + "," );
												sb.Append( pack.pack_info.pack_type + "," );
												sb.Append( "'" + pack.pack_info.name + "'," );
												for( int ball = 0; ball <= 25; ball++ )
												{
													//sb.Append( s.playing_card_away_pack_player_totals[player.ID, pack_number, ball] + "," );
												}

												sb.Append( game_id.ToString() );
												sb.Append( ")" );
												pack_id = (int)db.KindExecuteInsert( sb.ToString() );
											}


											cardcount = s.game.pack_card_counts[pack.pack_info.pack_type];

											for( int card = 0; card < cardcount; card++ )
											{
												if( UpdateCardsetInfoCards )
												{
													// write the card data itself.
													sb.Length = 0;
													sb.Append( "replace into cardset_cards (cardset_id," );
													for( int ball = 0; ball < 5; ball++ )
														for( int num = 0; num < 5; num++ )
														{
															if( ( ball == 2 ) && ( num == 2 ) )
																continue;
															sb.Append( "bingo".Substring( ball, 1 ) + ( num + 1 ).ToString() + "," );
														}
													sb.Append( "card_number)values(" );
													sb.Append( "0," ); // cardset_id
													for( int ball = 0; ball < 5; ball++ )
														for( int num = 0; num < 5; num++ )
														{
															if( ( ball == 2 ) && ( num == 2 ) )
																continue;
															sb.Append( s.playing_cards[card].CardData[0, ball, num].ToString() + "," );
														}
													sb.Append( ( card + 1 ).ToString() + ")" );
													//card_id = (int)db.KindExecuteInsert( sb.ToString() );
												}


												if( WritePerCardStatistics )
												{
													if( pack.dealer != null )
													{
														MessageBox.Show( "borken code." );
														int base_real_card = pack.dealer.Add( ( pack.start_card ),
																										!pack.paper
																											? s.game.ballset_number
																											: s.game.page_skip );
														int card_number = 0;
														int physical_card_number = 0;
#if asdf
														int card_number = pack.pack_info.dealer.GetNext( base_real_card, card );
														int physical_card_number = pack.pack_info.dealer.GetPhysicalNext( base_real_card, card );
#endif
														sb.Length = 0;
														sb.Append( "insert into called_game_cards_limited (" );
														sb.Append( "pack_id,card_id,cardset_id,cardset_card_number,played_card_number,away_count,points,called_game_id)values(" );
														sb.Append( player.played_packs.IndexOf( pack ) + "," );
														//sb.Append( card_counter + "," );
														object cardset_id = 0;// pack.dealer.cardset.ID;
														sb.Append( cardset_id + "," );
														sb.Append( physical_card_number + "," );
														sb.Append( card_number + "," );
														//sb.Append( s.playing_card_away[card_counter, s.bestwin - 1] + "," );
														int point_multiplier = 0;
														/*
														DataRow[] rows = Local.points.Select( "away_count=" + s.playing_card_away[card_counter, s.bestwin - 1] );
														if( rows.Length > 0 )
															point_multiplier = Convert.ToInt32( rows[0]["points"] );
														else
															point_multiplier = 0;
														 */
														sb.Append( point_multiplier + "," );
														sb.Append( game_id.ToString() );
														sb.Append( ")" );

														db.KindExecuteNonQuery( sb.ToString() );

														//game_id = db.last_insert_id();
													}
													else
													{
														Log.log( "That failed pack is failed again." );
													}
												}
												//card_counter++;
											}
										}
										pack_number++;


									}
									{
										sb.Length = 0;
										sb.Append( "insert into called_game_player_away_status (" );
										sb.Append( "player_id,card,limited," );

										for( int ball = 0; ball <= 25; ball++ )
										{
											sb.Append( "away_" + ball + "," );
										}

										sb.Append( "total_cards,called_game_id)values(" );
										sb.Append( player.ID + "," );
										sb.Append( "'" + player.card + "',0," );
										int total = 0;
										for( int ball = 0; ball <= 25; ball++ )
										{
											//total += player_totals[ball];
											//sb.Append( player_totals[ball] + "," );
										}

										if( total > 0 )
										{
											sb.Append( total.ToString() + "," );

											sb.Append( game_id.ToString() );
											sb.Append( ")" );
											db.KindExecuteInsert( sb.ToString() );
										}
									}
									{
										sb.Length = 0;
										sb.Append( "insert into called_game_player_away_status (" );
										sb.Append( "player_id,card,limited," );

										for( int ball = 0; ball <= 25; ball++ )
										{
											sb.Append( "away_" + ball + "," );
										}

										sb.Append( "total_cards,called_game_id)values(" );
										sb.Append( player.ID + "," );
										sb.Append( "'" + player.card + "',1," );
										int total = 0;
										for( int ball = 0; ball <= 25; ball++ )
										{
											//total += player_totals_limited[ball];
											//sb.Append( player_totals_limited[ball] + "," );
										}

										if( total > 0 )
										{
											sb.Append( total.ToString() + "," );

											sb.Append( game_id.ToString() );
											sb.Append( ")" );
											db.KindExecuteInsert( sb.ToString() );
										}


									}
								}
						}
						db.EndTransaction();
					}
					DropConnection( db );
				}
				catch( Exception e )
				{
					Log.log( e.Message + "\n" + e.StackTrace );
					//MessageBox.Show( e.Message + "\n" + e.StackTrace );
				}
			}
			//db.Dispose();
		}
#if asdfasdf
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

			// xperdex wrapper so we have one root.  local is it's own section.
			w.WriteEndElement();
			w.WriteRaw( "\r\n" );
			w.Close();

		}

		public void ReadXml( string name )
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

#endif
	}
}
