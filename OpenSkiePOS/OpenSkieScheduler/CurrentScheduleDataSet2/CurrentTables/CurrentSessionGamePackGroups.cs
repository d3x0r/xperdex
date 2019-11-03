using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenSkieScheduler3.Relations;
using System.Data;

namespace OpenSkie.Scheduler.CurrentTables
{
	public class CurrentSessionGameSessionPackGroups : CurrentObjectDataView
	{
		public CurrentSessionGameSessionPackGroups()
			: base( null, SessionGameSessionPackGroup.TableName )
		{
		}

		public CurrentSessionGameSessionPackGroups( DataSet set )
			: base( set, SessionGameSessionPackGroup.TableName )
		{

		}

	}

}
