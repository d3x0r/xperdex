using System;
using System.Data;
using System.Windows.Forms;
using OpenSkieScheduler3;

namespace BingoGameCore4
{
	public partial class SessionSelector : Form
	{
		OpenSkieScheduler3.ScheduleDataSet schedule;
		public SessionSelector( OpenSkieScheduler3.ScheduleDataSet schedule )
		{
			this.schedule = schedule;
			InitializeComponent();
			listBox1.SelectedIndexChanged += new EventHandler( listBox1_SelectedIndexChanged );
			this.AcceptButton = button1;
			button1.Click += new EventHandler( button1_Click );
		}

		void button1_Click( object sender, EventArgs e )
		{
			this.Close();
            DialogResult = DialogResult.OK;
		}

		void listBox1_SelectedIndexChanged( object sender, EventArgs e )
		{
            if( listBox1.SelectedItem != null )
    			session_row = (listBox1.SelectedItem as DataRowView).Row;
		}

		DataRow session_row;

		private void SessionSelector_Load( object sender, EventArgs e )
		{
			listBox1.DataSource = schedule.sessions;
			listBox1.DisplayMember = SessionTable.NameColumn;

		}

		public DataRow Session
		{
			get
			{
				return session_row;
			}
		}
	}
}