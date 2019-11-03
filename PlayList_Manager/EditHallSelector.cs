using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PlayList_Manager
{
	public partial class EditHallSelector : Form
	{
		HallSelector editing;
		public EditHallSelector( HallSelector editme )
		{
			editing = editme;
			InitializeComponent();
		}

		private void EditHallSelector_Load( object sender, EventArgs e )
		{
			comboBox1.DataSource = Local.FileSets;
			comboBox1.DisplayMember = "Name";
			comboBox1.SelectedItem = editing.fileset;
		}

		private void button1_Click( object sender, EventArgs e )
		{
			DialogResult = DialogResult.OK;
			editing.fileset = (comboBox1.SelectedItem as DataRowView).Row	;
			this.Close();
		}
	}
}
