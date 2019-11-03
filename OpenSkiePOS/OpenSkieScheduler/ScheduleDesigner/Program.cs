using System;
using System.Windows.Forms;

namespace ScheduleDesigner
{
	static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault( false );
            {
                OpenSkieScheduler.ScheduleDataSet schedule;
                if( xperdex.classes.Options.Default["Use static DSN", true].Bool )
                    schedule = new OpenSkieScheduler.ScheduleDataSet( xperdex.classes.StaticDsnConnection.dsn );
                else
                    schedule = new OpenSkieScheduler.ScheduleDataSet( new xperdex.classes.DsnConnection( xperdex.classes.Options.Default["Use DSN", "MySQL"].Value ) );

                schedule.Create();
                schedule.Fill();
                ScheduleDesigner form = new ScheduleDesigner( schedule );
                Application.Run( form );
            }
        }
	}
}
