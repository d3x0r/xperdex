using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using xperdex.classes;

namespace OpenSkieScheduler
{
    public partial class RelatedTableEditor : Form
    {
		string table_name1;
		DataTable table1;
		string table_name2;
		DataTable table2;
		string rel1;
		DataTable table3;
		DataTable current_table3;

		void SetupRelatedTableEditor( DataSet dataset, String Table1, String Table2 )
        {
			table_name1 = Table1;
			table_name2 = Table2;

			rel1 = MySQLDataTable.GetRelationName( table_name1, table_name2 );
			table1 = dataset.Tables[table_name1];
			table2 = dataset.Tables[table_name2];
			// this might be 'current_' + ... instead of just '...'
			table3 = dataset.Tables[rel1];
			current_table3 = dataset.Tables["current_" + rel1];

			InitializeComponent();

			dataGridViewMaster1.DataSource = table1;
			//dataGridViewMaster1.DisplayMember = xperdex.classes.XDataTable.Name( table1 );
			//dataGridViewMaster1.ValueMember = table1.Columns[0].ColumnName;

			dataGridViewMaster2.DataSource = table2;
			//listBoxSessions.DisplayMember = xperdex.classes.XDataTable.Name( table2 );
			//listBoxSessions.ValueMember = table2.Columns[0].ColumnName;

			dataGridViewRelation1.DataSource = table3;
			//listBoxSessionMacroSessions.DisplayMember = Names.Name( table3 );
			//listBoxSessionMacroSessions.ValueMember = table3.Columns[0].ColumnName;
		}

		public RelatedTableEditor( DataSet dataSet, String Table1, String Table2 )
		{
			SetupRelatedTableEditor(dataSet, Table1, Table2 );
		}

        private void SessionNewSelect(object sender, EventArgs e)
        {
			ListControl lb = sender as ListControl;
			DataTable dt = lb.DataSource as DataTable;
			ScheduleDataSet sd = ( dt.DataSet as ScheduleDataSet );
			if( lb.SelectedIndex >= 0 )
				sd.SetCurrentSession( sd.sessions.Rows[lb.SelectedIndex] );
            //UpdateCurrent();            
        }

        private void button3_Click(object sender, EventArgs e)
        {
			//SchedulerSessionEditor edit = new SchedulerSessionEditor();
            //edit.ShowDialog();
            //edit.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

		bool AddSelectionToAnotherTable( DataSet dataSet, ListControl l1, string t1
			, ListControl l2, string t2 )
		{
			DataTable table1 = dataSet.Tables[t1];
			DataTable table2 = dataSet.Tables[t2];
			String primary1 = table1.Columns[0].ColumnName;
			String primary2 = table2.Columns[0].ColumnName;
			DataTable rel1 = dataSet.Tables[xperdex.classes.MySQLDataTable.GetRelationName( table1, table2 )];

			DataRow drv = table1.Rows[l1.SelectedIndex];
			DataRow drv2 = table2.Rows[l2.SelectedIndex];
		
			DataRow[] rows = rel1.Select(
				table1.Columns[0].ColumnName + "=" + l1.SelectedValue
				+ " and "
				+ table2.Columns[0].ColumnName + "=" + l2.SelectedValue );

			if( rows.Length == 0 )
			{
				DataRow dr = rel1.NewRow();
				dr[primary1] = drv[primary1];
				dr[primary2] = drv2[primary2];

				try
				{
					rel1.Rows.Add( dr );
					rel1.AcceptChanges();
					return true;
				}
				catch( Exception e2 )
				{
					Log.log( e2.Message );
				}
			}
			return false;
		}

		private void listBox3_DoubleClick( object sender, EventArgs e )
		{
			//DeleteSelectionFromTable();
			ListBox list = (ListBox)sender;
			DataRowView drv = (DataRowView)list.SelectedItem;
			if( drv != null )
			{
				drv.Row.Delete(); // ? why is delete selectionfromtable ?
				//OpenSkieSchedule.data.DeleteSelectionFromTable( drv.Row );
			}
		}

		private void buttonNewMacro_Click( object sender, EventArgs e )
		{
			QueryNewName name = new QueryNewName( "Enter New Session Macro Name" );
			name.ShowDialog();
			if( name.DialogResult == DialogResult.OK )
			{

				DataRow row = table1.NewRow();
				row[xperdex.classes.XDataTable.Name( table1 )] = name.textBox1.Text;
				row.EndEdit();
				table1.Rows.Add( row );
				table1.AcceptChanges();
			}
		}

		private void buttonNewSession_Click( object sender, EventArgs e )
		{
			QueryNewName name = new QueryNewName( "Enter New Session Name" );
			name.ShowDialog();
			if( name.DialogResult == DialogResult.OK )
			{
				DataRow row = table2.NewRow();
				row[xperdex.classes.XDataTable.Name( table2 )] = name.textBox1.Text;
				row.EndEdit();
				table2.Rows.Add( row );
				table2.AcceptChanges();
				//OpenSkieSchedule.Save();
			}
		}

#if asdfasdf
		private void listBoxSessions_DoubleClick( object sender, EventArgs e )
		{
			if( AddSelectionToAnotherTable( this.listBoxSessionMacros, "session_macro_info"
				, this.listBoxSessions, "session_info" ) )
			{
				OpenSkieSchedule.data.Refresh( ScheduleDataSet.ScheduleChange.Session | ScheduleDataSet.ScheduleChange.SessionMacro );
			}

		}
#endif
    }
}