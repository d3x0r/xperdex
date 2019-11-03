using System;
using System.Data;
using xperdex.classes;

namespace BingoGameCore
{
	namespace GamePlay
	{

		static internal class CreateTables
		{
			public static DataSet ds;
			public static MySQLDataTable play_db;
			public static MySQLDataTable game_db;
			public static DsnConnection dsn_me;
			public static DsnConnection dsn_public;
			
			static CreateTables()
			{
				dsn_me = new DsnConnection( "odds.db" );
				dsn_public = new DsnConnection( "mysql-vertest" );
  
				play_db = new MySQLDataTable();
				play_db.TableName = "Odds_GamePlay";
				play_db.AddDefaultColumns( true );
				play_db.Columns.Add( "Odds_GamePlay_id", typeof( int ) );
				play_db.Columns.Add( "player_id", typeof( int ) );
				play_db.Columns.Add( "start_card", typeof( int ) );
				play_db.Columns.Add( "card_count", typeof( int ) );
				play_db.Columns.Add( "card_base", typeof( int ) );
				//play_db.Create();
			

				//Schedule.GetMacroSchedule				

				game_db = new MySQLDataTable( "Odds_Games" );
				game_db.AddDefaultColumns( true );
				game_db.Columns.Add( "Balls", typeof( String ) );
				game_db.Columns.Add( "session", typeof( int ) );
				game_db.Columns.Add( "game", typeof( int ) );
				game_db.Columns.Add( "bingoday", typeof( DateTime ) );
				game_db.Columns.Add( "pattern_id_1", typeof( int ) );
				game_db.Columns.Add( "pattern_id_2", typeof( int ) );
				game_db.Columns.Add( "pattern_id_3", typeof( int ) );
				game_db.Columns.Add( "pattern_id_4", typeof( int ) );
				game_db.Columns.Add( "pattern_id_5", typeof( int ) );
				//game_db.Create();

				ds = new DataSet();
				ds.Tables.Add( play_db );
				ds.Tables.Add( game_db );
				ds.Relations.Add( new DataRelation( "game_play"
					, game_db.Columns[0]
					, play_db.Columns[ XDataTable.Name( game_db )] ) 
					);
 

				
			}

			internal static void UpdateTables( DateTime bingoday, int session )
			{
				MySQLDataTable prize_validations;
				prize_validations = new MySQLDataTable( dsn_public
					, "select * from prize_validations where cast( bingoday as date)=cast(" + MySQLDataTable.MakeDate( bingoday ) + " as date) and session=" + session + " group by string_numbers" );
				DataRow[] rows = prize_validations.Select( null, "game" );
				foreach( DataRow row in rows )
				{
					//DataRow[] check;
				}
			}

		}

	}
	class GamePlayDatabase
	{
		void whatever()
		{
			GamePlay.CreateTables.UpdateTables(DateTime.Now, 1);

		}
	}
}
