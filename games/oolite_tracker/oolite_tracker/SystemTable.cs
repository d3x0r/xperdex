using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Drawing;
using System.Data.Odbc;

namespace oolite_tracker
{
    public class SystemTable : DataTable
    {
        public SystemTable()
        {
            //Local.grid = this;
            this.TableName = "Systems";
            //this.ContextMenuStrip = contextMenuStrip1;
            DataColumn dc = Columns.Add("system_id", typeof(int));
            dc.AutoIncrement = true;
            dc.AutoIncrementStep = 1;
            Columns.Add("Name", typeof(string));
            Columns.Add("Population", typeof(string));
            Columns.Add("Gross", typeof(string));
            Columns.Add("Type", typeof(string)); // combobox
            Columns.Add("Race Type", typeof(string)); // combobox
            Columns.Add("Race Species", typeof(string)); // combobox
            Columns.Add("Tech", typeof(string)); // combobox
			/*
            Columns.Add(new Commodity("Food", Color.Blue));
            Columns.Add(new Commodity("Textiles", Color.Blue));
            Columns.Add(new Commodity("Radioactives", Color.Blue));
            Columns.Add(new Commodity("Slaves", Color.Blue));
            Columns.Add(new Commodity("Liquor", Color.Blue));
            Columns.Add(new Commodity("Luxuries", Color.Blue));
            Columns.Add(new Commodity("Narcotics", Color.Blue));
            Columns.Add(new Commodity("Computers", Color.Blue));
            Columns.Add(new Commodity("Machinery", Color.Blue));
            Columns.Add(new Commodity("Alloys", Color.Blue));
            Columns.Add(new Commodity("Firearms", Color.Blue));
            Columns.Add(new Commodity("Furs", Color.Blue));
            Columns.Add(new Commodity("Minerals", Color.Blue));
            Columns.Add(new Commodity("Gold", Color.Blue));
            Columns.Add(new Commodity("Platinum", Color.Blue));
            Columns.Add(new Commodity("Gem_Stones", Color.Blue));
            Columns.Add(new Commodity("Alien_Items", Color.Blue));
			*/
            //bindingSource1.DataMember = "value";
            this.ColumnChanged += new DataColumnChangeEventHandler(basic_table_RowChanged);
        }

        static bool updating_row;
        void basic_table_RowChanged(object sender, DataColumnChangeEventArgs e)
        {
            if (!updating_row)
            {
                updating_row = true;
                if (!Local.loading_systems)
                {
                    //this.Columns[e.ColumnIndex]
                    if (e.Column.Ordinal == 1)
                    {
                        if (!Local.AddSystem((string)e.Row[1], e.Row))
                        {
                            if (Local.gridView != null)
                            {
                                int index = e.Row.Table.Rows.IndexOf(e.Row);
                                if (index >= 0)
                                    Local.gridView.Rows[index].Cells[1].Style.BackColor = Color.Red;
                                else
                                    Local.gridView.Rows[Local.gridView.Rows.Count - 2].Cells[1].Style.BackColor = Color.Red;
                            }
                        }
                        else
                        {
                            if (Local.gridView != null)
                            {
                                int index = e.Row.Table.Rows.IndexOf(e.Row);
                                if (index >= 0)
                                {
                                    Local.grid.Tables["Systems_Pivot"].Columns[index].ColumnName = (string)e.Row[e.Column.Ordinal];
                                    if (!Local.loading)
                                    {
                                        Local.gridView.Columns[index].HeaderText =
                                        Local.gridView.Columns[index].Name = (string)e.Row[e.Column.Ordinal];
                                    }
                                    //Local.gridView.Rows[index].Cells[1].Style.BackColor = Local.gridView.CurrentCell.Style.BackColor;
                                }
                            }
                        }
                        if (Local.gridView != null)
                        {
                            Local.gridView.Refresh();
                        }
                        updating_row = false;
                        return;
                    }
                    else if (e.Column.Ordinal < 6)
                    {
#if asdfasdf
                        //   basic_table.Rows[e.RowIndex][e.ColumnIndex] = s;
                        if (Local.odbc.State != ConnectionState.Closed)
                        {
                            if (e.Row[1].ToString().Length != 0)
                            {
                                OdbcCommand c = new OdbcCommand("Update Oolite_Systems set population='"
                                    + e.Row[2] + "',Gross='"
                                    + e.Row[3] + "',Type='"
                                    + e.Row[4] + "',Tech='"
                                    + e.Row[5] + "' where Name='"
                                    + e.Row[1] + "'"
                                    , Local.odbc);
                                try
                                {
                                    c.ExecuteNonQuery();
                                }
                                catch (Exception e2)
                                {
                                    Console.WriteLine(e2);
                                }
                            }
                        }
#endif
                    }
                    else
                    {
#if asdfasdf
                        try
                        {
                            if (Local.odbc.State != ConnectionState.Closed)
                            {
                                //Commodity c = (Commodity)basic_table.Rows[e.RowIndex][e.ColumnIndex];
                                OdbcCommand c = new OdbcCommand("Update Oolite_Systems set `"
                                    + e.Column.ColumnName + "`=" + e.Row[e.Column.Ordinal] + " where Name='"
                                    + e.Row[1] + "'"
                                    , Local.odbc);
                                try
                                {
                                    c.ExecuteNonQuery();
                                }
                                catch (Exception e3)
                                {
                                    Console.WriteLine(e3);
                                }
                            }

                            DataRow row = Local.grid.Tables["Price_History"].NewRow();
                            row[1] = e.Row[0];
                            row[2] = e.Column.ColumnName;
                            row[3] = DateTime.Now;
                            row[4] = e.Row[e.Column.Ordinal]; ;
                            Local.grid.Tables["Price_History"].Rows.Add(row);
                            Local.grid.Tables["Price_History"].AcceptChanges();
                            if (Local.odbc.State != ConnectionState.Closed)
                            {
                                OdbcCommand c = new OdbcCommand("insert into Oolite_Price_History (system_id,Commodity_name,price,time) values("
                                    + e.Row[0]
                                    + ",'" + e.Column.ColumnName
                                    + "','" + e.Row[e.Column.Ordinal]
                                    + "',now())"
                                    , Local.odbc);
                                try
                                {
                                    c.ExecuteNonQuery();
                                }
                                catch (Exception e3)
                                {
                                    Console.WriteLine(e3);
                                }
                            }
                        }
                        catch (Exception e2)
                        {
                            Console.WriteLine(e2);
                        }
#endif
                    }
                    Local.Save();
                }
                // else loading_systems, no readson for updates to database...
            }
            updating_row = false;
            //throw new Exception("The method or operation is not implemented.");
        }

        public void Load()
        {
#if asdfasdf
            if (Local.odbc.State != ConnectionState.Closed)
            {
                OdbcCommand c = new OdbcCommand("select system_id,name,Population,Gross,Type from Oolite_Systems", Local.odbc);
                try
                {
                    OdbcDataReader r = c.ExecuteReader();

                    while (r.Read())
                    {
                        Oolite_System_Info osi = Local.AddSystem(r.GetInt32(0), r.GetString(1));
                        osi.data[2] = r.GetString(2);
                        osi.data[3] = r.GetString(3);
                        osi.data[4] = r.GetString(4);

                        //?select max(time),Commodity_Name from Oolite_Price_History  group by Commodity_Name
                        //select * from Oolite_Price_History where time in (select max(time) from Oolite_Price_History  group by Commodity_Name )

                        OdbcCommand c2 = new OdbcCommand("select Commodity_Name,price from Oolite_Price_History where time in (select max(time) from Oolite_Price_History where system_id="
                            + osi.data[0]
                            + " group by Commodity_Name )"
                            , Local.odbc);
                        try
                        {

                            OdbcDataReader r2 = c2.ExecuteReader();
                            while (r2.Read())
                            {
                                osi.data[r2.GetString(0)] = r2.GetDouble(1);
                            }
                        }
                        catch (Exception e2)
                        {
                            Console.WriteLine(e2);
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
#endif
        }
    }
}
