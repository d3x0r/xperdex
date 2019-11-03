using System;
using System.Collections.Generic;
using System.Text;
using OpenSkieScheduler3.Relations;
using System.Data;
using OpenSkieScheduler3.BingoGameDefs;
using OpenSkieScheduler3;
using xperdex.classes;

namespace OpenSkie.Scheduler.CurrentTables
{
	public class CurrentSessionPriceExceptionSets : CurrentObjectDataView
	{
		new public static readonly String TableName = CurrentObjectTableView.TableName( SessionPriceExceptionSet.TableName );
		public CurrentSessionPriceExceptionSets()
			: base( null, SessionPriceExceptionSet.TableName )
        {
			
        }
		public CurrentSessionPriceExceptionSets( DataSet set )
			: base( set, SessionPriceExceptionSet.TableName )
		{
		}

	}

	public class CurrentPriceData :DataTable
	{
		new public static readonly String TableName = CurrentObjectTableView.TableName( SessionPriceData.TableName );
		new public static readonly String NameColumn = XDataTable.Name( TableName );

		void AddColumns()
		{
			Columns.Add( SessionPriceData.PrimaryKey, XDataTable.DefaultAutoKeyType );
			Columns.Add( NameColumn, typeof( String ) );
		}

		public CurrentPriceData()
        {
			base.TableName = "(tmp)" + TableName;
		}

		public CurrentPriceData( DataSet set )			
		{
			base.TableName = TableName;
			AddColumns();
			if( set.Tables.Contains( this.ToString() ) == false )
			{
				set.Tables.Add( this );
				DataRelation relation = new DataRelation( SessionPriceData.TableName, set.Tables[ SessionPriceData.TableName ].Columns[ SessionPriceData.PrimaryKey ], Columns[ SessionPriceData.PrimaryKey ] );
				set.Relations.Add( relation );
			}
		}

		void FillCurrentSession()
		{
			if( current_session != null && current_exception_set != null 
				&& current_exception_set.RowState != DataRowState.Detached 
				)
			{
				ScheduleDataSet schedule = this.DataSet as ScheduleDataSet;
				Clear();
				DataRow[] session_prices = schedule.session_price_data.Select( SessionTable.PrimaryKey + "='" + current_session[SessionTable.PrimaryKey] + "' and "
					+ PriceExceptionSet.PrimaryKey + "='" + current_exception_set[PriceExceptionSet.PrimaryKey] + "'" );
				foreach( DataRow session_price in session_prices )
				{
					DataRow new_row = NewRow();
					new_row[SessionPriceData.PrimaryKey] = session_price[SessionPriceData.PrimaryKey];
					Rows.Add( new_row );
				}
			}
		}


		DataRow _current_session;
		public DataRow current_session
		{
			get
			{
				return _current_session;
			}
			private set
			{
				_current_session = value;
			}

		}
		public DataRow _current_exception_set;
		public DataRow current_exception_set
		{
			get
			{
				return _current_exception_set;
			}
			private set
			{
				_current_exception_set = value;
			}
		}

		DataRow _current;
		public DataRow Current
		{
			set
			{
				if( value == null )
				{
					// I dunno... something like clear everything?
					return;
				}
				if( value.Table.TableName == SessionPriceExceptionSet.TableName )
				{
					DataRow session_price_exceptions = value;
					SessionPriceExceptionSet table = session_price_exceptions.Table as SessionPriceExceptionSet;
					_current = value;
					current_session = session_price_exceptions.GetParentRow( table.ChildrenOfParent  );
					current_exception_set = session_price_exceptions.GetParentRow( table.ParentOfChild );
					FillCurrentSession();
				}
				else if( value.Table.TableName == SessionTable.TableName )
				{
					current_session = value;
					FillCurrentSession();
				}
				else if( value.Table.TableName == SessionPriceData.TableName )
				{
					current_exception_set = value;
					FillCurrentSession();
				}
			}
			get
			{
				return _current;
			}
		}

	}
}
