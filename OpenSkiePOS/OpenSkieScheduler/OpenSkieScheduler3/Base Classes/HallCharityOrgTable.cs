using xperdex.classes;

namespace OpenSkieScheduler3
{
    public class xHallCharityOrgTable:MySQLDataTable
    {
		void AddOrgColumns()
        {
            //Columns.Add( HallTable.PrimaryKey, typeof( int ) );
            //Columns.Add( CharityTable.PrimaryKey, typeof(int));
        }
		public xHallCharityOrgTable( string prefix, string name, bool trim_info )
			: base( name, trim_info, true )
		{
            Prefix = prefix;
			AddOrgColumns();
		}
		public xHallCharityOrgTable( string prefix, string name )
			: base( prefix, name, false )
		{
			AddOrgColumns();
		}
		public xHallCharityOrgTable( string name )
			: base( null, name, false )
		{
			AddOrgColumns();
		}
		public xHallCharityOrgTable( string name, bool add_default_columns )
			: base( name, add_default_columns, false )
		{
			AddOrgColumns();
		}
		public xHallCharityOrgTable()
			: base()
        {
			AddOrgColumns();
        }
    }
}
