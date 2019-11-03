using xperdex.classes;

namespace OpenSkieScheduler3
{
    class HallTable: MySQLNameTable
    {
		new public static readonly string TableName = "hall_names";
		new public static readonly string PrimaryKey = "hall_id";
		public static readonly string NameColumn = "hall_name";

        public HallTable()
			: base( Names.schedule_prefix, TableName )
        {
        }
    }
}
