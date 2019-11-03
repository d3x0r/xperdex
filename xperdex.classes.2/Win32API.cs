using System;
using System.Runtime.InteropServices;

namespace xperdex.classes
{
        // Declaration of external function.	public static class Win32API
	{

		[DllImport( "user32.dll" )]		public static extern int SendMessage( int hWnd, int wMsg, int wParam, ref int lParam );
		// Windows message constant for setting the tab stops for a list box		public const int LB_SETTABSTOPS = 0x192;		[DllImport( "user32.dll" )]
		public static extern int PostMessage( IntPtr hWnd, uint msg,									   IntPtr wParam, IntPtr lParam );
		[DllImport( "user32.dll" )]
		public static extern int PostMessage( IntPtr hWnd, uint msg,									   int wParam, int lParam );
		[DllImport( "USER32.DLL" )]		public static extern IntPtr FindWindow(			string lpClassName,			string lpWindowName		);

		[DllImport("kernel32.dll", SetLastError=true, CharSet=CharSet.Auto)]		static extern ushort GlobalAddAtom(string lpString);
	}
}
