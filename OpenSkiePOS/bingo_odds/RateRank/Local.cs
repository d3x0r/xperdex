using System;
using System.Collections.Generic;
using System.Text;
using xperdex.classes;
using System.Data;

namespace RateRank
{
	static internal class Local
	{
		internal static String output_dsn = INI.File( "RateRank.ini" )["config"]["Output Database DSN", "gamestate.db"];
		internal static MySQLDataTable points;
		internal static ConfigurePacks.PackConfigDB db = new ConfigurePacks.PackConfigDB();
		static Local()
		{
			points = new MySQLDataTable( new DsnConnection( Local.output_dsn ) );
			points.TableName = "rate_rank_points2";
			DataColumn dc = points.Columns.Add( "rate_rank_point_id", typeof( int ) );
			dc.AutoIncrement = true;
			points.Columns.Add( "away_count", typeof( int ) );
			points.Columns.Add( "points", typeof( int ) );
			points.Create();
			points.Fill();
		}
	}
}
