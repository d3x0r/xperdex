using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using xperdex.core;
using xperdex.classes;
using xperdex.core.interfaces;
using System.Data;
using System.Windows.Forms;
using System.Drawing;

namespace ItemManager
{
	[ButtonAttribute( Name="Assign Macro Item" )] 
	class ButtonAssignMacroToItem : PSI_Button
	{
		public ButtonAssignMacroToItem()
		{
			Click += new ClickProc( ButtonAssignMacroToItem_Click );
			Text = "Assign_Macro";
		}

		void ButtonAssignMacroToItem_Click( object sender, ReflectorButtonEventArgs e )
		{
			if( ItemManagmentState.current_item == null )
			{
				MessageBox.Show( "Need to select an item description to assign." );
				return;
			}
			DataRow result = MySQLRelationTable.AddGroupMember( ItemManagmentState.item_dataset.floor_item_map
				, ItemManagmentState.current_macro
				, ItemManagmentState.current_item
				, false
				, true 
				, true );
			if( result != null )
			{
				result["paper_item_name"] = ItemManagmentState.current_item["item_name"];
				result["floor_name"] = ItemManagmentState.current_macro.ToString();
				result["macro_item"] = true;
			}
		}
	}

	[ButtonAttribute( Name = "Unassign Macro Item" )]
	class ButtonUnAssignMacroToItem : PSI_Button
	{
		public ButtonUnAssignMacroToItem()
		{
			Click += new ClickProc( ButtonAssignMacroToItem_Click );
			Text = "Unassign_Macro";
		}

		void ButtonAssignMacroToItem_Click( object sender, ReflectorButtonEventArgs e )
		{
			DataRow current_macro = ItemManagmentState.current_macro;
			List<Point> indexes = new List<Point>();
			foreach( ListboxCurrentMacroItems list in ItemManagmentState.macro_item_list )
			{
				foreach( DataGridViewCell cell in list.SelectedCells )
				{
					cell.Selected = false;
					indexes.Add( new Point( cell.RowIndex, cell.ColumnIndex ) );
				}
			}
			if(current_macro != null )
			{
				DataRow[] children = current_macro.GetChildRows( "macro_item_floor_item_map" );
				foreach( DataRow child in children )
				{
					//child["item_description_id"] = DBNull.Value;
					//child["paper_item_name"] = "";
					child["deleted"] = 1;
					child.Delete();
				}
			}
			foreach( ListboxCurrentMacroItems list in ItemManagmentState.macro_item_list )
			{
				foreach( DataGridViewCell cell in list.SelectedCells )
				{
					cell.Selected = false;
				}
			}
			int n = 0;
			foreach( ListboxCurrentMacroItems list in ItemManagmentState.macro_item_list )
			{
				foreach( Point cell in indexes )
				{
					list.Rows[cell.X].Cells[cell.Y].Selected = true;
				}
				n++;
			}
		}
	}
}
