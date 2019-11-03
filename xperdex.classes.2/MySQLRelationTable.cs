using System;
using System.Data;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace xperdex.classes
{
	/// <summary>
	/// Common class used for MySQLRelationTable2.  COntains primary parent and child of information;  
	/// </summary>
	public class MySQLRelationTableBase<T> : MySQLDataTable<T>, IMySQLRelationTableBase
		where T : DataRow
	{
		public String _child_relation_colname;
		public String _parent_relation_colname;

		/// <summary>
		/// This is the table representing the group of this relation
		/// </summary>
		public DataTable _parent_table;
		public DataTable parent_table
		{
			get
			{
				return _parent_table;
			}
			set
			{
				_parent_table = value;
			}
		}

		/// <summary>
		/// This is the table representing the elements of the group in this relation
		/// </summary>
		public DataTable _child_table;
		public DataTable child_table
		{
			get
			{
				return _child_table;
			}
			set
			{
				_child_table = value;
			}
		}
		protected String _children_of_parent;
		protected String children_of_parent
		{
			get
			{
				return _children_of_parent;
			}
		}
		protected String _parent_of_child;
		protected String parent_of_child
		{
			get
			{
				return _parent_of_child;
			}
		}

		/// <summary>
		/// Used to receive an event when a row is duplicated 
		/// </summary>
		public event MySQLRelationTable.OnCloneRow CloneRow;
		public event MySQLRelationTable.OnNewRow AddingRow;
		public event MySQLRelationTable.OnRowOrderChange RowOrderChange;
		public event MySQLRelationTable.OnRowOrderChanged RowOrderChanged;

		public event MySQLRelationTable.OnAcceptNewRow AcceptNewRow;

		public bool InvokeAcceptNewRow( DataRow row )
		{
			if( AcceptNewRow != null )
			{
				MySQLRelationTable.MySQLRelationTableEventArgs args = new MySQLRelationTable.MySQLRelationTableEventArgs();
				args.accept = false;
				AcceptNewRow( args, row );
				return args.accept;
			}
			return true;
		}

		public event MySQLRelationTable.OnAcceptNewRow AcceptNewChildRow;
		public bool InvokeAcceptNewChildRow( DataRow row )
		{
			if( AcceptNewChildRow != null )
			{
				MySQLRelationTable.MySQLRelationTableEventArgs args = new MySQLRelationTable.MySQLRelationTableEventArgs();
				args.accept = false;
				AcceptNewChildRow( args, row );
				return args.accept;
			}
			return true;
		}
		/// <summary>
		/// Behavior flags; no_duplicates means not to allow the same member in the same group more than once.
		/// </summary>
		public bool no_duplicates;
		/// <summary>
		/// Each item in the relation has a number, which can be used as a persistant order of the elements in the group
		/// </summary>
		public bool _has_number;
		public bool has_number
		{
			get
			{
				return _has_number;
			}
		}

		/// <summary>
		/// Index of the number DataColumn (if there is one); -1 if this is not used
		/// </summary>
		int numcol;

		protected bool _RootTableUnique;
		/// <summary>
		/// This relation is unique only by the Root table (parent table) 
		/// It ends up enforcing a 1:1 relation between root elements and its relatives.
		/// </summary>
		public bool RootTableUnique
		{
			get
			{
				return _RootTableUnique;
			}
			set
			{
				if( _RootTableUnique != value )
				{
					_RootTableUnique = value;
					// repopulate the table based on the new settings
				}
			}
		}

		protected void InvokeAddingRow( DataRow row )
		{
			if( AddingRow != null )
				AddingRow( row );

		}

		void table_RowChanged( object sender, DataRowChangeEventArgs e )
		{
			if( e.Action == DataRowAction.Add )//|| e.Action == DataRowAction.Commit )
			{
				if( filling )
					return;
				if( AddingRow != null )
					AddingRow( e.Row );
			}
		}

		/// <summary>
		/// This class isn't suitable for use outside(yet?) so keep its constructor internal for MySQLRelationTable2
		/// </summary>
		internal MySQLRelationTableBase()
		{
			numcol = -1;
			RowDeleting += new DataRowChangeEventHandler( MySQLRelationTableBase_RowDeleting );
			RowChanged += new DataRowChangeEventHandler( table_RowChanged );
			Columns.CollectionChanged += new System.ComponentModel.CollectionChangeEventHandler( Columns_CollectionChanged );
		}

		void Columns_CollectionChanged( object sender, System.ComponentModel.CollectionChangeEventArgs e )
		{
			if( !has_number )
			{
				_has_number = XDataTable.HasNumber( this );
				if( _has_number )
					numcol = Columns[NumberColumn].Ordinal;
			} 
		}

		void MySQLRelationTableBase_RowDeleting( object sender, DataRowChangeEventArgs e )
		{
			DataRow row = e.Row;
			if( has_number && number_column != null )
			{
				int rownum = (row[number_column]==DBNull.Value)?0: Convert.ToInt32( row[number_column] );
				DataRow[] peers = Select( XDataTable.ID( parent_table ) + "='" + row[XDataTable.ID( parent_table )] + "'" );
				if( RowOrderChange != null )
					RowOrderChange();
				foreach( DataRow peer in peers )
				{
					if( peer[number_column] == DBNull.Value )
						peer[number_column] = 0;

					if( rownum >= Convert.ToInt32( peer[number_column] ) )
						continue;
					peer[number_column] = Convert.ToInt32( peer[number_column] ) - 1;
				}
				if( RowOrderChanged != null )
					RowOrderChanged();
			}
		}

		/// <summary>
		/// Return the relation name to the child side of the relation
		/// </summary>
		public String ChildrenOfParent
		{
			get
			{
				return children_of_parent;
			}
		}

		/// <summary>
		/// Return the relation name to the parent side of the relation
		/// </summary>
		public String ParentOfChild
		{
			get
			{
				return parent_of_child;
			}
		}

		/// <summary>
		/// Return the relation name from a Group row to the members in the group-member relation
		/// </summary>
		public String MembersOfGroup
		{
			get
			{
				return children_of_parent;
			}
		}

		/// <summary>
		/// Return the relation name to get the group row which has this group-member relation
		/// </summary>
		public String GroupContainingMember
		{
			get
			{
				return children_of_parent;
			}
		}

		/// <summary>
		/// Return the relation name from a group-member relation to the member row
		/// </summary>
		public String MemberInGroup
		{
			get
			{
				return parent_of_child;
			}
		}

		/// <summary>
		/// Return the relation name from a member element row to the group-member relation
		/// </summary>
		public String GroupsWithMember
		{
			get
			{
				return parent_of_child;
			}
		}

		/// <summary>
		/// For those relation rows that have abundant (more than number) extra data associated... Invokes CloneRow event
		/// </summary>
		/// <param name="group">new group to make copy in</param>
		/// <param name="member">member to add to this group</param>
		/// <param name="original">an original relation row from this table</param>
		/// <returns></returns>
		public DataRow CloneGroupMember( DataRow group, DataRow member, DataRow original )
		{
			DataRow newrow = AddGroupMember( group, member, true );
			if( newrow != null && CloneRow != null )
				CloneRow( newrow, original );
			return newrow;
		}

		public bool HasGroupMember( DataRow group, DataRow member )
		{
			return MySQLRelationTable.HasGroupMember( this, group, member );
		}

		/// <summary>
		/// Adds a member item to the group. Calls AddGroupMember( DataRow group, DataRow member, bool isadding ) with isadding true.
		/// </summary>
		/// <param name="group">data row that is the group to add to</param>
		/// <param name="member">data row that is the member to add to the group</param>
		/// <returns>the row representing the relation created</returns>
		public DataRow AddGroupMember( DataRow group, DataRow member )
		{
			return MySQLRelationTable.AddGroupMember( this, group, member, true, no_duplicates, false );
		}


		/// <summary>
		/// Adds a member item to the group. 
		/// </summary>
		/// <param name="group">data row that is the group to add to</param>
		/// <param name="member">data row that is the member to add to the group</param>
		/// <param name="isadding">controls whether RowOderChange[d] events are called</param>
		/// <returns>the row representing the relation created</returns>
		public DataRow AddGroupMember( DataRow group, DataRow member, bool isadding )
		{
			if( group == null )
			{
				MessageBox.Show( "Please select a current from " + parent_table.TableName + "." );
				return null;
			}
			return MySQLRelationTable.AddGroupMember( this, group, member, isadding, no_duplicates, false );
		}

		/// <summary>
		/// Put the group member before another member already in the group.
		/// </summary>
		/// <param name="group">Parent group to add a member to</param>
		/// <param name="member">Member to add</param>
		/// <param name="before">Who to add before - if null, insert at start of list</param>
		public DataRow InsertGroupMember( DataRow group, DataRow member, DataRow before )
		{
			if( before == null )
			{
				MessageBox.Show( "No target row selected to insert before" );
				return null;
			}
			if( RowOrderChange != null )
				RowOrderChange();
			DataRow row = AddGroupMember( group, member, false );
			IXDataTable group_table = group.Table as IXDataTable;
			if( group_table != null )
			{
				object finalkey = before[PrimaryKeyName];
				DataRow[] peers = Select( group_table.PrimaryKeyName + "='" + group[group_table.PrimaryKeyName] + "'", has_number ? NumberColumn : null );
				if( peers.Length > 2 )
				{
					int row_index;
					for( row_index = peers.Length - 2; row_index >= 0; row_index-- )
					{
						SwapRows( row, peers[row_index], false );
						if( peers[row_index][PrimaryKeyName].Equals( finalkey ) )
						{
							//row = peers[row_index];
							break;
						}
					}
					if( row_index < 0 )
						throw new Exception( "Failed to find row we were inserting before..." );
				}
			}
			if( RowOrderChanged != null )
				RowOrderChanged();
			return row;
		}

		/// <summary>
		/// Replaces the current group member with a new group member
		/// </summary>
		/// <param name="group">Parent group to add a member to</param>
		/// <param name="member">Member to update to</param>
		/// <param name="original">member to update</param>
		public DataRow ReplaceGroupMember( DataRow member, DataRow original )
		{
			original[XDataTable.ID( member.Table )] = member[XDataTable.ID( member.Table )];
			return original;
		}

		public void RemoveGroupMember( DataRow group, DataRow member )
		{
			DataRow[] found = this.Select( _child_relation_colname + "='" + member[_child_relation_colname] + "' and "
				+ _parent_relation_colname + "='" + group[_parent_relation_colname] + "'" );
			if( found.Length > 0 )
				foreach( DataRow f in found )
				{
					f.Delete();
				}
		}

		public void InvokeRowChanged()
		{
			if( RowOrderChanged != null )
				RowOrderChanged();
		}

		public void SwapRows( DataRow row, DataRow other_row )
		{
			SwapRows( row, other_row, true );
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="row"></param>
		/// <param name="other_row"></param>
		/// <param name="is_swap"> may be actually an insert - if not !is_swap, events are not triggered</param>
		void SwapRows( DataRow row, DataRow other_row, bool is_swap )
		{
			DataTable Table = row.Table;
			if( other_row == null )
				return;

			{
				if( is_swap && RowOrderChange != null )
					RowOrderChange();

				/* this is really what we want to do - just reverse the number  *
				 * however a dataset's rows (without a view additionally) are   *
				 * spacially relative and need to be physically reordered       */
				if( has_number )
				{
					object _2tmp = row[numcol];
					row[numcol] = other_row[numcol];
					other_row[numcol] = _2tmp;
				}
#if !null
				//if( false )
				{
					object tmp;
					object[] up = row.ItemArray;
					object[] down = other_row.ItemArray;

					bool using_key = false;
					int primkey = 0;
					// this is not really a change, noone should care.
					if( Table.PrimaryKey != null && Table.PrimaryKey.Length > 0 )
					{
						using_key = true;
						//Table.BeginLoadData();
						// have to keep the events on... otherwise constraints fail.
						primkey = Table.PrimaryKey[0].Ordinal;
						tmp = other_row[primkey];
						if( Table.PrimaryKey[0].DataType == typeof( Guid ) )
							down[primkey] = Guid.Empty;
						else
							down[primkey] = -1;
						//other[primkey] = -1; // if constrained, moving the item data will fail...
					}
					else
					{
						// wth!
						tmp = null;
						using_key = false;
					}

					//other.ItemArray = null;
					row.ItemArray = down;
					other_row.ItemArray = up;

					if( using_key )
					{
						row[primkey] = tmp;
					}
				}
#endif
				if( is_swap && RowOrderChanged != null )
					RowOrderChanged();
			}
		}

		public bool ContainsGroupMember( DataRow pack_row, DataRow dataRow )
		{
			return MySQLRelationTable.ContainsGroupMember( this.children_of_parent, pack_row, dataRow );
		}


		/// <summary>
		/// Returns null if group member is not present in this set
		/// </summary>
		/// <param name="pack_row">group row </param>
		/// <param name="dataRow">member row</param>
		/// <returns>datarow if group already contains member</returns>
		public DataRow GetGroupMember( DataRow pack_row, DataRow dataRow )
		{
			return MySQLRelationTable.GetGroupMember( children_of_parent, pack_row, dataRow );
		}


		/// <summary>
		/// removes all members with the same ID as the row passed
		/// </summary>
		/// <param name="pack_row">group which member is in</param>
		/// <param name="dataRow">member to delete</param>
		public void DeleteGroupMember( DataRow pack_row, DataRow dataRow )
		{
			DataRow[] members = pack_row.GetChildRows( children_of_parent );
			string otherkey = XDataTable.ID( dataRow.Table );
			object key = dataRow[otherkey];
			foreach( DataRow member in members )
			{
				if( member[otherkey].Equals( key ) )
					member.Delete();
			}
		}

		/// <summary>
		/// removes all members with the same ID as the row passed
		/// </summary>
		/// <param name="pack_row">group which member is in</param>
		/// <param name="dataRow">member to delete</param>
		public void DeleteAllGroupMembers( DataRow pack_row )
		{
			DataRow[] members = pack_row.GetChildRows( children_of_parent );
			foreach( DataRow member in members )
			{
				member.Delete();
			}
		}


		/// <summary>
		/// an Indicator that a row order change is in progress.
		/// </summary>
		bool moving;

		/// <summary>
		/// Used to move the order of a row up (replaces number)
		/// </summary>
		/// <param name="row"></param>
		public void MoveRowUp( DataRow row )
		{
			while( moving )
				System.Threading.Thread.SpinWait( 1 );
			{
				DataRow[] other_rows = Select( XDataTable.ID( parent_table ) + "='" + row[XDataTable.ID( parent_table )] + "' and " + XDataTable.Number( this ) + "=" + ( ( Convert.ToInt32( row[XDataTable.Number( this )] ) ) - 1 ).ToString() );
				if( other_rows.Length == 0 )
					return;
				DataRow MyOtherRow = other_rows[0];

				DataRow real_row = row;
				DataRow other_row = MyOtherRow;
				moving = true;
				object tmp;
				String NumberColumn = XDataTable.Number( this );
				tmp = real_row[NumberColumn];
				real_row[NumberColumn] = other_row[NumberColumn];
				other_row[NumberColumn] = tmp;

				//relation.SwapRows( real_row, other_row );
				// updating the names is good :) - without fill all.

				moving = false;
			}
		}

		public void MoveRowDown( DataRow row )
		{
			while( moving )
				System.Threading.Thread.SpinWait( 1 );
			{
				DataRow[] other_rows = Select( XDataTable.ID( parent_table ) + "='" + row[XDataTable.ID( parent_table )] + "' and " + XDataTable.Number( this ) + "=" + ( ( Convert.ToInt32( row[XDataTable.Number( this )] ) ) + 1 ).ToString() );
				if( other_rows.Length == 0 )
					return;
				DataRow MyOtherRow = other_rows[0];

				DataRow real_row = row;
				DataRow other_row = MyOtherRow;
				moving = true;

				object tmp;
				String NumberColumn = XDataTable.Number( this );

				tmp = real_row[NumberColumn];
				real_row[NumberColumn] = other_row[NumberColumn];
				other_row[NumberColumn] = tmp;

				//relation.SwapRows( real_row, other_row );

				// updating the names is good :) - without fill all.
				moving = false;
			}
		}

		public void InvokeRowOrderChanging( bool isadding )
		{
			if( isadding && RowOrderChange != null )
				RowOrderChange();
		}

		public void InvokeRowOrderChanged( bool isadding )
		{
			if( isadding && RowOrderChanged != null )
				RowOrderChanged();
		}


		public string child_relation_colname
		{
			get { return _child_relation_colname; }
		}

		public string parent_relation_colname
		{
			get { return _parent_relation_colname; }
		}
	}

	public interface IMySQLRelationTableBase : IXDataTable
	{
		DataTable child_table { get; set; }
		DataTable parent_table { get; set; }

		String ChildrenOfParent { get; }
		String ParentOfChild { get; }
		void InvokeRowOrderChanging( bool isadding );
		void InvokeRowOrderChanged( bool isadding );

		DataRow InsertGroupMember( DataRow group, DataRow member, DataRow before );
		DataRow AddGroupMember( DataRow group, DataRow member );
		DataRow AddGroupMember( DataRow group, DataRow member, bool isadding );
		DataRow CloneGroupMember( DataRow group, DataRow member, DataRow original );
		DataRow ReplaceGroupMember( DataRow member, DataRow original );
		void RemoveGroupMember( DataRow group, DataRow member );

		void MoveRowDown( DataRow row );
		void MoveRowUp( DataRow row );

		event MySQLRelationTable.OnRowOrderChange RowOrderChange;
		event MySQLRelationTable.OnRowOrderChanged RowOrderChanged;
		bool has_number { get; }

		String child_relation_colname { get; }

		String parent_relation_colname { get; }
	}

	public class MySQLRelationTable2<Parent, Child> : MySQLRelationTable2<DataRow, Parent, Child>
	{
		public MySQLRelationTable2()
		{
		}
		public MySQLRelationTable2( DataSet dataset ): base( dataset )
		{
		}
		public MySQLRelationTable2( DsnConnection dsn, DataSet dataset, bool auto_fill )
			: base( dsn, dataset, auto_fill )
		{
		}
		/*
		public MySQLRelationTable2( DsnConnection dsn, DataSet dataset, bool auto_fill, bool add_number )
			: base( dsn, dataset, auto_fill, add_number )
		{
		}
		public MySQLRelationTable2( DsnConnection odbc, System.Data.DataSet dataset, string prefix, string tablename, DataTable first, DataTable second, bool p_3, DataColumn[] dataColumn )
			: base( odbc, dataset, prefix, tablename, first, second, p_3, dataColumn )
		{

		}
		 */
	}

	/// <summary>
	/// A relation between two tables; creates a meta n:m relation table between the primary keys of two other tables.
	/// Uses the names of the tables passed to create table name.
	/// </summary>
	public class MySQLRelationTable2<T, Parent, Child> : MySQLRelationTableBase<T>
		where T : DataRow
	{
		public Parent real_parent_table;
		public Child real_child_table;
		String use_child_name;
		static Type ParentType = typeof( Parent );
		static String ParentName
		{
			get
			{
				FieldInfo fi = ParentType.GetField( "TableName", BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.GetField | BindingFlags.Static );
				if( fi != null )
					return fi.GetValue( null ).ToString();
				else
					return "???";
			}
		}
		static Type ChildType = typeof( Child );
		static String ChildName
		{
			get
			{

				FieldInfo fi = ChildType.GetField( "TableName", BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.GetField | BindingFlags.Static );
				if( fi != null )
					return fi.GetValue( null ).ToString();
				else
				{
					fi = ChildType.GetField( "TableName", BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.GetField | BindingFlags.Static );
					return "???";
				}
			}
		}

		public String child_name
		{
			get
			{
				if( use_child_name != null )
					return use_child_name;
				return MySQLRelationTable2<T, Parent, Child>.ChildName;
				return "???";
			}
		}

		static String _RelationName;
		public static String RelationName
		{
			get
			{
				if( _RelationName == null )
				{
					String val1 = null;
					string val2 = null;
					FieldInfo fi1 = ParentType.GetField( "TableName", BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.GetField | BindingFlags.Static );
					if( fi1 != null )
					{
						val1 = fi1.GetValue( null ).ToString();
					}
					FieldInfo fi2 = ChildType.GetField( "TableName", BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.GetField | BindingFlags.Static );
					if( fi2 != null )
					{
						val2 = fi2.GetValue( null ).ToString();
					}

					_RelationName = MySQLDataTable.GetRelationName( val1, val2 );
				}
				return _RelationName;
			}

		}

		/// <summary>
		/// If meta relation is set, then the data is not read from the database, but is built from the related tables.
		/// </summary>
		bool meta_relation;
		//private DsnConnection odbc;
		//private System.Data.DataSet dataset;
		public bool MetaRelation
		{
			set
			{
				meta_relation = value;
			}
		}
		/// <summary>
		/// add a bool for no sql backend (Create(), Fill())
		/// </summary>
		/// <param name="prefix"></param>
		/// <param name="name"></param>
		/// <param name="first"></param>
		/// <param name="second"></param>
		/// <param name="dataset"></param>
		protected void init( string prefix, string name, DataTable first, DataTable second, DataSet dataset, bool auto_fill )
		{
			init( prefix, name, first, second, dataset, auto_fill, null );
		}

		/// <summary>
		/// Extended Init; this sets up the relation using XDataTables in a dataset.
		/// </summary>
		/// <param name="prefix">Prefix of the table</param>
		/// <param name="name">base name o the table</param>
		/// <param name="first">group datatable</param>
		/// <param name="second">member of group datatable</param>
		/// <param name="dataset">what dataset to create this relation in</param>
		/// <param name="auto_fill">Automatically creates the datatable and loads the information from a database</param>
		/// <param name="extra">additional text to add to the create table generated</param>
		protected void init( string prefix, string name, DataTable first, DataTable second, DataSet dataset, bool auto_fill, string extra, string real_related_tablename = null )
		{
			DataColumn dc1 = null;
			DataColumn dc2 = null;

			IXDataTable x_first = first as IXDataTable;
			DataTable dt_first = first as DataTable;
			IXDataTable x_second = second as IXDataTable;
			DataTable dt_second = second as DataTable;

			if( first == null )
				x_first = dataset.Tables[ParentName] as IXDataTable;
			if( second == null )
			{
				if( real_related_tablename != null )
				{
					x_second = dataset.Tables[real_related_tablename] as IXDataTable;
					dt_second = dataset.Tables[real_related_tablename];
				}
				else
				{
					x_second = dataset.Tables[ChildName] as IXDataTable;
					dt_second = dataset.Tables[ChildName];
				}
			}
			if( x_first != null && x_first.auto_id != null )
				dc1 = x_first.auto_id;
			else
				foreach( DataColumn dc in ( first as DataTable ).Columns )
				{
					if( dc.AutoIncrement )
						dc1 = dc;
				}
			if( dc1 == null )
			{
				if( dt_first.PrimaryKey != null )
					dc1 = dt_first.PrimaryKey[0];
				if( dc1 == null )
					throw new Exception( "table " + first + " does not have an auto increment column to auto relate." );
			}
			if( x_second != null && x_second.auto_id != null )
				dc2 = x_second.auto_id;
			else
				foreach( DataColumn dc in ( dt_second ).Columns )
				{
					if( dc.AutoIncrement )
						dc2 = dc;
				}
			if( dc2 == null )
			{
				if( dt_second.PrimaryKey != null )
					dc2 = dt_second.PrimaryKey[0];
				if( dc2 == null )
					throw new Exception( "table " + second + " does not have an auto increment column to auto relate." );
			}
			init( prefix, name, first, dc1.ColumnName, second, dc2.ColumnName, dataset, auto_fill, null );
		}

		/// <summary>
		/// Lowest level init finsihes setting up actual relationships
		/// </summary>
		/// <param name="prefix">prefix name of the table</param>
		/// <param name="name">base name of the table</param>
		/// <param name="first">Group table</param>
		/// <param name="first_key">Group table key column name</param>
		/// <param name="second">Member table</param>
		/// <param name="second_key">Member table key column name</param>
		/// <param name="dataset">dataset to create relation in</param>
		/// <param name="auto_fill">Auto create table in the database and load information (during this constructor)</param>
		/// <param name="extra">extra sql to add to create table statement genrated</param>
		/// <param name="auto_add_primary_count">Indicates whether to add the number column for ordering elements in the group</param>
		void init( string prefix, string name
			, DataTable first, string first_key
			, DataTable second, string second_key
			, DataSet dataset, bool auto_fill, string extra
			, bool auto_add_primary_count )
		{

			if( first == null )
			{
				//real_parent_table = (Parent)first;
				//real_child_table = second;

				parent_table = dataset.Tables[ParentName];
				child_table = dataset.Tables[child_name];
			}
			else
			{
				//real_parent_table = (Parent)first;
				//real_child_table = second;
				parent_table = first;
				child_table = second;
			}
			if( first_key == null )
			{
				IXDataTable _parent_table = parent_table as IXDataTable;
				if( parent_table != null )
				{
					if( _parent_table.auto_id != null )
						first_key = _parent_table.auto_id.ColumnName;
				}
			}
			if( second_key == null )
			{
				IXDataTable _child_table = child_table as IXDataTable;
				if( _child_table.auto_id != null )
					second_key = _child_table.auto_id.ColumnName;
			}
			if( name == null )
			{
				IXDataTable _this_table = this as IXDataTable;

				string name1 = _this_table.XTableName;
				if( name1 == "" )
					name1 = MySQLDataTable.GetRelationName( parent_table, child_table );
				TableName = name1;
			}
			else
				TableName = name;
			if( prefix == null )
				Prefix = parent_table.Prefix;
			else
				Prefix = prefix;

			//if( auto_add_primary_count )
			AddDefaultColumns( false, true, false );

			if( dataset == null )
				dataset = parent_table.DataSet;


			DataColumn dc1 = parent_table.Columns[first_key];
			DataColumn dc2 = child_table.Columns[second_key];
			DataColumn dcme1 = Columns.Add( first_key, dc1.DataType );
			DataColumn dcme2 = Columns.Add( second_key, dc2.DataType );
			_child_relation_colname = second_key;
			_parent_relation_colname = first_key;
			if( auto_add_primary_count )
			{
				number_column = XDataTable.Number( this );
				Columns.Add( number_column, typeof( int ) );
			}

			if( dataset != null )
			{
				if( !dataset.Tables.Contains( ( this as DataTable ).TableName ) )
					dataset.Tables.Add( this );
				else
				{
					int a = 3;
				}
				try
				{
					//children_of_parent = StripPlural( StripInfo( this.TableName ) ) + "_has_" + StripPlural( StripInfo( child_table.TableName ) );
					_children_of_parent = StripPlural( StripInfo( parent_table.TableName ) ) + "_has_" + StripPlural( StripInfo( child_table.TableName ) );
					if( dataset.Relations.Contains( children_of_parent ) )
						_children_of_parent = StripPlural( StripInfo( this.TableName ) ) + "_has_" + StripPlural( StripInfo( child_table.TableName ) );
					dataset.Relations.Add( children_of_parent, dc1, dcme1 );
				}
				catch( Exception e )
				{
					Log.log( e.Message );
				}
				try
				{
					_parent_of_child = StripPlural( StripInfo( child_table.TableName ) ) + "_in_" + StripPlural( StripInfo( parent_table.TableName ) );
					if( dataset.Relations.Contains( parent_of_child ) )
						_parent_of_child = StripPlural( StripInfo( child_table.TableName ) ) + "_in_" + StripPlural( StripInfo( this.TableName ) );
					dataset.Relations.Add( parent_of_child, dc2, dcme2 );
				}
				catch( Exception e )
				{
					Log.log( e.Message );
				}

				if( auto_fill )
				{
					DsnSQLUtil.CreateDataTable( connection, this, extra, false, false );
					Fill( null, number_column );
				}
			}
		}

		/// <summary>
		/// Public method to fill this table with all information in the database (intended for small datasets)
		/// </summary>
		new public void Fill()
		{
			base.Fill( null, ( number_column == null ) ? PrimaryKeyName : number_column );
		}

		/// <summary>
		/// Another Init layer wrapper to cover evolution
		/// </summary>
		/// <param name="prefix">table prefix </param>
		/// <param name="name">table name</param>
		/// <param name="first">data table that is the group</param>
		/// <param name="first_key">primary key of group</param>
		/// <param name="second">data table that is the members</param>
		/// <param name="second_key">primary key of members</param>
		/// <param name="dataset">dataset to create relation in</param>
		/// <param name="auto_fill">auto create in database and load information</param>
		/// <param name="extra">extra SQL to add to create table</param>
		protected void init( string prefix, string name
			, DataTable first, string first_key
			, DataTable second, string second_key
			, DataSet dataset, bool auto_fill, string extra )
		{
			init( prefix, name
				, first, first_key
				, second, second_key
				, dataset, auto_fill, extra, true );
		}

		public MySQLRelationTable2( DsnConnection odbc, System.Data.DataSet set )
		{
			// TODO: Complete member initialization
			this.connection = odbc;
			init( null, null, null, null, set, false );
		}
		public MySQLRelationTable2( DataTable first, DataTable second )
		{
			init( null, MySQLDataTable.GetRelationName( ( first as DataTable ).TableName, ( second as DataTable ).TableName ), first, second, null, true );
		}
		MySQLRelationTable2( string name, DataTable first, DataTable second )
		{
			init( null, name, first, second, null, true );
		}

		MySQLRelationTable2( DataSet dataset, DataTable first, DataTable second )
		{
			init( ( first as DataTable ).Prefix, MySQLDataTable.GetRelationName( ( first as DataTable ).TableName, ( second as DataTable ).TableName ), first, second, dataset, true );
		}

		public MySQLRelationTable2( DataSet dataset )
		{
			init( null, null, null, null, dataset, false );
		}

		public MySQLRelationTable2( DataSet dataset, String real_related_tablename )
		{
			use_child_name = real_related_tablename;
			init( null, null, null, null, dataset, false, null, real_related_tablename );
		}

		public MySQLRelationTable2( DataSet dataset, DataTable first, String first_keyname, DataTable second, String second_keyname )
		{
			init( null, null, first, first_keyname, second, second_keyname, dataset, false, null, true );
		}

		public MySQLRelationTable2( DsnConnection dsn, DataSet dataset, bool auto_fill )
		{
			this.connection = dsn;
			init( null, null, null, null, dataset, auto_fill );
		}
		MySQLRelationTable2( DsnConnection dsn, DataSet dataset, bool auto_fill, bool add_number )
		{
			this.connection = dsn;
			init( null, null, null, null, null, null, dataset, auto_fill, null, add_number );
		}

		MySQLRelationTable2( DsnConnection dsn, DataSet dataset, DataTable first, DataTable second )
		{
			this.connection = dsn;
			init( ( first as DataTable ).Prefix, MySQLDataTable.GetRelationName( ( first as DataTable ).TableName, ( second as DataTable ).TableName ), first, second, dataset, true );
		}

		MySQLRelationTable2( DataSet dataset, DataTable first, DataTable second, bool auto_fill )
		{
			init( null, MySQLDataTable.GetRelationName( first.TableName, second.TableName )
				, first, second, dataset, auto_fill );
		}

		MySQLRelationTable2( string name, DataTable first, string first_key, DataTable second, string second_key )
		{
			init( null, name, first, first_key, second, second_key, null, true, null );
		}

		MySQLRelationTable2( DsnConnection dsn, DataSet dataset, DataTable first, DataTable second, bool auto_fill )
		{
			this.connection = dsn;
			init( null, MySQLDataTable.GetRelationName( ( first as DataTable ).TableName, ( second as DataTable ).TableName ), first, second, dataset, auto_fill );
		}

		MySQLRelationTable2( DsnConnection dsn, DataSet dataset, String prefix, DataTable first, DataTable second, bool auto_fill )
		{
			this.connection = dsn;
			init( prefix, MySQLDataTable.GetRelationName( ( first as DataTable ).TableName, ( second as DataTable ).TableName ), first, second, dataset, auto_fill );
		}

		MySQLRelationTable2( DataSet dataset, DataTable first, DataTable second, bool auto_fill, string prefix, string extra )
		{
			init( prefix, MySQLDataTable.GetRelationName( ( first as DataTable ).TableName, ( second as DataTable ).TableName ), first, second, dataset, auto_fill, extra );
		}


		internal MySQLRelationTable2( DsnConnection dsn, DataSet dataset, String prefix, String name, DataTable first, DataTable second, bool auto_fill )
		{
			this.connection = dsn;
			init( prefix, name, first, second, dataset, auto_fill );
		}


		/// <summary>
		/// only those who inherit from this table should be allowed to use this constructor.
		/// </summary>
		protected MySQLRelationTable2()
		{
		}


		public MySQLRelationTable2( DsnConnection odbc, System.Data.DataSet dataset, string prefix, string tablename, DataTable first, DataTable second, bool p_3, DataColumn[] dataColumn )
		{
			init( prefix, tablename, first, XDataTable.ID( first ), second, XDataTable.ID( second ), dataset, false, null, true );
			if( dataColumn != null )
				foreach( DataColumn dc in dataColumn )
				{
					this.Columns.Add( dc );
				}
		}

		// setup a number, child data row, parent_id relation
		public virtual DataRow Define( int number, DataRow dataRow, Object parent_id )
		{
			DataRow[] rows = this.Select( Columns[3].ColumnName + "=" + number + " and " + Columns[1] + "=" + parent_id.ToString() );
			if( rows.Length == 0 )
			{
				DataRow dr = NewRow();
				dr[Columns[3].ColumnName] = number;
				dr[Columns[1].ColumnName] = parent_id;
				dr[Columns[2].ColumnName] = dataRow[Columns[2].ColumnName];
				Rows.Add( dr );
				return dr;
			}
			throw new Exception( "The method or operation is not implemented." );
		}
	}

	/// <summary>
	/// This class represents a relation that results because of other relations in the database.
	/// Used to build MetaMySQLRelation tables
	/// This is sort of a join-view map of how these other rows get built.
	/// They say this can be done as a trigger in a database and or stored procedures
	/// A relation using a map can also have additional information added at each relation point.
	/// 
	/// 
	/// crazy notation
	/// gonna have to work on that
	/// . = mark this as a key point.
	/// $ = if the name changes in this point, generate update events to self.
	/// / = follow as a child relation preferred
	/// \ = follow as a parent relation preferred
	/// </summary>
	public class MySQLRelationMap
	{
		/// <summary>
		/// Operations for meta relation to follow
		/// </summary>
		public enum MapOp
		{
			FollowToChild  // go to next table though child relation
			,
			FollowToParent // go to next table through parent relation
				,
			SaveRelationPoint // save this point as a relation point
				,
			InvokNameChangeEvent
				, FollowTo  // follow to table through either parent or child relations 
		};
		object[] path;
		public MySQLRelationMap( object[] path )
		{
			this.path = path;
		}

		public override string ToString()
		{
			bool finding_table = false;
			DataTable root = null;
			StringBuilder sb = new StringBuilder();
			foreach( object node in path )
			{
				String s = node as string;
				if( s != null )
				{
					if( finding_table )
					{
						foreach( DataRelation dr1 in root.ChildRelations )
						{
							foreach( DataRelation dr2 in dr1.ChildTable.ParentRelations )
							{
								if( dr2.ParentTable.TableName == s )
								{
									// found it.
									finding_table = false;
									sb.Append( "/" + dr1.RelationName + ".\\" + dr2.RelationName );
									//sb.Append( dr1.RelationName + "$\\" + dr2.RelationName );
									root = dr2.ParentTable;
									break;
								}
							}
							if( finding_table )
								foreach( DataRelation dr2 in dr1.ChildTable.ChildRelations )
								{
									if( dr2.ChildTable.TableName == s )
									{
										// found it.
										finding_table = false;
										sb.Append( "/" + dr1.RelationName + "./" + dr2.RelationName );
										root = dr2.ChildTable;
										break;
									}
								}
							if( !finding_table )
								break;
						}
						if( finding_table )
							foreach( DataRelation dr1 in root.ParentRelations )
							{
								foreach( DataRelation dr2 in dr1.ParentTable.ChildRelations )
								{
									if( dr2.ChildTable.TableName == s )
									{
										// found it.
										finding_table = false;
										sb.Append( "\\" + dr1.RelationName + ".\\" + dr2.RelationName );
										root = dr2.ChildTable;
										break;
									}
								}
								if( !finding_table )
									break;
								foreach( DataRelation dr2 in dr1.ParentTable.ParentRelations )
								{
									if( dr2.ParentTable.TableName == s )
									{
										// found it.
										finding_table = false;
										sb.Append( "\\" + dr1.RelationName + ".\\" + dr2.RelationName );
										root = dr2.ParentTable;
										break;
									}
								}
								if( !finding_table )
									break;
							}
					}
					else
					{

						sb.Append( s );
					}
				}
				else
				{
					IXDataTable xtable = node as IXDataTable;
					if( xtable != null )
					{
						root = node as DataTable;
					}
					else
					{
						MapOp op = (MapOp)node;
						switch( op )
						{
						case MapOp.FollowToChild:
							sb.Append( "/" );
							break;
						case MapOp.FollowToParent:
							sb.Append( "\\" );
							break;
						case MapOp.SaveRelationPoint:
							sb.Append( "." );
							break;
						case MapOp.InvokNameChangeEvent:
							sb.Append( "$" );
							break;

						case MapOp.FollowTo:
							finding_table = true;
							break;
						}
					}
				}
			}
			return sb.ToString();
		}
	}

	public class MySQLRelationTable : MySQLRelationTable2<DataRow,DataTable,DataTable>
	{
		public delegate void OnCloneRow( DataRow row, DataRow original );
		public delegate void OnNewRow( DataRow row );

		public class MySQLRelationTableEventArgs : EventArgs
		{
			public bool accept;
		}

		public MySQLRelationTable()
		{
		}
		public MySQLRelationTable( DsnConnection dsn, DataSet dataset, String prefix, String name, DataTable first, DataTable second, bool auto_fill )
			: base( dsn, dataset, prefix, name,  first, second, auto_fill )
		{
		}

		public MySQLRelationTable( DataSet dataset, String prefix, String name, DataTable first, DataTable second )
			: base( null, dataset, prefix, name, first, second, false )
		{
		}

		public delegate void OnAcceptNewRow( MySQLRelationTableEventArgs args, DataRow row );

		public delegate void OnRowOrderChange();
		public delegate void OnRowOrderChanged();

		/// <summary>
		/// Adds a member item to the group. 
		/// </summary>
		/// <param name="group">data row that is the group to add to</param>
		/// <param name="member">data row that is the member to add to the group</param>
		/// <param name="isadding">controls whether RowOderChange[d] events are called</param>
		/// <returns>the row representing the relation created</returns>
		public static DataRow AddGroupMember( DataTable set, DataRow group
			, DataRow member
			, bool isadding
			, bool disallow_duplication )
		{
			return AddGroupMember( set, group, member, isadding, disallow_duplication, false );
		}

		public static bool HasGroupMember( DataTable set, DataRow group, DataRow member )
		{
			IMySQLRelationTableBase IrelationSet = set as IMySQLRelationTableBase;
			DataRow[] found = set.Select( XDataTable.ID( member.Table ) + "='" + member[XDataTable.ID( member.Table )] + "' and "
							+ XDataTable.ID( group.Table ) + "='" + group[XDataTable.ID( group.Table )] + "'" );
			if( found.Length > 0 )
			{
				//throw new Exception( "Relation already exists : " + child_table.TableName + "." + member[child_table.DisplayMemberName].ToString() + " in " + parent_table.TableName + "." + group[parent_table.DisplayMemberName].ToString() );
				if( IrelationSet != null )
					Log.log( "Relation already exists : " + IrelationSet.child_table.TableName + "." + member[XDataTable.Name( IrelationSet.child_table )].ToString() + " in " + IrelationSet.parent_table.TableName + "." + group[XDataTable.Name( IrelationSet.parent_table )].ToString() + " (Ignoring addition)" );
				else
					Log.log( "Relation already existed... need more info?" );
				return true;
			}
			return false;
		}

		/// <summary>
		/// Adds a member item to the group. 
		/// </summary>
		/// <param name="set">This is the table that is the relation</param>
		/// <param name="group">data row that is the group to add to</param>
		/// <param name="member">data row that is the member to add to the group</param>
		/// <param name="isadding">controls whether RowOderChange[d] events are called</param>
		/// <param name="disallow_duplication">The combintion of group-member can only exist once</param>
		/// <param name="one_to_one">Relation is one-to-one, parent only can relate to one child</param>
		/// <returns>the row representing the relation created</returns>
		public static DataRow AddGroupMember( DataTable set, DataRow group
			, DataRow member
			, bool isadding
			, bool disallow_duplication
			, bool one_to_one
			)
		{
			//MySQLRelationTableBase<DataRow> relationSet = set as MySQLRelationTableBase<DataRow>;
			IMySQLRelationTableBase IrelationSet = set as IMySQLRelationTableBase;
			if( group == null )
			{
				return null;
			}
			if( one_to_one )
			{
				DataRow[] found = set.Select(
								XDataTable.ID( group.Table ) + "='" + group[XDataTable.ID( group.Table )] + "'" );
				if( found.Length > 0 )
				{
					found[0][XDataTable.ID( member.Table )] = member[XDataTable.ID( member.Table )];
					return found[0];
				}
			}
			if( disallow_duplication )
			{
				DataRow[] found = set.Select( XDataTable.ID( member.Table ) + "='" + member[XDataTable.ID( member.Table )] + "' and "
								+ XDataTable.ID( group.Table ) + "='" + group[XDataTable.ID( group.Table )] + "'" );
				if( found.Length > 0 )
				{
					//throw new Exception( "Relation already exists : " + child_table.TableName + "." + member[child_table.DisplayMemberName].ToString() + " in " + parent_table.TableName + "." + group[parent_table.DisplayMemberName].ToString() );
					if( IrelationSet != null )
						Log.log( "Relation already exists : " + IrelationSet.child_table.TableName + "." + member[XDataTable.Name( IrelationSet.child_table )].ToString() + " in " + IrelationSet.parent_table.TableName + "." + group[XDataTable.Name( IrelationSet.parent_table )].ToString() + " (Ignoring addition)" );
					else
						Log.log( "Relation already existed... need more info?" );
					return found[0];
				}
				/*
					found = set.Select( XDataTable.ID( member.Table ) + "='" + member[XDataTable.ID( member.Table )] +"'" );
					if( found.Length > 0 )
					{
						//throw new Exception( "Relation already exists : " + child_table.TableName + "." + member[child_table.DisplayMemberName].ToString() + " in " + parent_table.TableName + "." + group[parent_table.DisplayMemberName].ToString() );
						found[0][XDataTable.ID(member.Table)] = member[XDataTable.ID(member.Table)];
						return found[0];
					}
				 */
			}

			DataRow row = set.NewRow();
			if( member == null )
				row[XDataTable.ID( IrelationSet.child_table )] = DBNull.Value;
			else
				row[IrelationSet.child_relation_colname] = member[IrelationSet.child_relation_colname];
			row[IrelationSet.parent_relation_colname] = group[IrelationSet.parent_relation_colname];
			if( IrelationSet != null && IrelationSet.has_number )
			{
				object tmp_max = set.Compute( "max(" + XDataTable.Number( set ) + ")+1", XDataTable.ID( group.Table ) + "='" + group[XDataTable.ID( group.Table )] + "'" );
				if( tmp_max.GetType() == typeof( DBNull ) )
					tmp_max = 1;
				row[XDataTable.Number( set )] = tmp_max;
			}
			try
			{
				if( IrelationSet != null )
					IrelationSet.InvokeRowOrderChanging( isadding );
				set.Rows.Add( row );
				if( IrelationSet != null )
					IrelationSet.InvokeRowOrderChanged( isadding );
				//CommitChanges();
			}
			catch
			{
				// probably the row already existed... and the addition was aborted?
				row = null;
			}
			return row;
		}

		/// <summary>
		/// Returns true if a group member is present in this set
		/// </summary>
		/// <param name="pack_row">group row </param>
		/// <param name="dataRow">member row</param>
		/// <returns>true if group already contains member</returns>
		public static bool ContainsGroupMember( String relation_name, DataRow pack_row, DataRow dataRow )
		{
			DataRow[] members = pack_row.GetChildRows( relation_name );
			string otherkey = XDataTable.ID( dataRow.Table );
			foreach( DataRow member in members )
			{
				if( member[otherkey].Equals( dataRow[otherkey] ) )
					return true;
			}
			return false;
		}

		/// <summary>
		/// Returns null if group member is not present in this set
		/// </summary>
		/// <param name="pack_row">group row </param>
		/// <param name="dataRow">member row</param>
		/// <returns>datarow if group already contains member</returns>
		public static DataRow GetGroupMember( String relation_name, DataRow pack_row, DataRow dataRow )
		{
			DataRow[] members = pack_row.GetChildRows( relation_name );
			string otherkey = XDataTable.ID( dataRow.Table );
			foreach( DataRow member in members )
			{
				if( member[otherkey].Equals( dataRow[otherkey] ) )
					return member;
			}
			return null;
		}

	}

#if asdfasdf
	public class MySQLRelationTable2<Parent, Child> : MySQLRelationTable2<DataRow,Parent,Child>
	{
		public MySQLRelationTable2( DataSet dataset, DataTable first, DataTable second, bool auto_fill )
			: base( dataset, first, second, auto_fill )
		{
		}

		public MySQLRelationTable2( DsnConnection dsn, DataSet dataset, DataTable first, DataTable second, bool auto_fill )
			: base( dsn, dataset, first, second, auto_fill )
		{
		}
		public MySQLRelationTable2( DsnConnection dsn, DataSet dataset, String prefix, DataTable first, DataTable second, bool auto_fill )
			: base( dsn, dataset, prefix, first, second, auto_fill )
		{
		}
		public MySQLRelationTable2( DsnConnection dsn, DataSet dataset, String prefix, String name, DataTable first, DataTable second, bool auto_fill )
			: base( dsn, dataset, prefix, name, first, second, auto_fill )
		{
		}
		public MySQLRelationTable2( DsnConnection dsn, DataSet dataset, bool auto_fill )
			: base( dsn, dataset, auto_fill )
		{
		}
		public MySQLRelationTable2( DsnConnection dsn, DataSet dataset, bool auto_fill, bool add_number )
			: base( dsn, dataset, auto_fill, add_number )
		{
		}
		

		public MySQLRelationTable2( DsnConnection dsn, DataSet dataset, DataTable first, DataTable second )
			: base( dsn, dataset, first, second )
		{
		}


		public MySQLRelationTable2( DataSet dataset, DataTable first, DataTable second, bool auto_fill, string prefix, string extra )
			: base( dataset, first, second, auto_fill, prefix, extra )
		{
		}
		public MySQLRelationTable2( DataSet dataset, DataTable first, DataTable second )
			: base( dataset, first, second )
		{
		}
		public MySQLRelationTable2( DataTable first, DataTable second )
			: base( first, second )
		{
		}
		public MySQLRelationTable2( string name, DataTable first, DataTable second )
			: base( name, first, second )
		{
		}
		public MySQLRelationTable2( string name, DataTable first, string first_key, DataTable second, string second_key )
			: base( name, first, first_key, second, second_key )
		{
		}
		/// <summary>
		/// only those who inherit from this table should be allowed to use this constructor.
		/// </summary>
		protected MySQLRelationTable2()
			: base()
		{
		}

		public MySQLRelationTable2( DsnConnection odbc, System.Data.DataSet set )
			: base( odbc, set )
		{
		}

		public MySQLRelationTable2( DsnConnection odbc, System.Data.DataSet dataset, string prefix, string tablename
			, DataTable first, DataTable second, bool p_3, DataColumn[] dataColumn )
			: base( odbc, dataset, prefix, tablename, first, second, p_3, dataColumn )
		{
		}
	}
#endif
}
