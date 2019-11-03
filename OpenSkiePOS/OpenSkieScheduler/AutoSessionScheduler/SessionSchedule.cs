using System;
using System.Collections.Generic;
using System.Text;
using xperdex.classes;

namespace AutoSessionScheduler
{
	public class SessionSchedule: MySQLDataTable
	{
		public SessionSchedule(): base( "session_sales_schedule", false )
		{
			Columns.Add( "bingoday", typeof( DateTime ) );
			Columns.Add( "session_sales_info_id", typeof( int ) );
			Create();
			Fill();
		}
	}
}
