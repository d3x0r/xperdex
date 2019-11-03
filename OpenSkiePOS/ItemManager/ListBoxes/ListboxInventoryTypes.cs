using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using xperdex.gui;

namespace ItemManager.ListBoxes
{
	public partial class ListboxInventoryTypes : XListbox
	{
		public ListboxInventoryTypes()
		{
			DataSource = ItemManagmentState.inventory_types;
			DisplayMember = "inv_type";
			SelectedValueChanged += new EventHandler( ListboxInventoryTypes_SelectedValueChanged );
			ItemManagmentState.inventory_type_listboxes.Add( this );
		}

		void ListboxInventoryTypes_SelectedValueChanged( object sender, EventArgs e )
		{
			if( SelectedValue != null )
				ItemManagmentState.current_inventory_type = ( SelectedValue as DataRowView ).Row;
			
		}
	}
}
