using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using xperdex.core;
using xperdex.core.interfaces;

namespace ItemManager
{
	[ButtonAttribute( Name = "Toggle Retired Items" )]
	class ButtonToggleRetired : PSI_Button
	{
		public ButtonToggleRetired()
		{
			Click += new ClickProc( ButtonToggleRetired_Click );
			Text = "Show_Retired";
		}

		void ButtonToggleRetired_Click( object sender, ReflectorButtonEventArgs e )
		{
			ItemManagmentState.ShowRetiredItems = !ItemManagmentState.ShowRetiredItems;
			if( ItemManagmentState.ShowRetiredItems )
				Highlight = true;
			else
				Highlight = false;
		}
	}
}
