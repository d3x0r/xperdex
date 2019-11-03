using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using OpenSkie.Scheduler;
using OpenSkieScheduler3.BingoGameDefs;
using OpenSkieScheduler3.Relations;
using xperdex.classes;

namespace OpenSkieScheduler3.Controls.Forms
{
	public partial class PackEditor : Form
	{
		BindingSource BindingSourcePack;
		int CellSize = 30;
		DataRow[] PackFaces;
		PackControl.PackFace[] FaceButtons;
		DataRow pack;
		String cardset_id;
		String cardset_range_id;
		DataTable PackLevelDataTable;

		ScheduleDataSet schedule;
        ScheduleCurrents data;

		public PackEditor(DataRow pack)
		{
			this.pack = pack;
			schedule = pack.Table.DataSet as ScheduleDataSet;
            data = new ScheduleCurrents( schedule );
			data.SetCurrentPack( pack );
			if( data == null )
			{
				MessageBox.Show( "Pack must be in a Schedule dataset." );
				return;
			}

			cardset_range_id = CardsetRange.PrimaryKey;
			cardset_id = CardsetInfo.PrimaryKey;
			InitializeComponent();
			this.FormClosing += new FormClosingEventHandler( PackEditor_FormClosing );
		}

		void PackEditor_FormClosing( object sender, FormClosingEventArgs e )
		{
			BindingSourcePack.EndEdit();
		}

		
		private void PackEditor_Load( object sender, EventArgs e )
		{
			BindingSourcePack = new BindingSource();
			BindingSourcePack.DataSource = this.pack.Table;
			BindingSourcePack.Position = this.pack.Table.Rows.IndexOf(this.pack);
			DataRow CurrentBinding = ((DataRowView)BindingSourcePack.Current).Row;
			this.Text = "Pack Editor (" + CurrentBinding[OpenSkieScheduler3.PackTable.NameColumn] + ")";			
		
			//listBox1.DataSource = data.packs;
			//listBox1.DisplayMember = XDataTable.Name( data.packs );


            comboBox1.DataSource = schedule.cardset_info;
            comboBox1.DisplayMember = CardsetInfo.NameColumn;

            comboBoxColor.DataSource = schedule.colors;
			comboBoxColor.DisplayMember = ColorInfoTable.NameColumn;
            comboBoxColor.ValueMember = schedule.colors.PrimaryKeyName;

            comboBoxLevelColor.DataSource = schedule.colors;
			comboBoxLevelColor.DisplayMember = ColorInfoTable.NameColumn;
            comboBoxLevelColor.ValueMember = ColorInfoTable.PrimaryKey;


			comboBox2.DataSource = data.current_cardset_ranges;
			comboBox2.DisplayMember = OpenSkieScheduler3.BingoGameDefs.CurrentCardsetRanges.DisplayName;
			//comboBox2.ValueMember = "cardset_range_row";
			//comboBox2.DataBindings.Add( "SelectedValue", data, "current_cardset_ranges.cardset_range_row" );

            comboBox3.DataSource = schedule.prize_level_names;
			comboBox3.DisplayMember = OpenSkieScheduler3.PrizeLevelNames.NameColumn;
			comboBox3.ValueMember = OpenSkieScheduler3.PrizeLevelNames.PrimaryKey;

			
			//PackLevelDataTable = data.prize_level_names.Copy();

			PackLevelDataTable = new DataTable();
			//if( schedule.UseGuid )
			//	PackLevelDataTable.Columns.Add(OpenSkieScheduler.PrizeLevelNames.PrimaryKey, typeof(Guid));
			//else
			PackLevelDataTable.Columns.Add( OpenSkieScheduler3.PrizeLevelNames.PrimaryKey, typeof( int ) );
			PackLevelDataTable.Columns.Add( OpenSkieScheduler3.PrizeLevelNames.NameColumn, typeof( string ) );
			PackLevelDataTable.Columns.Add( "name", typeof( string ) );
			PackLevelDataTable.Columns.Add( "number", typeof( int ) );

            foreach( DataRow LevelRow in schedule.prize_level_names.Rows )
			{
				PackLevelDataTable.Rows.Add( LevelRow[OpenSkieScheduler3.PrizeLevelNames.PrimaryKey]
					, LevelRow[OpenSkieScheduler3.PrizeLevelNames.NameColumn] 
					);
			}

			DataRow PackLevelRow = PackLevelDataTable.NewRow();
			PackLevelRow[OpenSkieScheduler3.PrizeLevelNames.PrimaryKey] = DBNull.Value;
			PackLevelRow[OpenSkieScheduler3.PrizeLevelNames.NameColumn] = "By Faces";
			PackLevelDataTable.Rows.InsertAt(PackLevelRow, 0);

			PackLevelDataTable.AcceptChanges();

			int original_index = 0;
			DataRow original_row = null;
			DataRow[] prizes = pack.GetChildRows( "pack_has_prize_level" );
			/*
			if( prizes.Length == 0 )
			{
				DataRow[] rows = PackLevelDataTable.Select( OpenSkieScheduler.PrizeLevelNames.PrimaryKey + "='" + pack[PrizeLevelNames.PrimaryKey].ToString() + "'" );
				if( rows != null && rows.Length > 0 )
				{
					original_index = PackLevelDataTable.Rows.IndexOf( rows[0] );
					original_row = rows[0];
				}
			}
			*/
			comboBoxPackLevel.DataSource = PackLevelDataTable;
			comboBoxPackLevel.DisplayMember = OpenSkieScheduler3.PrizeLevelNames.NameColumn;
			comboBoxPackLevel.ValueMember = OpenSkieScheduler3.PrizeLevelNames.PrimaryKey;


			listBox2.DataSource = data.current_pack_cardset_ranges;
			//listBox2.DisplayMember = data.current_pack_cardset_ranges.NameColumn;

			textBox1.DataBindings.Add(new Binding("Text", BindingSourcePack, "onsize", true));
			textBoxWidth.DataBindings.Add(new Binding("Text", BindingSourcePack, "width", true));
			textBoxHeight.DataBindings.Add(new Binding("Text", BindingSourcePack, "height", true));
			checkBoxJumpingJackpot.DataBindings.Add( new Binding( "Checked", BindingSourcePack, "jumping_jackpot", true ) );

			//comboBoxPackLevel.DataBindings.Add( new Binding( "SelectedValue", BindingSourcePack
			//	, PrizeLevelNames.PrimaryKey, true ) );
			comboBoxColor.DataBindings.Add( new Binding( "SelectedValue", BindingSourcePack
				, ColorInfoTable.PrimaryKey, true ) );

			try
			{
				if( pack[ColorInfoTable.PrimaryKey].GetType() == typeof( DBNull ) )
					comboBoxColor.SelectedIndex = -1;
			}
			catch { }
			//string tmp = pack[PrizeLevelNames.PrimaryKey].ToString();

			//if( pack[PrizeLevelNames.PrimaryKey].GetType() == typeof( DBNull ) )
			//	comboBoxPackLevel.SelectedIndex = 0;

			//this.textBoxGroupId.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourceAccrual, "accrual_group_id", true));
			
			//UpdateDisplay(this.pack);
		}

		private void listBox1_SelectedIndexChanged( object sender, EventArgs e )
		{
			//pack = ( listBox1.SelectedItem as DataRowView ).Row;
			//data.SetCurrentPack( pack );
			//UpdateDisplay( pack );
		}

		private void comboBox1_SelectedIndexChanged( object sender, EventArgs e )
		{
			if( comboBox1.SelectedItem == null )
				return;
			data.current_cardset_ranges.Cardset = (comboBox1.SelectedItem as DataRowView ).Row;
			if( comboBox2.Items.Count > 0 )
				comboBox2.SelectedIndex = 0;
		}

        void ApplyChanges()
        {
            //if( pack[PrizeLevelNames.PrimaryKey].GetType() == typeof( Int32 ) )
            //    if( Convert.ToInt32( pack[PrizeLevelNames.PrimaryKey] ) == 0 )
            //        pack[PrizeLevelNames.PrimaryKey] = DBNull.Value;

            BindingSourcePack.EndEdit();

            // TO SAVE PACK FACE PRIZE LEVEL 
			if( FaceButtons != null )
				{
					for( int i = 0; i < FaceButtons.Length; i++ )
					{
						if( FaceButtons[i].PrizeLevelId != DBNull.Value )
						{
							DataRow[] Facedr = schedule.pack_face_prize_level.Select( "pack_id = '" + this.pack["pack_id"] + "' AND  face = " + FaceButtons[i].Face );
							if( Facedr.Length == 0 )
							{
								DataRow NewFace = schedule.pack_face_prize_level.NewRow();
								NewFace["pack_id"] = this.pack["pack_id"];
								NewFace["face"] = FaceButtons[i].Face;
								NewFace["prize_level_id"] = FaceButtons[i].PrizeLevelId;
								NewFace["color_id"] = FaceButtons[i].FaceColorId;
								schedule.pack_face_prize_level.Rows.Add( NewFace );
							}
							else
							{
								Facedr[0]["prize_level_id"] = FaceButtons[i].PrizeLevelId;
								Facedr[0][ColorInfoTable.PrimaryKey] = FaceButtons[i].FaceColorId;
							}
						}
					}

					// TO DELETE EXTRA PACK FACE PRIZE LEVEL 
					DataRow[] ExcedFacedr = schedule.pack_face_prize_level.Select( "pack_id = '" + this.pack["pack_id"] + "' AND  face >= " + FaceButtons.Length );
					foreach( DataRow dr in ExcedFacedr )
						dr.Delete();
				}
            MySQLDataTable tmp = this.pack.Table as MySQLDataTable;
            if( tmp != null )
            {
                // call mysql sync... 
                //tmp.CommitChanges();
            }
            else
                this.pack.Table.AcceptChanges();

        }

		private void button1_Click( object sender, EventArgs e )
		{
            ApplyChanges();
		}

		private void button2_Click( object sender, EventArgs e )
		{
			DataRowView drv_range = comboBox2.SelectedItem as DataRowView;
			if( drv_range == null )
			{
				MessageBox.Show( "Please Select a Cardset and\nselect a Range of that cardset." );
				return;
			}
			schedule.pack_cardset_ranges.AddGroupMember( pack, drv_range.Row.GetParentRow( CardsetRange.TableName ) );
		}

		private void button3_Click( object sender, EventArgs e )
		{
			DataRowView drv = listBox2.SelectedItem as DataRowView;
			if( drv == null )
			{
				MessageBox.Show( "Please Select a Cardset and\nselect a Range of that cardset." );
				return;
			}
			DataTable dt = drv.Row.Table;

			drv.Row.Delete();
			dt.AcceptChanges();
		}

		private void ResizeForm()
		{
			this.panelPackSelection.Top = panelPackLayout.Height + 94;
			this.panelPackCardset.Top = panelPackSelection.Top + panelPackSelection.Height + 6;
            //this.buttonCardsetRangeEdit.Top = panelPackCardset.Top + panelPackCardset.Height + 6;
			//this.Height = buttonCardsetRangeEdit.Bottom + 70;
		}


		bool prior_panel_enganged = true;
		private void comboBoxPackLevel_SelectedValueChanged(object sender, EventArgs e)
		{
			if( comboBoxPackLevel.SelectedValue != null )
			{
				DataRowView drv = comboBoxPackLevel.SelectedValue as DataRowView;
				if( drv != null )
				{
					//pack[PrizeLevelNames.PrimaryKey] = drv.Row[0];
				}
			}

			if( comboBoxPackLevel.SelectedValue!=null 
				&& comboBoxPackLevel.SelectedIndex != 0 )
			{
				panelPackSelection.Height = 0;
				comboBox3.SelectedValue = comboBoxPackLevel.SelectedValue;
				
				buttonSelectAll_Click(sender, e);
				buttonChangeLevel_Click(sender, e);
			}
			else
			{
				panelPackSelection.Height = 60;
				textBox_TextChanged(sender, e);
			}
			ResizeForm();
			
		}

		private void textBox_TextChanged(object sender, EventArgs e)
		{
			if( textBoxWidth.Text != "" && textBoxHeight.Text != "" )
			{
				CreatePanel( int.Parse( textBoxWidth.Text ), int.Parse( textBoxHeight.Text ) );
				pack["onsize"] = int.Parse( textBoxWidth.Text ) * int.Parse( textBoxHeight.Text );
				//textBox1.Text = ( int.Parse( textBoxWidth.Text ) * int.Parse( textBoxHeight.Text ) ).ToString();
			}
		}

		private void CreatePanel(int iCols,int iRows)
		{
			
				PackFaces = pack.GetChildRows("pack_face_prize_level_has_prize_level");

			// just docked' the container to the form... so user can resize as needed. (might just have scrollbar option on it too)
				//panelPackLayout.Width = iCols * CellSize;
				//panelPackLayout.Height = iRows * CellSize;
				
				panelPackLayout.Controls.Clear();
				FaceButtons = new PackControl.PackFace[iCols * iRows];

				int i = 0;
				for (int pos_y = 0; pos_y < iRows; pos_y++)
				{
					for (int pos_x = 0; pos_x < iCols; pos_x++)
					{
						FaceButtons[i] = new PackControl.PackFace();
						FaceButtons[i].Location = new Point(CellSize * pos_x, CellSize * pos_y);
						FaceButtons[i].Size = new Size(CellSize, CellSize);

						// IT SHOULD WORK WITH CURRENT PACK FACE ???
						//DataRow[] Facedr = data.current_pack_face_prize_level.Select("face = " + i);
						//DataRow[] Facedr = data.pack_face_prize_level.Select("pack_id = " + this.pack["pack_id"] + " AND  face = " + i);

						// CREATE ALL GENERAL BUTTONS GRAY COLOR
                        FaceButtons[i].SetPack( DBNull.Value, this.pack["pack_id"], DBNull.Value, i
                            , DBNull.Value, Color.FromName( "Gray" ) );

						FaceButtons[i].SetFace(i);
						FaceButtons[i].OnSelectedFace += new PackControl.PackFace.SelectedFace(FaceSelection);
						panelPackLayout.Controls.Add(FaceButtons[i]);

						i++;
					}
				}

				foreach (DataRow dr in PackFaces)
				{
					if (FaceButtons.Length > Convert.ToInt32(dr["face"]))
					{
                        DataRow color_row = dr.GetParentRow( PackFacePrizeLevel.TableName + "_is_color" );

						FaceButtons[Convert.ToInt32(dr["face"])].SetPack(
									dr["pack_face_prize_level_id"]
									, dr["pack_id"]
									, dr["prize_level_id"]
									, Convert.ToInt32(dr["face"])
                                    , dr[ColorInfoTable.PrimaryKey]
                                    , (color_row!=null)?((Color)(color_row["color"])):Color.Gray);
					}
				}
			//ResizeForm();
		}

		private void FaceSelection(PackControl.PackFace Choosen)
		{
			//string choosen = "";
			//for (int i = 0; i < PackButtons.Length; i++)
			//{
			//    if (PackButtons[i].Selected)
			//        choosen += ", " + PackButtons[i].PackName;
			//}
			//labelChoosen.Text = choosen;
		}

		private void OnlyNumbers(object sender, KeyPressEventArgs e)
		{
			if (!Char.IsNumber(e.KeyChar) && e.KeyChar != (char)8)
				e.Handled = true;
		}

		private void buttonSelectAll_Click(object sender, EventArgs e)
		{
			if (FaceButtons != null)
			{
				for (int i = 0; i < FaceButtons.Length; i++)
					FaceButtons[i].SetSelected(true);
			}
		}

		private void buttonUnSelectAll_Click(object sender, EventArgs e)
		{
			if (FaceButtons != null)
			{
				for (int i = 0; i < FaceButtons.Length; i++)
					FaceButtons[i].SetSelected(false);
			}
		}

		private void buttonChangeLevel_Click(object sender, EventArgs e)
		{
            DataRowView drv_color = comboBoxLevelColor.SelectedItem as DataRowView;
			DataRowView drv = comboBox3.SelectedItem as DataRowView;
			if (drv == null)
			{
				MessageBox.Show("Please Select a Level");
				return;
			}
            if( drv_color == null )
            {
                MessageBox.Show( "Please Select a color" );
                return;
            }
            {
                for( int i = 0; i < FaceButtons.Length; i++ )
                {
                    if( FaceButtons[i].Selected )
                    {
                        FaceButtons[i].SetFaceLevel( drv.Row["prize_level_id"], drv_color.Row[ColorInfoTable.PrimaryKey], (Color.FromName(drv_color.Row["color"].ToString())) );
                    }

                }
            }
			buttonUnSelectAll_Click(sender, e);
		}

		private void button4_Click( object sender, EventArgs e )
		{
			ColorEditor ce = new ColorEditor();
			ce.ShowDialog();
			ce.Dispose();
		}

        private void PackEditor_FormClosing_1( object sender, FormClosingEventArgs e )
        {
            ApplyChanges();
        }

        private void buttonCardsetRangeEdit_Click( object sender, EventArgs e )
        {
            CardsetRangeEditor cre = new CardsetRangeEditor();
            cre.ShowDialog();
            cre.Dispose();
        }

	}
}