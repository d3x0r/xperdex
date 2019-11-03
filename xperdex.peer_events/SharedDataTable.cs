//#define use_p2p_events
//#define fix_by_delete
#if use_p2p_events
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Odbc;
using System.Data.Common;
#if use_p2p_events
using System.ServiceModel;
using xperdex.classes.UpdateService;
using System.ServiceModel.Dispatcher;
using xperdex.classes.UpdateService;
#endif
using System.Reflection;
using System.Collections;
using xperdex.classes;

namespace xperdex.peer_event
{
#if use_p2p_events
	[ServiceBehavior( InstanceContextMode = InstanceContextMode.Single )]
#endif
	public class SharedDataTable : XDataTable
#if use_p2p_events
        , EventAnnouncer.IEventNotice, IDispatchMessageInspector, IClientMessageInspector
#endif
	{
		/// <summary>
		/// boolean to reflect whether the create table in the database sync has been done... used when adding foriegn keys - may be able to wait until table is created and generate as proper create statement without alter.
		/// </summary>
		public bool Created;
		/// <summary>
		/// Should implement the idea of lazy loading, so the entire tree of a complex structure is not loaded.
		/// Can load relavent tables as they are required....
		/// </summary>
		public bool filled = false;
#if use_p2p_events
		IEventNotice transmit;
#endif
		~SharedDataTable()
		{
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
			if( String.Compare( s, s.Length - 3, "ies", 0, 3 ) == 0 )
				return s.Substring( 0, s.Length - 1 ) + "y";
			if( s[s.Length - 1] == 's' )
				return s.Substring( 0, s.Length - 1 );
			return s;
		}


		void ReloadTable()
		{
			Log.log( "Handle Reloading the table... the database changed, and we have notice that we might want to reload." );
		}

		void Init()
		{
#if use_p2p_events
			transmit = xperdex.classes.UpdateService.EventAnnouncer.StartReceiving<MySQLDataTable, IEventNotice>( this );
#endif
			//this.RowChanged += new DataRowChangeEventHandler( MySQLDataTable_RowChanged );
			//this.ColumnChanging += new DataColumnChangeEventHandler( MySQLDataTable_ColumnChanged );
			this.RowDeleting += new DataRowChangeEventHandler( MySQLDataTable_RowDeleting );
		}

		void DoDelete( DataRow dataRow )
		{
			// should be clever about this...
			if( PrimaryKey != null && PrimaryKey.Length > 0 )
			{
				DeleteRow( dataRow[PrimaryKey[0].ColumnName] );
			}
			else
			{
				Delete( dataRow );
			}
		}
		void MySQLDataTable_RowDeleting( object sender, DataRowChangeEventArgs e )
		{
			//if( !live )
			//	return;
			//DoDelete( e.Row );
		}

		public static long MakeDate( DateTime dt )
		{
			return ( dt.Year * 10000000000 + dt.Month * 100000000 + dt.Day * 1000000 + dt.Hour * 10000 + dt.Minute * 100 + dt.Second );
		}
		public static long MakeDateOnly( DateTime dt )
		{
			return ( dt.Year * 10000 + dt.Month * 100 + dt.Day * 1 );
		}
		public static long MakeTimeOnly( DateTime dt )
		{
			return ( dt.Hour * 10000 + dt.Minute * 100 + dt.Second * 1 );
		}



		public static bool Compare( Type type, object a, object b )
		{
			if( ( a.GetType() == typeof( DBNull ) ) && ( b.GetType() == typeof( DBNull ) ) )
				return true;
			if( type == typeof( int ) )
			{
				if( b.GetType() == typeof( DBNull ) )
					return false;
				if( a.GetType() == typeof( DBNull ) )
					return false;
				if( Convert.ToInt32( a ) == Convert.ToInt32( b ) )
					return true;
				return false;
			}
			if( type == typeof( Int16 ) )
			{
				if( b.GetType() == typeof( DBNull ) )
					return false;
				if( a.GetType() == typeof( DBNull ) )
					return false;
				if( Convert.ToInt16( a ) == Convert.ToInt16( b ) )
					return true;
				return false;
			}
			if( type == typeof( string ) || type == typeof( Money ) || type == typeof( DateTime ) )
			{
				if( String.Compare( a.ToString(), b.ToString() ) == 0 )
					return true;
				return false;
			}
			if( type == typeof( bool ) )
			{
				if( a.GetType() == typeof( DBNull ) )
					return false;
				if( b.GetType() == typeof( DBNull ) )
					return false;
				if( Convert.ToBoolean( a ) == Convert.ToBoolean( b ) )
					return true;
				return false;
			}
			throw new Exception( "Possibly unchecked comparison..." );
		}

		bool DoUpdateCommand( DataRow Row )
		{
			object keyval = null;
			List<DataColumn> modified_columns = new List<DataColumn>();

			if( Row.HasVersion( DataRowVersion.Original ) && Row.HasVersion( DataRowVersion.Current ) )
			{
				bool first = true;
				//DataColumn auto = null;
				foreach( DataColumn col in Columns )
				{
					object a, b;
					try
					{
						a = Row[col.ColumnName, DataRowVersion.Original];
						b = Row[col.ColumnName, DataRowVersion.Current];
					}
					catch( Exception e )
					{
						Log.log( e.Message );
						continue;

					}
					if( !Compare( col.DataType, a, b ) )
					{
						// this was to get the PrimaryKey definition... it's better now.
						if( col.AutoIncrement )
							keyval = a;
						//	auto = col;
						//else
						{
							if( !col.ReadOnly )
							{
								if( Row[col.Ordinal].GetType() == typeof( DBNull ) )
								{
									if( !first )
										updateComm += ",";
									first = false;
									modified_columns.Add( col );
									updateComm += col.ColumnName + "=NULL";
								}
								else if( ( Row[col.Ordinal].ToString() == "" && ( col.DataType == typeof( string ) || col.DataType == typeof( DateTime ) ) )
									|| Row[col.Ordinal].ToString() != ""
									|| col.DefaultValue.ToString() != "" )
								{
									if( !first )
										updateComm += ",";
									first = false;
									modified_columns.Add( col );
									updateComm += col.ColumnName + "=";
									updateComm += GetSQLValue( col.DataType, Row[col.Ordinal] );// RegSQLDataTable.GetRowValue( col, Row );
								}
							}
						}
					}
				}
			}
			else
			{
				bool first = true;
				DataColumn auto = null;
				foreach( DataColumn col in Columns )
				{
					if( col.AutoIncrement )
						auto = col;
					else
					{
						if( !col.ReadOnly )
						{
							updateComm += ( !first ) ? "," : "";
							first = false;
							modified_columns.Add( col );
							updateComm += connection.sql_quote_open + col.ColumnName + connection.sql_quote_close + "=";
							updateComm += GetSQLValue( col.DataType, Row[col.Ordinal] );
						}
					}
				}
			}
			if( modified_columns.Count > 0 )
			{
				if( PrimaryKey.Length > 0 )
				{
					bool first = true;
					updateComm += " WHERE ";
					foreach( DataColumn keycol in PrimaryKey )
					{
						if( !first )
							updateComm += " and ";
						if( Row[keycol.Ordinal].GetType() != typeof( DBNull ) 
							
							)
						{
							first = false;
							updateComm += connection.sql_quote_open + keycol.ColumnName + connection.sql_quote_close + "=" + GetSQLValue( keycol.DataType, ( keyval == null ) ? Row[keycol.Ordinal] : keyval );
						}
					}
					connection.KindExecuteNonQuery( updateComm, 2, null );
				}
				else
				{
					bool first = true;
					updateComm += " WHERE ";
					for( int i = 0; i < Row.ItemArray.Length; i++ )
					{
						if( Row[i] == null || Row[i,DataRowVersion.Original].GetType() == typeof( DBNull ) )
							continue;
						//if( Row[i].GetType() != typeof( DBNull ) )
						{
							if( !first )
								updateComm += " and ";
							first = false;
							updateComm += connection.sql_quote_open + Row.Table.Columns[i].ColumnName + connection.sql_quote_close + "=" + GetSQLValue( Row[i].GetType(), Row[i, DataRowVersion.Original] );
						}
					}
					connection.KindExecuteNonQuery( updateComm, 2, null );
				}
				return true;
			}
			return false;
		}

		public String GetSQLValue( Type t, object o )
		{
			if( t == typeof( string ) )
				return connection.sql_value_quote_open + Escape( o.ToString() ) + connection.sql_value_quote_close;
			if (t == typeof(int)|| t == typeof( Int64 ) )
			{
				if (o.ToString().Length == 0)
					return "0";
				return o.ToString();
			}
			if( t == typeof( DateTime ) )
				return MakeDate(Convert.ToDateTime(o)).ToString();
			if( t == typeof( bool ) )
				return ( ( ( o.GetType() != typeof( DBNull) ) && (bool)o ) ? "1":"0" );
			if (t == typeof( Money ))
			{
				long MoneyAux = (Money)o;
				return MoneyAux.ToString();
			}
			if( t == typeof( System.Drawing.Color ) )
			{
				return ( (System.Drawing.Color)o ).ToArgb().ToString();
			}
			return o.ToString();
		}

        public String GetSQLValue( DataColumn dc, object o )
        {
            return MySQLDataTable.GetSQLValue( connection, dc, o );
        }
		public static String GetSQLValue( DsnConnection connection, DataColumn dc, object o )
		{
			if( dc.DataType == typeof( string ) )
                return connection.sql_value_quote_open + MySQLDataTable.Escape( connection, o.ToString() ) + connection.sql_value_quote_close;
			if( dc.DataType == typeof( int ) || dc.DataType == typeof( Int64 ) )
			{
				if( o.ToString().Length == 0 )
					return "0";
				return o.ToString();
			}
			if( dc.DataType == typeof( DateTime ) )
			{
                object o_type = dc.ExtendedProperties["Extra Type"];
                string extra_type_info = ( o_type == null ? "" : o_type.ToString() );
                if( extra_type_info != "" )
                {
                    if( extra_type_info == "date" )
                        return MakeDateOnly( Convert.ToDateTime( o ) ).ToString();
                    else
                        if( extra_type_info == "time" )
                            return MakeTimeOnly( Convert.ToDateTime( o ) ).ToString();
                        else
                            if( extra_type_info == "createstamp" )
                                return "should have already skipped this.";
                            else
                                return MakeDate( Convert.ToDateTime( o ) ).ToString();
                }
                else
                {
                    if( dc.Namespace == "date" )
                        return MakeDateOnly( Convert.ToDateTime( o ) ).ToString();
                    else
                        if( dc.Namespace == "time" )
                            return MakeTimeOnly( Convert.ToDateTime( o ) ).ToString();
                        else
                            if( dc.Namespace == "createstamp" )
                                return "should have already skipped this.";
                            else
                                return MakeDate( Convert.ToDateTime( o ) ).ToString();
                }
			}
			else if( dc.DataType == typeof( bool ) )
				return ( ( ( o.GetType() != typeof( DBNull ) ) && (bool)o ) ? "1" : "0" );
			if( dc.DataType == typeof( Money ) )
			{
				long MoneyAux = (Money)o;
				return MoneyAux.ToString();
			}
			if( dc.DataType == typeof( System.Drawing.Color ) )
			{
				return ( (System.Drawing.Color)o ).ToArgb().ToString();
			}
			return o.ToString();
		}



		void MySQLDataTable_ColumnChanged( object sender, DataColumnChangeEventArgs e )
		{
			if( !live )
				return;
			// filling the table with initial data causes update events...
			if( filling )
				return;
			// can't update until it's inserted into a table...
			if( e.Row.RowState == DataRowState.Detached )
				return;

            bool updated = false;
            if( !Compare( e.Column.DataType, e.ProposedValue, e.Row[e.Column.Ordinal] ) )
            {
                DataColumn keycol = PrimaryKey[0];
                if( keycol == null )
                    keycol = Columns[0];
                    //changes = this.GetChanges( DataRowState.Modified );
                    // update statment....
                    string cmd = "update " + Prefix + TableName
                            + " set " + Columns[e.Column.Ordinal].ColumnName + "="
                        + GetSQLValue( e.Column.DataType, e.ProposedValue )
                        + " where " + keycol.ColumnName + "="
                        + ( ( e.Row[keycol.Ordinal].GetType() == typeof( string ) ) ? connection.sql_quote_open : "" )
                        + ( ( e.Row[keycol.Ordinal].GetType() == typeof( int ) )
                                ?e.Row[keycol.Ordinal].ToString().Length==0
                                        ?"0"
                                        :e.Row[keycol.Ordinal].ToString() 
                                :e.Row[keycol.Ordinal].ToString() )
                        + ( ( e.Row[keycol.Ordinal].GetType() == typeof( string ) ) ? connection.sql_quote_close : "" )
                        ;
                    updated = true;				
                    //connection.KindExecuteNonQuery( cmd, 1 );
                    //e.Row.AcceptChanges();
            }
#if use_p2p_events
			if( updated && transmit != null )
			{
				Log.log( "Notifying..." );
				transmit.Trigger( "Updated Table!", TableName, e.Column.ColumnName );
			}
#endif
            //throw new Exception( "The method or operation is not implemented." );
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
		/// <summary>
		/// This is the thing that actually adds the default TableName_id and TableName_name
		/// </summary>
		/// <param name="trim_info">Option to trim _info and _description</param>
		public void AddDefaultColumns( bool trim_info, bool add_auto_id, bool add_auto_name )
		{
			if( add_auto_id )
			{
				DataColumn dc = this.Columns.Add( ID(this), typeof( int ) );
				dc.AutoIncrement = true;
				if( connection != null )
				{
					try
					{
						object seed = connection.ExecuteScalar( "select max(" + dc.ColumnName + ") from " + connection.sql_quote_open + FullTableName + connection.sql_quote_close );
						if( seed == DBNull.Value )
							dc.AutoIncrementSeed = 1;
						else
							dc.AutoIncrementSeed = Convert.ToInt64( seed ) + 1;
					}
					catch
					{
						dc.AutoIncrementSeed = 1;
					}
				}
				else
					dc.AutoIncrementSeed = 1;
				(this as DataTable).PrimaryKey = new DataColumn[] { dc };
			}
			if( add_auto_name )
			{
				this.Columns.Add( Name( this ), typeof( string ) ).Unique = true;
			}
		}
		
		/// <summary>
		/// Creates a table with a prefix and a name, deault columns name_id and name_name
		/// </summary>
		/// <param name="prefix">Prefix to prepend to the table name (not column names)</param>
		/// <param name="name">Table name to create and fill</param>
		public SharedDataTable( string prefix, string name )
		{
			this.TableName = name;
			this.Prefix = (prefix == null)?"":prefix;
			Init();
			AddDefaultColumns( false );
			Create();
			Fill();
		}
		public SharedDataTable( DsnConnection dsn, XDataTable table )
		{
			// copy table into myself...
			connection = dsn;
			TableName = table.TableName;
			Prefix = table.Prefix;
			foreach( DataColumn dc in table.Columns )
				Columns.Add( dc );
			MatchCreate( null, false );
		}
		/// <summary>
		/// Creates a table with a prefix and a name, deault columns name_id and name_name
		/// </summary>
		/// <param name="prefix">Prefix to prepend to the table name (not column names)</param>
		/// <param name="name">Table name to create and fill</param>
		/// <param name="auto_fill">Option to auto create/fill table with data</param>
		public SharedDataTable( string prefix, string name, bool auto_fill )
		{
			this.TableName = name;
			this.Prefix = ( prefix == null ) ? "" : prefix;
			Init();
			AddDefaultColumns( true );
			if( auto_fill )
			{
				Create();
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
		public SharedDataTable( string prefix, string name, bool trim_info, bool auto_fill )
		{
			this.TableName = name;
			this.Prefix = ( prefix == null ) ? "" : prefix;
			Init();
			AddDefaultColumns( trim_info );
			if( auto_fill )
			{
				Create();
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
		public SharedDataTable( DsnConnection dsn, string prefix, string name, bool trim_info, bool auto_fill )
		{
			this.connection = dsn;
			this.TableName = name;
			this.Prefix = ( prefix == null ) ? "" : prefix;
			Init();
			AddDefaultColumns( trim_info );
			if( auto_fill )
			{
				Create();
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
		public SharedDataTable(DsnConnection dsn, string prefix, string name, bool trim_info, bool auto_fill, bool add_default_name)
		{

			this.connection = dsn;
			this.TableName = name;
			this.Prefix = (prefix == null) ? "" : prefix;
			Init();
			AddDefaultColumns(trim_info, true, add_default_name);
			if (auto_fill)
			{
				Create();
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
		public SharedDataTable(DsnConnection dsn, string prefix, string name, bool trim_info, bool auto_fill, bool add_default_name, bool add_default_id)
		{

			this.connection = dsn;
			this.TableName = name;
			this.Prefix = (prefix == null) ? "" : prefix;
			Init();
			AddDefaultColumns(trim_info, add_default_id, add_default_name);
			if (auto_fill)
			{
				Create();
				Fill();
			}
		}
		/// <summary>
		/// Creates a table with a prefix and a name, deault columns name_id and name_name
		/// </summary>
		/// <param name="prefix">Prefix to prepend to the table name (not column names)</param>
		/// <param name="name">Table name to create and fill</param>
		public SharedDataTable( string name, bool auto_fill )
		{
			this.TableName = name;
			//this.Prefix = ( prefix == null ) ? "" : prefix;
			Init();
			AddDefaultColumns( false );
			if( auto_fill )
			{
				Create();
				Fill();
			}
		}
		/// <summary>
		/// Creates a table with a prefix and a name, deault columns name_id and name_name
		/// </summary>
		/// <param name="prefix">Prefix to prepend to the table name (not column names)</param>
		/// <param name="name">Table name to create and fill</param>
		/// <param name="strip_info_on_id">True to remove trailing _info from tablename for id column</param>
		public SharedDataTable( string name, bool auto_fill, bool strip_info_on_id )
		{
			this.TableName = name;
			//this.Prefix = ( prefix == null ) ? "" : prefix;
			Init();
			AddDefaultColumns( strip_info_on_id );
			if( auto_fill )
			{
				Create();
				Fill();
			}
		}
		/// <summary>
		/// Creates a table with the name, a auto increment column name_id, and a name column name_name
		/// </summary>
		/// <param name="name">Name of the table to create and fill</param>
		public SharedDataTable( string name )
		{
			this.TableName = name;
			Init();
			AddDefaultColumns( false );
			Create();
			Fill();
		}

		/// <summary>
		/// Just a normal DataTable with additional Methods?
		/// </summary>
		public SharedDataTable()
			: base()
		{
			Init();
		}

		/// <summary>
		/// Just a normal DataTable with additional Methods?
		/// </summary>
		public SharedDataTable( DsnConnection connection )
			: base()
		{
			this.connection = connection;

			Init();
		}
		/// <summary>
		/// Just a normal DataTable with additional Methods?
		/// </summary>
		public SharedDataTable( DsnConnection connection, String fill_query )
			: base()
		{
			this.connection = connection;

			Init();
			Fill( fill_query, 0 );
		}
	/// <summary>
	/// Invokes a CREATE TABLE on the odbc connection for this table's current schema.
	/// </summary>
	/// <param name="odbc">Database Connection</param>
	/// <param name="extra">Extra columns added 
	/// (these are often additional keys in the MySQL dialect)</param>
		public void Create( DsnConnection odbc, string extra, bool delete, bool delete_cols )
		{
			if( odbc != null && odbc.State != ConnectionState.Closed )
			{
				StringBuilder keys = new StringBuilder();
				StringBuilder sb = new StringBuilder();
				//string columns = null;

				if( delete )
				{
					try
					{
						odbc.ExecuteNonQuery( "Drop table if exists "
						+ odbc.sql_quote_open
						+ Prefix
						+ TableName
						+ odbc.sql_quote_close );
					}
					catch( Exception e )
					{
						Console.WriteLine( e );
					}
				}
				this.MatchCreate( null, delete_cols );
			}
		}
		public void Create( DsnConnection odbc, string extra, bool delete )
		{
			Create( odbc, extra, delete, false );

		}
		public void Create( string prefix, DsnConnection odbc )
		{
			Prefix = ( prefix == null ) ? "" : prefix;

			Create( odbc, null, false );
		}
		public void Create( DsnConnection odbc )
		{
			Create( odbc, null, false );
		}
		public void Create( DsnConnection odbc, bool delete )
		{
			Create( odbc, null, delete );
		}
		public void Create( string prefix, string extra )
		{
			Prefix = ( prefix == null ) ? "" : prefix;
			if( connection == null )
			{
				Log.log( "Previuosly this would default to staticDSN.... aborting table create." );
				return;
			}
			Create( connection, extra, false );
		}
		/// <summary>
		/// overridable create method for nothing...
		/// </summary>
		public virtual void Create() 
		{
			if( connection == null )
			{
				//Log.log( "this used to default to StaticDsnConnection, aborting create on disconnected table" );
				return;
			}
			Create( connection );
		}
		public virtual void Create(bool delete)
		{
			Create( connection, delete );
		}
		/// <summary>
		/// overridable create method for nothing...
		/// </summary>
		public virtual void Create( string s )
		{
			Create( s, connection );
		}

		//bool filling;
		/// <summary>
		/// Select * from table of same name as data table.
		/// </summary>
		/// <param name="filter">Condition to limit results to fill with</param>
		public void Fill( string filter )
		{
			if( connection == null )
				return;
			Fill( "select * from " + connection.sql_quote_open
				+ Prefix + TableName + connection.sql_quote_close + ( ( filter != null ) ? " where " + filter : "" ), 0 );
		}
		/// <summary>
		/// Select * from table of same name as data table.
		/// </summary>
		/// <param name="filter">Condition to limit results to fill with</param>
		public void Fill( string filter, string order )
		{
			if( connection == null )
				return;
			Fill( "select * from " + connection.sql_quote_open
				+ Prefix + TableName + connection.sql_quote_close 
				+ ( ( filter != null ) ? " where " + filter : "" )
				+ ( ( order != null ) ? " order by " + order :"" )
				, 0 );
		}
		/// <summary>
		/// Select * from table of same name as data table.
		/// </summary>
		/// <param name="filter">Condition to limit results to fill with</param>
		public void Fill( string full_sql, int unused_but_makes_different_param_sig )
		{
			if( connection == null )
				return;
			DbDataReader odr;
			filling = true;
			if( ( odr = connection.KindExecuteReader( full_sql, 2 ) ) != null )
			{
				while( odr.Read() )
				{
					DataRow dr = NewRow();
					for( int i = 0; i < odr.FieldCount; i++ )
					{
						string s = odr.GetName( i ); ;
						try
						{
							// Add JMU
							// I need to create the Column in DataTable even if the information is null

							//if( odr[i].GetType() == typeof( DBNull ) )
							//	continue;
							object o = odr[i];
                            //Log.log( "DOING COLUMN " + s );
							if( this.Columns.IndexOf( s ) < 0 )
							{
                                try
                                {
                                    this.Columns.Add( s, odr.GetFieldType( i ) );
                                }
                                catch
                                {
                                    Log.log( "Column " + s + " is not found, cannot add?" );
                                }
							}
							if( !odr.IsDBNull( i ) )
							{
								if( Columns[s].DataType == typeof( Money ) )
								{
									dr[s] = new Money( Convert.ToInt64( odr[i] ) );
								}
								else if( Columns[s].DataType == typeof( Int32 ) && o.ToString().Length == 0 )
									dr[s] = 0;
                                else if( Columns[s].DataType == typeof( System.Drawing.Color ) )
                                {
                                    try
                                    {
                                        dr[s] = System.Drawing.Color.FromArgb( Convert.ToInt32( (int)Convert.ToInt64( odr[i] )) );
                                    }
                                    catch
                                    {
                                        Log.log( "failed integer conversion" );
                                        try
                                        {
                                            dr[s] = System.Drawing.Color.FromArgb( (int)Convert.ToInt64( odr[i] ) );
                                            Log.log( " and... maybe that was ok? " );
                                        }
                                        catch( Exception e )
                                        {
                                            Log.log( e.Message );
                                        }
                                    }
                                }
                                else
                                    dr[s] = odr[i];
							}
						}
						catch( FormatException fex )
						{
							object o = odr.GetValue( i );
							{
								//byte[] buffer = new byte[256];
								//odr.GetBytes( i, 0, buffer, 0, 256 );
								//Log.log( "something" );
							}
							Log.log( "Format exception: " + fex.Message + "[" + odr[i].ToString() + "]" );
                            continue;
                        }
						catch( ArgumentException aex )
						{
							Log.log( "Argument exception: " + aex.Message );
						}
						catch( Exception ex )
						{
							this.Columns.Add( s, odr.GetFieldType( i ) );
							dr[s] = odr[i];
							Console.WriteLine( ex.Message );
						}
					}
					try
					{
						Rows.Add( dr );
					}
					catch( Exception ex )
					{																		
						Log.log( ex.Message );

//#if fix_by_delete			
						if( filling && live )
						{
							string cmd = "delete from " + FullTableName + " where ";
							bool first = true;
							if( PrimaryKey != null && PrimaryKey.Length > 0 )
							{
								/// use the primary key of the row to delete the conflict.
								//throw new Exception( "Untested." );
								for( int i = 0; i < PrimaryKey.Length; i++ )
								{
									int ord = odr.GetOrdinal( PrimaryKey[i].ColumnName );
									object o = odr[ord];
									if( odr.IsDBNull( i ) )
										continue;
									if( !first )
										cmd += " and ";
									cmd += odr.GetName( ord ) + "=" + GetSQLValue( o.GetType(), o );
									first = false;
								}
							}
							else
							{
								for( int i = 0; i < odr.FieldCount; i++ )
								{
									object o = odr[i];
									if( odr.IsDBNull( i ) )
										continue;
									if( !first )
										cmd += " and ";
									cmd += odr.GetName( i ) + "=" + GetSQLValue( o.GetType(), o );
									first = false;
								}
							}
							connection.KindExecuteNonQuery( cmd );
							Log.log( ex.Message + "{Fixed by Deleting relation.}" );
						}
//#else					 
						continue;
//#endif
					}
				}
				connection.EndReader( odr );
				// this is more of a flush out...
				AcceptChanges(); // sync base model... during filling is okay.
			}
			filling = false;
		}

		void InsertAllRows()
		{
			switch( connection.DbMode )
			{
			case DsnConnection.ConnectionMode.Sqlite:
				connection.KindExecuteNonQuery( "BEGIN TRANSACTION" );
				break;
			}

			foreach( DataRow row in Rows )
			{
				DoInsertRow( row );
			}

			switch( connection.DbMode )
			{
			case DsnConnection.ConnectionMode.Sqlite:
				connection.KindExecuteNonQuery( "COMMIT" );
				break;
			}
		}

		/// <summary>
		/// this is called from the Lower level XDataTable ... to external users of this library, this entry point should not be visible.
		/// </summary>
		new internal void SyncToDatabase()
		{
			// this should be in a 'filling' state already...
			// this is a helper from XDataTable's function called
			// the same thing.
			// should attach this as a event-callback to the xdatatable
			// (would be cleaner, and more generally useful)
			if( connection == null )
				return;
			switch( connection.DbMode )
			{
			case DsnConnection.ConnectionMode.Odbc:
			case DsnConnection.ConnectionMode.MySqlNative:
				connection.ExecuteNonQuery( "truncate " + Prefix + XTableName );
				break;
			case DsnConnection.ConnectionMode.Sqlite:
				connection.ExecuteNonQuery( "delete from " + Prefix + XTableName );
				break;
			}
			InsertAllRows();
		}

		new internal void AppendToDatabase()
		{
			if( connection == null )
				return;
			filling = true;
			object min_local_id = Compute( "min(" + PrimaryKeyName + ")", null );
			object max_local_id = Compute( "max(" + PrimaryKeyName + ")", null );
			// no rows to commit.
			if( min_local_id.GetType() == typeof( DBNull ) )
				return;

			object max_real_id = connection.ExecuteScalar( "select max(" + PrimaryKeyName + ") from " + connection.sql_quote_open + Prefix + TableName + connection.sql_quote_close );
			if( max_real_id == null || max_real_id.GetType() == typeof( DBNull ) )
			{
				//
				if( Convert.ToInt32( min_local_id ) != 1 )
				{
					int n = 1;
					foreach( DataRow row in Rows )
					{
						row[PrimaryKeyName] = n;
						n++;
					}
					this.AcceptChanges();
				}
			}
			else
			{
				if( Convert.ToInt32( max_real_id )>= Convert.ToInt32( min_local_id) && Convert.ToInt32( max_real_id) <= Convert.ToInt32( max_local_id ) )
				{
					int final_id = Convert.ToInt32( max_real_id ) + Rows.Count + 1;
					if( final_id < Convert.ToInt32( max_local_id ) )
					{
						int n = Convert.ToInt32( max_real_id ) + 1;
						// while moving row ID's we may duplicate, so... look ahead...
						foreach( DataRow row in Rows )
						{
							DataRow[] conflict = Select( PrimaryKeyName + "=" + n );
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
						for( r = Rows.Count - 1; r >= 0; r-- )
						{
							Rows[r][PrimaryKeyName] = final_id;
							final_id--;
						}
					}
				}
				else
				{
					int n = Convert.ToInt32( max_real_id ) + 1;
					foreach( DataRow row in Rows )
					{
						row[PrimaryKeyName] = n;
						n++;
					}
					this.AcceptChanges();
				}
			}
			InsertAllRows();
			filling = false;
		}


		/// <summary>
		/// Zero parameter to pass a null as the filter string to Fill(filter)
		/// </summary>
		public void Fill()
		{
			Fill( null );
		}

        public static bool DoInsertRow( DsnConnection connection, String TableName, DataRow row )
        {
			bool generated_update = false;
			if( connection != null )
			{
				try
				{

					StringBuilder sb = new StringBuilder();
					//changes = this.GetChanges( DataRowState.Added );
					//string cmd_prefix = "insert into " + CompleteTableName + "(";
					bool first = true;
					sb.Append( "insert into " );
					sb.Append( connection.sql_quote_open );
                    sb.Append( TableName );
					sb.Append( connection.sql_quote_close );
					sb.Append( "(" );
					DataColumn auto_count = null;
					bool auto_count_null = true;
					row.AcceptChanges();
					generated_update = true;
                    DataColumnCollection Columns = row.Table.Columns;
					foreach( DataColumn column in row.Table.Columns )
					{
						// skip columns that have NULL in them..
						if( column.AutoIncrement )
						{
							auto_count = column;
						}
						if( row[column.Ordinal] == null || ( row[column.Ordinal] as DBNull ) != null )
							continue;
						if( !first )
							sb.Append( "," );
						first = false;
						sb.Append( connection.sql_quote_open );
						sb.Append( column.ColumnName );
						sb.Append( connection.sql_quote_close );
					}
					if( first )
					{
						Log.log( "NULL database row.  Or no data." );
						return generated_update;
					}
					sb.Append( ")values(" );
					//foreach( DataRow row in changes.Rows )
					{
						List<object> parameters = new List<object>();
						int n;
						int val = 0;
						for( n = 0; n < Columns.Count; n++ )
						{
                            object o = Columns[n].ExtendedProperties["Extra Type"];
                            String exra_type_info = ( o == null ? "" : o.ToString() );
							// skip the auto increment column
							//if( Columns[n].AutoIncrement )
							//	continue;
							// only if it's null ...
                            if( Columns[n].DataType == typeof( DateTime ) && exra_type_info == "createstamp" )
								// skip timestamp column output - the database should be filling this value in.
								continue;
                            if( Columns[n].DataType == typeof( DateTime ) && Columns[n].Namespace == "createstamp" )
                                // skip timestamp column output - the database should be filling this value in.
                                continue;
                            if( row[n] == null || ( row[n] as DBNull ) != null )
								continue;

							if( Columns[n] == auto_count )
								auto_count_null = false;

							if( row[n].GetType() == typeof( byte[] ) )
							{
								parameters.Add( row[n] );
								sb.Append( ( ( val > 0 ) ? ",?" : "?" ) );
							}
							else 
							{
								sb.Append( ( ( val > 0 ) ? "," : "" ) );
                                sb.Append( MySQLDataTable.GetSQLValue( connection, Columns[n], row[n] ) );
							}
							val++;
						}
						sb.Append( ")" );
						long id = connection.KindExecuteInsert( sb.ToString(), parameters.ToArray() );
						if( id > 0 && auto_count_null )
						{
							// the id result from the insert will be 0 if it was set.
							//filling = true;
							// this is an update to get the auto-increment to sync.
							if( auto_count != null )
								if( !Compare( row[auto_count.Ordinal].GetType(), row[auto_count.Ordinal], id ) )
									row[auto_count.Ordinal] = id;
							//filling = false;
						}
					}
				}
				catch( Exception e )
				{
					Log.log( e.Message );
				}
			}
			return generated_update;
		}
		
		public bool DoInsertRow(DataRow row )
		{
            return MySQLDataTable.DoInsertRow( connection, CompleteTableName, row );
        }
        public void Update()
		{
			bool generated_update = false;
			if( filling )
				return;
			foreach( DataRow row in Rows )
			{
				switch( row.RowState )
				{
				case DataRowState.Deleted:
					DoDelete( row );
					break;
				case DataRowState.Modified:
					generated_update = DoUpdateCommand( row );
					break;
				case DataRowState.Added:
					generated_update = DoInsertRow( row );
					break;
				}
			}
#if use_p2p_events
			if( generated_update && transmit != null )
			{
				Log.log( "Generate Updated table event." );
				transmit.Trigger( "Updated Table!", TableName, null );
			}
#endif
		}

		public static string RelationName( String first, String second )
		{
			return StripPlural( StripInfo( first ) ) + "_" + StripPlural( StripInfo( second ) );
		}
		public static string RelationName( DataTable first, DataTable second )
		{
			return RelationName( first.TableName, second.TableName );
		}

		void Delete( DataRow row )
		{
			string cmd = "delete from " + Prefix + TableName + " where ";
			bool first = true;
			if( row.HasVersion( DataRowVersion.Original ) )
			{
				int cols = row.Table.Columns.Count;
				for( int i = 0; i < cols; i++ )
				{
					if( row[i, DataRowVersion.Original] == null || row[i, DataRowVersion.Original].GetType() == typeof( DBNull ) )
						continue;
					if( !first )
						cmd += " and ";
					first = false;
					cmd += row.Table.Columns[i].ColumnName + "=" + GetSQLValue( row[i,DataRowVersion.Original].GetType(), row[i, DataRowVersion.Original] );
				}
			}
			else
			{
				for( int i = 0; i < row.ItemArray.Length; i++ )
				{
					if( row[i] == null || row[i].GetType() == typeof( DBNull ) )
						continue;
					if( !first )
						cmd += " and ";
					first = false;
					cmd += row.Table.Columns[i].ColumnName + "=" + GetSQLValue( row[i].GetType(), row[i] );
				}
			}
			connection.KindExecuteNonQuery( cmd );
			//row.AcceptChanges();
			//Console.WriteLine( ex.Message + "Fixed by Deletion in source." );
			//row.Delete();

			//AcceptChanges();
		}

		public string CompleteTableName
		{
			get { return Prefix + TableName; }
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
						Create();
			}
			else
			{
				connection = dsn;
				if( auto_create )
					Create();
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
			Create();
			Fill();
		}

		/// <summary>
		/// internal function, used for building the create table statement to the database
		/// </summary>
		/// <param name="first"></param>
		/// <param name="output"></param>
		void AddTableKeys( ref bool first, StringBuilder output )
		{
			if( connection.DbMode == DsnConnection.ConnectionMode.Sqlite )
			{
				// indexes are not used in sqlite.?
				return;
			}
			foreach( XDataTableKey xkey in keys )
			{
				if( connection.DbMode == DsnConnection.ConnectionMode.Sqlite )
					if( xkey.columns.Count > 1 )
					{
						Log.log( "Skipping build of multi-column key for sqlite." );
						continue;
					}

				DataColumn dc_auto_inc = Columns[xkey.columns[0]];
				// this key was already added.
				if( dc_auto_inc != null && xkey.primary && dc_auto_inc.AutoIncrement )
					continue;
				if( !first )
					output.Append( "," );
				first = false;
				output.Append( xkey.unique ? "UNIQUE " : "" + "KEY" );
				if( xkey.name != null )
				{
					output.Append( connection.sql_quote_open );
					output.Append( xkey.name );
					output.Append( connection.sql_quote_close );
				}
				output.Append( "(" );
				bool colfirst = true;
				foreach( String s in xkey.columns )
				{
					if( !colfirst )
						output.Append( "," );
					colfirst = false;
					output.Append( connection.sql_quote_open );
					output.Append( s );
					output.Append( connection.sql_quote_close );
				}
				output.Append( ")" );
			}
			foreach( XDataTableForeignKey fk in foreign )
			{
				if( !first )
					output.Append( "," );
				first = false;
				output.Append( "CONSTRAINT " + connection.sql_quote_open + fk.keyname + connection.sql_quote_close + " FOREIGN KEY " + ( ( fk.child_indexname == null ) ? "" : connection.sql_quote_open + fk.child_indexname + connection.sql_quote_close ) );
				output.Append( "(" );
				bool firstcol = true;
				foreach( String col in fk.child_columns )
				{
					if( !firstcol )
						output.Append( "," );
					firstcol = false;
					output.Append( connection.sql_quote_open + col + connection.sql_quote_close );
				}
				output.Append( ")REFERENCES " );
				output.Append( connection.sql_quote_open + fk.parent_table + connection.sql_quote_close );
				output.Append( "(" );
				firstcol = true;
				foreach( String col in fk.parent_columns )
				{
					if( !firstcol )
						output.Append( "," );
					firstcol = false;
					output.Append( connection.sql_quote_open + col + connection.sql_quote_close );
				}
				output.Append( ")ON DELETE "
					+( ( fk.fk.DeleteRule == Rule.Cascade ) ? "CASCADE"
					:(fk.fk.DeleteRule==Rule.None)?"NO ACTION"
					:(fk.fk.DeleteRule==Rule.SetDefault)?"SET DEFAULT"
					:(fk.fk.DeleteRule==Rule.SetNull)?"SET NULL"
						:"RESTRICT")
				);
				output.Append( " ON UPDATE " 
					+ (( fk.fk.UpdateRule==Rule.Cascade)?"CASCADE"
					:(fk.fk.UpdateRule==Rule.None)?"NO ACTION"
					:(fk.fk.UpdateRule==Rule.SetDefault)?"SET DEFAULT"
					:(fk.fk.UpdateRule==Rule.SetNull)?"SET NULL"
						:"RESTRICT")
					);
			}
		}

		/// <summary>
		/// Matches a DataTable according to a CreateTable statement (TableName, columsn, and column types)
		/// </summary>
		/// <param name="CreateStatement">The create statement which describes the table</param>
		/// <param name="delete_cols">Delete extra columns in DataTable that are not in the create statement</param>
		public void MatchCreate( String CreateStatement, bool delete_cols )
		{
			if( connection == null )
			{
				Log.log( "Previously this would default to staticDSN.... aborting table create." );
				return;
			}
			if( connection == null )
				connection = StaticDsnConnection.dsn;

			if( CreateStatement != null )
			{
				XDataTable xoriginal = SQL_Utilities.CreateTable( CreateStatement );
				TableName = xoriginal.TableName;
				Prefix = xoriginal.Prefix;
				extra = xoriginal.extra;
				foreach( DataColumn dc_orig in xoriginal.Columns )
				{
					bool found = false;
					foreach( DataColumn dc_target in this.Columns )
					{
						if( dc_target.ColumnName == dc_orig.ColumnName )
						{
							found = true;
							break;
						}
					}
					if( !found )
					{
						DataColumn dc;
						this.Columns.Add( dc = new DataColumn( dc_orig.ColumnName, dc_orig.DataType ) );

                        foreach( DictionaryEntry property in dc_orig.ExtendedProperties )
						{
                            dc.ExtendedProperties.Add( property.Key, property.Value );
						}
						
                        dc.MaxLength = dc_orig.MaxLength;
						dc.Namespace = dc_orig.Namespace;
						dc.AutoIncrement = dc_orig.AutoIncrement;
						dc.AutoIncrementSeed = dc_orig.AutoIncrementSeed;
						dc.Unique = dc_orig.Unique;
					}
				}
				foreach( XDataTableKey dc_orig in xoriginal.keys )
				{
					bool found = false;
					foreach( XDataTableKey dc_target in this.keys )
					{
						if( dc_target.name == dc_orig.name )
						{
							found = true;
							break;
						}
					}
					if( !found )
					{
						this.keys.Add( new XDataTableKey( dc_orig ) );
					}
				}
			}

			XDataTable original = null;

			switch( connection.DbMode )
			{
			case DsnConnection.ConnectionMode.MySqlNative:
			case DsnConnection.ConnectionMode.Odbc:
				DbDataReader reader = connection.KindExecuteReader( "show create table " + CompleteTableName );
				if( reader != null && reader.HasRows )
				{
					//DataTable t = reader.GetSchemaTable();
					if( reader.Read() )
					{
						//object o = reader["Create Table"];
                        int cols = reader.FieldCount;
						int ord = reader.GetOrdinal( "Create Table" );
                        string s = reader.GetString(1);
						original = SQL_Utilities.CreateTable( reader.GetString( ord ) );
						foreach( XDataTableForeignKey fk in original.foreign )
						{
							bool found = false;
							foreach( XDataTableForeignKey fk2 in foreign )
								if( fk2.keyname == fk.keyname )
									found = true;
							if( !found )
								this.foreign.Add( fk );
							else
								Log.log( "Duplicated forieng key - one from database, one in default defniition... didn't check to see if they are the same." );
						}
						original.foreign = null;
					}
					connection.EndReader( reader );
				}
				break;
			case DsnConnection.ConnectionMode.Sqlite:
				reader = connection.KindExecuteReader( "select tbl_name,sql from sqlite_master where type='table' and name='" + CompleteTableName + "'" );
				if( reader != null && reader.HasRows )
				{
					reader.Read();
					original = SQL_Utilities.CreateTable( reader.GetString( 1 ) );
					connection.EndReader( reader );
				}
				break;
			default:
				throw new Exception( "Unhandled mode in MatchCreate" );
			}
			if( original == null )
			{
				StringBuilder keys = new StringBuilder();
				StringBuilder sb = new StringBuilder();
				//string columns = null;
				bool first = true;
				bool first_key = true;
				//DataColumn auto = null;
				keys.Length = 0;
				foreach( DataColumn col in Columns )
				{
					// the DsnConnection creates a column specifically for the type of database connected to
					// syntax for keys and types changes.
					connection.AddColumnCreate( sb, ref first, keys, ref first_key, col );
				}

				AddTableKeys( ref first_key, keys );
				string create = "create table "
					+ connection.sql_quote_open
					+ Prefix
					+ TableName
					+ connection.sql_quote_close
					+ "("
					+ sb.ToString()
					+ ( keys.Length > 0 ? "," : "" )
					+ keys.ToString()
					+ ")"
					+ ((connection.DbMode == DsnConnection.ConnectionMode.Sqlite)?""
						:( ( extra != null ) ? ( ( first || first_key ) ? "," : "" ) + extra : "" ))
					;

				if( ( connection.DbMode == DsnConnection.ConnectionMode.Odbc && connection.DbFlavor == DsnConnection.ConnectionFlavor.MySqlNative )
					|| connection.DbMode == DsnConnection.ConnectionMode.MySqlNative )
				{
					if( extra == null || ( !extra.Contains( "engine=" ) && !extra.Contains( "ENGINE=" ) ) )
						create += " ENGINE=INNODB";
				}
				//Columns[0].ExtendedProperties.
                try
                {
                    connection.ExecuteNonQuery( create );
                }
                catch( OdbcException oe )
                {
                    foreach( OdbcError error in oe.Errors )

                    if( error.NativeError == 1005 )
                    {
                        // probably failed, cause one of it's constraints references a MyISAM table.
                        create += " engine=MyISAM";
                        connection.ExecuteNonQuery( create );

                    }
                }
				if( connection.DbMode == DsnConnection.ConnectionMode.Sqlite )
				{
					foreach( XDataTableKey xkey in this.keys )
					{
						bool index_first = true;

						if( xkey.primary && xkey.columns.Count == 1 )
							continue;

						string index = "CREATE "+(xkey.unique?"UNIQUE ":"") +"INDEX " + Prefix+TableName+"_"+xkey.name + " ON " + Prefix + TableName + "(";
						foreach( string col in xkey.columns )
						{
							if( !index_first )
								index += ",";
							index += col;
							index_first = false;
						}
						index += ")";
						connection.KindExecuteNonQuery( index );
					}
				}

			}
			else
			{
				foreach( DataColumn dc_target in this.Columns )
				{
					bool found = false;
					foreach( DataColumn dc_orig in original.Columns )
					{
						if( dc_target.ColumnName == dc_orig.ColumnName )
						{
							found = true;
							break;
						}
					}
					if( !found )
					{
						// add this column
						connection.ExecuteNonQuery( "ALTER TABLE "
								+ connection.sql_quote_open
								+ CompleteTableName
								+ connection.sql_quote_close
								+ "ADD COLUMN "
								+ connection.sql_quote_open
								+ dc_target.ColumnName
								+ connection.sql_quote_close
								+ SQL_Utilities.GetColumnDef( connection.DbMode, dc_target ) );
#if use_p2p_events
						if( transmit != null )
							Trigger( "Alter table add", TableName, dc_target.ColumnName );
#endif
					}
				}
				if( delete_cols )
					foreach( DataColumn dc_orig in original.Columns )
					{
						bool found = false;
						foreach( DataColumn dc_target in this.Columns )
						{
							if( dc_target.ColumnName == dc_orig.ColumnName )
							{
								found = true;
								break;
							}

						}
						if( !found )
						{
							if( connection.DbMode == DsnConnection.ConnectionMode.Sqlite )
								continue;
							// add this column
							connection.ExecuteNonQuery( "ALTER TABLE "
									+ connection.sql_quote_open
									+ CompleteTableName
									+ connection.sql_quote_close
									+ "DROP COLUMN "
									+ connection.sql_quote_open
									+ dc_orig.ColumnName
									+ connection.sql_quote_close );
#if use_p2p_events
							if( transmit != null )
								Trigger( "Alter table drop", TableName, dc_orig.ColumnName );
#endif
						}
					}
			}
			Created = true;
		}

		/// <summary>
		/// This matches a DataTable to a string 'Create Table ...' SQL command.
		/// </summary>
		/// <param name="CreateStatement">The create statement which describes this table</param>
		public void MatchCreate( String CreateStatement )
		{
			MatchCreate( CreateStatement, false );
		}

		
		public void Trigger( String Event, String TableName, String Column )
		{
			// get the image
			Log.log( "Recevied notice " + Event + " On " + TableName + " . " + Column );
		}

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
#region IDispatchMessageInspector Members

		object IDispatchMessageInspector.AfterReceiveRequest( ref System.ServiceModel.Channels.Message request, IClientChannel channel, InstanceContext instanceContext )
		{
			throw new Exception( "The method or operation is not implemented." );
		}

		void IDispatchMessageInspector.BeforeSendReply( ref System.ServiceModel.Channels.Message reply, object correlationState )
		{
			throw new Exception( "The method or operation is not implemented." );
		}

#endregion

#region IClientMessageInspector Members

		void IClientMessageInspector.AfterReceiveReply( ref System.ServiceModel.Channels.Message reply, object correlationState )
		{
			throw new Exception( "The method or operation is not implemented." );
		}

		object IClientMessageInspector.BeforeSendRequest( ref System.ServiceModel.Channels.Message request, IClientChannel channel )
		{
			throw new Exception( "The method or operation is not implemented." );
		}

#endregion
#endif

		bool suspended;
		/// <summary>
		/// Turns off live, and turns on suspend.  Later, Accept changes will resume 'live' flag if it was 'suspended'
		/// </summary>
		protected void SuspendChanges()
		{
			suspended = true;
			live = false;
		}
		
		/// <summary>
		/// Override of base method, Syncronizes tables to database.
		/// </summary>
		public void CommitChanges()
		{
			if( connection != null )
			{
				if( !filling )
				{
					if( !live && suspended )
					{
						suspended = false;
						live = true;

						DataTable Updates = GetChanges();

						if( Updates != null )
						{
							foreach( DataRow Row in Updates.Rows )
							{
								switch( Row.RowState )
								{
								case DataRowState.Added:
									DoInsertRow( Row );
									break;
								case DataRowState.Modified:
									DoUpdateCommand( Row );
									break;
								case DataRowState.Deleted:
									DoDelete( Row );
									break;
								}
							}
						}
					}
					else
					{
						if( live )
						{
							DataTable Updates = null;
							try
							{
								Updates = GetChanges();
							}
							catch
							{
							}
							if( Updates != null )
							{
								foreach( DataRow Row in Updates.Rows )
								{
									switch( Row.RowState )
									{
									case DataRowState.Added:
										DoInsertRow( Row );
										break;
									case DataRowState.Modified:
										DoUpdateCommand( Row );
										break;
									case DataRowState.Deleted:
										DoDelete( Row );
										break;
									}
								}
							}
							else
							{
								// probably the updatechanges method FAILED
								//   because there was no default() constructor
								// big whoop.
								foreach( DataRow row in Rows )
								{
									switch( row.RowState )
									{
									case DataRowState.Added:
										DoInsertRow( row );
										break;
									case DataRowState.Modified:
										DoUpdateCommand( row );
										break;
									case DataRowState.Deleted:
										DoDelete( row );
										break;
									}
								}
							}
						}
					}
				}
			}
			base.AcceptChanges();
		}
	}

#if use_p2p_events
	[MessageContract]
	public class TransactionIdRequest
	{
		[MessageBodyMember]
		public string Requester;
		[PeerHopCount]
		public int Hops;

		public TransactionIdRequest()
		{
			Hops = 1;
		}
	}

	[ServiceContract]
	public interface IEventNotice
	{
		[OperationContract( IsOneWay = true )]
		void Trigger( String opearation, String TableName, String Column );
	}
#endif

}
#endif