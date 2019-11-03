#define use_prize_validations_for_balls
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using BingoGameCore4;
using BingoGameCore4.Forms;
using OpenSkieScheduler3.Controls;
using BingoGameInterfaces;
using xperdex.classes;

namespace BingoGameCore4
{
	public class BingoGameEvent
	{

		/// <summary>
		/// No, this is all games in this set ( same game number, maybe different number, into games might track here... 
		/// </summary>
		public List<BingoGame> games = new List<BingoGame>(); // which game this event is for.
		
		/// <summary>
		/// How many wins happened in this game event
		/// </summary>
		public int wins;

		public int starburst_wins;
		public int starburst_marks;
		public int bingo_match_wins;
		public int letter_color_wins;
		public int random_color_wins;

		public String name;

		BallDataInterface ball_interface;
		// how to get more balls, if required.
		public BallDataInterface balls
		{
			set
			{
				ball_interface = value;
			}
			get
			{
				if ( Local.ball_data_serialized )
				{
					Local.ball_data = null;
					return Local.ball_data;
				}
				else
				{
					if( ball_interface == null )
					{
						ball_interface = Local.ball_data; // creates a new instance
					}
					return ball_interface;
				}
			}
		}

		public int first_ball;
		public int[] _playing_balls;
		public int[] playing_balls
		{
			get
			{
				return _playing_balls;
			}
			set
			{
				int nBall;
				if( _playing_balls == null )
					_playing_balls = new int[value.Length];
				else if( _playing_balls.Length < value.Length )
					_playing_balls = new int[value.Length];
				for( nBall = 0; nBall < value.Length; nBall++ )
				{
					if( _playing_balls[nBall] == value[nBall] )
					{

					}
					else
					{
						// great.
						_playing_balls[nBall] = value[nBall];
					}
				}
			}
		}
		public int[] playing_hotballs;

		/// <summary>
		/// this is responsible for calling '5ball hotballs' depricated.
		/// </summary>
		public CardMaster.CardFactory card_factory;

		
		/// <summary>
		/// Result game event is sourced by a random number generator...
		/// </summary>
		public BingoGameEvent()
		{

		}

		/// <summary>
		/// Result game event is sourced by external or existing number generator...
		/// </summary>
		public BingoGameEvent( BingoGame game, BallDataInterface bdi = null )
		{
			this.games.Add( game );
			if( bdi != null )
				this.ball_interface = bdi;
			//game.
		}

		public static BingoGameEvent Continue( BingoGameEvent prior_event, BingoGame new_game )
		{
			if( prior_event != null )
			{
				//this.game_event_row = game_event_data_table_row;
				prior_event.games.Add( new_game );
			}
			return prior_event;
		}

		public class GameEventDataSet : DataSet
		{
			public static bool use_alt_game_processed = false;
			public MySQLDataTable GamesProcessed;
			internal  GameEventBallsProcessedDataTable games_processed;
			internal GameEventBallsProcessedAltDataTable alt_games_processed;
			public GameEventDataTable games;
			public GameEventBallsDataTable game_balls;
			public GameEventDataSet( DsnConnection database )
			{
				games = new GameEventDataTable( this, database );
				game_balls = new GameEventBallsDataTable( this, database );
				if( !use_alt_game_processed )
				{
					games_processed = new GameEventBallsProcessedDataTable( this, database );
					alt_games_processed = null;
					GamesProcessed = games_processed;
				}
				else
				{
					games_processed = null;
					alt_games_processed = new GameEventBallsProcessedAltDataTable( this, database );
					GamesProcessed = alt_games_processed;
				}
			}

			public void FillUnprocessed()
			{
				if( games_processed != null )
				{
					games_processed.FillUnprocessed( 0 );
				}
				else if( alt_games_processed != null )
				{
					alt_games_processed.FillUnprocessed();
				}

				game_balls.LoadEventBalls();
			}

			public void FillUnprocessed( int max_games )
			{
				if( games_processed != null )
				{
					games_processed.FillUnprocessed( max_games );
				}
				else if( alt_games_processed != null )
				{
					alt_games_processed.FillUnprocessed( max_games );
				}
				game_balls.LoadEventBalls();
			}

			public void FillToday( DateTime the_day, List<DateTime> selectedDates )
			{
				games.Fill();

				games.FillToday( the_day, selectedDates );
				game_balls.LoadEventBalls();
			}

			public void FillToday( DateTime the_day )
			{
				//Object[] dates = {the_day}; 
				List<DateTime> selectedDates = new List<DateTime>();
				selectedDates.Add( the_day );
				FillToday( the_day, selectedDates );
			}

			internal void FillBallSet( DateTime the_day, int session, int ballset )
			{
				games.FillBallSet( the_day, session, ballset );
				game_balls.LoadEventBalls();
			}

			public void ClearProcessed( DateTime day, int session )
			{
				DataRow[] result = games_processed.Select( "bingoday=" + DsnSQLUtil.MakeDateOnly( DsnConnection.ConnectionMode.NativeDataTable, 0, day )
					   + " and session=" + session );
				foreach( DataRow row in result )
					row["processed"] = 0;

			}
		}

		[MySQLPersistantTable]
		public class GameEventDataTable : MySQLDataTable
		{
			new static readonly public string TableName = "bingo_game";
			new static readonly public string Prefix = "";
			new static readonly public string PrimaryKey = XDataTable.ID( TableName );

			void AddColumns()
			{
				base.TableName = TableName;
				base.Prefix = Prefix;
				DataColumn dc;
				AddDefaultColumns( true, true, false );
				this.Columns.Add( dc = new DataColumn( "bingoday", typeof( DateTime ) ) );
				dc.ExtendedProperties.Add( "type", "date" );
				this.Columns.Add( new DataColumn( "session_id", typeof( int ) ) );
				this.Columns.Add( new DataColumn( "session", typeof( String ) ) );
				this.Columns.Add( new DataColumn( "game_id", typeof( int ) ) );
				this.Columns.Add( new DataColumn( "game", typeof( String ) ) );
				this.Columns.Add( new DataColumn( "ballset", typeof( int ) ) );
				this.Columns.Add( new DataColumn( "closed_at", typeof( DateTime ) ) );
				this.Columns.Add( new DataColumn( "created", typeof( DateTime ) ) );
			}

			public GameEventDataTable( DataSet ds, DsnConnection database )
			{
				connection = database;
				AddColumns();
				ds.Tables.Add( this );
			}
			public GameEventDataTable( DsnConnection database )
			{
				connection = database;
				AddColumns();
			}
			public GameEventDataTable()
			{
				AddColumns();
			}

			internal void FillToday( DateTime the_day, List<DateTime> selectedDates )
			{
				Rows.Clear();
				//for( int idx = 0; idx < selectedDates.Count; idx++ )
				{
					Fill( "bingoday >= " + DsnSQLUtil.MakeDateOnly( connection, the_day ) + " AND " +
						  "bingoday <= " + DsnSQLUtil.MakeDateOnly( connection, selectedDates[ selectedDates.Count - 1 ] ),
						  "session, game, created" );
				}
			}

			internal void FillToday( DateTime the_day )
			{
				List<DateTime> selectedDates = new List<DateTime>();
				selectedDates.Add( the_day );
				FillToday( the_day, selectedDates );
			}

			internal void FillBallSet( DateTime the_day, int session, int ballset )
			{
				while( Rows.Count > 0 )
				{
					Rows[0].Delete();
					this.DataSet.AcceptChanges();
				}
				Fill( "bingoday=" + DsnSQLUtil.MakeDateOnly( connection, the_day )
					+ " and ballset=" + ballset
					+ " and session=" + session
					, "session,game,created" );
			}
		}

		[MySQLPersistantTable]
		public class GameEventBallsDataTable : MySQLDataTable
		{
			new static readonly public string TableName = "bingo_game_balls";
			new static readonly public string PrimaryKey = XDataTable.ID( TableName );

			void AddColumns()
			{
				base.TableName = TableName;
				base.Prefix = Prefix;
				DataColumn dc;
				AddDefaultColumns( true, true, false );
				this.Columns.Add( dc = new DataColumn( GameEventDataTable.PrimaryKey, typeof( int ) ) );
				dc.AllowDBNull = false;
				this.keys.Add( new XDataTableKey( false, "ball_game_key", new string[]{dc.ColumnName} ) );
				this.Columns.Add( dc = new DataColumn( "ball", typeof( int ) ) );
				//dc.MaxLength = 3; // digits
				this.Columns.Add( new DataColumn( "called_at", typeof( DateTime ) ) );
				this.Columns.Add( new DataColumn( "hotball", typeof( bool ) ) );
				this.Columns.Add( new DataColumn( "uncalled", typeof( bool ) ) );
				this.Columns.Add( new DataColumn( "uncalled_at", typeof( DateTime ) ) );
			}

			public GameEventBallsDataTable()
			{
				AddColumns();
			}

			public GameEventBallsDataTable( DsnConnection database )
			{
				connection = database;
				AddColumns();
				//Create();
			}
			public GameEventBallsDataTable( DataSet dataSet, DsnConnection database )
			{
				connection = database;
				AddColumns();
				//Create();
				dataSet.Tables.Add( this );
				DataRelation dr;
				dataSet.Relations.Add( dr = new DataRelation( "game_has_ball"
					, dataSet.Tables[GameEventDataTable.TableName]
						.Columns[GameEventDataTable.PrimaryKey]
						, dataSet.Tables[TableName]
						.Columns[GameEventDataTable.PrimaryKey]
						) );
				//ForeignKeyConstraint fkc = this.Constraints["game_has_ball"] as ForeignKeyConstraint;
				//if( fkc != null )
				//	fkc.DeleteRule = Rule.SetNull;
				//dr.chil
			}

			/// <summary>
			/// Whatever game events are loaded in the dataset, load the balls for them.
			/// </summary>
			public void LoadEventBalls()
			{
				if( Rows.Count == 0 )
				{
					MySQLDataTable parent = this.DataSet.Tables[GameEventDataTable.TableName] as MySQLDataTable;
					foreach( DataRow row in parent.Rows )
					{
						Fill( GameEventDataTable.PrimaryKey + "=" + row[parent.PrimaryKeyName] + " and ((uncalled is null) or (uncalled=0))", "bingo_game_ball_id" );
					}
				}
			}
		}

		[MySQLPersistantTable]
		public class GameEventBallsProcessedDataTable : MySQLDataTable
		{
			new static readonly public string TableName = "bingo_game_balls_processed";
			new static readonly public string PrimaryKey = XDataTable.ID( TableName );

			void AddColumns()
			{
				base.TableName = TableName;
				base.Prefix = Prefix;
				DataColumn dc;
				AddDefaultColumns( true, true, false );
				this.Columns.Add( dc = new DataColumn( GameEventDataTable.PrimaryKey, typeof( int ) ) );
				// ya this is a 1:1 relation... so it should alos be unique constrained
				dc.Unique = true;
				dc.AllowDBNull = false;
				this.Columns.Add( new DataColumn( "processed", typeof( bool ) ) );
			}

			public GameEventBallsProcessedDataTable()
			{
				AddColumns();
			}

			public GameEventBallsProcessedDataTable( DsnConnection database )
			{
				connection = database;
				AddColumns();
				//Create();
			}

			public GameEventBallsProcessedDataTable( DataSet dataSet, DsnConnection database )
			{
				connection = database;
				AddColumns();
				//Create();
				dataSet.Tables.Add( this );
				dataSet.Relations.Add( new DataRelation( "game_is_processed"
					, dataSet.Tables[GameEventDataTable.TableName]
						.Columns[ GameEventDataTable.PrimaryKey]
						, dataSet.Tables[TableName]
						.Columns[GameEventDataTable.PrimaryKey]
						) );
					
			}

			public void FillUnprocessed( int max_games )
			{
				// shouldn't have any null parent ID

				if( this.DataSet != null )
				{
					MySQLDataTable parent = this.DataSet.Tables[GameEventDataTable.TableName] as MySQLDataTable;
					foreach( DataRow row in parent.Rows )
						row.Delete();
					this.DataSet.AcceptChanges();
					parent.Fill( "Select " + GameEventDataTable.PrimaryKey + ",bingoday,session,game,ballset,processed,closed_at from " + parent.FullTableName
					+ " left join " + this.FullTableName + " using (" + parent.PrimaryKeyName + ")"
					+ " where (processed=0 or processed is null) and (closed_at is not null and closed_at<>0)"
					+ " order by bingoday,session,game"
					+ ( ( max_games > 0 ) ? ( " limit " + max_games ) : "" )
					, 0 );

					bool added = false;
					foreach( DataRow row in parent.Rows )
					{
						if( row["processed"] == DBNull.Value )
						{
							DataRow newrow = this.NewRow();
							newrow[parent.PrimaryKeyName] = row[parent.PrimaryKeyName];
							newrow["processed"] = 0;
							this.Rows.Add( newrow );
							added = true;
						}
						else
							Fill( GameEventDataTable.PrimaryKey + "=" + row[parent.PrimaryKeyName] );
					}
					if( added )
						CommitChanges();
				}
				else
				{
					// oh I had the full select which could one-pass auto-expand this table to be the unprocessed list
					// but now we can get the balls
				}
			}
		}

		[MySQLPersistantTable]
		public class GameEventBallsProcessedAltDataTable : MySQLDataTable
		{
			new static readonly public string TableName = "bingo_game_balls_processed_alt";
			new static readonly public string PrimaryKey = XDataTable.ID( TableName );

			void AddColumns()
			{
				base.TableName = TableName;
				base.Prefix = Prefix;
				DataColumn dc;
				AddDefaultColumns( true, true, false );
				this.Columns.Add( dc = new DataColumn( GameEventDataTable.PrimaryKey, typeof( int ) ) );
				// ya this is a 1:1 relation... so it should alos be unique constrained
				dc.Unique = true;
				dc.AllowDBNull = false;
				this.Columns.Add( new DataColumn( "processed", typeof( bool ) ) );
			}

			public GameEventBallsProcessedAltDataTable()
			{
				AddColumns();
			}

			public GameEventBallsProcessedAltDataTable( DsnConnection database )
			{
				connection = database;
				AddColumns();
				//Create();
			}

			public GameEventBallsProcessedAltDataTable( DataSet dataSet, DsnConnection database )
			{
				connection = database;
				AddColumns();
				//extra = "engine=MyISAM";
				//Create();

				dataSet.Tables.Add( this );
				dataSet.Relations.Add( new DataRelation( "game_is_processed"
					, dataSet.Tables[GameEventDataTable.TableName]
						.Columns[GameEventDataTable.PrimaryKey]
						, dataSet.Tables[TableName]
						.Columns[GameEventDataTable.PrimaryKey]
						) );

			}

			public void FillUnprocessed()
			{
				FillUnprocessed( 0 );
			}
			public void FillUnprocessed( int max_games )
			{
				// shouldn't have any null parent ID

				if( this.DataSet != null )
				{
					MySQLDataTable parent = this.DataSet.Tables[GameEventDataTable.TableName] as MySQLDataTable;
					foreach( DataRow row in parent.Rows )
						row.Delete();
					this.DataSet.AcceptChanges();
					parent.Fill( "Select " + GameEventDataTable.PrimaryKey + ",bingoday,session,game,ballset,processed,closed_at from " + parent.FullTableName
					+ " left join " + this.FullTableName + " using (" + parent.PrimaryKeyName + ")"
					+ " where (processed=0 or processed is null) and (closed_at is not null and closed_at<>0) and bingoday>=20091130"
					+ " order by bingoday,session,game"
					+((max_games>0)?(" limit " + max_games):"")
					, 0 );

					bool added = false;
					foreach( DataRow row in parent.Rows )
					{
						if( row["processed"] == DBNull.Value )
						{
							DataRow newrow = this.NewRow();
							newrow[parent.PrimaryKeyName] = row[parent.PrimaryKeyName];
							newrow["processed"] = 0;
							this.Rows.Add( newrow );
							added = true;
						}
						else
							Fill( GameEventDataTable.PrimaryKey + "=" + row[parent.PrimaryKeyName] );
					}
					if( added )
						CommitChanges();
				}
				else
				{
					// oh I had the full select which could one-pass auto-expand this table to be the unprocessed list
					// but now we can get the balls
				}
			}
		}


		GameEventDataSet my_gameevent;
		public DataRow game_event_row;
				/// <summary>
		/// this Loads the prize-validation balls for the given session/game_number
		/// </summary>
		/// <param name="dsn"></param>
		/// <param name="session"></param>
		/// <param name="game_number"></param>
		public BingoGameEvent( DsnConnection dsn, BingoSessionEvent session, DataRow game_event_data_table_row )
		{
			// this is probably not a good thing to keep... 
			this.game_event_row = game_event_data_table_row;

			List<int> ball_list = new List<int>();

			// this data should be represented as a ball data...
			MySQLDataTable win_table = new MySQLDataTable(dsn
				, "select ball_list,balls from prize_validations where bingoday="
				+ DsnSQLUtil.MakeDateOnly(dsn, session.bingoday)
				+ " and session_id=" + session.session_number
				+ " and game_id=" + game_event_data_table_row["game_id"]
				+ " group by ball_list,balls"
				+ " order by ID desc"
				);

			if (win_table != null && win_table.Rows.Count > 0)
			{
				int nRow;
				for (nRow = 0; nRow < win_table.Rows.Count; nRow++)
				{
					if (Convert.ToInt32(win_table.Rows[nRow]["balls"]) >= 75)
						continue;
					DataRow win = win_table.Rows[nRow];
					String string_numbers = win["ball_list"].ToString();
					int count = Convert.ToInt32(win["balls"]);
					String[] numbers = string_numbers.Split();

					playing_balls = new int[numbers.Length];
					for (int n = 0; n < count; n++)
					{
						if (numbers[n].Length > 0)
							playing_balls[n] = Convert.ToByte(numbers[n]);
					}
					break;
				}
			}

			if (playing_balls == null && (Convert.ToInt32(game_event_data_table_row["game_id"]) < 12))
			{
 
				my_gameevent = new GameEventDataSet(dsn);
				my_gameevent.FillBallSet(Convert.ToDateTime(game_event_data_table_row["bingoday"])
					, Convert.ToInt32(game_event_data_table_row["session_id"])
					, ( game_event_data_table_row["ballset"] != DBNull.Value ) ? 
						Convert.ToInt32( game_event_data_table_row["ballset"] ) : 0 );

				foreach (DataRow game_row in my_gameevent.games.Rows)
				{
					if (Convert.ToInt32(game_row["game"]) <= Convert.ToInt32(game_event_data_table_row["game"]))
					{
						DataRow[] rows = game_row.GetChildRows("game_has_ball");
						foreach (DataRow row in rows)
						{
							ball_list.Add(Convert.ToByte(row["ball"]));
						}
					}
				}
				playing_balls = ball_list.ToArray();
			}
			//ball_list.Dispose();
		}

		/// <summary>
		/// this Loads the prize-validation balls for the given session/game_number
		/// </summary>
		/// <param name="dsn"></param>
		/// <param name="session"></param>
		/// <param name="game_number"></param>
		public BingoGameEvent( DsnConnection dsn, BingoSessionEvent session, int game_index )
		{
			List<byte> ball_list = new List<byte>();
			int game_id = 0;
			int game_num = session.session.GameList[game_index].game_number;

			bool did_next;
			int start = 0;

#if !use_prize_validations_for_balls
			do
			{
				MySQLDataTable win_table = new MySQLDataTable( dsn
					, "select bingo_game_id,ball from bingo_game_balls"
					+ " join bingo_game using(bingo_game_id)"
					+ " where bingoday=" + DsnSQLUtil.MakeDateOnly( dsn, session.bingoday )
					+ " and session=" + session.session_number
					+ " and game=" + game_num
					+ " and uncalled=0"
					+ " order by game desc,bingo_game_id desc,called_at desc,bingo_game_ball_id desc"
					);

				if( win_table != null && win_table.Rows.Count > 0 )
				{
					int max_row;
					for( max_row = 0; max_row < win_table.Rows.Count; max_row++ )
					{
						int this_row_game_id = Convert.ToInt32( win_table.Rows[max_row]["bingo_game_id"] );
						if( game_id == 0 )
						{
							game_id = this_row_game_id;
						}
						if( this_row_game_id == game_id )
						{
							ball_list.Add( Convert.ToByte( win_table.Rows[max_row]["ball"] ) );
						}
						else
							break;
					}

					if( game_num == 2 )
					{
						start = 1;
					}
				}
				game_id = 0;
				did_next = false;
				if( session.session.GameList[game_index].into )
				{
					BingoGame game = session.session.GameList[game_index];
					BingoGame next_game = game.prior_group_game;
					if( next_game == null )
					{
						next_game = game.prior_game;
						if( next_game.game_number == game.game_number )
							next_game = game.prior_group_game;
					}
					if( next_game != null )
					{
						game_index = session.session.GameList.IndexOf( next_game );
						game_num = session.session.GameList[game_index].game_number;
						did_next = true;
					}
				}

			}
			while( did_next );

			playing_balls = new int[ball_list.Count];
			for( int row = start; row < ball_list.Count; row++ )
			{
				playing_balls[row-start] = ball_list[ ( ball_list.Count - row ) - 1];
			}

#else
			// this data should be represented as a ball data...
			MySQLDataTable win_table = new MySQLDataTable( dsn
				, "select ball_list,balls from prize_validations where bingoday="
				+ DsnSQLUtil.MakeDateOnly( dsn, session.bingoday )
				+ " and session_id=" + session.session_number
				+ " and game_id=" + session.session.GameList[game_index].game_number
				+ " group by ball_list,balls"
				+ " order by ID desc"
				);

			if( win_table != null && win_table.Rows.Count > 0 )
			{
				int nRow;
				for( nRow = 0; nRow < win_table.Rows.Count; nRow++ )
				{
					if( Convert.ToInt32( win_table.Rows[nRow]["balls"] ) >= 75 )
						continue;
					DataRow win = win_table.Rows[nRow];
					String string_numbers = win["ball_list"].ToString();
					int count = Convert.ToInt32( win["balls"] );
					String[] numbers = string_numbers.Split();

					playing_balls = new int[numbers.Length];
					for( int n = 0; n < count; n++ )
					{
						if( numbers[n].Length > 0 )
							playing_balls[n] = Convert.ToByte( numbers[n] );
					}
					break;
				}
			}
#endif
		}

	}
}
