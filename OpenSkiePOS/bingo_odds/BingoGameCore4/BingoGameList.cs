using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using OpenSkieScheduler3;
using OpenSkieScheduler3.Relations;
using xperdex.classes;

namespace BingoGameCore4
{
	/// <summary>
	/// List of BingoGame
	/// </summary>
	public class BingoGameList:List<BingoGame>
	{
		public BingoGameGroupList game_group_list = new BingoGameGroupList();
		BingoSession session; // this is the session this game list is in.

		/// <summary>
		/// this is built during 'Load'
		/// </summary>
		public BingoPacks pack_list; // this is the list of packs these games play.

		/// <summary>
		/// this is a summary per-pack list of max card counts in all games
		/// </summary>
		public List<int> max_pack_card_counts = new List<int>(); 
		//List<BingoGame> games = new List<BingoGame>();

		public static BingoGameEvent.GameEventDataSet manual_dataset;

		public BingoGameList()
		{
			pack_list = new BingoPacks( this, null, null );
			
		}

		public BingoPack CreatePack( string Name, int cards )
		{
			return pack_list.MakePack( Name, cards );
		}

		public BingoPack CreatePack( BingoDealer dealer, string Name, int cards, int face_size = 25 )
		{
			BingoPack pack = pack_list.MakePack( Name, cards, face_size );
			if( !pack.dealers.Contains( dealer ) )
				pack.dealers.Add( dealer );
			//pack._dealer = dealer;
			return pack;
		}

		public void UpdateCardCounts()
		{
			foreach( BingoGame game in this )
			{
				for( int pack = 0; pack < game.pack_card_counts.Count; pack++ )
					if( pack == max_pack_card_counts.Count )
						max_pack_card_counts.Add( game.pack_card_counts[pack] );
					else if( game.pack_card_counts[pack] > max_pack_card_counts[pack] )
						max_pack_card_counts[pack] = game.pack_card_counts[pack];
			}
		}

		public static String[ ] sessions;
		public static Int32[ ] sessionIds;

		public static void GetPlayedSessions( DateTime bingoday )
		{
			List<String> sessionList = new List<String>();
			List<Int32> sessionIdList = new List<Int32>();

			MySQLDataTable win_table = new MySQLDataTable( StaticDsnConnection.dsn
				, "select * from prize_validations where bingoday=" + MySQLDataTable.MakeDateOnly( bingoday ) + " group by session_id" 
				);

			//ScheduleDataSet scheduleDataSet = new ScheduleDataSet( StaticDsnConnection.dsn, bingoday, 1, true );
			//scheduleDataSet.sessions.Fill();

			ScheduleDataSet scheduleDataSet = new ScheduleDataSet( StaticDsnConnection.dsn, bingoday, 1, true );


			foreach( DataRow row in scheduleDataSet.sessions.Rows )
			{
				sessionList.Add( row[ "session_name" ].ToString() );
				sessionIdList.Add( Convert.ToInt32( row[ "session_id" ] ) );


				MySQLDataTable game_table1 = new MySQLDataTable( StaticDsnConnection.dsn,
					"SELECT * from bingo_sched3_session_game where session_id=" + row[ "session_id" ].ToString() );

				DataRow[] game_table = scheduleDataSet.session_games.Select( scheduleDataSet.games.PrimaryKeyName + "=" + row[ scheduleDataSet.games.PrimaryKeyName ].ToString() );

				game_table1.Clear();

				foreach( DataRow gameRow in game_table1.Rows )
					game_table1.Rows.Add( gameRow[ "game_id" ], gameRow[ "session_game_name" ] );
			}

			
			sessions = sessionList.ToArray();
			sessionIds = sessionIdList.ToArray();
		}


		internal ScheduleDataSet schedule;

		public void ReloadSessionGames( DataRow session )
		{
			if( schedule == null )
				return;

			// clear all my games.
			this.Clear();
			// hmm...
			{
				DataRow[] SessionGames = session.GetChildRows( "session_has_game" );

				if( SessionGames != null )
					foreach( DataRow session_game in SessionGames )
					{
						int game_number = Convert.ToInt32( session_game[SessionGame.NumberColumn] );
						if( session_game.RowState == DataRowState.Deleted )
							continue;
						foreach( BingoGame test_game in this )
						{
							if( test_game.game_number == game_number )
							{
								test_game.Extend( this, session_game );
								game_number = 0;
								break;
							}
						}
						if( game_number > 0 )
						{
							BingoGame game = new BingoGame( this, session_game );
							//new BingoGame( patterns.ToArray() );
							Add( game );
							game.game_list = this;
							game.game_ID = IndexOf( game );
							DataRow[] games_game_groups = session_game.GetChildRows( "session_game_has_session_pack_group" );
							foreach( DataRow game_game_group in games_game_groups )
							{
								DataRow session_pack_group = game_game_group.GetParentRow( "session_pack_group_in_session_game" );
								DataRow pack_group_info = session_pack_group.GetParentRow( "pack_group_in_session" );
								//DataRow pack_group = session_pack_group.GetParentRow( "pack_group_in_session" );
								BingoGameGroup bgg = this.game_group_list.GetGameGroup( pack_group_info );
								bgg.Add( game );
							}
							game.session_game_id = session_game[SessionGame.PrimaryKey];
						}
					}
			}
			if( pack_list == null )
				pack_list = new BingoPacks( this, schedule, session );
			UpdateCardCounts();
		}

		List<int> use_groups;

		public void Load( DsnConnection dsn, ScheduleDataSet schedule, DateTime bingoday, int session, List<int> use_groups )
		{

			MySQLDataTable win_table = new MySQLDataTable( dsn
				, "select * from prize_validations where bingoday=" + DsnSQLUtil.MakeDateOnly( dsn, bingoday ) + " and session_id=" + session
				);


			if( win_table.Rows.Count == 0 )
			{
				Log.log( "No prizes for this session today." );
			//	return;
			}

			{
				foreach( DataRow row in win_table.Rows )
				{
					Log.log( "win record " + " Game:" + row["game_id"] + " card:" + row["card"].ToString() + " ball:"+row["ball_list"] + " unit:" + row["unit"]);
				}
			}


			this.use_groups = use_groups;
			this.schedule = schedule;
			if( this.schedule == null )
			{
				this.schedule = new ScheduleDataSet( dsn );
			}

			MessageBox.Show( "Failed to update this method." );
			//ReloadSessionGames( schedule.GetSession( bingoday, 1 ) );
		}


		/// <summary>
		/// This loads a specific schedule set.  You only need to pass dsn OR schedule.
		/// </summary>
		/// <param name="dsn"></param>
		/// <param name="schedule"></param>
		/// <param name="bingoday"></param>
		/// <param name="session"></param>
		public BingoGameList( BingoSession session )
		{
			this.session = session;
			this.schedule = session.schedule;
			ReloadSessionGames( session.dataRowSession );
		}

		public void Load( DsnConnection dsn, DateTime bingoday, int session )
		{
			Load( dsn, null, bingoday, session, null );
		}
	}



	public class BingoGameGroupList: List<BingoGameGroup>
	{
		Guid pack_set_id;

		public BingoGameGroup GetGameGroup( object ID, String name )
		{
			foreach( BingoGameGroup group in this )
			{
				if( group.ID.Equals( ID ) )
					return group;
			}
			BingoGameGroup newgroup = new BingoGameGroup( ID );
			newgroup.name = name;
			this.Add( newgroup );
			return newgroup;

		}
		public BingoGameGroup GetGameGroup( DataRow game_group_info )
		{
            if( game_group_info != null )
            {
                object ID = game_group_info[ PackGroupTable.PrimaryKey ];
                foreach( BingoGameGroup group in this )
                {
                    if( group.ID.Equals( ID ) )
                        return group;
                }
                BingoGameGroup newgroup = new BingoGameGroup( ID );
                newgroup.name = game_group_info[ PackGroupTable.NameColumn ] as string;
                this.Add( newgroup );
                return newgroup;
            }
            return null;
		}
		public void AddGameGroup( BingoGameGroup bgg )
		{
			Add( bgg );
			bgg.game_group_ID = IndexOf( bgg );
		}
	}
}
