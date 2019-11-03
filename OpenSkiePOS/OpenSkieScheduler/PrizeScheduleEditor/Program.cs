using System;
using System.Windows.Forms;
using OpenSkieScheduler3;

namespace PrizeScheduleEditor
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
			Form1 f = null;
			//new xperdex.classes.OptionEditor().Show();
			try
			{
				//new OpenSkieScheduler.Relations.Meta.SessionGameMetaRelation( OpenSkieSchedule.data );
				//new OpenSkieScheduler.Relations.Meta.SessionPackMetaRelation( OpenSkieSchedule.data );
                ScheduleDataSet schedule = new ScheduleDataSet(xperdex.classes.StaticDsnConnection.dsn);
                schedule.Fill();
				f = new Form1( schedule );
			}
			catch( NullReferenceException )
			{
				MessageBox.Show( "Probably cannot connect to database... " );
				return;
			}
			Application.Run( f );
		}
    }
}
