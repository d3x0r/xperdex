using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using xperdex.gui;
using xperdex.core.interfaces;
using System.Data;
using xperdex.classes;

namespace SessionManager
{
	[ControlAttribute( Name = "Select Prize List" )]
	class ListboxSelectPrizes : XListbox
	{
		public ListboxSelectPrizes()
		{
			this.DataSource = SessionManagementState.schedule_currents.current_session_prize_exception_sets;
			SelectedValueChanged += new EventHandler( SessionSelectionList_SelectedIndexChanged );
		}

		void SessionSelectionList_SelectedIndexChanged( object sender, EventArgs e )
		{
			DataRowView drv = ( SelectedItem as DataRowView );
			if( drv != null )
				SessionManagementState.current_prize_set = drv.Row;
			else
				SessionManagementState.current_prize_set = null;
		}
	}
}
