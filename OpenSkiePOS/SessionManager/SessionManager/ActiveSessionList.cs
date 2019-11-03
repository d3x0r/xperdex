using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using xperdex.gui;
using xperdex.core.interfaces;
using System.Windows.Forms;
using System.Data;

namespace SessionManager
{
	[ControlAttribute( Name = "Active Sessions" )]
	class ActiveSessionList : XDataGridView
	{
		int _hold_changes;
		internal bool hold_changes
		{
			get
			{
				return _hold_changes != 0;
			}
			set
			{
				if( value )
					_hold_changes++;
				else
					_hold_changes--;

				if( !value )
					ActiveSessionList_SelectionChanged( null, null );
			}
		}
		public ActiveSessionList()
		{
			AllowUserToOrderColumns = false;
			RowHeadersVisible = false;
			AllowUserToAddRows = false;
			AllowUserToDeleteRows = false;
			SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			this.EndEdit();
			DataSource = SessionManagementState.active_sessions;
			this.ColumnAdded += new System.Windows.Forms.DataGridViewColumnEventHandler( ActiveSessionList_ColumnAdded );
			SelectionChanged += new EventHandler( ActiveSessionList_SelectionChanged );
			if( SessionManagementState.active_session_lists == null )
				SessionManagementState.active_session_lists = new List<ActiveSessionList>();
			SessionManagementState.active_session_lists.Add( this );
		}

		void ActiveSessionList_SelectionChanged( object sender, EventArgs e )
		{
			bool have_selection = false;
			if( _hold_changes > 0 )
				return;
			if( SelectedRows.Count > 0 )
			{
				_hold_changes++;
				DataGridViewRow row = Rows[SelectedRows[0].Index];
				DataRowView drv = row.DataBoundItem as DataRowView;
				SessionManagementState.current_open_session = drv.Row;
				have_selection = true;
				_hold_changes--;
			}

			else foreach( DataGridViewCell cell in SelectedCells )
			{
				DataGridViewRow row = Rows[SelectedRows[0].Index];
				DataRowView drv = row.DataBoundItem as DataRowView;
				SessionManagementState.current_open_session = drv.Row;
				have_selection = true;
				break;
			}
			if( !have_selection )
			{
				SessionManagementState.current_open_session = null;
			}
		}

		void ActiveSessionList_ColumnAdded( object sender, System.Windows.Forms.DataGridViewColumnEventArgs e )
		{
			if( e.Column.Name == "session_name" )
			{
				e.Column.Width = 180 * scale_x;
			}
			else if( e.Column.Name == "bingoday" )
			{
				e.Column.Width = 90 * scale_x;
			}
			else if( e.Column.Name == "session_order" )
			{
				e.Column.Width = 60 * scale_x;
				e.Column.HeaderText = "Number";
			}
			else
			{
				e.Column.Visible = false;
			}
		}
	}
}
