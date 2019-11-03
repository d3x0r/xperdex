using System;
using System.Collections.Generic;
using System.Text;

namespace xperdex.classes
{
	public class MySQLViewCache : MySQLDataTable
	{

		public MySQLViewCache( DsnConnection dsn, String Prefix, String ViewName )
		{
			connection = dsn;
			this.Prefix = Prefix;
			this.TableName = ViewName;
			live = false;

			Fill();
		}
	}
}
