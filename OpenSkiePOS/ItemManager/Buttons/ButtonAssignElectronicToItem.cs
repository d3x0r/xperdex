using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using xperdex.core.interfaces;
using xperdex.core;
using System.Data;
using xperdex.classes;
using System.Windows.Forms;
using xperdex.gui;
using OpenSkieScheduler3;
using System.Drawing;

namespace ItemManager.Buttons
{
	[ButtonAttribute( Name = "Assign Electronic Item" )]
	class ButtonAssignElectronicToItem : PSI_Button
	{
		public ButtonAssignElectronicToItem()
		{
			Click += new ClickProc( ButtonAssignElectronicToItem_Click );
			Text = "Assign_Electronic";
		}
		void ButtonAssignElectronicToItem_Click( object sender, ReflectorButtonEventArgs e )
		{
			if( ItemManagmentState.current_item == null )
			{
				Banner.Show( "Need to select an\nitem description to assign." );
				return;
			}
			if( ItemManagmentState.current_electronic == null )
			{
				Banner.Show( "Need to select a\nElectronic Pack to assign." );
				return;
			}
			DataRow result = MySQLRelationTable.AddGroupMember( ItemManagmentState.item_dataset.floor_item_map
				, ItemManagmentState.current_electronic
				, ItemManagmentState.current_item
				, false
				, true
				, true );
			if( result != null )
			{
				result["paper_item_name"] = ItemManagmentState.current_item["item_name"];
				result["floor_name"] = ItemManagmentState.current_electronic.ToString();
				result["electronic_item"] = true;
				ItemManagmentState.RefreshLists();
			}

		}
	}


	[ButtonAttribute( Name = "Unassign Electronic Item" )]
	class ButtonUnAssignElectronicToItem : PSI_Button
	{
		public ButtonUnAssignElectronicToItem()
		{
			Click += new ClickProc( ButtonAssignElectronicToItem_Click );
			Text = "Unassign_Electronic";
		}

		void ButtonAssignElectronicToItem_Click( object sender, ReflectorButtonEventArgs e )
		{
			DataRow current_electronic = ItemManagmentState.current_assigned_electronic;
			if( current_electronic != null && current_electronic.RowState != DataRowState.Deleted )
			{
				current_electronic["deleted"] = 1;
				current_electronic.Delete();
			}
		}
	}

}
