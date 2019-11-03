using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using xperdex.core;
using xperdex.core.interfaces;
using System.Data;
using xperdex.classes;
using xperdex.gui;

namespace ItemManager
{
	[ButtonAttribute( Name = "Invoice Item" )]
	class ButtonInvoice: PSI_Button
	{
		public ButtonInvoice()
		{
			Click += new ClickProc( ButtonInvoice_Click );
			Text = "Invoice_Item";
		}

		void ButtonInvoice_Click( object sender, ReflectorButtonEventArgs e )
		{
			if( ItemManagmentState.Barcode == null )
			{
				Banner.Show( "No Scanned Barcode" );
				return;
			}
			if( ItemManagmentState.scanned_item == null )
			{
				String serial = ItemManagmentState.Barcode.Substring( 0, ItemManagmentState.current_serial_length );
				DataRow new_item = ItemManagmentState.item_dataset.items.NewRow();
				new_item["series"] = serial;
				new_item["serial_length"] = ItemManagmentState.current_serial_length;
				new_item["item_description_id"] = ItemManagmentState.current_item["Item_description_id"];
				new_item["retire"] = 0;
				ItemManagmentState.item_dataset.items.Rows.Add( new_item );
			}
			else
			{
				Banner.Show( "Barcode already assigned to an item" );
			}
		}
	}
}
