using System;
using System.Collections.Generic;
using System.Text;
using xperdex.classes;
using System.Data;

namespace xperdex.dataset.users
{
	public class GroupTokenRelation : MySQLRelationTable
	{
		public static readonly string TableName = "group_tokens";
		public GroupTokenRelation( DsnConnection odbc, DataSet ds ): 
			base( odbc
			, ds
			, "permission_"
			, TableName
			, ds.Tables[UserGroup.TableName]
			, ds.Tables[UserToken.TableName]
			, true )
		{
		}
	}
}
