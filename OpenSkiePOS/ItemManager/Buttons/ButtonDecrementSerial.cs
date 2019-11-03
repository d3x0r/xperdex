using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using xperdex.core.interfaces;
using xperdex.core;

namespace ItemManager
{
	[ButtonAttribute( Name = "Decrement Serial Length" )]
	class ButtonDecrementSerial : PSI_Button
	{
		public ButtonDecrementSerial()
		{
			Text = "-";
			Click += new ClickProc( ButtonDecrementSerial_Click );
		}

		void ButtonDecrementSerial_Click( object sender, ReflectorButtonEventArgs e )
		{
			ItemManagmentState.current_serial_length--;

		}
	}
}
