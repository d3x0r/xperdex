using System;
using System.Data;
using xperdex.classes;
using OpenSkieScheduler3.Relations;

namespace OpenSkieScheduler3
{
	/// <summary>
	/// Schedules session macros for a day on the calendar.
	/// </summary>
	[SchedulePersistantTable]
	public class SessionMacroSchedule: MySQLDataTable<DataRow>
	{
		public static readonly String DayColumn = "starting_date";
		new public static readonly String TableName = "session_macro_schedule";
		new public static readonly String PrimaryKey = XDataTable.ID( TableName );

		public SessionMacroSchedule()
		{
			base.TableName = "(tmp)" + TableName;
		}

		public SessionMacroSchedule( ScheduleDataSet dataSet )
			: base( null, Names.schedule_prefix, TableName )
		{
			DataColumn dc = new DataColumn( DayColumn, typeof( DateTime ) );
            dc.ExtendedProperties.Add( "Extra Type", "date" );
			//dc.Namespace = "date";
			Columns.Add( dc );
			Columns.Add( SessionMacroTable.PrimaryKey, XDataTable.DefaultAutoKeyType );

			//dataSet.TableFiller.AddLast(LoadMySQLDataTable);

			dataSet.Tables.Add( this );
			dataSet.Relations.Add( new DataRelation( "session_macro_on_day"
								, dataSet.Tables[SessionMacroTable.TableName].Columns[SessionMacroTable.PrimaryKey]
								, this.Columns[SessionMacroTable.PrimaryKey]
								) );
		}

		new public static string ValueMemberName { get { return "session_macro_schedule_id"; } }
		public static string SortMemberName { get { return DayColumn; } }

		public object GetMacroSchedule( DateTime bingoday )
		{
            this.Clear();
            this.Fill( "starting_date = " + bingoday.ToString( "yyyyMMdd" ) );

			DataRow[] rows = this.Select( DayColumn + "=" + DsnSQLUtil.MakeDateOnly( DsnConnection.ConnectionMode.NativeDataTable, DsnConnection.ConnectionFlavor.Unknown, bingoday ), DayColumn + " desc" );

			if( rows.Length > 0 )
			{
				return rows[0][PrimaryKeyName];
			}
			return null;
		}
		public DataRow GetMacroScheduleRow( DateTime bingoday )
		{
			object _date = this.Compute( "max(" + DayColumn + ")", DayColumn + "<=" + DsnSQLUtil.MakeDateOnly( DsnConnection.ConnectionMode.NativeDataTable, DsnConnection.ConnectionFlavor.Unknown, bingoday ) );
			DateTime date;

			if( _date == DBNull.Value )
				return null;
			else
				date = (DateTime)_date;

			DataRow[] rows = this.Select( DayColumn + "=" + DsnSQLUtil.MakeDateOnly( DsnConnection.ConnectionMode.NativeDataTable, DsnConnection.ConnectionFlavor.Unknown, date ) );

			if( rows.Length > 0 )
				return rows[0].GetParentRow( "session_macro_on_day" );

			return null;
		}

		public DataRow GetScheduledSessionMacro( DateTime bingoday )
		{
            this.Clear();
            this.Fill();

			DataRow[] rows = this.Select( DayColumn + "=" + DsnSQLUtil.MakeDateOnly( DsnConnection.ConnectionMode.NativeDataTable, DsnConnection.ConnectionFlavor.Unknown, bingoday ), DayColumn + " desc" );

            if( rows.Length > 0 )
				return rows[0];

            return null;
		}

		public static void Fill( DsnConnection dsn, SessionMacroSchedule table, DateTime bingoday )
		{
            table.Clear();
			DateTime date;
			Object obj = dsn.ExecuteScalar( "select max(" + DayColumn + ") from " + table.FullTableName + " where " + DayColumn + "<='" + bingoday.ToString( "yyyy-MM-dd" ) + "'" );
			if( obj != DBNull.Value )
				date = Convert.ToDateTime( obj );
			else
				date = bingoday;
			//DsnSQLUtil.FillDataTable( dsn, table, "select * from " + table.FullTableName + " where " + DayColumn + "='" + DsnSQLUtil.MakeDate( dsn, date ) + "'" );
			DsnSQLUtil.FillDataTable( dsn, table, DayColumn + "='" + DsnSQLUtil.MakeDate( dsn, date ) + "'" );
        }
#if extended_month_schedules
		public DataTable GetMonthMacroSchedule( DateTime bingoday )
		{
			string sql = " SELECT session_macro_id, starting_date " +
						" FROM elec_sch_session_macro_schedule " +
						" WHERE DATE_FORMAT(`starting_date`,'%m') = '" + bingoday.ToString( "MM" ) + "' " +
						" ORDER BY starting_date";

			return xperdex.classes.StaticDsnConnection.GetDataTableQuery( sql );

		}

		public DataTable GetMonthMacroSchedule( string month )
		{
			string sql = " SELECT session_macro_id, starting_date " +
						" FROM elec_sch_session_macro_schedule " +
						" WHERE DATE_FORMAT(`starting_date`,'%m') = '" + month + "' " +
						" ORDER BY starting_date";

			return xperdex.classes.StaticDsnConnection.GetDataTableQuery( sql );

		}
#endif 
	}
}
