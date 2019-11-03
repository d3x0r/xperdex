using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using xperdex.core;
using xperdex.classes;

namespace ItemManager
{
	class ButtonForgetChanges : PSI_Button
	{
		public ButtonForgetChanges()
		{
			Text = "Forget_Changes";
			Click += new ClickProc( ButtonForgetChanges_Click );
		}

		void ButtonForgetChanges_Click( object sender, ReflectorButtonEventArgs e )
		{
			ItemManagmentState.max_session = 0;
			ItemManagmentState.dataset_state.Fill( StaticDsnConnection.dsn );
			ItemManagmentState.SetMaxSession( Convert.ToInt32( ItemManagmentState.item_dataset.pos_macro_items.Compute( "max(session)", null ) ) );
		}

	}
}
