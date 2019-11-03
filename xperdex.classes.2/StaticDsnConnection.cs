using System;
using System.Data;
using System.Data.Common;
using System.Windows.Forms;
//using System.Windows.Forms;

namespace xperdex.classes
{
	/// <summary>
	/// Represents a connection to a DSN
	/// </summary>
	public static class StaticDsnConnection
	{
		static DsnConnection _dsn;
		public static DsnConnection dsn
		{
			get { return _dsn; }
            set { _dsn = value; }
		}
		/// <summary>
		/// Creates and opens a connection to the MySQL DSN.  Throws an exception if connection could not be open
		/// </summary>
		static StaticDsnConnection()
		{
			String attempting = null;
			try
			{
				_dsn = new DsnConnection(attempting = INI.Default[Options.ProgramName]["ODBC", "MySQL"]);
				_dsn.disable_logging = INI.Default[Options.ProgramName]["Static database connection logging disabled", 1].Bool;
			}
			catch (Exception exc)
			{
				if( _dsn == null )
				{
					MessageBox.Show( "Cannot open database ["+attempting+"].\n"
									+ "Database Connection Setting in...\n{" + INI.Default.file + "}\n[" + Options.ProgramName + "]\nODBC=" + attempting + "\n\n"
									+ exc.Message
									);
					throw new NullReferenceException( "Failed to connect to database", exc );
				}
			}
		}

		public static void ExecuteNonQuery( string s )
		{
			_dsn.ExecuteNonQuery( s );
		}
		public static bool KindExecuteNonQuery( string s )
		{
			return _dsn.KindExecuteNonQuery( s );
		}
		public static DbDataReader ExecuteReader( string s )
		{
			return _dsn.ExecuteReader( s );
		}
		public static long KindExecuteInsert( string s )
		{
			return _dsn.KindExecuteInsert( s );
		}
		public static DbDataReader KindExecuteReader( string s )
		{
			return _dsn.KindExecuteReader( s, 1 );
		}

		public static void EndReader( DbDataReader reader )
		{
			_dsn.EndReader( reader );
		}
		
		public static object ExecuteScalar(string s)
		{
			return _dsn.ExecuteScalar(s);
		}
		public static DataTable GetDataTableQuery(string s)
		{
			return _dsn.GetDataTableQuery(s);
		}
		public static DbDataReader RunQueryNonQuery(string[] NonQuery, string Query)
		{
			return _dsn.RunQueryNonQuery(NonQuery, Query);
		}
		

		public static ConnectionState State { get { return _dsn.State; } }
		public static long GetLastInsertID()
		{
			return _dsn.GetLastInsertID();
		}
	}
}
