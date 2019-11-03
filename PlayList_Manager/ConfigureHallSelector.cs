using System;
using System.Collections.Generic;
//using System.ComponentModel;
using System.Data;
//using System.Drawing;
//using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PlayList_Manager
{
	public partial class ConfigureHallSelector : Form
	{
		HallSelector editing;
		public ConfigureHallSelector( HallSelector button )
		{
			editing = button;
			InitializeComponent();
		}

		private void ConfigureHallSelector_Load( object sender, EventArgs e )
		{
			comboBox1.DataSource = Local.FileSets;
			comboBox1.DisplayMember = "Name";
			comboBox1.SelectedItem = editing.fileset;
		}
	}
}
