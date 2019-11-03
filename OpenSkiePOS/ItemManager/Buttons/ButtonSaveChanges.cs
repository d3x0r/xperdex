using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using xperdex.core;
using xperdex.classes;

namespace ItemManager
{
	class ButtonSaveChanges: PSI_Button
	{
		public ButtonSaveChanges()
		{
			Text = "Save_Changes";
			Click += new ClickProc( ButtonSaveChanges_Click );
		}

		void ButtonSaveChanges_Click( object sender, EventArgs e )
		{
			ItemManagmentState.dataset_state.Commit( StaticDsnConnection.dsn );
		}

	}
}
