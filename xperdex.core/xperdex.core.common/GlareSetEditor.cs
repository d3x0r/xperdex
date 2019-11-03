using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using xperdex.classes;
using xperdex.gui.PSI_Palette;

namespace xperdex.core
{
	public partial class GlareSetEditor: Form
	{
		public GlareSetEditor()
		{
			InitializeComponent();
			colorWellPrimary.ColorChanged += new ColorWell.ColorChangeHandler( colorWellPrimary_ColorChanged );
			colorWellSecondary.ColorChanged += new ColorWell.ColorChangeHandler( colorWellSecondary_ColorChanged );
			colorWellTertiary.ColorChanged += new ColorWell.ColorChangeHandler( colorWellTertiary_ColorChanged );
			colorWellPrimaryHighlight.ColorChanged += new ColorWell.ColorChangeHandler( colorWellPrimaryHighlight_ColorChanged );
			colorWellSecondaryHighlight.ColorChanged += new ColorWell.ColorChangeHandler( colorWellSecondaryHighlight_ColorChanged );
			colorWellTertiaryHighlight.ColorChanged += new ColorWell.ColorChangeHandler( colorWellTertiaryHighlight_ColorChanged );
			colorWellText.ColorChanged += new ColorWell.ColorChangeHandler( colorWellText_ColorChanged );


			colorWellPrimary.live_palette = true;
			colorWellSecondary.live_palette = true;
			colorWellTertiary.live_palette = true;
			colorWellPrimaryHighlight.live_palette = true;
			colorWellSecondaryHighlight.live_palette = true;
			colorWellTertiaryHighlight.live_palette = true;
			colorWellText.live_palette = true;

			psI_Button1.Text = "something";
		}

		void colorWellSecondary_ColorChanged( Color newColor )
		{
			attrib_last_selection.Secondary = newColor;
			psI_Button1.Refresh();
			psI_Button2.Refresh();
		}

		void colorWellText_ColorChanged( Color newColor )
		{
			attrib_last_selection.TextColor = newColor;
			psI_Button1.Refresh();
			psI_Button2.Refresh();
		}

		void colorWellTertiary_ColorChanged( Color newColor )
		{
			attrib_last_selection.Tertiary = newColor;
			psI_Button1.Refresh();
			psI_Button2.Refresh();
		}
		void colorWellPrimary_ColorChanged( Color newColor )
		{
			attrib_last_selection.Primary = newColor;
			psI_Button1.Refresh();
			psI_Button2.Refresh();
		}
		void colorWellSecondaryHighlight_ColorChanged( Color newColor )
		{
			attrib_last_selection.SecondaryHighlight = newColor;
			psI_Button1.Refresh();
			psI_Button2.Refresh();
		}

		void colorWellTertiaryHighlight_ColorChanged( Color newColor )
		{
			attrib_last_selection.TertiaryHighlight = newColor;
			psI_Button1.Refresh();
			psI_Button2.Refresh();
		}
		void colorWellPrimaryHighlight_ColorChanged( Color newColor )
		{
			attrib_last_selection.PrimaryHighlight = newColor;
			psI_Button1.Refresh();
			psI_Button2.Refresh();
		}

		private void buttonImagePick1_Click( object sender, EventArgs e )
		{
			this.openFileDialog1.ShowDialog();
			string result = this.openFileDialog1.FileName;
			if( result != null )
			{
				if( result.Contains( Environment.CurrentDirectory ) )
					result = result.Substring( Environment.CurrentDirectory.Length + 1 );
				this.textBoxMask.Text = result;
			}

		}

		private void button1_Click( object sender, EventArgs e )
		{
			this.openFileDialog1.ShowDialog();
			string result = this.openFileDialog1.FileName;
			if( result != null )
			{
				if( result.Contains( Environment.CurrentDirectory ) )
					result = result.Substring( Environment.CurrentDirectory.Length + 1 );
				this.textBoxNormal.Text = result;
			}

		}

		private void button4_Click( object sender, EventArgs e )
		{
			this.openFileDialog1.ShowDialog();
			string result = this.openFileDialog1.FileName;
			if( result != null )
			{
				if( result.Contains( Environment.CurrentDirectory ) )
					result = result.Substring( Environment.CurrentDirectory.Length + 1 );
				this.textBoxPressed.Text = result;
			}

		}

		private void button5_Click( object sender, EventArgs e )
		{
			this.openFileDialog1.ShowDialog();
			string result = this.openFileDialog1.FileName;
			if( result != null )
			{
				if( result.Contains( Environment.CurrentDirectory ) )
					result = result.Substring( Environment.CurrentDirectory.Length + 1 );
				this.textBoxGlare.Text = result;
			}

		}

		private void GlareSetEditor_Load( object sender, EventArgs e )
		{
			listBox1.DataSource = core_common.glaresets;
			listBox2.DataSource = core_common.glare_attribs;
			psI_Button1.Highlight = true;
			psI_ButtonPressed.buttons.clicked = true;
			psI_ButtonPressed.disable_changes = true;
			psI_ButtonDepressed.disable_changes = true;
			psI_ButtonHighlightPressed.disable_changes = true;
			psI_ButtonHighlightPressed.buttons.clicked = true;
			psI_ButtonHighlightPressed.Highlight = true;
			psI_ButtonHighlightDepressed.disable_changes = true;
			psI_ButtonHighlightDepressed.Highlight = true;
		}

		GlareSetData last_selection;
		GlareSetAttributes attrib_last_selection;

		public void Apply()
		{
			if( last_selection != null )
			{
				last_selection.mask_name = this.textBoxMask.Text;
				last_selection.depressed_name = this.textBoxNormal.Text;
				last_selection.pressed_name = this.textBoxPressed.Text;
				last_selection.glare_name = this.textBoxGlare.Text;
				last_selection.highlight_depressed_name = this.textBoxHighlightNormal.Text;
				last_selection.highlight_pressed_name = this.textBoxHighlightPressed.Text;
				if( this.radioButton1.Checked )
					last_selection.glare_type = GlareSetData.GlareType.noshade;
				else if( this.radioButton2.Checked )
					last_selection.glare_type = GlareSetData.GlareType.monoshade;
				else if( this.radioButton3.Checked )
					last_selection.glare_type = GlareSetData.GlareType.multishade;
				last_selection.SetGlareMulticolor();
			}
		}

		private void UpdateSamples( GlareSetData gsd )
		{
			this.psI_ButtonHighlightDepressed.gs.images = gsd;
			this.psI_ButtonHighlightDepressed.Refresh();
			this.psI_ButtonHighlightPressed.gs.images = gsd;
			this.psI_ButtonHighlightPressed.Refresh();
			this.psI_ButtonDepressed.gs.images = gsd;
			this.psI_ButtonDepressed.Refresh();
			this.psI_ButtonPressed.gs.images = gsd;
			this.psI_ButtonPressed.Refresh();
		}

		private void listBox1_SelectedIndexChanged( object sender, EventArgs e )
		{

			GlareSetData gsd = listBox1.SelectedItem as GlareSetData;
			if( last_selection != null )
				if( !last_selection.Equals( gsd ) )
				{
					Apply();
				}
			if( gsd != null )
			{
				last_selection = gsd;
				this.textBoxMask.Text = gsd.mask_name;
				this.textBoxNormal.Text = gsd.depressed_name;
				this.textBoxPressed.Text = gsd.pressed_name;
				this.textBoxGlare.Text = gsd.glare_name;
				this.textBoxHighlightNormal.Text = gsd.highlight_depressed_name;
				this.textBoxHighlightPressed.Text = gsd.highlight_pressed_name;
				//this.psI_ButtonPressed.glareSet = new GlareSet( gsd.Name );
				//this.psI_ButtonDepressed.glareSet = new GlareSet( gsd.Name );
				switch( gsd.glare_type )
				{
				case GlareSetData.GlareType.noshade:
					this.radioButton1.Checked = true;
					break;
				case GlareSetData.GlareType.monoshade:
					this.radioButton2.Checked = true;
					break;
				case GlareSetData.GlareType.multishade:
					this.radioButton3.Checked = true;
					break;
				}
				UpdateSamples( gsd );
			}
		}

		private void buttonCreateGlareset_Click( object sender, EventArgs e )
		{
			String dialog = QueryNewName.Show( "Enter New Glare Set Name" );
			if( dialog != null && dialog.Length > 0 )
			{
				GlareSetData gsd = core_common.GetGlareSetData( dialog );
				listBox1.DataSource = null;
				listBox1.DataSource = core_common.glaresets;
			}
		}

		private void buttonNewStyle_Click( object sender, EventArgs e )
		{
			String newname = QueryNewName.Show( "Enter new style name" );
			core_common.GetGlareSetAttributes( newname );
			listBox2.DataSource = null;
			listBox2.DataSource = core_common.glare_attribs;
		}

		private void listBox2_SelectedIndexChanged( object sender, EventArgs e )
		{
			GlareSetAttributes gsd = listBox2.SelectedItem as GlareSetAttributes;
			if( attrib_last_selection != null )
				if( !attrib_last_selection.Equals( gsd ) )
				{
					attrib_last_selection.Primary = this.colorWellPrimary.color;
					attrib_last_selection.PrimaryHighlight = this.colorWellPrimaryHighlight.color;
					attrib_last_selection.Secondary = this.colorWellSecondary.color;
					attrib_last_selection.SecondaryHighlight = this.colorWellSecondaryHighlight.color;
					attrib_last_selection.Tertiary = this.colorWellTertiary.color;
					attrib_last_selection.TertiaryHighlight = this.colorWellTertiaryHighlight.color;
				}

			psI_Button2.gs.attrib = gsd;
			if( gsd != null )
				psI_Button2.Refresh();
			psI_Button1.gs.attrib = gsd;
			if( gsd != null )
				psI_Button1.Refresh();

			if( gsd != null )
			{
				this.colorWellPrimary.color = gsd.Primary;
				this.colorWellPrimaryHighlight.color = gsd.PrimaryHighlight;
				this.colorWellSecondary.color = gsd.Secondary;
				this.colorWellSecondaryHighlight.color = gsd.SecondaryHighlight;
				this.colorWellTertiary.color = gsd.Tertiary;
				this.colorWellTertiaryHighlight.color = gsd.TertiaryHighlight;
				attrib_last_selection = gsd;
			}

		}

		private void button3_Click( object sender, EventArgs e )
		{
			GlareSetData gsd = listBox1.SelectedItem as GlareSetData;
			core_common.glaresets.Remove( gsd );
			listBox1.DataSource = null;
			listBox1.DataSource = core_common.glaresets;
		}

		private void tabPage1_Click( object sender, EventArgs e )
		{

		}

		private void buttonHighlightSelect_Click( object sender, EventArgs e )
		{
			this.openFileDialog1.ShowDialog();
			string result = this.openFileDialog1.FileName;
			if( result != null )
			{
				if( result.Contains( Environment.CurrentDirectory ) )
					result = result.Substring( Environment.CurrentDirectory.Length + 1 );
				this.textBoxHighlightNormal.Text = result;
			}
		}

		private void buttonHighlightPressSelect_Click( object sender, EventArgs e )
		{
			this.openFileDialog1.ShowDialog();
			string result = this.openFileDialog1.FileName;
			if( result != null )
			{
				if( result.Contains( Environment.CurrentDirectory ) )
					result = result.Substring( Environment.CurrentDirectory.Length + 1 );
				this.textBoxHighlightPressed.Text = result;
			}
		}

		private void button2_Click( object sender, EventArgs e )
		{
			Apply();
			if( last_selection != null )
				UpdateSamples( last_selection );
		}


	}
}