using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using xperdex.core.interfaces;
using xperdex.core;
using System.Windows.Forms;

namespace ItemManager.Buttons
{
	[ButtonAttribute( Name="Retire Item" )] 
	class ButtonRetireSerial : PSI_Button
	{
		public ButtonRetireSerial()
		{
			Click += new ClickProc( ButtonAssignMacroToItem_Click );
			Text = "Retire_Item";
		}

		void ButtonAssignMacroToItem_Click( object sender, ReflectorButtonEventArgs e )
		{
			if( ItemManagmentState.current_item_serial == null )
			{
				MessageBox.Show( "Need to select an item to retire." );
				return;
			}
			ItemManagmentState.current_item_serial["retire"] = 1;
		}
	}
}
