using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Odbc;

namespace GDAL.Players
{
	public class TopPlayers : xperdex.classes.RegSQLDataTable
	{
		public TopPlayers()
        {
            Prefix = "";
			TableName = "called_game_player_rank_partial";
			Columns.Add("card", typeof(string));
			Columns.Add("first_name", typeof(string));
			Columns.Add("last_name", typeof(string));
			Columns.Add("total_points", typeof(int));
			//LoadMySQLDataTable(); //To big to load.	
        }

        protected override void SelectAll()
		{
			string sql =
				" SELECT a1.card, a2.first_name, a2. last_name,  SUM(total_points) total_points" +
				" FROM " + TableName +" a1 " +
				" LEFT OUTER JOIN players_info a2 USING (card) " +  
				" GROUP BY card ";
			SelectCommand(sql);
		}

		/// Get from the Database the Table structure // Too Many records to Load All Table
		/// </summary>
		public override void SelectCondition(string condition)
		{
			if (condition != null && condition != "")
				condition = " WHERE " + condition;
			string selectComm =
				" SELECT a1.card, a2.first_name, a2. last_name, SUM(total_points) total_points" +
				" FROM " + TableName +   " a1 " +
				" LEFT OUTER JOIN players_info a2 USING (card) "  
				+ condition +
				" GROUP BY card " +
				" ORDER BY total_points DESC ";
			SelectCommand(selectComm);
		}

		/// Get from the Database the Table structure // Too Many records to Load All Table
		/// </summary>
		public void SelectCondition(string condition, string order, string limit)
		{
			if (condition != null && condition != "")
				condition = " WHERE " + condition;
			if (order != null && order != "")
				order = " ORDER BY " + order;
			string selectComm =
				" SELECT a1.card, a2.first_name, a2. last_name,  SUM(total_points) total_points" +
				" FROM " + TableName + " a1 " +
				" LEFT OUTER JOIN players_info a2 USING (card) " 
				+ condition
				+ " GROUP BY card "
				+ order
				+ limit;
			SelectCommand(selectComm);
		}
	}
}
