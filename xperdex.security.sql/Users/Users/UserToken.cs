using System;
using System.Collections.Generic;
using System.Text;
using xperdex.classes;
using System.Data;

namespace xperdex.dataset.users
{
	public class UserToken : MySQLDataTable
	{
		public static readonly String TableName = "token_info";
		public UserToken( DsnConnection odbc, DataSet ds )
			: base( odbc, "permission_", TableName, true, true )
		{
			ds.Tables.Add( this );
		}
	}
}
