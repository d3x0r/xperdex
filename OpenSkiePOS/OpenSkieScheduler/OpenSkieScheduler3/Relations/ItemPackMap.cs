using System;
using System.Collections.Generic;
using System.Text;
using xperdex.classes;
using System.Data;
namespace OpenSkieScheduler3.Relations
{
    class ItemPackMap : MySQLRelationTable2<DataRow, PackTable, ItemDescription >
    {
        static public readonly new string TableName = "pack_item_map";
        public ItemPackMap( DsnConnection dsn, DataSet dataSet )
            : base( dsn, dataSet, true )
        {
            
        }
    }
}
