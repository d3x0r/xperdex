using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using xperdex.gui;
using xperdex.core.interfaces;
using System.Data;

namespace ItemManager
{
	[ControlAttribute( Name = "Assigned POS Macros" )]
	class ListboxAssignedMacros : XListbox
	{
		public ListboxAssignedMacros()
		{
			DataSource = ItemManagmentState.current_floor_paper_macro_items;
			ItemManagmentState.lists.Add( this );
		}
	}
	[ControlAttribute( Name = "Assigned Floor Paper Names" )]
	class ListboxAssignedPaper : XListbox
	{
		public ListboxAssignedPaper()
		{
			//this.UseTabStops = true;
			this.TabStops = new int[] { 150 };
			DataSource = ItemManagmentState.current_floor_paper_paper_items;

			// updates on DataTable did not trigger update in DataView that this is pointing at.
			// maybe because it doesn't have a 'displaymember' ?
			ItemManagmentState.item_dataset.floor_item_map.RowChanged += new System.Data.DataRowChangeEventHandler( floor_item_map_RowChanged );
			ItemManagmentState.lists.Add( this );
		}

		void floor_item_map_RowChanged( object sender, System.Data.DataRowChangeEventArgs e )
		{
			if( e.Action == System.Data.DataRowAction.Change )
				Refresh();
		}
	}
	[ControlAttribute( Name = "Assigned Miscellaneous" )]
	class ListboxAssignedMisc : XListbox
	{
		public ListboxAssignedMisc()
		{
			this.TabStops = new int[] { 150 };
			DataSource = ItemManagmentState.current_floor_paper_misc_items;
			ItemManagmentState.lists.Add( this );
		}
	}
	[ControlAttribute( Name="Assigned Electronics" )]
	class ListboxAssignedElectronic : XListbox
	{
		public ListboxAssignedElectronic()
		{
			this.TabStops = new int[] { 150 };
			DataSource = ItemManagmentState.current_floor_paper_elec_items;
			ItemManagmentState.lists.Add( this );
			SelectedValueChanged += new EventHandler( ListboxAssignedElectronic_SelectedValueChanged );
		}

		void ListboxAssignedElectronic_SelectedValueChanged( object sender, EventArgs e )
		{
			DataRowView drv = this.SelectedValue as DataRowView;
			if( drv != null )
				ItemManagmentState.current_assigned_electronic = drv.Row;
			else
				ItemManagmentState.current_assigned_electronic = null;
		}
	}
}
