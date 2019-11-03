using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using xperdex.core;
using xperdex.core.interfaces;
using xperdex.classes;

namespace ItemManager
{
	[ButtonAttribute( Name = "Increment Serial Length" )]
	class ButtonIncrementSerial : PSI_Button
	{
		public ButtonIncrementSerial()
		{
			Text = "+";
			Click += new ClickProc( ButtonDecrementSerial_Click );
		}

		void ButtonDecrementSerial_Click( object sender, ReflectorButtonEventArgs e )
		{
			ItemManagmentState.current_serial_length++;
		}
	}

	[ButtonAttribute( Name = "Max Serial Length" )]
	class ButtonMaximizeSerial : PSI_Button
	{
		public ButtonMaximizeSerial()
		{
			Text = "Max";
			Click += new ClickProc( ButtonDecrementSerial_Click );
		}

		void ButtonDecrementSerial_Click( object sender, ReflectorButtonEventArgs e )
		{
			if( ItemManagmentState.Barcode == null )
				return;
			ItemManagmentState.current_serial_length  = ItemManagmentState.Barcode.Length;
		}
	}

	[ButtonAttribute( Name = "Manual Enter Barcode" )]
	class ButtonManualEnter : PSI_Button
	{
		public ButtonManualEnter()
		{
			Text = "Max";
			Click += new ClickProc( ButtonDecrementSerial_Click );
		}

		void ButtonDecrementSerial_Click( object sender, ReflectorButtonEventArgs e )
		{
			String barcode = QueryNewName.Show( "Enter new Barcode" );
			ItemManagmentState.Barcode = barcode;
			ItemManagmentState.current_serial_length = ItemManagmentState.Barcode.Length;
		}
	}
}
