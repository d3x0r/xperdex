using System.Collections.Generic;
using System.Data;
using System;
using xperdex.classes;

namespace ItemManager {
    
    
    public partial class ItemDataSet {
		partial class inventory_typesDataTable
		{
		}

		public MetaMySQLRelation<DataRow> macro_item_assignments;

		public void Init()
		{
			macro_item_assignments = new MetaMySQLRelation<DataRow>( this, "macro_assignments"
				, this.Tables["pos_macro_items"]
				, new MySQLRelationMap( new object[] {  MySQLRelationMap.MapOp.SaveRelationPoint
					, MySQLRelationMap.MapOp.FollowToChild
					, "macro_item_floor_item_map"
					, MySQLRelationMap.MapOp.SaveRelationPoint
					, MySQLRelationMap.MapOp.FollowToParent
					, "item_descriptions_floor_item_map"
					, MySQLRelationMap.MapOp.SaveRelationPoint }
					).ToString()
					, false, null
					, new string[] { "session", "name1", "name2", "receipt_string", "item_name" } );
			macro_item_assignments.AcceptNewRow += new MySQLRelationTable.OnAcceptNewRow( macro_item_assignments_AcceptNewRow );
			macro_item_assignments.AcceptNewChildRow += new MySQLRelationTable.OnAcceptNewRow( macro_item_assignments_AcceptNewChildRow );
			macro_item_assignments.AllowPartialRows = true;
			macro_item_assignments.RootTableUnique = true;

			floor_item_map.PrimaryKey = new DataColumn[] {floor_item_map.floor_item_map_idColumn } ;
		}

		void macro_item_assignments_AcceptNewChildRow( MySQLRelationTable.MySQLRelationTableEventArgs args, DataRow row )
		{
			if( row.Table.TableName == "floor_item_map" )
			{
				object o = row["deleted"];
				if( o == null || DBNull.Value == o || Convert.ToInt32( o ) == 0 )
					args.accept = true;
			}
			else
				args.accept = true;
		}

		void macro_item_assignments_AcceptNewRow( MySQLRelationTable.MySQLRelationTableEventArgs args, DataRow row )
		{
			DataRow item_map = row.GetParentRow( "macro_assignments_meta_floor_item_map" );
			if( item_map != null )
			{
				object o = item_map["deleted"];
				if( o == null || DBNull.Value == o || Convert.ToInt32( o ) == 0 )
					args.accept = true;
			}
			else
				args.accept = true;
		}

		partial class sessionsDataTable
		{
		}

		partial class sessionsRow
		{
			public override string ToString()
			{
				if( this.RowState == DataRowState.Deleted )
					return "<Deleted>";
				if( this.RowState == DataRowState.Detached )
					return "<Detached>";
				return "Session " + this["session_number"].ToString();
			}
		}

		[SQLPersistantTable]
		partial class itemsDataTable
		{
		}

		partial class itemsRow
		{
			public override string ToString()
			{
				DataRow parent = this.GetParentRow( "FK_item_descriptions_items" );
				if( parent != null )
					return this["series"].ToString() + "\t" + parent["item_name"];
				else
					return this["series"].ToString() + "\t<Unassigned>";
			}
		}

		[SQLPersistantTable]
		partial class misc_itemDataTable
		{
			new static readonly string PrimaryKey = "item_id";
		}

		partial class misc_itemRow
		{
			public override string ToString()
			{
				return this["name"].ToString();
			}
		}

		[SQLPersistantTable]
		partial class item_descriptionsDataTable
		{
			new static readonly string PrimaryKey = "item_description_id";

			internal DataRow CreateItem( string newname )
			{
				DataRow newrow = NewRow();
				newrow["item_name"] = newname;
				Rows.Add( newrow );
				return newrow;
			}
		}

		partial class item_descriptionsRow
		{
			public override string ToString()
			{
				if( this.RowState == DataRowState.Deleted )
					return "<Deleted>";
				if( this.RowState == DataRowState.Detached )
					return "<Detached>";
				return this["item_name"] + "\t" + this["inv_type"];
			}
		}


		[SQLPersistantTable]
		partial class pos_macro_itemsDataTable
		{
			new static readonly string PrimaryKey = "macro_item_id";
		}

		partial class pos_macro_itemsRow
		{
			public override string ToString()
			{
				return this["name1"] + "/" + this["name2"] + "{" + this["receipt_string"] + "}";
			}
		}

		[SQLPersistantTable]
		partial class floor_item_mapDataTable
		{
		}

		partial class floor_item_mapRow
		{
			public override string ToString()
			{
				return this["paper_item_name"].ToString() + "\t" + this["floor_name"].ToString();
			}

		}

		[SQLPersistantTable]
		partial class floor_paper_namesDataTable
		{
		}

		partial class floor_paper_namesRow
		{
			public override string ToString()
			{
				return this["name"].ToString();
			}
		}
	}
}
