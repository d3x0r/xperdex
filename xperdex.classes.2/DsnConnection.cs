//#define try_to_find_leftover_reader
#define use_sqlite_connector
#define use_odbc_connector
//#define use_mysql_net_connector
#define use_sql_server_connector

using System;
using System.Data;
using System.Data.Odbc;
using System.Globalization;
#if use_mysql_net_connector
using MySql;
using MySql.Data.MySqlClient;
#endif
#if use_sqlite_connector
using System.Data.SQLite;
#endif
using System.Data.SqlClient;
using System.Data.Common;
using System.Text;
using System.Threading;
using System.ComponentModel;
using System.IO;
using System.Collections.Generic;

namespace xperdex.classes
{
	/// <summary>
	/// Represents a connection to a DSN
	/// </summary>
	public class DsnConnection : IDisposable
	{
		public bool AllowFallback;
		public ConnectionMode DesiredMode = (ConnectionMode)INI.Default[Options.ProgramName]["Database Connection Preferred Provider:" 
			+ (int)ConnectionMode.MySqlNative + ") MySQL .NET"
			+ ";" + (int)ConnectionMode.Odbc + ") ODBC"
			+ ";" + (int)ConnectionMode.Sqlite + ") Sqlite Provider"
			+ ";" + (int)ConnectionMode.AccessMDB + ") ODBC (Access DB)"
			+ ";" + (int)ConnectionMode.SQLServer + ") MSSQL Client"
			, (int)ConnectionMode.Odbc].Integer;
		public ConnectionMode FallbackMode = ConnectionMode.Unknown;

		/// <summary>
		/// MySQLDataTables add themselves here... allowing me to call 
		/// a method in them to handle posting database fallback modes...
		/// </summary>
		//List<DataTable> datatables;
		//List<DataSet> datasets;

#if try_to_find_leftover_reader
		string last_command;
		string _last_command;
		public bool _disable_logging;
		public bool disable_logging
		{
			get { return _disable_logging;  }

			set
			{
#if !try_to_find_leftover_reader
				_disable_logging = value;
#endif
			}
		}
#else
		string _log_filename;
		FileStream log_filestream;
		StreamWriter log_writer;
		public string log_filename
		{
			set
			{								
				_log_filename = value;
				if( log_filestream != null )
					log_filestream.Close();
				log_filestream = new FileStream( _log_filename, FileMode.OpenOrCreate );
				log_filestream.SetLength( 0 );
				log_writer = new StreamWriter( log_filestream );
			}
		}
		public bool disable_logging;
#endif

        /// <summary>
        /// Internal string that contains the last statement's exception message.
        /// </summary>
        string last_error;

		/// <summary>
		/// this is the DSN String passed in... 
		/// </summary>
		string _dsnConnection;

		/// <summary>
		/// Opening quote around values.  Is invalid until the db mode is set.
		/// </summary>
 
		public string sql_value_quote_open;
		/// <summary>
		/// Closing quote around values.  Is invalid until the db mode is set.
		/// </summary>
		public string sql_value_quote_close;
		/// <summary>
		/// Opening quote around column and table names.  Is invalid until the db mode is set.
		/// </summary>
		public string sql_quote_open;
		/// <summary>
		/// Closing quote around column and table names.  Is invalid until the db mode is set.
		/// </summary>
		public string sql_quote_close;
#if use_mysql_net_connector
		private MySqlConnection _myConn;
#endif
#if use_sqlite_connector
      	private SQLiteConnection _sqliteConn;
#endif
		public DbConnection oConn
		{
			get { return _Connection; }
		}

#if use_odbc_connector
		public OdbcConnection odbcConn
		{
	    	get { return _oConn; }
		}
		private OdbcConnection _oConn;
#endif
#if use_sql_server_connector
		public SqlConnection sqlServerConn
		{
			get { return _sConn; }
		}
		private SqlConnection _sConn;
#endif

		private DbConnection _Connection;

		public String DataSource
		{
			get
			{
				return _dsnConnection;
			}
		}

		List<Exception> connectionFailures = new List<Exception>();
		// can use the more general purpose command usually...
		//DbCommand _oComm;

		/// <summary>
		/// Unknown is used for desired mode.... it 
		/// Otherwise desired mode controls what primary mode is
		/// Fallbackmode determines what mode is preferred as backup.
		/// </summary>
		public enum ConnectionMode
		{
			Unknown, 
			MySqlNative	,
			Odbc	 , 
			AccessMDB ,
			SQLServer,
			Sqlite,
			NativeDataTable
		}
		/// <summary>
		/// ODBC Can be a lot of providers, this provides a 'flavor' mechanism to subdetail how the connection should be treated.
		/// </summary>
		public enum ConnectionFlavor
		{
			Unknown,
			MySqlNative,
			Odbc,
			AccessMDB,
			SQLServer,
			Sqlite
		}

		ConnectionMode _Mode;
		ConnectionFlavor _Flavor;

		public ConnectionMode DbMode
		{
			get
			{
				return _Mode;
			}
		}

		public ConnectionFlavor DbFlavor
		{
			get
			{
				return _Flavor;
			}
		}

		public int DbVersion;

		internal ConnectionMode Mode
		{
			set
			{
				switch( value )
				{
				case ConnectionMode.SQLServer:
					sql_quote_open = "[";
					sql_quote_close = "]";
					sql_value_quote_open = "'";
					sql_value_quote_close = "'";
					break;
				case ConnectionMode.AccessMDB:
					sql_quote_open = "[";
					sql_quote_close = "]";
					sql_value_quote_open = "'";
					sql_value_quote_close = "'";
					break;
				case ConnectionMode.Odbc:
					switch( _Flavor )
					{
					case ConnectionFlavor.SQLServer:
						sql_quote_open = "[";
						sql_quote_close = "]";
						sql_value_quote_open = "'";
						sql_value_quote_close = "'";
						break;
					case ConnectionFlavor.AccessMDB:
						sql_quote_open = "[";
						sql_quote_close = "]";
						sql_value_quote_open = "'";
						sql_value_quote_close = "'";
						break;
					default:
						sql_quote_open = "`";
						sql_quote_close = "`";
						sql_value_quote_open = "'";
						sql_value_quote_close = "'";
						break;
					}
					break;
				default:
					sql_quote_open = "`";
					sql_quote_close = "`";
					sql_value_quote_open = "'";
					sql_value_quote_close = "'";
					break;
				}
				_Mode = value;
			}
		}

#if use_sqlite_connector
		/*
		[SQLiteFunction( Arguments = 0, FuncType = FunctionType.Scalar, Name = "isnull" )]
		public class SQLITE_IsNull : SQLiteFunction
		{
			public SQLITE_IsNull()
			{
				int a = 0;
			}
			public override object Invoke( object[] args )
			{
				if( args[0] == DBNull.Value )
					return true;
				return false;
			}


		}
		*/

		[SQLiteFunction( Arguments = 0, FuncType = FunctionType.Scalar, Name = "now" )]
		public class SQLITE_Now : SQLiteFunction
		{
			public SQLITE_Now()
			{
			}
			public override object Invoke( object[] args )
			{
				return DateTime.Now;
			}


		}

		[SQLiteFunction( Arguments = 3, FuncType = FunctionType.Scalar, Name = "if" )]
		public class SQLITE_If : SQLiteFunction
		{
			public SQLITE_If()
			{
				//int a = 0;
			}
			public override object Invoke( object[] args )
			{
				if( Convert.ToBoolean( args[0] ) )
					return args[1];
				return args[2];
			}
		}
#endif

		bool OpenConnectionType( ConnectionMode OpenMode )
		{
			switch( OpenMode )
			{
			case ConnectionMode.SQLServer:
				if( _sConn == null )
					_sConn = new SqlConnection( _dsnConnection );
				if( _sConn.State == ConnectionState.Open )
					return true;
				try
				{
					_sConn.Open();
					_Flavor = ConnectionFlavor.SQLServer;
					Mode = ConnectionMode.SQLServer;
					if( _sConn.State == ConnectionState.Open )
						_Connection = _sConn;
                }
				catch( Exception e )
				{
					connectionFailures.Add( e );
				}
				return _sConn.State == ConnectionState.Open;
#if use_odbc_connector
			case ConnectionMode.Odbc:

				if( _oConn == null )
					_oConn = new OdbcConnection();
				if( _oConn.State == ConnectionState.Open )
					return true;
				if ( String.Compare( _dsnConnection, 0, "DSN=", 0, 4 ) == 0 )
					_oConn.ConnectionString = _dsnConnection;
				else
					_oConn.ConnectionString = "DSN=" + _dsnConnection;
				try
				{
					_oConn.Open();
					if( _oConn.Driver.Contains( "myodbc" ) )
					{
						_Flavor = ConnectionFlavor.MySqlNative;
					}
					if( _oConn.Driver.Contains( "SQLSRV" ) )
					{
						_Flavor = ConnectionFlavor.SQLServer;
					}
					Mode = ConnectionMode.Odbc;
					if( _oConn.State == ConnectionState.Open )
						_Connection = _oConn;
                }
				catch( Exception e )
				{
					connectionFailures.Add( e );
				}
				return _oConn.State == ConnectionState.Open;
#endif
#if use_mysql_net_connector
            case ConnectionMode.MySqlNative:
                if (_myConn == null)
                    _myConn = new MySql.Data.MySqlClient.MySqlConnection();
				if( _myConn.State == ConnectionState.Open )
					return true;
				try
				{
					_myConn.ConnectionString = _dsnConnection;
					_myConn.Open();
					Mode = ConnectionMode.MySqlNative;
					_Connection = _myConn;
					_Connection = _myConn;
					return _myConn.State == ConnectionState.Open;
				}
				catch( Exception e )
				{
					Log.log( e.Message );
				}
				
                break;
#endif
#if use_odbc_connector
			case ConnectionMode.AccessMDB:
				if( _oConn == null )
					_oConn = new OdbcConnection();
				if( _oConn.State == ConnectionState.Open )
					return true;
				_oConn.ConnectionString = "DRIVER=Microsoft Access Driver (*.mdb); UID=admin; UserCommitSync=Yes; Threads=3; SafeTransactions=0; PageTimeout=5; MaxScanRows=8; MaxBufferSize=2048; FIL=MS Access; DriverId=25; DefaultDir=.; DBQ=" + _dsnConnection + "; ";
				try
				{
					_oConn.Open();
					if ( _oConn.State == ConnectionState.Open )
						_Connection = _oConn;
					Mode = ConnectionMode.AccessMDB;
					return _oConn.State == ConnectionState.Open;
				}
				catch( Exception e )
				{
					connectionFailures.Add( e );
				}
				break;
#endif
#if use_sqlite_connector
			case ConnectionMode.Sqlite:
				if( _sqliteConn == null )
				{
					try
					{
						_sqliteConn = new SQLiteConnection( "Database=xperdex;Data Source=" + _dsnConnection );
					}
					catch( Exception e )
					{
						connectionFailures.Add( e );
					}
				}
				if( _sqliteConn == null )
					return false;
				if( _sqliteConn.State == ConnectionState.Closed )
				{
					try
					{
						_sqliteConn.Open();
                        if( _sqliteConn.State == ConnectionState.Open )
                            _Connection = _sqliteConn;
                        Mode = ConnectionMode.Sqlite;
					}
					catch( Exception e )
					{
						connectionFailures.Add( e );
					}
					return _sqliteConn.State == ConnectionState.Open;
				}
				if( _sqliteConn.State == ConnectionState.Open )
					return true;

				break;
#endif
			}
			return false;
		}

		bool Reconnect;
		/// <summary>
		/// Opens the connection.
		/// </summary>
		/// 


		private void OpenConnection( int frame_skip )
		{
			bool connected = false;

			if( _Connection != null && _Connection.State == ConnectionState.Open )
			{
				// active connection IS Open.
				return;
			}

			if( Reconnect && _Mode != ConnectionMode.Unknown )
				connected = OpenConnectionType( _Mode );

			if( _dsnConnection.Contains( ".db" ) )
				DesiredMode = ConnectionMode.Sqlite;

			if( ( _dsnConnection.Contains( "DSN=" ) && DesiredMode == ConnectionMode.Odbc )
				 || DesiredMode != ConnectionMode.Odbc )
				connected = OpenConnectionType( DesiredMode );

#if use_odbc_connector
			if( !connected )
			{
				if( _Mode == ConnectionMode.Unknown || _Mode == ConnectionMode.Odbc )
					connected = OpenConnectionType( ConnectionMode.Odbc );
			}
			if( !connected )
			{
				if( _Mode == ConnectionMode.Unknown || _Mode == ConnectionMode.AccessMDB )
					connected = OpenConnectionType( ConnectionMode.AccessMDB );
			}
#endif
#if use_sql_server_connector
			if( !connected )
			{
				if( _Mode == ConnectionMode.Unknown || _Mode == ConnectionMode.SQLServer )
					connected = OpenConnectionType( ConnectionMode.SQLServer );
			}
#endif
#if use_mysql_net_connector
			if( !connected )
			{
				if( _Mode == ConnectionMode.Unknown || _Mode == ConnectionMode.MySqlNative )
					connected = OpenConnectionType( ConnectionMode.MySqlNative );
			}
#endif
#if use_sqlite_connector
			if( !connected )
			{
				if( _Mode == ConnectionMode.Unknown || _Mode == ConnectionMode.Sqlite )
				{
					connected = OpenConnectionType( ConnectionMode.Sqlite );
					// this is for testing the Sqlite functions which we baked in
					//this.KindExecuteReader( "select now()" );
					//this.KindExecuteReader( "select 1,NULL isnull()" );
					//this.KindExecuteReader( "select if(NULL isnull,1,2)" );
				}
			}
#endif
			if( !connected || _Connection == null )
			{
				String Message = "Database connection failed permanently\n\n";
				foreach( Exception e in connectionFailures )
				{
					Message += e.Message + "\n\n";
				};
				connectionFailures.Clear();
				throw new Exception( Message );
			}
		}


		private void OpenConnection()
		{
			OpenConnection( 1 );
		}
		/// <summary>
		/// Close Actual Connection
		/// </summary>
		public void CloseConnection()
		{
			if( _Connection != null )
				_Connection.Close();
		}


		/// <summary>
		/// Close Actual Connection
		/// </summary>
		public void DisposeConnection()
		{
#if use_odbc_connector
			if( DbMode == ConnectionMode.Odbc )
				_oConn.Dispose();
#endif
#if use_mysql_net_connector
            if (DbMode == ConnectionMode.MySqlNative)
                _myConn.Dispose();
#endif
#if use_sql_server_connector
			if( DbMode == ConnectionMode.SQLServer )
				_sConn.Dispose();
#endif
#if use_sqlite_connector
			if( DbMode == ConnectionMode.Sqlite )
				_sqliteConn.Dispose();
#endif

		}

		/// <summary>
		/// Get Connection Status
		/// </summary>
		public string GetStatusConnection()
		{
			return _Connection.ConnectionString + ": " + _Connection.State.ToString();
		}

		void OpenDSNConnection( string stuff, int frame_skip )
		{
			_dsnConnection = stuff;
			OpenConnection( 1+frame_skip );
		}
		void OpenDSNConnection( string stuff )
		{
			OpenDSNConnection( stuff, 1 );
		}
		/// <summary>
		/// Creates and opens a connection to the MySQL DSN.  Throws an exception if connection could not be open
		/// </summary>
		public DsnConnection()
		{
			OpenDSNConnection("MySQL",1);
		}
		/// <summary>
		/// Creates and opens a connection to a DSN.  Throws an exception if connection could not be open
		/// </summary>
		/// <param name="dsn">Name of the DSN</param>
		public DsnConnection(String dsn)
		{
			OpenDSNConnection( dsn, 1 );
		}

		/// <summary>
		/// Creates and opens a connection to a custom server.  Throws an exception if connection could not be open
		/// </summary>
		/// <param name="server">Server address</param>
		/// <param name="port">Server port</param>
		/// <param name="database">Database name</param>
		public DsnConnection(String server, String port, String database, String user, String password )
		{
			_dsnConnection = //"DRIVER={MySQL ODBC 3.51 Driver}; " +
					"SERVER=" + server + "; " +
					"PORT=" + port + "; " +
					"DATABASE=" + database + "; " +
					"USER= " + user + 
					";PASSWORD= " + password +
					";OPTION=3";
			OpenConnection();
		}

		/// <summary>
		/// A general utility for embedding escapes as required by string insertiaon to handle embeeded ' characters.
		/// </summary>
		/// <param name="blob">This is a string</param>
		/// <returns>a string appropriately escaped</returns>
		public static string Escape( DsnConnection.ConnectionMode DbMode, DsnConnection.ConnectionFlavor DbFlavor, string blob )
		{

			if( DbMode == DsnConnection.ConnectionMode.AccessMDB )
				return blob;

			if( ( DbMode == DsnConnection.ConnectionMode.NativeDataTable )
				|| ( DbMode == ConnectionMode.SQLServer ) )
			{
				int n = 0;
				int targetlen = 0;
				while( n < blob.Length )
				{
					if( blob[n] == '\'' )
						targetlen++;
					n++;
				}

				char[] output = new char[n + targetlen];
				n = 0;

				//result = tmpnamebuf = (TEXTSTR)AllocateEx( targetlen + bloblen + 1 DBG_RELAY );

				int offset = 0;
				while( n < blob.Length )
				{
					if( blob[n] == '\'' )
						output[offset++] = '\'';
					output[offset++] = blob[n];
					n++;
				}
				return new string( output );
			}
			else if( DbMode == DsnConnection.ConnectionMode.Odbc ||
				DbMode == DsnConnection.ConnectionMode.MySqlNative )
			{
				if( DbFlavor == ConnectionFlavor.SQLServer )
				{
					int n = 0;
					int targetlen = 0;
					while( n < blob.Length )
					{
						if( blob[n] == '\'' )
							targetlen++;

						n++;
					}
					char[] output = new char[n + targetlen];
					n = 0;

					//result = tmpnamebuf = (TEXTSTR)AllocateEx( targetlen + bloblen + 1 DBG_RELAY );

					int offset = 0;
					while( n < blob.Length )
					{
						if( blob[n] == '\'' )
							output[offset++] = '\'';

						output[offset++] = blob[n];
						n++;
					}
					return new string( output );
				}
				else
				{
					int n = 0;
					int targetlen = 0;
					while( n < blob.Length )
					{
						if( blob[n] == '\'' ||
							blob[n] == '\\' ||
							blob[n] == '\0' ||
							blob[n] == '\"' )
							targetlen++;
						n++;
					}

					char[] output = new char[n + targetlen];
					n = 0;

					//result = tmpnamebuf = (TEXTSTR)AllocateEx( targetlen + bloblen + 1 DBG_RELAY );

					int offset = 0;
					while( n < blob.Length )
					{
						if( blob[n] == '\'' ||
							blob[n] == '\\' ||
							blob[n] == '\0' ||
							blob[n] == '\"' )
							output[offset++] = '\\';
						if( blob[n] != 0 )
							output[offset++] = blob[n];
						else
							output[offset++] = '0';
						n++;
					}
					return new string( output );
				}
			}
			else if( DbMode == DsnConnection.ConnectionMode.Sqlite )
			{
				int n = 0;
				int targetlen = 0;
				while( n < blob.Length )
				{
					if( blob[n] == '\'' ||
						blob[n] == '\0' )
						targetlen++;
					n++;
				}

				char[] output = new char[n + targetlen];
				n = 0;

				//result = tmpnamebuf = (TEXTSTR)AllocateEx( targetlen + bloblen + 1 DBG_RELAY );

				int offset = 0;
				while( n < blob.Length )
				{
					if( blob[n] == 0 )
						output[offset++] = '\\';
					if( blob[n] == '\'' )
						output[offset++] = '\'';
					if( blob[n] != 0 )
						output[offset++] = blob[n];
					else
						output[offset++] = '0';
					n++;
				}
				return new string( output );
				// encode strings differently for sql..
			}
			return "BAD CONVERSION";
		}

		public string Escape( string blob )
		{
			return DsnConnection.Escape( DbMode, DbFlavor, blob );
		}

		private void CheckDesiredMode()
		{
			if( AllowFallback )
			{
				if( _Mode != DesiredMode )
				{
					Log.log( "Need to attempt reconnect here." );
				}
			}
		}

		private int MyNonQuery(DbCommand _oComm)
		{
			try
			{											
#if try_to_find_leftover_reader
				_last_command = last_command;
				last_command = _oComm.CommandText;
#endif
				return _oComm.ExecuteNonQuery();
			}
			catch( Exception e )
			{
				if( HandleReconnect( e ) )
				{
					try
					{
						return _oComm.ExecuteNonQuery();
					}
					catch( Exception e2 )
					{
						last_error = e2.Message;
						return -1;
					}
				}
				last_error = e.Message;
				throw e;
			}
		}


		/// <summary>
		/// Executes a query that returns no result
		/// </summary>
		/// <param name="sql">SQL statement</param>
		/// <param name="parameterObjects">Parameters for the query</param>
		public int ExecuteNonQuery( String sql, int skip, params Object[] parameterObjects )
		{
			if( _Connection.State != ConnectionState.Open )
				OpenConnection(); 
			DbCommand _oComm;
			switch( DbMode )
			{
#if use_sqlite_connector
			case ConnectionMode.Sqlite:
				_oComm = new SQLiteCommand( sql, _sqliteConn );
				break;
#endif
#if use_sql_server_connector
			case ConnectionMode.SQLServer:
				_oComm = new SqlCommand( sql, _sConn );
				break;
#endif
			default:
#if use_odbc_connector
			case ConnectionMode.Odbc:
				_oComm = new OdbcCommand( sql, _oConn );
				break;
#endif
#if use_mysql_net_connector
			case ConnectionMode.MySqlNative:
				_oComm = new MySqlCommand( sql, _myConn );
				break;
#endif
			}
			if (parameterObjects != null)
			{
				foreach (Object parameter in parameterObjects)
				{
					_oComm.Parameters.Add( parameter );
				}
			}
			//if( String.Compare( "delete", 0, _oComm.CommandText, 0, 6, false ) == 0 )
			{
			//	Log.log( "Delete something..." );
			}

			if( log_writer != null )
			{
				log_writer.Write( _oComm.CommandText );
				log_writer.WriteLine( ';' );
				log_writer.Flush();
			}

			if( !disable_logging )
				Log.log( "SQL Command[" + _dsnConnection + "]: " + _oComm.CommandText, 1 + skip );
			return MyNonQuery( _oComm );
		}
		public int ExecuteNonQuery( String sql, params Object[] parameterObjects )
		{
			return ExecuteNonQuery( sql, 1, parameterObjects );
		}
		/// <summary>
		/// Executes a query that returns no result
		/// </summary>
		/// <param name="sql">SQL statement</param>
		/// <param name="parameterObjects">Parameters for the query</param>
		public void ExecuteSoftNonQuery(String sql, params Object[] parameterObjects)
		{
			//OpenConnection();
			DbCommand _oComm;
			switch (DbMode)
			{
#if use_sqlite_connector
			case ConnectionMode.Sqlite:
				_oComm = new SQLiteCommand( sql, _sqliteConn );
				break;
#endif
#if use_sql_server_connector
			case ConnectionMode.SQLServer:
				_oComm = new SqlCommand( sql, _sConn );
				break;
#endif
			default:
#if use_odbc_connector
				case ConnectionMode.Odbc:
					_oComm = new OdbcCommand(sql, _oConn);
					break;
#endif
#if use_mysql_net_connector
			case ConnectionMode.MySqlNative:
				_oComm = new MySqlCommand( sql, _myConn );
				break;
#endif
			}
			if (parameterObjects != null)
			{
				foreach (Object parameter in parameterObjects)
				{
					_oComm.Parameters.Add(parameter);
				}
			}
			if( !disable_logging )
			{
				// not sure this matters... think was trying to debug...
				//if( String.Compare( "delete", 0, _oComm.CommandText, 0, 6, false ) == 0 )
				{
					//Log.log( "Delete something..." );
				}
				Log.log( "SQL Command[" + _dsnConnection + "]: " + _oComm.CommandText );
			}
			MyNonQuery( _oComm );
		}
		public bool KindExecuteNonQuery( String sql, params Object[] parameterObjects )
		{
			return KindExecuteNonQuery( sql, 1, parameterObjects );
		}
		/// <summary>
		/// Executes a query that returns with bool success/failure result.
		/// </summary>
		/// <param name="sql">SQL statement</param>
		/// <param name="parameterObjects">Parameters for the query</param>
		public bool KindExecuteNonQuery( String sql, int skip_frames, params Object[] parameterObjects )
		{
			try
			{
				DbCommand _oComm;
				switch( DbMode )
				{
#if use_sqlite_connector
				case ConnectionMode.Sqlite:

					_oComm = new SQLiteCommand( sql, _sqliteConn );
					break;
#endif
#if use_sql_server_connector
				case ConnectionMode.SQLServer:
					_oComm = new SqlCommand( sql, _sConn );
					break;
#endif
				default:
#if use_odbc_connector
				case ConnectionMode.Odbc:
					_oComm = new OdbcCommand( sql, _oConn );
					break;
#endif
#if use_mysql_net_connector
				case ConnectionMode.MySqlNative:
					_oComm = new MySqlCommand( sql, _myConn );
					break;
#endif
 				}
				if( parameterObjects != null )
				{
					foreach( Object parameter in parameterObjects )
					{
						_oComm.Parameters.Add( parameter );
					}
				}

				if( log_writer != null )
				{
					log_writer.Write( _oComm.CommandText );
					log_writer.WriteLine( ';' );
					log_writer.Flush();
				}

				if( !disable_logging )
					Log.log( "SQL Command[" + _dsnConnection + "]: " + _oComm.CommandText, skip_frames + 1 );
				MyNonQuery( _oComm );
			}
			catch( Exception e )
			{
                last_error = e.Message;
                Log.log( e.Message );
				//CloseConnection();
				return false;
			}
			return true;
		}
		/// <summary>
		/// Executes a query that returns with auto_increment ID of this insert
		/// </summary>
		/// <param name="sql">SQL statement</param>
		/// <param name="parameterObjects">Parameters for statement</param>
		public long KindExecuteInsert( String sql, params Object[] parameterObjects )
		{
			try
			{
				DbCommand _oComm;
				switch( DbMode )
				{
#if use_sqlite_connector
				case ConnectionMode.Sqlite:

					_oComm = new SQLiteCommand( sql, _sqliteConn );
					break;
#endif
#if use_sql_server_connector
				case ConnectionMode.SQLServer:
					_oComm = new SqlCommand( sql, _sConn );
					break;
#endif
				default:
#if use_odbc_connector
				case ConnectionMode.Odbc:
					_oComm = new OdbcCommand( sql, _oConn );
					break;
#endif
#if use_mysql_net_connector
				case ConnectionMode.MySqlNative:
					_oComm = new MySqlCommand( sql, _myConn );
					break;
#endif
 				}
				if( parameterObjects != null )
				{
					foreach( Object parameter in parameterObjects )
					{
						_oComm.Parameters.Add( parameter );
					}
				}
				if( log_writer != null )
				{
					log_writer.Write( _oComm.CommandText );
					log_writer.WriteLine( ';' );
					log_writer.Flush();
				}
				if( !disable_logging )
					Log.log( "SQL Command[" + _dsnConnection + "]: " + _oComm.CommandText, 1 );
				MyNonQuery( _oComm );
				return GetLastInsertID();
			}
			catch( Exception e )
			{
                last_error = e.Message;
                Log.log( e.ToString() );
				return -1;
			}
		}
		/// <summary>
		/// Executes a query that returns no result - throws exception
		/// </summary>
		/// <param name="sql">SQL statement</param>
		public int ExecuteNonQuery(String sql)
		{
			return ExecuteNonQuery(sql, null);
		}
		/// <summary>
		/// Executes a query that returns bool success/failure result
		/// </summary>
		/// <param name="sql">SQL statement</param>
		public bool KindExecuteNonQuery( String sql )
		{
			try
			{
				// this will catch and handle reconnect...
				// the catch here is just to return a false status.
				ExecuteNonQuery( sql, 1, null );
			}
			catch( Exception e )
			{
                last_error = e.Message;
                return false;
			}
			return true;
		}
		/// <summary>
		/// Executes a query that returns long auto_increment ID from insert.
		/// </summary>
		/// <param name="sql">SQL statement</param>
		public long KindExecuteInsert( String sql )
		{
			long LastInsert = -1;
			try
			{
				ExecuteNonQuery( sql, 1, null );
				LastInsert = GetLastInsertID();
			}
			catch( Exception e )
			{
                last_error = e.Message;
                Log.log( e.Message );
			}
			return LastInsert;
		}

		bool HandleReconnect(Exception e)
		{
			Log.log( e.Message );
			OdbcException oe = e.InnerException as OdbcException;
			Win32Exception we = e.InnerException as Win32Exception;
			if( e.InnerException != null )
				Log.log( "Handling exception, attempting reconnect (maybe) " + e.InnerException.GetType() );
			if( oe != null )
			{
				//Log.log( "No inner exception, maybe e is the odbc exception?" );
				if( e.GetType() == typeof( OdbcException ) )
				{
					//Log.log( "converting..." + e.GetType().ToString() );
					try
					{
						oe = e as OdbcException;
					}
					catch
					{
						Log.log( "Damnit, and that crashes too!" );
					}
					//Log.log( "converted?" );
				}
			}
			else if( we != null )
			{
				// OK.
			}
			else 
			{
				Log.log( "wasn't an odbc exception... type is:" + e.GetType().ToString() );
				throw e;
			}
				try
				{
					if( oe.Errors == null )
						Log.log( "No errors array on OdbcException... how do I hadnle it?" );
					else if( oe.Errors.Count == 0 )
						Log.log( "no errors." );
				}
				catch
				{
					Log.log( "Fail." );
					return false;
				}
				if( oe != null && oe.Errors.Count > 0 )
				{
					// table missing.
					if( oe.Errors[0].NativeError == 1146 )
					{
						// wasn't a reconnect, don't retry.
						return false;
					}
					// 2006 - 'server has gone away' - did a pskill mysqld on server
					// 2006 - 'server has gone away' - did a 'kill' on the connection within mysqld
					// 2013 - lost connection to server during a query (pulled network to server - far side of hub)
					Log.log( "Error 1 is [" + oe.Errors[0].NativeError + "]" + oe.Errors[0].ToString() );
					if( oe.Errors[0].NativeError == 2006
						|| oe.Errors[0].NativeError == 2013 )
					{
						//int tries = 0;
						Reconnect = true;

						try
						{
							Log.log( "Connection state is:" + _Connection.State );
							//if( oe.Errors[0].NativeError == 2013 )
							if( _Connection.State == ConnectionState.Open )
                                _Connection.Close();
#if use_odbc_connector
                            _oConn.ConnectionTimeout = 2;
#endif
#if use_mysql_net_connector
                            //_myConn.ConnectionTimeout = 2;
#endif
						}
						catch( Exception e2 )
						{
							Log.log( "Setting connection timeout on connection object: " + e2.Message );
						}

						Log.log( this._dsnConnection + " lost connection, attempting to reconnect." );
						while( this.State == ConnectionState.Closed )
						{
							try
							{
								//if( tries > 3 )
								{
									//if( AllowFallback != null )
									//	if( AllowFallback() )
									//	{
									//	}
									//Reconnect = false;
								}
								//tries++;
								OpenConnection();
							}
							catch( Exception e2 )
							{
								Log.log( "Fatal in OpenConnection: " + e2.Message );
							}
							if( State == ConnectionState.Closed )
							{
								Log.log( this._dsnConnection + " has still lost connection, waiting before reconnect." );
								Thread.Sleep( 250 );
							}
						}
						return true;
					}
					else
					{
						Log.log( this._dsnConnection + " has some other error... [" + oe.Errors[0].NativeError + "] " + oe.Errors[0].Message );
					}
				}
				else
				{
					Log.log( "Failed to find errors." );
				}
				return false;
		}

		private DbDataReader MyReader( DbCommand _oComm )
		{
			try
			{
#if try_to_find_leftover_reader
				Log.log( "reader++ command: " + _oComm.CommandText );
				_last_command = last_command;
				last_command = _oComm.CommandText;
#endif
				return _oComm.ExecuteReader();
			}
			catch( InvalidOperationException e )
			{
				//Log.log( "..." );
				if( HandleReconnect( e ) )
					return _oComm.ExecuteReader();
				return null;
			}
			

		}

		private object MyScalar( DbCommand _oComm )
		{
			try
			{
				return _oComm.ExecuteScalar();
			}
			catch( InvalidOperationException e )
			{
				if( HandleReconnect( e ) )
					return _oComm.ExecuteScalar();
				return null;
			}
			catch( OdbcException oe )
			{
				if( HandleReconnect( oe ) )
					return _oComm.ExecuteScalar();
				return null;
			}
		}

		/// <summary>
		/// Returns an OdbcDataReader from a query
		/// </summary>
		/// <param name="sql">SQL statement</param>
		/// <param name="parameterObjects">Parameters for the query</param>
		public DbDataReader ExecuteReader( String sql, int frame_skip, params Object[] parameterObjects )
		{
			if( _Connection.State != ConnectionState.Open )
				OpenConnection(frame_skip);
			
			DbCommand _oComm;
			switch( DbMode )
			{
#if use_sqlite_connector
			case ConnectionMode.Sqlite:
				_oComm = new SQLiteCommand( sql, _sqliteConn );
				break;
#endif
#if use_sql_server_connector
			case ConnectionMode.SQLServer:
				_oComm = new SqlCommand( sql, _sConn );
				break;
#endif
			default:
#if use_odbc_connector
			case ConnectionMode.Odbc:
				_oComm = new OdbcCommand( sql, _oConn );
				break;
#endif
#if use_mysql_net_connector
			case ConnectionMode.MySqlNative:
				_oComm = new MySqlCommand( sql, _myConn );
				break;
#endif
 			}
			if( parameterObjects != null )
			{
				foreach (Object parameter in parameterObjects)
				{
					_oComm.Parameters.Add( parameter );
				}
			}
			if( !disable_logging )
				Log.log( "SQL Command[" + _dsnConnection + "]: " + _oComm.CommandText, 1 + frame_skip );
			return MyReader( _oComm );
		}

		public void EndReader( DbDataReader reader )
		{
			if( reader != null )
			{
#if try_to_find_leftover_reader
				Log.log( "Reader closing..." );
				for ( int n = 0; n < reader.FieldCount; n++ )
				{
					Log.log( "Column of reader : " + reader.GetName( n ) );
				}
#endif
				reader.Dispose();
			}
		}

		/// <summary>
		/// Returns an OdbcDataReader from a query
		/// </summary>
		/// <param name="sql">SQL statement</param>
		/// <param name="parameterObjects">Parameters for the query</param>
		public DbDataReader ExecuteSoftReader(String sql, params Object[] parameterObjects)
		{
			//OpenConnection();
			//_oComm = new OdbcCommand(sql, _oConn);
			DbCommand _oComm;
			switch (DbMode)
			{
#if use_sqlite_connector
			case ConnectionMode.Sqlite:
				_oComm = new SQLiteCommand( sql, _sqliteConn );
				break;
#endif
#if use_sql_server_connector
			case ConnectionMode.SQLServer:
				_oComm = new SqlCommand( sql, _sConn );
				break;
#endif
			default:
#if use_odbc_connector
				case ConnectionMode.Odbc:
					_oComm = new OdbcCommand(sql, _oConn);
					break;
#endif
#if use_mysql_net_connector
			case ConnectionMode.MySqlNative:
				_oComm = new MySqlCommand( sql, _myConn );
				break;
#endif
			}
			if (parameterObjects != null)
			{
				foreach (Object parameter in parameterObjects)
				{
					_oComm.Parameters.Add(parameter);
				}
			}
			if( !disable_logging )
				Log.log( "SQL Command[" + _dsnConnection + "]: " + _oComm.CommandText );
			return MyReader( _oComm );
		}

		public DbDataReader ExecuteReader( String sql, params Object[] parameterObjects )
		{
			return ExecuteReader( sql, 1, parameterObjects );
		}

		/// <summary>
		/// Returns an OdbcDataReader from a query
		/// </summary>
		/// <param name="sql">SQL Statement</param>
		public DbDataReader ExecuteReader(String sql)
		{
			return ExecuteReader(sql, null);
		}
		/// <summary>
		/// Returns an OdbcDataReader from a query
		/// </summary>
		/// <param name="sql">SQL Statement</param>
		public DbDataReader KindExecuteReader( String sql, int skip_frames )
		{
			DbDataReader DbReader = null;
			try
			{
				DbReader = ExecuteReader( sql, 1 + skip_frames, null );
			}
			catch( Exception e )
			{
                last_error = e.Message;
                try
				{
					// it might not reconnect, it might re-throw the exception out...
					if ( HandleReconnect( e ) )
						DbReader = ExecuteReader( sql, 1 + skip_frames, null );
				}
				catch(Exception e2)
                {
                    last_error = e2.Message;
                }
			}
			return DbReader;
		}
		public DbDataReader KindExecuteReader( String sql )
		{
			return KindExecuteReader( sql, 1 );
		}
		/// <summary>
		/// Returns the content of the first column in the first row from a query
		/// </summary>
		/// <param name="sql">SQL statement</param>
		/// <param name="parameterObjects">Parameters for the query</param>
		public object ExecuteScalar(String sql, int tracelevel, params Object[] parameterObjects)
		{
			//OpenConnection(); 
			DbCommand _oComm;
			try
			{
				switch( DbMode )
				{
				default:
#if use_sqlite_connector
				case ConnectionMode.Sqlite:
					_oComm = new SQLiteCommand( sql, _sqliteConn );
					break;
#endif
#if use_sql_server_connector
				case ConnectionMode.SQLServer:
					_oComm = new SqlCommand( sql, _sConn );
					break;
#endif
#if use_odbc_connector
				case ConnectionMode.Odbc:
					_oComm = new OdbcCommand( sql, _oConn );
					break;
#endif
#if use_mysql_net_connector
	
					_oComm = new MySqlCommand( sql, _myConn );
					break;
#endif
				}
			}
			catch( Exception e )
			{
				Log.log( e.Message );
				return null;
			}
			if( parameterObjects != null )
			{
				foreach (object parameter in parameterObjects)
				{
					_oComm.Parameters.Add( parameter );
				}
			}
			if( !disable_logging )
				Log.log( "SQL Command[" + _dsnConnection + "]: " + _oComm.CommandText, tracelevel + 1 );
			return MyScalar( _oComm );
		}
		public object ExecuteScalar( String sql, params Object[] parameterObjects )
		{
			return ExecuteScalar( sql, 1, parameterObjects );
		}
		/// <summary>
		/// Returns the content of the first column in the first row from a query
		/// </summary>
		/// <param name="sql">SQL statement</param>
		public object ExecuteScalar(String sql)
		{
			return ExecuteScalar(sql, 1, null);
		}
		/// <summary>
		/// Returns a DataTable from a query
		/// </summary>
		/// <param name="sql">SQL statement</param>
		/// <param name="parameterObjects">Parameters for the query</param>
		public DataTable ExecuteTable(String sql, params Object[] parameterObjects)
		{
			DataTable dt = new DataTable();
			dt.Locale = CultureInfo.InvariantCulture;
			dt.Load(ExecuteReader(sql, parameterObjects));
			return dt;
		}
		/// <summary>
		/// Returns a DataTable from a query
		/// </summary>
		/// <param name="sql">SQL statement</param>
		public DataTable ExecuteTable(String sql)
		{
			return ExecuteTable(sql, null);
		}
		/// <summary>
		/// Dispose resources
		/// </summary>
		/// <param name="disposing">Flag for whether or not to dispose managed resources</param>
		protected virtual void Dispose(Boolean disposing)
		{
			if (disposing)
			{
				switch( DbMode )
				{
                default:
#if use_mysql_net_connector
				case ConnectionMode.MySqlNative:
					_myConn.Dispose();
					break;
#endif
#if use_odbc_connector
				case ConnectionMode.Odbc:
					_oConn.Dispose();
					break;
#endif
#if use_sql_server_connector
				case ConnectionMode.SQLServer:
					_sConn.Dispose();
					break;
#endif
#if use_sqlite_connector
				case ConnectionMode.Sqlite:
					_sqliteConn.Dispose();
					break;
#endif
				}
			}
		}

		/// <summary>
		/// Closes the connection to the DSN
		/// </summary>
		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}
		/// <summary>
		/// Relay the connection state... kinda useful for early trapping errors.
		/// </summary>
		public ConnectionState State {
			get
			{
				switch( this.DbMode )
				{
#if use_odbc_connector
				case ConnectionMode.Odbc: return _oConn.State;
#endif
#if use_sqlite_connector
				case ConnectionMode.Sqlite: return _sqliteConn.State;
#endif
#if use_sql_server_connector
				case ConnectionMode.SQLServer: return _sConn.State;
#endif
#if use_mysql_net_connector
				case ConnectionMode.MySqlNative: return _myConn.State;
#endif
				}
				return ConnectionState.Broken;
			}
		}
		public long GetLastInsertID()
		{
			DbCommand _oComm;
			long LastInsert;
			switch( DbMode )
			{
            default:
#if use_sqlite_connector
			case ConnectionMode.Sqlite:
				//Log.log( "select last_inset_rowid()" );
				//Log.log( "Cannot handle this query yet..." );
				//throw new Exception( "Cannot handle this query yet..." );
				//
				_oComm = new SQLiteCommand( "select last_insert_rowid()", _sqliteConn );
				break;
#endif
#if use_sql_server_connector
			case ConnectionMode.SQLServer:
				_oComm = new SqlCommand( "select SCOPE_IDENTITY()", _sConn );
				break;
#endif
#if use_odbc_connector
			case ConnectionMode.Odbc:
				if( DbFlavor == ConnectionFlavor.SQLServer )
				{
					_oComm = new OdbcCommand( "select @@IDENTITY", _oConn );

				}
				else
				{
					//Log.log( "Cannot handle this query yet..." );
					//throw new Exception( "Cannot handle this query yet..." );

					_oComm = new OdbcCommand( "select last_insert_id()", _oConn );

					//_oComm = new OdbcCommand( sql, _oConn );
					//_oComm = _oConn.
				}
				break;
#endif
#if use_mysql_net_connector
                case ConnectionMode.MySqlNative:
				//_oComm = new MySqlCommand( sql, _myConn );
				_oComm = new MySqlCommand( "select last_insert_id()", _myConn );
				break;
#endif
			case ConnectionMode.AccessMDB:

				_oComm = new OdbcCommand( "select @@IDENTITY", _oConn );
				break;
			}
			LastInsert = Convert.ToInt64( MyScalar( _oComm ) );
			_oComm.Dispose();
			return LastInsert;
		}

		static string KeyName( string name )
		{
			return name+"key";
		}
		/// <summary>
		/// Adds a column definition to a create table statement which is being built.  This builds appropriate to the syntax of the database which has been connected.
		/// </summary>
		/// <param name="sb">A string builder to add the column definition to</param>
		/// <param name="keys">A string builder which is building the keys definition (parallel to columns)</param>
		/// <param name="col"></param>
		
		public void AddColumnCreate( StringBuilder cols
			, ref bool first_col
			, StringBuilder keys
			, ref bool first_key
			, DataColumn col )
		{
			cols.Append( "\t" );
			if( !first_col )
			{
				cols.Append( "," );
			}
			switch( DbMode )
			{
			case ConnectionMode.AccessMDB:
				cols.Append( sql_quote_open + col.ColumnName + sql_quote_close
					+ SQL_Utilities.GetColumnDef( DbMode, DbFlavor, col ) );
				if( col.Unique )
				{
					keys.Append( ( first_key ? "" : "," ) + "UNIQUE KEY " + KeyName( col.ColumnName )
						+ " (" + sql_quote_open + col.ColumnName + sql_quote_close + ")" );
					first_key = false;
				}
				break;

			case ConnectionMode.MySqlNative:
			case ConnectionMode.Odbc:
				cols.Append( sql_quote_open + "" + col.ColumnName + "" + sql_quote_close + " "
					+ SQL_Utilities.GetColumnDef( DbMode, DbFlavor, col )
				);
				if( DbFlavor == ConnectionFlavor.MySqlNative )
				{
					if( col.AutoIncrement )
					{
						keys.Append( ( first_key ? "" : "\t," ) + "PRIMARY KEY (" + sql_quote_open + col.ColumnName + sql_quote_close + ")\n" );
						first_key = false;
					}
					else if( col.Unique )
					{
						keys.Append( ( first_key ? "" : "\t," ) + "UNIQUE KEY " + KeyName( col.ColumnName )
							+ " (" + sql_quote_open + col.ColumnName + sql_quote_close + ")\n" );
						first_key = false;
					}
				}
				break;
			case ConnectionMode.SQLServer:
				cols.Append( sql_quote_open + "" + col.ColumnName + "" + sql_quote_close + " "
					+ SQL_Utilities.GetColumnDef( DbMode, DbFlavor, col )
				);
				//if( DbFlavor == ConnectionFlavor.SQLServer )
				{
					if( col.AutoIncrement )
					{
						
						//keys.Append( ( first_key ? "" : "\t," ) + "PRIMARY KEY (" + sql_quote_open + col.ColumnName + sql_quote_close + ")\n" );
						//first_key = false;
					}
					else if( col.Unique )
					{
						cols.Append( " CONSTRAINT " + KeyName( col.ColumnName ) + " UNIQUE " );
						//first_key = false;
					}
				}
				break;
#if use_sqlite_connector
			case ConnectionMode.Sqlite:
				if( col.AutoIncrement )
				{
					cols.Append( "\t" + sql_quote_open + col.ColumnName + sql_quote_close + " INTEGER PRIMARY KEY" );
					//keys.Append( ( first_key ? "" : "," ) + "UNIQUE `primary`(" + sql_quote_open + col.ColumnName + sql_quote_close + ")" );
					//first_key = false;
				}
				else
				{
					cols.Append( sql_quote_open + col.ColumnName + sql_quote_close
						+ SQL_Utilities.GetColumnDef( DbMode, DbFlavor, col ) );
					if( col.Unique )
					{
						keys.Append( ( first_key ? "" : "\t," ) + "UNIQUE(" + sql_quote_open + col.ColumnName + sql_quote_close + ")" );
						first_key = false;
					}
				}
				break;
#endif
			}
			first_col = false;
			cols.Append( "\n" );
		}

		/// <summary>
		/// Create and return a DataTable object that holds the results
		/// of the supplied select statement.
		/// </summary>
		/// <param name="CommandText">The SQL statement to generate results</param>
		/// <returns>The DataTable</returns>
		public DataTable GetDataTableQuery( string CommandText )
		{
			//OpenConnection();
			DataTable MyDataTable = new DataTable();
			DbDataReader reader = ExecuteReader( CommandText );
			MyDataTable.Load( reader, LoadOption.OverwriteChanges );

			reader.Dispose();

			return MyDataTable;
		}

		/// <summary>
		/// Execute a Non Query Array Statements then Create and return a DataReader object that holds the results
		/// of the supplied select statement. // USED TO CREATE TEMPORARY TABLES ON DB
		/// </summary>
		/// <param name="NonQueryCommandText">The SQL statement to execute</param>
		/// <param name="QueryCommandText">The SQL statement to generate results</param>
		/// <returns>The DataReader</returns>
		public DbDataReader RunQueryNonQuery( string[] NonQueryCommandArray, string QueryCommandText )
		{
			bool first = true;
			foreach (string NonqueryCommand in NonQueryCommandArray)
			{
				if (first) ExecuteNonQuery(NonqueryCommand, null);
				else ExecuteSoftNonQuery(NonqueryCommand,null);
			}
			return ExecuteSoftReader( QueryCommandText,null );
		}


		/// <summary>
		/// Utility Function to handle looking up an ID for a name, creating the name if it doesn't exist.
		/// </summary>
		/// <param name="ID_ColumnName">Name of the ID column</param>
		/// <param name="Table">Name of the table</param>
		/// <param name="NameColumnName">Name of the Name column</param>
		/// <param name="Name">Name value to look up</param>
		/// <returns></returns>
		public long ReadNameTable( String ID_ColumnName, String Table, String NameColumnName, String Name )
		{
			object o;
			try
			{
				o = ExecuteScalar( "select " + ID_ColumnName + " from " + Table + " where " + NameColumnName + "='" + Name + "'" );
			}
			catch( OdbcException oe )
			{
				if( oe.Errors[0].NativeError == 1146 )
				{
					MySQLDataTable dt = new MySQLDataTable( this );
					dt.TableName = Table;
					DataColumn dc = dt.Columns.Add( ID_ColumnName, typeof( long ) );
					dc.AutoIncrement = true;
					dc.AutoIncrementSeed = 1;
					dt.Columns.Add( NameColumnName, typeof( String ) );
					DsnSQLUtil.CreateDataTable( this, dt );
				}
				o = ExecuteScalar( "select " + ID_ColumnName + " from " + sql_quote_open + Table + sql_quote_close + " where " + NameColumnName + "='" + Name + "'" );
			}
			if( o != null )
			{
				return Convert.ToInt64( o );
			}
			else
			{
				ExecuteNonQuery( "insert into " + sql_quote_open+Table +sql_quote_close+ " (" + NameColumnName + ")values(" +sql_value_quote_open + Name + sql_value_quote_close + ")" );
				return GetLastInsertID();
			}
		}

		/// <summary>
		/// Utility Function to handle looking up an ID for a name, creating the name if it doesn't exist.
		/// This assumes the ID will be TableName+"_id" and "name" as the name column
		/// </summary>
		/// <param name="Table">Name of the table</param>
		/// <param name="Name">Name value to look up</param>
		/// <returns></returns>
		public long ReadNameTable( String table, String name )
		{
			return ReadNameTable( table + "_id", table, "name", name );
		}

		public void CheckTable( String create_statement )
		{
			XDataTable<DataRow> t1 = SQL_Utilities.CreateTable( create_statement );
			MySQLDataTable t2 = new MySQLDataTable( this, t1 );
		}

		public static Guid GetGUID( DsnConnection dsn )
		{
			if ( dsn != null )
			{
				if( ( dsn.DbMode == ConnectionMode.Odbc
					&& dsn.DbFlavor == ConnectionFlavor.Sqlite )
					|| dsn.DbMode == ConnectionMode.Sqlite )
				{
					// just use pure guid
				}
				else if ( ( dsn.DbMode == ConnectionMode.Odbc
					&& dsn.DbFlavor == ConnectionFlavor.MySqlNative )
					|| dsn.DbMode == ConnectionMode.MySqlNative )
				{
					Guid id = Guid.NewGuid();
					Byte[] bytes = id.ToByteArray();
					long ticks = DateTime.Now.Ticks / 10000;
					Byte[] tick_bytes = BitConverter.GetBytes( ticks );
					for ( int n = 0; n < 6; n++ )
						bytes[n] = tick_bytes[n];
					Guid COMB = new Guid( bytes );
					return COMB;
				}

				else if ( ( dsn.DbMode == ConnectionMode.Odbc
					&& dsn.DbFlavor == ConnectionFlavor.SQLServer )
					|| dsn.DbMode == ConnectionMode.SQLServer )
				{
					Guid id = Guid.NewGuid();
					Byte[] bytes = id.ToByteArray();
					long ticks = DateTime.Now.Ticks / 10000;
					Byte[] tick_bytes = BitConverter.GetBytes( ticks );
					for ( int n = 0; n < 6; n++ )
						bytes[15 - n] = tick_bytes[n];
					Guid COMB = new Guid( bytes );
					return COMB;
				}
				else
				{
					Log.log( "No best-guid generator for database mode." );
				}
			}
			return Guid.NewGuid();
		}

        /// <summary>
        /// Get a GUID appropriate for this database connection (some connections behave more optimally with certain conditions)
        /// </summary>
        /// <returns></returns>
		public Guid GetGUID()
		{
			return DsnConnection.GetGUID( this );
		}

		int in_transaction;
        /// <summary>
        /// Begin a transaction state
        /// </summary>
		public void BeginTransaction()
		{
			if( in_transaction++ == 0 )
			{
				if( DbMode == ConnectionMode.MySqlNative 
					|| DbFlavor == ConnectionFlavor.MySqlNative )
				{
					KindExecuteNonQuery( "START TRANSACTION" );
				}
				else if( DbMode == ConnectionMode.Sqlite || DbFlavor == ConnectionFlavor.Sqlite )
				{
					KindExecuteNonQuery( "BEGIN TRANSACTION" );
				}
			}
		}

        /// <summary>
        /// close a transaction state.
        /// </summary>
		public void EndTransaction( )
		{
			if( --in_transaction == 0 )
			{
				if( ( DbMode == ConnectionMode.MySqlNative || DbFlavor == ConnectionFlavor.MySqlNative )
					|| ( DbMode == ConnectionMode.Sqlite || DbFlavor == ConnectionFlavor.Sqlite ) )
				{
					KindExecuteNonQuery( "COMMIT" );
				}
			}
		}

        public string Error
        {
            get
            {
                return last_error;
                // return the last database error string.
            }

        }

		public void LogWriteLine()
		{
			if( log_writer != null )
			{
				log_writer.WriteLine();
				log_writer.Flush();
			}
		}
	}

}
