using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace CUIC.ThermPrints
{
	public class ThermPrint
	{
		//  Receipt Printer Specific Defines for Star SP200
		public static string szInitPrinter = "\x1B\x40\x1B\x55\x30\x1B\x30";
		public static string szCutPaper = "\x1B\x64\x30";
		public static string szExpandedOn = "\x0E";
		public static string szExpandedOff = "\x14";
		public static string szUnderlineOn = "\x1B\x2D\x31";
		public static string szUnderlineOff = "\x1B\x2D\x30";
		public static string szLinefeed = "\x0A";
		public static string szHalfLinefeed = "\n";
		public static string szTwoLinefeed = "\x0A\x0A";
		public static string szOpenDrawer1 = "\x1C";
		public static string szOpenDrawer2 = "\x1A";
		public static string szEndReceipt = "\x1B\x61\x0A";
	}
}
