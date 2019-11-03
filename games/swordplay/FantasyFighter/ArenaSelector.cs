using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FantasyFighter
{
	public partial class ArenaSelector : Form
	{
		ClientPort client;



		public ArenaSelector( ClientPort client )
		{
			this.client = client;
			InitializeComponent();
		}

		Timer timer;

		private void ArenaSelector_Load( object sender, EventArgs e )
		{
			listBox1.DataSource = client.ArenaTable;
			listBox1.DisplayMember = "name";
			client.GetArenaList();
			timer = new Timer();
			timer.Interval = 500;
			timer.Tick += new EventHandler( timer_Tick );
			timer.Start();
		}

		void timer_Tick( object sender, EventArgs e )
		{
			if( listBox1.Items.Count != client.ArenaTable.Rows.Count )
			{
				listBox1.DataSource = null;
				listBox1.DataSource = client.ArenaTable;
				listBox1.DisplayMember = "name";
				listBox1.Refresh();
			}
		}

		private void button1_Click( object sender, EventArgs e )
		{
		    String s = xperdex.classes.QueryNewName.Show( "Enter new arena name" );
			client.CreateArena( s );
		}

		private void button2_Click( object sender, EventArgs e )
		{
			DataRowView drv = listBox1.SelectedItem as DataRowView;
			if( drv != null )
			{
				client.JoinArena( drv.Row["name"].ToString() );
			}
		}

		private void button3_Click( object sender, EventArgs e )
		{
			Close();
		}
	}
}
