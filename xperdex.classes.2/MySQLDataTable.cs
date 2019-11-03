//#define use_p2p_events
//#define fix_by_delete
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Odbc;
using System.Data.Common;
#if use_p2p_events
using System.ServiceModel;
using System.ServiceModel.Dispatcher;
#endif
using System.Reflection;
using System.Collections;
using System.Threading;

namespace xperdex.classes
{
	/// <summary>
	/// MySQLDataTable has a builtin connection; and was originally implemented to capture live change events and
	/// update a SQL database using the connection on demand immediately as changes happen.  This method is not always preferred.
	/// This Is an extension of XDataTable which provides addtional key/indexing features when defining a table.
	/// The functionality that this used to create and update sql was moved to DsnSQLUtil static utility class.
	/// </summary>
#if use_p2p_events
	[ServiceBehavior( InstanceContextMode = InstanceContextMode.Single )]
#endif
	public class MySQLDataTable<T> : XDataTable<T>
#if use_p2p_events
        , IEventNotice
#endif
		where T:DataRow
	{
#if use_p2p_events
        // when I get the update event from myself ignore it.
        private bool self_triggered;
#endif

		internal protected DsnConnection connection;
		public DsnConnection Connection
		{
			get
			{
				return connection;
			}
		}

		/// <summary>
		/// Replaces the current connection with the passed connection, and invokes Fill.
		/// </summary>
		/// <param name="new_connection"></param>
		public void Reconnect( DsnConnection new_connection )
		{
			connection = new_connection;
			this.BeginLoadData();
			Clear();
			DsnSQLUtil.CreateDataTable( connection, this );
			Fill();
			this.EndLoadData();
		}

#if use_p2p_events
        protected override void Dispose( bool disposing )
        {
            xperdex.classes.UpdateService.EventAnnouncer.StopReceiving( this );
            base.Dispose( disposing );
        }
#endif

		/// <summary>
		/// Replaces the current connection with the passed connection, and invokes Fill.
		/// </summary>
		/// <param name="new_connection"></param>
		/// <param name="fill">if set, will invoke Fill()</param>
		/// <param name="sync">if set, will sync to database (relation table, probably the current relations more accurate</param>
		public void Reconnect( DsnConnection new_connection, bool fill, bool sync )
		{
			connection = new_connection;
			DsnSQLUtil.CreateDataTable( connection, this );
			if( fill )
			{
				this.BeginLoadData();
				Clear();
				Fill();
				this.EndLoadData();
			}
			else if( sync )
				SyncToDatabase( new_connection );
		}

		/// <summary>
		/// boolean to reflect whether the create table in the database sync has been done... used when adding foriegn keys - may be able to wait until table is created and generate as proper create statement without alter.
		/// </summary>
		//public bool Created;
		/// <summary>
		/// this should control when updates are done (immdediate or at acceptchanges)
		/// </summary>
		protected internal bool live = false;

		/// <summary>
		/// Should implement the idea of lazy loading, so the entire tree of a complex structure is not loaded.
		/// Can load relavent tables as they are required....
		/// </summary>
		//public bool filled = false;
		//bool exists;
#if use_p2p_events
		IEventNotice transmit;
#endif
		~MySQLDataTable()
		{
			connection = null;
		}

		protected string _filter = "";
	
		//DataAdapter adapter;
		/// <summary>
		/// Checks the name, and removes tailing _info and _description from name for use in auto index/name columns.
		/// </summary>
		/// <param name="s">Table name to remove</param>
		/// <returns>A substring of Table appropriately trimmed</returns>
		public static string StripInfo( string s )
		{
			int trim = s.IndexOf( "_info" );
			if( trim > 0 )
				return s.Substring( 0, trim );
			trim = s.IndexOf( "_description" );
			if( trim > 0 )
				return s.Substring( 0, trim );
			return s;
		}

		/// <summary>
		/// Checks the name, and removes tailing 's' from name for use in auto index/name columns.
		/// </summary>
		/// <param name="s">Table name to singulate</param>
		/// <returns>A substring of Table appropriately trimmed</returns>
		public static string StripPlural( string s )
		{
            if ( ( s.Length > 3 ) && String.Compare( s, s.Length - 3, "ies", 0, 3 ) == 0 )
                return s.Substring( 0, s.Length - 3 ) + "y";
            if ( ( s.Length > 3 ) && String.Compare( s, s.Length - 3, "ses", 0, 3 ) == 0 )
                return s.Substring( 0, s.Length - 3 ) + "s";
            if ( ( s.Length > 1 ) && s[s.Length - 1] == 's' )
				return s.Substring( 0, s.Length - 1 );
			return s;
		}

#if use_p2p_events
		void OpenEventReceiver()
		{
			lock( MySQLDataTable.event_lock )
			{
				transmit = xperdex.classes.UpdateService.EventAnnouncer.StartReceiving<MySQLDataTable, IEventNotice>( this
						, "MySQL.data.table"
						, FullTableName
						, "generic" );
			}
			
		}
#endif
		void Init()
		{
			// this used to make a p2p event.  But if we never activate and send an event (if it never writes) then we don't need that channel open.
#if use_p2p_events
			Thread register_event = new Thread( OpenEventReceiver );
			register_event.Start();
#endif
		}

		bool DoUpdateCommand( DataRow Row )
		{
			return DsnSQLUtil.DoUpdateCommand( connection, this, Row );
		}

		public String GetSQLValue( Type t, object o )
		{
			return DsnSQLUtil.GetSQLValue( connection, t, 0 );
		}

        public String GetSQLValue( DataColumn dc, object o )
        {
			return DsnSQLUtil.GetSQLValue( connection, dc, o );
        }




		/// <summary>
		/// This is the thing that actually adds the default TableName_id and TableName_name
		/// </summary>
		/// <param name="trim_info">Option to trim _info and _description</param>
		public void AddDefaultColumns(bool trim_info)
		{
			AddDefaultColumns(trim_info, true, false);
			//this.Columns.Add( Name( this ), typeof( string ) );
		}



		//DataColumn auto_id;
		public static void AddDefaultColumns( DataTable table, bool trim_info, bool add_auto_id, bool add_auto_name )
		{
			if( add_auto_id )
			{
				IXDataTable ixtable = (IXDataTable)table;
				DataColumn dc;

				if( ixtable != null )
				{
					if( ixtable.AutoKeyType == typeof( Guid ) )
						table.TableNewRow += new DataTableNewRowEventHandler( table_TableNewRow );
					dc = table.Columns.Add( XDataTable.ID( table ), ixtable.AutoKeyType );
					if( ixtable.AutoKeyType == typeof( int ) )
					{
						dc.AutoIncrement = true;
						dc.AllowDBNull = false;
						dc.AutoIncrementStep = 1;
						dc.AutoIncrementSeed = 1;
					}
					ixtable.auto_id = dc;
				}
				else
					dc = table.Columns.Add( XDataTable.ID( table ), typeof( int ) );
				
				table.PrimaryKey = new DataColumn[] { dc };
			}
			if( add_auto_name )
			{
				table.Columns.Add( XDataTable.Name( table ), typeof( string ) ).Unique = true;
			}
		}

		public static Guid GetCOMB()
		{
			return DsnConnection.GetGUID( null );
		}

		public static String MakeDateOnly( DateTime day )
		{
			return DsnSQLUtil.MakeDateOnly( null, day );
		}

		static void table_TableNewRow( object sender, DataTableNewRowEventArgs e )
		{
			MySQLDataTable that = e.Row.Table as MySQLDataTable;
			MySQLDataTable<T> that_t = e.Row.Table as MySQLDataTable<T>;
			IXDataTable xthat = e.Row.Table as IXDataTable;
			DsnConnection conn = null;
			if( that != null )
				conn = that.connection;
			else if( that_t != null )
				conn = that_t.connection;
			if( xthat != null )
			{
				e.Row[xthat.PrimaryKeyName] = DsnConnection.GetGUID( conn );
			}
			else
				e.Row[XDataTable.ID( e.Row.Table )] = DsnConnection.GetGUID( conn );
		}
		/// <summary>
		/// This is the thing that actually adds the default TableName_id and TableName_name
		/// </summary>
		/// <param name="trim_info">Option to trim _info and _description</param>
		public void AddDefaultColumns( bool trim_info, bool add_auto_id, bool add_auto_name )
		{
			MySQLDataTable.AddDefaultColumns( this, trim_info, add_auto_id, add_auto_name );
		}

		/// <summary>
		/// Creates a table with a prefix and a name, deault columns name_id and name_name
		/// </summary>
		/// <param name="prefix">Prefix to prepend to the table name (not column names)</param>
		/// <param name="name">Table name to create and fill</param>
		/// <param name="add_default_columns">Option to add default _id and _name column</param>
		/// <param name="auto_fill">Option to auto create/fill table with data</param>
		public MySQLDataTable( DsnConnection dsn = null
			, string prefix = null
			, string name = null
			, bool add_default_columns = false
			, bool trim_info = false
			, bool auto_fill = false
			, bool live_update_dsn = false
			, string fill_query = null
			)
		{
			this.connection = dsn;
			this.live = live_update_dsn;
			this.TableName = ( name == null )? "" :name;
			this.Prefix = ( prefix == null ) ? "" : prefix;
			Init();
			if( add_default_columns && name != null )
				AddDefaultColumns( trim_info );
			if( auto_fill )
			{
				if( this.FullTableName != "" )
					DsnSQLUtil.CreateDataTable( connection, this );
				if( fill_query != null )
					Fill( fill_query, 0 );
				else
					Fill();
			}
		}
		public MySQLDataTable( DsnConnection dsn, DataTable table )
		{
			// copy table into myself...
			connection = dsn;
			TableName = table.TableName;
			Prefix = table.Prefix;
			foreach( DataColumn dc in table.Columns )
				Columns.Add( dc );
			DsnSQLUtil.CreateDataTable( connection, this );
		}
#if asdf
		/// <summary>
		/// Creates a table with a prefix and a name, deault columns name_id and name_name
		/// </summary>
		/// <param name="prefix">Prefix to prepend to the table name (not column names)</param>
		/// <param name="name">Table name to create and fill</param>
		public MySQLDataTable( string prefix, string name )
		{
			this.TableName = name;
			this.Prefix = (prefix == null)?"":prefix;
			Init();
			AddDefaultColumns( false );
			DsnSQLUtil.CreateDataTable( connection, this );
			Fill();
		}

		/// <summary>
		/// Creates a table with a prefix and a name, deault columns name_id and name_name
		/// </summary>
		/// <param name="prefix">Prefix to prepend to the table name (not column names)</param>
		/// <param name="name">Table name to create and fill</param>
		/// <param name="auto_fill">Option to auto create/fill table with data</param>
		public MySQLDataTable( string prefix, string name, bool auto_fill )
		{
			this.TableName = name;
			this.Prefix = ( prefix == null ) ? "" : prefix;
			Init();
			AddDefaultColumns( true );
			if( auto_fill )
			{
				DsnSQLUtil.CreateDataTable( connection, this );
				Fill();
			}
		}
		/// <summary>
		/// Creates a table with a prefix and a name, deault columns name_id and name_name
		/// </summary>
		/// <param name="prefix">Prefix to prepend to the table name (not column names)</param>
		/// <param name="name">Table name to create and fill</param>
		/// <param name="add_default_columns">Option to add default _id and _name column</param>
		/// <param name="auto_fill">Option to auto create/fill table with data</param>
		public MySQLDataTable( string prefix, string name, bool trim_info, bool auto_fill )
		{
			this.TableName = name;
			this.Prefix = ( prefix == null ) ? "" : prefix;
			Init();
			AddDefaultColumns( trim_info );
			if( auto_fill )
			{
				DsnSQLUtil.CreateDataTable( connection, this );
				Fill();
			}
		}
		/// <summary>
		/// Creates a table with a prefix and a name, deault columns name_id and name_name
		/// </summary>
		/// <param name="prefix">Prefix to prepend to the table name (not column names)</param>
		/// <param name="name">Table name to create and fill</param>
		/// <param name="add_default_columns">Option to add default _id and _name column</param>
		/// <param name="auto_fill">Option to auto create/fill table with data</param>
		public MySQLDataTable(DsnConnection dsn, string prefix, string name, bool trim_info, bool auto_fill, bool add_default_name)
		{

			this.connection = dsn;
			this.TableName = name;
			this.Prefix = (prefix == null) ? "" : prefix;
			Init();
			AddDefaultColumns(trim_info, true, add_default_name);
			if (auto_fill)
			{
				DsnSQLUtil.CreateDataTable( connection, this );
				Fill();
			}
		}
		/// <summary>
		/// Creates a table with a prefix and a name, deault columns name_id and name_name
		/// </summary>
		/// <param name="prefix">Prefix to prepend to the table name (not column names)</param>
		/// <param name="name">Table name to create and fill</param>
		/// <param name="add_default_columns">Option to add default _id and _name column</param>
		/// <param name="auto_fill">Option to auto create/fill table with data</param>
		public MySQLDataTable(DsnConnection dsn, string prefix, string name, bool trim_info, bool auto_fill, bool add_default_name, bool add_default_id)
		{

			this.connection = dsn;
			this.TableName = name;
			this.Prefix = (prefix == null) ? "" : prefix;
			Init();
			AddDefaultColumns(trim_info, add_default_id, add_default_name);
			if (auto_fill)
			{
				DsnSQLUtil.CreateDataTable( connection, this );
				Fill();
			}
		}
		/// <summary>
		/// Creates a table with a prefix and a name, deault columns name_id and name_name
		/// </summary>
		/// <param name="prefix">Prefix to prepend to the table name (not column names)</param>
		/// <param name="name">Table name to create and fill</param>
		public MySQLDataTable( string name, bool auto_fill )
		{
			this.TableName = name;
			Init();
			AddDefaultColumns( false );
			if( auto_fill )
			{
				DsnSQLUtil.CreateDataTable( connection, this );
				Fill();
			}
		}
		/// <summary>
		/// Creates a table with a prefix and a name, deault columns name_id and name_name
		/// </summary>
		/// <param name="prefix">Prefix to prepend to the table name (not column names)</param>
		/// <param name="name">Table name to create and fill</param>
		/// <param name="strip_info_on_id">True to remove trailing _info from tablename for id column</param>
		public MySQLDataTable( string name, bool auto_fill, bool strip_info_on_id )
		{
			this.TableName = name;
			Init();
			AddDefaultColumns( strip_info_on_id );
			if( auto_fill )
			{
				DsnSQLUtil.CreateDataTable( connection, this );
				Fill();
			}
		}
		/// <summary>
		/// Creates a table with the name, a auto increment column name_id, and a name column name_name
		/// </summary>
		/// <param name="name">Name of the table to create and fill</param>
		public MySQLDataTable( string name )
		{
			this.TableName = name;
			Init();
			AddDefaultColumns( false );
			DsnSQLUtil.CreateDataTable( connection, this );
			Fill();
		}

		/// <summary>
		/// Just a normal DataTable with additional Methods?
		/// </summary>
		public MySQLDataTable( DsnConnection connection )
		{
			this.connection = connection;
			Init();
		}
		/// <summary>
		/// Just a normal DataTable with additional Methods?
		/// </summary>
		public MySQLDataTable( DsnConnection connection, String fill_query )
			: base()
		{
			this.connection = connection;

			Init();
			Fill( fill_query, 0 );
		}
#endif
		/// <summary>
		/// Just a normal DataTable with additional Methods?
		/// </summary>
		public MySQLDataTable()
		{
			Init();
		}

		/// <summary>
		/// Select * from table of same name as data table.
		/// </summary>
		/// <param name="filter">Condition to limit results to fill with</param>
		public void Fill( string filter )
		{
			DsnSQLUtil.FillDataTable( connection, this, filter ); 
		}
		/// <summary>
		/// Select * from table of same name as data table.
		/// </summary>
		/// <param name="filter">Condition to limit results to fill with</param>
		public void Fill( string filter, string order )
		{
			DsnSQLUtil.FillDataTable( connection, this, filter, order );
		}
		/// <summary>
		/// Select * from table of same name as data table.
		/// </summary>
		/// <param name="filter">Condition to limit results to fill with</param>
		public void Fill(string full_sql, int unused_but_makes_different_param_sig)
		{
			DsnSQLUtil.FillDataTable(connection, this, full_sql, true);
		}

		public int DeleteAllRows(DsnConnection NewConnection)
		{
			int DeleteCount = 0;
			connection = NewConnection;
			switch (connection.DbMode)
			{
				case DsnConnection.ConnectionMode.Sqlite:
					connection.BeginTransaction();
					break;
			}

			foreach (DataRow row in Rows)
			{
				if (DoDeleteRow(row))
					DeleteCount++;
			}

			switch (connection.DbMode)
			{
				case DsnConnection.ConnectionMode.Sqlite:
					connection.EndTransaction( );;
					break;
			}
			return DeleteCount;
		}

		public int InsertAllRows(DsnConnection NewConnection)
		{
			int InsertCount = 0;
			connection = NewConnection;
			switch (connection.DbMode)
			{
				case DsnConnection.ConnectionMode.Sqlite:
					connection.BeginTransaction();
					break;
			}

			foreach (DataRow row in Rows)
			{
				if (DoInsertRow(row))
					InsertCount++;
			}

			switch (connection.DbMode)
			{
				case DsnConnection.ConnectionMode.Sqlite:
					connection.EndTransaction();
					break;
			}
			return InsertCount;
		}

		public int InsertAllRows(DsnConnection NewConnection, int LocationId)
		{
			int InsertCount = 0;
			connection = NewConnection;
			switch (connection.DbMode)
			{
				case DsnConnection.ConnectionMode.Sqlite:
					connection.BeginTransaction();
					break;
			}

			foreach (DataRow row in Rows)
			{
				if (DoInsertRow(row, LocationId))
					InsertCount++;
			}

			switch (connection.DbMode)
			{
				case DsnConnection.ConnectionMode.Sqlite:
					connection.EndTransaction();
					break;
			}
			return InsertCount;
		}

		/// <summary>
		/// method to select distinct values from a DataTable
		/// </summary>
		/// <param name="field">the column we are searching in</param>
		/// <returns>DataTable with the distinct values</returns>
		public DataTable GetDistinct(string field,string filter)
		{
			//new DataTable to hold the distinct values
			DataTable newDT = new DataTable(this.TableName);

			//add a new column to the DataTable (column we are searching in)
			newDT.Columns.Add(field, this.Columns[field].DataType);

			//get an array of DataRows that match the search criteria
			DataRow[] Selectedrows = this.Select(filter, field);

			object value = null;

			//loop through all the rows
			foreach (DataRow row in Selectedrows)
			{
				if (value == null || !(AreEqual(value, row[field])))
				{
					value = row[field];
					newDT.Rows.Add(new object[] { value });
				}
			}
			return newDT;
		}

		/// <summary>
		/// method to compare two objects to see if they are equal (also handles DBNull.Value values)
		/// </summary>
		/// <param name="obj1">object we're comparing to</param>
		/// <param name="obj2">object we're comparing</param>
		/// <returns></returns>
		private static bool AreEqual(object obj1, object obj2)
		{
			//both columns are DBNull.Value
			if (object.ReferenceEquals(obj1, DBNull.Value) & object.ReferenceEquals(obj2, DBNull.Value))
				return true;
			//only one column is DBNull.Value
			if (object.ReferenceEquals(obj1, DBNull.Value) | object.ReferenceEquals(obj2, DBNull.Value))
				return false;

			//if we make it this far then we just do a standard comparison
			return obj1.ToString() == obj2.ToString();
		}

		void InsertAllRows()
		{
			DsnSQLUtil.InsertAllRows( connection, this );
		}

		new internal void AppendToDatabase()
		{
			MySQLDataTable.AppendToDatabase( connection, this );
		}

		static public void AppendToDatabase( DsnConnection connection, DataTable table )
		{
			if( connection == null )
				return;
			String PrimaryKeyName = XDataTable.ID( table );
			IXDataTable xdataTable = table as IXDataTable;
			Type key_type = table.Columns[PrimaryKeyName].DataType;
			if( xdataTable != null )
				xdataTable.filling = true;
            Log.log( "AppendToDatabase should check primary key type - if it's Guid, then min/max are irrelavent" );
			object min_local_id = table.Compute( "min(" + PrimaryKeyName + ")", null );
			object max_local_id = table.Compute( "max(" + PrimaryKeyName + ")", null );
			// no rows to commit.
			if( min_local_id.GetType() == typeof( DBNull ) )
				return;

			if( key_type == typeof( Int32 ) )
			{
				object max_real_id = connection.ExecuteScalar( "select max(" + PrimaryKeyName + ") from "
					+ connection.sql_quote_open + table.Prefix + table.TableName + connection.sql_quote_close );
				if( ( max_real_id == null ) || ( max_real_id.GetType() == typeof( DBNull ) ) )
				{
					//
					if( Convert.ToInt32( min_local_id ) != 1 )
					{
						int n = 1;
						foreach( DataRow row in table.Rows )
						{
							row[PrimaryKeyName] = n;
							n++;
						}
					}
				}
				else
				{
					if( Convert.ToInt32( max_real_id ) >= Convert.ToInt32( min_local_id ) && Convert.ToInt32( max_real_id ) <= Convert.ToInt32( max_local_id ) )
					{
						int final_id = Convert.ToInt32( max_real_id ) + table.Rows.Count + 1;
						if( final_id < Convert.ToInt32( max_local_id ) )
						{
							int n = Convert.ToInt32( max_real_id ) + 1;
							// while moving row ID's we may duplicate, so... look ahead...
							foreach( DataRow row in table.Rows )
							{
								DataRow[] conflict = table.Select( PrimaryKeyName + "=" + n );
								if( conflict.Length > 0 )
								{
									int old_id = Convert.ToInt32( row[PrimaryKeyName] );
									conflict[0][PrimaryKeyName] = 0;
									row[PrimaryKeyName] = n;
									conflict[0][PrimaryKeyName] = old_id;
								}
								else
									row[PrimaryKeyName] = n;
								n++;
							}


							//object o = null;
							//o.GetType();
						}
						else
						{
							int r;
							for( r = table.Rows.Count - 1; r >= 0; r-- )
							{
								table.Rows[r][PrimaryKeyName] = final_id;
								final_id--;
							}
						}
					}
					else
					{
						int n = Convert.ToInt32( max_real_id ) + 1;
						foreach( DataRow row in table.Rows )
						{
							row[PrimaryKeyName] = n;
							n++;
						}
					}
				}
			}
			else if( key_type == typeof( Guid ) )
			{
				foreach( DataRow row in table.Rows )
				{
					row[PrimaryKeyName] = connection.GetGUID();
				}
			}
			DsnSQLUtil.InsertAllRows( connection, table );
			if( xdataTable != null )
				xdataTable.filling = false;
		}


		/// <summary>
		/// Zero parameter to pass a null as the filter string to Fill(filter)
		/// </summary>
		public void Fill()
		{
			DsnSQLUtil.FillDataTable( connection, this, null, null ); 
		}

		public bool DoDeleteRow(DataRow row)
		{
			return DsnSQLUtil.DoDeleteRow(connection, this, row);
		}
		public bool DoInsertRow(DataRow row, int LocationId)
		{
			return DsnSQLUtil.DoInsertRow(connection, this, row, LocationId);
		}

		public bool DoInsertRow(DataRow row )
		{
            return DsnSQLUtil.DoInsertRow( connection, this, row );
        }

#if use_p2p_events
        internal void GenerateTrigger( string event_name )
        {
            self_triggered = true;
			if( transmit == null )
			{
				transmit = xperdex.classes.UpdateService.EventAnnouncer.StartReceiving<MySQLDataTable, IEventNotice>( this
						, "MySQL.data.table"
						, FullTableName
						, "generic" );
			}
            transmit.Trigger( event_name, FullTableName, null );
        }
#endif

		public static string GetRelationName( String first, String second )
		{
			return StripPlural( StripInfo( first ) ) + "_" + StripPlural( StripInfo( second ) );
		}
		public static string GetRelationName( DataTable first, DataTable second )
		{
			return GetRelationName( first.TableName, second.TableName );
		}


		public static string GetCompleteTableName( DataTable table )
		{
			String name = null;
			if( table.DataSet != null && table.DataSet.Prefix != null )
			{
				foreach( Attribute attr in table.GetType().GetCustomAttributes( true ) )
				{
					//Log.log( "Checking " + attr.ToString() + " in " + e.Element.ToString() );
					SQLPersistantTable persist = attr as SQLPersistantTable;
					if( null != persist )
					{
						name = table.DataSet.Prefix;
					}
				}
			}
			if( table.Prefix != null )
				name += table.Prefix;
			name += table.TableName;
			return name;
		}

		public string CompleteTableName
		{
			get
			{
				return GetCompleteTableName( this );
			}
		}

		public DsnConnection _myConnection
		{
			get
			{
				return connection;
			}
		}

		public void SetConnection( DsnConnection dsn, bool auto_create )
		{
			if( connection == null )
			{
				connection = dsn;
				if( dsn != null )
					if( auto_create )
						DsnSQLUtil.CreateDataTable( connection, this );
			}
			else
			{
				connection = dsn;
				if( auto_create )
					DsnSQLUtil.CreateDataTable( connection, this );
			}
		}

		protected virtual void SelectCommand( string SelectQuery )
		{
			this.Clear();
			Fill( SelectQuery, 0 );
		}

		/// <summary>
		/// Get from the Database the Table structure // Too Many records to Load All Table
		/// </summary>
		public virtual void SelectCondition( string condition )
		{
			if( condition != null && condition != "" )
				condition = " WHERE " + condition;
			string selectComm = "SELECT * FROM " + CompleteTableName + condition;
			SelectCommand( selectComm );
		}

		/// <summary>
		/// Re-Assembly Select Command and Fill the DataTable
		/// </summary>
		public virtual void SelectCondition()
		{
			SelectAll();
		}

		/// <summary>
		/// Get from the Database the Table structure // Too Many records to Load All Table
		/// </summary>
		/// <param name="condition">where clause of select</param>
		/// <param name="order">what to order by</param>
		public virtual void SelectCondition( string condition, string order )
		{
			if( condition != null && condition != "" )
				condition = " WHERE " + condition;
			if( order != null && order != "" )
				order = " ORDER BY " + order;
			string selectComm = "SELECT * FROM " + CompleteTableName + condition + order;
			SelectCommand( selectComm );
		}

		protected virtual void SelectAll()
		{
			string selectComm = "SELECT * FROM " + CompleteTableName;
			SelectCommand( selectComm );
		}

		/// <summary>
		/// Just a wrapper for Create() and Fill().
		/// </summary>
		public void LoadMySQLDataTable()
		{
			DsnSQLUtil.CreateDataTable( connection, this );
			Fill();
		}


#if use_p2p_events
		public delegate void FormUpdateMethod( DataTable table );
        public event FormUpdateMethod FormReloadTable;

		public void Trigger( String Event, String TableName, String Column )
		{
            if ( this.FullTableName == TableName )
            {
                if ( self_triggered )
                {
                    self_triggered = false;
                    Log.log( "Ignoring self triggered event." );
                    return;
                }
                else
                    Log.log( this.TableName + " Received notice " + Event + " On " + TableName + " . " + Column );
                switch ( Event )
                {
                    case "Table Updated":
                        if ( FormReloadTable != null )
                            FormReloadTable( this );
                        else
                            DsnSQLUtil.ReloadTable( connection, this );
                        break;
                }
            }
            else
            {
                Log.log( "Still a wasted event notice." );
            }
			// get the image
		}
#endif

        //static IEventNotice _transmit;
        //static public IEventNotice transmit
        //{
        //			get
        //			{
        //				return _transmit;
        //			}
        //
        //	}

#if asdfasdf
		//internal bool suspended;
		/// <summary>
		/// Turns off live, and turns on suspend.  Later, Accept changes will resume 'live' flag if it was 'suspended'
		/// </summary>
		protected void SuspendChanges()
		{
			suspended = true;
			//live = false;
		}
#endif

        public void CommitChanges()
		{
			DsnSQLUtil.CommitChanges( connection, this );
		}

		public static string MakeDate( DateTime bingoday )
		{
			return DsnSQLUtil.MakeDate( null, bingoday ).ToString();
		}
	}

	public class MySQLPersistantTable : SQLPersistantTable
	{

	}

	public class SQLPersistantTable : Attribute
	{
		string method = "Complete";
		/// <summary>
		/// how to fill - default is "Complete", option is "None" which is used for PatternData (patterns require extra work to load information)
		/// </summary>
		public string FillMethod
		{
			get { return method; }
			set { method = value; }
		}
		string initial_fill = null;
		/// <summary>
		/// This specifies a method (public void ()) that is called when there is no data in the table; allows building defaults.
		/// </summary>
		public string DefaultFill
		{
			get { return initial_fill; }
			set { initial_fill = value; }
		}
		string fill_condition = null;
		/// <summary>
		/// Badly named thing, this is the method to use to fill if the fill method condition worked?
		/// </summary>
		public string Fill
		{
			get { return fill_condition; }
			set { fill_condition = value; }
		}

		public SQLPersistantTable()
		{
		}

	}

#if use_p2p_events
	[ServiceContract]
	public interface IEventNotice
	{
		[OperationContract( IsOneWay = true )]
		void Trigger( String opearation, String TableName, String Column );
	}
#endif

	public class MySQLDataTable : MySQLDataTable<DataRow>
	{
		static internal object event_lock = new object();

		public MySQLDataTable( string prefix, string name )
			: base( null, prefix, name )
		{
		}
		public MySQLDataTable( DsnConnection dsn, DataTable table )
			: base( dsn, table )
		{
		}
		/// <summary>
		/// Creates a table with a prefix and a name, deault columns name_id and name_name
		/// </summary>
		/// <param name="prefix">Prefix to prepend to the table name (not column names)</param>
		/// <param name="name">Table name to create and fill</param>
		/// <param name="auto_fill">Option to auto create/fill table with data</param>
		public MySQLDataTable( string prefix, string name, bool auto_fill )
			: base( null, prefix, name, auto_fill )
		{
		}

				/// <summary>
		/// Creates a table with a prefix and a name, deault columns name_id and name_name
		/// </summary>
		/// <param name="prefix">Prefix to prepend to the table name (not column names)</param>
		/// <param name="name">Table name to create and fill</param>
		/// <param name="add_default_columns">Option to add default _id and _name column</param>
		/// <param name="auto_fill">Option to auto create/fill table with data</param>
		public MySQLDataTable( string prefix, string name, bool trim_info, bool auto_fill )
			: base( null, prefix, name, trim_info, auto_fill )
		{
		}
		/// <summary>
		/// Creates a table with a prefix and a name, deault columns name_id and name_name
		/// </summary>
		/// <param name="prefix">Prefix to prepend to the table name (not column names)</param>
		/// <param name="name">Table name to create and fill</param>
		/// <param name="add_default_columns">Option to add default _id and _name column</param>
		/// <param name="auto_fill">Option to auto create/fill table with data</param>
		public MySQLDataTable( DsnConnection dsn, string prefix, string name, bool trim_info, bool auto_fill )
			: base( dsn, prefix, name, trim_info, auto_fill )
		{
		}
		/// <summary>
		/// Creates a table with a prefix and a name, deault columns name_id and name_name
		/// </summary>
		/// <param name="prefix">Prefix to prepend to the table name (not column names)</param>
		/// <param name="name">Table name to create and fill</param>
		/// <param name="add_default_columns">Option to add default _id and _name column</param>
		/// <param name="auto_fill">Option to auto create/fill table with data</param>
		public MySQLDataTable(DsnConnection dsn, string prefix, string name, bool trim_info, bool auto_fill, bool add_default_name)
			: base( dsn, prefix, name, trim_info, auto_fill, add_default_name )
		{
		}
		/// <summary>
		/// Creates a table with a prefix and a name, deault columns name_id and name_name
		/// </summary>
		/// <param name="prefix">Prefix to prepend to the table name (not column names)</param>
		/// <param name="name">Table name to create and fill</param>
		/// <param name="add_default_columns">Option to add default _id and _name column</param>
		/// <param name="auto_fill">Option to auto create/fill table with data</param>
		public MySQLDataTable(DsnConnection dsn, string prefix, string name, bool trim_info, bool auto_fill, bool add_default_name, bool add_default_id)
			: base( dsn, prefix, name, trim_info, auto_fill, auto_fill, add_default_id )
		{
		}
		/// <summary>
		/// Creates a table with a prefix and a name, deault columns name_id and name_name
		/// </summary>
		/// <param name="prefix">Prefix to prepend to the table name (not column names)</param>
		/// <param name="name">Table name to create and fill</param>
		public MySQLDataTable( string name, bool auto_fill )
			: base( null, null, name, true, true, auto_fill )
		{
		}
		/// <summary>
		/// Creates a table with a prefix and a name, deault columns name_id and name_name
		/// </summary>
		/// <param name="prefix">Prefix to prepend to the table name (not column names)</param>
		/// <param name="name">Table name to create and fill</param>
		/// <param name="strip_info_on_id">True to remove trailing _info from tablename for id column</param>
		public MySQLDataTable( string name, bool auto_fill, bool strip_info_on_id )
			: base( null, null, name, true, strip_info_on_id, auto_fill )
		{
		}
		/// <summary>
		/// Creates a table with the name, a auto increment column name_id, and a name column name_name
		/// </summary>
		/// <param name="name">Name of the table to create and fill</param>
		public MySQLDataTable( string name )
			: base( null, null, name )
		{
		}
		/// <summary>
		/// Just a normal DataTable with additional Methods?
		/// </summary>
		public MySQLDataTable()
			: base()
		{
		}

		/// <summary>
		/// Just a normal DataTable with additional Methods?
		/// </summary>
		public MySQLDataTable( DsnConnection connection )
			: base( connection )
		{
		}
		/// <summary>
		/// Just a normal DataTable with additional Methods?
		/// </summary>
		public MySQLDataTable( DsnConnection connection, String fill_query )
			: base( connection, null, null, false, false, true, false, fill_query )
		{
		}

	}


}
