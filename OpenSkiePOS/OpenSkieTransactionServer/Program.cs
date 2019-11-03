using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace OpenSkieTransactionServer
{
	static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			bool x = TransactionGlobal.init_trigger;
			Application.Run();
		}
	}
}
