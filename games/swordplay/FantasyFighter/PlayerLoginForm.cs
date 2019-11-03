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
	public partial class PlayerLoginForm : Form
	{
		PlayerTracker player;
		internal PlayerLoginForm( PlayerTracker player )
		{
			this.player = player;
			InitializeComponent();
		}

		private void button1_Click( object sender, EventArgs e )
		{
			player.client = new ClientPort( player );
			player.client.Start();
		}

		private void buttonLogin_Click( object sender, EventArgs e )
		{
			player.client.Login( textBoxUserName.Text );

			player.Wait();
			if( player.arena != null )
			{
				ArenaSelector pick_arena = new ArenaSelector( player );
				pick_arena.Show();
			}
			else
			{
				MessageBox.Show( "Login timed out." );
			}
		}
	}
}
