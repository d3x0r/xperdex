using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Odbc;
using xperdex.classes;

namespace TopPlayers
{
	public class RankPlayerPrizes: MySQLDataTable
	{
		public static readonly String TableName = "called_game_player_prizes";
		public static readonly string PrimaryKey = MySQLNameTable.ID( TableName );

		public RankPlayerPrizes(DsnConnection odbc)
			: base( odbc, "", TableName, true, false, false )
		{
			Columns.Add("position", typeof(int));
			Columns.Add("cash_prize", typeof(Money));
			Columns.Add("point_prize", typeof(int));
			Create();
			Fill();
			init_values();
        }

		public void init_values()
		{
			if (this.Rows.Count == 0)
			{
				this.Rows.Add(1, 1, (Money)50000,100);
				this.Rows.Add(2, 2, (Money)12500, 80);
				this.Rows.Add(3, 3, (Money)10000, 50);
				this.Rows.Add(4, 4, (Money)5000, 30);
				this.Rows.Add(5, 5, (Money)5000, 30);
				this.Rows.Add(6, 6, (Money)5000, 30);
				this.Rows.Add(7, 7, (Money)5000, 30);
				this.Rows.Add(8, 8, (Money)2500, 10);
				this.Rows.Add(9, 9, (Money)2500, 10);
				this.Rows.Add(10, 10, (Money)2500, 10);
				this.Rows.Add(11, -1, (Money)500, 5);
				this.Rows.Add(12, -2, (Money)1000, 10);
				this.Rows.Add(13, -3, (Money)2500, 25);
			}
		}

		public string GetConditionedDisplayValue(string ValueMember, string DisplayMember, string Condition)
		{
			string parentName = "";
			if (Condition != "")
			{
				DataRow[] ParentRow = this.Select(ValueMember + " = " + Condition);
				if (ParentRow.Length > 0)
					if (ParentRow.Length > 1)
						parentName = ParentRow[0][DisplayMember].ToString() + "... ";
					else
						parentName = ParentRow[0][DisplayMember].ToString();
				else
					parentName = "0";
			}
			else
				parentName = "0";
			return parentName;
		}
	}
}
