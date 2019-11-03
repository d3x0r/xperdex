using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data;
using OpenSkieScheduler3.Controls;
using OpenSkieScheduler3;
using OpenSkieScheduler3.BingoGameDefs;
using OpenSkieScheduler3.Relations;
using xperdex.gui;

namespace OpenSkie.Scheduler.Controls.Controls.Grids
{
	public class SessionSchedulingGrid : DataGridView
	{
		internal static DateTime month = DateTime.Now;
		
		DataTable current_data;
        


		bool filling = false;

		public SessionSchedulingGrid()
        {
			current_data = ControlList.schedule.Tables["current_session_schedule"];
			if( current_data == null )
			{
				current_data = new DataTable();
				current_data.TableName = "current_session_schedule";
				ControlList.schedule.Tables.Add( current_data );
			}

			//DataGridViewColumn dgvc;
			DataGridViewComboBoxColumn dgvcbc;
			DataGridViewTextBoxColumn dgvtbc;

			Columns.Add( dgvtbc = new DataGridViewTextBoxColumn() );
			dgvtbc.Name = "Date";
			dgvtbc.ReadOnly = true;

			Columns.Add( dgvtbc = new DataGridViewTextBoxColumn() );
			dgvtbc.Name = "Day";
			dgvtbc.ReadOnly = true;

			Columns.Add( dgvcbc = new DataGridViewComboBoxColumn() );
			dgvcbc.Name = "Session Type";
			dgvcbc.DataSource = ControlList.schedule.session_types;
			dgvcbc.DisplayMember = SessionTypeTable.NameColumn;
			dgvcbc.ValueMember = SessionTypeTable.PrimaryKey;
			Columns.Add( dgvcbc = new DataGridViewComboBoxColumn() );
			dgvcbc.Name = "Session";
			dgvcbc.DataSource = ControlList.schedule.sessions;
			dgvcbc.DisplayMember = SessionTable.NameColumn;
			dgvcbc.ValueMember = SessionTable.PrimaryKey;

			XDataGridViewComboBoxColumn xdbgcbc;
			Columns.Add( xdbgcbc = new XDataGridViewComboBoxColumn() );
			xdbgcbc.Name = "Prices";
			xdbgcbc.DataSource = ControlList.data.current_session_price_exception_sets;
			//dgvcbc.ValueMember = PriceExceptionSet.PrimaryKey;
			//dgvcbc.datamember
			//dgvcbc.DisplayMember = "";

			Columns.Add( xdbgcbc = new XDataGridViewComboBoxColumn() );
			xdbgcbc.Name = "Prizes";
			xdbgcbc.DataSource = ControlList.data.current_session_prize_exception_sets;
			//dgvcbc.ValueMember = PrizeExceptionSet.PrimaryKey;
			//xdbgcbc.DisplayMember = "";

			//this.AutoGenerateColumns = true;
			//this.CellValueChanged += new DataGridViewCellEventHandler( GameGroupAssignmentGrid_CellValueChanged );
			FillCurrent();
		}


		void FillCurrent()
		{

			SuspendLayout();
			ScheduleDataSet schedule = ControlList.schedule;
			filling = true;

			{
				object[] row_data = new object[6];
				int n;
				DateTime start = month;
				if( start.Day > 1 )
					start = start.AddDays( -( start.Day - 1 ) );


				for( n = 0; start.AddDays( n ).Month == start.Month; n++ )
				{
					DataRow session_macro = schedule.session_macro_schedule.GetMacroScheduleRow( start.AddDays( n ) );
					row_data[0] = start.AddDays( n );
					row_data[1] = start.AddDays(n).DayOfWeek;
					if( session_macro != null )
					{
						foreach( DataRow session_macro_session in session_macro.GetChildRows( schedule.session_macro_sessions.ChildrenOfParent ) )
						{
							DataRow session = session_macro_session.GetParentRow( schedule.session_macro_sessions.ParentOfChild );
							row_data[2] = session_macro_session[SessionTypeTable.PrimaryKey];
							row_data[3] = session_macro_session[SessionTable.PrimaryKey];
							row_data[4] = session_macro_session[PriceExceptionSet.PrimaryKey];
							row_data[5] = session_macro_session[PrizeExceptionSet.PrimaryKey];
							Rows.Add( row_data );
						}
					}
					else
					{
						row_data[2] = null;
						row_data[3] = null;
						row_data[4] = null;
						row_data[5] = null;
						Rows.Add( row_data );
					}
				}
			}

			filling = false;
		}

	}
}
