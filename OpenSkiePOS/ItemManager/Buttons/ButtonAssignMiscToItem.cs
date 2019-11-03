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
	[ButtonAttribute( Name="Assign Misc Item" )] 
	class ButtonAssignMiscToItem : PSI_Button
	{
		public ButtonAssignMiscToItem()
		{
			Click += new ClickProc( ButtonAssignMiscToItem_Click );
			Text = "Assign_Misc";
		}

		void ButtonAssignMiscToItem_Click( object sender, ReflectorButtonEventArgs e )
		{
			DataRow result = MySQLRelationTable.AddGroupMember( ItemManagmentState.item_dataset.floor_item_map
				, ItemManagmentState.current_misc
				, ItemManagmentState.current_item
				, false
				, true );

			result["paper_item_name"] = ItemManagmentState.current_item["item_name"];
			result["floor_name"] = ItemManagmentState.current_misc.ToString();
			result["misc_item"] = true;
		}
	}
}
