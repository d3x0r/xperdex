using System;
using System.Data;
using System.Data.OleDb;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Collections;     

namespace TreeSample
{
 
	public class DataAccess
	{
		public DataAccess()
		{
 
		}


        #region Commit To Database
        public static void CommitToDataBase(string connectionString,DataSet ds,string sql)
        {
   
           try
           {

              if (!ds.HasChanges()) { return; } 
     
			  using (OleDbConnection conn = new OleDbConnection())
			  {
 
				conn.ConnectionString = connectionString;
				conn.Open(); 
	 
				using(OleDbDataAdapter da = new OleDbDataAdapter(sql,conn))
				{
                    OleDbCommandBuilder  b = new OleDbCommandBuilder(da); 
                    da.Update(ds.Tables[0]); 
                    ds.AcceptChanges();
				}

			  }

            }
            catch (Exception) { throw; }

        }
        #endregion

        #region Get Data Set
        public static DataSet GetDataSet(string connectionString,string sql)
        {
   
           DataSet ds = new DataSet();

           try
           {
       
			  using (OleDbConnection conn = new OleDbConnection())
			  {
 
				conn.ConnectionString = connectionString;
				conn.Open(); 
				 
				using(OleDbDataAdapter da = new OleDbDataAdapter(sql,conn))
				{
                  
                    da.Fill(ds);  
                    
				}

			  }
            }
            catch (Exception) { throw; }
            return ds;
        }
        #endregion

	}
}
