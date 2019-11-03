using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using xperdex.classes;

namespace xperdex.dataset.users
{
	public static class UserDataSet
	{
		public static DataSet BuildDataSet( DsnConnection odbc, DataSet dataSet )
		{
			new User( odbc, dataSet );
			new UserGroup( odbc, dataSet );
			new UserToken( odbc, dataSet );

			new UserGroupRelation( odbc, dataSet );
			new GroupTokenRelation( odbc, dataSet );
			return dataSet;
		}		
	}
}
