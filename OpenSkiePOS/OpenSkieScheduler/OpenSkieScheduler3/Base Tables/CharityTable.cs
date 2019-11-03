using System;
using xperdex.classes;

namespace OpenSkieScheduler3
{
    public class CharityTable: MySQLNameTable
    {
		new public static readonly String TableName = "charity_names";
		new public static readonly string PrimaryKey = "charity_id";
		public static readonly string NameColumn = "charity_name";
		public CharityTable()
			: base( Names.schedule_prefix, TableName )
        {
        }
    }
}
