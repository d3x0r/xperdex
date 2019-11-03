using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using xperdex.classes;

namespace PrizeScheduleEditor
{
	public partial class SessionPackEditor : Form
	{
		public SessionPackEditor()
		{
			InitializeComponent();
		}

		private void SessionPackEditor_Load( object sender, EventArgs e )
		{
			comboBox1.DataSource = Local.schedule.sessions;
			comboBox1.DisplayMember = xperdex.classes.MySQLDataTable.Name( Local.schedule.sessions );
			//comboBox1.ValueMember
			listBox2.DataSource = Local.schedule.current_session_packs;
			listBox2.DisplayMember = MySQLDataTable.Name( Local.schedule.current_session_packs );

			listBox1.DataSource = Local.schedule.packs;
			listBox1.DisplayMember = MySQLDataTable.Name( Local.schedule.packs );
		}

		private void comboBox1_SelectedIndexChanged( object sender, EventArgs e )
		{
			Local.schedule.SetCurrentSession( (comboBox1.SelectedItem as DataRowView).Row );
		}

		private void button1_Click( object sender, EventArgs e )
		{
			Local.schedule.packs.NewPack();
		}

		private void listBox1_MouseDoubleClick( object sender, MouseEventArgs e )
		{
			DataRowView rowview = listBox1.SelectedItem as DataRowView;
			DataRow row = rowview.Row;
			Local.schedule.current_session_packs.AddPack( row );
		}
	}
}