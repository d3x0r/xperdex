using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using xperdex.classes;

namespace ECube.AccrualProcessor
{
	public partial class ConfigureAccrualForm : Form
	{
		bool filling;
		public ConfigureAccrualForm()
		{
			InitializeComponent();
		}

		void SetupPercentages()
		{
			LinkedList<AccrualGroup.AccrualPercents> data = Local.ConfigureState._current_accrual_group.accrual_percentages;
			dataGridViewPercentages.Rows.Clear();
			dataGridViewPercentages.Columns.Clear();

			dataGridViewPercentages.Columns.Add( "threshold", "Threshold" );
			dataGridViewPercentages.Columns.Add( "primary", "Primary" );
			dataGridViewPercentages.Columns.Add( "secondary", "Secondary" );
			if( Local.ConfigureState.use_tertiary )
				dataGridViewPercentages.Columns.Add( "tertiary", "Tertiary" );
			dataGridViewPercentages.Columns.Add( "kitty", "Kitty" );

			dataGridViewPercentages.Columns[0].Width = 60;
			dataGridViewPercentages.Columns[1].Width = 50;
			dataGridViewPercentages.Columns[2].Width = 60;
			if( Local.ConfigureState.use_tertiary )
			{
				dataGridViewPercentages.Columns[3].Width = 50;
				dataGridViewPercentages.Columns[4].Width = 50;
			}
			else
				dataGridViewPercentages.Columns[3].Width = 50;

			Object[] row = new object[4];
			LinkedListNode<AccrualGroup.AccrualPercents> scan = data.First;
			while( scan != null )
			{
				row[0] = scan.Value.threshold;
				row[1] = scan.Value.primary;
				row[2] = scan.Value.secondary;
				if( Local.ConfigureState.use_tertiary )
				{
					row[3] = scan.Value.tertiary;
					row[3] = scan.Value.kitty;
				}
				else
					row[3] = scan.Value.kitty;
				dataGridViewPercentages.Rows.Add( row );
				scan = scan.Next;
			}
			dataGridViewPercentages.CellValueChanged += new DataGridViewCellEventHandler( dataGridViewPercentages_CellValueChanged );
		}

		void dataGridViewPercentages_CellValueChanged( object sender, DataGridViewCellEventArgs e )
		{
			DataGridViewRow row = dataGridViewPercentages.Rows[e.RowIndex];
			int value1;
			int value2 = 0;
			int value3 = 0;
			int valuek = 0;
			if( row.Cells[1].Value == null )
				row.Cells[1].Value = 0;
			if( row.Cells[2].Value == null )
				row.Cells[2].Value = 0;
			if( row.Cells[3].Value == null )
				row.Cells[3].Value = 0;

			if( Local.ConfigureState.use_tertiary )
			{
				if( row.Cells[4].Value == null )
					row.Cells[4].Value = 0;
				if( !Int32.TryParse( row.Cells[1].Value.ToString(), out value1 )
					|| !Int32.TryParse( row.Cells[2].Value.ToString(), out value2 )
					|| !Int32.TryParse( row.Cells[3].Value.ToString(), out value3 )
					|| !Int32.TryParse( row.Cells[4].Value.ToString(), out valuek ) )
					return;
			}
			else
				if( !Int32.TryParse( row.Cells[1].Value.ToString(), out value1 )
					|| !Int32.TryParse( row.Cells[2].Value.ToString(), out value2 )
					|| !Int32.TryParse( row.Cells[3].Value.ToString(), out valuek ) )
					return;

			switch( e.ColumnIndex )
			{
			case 0: // threshold; no check
				break;
			case 1:
				row.Cells[2].Value = 100 - ( value1 + value3 + valuek );

				break;
			case 2:
				if( Local.ConfigureState.use_tertiary )
					row.Cells[3].Value = 100 - ( value1 + value2 + valuek );
				else
					row.Cells[3].Value = 100 - ( value1 + value2 );
				break;
			case 3:
				if( Local.ConfigureState.use_tertiary )
					row.Cells[4].Value = 100 - ( value1 + value2 + value3 );
				else
					row.Cells[1].Value = 100 - ( value2 + valuek );
				break;
			case 4: // won't be 4 columns if use_tertiaary...
				row.Cells[1].Value = 100 - ( value2 + value3 + valuek );
				break;
			}
		}

		bool ScanPercentages()
		{
			List<AccrualGroup.AccrualPercents> new_data = new List<AccrualGroup.AccrualPercents>();

			foreach( DataGridViewRow dgr in dataGridViewPercentages.Rows )
			{
				Decimal threshold;
				int primary, secondary, tertiary, kitty;

				if( dgr.Cells[0].Value == null ||
					dgr.Cells[1].Value == null ||
					dgr.Cells[2].Value == null ||
					dgr.Cells[3].Value == null )
					continue;

				if( Local.ConfigureState.use_tertiary )
					if( dgr.Cells[4].Value == null )
						continue;
				int col = 0;
				if( !Decimal.TryParse( dgr.Cells[col].Value.ToString(), System.Globalization.NumberStyles.Currency, null, out threshold ) )
				{
					MessageBox.Show( "Error on row " + dgr.Index + " threshold value" );
					return false;
				}
				if( threshold < 0 )
				{
					MessageBox.Show( "Illegale value in threshold. Cannot be less than 0" );
					return false;
				}
				col++;
				if( !Int32.TryParse( dgr.Cells[col].Value.ToString(), out primary ) )
				{
					MessageBox.Show( "Error on row " + dgr.Index + " primary value" );
					return false;
				}
				col++;
				if( primary < 0 )
				{
					MessageBox.Show( "Illegale value in primary percent. Cannot be less than 0" );
					return false;
				}
				if( primary > 100 )
				{
					MessageBox.Show( "Illegale value in primary percent. Cannot be more than than 100" );
					return false;
				}

				if( !Int32.TryParse( dgr.Cells[col].Value.ToString(), out secondary ) )
				{
					MessageBox.Show( "Error on row " + dgr.Index + " secondary value" );
					return false;
				}
				col++;
				if( secondary < 0 )
				{
					MessageBox.Show( "Illegale value in secondary percent. Cannot be less than 0" );
					return false;
				}
				if( secondary > 100 )
				{
					MessageBox.Show( "Illegale value in secondary percent. Cannot be more than than 100" );
					return false;
				}

				if( Local.ConfigureState.use_tertiary )
				{
					if( !Int32.TryParse( dgr.Cells[3].Value.ToString(), out tertiary ) )
					{
						MessageBox.Show( "Error on row " + dgr.Index + " tertiary value" );
						return false;
					}
					col++;
				}
				else
					tertiary = 0;
				if( tertiary < 0 )
				{
					MessageBox.Show( "Illegale value in tertiary percent. Cannot be less than 0" );
					return false;
				}
				if( tertiary > 100 )
				{
					MessageBox.Show( "Illegale value in tertiary percent. Cannot be more than than 100" );
					return false;
				}

				if( !Int32.TryParse( dgr.Cells[col].Value.ToString(), out kitty ) )
				{
					MessageBox.Show( "Error on row " + dgr.Index + " kitty value" );
					return false;
				}

				if( ( primary + secondary + tertiary + kitty ) != 100 )
				{
					MessageBox.Show( "Error on row " + (dgr.Index+1) + " percentages do not total 100" );
					return false;
				}

				new_data.Add( new AccrualGroup.AccrualPercents( threshold, primary, secondary, tertiary, kitty ) );
			}

			LinkedList<AccrualGroup.AccrualPercents> list = Local.ConfigureState._current_accrual_group.accrual_percentages;
			list.Clear();
			int n = 0;
			foreach( AccrualGroup.AccrualPercents data in new_data )
			{
				n++;
				if( list.First == null )
					list.AddFirst( data );
				else
				{
					LinkedListNode<AccrualGroup.AccrualPercents> check = list.First;
					while( check != null )
					{
						if( data.threshold == check.Value.threshold )
						{
							MessageBox.Show( "Multiple percentages found for same threshold value line " + n );
							return false;
						}
						if( data.threshold < check.Value.threshold )
						{
							list.AddBefore( check, data );
							break;
						}
						check = check.Next;
					}
					if( check == null )
						list.AddLast( data );
				}
			}
			Local.ConfigureState._current_accrual_group.SyncPercentages();
			return true;
		}

		private void ConfigureAccrualForm_Load( object sender, EventArgs e )
		{
			filling = true;
			Text = "Configure Accrual - " + Local.ConfigureState._current_accrual_group.Name;
			if( Local.use_program_relation )
			{
				simpleCheckRelationGrid1.current_relation_dataview = Local.current_accrual_group_programs;
				simpleCheckRelationGrid1.source_data_tablename = "some_unique_name_here_programs";
				simpleCheckRelationGrid1.source_data_relation_member_key = "prg_id";
				simpleCheckRelationGrid1.source_data_relation_tablename = "accrual_group_input_programs";
				simpleCheckRelationGrid1.source_data_relation_member_tablename = "program";
				simpleCheckRelationGrid1.display_column_name = "prg_desc";
			}
			else
			{
				simpleCheckRelationGrid1.current_relation_dataview = Local.current_accrual_group_sessions;
				simpleCheckRelationGrid1.source_data_tablename = "some_unique_name_here_sessions";
				simpleCheckRelationGrid1.source_data_relation_member_key = "slt_id";
				simpleCheckRelationGrid1.source_data_relation_tablename = "accrual_group_input_sessions";
				simpleCheckRelationGrid1.source_data_relation_member_tablename = "sesslot";
				simpleCheckRelationGrid1.display_column_name = "slt_desc";
			}
			simpleCheckRelationGridCategories.current_relation_dataview = Local.current_accrual_group_categories;
			simpleCheckRelationGridListPick.current_relation_dataview = Local.current_item_list;
			this.simpleCheckRelationGrid1.DoFill();
			this.simpleCheckRelationGridCategories.DoFill();
			this.simpleCheckRelationGridListPick.DoFill();

			this.FormClosing += ConfigureAccrualForm_FormClosing;
			textBoxSeedValue.Text = Local.ConfigureState._current_accrual_group.SeedValue.ToString( "C" );
			if( !Local.ConfigureState.use_tertiary 
				|| Local.ConfigureState._current_accrual_group._prior_accrument == null )
			{
				textBoxTertiaryValue.Visible = false;
				labelCurrentTertiary.Visible = false;
			}
			else
			{
				textBoxTertiaryValue.Text = Local.ConfigureState._current_accrual_group._prior_accrument.tertiary_end.ToString( "C" );
			}

			if( Local.ConfigureState._current_accrual_group._prior_accrument == null )
			{
				textBoxCurrentBackup.Visible = false;
				labelCurrentBackup.Visible = false;
				textBoxCurrentValue.Visible = false;
				labelCurrentValue.Visible = false;
			}
			else
			{
				textBoxCurrentValue.Text = Local.ConfigureState._current_accrual_group._prior_accrument.primary_end.ToString( "C" );
				textBoxCurrentBackup.Text = Local.ConfigureState._current_accrual_group._prior_accrument.secondary_end.ToString( "C" );
			}

			checkBoxAccrueWeekly.Checked = Local.ConfigureState._current_accrual_group.IsWeeklyAccrual;
			comboBoxDayOfWeek.Items.Add( "Sunday" );
			comboBoxDayOfWeek.Items.Add( "Monday" );
			comboBoxDayOfWeek.Items.Add( "Teusday" );
			comboBoxDayOfWeek.Items.Add( "Wednesday" );
			comboBoxDayOfWeek.Items.Add( "Thursday" );
			comboBoxDayOfWeek.Items.Add( "Friday" );
			comboBoxDayOfWeek.Items.Add( "Saturday" );

			if( checkBoxAccrueWeekly.Checked )
			{
				comboBoxDayOfWeek.SelectedIndex = Local.ConfigureState._current_accrual_group.WeeklyAccrualDay;
				comboBoxDayOfWeek.Visible = true;
			}
			else
				comboBoxDayOfWeek.Visible = false;

			checkBoxDaily.Checked = Local.ConfigureState._current_accrual_group.IsDailyAccrual;
			checkBoxParamutual.Checked = Local.ConfigureState._current_accrual_group.IsParamutualAccrual;
			checkBoxAnySession.Checked = Local.ConfigureState._current_accrual_group.AnySession;
			checkBoxValidations.Checked = Local.ConfigureState._current_accrual_group.UseValidations;
			checkBoxOverride.Checked = Local.ConfigureState._current_accrual_group.PriceOverride;
			textBoxPackPriceOverride.Text = Local.ConfigureState._current_accrual_group.PriceOverrideValue.ToString( "C" );
			textBoxHousePortion.Text = Local.ConfigureState._current_accrual_group.house_percent.ToString();
			textBoxBallCountMax.Text = Local.ConfigureState._current_accrual_group.ball_count_max.ToString();
			textBoxBallCountReset.Text = Local.ConfigureState._current_accrual_group.ball_count_reset.ToString();
			textBoxBallIncrementDays.Text = Local.ConfigureState._current_accrual_group.ball_count_increment_days.ToString();
			textBoxHotballGame.Text = Local.ConfigureState._current_accrual_group.hotball_game_name;

			if( Local.ConfigureState._current_accrual_group.fixedIncrement )
			{
				dataGridViewPercentages.Visible = false;
				if (Local.ConfigureState._current_accrual_group.fixedIncrement_RemainderToPrimary)
				{
					labelPrimaryFixed.Visible = false;
					textBoxPrimaryIncrement.Visible = false;
				}
				else
				{
					labelPrimaryFixed.Visible = true;
					textBoxPrimaryIncrement.Visible = true;
				}
				checkBoxRemainderToSecondary.Visible = true;
				checkBoxRemainderToPrimary.Visible = true;
				if ( Local.ConfigureState._current_accrual_group.fixedIncrement_RemainderToSecondary )
				{
					labelSecondaryFixed.Visible = false;
					textBoxSecondaryIncrement.Visible = false;
					labelTertiaryFixed.Visible = false;
					textBoxTertiaryIncrement.Visible = false;
				}
				else
				{
					labelSecondaryFixed.Visible = true;
					textBoxSecondaryIncrement.Visible = true;
					if( Local.ConfigureState.use_tertiary )
					{
						labelTertiaryFixed.Visible = true;
						textBoxTertiaryIncrement.Visible = true;
					}
				}
			}
			else
			{
				dataGridViewPercentages.Visible = true;
				labelPrimaryFixed.Visible = false;
				labelSecondaryFixed.Visible = false;
				labelTertiaryFixed.Visible = false;
				textBoxPrimaryIncrement.Visible = false;
				checkBoxRemainderToSecondary.Visible = false;
				checkBoxRemainderToPrimary.Visible = false;
				textBoxSecondaryIncrement.Visible = false;
				textBoxTertiaryIncrement.Visible = false;
			}
			textBoxDisplayOrder.Text = Local.ConfigureState._current_accrual_group.display_order.ToString();
			checkBoxFixedIncrement.Checked = Local.ConfigureState._current_accrual_group.fixedIncrement;
			checkBoxRemainderToSecondary.Checked = Local.ConfigureState._current_accrual_group.fixedIncrement_RemainderToSecondary;
			checkBoxRemainderToPrimary.Checked = Local.ConfigureState._current_accrual_group.fixedIncrement_RemainderToPrimary;
			textBoxPrimaryIncrement.Text = Local.ConfigureState._current_accrual_group.primaryIncrement.ToString( "C" );
			textBoxSecondaryIncrement.Text = Local.ConfigureState._current_accrual_group.secondaryIncrement.ToString( "C" );
			textBoxTertiaryIncrement.Text = Local.ConfigureState._current_accrual_group.tertiaryIncrement.ToString( "C" );
			//textBoxPrimaryPercent.Text = Local.ConfigureState._current_accrual_group.primary_percent.ToString(); ;
			//textBoxSecondaryPercent.Text = Local.ConfigureState._current_accrual_group.secondary_percent.ToString(); ;
			//textBoxTertiaryPercent.Text = Local.ConfigureState._current_accrual_group.tertiary_percent.ToString(); ;
			SetupPercentages();
			filling = false;
		}

		void ConfigureAccrualForm_FormClosing( object sender, FormClosingEventArgs e )
		{

			//ScanPercentages();
		}

		private void checkBoxAnySession_CheckedChanged( object sender, EventArgs e )
		{
			if( Local.ConfigureState._current_accrual_group.AnySession = checkBoxAnySession.Checked )
			{
				simpleCheckRelationGrid1.Enabled = false;
				simpleCheckRelationGrid1.Visible = false;
			}
			else
			{
				simpleCheckRelationGrid1.Enabled = true;
				simpleCheckRelationGrid1.Visible = true;
			}
		}

		private void checkBoxValidations_CheckedChanged( object sender, EventArgs e )
		{
			if( Local.ConfigureState._current_accrual_group.UseValidations = checkBoxValidations.Checked )
			{
				simpleCheckRelationGridCategories.Enabled = false;
				simpleCheckRelationGridCategories.Visible = false;
			}
			else
			{
				simpleCheckRelationGridCategories.Enabled = true;
				simpleCheckRelationGridCategories.Visible = true;
			}
		}

		private void buttonApplyChanges_Click(object sender, EventArgs e)
		{

			Decimal number;
			int percent;
			int display_order;
			if( Int32.TryParse( textBoxDisplayOrder.Text, out display_order ) )
				Local.ConfigureState._current_accrual_group.display_order = display_order;
			simpleCheckRelationGrid1.CommitEdit( DataGridViewDataErrorContexts.Commit );
			simpleCheckRelationGridCategories.CommitEdit( DataGridViewDataErrorContexts.Commit );
			Local.ConfigureState._current_accrual_group.IsDailyAccrual = checkBoxDaily.Checked;
			Local.ConfigureState._current_accrual_group.IsParamutualAccrual = checkBoxParamutual.Checked;
			decimal decval;
			bool increment_changed = false;
			int intval;

			Log.log("save 1");
			if( Int32.TryParse( textBoxBallCountMax.Text, out intval ) )
				Local.ConfigureState._current_accrual_group.ball_count_max = intval;
			else
			{
				MessageBox.Show( "Format error in ball count max" );
				return;
			}
			if( Int32.TryParse( textBoxBallCountReset.Text, out intval ) )
				Local.ConfigureState._current_accrual_group.ball_count_reset = intval;
			else
			{
				MessageBox.Show( "Format error in ball count reset" );
				return;
			}
			Log.log("save 2");
			if ( Int32.TryParse( textBoxBallIncrementDays.Text, out intval ) )
				Local.ConfigureState._current_accrual_group.ball_count_increment_days = intval;
			else
			{
				MessageBox.Show( "Format error in ball increment days" );
				return;
			}
			if( Int32.TryParse( textBoxHousePortion.Text, out intval ) )
				Local.ConfigureState._current_accrual_group.house_percent = intval;
			else
			{
				MessageBox.Show( "Format error in house percentage value" );
				return;
			}
			//if( Local
			Log.log("save 3");
			if ( decimal.TryParse( textBoxCurrentValue.Text, System.Globalization.NumberStyles.Currency, null, out decval ) )
			{
				AccrualGroup.Accrument a = Local.ConfigureState._current_accrual_group.prior_accrument;
				a.SetPrimaryValue( decval );
				a.DoMath();
			}
			else
			{
				MessageBox.Show( "Format error in current value" );
				return;
			}
			Log.log("save 4");
			if ( decimal.TryParse( textBoxCurrentBackup.Text, System.Globalization.NumberStyles.Currency, null, out decval ) )
			{
				AccrualGroup.Accrument a = Local.ConfigureState._current_accrual_group.prior_accrument;
				a.SetSecondaryValue( decval );
				a.DoMath();
			}
			else
			{
				MessageBox.Show( "Format error in backup value" );
				return;
			}

			if( Local.ConfigureState._current_accrual_group.fixedIncrement != checkBoxFixedIncrement.Checked )
				increment_changed = true;
			Local.ConfigureState._current_accrual_group.fixedIncrement = checkBoxFixedIncrement.Checked;

			Log.log("save 5");
			if ( decimal.TryParse( textBoxPrimaryIncrement.Text, System.Globalization.NumberStyles.Currency, null, out decval ) )
			{
				Local.ConfigureState._current_accrual_group.primaryIncrement = decval;
			}
			else
			{
				MessageBox.Show( "Format error in primary increment value" );
				return;
			}

			Log.log("save 6");
			if ( decimal.TryParse( textBoxSecondaryIncrement.Text, System.Globalization.NumberStyles.Currency, null, out decval ) )
			{
				Local.ConfigureState._current_accrual_group.secondaryIncrement = decval;
			}
			else
			{
				MessageBox.Show( "Format error in secondary increment value" );
				return;
			}

			Log.log("save 7");
			if ( Local.ConfigureState.use_tertiary )
				if( decimal.TryParse( textBoxTertiaryIncrement.Text, System.Globalization.NumberStyles.Currency, null, out decval ) )
				{
					Local.ConfigureState._current_accrual_group.tertiaryIncrement = decval;
				}
				else
				{
					MessageBox.Show( "Format error in tertiary increment value" );
					return;
				}
	
			if( Local.ConfigureState.use_tertiary )
				if( decimal.TryParse( textBoxTertiaryValue.Text, System.Globalization.NumberStyles.Currency, null, out decval ) )
				{
					AccrualGroup.Accrument a = Local.ConfigureState._current_accrual_group.prior_accrument;
					a.tertiary_transfer = decval - ( a.tertiary_end - a.tertiary_transfer );
					a.DoMath();
				}
				else
				{
					MessageBox.Show( "Format error in tertiary value" );
					return;
				}

			Log.log("save 8");
			if ( Decimal.TryParse( textBoxSeedValue.Text, System.Globalization.NumberStyles.Currency, null, out number ) )
			{
				Local.ConfigureState._current_accrual_group.SeedValue = number;
			}
			Log.log("save 9");
			if ( int.TryParse( textBoxHousePortion.Text, System.Globalization.NumberStyles.Currency, null, out percent ) )
			{
				Local.ConfigureState._current_accrual_group.house_percent = percent;
			}

			Log.log("save 10");
			if ( !Local.ConfigureState._current_accrual_group.fixedIncrement && !ScanPercentages() )
				return;

			{
				//int tmp1, tmp2, tmp3;
				simpleCheckRelationGrid1.CommitEdit( DataGridViewDataErrorContexts.Commit );
				simpleCheckRelationGridCategories.CommitEdit( DataGridViewDataErrorContexts.Commit );
				if( Decimal.TryParse( textBoxSeedValue.Text, System.Globalization.NumberStyles.Currency, null, out number ) )
				{
					Local.ConfigureState._current_accrual_group.SeedValue = number;
				}
				else
				{
					MessageBox.Show( "Number format error in seed value" );
					return;
				}
				if( Decimal.TryParse( textBoxPackPriceOverride.Text, System.Globalization.NumberStyles.Currency, null, out number ) )
				{
					//Log.log( "Update override number..." + number.ToString( "C" ) );
					Local.ConfigureState._current_accrual_group.PriceOverrideValue = number;
				}
				else
				{
					MessageBox.Show( "Number format error in price override" );
					return;
				}
			}
			Log.log("save 11");
			if ( increment_changed )
			{
				AccrualGroup.Accrument a = Local.ConfigureState._current_accrual_group.prior_accrument;
				a.Process();  // compute sales and DoMath
			}
			Log.log("save 12");
			Local.CommitSettingChanges();

			this.Close();
		}

		private void buttonDone_Click( object sender, EventArgs e )
		{
			this.Close();
		}

		private void button4_Click( object sender, EventArgs e )
		{
			int intval;
			if( Int32.TryParse( textBoxHousePortion.Text, System.Globalization.NumberStyles.Currency, null, out intval ) )
				Local.ConfigureState._current_accrual_group.house_percent = intval;
		}

		private void checkBoxFixedIncrement_CheckedChanged( object sender, EventArgs e )
		{
			if( checkBoxFixedIncrement.Checked )
			{
				Local.ConfigureState._current_accrual_group.fixedIncrement = true;
				dataGridViewPercentages.Visible = false;
				if (Local.ConfigureState._current_accrual_group.fixedIncrement_RemainderToPrimary)
				{
					labelPrimaryFixed.Visible = false;
					textBoxPrimaryIncrement.Visible = false;
				}
				else
				{
					labelPrimaryFixed.Visible = true;
					textBoxPrimaryIncrement.Visible = true;
				}
				checkBoxRemainderToPrimary.Visible = true;
				checkBoxRemainderToSecondary.Visible = true;
				if ( Local.ConfigureState._current_accrual_group.fixedIncrement_RemainderToSecondary )
				{
					labelSecondaryFixed.Visible = false;
					textBoxSecondaryIncrement.Visible = false;
					labelTertiaryFixed.Visible = false;
					textBoxTertiaryIncrement.Visible = false;
				}
				else
				{
					labelSecondaryFixed.Visible = true;
					textBoxSecondaryIncrement.Visible = true;
					if( Local.ConfigureState.use_tertiary )
					{
						labelTertiaryFixed.Visible = true;
						textBoxTertiaryIncrement.Visible = true;
					}
				}
			}
			else
			{
				Local.ConfigureState._current_accrual_group.fixedIncrement = false;
				dataGridViewPercentages.Visible = true;
				labelPrimaryFixed.Visible = false;
				labelSecondaryFixed.Visible = false;
				labelTertiaryFixed.Visible = false;
				textBoxPrimaryIncrement.Visible = false;
				checkBoxRemainderToSecondary.Visible = false;
				checkBoxRemainderToPrimary.Visible = false;
				textBoxSecondaryIncrement.Visible = false;
				textBoxTertiaryIncrement.Visible = false;
			}
		}

		private void checkBoxAccrueWeekly_CheckedChanged( object sender, EventArgs e )
		{
			Local.ConfigureState._current_accrual_group.IsWeeklyAccrual = checkBoxAccrueWeekly.Checked;
			if( checkBoxAccrueWeekly.Checked )
				comboBoxDayOfWeek.Visible = true;
			else
				comboBoxDayOfWeek.Visible = false;
		}

		private void comboBoxDayOfWeek_SelectedIndexChanged( object sender, EventArgs e )
		{
			if( !filling )
			{
				int index = comboBoxDayOfWeek.SelectedIndex;
				if( index >= 0 )
					Local.ConfigureState._current_accrual_group.WeeklyAccrualDay = index;
			}
		}

		private void checkBoxRemainderToSecondary_CheckedChanged( object sender, EventArgs e )
		{
			if( checkBoxRemainderToSecondary.Checked )
			{
				Local.ConfigureState._current_accrual_group.fixedIncrement_RemainderToSecondary = true;
				labelSecondaryFixed.Visible = false;
				textBoxSecondaryIncrement.Visible = false;
			}
			else
			{
				Local.ConfigureState._current_accrual_group.fixedIncrement_RemainderToSecondary = false;
				labelSecondaryFixed.Visible = true;
				textBoxSecondaryIncrement.Visible = true;
			}
		}

		private void checkBoxRemainderToPrimary_CheckedChanged(object sender, EventArgs e)
		{
			if (checkBoxRemainderToPrimary.Checked)
			{
				Local.ConfigureState._current_accrual_group.fixedIncrement_RemainderToPrimary = true;
				labelPrimaryFixed.Visible = false;
				textBoxPrimaryIncrement.Visible = false;
			}
			else
			{
				Local.ConfigureState._current_accrual_group.fixedIncrement_RemainderToPrimary = false;
				labelPrimaryFixed.Visible = true;
				textBoxPrimaryIncrement.Visible = true;
			}
		}
	}
}
