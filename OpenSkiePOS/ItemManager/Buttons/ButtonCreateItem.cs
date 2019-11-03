using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using xperdex.core;
using xperdex.core.interfaces;
using System.Data;
using xperdex.classes;
using xperdex.gui;
using System.Windows.Forms;

namespace ItemManager
{
	[ButtonAttribute( Name = "Create Item" )]
	class ButtonCreateItem : PSI_Button
	{
		public ButtonCreateItem()
		{
			Click += new ClickProc( ButtonCreateItem_Click );
			Text = "Create_Item";
		}

		void ButtonCreateItem_Click( object sender, ReflectorButtonEventArgs e )
		{
			if( ItemManagmentState.current_inventory_type != null )
			{
				String newname = QueryNewName.Show( "Enter new " + ItemManagmentState.current_inventory_type["inv_type"] + " item name" );
				if( newname != null && newname != "" )
				{
					String condition = "inv_type='"
						+ DsnConnection.Escape( DsnConnection.ConnectionMode.NativeDataTable,
								DsnConnection.ConnectionFlavor.Unknown, ItemManagmentState.current_inventory_type["inv_type"].ToString() ) + "'"
						+ " and item_name='"
						+ DsnConnection.Escape( DsnConnection.ConnectionMode.NativeDataTable,
									DsnConnection.ConnectionFlavor.Unknown, newname ) + "'";
					DataRow[] existing = ItemManagmentState.item_dataset.item_descriptions.Select( condition );
					if( existing.Length < 1 )
					{
						DataRow newrow = ItemManagmentState.item_dataset.item_descriptions.CreateItem( newname );
						newrow["inv_type"] = ItemManagmentState.current_inventory_type["inv_type"];
						ItemManagmentState.current_item = newrow;
						DsnSQLUtil.CommitChanges( ItemManagmentState.item_dataset_dsn, ItemManagmentState.item_dataset );
					}
					else
						MessageBox.Show( "Inventory item of specified type already exists" );
				}
			}
			else
				Banner.Show( "Must Select Inventory Type" );
		}
	}

	[ButtonAttribute( Name = "Create Type" )]
	class ButtonCreateInventoryType : PSI_Button
	{
		public ButtonCreateInventoryType()
		{
			Click += new ClickProc( ButtonCreateItem_Click );
			Text = "Create Inventory_Type";
		}

		void ButtonCreateItem_Click( object sender, ReflectorButtonEventArgs e )
		{
			String newname = QueryNewName.Show( "Enter new inventory type" );
			if( newname != null && newname != "" )
			{
				DataRow[] existing = ItemManagmentState.inventory_types.Select( "inv_type='" 
					+ DsnConnection.Escape(  DsnConnection.ConnectionMode.NativeDataTable, DsnConnection.ConnectionFlavor.Unknown, newname ) 
					+ "'" );
				if( existing.Length < 1 )
				{
					DataRow row = ItemManagmentState.inventory_types.NewRow();
					row["inv_type"] = newname;
					ItemManagmentState.inventory_types.Rows.Add( row );
					ItemManagmentState.current_inventory_type = row;
				}
				else
					MessageBox.Show( "Inventory type already exists." );
			}
		}
	}

	[ButtonAttribute( Name = "Update Inventory Type" )]
	class ButtonUpdateInventoryType : PSI_Button
	{
		public ButtonUpdateInventoryType()
		{
			Click += new ClickProc( ButtonCreateItem_Click );
			Text = "Update Inventory_Type";
		}

		void ButtonCreateItem_Click( object sender, ReflectorButtonEventArgs e )
		{
			DialogResult result = Banner.Show( "Are you sure you want to change " + ItemManagmentState.current_item["item_name"] + "\n"
				+ " from " + ItemManagmentState.current_item["inv_type"] + " to " + ItemManagmentState.current_inventory_type["inv_type"] 
				, MessageBoxButtons.YesNo
				);
			if( result == DialogResult.Yes )
			{
				DataRow[] existing = ItemManagmentState.item_dataset.item_descriptions.Select( "inv_type='" + ItemManagmentState.current_inventory_type["inv_type"] 
					+ "' and item_name='" + ItemManagmentState.current_item["item_name"] + "'"  );
				if( existing.Length < 1 )
				{
					ItemManagmentState.current_item["inv_type"]
						= ItemManagmentState.current_inventory_type["inv_type"];
				}
				else
					MessageBox.Show( "An inventory item already exists that is the new type" );
			}
		}
	}

}
