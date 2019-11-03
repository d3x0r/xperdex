using System.Data.Common;

namespace xperdex.classes
{
    public class DsnOdbcConnection: DsnConnection
    {
		
		public DsnOdbcConnection()
			: base( INI.File( "CTK.INI" )["ODBC"]["DSN", "MySQL"] )
		{
		}

#if asdfasdf
        OdbcConnection _oConn;
        OdbcCommand _oComm;
		string _dsnConnection;
		
        public OdbcConnection oConn
        {
            get { return _oConn; }            
        }

		public string dnsConnection
		{
			get { return _dsnConnection; }
		}

       /// <summary>
		/// Creates and opens a connection to the MySQL DSN.  
		/// 1.) Search DSN connection in Settings/CTK.ini file... 
		/// 2.) if doesn't find it, search C:\\WINDOWS\\win.ini [FORTUNET], SYSTEM PATH = [file with general settings]
		/// and then get the DSN Connection from [file with general settings]
		/// Throws an exception if connection could not be open
		/// </summary>
		public DsnOdbcConnection()
		{
			InitializeDsnOdbcConnection();
		}

		private void InitializeDsnOdbcConnection()
		{
			try
			{

				IniFile dnsConfig = new IniFile(path);
				string _dnsConnection = dnsConfig.IniReadValue("ODBC", "DSN");
				if (_dnsConnection == "")
				{
					dnsConfig = new IniFile("C:\\WINDOWS\\win.ini");
					path = dnsConfig.IniReadValue("FORTUNET", "SYSTEM PATH");

					dnsConfig = new IniFile(path);
					_dnsConnection = dnsConfig.IniReadEncValue("ODBC", "DSN", "MySQL");

				}
				if( _dnsConnection )
				_oConn = new OdbcConnection("DSN=" + _dnsConnection);
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
			}
			//_dsn = new DsnConnection(INI.Default["Static Reg DSN ODBC"]["DSN", "MySQL"]);
			
			//string path;

			//path = Environment.CurrentDirectory + "\\Settings\\CTK.ini";

			//try
			//{

			//    IniFile dnsConfig = new IniFile(path);
			//    string _dnsConnection = dnsConfig.IniReadValue("ODBC", "DSN");
			//    if (_dnsConnection == "")
			//    {
			//        dnsConfig = new IniFile("C:\\WINDOWS\\win.ini");
			//        path = dnsConfig.IniReadValue("FORTUNET", "SYSTEM PATH");

			//        dnsConfig = new IniFile(path);
			//        _dnsConnection = dnsConfig.IniReadEncValue("ODBC", "DSN", "MySQL");

			//    }
			//    _oConn = new OdbcConnection("DSN=" + _dnsConnection);
			//}
			//catch (Exception e)
			//{
			//    string w = e.Message;
			//}
		}
		

		public DsnOdbcConnection(string p_dsnConnection)
        {
			_dsnConnection = p_dsnConnection;
			_oConn = new OdbcConnection("DSN=" + _dsnConnection);            
        }

        /// <summary>
        /// Opens the connection.
        /// </summary>
        private void OpenConnection()
        {
			try
			{
				if (_oConn == null)
					InitializeDsnOdbcConnection();

				if (_oConn.State != ConnectionState.Open)
				{
					_oConn.Open();
				}
			}
			catch (Exception e)
			{

			}
        }


        /// <summary>
        /// Disposes the object.
        /// </summary>
        public void Dispose()
        {
            CloseConnection();
            _oConn = null;
            _oComm = null;
        }

        /// <summary>
        /// Closes the connection.
        /// </summary>
        private void CloseConnection()
        {
            if (_oConn != null && _oConn.State != ConnectionState.Closed)
                _oConn.Close();
        }
#endif
        /// <summary>
        /// Execute a Non Query Statement
        /// </summary>
        /// <param name="CommandText">The SQL statement to execute</param>
        /// <returns>Count of records updated if successful, -1 if it fails</returns>
        public int RunNonQuery(string CommandText)
        {
			return base.ExecuteNonQuery( CommandText );
#if asdfasdf
            OpenConnection();
            int RecordsAffected = 0;
            _oComm = new OdbcCommand(CommandText, _oConn);
            try
            {
                RecordsAffected = _oComm.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                RecordsAffected = -1;
                throw (ex);
            }
            finally
            {
                CloseConnection();
            }

            return RecordsAffected;
#endif
        }

		/// <summary>
		/// Execute a Non Query Statement
		/// </summary>
		/// <param name="CommandText">The SQL statement to execute</param>
		public long InsertQuery(string CommandText)
		{
			return KindExecuteInsert( CommandText );
#if asdfasdf
			OpenConnection();
			long RecordsAffected = 0;
			_oComm = new OdbcCommand(CommandText, _oConn);
			try
			{
				RecordsAffected = _oComm.ExecuteNonQuery();
				_oComm = new OdbcCommand("select last_insert_id()", _oConn);
				RecordsAffected = Convert.ToInt64(_oComm.ExecuteScalar());
			}
			catch (Exception ex)
			{
				RecordsAffected = -1;
				throw (ex);
			}
			finally
			{
				CloseConnection();
			}

			return RecordsAffected;
#endif
		}

        /// <summary>
        /// Create and return a DataReader object that holds the results
        /// of the supplied select statement.
        /// </summary>
        /// <param name="CommandText">The SQL statement to generate results</param>
        /// <returns>The DataReader</returns>
        public DbDataReader RunQuery(string CommandText)
        {
			return base.ExecuteReader( CommandText );
#if asdffasdf
            OpenConnection();
            OdbcDataReader reader;
            _oComm = new OdbcCommand(CommandText, _oConn);
            try
            {
                reader = _oComm.ExecuteReader();
            }
            catch (Exception ex)
            {
                reader = null;
                throw (ex);
            }
            finally
            {
                
            }
            return reader;
#endif
        }

        /// <summary>
        /// Execute a Non Query Array Statements then Create and return a DataReader object that holds the results
        /// of the supplied select statement. // USED TO CREATE TEMPORARY TABLES ON DB
        /// </summary>
        /// <param name="NonQueryCommandText">The SQL statement to execute</param>
        /// <param name="QueryCommandText">The SQL statement to generate results</param>
        /// <returns>The DataReader</returns>
#if asdfasdf
        public DbDataReader RunQueryNonQuery(string[] NonQueryCommandArray, string QueryCommandText)
        {
			//OpenConnection();
            //int RecordsAffected = 0;
            foreach (string NonqueryCommand in NonQueryCommandArray)
            {
				base.ExecuteNonQuery( NonqueryCommand );
#if asdasdf
                _oComm = new OdbcCommand(NonqueryCommand, _oConn);
                try
                {
                    RecordsAffected = _oComm.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    RecordsAffected = -1;
                    throw (ex);
                }
#endif
            }
			return base.ExecuteReader( QueryCommandText );
#if asdfasdf
            OdbcDataReader reader;
            _oComm = new OdbcCommand(QueryCommandText, _oConn);
            try
            {
                reader = _oComm.ExecuteReader();
            }
            catch (Exception ex)
            {
                reader = null;
                throw (ex);
            }
            finally
            {
                
            }
            return reader;
#endif
        }
#endif


        /// <summary>
        /// Execute a scalar query returning the first column of the first row
        /// of the supplied select statement.
        /// </summary>
        /// <param name="CommandText">The SQL statement to generate results</param>
        /// <returns>The Object</returns>
        public object RunScalar(string CommandText)
        {
			return base.ExecuteScalar( CommandText );
#if sadfasdf
            object Scalar;
            OpenConnection();
            _oComm = new OdbcCommand(CommandText, _oConn);
            Scalar = _oComm.ExecuteScalar();
            CloseConnection();
            return Scalar;
#endif
        }
    }
}
