using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Odbc;
using xperdex.classes;

namespace TopPlayers
{
	public class PlayerTrack: MySQLDataTable
	{
		public static readonly String TableName = "player_track";
		public static readonly string PrimaryKey = "ID";

		public PlayerTrack()
		{
			base.TableName = TableName;
		}

		public PlayerTrack(DsnConnection odbc)
			: base( odbc, "", TableName, false,false,false,false)
		{
			Columns.Add("transnum", typeof(long));
			Columns.Add("void_trans", typeof(long));
			Columns.Add("card", typeof(string));
			Columns.Add("value", typeof(int));
			Columns.Add("points", typeof(int));
			Columns.Add("session", typeof(int));
			Columns.Add("cashier", typeof(string));
			DataColumn dc = new DataColumn("bingoday", typeof(DateTime));
			dc.Namespace = "date";
			Columns.Add(dc);
			Columns.Add("dummy_timestamp", typeof(DateTime));
			Columns.Add("transaction_whenstamp", typeof(DateTime));
			Create();
        }
	}
}
