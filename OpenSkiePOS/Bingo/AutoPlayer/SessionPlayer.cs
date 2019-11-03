using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using OpenSkieScheduler3;
using OpenSkie.Scheduler;
using xperdex.classes;
using BingoGameCore4;

namespace AutoPlayer
{
	public partial class SessionPlayer : Form
	{
		ScheduleDataSet schedule;
		ScheduleCurrents currents;

		DataTable pack_play_table;

		Random entropy;
        BingoSession session;
		BingoSessionEvent session_event;

		public SessionPlayer()
		{
			entropy = new Random();

			schedule = new ScheduleDataSet( StaticDsnConnection.dsn );
			schedule.Fill();
			currents = new ScheduleCurrents( schedule );
			pack_play_table = new DataTable();
			pack_play_table.Columns.Add( "Pack Name", typeof( String ) );
			pack_play_table.Columns.Add( "Min", typeof( int ) );
			pack_play_table.Columns.Add( "Max", typeof( int ) );
			pack_play_table.Columns.Add( "Avg", typeof( int ) );
			pack_play_table.Columns.Add( "percent average", typeof( int ) );
            pack_play_table.Columns.Add( "percent above average", typeof( int ) );
			InitializeComponent();
		}

		bool OverPercent( int percent )
		{
			if( entropy.Next( 100 ) >= percent )
				return true;
			return false;
		}

		private void SessionPlayer_Load( object sender, EventArgs e )
		{
			listBox1.DataSource = schedule.sessions;
			listBox1.DisplayMember = schedule.sessions.DisplayMemberName;
			listBox1.ValueMember = schedule.sessions.ValueMemberName;

			dataGridView1.DataSource = pack_play_table;
			dataGridView1.AllowUserToAddRows = false;
			dataGridView1.AllowUserToDeleteRows = false;

			foreach( DataGridViewColumn c in dataGridView1.Columns )
			{
				if( c.Name == "Pack Name" )
					continue;
				c.Width = 50;
			}
		}

        void PurchasePacks()
        {
			for( int playr = 0; playr< 50; playr++ )
			{
				PlayerTransaction transaction;
				BingoPlayer player;
				player = new BingoPlayer();
				transaction = new PlayerTransaction( player, playr );
				player.transactions.Add( transaction );
				
				foreach( DataRow row in pack_play_table.Rows )
				{
					int numplay = Convert.ToInt32( row["Avg"] );
					int percent_avg = Convert.ToInt32( row["percent average"] );
					if( OverPercent( percent_avg ) )
					{
						// not average
						if( OverPercent( Convert.ToInt32( row["percent above average"] ) ) )
						{
							numplay = numplay - ( entropy.Next( numplay - Convert.ToInt32( row["min"] ) ) + 1 );
						}
						else
						{
							// above average (less than or equal to 75% for instance)
							numplay = numplay + ( entropy.Next( Convert.ToInt32( row["max"] ) - numplay ) + 1 );
						}
					}
					if( numplay > 0 )
					{
						BingoPack pack = session.GameList.pack_list[pack_play_table.Rows.IndexOf( row )];
						for( int n = 0; n < numplay; n++ )
						{
							player.PlayPack( transaction, pack );
						}
					}
				}
				session_event.PlayerList.Add( player);
			}
			session_event.StorePlayers();
        }

		void UpdatePacks()
		{
			pack_play_table.Clear();
            foreach( BingoPack pack in session.GameList.pack_list )
            {
                DataRow newrow = pack_play_table.NewRow();
                newrow["Pack Name"] = pack.name;
                newrow["Min"] = 1;
                newrow["Max"] = 10;
                newrow["Avg"] = 4;
                newrow["Percent Above Average"] = 25;
                newrow["Percent Average"] = 50;
                pack_play_table.Rows.Add( newrow );
            }
            pack_play_table.AcceptChanges();
		}

		private void listBox1_SelectedIndexChanged( object sender, EventArgs e )
		{
			DataRowView drv = listBox1.SelectedItem as DataRowView;
			if( drv != null )
			{
				currents.SetCurrentSession( drv.Row );
                session = new BingoSession( drv.Row );
				session_event = new BingoSessionEvent( session, true );
				session_event.SaveToDatabase = true;
				session_event.Open();
				UpdatePacks();
			}
		}

		private void button1_Click( object sender, EventArgs e )
		{
			PurchasePacks();
			foreach( BingoGame game in session.GameList )
			{
				BingoGameState state = session_event.StepTo( session.GameList.IndexOf( game ) );
				session_event.PlayGame( state );
			}
		}

	}
}
