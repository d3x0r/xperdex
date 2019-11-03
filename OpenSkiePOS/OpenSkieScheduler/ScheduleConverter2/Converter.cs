using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using OpenSkieScheduler3;
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
			if( checkBoxLegacySchedule1.Checked )
			{
				Options.Default[Options.ProgramName]["lastrun/schedule"].Value = textBoxLegacyPath1.Text;
				Options.Default[Options.ProgramName]["lastrun/bingo.ini"].Value = textBoxBingoINI.Text;
				Options.Default[Options.ProgramName]["lastrun/ftnsys.ini"].Value = textBoxFtnSysINI.Text;

				if( checkBoxLoadOldSchedule1.Checked )
				{
					schedule1.Fill();
				}
#if ELTANIN_SUPPORT
				EltaninObject.ScheduleDataSetLoader.LoadLegacySchedule( textBoxLegacyPath1.Text
						, schedule1
						, checkBoxUseEPaperCardset.Checked
						, textBoxBingoINI.Text
						, textBoxFtnSysINI.Text
                        , checkBoxLoadOldSchedule1.Checked
						);
#endif
			}
			else
			{
				//schedule1 = new ScheduleDataSet( new DsnConnection( textBoxDsn1.Text ) );
				schedule1.Fill();
			}
			labelStatus1.Text = "Loaded schedule 1...";
			schedule1.SyncOnNextCommit = true;

		}

		private void buttonCreateSchedule2_Click( object sender, EventArgs e )
		{
			labelStatus2.Text = "Creating schedule 2...";
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
#if ELTANIN_SUPPORT
				EltaninObject.ScheduleDataSetLoader.StoreLegacySchedule( textBoxLegacyPath2.Text, schedule1 );
#endif
			}
			else
			{
				schedule2.SyncOnNextCommit = true;
				schedule2.Commit();
			}
		}

		private void buttonConvert_Click( object sender, EventArgs e )
		{
			OpenSkieScheduler3.ScheduleDataSet.ConvertSchedule( schedule2, schedule1 );
		}

		private void checkBoxLegacySchedule1_CheckedChanged( object sender, EventArgs e )
		{
			if( checkBoxLegacySchedule1.Checked )
			{
				String lastrun = Options.Default[Options.ProgramName]["lastrun/schedule"].Value;
				if( lastrun == null || lastrun.Length == 0 )
				{

					String Drive = INI.Legacy( null )["Data Files"]["Schedule Drive", "F"].Value;
					String Path = INI.Legacy( null )["Data Files"]["Schedule Path", "/ftn3000/data/schedule"].Value;
					String SchedulePath;
					if( Drive.Length > 0 )
						SchedulePath = Drive + ":" + Path;
					else
						SchedulePath = Path;
					textBoxLegacyPath1.Text = SchedulePath;
					textBoxBingoINI.Text = "f:\\ftn3000\\working\\bingo.ini";
					textBoxFtnSysINI.Text = "f:\\ftn3000\\working\\ftnsys.ini";
				}
				else
				{
					textBoxLegacyPath1.Text = lastrun;
					lastrun = Options.Default[Options.ProgramName]["lastrun/bingo.ini"].Value;
					textBoxBingoINI.Text = lastrun;
					lastrun = Options.Default[Options.ProgramName]["lastrun/ftnsys.ini"].Value;
					textBoxFtnSysINI.Text = lastrun;
			
				}
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

		private void buttonLoadSchedule2_Click( object sender, EventArgs e )
		{
			labelStatus2.Text = "Loading schedule 2...";
			schedule2.Fill();
			labelStatus2.Text = "Loaded schedule 2...";
		}

		private void buttonMergePatterns_Click( object sender, EventArgs e )
		{
			ScheduleDataSet.MergePatterns( schedule2, schedule1 );
		}

		private void buttonDropSchedule1_Click( object sender, EventArgs e )
		{
			schedule1.Drop();
			schedule1.Create();
		}


	}
}
