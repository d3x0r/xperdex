using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Odbc;

namespace GDAL.Players
{
	public class PlayersInfo : xperdex.classes.RegSQLDataTable
	{
		public PlayersInfo()
        {
            Prefix = "";
            TableName = "players_info";
            
            DataColumn dc = new DataColumn(ValueMemberName, typeof(int));
            dc.AutoIncrement = true;
            Columns.Add(dc);
            Columns.Add(DisplayMemberName, typeof(string));
            //Columns.Add("hall_id", typeof(int));
            //Columns.Add("charity_id", typeof(int));
            //Columns.Add("reset_flag", typeof(int));
            Columns.Add("update", typeof(DateTime));
            Columns.Add("last_name", typeof(string));
			Columns.Add("first_name",  typeof(string));
			Columns.Add("address_1",  typeof(string));
			Columns.Add("address_2", typeof(string));
			Columns.Add("city",  typeof(string));
			Columns.Add("state" , typeof(string));
			Columns.Add("zip_code",  typeof(string));
			Columns.Add("country",  typeof(string));
			Columns.Add("ssn", typeof(string));
			Columns.Add("gender",  typeof(string));
			Columns.Add("birthdate" , typeof(DateTime));
			//LoadMySQLDataTable(); To big to load.
	
        }

        public static string ValueMemberName { get { return "player_id"; } }	
        public static string DisplayMemberName { get { return "card"; } }

		public void CheckCard(string card)
		{
			string sql = "SELECT * FROM players_info WHERE card LIKE '%" + card +"%' ";
			SelectCommand(sql);
		}
		
		public void SearchPlayer(string card, string first_name, string last_name)
		{
			string sql = "SELECT * FROM players_info WHERE card LIKE '%" + card + "%' " +
						 " AND first_name LIKE '%" + first_name + "%' " +
							" AND last_name LIKE '%" + last_name + "%' ";
			SelectCommand(sql);
		}
	}
}
