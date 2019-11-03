using System.Data;
using System.Data.Common;

namespace xperdex.classes
{
	/// <summary>
	/// Represents a connection to a DSN
	/// </summary>
	public static class StaticRegDsnConnection
	{
		static DsnConnection _dsn;
		public static DsnConnection dsn
		{
			get { return _dsn; }
		}
		/// <summary>
		/// Creates and opens a connection to the MySQL DSN.  
		/// 1.) Search DSN connection in Settings/CTK.ini file... 
		/// 2.) if doesn't find it, search C:\\WINDOWS\\win.ini [FORTUNET], SYSTEM PATH = [file with general settings]
		/// and then get the DSN Connection from [file with general settings]
		/// Throws an exception if connection could not be open
		/// </summary>
		static StaticRegDsnConnection()
		{
			InitializeStaticRegDsnConnection();
		}

		private static void InitializeStaticRegDsnConnection()
		{
			// read from the default file (ftnsys.ini)
			_dsn = new DsnConnection( INI.Default["Static Reg DSN ODBC"]["DSN","MySQL"] );
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
			return _dsn.KindExecuteReader( s );
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
			return _dsn.RunQueryNonQuery(NonQuery,Query);
		}
		
		public static ConnectionState State { get { return _dsn.State; } }

		public static void CloseConnection()
		{
			_dsn.CloseConnection();
		}

		public static long GetLastInsertID()
		{
			return _dsn.GetLastInsertID();
		}

	}
}
