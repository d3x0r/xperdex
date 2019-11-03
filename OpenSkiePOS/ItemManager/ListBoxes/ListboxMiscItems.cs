using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using xperdex.gui;
using System.Data;

namespace ItemManager
{
	class ListboxMiscItems : XListbox
	{
		public ListboxMiscItems()
		{
			DataSource = ItemManagmentState.item_dataset.misc_item;
			SelectedIndexChanged += new EventHandler( ListboxMiscItems_SelectedIndexChanged );
		}

		void ListboxMiscItems_SelectedIndexChanged( object sender, EventArgs e )
		{
			DataRowView drv = SelectedItem as DataRowView;
			if( drv == null )
				ItemManagmentState.current_misc = null;
			else
				ItemManagmentState.current_misc = drv.Row;
		}


	}
}
