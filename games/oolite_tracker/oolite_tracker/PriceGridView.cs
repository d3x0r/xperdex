using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Data.Odbc;
using System.Text;
using System.Windows.Forms;

namespace oolite_tracker
{
    public partial class PriceGridView : DataGridView
    {
        SystemTablePivot basic_table_pivot;
        SystemTable basic_table;
        bool use_pivot = false;
        public PriceGridView()
        {
            InitializeComponent();
            //Local.SystemJump = SystemJump;
            this.RowHeadersWidth = 120;
            basic_table = (SystemTable)Local.grid.Tables["Systems"];
            basic_table.AcceptChanges();
            basic_table_pivot = (SystemTablePivot)(Local.grid.Tables["Systems_Pivot"]);
            if (!use_pivot)
            {
                basic_table = (SystemTable)Local.grid.Tables[0];
                this.DataSource = basic_table;
            }
            else
            {
                this.DataSource = basic_table_pivot;
            }
            // at this point, local should have already been loaded
            // should really be able to make first two rows not visible.
            // but we have not synced with the data source, so we cannot hide stuf..
            Local.gridView = this;
            this.ContextMenuStrip = contextMenuStrip1;
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }


        private void PriceGridView_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
        {
            //if( String.Compare( e.Column.Name, "system_id", true ) == 0 )
            //    this.Columns[0].Visible = false;
        }

        private void AllowAbortNewRow(object sender, DataGridViewDataErrorEventArgs e)
        {

            Console.WriteLine(e.Exception);
        }

        bool changing;
        private void PriceGridView_RowAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            if (!changing)
            {
                int n;
                changing = true;
                if (use_pivot)
                {
                    if (e.RowIndex > 0)
                    {
                        //this.Rows[0].Visible = false;
                    }
                    for (n = 0; n < e.RowCount; n++)
                        this.Rows[e.RowIndex + n].HeaderCell.Value =
                            basic_table_pivot.pivot_from.Columns[e.RowIndex + n].ColumnName;
                }
                else
                {
                    for (n = 0; n < e.RowCount; n++)
                        if (e.RowIndex + n < basic_table_pivot.Columns.Count)
                            this.Rows[e.RowIndex + n].HeaderCell.Value =
                                basic_table_pivot.Columns[e.RowIndex + n].ColumnName;
                }
                changing = false;
            }
        }

        void toolStripMenuItem2_Click(object sender, System.EventArgs e)
        {
            ToolStripMenuItem m = (ToolStripMenuItem)sender;
            SuspendLayout();
            if (m.Checked)
            {
                //changing = true;
                use_pivot = true;
                this.DataSource = basic_table_pivot;
                this.AllowUserToAddRows = false;
                //changing = false;
            }
            else
            {
                //changing = true;
                use_pivot = false;
                this.DataSource = basic_table;
                this.AllowUserToAddRows = true;
                //changing = false;
            }
            ResumeLayout();
        }
        void toolStripMenuItem1_Click(object sender, System.EventArgs e)
        {
            string name = (string)Local.grid.Tables["Systems"].Rows[this.CurrentCell.ColumnIndex][1];
            foreach (Oolite_System_Info x in Local.Systems)
                if (String.Compare(x.ToString(), name, true) == 0)
                {
                    if (!Local.Systems.Remove(x))
                        Console.WriteLine("Failed to find?!");
                    break;
                }
            Local.grid.Tables["Systems"].Rows[this.CurrentCell.ColumnIndex].Delete();
            Local.grid.Tables["Systems_Pivot"].Columns.Remove(Local.grid.Tables["Systems_Pivot"].Columns[this.CurrentCell.ColumnIndex]);
            Local.Save();
            //row new System.Exception("The method or operation is not implemented.");
            //this.Columns.Remove(this.Columns[this.CurrentCell.ColumnIndex]);
        }

		private void contextMenuStrip1_Opening_1( object sender, CancelEventArgs e )
		{

		}

    }

}


