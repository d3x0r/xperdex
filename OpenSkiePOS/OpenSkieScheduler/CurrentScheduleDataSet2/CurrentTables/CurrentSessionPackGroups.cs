using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using xperdex.classes;

namespace OpenSkieScheduler3.Relations
{
	public class CurrentSessionPackGroup : CurrentObjectDataView
	{
		public CurrentSessionPackGroup()
			: base( null, SessionGame.TableName )
		{
		}

		public CurrentSessionPackGroup( DataSet set )
			: base( set, SessionPackGroup.TableName )
		{

		}

	}
}
