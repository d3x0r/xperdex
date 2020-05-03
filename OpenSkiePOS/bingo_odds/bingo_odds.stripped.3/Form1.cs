using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using bingo_odds;
using BingoGameCore4.Controls;
using OpenSkieScheduler3;
using OpenSkieScheduler3.BingoGameDefs;
using xperdex.classes;

namespace BingoGameCore4
{

	public partial class Form1 : Form
	{
		OddsRunInfo ori;

		DataTable GamePatternTable;
		DataTable GameGroups;

		DataTable Cardsets;

        Patterns patterns;

		ScheduleDataSet schedule;
        DataRow selected_session;
        void PoplateGameTable()
        {
            if( GamePatternTable == null )
            {
                GamePatternTable = new DataTable();
                GamePatternTable.TableName = "InputDataTable";
            }
            else
            {
                GamePatternTable.Clear();
                GamePatternTable.Columns.Clear();
            }
            DataColumn dc;

            dc = GamePatternTable.Columns.Add( "Pattern 1", schedule.patterns.Columns["pattern_id"].DataType );
            //dc = GamePatternTable.Columns.Add( "Pattern 2", schedule.patterns.Columns["pattern_id"].DataType );
            //dc = GamePatternTable.Columns.Add( "Pattern 3", schedule.patterns.Columns["pattern_id"].DataType );
            //dc = GamePatternTable.Columns.Add( "Pattern 4", schedule.patterns.Columns["pattern_id"].DataType );
            //dc = GamePatternTable.Columns.Add( "Pattern 5", schedule.patterns.Columns["pattern_id"].DataType );

            GamePatternTable.Columns.Add( "Rate Game", typeof( bool ) );

            GamePatternTable.Columns.Add( "Last Ball", typeof( bool ) );
            GamePatternTable.Columns.Add( "Progressive", typeof( bool ) );
            GamePatternTable.Columns.Add( "Double Action", typeof( bool ) );
            GamePatternTable.Columns.Add( "Starburst", typeof( bool ) );
            GamePatternTable.Columns.Add( "Hotball", typeof( bool ) );
            GamePatternTable.Columns.Add( "Hotball Count", typeof( int ) );
            GamePatternTable.Columns.Add( "# Cash Ball", typeof( int ) );
            GamePatternTable.Columns.Add( "Ignore Bs", typeof( bool ) );
            GamePatternTable.Columns.Add( "Ignore Is", typeof( bool ) );
            GamePatternTable.Columns.Add( "Ignore Ns", typeof( bool ) );
            GamePatternTable.Columns.Add( "Ignore Gs", typeof( bool ) );
            GamePatternTable.Columns.Add( "Ignore Os", typeof( bool ) );
            GamePatternTable.Columns.Add( "Extension", typeof( bool ) );
            GamePatternTable.Columns.Add( "Overlapped", typeof( bool ) );
            GamePatternTable.Columns.Add( "Game Group", typeof( int ) );
            GamePatternTable.Columns.Add( "Ball Timer", typeof( int ) );
			GamePatternTable.Columns.Add( "Upick Count", typeof( int ) );
			GamePatternTable.Columns.Add( "Colored Ball Count", typeof( int ) );

            radioRandomNumber.Select();

            if (selected_session != null)
            {
                {
                    DataRow[] games = selected_session.GetChildRows( schedule.session_games.ChildrenOfParent );
                    List<DataRow> groups = new List<DataRow>();
                    List<DataRow> packs = new List<DataRow>();
                    foreach( DataRow game in games )
                    {
                        DataRow[] tmp_groups = game.GetChildRows( "session_game_has_group" );
                        foreach( DataRow group in tmp_groups )
                        {
                            DataRow game_group = group.GetParentRow( "session_game_group_in_session_game" );
                            if( !groups.Contains( game_group ) )
                            {
                                groups.Add( game_group );
                                DataRow[] group_prizes = game_group.GetChildRows( "game_group_has_prize_level" );
                                foreach( DataRow group_prize in group_prizes )
                                {
                                    DataRow[] group_prize_packs = group_prize.GetChildRows( "game_group_prize_level_has_pack" );
                                    foreach( DataRow group_prize_pack in group_prize_packs )
                                    {
                                        // so here I have
                                        // pack
                                        // prize_level
                                        // game_group
                                        // game
                                        // session
                                        DataRow pack = group_prize_pack.GetParentRow( "pack_in_game_group_prize_level" );
                                        if( !packs.Contains( pack ) )
                                        {
                                            packs.Add( pack );
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            //GamePatternTable.Columns.Add( "Level 1 Prize", typeof( int ) );
            //GamePatternTable.Columns.Add( "Level 2 Prize", typeof( int ) );
            //GamePatternTable.Columns.Add( "Level 3 Prize", typeof( int ) );
            //GamePatternTable.Columns.Add( "Level 4 Prize", typeof( int ) );
            //GamePatternTable.Columns.Add( "Level 1 Prize", typeof( int ) );

        }

		public Form1()
		{
            DataRow[ ] drarray;
			BingoSQLTracking.BingoTracking.disable = true;

	
			schedule = new ScheduleDataSet( StaticDsnConnection.dsn );
			schedule.Create();
			schedule.Fill();

            schedule.patterns.DefaultView.Sort = "pattern_name ASC";
            schedule.sessions.DefaultView.Sort = "session_name ASC";

            patterns = new Patterns( schedule );

			ori = new OddsRunInfo( );

			InitializeComponent();

			Cardsets = new DataTable();
			Cardsets.TableName = "Cardset";
			Cardsets.Columns.Add( "Name", typeof( String ) );
			Cardsets.Columns.Add( "filename", typeof( string ) );
            Cardsets.Columns.Add( "original_row", typeof( DataRow ) );
			DataRow drx = Cardsets.NewRow();

			drx[0] = "<No Dealers Found>";
			drx[1] = null;
			Cardsets.Rows.Add( drx );
			foreach( DataRow row in schedule.cardset_ranges.Rows )
			{
				DataRow dr = Cardsets.NewRow();
				dr[0] = row[OpenSkieScheduler3.BingoGameDefs.CardsetRange.NameColumn];
				// skip the ',' string
				object o = row.GetParentRow( CardsetRange.CardsetInfoRelationName )["name"];
				if( o == null )
					dr[1] = DBNull.Value;
				else
					dr[1] = o;
                dr[2] = row;
				Cardsets.Rows.Add( dr );
			}

			Cardsets.AcceptChanges();

            PoplateGameTable();
		}

        BingoGameList GameList;

		void a_RowUpdating( object sender, System.Data.Common.RowUpdatingEventArgs e )
		{

			for( int i = 0; i < e.Row.ItemArray.Length; i++ )

				Console.WriteLine( i + " " + e.Row[i] as string );

			throw new Exception( "The method or operation is not implemented." );

		}

        bool Loaded;

        bool LoadGameInfoFromGrid()
        {
			if( !Loaded )
			{
				int game_number = 1;
				//int maxid = 0;
				OddsRunInfo.GameInfo prior_game = null;
				GameList = new BingoGameList();

				foreach( DataRow row in GamePatternTable.Rows )
				{
                    bool rate;
                    if ( !(rate = row["Rate Game"].Equals(DBNull.Value) ? false : Convert.ToBoolean(row["Rate Game"])) )
                        continue;

                    OddsRunInfo.GameInfo game = new OddsRunInfo.GameInfo();

                    game.patterns = new List<Pattern>();
					int pattern_col = GamePatternTable.Columns.IndexOf( "Pattern 1" );
                    ori.flags.lastBall = row[ "Last Ball" ].Equals( DBNull.Value ) ? false : Convert.ToBoolean( row[ "Last Ball" ] );
                    game.starburst = row[ "Starburst" ].Equals( DBNull.Value ) ? false : Convert.ToBoolean( row[ "Starburst" ] );
					if( game.starburst )
						ori.flags.starburst = true;
                    game.rate = rate;
                    //game.rate = row["Rate Game"].Equals( DBNull.Value ) ? false : Convert.ToBoolean( row["Rate Game"] );
                    game.ignore_b_balls = row["Ignore Bs"].Equals( DBNull.Value ) ? false : Convert.ToBoolean( row["Ignore Bs"] );
                    game.ignore_i_balls = row["Ignore Is"].Equals( DBNull.Value ) ? false : Convert.ToBoolean( row["Ignore Is"] );
                    game.ignore_n_balls = row["Ignore Ns"].Equals( DBNull.Value ) ? false : Convert.ToBoolean( row["Ignore Ns"] );
                    game.ignore_g_balls = row["Ignore Gs"].Equals( DBNull.Value ) ? false : Convert.ToBoolean( row["Ignore Gs"] );
                    game.ignore_o_balls = row["Ignore Os"].Equals( DBNull.Value ) ? false : Convert.ToBoolean( row["Ignore Os"] );
                    //if( !game.rate )
					//	continue;
					//game.hotball = row["Hotball"].Equals( DBNull.Value ) ? false : Convert.ToBoolean( row["Hotball"] );
					game.cashballs = row["# Cash Ball"].Equals( DBNull.Value ) ? 0 : Convert.ToInt32( row["# Cash Ball"] );
					game.progressive = row["Progressive"].Equals( DBNull.Value ) ? false : Convert.ToBoolean( row["Progressive"] );
					//game.double_action = row["Double Action"].Equals( DBNull.Value ) ? false : Convert.ToBoolean( row["Double Action"] );
					game.overlapped = row["Overlapped"].Equals( DBNull.Value ) ? false : Convert.ToBoolean( row["Overlapped"] );
					game.extension = row["Extension"].Equals( DBNull.Value ) ? false : Convert.ToBoolean( row["Extension"] );

					game.upick_size = row["Upick Count"].Equals( DBNull.Value ) ? 0 : Convert.ToInt32( row["Upick Count"] );
					game.number_colored = row["Colored Ball Count"].Equals( DBNull.Value ) ? 0 : Convert.ToInt32( row["Colored Ball Count"] );
					// extended games have a prior_game.

					if( game.extension )
					{
						if( prior_game == null )
							game.extension = false;
						game.prior_game = prior_game;
					}

					// if there is a prior game, then check that game to see if it was progressive or overlapped... if it is, then this has a prior.

					else if( prior_game != null && ( prior_game.progressive || prior_game.overlapped ) )
					{
						game.prior_game = prior_game;
						game.into = true; // set that we are the inot part of a progressive...
					}
					else
						game.prior_game = null;

					prior_game = game;

					// game group is 5... 

					// okay pattern is found by name and added offset... good.

					if( game.cashballs == 1 )
						ori.flags.hotball = true;

					if( game.cashballs == 5 )
						ori.flags._5cashball = true;

					Patterns tmp = new Patterns( schedule );
					for( int i = 0; i < 1; i++ )
					{
						object pattern_id = row[pattern_col + i];

						if( pattern_id != DBNull.Value )
						{

							DataRow[] rows = schedule.patterns.Select( "pattern_id='" + pattern_id + "'" );
							if( rows.Length > 0 )
								tmp.Add( new Pattern( rows[0], patterns ) );
						}
					}
					if( tmp.Count == 0 )
					{
						// otherwise we don't need (or want) patterns
						if( game.upick_size == 0 )
						{
							// no pattern, and not upick, drop the issue
							continue; // next game.
						}
						game.Name = "Upickem " + game.upick_size;
					}
					else
					{
						game.Name = tmp[0].Name;
						if( game.upick_size > 0 )
						{
							// this is a conflict.
						}
						game.SetPatterns( tmp.ToArray() );

					}

					game.game_number = game_number;

					bool found_match = false;

					// this shouldn't have to be initialized to zero here.

					// there won't be any in the list

					// so it will end up being assigned before the

					// location that the compiler throws a stupid warning

					game.game_ID = 0;
					int game_pattern_count = game.patterns.Count;

					// gamelist as null is okay, and just bails the loop.
					foreach( OddsRunInfo.GameInfo checkgame in GameList )
					{

						int i = 0;
						if( checkgame.patterns.Count == game_pattern_count )
							for( ; i < game_pattern_count; i++ )
							{
								if( !checkgame.patterns[i].ID.Equals( game.patterns[i].ID ) )
								{
									break;
								}
							}

						if( i == game_pattern_count )
						{
							found_match = true;
							game.game_ID = checkgame.game_ID;
							game.pattern_list = checkgame.pattern_list;
							game.stats = checkgame.stats;
							lock( game.stats )
							{
								game.stats.games++;
							}
							break;
						}
					}

					if( !found_match )
					// if it's still zero, didn't find one, so set one.
					{
						OddsRunInfo.GameTypeInfo stats = new OddsRunInfo.GameTypeInfo();
						///if( !ori.GameTypeList )
						if( ori.GameTypeList == null )
							ori.GameTypeList = new List<OddsRunInfo.GameTypeInfo>();
						stats.best_wins = new int[ori.bestwins.Length];
						stats.aways = new int[5];
						stats.games = 1; // one same game.
						stats.name = game.Name;
                        stats.lastBalls = new int[ 90 ];
						if( ori.colored_balls > 0 )
							stats.colored_ball_hit = new int[ori.colored_balls];
						ori.GameTypeList.Add( stats );
						game.stats = stats;
						game.game_ID = ori.GameTypeList.IndexOf( stats );
					}

					game.quickshot = ori.flags.quickshot;

					if( ( game.patterns.Count > 0 ) || ( game.upick_size > 0 ) )
					{
						GameList.Add( game );
					}
					else
						game = null; // just make sure we auto destruct this...
					game_number++;
				}

                //-------------------------------------------------------------
                // Check if user has selected a game/pattern
                //-------------------------------------------------------------
                if (GameList.Count <= 0)
                {
                    MessageBox.Show("Please select a Pattern and Game to Rate from the Game Grid before pressing 'Go'", "Missing Pattern");
                    return false;
                }

                ori.Games = GameList.Count;

				BingoGameGroup bgg = null;// new BingoGameGroup( Guid.NewGuid() );
				BingoDealer dealer;
				if( ori.dealer != null )
					dealer = ori.dealer;
				else
					dealer = BingoDealers.CreateSimpleDealer();
				foreach( BingoGame game in GameList )
				{
					if( bgg == null || !game.into )
					{
						bgg = new BingoGameGroup( Guid.NewGuid() );
						GameList.game_group_list.AddGameGroup( bgg );
						// add some packs to the game_group
						if( game.upick_size > 0 )
						{
							BingoDealer upick_dealer = BingoDealers.CreateUpickDealer( game.upick_size );
							BingoPack upick_pack = GameList.CreatePack( upick_dealer, "Fictional UPick " + game.upick_size, ori.Cards );
							upick_pack.face_size = game.upick_size;
							upick_pack.flags.upickem = true;
							if( !upick_pack.game_groups.Contains( bgg ) )
								upick_pack.game_groups.Add( bgg );
							bgg.packs.Add( upick_pack );
						}
						else
						{
							BingoPack pack = GameList.CreatePack( dealer, "Fictional Pack", ori.PackSize );
							pack.game_groups.Add( bgg );
							bgg.packs.Add( pack );
						}
					}
					bgg.Add( game );
					game.game_group = bgg;
					if( game.pack_card_counts.Count < 1 )
						game.pack_card_counts.Add( ori.Cards );
				}
				ori.bingo_session = new BingoSession( GameList );
                ori.bingo_session.session_name = "Odds Run Info";
            }
            return true;
        }

		bool BuildRunInfo( bool one_session )
		{

			if( ori == null )
			{
				ori = new OddsRunInfo( );
			}

#if this_loaded_player_tracking_for_phsycial_players
			BingoPlayers players = new BingoPlayers();
			DbDataReader reader = StaticDsnConnection.KindExecuteReader( "select card,sum(value) from player_track where bingoday="
				+ MySQLDataTable.MakeDateOnly( result.bingoday.AddYears( 2006 ).AddDays( 7 ).AddMonths( 5 ) )
				+ " and session=" + ( _sessions + 1 )
				+ " and card<>'000000000000000000'"
				+ " group by card" );
			if( reader.HasRows )
			{
				while( reader.Read() )
				{
					BingoPlayer player;
					players.Add( player = new BingoPlayer( reader.GetString( 0 ) ) );
					int spend = reader.GetInt32( 1 );
					for( int p = 0; p < ( spend / 2000 ); p++ )
					{
						BingoPack pack = GameList.pack_list.GetPack( true, Cards, "Fictional Pack" );
						PlayerPack played;
						pack.pack_set = p;
						player.played_packs.Add( played = new PlayerPack() );
						played.pack_info = pack;
						played.player = player;
						played.game_list = GameList;
					}
				}
			}
#endif
			if( ori.trigger_stats.enabled = checkBoxTriggerBalls.Checked )
			{
				ori.trigger_stats.max_triggered = Convert.ToInt32( textBoxMaxTriggered.Text );
				ori.trigger_stats.triggered = new int[ori.trigger_stats.max_triggered + 1];
				ori.trigger_stats.trigger_wins = new int[ori.trigger_stats.max_triggered + 1];
			}
			if( one_session )
			{
				ori.Years = 1;
				ori.Days = 1;
				ori.Sessions = 1;
				ori.Halls = 1;
				ori.Players = Convert.ToInt32( textBoxPlayers.Text );
				ori.Cards = Convert.ToInt32( textBoxCards.Text );
				// this will be overridden later, if external game grid is used.
				ori.Games = Convert.ToInt32( textBoxGames.Text );
			}
			else
			{
				ori.Years = Convert.ToInt32( textBoxYears.Text );
				ori.Days = Convert.ToInt32( textBoxDays.Text );

				//move all days into the day counter
				// the DateTime thing will take just adding days.
				ori.Days = ori.Years * ori.Days;
				ori.Years = 1;

				ori.Sessions = Convert.ToInt32( textBoxSessions.Text );
				ori.Halls = Convert.ToInt32( textBoxHalls.Text );
				ori.Players = Convert.ToInt32( textBoxPlayers.Text );
				ori.Cards = Convert.ToInt32( textBoxCards.Text );
				// this will be overridden later, if external game grid is used.
				ori.Games = Convert.ToInt32( textBoxGames.Text );
			}

			ori.colored_balls = textBoxColorBallCount.Text.Length > 0 ? Convert.ToInt32( textBoxColorBallCount.Text ) : 0;

			ori.flags.use_blower = radioBallBlower.Checked;
			ori.flags.database_run = checkBoxDatabase.Checked;

			ori.flags.save_winning_cards = checkBoxSaveWinningCards.Checked;
			ori.flags.Count_BINGO_Calls = checkBoxCountBINGOCalls.Checked;
			ori.flags.countColorBINGO = checkBoxCountColorBINGO.Checked;
			ori.flags.quickshot = checkBoxQuickshot.Checked;

			ori.flags.starburst = checkBoxStarburst.Checked;
			ori.flags.simulate = checkBoxSimulate.Checked;
			ori.flags.only_simulate = true;

			// this will be overridden later, if external game grid is used.
			ori.flags.hotball = checkBoxHotball.Checked;

			// this will be overridden later, if external game grid is used.
			ori.flags._5cashball = checkBox5Hotball.Checked;

			ori.PackSize = Convert.ToInt32( textBoxPackSize.Text );
			if( ( ori.Cards / ori.PackSize ) * ori.PackSize != ori.Cards )
			{
				ori = null;
				MessageBox.Show( "Cards does not divide by Pack Size evenly..." );
				return false;
			}

            if( comboBox1.SelectedItem != null )
            {
                String name = (comboBox1.SelectedItem as DataRowView).Row["name"].ToString();
                if( name != null && name.Length > 0 )
                {
                    try
                    {
                        DataRow row = ( comboBox1.SelectedItem as DataRowView ).Row;
                        DataRow original = row["original_row"] as DataRow;
						if( original != null )
							ori.dealer = BingoDealers.GetDealer( original );
                        //ori.cardreader = new CardReader( row["original_row"] as DataRow );
                        //if( ori.cardreader.Length != 0 )
                        //	ori.flags.cardfile = true;
                    }
                    catch { }
                }
                else
                    ori.dealer = BingoDealers.nodealer;
            }
            else
                ori.dealer = BingoDealers.nodealer;

			if( !LoadGameInfoFromGrid() )
				return false;

			return true;
		}



		void Go( bool one_session )
		{
			if( !BuildRunInfo( one_session ) )
				return;
			ori.BeginRun();

			{ // setup ball data interface to support colored balls.
				ori.ball_data_interface = new BallData_Random75( 75 );
				if( ori.colored_balls > 0 )
				{
					int[] newballs = new int[ori.colored_balls];
					int n;
					for( n = 0; n < ori.colored_balls; n++ )
						newballs[n] = -1 - n;
					ori.ball_data_interface.AddExtraBalls( newballs );
				}
			}

			RunDetails rd = new RunDetails( ori, Convert.ToInt32( this.textBoxThreadCount.Text ) );
			rd.ShowDialog();
			rd.Dispose();
			ori = null;
		}


		private void buttonGo_Click( object sender, EventArgs e )
		{
			Go( false );
		}

		DataGridViewComboBoxColumn[] cols;

		void UpdateFormFromRunInfo()
		{
            
			textBoxYears.Text = ori.Years.ToString();
			textBoxDays.Text = ori.Days.ToString();
			textBoxSessions.Text = ori.Sessions.ToString();
			textBoxPlayers.Text = ori.Players.ToString();
			textBoxHalls.Text = ori.Halls.ToString();
			textBoxCards.Text = ori.Cards.ToString();
			textBoxGames.Text = ori.Games.ToString();
			checkBoxStarburst.Checked = ori.flags.starburst;
			checkBoxCountBINGOCalls.Checked = ori.flags.Count_BINGO_Calls;
            checkBoxCountColorBINGO.Checked = ori.flags.countColorBINGO;
			checkBoxTriggerBalls.Checked = ori.trigger_stats.enabled;
			textBoxMaxTriggered.Text = ori.trigger_stats.max_triggered.ToString();
			checkBoxSimulate.Checked = ori.flags.simulate;
			checkBoxHotball.Checked = ori.flags.hotball;
			checkBox5Hotball.Checked = ori.flags._5cashball;
			textBoxPackSize.Text = ori.PackSize.ToString();

			checkBoxDatabase.Checked = ori.flags.database_run;
			checkBoxSaveWinningCards.Checked = ori.flags.save_winning_cards;

            if( ori.dealer != null )
            {
                DataRow[] row = Cardsets.Select( "name='" + ori.dealer.ToString() + "'" );
                if( row.Length > 0 )
                {
                    comboBox1.SelectedIndex = row[0].Table.Rows.IndexOf( row[0] );
                    comboBox1.Enabled = true;
                    cardSetLabel.Enabled = true;
                }
            }
		}


		private void Form1_Load( object sender, EventArgs e )
		{
			Log.log( "loading" );
			DataTable test = new DataTable();// new MySQLDataTable( StaticDsnConnection.dsn, "select * from players_info" );
			Log.log( "loaded" );
			test.Clear();
			//DsnSQLUtil.FillDataTable( StaticDsnConnection.dsn, test );
			comboBox1.DataSource = Cardsets;
			comboBox1.ValueMember = "filename";
			comboBox1.DisplayMember = "Name";
			comboBox1.SelectedIndex = 0;

            if( Cardsets.Rows.Count == 1 && Cardsets.Rows[ 0 ][ 0 ].ToString().Equals( "<No Dealers Found>" ) )
            {
                comboBox1.Enabled = false;
                cardSetLabel.Enabled = false;
            }

            UpdateFormFromRunInfo();

			// doing this... the 'select' event on the table
			// causes both this and other lists to update.

    		dataGridViewGameSet.AutoGenerateColumns = false;
            dataGridViewGameSet.RowHeadersVisible = false;
            dataGridViewGameSet.DataSource = GamePatternTable;

            DataGridViewComboBoxColumn dgvcbc;
			cols = new DataGridViewComboBoxColumn[1];

			cols[0] = dgvcbc = new DataGridViewComboBoxColumn();

            int col_width = (int)(TextRenderer.MeasureText("WWWWWWWWWWWW", dgvcbc.HeaderCell.Style.Font).Width * 0.6);

            int combo_width = (dataGridViewGameSet.Width - col_width) / 5;

            dgvcbc.HeaderText = "Pattern 1";
			dgvcbc.DataSource = schedule.patterns;// array;// patterns.ToArray();
			dgvcbc.AutoComplete = true;
			dgvcbc.DataPropertyName = dgvcbc.HeaderText;
			dgvcbc.DisplayMember = PatternDescriptionTable.NameColumn;
			dgvcbc.ValueMember = "pattern_id";
            dgvcbc.Width = combo_width;
			dgvcbc.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox;
            dgvcbc.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
			dataGridViewGameSet.Columns.Add( dgvcbc );

			/*
			dgvcbc = new DataGridViewComboBoxColumn();
			dgvcbc.HeaderText = "Pattern 2";
			dgvcbc.DataSource = schedule.patterns;// array;// patterns.ToArray();
			dgvcbc.ValueType = typeof( Pattern );
			dgvcbc.AutoComplete = true;
			dgvcbc.DataPropertyName = dgvcbc.HeaderText;
			dgvcbc.DisplayMember = cols[0].DisplayMember;
			dgvcbc.ValueMember = "pattern_id";
            dgvcbc.Width = combo_width;
            dgvcbc.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox;
            dgvcbc.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewGameSet.Columns.Add(dgvcbc);

			dgvcbc = new DataGridViewComboBoxColumn();
			dgvcbc.HeaderText = "Pattern 3";
			dgvcbc.DataSource = schedule.patterns;// array;//patterns;
			dgvcbc.ValueType = typeof( Pattern );
			dgvcbc.AutoComplete = true;
			dgvcbc.DataPropertyName = dgvcbc.HeaderText;
			dgvcbc.DisplayMember = cols[0].DisplayMember;
			dgvcbc.ValueMember = "pattern_id";
            dgvcbc.Width = combo_width;
            dgvcbc.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox;
            dgvcbc.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
			dataGridViewGameSet.Columns.Add( dgvcbc );

			dgvcbc = new DataGridViewComboBoxColumn();
			dgvcbc.HeaderText = "Pattern 4";
			dgvcbc.DataSource = schedule.patterns;// array;//patterns;
			dgvcbc.ValueType = typeof( Pattern );
			dgvcbc.AutoComplete = true;
			dgvcbc.DataPropertyName = dgvcbc.HeaderText;
			dgvcbc.DisplayMember = cols[0].DisplayMember;
			dgvcbc.ValueMember = "pattern_id";
            dgvcbc.Width = combo_width;
            dgvcbc.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox;
            dgvcbc.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
			dataGridViewGameSet.Columns.Add( dgvcbc );

			dgvcbc = new DataGridViewComboBoxColumn();
			dgvcbc.HeaderText = "Pattern 5";
			dgvcbc.DataSource = schedule.patterns;// array;//patterns;
			dgvcbc.ValueType = typeof( Pattern );
			dgvcbc.AutoComplete = true;
			dgvcbc.DataPropertyName = dgvcbc.HeaderText;
			dgvcbc.DisplayMember = cols[0].DisplayMember;
			dgvcbc.ValueMember = "pattern_id";
            dgvcbc.Width = combo_width;
            dgvcbc.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox;
            dgvcbc.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewGameSet.Columns.Add(dgvcbc);
*/
            DataGridViewCheckBoxColumn check_col = new DataGridViewCheckBoxColumn();
            DataGridViewTextBoxColumn text_col;

            check_col = new DataGridViewCheckBoxColumn();
			check_col.HeaderText = "Rate Game";
			check_col.Name = "Rate Game";
			check_col.DataPropertyName = check_col.Name;
            check_col.Width = col_width;
            check_col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            check_col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewGameSet.Columns.Add(check_col);

            check_col = new DataGridViewCheckBoxColumn();
            check_col.HeaderText = "Last Ball";
            check_col.Name = "Last Ball";
            check_col.DataPropertyName = check_col.Name;
            check_col.Width = col_width;
            check_col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            check_col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewGameSet.Columns.Add( check_col );

            check_col = new DataGridViewCheckBoxColumn();
			check_col.HeaderText = "Starburst";
			check_col.Name = "Starburst";
			check_col.DataPropertyName = check_col.Name;
            check_col.Width = col_width;
            check_col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            check_col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewGameSet.Columns.Add(check_col);

			check_col = new DataGridViewCheckBoxColumn();
			check_col.HeaderText = "Hotball";
			check_col.Name = "Hotball";
			check_col.DataPropertyName = check_col.Name;
            check_col.Width = col_width;
            check_col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            check_col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewGameSet.Columns.Add(check_col);

			check_col = new DataGridViewCheckBoxColumn();
			check_col.HeaderText = "Progressive";
			check_col.Name = "Progressive";
			check_col.DataPropertyName = check_col.Name;
            check_col.Width = col_width;
            check_col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            check_col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewGameSet.Columns.Add(check_col);

			check_col = new DataGridViewCheckBoxColumn();
			check_col.HeaderText = "Extension";
			check_col.Name = "Extension";
			check_col.DataPropertyName = check_col.Name;
            check_col.Width = col_width;
            check_col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            check_col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewGameSet.Columns.Add(check_col);

			check_col = new DataGridViewCheckBoxColumn();
			check_col.HeaderText = "Double Action";
			check_col.Name = "Double Action";
			check_col.DataPropertyName = check_col.Name;
            check_col.Width = col_width;
            check_col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            check_col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewGameSet.Columns.Add(check_col);

			check_col = new DataGridViewCheckBoxColumn();
			check_col.HeaderText = "Overlapped";
			check_col.Name = "Overlapped";
			check_col.DataPropertyName = check_col.Name;
            check_col.Width = col_width;
            check_col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            check_col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewGameSet.Columns.Add(check_col);

            text_col = new DataGridViewTextBoxColumn();
            text_col.HeaderText = "# Cash Ball";
            text_col.Name = "# Cash Ball";
            text_col.DataPropertyName = text_col.Name;
            text_col.ValueType = typeof( int );
            text_col.Width = col_width;
            text_col.SortMode = DataGridViewColumnSortMode.NotSortable;
            text_col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            text_col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewGameSet.Columns.Add(text_col);

            check_col = new DataGridViewCheckBoxColumn();
            check_col.HeaderText = "Ignore Bs";
            check_col.Name = "Ignore Bs";
            check_col.DataPropertyName = check_col.Name;
            check_col.Width = col_width;
            check_col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            check_col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewGameSet.Columns.Add(check_col);

            check_col = new DataGridViewCheckBoxColumn();
            check_col.HeaderText = "Ignore Is";
            check_col.Name = "Ignore Is";
            check_col.DataPropertyName = check_col.Name;
            check_col.Width = col_width;
            check_col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            check_col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewGameSet.Columns.Add(check_col);

            check_col = new DataGridViewCheckBoxColumn();
            check_col.HeaderText = "Ignore Ns";
            check_col.Name = "Ignore Ns";
            check_col.DataPropertyName = check_col.Name;
            check_col.Width = col_width;
            check_col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            check_col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewGameSet.Columns.Add(check_col);

            check_col = new DataGridViewCheckBoxColumn();
            check_col.HeaderText = "Ignore Gs";
            check_col.Name = "Ignore Gs";
            check_col.DataPropertyName = check_col.Name;
            check_col.Width = col_width;
            check_col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            check_col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewGameSet.Columns.Add(check_col);

            check_col = new DataGridViewCheckBoxColumn();
            check_col.HeaderText = "Ignore Os";
            check_col.Name = "Ignore Os";
            check_col.DataPropertyName = check_col.Name;
            check_col.Width = col_width;
            check_col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            check_col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewGameSet.Columns.Add(check_col);

			text_col = new DataGridViewTextBoxColumn();
			text_col.HeaderText = "Upick Count";
			text_col.Name = "Upick Count";
			text_col.DataPropertyName = text_col.Name;
			text_col.ValueType = typeof( int );
			text_col.Width = col_width;
			text_col.SortMode = DataGridViewColumnSortMode.NotSortable;
			text_col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
			text_col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
			dataGridViewGameSet.Columns.Add( text_col );

			text_col = new DataGridViewTextBoxColumn();
			text_col.HeaderText = "Colored Ball Count";
			text_col.Name = "Colored Ball Count";
			text_col.DataPropertyName = text_col.Name;
			text_col.ValueType = typeof( int );
			text_col.Width = col_width;
			text_col.SortMode = DataGridViewColumnSortMode.NotSortable;
			text_col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
			text_col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
			dataGridViewGameSet.Columns.Add( text_col );

			DataGridViewTextBoxColumn dgvc = new DataGridViewTextBoxColumn();
			dgvc.HeaderText = "Level 1 Prize";
			dgvc.DataPropertyName = "Level 1 Prize";
			dgvc.ValueType = typeof( int );
            dgvc.SortMode = DataGridViewColumnSortMode.NotSortable;
            dgvc.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvc.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewGameSet.Columns.Add(dgvc);

			dgvcbc = new DataGridViewComboBoxColumn();
			dgvcbc.HeaderText = "Game Group";
			dgvcbc.DataSource = GameGroups;
			dgvcbc.AutoComplete = true;
			dgvcbc.DataPropertyName = dgvcbc.HeaderText;
			dgvcbc.DisplayMember = "Name";
			dgvcbc.ValueMember = "ID";
			dgvcbc.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox;
            dgvcbc.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewGameSet.Columns.Add(dgvcbc);

			dataGridViewGameSet.DataError += new DataGridViewDataErrorEventHandler( dataGridViewGameSet_DataError );

            textBoxYears.Select();
		}



		void dataGridViewGameSet_DataError( object sender, DataGridViewDataErrorEventArgs e )
		{
			//throw new Exception( "The method or operation is not implemented." );
		}



		void dataGridViewGameSet_RowsAdded( object sender, DataGridViewRowsAddedEventArgs e )
		{
			//dataGridViewGameSet.Rows[e.RowIndex].Cells["Pattern_1"].EditType
			//throw new Exception( "The method or operation is not implemented." );
		}



		private void buttonLoadConfig_Click( object sender, EventArgs e )
		{
			OpenFileDialog openFileDialog1 = new OpenFileDialog();
			openFileDialog1.Filter = "XML files (*.xml)|*.xml|All files (*.*)|*.*";
			openFileDialog1.FilterIndex = 1;
			//openFileDialog1.RestoreDirectory = true;

			if( openFileDialog1.ShowDialog() == DialogResult.OK )
			{

				GamePatternTable.Clear();
				GamePatternTable.ReadXml( openFileDialog1.FileName );

				if( ori != null )
				{
                    ori.ReadXml( openFileDialog1.FileName + ".Form", schedule.cardset_ranges );
					UpdateFormFromRunInfo();
				}
				else
					MessageBox.Show( "Somehow we're loading without a OddsRunInfo instance?!" );
			}
			openFileDialog1.Dispose();
		}



		private void buttonSaveGames_Click( object sender, EventArgs e )
		{

			SaveFileDialog openFileDialog1 = new SaveFileDialog();
			openFileDialog1.Filter = "XML files (*.xml)|*.xml|All files (*.*)|*.*";
			openFileDialog1.FilterIndex = 1;
			//openFileDialog1.RestoreDirectory = true;

			if( openFileDialog1.ShowDialog() == DialogResult.OK )
			{
				GamePatternTable.WriteXml( openFileDialog1.FileName, XmlWriteMode.IgnoreSchema, true );
				if( BuildRunInfo( false ) )
					ori.WriteXml( openFileDialog1.FileName + ".Form" );
			}

			openFileDialog1.Dispose();
		}

		private void buttonEditPatterns_Click( object sender, EventArgs e )
		{
			PatternEditor pe = new PatternEditor( schedule );
			pe.ShowDialog();
			pe.Dispose();
			schedule.Commit();
		}

		private void button2_Click( object sender, EventArgs e )
		{
			Go( true );
		}

		private void buttonLoadSession_Click( object sender, EventArgs e )
		{
			SessionSelector ss = new SessionSelector( schedule );
			DialogResult result = ss.ShowDialog();
			DataRow session = ss.Session;
			if( result == DialogResult.Cancel || session == null )
				return;
            //Loaded = true;
            selected_session = session;


            ori.bingo_session = new BingoSession( session );
			GameList = ori.bingo_session.GameList;

            {
                DataRow[] games;
                games = session.GetChildRows( "session_has_game" );
			    //schedule.session_macro_sessions.GetGames( session_macro, 1 );
			    GamePatternTable.Clear();
				// games is session_game
			    if( games != null )
			    foreach( DataRow game in games )
			    {
				    DataRow[] patterns = schedule.session_games.GetPatterns( game );
				    int n = 0;
				    DataRow newrow = GamePatternTable.NewRow();
				    foreach( DataRow pattern in patterns )
				    {
					    newrow[n] = pattern[PatternDescriptionTable.PrimaryKey];
					    n++;
				    }
				    newrow["Rate Game"] = true;
				    newrow["progressive"] = game["progressive"];
				    newrow["hotball"] = game["single_hotball"];
                    if( Convert.ToBoolean( game["single_hotball"] ) )
                        newrow["# Cash Ball"] = 1;
				    GamePatternTable.Rows.Add( newrow );				
			    }
    			GamePatternTable.AcceptChanges();
            }
		}

		private void button1_Click( object sender, EventArgs e )
		{
            new ScheduleDesigner.ScheduleDesigner(schedule).ShowDialog();
			//f.ShowDialog();

		}

		private void button4_Click(object sender, EventArgs e)
		{
			new OptionEditor(Options.File(null)).ShowDialog();
		}

        private void dataGridView_SizeChanged( object sender, System.EventArgs e )
        {
            label10.SetBounds(label10.Location.X, label10.Location.Y, dataGridViewGameSet.Size.Width, label10.Size.Height);
            label10.Refresh();
        }

    }

}

