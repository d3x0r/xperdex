using System;
using System.Drawing;
using System.Windows.Forms;
using xperdex.core.common.Text_Layout;
using xperdex.gui;

namespace xperdex.core
{
	public partial class TextPlacementEditor : Form
	{
		//TextLayout editing_layout;
		public TextPlacementEditor()
		{
			InitializeComponent();
		}

		void listBox2_SelectedValueChanged( object sender, EventArgs e )
		{
			
		}

		int original_width;
		int original_height;

		private void TextPlacementEditor_Load( object sender, EventArgs e )
		{
			original_width = textPlacementLayoutEditor1.Width;
			original_height = textPlacementLayoutEditor1.Height;
			listBoxFonts.DataSource = FontEditor.fonts;
			listBoxFonts.SelectedValueChanged += new EventHandler( listBox2_SelectedValueChanged );
			listBoxLayout.DataSource = core_common.layouts;
			trackBarSampelVert.Minimum = -100;
			trackBarSampelVert.Maximum = -1;
			trackBarSampelVert.Value = -100;
			trackBarSampleHoriz.Minimum = 1;
			trackBarSampleHoriz.Maximum = 100;
			trackBarSampleHoriz.Value = 100;
			
		}

		private void listBoxLayout_SelectedValueChanged( object sender, EventArgs e )
		{
			TextLayout layout = listBoxLayout.SelectedItem as TextLayout;
			if( layout != null )
			{
				textPlacementLayoutEditor1.UpdateEditingLayout( layout );
				listBoxLabel.DataSource = layout.placements;
			}
		}

		private void buttonCreateLayout_Click( object sender, EventArgs e )
		{
			xperdex.classes.QueryNewName nn = new xperdex.classes.QueryNewName( "New Layout Name" );
			nn.ShowDialog();
			if( nn.DialogResult == DialogResult.OK )
			{
				TextLayout layout = core_common.GetLayout( nn.textBox1.Text );
				listBoxLayout.DataSource = null;
				listBoxLayout.DataSource = core_common.layouts;
				listBoxLayout.SelectedItem = layout;
			}
			nn.Dispose();
		}

		private void buttonAddLabel_Click( object sender, EventArgs e )
		{
			TextLayout layout = listBoxLayout.SelectedItem as TextLayout;
			if( layout == null )
			{
				MessageBox.Show( "Please select a Layout to add this label to..." );
				return;
			}
			xperdex.classes.QueryNewName nn = new xperdex.classes.QueryNewName( "New Label Name" );
			nn.ShowDialog();
			if( nn.DialogResult == DialogResult.OK )
			{
				if( layout.AddLayout( nn.textBox1.Text ) )
				{
					textPlacementLayoutEditor1.Refresh();
					listBoxLabel.DataSource = null;
					listBoxLabel.DataSource = layout.placements;
				}				
			}			
		}

		void ApplyLabelChanges( TextLabel label )
		{
			//TextLabel label = this.listBoxLabel.SelectedItem as TextLabel;
			if( label != null )
			{
				label.textColor = this.colorWell1.color;
				label.font = this.listBoxFonts.SelectedItem as font_tracker;
				label.bDrawRightJustified = this.checkBoxRightAlign.Checked;
				label.bHorizCenter = this.checkBoxCenter.Checked;
				textPlacementLayoutEditor1.Refresh();
			}
		}

		TextLabel prior_selection;
		private void listBoxLabel_SelectedIndexChanged( object sender, EventArgs e )
		{
			TextLabel label = this.listBoxLabel.SelectedItem as TextLabel;
			if( label != null )
			{
				if( prior_selection != null )
					ApplyLabelChanges( prior_selection );
				prior_selection = label;
				switch( label.anchor )
				{
				case TextLabel.AnchorPoint.BottomLeft:
					this.checkBoxAnchorBottom.Checked = true;
					this.checkBoxAnchorRight.Checked = false;
					break;
				case TextLabel.AnchorPoint.BottomRight:
					this.checkBoxAnchorBottom.Checked = true;
					this.checkBoxAnchorRight.Checked = true;
					break;
				case TextLabel.AnchorPoint.TopLeft:
					this.checkBoxAnchorBottom.Checked = false;
					this.checkBoxAnchorRight.Checked = false;
					break;
				case TextLabel.AnchorPoint.TopRight:
					this.checkBoxAnchorBottom.Checked = false;
					this.checkBoxAnchorRight.Checked = true;
					break;
				}
				this.colorWell1.color = label.textColor;
				this.textBox1.Text = label.Name;
				this.listBoxFonts.SelectedItem = label.font;
				this.checkBoxCenter.Checked = label.bHorizCenter;
				this.checkBoxRightAlign.Checked = label.bDrawRightJustified;
			}

		}

		private void buttonEditFonts_Click( object sender, EventArgs e )
		{
			FontEditor fe = new FontEditor();
			fe.ShowDialog();
			if( fe.DialogResult == DialogResult.OK )
			{
				listBoxFonts.DataSource = null;
				listBoxFonts.DataSource = FontEditor.fonts;

			}
			fe.Dispose();
		}

		private void listBoxFonts_SelectedIndexChanged( object sender, EventArgs e )
		{
			TextLabel label = this.listBoxLabel.SelectedItem as TextLabel;
			if( label != null )
			{
				if( this.listBoxFonts.SelectedItem != null )
				{
					label.font = (font_tracker)this.listBoxFonts.SelectedItem;
					this.textPlacementLayoutEditor1.Refresh();
				}

			}
		}

		private void checkBoxAnchorBottom_CheckedChanged( object sender, EventArgs e )
		{
			TextLabel label = this.listBoxLabel.SelectedItem as TextLabel;
			if( label != null )
			{
				if( this.checkBoxAnchorBottom.Checked )
				{
					switch( label.anchor )
					{
					case TextLabel.AnchorPoint.BottomRight:
					case TextLabel.AnchorPoint.BottomLeft:
						break;
					case TextLabel.AnchorPoint.TopLeft:
						label.anchor = TextLabel.AnchorPoint.BottomLeft;
						break;
					case TextLabel.AnchorPoint.TopRight:
						label.anchor = TextLabel.AnchorPoint.BottomRight;
						break;
					}
				}
				else 					
				{
					switch( label.anchor )
					{
					case TextLabel.AnchorPoint.BottomRight:
						label.anchor = TextLabel.AnchorPoint.TopRight;
						break;
					case TextLabel.AnchorPoint.BottomLeft:

						label.anchor = TextLabel.AnchorPoint.TopLeft;
						break;
					case TextLabel.AnchorPoint.TopLeft:
						break;
					case TextLabel.AnchorPoint.TopRight:
						break;
					}
				}
				this.textPlacementLayoutEditor1.Refresh();
			}
		}

		private void checkBoxAnchorRight_CheckedChanged( object sender, EventArgs e )
		{
			TextLabel label = this.listBoxLabel.SelectedItem as TextLabel;
			if( label != null )
			{
				if( this.checkBoxAnchorRight.Checked )
				{
					switch( label.anchor )
					{
					case TextLabel.AnchorPoint.BottomRight:
					case TextLabel.AnchorPoint.BottomLeft:
						label.anchor = TextLabel.AnchorPoint.BottomRight;
						break;
					case TextLabel.AnchorPoint.TopLeft:
						label.anchor = TextLabel.AnchorPoint.TopRight;
						break;
					case TextLabel.AnchorPoint.TopRight:
						break;
					}
				}
				else
				{
					switch( label.anchor )
					{
					case TextLabel.AnchorPoint.BottomRight:
						label.anchor = TextLabel.AnchorPoint.BottomLeft;
						break;
					case TextLabel.AnchorPoint.BottomLeft:
						break;
					case TextLabel.AnchorPoint.TopLeft:
						break;
					case TextLabel.AnchorPoint.TopRight:
						label.anchor = TextLabel.AnchorPoint.TopLeft;
						break;
					}
				}
				this.textPlacementLayoutEditor1.Refresh();
			}

		}

		private void trackBarSampelVert_ValueChanged( object sender, EventArgs e )
		{

			textPlacementLayoutEditor1.Size = new Size(
				trackBarSampleHoriz.Value * original_width / 100,
				-trackBarSampelVert.Value * original_height / 100 );
			textPlacementLayoutEditor1.Refresh();
		}

		private void trackBarSampleHoriz_ValueChanged( object sender, EventArgs e )
		{
			textPlacementLayoutEditor1.Size = new Size(
				trackBarSampleHoriz.Value * original_width / 100,
				-trackBarSampelVert.Value * original_height / 100 );
			textPlacementLayoutEditor1.Refresh();
		}

		private void buttonOkay_Click( object sender, EventArgs e )
		{
			ApplyLabelChanges( prior_selection );
		}

		private void checkBoxCenter_CheckedChanged( object sender, EventArgs e )
		{
			ApplyLabelChanges( prior_selection );
		}

		private void checkBoxRightAlign_CheckedChanged( object sender, EventArgs e )
		{
			ApplyLabelChanges( prior_selection );

		}
	}
}