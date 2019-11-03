using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using OpenSkieScheduler.Controls.Buttons;
using OpenSkieScheduler.Controls.Forms;
using OpenSkieScheduler.Controls;
using xperdex.classes;
using OpenSkieScheduler;
//using xperdex.core;
using System.Reflection;
using OpenSkie.Scheduler;
using OpenSkie.Scheduler.Controls;
using OpenSkieScheduler.Relations;
using OpenSkieScheduler.BingoGameDefs;

namespace ScheduleDesigner
{
	public partial class ScheduleDesigner : Form
	{
        ScheduleCurrents schedule_currents; 
		OpenSkieScheduler.ScheduleDataSet schedule;


		public ScheduleDesigner()
		{
            //OpenSkieSchedule.GamesRelateToSessions = true;
            //OpenSkieSchedule.UseGuid = true;
            //OpenSkieSchedule.PacksRelateToPrizes = true;
			schedule = new OpenSkieScheduler.ScheduleDataSet( StaticDsnConnection.dsn );
            schedule_currents = new ScheduleCurrents( schedule );
			schedule.Create();
			// this requires p2p events.
            //schedule.SetTableReload( FormTableUpdate );
            ControlList.schedule = schedule;
			ControlList.data = schedule_currents;
			schedule_currents = new ScheduleCurrents( schedule );
            InitializeComponent();
		}

		public ScheduleDesigner( OpenSkieScheduler.ScheduleDataSet schedule )
		{
            //schedule.SetTableReload( FormTableUpdate );
            this.schedule = schedule;
			schedule_currents = new ScheduleCurrents( schedule );

			ControlList.schedule = schedule;
			ControlList.data = schedule_currents;
			InitializeComponent();
		}

        DataTable current_colors;

		List<BindingSource> bindings;

        BindingSource BindingSourceSessionGameGroupGame;
        BindingSource BindingSourceSessionGame;
        BindingSource BindingSourcePack;
		BindingSource BindingSourcePrizeLevels;

		private void enableEditToolStripMenuItem_Click( object sender, EventArgs e )
		{
			EnableEdit.Enable( true );
		}

        delegate void InvokeFormTableUpdate( DataTable table );

        private void FormTableUpdate( DataTable table )
        {
            if( this.InvokeRequired )
            {
                this.Invoke( new InvokeFormTableUpdate( FormTableUpdate ), new object[] { table } );
            }
            else
                DsnSQLUtil.ReloadTable( StaticDsnConnection.dsn, table );
        }

		private void Form1_Load( object sender, EventArgs e )
		{
			FormClosing += new FormClosingEventHandler( ScheduleDesigner_FormClosing );
            tabControl1.TabPages.Remove( tabPage16 ); // Items
            //tabControl1.TabPages.Remove( tabPage15 ); // session -pack/prize ordering
            tabControl1.TabPages.Remove( tabPageTreeEditor ); // tree editor expiramental
            //tabControl1.TabPages.Remove( tabPageSessionBundles );
            //tabControl1.TabPages.Remove( tabPage6 );
            //tabControl1.TabPages.Remove( tabpage
			if( schedule.PacksRelateToPrizes )
			{
				tabControl1.TabPages.Remove( tabPageGameGroupPacks );
			}
            if( schedule.GamesInSessions )
            {
                tabControl1.TabPages.Remove( tabPageGameGroupsGames );
                tabControl1.TabPages.Remove( tabPageSessionGameGroupGameOrder );
                //                tabPage11.Hide();
            }
            else
            {
                tabControl1.TabPages.Remove( tabPageGameGameGroups );
                tabControl1.TabPages.Remove( tabPageSessionGame );
                //tabControl1.TabPages.Remove( tabPage1 );
            }

            //------------------------------------
            BindingSourceSessionGameGroupGame = new BindingSource();
            if( schedule.GamesInSessions )
                BindingSourceSessionGameGroupGame.DataSource = schedule.session_games;
            else
                BindingSourceSessionGameGroupGame.DataSource = schedule.session_game_group_game_order;

            textBoxGameNumber.DataBindings.Add( new Binding( "Text", BindingSourceSessionGameGroupGame, "game_number", true ) );
            textBoxBallTimer.DataBindings.Add( new Binding( "Text", BindingSourceSessionGameGroupGame, "ball_timer", true ) );
            checkBoxProgressive.DataBindings.Add( new Binding( "Checked", BindingSourceSessionGameGroupGame, "progressive", true ) );
            //checkBoxPoker.DataBindings.Add( new Binding( "Checked", BindingSourceSessionGameGroupGame, "poker", true ) );
            checkBoxHotball.DataBindings.Add( new Binding( "Checked", BindingSourceSessionGameGroupGame, "single_hotball", true ) );
            checkBoxBonanza.DataBindings.Add( new Binding( "Checked", BindingSourceSessionGameGroupGame, "bonanza", true ) );
            checkBoxOverlapped.DataBindings.Add( new Binding( "Checked", BindingSourceSessionGameGroupGame, "overlap_prior", true ) );
            //checkBoxGameDoubleAction.DataBindings.Add( new Binding( "Checked", BindingSourceSessionGameGroupGame, "double_action", true ) );
            checkBoxSingleWild.DataBindings.Add( new Binding( "Checked", BindingSourceSessionGameGroupGame, "wild", true ) );
            checkBoxDoubleWild.DataBindings.Add( new Binding( "Checked", BindingSourceSessionGameGroupGame, "double_wild", true ) );
            checkBoxBlind.DataBindings.Add( new Binding( "Checked", BindingSourceSessionGameGroupGame, "blind", true ) );


            //------------------------------------
            BindingSourceSessionGame = new BindingSource();
            BindingSourceSessionGame.DataSource = schedule.session_games;

            textBoxGameNumber2.DataBindings.Add( new Binding( "Text", BindingSourceSessionGame, "game_number", true ) );
            textBoxBallTimer2.DataBindings.Add( new Binding( "Text", BindingSourceSessionGame, "ball_timer", true ) );
            checkBoxProgressive2.DataBindings.Add( new Binding( "Checked", BindingSourceSessionGame, "progressive", true ) );
            checkBoxHotball2.DataBindings.Add( new Binding( "Checked", BindingSourceSessionGame, "single_hotball", true ) );
            checkBoxBonanza2.DataBindings.Add( new Binding( "Checked", BindingSourceSessionGame, "bonanza", true ) );
            checkBoxSingleWild2.DataBindings.Add( new Binding( "Checked", BindingSourceSessionGame, "wild", true ) );
            checkBoxDoubleWild2.DataBindings.Add( new Binding( "Checked", BindingSourceSessionGame, "double_wild", true ) );
            checkBoxBlind2.DataBindings.Add( new Binding( "Checked", BindingSourceSessionGame, "blind", true ) );
            comboBoxGameColor2.DataBindings.Add( new Binding( "SelectedValue", BindingSourceSessionGame
                , schedule.colors.PrimaryKeyName, true ) );
            //comboBoxGameColor2


			//------------------------------------

			BindingSourcePrizeLevels = new BindingSource();
			BindingSourcePrizeLevels.DataSource = schedule.prize_level_names;
			checkBoxLastBallWin.DataBindings.Add( new Binding( "Checked", BindingSourcePrizeLevels, "lastball_wins", true ) );
			checkBoxBallCountWin.DataBindings.Add( new Binding( "Checked", BindingSourcePrizeLevels, "ballcount_wins", true ) );
			checkBoxValueAdded.DataBindings.Add( new Binding( "Checked", BindingSourcePrizeLevels, "value_added", true ) );

			//------------------------------------
			//schedule.packs.Bind( textBox1, "Text", "onsize" );

            BindingSourcePack = new BindingSource();
			BindingSourcePack.DataSource = schedule.packs;

			textBoxPackMultiplier.DataBindings.Add( new Binding( "Text", BindingSourcePack, "multiplier", true ) );
			textBox1.DataBindings.Add( new Binding( "Text", BindingSourcePack, "onsize", true ) );
			textBoxWidth.DataBindings.Add( new Binding( "Text", BindingSourcePack, "width", true ) );
			textBoxHeight.DataBindings.Add( new Binding( "Text", BindingSourcePack, "height", true ) );
			checkBoxJumpingJackpot.DataBindings.Add( new Binding( "Checked", BindingSourcePack, "jumping_jackpot", true ) );
			checkBoxBonusLine.DataBindings.Add( new Binding( "Checked", BindingSourcePack, "_3_number", true ) );
            checkBoxPackDoubleAction.DataBindings.Add( new Binding( "Checked", BindingSourcePack, "double_action", true ) );
            checkBoxOddNumberBonus.DataBindings.Add( new Binding( "Checked", BindingSourcePack, "odd_count_bonus", true ) );
            checkBoxEvenNumberBonus.DataBindings.Add( new Binding( "Checked", BindingSourcePack, "even_count_bonus", true ) );

			comboBoxPackColor.DataBindings.Add( new Binding( "SelectedValue", BindingSourcePack
				, schedule.colors.PrimaryKeyName, true ) );

			//comboBoxPackPrizeLevel.DataBindings.Add( new Binding( "SelectedValue", BindingSourcePack
			//		, schedule.prize_level_names.PrimaryKeyName, true ) );

            listBoxPackRanges.DataSource = schedule_currents.current_pack_cardset_ranges;
            listBoxPackRanges.DisplayMember = schedule_currents.current_pack_cardset_ranges.NameColumn;

			comboBoxCardset.DataSource = schedule.cardset_info;
			comboBoxCardset.DisplayMember = CardsetInfo.NameColumn;

            if( schedule.UseGuid )
                XDataTable.DefaultAutoKeyType = typeof( Guid );
            current_colors = new ColorInfoTable();
            if( schedule.UseGuid )
                XDataTable.DefaultAutoKeyType = typeof( int );

            current_colors.Columns[ColorInfoTable.PrimaryKey].AllowDBNull = true;
            
			//------------------------------------


            foreach( DataRow color in schedule.colors.Rows )
            {
                DataRow newrow = current_colors.NewRow();

                newrow[ColorInfoTable.NameColumn] = color[ColorInfoTable.NameColumn];
                newrow[ColorInfoTable.PrimaryKey] = color[ColorInfoTable.PrimaryKey];
                current_colors.Rows.Add( newrow );
            }

            if( schedule.UseGuid )
                XDataTable.DefaultAutoKeyType = typeof( Guid );
            DataRow no_color = current_colors.NewRow();
			//if( schedule.UseGuid )
			//    XDataTable.DefaultAutoKeyType = typeof( int );

            comboBoxPackColor.DataSource = current_colors;
			comboBoxPackColor.DisplayMember = ColorInfoTable.NameColumn;
			comboBoxPackColor.ValueMember = schedule.colors.PrimaryKeyName;

			DataTable levels = new PrizeLevelNames();

			levels.Columns[PrizeLevelNames.PrimaryKey].AllowDBNull = true;
			foreach( DataRow prize in schedule.prize_level_names.Rows )
			{
				DataRow newrow = levels.NewRow();

				newrow[PrizeLevelNames.NameColumn] = prize[PrizeLevelNames.NameColumn];
				newrow[PrizeLevelNames.PrimaryKey] = prize[PrizeLevelNames.PrimaryKey];
				levels.Rows.Add( newrow );
			}

			comboBoxPackPrizeLevel.DataSource = schedule.prize_level_names;
			comboBoxPackPrizeLevel.DisplayMember = PrizeLevelNames.NameColumn;
			comboBoxPackPrizeLevel.ValueMember = schedule.prize_level_names.PrimaryKeyName;

			comboBoxCardsetRange.DataSource = schedule_currents.current_cardset_ranges;
			comboBoxCardsetRange.DisplayMember = OpenSkieScheduler.BingoGameDefs.CurrentCardsetRanges.DisplayName;

			if( schedule.PacksRelateToPrizes )
			{
				// remove the page for game_group:packs
				tabControl1.TabPages.Remove( tabPageGameGroupPacks );
			}
			else
			{
				// remove the page for game_group-prize:packs
				tabControl1.TabPages.Remove( tabPage17 );
			}

			listBoxCurrentPackPrizeLevels.DataSource = schedule_currents.current_pack_prize_level;
			listBoxCurrentPackPrizeLevels.DisplayMember = schedule_currents.current_pack_prize_level.NameColumn;
			listBoxCurrentPackPrizeLevels.ValueMember = schedule_currents.current_pack_prize_level.PrimaryKeyName;
		}

		void ScheduleDesigner_FormClosing( object sender, FormClosingEventArgs e )
		{
			if( schedule.HasChanges() )
			{
                String pending_changes = "";
                bool real_changes = false;
                DataSet ds = schedule.GetChanges();
                StringBuilder detail = new StringBuilder();
                foreach( DataTable table in ds.Tables )
                {
                    foreach( Attribute attr in table.GetType().GetCustomAttributes( true ) )
                    {
                        SchedulePersistantTable persist = attr as SchedulePersistantTable;
                        if( null != persist )
                        {
                            if( table.Rows.Count > 0 )
                            {
								pending_changes += table.TableName + "(" + table.Rows.Count + ")\n";
                                detail.Append( "Table " );
                                detail.Append( table.TableName );
                                detail.Append( " has " );
                                detail.Append( table.Rows.Count.ToString() );
                                detail.Append( " Changes...\n" );
                                
                                foreach( DataRow row in table.Rows )
                                {
									bool added_row_header = false;
                                    bool first = true;
                                    if( row.RowState == DataRowState.Deleted )
                                    {
										detail.Append( "Row " + table.Rows.IndexOf( row ) + " : " );
										detail.Append( "(deleted)\n" );
										real_changes = true;
										continue;
                                    }
                                    if( row.RowState == DataRowState.Added )
                                    {
										detail.Append( "Row " + table.Rows.IndexOf( row ) + " : " );
										detail.Append( "(new)" );
										real_changes = true;
                                    }
                                   
                                    foreach( DataColumn col in table.Columns )
                                    {
                                        if( row.RowState == DataRowState.Added )
                                        {
											if( !added_row_header )
											{
												detail.Append( "Row " + table.Rows.IndexOf( row ) + " : " );
												added_row_header = true;
											}
                                            if( !first )
                                                detail.Append( ", " );
                                            first = false;
                                            detail.Append( col.ColumnName + "=" + row[col].ToString() );
                                            continue;
                                        }
                                        object a;
                                        object b;
                                        if( !DsnSQLUtil.Compare( col.DataType, a = row[col, DataRowVersion.Original], b = row[col, DataRowVersion.Current] ) )
                                        {
											if( !added_row_header )
											{
												detail.Append( "Row " + table.Rows.IndexOf( row ) + " : " );
												added_row_header = true;
											}
											if( !first )
                                                detail.Append( " and " );
                                            first = false;
                                            detail.Append( col.ColumnName + "changed from [" + a.ToString() + "] to [" + b.ToString() + "]" );
											real_changes = true;
										}
									}
									if( added_row_header )
										detail.Append( "\n" );
                                }
								detail.Append( "\n===============================================\n" );
                            }
                        }
                    }
                }
                if( real_changes )
                {
                    DialogResult r; 
                    if( ( r = MessageBox.Show( "There are unsaved changes to the schedule.\nDo you want to save now?\nCancel will show details." + pending_changes, "Unsaved Changes", MessageBoxButtons.YesNoCancel ) ) == System.Windows.Forms.DialogResult.Yes )
                        schedule.Commit();
                    if( r == System.Windows.Forms.DialogResult.Cancel )
                    {
                        detail.Append( "\nYes will save these changes, no will not commit." );
                        if( ScrollableMessageBox.Show( detail.ToString(), "Unsaved Changes", MessageBoxButtons.YesNo ) == System.Windows.Forms.DialogResult.Yes )
                            schedule.Commit();
                    }
                }
			}
		}

        private void ReloadColors()
        {
            current_colors.Clear();
            foreach( DataRow color in schedule.colors.Rows )
            {
                DataRow newrow = current_colors.NewRow();

                newrow[ColorInfoTable.NameColumn] = color[ColorInfoTable.NameColumn];
                newrow[ColorInfoTable.PrimaryKey] = color[ColorInfoTable.PrimaryKey];
                current_colors.Rows.Add( newrow );
            }
        }

		private void currentSessionGameOrderList1_SelectedIndexChanged( object sender, EventArgs e )
		{
            if( !schedule.GamesInSessions )
            {
                if( currentSessionGameOrderList1.SelectedItem != null )
                    if( BindingSourceSessionGameGroupGame != null )
                    {
                        DataRow myself = ( currentSessionGameOrderList1.SelectedItem as DataRowView ).Row;
                        DataRow real;
                        if( schedule.GamesInSessions )
                            real = myself.GetParentRow( OpenSkieScheduler.Relations.SessionGame.TableName );
                        else
                            real = myself.GetParentRow( OpenSkieScheduler.Relations.SessionGameGroupGameOrder.TableName );
                        //BindingSourceSessionGameGroupGame.EndEdit();
                        if( real != null )
                        {
                            int a = BindingSourceSessionGameGroupGame.Find( XDataTable.ID( real.Table ), real[XDataTable.ID( real.Table )] );
                            BindingSourceSessionGameGroupGame.Position = a;
                        }
                    }
            }
		}

        private void currentSessionGameList1_SelectedIndexChanged( object sender, EventArgs e )
        {
            if( schedule.GamesInSessions )
            {
                if( currentSessionGameList1.SelectedItem != null )
                    if( BindingSourceSessionGame != null )
                    {
                        DataRow myself = ( currentSessionGameList1.SelectedItem as DataRowView ).Row;
                        DataRow real = myself.GetParentRow( OpenSkieScheduler.Relations.SessionGame.TableName );
                        //BindingSourceSessionGameGroupGame.EndEdit();

                        // might not exist for a moment...
                        if( real != null )
                        {
                            int a = BindingSourceSessionGame.Find( XDataTable.ID( real.Table ), real[XDataTable.ID( real.Table )] );
                            BindingSourceSessionGame.Position = a;
                        }
                    }
            }
        }

		private void packList1_SelectedIndexChanged( object sender, EventArgs e )
		{
			if( packList1.SelectedItem != null )
				if( BindingSourcePack != null )
				{
					BindingSourcePack.Position = schedule.packs.Rows.IndexOf( ( packList1.SelectedItem as DataRowView ).Row );
				}

		}

		private void button4_Click( object sender, EventArgs e )
		{
			ColorEditor editor = new ColorEditor();
			editor.ShowDialog();
			editor.Dispose();
            ReloadColors();
		}

		private void button6_Click( object sender, EventArgs e )
		{
			BindingSourcePack.EndEdit();
			//data.packs.CommitChanges();
		}

		private void saveScheduleToolStripMenuItem_Click( object sender, EventArgs e )
		{
//		[STAThread]
//		void SaveSchedule_Click( object sender, EventArgs e )
		{
			SaveFileDialog openFileDialog1 = new SaveFileDialog();

			openFileDialog1.InitialDirectory = Environment.CurrentDirectory;
			openFileDialog1.Filter = "Schedule files(*.xml)|*.xml|All files (*.*)|*.*";
			openFileDialog1.FilterIndex = 1;
			openFileDialog1.RestoreDirectory = true;
			//openFileDialog1.RestoreDirectory = true;

			if( openFileDialog1.ShowDialog() == DialogResult.OK )
			{
				try
				{
					schedule.WriteXML( openFileDialog1.FileName );
				}
				catch( Exception e2 )
				{
					Console.WriteLine( e2.Message );
				}
			}			
		}

		}

		private void loadScheduleToolStripMenuItem_Click( object sender, EventArgs e )
		{
			{
				OpenFileDialog openFileDialog1 = new OpenFileDialog();

				openFileDialog1.InitialDirectory = Environment.CurrentDirectory;
				openFileDialog1.Filter = "Schedule files(*.xml)|*.xml|All files (*.*)|*.*";
				openFileDialog1.FilterIndex = 1;
				openFileDialog1.RestoreDirectory = true;
				//openFileDialog1.RestoreDirectory = true;

				if( openFileDialog1.ShowDialog() == DialogResult.OK )
				{
					try
					{
						schedule.ReadXML( openFileDialog1.FileName );
					}
					catch( Exception e2 )
					{
						Console.WriteLine( e2.Message );
					}
				}
			}

		}

		private void buttonPriceEditClick( object sender, EventArgs e )
		{
			PriceEditor2 pe = new PriceEditor2();
			pe.ShowDialog();
			pe.Dispose();
		}

		private void button7_Click( object sender, EventArgs e )
		{
			PayoutEditor2 pe = new PayoutEditor2();
			pe.ShowDialog();
			pe.Dispose();
		}

		private void comboBox1_SelectedIndexChanged( object sender, EventArgs e )
		{
			if( comboBoxCardset.SelectedItem != null )
			{
				schedule_currents.SetCurrentCardsetRange( ( comboBoxCardset.SelectedItem as DataRowView ).Row );
				if( comboBoxCardsetRange.Items.Count > 0 )
					comboBoxCardsetRange.SelectedIndex = 0;
			}

		}

		private void textbox_TextChanged( object sender, EventArgs e )
		{
			if( textBoxWidth.Text != "" && textBoxHeight.Text != "" )
			{
				//CreatePanel( int.Parse( textBoxWidth.Text ), int.Parse( textBoxHeight.Text ) );
				DataRow pack = (BindingSourcePack.Current as DataRowView).Row;
				if( pack != null )
				{
					try
					{
						int newsize = int.Parse( textBoxWidth.Text ) * int.Parse( textBoxHeight.Text );
						if( pack["onsize"] == DBNull.Value || Convert.ToInt32( pack["onsize"] ) != newsize )
							pack["onsize"] = newsize;
					}
					catch
					{
					}
				}

				//textBox1.Text = ( int.Parse( textBoxWidth.Text ) * int.Parse( textBoxHeight.Text ) ).ToString();
			}

		}

		private void textBoxWidth_TextChanged( object sender, EventArgs e )
		{
			textbox_TextChanged( sender, e );
		}

		private void textBoxHeight_TextChanged( object sender, EventArgs e )
		{
			textbox_TextChanged( sender, e );
		}

		private void button2_Click( object sender, EventArgs e )
		{
			DataRowView drv_range = comboBoxCardsetRange.SelectedItem as DataRowView;
			if( drv_range == null )
			{
				MessageBox.Show( "Please Select a Cardset and\nselect a Range of that cardset." );
				return;
			}
			schedule_currents.current_pack_cardset_ranges.AddChildMember( drv_range.Row.GetParentRow( drv_range.Row.Table.ParentRelations[0] ) );

		}

		private void button3_Click( object sender, EventArgs e )
		{
			DataRowView drv = listBoxPackRanges.SelectedItem as DataRowView;
			if( drv == null )
			{
				MessageBox.Show( "Please Select a Cardset and\nselect a Range of that cardset." );
				return;
			}
			DataTable dt = drv.Row.Table;

			drv.Row.Delete();
		}

        private void validateScheduleToolStripMenuItem_Click( object sender, EventArgs e )
        {
            //OpenSkieScheduler.ValidateScheduleIntegrity vsi = new OpenSkieScheduler.ValidateScheduleIntegrity();
            //vsi.ShowDialog();
        }

        private void exportLegacyScheduleToolStripMenuItem_Click( object sender, EventArgs e )
        {
#if save_this_code
            FolderBrowserDialog fbd = new FolderBrowserDialog();

            fbd.SelectedPath = Options.Default["/EltaninButton/Defaultpath", "c:/ftn3000/data/schedule"].Value;
            if( fbd.ShowDialog() != DialogResult.OK )
            {
                return;
            }
            
            String path = fbd.SelectedPath;
            Options.Default["/EltaninButton/Defaultpath", "c:/ftn3000/data/schedule"].Value = path;

            OpenSkieScheduler.EltaninObjects.EltaninDatabaseInterface.BlobberDatabaseInterface bdi 
                = new OpenSkieScheduler.EltaninObjects.EltaninDatabaseInterface.BlobberDatabaseInterface();

            bool successful_grab = true;
            int session_count = 1;
            string day_name = "Generated";
            do
            {

                //We only have room for 32 sessions in the minischedule.
                if( session_count < 32 )
                {
                    successful_grab = bdi.AddSessionDayToSchedule( session_count, DateTime.Now, true, ref day_name );
                }
                else
                {
                    successful_grab = bdi.AddSessionDayToSchedule( session_count, DateTime.Now, false, ref day_name );

                }

                if( successful_grab == true )
                    session_count++;

            } while( ( successful_grab == true ) );


            //Making our month.sch file
            int monthindex = bdi.scg.CreateDayWithSessions( day_name, session_count );
            bdi.scg.SetEntireMonthToDayIndex( monthindex );



            //making a sample papsch.dat
            bdi.scg.PaySchSetType( 0, "whatever 1" );
            bdi.scg.PaySchSetType( 1, "whatever 2" );
            bdi.scg.PaySchSetType( 2, "whatever 3" );

            bdi.scg.PayschSetSeriesData( 0, 0, 1, 3, "whatever 1", 100, 200, 138, 18, 1, "RED" );
            bdi.scg.PayschSetSeriesData( 0, 0, 1, 2, "whatever 2", 100, 200, 139, 18, 1, "GREEN" );
            bdi.scg.PayschSetSeriesData( 0, 0, 1, 4, "whatever 3", 100, 200, 140, 18, 1, "RED" );
            bdi.scg.PaySchSetPrize( 1, 2, 1, 4, 3, 1003 );
            bdi.scg.PaySchSetPrize( 0, 0, 1, 4, 3, 1004 );



            bdi.DumpFilesDirectory( path );



            /* Just for illustration purposes here....we're going to get some things.*/
            Byte[] sessiondat = bdi.ExtractSessionDat();

            Byte[] gamepattdat = bdi.ExtractGamePattDat();

            Byte[] klugedat = bdi.ExtractKlugeDat();

            Byte[] patternsdat = bdi.ExtractPatternsDat();

            Byte[] colorsdat = bdi.ExtractColorsDat();


            //We could always just wait for a null-test....
            for( int i = 0; i < session_count; i++ )
            {
                Byte[] session_data = bdi.ExtractMiniSession( i );
                String session_name = bdi.GetMinisessionIdString( i );
            }

            /*--------------------------------------------------*/

            EltaninObject.ticket0 my_ticket0 = new EltaninObject.ticket0();

            for( int i = 0; i < session_count; i++ )
            {
                UInt32 dataname = bdi.GetMinisessionId( i );
                byte[] data_toaddd = bdi.ExtractMiniSession( i );

                my_ticket0.Add( bdi.GetMinisessionId( i ), bdi.ExtractMiniSession( i ) );
            }
            byte[] gentzpdes = bdi.ExtractPackDescription();


            my_ticket0.Add( bdi.ExtractPackDescriptionId(), bdi.ExtractPackDescription() );

            my_ticket0.SerializeToPath( path );

            byte[] SampleBlobData = { 0, 1, 3, 4, 5 };
            byte[] SampleBlobData2 = { 6, 1, 7, 4, 5 };

            EltaninObject.ticketn256 my_ticketn = new EltaninObject.ticketn256();

            my_ticketn.AddTicket( 0, 0xffffffff );
            my_ticketn.AddTicket( 0, 0xffffffff );
            my_ticketn.AddTicket( 0, 1 );
            my_ticketn.AddTicket( 0, 2 );
            my_ticketn.AddTicket( 1, 2 );
            my_ticketn.AddTicket( 2, 2 );
            my_ticketn.AddTicket( true, 2, 2 );

            my_ticketn.AddBlobData( 0, SampleBlobData );
            my_ticketn.AddBlobData( 1, SampleBlobData2 );
            my_ticketn.AddBlobData( 50, SampleBlobData );


            my_ticketn.SerializeToPathFilename( path, "ticketn" );

            //----------successful schedule test right here
            //dotsch mydotsch = new dotsch();

            //mydotsch.CreateTestSchedule();
            //mydotsch.SerializeToPath(path);
            //*-----------------------/

#endif
        }

		private void reloadFromDatabaseToolStripMenuItem_Click( object sender, EventArgs e )
		{
			schedule.Create();
			schedule.Fill();
		}


		static bool MyInterfaceFilter( Type typeObj, Object criteriaObj )
		{
			Type started = typeObj;
			while( typeObj != null )
			{

				if( string.Compare( typeObj.FullName, criteriaObj.ToString(), true ) == 0 )
					return true;
				if( string.Compare( typeObj.Name, criteriaObj.ToString(), true ) == 0 )
					return true;
				typeObj = typeObj.BaseType;
			}
			return false;
		}

		private void ButtonLoadDepartment_Click( object sender, EventArgs e )
		{
			OpenFileDialog openFileDialog1 = new OpenFileDialog();

			openFileDialog1.InitialDirectory = Environment.CurrentDirectory;
			openFileDialog1.Filter = "Assembly files (*.exe;*.dll)|*.exe;*.dll|All files (*.*)|*.*";
			openFileDialog1.FilterIndex = 1;
			openFileDialog1.RestoreDirectory = true;
			//openFileDialog1.RestoreDirectory = true;
#if asdfasdf
			if( openFileDialog1.ShowDialog() == DialogResult.OK )
			{
				try
				{
					Assembly department = osalot.LoadAssembly( openFileDialog1.FileName );
					Type[] assembly_types = null;
					try
					{
						assembly_types = a.GetTypes();
					}
					catch
					{
						return;
					}
					foreach( Type current_type in assembly_types )
					{
						Type[] interfaces;
						interfaces = current_type.FindInterfaces( MyInterfaceFilter, "SellableItemType" );
						if( interfaces.Length > 0 )
						{
							object o = Activator.CreateInstance( t );
							tracker.objects.Add( ao = new AssemblyObject( t, o ) );
							SellableItemType department = o as SellableItemType; 
														
						}						
					}
				}
				catch( Exception e2 )
				{
					Console.WriteLine( e2.Message );
				}
			}
#endif
		}

		private void commitDatasetToolStripMenuItem_Click( object sender, EventArgs e )
		{
			schedule.Commit();
		}

        private void menuStrip1_ItemClicked( object sender, ToolStripItemClickedEventArgs e )
        {

        }

        private void editOptionDatabaseToolStripMenuItem_Click( object sender, EventArgs e )
        {
            OptionEditor oe = new OptionEditor();
            oe.ShowDialog();
            oe.Dispose();
        }

        private void button10_Click( object sender, EventArgs e )
        {
			DataRow session = schedule_currents.current_session;
            if( session != null )
            {
                String result = xperdex.classes.QueryNewName.Show( "Enter new session name" );
                DataRow new_session = null;
                if( result.Length > 0 )
                {
                    new_session = schedule.sessions.NewSession( result );
                }
                if( new_session != null )
                {
                    foreach( DataRow session_game_group in session.GetChildRows( "session_has_game_group" ) )
                    {
                        schedule.session_game_groups.CloneGroupMember( new_session, session_game_group.GetParentRow( "game_group_in_session" ), session_game_group );
                    }

                    if( schedule.GamesInSessions )
                    {
                        foreach( DataRow session_game in session.GetChildRows( "session_has_game" ) )
                        {
                            DataRow new_session_game = schedule.session_games.CloneGroupMember( new_session, session_game.GetParentRow( "game_in_session" ), session_game );
                            foreach( DataRow game_game_group in session_game.GetChildRows( "session_game_has_game_group" ) )
                            {
                                schedule.session_game_game_group.CloneGroupMember( new_session_game, game_game_group.GetParentRow( "game_group_in_session_game" ), game_game_group );
                            }
                        }
                    }
                }
            }
        }

        private void gameGroupList8_SelectedIndexChanged( object sender, EventArgs e )
        {
            if( gameGroupPrizeList1.Items.Count > 0 )
            {
                gameGroupPrizeList1.SelectedIndex = -1;
                gameGroupPrizeList1.SelectedIndex = 0;
            }
        }

		private void prizeLevelList2_SelectedIndexChanged( object sender, EventArgs e )
		{
			if( BindingSourcePrizeLevels != null && prizeLevelList2.SelectedItem != null )
			{
				DataRow myself = ( prizeLevelList2.SelectedItem as DataRowView ).Row;
				DataRow real = myself;
				//BindingSourceSessionGameGroupGame.EndEdit();
				if( real != null )
				{
					int a = BindingSourcePrizeLevels.Find( XDataTable.ID( real.Table ), real[XDataTable.ID( real.Table )] );
					BindingSourcePrizeLevels.Position = a;
				}
			}
		}

		private void buttonMakeSingleFace_Click( object sender, EventArgs e )
		{
			schedule_currents.current_pack["width"] = 1;
			schedule_currents.current_pack["height"] = 1;
			schedule_currents.current_pack["onsize"] = 1;
		}

		private void buttonMake6on_Click( object sender, EventArgs e )
		{
			schedule_currents.current_pack["width"] = 2;
			schedule_currents.current_pack["height"] = 3;
			schedule_currents.current_pack["onsize"] = 6;

		}

		private void buttonMake12onRainbow_Click( object sender, EventArgs e )
		{
			schedule_currents.current_pack["width"] = 4;
			schedule_currents.current_pack["height"] = 3;
			schedule_currents.current_pack["onsize"] = 12;
			schedule_currents.current_pack[PrizeLevelNames.PrimaryKey] = DBNull.Value;
			DataRow[] face_prizes = schedule_currents.current_pack.GetChildRows( "pack_has_prize_level" );
			foreach( DataRow row in face_prizes )
			{
				row.Delete();
			}
			MessageBox.Show( "Intended to fill out prize levels for the faces, but I don't know what prize levels you're using..." );
/*
			{
                DataRow NewFace = schedule.pack_face_prize_level.NewRow();
                NewFace["pack_id"] = this.pack["pack_id"];
                NewFace["face"] = FaceButtons[i].Face;
                NewFace["prize_level_id"] = FaceButtons[i].PrizeLevelId;
                NewFace["color_id"] = FaceButtons[i].FaceColorId;
                schedule.pack_face_prize_level.Rows.Add( NewFace );
			}
 */
		}

		private void buttonMake18onRainbow_Click( object sender, EventArgs e )
		{
			schedule_currents.current_pack["width"] = 6;
			schedule_currents.current_pack["height"] = 3;
			schedule_currents.current_pack["onsize"] = 18;

			MessageBox.Show( "Intended to fill out prize levels for the faces, but I don't know what prize levels you're using..." );
		}

		private void buttonMake3Strip_Click( object sender, EventArgs e )
		{
			schedule_currents.current_pack["width"] = 1;
			schedule_currents.current_pack["height"] = 3;
			schedule_currents.current_pack["onsize"] = 3;
		}

		private void buttonMakePackBundle_Click( object sender, EventArgs e )
		{
			DataRowView drv = packList5.SelectedItem as DataRowView;
			if( drv != null )
			{
				String name = drv.Row[PackTable.NameColumn].ToString();
				DataRow[] bundles = schedule.bundles.Select( BundleTable.NameColumn + "='" + name + "'" );
				if( bundles.Length > 0 )
				{
					MessageBox.Show( "Bundle with pack's name '" + name + "' already exists." );
					return;
				}
				DataRow newbundle = schedule.bundles.NewBundle( name );
				DataRow new_bundle_pack = schedule.bundle_packs.AddGroupMember( newbundle, drv.Row );
				new_bundle_pack["quantity"] = 1;
			}
		}

		private void buttonAddPackPrize_Click( object sender, EventArgs e )
		{
			DataRowView drv = comboBoxPackPrizeLevel.SelectedItem as DataRowView;
			if( drv != null )
			{
				DataRow[] old_row = schedule.pack_prize_level.Select( PackTable.PrimaryKey + "='" + schedule_currents.current_pack[PackTable.PrimaryKey] + "' and " + PrizeLevelNames.PrimaryKey + "='" + drv.Row[PrizeLevelNames.PrimaryKey] + "'" );
				if( old_row.Length == 0 )
				{
					schedule.pack_prize_level.AddGroupMember( schedule_currents.current_pack, drv.Row );
				}
			}
		}

		private void buttonRemovePackPrize_Click( object sender, EventArgs e )
		{
			DataRowView drv = listBoxCurrentPackPrizeLevels.SelectedItem as DataRowView;
			if( drv != null )
			{
				DataRow real_row = drv.Row.GetParentRow( PackPrizeLevel.TableName );
				if( real_row != null )
					real_row.Delete();
			}
		}
		


	}
}
