using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using xperdex.classes;
using OpenSkieScheduler3.BingoGameDefs;

namespace OpenSkieScheduler3.Relations
{
	public class oldCurrentSessionMacroSessions : CurrentObjectTableView
	{
		new public static readonly String TableName = CurrentObjectTableView.TableName( SessionDayMacroSessionTable.TableName );
		ScheduleDataSet schedule;

		public oldCurrentSessionMacroSessions( DataSet set )
			: base( set, SessionDayMacroSessionTable.TableName )
		{
			schedule = set as ScheduleDataSet;
		}

		public oldCurrentSessionMacroSessions()
			: base( null, SessionDayMacroSessionTable.TableName )
        {
		}

		public override string GetDisplayMember( DataRow row )
		{
			DataRow row_session = row.GetParentRow( "session_in_session_macro" );
			DataRow session_type = row.GetParentRow( "session_macro_session_type" );
			String session_type_name = ( session_type == null ) ? "<Undefined>" : session_type[SessionTypeTable.NameColumn].ToString();
			//if( session_type == null )
			//	row[SessionTypeTable.PrimaryKey] = schedule.session_types.GetDefault();
			DataRow Prizes = row.GetParentRow( "session_macro_prize_exceception" );
			String session_prize_name = ( Prizes == null ) ? "<Undefined>" : Prizes[PrizeExceptionSet.NameColumn].ToString();

			DataRow Prices = row.GetParentRow( "session_macro_price_exceception" );
			String session_price_name = ( Prices == null ) ? "<Undefined>" : Prices[PriceExceptionSet.NameColumn].ToString();


			if( row[SessionDayMacroSessionTable.NameColumn].GetType() == typeof( DBNull ) ||
				row[SessionDayMacroSessionTable.NameColumn].ToString().Length == 0 )
				return row[SessionDayMacroSessionTable.NumberColumn] +") "
					+ session_type_name 
					+ ":" + row_session[XDataTable.Name( row_session.Table.TableName )].ToString()
					+ "[" + session_price_name + "]"
					+ "[" + session_prize_name + "]"
					;

			return row[SessionDayMacroSessionTable.NumberColumn] + ") "
				+ session_type_name
				+ ":" + row[SessionDayMacroSessionTable.NameColumn].ToString() 
				+ "<" + row_session[XDataTable.Name( row_session.Table.TableName )].ToString() + ">"
				+ "[" + session_price_name + "]"
				+ "[" + session_prize_name + "]"
				;
		}
	}


	public class CurrentSessionMacroSessions : CurrentObjectDataView
	{
		new public static readonly String TableName = CurrentObjectTableView.TableName( SessionDayMacroSessionTable.TableName );
		public CurrentSessionMacroSessions()
					: base( null, SessionDayMacroSessionTable.TableName )
		{

		}
		public CurrentSessionMacroSessions( DataSet set )
			: base( set, SessionDayMacroSessionTable.TableName )
		{
		}

	}
}
