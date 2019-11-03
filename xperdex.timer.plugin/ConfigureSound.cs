using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace xperdex.timer.plugin
{
	public partial class ConfigureSound : Form
	{
		public ConfigureSound()
		{
			InitializeComponent();
		}

		private void ConfigureSound_Load( object sender, EventArgs e )
		{
			textBox1.Text = Timer.sound_file;
		}

		private void button1_Click( object sender, EventArgs e )
		{
			Timer.sound_file = textBox1.Text;
			Close();
		}


	}
}
