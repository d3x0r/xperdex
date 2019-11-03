using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using xperdex.classes;
using System.Data;

namespace AutoSessionScheduler
{
	public partial class SessionSalesDefine : Form
	{
		bool initializing;

		public void UpdatePageViews( )
		{
			PageList.DataSource = Local.session_info.page_view;

		}

		public SessionSalesDefine()
		{
			initializing = true;
			InitializeComponent();
			SessionList.DataSource = Local.session_info;
			SessionList.DisplayMember = MySQLDataTable.Name( Local.session_info );
			PageList.DataSource = Local.session_info.page_view;
			PageList.Columns[2].SortMode = DataGridViewColumnSortMode.Automatic;
			//PageList.Rows[0].Cells[0].Selected = false;
			//PageList.Rows[0].Cells[1].Selected = true;
			PageList.Columns[0].Width = 0;
			PageList.Columns[1].Width = 90;
			PageList.Columns[2].Width = 70;
			PageList.Columns[3].Width = 70;
			PageList.Columns[4].Width = 36;
			PageList.Columns[5].Visible = false;
			PageList.Columns[0].Visible = false;

			initializing = false;
			//PageList.Columns[0].Visible = false;
			
			Local.session_info.UpdatePages();
		}

		private void button1_Click( object sender, EventArgs e )
		{
			string result = QueryNewName.Show( "Enter new Session Sales name" );
			if( result.Length > 0 )
			{
				Local.session_info.AddSession( result );
			}
		}

		private void button2_Click( object sender, EventArgs e )
		{
			string result = QueryNewName.Show( "Enter new Page name" );
			if( result.Length > 0 )
			{
				string result2 = QueryNewName.Show( "Enter new Page number" );
				if( result2.Length > 0 )
				{
					int n = 0;
					try
					{
						n = Convert.ToInt32( result2 );
					}
					catch( Exception e2 )
					{

					}
					if( n > 0 )
						Local.session_info.pages.AddPage( result, n );
					else
						MessageBox.Show( "Invalid Page Number" );
				}
			}
		}

		private void PageList_CellDoubleClick( object sender, DataGridViewCellEventArgs e )
		{
			
		}

		private void SessionList_SelectedValueChanged( object sender, EventArgs e )
		{
			if( SessionList.SelectedValue != null )
			{
				Local.add_to_session = Local.current_session;
				Local.current_session = ( (DataRowView)SessionList.SelectedValue ).Row;
				if( !initializing )
					Local.session_info.UpdatePages();
				Local.add_to_session = Local.current_session;
			}
		}

		private void label1_Click( object sender, EventArgs e )
		{

		}

		private void label2_Click( object sender, EventArgs e )
		{

		}

		private void button3_Click( object sender, EventArgs e )
		{
			if( MessageBox.Show( "Are you sure you wish to delete page (insert name)", "Confirm Delete", MessageBoxButtons.YesNo ) == DialogResult.Yes )
			{
				if( MessageBox.Show( "Operation is not recoverable\nDo you want to abort deletion?"
					, "Confirm Delete", MessageBoxButtons.YesNo ) == DialogResult.No )
				{
					MessageBox.Show( "Okay." );
				}
			}
		}

		private void button4_Click( object sender, EventArgs e )
		{
			if( MessageBox.Show( "Are you sure you wish to delete session (insert name)", "Confirm Delete", MessageBoxButtons.YesNo ) == DialogResult.Yes )
			{
				if( MessageBox.Show( "Operation is not recoverable\nDo you want to abort deletion?"
					, "Confirm Delete", MessageBoxButtons.YesNo ) == DialogResult.No )
				{
					MessageBox.Show( "Okay." );
					Local.sessions_changed = true;
				}
			}
		}

	}
}