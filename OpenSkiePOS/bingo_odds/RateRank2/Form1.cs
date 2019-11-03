using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using BingoGameCore4;
using BingoGameCore4.Forms;
using OpenSkieScheduler3;
using OpenSkieScheduler3.Relations;
using xperdex.classes;
using System.Data.Common;

namespace RateRank2
{
    public partial class Form1 : Form
    {
        public static readonly int StartingDayOfWeek = 4;
        private DataSet ds;
        private MultiColumnListBox listBox1;
        private static DateTime gameDate = DateTime.MinValue;
        private bool fillingSessionTable = false;

        public Form1()
        {
            InitializeComponent();
            //String test1 = BuildSessionRangeCondition( "a", new DateTime( 2009, 02, 25 ), StartingDayOfWeek, 5 );
            this.Load += new EventHandler( MyOnLoad );

            ds = DataArray.ToDataSet( new object[,] { { "", "", "" } } );
            
#if null
            ds = DataArray.ToDataSet( new object[ , ]
                {
                    {"Row0, col0",  "Row0, col1"},
                    {"Row00, col0", "Row1, col1"},
                    {"Row1, col0",  "Row2, col1"},
                    {"Row1a, col0", "Row3, col1"},
                    {"row1aa,col0", "Row4, col1"},
                    {"row0, col0",  "Row5, col1"},
                    {"pow0, col0",  "Row6, col1"},
                    {"Row7, col0",  "Row7, col1"}
                }
             );
#endif
            listBoxSessions.DataSource = ds.Tables[0];
        }

        DsnConnection schedule_dsn;
        BingoSession this_session;

        BingoGameEvent.GameEventDataSet timer_gameEventDataSet;

        DsnConnection input_db;

        BingoSessionEvent playing_session;
        System.Windows.Forms.Timer check_winner;
        PackDNA pack_sequence;
        //List<int> game_group_list = new List<int>();
        DateTime the_day;
        OpenSkieScheduler3.ScheduleDataSet schedule;


        public static ControlBindingsCollection sessionCollection;

#if test_boundries
        void TestBoundries()
        {
            int start = 0;
            int session = 0;
            DateTime start_date;
            DateTime end_date;
            DateTime current_date;
            DateTime from = new DateTime( 1972, 1, 1 );
            DateTime to = new DateTime( 1972, 3, 1 );

            for( start = 0; start < 7; start++ )
            {
                for( current_date = from; current_date < to; current_date = current_date.AddDays( 1 ) )
                {
                    Log.log( 
                    String_Utilities.BuildSessionRangeCondition( null, current_date, 0, start, 3, out start_date, out end_date )
                    );

                    Log.log( current_date.ToString( "yyyyMMdd" ) + " is in " + start_date.ToString("yyyyMMdd") + " - " +end_date.ToString( "yyyyMMdd" ) );
                }
            }
            
        }
#endif
        void MyOnLoad( object sender, EventArgs e )
        {

            //TestBoundries();
            if( Environment.CommandLine.Contains( "hide" ) )
            {
                this.Visible = false;
                //this.ShowInTaskbar = false;
            }
            if( Environment.CommandLine.Contains( "HIDE" ) )
            {
                this.Visible = false;
                this.ShowInTaskbar = false;
            }

            if( !Environment.CommandLine.Contains( "config" ) )
            {
#if test
                button2.Enabled = false;
                button3.Enabled = false;
                button4.Enabled = false;
                button5.Enabled = false;
                button6.Enabled = false;
                buttonOptionEdit.Enabled = false;
#endif
            }

			// might take this option out of the starter... and just Start...
#if asdfasdfasdf
			if( Options.Default["System:" + Environment.MachineName]["Bingo Game Core"]["External Game Data"]["Enable Reciever", "0"].Bool )
            {

                //String_Utilities.BuildSessionRangeCondition( null, DateTime.Now, 0 );
                BingoGameCore4.Networking.EltaninReceiver.BingodayChanged
                    += new BingoGameCore4.Networking.ExternalReceiver.OnBingodayChange( ExternalReceiver_BingodayChanged );
                BingoGameCore4.Networking.EltaninReceiver.SessionChanged
                    += new BingoGameCore4.Networking.ExternalReceiver.OnSessionChange( ExternalReceiver_SessionChanged );
                BingoGameCore4.Networking.EltaninReceiver.GameChanged
                    += new BingoGameCore4.Networking.ExternalReceiver.OnGameChange( ExternalReceiver_GameChanged );

                BingoGameCore4.Networking.ExternalReceiver.Start();
            }
#endif
			schedule_dsn = new DsnConnection( StaticDsnConnection.dsn.DataSource );
            schedule = new OpenSkieScheduler3.ScheduleDataSet( schedule_dsn );
			schedule.Fill();

            BingoGameCore4.RateRank.Setup( schedule_dsn );
            BingoGameCore4.RateRank.game_points = new BingoGameCore4.Database.RankPointsExtended( schedule );
            input_db = new DsnConnection( Options.File( "RateRank.ini" )[Options.ProgramName + "/config"]["Input Database DSN", "MySQL"].Value );
            Text = Text + "["+input_db.DataSource +"]";

            OptionMap options = Options.Database( input_db )[Options.ProgramName];

            StateWriter.WritePackRateDetails = options["Write called_game_player_pack_stats (per card info)", "1"].Bool;


            if( options["config"]["Enable Game Check Timer", "0"].Bool )
            {
                timer_gameEventDataSet = new BingoGameEvent.GameEventDataSet( input_db );
                check_winner = new System.Windows.Forms.Timer();
                check_winner.Interval = options["config"]["Game Check Timer Length", "5000"].Integer;
                check_winner.Tick += new EventHandler( check_winner_Tick );
                check_winner.Start();
            }


            monthCalendar1.ActiveMonth.Year = DateTime.Now.Year;
            monthCalendar1.ActiveMonth.Month = DateTime.Now.Month;
            monthCalendar1.MonthChanged += new Pabo.Calendar.MonthChangedEventHandler( monthCalendar1_MonthChanged );
            monthCalendar1.DaySelected += new Pabo.Calendar.DaySelectedEventHandler( monthCalendar1_DaySelected );
            listBoxSessions.SelectedIndexChanged += new EventHandler( listBoxSessions_SelectedIndexChanged );
            dataGridView1.SelectionChanged += new EventHandler( dataGridView1_SelectionChanged );
            dataGridView1.MouseCaptureChanged += new EventHandler( dataGridView1_MouseCaptureChanged );
        }

        void EltaninReceiver_BingodayChanged( DateTime new_bingoday )
        {
            //throw new NotImplementedException();
        }

        DataGridViewSelectedCellCollection dataGridView1_Selection;
        bool MouseCaptureOn = false;

        void dataGridView1_SelectionChanged( object sender, EventArgs e )
        {
            if( MouseCaptureOn == false )
                dataGridView1_Selection = dataGridView1.SelectedCells;

            return;
        }

        void dataGridView1_MouseCaptureChanged( object sender, EventArgs e )
        {
            MouseCaptureOn = ( MouseCaptureOn ? false : true );
            return;
        }
        
        void listBoxSessions_SelectedIndexChanged( object sender, EventArgs e )
        {
            int session_number = 0;

            this.Cursor = Cursors.WaitCursor;

            if( fillingSessionTable == true )
                return;

            OpenSkieScheduler3.ScheduleDataSet.GetScheduleDataSet();

            if( ( session_number = GetSession() ) > 0 )
            {
                String  strItem;
                
                manual_dataset.games.Clear();
                ListBox.SelectedObjectCollection listBoxItems = listBoxSessions.SelectedItems;

                if( listBoxItems.Count > 0 )
                {

                    foreach( DataRowView item in listBoxItems )
                    {
                        session_number = Convert.ToInt32( item[ 2 ].ToString() );
                        strItem = item[ 0 ].ToString();

                        gameDate = the_day = DateTime.Parse( item[ 1 ].ToString() );

                        DataRow session = schedule.GetSession( gameDate, session_number );
                        DataRow[ ] games = session.GetChildRows( schedule.session_games.ChildrenOfParent );

                        foreach( DataRow gameRow in games )
                        {
                            manual_dataset.games.Rows.Add( new Object[ ]
                                {
                                    gameDate.ToString( "yyMMdd" ) + gameRow[ "session_game_id" ].ToString(),
                                    gameDate,
                                    gameRow[ "session_id" ],
                                    strItem,
                                    gameRow[ "game_id" ],
                                    gameRow.ToString()
                                }
                            );
                        }

                    }
                }
                else
                {
                    // All have been selected
                }
            }
            this.Cursor = Cursors.Default;
            return;
        }


        delegate void SetTextCallback( string text );

        void UpdateStatus( string textToWrite )
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.

            // .NET takes care of the InvokeRequired check
            // We don't need to do it twice!
            lock( listBoxStatus )
            {
                Invoke( ( MethodInvoker ) delegate
                {
					listBoxStatus.Items.Add( textToWrite );
					listBoxStatus.TopIndex = listBoxStatus.Items.Count - ( listBoxStatus.Height / listBoxStatus.ItemHeight );
					listBoxStatus.Refresh();
                } );
            }
        }

		void UpdateLastStatusLine( string textToWrite )
		{
			// InvokeRequired required compares the thread ID of the
			// calling thread to the thread ID of the creating thread.
			// If these threads are different, it returns true.

			// .NET takes care of the InvokeRequired check
			// We don't need to do it twice!
			lock( listBoxStatus )
			{
				Invoke( ( MethodInvoker )delegate
				{
					listBoxStatus.Items[listBoxStatus.Items.Count - 1] = textToWrite;
					listBoxStatus.TopIndex = listBoxStatus.Items.Count - ( listBoxStatus.Height / listBoxStatus.ItemHeight );
					listBoxStatus.Refresh();
				} );
			}
		}
		
		int old_game;
        void EltaninReceiver_GameChanged( int new_Game )
        {
            //this needs to have an option.
            if( true )
                return;

            //----------------------------------------------
            // FIX
            //----------------------------------------------
            if (playing_session == null)
                return;
            Log.log( "New game " + new_Game );
            if( new_Game != old_game )
            {
                if( old_game > 0 )
                {
                    UpdateStatus( "Reloading players in session "
                        + playing_session.session_number
                        + " and game "
                        + old_game );

                    try
                    {
                        //playing_session.PlayerList
                        //playing_session.ReloadPlayers(/* pack_sequence */); // make sure the players are up to date...
                        /*
                        for( int p = 0; p < 60; p++ )
                            playing_session.PlayerList.Add( new BingoPlayer() );
                        */
                        BingoGameState s = playing_session.StepToReplay( old_game );
                        if( s.valid )
                        {
                            UpdateStatus( "Playing session "
                                + playing_session.session_number
                                + " and game "
                                + old_game );
                            playing_session.Play( s );
                            while( playing_session.Active )
                                Thread.SpinWait( 1 );
                            UpdateStatus( "Calculating session "
                                + playing_session.session_number
                                + " and game "
                                + old_game );
                            if( BingoGameCore4.RateRank.Calculate( s ) )
                            {
                                UpdateStatus( "Writing session "
                                    + playing_session.session_number
                                    + " and game "
                                    + old_game );
                                StateWriter.DumpState( s, false, false );
                            }
                            else
                                UpdateStatus( "Game did not get ranked, not writing." );
                        }
                        else
                            UpdateStatus( "Skiping game... not playing it." );
                    }
                    catch( Exception e )
                    {
                        Log.log( "Outermost catcher caught exception - " + e.StackTrace );
                        Log.log( "Timer will resume at least..." );
                        Log.log( e.Message );
                    }
                }
                old_game = new_Game;
            }
            // Scan prior game...

            //throw new Exception( "The method or operation is not implemented." );
        }

        void SetupNewSession( DateTime the_day, DataRow session )
        {
            StaticDsnConnection.KindExecuteNonQuery( "update bingo_game_processed set processed=0 join bingo_game using(bingo_game_id) where bingoday=" + MySQLDataTable.MakeDateOnly( the_day ) + " and session=" + session["session"].ToString() );
        }

        void SetupNewSession( DateTime the_day, int session )
        {
            //if( playing_session == null || playing_session.session_number != session )
            {
                Log.log( "Starting new session " + session );
                // load in the correct session....
                this_session = new BingoSession( schedule, the_day, session );
                playing_session = new BingoSessionEvent( this_session, true );
                BingoGameCore4.Forms.RatedGameConfigurator.GameConfiguration game_config = new RatedGameConfigurator.GameConfiguration( schedule );
				DsnSQLUtil.MatchCreate( schedule.schedule_dsn, game_config );
				game_config.Fill();

                foreach( BingoGame game in this_session.GameList )
                {
                    BingoGameState s = playing_session.Step();

                    DataRow[] rows = game_config.Select( "session_game_id=" 
                        + DsnSQLUtil.GetSQLValue( null
                            , schedule.session_games.Columns[SessionGame.PrimaryKey].DataType
                            , game.session_game_id ) );

                    if( rows.Length > 0 )
                        game.rate = Convert.ToBoolean( rows[0]["rate"] );
                }


                pack_sequence = RatedPackConfigurator.GetPackDNA( this_session );
                //playing_session.ReloadPlayers(/* pack_sequence */);
#if static_dna
                {

                    pack_sequence = new PackDNA();
                    pack_sequence.pack_sequence.Add( this_session.GameList.pack_list.GetPack( "RB Blue" ) );     //1
                    pack_sequence.pack_sequence.Add( this_session.GameList.pack_list.GetPack( "RB Blue" ) );     //2
                    pack_sequence.pack_sequence.Add( this_session.GameList.pack_list.GetPack( "RB Blue" ) );     //3
                    pack_sequence.pack_sequence.Add( this_session.GameList.pack_list.GetPack( "RB Blue" ) );     //4
                    pack_sequence.pack_sequence.Add( this_session.GameList.pack_list.GetPack( "RB Red" ) );
                    pack_sequence.pack_sequence.Add( this_session.GameList.pack_list.GetPack( "RB Red" ) );     //5
                    pack_sequence.pack_sequence.Add( this_session.GameList.pack_list.GetPack( "RB Red" ) );
                    pack_sequence.pack_sequence.Add( this_session.GameList.pack_list.GetPack( "RB Red" ) );     //6
                    pack_sequence.pack_sequence.Add( this_session.GameList.pack_list.GetPack( "RB Green" ) );
                    pack_sequence.pack_sequence.Add( this_session.GameList.pack_list.GetPack( "RB Green" ) );     //7
                    pack_sequence.pack_sequence.Add( this_session.GameList.pack_list.GetPack( "RB Green" ) );
                    pack_sequence.pack_sequence.Add( this_session.GameList.pack_list.GetPack( "RB Green" ) );     //8
                    pack_sequence.pack_sequence.Add( this_session.GameList.pack_list.GetPack( "Free Blue" ) );  //9
                    pack_sequence.pack_sequence.Add( this_session.GameList.pack_list.GetPack( "Free Blue" ) );  //10
                    pack_sequence.pack_sequence.Add( this_session.GameList.pack_list.GetPack( "Free Blue" ) );  //11
                    pack_sequence.pack_sequence.Add( this_session.GameList.pack_list.GetPack( "Free Red" ) );      //12
                    pack_sequence.pack_sequence.Add( this_session.GameList.pack_list.GetPack( "Free Red" ) );      //13
                    pack_sequence.pack_sequence.Add( this_session.GameList.pack_list.GetPack( "Free Red" ) );      //14
                    pack_sequence.pack_sequence.Add( this_session.GameList.pack_list.GetPack( "RB Blue" ) );      //15
                    pack_sequence.pack_sequence.Add( this_session.GameList.pack_list.GetPack( "RB Red" ) );
                    pack_sequence.pack_sequence.Add( this_session.GameList.pack_list.GetPack( "RB Green" ) );      //16


                    playing_session.ReloadPlayers( pack_sequence );
                }
#endif
            }
        }

        void EltaninReceiver_SessionChanged( int new_session )
        {
            //this needs to have an option.
            if( true )
                return;

            //--------------------------------------------------
            // FIX
            //--------------------------------------------------
#if null
            //game_group_list.Clear();
            //foreach( DataRow row in Local.game_db.Rows )
            //    if( Convert.ToBoolean( row["rate"] ) )
            //game_group_list.Add( Convert.ToInt32( row["session_game_group_id"] ) );

            if( new_session == 0 )
            {
                // close rank tables..
                if( playing_session != null )
                {
                    BingoGameCore4.RateRank.UpdateRanks( playing_session.bingoday, playing_session.session_number );
                }
                playing_session = null;
            }
            else
            {
                if( playing_session != null && playing_session.session_number == new_session )
                {
                    UpdateStatus( "Change in eltanin indicates we already ahve the right one." );
                    return;
                }
                // kinda don't need this, since copmutation's cannot be done until games end...
                UpdateStatus( "Loading New session" + new_session );
                // loses prior session when set... otherwise collects ALL information about the session.
                SetupNewSession( BingoGameCore4.Networking.EltaninReceiver.Bingoday, new_session );
                //playing_session.flags.ignore_same_pattern_progressives = true;
            }
            Log.log( "New session " + new_session );
            //throw new Exception( "The method or operation is not implemented." );
#endif
        }


        bool complete;

        void check_winner_Tick( object sender, EventArgs e )
        {
            Log.log( "Tick." );
            check_winner.Stop();
            timer_gameEventDataSet.FillUnprocessed( 10 );
            {
                if( timer_gameEventDataSet.GamesProcessed.Rows.Count > 0 )
                {
                    complete = false;
                    // if playing session is not initialized, a warning is thrown for this loop.

                    foreach( DataRow row in timer_gameEventDataSet.GamesProcessed.Rows )
                    {
                        DataRow GameEventRow = row.GetParentRow( "game_is_processed" );
                        int row_session = Convert.ToInt32( GameEventRow["session"] );
                        //if( this_session == null || playing_session.session_number != row_session )
                        {
                            SetupNewSession( Convert.ToDateTime( GameEventRow["bingoday"] ), Convert.ToInt32( GameEventRow["session"] ) );
                            
                            this_session.StatusUpdate += UpdateStatus;

                            UpdateStatus( "Reloading players in session " + playing_session.session_number );
                            // each session has one set of players...
                            // playing_session.ReloadPlayers();
                        }
                        
                        // this has game number in it...
                        BingoGameState[] states = playing_session.StepToReplay( GameEventRow );
                        if( states != null )
                        {
                            UpdateStatus( "Playing session "
                                + playing_session.session_number
                                );
                            foreach( BingoGameState game_state in states )
                            {
                                // bingo game state contains the BingoGameEvent
                                // so part of initializiation is the Bingogaemevent from the row ... already exists...
                                playing_session.DoPlayState( game_state );
                                //playing_session.Play( game_state );
                                if( BingoGameCore4.RateRank.Calculate( game_state ) )
                                {
                                    //StateWriter.WritePerCardStatistics = true;
                                    //StateWriter.WritePlayerPackBreakdown = true;
                                    //    StateWriter.
                                    StateWriter.DumpState( game_state, false, false );
                                }

                            }
                            UpdateStatus( "Played session (wrote results)"
                                            + playing_session.session_number
                                    );
                        }
                        row["processed"] = true;
                        timer_gameEventDataSet.GamesProcessed.CommitChanges();
                    }
                }
                else
                {
                    if( !complete )
                    {
                        UpdateStatus( "Everything Complete." );
                        complete = true;
                    }
                }
            }
            check_winner.Start();
            // select from prize_validations, see if anything is new.

            // step to game, and play.
        }

        void monthCalendar1_MonthChanged( object sender, Pabo.Calendar.MonthChangedEventArgs e )
        {
            int x = 0;
            x++;

            //Pabo.Calendar.DateItemCollection days =
            //    monthCalendar1.;


        }

        int[] sessions;
        public BingoGameEvent.GameEventDataSet manual_dataset;

        void monthCalendar1_DaySelected( object sender, Pabo.Calendar.DaySelectedEventArgs e )
        {
            Pabo.Calendar.SelectedDatesCollection dates = this.monthCalendar1.SelectedDates;
			if( manual_dataset == null )
			{
				manual_dataset = new BingoGameEvent.GameEventDataSet( StaticDsnConnection.dsn );
				DsnSQLUtil.MatchCreate( StaticDsnConnection.dsn, manual_dataset );
			}
            if( dates.Count > 0 )
            {
                {
                    List<DateTime> selectedDates = new List<DateTime>();

                    for( int idx = 0; idx < dates.Count; idx++ )
                        selectedDates.Add( dates[idx] );

                    the_day = dates[0];

                    GetSessions( the_day, selectedDates );
                    
                    //sessions = BingoGameList.GetPlayedSessions( dates[ 0 ] );
                    manual_dataset.FillToday( the_day, selectedDates );
                }

            }

            dataGridView1.DataSource = manual_dataset.games;
            dataGridView1.Columns[ "bingo_game_id" ].Visible = false;
            dataGridView1.Columns[ "bingoday" ].Visible = true;
            dataGridView1.Columns[ "bingoday" ].HeaderText = "Date";
            dataGridView1.Columns[ "session" ].HeaderText = "Session";
            dataGridView1.Columns[ "session" ].Width = 150;
            dataGridView1.Columns[ "game" ].HeaderText = "Game";
            dataGridView1.Columns[ "game" ].Width = 150;
            dataGridView1.Columns[ "session_id" ].Visible = false;
            dataGridView1.Columns[ "game_id" ].Visible = false;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.ScrollBars = ScrollBars.Vertical;
            dataGridView1.EditMode = DataGridViewEditMode.EditProgrammatically;

            int width = dataGridView1.Width;
            width -= dataGridView1.Columns[ "bingoday" ].Width;
            width -= dataGridView1.Columns[ "session" ].Width;
            width -= dataGridView1.Columns[ "game" ].Width;
            width -= dataGridView1.Columns[ "ballset" ].Width;
            width -= dataGridView1.Columns[ "closed_at" ].Width;
            dataGridView1.Columns[ "created" ].Width = width;
            dataGridView1.Columns[ "created" ].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            return;                
        }

        private void comboBox1_SelectedIndexChanged( object sender, EventArgs e )
        {

        }

        bool all_sessions;

        void RunSession( bool write_state)
        {
            BingoGameState s;

            playing_session.BeginPlay();
            // can't check valid, games with no balls are also not valid, but shouldn't end the list.
            while( ( s = playing_session.StepReplay(false) ).game != null )
            {
                // this begins a thread that plays once.
                // playing_session.Up
                if( s.valid )
                {
					playing_session.LoadPlayerCards( s );
					string[] columns = s.game.Name.Split( '\t' );
					UpdateStatus( "Session: " + this.playing_session.session.session_name + ", Game: " + columns[ 1 ].ToString() + " Started");

                    playing_session.Play( s );
                    while( playing_session.Active )
                        Thread.SpinWait( 1 );
					if( BingoGameCore4.RateRank.Calculate( s ) )
						if( write_state )
							StateWriter.DumpState( s, false, true );
					UpdateStatus( "Session: " + this.playing_session.session.session_name + ", Game: " + columns[1].ToString() + " Ended" );
				}
            }
			UpdateStatus( "Updating Session Rate & Rank Data Tables..." );
			BingoGameCore4.RateRank.UpdateRanks( playing_session.bingoday, playing_session.session_number );
			UpdateLastStatusLine( "Updating Session Rate & Rank Data Tables... Done" );

        }

        int GetSessions( DateTime bingoday, List<DateTime> selectedDays )
        {
            Int32[] width = new Int32[3];

            fillingSessionTable = true;
            listBoxSessions.SelectionMode = SelectionMode.None;

            ds.Tables[ 0 ].Rows.Clear();

            for( int idx = 0; idx < selectedDays.Count; idx++ )
            {
                the_day = bingoday = selectedDays[ idx ];
                schedule.Fill( bingoday );

                foreach( DataRow sms_row in schedule.session_macro_sessions.Rows )
                {
					DataRow row = sms_row.GetParentRow( schedule.session_macro_sessions.MemberInGroup );
                    // This gets us the session ids in session order
                    // now we need to get the corresponding session info
                    //foreach( DataRow row in schedule.sessions.Rows )
                    {
						DbDataReader reader = StaticDsnConnection.dsn.KindExecuteReader( "select count(*) from player_track as a left outer join player_track as b on a.transnum=b.void_trans"
							+ " where a.bingoday="+ DsnSQLUtil.MakeDateOnly( selectedDays[idx] ) + " and a.void_trans=0 and b.transnum is NULL"
							+ " and a.session=" + sms_row[SessionDayMacroSessionTable.NumberColumn] );
						if( reader == null || !reader.HasRows )
						{
							StaticDsnConnection.dsn.EndReader( reader );
							continue;
						}
						reader.Read();
						if( reader.GetInt32( 0 ) == 0 )
						{
							StaticDsnConnection.dsn.EndReader( reader );
							continue;
						}
						StaticDsnConnection.dsn.EndReader( reader );

                        ds.Tables[ 0 ].Rows.Add(
                            new string[ ] { 
                                row[ "session_name"].ToString(), 
                                selectedDays[idx].ToString( "MM/dd/yyyy" ),
                                sms_row[ "session_number" ].ToString()
                            }
                        );

                        width[ 0 ] = Math.Max( width[ 0 ], TextRenderer.MeasureText( ds.Tables[ 0 ].Rows[ ds.Tables[ 0 ].Rows.Count - 1 ][ 0 ].ToString(), ListBox.DefaultFont ).Width );
                        width[ 1 ] = Math.Max( width[ 1 ], TextRenderer.MeasureText( ds.Tables[ 0 ].Rows[ ds.Tables[ 0 ].Rows.Count - 1 ][ 1 ].ToString(), ListBox.DefaultFont ).Width );
                        width[ 2 ] = Math.Max( width[ 2 ], TextRenderer.MeasureText( ds.Tables[ 0 ].Rows[ ds.Tables[ 0 ].Rows.Count - 1 ][ 2 ].ToString(), ListBox.DefaultFont ).Width );
                    }
                }

                if( selectedDays.Count > 1 )
                {
                    listBoxSessions.ColumnWidths[ 0 ] = width[ 0 ] + 5;
                    listBoxSessions.ColumnWidths[ 1 ] = listBoxSessions.ColumnWidth - listBoxSessions.ColumnWidths[ 0 ];
                    listBoxSessions.ColumnWidths[ 2 ] = width[ 2 ] + 5;
                }
                else
                {
                    listBoxSessions.ColumnWidths[ 0 ] = listBoxSessions.ColumnWidth;
                    listBoxSessions.ColumnWidths[ 1 ] = width[ 1 ] + 5;
                    listBoxSessions.ColumnWidths[ 2 ] = width[ 2 ] + 5;
                }

                the_day = bingoday = selectedDays[ 0 ];
            }

            fillingSessionTable = false;
            listBoxSessions.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;

            return listBoxSessions.Items.Count;
        }

        int GetSessions( DateTime bingoday )
        {
            List<DateTime> selectedDates = new List<DateTime>();
            return GetSessions( bingoday, selectedDates );
        }

        int GetSession()
        {
            // if no day is selected...
            if( the_day == DateTime.MinValue )
                return 0;

            int column = ds.Tables[ 0 ].Columns.Count - 1;

            if( listBoxSessions.SelectedItems.Count > 0 )
            {
                for( int index = 0; index < listBoxSessions.Items.Count; index++ )
                {
                    if( listBoxSessions.GetSelected( index ) == true )
                        return Convert.ToInt32( ds.Tables[ 0 ].Rows[ index ][ column ] );
                }
            }
            return 0;
        }

        void RunSessions( object param )
        {
            int sessionId = Convert.ToInt32( param );
            string sessionName = playing_session.session.session_name;

            // should probably lock-step the sessions somehow...
            // at this point, all threads would spawn for hundreds of days and that many times sessions
            // threading is a limited resource (probably)

            if( playing_session == null || playing_session.session_number != sessionId )
            {
                SetupNewSession( the_day, sessionId );
            }
			sessionName = playing_session.session.session_name;

			// play a 'new' session...
            UpdateStatus( "Loading Session: " + sessionName );
            //playing_session.flags.ignore_same_pattern_progressives = true;
            UpdateStatus( DateTime.Now + ": Session " + sessionName + " started..." );
            RunSession( true );
            UpdateStatus( DateTime.Now + ": Session " + sessionName + " finished" );

            return;
#if null
            all_sessions = false;
            if( sessionId < 0 )
                all_sessions = true;

            if( all_sessions )
            {
                sessionId = 1;
            }

            while( sessionId > 0 )
            {
                if( all_sessions )
                {
                    if( playing_session == null || playing_session.session_number != sessionId )
                    {
                        SetupNewSession( the_day, sessionId );
                    }
                    // play a 'new' session...
                    UpdateStatus( DateTime.Now + ":Starting session " + sessionId + "..." );
                    UpdateStatus( "Loading New Session " + sessionId );
                    //playing_session.flags.ignore_same_pattern_progressives = true;
                    RunSession( true );
                    UpdateStatus( DateTime.Now + ":Session " + sessionId + " started..." );
                    sessionId++;
                }
                else
                {
                    // should already be setup form selecting in listbox...
                    // SetupNewSession( the_day, session );
                    // play 'this' session.
                    UpdateStatus( DateTime.Now + ":Starting session " + sessionId + "..." );
                    RunSession( true );
                    UpdateStatus( DateTime.Now + ":Session " + sessionId + " started..." );
                    sessionId = 0;
                }
            }
            //labelStatus.Text = "Complete...";
            UpdateStatus( "Complete..." );
            //labelStatus2.Text = "Complete...";
#endif
        }

        private void button1_Click( object sender, EventArgs e )
        {
            this.listBoxStatus.Items.Clear();
            //this.labelStatus.Text = "Getting selected date...";

            Pabo.Calendar.SelectedDatesCollection dates = this.monthCalendar1.SelectedDates;
            if( dates.Count == 0 )
                return;

			/* these tables are part of 'StateWriter' */
			/*
			StaticDsnConnection.KindExecuteNonQuery( "DELETE FROM called_game_balls" );
			StaticDsnConnection.KindExecuteNonQuery( "DELETE FROM called_game_player_rank2" );
			StaticDsnConnection.KindExecuteNonQuery( "DELETE FROM called_game_player_pack_status" );
			StaticDsnConnection.KindExecuteNonQuery( "DELETE FROM called_game_card_away_status" );
			StaticDsnConnection.KindExecuteNonQuery( "DELETE FROM called_game_player_away_status" );
			StaticDsnConnection.KindExecuteNonQuery( "DELETE FROM called_game_winning_card_info" );
			*/
			UpdateStatus( "Initializing Rate & Rank Data Tables..." );

            foreach( DateTime date in dates )
            {
				int session;
				foreach( DataRowView rowView in listBoxSessions.SelectedItems )
                {
					session = Convert.ToInt32( rowView.Row[2] );
					if( timer_gameEventDataSet != null )
						timer_gameEventDataSet.ClearProcessed( the_day, session );
					SetupNewSession( date, session );
                    RunSessions( session );
                }
            }
        }

        private void button2_Click( object sender, EventArgs e )
        {
            //RunSession();
        }

        private void button3_Click( object sender, EventArgs e )
        {
            ConfigureGamePackPoints cgpp = new ConfigureGamePackPoints( schedule );
            cgpp.ShowDialog();
            //ConfigurePoints cp = new ConfigurePoints();
            //cp.ShowDialog();
        }

        private void button4_Click( object sender, EventArgs e )
        {
            RatedPackConfigurator rpc = new RatedPackConfigurator( schedule );
            rpc.ShowDialog();
            //ConfigurePacks cp = new ConfigurePacks( this_session.schedule );
            //cp.ShowDialog();
        }

        private void button2_Click_1( object sender, EventArgs e )
        {
            ScheduleDesigner.ScheduleDesigner pse = new ScheduleDesigner.ScheduleDesigner( schedule );
            pse.ShowDialog();
        }

        private void button5_Click( object sender, EventArgs e )
        {
            RatedGameConfigurator rgc = new RatedGameConfigurator( schedule );
            rgc.ShowDialog();

            //-----------------------------------------
            // FIX
            //-----------------------------------------
            if( listBoxSessions.SelectedItem != null ) 
				if( listBoxSessions.GetSelected( listBoxSessions.SelectedIndex ) == false )
			{
                MessageBox.Show( "Please select a session" );
                return;
            }
			return;
		}

        private void buttonInspect_Click( object sender, EventArgs e )
        {
            int session = GetSession();
			if( session > 0 )
				try
				{
					this_session = new BingoSession( schedule, the_day, session );
					UpdateStatus( "Inspecting Session: " + this_session.session_name.ToString() + "..." );
				}
				catch
				{
					return;
				}
			else
			{
				MessageBox.Show( "Cannot open session " + session );
				return;
			}
//#if null
            try
            {
                playing_session = new BingoSessionEvent( this_session, true );
            }
            catch( Exception session_exception )
            {
                Log.log( session_exception.Message );
                return;
            }
			{
				playing_session.LoadPlayers();
				RunSession( false );
				//playing_session.Play();
				while( playing_session.Active )
					Thread.SpinWait( 100 );
				CardBrowsingForm sb = new CardBrowsingForm( playing_session );
                sb.ShowDialog();
            }
//#endif

//			SessionBrowser sb = new SessionBrowser( schedule, this_session );
//			sb.ShowDialog();
        }

        private void buttonReRank_Click( object sender, EventArgs e )
        {
            BingoGameCore4.RateRank.UpdateRanks();
        }

        private void button6_Click( object sender, EventArgs e )
        {
            BingoGameCore4.Forms.BonusPointConfigurator bcp = new BonusPointConfigurator();
            bcp.ShowDialog();
        }

        private void button7_Click( object sender, EventArgs e )
        {
            OptionEditor oe = new OptionEditor();
            oe.ShowDialog();
            oe.Dispose();
        }

        private void labelStatus2_Click(object sender, EventArgs e)
        {

        }

        private void labelStatus_Click(object sender, EventArgs e)
        {

        }

		private void button7_Click_1( object sender, EventArgs e )
		{
			ScheduleDataSet schedule = new ScheduleDataSet();
			schedule.schedule_dsn = StaticDsnConnection.dsn;
			DataRow session = schedule.GetSession( new DateTime( 2013, 4, 1 ), 1 );
			schedule.Fill( session );
			schedule.WriteXML( "testload.xml" );

		}


    }
}