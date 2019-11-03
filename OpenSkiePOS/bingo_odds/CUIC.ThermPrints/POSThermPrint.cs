using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace CUIC.ThermPrints
{
	public class POSThermPrint
	{
		POSMessages aPOSMessages = new POSMessages();

		string _windowClass = "POSREG";
		string _windowName = "Point Of Sale";

		public POSThermPrint()
		{
			POSMessages aPOSMessages = new POSMessages(_windowClass, _windowName);
		}

		public void PrintString(string p_string)
		{
			if (p_string.Length > 255)
			{
				aPOSMessages.PostMessage(p_string.Remove(255));
				PrintString(p_string.Substring(255));
			}
			else
			{
				aPOSMessages.PostMessage(p_string);
			}
		}

	}
}
