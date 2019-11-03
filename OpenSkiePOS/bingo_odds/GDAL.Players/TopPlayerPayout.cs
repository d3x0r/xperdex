using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Odbc;

namespace GDAL.Players
{
	public class TopPlayerPayout: xperdex.classes.RegSQLDataTable
	{
		public TopPlayerPayout()
        {
            Prefix = "";
			TableName = "called_game_player_payouts";
            
            DataColumn dc = new DataColumn(ValueMemberName, typeof(int));
            dc.AutoIncrement = true;
            Columns.Add(dc);
			Columns.Add("position", typeof(int));
			dc = new DataColumn("date_payout", typeof(DateTime));
			dc.Namespace = "date";
			Columns.Add(dc);
			Columns.Add("payout", typeof(xperdex.classes.Money));
			Columns.Add("card", typeof(string));
			Columns.Add("removed", typeof(int));
			LoadMySQLDataTable();
	
        }

		public static string ValueMemberName { get { return "called_game_player_payout_id"; } }	
		
	}
}
