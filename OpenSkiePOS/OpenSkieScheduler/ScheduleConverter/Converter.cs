using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using OpenSkieScheduler;
using xperdex.classes;

namespace ScheduleConverter
{
	public partial class Converter : Form
	{

		ScheduleDataSet schedule1;
		ScheduleDataSet schedule2;

		public Converter()
		{
			InitializeComponent();
		}

		private void Converter_Load( object sender, EventArgs e )
		{
			textBoxDsn1.Text = "MySQL";
			textBoxDsn2.Text = "MySQL";
		}

		private void buttonCreateSchedule1_Click( object sender, EventArgs e )
		{
			labelStatus1.Text = "Creating schedule 1...";
			OpenSkieSchedule.UseGuid = checkBoxUseGuid1.Checked;
			OpenSkieSchedule.PacksRelateToPrizes = checkBoxPackToPrizes1.Checked;
			OpenSkieSchedule.GamesRelateToSessions = checkBoxGameToSessions1.Checked;
			schedule1 = new ScheduleDataSet( new DsnConnection( textBoxDsn1.Text ) );
			schedule1.Create();
			labelStatus1.Text = "Created schedule 1...";
		}

		private void buttonLoad1_Click( object sender, EventArgs e )
		{
			if( schedule1 == null )
			{
				MessageBox.Show( "Need to create a schedule before you can load it." );
				return;
			}
			labelStatus1.Text = "Loading schedule 1...";
			OpenSkieSchedule.UseGuid = checkBoxUseGuid1.Checked;
			OpenSkieSchedule.PacksRelateToPrizes = checkBoxPackToPrizes1.Checked;
			OpenSkieSchedule.GamesRelateToSessions = checkBoxGameToSessions1.Checked;
			if( checkBoxLegacySchedule1.Checked )
			{
				//schedule1 = new ScheduleDataSet( new DsnConnection( textBoxDsn1.Text ) );
				schedule1.Fill();
				EltaninObject.ScheduleDataSetLoader.LoadLegacySchedule( textBoxLegacyPath1.Text, schedule1 );
			}
			else
			{
				//schedule1 = new ScheduleDataSet( new DsnConnection( textBoxDsn1.Text ) );
				schedule1.Fill();
			}
			labelStatus1.Text = "Loaded schedule 1...";
		}

		private void buttonCreateSchedule2_Click( object sender, EventArgs e )
		{
			labelStatus2.Text = "Creating schedule 2...";
			OpenSkieSchedule.UseGuid = checkBoxUseGuid2.Checked;
			OpenSkieSchedule.PacksRelateToPrizes = checkBoxPackToPrizes2.Checked;
			OpenSkieSchedule.GamesRelateToSessions = checkBoxGameToSessions2.Checked;
			schedule2 = new ScheduleDataSet( new DsnConnection( textBoxDsn2.Text ) );
			schedule2.Create();
			labelStatus2.Text = "Created schedule 2...";
		}

		private void buttonEdit1_Click( object sender, EventArgs e )
		{
			if( schedule1 != null )
			{
				ScheduleDesigner.ScheduleDesigner form = new ScheduleDesigner.ScheduleDesigner( schedule1 );
				form.ShowDialog();
			}
		}

		private void buttonEdit2_Click( object sender, EventArgs e )
		{
			ScheduleDesigner.ScheduleDesigner form = new ScheduleDesigner.ScheduleDesigner( schedule2 );
			form.ShowDialog();
		}

		private void buttonStoreSchedule2_Click( object sender, EventArgs e )
		{
			if( checkBoxLegacySchedule2.Checked )
			{
				EltaninObject.ScheduleDataSetLoader.StoreLegacySchedule( textBoxLegacyPath2.Text, schedule1 );
			}
			else
			{
				schedule2.Commit();
			}
		}

		private void buttonConvert_Click( object sender, EventArgs e )
		{
			ScheduleDataSet.ConvertSchedule( schedule2, schedule1 );
		}

		private void checkBoxLegacySchedule1_CheckedChanged( object sender, EventArgs e )
		{
			if( checkBoxLegacySchedule1.Checked )
			{
				String Drive = INI.Legacy( null )["Data Files"]["Schedule Drive", "F"].Value;
				String Path = INI.Legacy( null )["Data Files"]["Schedule Path", "/ftn3000/data/schedule"].Value;
				String SchedulePath;
				if( Drive.Length > 0 )
					SchedulePath = Drive + ":" + Path;
				else
					SchedulePath = Path;
				textBoxLegacyPath1.Text = SchedulePath;
			}
		}

		private void checkBoxLegacySchedule2_CheckedChanged( object sender, EventArgs e )
		{
			if( checkBoxLegacySchedule2.Checked )
			{
				String Drive = INI.Legacy( null )["Data Files"]["Schedule Drive", "F"].Value;
				String Path = INI.Legacy( null )["Data Files"]["Schedule Path", "/ftn3000/data/schedule"].Value;
				String SchedulePath;
				if( Drive.Length > 0 )
					SchedulePath = Drive + ":" + Path;
				else
					SchedulePath = Path;
				textBoxLegacyPath2.Text = SchedulePath;
			}
		}

	}
}
