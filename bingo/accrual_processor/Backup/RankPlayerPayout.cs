using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Odbc;
using xperdex.classes;

namespace TopPlayers
{
	public class RankPlayerPayout: MySQLDataTable
	{
		public static readonly String TableName = "called_game_player_payouts";
		public static readonly string PrimaryKey = MySQLNameTable.ID( TableName );

		public RankPlayerPayout()
		{
			base.TableName = TableName;
		}
		public RankPlayerPayout(DsnConnection odbc)
			: base( odbc, "", TableName, true, false, false )
		{
			Columns.Add("position", typeof(int));
			DataColumn dc = new DataColumn("date_prize", typeof(DateTime));
			dc.Namespace = "date";
			Columns.Add(dc);
			Columns.Add("card", typeof(string));
			Columns.Add("total_points", typeof(int));
			Columns.Add("cash_prize", typeof(xperdex.classes.Money));
			Columns.Add("point_prize", typeof(int));
			Columns.Add("paid", typeof(int));
			Columns.Add("void", typeof(int));
			Columns.Add("removed", typeof(int));
			Columns.Add("created_on", typeof(DateTime));
			Columns.Add("paid_on", typeof(DateTime));
			Columns.Add("void_on", typeof(DateTime));
			Columns.Add("removed_on", typeof(DateTime));
			Create();
			Fill(); 
        }


		
	}
}
