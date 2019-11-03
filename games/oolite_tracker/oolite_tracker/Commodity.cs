using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.Data;
using xperdex.classes;

namespace oolite_tracker
{
    public class Commodity:DataColumn
    {
        //public string Name;
        public Pen pen;
        public DataRow row;

        public Commodity( string name, Color color )
        {
            this.ColumnName = name;
			//DataTable history = 
            //Local.grid.AddCommodityTable(history);
            pen = new Pen(color);
            //Name = name;
        }
    }

	public class CommodityTable : MySQLNameTable
	{
		static readonly new string TableName = "Commodities";
		public CommodityTable()
        {
            base.TableName = TableName;
        }
		public CommodityTable( DsnConnection dsn ): base( dsn, null, TableName, false )
		{
			base.TableName = TableName;
		}

	}


}
