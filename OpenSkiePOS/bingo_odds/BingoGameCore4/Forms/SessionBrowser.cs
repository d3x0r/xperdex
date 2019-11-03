using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Threading;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using OpenSkieScheduler3;

namespace BingoGameCore4.Forms
{
	public partial class SessionBrowser : Form
	{
		BingoSessionEvent session_event;
		public SessionBrowser( BingoSessionEvent session )
		{
			this.session_event = session;
			InitializeComponent();
		}

		BingoSession session;
		public SessionBrowser( ScheduleDataSet schedule,  BingoSessionEvent session ) //DataRow dataRow_BingoGame )
		{
			this.session = session.session;
			this.session_event = session;
			InitializeComponent();
		}


		
		private void SessionBrowser_Load( object sender, EventArgs e )
		{
			int[] points = new int[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0};
			dataGridViewPlayers.Columns.Add( "card", "Player ID" );
			dataGridViewPlayers.Columns.Add( "points", "points" );
			foreach( BingoPlayer player in session_event._PlayerList )
			{
				object[] row = new object[2];
				row[0] = player;
				{
					int total = 0;
					//foreach( BingoGameEvent game_event in session_event.BingoGameEvents )
					foreach( List<BingoCardState> cards in player._played_cards )
					{
						foreach( BingoCardState card in cards )
						{
							if( card.BestAway() < points.Length )
								total += points[card.BestAway()];
						}
					}
					row[1] = total;
				}
				//row[1] = player.ID;
				dataGridViewPlayers.Rows.Add( row );
			}

			dataGridViewPlayers.SelectionChanged += new EventHandler( dataGridViewPlayers_SelectionChanged );

			dataGridViewGames.EditMode = DataGridViewEditMode.EditProgrammatically;
			dataGridViewGames.RowHeadersVisible = false;
			dataGridViewGames.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			dataGridViewGames.Columns.Add( "Game", "Game" );
			dataGridViewGames.Columns[ "Game" ].Width = dataGridViewGames.Width - 73;
			dataGridViewGames.Columns.Add( "Progressive", "Progressive" );
			dataGridViewGames.Columns[ "Progressive" ].Width = 70;
			dataGridViewGames.Columns[ "Progressive" ].DefaultCellStyle.Alignment = 
				DataGridViewContentAlignment.MiddleCenter;
			dataGridViewGames.Columns.Add( "GameID", "GameID" );
			dataGridViewGames.Columns[ "GameID" ].Visible = false;

			foreach( BingoGame game in session_event.session.GameList )
			{
				string[ ] strs = game.ToString().Split( '\t' );

				dataGridViewGames.Rows.Add(
					strs[ 1 ].ToString(),
					( ( strs[ 2 ] != "" ) ? "\u2714" : "" ), // Check Mark
					game.game_ID
					);
			}
		}

		void dataGridViewPlayers_SelectionChanged( object sender, EventArgs e )
		{
			DataGridViewSelectedCellCollection cells = dataGridViewPlayers.SelectedCells;
			foreach( DataGridViewCell cell in cells )
			{
				if( cell.ColumnIndex == 0 && cell.Value != null )
				{
					BingoPlayer player = cell.Value as BingoPlayer;
					listBoxPacks.DataSource = player.played_packs;
				}
			}
		}

		private void button1_Click( object sender, EventArgs e )
		{
			//session_event
			dataGridViewGames.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			DataGridViewSelectedRowCollection rows = dataGridViewGames.SelectedRows;
			foreach( DataGridViewRow row in rows )
			{
				//BingoGame game = row.             [ 0 , 1 ] as BingoGame;

				BingoGameState s = session_event.BingoGameEvents[ Convert.ToInt32( row.Cells[ "GameID" ].Value ) ];
				//game.game_ID );
				//BingoSession.BingoSessionEvent game_event = s as BingoSession.BingoSessionEvent;
				session_event.Play( s );
				CardBrowsingForm info = new CardBrowsingForm( s );
				info.ShowDialog();
			}

		}

		private void button2_Click( object sender, EventArgs e )
		{
			this.DialogResult = DialogResult.OK;
		}
	}
}
