using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;
using xperdex.classes.Types;

namespace xperdex.classes
{
	public class MetaMySQLRelation : MetaMySQLRelation<DataRow>
	{
		public MetaMySQLRelation( DataSet dataSet
			, DataTable table
			, String path_from_2_to_source
			, bool add_number
			, DataColumn[] extra_data
			)
			: base(  dataSet
				,  table
				,  path_from_2_to_source
				,  add_number
				,  extra_data
				,  false
				)
		{
		}

		public MetaMySQLRelation( DsnConnection odbc, DataSet dataSet
			, DataTable table
			, String path_from_2_to_source
			, bool add_number
			, bool auto_fill
			, DataColumn[] extra_data )
			: base( odbc, dataSet
			, table
			, path_from_2_to_source
			, add_number
			, auto_fill
			, extra_data )
		{
		}
		public MetaMySQLRelation()
		{
		}
	}

	/// <summary>
	/// This class is a relation that results because of other relations in a dataset.
	/// This relation creates a table that can store additional information at the point
	/// Rows are related back to their origin rows with parent relationships; so cascade rules work to update the content without a lot of work.
	/// This is also a way to do complex joins and have the result in a single table.
	/// </summary>
	public class MetaMySQLRelation<T> : MySQLRelationTableBase<T>, IMetaMySQLRelation
		where T : DataRow

	{
		/// <summary>
		/// This is the table that is the lowest member table
		/// </summary>
		public DataTable _terminal_table;

		/// <summary>
		/// This is the table that is the lowest member table
		/// </summary>
		public XDataTable<DataRow> terminal_table;

		/// <summary>
		/// need a copy constructor... (GetChanges)
		/// </summary>
		public MetaMySQLRelation()
		{
		}

		bool _AllowPartialRows;
		public bool AllowPartialRows
		{
			get
			{
				return _AllowPartialRows;
			}
			set
			{
				if( _AllowPartialRows != value )
				{
					_AllowPartialRows = value;
					// repopulate the table based on the new settings
				}
			}
		}

		//String table1_key;
		//String table2_key;
		//XString xPath;

		DataTable[] _parents;
		/// <summary>
		/// This is the array of all tables that were used to create this relationship.  Can be used for removing the relation for instance.
		/// </summary>
		public DataTable[] parents
		{
			get
			{
				return _parents;
			}
		}

		internal class DataColumnMimicer
		{
			internal string column_name;
			internal DataColumn data_column;
			internal PathNode node;
			internal DataColumnMimicer( String column_name, DataColumn data_column, PathNode node )
			{
				this.column_name = column_name;
				this.data_column = data_column;
				this.node = node;
			}
		}

		List<DataColumnMimicer> extra_columns;

		/// <summary>
		/// Internal class used to track interpretation of the MySQLRelationMap class information
		/// </summary>
		internal class PathNode
		{
			public override string ToString()
			{
				return "From " + table.TableName + " Via " + (relation!=null?relation.RelationName:meta_relation!=null?meta_relation.RelationName:"??" ) + ( save_link ? " SaveLink" : "" ) + ( invoke_name_event ? " NameEvent" : "" );
			}
			/// <summary>
			/// Save this key as part of the relation (some points on the map are not actual relation points)
			/// </summary>
			internal bool save_link;
			/// <summary>
			/// The relation that represents this (if save_link is also on?)
			/// </summary>
			internal DataRelation relation;
			/// <summary>
			/// The relation that represents this (if save_link is also on?)
			/// </summary>
			internal DataRelation meta_relation;
			/// <summary>
			/// The table at this point in the map
			/// </summary>
			internal DataTable table;
			/// <summary>
			///The relation should be followed as a child relationship (otherwise followed as parent relationship).  
			///Modifies wheter GetParentRows or GetChildRows is used.
			/// </summary>
			internal bool follow_as_child;
			//internal bool followed_as_child; // how we got to here... root node is...
			/// <summary>
			/// The name of the key at this point in the origin table
			/// </summary>
			internal string keyname;
			/// <summary>
			/// Boolean whether a change in this name in the parent relation causes an update to the name of this.
			/// </summary>
			internal bool invoke_name_event;
			/// <summary>
			/// Index of the column this node references in the meta table.
			/// </summary>
			internal int column_index;
		}

		/// <summary>
		/// Path nodes that make up this reltionship
		/// </summary>
		List<PathNode> data_path = new List<PathNode>();

		/// <summary>
		/// This is the beginning point of the relation.
		/// </summary>
		public DataTable _root_table;

		/// <summary>
        /// This is the beginning point of the relation.
        /// </summary>
		public DataTable root_table
		{
			get
			{
				return _root_table;
			}
		}

		/// <summary>
		/// Even if unique is not part of the above set, if the same set of keys results, don't replicate the row.
		/// </summary>
		protected bool unique;

		/// <summary>
		/// creates a relationship which table1 is based as a root databable.  
		/// Additions to table2 which relate to table1 are traced via the path to their data.
		/// </summary>
		/// <param name="dataSet"></param>
		/// <param name="table"></param>
		/// <param name="path_from_2_to_source"></param>
		/// <param name="table2"></param>
		void Init( DataSet dataSet
			, DataTable table
			, String path_from_2_to_source
			, bool add_number
			, DataColumn[] extra_data
			, bool live
			)
		{
			Init( dataSet, table, path_from_2_to_source, add_number, false, extra_data, live );
		}
		/// <summary>
		/// creates a relationship which table1 is based as a root databable.  
		/// Additions to table2 which relate to table1 are traced via the path to their data.
		/// </summary>
		/// <param name="dataSet"></param>
		/// <param name="table"></param>
		/// <param name="path_from_2_to_source"></param>
		/// <param name="table2"></param>
		void Init( DataSet dataSet
			, DataTable table
			, String path_from_2_to_source
			, bool add_number
			, DataColumn[] extra_data
			, bool live
			, String[] extra_mimic_columns
			)
		{
			Init( (DsnConnection)null, dataSet, table, path_from_2_to_source, add_number, add_number, extra_data, live, extra_mimic_columns );
		}
		/// <summary>
		/// creates a relationship which table1 is based as a root databable.  
		/// Additions to table2 which relate to table1 are traced via the path to their data.
		/// </summary>
		/// <param name="dataSet"></param>
		/// <param name="table"></param>
		/// <param name="path_from_2_to_source"></param>
		/// <param name="table2"></param>
		void Init( DataSet dataSet
			, DataTable table
			, String path_from_2_to_source
			, bool add_number
			, bool auto_fill
			, DataColumn[] extra_data
			, bool live
			)
		{
			Init( (DsnConnection)null, dataSet
				, table, path_from_2_to_source
				, add_number, auto_fill, extra_data, live, null );
		}
		/// <summary>
		/// creates a relationship which table1 is based as a root databable.  
		/// Additions to table2 which relate to table1 are traced via the path to their data.
		/// </summary>
		/// <param name="dataSet">dataset to build metarelation in</param>
		/// <param name="table">Root table to build relation from</param>
		/// <param name="path_from_2_to_source">the path from the root to the end child</param>
		/// <param name="add_number">whether to add a column for independant ordering of elements</param>
		/// <param name="auto_fill">indicate whether to create table in database and load with data at this time</param>
		/// <param name="extra_data">additional columns to add (passed from derrived class with a base() intializer)</param>
		/// <param name="live">indiciator whether changes in this table go directly to the database or not</param>
		/// <param name="extra_mimic_columns">An optional array of extra data columns to copy to this table</param>
		void Init( DsnConnection odbc
			, DataSet dataSet
			, DataTable table
			, String path_from_2_to_source
			, bool add_number
			, bool auto_fill
			, DataColumn[] extra_data
			, bool live
			, String[] extra_mimic_columns
			)
		{
			this.connection = odbc;
			// attach these relations to the same namespace as the root table.
			Prefix = table.Prefix;
			TableName = this.XTableName;
			_root_table = table;

			_terminal_table = FindTable( _root_table, new XString( path_from_2_to_source ), extra_mimic_columns );
			terminal_table = _terminal_table as XDataTable<DataRow>;
			dataSet.Tables.Add( this );

			this.RowDeleting += new DataRowChangeEventHandler( MetaMySQLRelation_RowDeleting );
			this.RowDeleted += new DataRowChangeEventHandler( MetaMySQLRelation_RowDeleted );

			// this routine used to be hooked in to delete existing rows as new combinations were added..
			//this.RowChanging += new DataRowChangeEventHandler( MetaMySQLRelation_RowChanging );

			base._children_of_parent = this.XTableName + "_meta_" + _root_table.TableName;
			base._parent_of_child = "something else";

			int parent_count = 0;


			foreach( PathNode node in data_path )
			{
				if( node.save_link )
				{
					DataTable node_table = node.table;
					DataColumn keycol = ( node_table.PrimaryKey.Length > 0 ) ? node_table.PrimaryKey[0] : node_table.Columns[XDataTable.ID( node_table )];
					DataColumn relcol = Columns.Add( keycol.ColumnName, keycol.DataType );
					node.table.RowDeleted += new DataRowChangeEventHandler( table_RowDeleted );
					node.column_index = relcol.Ordinal;
					dataSet.Relations.Add( node.meta_relation = new DataRelation( this.XTableName + "_meta_" + node_table.TableName
						, keycol
						, relcol ) );
				}
				//if( node.invoke_name_event )
				{
					parent_count++;
					if( base.parent_table == null )
						base.parent_table = node.table;
					else if( base.child_table == null )
						base.child_table = node.table;
				}
				if( node.invoke_name_event )
				{
					node.table.ColumnChanged += new DataColumnChangeEventHandler( table_ColumnChanged );
				}

				// additional rows in some tables may cause a link to relavent data.
				node.table.RowChanged += new DataRowChangeEventHandler( table_RowChanged );
				{
					XDataTable<DataRow> tmp = node.table as XDataTable<DataRow>;
					if( tmp != null )
						tmp.AcceptedChanges += new XDataTable.OnAcceptChanges( table_AcceptedChanges );
				}
			}

			_parents = new DataTable[parent_count];
			parent_count = 0;
			foreach( PathNode node in data_path )
			{
				//if( node.invoke_name_event )
				{
					parents[parent_count++] = node.table;
				}
			}

			if( base.parent_table == null )
				base.parent_table = _root_table;
			if( base.child_table == null )
				base.child_table = _terminal_table;
			if( extra_columns != null )
			{
				foreach( DataColumnMimicer mimic in extra_columns )
					Columns.Add( mimic.column_name, mimic.data_column.DataType );
			}
			// all prior nodes need to be first...
			AddDefaultColumns( true, true, false );
			if( add_number )
			{
				base.number_column = NumberColumn;
				Columns.Add( number_column, typeof( int ) );
			}
			else
				base.number_column = null;

			if( extra_data != null )
				foreach( DataColumn dc in extra_data )
					Columns.Add( dc );

			if( auto_fill )
			{
				// still - populate from all existing relations....
				Fill();
			}
		}


		List<DataRow> pending_restore_rows;
		void MetaMySQLRelation_RowDeleted( object sender, DataRowChangeEventArgs e )
		{
			if( RootTableUnique )
			{
				foreach( DataRow row in pending_restore_rows )
					FollowAndLoadRowFrom( row );
				pending_restore_rows.Clear();
				// need to rebuild this row
			}
			
		}

		void MetaMySQLRelation_RowDeleting( object sender, DataRowChangeEventArgs e )
		{
			if( RootTableUnique )
			{
				DataRow row = e.Row.GetParentRow( e.Row.Table.TableName + "_meta_" + _root_table.TableName );
				if( pending_restore_rows == null )
					pending_restore_rows = new List<DataRow>();
				// need to rebuild this row
				pending_restore_rows.Add( row );
			}
		}

		void table_AcceptedChanges()
		{
			CommitChanges();
		}

		/// <summary>
		/// Event handler when a row is changing
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void MetaMySQLRelation_RowChanging( object sender, DataRowChangeEventArgs e )
		{
			switch( e.Action )
			{
			case DataRowAction.Add:
				if( false )
				{
					// this deletes old rows that were here...
					// the newer logic should update existing rows appropriately
					StringBuilder sb = new StringBuilder();
					int pos = 0;
					bool first = true;
					foreach( PathNode node in data_path )
					{
						if( node.save_link )
						{
							if( e.Row[node.column_index].GetType() == typeof( DBNull ) )
							{
								// if any of these are DbNULL... fail.
								sb.Length = 0;
								break;
							}
							if( !first )
								sb.Append( " and " );
							first = false;
							sb.Append( node.keyname );
							sb.Append( "=" );
							sb.Append( DsnSQLUtil.GetSQLValue( null, e.Row[node.column_index].GetType(), e.Row[node.column_index] ) );
						}
						else if( node.invoke_name_event )
						{
							//pos++;
						}
					}
					if( sb.Length > 0 )
					{
						DataRow[] oldrow = Select( sb.ToString() );
						foreach( DataRow row in oldrow )
						{
							row.Delete();
						}
					}
				}
				break;
			}
		}

		protected delegate void NameChangeEvent( DataColumnChangeEventArgs e );
		protected event NameChangeEvent NameChanged;

		void table_ColumnChanged( object sender, DataColumnChangeEventArgs e )
		{
			if( NameChanged != null )
				if( e.Column.ColumnName == ( e.Row.Table as XDataTable<DataRow> ).NameColumn )
				{
					this.NameChanged( e );
				}
		}

		new protected void Fill()
		{
			// this fill only builds new records from 
			// the exisiting schedule data.
			//if( live )
			// load from database...
			base.Fill();
			// this done to seed any relations
			// that were not saved in the database
			// all rows here should be discarded...
			// unless it's a new relation, in which case
			// all current relations will be tracked
			foreach( DataRow row in _root_table.Rows )
			{
				if( row.RowState == DataRowState.Deleted )
					continue;
				FollowAndLoadRow( row );
				//CommitChanges();
			}
		}

		public void BuildDataRows( DsnConnection dsn )
		{
			// as a fill method.  (expected to load from database);
			// so I guess there should be no data already, so just fill it; probably non persistant(?)
			BuildDataRows( false );
		}

		public void BuildDataRows()
		{
			BuildDataRows( true );
		}

		public void BuildDataRows( bool clear )
		{
			if( clear )
				Rows.Clear();
			// this done to seed any relations
			// that were not saved in the database
			// all rows here should be discarded...
			// unless it's a new relation, in which case
			// all current relations will be tracked
			foreach( DataRow row in _root_table.Rows )
			{
				if( row.RowState == DataRowState.Deleted )
					continue;
				FollowAndLoadRow( row );
			}
			//CommitChanges();
		}

		new protected void Fill( string order_expression )
		{
			// this fill only builds new records from 
			// the exisiting schedule data.
			if( live )
				// load from database...
				base.Fill( null, order_expression );
			// this done to seed any relations
			// that were not saved in the database
			// all rows here should be discarded...
			// unless it's a new relation, in which case
			// all current relations will be tracked
			foreach( DataRow row in _root_table.Rows )
			{
				if( row.RowState == DataRowState.Deleted )
					continue;
				FollowAndLoadRow( row );
				//CommitChanges();
			}
		}

		/// <summary>
		/// creates a relationship which table1 is based as a root databable.  
		/// Additions to table2 which relate to table1 are traced via the path to their data.
		/// </summary>
		/// <param name="dataSet"></param>
		/// <param name="table"></param>
		/// <param name="path_from_2_to_source"></param>
		/// <param name="table2"></param>
		/// <param name="extra_mimic_columns">An array of extra column names to copy to this</param>
		public MetaMySQLRelation( DataSet dataSet
			, DataTable table
			, String path_from_2_to_source
			, bool add_number
			, DataColumn[] extra_data
			, String[] extra_mimic_columns
			)
		{
			Init( dataSet, table, path_from_2_to_source, add_number, extra_data, true, extra_mimic_columns );
		}

		/// <summary>
		/// creates a relationship which table1 is based as a root databable.  
		/// Additions to table2 which relate to table1 are traced via the path to their data.
		/// </summary>
		/// <param name="dataSet"></param>
		/// <param name="table"></param>
		/// <param name="path_from_2_to_source"></param>
		/// <param name="table2"></param>
		/// <param name="extra_mimic_columns">An array of extra column names to copy to this</param>
		public MetaMySQLRelation( DataSet dataSet
			, String tableName
			, DataTable table
			, String path_from_2_to_source
			, bool add_number
			, DataColumn[] extra_data
			, String[] extra_mimic_columns
			)
		{
			TableName = tableName;
			Init( dataSet, table, path_from_2_to_source, add_number, extra_data, true, extra_mimic_columns );
		}

		/// <summary>
		/// creates a relationship which table1 is based as a root databable.  
		/// Additions to table2 which relate to table1 are traced via the path to their data.
		/// </summary>
		/// <param name="dataSet"></param>
		/// <param name="table"></param>
		/// <param name="path_from_2_to_source"></param>
		/// <param name="table2"></param>
		public MetaMySQLRelation( DataSet dataSet
			, DataTable table
			, String path_from_2_to_source
			, bool add_number
			, DataColumn[] extra_data
			)
		{
			Init( dataSet, table, path_from_2_to_source, add_number, extra_data, true );
		}

		/// <summary>
		/// creates a relationship which table1 is based as a root databable.  
		/// Additions to table2 which relate to table1 are traced via the path to their data.
		/// </summary>
		/// <param name="dataSet"></param>
		/// <param name="table"></param>
		/// <param name="path_from_2_to_source"></param>
		/// <param name="table2"></param>
		public MetaMySQLRelation( DsnConnection odbc, DataSet dataSet
			, DataTable table
			, String path_from_2_to_source
			, bool add_number
			, bool auto_fill
			, DataColumn[] extra_data
			)
		{
			Init( odbc, dataSet, table, path_from_2_to_source, add_number, auto_fill, extra_data, true, null );
		}
		/// <summary>
		/// creates a relationship which table1 is based as a root databable.  
		/// Additions to table2 which relate to table1 are traced via the path to their data.
		/// </summary>
		/// <param name="dataSet"></param>
		/// <param name="tableName">name this table should be called</param>
		/// <param name="table"></param>
		/// <param name="path_from_2_to_source"></param>
		/// <param name="table2"></param>
		public MetaMySQLRelation( DsnConnection odbc, DataSet dataSet
			, String tableName
			, DataTable table
			, String path_from_2_to_source
			, bool add_number
			, bool auto_fill
			, DataColumn[] extra_data
			)
		{
			TableName = tableName;
			Init( odbc, dataSet, table, path_from_2_to_source, add_number, auto_fill, extra_data, true, null );
		}
		/// <summary>
		/// creates a relationship which table1 is based as a root databable.  
		/// Additions to table2 which relate to table1 are traced via the path to their data.
		/// </summary>
		/// <param name="dataSet"></param>
		/// <param name="table"></param>
		/// <param name="path_from_2_to_source"></param>
		/// <param name="table2"></param>
		public MetaMySQLRelation( DataSet dataSet
			, DataTable table
			, String path_from_2_to_source
			, bool add_number
			, bool auto_fill
			, DataColumn[] extra_data
			)
		{
			Init( dataSet, table, path_from_2_to_source, add_number, auto_fill, extra_data, true );
		}

		//public delegate void OnNewRow( DataRow row );
		//public event OnNewRow AddingRow;
		public delegate void OnFixupRow( DataRow row );
		public event OnFixupRow FixupRow;

		/// <summary>
		/// creates a relationship which table1 is based as a root databable.  
		/// Additions to table2 which relate to table1 are traced via the path to their data.
		/// </summary>
		/// <param name="dataSet"></param>
		/// <param name="table"></param>
		/// <param name="path_from_2_to_source"></param>
		/// <param name="table2"></param>
		protected MetaMySQLRelation( DataSet dataSet
			, DataTable table
			, String path_from_2_to_source
			, bool add_number
			, DataColumn[] extra_data
			, bool live
			)
		{
			Init( dataSet, table, path_from_2_to_source, add_number, extra_data, live );
		}

		void FillMimicColumns( DataRow building_row )
		{
			if( extra_columns != null )
			{
				foreach( DataColumnMimicer mimic in extra_columns )
				{
					DataRow parent = building_row.GetParentRow( mimic.node.meta_relation );
					if( parent != null )
						building_row[mimic.column_name] = parent[mimic.data_column.Ordinal];
				}
			}
		}

		/// <summary>
		///  this starts at a row in the root table, and populates the full relation through the path.
		///  building all rows which should be attached to the root row.
		/// </summary>
		/// <param name="row"></param>
		/// <returns></returns>
		private void FollowAndLoadRow( DataRow row )
		{
			DataRow[] seed = new DataRow[1];
			seed[0] = row;
			DataRow seed_row = null;
			//seed[0] = row[data_path[0].keyname];
			FollowAndLoadRowRec( ref seed_row, 0, 0, seed );
			//DataRow newrow = NewRow();
		}

		/// <summary>
		/// some arbitrary row within a row passed, all children loaded, all parents that led up to that row are also filled.
		/// </summary>
		/// <param name="row"></param>
		private void FollowAndLoadRowFromUsing( DataRow baserow, DataRow relrow
			, ref DataRow add_row
			, int index, int save_point
			, int backfill, int backpos )
		{
			DataRow current = relrow;
			if( current == null )
				return;
			{
				if( data_path[backfill].save_link )
				{
					if( backpos >= 0 )
						add_row[backpos] = current[data_path[backfill].keyname];
				}
				if( backfill > 0 )
				{
					if( data_path[ backfill - 1 ].follow_as_child )
					{
						DataRow[ ] parents = current.GetParentRows( data_path[ backfill - 1 ].relation.RelationName );
						foreach( DataRow parent in parents )
						{
							FollowAndLoadRowFromUsing( baserow, parent, ref add_row
								, index, save_point, backfill - 1, backpos - ( data_path[ backfill ].save_link ? 1 : 0 ) );
						}
					}
					else
					{
						DataRow[ ] children = current.GetChildRows( data_path[ backfill - 1 ].relation.RelationName );
						foreach( DataRow row in children )
						{
							FollowAndLoadRowFromUsing( baserow, row, ref add_row
								, index, save_point, backfill - 1, backpos - ( data_path[ backfill ].save_link ? 1 : 0 ) );
						}
					}
					//add_row.Delete();
				}
			}
			if( backfill == 0 )
			{
				DataRow[] child_rows;
				List<DataRow> use_child_rows = new List<DataRow>();
				if( data_path[index].follow_as_child )
				{
					child_rows = baserow.GetChildRows( data_path[index].relation );
					for( int n = 0; n < child_rows.Length; n++ )
					{
						if( InvokeAcceptNewChildRow( child_rows[n] ) )
						{
							use_child_rows.Add( child_rows[n] );
						}
					}
				}
				else
				{
					child_rows = baserow.GetParentRows( data_path[index].relation );
					for( int n = 0; n < child_rows.Length; n++ )
					{
						if( InvokeAcceptNewChildRow( child_rows[n] ) )
						{
							use_child_rows.Add( child_rows[n] );
						}
					}
				}

				FollowAndLoadRowRec( ref add_row
					, index + 1
					, save_point + (data_path[index].save_link?1:0)
					, use_child_rows.ToArray() );
			}
			//FollowAndLoadRow( ();

		}
		/// <summary>
		/// some arbitrary row within a row passed, all children loaded, all parents that led up to that row are also filled.
		/// </summary>
		/// <param name="row"></param>
		private void FollowAndLoadRowFrom( DataRow relrow )
		{
			int index = 0;
			int save_point = 0;
			DataRow add_row = NewRow();
			foreach( PathNode node in data_path )
			{
				if( node.table == relrow.Table )
				{
					DataRow current = relrow;
					FollowAndLoadRowFromUsing( relrow, relrow, ref add_row
						, index, save_point
						, index, save_point - ( node.save_link ? 0 : 1 ) );
					add_row.Delete();
					break;
				}
				if( node.save_link )
					save_point++;
				index++;
			}
			//FollowAndLoadRow( ();

		}
		private void FollowAndLoadRowRec( ref DataRow building_row, int index, int save_point, DataRow[] rows )
		{
			//DataTable table = row.Table;
			if( index == data_path.Count )
			{
				StringBuilder sb = new StringBuilder();
				if( _RootTableUnique )
				{
					sb.Append( XDataTable.ID( _root_table ) );
					sb.Append( "=" );
					sb.Append( DsnSQLUtil.GetSQLValue( null, building_row.Table.Columns[XDataTable.ID( _root_table )].DataType, building_row[XDataTable.ID( _root_table )] ) );
				}
				else
				{
					bool first_column = true;
					for( int n = 0; n < save_point; n++ )
					{
						if( !first_column )
							sb.Append( " and " );
						first_column = false;
						sb.Append( building_row.Table.Columns[n].ColumnName );
						sb.Append( "=" );
						sb.Append( DsnSQLUtil.GetSQLValue( null, building_row.Table.Columns[n].DataType, building_row[n] ) );
						//Log.log( "Table " + TableName + " selecting " + sb.ToString() );
					}
				}
				DataRow[] row_in_table = Select( sb.ToString() );
				if( index == (data_path.Count) && row_in_table.Length > 0 )
				{
					foreach( PathNode node in data_path )
					{
						if( node.table.TableName == _root_table.TableName )
							continue;
						if( node.save_link )
						{
							if( !row_in_table[0][node.keyname].Equals( building_row[node.keyname] ) )
								row_in_table[0][node.keyname] = building_row[node.keyname];
						}
					}

					//Log.log( "Found existing row (read already?) dropping new row." );
					if( extra_columns != null )
						FillMimicColumns( row_in_table[0] );
					building_row.Delete();
					return;
				}
				DataRow[] rows_in_table = null;
				if( number_column != null )
				{
					sb.Clear();
					if( _RootTableUnique )
					{
						sb.Append( XDataTable.ID( _root_table ) );
						sb.Append( "=" );
						sb.Append( DsnSQLUtil.GetSQLValue( null, building_row.Table.Columns[XDataTable.ID( _root_table )].DataType, building_row[XDataTable.ID( _root_table )] ) );
					}
					else
					{
						bool first_column = true;
						for( int n = 0; n < ( save_point - 1 ); n++ )
						{
							if( !first_column )
								sb.Append( " and " );
							first_column = false;
							sb.Append( building_row.Table.Columns[n].ColumnName );
							sb.Append( "=" );
							sb.Append( DsnSQLUtil.GetSQLValue( null, building_row.Table.Columns[n].DataType, building_row[n] ) );
						}
					}
					rows_in_table = Select( sb.ToString() );
				}
				// if the row is not already present.
				try
				{
					//Log.log( "Did not find existing row adding new row." );
					if( number_column != null )
						building_row[number_column] = rows_in_table.Length+1;
					InvokeAddingRow( building_row );

					if( InvokeAcceptNewRow( building_row ) )
					{
						Rows.Add( building_row );
						FillMimicColumns( building_row );
					}

					{
						object primary;
						DataRow clonedRow = building_row.Table.NewRow();
						primary = clonedRow[XDataTable.ID( building_row.Table )];
						
						clonedRow.ItemArray = building_row.ItemArray;
						clonedRow[XDataTable.ID( building_row.Table )] = primary;
						building_row = clonedRow;
					}
				}
				catch
				{
				}
			}
			else
			{
				//DataRow[] rows;

				string key = data_path[index].keyname;
				if( rows.Length == 0 )
				{
					if( _AllowPartialRows )
					{
						DataRow add_row = NewRow();

						for( int copy = 0; copy < save_point; copy++ )
							add_row[copy] = building_row[copy];
						if( InvokeAcceptNewRow( add_row ) )
						{
							Rows.Add( add_row );
							FillMimicColumns( add_row );
						}
					}
				}
				foreach( DataRow relrow in rows )
				{
					DataRow add_row = NewRow();

					for( int copy = 0; copy < save_point; copy++ )
						add_row[copy] = building_row[copy];
					if( data_path[index].save_link )
					{
						add_row[save_point] = relrow[key];
					}

					DataRow[] child_rows;
					List<DataRow> use_child_rows = new List<DataRow>();
					if( data_path[index].follow_as_child )
					{
						child_rows = relrow.GetChildRows( data_path[index].relation );
						for( int n = 0; n < child_rows.Length; n++ )
						{
							if( InvokeAcceptNewChildRow( child_rows[n] ) )
							{
								use_child_rows.Add( child_rows[n] );
							}
						}
					}
					else
					{
						child_rows = relrow.GetParentRows( data_path[index].relation );
						for( int n = 0; n < child_rows.Length; n++ )
						{
							if( InvokeAcceptNewChildRow( child_rows[n] ) )
							{
								use_child_rows.Add( child_rows[n] );
							}
						}
					}

					FollowAndLoadRowRec( ref add_row, index+1, data_path[index].save_link?save_point + 1:save_point, use_child_rows.ToArray() );
				}
			}
		}

		void table_RowDeleted( object sender, DataRowChangeEventArgs e )
		{
			if( e.Row.HasVersion( DataRowVersion.Original ) )
			{
				//string key = e.Row.Table.PrimaryKey[0].ColumnName;
				//DataRow[] deletions = Select( key + "=" + e.Row[key, DataRowVersion.Original].ToString() );
				//foreach( DataRow delete in deletions )
				//{
					//delete.Delete();
				//}
				if( number_column != null )
				{
					Log.log( "Fixing up row with a number. Relation member deleted (presumably from middle of sequence... fixing up numbers" );
					foreach( DataRow row in Rows )
					{
						if( row.RowState == DataRowState.Deleted )
							continue;
						if( FixupRow != null )
							FixupRow( row );
						//row[number_column] = number;
						//number++;
					}
				}
				//CommitChanges();
			}
		}

		void table_RowChanged( object sender, DataRowChangeEventArgs e )
		{
			if( e.Action == DataRowAction.Delete )
			{
				string key = ( e.Row.Table as XDataTable<DataRow> ).PrimaryKeyName;
				DataRow[] deletions = Select( key + "='" + e.Row[key] + "'" );
				foreach( DataRow delete in deletions )
				{
					delete.Delete();
				}
			}
			if( e.Action == DataRowAction.Add )//|| e.Action == DataRowAction.Commit )
			{
				if( filling )
					return;
				FollowAndLoadRowFrom( e.Row );
				//AcceptChanges();
			}
            if( e.Action == DataRowAction.Change )
            {
            }
		}


		void AddMimicColumns( PathNode node, String[] extra_mimic_columns )
		{
			int n;
			for( n = 0; n < extra_mimic_columns.Length; n++ )
			{
				String column = extra_mimic_columns[n];
				// if the column was already accounted for, skip it.
				if( column == null )
					continue;

				if( column.Contains( "." ) )
				{
					String table_name = column.Substring( 0, column.IndexOf( "." ) - 1 );
					if( table_name == node.table.TableName )
					{
						String column_name = column.Substring( column.IndexOf( "." ) + 1 );
						extra_columns.Add( new DataColumnMimicer( column, node.table.Columns[column_name], node ) );
						// consumed this one.
						extra_mimic_columns[n] = null;
					}
				}
				else foreach( DataColumn datacolumn in node.table.Columns )
				{
					if( datacolumn.ColumnName == column )
					{
						extra_columns.Add( new DataColumnMimicer( column, datacolumn, node ) );
					}
				}
			}
		}

		///
		// crazy notation
		// gonna have to work on that
		// . = mark this as a key point.
		// $ = if the name changes in this point, generate update events to self.
		// / = follow as a child relation preferred
		// \ = follow as a parent relation preferred

		/// <summary>
		/// Locate a table from the base table using the path string specified ( MySQLRelationMap.ToString() )
		/// crazy notation
		/// gonna have to work on that
		/// . = mark this as a key point.
		/// $ = if the name changes in this point, generate update events to self.
		/// / = follow as a child relation preferred
		/// \ = follow as a parent relation preferred
		/// 
		/// </summary>
		/// <param name="table"></param>
		/// <param name="path"></param>
		/// <returns></returns>
		DataTable FindTable( DataTable table, XString path, String[] extra_mimic_columns )
		{
			PathNode node;
			bool child_prefer = true;

			if( extra_mimic_columns != null )
				extra_columns = new List<DataColumnMimicer>();

			// add the first node of the path - the root table.
			{
				node = new PathNode();

				node.table = table;
				node.relation = null;
				node.keyname = XDataTable.ID( table );
				//node.follow_as_child = false;
				//node.save_link = true;
				data_path.Add( node );
				if( extra_mimic_columns != null )
					AddMimicColumns( node, extra_mimic_columns );
			}

			foreach( String seg in path )
			{
				switch( seg )
				{
				case ".":
					node.save_link = true;
					break;
				case "$":
					node.invoke_name_event = true;
					node.save_link = true;
					break;
				case "/":
					child_prefer = true;
					break;
				case "\\":
					child_prefer = false;
					break;
				default:
					bool found = false;
					foreach( DataRelation rel in table.ChildRelations )
					{
						if( ( rel.RelationName == seg )
							|| ( rel.ChildTable.TableName == seg ) )
						{
							node.relation = rel;
							node.follow_as_child = true;
							table = rel.ChildTable;
							found = true;
							if( table == null )
								return table;
							node = new PathNode();
							node.keyname = XDataTable.ID( table );// rel.ChildColumns[0].ColumnName;
							//node.relation = null;// rel;
							node.table = table;
							//node.follow_as_child = true;
							data_path.Add( node );
							if( extra_mimic_columns != null )
								AddMimicColumns( node, extra_mimic_columns );
							child_prefer = true;
							break;
						}
					}
					if( !found || !child_prefer )
						foreach( DataRelation rel in table.ParentRelations )
						{
							if( ( rel.RelationName == seg )
								|| ( rel.ParentTable.TableName == seg ) )
							{
								node.relation = rel;
								node.follow_as_child = false;

								table = rel.ParentTable;
								found = true;
								if( table == null )
									return table;
								node = new PathNode();
								node.keyname = XDataTable.ID( table ); //rel.ParentColumns[0].ColumnName;
								node.relation = null;// rel;
								node.table = table;
								node.follow_as_child = false;
								data_path.Add( node );
								if( extra_mimic_columns != null )
									AddMimicColumns( node, extra_mimic_columns );
								child_prefer = true;
								break;
							}
						}
					if( !found )
						throw new Exception( "Failed to find " + seg + " relation in " + table.TableName );
					break;
				}
			}
			return table;
		}

		/// <summary>
		/// They say this can be done with triggers; I don't beleive it; so I'm not sure how to build the triggerset rules
		/// </summary>
		public void ValidateTriggers()
		{
#if asdfasdf
			create trigger ai_eav
after insert on eav
for each row
begin
set @id=new.entity;
set @attribute=new.attribute;
set @value=new.value;
update pivot
set 
Author=(select if(@attribute='Author',@value,Author)),
Title=(select if(@attribute='Title',@value,Title)),
Publisher=(select if(@attribute='Publisher',@value,Publisher))
where
id=@id;
end
#endif
			//			CREATE
			//   [DEFINER = { user | CURRENT_USER }]
			//  TRIGGER trigger_name trigger_time trigger_event
			//  ON tbl_name FOR EACH ROW trigger_stmt

			// show create trigger <triggername>

			if( connection != null )
			{
				DbDataReader tmp = connection.KindExecuteReader( "show create trigger " );
			}

		}
	}

	public interface IMetaMySQLRelation
	{
		DataTable[] parents { get; }
		DataTable root_table { get; }
	}
}
