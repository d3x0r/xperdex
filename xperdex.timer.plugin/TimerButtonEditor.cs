using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace xperdex.timer.plugin
{
	internal partial class TimerButtonEditor : Form
	{
		TimerControlButton edit_button;
		public TimerButtonEditor( TimerControlButton button )
		{
			edit_button = button;
			InitializeComponent();
		}

		private void TimerButtonEditor_Load( object sender, EventArgs e )
		{
			textBoxTimerValHours.Text = edit_button.hours.ToString();
			textBoxTimerValMinutes.Text = edit_button.minutes.ToString();
			textBoxTimerValSeconds.Text = edit_button.seconds.ToString();
			checkBox2.Checked = edit_button.add;
			checkBox3.Checked = edit_button.reset_timer;
		}

		private void button2_Click( object sender, EventArgs e )
		{
			textBoxTimerValHours.Text = edit_button.hours.ToString();
			textBoxTimerValMinutes.Text = edit_button.minutes.ToString();
			textBoxTimerValSeconds.Text = edit_button.seconds.ToString();
			checkBox2.Checked = edit_button.add;
			checkBox3.Checked = edit_button.reset_timer;

		}

		private void button1_Click( object sender, EventArgs e )
		{
			edit_button.hours = Convert.ToInt32( textBoxTimerValHours.Text );
			edit_button.minutes = Convert.ToInt32( textBoxTimerValMinutes.Text );
			edit_button.seconds = Convert.ToInt32( textBoxTimerValSeconds.Text );
			edit_button.add = checkBox2.Checked;
			edit_button.reset_timer = checkBox3.Checked;
			Close();
		}
	}
}
