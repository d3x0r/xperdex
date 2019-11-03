using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace OpenSkieScheduler3.Controls.Forms
{
	public partial class SessionMacroScheduler : Form
	{
		public SessionMacroScheduler()
		{
			InitializeComponent();
		}

		private void SessionMacroScheduler_Load( object sender, EventArgs e )
		{
			LoadSessionColors();
		}


		#region Session Colos screen Layout
		int x_Dist = 220;
		int y_Dist = 20;

		int IniX_Pos = 20;
		int IniY_Pos = 46;

		int MaxX_Pos = 3;
		int MaxY_Pos = 8;
		#endregion

		#region Selected Session Details Screen Layout
		int MaxLineItems = 15;
		#endregion
		Label[] SessionLabels;
		Panel[] SessionPanels;
		Button[] SessionButtons;
		OpenSkieScheduler3.ScreenColors.ScreenColors ScreenColors = new OpenSkieScheduler3.ScreenColors.ScreenColors();

		private void LoadSessionColors()
		{
            ControlList.schedule.session_macros.RowChanged += new DataRowChangeEventHandler( session_macros_RowChanged );
			ReloadSessionColors();


            comboBoxMacroSessionChange.DataSource = ControlList.schedule.session_macros;
            comboBoxMacroSessionChange.DisplayMember = ControlList.schedule.session_macros.DisplayMemberName;
            comboBoxMacroSessionChange.ValueMember = ControlList.schedule.session_macros.ValueMemberName;
		}

		void session_macros_RowChanged( object sender, DataRowChangeEventArgs e )
		{
			SessionLabels = null;
			SessionPanels = null;
			SessionButtons = null;
			ReloadSessionColors();
		}

		private void ReloadSessionColors()
		{
            int totalRows = ControlList.schedule.session_macros.Rows.Count;
			SessionLabels = new Label[totalRows];
			SessionPanels = new Panel[totalRows];
			SessionButtons = new Button[totalRows];

			int i = 0;
			int y_pos = IniY_Pos;
			int x_pos = IniX_Pos;
			int color = 0;
            foreach( DataRow MacroSession in ControlList.schedule.session_macros.Rows )
			{
				//panels
				SessionPanels[i] = new Panel();
				this.panelColorsConvention.Controls.Add( SessionPanels[i] );
				SessionPanels[i].BackColor = ScreenColors.ColorsArray[color++];
				SessionPanels[i].Location = new System.Drawing.Point( x_pos, y_pos + 3 );
				SessionPanels[i].Name = "panelItem" + i;
				SessionPanels[i].Size = new System.Drawing.Size( 20, 17 );
				SessionPanels[i].TabIndex = i;

				//labels
				SessionLabels[i] = new Label();
				this.panelColorsConvention.Controls.Add( SessionLabels[i] );
				SessionLabels[i].AutoSize = true;
				SessionLabels[i].Font = new System.Drawing.Font( "Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( (byte)( 0 ) ) );
				SessionLabels[i].Location = new System.Drawing.Point( x_pos + 40, y_pos );
				SessionLabels[i].Name = "labelSession" + i;
				SessionLabels[i].Size = new System.Drawing.Size( 100, 20 );
				SessionLabels[i].TabIndex = i;
				SessionLabels[i].Text = MacroSession[SessionMacroTable.NameColumn].ToString();

				i++;
				y_pos += y_Dist;

				if( ( i % MaxY_Pos ) == 0 )
				{
					y_pos = IniY_Pos;
					x_pos = x_pos + x_Dist;
				}
			}

		}

		#region Macro Session Schedule

		private void monthCalendarMacroSchedule_DayQueryInfo( object sender, Pabo.Calendar.DayQueryInfoEventArgs e )
		{
			object AuxMacroSessionId;
			string date = e.Date.ToString( "yyyy-MM-dd" );
            DataRow[] MacroSessionId = ControlList.schedule.session_macro_schedule.Select( "starting_date <= '" + date + "'", "starting_date desc" );
			if ( MacroSessionId.Length != 0 )
			{
				DataRow session_macro = MacroSessionId[0].GetParentRow( "session_macro_on_day" );
				AuxMacroSessionId = MacroSessionId[0]["session_macro_id"];
                e.Info.BackColor1 = ScreenColors.ColorsArray[ControlList.schedule.session_macros.Rows.IndexOf( session_macro )];
			}
			else
				e.Info.BackColor1 = Color.LightGray;

			e.OwnerDraw = true;
		}

		private void monthCalendarMacroSchedule_DaySelected( object sender, Pabo.Calendar.DaySelectedEventArgs e )
		{
			labelDetails.Visible = true;
			labelDetailsII.Visible = false;
			buttonMacroChangeTo.Visible = true;
			comboBoxMacroSessionChange.Visible = true;
			ShowDetails();
		}

		private void ShowDetails()
		{

			labelDetails.Text = "";
			labelDetailsII.Text = "";

			for( int i = 0; i < monthCalendarMacroSchedule.SelectedDates.Count; i++ )
			{
				if( i < MaxLineItems )
				{
					DataRow[] MacroSessionId = ControlList.schedule.session_macro_schedule.Select( "starting_date <= '" + monthCalendarMacroSchedule.SelectedDates[i].ToString( "yyyy-MM-dd" ) + "'", "starting_date desc" );
					if( MacroSessionId.Length != 0 )
					{
						labelDetails.Text += ( i + 1 ) + ". " + ControlList.schedule.session_macros.GetConditionedDisplayValue( ControlList.schedule.session_macros.ValueMemberName, ControlList.schedule.session_macros.DisplayMemberName, MacroSessionId[0]["session_macro_id"].ToString() ) + " \n\r";
					}
				}
				else
				{
					if( i == MaxLineItems ) labelDetailsII.Visible = true;
					if( i < ( MaxLineItems * 2 ) - 1 )
					{
                        DataRow[] MacroSessionId = ControlList.schedule.session_macro_schedule.Select( "starting_date <= '" + monthCalendarMacroSchedule.SelectedDates[i].ToString( "yyyy-MM-dd" ) + "'", "starting_date desc" );
						if( MacroSessionId.Length != 0 )
						{
                            labelDetailsII.Text += ( i + 1 ) + ". " + ControlList.schedule.session_macros.GetConditionedDisplayValue( ControlList.schedule.session_macros.ValueMemberName, ControlList.schedule.session_macros.DisplayMemberName, MacroSessionId[0]["session_macro_id"].ToString() ) + " \n\r";
						}
					}
					else
					{
						if( i == ( MaxLineItems * 2 ) - 1 )
							labelDetailsII.Text += ( i + 1 ) + ". ... ";
					}
				}
			}

		}

		private void buttonMacroChangeTo_Click( object sender, EventArgs e )
		{
			int TotalSelectedDates = monthCalendarMacroSchedule.SelectedDates.Count;
			if( TotalSelectedDates == 0 )
			{
				MessageBox.Show( "Please Select a Date", "Warning" );
			}
			else
			{
				if( MessageBox.Show( "Are you sure to Change " + TotalSelectedDates + " Day(s) with Macro Session " +
                                    ControlList.schedule.session_macros.GetConditionedDisplayValue( ControlList.schedule.session_macros.ValueMemberName
                                    , ControlList.schedule.session_macros.DisplayMemberName, comboBoxMacroSessionChange.SelectedValue.ToString() ) + "?",
								 "Macro Packs Default Prices", MessageBoxButtons.YesNo, MessageBoxIcon.Warning ) == DialogResult.Yes )
				{
					DateTime NextDay, PreviousDay;
					DataRow NewDay = null;
					for( int i = TotalSelectedDates; i > 0; i-- )
					{
						PreviousDay = monthCalendarMacroSchedule.SelectedDates[i - 1].AddDays( -1 );
						NextDay = monthCalendarMacroSchedule.SelectedDates[i - 1].AddDays( 1 );

						//Is Last Day
						if( i == TotalSelectedDates || NextDay != monthCalendarMacroSchedule.SelectedDates[i] )
						{
                            DataRow[] MacroSessionIdRow = ControlList.schedule.session_macro_schedule.Select( "starting_date = '" + NextDay.ToString( "yyyy-MM-dd" ) + "'", "starting_date desc" );
							if( MacroSessionIdRow.Length == 0 )
							{
                                NewDay = ControlList.schedule.session_macro_schedule.NewRow();
                                MacroSessionIdRow = ControlList.schedule.session_macro_schedule.Select( "starting_date <= '" + NextDay.ToString( "yyyy-MM-dd" ) + "'", "starting_date desc" );
								if( MacroSessionIdRow.Length != 0 )
								{
									NewDay["starting_date"] = NextDay;
									NewDay["session_macro_id"] = MacroSessionIdRow[0]["session_macro_id"];
                                    ControlList.schedule.session_macro_schedule.Rows.Add( NewDay );
									//ControlList.schedule.session_macro_schedule.CommitChanges();
								}
							}
						}
						ControlList.schedule.session_macro_schedule.Delete( "starting_date = '" + monthCalendarMacroSchedule.SelectedDates[i - 1].ToString( "yyyy-MM-dd" ) + "'" );
						/// should never require q re-fill when deleting from said table... rows will be deleted
						/// as a property of onRowDeleted Event...
						//ControlList.schedule.session_macro_schedule.Fill();

						//Is First Day
						if( i == 1 || PreviousDay != monthCalendarMacroSchedule.SelectedDates[i - 2] )
						{
							NewDay = ControlList.schedule.session_macro_schedule.NewRow();
							NewDay["starting_date"] = monthCalendarMacroSchedule.SelectedDates[i - 1];
							NewDay["session_macro_id"] = comboBoxMacroSessionChange.SelectedValue;
							ControlList.schedule.session_macro_schedule.Rows.Add( NewDay );
							//ControlList.schedule.session_macro_schedule.CommitChanges();
						}
					}
					ShowDetails();
				}
			}
		}

		#endregion
	}
}