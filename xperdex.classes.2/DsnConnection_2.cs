#define use_sqlite_connector
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
using System.Data.Common;
using System.Text;
using System.Collections.ObjectModel;

namespace xperdex.classes
{

	// could implement now() and junk...
#if whatever
	[SQLiteFunctionAttribute( Arguments=0,  FuncType=FunctionType.Scalar,  Name="last_insert_id" ) ]
	public class LastInsertID : SQLiteFunction
	{
		public LastInsertID()
		{

		}
		public override object Invoke( object[] args )
		{
			//this.SQLiteConvert.
			UnsafeNativeMethods.sqlite3_cursor_
			return 1;
			//return base.Invoke( args );
		}
	}
#endif



	/// <summary>
	/// Represents a connection to a DSN
	/// </summary>
	public class DsnConnection : IDisposable
	{
		Collection<DbCommand> commands; // outstanding commands?
#if use_mysql_net_connector
		private MySqlConnection _myConn;
#endif
#if use_sqlite_connector
      
		private SQLiteConnection _sqliteConn;
#endif
		private OdbcConnection _oConn;

		// can use the more general purpose command usually...
		//DbCommand _oComm;

		internal enum ConnectionMode
		{
			MySqlNative
			, Odbc
			, Sqlite
		}
		internal ConnectionMode Mode;

		//bool log;
		bool connected;

		void OpenAConnection( string stuff )
		{
			commands = new Collection<DbCommand>();
			if( !connected )
			{
				try
				{
					_oConn = new OdbcConnection( "DSN=" + stuff );
					_oConn.Open();
					connected = true;
					Mode = ConnectionMode.Odbc;
				}
				catch( Exception e )
				{
					Log.log( e.Message );
				}
			}
#if use_mysql_net_connector
			if( !connected )
			{
				try
				{
					_myConn = new MySqlConnection( "Database=Fortunet;Host=localhost;Data Source=localhost;User Id=fortunet;Password=dkc408a1f" );
					_myConn.Open();
					Mode = ConnectionMode.MySqlNative;
					connected = true;
				}
				catch( Exception ex )
				{
					_myConn.Dispose();
					_myConn = null;
					xperdex.classes.Log.log( ex.Message );
				}
			}
#endif
#if use_sqlite_connector
			if( !connected )
			{
				try
				{
					_sqliteConn = new SQLiteConnection( "Database=Fortunet;Data Source=" + stuff );
					//_sqliteConn.
					_sqliteConn.Open();
					Mode = ConnectionMode.Sqlite;
					connected = true;
				}
				catch( Exception ex2 )
				{
					classes.Log.log( ex2.Message );
				}
			}
#endif
		}
		/// <summary>
		/// Creates and opens a connection to the MySQL DSN.  Throws an exception if connection could not be open
		/// </summary>
		public DsnConnection()
		{
			OpenAConnection( "MySQL" );
		}
		/// <summary>
		/// Creates and opens a connection to a DSN.  Throws an exception if connection could not be open
		/// </summary>
		/// <param name="dsn">Name of the DSN</param>
		public DsnConnection(String dsn)
		{
			OpenAConnection( dsn );
		}
		/// <summary>
		/// Creates and opens a connection to a DSN.
		/// </summary>
		/// <param name="dsn">Name of the DSN</param>
		/// <param name="kind">if true does not exception.</param>
		public DsnConnection( String dsn, bool kind )
		{
			throw new Exception( "ERm... yeah fix this." );
			_oConn = new OdbcConnection( "DSN=" + dsn );
			try
			{
				_oConn.Open();
			}
			catch( Exception e )
			{
				// release any sort of connection... (should have saved the dsn?)
				//_oConn = null;
				Console.WriteLine( e );
				if( !kind )
					throw e;
			}
		}
		/// <summary>
		/// Creates and opens a connection to a custom server.  Throws an exception if connection could not be open
		/// </summary>
		/// <param name="server">Server address</param>
		/// <param name="port">Server port</param>
		/// <param name="database">Database name</param>
		public DsnConnection(String server, String port, String database)
		{
			_oConn = new OdbcConnection(
				"DRIVER={MySQL ODBC 3.51 Driver}; " +
					"SERVER=" + server + "; " +
					"PORT=" + port + "; " +
					"DATABASE=" + database + "; " +
					"USER=fortunet; " +
					"PASSWORD=dkc408a1f; " +
					"OPTION=3"
				);
			_oConn.Open();
		}
		/// <summary>
		/// Executes a query that returns no result
		/// </summary>
		/// <param name="sql">SQL statement</param>
		/// <param name="parameterObjects">Parameters for the query</param>
		public void ExecuteNonQuery(String sql, params Object[] parameterObjects)
		{
			DbCommand _oComm;
			switch( Mode )
			{
#if use_sqlite_connector
			case ConnectionMode.Sqlite:
				_oComm = new SQLiteCommand( sql, _sqliteConn );
				break;
#endif
			default:
			case ConnectionMode.Odbc:
				_oComm = new OdbcCommand( sql, _oConn );
				break;
#if use_mysql_net_connector
			case ConnectionMode.MySqlNative:
				_oComm = new MySqlCommand( sql, _myConn );
				break;
#endif
			}
			commands.Add( _oComm );
			if (parameterObjects != null)
			{
				foreach (Object parameter in parameterObjects)
				{
					_oComm.Parameters.Add( parameter );
				}
			}
			if( String.Compare( "delete", 0, _oComm.CommandText, 0, 6, false ) == 0 )
			{
				Log.log( "Delete something..." );
			}
			Log.log( "SQL Command: " + _oComm.CommandText );
			
			_oComm.ExecuteNonQuery();
		}
		/// <summary>
		/// Executes a query that returns with bool success/failure result.
		/// </summary>
		/// <param name="sql">SQL statement</param>
		/// <param name="parameterObjects">Parameters for the query</param>
		public bool KindExecuteNonQuery( String sql, params Object[] parameterObjects )
		{
			try
			{
				DbCommand _oComm;
				switch( Mode )
				{
#if use_sqlite_connector
				case ConnectionMode.Sqlite:

					_oComm = new SQLiteCommand( sql, _sqliteConn );
					break;
#endif
				default:
				case ConnectionMode.Odbc:
					_oComm = new OdbcCommand( sql, _oConn );
					break;
#if use_mysql_net_connector
				case ConnectionMode.MySqlNative:
					_oComm = new MySqlCommand( sql, _myConn );
					break;
#endif
 				}
				commands.Add( _oComm );
				if( parameterObjects != null )
				{
					foreach( Object parameter in parameterObjects )
					{
						_oComm.Parameters.Add( parameter );
					}
				}
				Log.log( "SQL Command: " + _oComm.CommandText );
				_oComm.ExecuteNonQuery();
			}
			catch( Exception e )
			{
				Log.log( e.Message );
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
				switch( Mode )
				{
#if use_sqlite_connector
				case ConnectionMode.Sqlite:

					_oComm = new SQLiteCommand( sql, _sqliteConn );
					break;
#endif
				default:
				case ConnectionMode.Odbc:
					_oComm = new OdbcCommand( sql, _oConn );
					break;
#if use_mysql_net_connector
				case ConnectionMode.MySqlNative:
					_oComm = new MySqlCommand( sql, _myConn );
					break;
#endif
 				}
				commands.Add( _oComm );
				if( parameterObjects != null )
				{
					foreach( Object parameter in parameterObjects )
					{
						_oComm.Parameters.Add( parameter );
					}
				}
				Log.log( "SQL Command: " + _oComm.CommandText );
				_oComm.ExecuteNonQuery();
				switch( Mode )
				{
#if use_sqlite_connector
				case ConnectionMode.Sqlite:
					_oComm = new SQLiteCommand( "select last_insert_rowid()", _sqliteConn );
					break;
#endif
				default:
				case ConnectionMode.Odbc:
					_oComm = new OdbcCommand( "select last_insert_id()", _oConn );
					break;
#if use_mysql_net_connector
				case ConnectionMode.MySqlNative:
					_oComm = new MySqlCommand( "select last_insert_id()", _myConn );
					break;
#endif
				}
				
				return Convert.ToInt64( _oComm.ExecuteScalar() );
			}
			catch( Exception e )
			{
				Console.WriteLine( e );
				return -1;
			}
		}
		/// <summary>
		/// Executes a query that returns no result - throws exception
		/// </summary>
		/// <param name="sql">SQL statement</param>
		public void ExecuteNonQuery(String sql)
		{
			ExecuteNonQuery(sql, null);
		}
		/// <summary>
		/// Executes a query that returns bool success/failure result
		/// </summary>
		/// <param name="sql">SQL statement</param>
		public bool KindExecuteNonQuery( String sql )
		{
			try
			{
				ExecuteNonQuery( sql, null );
			}
			catch( Exception e )
			{
				Log.log( e.Message );
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
			try
			{
				DbCommand _oComm;
				ExecuteNonQuery( sql, null );

				switch( Mode )
				{
#if use_sqlite_connector
				case ConnectionMode.Sqlite:
					Log.log( "Cannot handle this query yet..." );
					throw new Exception( "Cannot handle this query yet..." );
					//
					//_oComm = new SQLiteCommand( sql, _sqliteConn );
					break;
#endif
				default:
				case ConnectionMode.Odbc:
					Log.log( "Cannot handle this query yet..." );
					throw new Exception( "Cannot handle this query yet..." );
					//_oComm = new OdbcCommand( sql, _oConn );
					//_oComm = _oConn.
					break;
#if use_mysql_net_connector
				case ConnectionMode.MySqlNative:
					//_oComm = new MySqlCommand( sql, _myConn );
					_oComm = new OdbcCommand( "select last_insert_id()", _oConn );
					break;
#endif
 				}
				commands.Add( _oComm );
				Log.log( "SQL Command: " + _oComm.CommandText );
				return Convert.ToInt64( _oComm.ExecuteScalar() );
			}
			catch( Exception e )
			{
				Console.WriteLine( e );
			}
			return -1;
		}
		/// <summary>
		/// Returns an OdbcDataReader from a query
		/// </summary>
		/// <param name="sql">SQL statement</param>
		/// <param name="parameterObjects">Parameters for the query</param>
		public DbDataReader ExecuteReader(String sql, params Object[] parameterObjects)
		{
			//_oComm = new OdbcCommand(sql, _oConn);
			DbCommand _oComm;
			switch( Mode )
			{
#if use_sqlite_connector
			case ConnectionMode.Sqlite:
				_oComm = new SQLiteCommand( sql, _sqliteConn );
				break;
#endif
			default:
			case ConnectionMode.Odbc:
				_oComm = new OdbcCommand( sql, _oConn );
				break;
#if use_mysql_net_connector
			case ConnectionMode.MySqlNative:
				_oComm = new MySqlCommand( sql, _myConn );
				break;
#endif
 			}
			commands.Add( _oComm );
			if( parameterObjects != null )
			{
				foreach (Object parameter in parameterObjects)
				{
					_oComm.Parameters.Add( parameter );
				}
			}
			Log.log( "SQL Command: " + _oComm.CommandText );
			return _oComm.ExecuteReader();
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
		public DbDataReader KindExecuteReader( String sql )
		{
			try
			{
				return ExecuteReader( sql, null );
			}
			catch( Exception e )
			{

				Console.WriteLine( e.Message );
			}
			return null;
		}
		/// <summary>
		/// Returns the content of the first column in the first row from a query
		/// </summary>
		/// <param name="sql">SQL statement</param>
		/// <param name="parameterObjects">Parameters for the query</param>
		public object ExecuteScalar(String sql, params Object[] parameterObjects)
		{
			DbCommand _oComm;

			switch( Mode )
			{
#if use_sqlite_connector
			case ConnectionMode.Sqlite:
				_oComm = new SQLiteCommand( sql, _sqliteConn );
				break;
#endif
			default:
			case ConnectionMode.Odbc:
				_oComm = new OdbcCommand( sql, _oConn );
				break;
#if use_mysql_net_connector
			case ConnectionMode.MySqlNative:
				_oComm = new MySqlCommand( sql, _myConn );
				break;
#endif
 			}
			commands.Add( _oComm );
			if( parameterObjects != null )
			{
				foreach (object parameter in parameterObjects)
				{
					_oComm.Parameters.Add( parameter );
				}
			}
			Log.log( "SQL Command: " + _oComm.CommandText );
			return _oComm.ExecuteScalar();
		}
		/// <summary>
		/// Returns the content of the first column in the first row from a query
		/// </summary>
		/// <param name="sql">SQL statement</param>
		public object ExecuteScalar(String sql)
		{
			return ExecuteScalar(sql, null);
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
				foreach(DbCommand _oComm in commands )
					_oComm.Dispose();
				commands = null;
				switch( Mode )
				{
#if use_mysql_net_connector
				case ConnectionMode.MySqlNative:
					_myConn.Dispose();
					break;
#endif
				default:
				case ConnectionMode.Odbc:
					_oConn.Dispose();
					break;
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
				switch( this.Mode )
				{
				default:
				case ConnectionMode.Odbc: return _oConn.State;
#if use_sqlite_connector
				case ConnectionMode.Sqlite: return _sqliteConn.State;
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
			DbDataReader r = KindExecuteReader( "select last_insert_id()" );
			if( r != null )
			{
				r.Read();
				return Convert.ToInt64( r[0] );
			}
			return -1;
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
		const string sql_quote = "`";
		public void AddColumnCreate( StringBuilder cols
			, ref bool first_col
			, StringBuilder keys
			, ref bool first_key
			, DataColumn col )
		{
			if( !first_col )
			{
				cols.Append( "," );
			}
			switch( Mode )
			{
			case ConnectionMode.MySqlNative:
			case ConnectionMode.Odbc:
				cols.Append( sql_quote + "" + col.ColumnName + "" + sql_quote + " "
					+ ( ( col.DataType == typeof( string ) )
					? "varchar(100) not NULL default ''"
					: ( col.DataType == typeof( double ) )
					? "double not NULL default 0.0"
					//: ( col.DataType == typeof( Commodity ) )
					//? "double not NULL default 0.0"
					: ( col.DataType == typeof( DateTime ) )
					? "datetime NOT NULL default '00-00-00 00:00:00'"
					: ( col.DataType == typeof( byte[] ) )
					? "blob default NULL"
					: ( col.AutoIncrement ? "int(11) auto_increment" : "int(11) NOT NULL default '0'" )
					) );
				if( col.AutoIncrement )
				{
					keys.Append( ( first_key ? "" : "," ) + "PRIMARY KEY (" + sql_quote + col.ColumnName + sql_quote + ")" );
					first_key = false;
				}
				if( col.Unique )
				{
					keys.Append( ( first_key ? "" : "," ) + "UNIQUE KEY" + KeyName( col.ColumnName )
						+ " (" + sql_quote + col.ColumnName + sql_quote + ")" );
					first_key = false;
				}
				break;
#if use_sqlite_connector
			case ConnectionMode.Sqlite:
				if( col.AutoIncrement )
				{
					cols.Append( sql_quote + col.ColumnName + sql_quote + " int" );
					keys.Append( (first_key?"":",") + "PRIMARY KEY (" + col.ColumnName + ")" );
					first_key = false;
				}
				else
				{
					cols.Append( sql_quote + "" + col.ColumnName + "" + sql_quote + " "
						+ ( ( col.DataType == typeof( string ) )
						? "varchar default ''"
						: ( col.DataType == typeof( double ) )
						? "double not NULL default 0.0"
						//: ( col.DataType == typeof( Commodity ) )
						//? "double not NULL default 0.0"
						: ( col.DataType == typeof( DateTime ) )
						? "datetime NOT NULL default '00-00-00 00:00:00'"
						: ( col.DataType == typeof( byte[] ) )
						? "blob default NULL"
						: "int(11) NOT NULL default '0'" )
						);
					if( col.Unique )
					{
						keys.Append( ( first_key ? "" : "," ) + "UNIQUE(" + sql_quote + col.ColumnName + sql_quote + ")" );
						first_key = false;
					}
				}
				break;
#endif
			}
			first_col = false;
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
			foreach( string NonqueryCommand in NonQueryCommandArray )
				ExecuteNonQuery( NonqueryCommand );
			return ExecuteReader( QueryCommandText );
		}

	}
}
