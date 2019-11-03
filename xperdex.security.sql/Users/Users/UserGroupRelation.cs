using System;
using System.Collections.Generic;
using System.Text;
using xperdex.classes;
using System.Data;

namespace xperdex.dataset.users
{
	public class UserGroupRelation : MySQLRelationTable
	{
		public static readonly string TableName = "user_groups";
		public UserGroupRelation( DsnConnection odbc, DataSet ds )
			: base( odbc
			, ds
			, "permission_"
			, TableName
			, ds.Tables[User.TableName]
			, ds.Tables[UserGroup.TableName]
			, true )
		{
		}

	}
}
