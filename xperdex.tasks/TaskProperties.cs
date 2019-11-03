using System;
using System.Windows.Forms;
using xperdex.core.interfaces;

namespace xperdex.tasks
{
	internal partial class TaskProperties: Form
	{
		TaskItem _task;
		Control control;

		public TaskProperties( TaskItem task 
			 , Control c)
		{

			control = c;
			_task = task;
			InitializeComponent();
			
		}
		public TaskProperties( TaskItem task )
		{

			control = null;
			_task = task;
			InitializeComponent();
		}

		private void label1_Click( object sender, EventArgs e )
		{

		}

		private void BaseProperties_Click( object sender, EventArgs e )
		{
			if( control != null )
				( (IReflectorPersistance)control ).Properties();
			//base.Properties();
		}

		internal void Apply()
		{
			// copy all the dialog values into the TaskItem
			_task.Name = textBoxName.Text;
			control.Text = textBoxName.Text;
			_task.ProgramName = textBoxProgram.Text;
			_task.Arguments = textBoxArguments.Text;
			_task.exclusive = checkBoxExclusive.Checked;
			_task.run_once = checkBoxRunOnce.Checked;
			_task.restart = checkBoxRestart.Checked;
			_task.WorkingPath = textBoxWorking.Text;
			_task.run_remote = checkBoxRemote.Checked;
		}

		private void TaskProperties_Load( object sender, EventArgs e )
		{
			BaseProperties.Visible = false;
			textBoxName.Text = _task.Name;
			textBoxProgram.Text = _task.ProgramName;
			textBoxWorking.Text = _task.WorkingPath;
			textBoxArguments.Text = _task.Arguments;
			checkBoxExclusive.Checked = _task.exclusive;
			checkBoxRunOnce.Checked = _task.run_once;
			checkBoxRestart.Checked = _task.restart;
			checkBoxRemote.Checked = _task.run_remote;
			tabTaskProp.SelectTab( tabPageTaskProp );
			//tabTaskProp.
			//tabPageTaskProp.Show();
		}

		private void button3_Click( object sender, EventArgs e )
		{
			OpenFileDialog openFileDialog1 = new OpenFileDialog();
			openFileDialog1.Filter = "Program Files|*.exe;*.bat;*.cmd;*.ps|All Files|*.*";

			openFileDialog1.Title = "Select a program File"; if( openFileDialog1.ShowDialog() == DialogResult.OK )
			{
				textBoxProgram.Text = openFileDialog1.FileName;
			}
		}
	}
}