using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using OpenSkieScheduler3;
using xperdex.classes;
using BingoGameCore4;

namespace AutoPlayer
{
	public partial class Form1 : Form
	{
		ScheduleDataSet schedule;
		BingoSession session;
		BingoSessionEvent session_event;
		BingoGameState game_state;
		public Form1()
		{
            //OpenSkieSchedule.PacksRelateToPrizes = true;
            //OpenSkieSchedule.UseGuid = true;
			schedule = new ScheduleDataSet( StaticDsnConnection.dsn );
			schedule.Create();
			schedule.Fill();
			InitializeComponent();
		}

		private void button1_Click( object sender, EventArgs e )
		{
			session = new BingoSession( schedule, DateTime.Now, 1 );
			session_event = new BingoSessionEvent( session, true );
			session_event.Open();
			//session_event.ReloadPlayers();
			listBox1.Items.Add( "Loaded " + session_event.PlayerList.Count + " Player" + ((session_event.PlayerList.Count==1)?"":"s") );
		}

		private void button2_Click( object sender, EventArgs e )
		{
			do
			{
				game_state = session_event.Step();
				if( game_state.valid )
				{
					session_event.PlayGame( game_state );

					foreach( wininfo win in game_state.winning_cards )
					{
						listBox1.Items.Add( win.playing_card.ToString() );
						listBox1.Refresh();
					}
				}
			}
			while( game_state.valid );
			session_event.Close();
		}

		private void button3_Click( object sender, EventArgs e )
		{
			ScheduleDesigner.ScheduleDesigner sd = new ScheduleDesigner.ScheduleDesigner( schedule );
			sd.ShowDialog();
			sd.Dispose();
		
		}

		private void button6_Click( object sender, EventArgs e )
		{
			try
			{
				session = new BingoSession( schedule, DateTime.Now, 1 );
			}
			catch
			{
				return;
			}
			session_event = new BingoSessionEvent( session, true );
			session_event.Open();
			int n;
			BingoPack[] play_packs = SelectPacks.Show( session_event );


			for( n = 0; n < 150; n++ )
			{
				BingoPlayer player;

				session_event.PlayerList.Add( player = new BingoPlayer( n.ToString( "0:00000" ) ) );

				PlayerTransaction transaction;
				player.transactions.Add( transaction = new PlayerTransaction( player, n ) );

				PlayerPack[] packs = new PlayerPack[play_packs.Length];
				int z = 0;
				foreach( BingoPack pack in play_packs )
				{
					packs[z++] = session_event.session.GameList.pack_list.GetPlayerPacks( pack.name, "Pos 1" )[0];
				}

				if( packs != null )
					foreach( PlayerPack pack in packs )
					{
						pack.player = player;
						pack.unit_number = 1001 + n;
						transaction.Add( pack );
						player.played_packs.Add( pack );
					}
				else
					MessageBox.Show( "Probably need to edit the schedule to assign new pack to a game group" );
			}

			// commit all players, their transactions and packs to the game event database.
			session_event.StorePlayers();

			listBox1.Items.Add( "Loaded " + session_event.PlayerList.Count + " Player" + ( ( session_event.PlayerList.Count == 1 ) ? "" : "s" ) );
		}

		private void Form1_Load( object sender, EventArgs e )
		{

		}

		private void button7_Click( object sender, EventArgs e )
		{
			OptionEditor editor = new OptionEditor();
			editor.ShowDialog();
		}

        private void button8_Click( object sender, EventArgs e )
        {
            new SessionPlayer().Show();
        }
	}
}
