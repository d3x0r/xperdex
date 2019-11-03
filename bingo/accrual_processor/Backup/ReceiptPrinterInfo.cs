using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using xperdex.classes;

namespace TopPlayers
{
	public class ReceiptPrinterInfo : MySQLDataTable  
	{
		public static readonly String TableName = "receipt_printer_info";
		public static readonly String PrimaryKey = "printer_id";
		public static readonly String NameColumn = "printer_type";
		
		public ReceiptPrinterInfo(DsnConnection odbc)
			: base( odbc, "", TableName, false, false, false )
		{
			Fill();
        }

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
		/// Only use when already filter the table with printer_id
		/// </summary>
		/// <param name="Command"></param>
		/// <returns></returns>
		public string GetCommand(string Command)
		{
			string printerCommand = this.Rows[0][Command].ToString();
			printerCommand = HexListToAscii(printerCommand, ";");
			return printerCommand;	
		}

	}
}
