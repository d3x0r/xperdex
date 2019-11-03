using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Odbc;
using System.Data.SqlClient;

namespace oolite_tracker
{
    public class PriceDataSet:DataSet
    {
        public void CreateDataTable(DataTable dt)
        {
#if asdfasdf
            if (Local.odbc.State != ConnectionState.Closed)
            {
                string columns = null;
                bool first = true;
                string sql_quote = "`";
                bool mysql = true;
                bool delete = false;
                if (delete)
                {
                    OdbcCommand c = new OdbcCommand("Drop table if exists " + sql_quote + "Oolite_" + dt.TableName + sql_quote
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
                foreach (DataColumn col in dt.Columns)
                {
                    columns += (first ? "" : ",") + "" + sql_quote + "" + col.ColumnName + "" + sql_quote + " "
                        + ((col.DataType == typeof(string))
                        ? "varchar(100) not NULL default ''"
                        : (col.DataType == typeof(double))
                        ? "double not NULL default 0.0"
                        : (col.DataType == typeof(Commodity))
                        ? "double not NULL default 0.0"
                        : (col.DataType == typeof(DateTime))
                        ? "datetime NOT NULL default '00-00-00 00:00:00'"
                        : ((col.Ordinal == 0) ? "int(11) auto_increment" : "int(11) NOT NULL default '0'")
                        );
                    first = false;
                }
                columns += (first ? "" : ",") + "PRIMARY KEY (" + sql_quote + "" + dt.Columns[0].ColumnName + "" + sql_quote + ")";

                string create = "create table " + (mysql ? "if not exists " : "") + sql_quote + "Oolite_" + dt.TableName + "" + sql_quote + "(" + columns + ")";
                {
                    OdbcCommand c = new OdbcCommand(create, Local.odbc);
                    try
                    {

                        c.ExecuteNonQuery();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                    }
                }
            }
#endif
            Tables.Add(dt);
        }

        public PriceDataSet()
        {
            //this.
            
                      
        }
        public void AddCommodityTable( DataTable dt )
        {
            Tables.Add( dt );
        }
        public void Load()
        {

        }
    }
}
