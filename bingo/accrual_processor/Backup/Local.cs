#define Settings_Flat_File

using System;
using System.Collections.Generic;
using System.Text;
using xperdex.classes;

namespace TopPlayers
{
    public static class Local
    {
		
		public static DsnConnection _dsn;
		
		public static RankPlayerPayout aRankPlayerPayouts;
		public static RankPlayerPrizes aRankPlayerPrizes;
		public static PlayerTrack aPlayerTrack;
		// SETTINGS INI

		public static bool _ReceiptsTopPlayerEnable;
		public static bool _ReceiptsSystemEnable;
		public static string _ReceiptsSystemProtocol;
		public static string _ReceiptsSystemPrinterType;
		public static string _ReceiptsSystemPort;
		public static int _ReceiptsCopies;
		public static string _SwipeCardsSystemPort;
		
		// SETTINGS END

		public static ReceiptPrinterCommands _PrinterCommands;
		//public static CORE.TopPlayersSettings.Config_TopPlayers aConfig;
		//public static CORE.TopPlayersSettings.Config_Receipts _ReceiptConfig;

		public static CORE.SwipeCards.PlayerCard playerCard;
		public static CORE.SwipeCards.ComPort swipeCardPort;
		
		static Local()
        {
			_dsn = new DsnConnection(StaticDsnConnection.dsn.DataSource);

			aRankPlayerPrizes = new RankPlayerPrizes(_dsn);
			aRankPlayerPayouts = new RankPlayerPayout(_dsn);
			aPlayerTrack = new PlayerTrack(_dsn);
			// SETTINGS INI
			//_ReceiptConfig = new CORE.TopPlayersSettings.Config_Receipts(_dsn);

#if (Settings_Flat_File)

			_ReceiptsTopPlayerEnable = bool.Parse(INI.Default["ThermPrinter"]["EnableTopPlayerPrinting", "TRUE"].Value);
			// TRUE / FALSE
			_ReceiptsSystemEnable = bool.Parse(INI.Default["ThermPrinter"]["EnableSystemPrinting", "FALSE"].Value);
			// TRUE / FALSE
			_ReceiptsSystemProtocol = INI.Default["ThermPrinter"]["Protocol", "REG"].Value;
			// Define the Printer Protocol [POS/HTML/REG] POS: Print throught the POS / HTML: Show printing in Browser / REG: Print directly to printer
			_ReceiptsSystemPrinterType = INI.Default["ThermPrinter"]["Printer Type", "1"].Value;
			// Printer emulations: (1)STAR (2)EPSON (3)STAR_EMU (4)EPSON_EMU (5) HTML
			_ReceiptsSystemPort = INI.Default["ThermPrinter"]["Printer Port", "lpt1"].Value;
			// Thermal Printer Port [lpt1/lpt2/...]		
			_ReceiptsCopies = INI.Default["ThermPrinter"]["Copies to Print", "2"].Integer;
			// Number of copies to print

			_SwipeCardsSystemPort = INI.Default["SwipeCards"]["Swipe Cards Port", "COM1"];
			

			
#else
			_StartingSession = Options.Default["FTNSYS"]["Rate Rank"]
				["Starting Session", "5", "Session Number to start Ranking"].Integer;

			_StartingDayOfWeek = Options.Default["FTNSYS"]["Rate Rank"]
				["Starting DayOfWeek", "4", "Week day to start Ranking [Monday = 1 .. Sunday = 7]"].Integer;

			_TopPlayersNumber = Options.Default["FTNSYS"]["Rate Rank"]
				["Top Players Number", "10", "The Top # to Pay."].Integer;

			_BottomPlayersNumber = Options.Default["FTNSYS"]["Rate Rank"]
				["Bottom Players Number", "3", "The Bottom # to Pay."].Integer;

			_DaysToClaim = Options.Default["FTNSYS"]["Rate Rank"]
				["Days To Claim", "30", "Days to claim a Prize"].Integer;

			_ReceiptsTopPlayerEnable = bool.Parse(Options.Default["FTNSYS"]["Rate Rank"]["Receipts"]
				["Enable", "TRUE", "TRUE / FALSE"].Value);

			_ReceiptsCopies = Options.Default["FTNSYS"]["Rate Rank"]["Receipts"]
				["Copies", "2", "Number of copies to print"].Integer;

			_ReceiptsSystemEnable = bool.Parse(Options.Default["AIMS_SL"]["SYSTEMS"][System.Environment.MachineName]["Printing"]["Thermal Printer"]
				["Enable", "TRUE", "System/Computer has a Printer [TRUE/FALSE]"].Value);

			_ReceiptsSystemProtocol = Options.Default["AIMS_SL"]["SYSTEMS"][System.Environment.MachineName]["Printing"]["Thermal Printer"]
				["Protocol", "REG", "Define the Printer Protocol [POS/HTML/REG] POS: Print throught the POS / HTML: Show printing in Browser / REG: Print directly to printer"].Value;

			_ReceiptsSystemPrinterType = Options.Default["AIMS_SL"]["SYSTEMS"][System.Environment.MachineName]["Printing"]["Thermal Printer"]
				["Printer Type", "1", "Printer emulations: (1)STAR (2)EPSON (3)STAR_EMU (4)EPSON_EMU (5) HTML"].Value;

			_ReceiptsSystemPort = Options.Default["AIMS_SL"]["SYSTEMS"][System.Environment.MachineName]["Printing"]["Thermal Printer"]
				["Printer Port", "lpt1", "Thermal Printer Port [lpt1/lpt2/...]"].Value;
#endif


			// SETTINGS END

			_PrinterCommands = new ReceiptPrinterCommands(_dsn);
			_PrinterCommands.PrinterTypeId = _ReceiptsSystemPrinterType;

			playerCard = new CORE.SwipeCards.PlayerCard();
			
		}
    }
}
