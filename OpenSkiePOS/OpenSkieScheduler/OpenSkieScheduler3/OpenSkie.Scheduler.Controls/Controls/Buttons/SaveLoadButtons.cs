using System;
using System.Windows.Forms;

namespace OpenSkieScheduler3.Controls.Buttons
{
	public class SaveSchedule: Button
	{
		public SaveSchedule()
		{
			InitializeComponent();
		}

		void InitializeComponent()
		{
			Click += new EventHandler( SaveSchedule_Click );
		}

		[STAThread]
		void SaveSchedule_Click( object sender, EventArgs e )
		{
			SaveFileDialog openFileDialog1 = new SaveFileDialog();

			openFileDialog1.InitialDirectory = Environment.CurrentDirectory;
			openFileDialog1.Filter = "Schedule files(*.xml)|*.xml|All files (*.*)|*.*";
			openFileDialog1.FilterIndex = 1;
			openFileDialog1.RestoreDirectory = true;
			//openFileDialog1.RestoreDirectory = true;

			if( openFileDialog1.ShowDialog() == DialogResult.OK )
			{
				try
				{
                    ControlList.schedule.WriteXML( openFileDialog1.FileName );
				}
				catch( Exception e2 )
				{
					Console.WriteLine( e2.Message );
				}
			}			
		}
	}

	public class LoadSchedule: Button
	{
		public LoadSchedule()
		{
			InitializeComponent();
		}

		void InitializeComponent()
		{
			Click += new EventHandler( SaveSchedule_Click );
		}

		void SaveSchedule_Click( object sender, EventArgs e )
		{
			OpenFileDialog openFileDialog1 = new OpenFileDialog();

			openFileDialog1.InitialDirectory = Environment.CurrentDirectory;
			openFileDialog1.Filter = "Schedule files(*.xml)|*.xml|All files (*.*)|*.*";
			openFileDialog1.FilterIndex = 1;
			openFileDialog1.RestoreDirectory = true;
			//openFileDialog1.RestoreDirectory = true;

			if( openFileDialog1.ShowDialog() == DialogResult.OK )
			{
				try
				{
                    ControlList.schedule.ReadXML( openFileDialog1.FileName );
				}
				catch( Exception e2 )
				{
					Console.WriteLine( e2.Message );
				}
			}
		}
	}

}
