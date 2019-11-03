using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using xperdex.core.interfaces;

namespace ItemManager
{
	class BarcodeLabelVariable: IReflectorVariable
	{

		public string Name
		{
			get { return "<Barcode>"; }
		}

		public string Text
		{
			get { return ItemManagmentState.Barcode; }
		}
	}

	class BarcodeSerialVariable : IReflectorVariable
	{

		public string Name
		{
			get { return "<Barcode Serial>"; }
		}

		public string Text
		{
			get {
				if( ItemManagmentState.Barcode != null )
				{
					if( ItemManagmentState.Barcode.Length >= ItemManagmentState.current_serial_length )
						return ItemManagmentState.Barcode.Substring( 0, ItemManagmentState.current_serial_length );
					else
						return ItemManagmentState.Barcode;
				}
				else
					return "No Scan";
			}
		}
	}

	class ScannedItemNameVariable : IReflectorVariable
	{

		public string Name
		{
			get { return "<Scanned Item Name>"; }
		}

		public string Text
		{
			get
			{
				if( ItemManagmentState.scanned_item != null )
					return ItemManagmentState.scanned_item_description["item_name"].ToString();
				else
					return "No Item Match";
			}
		}
	}

	class ScannedItemSerialVariable : IReflectorVariable
	{

		public string Name
		{
			get { return "<Scanned Item Serial>"; }
		}

		public string Text
		{
			get
			{
				if( ItemManagmentState.scanned_item != null )
					return ItemManagmentState.scanned_item["series"].ToString();
				else
					return "No Item Match";
			}
		}
	}
}
