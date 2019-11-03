using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Drawing;
using System.Data;
using System.Drawing.Imaging;
using System.Windows.Forms;
using System.Data.Odbc;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Xml;
namespace oolite_tracker
{
    public static class Local
    {
        public static SystemSelect SystemJump;
        public static PriceDataSet grid; // erm...
        public static List<Oolite_System_Info> Systems;
        public static List<Commodity> commodities; // blank templates for commodities.
        //public static OdbcConnection odbc;
        public static PriceGridView gridView;
        static Local()
        {
            try
            {
                //odbc = new SqlConnection( "Data Source=D3X0R-PC\\SQLEXPRESS;Initial Catalog=test;Integrated Security=True;Pooling=False" );
                //odbc = new OdbcConnection( "Dsn=asdflocal" );
                //odbc.Open();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            //IAsyncResult emps = sqlcmd.BeginExecuteNonQuery(QueryCallbackMethod, null);

            // need systems before we have a grid.... 
            Systems = new List<Oolite_System_Info>();
            commodities = new List<Commodity>();

            grid = new PriceDataSet();

            grid.CreateDataTable(new SystemTable());
            grid.CreateDataTable(new PriceHistoryTable());
			grid.CreateDataTable( new CommodityTable() );
            grid.CreateDataTable(new SystemTablePivot( grid.Tables["Systems"]));

            Load();
        }
        public static bool loading;
        public static bool loading_systems;
        static bool loaded;
        public static void Load()
        {
            loading = true;
            FileStream fs = null;
            try
            {
                loading_systems = true;
                fs = new FileStream("oolite_tracker.dat", FileMode.Open);
                grid.Tables["Systems"].ReadXml( fs );
                fs.Close();
                loading_systems = false;
            }
            catch (Exception e)
            {
                if (fs != null)
                    fs.Close();
                loading_systems = false;

                AddSystem("Lave");
                Console.WriteLine(e);
                // probably failed open.
            }
            try
            {
                fs = new FileStream("oolite_tracker.dat2", FileMode.Open);
                grid.Tables["Price_History"].ReadXml(fs);
                fs.Close();
            }
            catch (Exception e)
            {
                if (fs != null)
                    fs.Close();
                loading_systems = false;

                //AddSystem("Lave");
                Console.WriteLine(e);
                // probably failed open.
            }
            loaded = true;
            loading = false;
        }
        public static void Save()
        {
            if (loading || !loaded)
                return;
            FileStream fs = null;
            try
            {
                fs = new FileStream("oolite_tracker.dat", FileMode.Create);
                grid.Tables["Systems"].WriteXml(fs);
                fs.Close();
                fs = new FileStream("oolite_tracker.dat2", FileMode.Create);
                grid.Tables["Price_History"].WriteXml(fs);
                fs.Close();
            }
            catch (Exception e)
            {
                if (fs != null)
                    fs.Close();
                Console.WriteLine(e);
            }
        }
        static bool something(Oolite_System_Info s)
        {
            return false;
        }
        public static Oolite_System_Info AddSystem(string s)
        {
            Oolite_System_Info info = null;
            foreach (Oolite_System_Info x in Systems)
                if (String.Compare(x.ToString(), s, true) == 0)
                {
                    info = x;
                    break;
                }

            if (info == null)
            {
                try
                {
                    info = new Oolite_System_Info(s, grid.Tables["Systems"].NewRow(), true);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
                //Save();
            }
            return info;
        }
		public static Commodity AddCommodity( string s )
		{
			Commodity info = null;
			foreach( Commodity x in commodities )
				if( String.Compare( x.ToString(), s, true ) == 0 )
				{
					info = x;
					break;
				}

			if( info == null )
			{
				try
				{
					info = new Commodity( s, Color.Black );
					grid.Tables["Systems"].Columns.Add( info );
				}
				catch( Exception e )
				{
					Console.WriteLine( e );
				}
				//Save();
			}
			return info;
		}
		public static Oolite_System_Info AddSystem( int ID, string s )
        {
            Oolite_System_Info info = null;
            foreach (Oolite_System_Info x in Systems)
            {
                Console.WriteLine(x.ToString());
                if (String.Compare(x.ToString(), s, true) == 0)
                {
                    info = x;
                    break;
                }
            }
            if (info == null)
            {
                try
                {
                    info = new Oolite_System_Info(s, ID, grid.Tables["Systems"].NewRow());
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
                //Save();
            }
            return info;
        }
        public static bool AddSystem(string s, DataRow row )
        {
            Oolite_System_Info info = null;
                foreach (Oolite_System_Info x in Systems)
                    if (String.Compare(x.ToString(), s, true) == 0 )
                    {
                        if ((x.data != row))
                        {
							{
                                // // row.RejectChanges(); casues application fault.
                                row[1] = DBNull.Value;
                                row[0] = DBNull.Value;
                                //--- these don't work either... 
                                //row.Table.AcceptChanges();
                                //row.Delete();
                                ////row.RowState = DataRowState.Deleted;
                                //row.Table.AcceptChanges();

                                //--- thrown an exception is not caught nicely by top level (middle)
                                ////throw new Exception("Abort NewRow()");
                                ////row.AcceptChanges();
                            }
                            return false;
                        }
                        else
                            info = x;
                        //else fall through - and rename will happen ...
                        // allowed to change this name...
                    }

                if (info == null)
                {
                    try
                    {
                        Systems.Add(info = new Oolite_System_Info(s, row, false));
                        return true;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                    }
                    //Save();
                }
            return true;
        }
    }
}
