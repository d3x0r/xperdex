using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OpenSkieScheduler3;
using xperdex.classes;

namespace InitScheduleDatabase
{
	public partial class Form1 : Form
	{
		ScheduleDataSet schedule;
		public Form1()
		{
			//XDataTable.DefaultAutoKeyType = typeof( Guid );
			schedule = new ScheduleDataSet();
			InitializeComponent();
		}

		private void button1_Click( object sender, EventArgs e )
		{
			if( schedule.schedule_dsn == null 
				|| schedule.schedule_dsn.DataSource != textBoxDSN.Text ) 
				schedule.schedule_dsn = new DsnConnection( textBoxDSN.Text );
			// enable optional logging, default is disabled.
			schedule.schedule_dsn.disable_logging = false;
			// optional destination logging; if logging is not disabled, this should not be null.
			schedule.schedule_dsn.log_filename = "schedule.create.sql";
			// create the dataset
			schedule.Create();
			// put in default values if tables are empty... good to do the first time , but next fill will do it anyway
			schedule.Fill();
			schedule.Commit();
		}

		private void buttonDropSchedule_Click( object sender, EventArgs e )
		{
			if( schedule.schedule_dsn == null
				|| schedule.schedule_dsn.DataSource != textBoxDSN.Text )
				schedule.schedule_dsn = new DsnConnection( textBoxDSN.Text );
			// enable optional logging, default is disabled.
			schedule.schedule_dsn.disable_logging = false;
			// optional destination logging; if logging is not disabled, this should not be null.
			schedule.schedule_dsn.log_filename = "schedule.drop.sql";
			// drop the schedule in a proper order so child relations are released first.
			schedule.Drop();
		}
	}
}
