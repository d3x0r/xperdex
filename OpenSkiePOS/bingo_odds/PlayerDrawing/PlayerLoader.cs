using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using xperdex.classes;
using System.Data.Common;

namespace PlayerDrawing
{
	public partial class PlayerLoader : Form
	{
		DataTable sessions = new DataTable();
		List<PlayerDrawing.Form1.Player> players;
		public PlayerLoader( List<PlayerDrawing.Form1.Player> players )
		{
			this.players = players;
			InitializeComponent();

		}

		private void button1_Click( object sender, EventArgs e )
		{
			DateTime date = dateTimePicker1.Value;
			int session = Convert.ToInt32( ((DataRowView)listBox1.SelectedValue).Row[0] );
			DbDataReader reader = StaticDsnConnection.dsn.KindExecuteReader( "select player_id,card,concat(first_name,IF(ISNULL(middle_initial),' ',concat(' ',middle_initial)),' ',last_name) as `Player Name` from player_track join players_info using(card) where bingoday=" + DsnSQLUtil.MakeDateOnly( StaticDsnConnection.dsn, date ) + " and session=" + session.ToString() + " group by card");
			if( reader != null )
			{
				if( reader.HasRows )
				{
					while( reader.Read() )
					{
						players.Add( new Form1.Player( Convert.ToInt32( reader[0] ), reader[1] as String, reader[2] as String ) );
					}
				}
				StaticDsnConnection.dsn.EndReader( reader );
			}
			Close();
		}

		private void FillSessions()
		{
			DateTime date = dateTimePicker1.Value;
			sessions.Rows.Clear();
			//DsnSQLUtil.FillDataTable( StaticDsnConnection.dsn, sessions, "select session from player_track where bingoday=" + DsnSQLUtil.MakeDateOnly( StaticDsnConnection.dsn, date ) + " group by session", true );
			DsnSQLUtil.FillDataTable( StaticDsnConnection.dsn, sessions, "select session from player_track where sesdate=" + DsnSQLUtil.MakeDateOnly( StaticDsnConnection.dsn, date ) + " group by session", true );
			listBox1.SelectedIndex = listBox1.Items.Count - 1;
		}
		private void dateTimePicker1_ValueChanged( object sender, EventArgs e )
		{
			FillSessions();
		}

		private void PlayerLoader_Load( object sender, EventArgs e )
		{
			sessions.Columns.Add( "session", typeof( int ) );
			listBox1.DataSource = sessions;
			listBox1.DisplayMember = "session";
			FillSessions();
		}
	}
}
