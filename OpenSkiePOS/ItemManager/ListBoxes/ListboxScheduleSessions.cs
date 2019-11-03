using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using xperdex.core.interfaces;
using xperdex.gui;
using System.Data;

namespace ItemManager.ListBoxes
{
	[ControlAttribute( Name = "Schedule Session Select" )]
	class ListboxScheduleSessions : XListbox
	{
		public ListboxScheduleSessions()
		{
			this.SelectedValueChanged += new System.EventHandler( this.ListboxSessionSelect_SelectedValueChanged );
			this.DataSource = ItemManagmentState.schedule_currents.current_all_sessions;
		}

		private void ListboxSessionSelect_SelectedValueChanged( object sender, EventArgs e )
		{
			if( this.SelectedValue != null )
			{
				ItemManagmentState.current_schedule_session = ( this.SelectedValue as DataRowView ).Row;
			}
		}
	}
}
