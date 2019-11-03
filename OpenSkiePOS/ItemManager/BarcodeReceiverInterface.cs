using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebInterfaces;

namespace ItemManager
{
	class BarcodeReceiverInterface : IBarcodeReceiver
	{

		public bool HandleBarcode( string s )
		{
			ItemManagmentState.scanner_DataReceived( s );
			return true;
		}
	}
}
