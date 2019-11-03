﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using OpenSkieScheduler3.Controls.Buttons;
using OpenSkieScheduler3.Controls.Forms;
using OpenSkieScheduler3.Controls;
using xperdex.classes;
using OpenSkieScheduler3;
//using xperdex.core;
using System.Reflection;
using OpenSkie.Scheduler;
using OpenSkie.Scheduler.Controls;
using OpenSkieScheduler3.Relations;
using OpenSkieScheduler3.BingoGameDefs;

namespace ScheduleDesigner
{
	public partial class ScheduleDesigner : Form
	{
        ScheduleCurrents schedule_currents; 
		OpenSkieScheduler3.ScheduleDataSet schedule;

		public ScheduleDesigner()
		{
            //OpenSkieSchedule.GamesRelateToSessions = true;
            //OpenSkieSchedule.UseGuid = true;
            //OpenSkieSchedule.PacksRelateToPrizes = true;
			schedule = new OpenSkieScheduler3.ScheduleDataSet( StaticDsnConnection.dsn );
            schedule_currents = new ScheduleCurrents( schedule );
			schedule.Drop();
			schedule.Create();
#if use_p2p_events
            schedule.SetTableReload( FormTableUpdate );
#endif
            ControlList.schedule = schedule;
			ControlList.data = schedule_currents;
            InitializeComponent();
		}

		public ScheduleDesigner( OpenSkieScheduler3.ScheduleDataSet schedule )
		{
#if use_p2p_events
            schedule.SetTableReload( FormTableUpdate );
#endif
            this.schedule = schedule;
			schedule_currents = new ScheduleCurrents( schedule );

			ControlList.schedule = schedule;
			ControlList.data = schedule_currents;
			InitializeComponent();
		}

        DataTable current_colors;

		List<BindingSource> bindings;

        BindingSource BindingSourceSessionGameGroupGame;
		BindingSource BindingSourceSessionInfo;
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
			addItemToSet7.UpdateNewRow += new OpenSkie.Scheduler.Controls.Controls.Buttons.AddItemToSet.OnUpdateNewRow( addItemToSet7_UpdateNewRow );

			textBoxGameCount.Text = schedule_currents.current_session_games.Count.ToString();
			schedule_currents.SetSessionCurrent += new ScheduleCurrents.OnSetCurrent( schedule_currents_SetSessionCurrent );

			FormClosing += new FormClosingEventHandler( ScheduleDesigner_FormClosing );
            tabControl1.TabPages.Remove( tabPage16 ); // Items
            tabControl1.TabPages.Remove( tabPageTreeEditor ); // tree editor expiramental

			//------------------------------------
			BindingSourceSessionInfo = new BindingSource();
			BindingSourceSessionInfo.DataSource = schedule.sessions;
			textBoxMaxSessionCards.DataBindings.Add( new Binding( "Text", BindingSourceSessionInfo, "max_cards", true ) );
            
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
			textBoxSessionGameName.DataBindings.Add( new Binding( "Text", BindingSourceSessionGame, "session_game_name", true ) );
            comboBoxGameColor2.DataBindings.Add( new Binding( "SelectedValue", BindingSourceSessionGame, schedule.colors.PrimaryKeyName, true ) );
			checkBoxCallersChoice.DataBindings.Add( new Binding( "Checked", BindingSourceSessionGame, "callers_choice", true ) );


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

			checkBoxUpick.DataBindings.Add( new Binding( "Checked", BindingSourcePack, "upickem", true ) );
			textBoxFaceSize.DataBindings.Add( new Binding( "Text", BindingSourcePack, "face_size", true ) );

			comboBoxPackColor.DataBindings.Add( new Binding( "SelectedValue", BindingSourcePack
				, schedule.colors.PrimaryKeyName, true ) );

			//comboBoxPackPrizeLevel.DataBindings.Add( new Binding( "SelectedValue", BindingSourcePack
			//		, schedule.prize_level_names.PrimaryKeyName, true ) );

            listBoxPackRanges.DataSource = schedule_currents.current_pack_cardset_ranges;
            //listBoxPackRanges.DisplayMember = schedule_currents.current_pack_cardset_ranges.NameColumn;

			comboBoxCardset.DataSource = schedule.cardset_info;
			comboBoxCardset.DisplayMember = CardsetInfo.NameColumn;

            //if( schedule.UseGuid )
            //    XDataTable.DefaultAutoKeyType = typeof( Guid );
            current_colors = new ColorInfoTable();
            //if( schedule.UseGuid )
            //    XDataTable.DefaultAutoKeyType = typeof( int );

            current_colors.Columns[ColorInfoTable.PrimaryKey].AllowDBNull = true;
            
			//------------------------------------


            foreach( DataRow color in schedule.colors.Rows )
            {
                DataRow newrow = current_colors.NewRow();

                newrow[ColorInfoTable.NameColumn] = color[ColorInfoTable.NameColumn];
                newrow[ColorInfoTable.PrimaryKey] = color[ColorInfoTable.PrimaryKey];
                current_colors.Rows.Add( newrow );
            }

            //if( schedule.UseGuid )
            //    XDataTable.DefaultAutoKeyType = typeof( Guid );
            DataRow no_color = current_colors.NewRow();
			//if( schedule.UseGuid )
			//    XDataTable.DefaultAutoKeyType = typeof( int );

			comboBoxGameColor2.DataSource = current_colors;
			comboBoxGameColor2.DisplayMember = ColorInfoTable.NameColumn;
			comboBoxGameColor2.ValueMember = schedule.colors.PrimaryKeyName;

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
			comboBoxCardsetRange.DisplayMember = OpenSkieScheduler3.BingoGameDefs.CurrentCardsetRanges.DisplayName;

			// remove the page for game_group-prize:packs

			listBoxCurrentPackPrizeLevels.DataSource = schedule_currents.current_pack_prize_level;
			listBoxCurrentPackPrizeLevels.DisplayMember = schedule_currents.current_pack_prize_level.NameColumn;
			listBoxCurrentPackPrizeLevels.ValueMember = schedule_currents.current_pack_prize_level.PrimaryKeyName;
		}

		void addItemToSet7_UpdateNewRow( DataRow row )
		{
			if( schedule_currents.current_session_type == null )
			{
				row.Delete();
				return;
			}
			DataRow tmp;
			tmp = schedule_currents.current_session_prize_exception_set;
			if( tmp != null )
				row[PrizeExceptionSet.PrimaryKey] = tmp[PrizeExceptionSet.PrimaryKey];
			tmp = schedule_currents.current_session_price_exception_set;
			if( tmp != null )
				row[ PriceExceptionSet.PrimaryKey ] = tmp[ PriceExceptionSet.PrimaryKey ];
			row[SessionTypeTable.PrimaryKey] = schedule_currents.current_session_type[SessionTypeTable.PrimaryKey];
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
					int change_count = table.Rows.Count;
                    foreach( Attribute attr in table.GetType().GetCustomAttributes( true ) )
                    {
                        SchedulePersistantTable persist = attr as SchedulePersistantTable;
                        if( null != persist )
                        {
                            if( table.Rows.Count > 0 )
                            {
								foreach( DataRow row in table.Rows )
								{
									if( row.RowState == DataRowState.Unchanged )
									{
										change_count--;
										continue;
									}
								}
								if( change_count == 0 )
									break;
								pending_changes += table.TableName + "(" + change_count + ")\n";
								detail.Append( "Table " );
                                detail.Append( table.TableName );
                                detail.Append( " has " );
								detail.Append( change_count );
                                detail.Append( " Changes...\n" );
                                
                                foreach( DataRow row in table.Rows )
                                {
									if( row.RowState == DataRowState.Unchanged )
										continue;
									bool added_row_header = false;
                                    bool first = true;
                                    if( row.RowState == DataRowState.Deleted )
                                    {
										detail.Append( "Row " + table.Rows.IndexOf( row ) + " : " );
										detail.Append( "(deleted)\n" );
										real_changes = true;
										//continue;
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
										if( row.RowState == DataRowState.Deleted )
										{
											if( !added_row_header )
											{
												detail.Append( "Row " + table.Rows.IndexOf( row ) + " : " );
												added_row_header = true;
											}
											if( !first )
												detail.Append( ", " );
											first = false;
											detail.Append( col.ColumnName + "=" + row[col, DataRowVersion.Original].ToString() );
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
		}

        private void currentSessionGameList1_SelectedIndexChanged( object sender, EventArgs e )
        {
            if( currentSessionGameList1.SelectedItem != null )
                if( BindingSourceSessionGame != null )
                {
                    DataRow myself = ( currentSessionGameList1.SelectedItem as DataRowView ).Row;
                    DataRow real = myself;
                    //BindingSourceSessionGameGroupGame.EndEdit();

                    // might not exist for a moment...
                    if( real != null )
                    {
						int a = BindingSourceSessionGame.Find( XDataTable.ID( real.Table ), real[XDataTable.ID( real.Table )] );
                        BindingSourceSessionGame.Position = a;
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
			DataRow real_row = drv.Row.GetParentRow( "pack_cardset_range" );
			if( real_row != null )
				real_row.Delete();
			else
				drv.Delete();
		}

        private void validateScheduleToolStripMenuItem_Click( object sender, EventArgs e )
        {
            //OpenSkieScheduler.ValidateScheduleIntegrity vsi = new OpenSkieScheduler.ValidateScheduleIntegrity();
            //vsi.ShowDialog();
        }

        private void exportLegacyScheduleToolStripMenuItem_Click( object sender, EventArgs e )
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();

            fbd.SelectedPath = Options.Default["/EltaninButton/Defaultpath", "c:/ftn3000/data/schedule"].Value;
            if( fbd.ShowDialog() != DialogResult.OK )
            {
                return;
            }
            
            String path = fbd.SelectedPath;
            Options.Default["/EltaninButton/Defaultpath", "c:/ftn3000/data/schedule"].Value = path;

#if ELTANIN_SUPPORT
            OpenSkieScheduler3.EltaninObjects.EltaninDatabaseInterface.BlobberDatabaseInterface bdi 
                = new OpenSkieScheduler3.EltaninObjects.EltaninDatabaseInterface.BlobberDatabaseInterface( schedule );

            bool successful_grab = true;
            int session_count = 1;
            string day_name = "Generated";
            do
            {
                //We only have room for 32 sessions in the minischedule.
                if( session_count < 32 )
                {
                    successful_grab = bdi.AddSessionDayToSchedule( schedule, session_count, DateTime.Now, true, ref day_name );
                }
                else
                {
                    successful_grab = bdi.AddSessionDayToSchedule( schedule, session_count, DateTime.Now, false, ref day_name );

                }

                if( successful_grab == true )
                    session_count++;

            } while( ( successful_grab == true ) );


            //Making our month.sch file
            int monthindex = bdi.scg.CreateDayWithSessions( day_name, session_count );
            bdi.scg.SetEntireMonthToDayIndex( monthindex );



            //making a sample papsch.dat
            //bdi.scg.PaySchSetType( 0, "whatever 1" );
            //bdi.scg.PaySchSetType( 1, "whatever 2" );
            //bdi.scg.PaySchSetType( 2, "whatever 3" );

            //bdi.scg.PayschSetSeriesData( 0, 0, 1, 3, "whatever 1", 100, 200, 138, 18, 1, "RED" );
            //bdi.scg.PayschSetSeriesData( 0, 0, 1, 2, "whatever 2", 100, 200, 139, 18, 1, "GREEN" );
            //bdi.scg.PayschSetSeriesData( 0, 0, 1, 4, "whatever 3", 100, 200, 140, 18, 1, "RED" );
            //bdi.scg.PaySchSetPrize( 1, 2, 1, 4, 3, 1003 );
            //bdi.scg.PaySchSetPrize( 0, 0, 1, 4, 3, 1004 );


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
#endif
            //----------successful schedule test right here
            //dotsch mydotsch = new dotsch();

            //mydotsch.CreateTestSchedule();
            //mydotsch.SerializeToPath(path);
            //*-----------------------/
        }

		private void reloadFromDatabaseToolStripMenuItem_Click( object sender, EventArgs e )
		{
			if( schedule.HasChanges() )
				if( MessageBox.Show( "Unsaved changes...\nAre you sure you want to reload?\nThis will drop all changes.", "Unsaved Changes", MessageBoxButtons.YesNo ) == System.Windows.Forms.DialogResult.No )
				{
					return;
				}
			schedule.snapshot = false;
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

        private void buttonCopySession_Click( object sender, EventArgs e )
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
					Dictionary<DataRow, DataRow> session_pack_group_map = new Dictionary<DataRow, DataRow>();
 
                    foreach( DataRow session_pack_group in session.GetChildRows( schedule.session_pack_groups.ChildrenOfParent ) )
                    {
						DataRow new_session_pack_group = schedule.session_pack_groups.CloneGroupMember( new_session, session_pack_group.GetParentRow( schedule.session_pack_groups.ParentOfChild ), session_pack_group );
						session_pack_group_map.Add( session_pack_group, new_session_pack_group );
                    }

                    {
                        foreach( DataRow session_game in session.GetChildRows( schedule.session_games.ChildrenOfParent ) )
                        {
                            DataRow new_session_game = schedule.session_games.CloneGroupMember( new_session, session_game.GetParentRow( schedule.session_games.ParentOfChild ), session_game );
                            foreach( DataRow session_game_session_pack_group in session_game.GetChildRows( schedule.session_game_session_pack_group.ChildrenOfParent ) )
                            {
								DataRow old_session_pack_group = session_game_session_pack_group.GetParentRow( schedule.session_game_session_pack_group.ParentOfChild );
								DataRow new_session_pack_group = session_pack_group_map[old_session_pack_group];

								schedule.session_game_session_pack_group.CloneGroupMember( new_session_game
									, new_session_pack_group
									, session_game_session_pack_group );
                            }
							foreach( DataRow session_game_pattern in session_game.GetChildRows( schedule.game_patterns.ChildrenOfParent ) )
							{
								schedule.game_patterns.CloneGroupMember( new_session_game
									, session_game_pattern.GetParentRow( schedule.game_patterns.ParentOfChild )
									, session_game_pattern );
							}
                        }
                    }

					foreach( DataRow session_bundle in session.GetChildRows( schedule.session_bundles.ChildrenOfParent ) )
					{
						DataRow new_session_bundle = schedule.session_bundles.CloneGroupMember( new_session, session_bundle.GetParentRow( schedule.session_bundles.ParentOfChild ), session_bundle );
						foreach( DataRow session_bundle_pack in session_bundle.GetChildRows( schedule.session_bundle_packs.ChildrenOfParent ) )
						{
							schedule.session_bundle_packs.CloneGroupMember( new_session_bundle, session_bundle_pack.GetParentRow( schedule.session_bundle_packs.ParentOfChild ), session_bundle_pack );
						}
					}

					foreach( DataRow session_prize_exception_set in session.GetChildRows( schedule.session_prize_exception_sets.ChildrenOfParent ) )
					{
						DataRow prize_set = session_prize_exception_set.GetParentRow( schedule.session_prize_exception_sets.ParentOfChild );

						if( prize_set[PrizeExceptionSet.NameColumn].Equals( "Default" ) )
							continue;
						schedule.session_prize_exception_sets.CloneGroupMember( new_session, prize_set, session_prize_exception_set );
					}

					foreach( DataRow session_price_exception_set in session.GetChildRows( schedule.session_price_exception_sets.ChildrenOfParent ) )
					{
						DataRow price_set = session_price_exception_set.GetParentRow( schedule.session_price_exception_sets.ParentOfChild );

						if( price_set[PriceExceptionSet.NameColumn].Equals( "Default" ) )
							continue;
						schedule.session_price_exception_sets.CloneGroupMember( new_session, price_set, session_price_exception_set );
					}
				}
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
			//schedule_currents.current_pack[PrizeLevelNames.PrimaryKey] = DBNull.Value;
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
			DataRow row = schedule_currents.current_pack;
			if( row != null )
			{
				String name = row[PackTable.NameColumn].ToString();
				DataRow[] bundles = schedule.bundles.Select( BundleTable.NameColumn + "='" + name + "'" );
				DataRow newbundle;
				if( bundles.Length > 0 )
					newbundle = bundles[0];
				else
					newbundle = schedule.bundles.NewBundle( name );
				DataRow session_bundle = schedule.session_bundles.AddGroupMember( schedule_currents.current_session, newbundle );
				DataRow new_bundle_pack = schedule.session_bundle_packs.AddGroupMember( session_bundle, row );
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

		private void buttonPackToItem_Click( object sender, EventArgs e )
		{
			DataRow row = schedule_currents.current_pack;
			DataRow[] base_bundle = schedule.bundles.Select( BundleTable.NameColumn + "='" + row[PackTable.NameColumn] + "'" );
			DataRow session_row = ( sessionList2.SelectedItem as DataRowView ).Row;
			if( base_bundle.Length == 0 )
			{
				DataRow new_bundle = schedule.bundles.NewRow();
				new_bundle[BundleTable.NameColumn] = row[PackTable.NameColumn];
				schedule.bundles.Rows.Add( new_bundle );
				DataRow relation = schedule.session_bundles.AddGroupMember( session_row, new_bundle );
				schedule.session_bundle_packs.AddGroupMember( relation, row );
			}
			else
			{
				DataRow relation;
				DataRow relation_item;
				relation = schedule.session_bundles.GetGroupMember( session_row, base_bundle[0] );
				if( relation == null )
					relation = schedule.session_bundles.AddGroupMember( session_row, base_bundle[0] );
				if( ( relation_item = schedule.session_bundle_packs.GetGroupMember( relation, row ) ) == null )
					schedule.session_bundle_packs.AddGroupMember( relation, row );
				else
				{
					if( MessageBox.Show( "Do you want to add ANOTHER of these packs to the existing bundle?", "Confirm", MessageBoxButtons.YesNo ) == System.Windows.Forms.DialogResult.Yes )
						relation_item[SessionBundlePackRelation.CountColumn] 
							= Convert.ToInt32( relation_item[SessionBundlePackRelation.CountColumn] ) + 1;
				}
			}
		}

		private void buttonInsertSessionGame_Click( object sender, EventArgs e )
		{
			DataRow insert_before = schedule_currents.current_session_game;
			if( insert_before == null )
			{
				MessageBox.Show( "Must select a session-game to insert before" );
				return;
			}
            object insert_before_id = insert_before[SessionGame.PrimaryKey];
			DataRow[] session_games = schedule.session_games.Select( SessionTable.PrimaryKey + "='" + schedule_currents.current_session[SessionTable.PrimaryKey] + "'", XDataTable.Number( schedule.session_games ) );

			//DataRow game_row = schedule.games.GetGame( "Game " + (session_games.Length + 1) );
			DataRow newgame = schedule.session_games.AddGroupMember( schedule_currents.current_session, null );
			DataRow copy_to = newgame;
			int idx;
			for( idx = session_games.Length - 1; idx >= 0; idx-- )
			{
				DataRow[] game_patterns = session_games[idx].GetChildRows( "session_game_has_pattern" );
				foreach( DataRow game_pattern in game_patterns )
				{
					game_pattern[SessionGame.PrimaryKey] = copy_to[SessionGame.PrimaryKey];
				}
				DataRow[] session_game_pack_groups = session_games[idx].GetChildRows( "session_game_has_pack_group" );
				foreach( DataRow session_game_pack_group in session_game_pack_groups )
				{
					session_game_pack_group[SessionGame.PrimaryKey] = copy_to[SessionGame.PrimaryKey];
				}
				if( session_games[idx][SessionGame.PrimaryKey].Equals( insert_before_id ) )
					break;
				copy_to = session_games[idx];
			}

		}

		private void textBoxGameCount_TextChanged( object sender, EventArgs e )
		{
		}
		void schedule_currents_SetSessionCurrent( DataRow current )
		{
			textBoxGameCount.Text = schedule_currents.current_session_games.Count.ToString();
		}


		private void buttonRemoveSessionGame_Click( object sender, EventArgs e )
		{
			DataRow remove_game = schedule_currents.current_session_game;
			if( remove_game == null )
			{
				MessageBox.Show( "Must select a session-game to remove" );
				return;
			}
			DataRow[] session_games = schedule.session_games.Select( SessionTable.PrimaryKey + "='" + schedule_currents.current_session[SessionTable.PrimaryKey] + "'", XDataTable.Number( schedule.session_games ) );

			object remove_game_id = remove_game[SessionGame.PrimaryKey];
			DataRow copy_to = null;
			int idx;
			bool found = false;
			bool first = true;
			for( idx = 0; idx < session_games.Length; idx++ )
			{
				if( !found )
				{
					if( !session_games[idx][SessionGame.PrimaryKey].Equals( remove_game_id ) )
						continue;
					found = true;
					copy_to = session_games[idx];
				}
				DataRow[] game_patterns = session_games[idx].GetChildRows( "session_game_has_pattern" );
				foreach( DataRow game_pattern in game_patterns )
				{
					if( first )
						game_pattern.Delete();
					else
						game_pattern[SessionGame.PrimaryKey] = copy_to[SessionGame.PrimaryKey];
				}
				DataRow[] session_game_pack_groups = session_games[idx].GetChildRows( "session_game_has_pack_group" );
				foreach( DataRow session_game_pack_group in session_game_pack_groups )
				{
					if( first )
						session_game_pack_group.Delete();
					else
						session_game_pack_group[SessionGame.PrimaryKey] = copy_to[SessionGame.PrimaryKey];
				}
				first = false;
				copy_to = session_games[idx];
			}
			// remove the last row.  every other game' s content was moved up
			session_games[session_games.Length-1].Delete();
		}

		private void button1_Click( object sender, EventArgs e )
		{
			int count = Convert.ToInt32( textBoxGameCount.Text );
			DataRow[] session_games = schedule.session_games.Select( 
				SessionTable.PrimaryKey + "='" + schedule_currents.current_session[SessionTable.PrimaryKey] + "'"
				, XDataTable.Number( schedule.session_games ) );
			if( session_games.Length > count )
			{
				int idx;
				for( idx = count; idx < session_games.Length; idx++ )
					session_games[idx].Delete();
			}
			else if( session_games.Length < count )
			{
				int idx;
				for( idx = session_games.Length; idx < count; idx++ )
				{
					//DataRow game_row = schedule.games.GetGame( "Game " + (idx + 1) );
					DataRow newgame = schedule.session_games.AddGroupMember( schedule_currents.current_session, null );
				}
			}

		}

		private void addItemToSet2_Click( object sender, EventArgs e )
		{
			Refresh();
		}

		private void fixScheduletmpToolStripMenuItem_Click( object sender, EventArgs e )
		{
			if( StaticDsnConnection.KindExecuteReader( "select hall_id,charity_id from bingo_sched3_session_info" ) != null )
			{
				StaticDsnConnection.KindExecuteNonQuery( "alter table bingo_sched3_session_info drop column hall_id,drop column charity_id" );
				StaticDsnConnection.KindExecuteNonQuery( "alter table bingo_sched3_game_info drop column hall_id,drop column charity_id" );
				StaticDsnConnection.KindExecuteNonQuery( "alter table bingo_sched3_pattern_description drop column hall_id,drop column charity_id" );
				StaticDsnConnection.KindExecuteNonQuery( "alter table bingo_sched3_pack_info drop column hall_id,drop column charity_id" );
				StaticDsnConnection.KindExecuteNonQuery( "alter table bingo_sched3_session_info drop column session_board_size,change column board_size session_board_size int(11) " );
				StaticDsnConnection.KindExecuteNonQuery( "alter table bingo_sched3_pattern_description drop column pattern_board_size,change column board_size pattern_board_size int(11) " );
			}

			{
				StaticDsnConnection.KindExecuteNonQuery( "update bingo_sched3_prize_info as a "
						+ "join bingo_sched3_session_prize_exception_set as b on a.session_id=b.session_id and a.prize_exception_set_id=b.prize_exception_set_id "
						+ "set a.session_prize_exception_set_id=b.session_prize_exception_set_id" );

				StaticDsnConnection.KindExecuteNonQuery( "update bingo_sched3_price_info as a "
						+ "join bingo_sched3_session_price_exception_set as b on a.session_id=b.session_id and a.price_exception_set_id=b.price_exception_set_id "
						+ "set a.session_price_exception_set_id=b.session_price_exception_set_id " );
			}
			schedule.session_games.UpdateAllParts();
		}

		private void groupBox1_Enter( object sender, EventArgs e )
		{

		}

		private void buttonSaveSessionGameChanges_Click( object sender, EventArgs e )
		{
			BindingSourceSessionGame.EndEdit();
			currentSessionGameList1.Refresh();
		}

		private void openSnapshotToolStripMenuItem_Click( object sender, EventArgs e )
		{
			schedule.snapshot = true;
#if use_p2p_events
			schedule.RemoveTableReload( FormTableUpdate );
#endif
			SnapshotSelector form = new SnapshotSelector( ControlList.data );
			form.ShowDialog();
			if( form.DialogResult == System.Windows.Forms.DialogResult.OK )
			{
				object key = form.result_session[SessionTable.PrimaryKey];
				schedule.Fill( key );
			}
#if use_p2p_events
			schedule.SetTableReload( FormTableUpdate );
#endif
		}

		private void button9_Click( object sender, EventArgs e )
		{
			ColorEditor ce = new ColorEditor();
			ce.ShowDialog();
			ce.Dispose();
		}

		private void sessionList1_SelectedIndexChanged( object sender, EventArgs e )
		{
            if( sessionList1.SelectedItem != null )
                if( BindingSourceSessionInfo != null )
                {
                    DataRow myself = ( sessionList1.SelectedItem as DataRowView ).Row;
                    DataRow real = myself;
                    //BindingSourceSessionGameGroupGame.EndEdit();

                    // might not exist for a moment...
                    if( real != null )
                    {
						int a = BindingSourceSessionInfo.Find( XDataTable.ID( real.Table ), real[XDataTable.ID( real.Table )] );
                        BindingSourceSessionInfo.Position = a;
                    }
                }
        }



	}
}
