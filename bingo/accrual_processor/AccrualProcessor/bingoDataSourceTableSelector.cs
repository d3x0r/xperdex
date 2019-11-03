using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ECube.AccrualProcessor
{
	public partial class bingoDataSourceTableSelector : Form
	{
		ListBox edit_control;
		public bingoDataSourceTableSelector()
		{
			InitializeComponent();
		}

		public bingoDataSourceTableSelector( ListBox control )
		{
			InitializeComponent();
			edit_control = control;
		}

		private void bingoDataSourceTableSelector_Load( object sender, EventArgs e )
		{
			foreach( DataTable table in Local.BingoDataSet.Tables )
			{
				if( table.Rows.Count > 0 )
					listBox1.Items.Add( table.TableName );
			}
			listBox1.MouseDoubleClick += listBox1_MouseDoubleClick;
		}

		void listBox1_MouseDoubleClick( object sender, MouseEventArgs e )
		{
			object o = listBox1.SelectedItem;
			if( o != null )
			{
				DataTable table;
				edit_control.DataSource = table = Local.BingoDataSet.Tables[(String)o];
				foreach( DataColumn col in table.Columns )
					if( col.DataType == typeof( String ) )
						edit_control.DisplayMember = col.ColumnName;
			}
			Close();
		}

		private void listBox1_SelectedIndexChanged( object sender, EventArgs e )
		{

		}
	}
}
