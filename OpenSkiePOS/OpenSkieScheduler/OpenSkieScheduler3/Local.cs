namespace OpenSkieScheduler3
{
    public class OpenSkieSchedule
    {
		//readonly 
        //public static ScheduleDataSet data;
		//public static readonly xperdex.classes.DsnConnection odbc;

		static void FixNames()
		{
			//Names.extra_schedule_prefix = "bingo_sched4_";
			Names.schedule_prefix = "bingo_sched4_";
		}

		public static ScheduleDataSet last_created_schedule;
        static OpenSkieSchedule()
        {
			//DsnConnection odbc = new DsnConnection( StaticDsnConnection.dsn.DataSource );
			//data = new ScheduleDataSet( odbc );

        }
	}
}
