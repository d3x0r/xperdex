using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Odbc;

namespace oolite_tracker
{
    public class Oolite_System_Info //System.Windows.Forms.DataGridViewTextBoxColumn
    {
        //public string Name;
        //public List<Commodity> commodities;
        //public string income;
        //public string population;
        //public string type;
        public DataRow data;
        public int system_id;
        public Oolite_System_Info(string s, DataRow row, bool add )
        {
            data = row;
            if (add)
            {
                data[1] = s;
                row.Table.Rows.Add(row);
                row.Table.AcceptChanges();
            }
#if asdfasdf
            if (Local.odbc.State == ConnectionState.Open)
            {
                if (data[0].GetType() != typeof(DBNull))
                {
                    // do an update on the name...
                    OdbcCommand c = new OdbcCommand("update `Oolite_Systems` set Name='" + s + "' where system_id=" + data[0]
                            , Local.odbc);
                    try
                    {
                        c.ExecuteNonQuery();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                    }
                }
                else
                {
                    // otherwise we need an ID from the database...
                    OdbcCommand c = new OdbcCommand("insert into `Oolite_Systems` (name) values('" + s + "')", Local.odbc);
                    try
                    {
                        c.ExecuteNonQuery();
                        c = new OdbcCommand("select last_insert_id()", Local.odbc);
                        OdbcDataReader r = c.ExecuteReader();
                        if (r.HasRows)
                        {
                            r.Read();
                            data[0] =
                                system_id = r.GetInt32(0);
                        }
                    }
                    catch (Exception e4)
                    {
                        try
                        {
                            c = new OdbcCommand("select system_id from `Oolite_Systems` where name='" + s + "'", Local.odbc);
                            OdbcDataReader r = c.ExecuteReader();
                            if (r.HasRows)
                            {
                                r.Read();
                                data[0] =
                                    system_id = r.GetInt32(0);
                            }
                        }
                        catch (Exception e5)
                        {
                        }

                    }
                }
            }
#endif
            Local.Save();
        }
        public Oolite_System_Info(string s, int ID, DataRow row)
        {
            data = row;
            data[1] = s;
            data[0] = ID;
            system_id = ID;
            if (row.RowState != DataRowState.Added)
            {
                row.Table.Rows.Add(row);
                row.Table.AcceptChanges();
            }
        }
        public override string ToString()
        {
            return data["Name"].ToString();
        }
        //UpdateCommodity( 
    }
}
