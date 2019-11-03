using System;
using xperdex.classes;

namespace RateRank2
{
	static internal class Local
	{
		internal static String output_dsn = Options.File( "RateRank.ini" )["config"]["Output Database DSN", "gamestate.db"];
		//internal static MySQLDataTable points;
		internal static ConfigurePacks.PackConfigDB pack_db = new ConfigurePacks.PackConfigDB();
		internal static ConfigureGames.GameConfigDB game_db = new ConfigureGames.GameConfigDB();
		internal static DsnConnection input_db;
		static Local()
		{
			input_db = StaticDsnConnection.dsn;
#if this_was_moved___
			points = new MySQLDataTable( new DsnConnection( Local.output_dsn ) );
			points.TableName = "rate_rank_points2";
			DataColumn dc = points.Columns.Add( "rate_rank_point_id", typeof( int ) );
			points.PrimaryKey = new DataColumn[] { dc };
			dc.AutoIncrement = true;
			dc.AutoIncrementSeed = 1;
			points.Columns.Add( "away_count", typeof( int ) );
			points.Columns.Add( "points", typeof( int ) );
			points.Create();
			points.Fill();#endif

		}
	}
}
