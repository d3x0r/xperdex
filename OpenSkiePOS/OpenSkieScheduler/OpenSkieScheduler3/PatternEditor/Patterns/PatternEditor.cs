using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using OpenSkieScheduler3;
using xperdex.classes;

namespace BingoGameCore4.Controls
{
	public partial class PatternEditor : Form
	{
		BingoGameCore4.Patterns patterns;
		List<Pattern> multi_patterns; // need seperate list so 'current' doesn't trigger change in multi-pattern
		public List<Pattern> changed_list;
        ScheduleDataSet schedule;
		BindingSource BindingSourcePattern;



		DataTable match_type;

		private void PatternEditor_Load( object sender, EventArgs e )
		{
			tabControl2.Visible = false;
			comboBox1.ValueMember = "ID";
			comboBox1.DisplayMember = "name";
			comboBox1.DataSource = match_type;


			BindingSourcePattern = new BindingSource();
			BindingSourcePattern.PositionChanged += new EventHandler( BindingSourcePattern_PositionChanged );
			BindingSourcePattern.DataSource = this.patterns;

			listBox1.DataSource = BindingSourcePattern;


			changed_list = new List<Pattern>();

			//Binding x;
			//comboBox1.DataBindings.Add( new Binding( "SelectedValue", BindingSourcePattern, "Algorithm", true ) );
			textBoxRepeat.DataBindings.Add( new Binding( "Text", BindingSourcePattern, "repeat_count", true ) );
			checkBoxNoOverlap.DataBindings.Add( new Binding( "Checked", BindingSourcePattern, "repeat_no_overlap", true ) );
			checkBoxCrazyHardway.DataBindings.Add( new Binding( "Checked", BindingSourcePattern, "crazy_hardway", true ) );
			textBoxCrazyCount.DataBindings.Add( new Binding( "Text", BindingSourcePattern, "repeat_count", true ) );

			DataGridViewComboBoxColumn dgvcbc;

			dgvcbc = new DataGridViewComboBoxColumn();
			dgvcbc.HeaderText = "Pattern";
			dgvcbc.ValueType = XDataTable.DefaultAutoKeyType;
            dgvcbc.DataSource = patterns.ToArray();
			dgvcbc.AutoComplete = true;
			dgvcbc.DataPropertyName = dgvcbc.HeaderText;
			dgvcbc.DisplayMember = "Name";
			dgvcbc.ValueMember = "ID";
			dgvcbc.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox;

			dataGridView1.Columns.Add( dgvcbc );

		}


		void init( BingoGameCore4.Patterns patterns, DsnConnection dsn )
		{
			this.patterns = patterns;

			this.multi_patterns = new List<Pattern>();
			foreach( Pattern p in patterns )
				multi_patterns.Add( p );

			{
				match_type = new DataTable();
				match_type.Columns.Add( "ID", typeof( int ) );
				match_type.Columns.Add( "Name", typeof( String ) );


				DataRow dr;

				dr = match_type.NewRow();
				dr["ID"] = PatternDescriptionTable.match_types.NoPattern;
				dr["Name"] = "No Pattern";
				match_type.Rows.Add( dr );

				dr = match_type.NewRow();
				dr["ID"] = PatternDescriptionTable.match_types.Normal;
				dr["Name"] = "Normal";
				match_type.Rows.Add( dr );

				dr = match_type.NewRow();
				dr["ID"] = PatternDescriptionTable.match_types.CrazyMultiCard;
				dr["Name"] = "Crazy Multi-Card";
				match_type.Rows.Add( dr );

				dr = match_type.NewRow();
				dr["ID"] = PatternDescriptionTable.match_types.TopMiddleBottom;
				dr["Name"] = "Top-Middle-Bottom";
				match_type.Rows.Add( dr );

				dr = match_type.NewRow();
				dr["ID"] = PatternDescriptionTable.match_types.TwoGroups;
				dr["Name"] = "2 Groups";
				match_type.Rows.Add( dr );

				dr = match_type.NewRow();
				dr["ID"] = PatternDescriptionTable.match_types.TwoGroupsNoOver;
				dr["Name"] = "2 Groups(No Overlap)";
				match_type.Rows.Add( dr );

				dr = match_type.NewRow();
				dr["ID"] = PatternDescriptionTable.match_types.TwoGroupsPrime;
				dr["Name"] = "2 Groups(Prime)";
				match_type.Rows.Add( dr );

				dr = match_type.NewRow();
				dr["ID"] = PatternDescriptionTable.match_types.TwoGroupsPrimeNoOver;
				dr["Name"] = "2 Groups(Prime,NoOver)";
				match_type.Rows.Add( dr );

				dr = match_type.NewRow();
                dr["ID"] = PatternDescriptionTable.match_types.CrazyMark;
                dr["Name"] = "Crazy";
                match_type.Rows.Add( dr );

                dr = match_type.NewRow();
                dr["ID"] = PatternDescriptionTable.match_types.ExternalJavaEngine;
                dr["Name"] = "External Java Engine";
                match_type.Rows.Add(dr);

                match_type.AcceptChanges();
            }

			InitializeComponent();
		}
		 ~PatternEditor()
		{
			match_type.Dispose();
		}

        //public PatternEditor( BingoGameCore3.Patterns patterns )
		//{
		//	init( patterns, null );
		//}

        public PatternEditor( OpenSkieScheduler3.ScheduleDataSet schedule )
		{
            BingoGameCore4.Patterns list = new BingoGameCore4.Patterns( schedule );
            this.schedule = schedule;
            if( schedule.patterns != null )
			{
				foreach( DataRow row in schedule.patterns.Rows )
					list.Add( new Pattern( row, list ) );
			}
			init( list, null );
		}
        public PatternEditor( DsnConnection dsn, OpenSkieScheduler3.ScheduleDataSet schedule )
		{
            BingoGameCore4.Patterns list = new BingoGameCore4.Patterns( schedule );
            foreach( DataRow row in schedule.patterns.Rows )
                list.Add( new Pattern( row, list ) );
			init( list, dsn );
		}

		public bool IsMultiPattern( Pattern p )
		{
			return p.IsMultiPattern();
		}

		void FillMultiPatternList()
		{
			Pattern p = BindingSourcePattern.Current as Pattern;
			if( IsMultiPattern(p) )
			{
                //dataGridView1.DataSource = p.sub_patterns;
                object[] arr = new object[1];
				dataGridView1.Rows.Clear();
				foreach( Pattern pattern in p.sub_patterns )
				{
					arr[0] = pattern.ID;
					dataGridView1.Rows.Add( arr );
				}

				checkBox2.Checked = ( ( p.mode_mod & Pattern.mode_modifications.SingleCard ) != 0 );
				checkBoxMultiPatternOrderDependant.Checked = ( ( p.mode_mod & Pattern.mode_modifications.OrderMatters ) != 0 );
			}
		}

		void UpdateFromMultiPatternList()
		{
			Pattern p = BindingSourcePattern.Current as Pattern;

			if( IsMultiPattern(p) )
			{
                int n = 0;
				Pattern.mode_modifications old_mod = p.mode_mod;
                bool different = false;
				bool changed = false;
				p.mode_mod &= ~Pattern.mode_modifications.SingleCard;
				p.mode_mod &= ~Pattern.mode_modifications.OrderMatters;

				if( checkBox2.Checked )
					p.mode_mod |= Pattern.mode_modifications.SingleCard;
				if( checkBoxMultiPatternOrderDependant.Checked )
					p.mode_mod |= Pattern.mode_modifications.OrderMatters;

				if( p.mode_mod != old_mod )
					p.changed = true;
				foreach( DataGridViewRow row_view in dataGridView1.Rows )
                {
                    if( row_view.Cells[0].Value != null )
                    {
                        if( n >= p.sub_patterns.Count )
                        {
                            if( row_view.Cells[0].Value != null )
                            {
                                different = true;
                            }
                            break;
                        }
                        object find_id = row_view.Cells[0].Value;
                        foreach( Pattern find_pat in patterns )
                        {
                            if( find_pat.ID == find_id )
                            {
                                if( p.sub_patterns[n] != find_pat )
                                {
                                    different = true;
                                }
                                break;
                            }
                        }
                        n++;
                    }
                }
                if( different )
                {
                    p.sub_patterns.Clear();
                    foreach( DataGridViewRow row_view in dataGridView1.Rows )
                    {                        
                        if( row_view.Cells[0].Value != null )
                        {
                            Object find_id = row_view.Cells[0].Value;
                            foreach( Pattern find_pat in patterns )
                                if( find_pat.ID == find_id )
                                {
                                    p.sub_patterns.Add( find_pat );
                                    break;
                                }
                        }
                    }
                    p.sub_pattern_changed = true;
				}
			}
		}


		void BindingSourcePattern_PositionChanged( object sender, EventArgs e )
		{
			Pattern p = BindingSourcePattern.Current as Pattern;
			// if( p )
			if( p != null )
			{
				Pattern old_pattern = patternBlockGroup1.pattern;
				if( old_pattern != null )
				{
					//old_pattern.algorithm = Convert.ToInt32( comboBox1.SelectedValue );
					if( old_pattern.changed )
					{
						if( changed_list.IndexOf( old_pattern ) == -1 )
							changed_list.Add( old_pattern );
					}
				}
				if( patternBlockGroup1.pattern != p )
				{
					// read old values? no- discard unless applied.
					// check and warn?
					p.UpdateBits(); // loads bits from pattern_data
                    patterns.UpdateSubPatterns( p );
                    //patternBlockGroup1.pattern = p;
				}
				//comboBox1.SelectedValue = p.algorithm;
				BindingSourcePattern.Position = patterns.IndexOf( p );

                comboBox1.SelectedValue = (int)p.algorithm;
				FillMultiPatternList();
				patternBlockGroup1.pattern = p;

				//ControlList.data.SetCurrentPattern( p.row );

				radioButtonAnywhere.Checked = false;
				radioButtonNoExpand.Checked = false;
				radioButtonNoOverlap.Checked = false;
				radioButtonAnyRotationHardway.Checked = false;
				radioButtonAnyRotation.Checked = false;
				checkBoxAllowMirror.Checked = false;
                radioButtonMustOverlap.Checked = false;
                radioButtonNoOverlap.Checked = false;
                radioButtonOverlapOk.Checked = false;
                checkBoxSingleCard.Checked = false;

				switch( p.mode_mod )
				{
				case Pattern.mode_modifications.NoExpansion :
					radioButtonNoExpand.Checked = true;
					break;
				case Pattern.mode_modifications.Anywhere :
					radioButtonAnywhere.Checked = true;
					break;
				case Pattern.mode_modifications.AnywhereHardway :
					radioButtonAnyHardway.Checked = true;
					break;
				case Pattern.mode_modifications.Anydirection:
					radioButtonAnyRotation.Checked = true;
					break;
				case Pattern.mode_modifications.AnydirectionHardway:
					radioButtonAnyRotationHardway.Checked = true;
					break;
				case Pattern.mode_modifications.AnyWhereAnyDirection:
					radioButtonAnyWhereAnyRotation.Checked = true;
					break;
				case Pattern.mode_modifications.AnyWhereAnyDirectionHardway:
					radioButtonAnyWhereAnyRotationHardway.Checked = true;
					break;
				case Pattern.mode_modifications.MirrorAnydirection:
					radioButtonAnyRotation.Checked = true;
					checkBoxAllowMirror.Checked = true;
					break;
				case Pattern.mode_modifications.MirrorAnydirectionHardway:
					radioButtonAnyRotationHardway.Checked = true;
					checkBoxAllowMirror.Checked = true;
					break;
				case Pattern.mode_modifications.MirrorAnyWhereAnyDirection:
					radioButtonAnyWhereAnyRotation.Checked = true;
					checkBoxAllowMirror.Checked = true;
					break;
				case Pattern.mode_modifications.MirrorAnyWhereAnyDirectionHardway:
					radioButtonAnyWhereAnyRotationHardway.Checked = true;
					checkBoxAllowMirror.Checked = true;
					break;
				case Pattern.mode_modifications.OverlapOK:
                    radioButtonOverlapOk.Checked = true;
                    break;
                case Pattern.mode_modifications.MustOverlap:
                    radioButtonMustOverlap.Checked = true;
                    break;
                case Pattern.mode_modifications.NoOverlap:
                    radioButtonNoOverlap.Checked = true;
                    break;
                case Pattern.mode_modifications.OverlapOK | Pattern.mode_modifications.SingleCard:
                    radioButtonOverlapOk.Checked = true;
                    checkBoxSingleCard.Checked = true;
                    break;
                case Pattern.mode_modifications.MustOverlap | Pattern.mode_modifications.SingleCard:
                    radioButtonMustOverlap.Checked = true;
                    checkBoxSingleCard.Checked = true;
                    break;
                case Pattern.mode_modifications.NoOverlap | Pattern.mode_modifications.SingleCard:
                    radioButtonNoOverlap.Checked = true;
                    checkBoxSingleCard.Checked = true;
                    break;
                }
			}
		}

		private void buttonUndo_Click( object sender, EventArgs e )
		{
			patternBlockGroup1.pattern = BindingSourcePattern.Current as Pattern;
		}

		void ApplyChanges( Pattern p )
		{
			if( IsMultiPattern( p ) )
			{
				UpdateFromMultiPatternList();
			}

			if( ( Convert.ToInt32( comboBox1.SelectedValue ) == (int)PatternDescriptionTable.match_types.Normal )
			   || ( Convert.ToInt32( comboBox1.SelectedValue ) == (int)PatternDescriptionTable.match_types.TwoGroups )
				)
			{
				if( patternBlockGroup1.ReadPattern() )
					if( changed_list.IndexOf( p ) == -1 )
						changed_list.Add( p );
				patternBlockGroup1.pattern = p;
			}

			// also do the update/undo action to realign patternbox.
			if( p.changed || p.sub_pattern_changed )
			{
				p.UpdateRow();
			}

			// we don't really need changedlist anymore (or save on exit)
			// that was from live connection days...
			changed_list.Remove( p );
			p.HasChanges = false;
		}

		private void buttonApply_Click( object sender, EventArgs e )
		{
			Pattern p = BindingSourcePattern.Current as Pattern;
			if( p == null )
			{
				MessageBox.Show( "Pattern was not selected, not applying changes." );
				return;
			}
			ApplyChanges( p );
		
		}

		private void buttonCreate_Click( object sender, EventArgs e )
		{
			try
			{
                BindingSourcePattern.Add(new Pattern(schedule, patterns));
			}
			catch( System.Reflection.TargetInvocationException tie )
			{
				if( tie.InnerException != null && tie.InnerException.GetType() == typeof( NullReferenceException ) )
				{
					// ok.
				}
				else
				{
					MessageBox.Show( "Failed to create pattern.\nThe pattern name already exists?" );
					Log.log( "Exception during pattern creation... " );
				}
			}
			catch
			{
				MessageBox.Show( "Failed to create pattern.\nThe pattern name already exists?" );
				Log.log( "Exception during pattern creation... " );
			}
		}

		private void buttonAddBlock_Click( object sender, EventArgs e )
		{
			Pattern p = BindingSourcePattern.Current as Pattern;
			if( !changed_list.Contains( p ) )
				changed_list.Add( p );
			patternBlockGroup1.AddBlock();
		}

		private void buttonRename_Click( object sender, EventArgs e )
		{
			xperdex.classes.QueryNewName qnn = new xperdex.classes.QueryNewName( "Enter new pattern name" );
			qnn.ShowDialog();
			if( qnn.DialogResult == DialogResult.OK )
			{
				Pattern p = BindingSourcePattern.Current as Pattern;
				// if( p )
				if( p != null )
				{
					p.Name = qnn.textBox1.Text;
					BindingSourcePattern.ResetItem( BindingSourcePattern.Position );
					if( changed_list.IndexOf( p ) == -1 )
						changed_list.Add( p );
					//listBox1.DataSource = null;
					//listBox1.DataSource = patterns;
				}
			}
		}

		private void buttonCopy_Click( object sender, EventArgs e )
		{
			xperdex.classes.QueryNewName qnn = new xperdex.classes.QueryNewName( "Enter new pattern name" );
			qnn.ShowDialog();
			if( qnn.DialogResult == DialogResult.OK )
			{
				Pattern p;
				BindingSourcePattern.Add( p = new Pattern( BindingSourcePattern.Current as Pattern ) );
				// if( p )
				if( p != null )
				{
					p.Name = qnn.textBox1.Text;
					BindingSourcePattern.ResetItem( patterns.IndexOf( p ) );
					p.UpdateRow();
				}
			}

		}

		private void buttonDeletePattern_Click( object sender, EventArgs e )
		{
			Pattern p = BindingSourcePattern.Current as Pattern;
			// if( p )
			if( p != null )
			{
				BindingSourcePattern.RemoveCurrent();

				//patterns.Remove( p );
				p.row.Delete();
				if( changed_list.IndexOf( p ) == -1 )
					changed_list.Add( p );
			}
		}

		private void PatternEditor_FormClosing( object sender, FormClosingEventArgs e )
		{
			if( changed_list.Count == 0 )
				return;
			DialogResult result = MessageBox.Show( "Saving any changes..." + changed_list.Count + " Patterns pending..."
				+ " \n If this does not close, there may have\nbeen an error in saving.\n Cancel will attempt to undo pending changes...."
				, "Probably Pending Deletions"
				, MessageBoxButtons.OKCancel );
			if( result == DialogResult.OK )
			{
				foreach( Pattern p in changed_list )
				{
					p.UpdateRow();
				}
				changed_list.Clear();
			}
			else
			{
				foreach( Pattern p in changed_list )
				{
					p.row.RejectChanges();
					BindingSourcePattern.ResetItem( patterns.IndexOf( p ) );
				}
				changed_list.Clear();
			}
		}

		private void comboBox1_SelectedIndexChanged( object sender, EventArgs e )
		{
			int new_value = Convert.ToInt32( comboBox1.SelectedValue );
			BingoGameCore4.Controls.Patterns.PatternBlockGroup pattern_blocks = tabPage1.Controls["patternBlockGroup1"] as BingoGameCore4.Controls.Patterns.PatternBlockGroup;

			Pattern p = ( BindingSourcePattern != null && ( BindingSourcePattern.Position >= 0 ) ) ? patterns[BindingSourcePattern.Position] : null;

			if( pattern_blocks != null )
				pattern_blocks.pattern = p;

			if( new_value != -1 && p == null )
			{
				//comboBox1.SelectedValue = -1;
				//MessageBox.Show( "Pattern was not selected, cannot change match type..." );
				//throw new Exception( "Pattern was not selected, cannot change match type..." );
				return;
			}

			if( p != null )
                p.algorithm = (PatternDescriptionTable.match_types) new_value;

            if( new_value == (int)PatternDescriptionTable.match_types.NoPattern )
			{
				tabControl1.TabPages.Remove( tabPage1 );
				tabControl2.TabPages.Add( tabPage1 );
				tabControl1.TabPages.Remove( tabPage2 );
				tabControl2.TabPages.Add( tabPage2 );
				tabControl1.TabPages.Remove( tabPage3 );
				tabControl2.TabPages.Add( tabPage3 );
				tabControl1.TabPages.Remove( tabPageJavaServer );
				tabControl2.TabPages.Add( tabPageJavaServer );
			}
			else if( new_value == (int)PatternDescriptionTable.match_types.Normal )
			{
				if( tabControl1.TabPages.IndexOf( tabPage3 ) >= 0 )
				{
					tabControl1.TabPages.Remove( tabPage3 );
					tabControl2.TabPages.Add( tabPage3 );
				}
				if( tabControl1.TabPages.IndexOf( tabPage2 ) >= 0 )
				{
					tabControl1.TabPages.Remove( tabPage2 );
					tabControl2.TabPages.Add( tabPage2 );
				}
				if( tabControl1.TabPages.IndexOf( tabPageJavaServer ) >= 0 )
				{
					tabControl1.TabPages.Remove( tabPageJavaServer );
					tabControl2.TabPages.Add( tabPageJavaServer );
				}
				if( tabControl2.TabPages.IndexOf( tabPage1 ) >= 0 )
				{
					tabControl2.TabPages.Remove( tabPage1 );
					tabControl1.TabPages.Add( tabPage1 );
				}
			}
			else if( ( new_value == (int)PatternDescriptionTable.match_types.TwoGroups )
					|| ( new_value == (int)PatternDescriptionTable.match_types.TwoGroupsPrimeNoOver )
					|| ( new_value == (int)PatternDescriptionTable.match_types.TwoGroupsPrime )
					|| ( new_value == (int)PatternDescriptionTable.match_types.TwoGroupsNoOver ) )
			{
				if( tabControl1.TabPages.IndexOf( tabPage3 ) >= 0 )
				{
					tabControl1.TabPages.Remove( tabPage3 );
					tabControl2.TabPages.Add( tabPage3 );
				}
				if( tabControl1.TabPages.IndexOf( tabPage2 ) >= 0 )
				{
					tabControl1.TabPages.Remove( tabPage2 );
					tabControl2.TabPages.Add( tabPage2 );
				}
				if( tabControl1.TabPages.IndexOf( tabPageJavaServer ) >= 0 )
				{
					tabControl1.TabPages.Remove( tabPageJavaServer );
					tabControl2.TabPages.Add( tabPageJavaServer );
				}
				if( tabControl2.TabPages.IndexOf( tabPage1 ) >= 0 )
				{
					tabControl2.TabPages.Remove( tabPage1 );
					tabControl1.TabPages.Add( tabPage1 );
				}
			}
			else if( new_value == (int)PatternDescriptionTable.match_types.ExternalJavaEngine )
			{
				if( tabControl1.TabPages.IndexOf( tabPage3 ) >= 0 )
				{
					tabControl1.TabPages.Remove( tabPage3 );
					tabControl2.TabPages.Add( tabPage3 );
				}
				if( tabControl1.TabPages.IndexOf( tabPage2 ) >= 0 )
				{
					tabControl1.TabPages.Remove( tabPage2 );
					tabControl2.TabPages.Add( tabPage2 );
				}
				if( tabControl1.TabPages.IndexOf( tabPage1 ) >= 0 )
				{
					tabControl1.TabPages.Remove( tabPage1 );
					tabControl2.TabPages.Add( tabPage1 );
				}
				if( tabControl2.TabPages.IndexOf( tabPageJavaServer ) >= 0 )
				{
					tabControl2.TabPages.Remove( tabPageJavaServer );
					tabControl1.TabPages.Add( tabPageJavaServer );
				}
			}
			else if( IsMultiPattern( p ) )
			{
                DataGridViewComboBoxColumn dgvcbc;
                dgvcbc = dataGridView1.Columns[0] as DataGridViewComboBoxColumn;
                dgvcbc.DataSource = patterns.ToArray();

				if( tabControl1.TabPages.IndexOf( tabPage3 ) >= 0 )
				{
					tabControl1.TabPages.Remove( tabPage3 );
					tabControl2.TabPages.Add( tabPage3 );
				}
				if( tabControl1.TabPages.IndexOf( tabPage1 ) >= 0 )
				{
					tabControl1.TabPages.Remove( tabPage1 );
					tabControl2.TabPages.Add( tabPage1 );
				}

				if( tabControl1.TabPages.IndexOf( tabPageJavaServer ) >= 0 )
				{
					tabControl1.TabPages.Remove( tabPageJavaServer );
					tabControl2.TabPages.Add( tabPageJavaServer );
				}
				if( tabControl2.TabPages.IndexOf( tabPage2 ) >= 0 )
				{
					tabControl2.TabPages.Remove( tabPage2 );
					tabControl1.TabPages.Add( tabPage2 );
				}
			}
			else if( new_value == (int)PatternDescriptionTable.match_types.CrazyMark )
			{
				if( tabControl1.TabPages.IndexOf( tabPage1 ) >= 0 )
				{
					tabControl1.TabPages.Remove( tabPage1 );
					tabControl2.TabPages.Add( tabPage1 );
				}
				if( tabControl1.TabPages.IndexOf( tabPage2 ) >= 0 )
				{
					tabControl1.TabPages.Remove( tabPage2 );
					tabControl2.TabPages.Add( tabPage2 );
				}

				if( tabControl1.TabPages.IndexOf( tabPageJavaServer ) >= 0 )
				{
					tabControl1.TabPages.Remove( tabPageJavaServer );
					tabControl2.TabPages.Add( tabPageJavaServer );
				}
				if( tabControl2.TabPages.IndexOf( tabPage3 ) >= 0 )
				{
					tabControl2.TabPages.Remove( tabPage3 );
					tabControl1.TabPages.Add( tabPage3 );
				}

			}
		}

		private void button1_Click( object sender, EventArgs e )
		{
			Pattern p = BindingSourcePattern.Current as Pattern;
			if( changed_list.Contains( p ) || p.HasChanges )
				if( MessageBox.Show( "Pattern has changes, apply changes?", "Pattern has Changes", MessageBoxButtons.YesNo ) == System.Windows.Forms.DialogResult.Yes )
					ApplyChanges( p );
            BingoGameCore4.Controls.Patterns.ShowExpandedPattern show = new BingoGameCore4.Controls.Patterns.ShowExpandedPattern( p );
			show.ShowDialog();
		}

		private void radioButton5_CheckedChanged( object sender, EventArgs e )
		{
			if( radioButtonNoExpand.Checked )
			{
				Pattern p = BindingSourcePattern.Current as Pattern;
				if( p != null )
				{
					p.mode_mod = Pattern.mode_modifications.NoExpansion;
				}
			}
		}

		private void radioButton1_CheckedChanged( object sender, EventArgs e )
		{
			if( radioButtonAnywhere.Checked )
			{
				Pattern p = BindingSourcePattern.Current as Pattern;
				if( p != null )
				{
					p.mode_mod = Pattern.mode_modifications.Anywhere;
				}
			}
		}

		private void radioButton2_CheckedChanged( object sender, EventArgs e )
		{
			if( radioButtonAnyRotation.Checked )
			{
				Pattern p = BindingSourcePattern.Current as Pattern;
				if( p != null )
				{
					if( checkBoxAllowMirror.Checked )
						p.mode_mod = Pattern.mode_modifications.MirrorAnydirection;
					else
						p.mode_mod = Pattern.mode_modifications.Anydirection;
				}
			}
		}

		private void radioButton3_CheckedChanged( object sender, EventArgs e )
		{
			if( radioButtonAnyHardway.Checked )
			{
				Pattern p = BindingSourcePattern.Current as Pattern;
				if( p != null )
				{
					p.mode_mod = Pattern.mode_modifications.AnywhereHardway;
				}
			}
		}

		private void radioButton4_CheckedChanged( object sender, EventArgs e )
		{
			if( radioButtonAnyRotationHardway.Checked )
			{
				Pattern p = BindingSourcePattern.Current as Pattern;
				if( p != null )
				{
					if( checkBoxAllowMirror.Checked )
						p.mode_mod = Pattern.mode_modifications.MirrorAnydirectionHardway;
					else
						p.mode_mod = Pattern.mode_modifications.AnydirectionHardway;
				}
			}
		}

		private void checkBoxAllowMirror_CheckedChanged( object sender, EventArgs e )
		{
			Pattern p = BindingSourcePattern.Current as Pattern;
			if( p != null )
			{
				switch( p.mode_mod )
				{
				case Pattern.mode_modifications.AnydirectionHardway:
					if( checkBoxAllowMirror.Checked )
						p.mode_mod = Pattern.mode_modifications.MirrorAnydirectionHardway;
					break;
				case Pattern.mode_modifications.Anydirection:
					if( checkBoxAllowMirror.Checked )
						p.mode_mod = Pattern.mode_modifications.MirrorAnydirection;
					break;
				case Pattern.mode_modifications.AnyWhereAnyDirectionHardway:
					if( checkBoxAllowMirror.Checked )
						p.mode_mod = Pattern.mode_modifications.MirrorAnyWhereAnyDirectionHardway;
					break;
				case Pattern.mode_modifications.AnyWhereAnyDirection:
					if( checkBoxAllowMirror.Checked )
						p.mode_mod = Pattern.mode_modifications.MirrorAnyWhereAnyDirection;
					break;
				case Pattern.mode_modifications.MirrorAnydirectionHardway:
					if( !checkBoxAllowMirror.Checked )
						p.mode_mod = Pattern.mode_modifications.AnydirectionHardway;
					break;
				case Pattern.mode_modifications.MirrorAnydirection:
					if( !checkBoxAllowMirror.Checked )
						p.mode_mod = Pattern.mode_modifications.Anydirection;
					break;
				case Pattern.mode_modifications.MirrorAnyWhereAnyDirectionHardway:
					if( !checkBoxAllowMirror.Checked )
						p.mode_mod = Pattern.mode_modifications.AnyWhereAnyDirectionHardway;
					break;
				case Pattern.mode_modifications.MirrorAnyWhereAnyDirection:
					if( !checkBoxAllowMirror.Checked )
						p.mode_mod = Pattern.mode_modifications.AnyWhereAnyDirection;
					break;

				}
			}			
		}

		private void checkBoxNoOverlap_CheckedChanged( object sender, EventArgs e )
		{
			Pattern p = BindingSourcePattern.Current as Pattern;
			if( p != null )
			{
				p.repeat_no_overlap = checkBoxNoOverlap.Checked;
			}
		}

        private void checkBox2_CheckedChanged( object sender, EventArgs e )
        {
            buttonExpand2.Visible = checkBoxSingleCard.Checked;
            Pattern p = BindingSourcePattern.Current as Pattern;
            if( p != null )
            {
                p.mode_mod = p.mode_mod & ( Pattern.mode_modifications.max_mod - 1 );
                p.mode_mod |= checkBoxSingleCard.Checked ? Pattern.mode_modifications.SingleCard : 0;
            }
        }

        private void buttonExpand2_Click( object sender, EventArgs e )
        {
            BingoGameCore4.Controls.Patterns.ShowExpandedPattern show
                = new BingoGameCore4.Controls.Patterns.ShowExpandedPattern( BindingSourcePattern.Current as Pattern );
            show.ShowDialog();

        }

        private void radioButtonOverlapOk_CheckedChanged( object sender, EventArgs e )
        {
            if( radioButtonOverlapOk.Checked )
            {
                Pattern p = BindingSourcePattern.Current as Pattern;
                if( p != null )
                {
                    p.mode_mod = Pattern.mode_modifications.OverlapOK;
                }

            }
        }

        private void radioButtonMustOverlap_CheckedChanged( object sender, EventArgs e )
        {
            if( radioButtonMustOverlap.Checked )
            {
                Pattern p = BindingSourcePattern.Current as Pattern;
                if( p != null )
                {
                    p.mode_mod = Pattern.mode_modifications.MustOverlap;
                }
            }

        }

        private void radioButtonNoOverlap_CheckedChanged( object sender, EventArgs e )
        {
            if( radioButtonNoOverlap.Checked )
            {
                Pattern p = BindingSourcePattern.Current as Pattern;
                if( p != null )
                {
                    p.mode_mod |= Pattern.mode_modifications.NoOverlap;
                }
            }
			else
			{
				Pattern p = BindingSourcePattern.Current as Pattern;
				if( p != null )
				{
					p.mode_mod &= ~Pattern.mode_modifications.NoOverlap;
				}
			}
		}

		private void checkBox1_CheckedChanged( object sender, EventArgs e )
		{
			if( radioButtonNoOverlap.Checked )
			{
				Pattern p = BindingSourcePattern.Current as Pattern;
				if( p != null )
				{
					p.mode_mod |= Pattern.mode_modifications.OrderMatters;
				}
			}
			else
			{
				Pattern p = BindingSourcePattern.Current as Pattern;
				if( p != null )
				{
					p.mode_mod &= ~Pattern.mode_modifications.OrderMatters;
				}
			}
		}

		private void radioButtonAnyWhereAnyRotation_CheckedChanged( object sender, EventArgs e )
		{
			if( radioButtonAnyWhereAnyRotation.Checked )
			{
				Pattern p = BindingSourcePattern.Current as Pattern;
				if( p != null )
				{
					p.mode_mod = Pattern.mode_modifications.AnyWhereAnyDirection;
				}
			}
		}

		private void radioButtonAnyWhereAnyRotationHardway_CheckedChanged( object sender, EventArgs e )
		{
			if( radioButtonAnyWhereAnyRotationHardway.Checked )
			{
				Pattern p = BindingSourcePattern.Current as Pattern;
				if( p != null )
				{
					p.mode_mod = Pattern.mode_modifications.AnyWhereAnyDirectionHardway;
				}
			}

		}

	}
}
