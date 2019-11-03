#define method1

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using xperdex.classes;
using Pabo.Calendar;
using OpenSkieScheduler3.Relations;
using OpenSkie.Scheduler;
using OpenSkieScheduler3.BingoGameDefs;
using xperdex.gui;

namespace OpenSkieScheduler3.Controls.Forms
{
	public partial class PayoutEditor2 : Form
	{
		/// <summary>
		/// There are one or more fixed columns at the start, this is index of first payout column
		/// </summary>
		int prize_col_start;

		/// <summary>
		/// temp workspace for prize column names
		/// </summary>
		List<DataRow> prize_levels;

		ScheduleDataSet schedule
		{
			get
			{
				return ControlList.schedule;
			}
		}
		ScheduleCurrents data
		{
			get
			{
				return ControlList.data;
			}
		}

		//SessionPrizeData prize_data;

		internal class GamePrize
		{
			internal DataRow session_game;
			internal List<DataRow> prize_level;
		}

		List<GamePrize> game_has_prize;

		DataRow session
		{
			get
			{
				return data.current_session;
			}
		}
		DataRow session_exception_set
		{
			get
			{
				return data.current_prize_data.Current;
			}
		}

		public PayoutEditor2()
		{
			//schedule = ControlList.schedule;
			//prize_data = schedule.session_prize_data;
            //data = ControlList.data;
			prize_levels = new List<DataRow>();
            //dsn = ControlList.schedule.schedule_dsn;


			game_has_prize = new List<GamePrize>();

			data.SetSessionPrizeExceptionSetCurrent += UpdatedCurrent;
			data.SetSessionCurrent += data_SetSessionCurrent;

			InitializeComponent();
		}



		private void PayoutEditor2_FormClosing( object sender, FormClosingEventArgs e )
		{
			data.SetSessionCurrent -= data_SetSessionCurrent;
			data.SetSessionPrizeExceptionSetCurrent -= UpdatedCurrent;
		}

		private void PayoutEditor_Load( object sender, EventArgs e )
		{

			radioButtonNoIncrement.Checked = true;
			dataGridView1.CellValueChanged += new DataGridViewCellEventHandler( dataGridView1_CellValueChanged );
		}

		void data_SetSessionCurrent( DataRow current )
		{
			FillPrizeGrid();
		}

		void UpdatedCurrent( DataRow row )
		{
			InitGridPrizes();
		}


		void dataGridView1_PreviewKeyDown( object sender, PreviewKeyDownEventArgs e )
		{
			if( e.KeyCode == Keys.Delete )
			{
				DataGridViewSelectedCellCollection cells =
					dataGridView1.SelectedCells;
				foreach( DataGridViewCell cell in cells )
				{
					if( cell.ColumnIndex >= prize_col_start )
						cell.Value = new Money(0);
				}
			}
		}

		bool auto_filling = false;
		void dataGridView1_CellValueChanged( object sender, DataGridViewCellEventArgs e )
		{
			Money value = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value as Money;
			DataRow session_game = dataGridView1.Rows[e.RowIndex].Cells["session_game_row"].Value as DataRow;
			if( ( session_game == null ) || ( value == null ) )
				return;
			if( radioButtonNoIncrement.Checked )
				return;
			if( auto_filling )
				return;
			auto_filling = true;

			// auto fill is for the prize increment stuff.  
#if can_auto_fill
			try
			{
				if( e.ColumnIndex == prize_col_start )
				{
					if( IsPrizeSame( session_game
						, exception_set
						, prize_levels[e.ColumnIndex - prize_col_start]
						, value ) )
					{
					}
					else
					{
						int n;
						bool ok = false;
						double compound = value;
						double scalar_value = 0.0;
						if( radioButtonPrizeMultiplier.Checked || radioButtonCompound.Checked )
						{
							ok = true;
							scalar_value = Convert.ToDouble( textBoxPrizeIncrement.Text );
							if( radioButtonCompound.Checked )
								scalar_value = ( 100 + scalar_value ) / 100;
							else if( radioButtonPrizeMultiplier.Checked )
								scalar_value = ( scalar_value ) / 100;
						}
						if( radioButtonPrizeIncrement.Checked )
						{
							ok = true;
							scalar_value = (int)( new Money( textBoxPrizeIncrement.Text ) );
						}
						for( n = 1; ( n + prize_col_start ) < dataGridView1.Columns.Count; n++ )
						{
							object cell = dataGridView1.Rows[e.RowIndex].Cells[prize_col_start+n].Value;

							if( ok 
								|| cell == null 
								//|| IsPrizeBlank( Convert.ToInt32( session_game[SessionGameGroupGameOrder.PrimaryKey] ), Convert.ToInt32( prize_levels[n] ) )
								|| Convert.ToInt32( cell ) == 0 
								)
								
							{
								
								if( radioButtonCompound.Checked )
								{
									compound = compound * scalar_value;
									dataGridView1.Rows[e.RowIndex].Cells[n + prize_col_start].Value = new Money( (int)compound );
								}
								else if( radioButtonPrizeMultiplier.Checked )
								{
									// first step is *.33 is 1.00 1.33 1.66 1.99
									//  so scalar would be *4, *6, *8
									
									dataGridView1.Rows[e.RowIndex].Cells[n + prize_col_start].Value = new Money( (int)(value * (1+n * (scalar_value)) ) );
								}
								else if( radioButtonPrizeIncrement.Checked )
									dataGridView1.Rows[e.RowIndex].Cells[n + prize_col_start].Value = new Money( (int)(value + n * scalar_value) );
								else
								{
									// no rule selected for auto prize...
									break;
								}
							}
						}
					}

				}
			}
			catch { }
#endif
			auto_filling = false;
			//throw new Exception( "The method or operation is not implemented." );
		}

		DataTable LoadPrizes( DateTime day, int session )
        {			
            bool weekend;

            DayOfWeek day_type = day.DayOfWeek;
            //PrizeSchedule prizes = new PrizeSchedule( dsn );
            int day_num = ( (int)day_type ) + 1;
            return null;
        }

		void InitGridPrizes()
		{
			dataGridView1.Columns.Clear();
			int n;


			//LoadPrizes( DateTime.Now, 1 );
			n = dataGridView1.Columns.Add( "session", "Session" );
			dataGridView1.Columns[n].ReadOnly = true;
			n = dataGridView1.Columns.Add( "game", "Game" );
			dataGridView1.Columns[n].ReadOnly = true;
			n = dataGridView1.Columns.Add( "game_number", "Number" );
			dataGridView1.Columns[n].ReadOnly = true;

			n = dataGridView1.Columns.Add( "session_game_row", "Hidden" );
			dataGridView1.Columns[n].Visible = false;

			int levels = 0;
			game_has_prize.Clear();
			prize_levels.Clear();
			prize_col_start = 0;

			foreach( DataRowView session_pack_group_view in ControlList.data.current_session_pack_groups )
			{
				DataRow session_pack_group = session_pack_group_view.Row;
				DataRow pack_group = session_pack_group.GetParentRow( "pack_group_in_session" );

				foreach( DataRow pack_group_pack in pack_group.GetChildRows( "pack_group_has_pack" ) )
				{
					DataRow pack = pack_group_pack.GetParentRow( schedule.pack_group_packs.ParentOfChild );
					foreach( DataRow prize_level in pack.GetChildRows( schedule.pack_prize_level.ChildrenOfParent ) )
					{
						levels++;
						DataRow real_row = prize_level.GetParentRow( schedule.pack_prize_level.ParentOfChild );
						if( prize_levels.Contains( real_row ) )
							continue;
						prize_levels.Add( real_row );
						DataGridViewTextBoxColumn col = new DataGridViewTextBoxColumn();
						col.Name = real_row[PrizeLevelNames.NameColumn].ToString();
						col.ValueType = typeof( Money );
						col.HeaderText = col.Name;

						int n_col = dataGridView1.Columns.Add( col );
						if( prize_col_start == 0 )
							prize_col_start = n_col;
						//dataGridView1.Columns[n_col].CellType = typeof( Money );
					}
				}
			}
			if( prize_col_start == 0 )
				prize_col_start = n;


			foreach( DataRowView session_game_view in ControlList.data.current_session_games )
			{
				DataRow session_game = session_game_view.Row;
				GamePrize game_prize_list = new GamePrize();
				game_prize_list.session_game = session_game;
				game_prize_list.prize_level = new List<DataRow>();
				game_has_prize.Add( game_prize_list );
				foreach( DataRow pack_group in session_game.GetChildRows( schedule.session_game_session_pack_group.ChildrenOfParent ) )
				{
					DataRow real_session_pack_group = pack_group.GetParentRow( schedule.session_game_session_pack_group.ParentOfChild );
					if( real_session_pack_group == null )
						continue;
					DataRow real_pack_group = real_session_pack_group.GetParentRow( schedule.session_pack_groups.ParentOfChild );
					foreach( DataRow pack_group_pack in real_pack_group.GetChildRows( schedule.pack_group_packs.ChildrenOfParent ) )
					{
						DataRow pack = pack_group_pack.GetParentRow( schedule.pack_group_packs.ParentOfChild );
						foreach( DataRow prize_level in pack.GetChildRows( schedule.pack_prize_level.ChildrenOfParent ) )
						{
							DataRow real_row = prize_level.GetParentRow( schedule.pack_prize_level.ParentOfChild );
							if( !game_prize_list.prize_level.Contains( real_row ) )
								game_prize_list.prize_level.Add( real_row );
						}
					}
				}
			}
			if( session != null )
			{
				// put the values in it.
				FillPrizeGrid();
			}
		}

		void FillPrizeGrid()
		{
			int row_id = 0;
			dataGridView1.Rows.Clear();
			object[] newrow = new object[prize_col_start + 1 + prize_levels.Count];

			bool[] game_prizes = new bool[prize_levels.Count];

			foreach( DataRowView session_game_view in ControlList.data.current_session_games )
			{
				DataRow session_game = session_game_view.Row;
				for( int p = 0; p < game_prizes.Length; p++ )
				{
					game_prizes[p] = false;
					newrow[prize_col_start + p] = null;
				}

				newrow[0] = session[SessionTable.NameColumn];
				{
					DataRow game = session_game.GetParentRow( schedule.session_games.ParentOfChild );
					DataRow[] patterns = session_game.GetChildRows( schedule.game_patterns.ChildrenOfParent );

					newrow[1] = session_game.ToString();
				}
				newrow[2] = session_game[SessionGame.NumberColumn];
				newrow[3] = session_game;

				for( int c = 0; c < prize_levels.Count; c++ )
				{
					newrow[prize_col_start + 1 + c] = null;
				}

				for( int c = 0; c < prize_levels.Count; c++ )
				{
					int valid_prize = game_has_prize[row_id].prize_level.IndexOf( prize_levels[c] );
					if( valid_prize >= 0 )
					{
						game_prizes[c] = true;
						newrow[prize_col_start + c] = schedule.session_prize_data.GetPrize( session_game
							, session_exception_set, prize_levels[c] );
					}
				}

				int new_row_id = dataGridView1.Rows.Add( newrow );

				for( int c = 0; c < prize_levels.Count; c++ )
				{
					DataGridViewCell dgvc = dataGridView1[prize_col_start + c, new_row_id];
					if( game_prizes[c] )
					{
						dgvc.ReadOnly = false;
						dgvc.Style.BackColor = Form.DefaultBackColor;
					}
					else
					{
						dgvc.Style.BackColor = Color.DarkGray;
						dgvc.ReadOnly = true;
					}
				}

				row_id++;
			}
		}


        void UpdatePrize( int session_game_id, int prize_id, Money prize )
        {
        }

		void UpdatePrizesFromGrid()
		{
			//if( day_of_week_type == -1 )
			{
				foreach( DataGridViewRow row in dataGridView1.Rows )
				{
					bool new_row = false;
					if( row.Cells["game_number"].Value == "-" )
						continue;
					int game_number = Convert.ToInt32( row.Cells["game_number"].Value );
					DataRow session_game = row.Cells["session_game_row"].Value as DataRow;
					int level;
					for( level = 0; level < prize_levels.Count; level++ )
					{

						Object _prize = row.Cells[level + prize_col_start].Value;
						if( _prize == null )
							continue;
						Money prize = _prize as Money;
						if( prize == null )
							continue;

						schedule.session_prize_data.WritePrize( session_game, session_exception_set
							, prize_levels[level]
							, prize 
							, true
							);
					}
				}

			}
			// reload with current values from database.
			FillPrizeGrid();
		}


		private void button1_Click( object sender, EventArgs e )
		{
			UpdatePrizesFromGrid();
		}

		private void button2_Click( object sender, EventArgs e )
		{
			FillPrizeGrid();
		}

		private void button3_Click( object sender, EventArgs e )
		{
			String result = xperdex.classes.QueryNewName.Show( "Enter new prize schedule name" );
			if( result.Length > 0 )
			{
				DataRow new_set = schedule.prize_exception_sets.NewPrizeException( result );
				DataRow session_prize_set = schedule.session_prize_exception_sets.AddGroupMember( session, new_set );

				foreach( DataRowView current_prize_view in data.current_prize_data )
				{
					DataRow current_prize = current_prize_view.Row;
					schedule.session_prize_data.DuplicatePrize( current_prize, new_set );
				}
				sessionPrizeExceptionList1.SelectedItem = new_set;
			}

		}

		private void button4_Click( object sender, EventArgs e )
		{
			if( session_exception_set.ToString() == "Default" )
			{
				Banner.Show( "Cannot remove 'Default' prize set" );
				return;
			}
			schedule.session_prize_exception_sets.RemoveGroupMember( session, session_exception_set );
		}

		public void EnableSessionMacroSessionList()
		{
			this.sessionList1.DataSource = ControlList.data.current_session_macro_sessions;
		}

		public void HideSessionExceptions()
		{
			this.button3.Visible = false;
			this.button4.Visible = false;
		}

	}
}