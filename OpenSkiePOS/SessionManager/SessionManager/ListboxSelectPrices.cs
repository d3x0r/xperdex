using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using xperdex.core.interfaces;
using xperdex.gui;
using System.Data;

namespace SessionManager
{
	[ControlAttribute( Name = "Select Price List" )]
	class ListboxSelectPrices : XListbox
	{
		public ListboxSelectPrices()
		{
			this.DataSource = SessionManagementState.schedule_currents.current_session_price_exception_sets;
			SelectedValueChanged += new EventHandler( ListboxSelectPrices_SelectedValueChanged );
		}

		void ListboxSelectPrices_SelectedValueChanged( object sender, EventArgs e )
		{
			DataRowView drv = ( SelectedItem as DataRowView );
			if( drv != null )
				SessionManagementState.current_price_set = drv.Row;
			else
				SessionManagementState.current_price_set = null;
		}

	}
}
