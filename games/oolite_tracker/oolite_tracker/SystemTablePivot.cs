using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
namespace oolite_tracker
{
    public class SystemTablePivot : DataTable
    {

        public DataTable pivot_from;
        public SystemTablePivot(DataTable pivot_from)
        {
            this.pivot_from = pivot_from;
            this.TableName = "Systems_Pivot";
            pivot_from.RowChanged += new DataRowChangeEventHandler(pivot_from_RowChanged);
            //this.RowChanged += new DataRowChangeEventHandler(SystemTablePivot_RowChanged);
            this.ColumnChanged += new DataColumnChangeEventHandler(SystemTablePivot_ColumnChanged);

            SyncPivot(pivot_from);
        }
        bool updating;
        void SystemTablePivot_ColumnChanged(object sender, DataColumnChangeEventArgs e)
        {
            if (!updating)
                pivot_from.Rows[e.Column.Ordinal][e.Row.Table.Rows.IndexOf(e.Row)] = e.Row[e.Column.Ordinal];
            Local.Save();
            //pivot_from
            //throw new Exception("The method or operation is not implemented.");
        }

        void SyncPivot(DataTable pivot_from)
        {
            foreach (DataRow dr in pivot_from.Rows)
            {
                DataColumn dc = this.Columns.Add(dr[1].ToString()); // add a column of the system name.
                {
                    bool new_row = false;
                    int n;
                    DataRow row = null;
                    for (n = 0; n < pivot_from.Columns.Count; n++)
                    {
                        try
                        {
                            row = this.Rows[n];
                        }
                        catch (Exception e)
                        {
                            new_row = true;
                            row = this.NewRow();
                        }
                        row[dc.Ordinal] = dr[n];
                        if (new_row)
                        {
                            this.Rows.Add(row);
                            this.AcceptChanges();
                            new_row = false;
                        }
                    }
                }
            }
        }

        void pivot_from_RowChanged(object sender, DataRowChangeEventArgs e)
        {
            if (e.Row.RowState == DataRowState.Added)
            {
                DataColumn dc = null;
                updating = true;
                try
                {
                    dc = this.Columns[e.Row[1].ToString()];
                    if (dc == null)
                        dc = this.Columns.Add(e.Row[1].ToString()); // add a column of the system name.
                }
                catch (Exception e2)
                {
                    Console.WriteLine(e2);
                }
                int n_system = dc.Ordinal;
                //Console.WriteLine("Added a row..");

                bool new_row = false;
                int n;
                DataRow row = null;
                for (n = 0; n < pivot_from.Columns.Count; n++)
                {
                    if (n < Rows.Count)
                        row = this.Rows[n];
                    else
                    {
                        row = NewRow();
                        new_row = true;
                    }
                    // update pivot row data to each column in the row updated.
                    row[n_system] = e.Row[n];
                    if (new_row)
                    {
                        this.Rows.Add(row);
                        new_row = false;
                    }
                    this.AcceptChanges();
                }
                updating = false;

            }
            else
                Console.WriteLine("Did something");

        }
    }
}
