using System;
using System.Data;
using xperdex.classes;
//using System.Windows.Forms;

namespace OpenSkieScheduler3.Relations
{
	/// <summary>
	/// Used to be a data table that can auto-populate based on
	/// selected parent relationship items.  (should use CurrentObjectDataView instead)
	/// </summary>
	public class CurrentObjectTableView : XDataTable<DataRow>
	{

		new public static String TableName( String name )
		{
			return "current_" + name;
		}
		IXDataTable children;
		IXDataTable parents;
		IXDataTable[] all_parents;
		protected IMySQLRelationTableBase relation;
		public DataTable relation_data_table;
		IMetaMySQLRelation relation2;
		String relation_keyname;

		DataRow current_parent;
		String parent_keyname;
		DataRow current_child;
		String child_keyname;


		public string ChildRelationName;
		public string NameColumn;
		//public static readonly String NameColumn = XDataTable.Name( TableName );

		void InitCurrentObject( DataTable table1, DataTable table2, DataTable[] tables )
		{
			IXDataTable[] tmp = null;
			if( tables != null )
			{
				tmp = new IXDataTable[tables.Length];
				for( int n = 0; n < tables.Length; n++ )
					tmp[n] = tables[n] as IXDataTable;
			}
			InitCurrentObject( table1 as IXDataTable, table2 as IXDataTable, tmp );
		}

		void InitCurrentObject( IXDataTable table1, IXDataTable table2, IXDataTable[] tables )
		{
			parents = table1;
			if( parents != null )
				parent_keyname = XDataTable.ID( parents as DataTable );

			children = table2;
			if( children != null )
				child_keyname = XDataTable.ID( children as DataTable );

			all_parents = tables;
			NameColumn = relation.NameColumn;
			//session_game_groups = table1.DataSet.Tables[MySQLRelationTable.RelationName( table1, table2 )] as MySQLRelationTable;

			if( children == null && all_parents == null )
			{
				throw new Exception( "Table is not an XDataTable with a DisplayMemberName" );
			}

			base.TableName = "current_" + relation.TableName;
			DataColumn mykeycol = Columns.Add( relation_keyname = relation.PrimaryKeyName, XDataTable.DefaultAutoKeyType );

			Columns.Add( NameColumn, typeof( String ) );

			if( relation_data_table.DataSet.Tables.Contains( this.ToString() ) == false )
			{
				relation_data_table.DataSet.Tables.Add( this );

				DataRelation r = new DataRelation( relation.TableName
					, relation_data_table.Columns[ relation.PrimaryKeyName ]
					, mykeycol );
				//r.ChildKeyConstraint.ExtendedProperties.
				relation_data_table.DataSet.Relations.Add( r );
			}

			// these are to handle updating the current display name...
			// they should resolve to a common routine in the derived class.
			if( children != null )
				children.ColumnChanged += new DataColumnChangeEventHandler( child_ColumnChanged );
			if( parents != null )
				parents.ColumnChanged += new DataColumnChangeEventHandler( parents_ColumnChanged );
			if( all_parents != null )
				foreach( IXDataTable dt in all_parents )
				{
					dt.ColumnChanged += new DataColumnChangeEventHandler( dt_ColumnChanged );
				}
            base.PrimaryKey = new DataColumn[]{mykeycol};
			relation.RowChanged += new DataRowChangeEventHandler( parent_children_RowChanged );
			relation.ColumnChanged += new DataColumnChangeEventHandler( parent_child_ColumnChanged );
			relation.RowOrderChanged += new MySQLRelationTable.OnRowOrderChanged( relation_RowOrderChanged );
			Fill();
		}

		void relation_RowOrderChanged()
		{
			// completed a change - swapped rows, or inserted a new row...
			Fill();
		}

		void dt_ColumnChanged( object sender, DataColumnChangeEventArgs e )
		{
			if( filling )
				return;

			// going to blow away this row anyway.
			if( moving )
				return;
			IXDataTable table = e.Row.Table as IXDataTable;
			if( e.Column.ColumnName == table.NameColumn )
			{
				filling = true;
				DataRow[] groups = relation_data_table.Select( e.Row.Table.PrimaryKey[0] + "='" + e.Row[e.Row.Table.PrimaryKey[0].Ordinal] + "'" );
				//e.Row.GetChildRows( relation.ChildrenOfParent );
				foreach( DataRow group in groups )
				{
					DataRow[] currents = group.GetChildRows( relation.TableName );
					foreach( DataRow current in currents )
						current[NameColumn] = GetDisplayMember( group );
				}
				filling = false;
			}
			else if( e.Column.ColumnName == relation.NumberColumn )
			{
			}
		}

		void parent_child_ColumnChanged( object sender, DataColumnChangeEventArgs e )
		{
			if( filling || moving )
				return;
			if( e.Column.ColumnName == relation.NameColumn 
                || e.Column.ColumnName == relation.NumberColumn )
			{
				filling = true;
				DataRow[] groups = e.Row.GetChildRows( relation.TableName );
				//groups.s
				foreach( DataRow group in groups )
				{
					group[NameColumn] = GetDisplayMember( e.Row );
				}
				filling = false;
			}

		}

		public delegate void FillCurrent( DataRow current_parent );
		FillCurrent FillMethod;

		public CurrentObjectTableView( DataSet set, String mirror_table )
		{
            if ( set != null )
            {
				relation_data_table = set.Tables[mirror_table];
				relation = relation_data_table as IMySQLRelationTableBase;
                if ( relation == null )
                {
					DataTable table = set.Tables[mirror_table];
					if( table == null )
						throw new Exception( "Failed to get table:" + mirror_table );
					else
						throw new Exception( "Found table, but is not proper type:" + mirror_table );
                }
				InitCurrentObject( relation.parent_table as IXDataTable, relation.child_table as IXDataTable, null );
                ChildRelationName = relation.TableName;
            }
            else
				base.TableName = "(tmp)" + "current_" + mirror_table;
		}
		public CurrentObjectTableView( DataSet set, String mirror_table, bool meta_relation )
		{
			relation_data_table = set.Tables[mirror_table];
			if( meta_relation )
            {
				relation2 = relation_data_table as IMetaMySQLRelation;
				if( relation2 != null )
				{
					relation = relation2 as IMySQLRelationTableBase;
					InitCurrentObject( null, null, relation2.parents );
					ChildRelationName = relation.TableName;
				}
            }
            else
            {
				relation = relation_data_table as IMySQLRelationTableBase;
				if( relation != null )
				{
					InitCurrentObject( relation.parent_table, relation.child_table, null );
					ChildRelationName = relation.TableName;
				}
            }
		}

		void child_ColumnChanged( object sender, DataColumnChangeEventArgs e )
		{
			if( filling )
				return;
			if( e.Column.ColumnName == children.NameColumn )
			{
				filling = true;
				DataRow[] groups = e.Row.GetChildRows( relation.ParentOfChild );
				foreach( DataRow group in groups )
				{
					DataRow[] currents = group.GetChildRows( relation.TableName );
					foreach( DataRow current in currents )
						current[NameColumn] = GetDisplayMember( group );
				}
				filling = false;
			}
		}

		void parents_ColumnChanged( object sender, DataColumnChangeEventArgs e )
		{
			if( filling )
				return;

			// going to blow away this row anyway.
			if( moving )
				return;
			if( e.Column.ColumnName == parents.NameColumn )
			{
				filling = true;
				DataRow[] groups = e.Row.GetChildRows( relation.ChildrenOfParent );
				foreach( DataRow group in groups )
				{
					DataRow[] currents = group.GetChildRows( relation.TableName );
					foreach( DataRow current in currents )
						current[NameColumn] = GetDisplayMember( group );
				}
				filling = false;
			}
			else if( e.Column.ColumnName == relation.NumberColumn )
			{
				filling = true;
				Log.log( "Need to do something here.." );

				
				DataRow[] groups = e.Row.GetChildRows( relation.ChildrenOfParent );
				foreach( DataRow group in groups )
				{
					DataRow[] currents = group.GetChildRows( relation.TableName );
					foreach( DataRow current in currents )
						current[NameColumn] = GetDisplayMember( group );
				}
				
				filling = false;
			}
		}


		void parent_children_RowChanged( object sender, DataRowChangeEventArgs e )
		{
			// going to blow away this row anyway.
			if( moving )
				return;
			if( _current == null && current_parent == null )
                return;
            if( filling )
			{
				base.OnRowChanging( e );
				return;
			}
			switch( e.Action )
			{
			case DataRowAction.Change:
				{
					DataRow[] these = e.Row.GetChildRows( ChildRelationName );
					if( these.Length > 0 )
					{
						if( these.Length > 1 )
							throw new Exception( "These are supposed to be a 1:1 relation!" );
						DataRow myself = these[0];
						myself[NameColumn] = GetDisplayMember( e.Row );
					}
					AcceptChanges();
				}
				break;
			case DataRowAction.Add:
				if( e.Row.RowState != DataRowState.Detached )
				{
					bool success = false;
					if( _current != null && _current.RowState != DataRowState.Detached )
						if( e.Row[relation_keyname].Equals( _current[relation_keyname] ) )
							success = true;
					if( current_parent != null && current_parent.RowState != DataRowState.Detached )
						if( e.Row[parent_keyname].Equals( current_parent[parent_keyname] ) )
							success = true;
					if( success )
                    {
                        DataRow x = NewRow();
                        x[relation_keyname] = e.Row[relation_keyname];
                        x[NameColumn] = GetDisplayMember( e.Row );
                        Rows.Add( x );
                        AcceptChanges();
                    }
				}
				break;
			}
		}

		public delegate string GetDisplayMemberPlusDelegate( DataRow relation );

		public GetDisplayMemberPlusDelegate ExtraDisplayMember;

		public virtual String GetDisplayMember( DataRow Relation )
		{
			if( ExtraDisplayMember != null )
				return ExtraDisplayMember( Relation );
			return Relation.Table.TableName + "(" + Relation[0] + ")";
		}

		public void Fill()
		{
			DataRow[] rows = null;
			if( current_parent == null )
			{
				if( current_child == null )
					return;
				filling = true;
				Clear();
				try
				{
					throw new Exception( "..." );
					rows = relation_data_table.Select( this.child_keyname + "='" + current_child[relation.PrimaryKeyName] + "'", relation.NumberColumn );
				}
				catch
				{
				}
				foreach( DataRow row in rows )
				{
					DataRow add_row = NewRow();
					add_row[relation.PrimaryKeyName] = row[relation.PrimaryKeyName];
					add_row[NameColumn] = GetDisplayMember( row );
					Rows.Add( add_row );
				}
				AcceptChanges();
				filling = false;
				return;
			}
			else
			{
				filling = true;
				Clear();
                if ( current_parent.RowState != DataRowState.Detached )
                {
					try
					{
						if( relation.has_number )
							rows = relation_data_table.Select( this.parent_keyname + "='" + current_parent[this.parent_keyname] + "'", relation.NumberColumn );
						else
							rows = relation_data_table.Select( this.parent_keyname + "='" + current_parent[this.parent_keyname] + "'" );
					}
					catch
					{
					}
											//current_parent.GetChildRows( relation.ChildrenOfParent );
                    //				Array.Sort<DataRow>( rows
                    //					, delegate (DataRow dr1, DataRow dr2){ 
                    //					//	dr1[
                    //			} );
                    foreach ( DataRow row in rows )
                    {
                        DataRow add_row = NewRow();
                        add_row[relation.PrimaryKeyName] = row[relation.PrimaryKeyName];
                        add_row[NameColumn] = GetDisplayMember( row );
                        Rows.Add( add_row );
                    }
                    AcceptChanges();
                }
				filling = false;
			}
		}

        DataRow _current;
		/// <summary>
		/// this is a magic routine.
		/// If the row you set is from the parent table, then it sets the current parent reference
		/// if the row you set is on the child of the relationship this sets the current child reference.
		/// </summary>
		public DataRow Current
		{
			set
			{
				if( value != null )
				{
                    if( value.Table.TableName == relation.TableName )
                        _current = value;
                    else if( value.Table.TableName == base.TableName )
                        _current = value.GetParentRow( relation.TableName );
                    else if( all_parents != null )
                    {
                        if( relation2.root_table.TableName == value.Table.TableName )
                        {
                            current_parent = value;
							Fill();
                        }
                        else
							foreach( IXDataTable table in all_parents )
                            {
                                if( table.TableName == value.Table.TableName )
                                {
                                    current_parent = value;
									Fill();
                                }
                            }
                    }
                    else if( parents.TableName == value.Table.TableName )
                    {
                        current_parent = value;
						Fill();
                    }
                    else if( children.TableName == value.Table.TableName )
                    {
                        current_child = value;
						Fill();
                    }
				}
				else
				{
					current_child = null;
					current_parent = null;
					Rows.Clear();
				}
			}
            get
            {
                return _current;
            }
		}

		public DataRow AddChildMember( DataRow member_row )
		{
			DataRow new_relation = relation.AddGroupMember( current_parent, member_row );
			if( new_relation != null && new_relation.RowState != DataRowState.Detached )
			{
				DataRow[] myself = new_relation.GetChildRows( new_relation.Table.TableName );
				if( myself.Length > 0 )
					return myself[0];
			}
			return null;
		}

        public DataRow InsertChildMember( DataRow member_row, DataRow before )
        {
            DataRow new_relation = relation.InsertGroupMember( current_parent, member_row, before );
            if( new_relation != null )
            {
                DataRow[] myself = new_relation.GetChildRows( new_relation.Table.TableName );
                if( myself.Length > 0 )
                    return myself[0];
            }
            return null;
        }

        public DataRow ReplaceChildMember( DataRow member_row, DataRow original )
        {
            DataRow new_relation = relation.ReplaceGroupMember( member_row, original );
            if( new_relation != null )
            {
                DataRow[] myself = new_relation.GetChildRows( new_relation.Table.TableName );
                if( myself.Length > 0 )
                    return myself[0];
            }
            return null;
        }
        /// <summary>
		/// an Indicator that a row order change is in progress.
		/// </summary>
		bool moving;

		public void MoveRowUp( DataRow row )
		{
			while( moving )
				System.Threading.Thread.SpinWait( 1 );
			int index = Rows.IndexOf( row );
			if( index > 0 )
			{
				int next = 1;
				DataRow MyOtherRow = Rows[index - next];
				while( MyOtherRow.RowState == DataRowState.Deleted )
				{
					next++;
					if( next > index )
						return;
					MyOtherRow = Rows[index - next];
				}

				DataRow real_row = row.GetParentRow( relation.TableName );
				DataRow other_row = MyOtherRow.GetParentRow( relation.TableName );
				moving = true;
				object tmp;
				tmp = real_row[relation.NumberColumn];
				real_row[relation.NumberColumn] = other_row[relation.NumberColumn];
				other_row[relation.NumberColumn] = tmp;

				tmp = row[relation.PrimaryKeyName];
				row[relation.PrimaryKeyName] = MyOtherRow[relation.PrimaryKeyName];
				MyOtherRow[relation.PrimaryKeyName] = tmp;
				//relation.SwapRows( real_row, other_row );

				// updating the names is good :) - without fill all.
				row[NameColumn] = GetDisplayMember( row.GetParentRow( relation.TableName ) );
				MyOtherRow[NameColumn] = GetDisplayMember( MyOtherRow.GetParentRow( relation.TableName ) );
				moving = false;
			}
		}

		public void MoveRowDown( DataRow row )
		{
			while( moving )
				System.Threading.Thread.SpinWait( 1 );
			int index = Rows.IndexOf( row );
			if( index < ( Rows.Count - 1 ) )
			{
				int next = 1;
				DataRow MyOtherRow = Rows[index + next];
				while( MyOtherRow.RowState == DataRowState.Deleted )
				{
					next++;
					if( ( index + next ) >= Rows.Count )
						return;
					MyOtherRow = Rows[index + next];
				}
				DataRow real_row = row.GetParentRow( relation.TableName );
				DataRow other_row = MyOtherRow.GetParentRow( relation.TableName );
				moving = true;

				object tmp;
				tmp = real_row[relation.NumberColumn];
				real_row[relation.NumberColumn] = other_row[relation.NumberColumn];
				other_row[relation.NumberColumn] = tmp;

				tmp = row[relation.PrimaryKeyName];
				row[relation.PrimaryKeyName] = MyOtherRow[relation.PrimaryKeyName];
				MyOtherRow[relation.PrimaryKeyName] = tmp;

				//relation.SwapRows( real_row, other_row );

				// updating the names is good :) - without fill all.
				row[NameColumn] = GetDisplayMember( row.GetParentRow( relation.TableName ) );
				MyOtherRow[NameColumn] = GetDisplayMember( MyOtherRow.GetParentRow( relation.TableName ) );
				moving = false;
			}
		}
	}

	public class CurrentObjectDataView : DataView
	{
		new public static String TableName( String name )
		{
			return "current_" + name;
		}

		DataTable children;
		DataTable parents;
		DataTable[] all_parents;
		protected IMySQLRelationTableBase relation;
		IMetaMySQLRelation relation2;
		String relation_keyname;
		
		DataRow current_parent;
		String parent_keyname;
		DataRow current_child;
		String child_keyname;

		void InitCurrentObject( DataTable table1, DataTable table2, DataTable[] tables )
		{
			parents = table1;
			if( parents != null )
				parent_keyname = XDataTable.ID( parents );

			children = table2;
			if( children != null )
				child_keyname = XDataTable.ID( children );

			all_parents = tables;
			//NameColumn = relation.Name;
			//session_game_groups = table1.DataSet.Tables[MySQLRelationTable.RelationName( table1, table2 )] as MySQLRelationTable;

			if( children == null && all_parents == null )
			{
				throw new Exception( "Table is not an XDataTable with a DisplayMemberName" );
			}

		}
		public delegate void FillCurrent( DataRow current_parent );
		FillCurrent FillMethod;

		void InitDataView( DataSet set, String mirror_table )
		{
			this.Table = set.Tables[mirror_table];
			this.RowFilter = "";
			this.RowStateFilter = DataViewRowState.CurrentRows;
			if( XDataTable.HasNumber( this.Table ) )
				this.Sort = XDataTable.Number( Table );
			else if( Table.Columns.Contains( XDataTable.Name( Table ) ) )
				this.Sort = XDataTable.Name( Table );
		}

		public CurrentObjectDataView( DataSet set, String mirror_table )
		{
            if ( set != null )
            {
				relation = set.Tables[mirror_table] as IMySQLRelationTableBase;

                if ( relation != null )
                {
					InitCurrentObject( relation.parent_table as DataTable
						, relation.child_table as DataTable, null );
                }
				InitDataView( set, mirror_table );
            }
		}
		public CurrentObjectDataView( DataSet set, String mirror_table, bool meta_relation )
		{
            if( meta_relation )
            {
                relation2 = set.Tables[mirror_table] as IMetaMySQLRelation;
				if( relation2 != null )
				{
					relation = relation2 as IMySQLRelationTableBase;
					Table = set.Tables[mirror_table];
					InitCurrentObject( relation2.root_table, null, relation2.parents );
				}
            }
            else
            {
				relation = set.Tables[mirror_table] as IMySQLRelationTableBase;
				if( relation != null )
				{
					InitCurrentObject( relation.parent_table, relation.child_table, null );
				}
            }
			InitDataView( set, mirror_table );
		}


        DataRow _current;
		/// <summary>
		/// this is a magic routine.
		/// If the row you set is from the parent table, then it sets the current parent reference
		/// if the row you set is on the child of the relationship this sets the current child reference.
		/// </summary>
		public DataRow Current
		{
			set
			{
				if( value != null )
				{
                    if( relation != null && value.Table.TableName == relation.TableName )
                        _current = value;
                    //else if( value.Table.TableName == Table.TableName )
                    //    _current = value.GetParentRow( relation.TableName );
                    else if( all_parents != null )
                    {
                        if( relation2.root_table.TableName == value.Table.TableName )
						{
							current_parent = value;
							RowFilter = parent_keyname + "='" + value[parent_keyname] + "'";
						}
                        else
							foreach( IXDataTable table in all_parents )
                            {
                                if( table.TableName == value.Table.TableName )
                                {
                                    current_parent = value;
									RowFilter = parent_keyname + "='" + value[parent_keyname] + "'";
								}
                            }
                    }
                    else if( parents != null && parents.TableName == value.Table.TableName )
                    {
                        current_parent = value;
						RowFilter = parent_keyname + "='" + value[parent_keyname] + "'";
                    }
					else if( children != null && children.TableName == value.Table.TableName )
                    {
                        current_child = value;
                    }
					else if( Table != null && Table.TableName == value.Table.TableName )
					{
					}
				}
				else
				{
					RowFilter = "false";
					current_child = null;
					current_parent = null;
					//Rows.Clear();
				}
			}
            get
            {
                return _current;
            }
		}

		public DataRow AddChildMember( DataRow member_row )
		{
			return relation.AddGroupMember( current_parent, member_row );
		}

        public DataRow InsertChildMember( DataRow member_row, DataRow before )
        {
            DataRow new_relation = relation.InsertGroupMember( current_parent, member_row, before );
            if( new_relation != null )
            {
                DataRow[] myself = new_relation.GetChildRows( new_relation.Table.TableName );
                if( myself.Length > 0 )
                    return myself[0];
            }
            return null;
        }

        public DataRow ReplaceChildMember( DataRow member_row, DataRow original )
        {
            DataRow new_relation = relation.ReplaceGroupMember( member_row, original );
            if( new_relation != null )
            {
                DataRow[] myself = new_relation.GetChildRows( new_relation.Table.TableName );
                if( myself.Length > 0 )
                    return myself[0];
            }
            return null;
        }

	}

}
