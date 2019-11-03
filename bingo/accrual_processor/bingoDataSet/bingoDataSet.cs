using System.Data;

namespace bingoDataSet {
    
    
    public partial class bingoDataSet {
		partial class sesslotDataTable
		{
			public static string TableName = "sesslot";
			public static string PrimaryKey = "slt_id";
			public static string NameColumn = "slt_desc";
			string _TableColumns;

			public string TableColumns
			{
				get
				{
					if( _TableColumns == null )
					{
						bool first = true;
						// TODO: Complete member initialization
						foreach( DataColumn col in Columns )
						{
							if( !first )
								_TableColumns += ",";
							first = false;
							_TableColumns += TableName + "." + col.ColumnName;
						}
					}
					return _TableColumns;
				}
			}
		}

		partial class programDataTable
		{
			public static string TableName = "program";
			public static string PrimaryKey = "prg_id";
			public static string NameColumn = "prg_desc";
		}
		partial class categoryDataTable
		{
			public static string TableName = "category";
			public static string PrimaryKey = "ctg_id";
			public static string NameColumn = "ctg_desc";
		}

		partial class listpickDataTable
		{
			public static string TableName = "listpick";
			public static string PrimaryKey = "lst_id";
			public static string NameColumn = "lst_desc";
		}
	}
}
