using System;
using System.Collections.Generic;
using System.Text;
using OpenSkieScheduler3.Relations;
using xperdex.classes;
using System.Data;
using OpenSkieScheduler3;

namespace OpenSkie.Scheduler.CurrentTables
{
	public class CurrentSessionPack: CurrentObjectDataView
	{
		new public static readonly String TableName = CurrentObjectTableView.TableName( OpenSkieScheduler3.Relations.SessionPack.TableName );
		public CurrentSessionPack(): base( null, null )
		{
		}

		public CurrentSessionPack( DataSet set )
			: base( set, SessionPack.TableName, true )
		{
		}
	}
}
