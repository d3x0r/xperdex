using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Odbc;

namespace GDAL.Players
{
	public class TopPlayerPrizes: xperdex.classes.RegSQLDataTable
	{
		public TopPlayerPrizes()
        {
            Prefix = "";
			TableName = "called_game_player_prizes";
            
            DataColumn dc = new DataColumn(ValueMemberName, typeof(int));
            dc.AutoIncrement = true;
            Columns.Add(dc);
            Columns.Add("position" , typeof(int));
			Columns.Add(DisplayMemberName, typeof(xperdex.classes.Money));
            LoadMySQLDataTable();
			LoadInitValues();
		}

		private void LoadInitValues()
		{
			if (this.Rows.Count == 0)
			{
				insertValues(1, 50000);
				insertValues(2, 12500);
				insertValues(3, 10000);
				insertValues(4, 5000);
				insertValues(5, 5000);
				insertValues(6, 5000);
				insertValues(7, 5000);
				insertValues(8, 2500);
				insertValues(9, 2500);
				insertValues(10, 2500);
				Fill();
			}

		}

		private void insertValues(int p_position, int p_prize)
		{
			string sql = " INSERT INTO " + CompleteTableName + " (position, prize) " +
			" VALUES ('" + p_position + "', '" + p_prize + "');";
			connection.ExecuteNonQuery(sql);
		}
		
		public static string ValueMemberName { get { return "called_game_player_prize_id"; } }	
        public static string DisplayMemberName { get { return "prize"; } }
		
	}
}
