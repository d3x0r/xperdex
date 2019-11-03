using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace oolite_tracker
{
    public class PriceHistoryTable: DataTable
    {
        public PriceHistoryTable()
        {
            this.TableName = "Price_History";
            this.Columns.Add("ID", typeof(int));
            this.Columns.Add("system_id", typeof(int));
            this.Columns.Add("Commodity_Name", typeof(string));
            this.Columns.Add("time",typeof(DateTime));
            this.Columns.Add("price",typeof(double));
        }
        public void Load()
        {

        }
        public void AddPriceUpdate( double d )
        {
            //AddRow
        }
    }
}
