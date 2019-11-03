using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenSkieScheduler3.Relations;
using OpenSkieScheduler3;
using System.Data;

namespace OpenSkie.Scheduler.CurrentTables
{
	public class CurrentBundles: CurrentObjectDataView
	{
		new public static readonly String TableName = CurrentObjectTableView.TableName( BundleTable.TableName );

		public CurrentBundles( DataSet set )
			: base( set, BundleTable.TableName )
		{
		}
	}
}
