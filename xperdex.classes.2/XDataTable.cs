using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using xperdex.classes.Types;

namespace xperdex.classes
{
	public class XDataTable<T> : DataTable, IXDataTable
		where T : DataRow
	{
		

		protected override global::System.Data.DataRow NewRowFromBuilder( global::System.Data.DataRowBuilder builder )
		{
			if( GetRowType() == typeof( DataRow ) )
				return base.NewRowFromBuilder( builder );

			object[] paramlist = new object[]{ builder };

			//ConstructorInfo[] constructors = GetRowType().GetConstructors( BindingFlags.Public | BindingFlags.NonPublic );
			//ConstructorInfo GetRowType().GetConstructor( new Type[1] { typeof( DataRowBuilder ) } );
			//GetRowType().CreateInstance( paramlist );
			return (T)Activator.CreateInstance( GetRowType(), paramlist );
		}

		protected override global::System.Type GetRowType()
		{
			return typeof( T );
		}


		public class XDataTableForeignKey
		{
			public String keyname;
			public String child_indexname;
			public List<String> child_columns = new List<string>();
			public String parent_table;
			public List<String> parent_columns = new List<string>();
			// restrict is the default for mysql...
			public ForeignKeyConstraint fk;
			// sometimes I have to know these, but cannot know literal DataColumns (parsing from database)
			public Rule fk_DeleteRule;
			public Rule fk_UpdateRule;

			public XDataTableForeignKey()
			{
			}

			/// <summary>
			///  consider that other databases may have differnt defauls for ondelete and onupdate...
			/// </summary>
			/// <param name="mode"></param>
			public XDataTableForeignKey( DsnConnection.ConnectionMode mode )
			{
				switch( mode )
				{
				case DsnConnection.ConnectionMode.MySqlNative:
				case DsnConnection.ConnectionMode.Odbc:
					break;
				}
			}
		}


		//public static Type DefaultAutoKeyType = typeof( Guid );
		//public static Type DefaultAutoKeyType = typeof( GUID );
		public Type _AutoKeyType;
		public Type AutoKeyType
		{
			get
			{
				return _AutoKeyType;
			}
			set
			{
				_AutoKeyType = value;
			}
	}

		object _ZeroKey;
		public object ZeroKey
		{
			get
			{
				return _ZeroKey;
			}
			set
			{
				_ZeroKey = value;
			}
		}

        public XDataTable( global::System.Runtime.Serialization.SerializationInfo info, global::System.Runtime.Serialization.StreamingContext context ): base( info, context )
        {
        }
		public XDataTable()
        {
			AutoKeyType = XDataTable.DefaultAutoKeyType;
			if( AutoKeyType == typeof( Guid )
				|| AutoKeyType == typeof( XGuid ) )
				ZeroKey = Guid.Empty;
			else if( AutoKeyType == typeof( Int32 ) )
				ZeroKey = 0;
			else
				throw new Exception( "Unknown zero key value for column type: " + AutoKeyType.ToString() );
			if( TableName == null || TableName == "" )
            {
				TableName = XTableName;
            }
            
        }

        // wish I could enforce requiremnt of a static name of the table...
        //public abstract static readonly string TableName{ get{} }
		int _filling;
		/// <summary>
		/// This is set to true when filling the table, allowing Update() to not update while initializing....
		/// </summary>
		public bool filling
		{
			get
			{
				return (_filling > 0);
			}
			set
			{
				if( value )
				{
					_filling++;
					//Log.log( TableName + ":fill aquire...", 1 );
				}
				else
					if( _filling > 0 )
					{
						_filling--;
						//Log.log( TableName + ":fill release...", 1 );
						//if( _filling == 0 )
						//   Log.log( TableName + ":Last Filling underflow...", 1 );

					}
					else
						Log.log( TableName + ":Filling underflow...", 1 );
			}
		}

		/// <summary>
		/// This event is triggered after AcceptChanges() is called.  This allows child tables to get their Accept after the parent has been commited to the database.
		/// </summary>
		public event XDataTable.OnAcceptChanges AcceptedChanges;

		public void BeginSyncToDatabase()
		{
			filling = true;
		}

		public void llCommitChanges()
		{
			base.AcceptChanges();
			if( AcceptedChanges != null )
				AcceptedChanges();
		}
		
		public void SyncToDatabase( DsnConnection dsn )
		{
			if( dsn != null )
			{
				switch( dsn.DbMode )
				{
				case DsnConnection.ConnectionMode.Odbc:
				case DsnConnection.ConnectionMode.MySqlNative:
					// cannot truncate foreign keyed tables.
					//dsn.ExecuteNonQuery( "truncate " + Prefix + XTableName );
					dsn.ExecuteNonQuery( "delete from " + Prefix + XTableName );
					// want to reset the keys though... so can truncate after it's empty?
					dsn.ExecuteNonQuery( "ALTER TABLE " + Prefix + XTableName + " AUTO_INCREMENT = 1" );
					break;
				case DsnConnection.ConnectionMode.Sqlite:
					dsn.ExecuteNonQuery( "delete from " + Prefix + XTableName );
					dsn.ExecuteNonQuery( "update sqlite_sequence set seq = 1 where name='"+ Prefix + XTableName + "'" );
					break;
				default:
					dsn.ExecuteNonQuery( "delete from " + Prefix + XTableName );
					break;
				}
				DsnSQLUtil.InsertAllRows( dsn, this );
			}
			filling = false;
		}

		public void AppendToDatabase()
		{
			MySQLDataTable dbtable = this as MySQLDataTable;
			if( dbtable != null )
				dbtable.AppendToDatabase();
		}

		/// <summary>
		/// Result with Prefix+Tablename - handles if Prefix is NULL or TableName is NULL....
		/// </summary>
		public string FullTableName
		{
			get
			{
				if( DataSet != null && DataSet.Prefix != null )
				{
					if( Prefix != null )
						if( TableName != null )
							return DataSet.Prefix + Prefix + TableName;
						else
						{
							return null;
						}
					else
						return DataSet.Prefix + TableName;
				}
				else
				if( Prefix != null )
					if( TableName != null )
						return Prefix + TableName;
					else
					{
						return null;
					}
				else
					return TableName;

			}
		}

		public bool dynamic;
		/// <summary>
		/// list of key columns we desired in a create table statement...
		/// </summary>
		public List<XDataTableKey> _keys = new List<XDataTableKey>();
		public List<XDataTableKey> keys
		{
			get
			{
				return _keys;
			}
		}

		/// <summary>
		/// list of foreign key columns (these are an after-thought in this model... so these reflect what was on the table to start...
		/// then as relations are added to the dataset, they are compared to these to see if they need to be added.
		/// </summary>
		public List<XDataTableForeignKey> foreign = new List<XDataTableForeignKey>();

		String _extra;
		/// <summary>
		/// comments, engine type... database specific information
		/// </summary>
		public String extra
		{
			get
			{
				return _extra;
			}
			set
			{
				_extra = value;
			}
		}


		public String DisplayMemberName
		{
			get
			{
				return NameColumn;
			}
		}

		string value_member_override;
		public String ValueMemberName
		{
			get
			{
				if( value_member_override == null )
					return XDataTable.ID( this );
				return value_member_override;
			}
			set
			{
				value_member_override = value;
			}
		}

		public String PrimaryKeyName
		{
			get
			{
                if( base.PrimaryKey.Length == 1 )
                    return base.PrimaryKey[0].ColumnName;
				if( base.PrimaryKey == null )
					base.PrimaryKey = new DataColumn[] { Columns[XDataTable.ID( this )] };
				return XDataTable.ID( this );
			}
		}


		protected String number_column;

		public String NumberColumn
		{
			get
			{
				FieldInfo fi = this.GetType().GetField( "NumberColumn", BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.GetField | BindingFlags.Static );
				if( fi != null )
				{
					return fi.GetValue( this ).ToString();
				}
				if( number_column != null )				
					return number_column;
				return MySQLDataTable.StripPlural( MySQLDataTable.StripInfo( TableName ) ) + "_number";
			}
		}

		public DataColumn _auto_id;
		public DataColumn auto_id
		{
			get
			{
				return _auto_id;
			}
			set
			{
				_auto_id = value;
			}
		}

        /// <summary>
		/// Returns the proper table 'name' column.  Where the text description for this record may be set.
		/// </summary>
		/// <returns></returns>
		public string NameColumn
		{
			get
			{
				return XDataTable.Name( this );
			}
		}
		/// <summary>
		/// returns the number column name defined for this table
		/// </summary>
		/// <returns></returns>
        public string Number
        {
			get
			{
				return XDataTable.Number( this );
			}
        }

        public string XTableName
		{
			get
			{
				FieldInfo fi = this.GetType().GetField( "TableName", BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.GetField | BindingFlags.Static );
				if( fi != null )
				{
					return fi.GetValue( this ).ToString();
				}
				return base.TableName;
			}
		}

		public DataRow AddClonedRow( DataRow clone )
		{
			String primary_key = null;
			IXDataTable source = clone.Table as IXDataTable;
			if( source != null )
			{
				primary_key = source.PrimaryKeyName;
				// first, check if the row already exists in the target... 
				// if so, result with null instead of a row.
				DataRow[] rows = Select( source.PrimaryKeyName + "=" + clone[source.PrimaryKeyName] );
				if( rows.Length > 0 )
				{
					return rows[0];
				}
			}

			DataRow row = NewRow();
			foreach( DataColumn dc in clone.Table.Columns )
			{
				try
				{
					if( primary_key != null && dc.ColumnName == primary_key )
						continue;
					row[dc.ColumnName] = clone[dc];
				}
				catch
				{
					// the column night not exist in the source table...
				}
			}
			this.Rows.Add( row );
			return row;
		}

		public DataRow AddClonedRow( DataRow new_parent, DataRow clone )
		{
			String primary_key = null;
			String parent_primary_key = null;
			IXDataTable source = clone.Table as IXDataTable;
			IXDataTable parent_source = new_parent.Table as IXDataTable;
			if( parent_source != null )
			{
				parent_primary_key = parent_source.PrimaryKeyName;
			}

			if( source != null )
			{
				primary_key = source.PrimaryKeyName;
				// first, check if the row already exists in the target... 
				// if so, result with null instead of a row.
				DataRow[] rows = Select( source.PrimaryKeyName + "=" + clone[source.PrimaryKeyName] );
				//if( rows.Length > 0 )
				{
				//	return rows[0];
				}
			}

			DataRow row = NewRow();
			foreach( DataColumn dc in clone.Table.Columns )
			{
				try
				{
					// skip setting my own primary key
					if( primary_key != null && dc.ColumnName == primary_key )
						continue;
					// use new parent primary key
					else if( parent_primary_key != null && dc.ColumnName == parent_primary_key )
						row[dc.ColumnName] = new_parent[dc.ColumnName];
					else
						row[dc.ColumnName] = clone[dc];
				}
				catch
				{
					// the column night not exist in the source table...
				}
			}
			this.Rows.Add( row );
			return row;
		}

		public DataRow Clone( DataRow clone )
		{
			DataRow row = NewRow();
			foreach( DataColumn dc in clone.Table.Columns )
			{
				try
				{
					if( dc.AutoIncrement )
						continue;
					row[dc.ColumnName] = clone[dc];
				}
				catch
				{
					// the column night not exist in the source table...
				}
			}
			{
				IXDataTable xdatatable = clone.Table as IXDataTable;
				if( xdatatable != null )
				{
					if( xdatatable.AutoKeyType == typeof( Guid ) )
					{
						row[xdatatable.PrimaryKeyName] = Guid.NewGuid();// DsnConnection.GetGUID();
					}
				}
			}
			return row;
		}

		public DataRow AddClonedRow( DataRow clone, bool allow_duplicate_key )
		{
			IXDataTable xsource = clone.Table as IXDataTable;
			DataTable source = clone.Table as DataTable;
			if( !allow_duplicate_key && xsource != null )
			{
				// first, check if the row already exists in the target... 
				// if so, result with null instead of a row.
				DataRow[] rows;
				rows = Select( xsource.PrimaryKeyName + "='" + clone[xsource.PrimaryKeyName].ToString() + "'" );
				if( rows.Length > 0 )
				{
					return null;
				}
			}

			DataRow row = NewRow();
			foreach ( DataColumn dc in source.Columns )
			{
				try
				{
					// leave this NULL and auto-increment
					if( dc.AutoIncrement )
						continue;
					if( row.Table.Columns.Contains( dc.ColumnName ) )
						row[dc.ColumnName] = clone[dc.ColumnName];
				}
				catch
				{
					// the column night not exist in the source table...
				}
			}
			this.Rows.Add( row );
			return row;
		}

		public string GetConditionedDisplayValue( string ValueMember, string DisplayMember, string Condition )
		{
			string parentName = "";
			if( Condition != "" )
			{
				DataRow[] ParentRow = this.Select( IDColumn + "='" + Condition +"'");
				if( ParentRow.Length > 0 )
					if( ParentRow.Length > 1 )
						parentName = ParentRow[0][NameColumn].ToString() + "... ";
					else
						parentName = ParentRow[0][NameColumn].ToString();
				else
					parentName = "Unknown";
			}
			else
				parentName = "UnAssign";
			return parentName;
		}

		public String IDColumn
		{
			get
			{
				return XDataTable.ID( this );
			}
		}

		public void Delete( string deleteCondition )
		{
			DataRow[] rows = Select( deleteCondition );
			foreach( DataRow row in rows )
				row.Delete();
			//return deleteComm;
		}

		public DataRow NewSimpleName( String name )
		{
			String name_column = XDataTable.Name( this );
			if( name_column != null )
			{
				String safe_name = DsnConnection.Escape( DsnConnection.ConnectionMode.NativeDataTable, DsnConnection.ConnectionFlavor.Unknown, name );
				if( Columns[name_column].Unique )
				{
					DataRow[] rows = Select( name_column + "='" + safe_name + "'" );
					if( rows.Length > 1 )
						throw new ConstraintException( "unique name column has already been violated, while attempting to add [" + name + "]" );
					if( rows.Length == 1 )
						return rows[0];
				}
				DataRow newnamerow = NewRow();
				newnamerow[name_column] = safe_name;
				Rows.Add( newnamerow );
				return newnamerow;
			}
			return null;
		}

	}

	public class XDataTableKey
	{
		public bool primary;
		public bool unique;
		public String name;
		public List<String> columns = new List<string>();
		public XDataTableKey( bool unique, String name, String[] columns )
		{
			primary = false;
			this.unique = unique;
			this.name = name;
			this.columns = new List<string>();
			foreach( String s in columns )
			{
				if( s != null )
					this.columns.Add( s );
			}
		}
		public XDataTableKey( XDataTableKey clone )
		{
			this.primary = clone.primary;
			this.unique = clone.unique;
			this.name = clone.name;
			this.columns = clone.columns;
		}
		public XDataTableKey()
		{

		}
	}

	public class XDataTable : XDataTable< DataRow >
	{
		/// <summary>
		/// This is the event triggered after AcceptChanges()
		/// </summary>
		public delegate void OnAcceptChanges();

		public static object Lock = new object();
		public static Type DefaultAutoKeyType = typeof( int );
		/// <summary>
		/// Return the name function based on the table name?
		/// Table name is really optional cause all code will know what table is there?
		/// </summary>
		/// <param name="table"></param>
		/// <returns></returns>
		public static string Name( DataTable table )
		{
			FieldInfo fi = table.GetType().GetField( "NameColumn", BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.GetField | BindingFlags.Static );
			if( fi != null )
			{
				return fi.GetValue( table ).ToString();
			}
			return Name( table.TableName );
		}
		public static bool HasName( DataTable table )
		{
			FieldInfo fi = table.GetType().GetField( "NameColumn", BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.GetField | BindingFlags.Static );
			if( fi != null )
			{
				if( table.Columns.IndexOf( fi.GetValue( table ).ToString() ) >= 0 )
					return true;
				return false;
			}
			if( table.Columns.IndexOf( Name( table.TableName ) ) >= 0 )
				return true;
			return false;
		}

		new public static string Number( DataTable table )
		{
			FieldInfo fi = table.GetType().GetField( "NumberColumn", BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.GetField | BindingFlags.Static );
			if( fi != null )
			{
				return fi.GetValue( table ).ToString();
			}
			return Number( table.TableName );
		}

		public static bool HasNumber( DataTable table )
		{
			FieldInfo fi = table.GetType().GetField( "NumberColumn", BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.GetField | BindingFlags.Static );
			if( fi != null )
			{
				if( table.Columns.IndexOf( fi.GetValue( table ).ToString() ) >= 0 )
					return true;
				return false;
			}
			if( table.Columns.IndexOf( Number( table.TableName ) ) >= 0 )
				return true;
			return false;
		}
		public static string ID( DataTable table )
		{
			FieldInfo fi = table.GetType().GetField( "PrimaryKey", BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.GetField | BindingFlags.Static );
			if( fi != null )
			{
				return fi.GetValue( table ).ToString();
			}
			return ID( table.TableName );
		}
		public static string ID( Type TableName )
		{
			FieldInfo fi = TableName.GetField( "PrimaryKey", BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.GetField | BindingFlags.Static );
			if( fi != null )
			{
				return fi.GetValue( TableName ).ToString();
			}
			throw new Exception( "primary key static field not found" );
		}
		/// <summary>
		/// Results with a standardized name_string column name based on the table name.  Uses StripInfo and StripPlural to singularize and shorten the name.
		/// Method which gets passed a DataTable instance can reference static definitions to get custom values, and should be used if able.
		/// </summary>
		/// <param name="TableName">the table name string to turn into a name field</param>
		/// <returns></returns>
		public static string Name( String TableName )
	{
			return MySQLDataTable.StripInfo( MySQLDataTable.StripPlural( TableName ) ) + "_name";
		}
        /// <summary>
        /// Results with a standardized number column name based on the table name.  Uses StripInfo and StripPlural to singularize and shorten the name.
        /// Method which gets passed a DataTable instance can reference static definitions to get custom values, and should be used if able.
        /// </summary>
        /// <param name="TableName">the table name string to turn into a number column</param>
        /// <returns></returns>
        new public static string Number( String TableName )
		{
			return MySQLDataTable.StripInfo( MySQLDataTable.StripPlural( TableName ) ) + "_number";
		}

		/// <summary>
		/// Results with a standardized primary key name based on the table name.  Uses StripInfo and StripPlural to singularize and shorten the name.
		/// Method which gets passed a DataTable instance can reference static definitions to get custom values, and should be used if able.
		/// </summary>
		/// <param name="TableName">the table name string to turn into a key</param>
		/// <returns></returns>

		public static string ID( String TableName )
		{
			return MySQLDataTable.StripInfo( MySQLDataTable.StripPlural( TableName ) ) + "_id";
		}
	}

	public interface IXDataTable
	{

		Type AutoKeyType { get; set; }
		object ZeroKey { get; set; }

		/// <summary>
		/// This is set to true when filling the table, allowing Update() to not update while initializing....
		/// </summary>
		bool filling
		{
			get;
			set;
		}

		/// <summary>
		/// This event is triggered after AcceptChanges() is called.  This allows child tables to get their Accept after the parent has been commited to the database.
		/// </summary>
		event XDataTable.OnAcceptChanges AcceptedChanges;

		void BeginSyncToDatabase();

		void llCommitChanges();
		void SyncToDatabase(DsnConnection dsn);
		void AppendToDatabase();

		/// <summary>
		/// Result with Prefix+Tablename - handles if Prefix is NULL or TableName is NULL....
		/// </summary>
		string FullTableName
		{
			get;
		}

		/// <summary>
		/// comments, engine type... database specific information
		/// </summary>
		String extra
		{
			get;
			set;
		}
		String DisplayMemberName
		{
			get;
		}

		String ValueMemberName
		{
			get;
			set;
		}

		String PrimaryKeyName
		{
			get;
		}


		String NumberColumn
		{
			get;
		}

		DataColumn auto_id { get; set; }
		List<XDataTableKey> keys { get; }


		/// <summary>
		/// Returns the proper table 'name' column.  Where the text description for this record may be set.
		/// </summary>
		/// <returns></returns>
		string NameColumn { get; }

		/// <summary>
		/// returns the number column name defined for this table
		/// </summary>
		/// <returns></returns>
		string Number { get; }
		string XTableName { get; }

		DataRow AddClonedRow( DataRow clone );
		DataRow AddClonedRow( DataRow clone, bool allow_duplicate_key );
		string GetConditionedDisplayValue( string ValueMember, string DisplayMember, string Condition );
		void Delete( string deleteCondition );
		DataRow NewSimpleName( String name );


		String TableName { get; set; }
		event DataRowChangeEventHandler RowChanged;
		event DataColumnChangeEventHandler ColumnChanged;

		DataRow NewRow();
	}
}
