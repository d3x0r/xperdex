//#define excel_linked 

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using bingo_odds;
using BingoGameCore4.Forms;
using xperdex.classes;

#if excel_linked
using System.Drawing;
using System.Runtime.InteropServices;
using Microsoft.CSharp.RuntimeBinder;
//using Microsoft.Office.Core;
using Microsoft.Office.Interop.Excel;
#endif

namespace BingoGameCore4
{
    public partial class RunDetails : Form
    {
        DateTime dtStart;
        OddsRunInfo runinfo;
        bool paused;
        int tick;
        // thse should move to an array.
        int threads;
        StringBuilder sb = new StringBuilder();
        OddsRunInfo.state last_state;
        System.Windows.Forms.Timer t = new System.Windows.Forms.Timer();

        void PlayCards( object param )
        {
            int id = Convert.ToInt32( param );
            OddsRunInfo.state state;
            DateTime last_bingoday = DateTime.Now.Date;
            int last_session = 0;
            threads++;

            //Thread.Sleep( 250 );
            do
            {
                while( paused )
                    Thread.Sleep( 250 );

				// release this ... we use the same session over and over.
                //Log.log( id+ ":Step." );
                try
                {
                    state = runinfo.Step();
                }
                catch( Exception e )
                {
                    Log.log( e.Message );
                    break;
                }

                //Log.log( id + ":Stepped." );
                if( state.valid )
                {
                    // grab this, so the snapshot browse dialog can work...
                    last_state = state;
                    //Log.log( id + ":Play." );
                    runinfo.Play( state );

                    if( state.game.rate )
                    {
                        BingoGameCore4.RateRank.Setup( StaticDsnConnection.dsn );
                        BingoGameCore4.RateRank.Calculate( state );
                        //Log.log( "Write..." );
						if( runinfo.flags.database_run )
							StateWriter.DumpState( state, false, false );
                    }

					if( runinfo.trigger_stats.enabled )
					{
						int count = state.bestwin;
						int n;
						bool triggered = false;
						int[] balls = state.game_event._playing_balls;
						Log.log( "game " + state.Game + " hotball " + state.session_event.trigger_balls[0] + " has " + count + " balls starting at " + state.starting_balls + " of balls " + balls.Length );

						for( n = state.starting_balls; n < count; n++ )
						{
							if( balls[n] == state.session_event.trigger_balls[0] )
							{
								Log.log( "ball " + n + " (" + balls[n] + ") the hotball?" );
								if( n == ( count - 1 ) )
								{
									if( state.session_event.hotwins == 0 )
									{
										Log.log( "hotball win - natural" );
										state.session_event.hotwins++;
										runinfo.trigger_stats.trigger_wins[0]++;
									}
									else
										Log.log( "hotball already won in the session" );
								}
								else
								{
									int newball;
								rescan:
									for( newball = 0; newball < runinfo.trigger_stats.max_triggered; newball++ )
									{
										if( state.session_event.triggered_balls[newball] == 0 )
											break;
										else
											if( state.session_event.triggered_balls[newball] == balls[n + 1] )
											{
												n++;
												if( (n+1) < count )
												{
													Log.log( "duplicate ball in session " + runinfo._total_sessions + " ball num " + newball + " is already " + balls[n + 1] );
													Log.log( "have another ball in the game..." );
													goto rescan;
												}
												else
												{
													Log.log( "duplicate ball in session " + runinfo._total_sessions + " ball num " + newball + " is already " + balls[n] );
													Log.log( "No Further Balls Avaialble... " );
													goto abort_trigger;
												}
												// duplicate ball.
											}
									}
									Log.log( "Trigger hotball at " + newball + " = " + balls[n + 1] );
									if( newball < runinfo.trigger_stats.max_triggered )
									{
										triggered = true;
										runinfo.trigger_stats.triggered[newball + 1]++;
										state.session_event.triggered_balls[newball] = balls[n + 1];
									}
								}
							}
						}
					abort_trigger:
						;
						for( n = 0; n < runinfo.trigger_stats.max_triggered; n++ )
						{
							if( state.session_event.triggered_balls[n] == 0 )
								break;
							//Log.log( "did trigger ball " + ( n + 1 ) + " " + state.session_event.triggered_balls[n] + " == " + balls[state.bestwin - 1] );
							if( triggered )
							{
								// don't win on last ball even if it's the last
								if( n == ( runinfo.trigger_stats.max_triggered - 1 ) )
								{
									if( state.session_event.triggered_balls[n] == balls[state.bestwin - 1] )
									{
										Log.log( "triggered ball would have also won " + (n+1) );
									}
									break;
								}
								// don't win on ball that has just been triggered (next is 0)
								if( state.session_event.triggered_balls[n + 1] == 0 )
								{
									if( state.session_event.triggered_balls[n] == balls[state.bestwin - 1] )
									{
										Log.log( "triggered ball would have also won " + ( n + 1 ) );
									}
									break;
								}
							}
							if( state.session_event.triggered_balls[n] == balls[state.bestwin - 1] )
							{
								if( !state.session_event.triggered_ball_won[n] )
								{
									state.session_event.triggered_ball_won[n] = true;
									runinfo.trigger_stats.trigger_wins[n + 1]++;
									Log.log( "triggered hotball wins...." );
								}
								else
									Log.log( "Triggered hotball has already won in this session." );
							}
						}
					}

                    //GameStatsCount( state );
                    //Log.log( id + ":Played." );
                    if( state.session_event.session_number != last_session )
                    {
                        if( last_session != 0 )
                        {
                            //StaticDsnConnection.dsn.KindExecuteNonQuery( "update called_game_player_rank2 set pack_set_id=1 where bingoday=" + MySQLDataTable.MakeDateOnly( last_bingoday ) + " and session=" + last_session );
                            RateRank.UpdateRanks( last_bingoday, last_session );
                        }
                        last_session = state.session_event.session_number;
                    }
                    if( last_bingoday != state.session_event.bingoday )
                    {
                        //if( last_session != 0 )
                        //    RateRank.UpdateRanks( last_bingoday, 0 );
                        last_bingoday = state.session_event.bingoday;
                    }
                    //Log.log( "..." );
                }
            }
            while( state.stepped );
            threads--;
        }

        public RunDetails( OddsRunInfo ori, int start_threads )
        {
            tick = 0;
            dtStart = DateTime.Now;
            runinfo = ori;

            InitializeComponent();

//            for( int n = 0; n < 16; n++ )
//                dataGridViewGeneralStats.Columns.Add( "statname", "Statistic" );
//            this.dataGridViewGeneralStats.Columns.Add( "value", "Value" );
			dataGridViewGeneralStats.ColumnHeadersVisible = true;
            dataGridViewGeneralStats.AllowUserToAddRows = false;
            dataGridViewGeneralStats.RowHeadersVisible = false;
            dataGridViewGeneralStats.EditMode = DataGridViewEditMode.EditProgrammatically;

			dataGridViewGeneralStats.Columns.Add( "Year", "Year" );										// 0
			dataGridViewGeneralStats.Columns.Add( "Day", "Day" );										// 1
			dataGridViewGeneralStats.Columns.Add( "Hall", "Hall" );										// 2
			dataGridViewGeneralStats.Columns.Add( "Session", "Session" );								// 3
			dataGridViewGeneralStats.Columns.Add( "Game", "Game" );										// 4
			dataGridViewGeneralStats.Columns.Add( "Card", "Card" );										// 5 
			dataGridViewGeneralStats.Columns.Add( "Total Cards", "Total Cards" );						// 6
			dataGridViewGeneralStats.Columns.Add( "Total Wins", "Total Wins" );							// 7
			dataGridViewGeneralStats.Columns.Add( "Win %", "Win %" );									// 8
			dataGridViewGeneralStats.Columns.Add( "Win 1 in X", "Win 1 in X" );							// 9
			dataGridViewGeneralStats.Columns.Add( "Hot Wins", "Hot Wins" );								// 10
			dataGridViewGeneralStats.Columns.Add( "Hot Win %", "Hot Win %" );							// 11
			dataGridViewGeneralStats.Columns.Add( "Hot Win 1 in X", "Hot Win 1 in X" );					// 12
			dataGridViewGeneralStats.Columns.Add( "Hot Win Cards", "Hot Win Cards" );					// 13
			dataGridViewGeneralStats.Columns.Add( "Hot Win % (Cards)", "Hot Win % (Cards)" );			// 14
			dataGridViewGeneralStats.Columns.Add( "Hot Win 1 in X (Cards)", "Hot Win 1 in X (Cards)" );	// 15
#if null
			List<String> strings = new List<string>();
			strings.Add( "Year" );   //0
			strings.Add( "Day" );  //1
			strings.Add( "Hall" );   //2
			strings.Add( "Session" );  //3
			strings.Add( "Game" );  //4
			strings.Add( "Card" );  //5 
			strings.Add( "Total Cards" );  //6
			strings.Add( "Total Wins" );//7
			strings.Add( "Win %" );//8
			strings.Add( "Win 1 in X" );//9
			strings.Add( "Hot Wins" );
			strings.Add( "Hot Win %" );
			strings.Add( "Hot Win 1 in X" );
			strings.Add( "Hot Win Cards" );
			strings.Add( "Hot Win % (Cards)" );
			strings.Add( "Hot Win 1 in X (Cards)" );
            dataGridViewGeneralStats.Rows.Add( strings.ToArray() );

#endif
			// add a blank row under this one.
            dataGridViewGeneralStats.Rows.Add();

            int col_width = (int)(TextRenderer.MeasureText("WWWWWWW", DataGridView.DefaultFont).Width / 1.75);

            dataGridViewHotBallWins.RowHeadersVisible = false;

            dataGridViewHotBallWins.Columns.Add("Game", "Game");
            dataGridViewHotBallWins.Columns.Add( "Plays", "Plays" );
            dataGridViewHotBallWins.Columns["Plays"].Width = col_width;
            dataGridViewHotBallWins.Columns["Plays"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewHotBallWins.Columns["Plays"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewHotBallWins.Columns.Add("Wins", "Wins");
            dataGridViewHotBallWins.Columns["Wins"].Width = col_width;
            dataGridViewHotBallWins.Columns["Wins"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewHotBallWins.Columns["Wins"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

			int bingo_width = (int)( TextRenderer.MeasureText( "WWWWWWWWWWWWWWW", DataGridView.DefaultFont ).Width / 1.75 );

			if( runinfo.colored_balls > 0 )
			{
				int newcol;
				int n;
				for( n = 0; n < runinfo.colored_balls; n++ )
				{
					newcol = dataGridViewHotBallWins.Columns.Add( "Colored Bingo ball " + n, (n+1)+" ClrBall(s)" );
					dataGridViewHotBallWins.Columns[newcol].Width = bingo_width;
					dataGridViewHotBallWins.Columns[newcol].SortMode = DataGridViewColumnSortMode.NotSortable;
					dataGridViewHotBallWins.Columns[newcol].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
					dataGridViewHotBallWins.Columns[newcol].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
				}
				newcol = dataGridViewHotBallWins.Columns.Add( "Colored Bingo ball immediate before", "ClrBall B4 Win" );
				dataGridViewHotBallWins.Columns[newcol].Width = bingo_width;
				dataGridViewHotBallWins.Columns[newcol].SortMode = DataGridViewColumnSortMode.NotSortable;
				dataGridViewHotBallWins.Columns[newcol].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
				dataGridViewHotBallWins.Columns[newcol].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
			}

            if (runinfo.flags.countColorBINGO)
            {
                dataGridViewHotBallWins.Columns.Add("Color Bingo", "Color Bingo");
                dataGridViewHotBallWins.Columns["Color Bingo"].Width = bingo_width;
                dataGridViewHotBallWins.Columns["Color Bingo"].SortMode = DataGridViewColumnSortMode.NotSortable;
                dataGridViewHotBallWins.Columns["Color Bingo"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridViewHotBallWins.Columns["Color Bingo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            if (runinfo.flags.Count_BINGO_Calls)
            {
                dataGridViewHotBallWins.Columns.Add("BINGO(Calls)", "BINGO(Calls)");
                dataGridViewHotBallWins.Columns["BINGO(Calls)"].Width = bingo_width;
                dataGridViewHotBallWins.Columns["BINGO(Calls)"].SortMode = DataGridViewColumnSortMode.NotSortable;
                dataGridViewHotBallWins.Columns["BINGO(Calls)"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridViewHotBallWins.Columns["BINGO(Calls)"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridViewHotBallWins.Columns.Add("BINGO(ordered)", "BINGO(ordered)");
                dataGridViewHotBallWins.Columns["BINGO(ordered)"].SortMode = DataGridViewColumnSortMode.NotSortable;
                dataGridViewHotBallWins.Columns["BINGO(ordered)"].Width = bingo_width;
                dataGridViewHotBallWins.Columns["BINGO(ordered)"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridViewHotBallWins.Columns["BINGO(ordered)"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            bingo_width = (int)(TextRenderer.MeasureText("WWWWWWWWWWWWWWWW", DataGridView.DefaultFont).Width / 1.75);
            if (runinfo.flags.starburst)
            {
                dataGridViewHotBallWins.Columns.Add("Starburst(Win)", "Starburst(win)");
                dataGridViewHotBallWins.Columns["Starburst(Win)"].Width = bingo_width;
                dataGridViewHotBallWins.Columns["Starburst(Win)"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridViewHotBallWins.Columns["Starburst(Win)"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridViewHotBallWins.Columns.Add("Starburst(mark)", "Starburst(mark)");
                dataGridViewHotBallWins.Columns["Starburst(mark)"].Width = bingo_width;
                dataGridViewHotBallWins.Columns["Starburst(mark)"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridViewHotBallWins.Columns["Starburst(mark)"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            col_width = (int)(TextRenderer.MeasureText("WWWWWWWWWW", DataGridView.DefaultFont).Width / 1.75);
            dataGridViewHotBallWins.Columns.Add("1 Hotball", "1 Hotball");
            dataGridViewHotBallWins.Columns["1 Hotball"].Width = col_width;
            dataGridViewHotBallWins.Columns["1 Hotball"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridViewHotBallWins.Columns["1 Hotball"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewHotBallWins.Columns["1 Hotball"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewHotBallWins.Columns.Add("2 Hotballs", "2 Hotballs");
            dataGridViewHotBallWins.Columns["2 Hotballs"].Width = col_width;
            dataGridViewHotBallWins.Columns["2 Hotballs"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewHotBallWins.Columns["2 Hotballs"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewHotBallWins.Columns.Add("3 Hotballs", "3 Hotballs");
            dataGridViewHotBallWins.Columns["3 Hotballs"].Width = col_width;
            dataGridViewHotBallWins.Columns["3 Hotballs"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewHotBallWins.Columns["3 Hotballs"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewHotBallWins.Columns.Add("4 Hotballs", "4 Hotballs");
            dataGridViewHotBallWins.Columns["4 Hotballs"].Width = col_width;
            dataGridViewHotBallWins.Columns["4 Hotballs"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewHotBallWins.Columns["4 Hotballs"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewHotBallWins.Columns.Add("5 Hotballs", "5 Hotballs");
            dataGridViewHotBallWins.Columns["5 Hotballs"].Width = col_width;
            dataGridViewHotBallWins.Columns["5 Hotballs"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewHotBallWins.Columns["5 Hotballs"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

			dataGridViewTriggerBallStats.AllowUserToAddRows = false;
			dataGridViewTriggerBallStats.RowHeadersVisible = false;
			dataGridViewTriggerBallStats.Columns.Add( "Sessions", "Sessions" );
			dataGridViewTriggerBallStats.Columns[0].Width = 48;
			dataGridViewTriggerBallStats.Columns.Add( "Games", "Games" );
			dataGridViewTriggerBallStats.Columns[1].Width = 64;
			dataGridViewTriggerBallStats.Columns.Add( "Cashball win", "Cashball" );
			dataGridViewTriggerBallStats.Columns[2].Width = 48;
			for( int n = 1; n <= ori.trigger_stats.max_triggered; n++ )
			{
				int col;
				col = dataGridViewTriggerBallStats.Columns.Add( "Trigger " + n, "Trigger " + n );
				dataGridViewTriggerBallStats.Columns[col].Width = 36;
				col = dataGridViewTriggerBallStats.Columns.Add( "Win " + n, "Win " + n );
				dataGridViewTriggerBallStats.Columns[col].Width = 36;
			}
			object[] trigger_defaults = new object[dataGridViewTriggerBallStats.Columns.Count];
			for( int n = 0; n < dataGridViewTriggerBallStats.Columns.Count; n++ )
				trigger_defaults[n] = 0;
			this.dataGridViewTriggerBallStats.Rows.Add( trigger_defaults );

			//System.Data.DataTable patterns_table = OpenSkieScheduler.OpenSkieSchedule.data.patterns;// FlashboardDriver.GetPatternTable();
#if sadfsdf
            for( int game = 0; game < runinfo.GameTypeList.Count; game++ )
            {
                int check = 0;
                for( check = 0; check < runinfo.bingo_session.GameList.Count; check++ )
                    if( runinfo.bingo_session.GameList[check].game_ID == game )
                        break;

                int rowid = this.dataGridViewHotBallWins.Rows.Add();
                DataRow[] rows = patterns_table.Select( "pattern_id=" + runinfo.bingo_session.GameList[check].patterns[0].ID.ToString() );
                if( rows.Length > 0 )
                    this.dataGridViewHotBallWins.Rows[rowid].Cells[0].Value 
                        = rows[0][OpenSkieScheduler.OpenSkieSchedule.data.patterns.Name];
            }
#endif
            dataGridView1.RowHeadersVisible = false;

            dataGridView1.EditMode = DataGridViewEditMode.EditProgrammatically;

            dataGridView1.Columns.Add( "Balls", "Balls" );
			dataGridView1.Columns[0].Width = 40;
            dataGridView1.Columns.Add( "Wins", "Wins" );
			dataGridView1.Columns[1].Width = 40;
			dataGridView1.Columns.Add( "MultWins", "Mult Wins" );
			dataGridView1.Columns[2].Width = 40;
			dataGridView1.Columns.Add( "WinPercent", "Win %" );
			dataGridView1.Columns[3].Width = 40;
			dataGridView1.Columns.Add( "MultWinsPercent", "Mult Win %" );
			dataGridView1.Columns[4].Width = 40;
			dataGridView1.Columns.Add( "WinIn", "Win 1 in X" );
			dataGridView1.Columns[5].Width = 40;
			dataGridView1.Columns.Add( "TotalPercent", "Total %" );
			dataGridView1.Columns[6].Width = 40;

            if( runinfo.GameTypeList != null )
            for( int w = 0; w < runinfo.GameTypeList.Count; w++ )
            {
                dataGridViewHotBallWins.Rows.Add();
                dataGridViewHotBallWins[0, w].Value = runinfo.GameTypeList[w].name;
                if( runinfo.flags.simulate )
                {
                    dataGridView1.Columns.Add( "RealWins" + ( w + 1 ).ToString(), "Wins ("+runinfo.GameTypeList[w].name+")" );
                    dataGridView1.Columns.Add( "WinPercentCards" + ( w + 1 ).ToString(), "Win % (" + runinfo.GameTypeList[w].name + ")" );
                    dataGridView1.Columns.Add( "WinInCards" + ( w + 1 ).ToString(), "Win 1 in X (" + runinfo.GameTypeList[w].name + ")" );
                    dataGridView1.Columns.Add( "TotalPercentCards" + ( w + 1 ).ToString(), "Total % (" + runinfo.GameTypeList[w].name + ")" );
                    if( runinfo.flags.lastBall )
                    {
                        dataGridView1.Columns.Add( "TotalPercentBalls" + ( w + 1 ).ToString(), "Last Ball % (" + runinfo.GameTypeList[ w ].name + ")" );
                    }
                }
            }
            /*

            }
            /*
            if( ori.flags._5cashball )
            {
                dataGridView1.Columns.Add( "1 Hotball", "1 Hotball" );
                dataGridView1.Columns.Add( "2 Hotball", "2 Hotball" );
                dataGridView1.Columns.Add( "3 Hotball", "3 Hotball" );
                dataGridView1.Columns.Add( "4 Hotball", "4 Hotball" );
                dataGridView1.Columns.Add( "5 Hotball", "5 Hotball" );
            }
             * */

            object[] defaults = new object[this.dataGridView1.Columns.Count];
            for( int n = 0; n < dataGridView1.Columns.Count; n++ )
                defaults[n] = 0;

            for( int n = 1; n <= 75; n++ )
            {
                defaults[0] = n;
                this.dataGridView1.Rows.Add( defaults );
            }


            t.Interval = 100;
            t.Tick += new EventHandler( t_Tick );
            t.Enabled = true;

            thread_info = new Thread[start_threads];
            for( int thread = 0; thread < start_threads; thread++ )
            {
                thread_info[thread] = new Thread( PlayCards );
                thread_info[thread].Start( thread );
            }
        }
        Thread[] thread_info;// = new Thread[2];
        //Thread t2;




        void t_Tick( object sender, EventArgs e )
        {
            /* play a card here */
//            if( dtStart.AddMilliseconds( 1000.0 * tick ) < DateTime.Now )
            {
                double percent;
                double total = 0;
                double totalwins = 0;

                lock( runinfo )
                {
					if( runinfo.trigger_stats.enabled )
					{
						dataGridViewTriggerBallStats.Rows[0].Cells[0].Value = runinfo._total_sessions;
						dataGridViewTriggerBallStats.Rows[0].Cells[1].Value = runinfo._total_games;
						dataGridViewTriggerBallStats.Rows[0].Cells[2].Value = runinfo.trigger_stats.trigger_wins[0];
						for( int n = 1; n <= runinfo.trigger_stats.max_triggered; n++ )
						{
							dataGridViewTriggerBallStats.Rows[0].Cells[1 + n * 2].Value = runinfo.trigger_stats.triggered[n];
							dataGridViewTriggerBallStats.Rows[0].Cells[2 + n * 2].Value = runinfo.trigger_stats.trigger_wins[n];
						}
					}

                    dataGridViewGeneralStats.Rows[0].Cells[0].Value = ( runinfo._years ).ToString();
                    dataGridViewGeneralStats.Rows[0].Cells[1].Value = ( runinfo._days ).ToString();
                    dataGridViewGeneralStats.Rows[0].Cells[2].Value = ( runinfo._halls ).ToString();
                    dataGridViewGeneralStats.Rows[0].Cells[3].Value = ( runinfo._sessions ).ToString();
                    dataGridViewGeneralStats.Rows[0].Cells[4].Value = ( runinfo._games ).ToString();
                    dataGridViewGeneralStats.Rows[0].Cells[5].Value = ( runinfo._cards ).ToString();

                    // this used to be TotalCount
                    dataGridViewGeneralStats.Rows[0].Cells[6].Value = runinfo.TotalCards.ToString();
                    dataGridViewGeneralStats.Rows[0].Cells[7].Value = runinfo.TotalWins.ToString();
                    dataGridViewGeneralStats.Rows[0].Cells[8].Value =
                        ( runinfo.TotalCount == 0 ) ? "0" : ( runinfo.TotalWins * 100.0 / runinfo.TotalCount ).ToString();
                    dataGridViewGeneralStats.Rows[0].Cells[9].Value =
                        ( runinfo.TotalWins == 0 ) ? "0" : ( ( double )runinfo.TotalCount / runinfo.TotalWins ).ToString();
                    dataGridViewGeneralStats.Rows[0].Cells[10].Value = runinfo.hotwins.ToString();
                    dataGridViewGeneralStats.Rows[0].Cells[11].Value =
                        ( runinfo.TotalCount == 0 ) ? "0" : ( runinfo.hotwins * 100.0 / runinfo.TotalCount ).ToString();
                    dataGridViewGeneralStats.Rows[0].Cells[12].Value =
                        ( runinfo.hotwins == 0 ) ? "0" : ( ( double )runinfo.TotalCount / runinfo.hotwins ).ToString();
                    dataGridViewGeneralStats.Rows[0].Cells[13].Value = runinfo.besthotwins.ToString();
                    dataGridViewGeneralStats.Rows[0].Cells[14].Value =
                        ( runinfo.TotalWins == 0 ) ? "0" : ( runinfo.besthotwins * 100.0 / runinfo.TotalWins ).ToString();
                    dataGridViewGeneralStats.Rows[0].Cells[15].Value =
                        ( runinfo.besthotwins == 0 ) ? "0" : ( ( double )runinfo.TotalWins / runinfo.besthotwins ).ToString();

                    labelTotal.Text = runinfo.TotalCount.ToString();
                    labelDays.Text = runinfo._days.ToString();
                    labelYear.Text = runinfo._years.ToString();
                    labelHall.Text = runinfo._halls.ToString();
                    labelSession.Text = runinfo._sessions.ToString();
                    labelCard.Text = runinfo._cards.ToString();
                    labelTotalWins.Text = runinfo.TotalWins.ToString();
                    labelTotalWinPercent.Text =
                        ( runinfo.TotalCount == 0 ) ? "0" : ( runinfo.TotalWins * 100.0 / runinfo.TotalCount ).ToString();
                    labelTotalInX.Text =
                        ( runinfo.TotalWins == 0 ) ? "0" : ( ( double )runinfo.TotalCount / runinfo.TotalWins ).ToString();

                    // We need to increase the plays and some other stats, even if there are now winners
                    // if( runinfo.TotalCount > 0 )
                    {
                        this.dataGridViewHotBallWins.EditMode = DataGridViewEditMode.EditProgrammatically;
                        for( int game = 0; game < runinfo.GameTypeList.Count; game++ )
                        {

                            this.dataGridViewHotBallWins.Rows[game].Cells[1].Value = runinfo.GameTypeList[game].plays;
                            this.dataGridViewHotBallWins.Rows[game].Cells[2].Value = runinfo.GameTypeList[game].wins;

							if( runinfo.colored_balls > 0 )
							{
								int idx = this.dataGridViewHotBallWins.Columns["Colored Bingo ball 0"].Index;

								this.dataGridViewHotBallWins.Rows[game].Cells[idx + 0].Value = runinfo.GameTypeList[game].BINGO_Same_Color;
								int n;
								for( n = 0; n < runinfo.colored_balls; n++ )
								{
									this.dataGridViewHotBallWins.Rows[game].Cells[idx + n].Value = runinfo.GameTypeList[game].colored_ball_hit[n];
								}
								this.dataGridViewHotBallWins.Rows[game].Cells[idx + n].Value = runinfo.GameTypeList[game].colored_ball_before_win;
							}

							if( runinfo.flags.countColorBINGO )
                            {
                                int idx = this.dataGridViewHotBallWins.Columns["Color Bingo"].Index;
                                this.dataGridViewHotBallWins.Rows[game].Cells[idx + 0].Value = runinfo.GameTypeList[game].BINGO_Same_Color;
                            }

                            if( runinfo.flags.Count_BINGO_Calls )
                            {
                                int idx = this.dataGridViewHotBallWins.Columns["BINGO(Calls)"].Index;
                                this.dataGridViewHotBallWins.Rows[game].Cells[idx + 0].Value = runinfo.GameTypeList[game].BINGO_Call_Wins;
                                this.dataGridViewHotBallWins.Rows[game].Cells[idx + 1].Value = runinfo.GameTypeList[game].BINGO_Call_Wins_ordered;
                            }

                            if( runinfo.flags.starburst )
                            {
                                int idx = this.dataGridViewHotBallWins.Columns["Starburst(win)"].Index;
                                this.dataGridViewHotBallWins.Rows[game].Cells[idx + 0].Value = runinfo.GameTypeList[game].starburst_wins;
                                this.dataGridViewHotBallWins.Rows[game].Cells[idx + 1].Value = runinfo.GameTypeList[game].starburst_marks;
                            }

                            //if( runinfo.game_event.playing_hotballs != null )
                            //{
                            //    int idx = this.dataGridViewHotBallWins.Columns["1 Hotball"].Index;
                            //    for( int ball = 0; ball < runinfo.game_event.playing_hotballs.Length; ball++ )
                            //        this.dataGridViewHotBallWins.Rows[game].Cells[idx + ball].Value = runinfo.hotball_wins[game, ball];
                            //}
                        }


                        //if( false ) // skip this factor... just logging database...
                        for( int n = 0; n < 75; n++ )
                        {
                            int col = 1;

                            this.dataGridView1.Rows[n].Cells[col++].Value = runinfo.wins[n];
                            this.dataGridView1.Rows[n].Cells[col++].Value = runinfo.bestwins[n];

                            percent = ( runinfo.TotalCount == 0 ) ? 0 : ( (double)runinfo.wins[n] ) / runinfo.TotalCount;
                            total += runinfo.wins[n];
                            this.dataGridView1.Rows[n].Cells[col++].Value = percent * 100;
                            this.dataGridView1.Rows[n].Cells[col++].Value =
                                ( runinfo.wins[ n ] == 0 ) ? 0 : ( ( runinfo.bestwins[ n ] - runinfo.wins[ n ] ) * 100.0 ) / runinfo.wins[ n ];

                            this.dataGridView1.Rows[n].Cells[col++].Value =
                                ( percent == 0 ) ? 0 : 1.0 / percent;
                            this.dataGridView1.Rows[n].Cells[col++].Value =
                                ( runinfo.TotalCount == 0 ) ? 0 : total * 100 / runinfo.TotalCount;

                        }
                        for( int win = 0; win < runinfo.GameTypeList.Count; win++ )
                        {
                            totalwins = 0;
                            for( int n = 0; n < 75; n++ )
                            {

                                int col = 7 + ( 4 + ( runinfo.flags.lastBall ? 1 : 0 ) ) * win;

                                this.dataGridView1.Rows[n].Cells[col++].Value = runinfo.GameTypeList[win].best_wins[n];

                                percent = ( runinfo.GameTypeList[win].wins == 0 ) ?
                                    0 : ( (double)runinfo.GameTypeList[win].best_wins[n] ) / runinfo.GameTypeList[win].wins;

                                this.dataGridView1.Rows[n].Cells[col++].Value = percent * 100;
                                this.dataGridView1.Rows[n].Cells[col++].Value = ( percent == 0 ) ? 0 : 1 / percent;

                                totalwins += runinfo.GameTypeList[win].best_wins[n];

                                this.dataGridView1.Rows[n].Cells[col++].Value =
                                    ( runinfo.GameTypeList[win].wins == 0 ) ? 0 : totalwins * 100 / runinfo.GameTypeList[win].wins;

                                if( runinfo.flags.lastBall )
                                {
                                    int count = runinfo.GameTypeList[win].lastBalls[n];
                                    sb.Length = 0;
                                    if( count > 0 )
                                    {
                                        sb.AppendFormat( "{0}{1}  ({2:0.000000})",
                                            ( "BINGO"[ n / 15 ] ).ToString(),
                                            ( n + 1 ),
                                            ( runinfo.GameTypeList[ 0 ].plays == 0 || count == 0 ) ? 
                                                0.0 : ( 100.00 / runinfo.GameTypeList[ 0 ].plays ) * count );
                                    }
                                    else
                                    {
                                        sb.AppendFormat( "{0}{1}", ( "BINGO"[ n / 15 ] ).ToString(), ( n + 1 ) );
                                    }
                                    this.dataGridView1.Rows[n].Cells[col++].Value = sb.ToString();
                                }
                            }
                        }
                    }

                    this.labelHotWins.Text = runinfo.hotwins.ToString();
                    this.labelHotWinPercent.Text =
                        ( runinfo.TotalCount == 0 ) ? "0" : ( runinfo.hotwins * 100.0 / runinfo.TotalCount ).ToString();
                    labelHot1inX.Text =
                        ( runinfo.hotwins == 0 ) ? "0" : ( (double)runinfo.TotalCount / runinfo.hotwins ).ToString();

                    this.labelHotWins2.Text = runinfo.besthotwins.ToString();
                    this.labelHotWinPercent2.Text =
                        ( runinfo.TotalWins == 0 ) ? "0" : ( runinfo.besthotwins * 100.0 / runinfo.TotalWins ).ToString();
                    label1HotCards1inX.Text = 
                        ( runinfo.besthotwins == 0 ) ? "0" : ( (double)runinfo.TotalWins / runinfo.besthotwins ).ToString();
                }
                tick++;
            }

        }

        //private static Thread waitBoxThread;
        public  static Thread rateRankThread = null;
        private static WaitBox waitBox = null;

        private void RunDetails_FormClosing( object sender, FormClosingEventArgs e )
        {
            //Cursor.Current = Cursors.WaitCursor;

            runinfo.end = true;
            paused = false;
            while( threads > 0 )
            {
                Thread.Yield();
                Thread.Sleep( 50 );
            }
            
            for( int thread = 0; thread < thread_info.Length; thread++ )
            {
                if (thread_info[thread].ThreadState != ThreadState.Stopped)
                {
                    thread_info[thread].Interrupt();
                    thread_info[thread].Abort();
                }
                thread_info[thread] = null;
            }

            // dispose the timer object too.
            t.Enabled = false;
            t.Dispose();

            // Ask if user wants to update
            DialogResult updateResponse;
            updateResponse = MessageBox.Show(
                "Do you want to update the bingo card ranking database?\n(This process could take several minutes.)",
                "Updating Ranking Data",
                MessageBoxButtons.YesNo );

            if( updateResponse == DialogResult.No )
                return;

            // Put RateRank on it's own thread so we can have more
            // control over the processing of the WaitBox
            rateRankThread = new Thread( new ThreadStart( RateRankProc ) );
            rateRankThread.Start();

            waitBox = new WaitBox();
            waitBox.Cursor = Cursors.Default;
            waitBox.ShowDialog();
            waitBox.Close();

            if( rateRankThread != null && rateRankThread.IsAlive )
                //rateRankThread.ThreadState != ThreadState.Stopped)
            {
                rateRankThread.Interrupt();
                rateRankThread.Abort();
            }
            rateRankThread = null;

            return;
        }

        private static void RateRankProc( )
        {
            RateRank.UpdateRanks();

            if( waitBox.waitBoxThread.IsAlive )
            {
                waitBox.SetStopped();
                Thread.Sleep(600);
            }

            waitBox.Invoke( ( MethodInvoker )delegate
            {
                waitBox.Close();
            } );
        }

        //-----------------------------------------------------------

        private void buttonPause_Click( object sender, EventArgs e )
        {
            paused = !paused;
            if( paused )
                buttonPause.Text = "Play";
            else
                buttonPause.Text = "Pause";
        }


        public static int DecodeAlpha( String s )
        {
            int number = 0;
            for( int i = 0; i <  s.Length; i++ )
            {
                number = number * 26 + Convert.ToInt32( s[0] - 'A' );
            }
            return number;
        }

        public static String encode_numeric( int n )
        {
            // see here I need to know length of N in base 26...
            StringBuilder sb = new StringBuilder();
            bool first = true;

			while( n > 0 )
            {
                if( first )
                    sb.Append( (char)( 'A' + ( n % 26 - 1 ) ) );
                else
                    sb.Append( (char)( 'A' + ( n % 26 - 1 ) ) );

				n /= 26;

                first = false;
            }

//            char[] result = new char[sb.Length];

//            for( int c = 0; c < sb.Length; c++ )
//                result[sb.Length-(c+1)] = sb[c];
//			  return new String( result );
			return sb.ToString();
        }


#if excel_linked

        public static void DumpIntoSheet( object[,] array, _Worksheet worksheet, int row, int col )
        {
			double width = 0;
			double cellWidth = 0;
			int columnAlphaTagLen = 0;
			//-----------------------------------------------------------------------
			// Adjust input row and col from 0 array offset to 1 spreadsheet offset
			//-----------------------------------------------------------------------
			row++;
			col++;

            string upperLeft = encode_numeric( col ) + row.ToString();
			string upperRight = encode_numeric( col + array.GetLength( 1 ) - 2 ) + row.ToString();
			string lowerLeft = encode_numeric( col ) + ( row + array.GetLength( 0 ) - 1 ).ToString();
            string lowerRight = encode_numeric( col + array.GetLength( 1 ) - 2 ) + ( row + array.GetLength( 0 ) - 1).ToString();

			columnAlphaTagLen = upperLeft.Length - row.ToString().Length;

            Range range3 = worksheet.get_Range( upperLeft, lowerRight );

			for( int column = 0; column < (array.GetLength( 1 ) - 1); column++ )
			{
				String tempStr = encode_numeric( column + 1 ) + "1";

				width = worksheet.Range[ tempStr, tempStr ].ColumnWidth;
				cellWidth = array[ 0, column ].ToString().Length;

				if( cellWidth > width )
					worksheet.Range[ tempStr, tempStr ].ColumnWidth = cellWidth;
			}

			// Column Headers
			worksheet.Range[ upperLeft, upperRight ].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
			worksheet.Range[ upperLeft, upperRight ].Interior.Color = Color.LightGray.ToArgb();

			// Cell boarders
			worksheet.Range[ upperLeft, lowerRight ].BorderAround();
			worksheet.Range[ upperLeft, lowerRight ].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;

			range3.Value2 = array;
        }

		/// <summary>
		/// Check to see if Microsoft.Office.Interop.Excel is loaded
		/// </summary>
		/// <returns>bool</returns>
		public static bool AssemblyExists( string assemblyName )
        {
			string[ ] strGacDir = new string[ 2 ];
			 strGacDir[ 0 ] = Environment.GetEnvironmentVariable( "windir" ) + "\\assembly\\GAC";
			 strGacDir[ 1 ] = Environment.GetEnvironmentVariable( "windir" ) + "\\assembly\\GAC_MSIL";
			string[ ] strDirs2;
			string[ ] strFiles;

			for( int dir = 0; dir < strGacDir.Length; dir++ )
			{
				string[ ] strDirs1 = System.IO.Directory.GetDirectories( strGacDir[ dir ] );

				foreach( string strDir1 in strDirs1 )
				{
					strDirs2 = System.IO.Directory.GetDirectories( strDir1 );

					if( strDir1.EndsWith( assemblyName ) )
					{
						foreach( string strDir2 in strDirs2 )
						{
							strFiles = System.IO.Directory.GetFiles( strDir2 );

							foreach( string strFile in strFiles )
							{
								if( strFile.EndsWith( assemblyName + ".dll" ) )
									return true;
							}
						}
					}
				}
			}
			return false;
		}

        private void button1_Click( object sender, EventArgs e )
        {
			// Check for Microsoft.Office.Interop.Excel loaded and ready
			int col = 0;
			int row = 0;

			if( AssemblyExists( "Microsoft.Office.Interop.Excel" ) == false )
				return;

			Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.Application();
			app.Visible = true;

            Workbooks workbooks = app.Workbooks;

            _Workbook workbook = workbooks.Add( XlWBATemplate.xlWBATWorksheet );
            Sheets sheets = workbook.Worksheets;
            _Worksheet worksheet = (_Worksheet)sheets.get_Item( 1 );

            lock( runinfo )
            {
				// dataGridView1 info to spreadsheet
				int rowCount = 75;
				int columnCount = this.dataGridView1.ColumnCount;
                object[ , ] array3 = new object[ rowCount + 1, columnCount + 1 ];

				for( col = 0; col < columnCount; col++ )
				{
					// COLUMN HEADERS
					array3[ 0, col ] = this.dataGridView1.Columns[ col ].HeaderText;

					// TABLE DATA
                    for( row = 0; row < rowCount; row++ )
						array3[ row + 1, col ] = this.dataGridView1[ col, row ].Value;
                }

                DumpIntoSheet( array3, worksheet, dataGridViewGeneralStats.RowCount + 2, 0 );

				// dataGridViewGeneralStats info to spreadsheet
				rowCount = this.dataGridViewGeneralStats.RowCount;
				columnCount = this.dataGridViewGeneralStats.ColumnCount;
				object[ , ] array4 = new object[ rowCount + 1, columnCount + 1 ];

				for( col = 0; col < columnCount; col++ )
				{
					// COLUMN HEADERS
					array4[ 0, col ] = this.dataGridViewGeneralStats.Columns[ col ].HeaderText;

					// TABLE DATA
					for( row = 0; row < rowCount; row++ )
						array4[ row + 1, col ] = this.dataGridViewGeneralStats[ col, row ].Value;
				}

				DumpIntoSheet( array4, worksheet, 0, 0 );

				// dataGridViewHotBallWins info to spreadsheet
				rowCount = this.dataGridViewHotBallWins.RowCount;
				columnCount = this.dataGridViewHotBallWins.ColumnCount;
				array4 = new object[ rowCount, columnCount + 1 ];

                //array4 = new object[runinfo.bingo_session.GameList.Count + 1, 6 + 6];

				for( col = 0; col < columnCount; col++ )
				{
					// COLUMN HEADERS
					array4[ 0, col ] = this.dataGridViewHotBallWins.Columns[ col ].HeaderText;

					// TABLE DATA
					for( row = 0; row < (rowCount - 1); row++ )
						array4[ row + 1, col ] = this.dataGridViewHotBallWins[ col, row ].Value;
				}

				DumpIntoSheet( array4, worksheet, this.dataGridViewGeneralStats.RowCount + 2, this.dataGridView1.ColumnCount + 1 );
            }
        }
#else
        private void button1_Click( object sender, EventArgs e )
        {
            MessageBox.Show( "Office interop not linked." );
        }
#endif
        private void button2_Click( object sender, EventArgs e )
        {
            if( last_state != null )
            {
                CardBrowsingForm cbf = new CardBrowsingForm( last_state );
                cbf.Show();
            }
        }
    }

}
