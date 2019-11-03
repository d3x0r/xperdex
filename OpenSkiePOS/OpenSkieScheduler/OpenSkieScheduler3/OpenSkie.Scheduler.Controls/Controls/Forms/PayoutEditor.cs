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
using OpenSkieScheduler.Relations;

namespace OpenSkieScheduler.Controls.Forms
{
	public partial class PayoutEditor : Form
	{
		DsnConnection dsn;

		XDataTable session_macros;
		XDataTable sessions;
		XDataTable game_groups;

		MySQLDataTable prize_data;

		bool day_of_week;
		bool is_weekend;
		bool is_weekday;
		bool is_specific;

		int day_of_week_type;
		DayOfWeek dow_specific;

		DateTime date;

		int advanced_offset;

		DataRow session_macro;
		DataRow session_macro_session;
		DataRow session;
		DataRow game_group;
		int prize_col_start;
		List<object> prize_levels;

		ScheduleDataSet schedule;

		public PayoutEditor()
		{
			schedule = ControlList.data;
			prize_levels = new List<object>();
			dsn = ControlList.data.schedule_dsn;
			InitializeComponent();
		}

		private void PayoutEditor_Load( object sender, EventArgs e )
		{
			// select default...
			radioButton1.Checked = true;
			day_of_week_type = -1;

			{
				advanced_offset = this.Width - groupBox1.Location.X;

				Size tmp = this.Size;
				tmp.Width = groupBox1.Location.X;
				groupBox1.Location = new Point( groupBox1.Location.X + advanced_offset, groupBox1.Location.Y );
				dataGridView1.Size = new Size( dataGridView1.Size.Width + advanced_offset, dataGridView1.Size.Height );
				dataGridView1.KeyPress += new KeyPressEventHandler( dataGridView1_KeyPress );
				dataGridView1.PreviewKeyDown += new PreviewKeyDownEventHandler( dataGridView1_PreviewKeyDown );
				//tmp.Width -= 982 - 562;
				this.Size = tmp;

			}

			checkBoxAdvancedOptions.Checked = false;
			//monthCalendar1.SelectionMode = mcSelectionMode.One;
			sessions = new SessionTable();
			sessions.Columns.Add( "original_row", typeof( DataRow ) );
			sessions.Columns.Add( "original_relation_row", typeof( DataRow ) );
			sessions.Columns[SessionTable.NameColumn].Unique = false;
			sessions.Columns.Add( "session_macro_session_name", typeof( String ) );

			session_macros = new SessionMacroTable();
			session_macros.Columns.Add( "original_row", typeof( DataRow ) );
			session_macros.Columns[SessionMacroTable.NameColumn].Unique = false;

			game_groups = new GameGroupTable();
			game_groups.Columns.Add( "original_row", typeof( DataRow ) );
			game_groups.Columns[GameGroupTable.NameColumn].Unique = false;

			listBox3.DataSource = session_macros;
			listBox3.DisplayMember = SessionMacroTable.NameColumn;
			listBox1.DataSource = sessions;
			listBox1.DisplayMember = SessionTable.NameColumn;
			listBox2.DataSource = game_groups;
			listBox2.DisplayMember = GameGroupTable.NameColumn;

			foreach( DataRow row in ControlList.data.session_macros.Rows )
			{
				DataRow newrow = session_macros.AddClonedRow( row, true );
                newrow["original_row"] = row;

			}

			radioButtonNoIncrement.Checked = true;
			dataGridView1.CellValueChanged += new DataGridViewCellEventHandler( dataGridView1_CellValueChanged );
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

		void dataGridView1_KeyPress( object sender, KeyPressEventArgs e )
		{
			//throw new NotImplementedException();
		}

		bool auto_filling = false;
		void dataGridView1_CellValueChanged( object sender, DataGridViewCellEventArgs e )
		{
			Money value = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value as Money;
			DataRow session_game_group_game = dataGridView1.Rows[e.RowIndex].Cells["session_game_group_game_row"].Value as DataRow;
			if( ( session_game_group_game == null ) || ( value == null ) )
				return;
			if( radioButtonNoIncrement.Checked )
				return;
			if( auto_filling )
				return;
			auto_filling = true;
			try
			{
				if( e.ColumnIndex == prize_col_start )
				{
					if( IsPrizeSame( session_game_group_game[SessionGameGroupGameOrder.PrimaryKey]
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
								//|| IsPrizeBlank( Convert.ToInt32( session_game_group_game[SessionGameGroupGameOrder.PrimaryKey] ), Convert.ToInt32( prize_levels[n] ) )
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
			auto_filling = false;
			//throw new Exception( "The method or operation is not implemented." );
		}

		private void monthCalendar1_DayDeselected( object sender, Pabo.Calendar.DaySelectedEventArgs e )
		{
			DateTime date = Convert.ToDateTime( e.Days[0] );
			DataRow session_macro = ControlList.data.session_macro_schedule.GetMacroScheduleRow( date );
			if( session_macro == null )
			{
				MessageBox.Show( "No sessions on that day." );
			}

			this.sessions.Rows.Clear();
			DataRow[] sessions = session_macro.GetChildRows( "session_macro_has_session" );
			foreach( DataRow session_macro_row in sessions )
			{
				DataRow session = session_macro_row.GetParentRow( "session_in_session_macro" );
				DataRow newrow = this.sessions.AddClonedRow( session, true );
				newrow["original_row"] = session_macro_row;
			}
			this.sessions.AcceptChanges();
			//GetSessions();
		}

		private void listBox1_SelectedIndexChanged( object sender, EventArgs e )
		{
			//ControlList.data.SetCurrentSession( ( listBox1.SelectedItem as DataRowView ).Row );
			if( listBox1.SelectedItem != null )
			{
				DataRow session = ( listBox1.SelectedItem as DataRowView ).Row;
				DataRow original = session["original_row"] as DataRow;
				if( original == null )
					return;
				this.session = original;
				this.session_macro_session = session["original_relation_row"] as DataRow;
				DataRow[] rows = original.GetChildRows( "session_has_game_group" );
				game_groups.Rows.Clear();
				foreach( DataRow row in rows )
				{
					DataRow group = row.GetParentRow( "game_group_in_session" );
					DataRow newrow = game_groups.AddClonedRow( group, true );
					newrow["original_row"] = row;
				}
				game_groups.AcceptChanges();
			}
			else
				game_groups.Clear();
		}

		private void listBox2_SelectedIndexChanged( object sender, EventArgs e )
		{
			if( listBox2.SelectedItem != null )
			{
				this.game_group = ( listBox2.SelectedItem as DataRowView ).Row;
				UpdatePrizeGrid();
			}
		}

		private void checkBox2_CheckedChanged( object sender, EventArgs e )
		{
			if( checkBoxAdvancedOptions.Checked )
			{
				Size tmp = this.Size;
				//tmp.Width += 982 - 562;
				tmp.Width = this.Width + advanced_offset;
				groupBox1.Location = new Point( groupBox1.Location.X - ( advanced_offset ), groupBox1.Location.Y );
				dataGridView1.Size = new Size( dataGridView1.Size.Width - advanced_offset, dataGridView1.Size.Height );
				this.Size = tmp;
			}
			else
			{
				int del;
				Size tmp = this.Size;

				is_specific = false;
				is_weekday = false;
				is_weekend = false;
				day_of_week_type = 0;
				radioButton1.Checked = true;

				tmp.Width = groupBox1.Location.X;
				groupBox1.Location = new Point( groupBox1.Location.X + advanced_offset, groupBox1.Location.Y );
				dataGridView1.Size = new Size( dataGridView1.Size.Width + advanced_offset, dataGridView1.Size.Height );
				//tmp.Width -= 982 - 562;
				this.Size = tmp;
			}
			UpdatePrizeGrid();
		}

		private void radioButton11_CheckedChanged( object sender, EventArgs e )
		{
			if( radioButton11.Checked )
			{
				is_weekend = false;
				is_weekday = false;
				day_of_week = false;

				is_specific = true;
				date = PayoutDateSelector.SelectDate();
				day_of_week_type = 10;
				label4.Text = date.ToString( "MMM dd, yyyy" );
				//MessageBox.Show( "Popup a calendar to select..." );

			}
		}

		DataTable LoadPrizes( DateTime day, int session )
        {
            bool weekend;

            DayOfWeek day_type = day.DayOfWeek;
            PrizeSchedule prizes = new PrizeSchedule( dsn );
            int day_num = ( (int)day_type ) + 1;
            if( day_type == DayOfWeek.Saturday || day_type == DayOfWeek.Sunday )
            {
                weekend = true;
            }
            else
                weekend = false;




            DataTable _prize_data = new MySQLDataTable( dsn, "select a.amount,b.amount,d.new_amount,e.new_amount,f.new_amount,g.new_amount,g.new_amount,i.new_amount,if(isnull(i.new_amount),if(isnull(g.new_amount),if(isnull(h.new_amount),if(isnull(b.amount),if(isnull(f.new_amount),if(isnull(d.new_amount),if(isnull(e.new_amount)  ,a.amount,e.new_amount)  ,d.new_amount)  ,f.new_amount)  ,b.amount)  ,h.new_amount)  ,g.new_amount)  ,i.new_amount) as amount,game_number,a.prize_level_id,a.session_macro_id,a.session_number,a.session_game_group_game_id,a.prize_schedule_id"

            + " from " + Names.schedule_prefix + "prize_schedule as a "

            + " left join " + Names.schedule_prefix + "prize_schedule_override as d on a.prize_schedule_id=d.prize_schedule_id and d.day_of_week=10 and d.specific_date=" + MySQLDataTable.MakeDateOnly( day )
            + ( weekend ? " left join " + Names.schedule_prefix + "prize_schedule_override as e on a.prize_schedule_id=e.prize_schedule_id and e.day_of_week=9"
                     : " left join " + Names.schedule_prefix + "prize_schedule_override as e on a.prize_schedule_id=e.prize_schedule_id and e.day_of_week=8" )
            + " left join " + Names.schedule_prefix + "prize_schedule_override as f on a.prize_schedule_id=f.prize_schedule_id and f.day_of_week=" + day_num

            // now join the session-specific overrides...
            + " left join " + Names.schedule_prefix + "prize_schedule as b on a.session_macro_id=b.session_macro_id and a.session_game_group_game_id=b.session_game_group_game_id and b.session_number=" + session + " and a.prize_level_id=b.prize_level_id"
            + " left join " + Names.schedule_prefix + "prize_schedule_override as g on b.prize_schedule_id=g.prize_schedule_id and g.day_of_week=10 and g.specific_date=" + MySQLDataTable.MakeDateOnly( day )
            + ( weekend ? " left join " + Names.schedule_prefix + "prize_schedule_override as h on b.prize_schedule_id=e.prize_schedule_id and h.day_of_week=9"
                     : " left join " + Names.schedule_prefix + "prize_schedule_override as h on b.prize_schedule_id=h.prize_schedule_id and h.day_of_week=8" )
            + " left join " + Names.schedule_prefix + "prize_schedule_override as i on a.prize_schedule_id=i.prize_schedule_id and i.day_of_week=" + day_num


            // finall, grab the session game group info.

            + " join " + Names.schedule_prefix + "session_game_group_game on (" + Names.schedule_prefix + "session_game_group_game.session_game_group_game_id=a.session_game_group_game_id)"
            + " where " + Names.schedule_prefix + "session_game_group_game.session_id=a.session_id and a.session_macro_id='" + session_macro[SessionMacroTable.PrimaryKey] +"'"
            + " and a.session_number=0"
            + " order by " + Names.schedule_prefix + "session_game_group_game.game_number"
            );
            return _prize_data;
        }

		void UpdatePrizeGrid()
		{
			dataGridView1.Columns.Clear();
			int n;
			int prior_game_number = 0;
			LoadPrizes( DateTime.Now, 1 );
			n = dataGridView1.Columns.Add( "session", "Session" );
			dataGridView1.Columns[n].ReadOnly = true;
			n = dataGridView1.Columns.Add( "game group", "Game Group" );
			dataGridView1.Columns[n].ReadOnly = true;
			n = dataGridView1.Columns.Add( "game", "Game" );
			dataGridView1.Columns[n].ReadOnly = true;
			n = dataGridView1.Columns.Add( "game_number", "Number" );
			dataGridView1.Columns[n].ReadOnly = true;

			n = dataGridView1.Columns.Add( "session_game_group_game_row", "Hidden" );
			dataGridView1.Columns[n].Visible = false;

			DataRow real_session_game_group = game_group["original_row"] as DataRow;
			DataRow real_game_group = real_session_game_group.GetParentRow( "game_group_in_session" );
			DataRow[] prizes = real_game_group.GetChildRows( "game_group_has_prize_level" );
			int levels = 0;
			prize_levels.Clear();
			prize_col_start = 0;
			foreach( DataRow prize in prizes )
			{
				levels++;
				DataRow real_row = prize.GetParentRow( "prize_level_in_game_group" );
				prize_levels.Add( real_row[PrizeLevelNames.PrimaryKey] );
				DataGridViewTextBoxColumn col = new DataGridViewTextBoxColumn();
				col.Name = real_row[PrizeLevelNames.NameColumn].ToString();
				col.ValueType = typeof( Money );
				col.HeaderText = col.Name;

				int n_col = dataGridView1.Columns.Add( col );
				if( prize_col_start == 0 )
					prize_col_start = n_col;
				//dataGridView1.Columns[n_col].CellType = typeof( Money );
			}

			if( session == null )
				return;
			if( session_macro == null )
				return;
			if( game_group == null )
				return;


			DataRow original = this.game_group["original_row"] as DataRow;
			DataRow this_game_group = original;

			DataRow[] rows = ControlList.data.session_game_group_game_order
				.Select( SessionTable.PrimaryKey + "='" + session[SessionTable.PrimaryKey] + "' and " + GameGroupTable.PrimaryKey + "='" + this_game_group[GameGroupTable.PrimaryKey] + "'" );
			dataGridView1.Rows.Clear();
			foreach( DataRow row in rows )
			{
				int game_number = Convert.ToInt32( row[SessionGameGroupGameOrder.NumberColumn] );
				DataRow tmp_game = row.GetParentRow( "session_game_group_game_meta_game_info" );
				DataRow tmp_game_group = row.GetParentRow( "session_game_group_game_meta_game_group_info" );
				DataRow tmp_session = row.GetParentRow( "session_game_group_game_meta_session_info" );

				object[] o = new object[] { tmp_session[SessionTable.NameColumn]
					, tmp_game_group[GameGroupTable.NameColumn]
					, tmp_game[GameTable.NameColumn]
					, row[SessionGameGroupGameOrder.NumberColumn]
					, row
				};

				if( prior_game_number != ( game_number - 1 ) )
				{
					for( int x = prior_game_number; x < (game_number-1); x++ )
					{
						object[] o_blank = new object[] { "Game", "not in", "this group", "-" };
						dataGridView1.Rows.Add( o_blank );
					}
				}
				prior_game_number = game_number;
				dataGridView1.Rows.Add( o );
			}

			// checking for specific session (and specific day)
			if( checkBox1.Checked )
			{
				prize_data = new MySQLDataTable( dsn, "select if(isnull(d.new_amount),if(isnull(b.amount),if(isnull(c.new_amount),a.amount,c.new_amount),b.amount),d.new_amount) as amount,game_number,a.prize_level_id,a.session_macro_id,a.session_number,a.session_game_group_game_id,a.prize_schedule_id,d.new_amount as day_session_prize,c.new_amount as day_prize,b.amount as session_prize,a.amount as default_prize"
					+ " from " + Names.schedule_prefix + "prize_schedule as a "
					+ " left join " + Names.schedule_prefix + "prize_schedule_override as c on a.prize_schedule_id=c.prize_schedule_id and c.day_of_week=" + day_of_week_type
						+ ( ( day_of_week_type == 10 ) ? " and c.specific_day=" + MySQLDataTable.MakeDateOnly( date ) : "" )
					+ " left join " + Names.schedule_prefix + "prize_schedule as b on a.session_macro_id=b.session_macro_id and a.session_game_group_game_id=b.session_game_group_game_id and b.session_number=" + session_macro_session["session_number"] + " and a.prize_level_id=b.prize_level_id"
					+ " left join " + Names.schedule_prefix + "prize_schedule_override as d on b.prize_schedule_id=d.prize_schedule_id and d.day_of_week=" + day_of_week_type
						+ ( ( day_of_week_type == 10 ) ? " and d.specific_day=" + MySQLDataTable.MakeDateOnly( date ) : "" )
					+ " join " + Names.schedule_prefix + "session_game_group_game on (" + Names.schedule_prefix + "session_game_group_game.session_game_group_game_id=a.session_game_group_game_id)"
					+ " where " + Names.schedule_prefix + "session_game_group_game.session_id=" + session[SessionTable.PrimaryKey]
					+ " and a.session_macro_id=" + session_macro[SessionMacroTable.PrimaryKey]
					+ " and a.session_number=0"
					);
			}
			else
			{
				// checking for default session, and maybe specific day.
				prize_data = new MySQLDataTable( dsn, "select if(isnull(new_amount),amount,new_amount)as amount,game_number,prize_level_id,session_macro_id,session_number,session_game_group_game_id,"+Names.schedule_prefix+"prize_schedule.prize_schedule_id,new_amount as day_prize"
					+ " from " + Names.schedule_prefix + "prize_schedule "
					+ " left join " + Names.schedule_prefix + "prize_schedule_override on " + Names.schedule_prefix + "prize_schedule.prize_schedule_id=" + Names.schedule_prefix + "prize_schedule_override.prize_schedule_id and " + Names.schedule_prefix + "prize_schedule_override.day_of_week=" + day_of_week_type
					+ ( ( day_of_week_type == 10 ) ? " and specific_day=" + MySQLDataTable.MakeDateOnly( date ) : "" )
					+ " join " + Names.schedule_prefix + "session_game_group_game using(session_game_group_game_id)"
					+ " where " + Names.schedule_prefix + "session_game_group_game.session_id='" + session[SessionTable.PrimaryKey]
					+ "' and " + Names.schedule_prefix + "prize_schedule.session_macro_id='" + session_macro[SessionMacroTable.PrimaryKey]
					+ "' and session_number=0" 

					);
			}
			foreach( DataRow row in prize_data.Rows )
			{
				int number = Convert.ToInt32( row["game_number"] );
				foreach( DataGridViewRow row2 in dataGridView1.Rows )
				{
					if( row2.Cells["game_number"].Value == "-" )
						continue;
					if( Convert.ToInt32( row2.Cells["game_number"].Value ) == number )
					{
						int col = 0;
						foreach( object prize_id in prize_levels )
						{
							Log.log( "This uses a fixed auto key type, and is not based on the tables... this whole thing still needs to be dataset wrapped." );
							if( DsnSQLUtil.Compare( XDataTable.DefaultAutoKeyType, row["prize_level_id"], prize_id ) )
							{
								row2.Cells[prize_col_start + col].Value = new Money( Convert.ToInt64( row["amount"] ) );
								break;
							}
							col++;
						}
						break;
					}
				}
				//dataGridView1.Rows[Convert.ToInt32( row["game_number"] )-1].
			}
		}


		bool IsPrizeSame( object session_game_group_game_id
			, object prize_id
			, long prize )
		{
			// prize_data is a reflection of what the current values being displayed are.
			if( prize_data.Rows.Count > 0 )
			{
				DataRow[] rows = prize_data.Select( "prize_level_id='" + prize_id 
					+ "' and session_game_group_game_id='" + session_game_group_game_id +"'" 
				);
				if( rows.Length > 0 )
				{
					if( rows.Length > 1 )
						Log.log( "damnit." );
					if( Convert.ToInt64( rows[0]["amount"] ) == prize )
						return true;
				}
			}
			return false;
		}

		bool IsPrizeBlank( int session_game_group_game_id, int prize_id )
		{
			// prize_data is a reflection of what the current values being displayed are.
			if( prize_data.Rows.Count > 0 )
			{
                DataRow[] rows = schedule.prize_schedule.Select( "prize_level_id=" + prize_id
					+ " and session_game_group_game_id=" + session_game_group_game_id
				);
				if( rows.Length > 0 )
				{
					if( rows.Length > 1 )
						Log.log( "damnit." );
					if( Convert.ToInt32( rows[0]["amount"] ) == 0 )
						return true;
					return false;
				}
			}
			return true;
		}

        void UpdatePrize( int session_game_group_game_id, int prize_id, Money prize )
        {
            //if( schedule.prize_schedule.Rows.Count == 0 )
            {
                DataRow addrow = schedule.prize_schedule.NewRow();
                DataRow add_date_row = schedule.prize_schedule_override.NewRow();
                addrow[PrizeLevelNames.PrimaryKey] = prize_id;
                addrow[SessionGameGroupGameOrder.PrimaryKey] = session_game_group_game_id;
                // is checked for specific session...
                addrow[SessionMacroTable.PrimaryKey] = session_macro[SessionMacroTable.PrimaryKey];
                addrow[SessionTable.PrimaryKey] = session[SessionTable.PrimaryKey];

                addrow["amount"] = prize;

                {
                    DataRow[] default_rows = schedule.prize_schedule.Select( PrizeLevelNames.PrimaryKey + "=" + prize_id
                                    + " and " + SessionGameGroupGameOrder.PrimaryKey + "=" + session_game_group_game_id
                                    + " and " + SessionTable.PrimaryKey + "=" + session[SessionTable.PrimaryKey]
                                    + " and " + SessionMacroTable.PrimaryKey + "=" + session_macro[SessionMacroTable.PrimaryKey]
                                    , "session_number asc"
                                    );
                    if( default_rows.Length == 0 )
                    {
                        addrow[SessionDayMacroSessionTable.NumberColumn] = 0;
                        schedule.prize_schedule.Rows.Add( addrow );
                        add_date_row.Delete();
                        return;
                    }
                    else
                    {
                        int find_session;
                        if( checkBox1.Checked )
                        {
                            find_session = Convert.ToInt32( session_macro_session[SessionDayMacroSessionTable.NumberColumn] );
                        }
                        else
                        {
                            find_session = 0;
                        }
                        Money default_prize = new Money(0);
                        foreach( DataRow row in default_rows )
                        {
                            int rows_session = Convert.ToInt32( row[SessionDayMacroSessionTable.NumberColumn] );
                            if( rows_session != find_session )
                            {
                                if( rows_session == 0 )
                                {
                                    default_prize = row["amount"] as Money;
                                }
                                continue;
                            }

                            if( day_of_week_type > 0 )
                            {
                                DataRow[] specifics = row.GetChildRows( schedule.prize_schedule_override.Relation );
                                foreach( DataRow specific in specifics )
                                {
                                    if( Convert.ToInt32( specific["day_of_week"] ) == day_of_week_type )
                                    {
                                        if( ( day_of_week_type == 10 ) )
                                        {
                                            if( date == Convert.ToDateTime( specific["specific_date"] ) )
                                            {
                                                specific["new_amount"] = prize;
                                                add_date_row.Delete();
                                                addrow.Delete();
                                                return;
                                            }
                                            else
                                                continue;
                                        }
                                        specific["new_amount"] = prize;
                                        add_date_row.Delete();
                                        addrow.Delete();
                                        return;
                                    }
                                }
                                add_date_row["new_amount"] = prize;
                                add_date_row[PrizeSchedule.PrimaryKey] = row[PrizeSchedule.PrimaryKey];
                                add_date_row["day_of_week"] = day_of_week_type;
                                if( day_of_week_type == 10 )
                                    add_date_row["specific_date"] = date;
                                schedule.prize_schedule_override.Rows.Add( add_date_row );
                                addrow.Delete();
                                return;
                            }
                            else
                            {
                                if( day_of_week_type == 0 )
                                {
                                    row["amount"] = prize;
                                    add_date_row.Delete();

                                    addrow.Delete();

                                    return;
                                }
                            }
                        }
                        addrow[SessionDayMacroSessionTable.NumberColumn] = find_session;
                        if( day_of_week_type > 0 )
                        {
                            addrow["amount"] = default_prize;
                            schedule.prize_schedule.Rows.Add( addrow );
                            add_date_row[PrizeSchedule.PrimaryKey] = addrow[PrizeSchedule.PrimaryKey];
                            add_date_row["day_of_week"] = day_of_week_type;
                            if( day_of_week_type == 10 )
                                add_date_row["specific_date"] = date;
                            add_date_row["new_amount"] = prize;
                            schedule.prize_schedule_override.Rows.Add( add_date_row );
                        }
                        else
                        {
                            addrow["amount"] = prize;
                            schedule.prize_schedule.Rows.Add( addrow );
                            add_date_row.Delete();
                        }

                        //if( checkBox1.Checked )
                        //    addrow[SessionDayMacroSessionTable.NumberColumn] = session_macro_session[SessionDayMacroSessionTable.NumberColumn];
                        //addrow["day_of_week"] = day_of_week_type;
                        //MySQLDataTable.DoInsertRow( dsn, addrow );
                        //schedule.prize_schedule.Rows.Add( addrow );
                    }
                }
            }
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
					DataRow session_game_group_game = row.Cells["session_game_group_game_row"].Value as DataRow;
					int level;
					for( level = 0; level < prize_levels.Count; level++ )
					{
						Money prize = row.Cells[level + prize_col_start].Value as Money;
						if( prize == null )
							continue;
						if( IsPrizeSame( Convert.ToInt32( session_game_group_game[SessionGameGroupGameOrder.PrimaryKey] ), Convert.ToInt32( prize_levels[level] ), prize ) )
							continue;
						//schedule.prize_schedule.UpdatePrize( Convert.ToInt32( session_game_group_game[SessionGameGroupGameOrder.PrimaryKey] ), Convert.ToInt32( prize_levels[level] ), prize );

						UpdatePrize( Convert.ToInt32( session_game_group_game[SessionGameGroupGameOrder.PrimaryKey] ), Convert.ToInt32( prize_levels[level] ), prize );
						continue;
#if asdfasdfasdf
						if( prize_data.Rows.Count > 0 )
						{
							DataRow[] rows = prize_data.Select( "prize_level_id=" + prize_levels[level]
								+ " and session_game_group_game_id=" + session_game_group_game[SessionGameGroupGameOrder.PrimaryKey]
								+ " and session_number=" + ( checkBox1.Checked ? session_macro_session["session_number"] : "0" )
								+ " and session_macro_id=" + session_macro_session[SessionMacroTable.PrimaryKey]
							);
							if( rows.Length == 0 )
							{
								new_row = true;
								rows = prize_data.Select( "prize_level_id=" + prize_levels[level]
									+ " and session_game_group_game_id=" + session_game_group_game[SessionGameGroupGameOrder.PrimaryKey]
									+ " and session_number=0"
									+ " and session_macro_id=" + session_macro_session[SessionMacroTable.PrimaryKey]
								);
							}
							else
							{
								if( rows.Length > 2 )
								{
									Log.log( "damnit." );
								}
								if( Convert.ToInt64( rows[0]["amount"] ) == (long)prize )
									continue;
							}
						}
						else
							new_row = true;
						if( new_row )
						{
							dsn.ExecuteNonQuery( "insert into " + Names.schedule_prefix + "prize_schedule (prize_level_id,session_game_group_game_id,session_number,session_macro_id,amount,session_id) values (" + prize_levels[level]
								+ "," + session_game_group_game[SessionGameGroupGameOrder.PrimaryKey]
								+ "," + (checkBox1.Checked?(session_macro_session[SessionDayMacroSessionTable.NumberColumn]):"0")
								+ "," + session_macro[SessionMacroTable.PrimaryKey]
								+ "," + (int)( prize )
								+ "," + session[SessionTable.PrimaryKey]
								+ ")"
								);
						}
						else
						{
							dsn.ExecuteNonQuery( "replace into " + Names.schedule_prefix + "prize_schedule (prize_schedule_id,prize_level_id,session_game_group_game_id,session_number,session_macro_id,amount,session_id) select if(isnull(prize_schedule_id),0,prize_schedule_id)," + prize_levels[level]
								+ "," + session_game_group_game[SessionGameGroupGameOrder.PrimaryKey]
								+ "," + ( checkBox1.Checked ? ( session_macro_session[SessionDayMacroSessionTable.NumberColumn] ) : "0" )
								+ "," + session_macro[SessionMacroTable.PrimaryKey]
								+ "," + (int)( prize )
								+ "," + session[SessionTable.PrimaryKey]
								+ " from " + Names.schedule_prefix + "prize_schedule "
								+ " where session_game_group_game_id=" + session_game_group_game[SessionGameGroupGameOrder.PrimaryKey]
								+ " and session_macro_id=" + session_macro[SessionMacroTable.PrimaryKey]
								+ " and session_number=" + session_macro_session[SessionDayMacroSessionTable.NumberColumn]
								);
						}
#endif
					}
				}

			}
			// if these aren't commited, then changes would be lost on next stage reload.
            schedule.prize_schedule.CommitChanges();
            schedule.prize_schedule_override.CommitChanges();
#if asdfadsf
			else
			{
				foreach( DataGridViewRow row in dataGridView1.Rows )
				{
					bool new_row = false;
					int game_number = Convert.ToInt32( row.Cells["game_number"].Value );
					DataRow session_game_group_game = row.Cells["session_game_group_game_row"].Value as DataRow;
					int level;
					for( level = 0; level < prize_levels.Count; level++ )
					{
						Money prize = row.Cells[level + prize_col_start].Value as Money;
						if( prize == null )
							continue;
						if( IsPrizeSame( Convert.ToInt32( session_game_group_game[SessionGameGroupGameOrder.PrimaryKey] ), prize_levels[level], prize ) )
							continue;

						if( prize_data.Rows.Count > 0 )
						{
							// this is a duplicate check, if there are no rows, can insert without regard.
							DataRow[] rows = prize_data.Select( "prize_level_id=" + prize_levels[level]
								+ " and session_game_group_game_id=" + session_game_group_game[SessionGameGroupGameOrder.PrimaryKey]
								+ " and session_number=" + ( checkBox1.Checked ? session_macro_session["session_number"] : "0" )
								+ " and session_macro_id=" + session_macro_session[SessionMacroTable.PrimaryKey]
							);
							if( rows.Length == 0 )
							{
								new_row = true;
								// select the default level...
								rows = prize_data.Select( "prize_level_id=" + prize_levels[level]
									+ " and session_game_group_game_id=" + session_game_group_game[SessionGameGroupGameOrder.PrimaryKey]
									+ " and session_number=0"
									+ " and session_macro_id=" + session_macro_session[SessionMacroTable.PrimaryKey]
								);

								if( rows.Length == 1 )
								{
									if( checkBox1.Checked )
									{


										DataRow newrow = prize_data.NewRow();
										dsn.ExecuteNonQuery( "insert into " + Names.schedule_prefix + "prize_schedule (prize_level,amount,session_game_group_game,session_macro_id,session_number,session_id)values(" + prize_levels[level] + "," + rows[0]["amount"] + "," + session_game_group_game[SessionGameGroupGameOrder.PrimaryKey] + "," + session_macro_session[SessionMacroTable.PrimaryKey] + ",0,"+session[SessionTable.PrimaryKey]+")" );


										newrow["session_game_group_game_id"] = session_game_group_game[SessionGameGroupGameOrder.PrimaryKey];
										newrow["prize_level_id"] = prize_levels[level];
										newrow["session_number"] = session_macro_session["session_number"];
										newrow["session_macro_id"] = session_macro_session[SessionMacroTable.PrimaryKey];
										prize_data.Rows.Add( newrow );
										prize_data.AcceptChanges();
										rows = new DataRow[1];
										rows[0] = newrow;
									}
								}
								else
								{
									// no default, 
								}
							}
							if( rows.Length > 2 )
							{
								Log.log( "damnit." );
							}
							if( Convert.ToInt64( rows[0]["amount"] ) == (long)prize )
								continue;


							dsn.ExecuteNonQuery( "replace into " + Names.schedule_prefix + "prize_schedule_override (prize_schedule_id,day_of_week,specific_date,new_amount) values (" + rows[0]["prize_schedule_id"]
								+ "," + day_of_week_type
								+ "," + MySQLDataTable.MakeDateOnly( date )
								+ "," + (int)( prize )
								+ ")"
								);
						}
					}
				}
			}
#endif
			// reload with current values from database.
			UpdatePrizeGrid();
		}

		private void radioButton2_CheckedChanged( object sender, EventArgs e )
		{
			ButtonBase cb = sender as ButtonBase;
			is_weekend = false;
			is_weekday = false;
			day_of_week = false;
			is_specific = false;
			RadioButton rb = sender as RadioButton;
			if( !rb.Checked )
				return;
			switch( cb.Text )
			{
			case "Default":
				day_of_week_type = -1;
				break;
			case "Monday":
				dow_specific = DayOfWeek.Monday;
				day_of_week = true;
				break;
			case "Tuesday":
				dow_specific = DayOfWeek.Tuesday;
				day_of_week = true;
				break;
			case "Wednesday":
				dow_specific = DayOfWeek.Wednesday;
				day_of_week = true;
				break;
			case "Thursday":
				dow_specific = DayOfWeek.Thursday;
				day_of_week = true;
				break;
			case "Friday":
				dow_specific = DayOfWeek.Friday;
				day_of_week = true;
				break;
			case "Saturday":
				dow_specific = DayOfWeek.Saturday;
				day_of_week = true;
				break;
			case "Sunday":
				dow_specific = DayOfWeek.Sunday;
				day_of_week = true;
				break;
			case "Weekday":
				is_weekday = true;
				break;
			case "Weekend":
				is_weekend = true;
				break;
			case "Specific Day":
				// this is handled by it's own cuseom rotuine
				is_specific = true;
				date = PayoutDateSelector.SelectDate();
				break;
			}
			if( is_specific )
				day_of_week_type = 10;
			if( is_weekend )
				day_of_week_type = 9;
			else if( is_weekday )
				day_of_week_type = 8;
			else if( day_of_week )
				day_of_week_type = ((int)dow_specific)+1;
			
			if( day_of_week_type != 10 )
				date = DateTime.MinValue;

			UpdatePrizeGrid();
		}

		private void checkBox1_CheckedChanged( object sender, EventArgs e )
		{
			FillSessionList();
		}

		void FillSessionList()
		{
			if( session_macro == null )
				return;

			this.sessions.Rows.Clear();
			if( checkBox1.Checked )
			{
				DataRow this_session_macro = ( listBox3.SelectedItem as DataRowView ).Row;
				DataRow original = this_session_macro["original_row"] as DataRow;
				DataRow[] sessions = original.GetChildRows( "session_macro_has_session" );
				foreach( DataRow session in sessions )
				{
					DataRow real_session = session.GetParentRow( "session_in_session_macro" );
					DataRow newrow = this.sessions.AddClonedRow( real_session, true );
					newrow["session_macro_session_name"] = session[SessionDayMacroSessionTable.NameColumn];
					if( session[SessionDayMacroSessionTable.NameColumn] == null ||
						session[SessionDayMacroSessionTable.NameColumn].GetType()  == typeof( DBNull ) )
						//newrow[SessionTable.NameColumn] = newrow[SessionTable.NameColumn].ToString();
						;
					else
						newrow[SessionTable.NameColumn] = session[SessionDayMacroSessionTable.NameColumn] + "(" + newrow[SessionTable.NameColumn].ToString() + ")";
					newrow["original_relation_row"] = session;
					newrow["original_row"] = real_session;
				}
				this.sessions.AcceptChanges();
			}
			else
			{
				DataRow this_session_macro = ( listBox3.SelectedItem as DataRowView ).Row;
				DataRow original = this_session_macro["original_row"] as DataRow;
				DataRow[] sessions = original.GetChildRows( "session_macro_has_session" );
				foreach( DataRow session in sessions )
				{
					DataRow real_session = session.GetParentRow( "session_in_session_macro" );
					DataRow newrow = this.sessions.AddClonedRow( real_session, false );
					if( newrow != null )
					{
						//newrow["session_macro_session_name"] = session[SessionDayMacroSessionTable.NameColumn];
						newrow["original_relation_row"] = session;
						newrow["original_row"] = real_session;
					}
				}
				this.sessions.AcceptChanges();
			}
		}



		private void listBox3_SelectedIndexChanged( object sender, EventArgs e )
		{
			if( listBox3.SelectedItem != null )
			{
				this.session_macro = ( listBox3.SelectedItem as DataRowView ).Row;
				FillSessionList();
			}
		}

		private void button1_Click( object sender, EventArgs e )
		{
			UpdatePrizesFromGrid();
		}

		private void button2_Click( object sender, EventArgs e )
		{
			UpdatePrizeGrid();
		}


	}
}