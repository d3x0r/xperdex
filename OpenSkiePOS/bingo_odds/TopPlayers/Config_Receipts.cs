using System;
using System.Collections.Generic;
using System.Text;
using xperdex.classes;

namespace CORE.TopPlayersSettings
{
    public class Config_Receipts
    {
		private CORE.Config.OptionTree myOptionTree;

		private bool _ReceiptsSystemEnable;
		private bool _ReceiptsTopPlayerEnable;
		private string _ReceiptsSystemProtocol;
		private string _ReceiptsSystemPrinterType;
		private string _ReceiptsSystemPort;

        #region Properties

		public bool ReceiptsSystemEnable
		{
			get { return _ReceiptsSystemEnable; }
		}
		public bool ReceiptsTopPlayerEnable
		{
			get { return _ReceiptsTopPlayerEnable; }
		}

		public string ReceiptsSystemProtocol
		{
			get { return _ReceiptsSystemProtocol; }
		}

		public string ReceiptsSystemPrinterType
		{
			get { return _ReceiptsSystemPrinterType; }
		}
		public string ReceiptsSystemPort
		{
			get { return _ReceiptsSystemPort; }
		}
	
        # endregion

		public Config_Receipts(DsnConnection odbc)
		{
			myOptionTree = new CORE.Config.OptionTree(odbc);

			_ReceiptsTopPlayerEnable =
				bool.Parse(myOptionTree.GetSetValueOptionTree(
				"AIMS_SL/Rank Players/Receipts/Enable", "TRUE",
				"To Print receipts in Paymaster [TRUE/FALSE]"));

			_ReceiptsSystemProtocol =
				myOptionTree.GetSetValueOptionTree(
				"AIMS_SL/SYSTEMS/" + System.Environment.MachineName + "/Printing/Thermal Printer/Protocol", "HTML",
				"Define the Printer Protocol [POS/HTML/REG] POS: Print throught the POS / HTML: Show printing in Browser / REG: Print directly to printer");

			_ReceiptsSystemEnable =
				bool.Parse(myOptionTree.GetSetValueOptionTree(
				"AIMS_SL/SYSTEMS/" + System.Environment.MachineName + "/Printing/Thermal Printer/Enabled", "TRUE",
				"Enable thermal printer for receipts? [TRUE/FALSE])"));

			_ReceiptsSystemPrinterType =
				myOptionTree.GetSetValueOptionTree(
				"AIMS_SL/SYSTEMS/" + System.Environment.MachineName + "/Printing/Printer Type", "1",
				"Printer emulations: (1)STAR (2)EPSON (3)STAR_EMU (4)EPSON_EMU (5) HTML");

			_ReceiptsSystemPort =
				myOptionTree.GetSetValueOptionTree(
				"AIMS_SL/SYSTEMS/" + System.Environment.MachineName + "/Printing/Thermal Printer/Port", "lpt1",
				"Thermal Printer Port [lpt1/lpt2/...]");			
		}
    }
}
