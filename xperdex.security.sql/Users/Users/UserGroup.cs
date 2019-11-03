using System;
using System.Collections.Generic;
using System.Text;
using xperdex.classes;
using System.Data;

namespace xperdex.dataset.users
{
	public class UserGroup : MySQLDataTable
	{
		public static readonly String TableName = "group_info";
		public UserGroup( DsnConnection odbc, DataSet ds ): base( odbc, "permission_", TableName, true, true )
		{
			ds.Tables.Add( this );
		}
	}
}
