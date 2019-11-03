using System;
using System.Collections.Generic;
using System.Text;
using OpenSkieScheduler;
using xperdex.classes;

namespace POS.Department.Electronic
{
	internal static class Local
	{
		internal static bool inited;
		internal static ScheduleDataSet schedule;
		internal static DsnConnection dsn;

		static int item_index;
		internal static int ItemIndex
		{
			get
			{
				return item_index;
			}
			set
			{
				item_index = value;
			}
		}

		static Local()
		{
			dsn = new DsnConnection( StaticDsnConnection.dsn.DataSource );

			schedule = new ScheduleDataSet( dsn );
			schedule.Create();
			schedule.Fill();

			//schedule.GetSession( DateTime.Now, 1 );

			inited = true;
		}
	}
}
