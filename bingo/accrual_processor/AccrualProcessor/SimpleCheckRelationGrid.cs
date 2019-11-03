using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data;
using xperdex.classes;

namespace ECube.AccrualProcessor
{
	public class SimpleCheckRelationGrid : DataGridView
	{
		DataTable current_data;  // table that backs the datagrid; added to dataset for keys
		DataTable relatable_elements; // source groups
		String relatable_element_key; // source groups
		String item_column_name;
		String item_column_header;
		IMySQLRelationTableBase accrual_group_related;
		bool filling = false;
		List<DataRow> relation_rows = new List<DataRow>();
		AccrualGroup.CurrentObjectDataView current_relations;

		public string source_data_tablename
		{
			get{
				if( current_data != null )
					return current_data.TableName;
				return "uninitialized";
			}
			set{
				current_data = Local.BingoDataSet.Tables[value];
				if( current_data == null )
				{
					current_data = new DataTable();
					current_data.TableName = value;
					Local.BingoDataSet.Tables.Add( current_data );
				}
				else
				{
					current_data.Clear();
				}
			}
		}

		public string source_data_relation_tablename
		{
			get{
				if( accrual_group_related != null )
					return accrual_group_related.TableName;
				return "uninitialized";
			}
			set{
				accrual_group_related = Local.BingoDataSet.Tables[value] as IMySQLRelationTableBase;
			}
		}

		public string source_data_relation_member_tablename
		{
			get {
				if( relatable_elements != null )
					return relatable_elements.TableName;
				return "uninitialized";
			}
			set {
				relatable_elements = Local.BingoDataSet.Tables[value];
			}
		}

		public string source_data_relation_member_key
		{
			get
			{
				return relatable_element_key;
			}
			set
			{
				relatable_element_key = value;
			}
		}
		public string display_column_name
		{
			set{
				item_column_name  = value;
			}
			get{
				return item_column_name ;
			}
		}
		public string display_column_header
		{
			set{
				item_column_header  = value;
			}
			get{
				return item_column_header ;
			}
		}

		internal AccrualGroup.CurrentObjectDataView current_relation_dataview
		{
			set{
				current_relations = value;
			}
			get{
				return current_relations;
			}
		}

		public void SetupCheckRelationGrid(  )
		{
			// event on select new accrual group

			Local.accrual_group_table.RowChanged += accrual_group_table_RowChanged;
			Local.ConfigureState.current_accrual_group_changed += ConfigureState_current_accrual_group_changed;

			this.AutoGenerateColumns = true;
			this.CellValueChanged += new DataGridViewCellEventHandler( GameGroupAssignmentGrid_CellValueChanged );
			this.Disposed += new EventHandler( SimpleCheckRelationGrid_Disposed );
		}

		void SimpleCheckRelationGrid_Disposed( object sender, EventArgs e )
		{
			Local.ConfigureState.current_accrual_group_changed -= ConfigureState_current_accrual_group_changed;
		}

		public void DoFill()
		{
			if( !filling )
				FillCurrent();
		}

		void ConfigureState_current_accrual_group_changed()
		{
			DoFill();
		}

		void accrual_group_table_RowChanged( object sender, DataRowChangeEventArgs e )
		{
			if( e.Action == DataRowAction.Commit 
				|| e.Action == DataRowAction.Change )
				return;
			DoFill();
		}


		public SimpleCheckRelationGrid()
		{
			SetupCheckRelationGrid();
			//accrual_groups = Local.BingoDataSet.Tables[AccrualGroup.AccrualGroupTable.TableName];
		}

		void session_pack_groups_RowChanged( object sender, DataRowChangeEventArgs e )
		{
			if( e.Action == DataRowAction.Commit )
				return;
			if( !filling )
				FillCurrent();
		}

		void session_games_RowOrderChange()
		{
				filling = true;
		}


		void session_games_RowOrderChanged()
		{
				filling = false;
				FillCurrent();
		}

		void data_SetSessionCurrent( DataRow current )
		{
			//new current session
			if( !filling )
				FillCurrent();
		}

		void GameGroupAssignmentGrid_CellValueChanged( object sender, DataGridViewCellEventArgs e )
		{
				if( !filling )
				{
					 if( e.ColumnIndex > 0 )
					 {
						DataGridViewCell c = this[e.ColumnIndex, e.RowIndex];
						if( Convert.ToBoolean( c.Value ) )
						{
							accrual_group_related.AddGroupMember( Local.ConfigureState.current_accrual_group, relatable_elements.Rows[e.RowIndex] );
						}
						else
							accrual_group_related.RemoveGroupMember( Local.ConfigureState.current_accrual_group, relatable_elements.Rows[e.RowIndex] );
						//.GetParentRow( ControlList.schedule.session_pack_groups.ParentOfChild ) 
					 }
				}
		}
		
		void FillCurrent()
		{
			// entirely recreates the grid layout.
			if( Local.ConfigureState.current_accrual_group != null )
			{
				SuspendLayout();
				filling = true;
				DataSource = current_data;
				AutoGenerateColumns = true;// force this AGAIN because the designer likes to leave this off because I get a datasource?

				DataRow current_accrual_group = Local.ConfigureState.current_accrual_group;
				relation_rows.Clear();
				current_data.Rows.Clear();
				current_data.Columns.Clear();
				DataColumn dc;
				dc = new DataColumn( item_column_header, typeof( String ) );
				dc.AllowDBNull = false;
				current_data.Columns.Add( dc );

				//session_pack_groups.Add( tmp_game );
				dc = new DataColumn( "Use", typeof( bool ) );
				dc.AllowDBNull = false;
				dc.DefaultValue = false;
				current_data.Columns.Add( dc );

				object[] rowdata = new object[2];
				foreach( DataRow member in relatable_elements.Rows )
				{
					rowdata[0] = member[item_column_name];
					DataRow[] assigned = member.GetChildRows( accrual_group_related.ParentOfChild );
					rowdata[1] = false;
					foreach( DataRow a in assigned )
					{ 
						if( a[AccrualGroup.AccrualGroupTable.PrimaryKey].Equals( Local.ConfigureState.current_accrual_group[AccrualGroup.AccrualGroupTable.PrimaryKey]))
						{
							rowdata[1] = true;
							break;
						}
					}
					current_data.Rows.Add( rowdata );
				}
				filling = false;
				ResumeLayout();
			}
		}

		void session_game_groups_RowChanged( object sender, System.Data.DataRowChangeEventArgs e )
		{
				if( e.Action == DataRowAction.Commit )
					 return;
				if( !filling )
					 FillCurrent();
				//throw new NotImplementedException();
		}

		void game_groups_RowChanged( object sender, System.Data.DataRowChangeEventArgs e )
		{
				if( e.Action == DataRowAction.Commit )
					 return;
				if( !filling )
					 FillCurrent();
		}
	
	}
	
}
