using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenSkieScheduler3.Relations;
using System.Data;
using OpenSkieScheduler3;

namespace OpenSkie.Scheduler.CurrentTables
{
	public class CurrentSessions : CurrentObjectDataView
	{
		new public static readonly String TableName = CurrentObjectTableView.TableName( SessionTable.TableName );

		public CurrentSessions( DataSet set )
			: base( set, SessionTable.TableName )
		{
		}
	}
}
