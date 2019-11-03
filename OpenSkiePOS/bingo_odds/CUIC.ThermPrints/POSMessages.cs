using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace CUIC.ThermPrints
{
	public class POSMessages
	{
		[DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = false)]
		static extern IntPtr SendMessage(HandleRef hWnd, uint Msg, IntPtr wParam, IntPtr lParam);

		[DllImport("user32.dll")]
		public static extern int FindWindow(string lpClassName, string lpWindowName);

		[DllImport("user32.dll")]
		public static extern int SendMessage(int hWnd, uint Msg, int wParam, int lParam);

		[DllImport("user32.dll")]
		public static extern int PostMessage(int hWnd, uint Msg, int wParam, int lParam);

		[DllImport("user32.dll")]
		private static extern int GetParent(int hWnd);

		[DllImport("user32.dll", SetLastError = true)]
		private static extern IntPtr FindWindowEx(IntPtr parentHandle, IntPtr childAfter, string className, string windowTitle);

		[DllImport("USER32.DLL")]
		private static extern int GetWindowLong(IntPtr hWnd, int nIndex);

		[DllImport("Kernel32.DLL")]
		private static extern IntPtr GlobalAddAtom(string lpString);

		private const int WM_COMMAND = 0x0112;
		private const int WM_USER = 1024;
		private const int WM_CLOSE = 0xF060;
		private const int BN_CLICKED = 245;
		private const int GWL_ID = -12;
		IntPtr hwnd = IntPtr.Zero;

		string _windowClass = "TaskMonClass";
		string _windowName = "Task Completion Monitor";

		public POSMessages()
		{
			hwnd = (IntPtr)FindWindow(_windowClass, _windowName);
		}

		public POSMessages(string p_windowClass, string p_windowName)
		{
			SetWindowSettings(p_windowClass, p_windowName);
		}

		public void SetWindowSettings(string p_windowClass, string p_windowName)
		{
			_windowClass = p_windowClass;
			_windowName = p_windowName;
			hwnd = (IntPtr)FindWindow(_windowClass, _windowName);
		}

		public void PostMessage(string p_string)
		{
			if (PostMessage((int)hwnd, WM_USER + 500, (int)GlobalAddAtom(p_string), 0) == 0)
				PostMessage(p_string);
		}

		public void PostMessage()
		{
			string p_string = "Done";
			if (PostMessage((int)hwnd, WM_USER + 500, (int)GlobalAddAtom(p_string), 0) == 0)
				PostMessage(p_string);
		}
	}
}
