using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using xperdex.classes;

namespace TopPlayers
{
	public class ReceiptPrinterType : MySQLDataTable  
	{
		public static readonly String TableName = "receipt_printer_type";
		public static readonly String PrimaryKey = MySQLNameTable.ID(TableName);
		public static readonly String NameColumn = MySQLNameTable.Name(TableName);
		
		public ReceiptPrinterType(DsnConnection odbc)
			: base( odbc, "", TableName, true, false, true )
		{
			Columns.Add("isHex", typeof(int));
			Columns.Add("max_page_width", typeof(int));
			Columns.Add("max_page_bold_width", typeof(int));
			Create();
			Fill(); 
			LoadInitValues();
        }

		private void LoadInitValues()
		{
			if (this.Rows.Count == 0)
			{
				this.Rows.Add(1, "Start",1,48,24);
				this.Rows.Add(2, "Epson", 1, 56, 56);
				this.Rows.Add(5, "HTML", 0, 48, 48);
			}
		}		
	}
}
