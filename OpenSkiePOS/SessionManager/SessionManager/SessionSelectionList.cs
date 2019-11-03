using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using xperdex.gui;
using xperdex.core.interfaces;
using System.Windows.Forms;
using System.Data;

namespace SessionManager
{
	[ControlAttribute( Name = "Session List" )]
	class SessionSelectionList : XListbox
	{
		public SessionSelectionList()
		{
			this.DataSource = SessionManagementState.schedule.sessions;
			this.DisplayMember = SessionManagementState.schedule.sessions.DisplayMemberName;
			SelectedValueChanged += new EventHandler( SessionSelectionList_SelectedValueChanged );
		}

		void SessionSelectionList_SelectedValueChanged( object sender, EventArgs e )
		{
			DataRowView drv = ( SelectedItem as DataRowView );
			if( drv != null )
				SessionManagementState.current_session = drv.Row;
			else
				SessionManagementState.current_session = null;
		}

	}
}
