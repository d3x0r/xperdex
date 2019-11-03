using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using xperdex.core;
using xperdex.classes;
using xperdex.core.interfaces;
using System.Data;

namespace ItemManager
{
	[ButtonAttribute( Name="Assign Paper Item" )] 
	class ButtonAssignPaperToItem : PSI_Button
	{
		public ButtonAssignPaperToItem()
		{
			Click += new ClickProc( ButtonAssignPaperToItem_Click );
			Text = "Assign_Paper";
		}

		void ButtonAssignPaperToItem_Click( object sender, ReflectorButtonEventArgs e )
		{
			DataRow[] previous_row = ItemManagmentState.item_dataset.floor_item_map.Select(
				XDataTable.ID( ItemManagmentState.current_item.Table ) 
				+ "='"
				+ ItemManagmentState.current_item[XDataTable.ID( ItemManagmentState.current_item.Table )] + "'" );
			if( previous_row.Length == 0 )
			{
				previous_row = ItemManagmentState.item_dataset.floor_item_map.Select(
				"paper_item_name"
				+ "='"
				+ DsnConnection.Escape(  DsnConnection.ConnectionMode.NativeDataTable
									, DsnConnection.ConnectionFlavor.Unknown
									, ItemManagmentState.current_item[XDataTable.Name( ItemManagmentState.current_item.Table )].ToString() ) + "'" );
			}
			if( previous_row.Length > 0 )
			{
				previous_row[0]["floor_paper_name_id"] = ItemManagmentState.current_paper["floor_paper_name_id"];
				previous_row[0]["paper_item_name"] = ItemManagmentState.current_item["item_name"];
				previous_row[0]["floor_name"] = ItemManagmentState.current_paper.ToString();
				previous_row[0]["paper_item"] = true;
				//ItemManagmentState.current_floor_paper_paper_items.
			}
			else
			{
				DataRow result = MySQLRelationTable.AddGroupMember( ItemManagmentState.item_dataset.floor_item_map
					, ItemManagmentState.current_paper
					, ItemManagmentState.current_item
					, false
					, true );

				result["paper_item_name"] = ItemManagmentState.current_item["item_name"];
				result["floor_name"] = ItemManagmentState.current_paper.ToString();
				result["paper_item"] = true;
			}
		}
	}

	[ButtonAttribute( Name = "Auto Assign Paper Item" )]
	class ButtonAutoAssignPaperToItem : PSI_Button
	{
		public ButtonAutoAssignPaperToItem()
		{
			Click += new ClickProc( ButtonAssignPaperToItem_Click );
			Text = "Auto-Assign_Paper";
		}

		void ButtonAssignPaperToItem_Click( object sender, ReflectorButtonEventArgs e )
		{
			foreach( DataRow row in ItemManagmentState.item_dataset.floor_paper_names.Rows )
			{
				DataRow[] items = ItemManagmentState.item_dataset.item_descriptions.Select( "item_name='" + row["name"] + "' and inv_type='Paper'" );
				if( items.Length > 0 )
				{
					DataRow[] existing_relation = ItemManagmentState.item_dataset.floor_item_map.Select( "floor_name='" + row["name"] + "' and paper_item_name='" + items[0]["item_name"] + "'" );
					if( existing_relation.Length == 0 )
					{
						DataRow new_relation = ItemManagmentState.item_dataset.floor_item_map.NewRow();
						new_relation["floor_name"] = row["name"];
						new_relation["paper_item_name"] = items[0]["item_name"];
						new_relation["paper_item"] = true;
						new_relation["item_description_id"] = items[0]["item_description_id"];
						new_relation["floor_paper_name_id"] = row["floor_paper_name_id"];
						ItemManagmentState.item_dataset.floor_item_map.Rows.Add( new_relation );
					}
				}
			}
		}
	}
}
