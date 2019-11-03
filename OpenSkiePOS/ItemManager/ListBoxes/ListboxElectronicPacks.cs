using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using xperdex.gui;
using System.Data;
using xperdex.core.interfaces;

namespace ItemManager.ListBoxes
{
	[ControlAttribute( Name = "Electronic Packs" )]
	class ListboxElectronicPacks : XListbox
	{
		DataTable items;

		public ListboxElectronicPacks()
		{
			this.DataSource = ItemManagmentState.current_electronic_items;
			SelectedValueChanged += new EventHandler( ListboxCurrentElectronicItems_SelectedValueChanged );
		}



		void ListboxCurrentElectronicItems_SelectedValueChanged( object sender, EventArgs e )
		{
			if( SelectedValue != null )
				ItemManagmentState.current_electronic = ( SelectedValue as DataRowView ).Row;
			else
				ItemManagmentState.current_electronic = null;
		}

	}
}
