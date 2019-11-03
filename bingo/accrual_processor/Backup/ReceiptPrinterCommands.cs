using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using xperdex.classes;

namespace TopPlayers
{
	public class ReceiptPrinterCommands : MySQLDataTable  
	{
		public List<string> Signatures;
		
		public static readonly String TableName = "receipt_printer_commands";
		public static readonly String PrimaryKey = "printer_command_id";
		public string PrinterTypeId;
		
		public ReceiptPrinterCommands(DsnConnection odbc)
			: base( odbc, "", TableName, true, false, false,false )
		{

			Columns.Add("printer_type_id", typeof(int));
			Columns.Add("command_name", typeof(string));
			Columns.Add("command", typeof(string));
			Create();
			Fill();
			LoadInitValues();          
        }

		private void LoadInitValues()
		{
			if (this.Rows.Count == 0)
			{
				this.Rows.Add(1,2, "mode_a", "1B;4D;01");
				this.Rows.Add(2,2, "mode_b", "1B;4D;00");

				this.Rows.Add(3,1, genInitReceipt, "1B;40;1B;55;30;1B;30");
				this.Rows.Add(4,2, genInitReceipt, "1B;40;1B;55;30;1B;30");
				this.Rows.Add(5,5, genInitReceipt, "<HTML>");
							  
				this.Rows.Add(6,1, genEndReceipt, "1B;61;0A");
				this.Rows.Add(7,2, genEndReceipt, "1B;61;0A");
				this.Rows.Add(8,5, genEndReceipt, "</HTML>");
				
				this.Rows.Add(9,1, genBoldOn, "0E");
				this.Rows.Add(10,2, genBoldOn, "1D;21;01");
				this.Rows.Add(11,5, genBoldOn, "<B>");

				this.Rows.Add(12,1, genBoldOff, "14");
				this.Rows.Add(13,2, genBoldOff, "1D;21;00");
				this.Rows.Add(14,5, genBoldOff, "</B>");

				this.Rows.Add(15,1, genUnderlineOn, "1B;2D;01");
				this.Rows.Add(16,2, genUnderlineOn, "1B;2D;01");
				this.Rows.Add(17,5, genUnderlineOn, "<U>");

				this.Rows.Add(18,1, genUnderlineOff, "1B;2D;00");
				this.Rows.Add(19,2, genUnderlineOff, "1B;2D;00");
				this.Rows.Add(20,5, genUnderlineOff, "</U>");

				this.Rows.Add(21,1, "highlight_on", "1B;34");
				this.Rows.Add(22,2, "highlight_on", "1D;42;01");
				this.Rows.Add(23,5, "highlight_on", "<B>");

				this.Rows.Add(24,1, "highlight_off", "1B;35");
				this.Rows.Add(25,2, "highlight_off", "1D;42;00");
				this.Rows.Add(26,5, "highlight_off", "</B>");

				this.Rows.Add(27,1, "emphasize_on", "1B;45");
				this.Rows.Add(28,2, "emphasize_on", "1B;45;01");
				this.Rows.Add(29,5, "emphasize_on", "<STRONG>");

				this.Rows.Add(30,1, "emphasize_off", "1B;46");
				this.Rows.Add(31,2, "emphasize_off", "1B;45;00");
				this.Rows.Add(32,5, "emphasize_off", "</STRONG>");

				this.Rows.Add(33,1, genLinefeed, "0A");
				this.Rows.Add(34,2, genLinefeed, "1B;64;04");
				this.Rows.Add(35,5, genLinefeed, "<BR>");

				this.Rows.Add(36,1, "cut", "1B;64;30");
				this.Rows.Add(37,2, "cut", "1D;56;31");
				this.Rows.Add(38,5, "cut", "<HR>");
			}

		}

		public static string genInitReceipt = "init_receipt";
		public static string genEndReceipt = "end_receipt";
		public static string genCutPaper = "cut";
		public static string genUnderlineOn = "underline_on";
		public static string genUnderlineOff = "underline_off";
		public static string genBoldOn = "bold_on";
		public static string genBoldOff = "bold_off";
		public static string genLinefeed = "line_feed";
		
		public string HexListToAscii(string hexList, string delimiter)
		{
			string retVal = "";

			if (hexList != "")
			{
				int startAt = 0;
				int nextDelimAt;
				int endAt;
				do
				{
					nextDelimAt = hexList.IndexOf(delimiter, startAt);
					endAt = (nextDelimAt != -1 ? nextDelimAt : hexList.Length);
					retVal += (char)Convert.ToSByte(hexList.Substring(startAt, endAt - startAt), 16);

					startAt = endAt + delimiter.Length;
				} while (startAt <= hexList.Length);
			}
			else
				retVal = "";

			return retVal;
		}

		/// <summary>
		/// Only use when already filter the table with printer_type_id
		/// </summary>
		/// <param name="Command"></param>
		/// <returns></returns>
		public string GetCommand(string Command)
		{
			string printerCommand = "";
			DataRow[] ParentRow = this.Select("command_name = '" + Command + "' " +
											" AND printer_type_id = " + PrinterTypeId);
			if (ParentRow.Length > 0)
				if (ParentRow.Length > 1)
					printerCommand = ParentRow[0]["command"].ToString() + "... ";
				else
					printerCommand = ParentRow[0]["command"].ToString();
			if (ParentRow.Length > 0)
			{
				if (ParentRow[0]["printer_type_id"].ToString() != "5")//Hexadecimal
					printerCommand = HexListToAscii(printerCommand, ";");
			}
			else
				printerCommand = "Error";
			return printerCommand;
		}

		/// <summary>
		/// Only use when already filter the table with printer_type_id
		/// </summary>
		/// <param name="Command"></param>
		/// <param name="Times"></param>
		/// <returns></returns>
		public string GetCommand(string Command, int Times)
		{
			string printerCommand = "";
			string timesPrinterCommand = "";
			DataRow[] ParentRow = this.Select("command_name = '" + Command + "' " +
											" AND printer_type_id = " + PrinterTypeId);
			if (ParentRow.Length > 0)
				if (ParentRow.Length > 1)
					printerCommand = ParentRow[0]["command"].ToString() + "... ";
				else
					printerCommand = ParentRow[0]["command"].ToString();
			if (ParentRow[0]["printer_type_id"].ToString() != "5")//Hexadecimal
				printerCommand = HexListToAscii(printerCommand, ";");
			for (int i = 0; i < Times; i++)
				timesPrinterCommand += printerCommand;
			return timesPrinterCommand;
		}
	}
}
