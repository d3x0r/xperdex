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
	public class CurrentSessionPrizeExceptionSets : CurrentObjectDataView
	{
		new public static readonly String TableName = CurrentObjectTableView.TableName( SessionPrizeExceptionSet.TableName );
		public CurrentSessionPrizeExceptionSets()
			: base( null, SessionPrizeExceptionSet.TableName )
		{

		}
		public CurrentSessionPrizeExceptionSets( DataSet set )
			: base( set, SessionPrizeExceptionSet.TableName )
		{
		}

	}

	public class CurrentPrizeData : CurrentObjectDataView
	{
		new public static readonly String TableName = CurrentObjectTableView.TableName( SessionPrizeData.TableName );

		public CurrentPrizeData()
			: base( null, SessionPrizeData.TableName )
		{

		}
		public CurrentPrizeData( DataSet set )
			: base( set, SessionPrizeData.TableName )
		{
		}
#if asdfasdf
		public CurrentPrizeData()
		{
			base.TableName = "(tmp)" + TableName;
		}

		public CurrentPrizeData( DataSet set )
		{
			base.TableName = TableName;
			AddColumns();
			set.Tables.Add( this );
			DataRelation relation = new DataRelation( SessionPrizeData.TableName, set.Tables[SessionPrizeData.TableName].Columns[SessionPrizeData.PrimaryKey], Columns[SessionPrizeData.PrimaryKey] );
			set.Relations.Add( relation );
		}

		void FillCurrentSession()
		{
			if( current_session != null && current_exception_set != null )
			{
				ScheduleDataSet schedule = this.DataSet as ScheduleDataSet;
				Clear();
				DataRow[] session_prizes = schedule.session_prize_data.Select( SessionTable.PrimaryKey + "='" + current_session[SessionTable.PrimaryKey] + "' and "
					+ PrizeExceptionSet.PrimaryKey + "='" + current_exception_set[PrizeExceptionSet.PrimaryKey] + "'" );
				foreach( DataRow session_prize in session_prizes )
				{
					DataRow new_row = NewRow();
					new_row[SessionPrizeData.PrimaryKey] = session_prize[SessionPrizeData.PrimaryKey];
					Rows.Add( new_row );
				}
			}
		}
#endif

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
				if( current_exception_set != null && current_session != null
					&& current_exception_set.RowState != DataRowState.Detached
					)
					RowFilter = SessionTable.PrimaryKey + "='" + current_session[SessionTable.PrimaryKey] + "' and "
						+ PrizeExceptionSet.PrimaryKey + "='" + current_exception_set[PrizeExceptionSet.PrimaryKey] + "'";
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
				if( current_exception_set != null && current_session != null )
					RowFilter = SessionTable.PrimaryKey + "='" + current_session[SessionTable.PrimaryKey] + "' and "
						+ PrizeExceptionSet.PrimaryKey + "='" + current_exception_set[PrizeExceptionSet.PrimaryKey] + "'";


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
				if( value.Table.TableName == SessionPrizeExceptionSet.TableName )
				{
					DataRow session_prize_exceptions = value;
					SessionPrizeExceptionSet table = session_prize_exceptions.Table as SessionPrizeExceptionSet;
					_current = value;
					current_session = session_prize_exceptions.GetParentRow( table.ChildrenOfParent );
					current_exception_set = session_prize_exceptions;

				}
				else if( value.Table.TableName == SessionTable.TableName )
				{
					current_session = value;
					//FillCurrentSession();
				}
				else if( value.Table.TableName == SessionPrizeData.TableName )
				{
					current_exception_set = value;
				}
			}
			get
			{
				return _current;
			}

		}

	}
}
