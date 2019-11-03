using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using xperdex.gui;
using xperdex.core.interfaces;
using System.Data;
using xperdex.classes;
using System.Windows.Forms;

namespace ItemManager
{
	
	class ListboxMacroItems: XListbox
	{
		DataTable items;

		public ListboxMacroItems()
		{
			this.DataSource = ItemManagmentState.current_macro_items;
			SelectedValueChanged += new EventHandler( ListboxCurrentMacroItems_SelectedValueChanged );
			//this.DisplayMember = "ToString";
		}


		void ListboxCurrentMacroItems_SelectedValueChanged( object sender, EventArgs e )
		{
			if( SelectedValue != null )
				ItemManagmentState.current_macro = ( SelectedValue as DataRowView ).Row;
		}

	}
	class ListboxCurrentMacroItems: XDataGridView
	{
		DataTable items;

		public ListboxCurrentMacroItems()
		{
			ItemManagmentState.macro_item_list.Add( this );
			this.DataSource = ItemManagmentState.current_assigned_macro_items;
			SelectionChanged += new EventHandler( ListboxCurrentMacroItems_SelectionChanged );
			//SelectedValueChanged += new EventHandler( ListboxCurrentMacroItems_SelectedValueChanged );
			//this.DisplayMember = "ToString";
			RowHeadersVisible = false;
			AllowUserToAddRows = false;
			AllowUserToDeleteRows = false;
			AllowUserToResizeRows = false;

			Columns.CollectionChanged += new System.ComponentModel.CollectionChangeEventHandler( Columns_CollectionChanged );
		}

		void Columns_CollectionChanged( object sender, System.ComponentModel.CollectionChangeEventArgs e )
		{
			DataGridViewColumn dgvc = e.Element as DataGridViewColumn;
			if( dgvc != null )
			{
				switch( dgvc.Name )
				{
				case "Table1_id":
				case "item_description_id":
				case "floor_item_map_id":
				case "macro_item_id":
				case "pos_macro_item_id":
				case "session":
				case "macro_assignment_id":
					dgvc.Visible = false;
					break;
				case "name1":
				case "name2":
				case "receipt_string":
				case "item_name":
					dgvc.Width = 140;
					break;
				}

			}
		}

		void ListboxCurrentMacroItems_SelectionChanged( object sender, EventArgs e )
		{
			foreach( DataGridViewCell cell in this.SelectedCells )
			{
				DataGridViewRow row = Rows[cell.RowIndex];
				DataRowView drv = row.DataBoundItem as DataRowView;
				ItemManagmentState.current_macro = drv.Row.GetParentRow( "macro_assignments_meta_pos_macro_items" );
			}
		}
	}
}
