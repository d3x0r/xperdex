using System;
using System.Drawing;
using System.Windows.Forms;
using xperdex.gui;

namespace xperdex.core
{
	public partial class LabelEditor : Form
	{
		Label editing;
		public LabelEditor( Label edit_label )
		{
			editing = edit_label;
			InitializeComponent();
		}

		private void LabelEditor_Load( object sender, EventArgs e )
		{
			listBoxFonts.DataSource = FontEditor.fonts;
			listBoxVariables.DataSource = variables.Variables.known_variables;
			listBoxVariableArrays.DataSource = variables.Variables.known_variable_arrays;
			colorWellText.color = editing.textcolor;
			colorWellBackground.color = editing.BackColor;
			listBoxFonts.SelectedItem = editing.font;
			textBox1.Text = editing.text;
			if( editing.centered )
				radioButton2.Checked = true;
			else if( editing.right_just )
				radioButton3.Checked = true;
			else
				radioButton1.Checked = true;
		}

		internal void LabelEditor_Apply()
		{
			editing.text = textBox1.Text;

			editing.textcolor = colorWellText.color;
			if( editing.textcolor.ToArgb() == 0 )
				editing.textcolor = Color.White;

			editing.BackColor = colorWellBackground.color;
			if( editing.BackColor.ToArgb() == 0 )
				editing.BackColor = Color.Black;

			editing.font = listBoxFonts.SelectedItem as font_tracker;
			if( editing.font == null )
				editing.font = FontEditor.GetFontTracker( "Default" );
			if( radioButton1.Checked )
			{
				editing.centered = false;
				editing.right_just = false;
			}
			else if( radioButton2.Checked )
			{
				editing.centered = true;
				editing.right_just = false;
			}
			else if( radioButton3.Checked )
			{
				editing.centered = false;
				editing.right_just = true;
			}
		}

		private void listBoxVariables_SelectedIndexChanged( object sender, EventArgs e )
		{
			textBox1.Text += "%" + listBoxVariables.SelectedItem;
		}

		private void listBoxVariableArrays_SelectedIndexChanged( object sender, EventArgs e )
		{
			VariableChooseMemberForm vcmf;
			string member = "";
			xperdex.core.interfaces.IReflectorVariableNamedArray iNamedVar = ( listBoxVariableArrays.SelectedItem as xperdex.core.variables.Variable ).IVariableNamedArray;
			if( iNamedVar != null )
			{
				vcmf = new VariableChooseMemberForm( iNamedVar );
				if( vcmf.ShowDialog() == System.Windows.Forms.DialogResult.OK )
				{
					member = vcmf.Result;
				}
				vcmf.Dispose();
			}
			textBox1.Text += "%" + listBoxVariableArrays.SelectedItem + "["+member+"]";
		}

		private void buttonEditFonts_Click( object sender, EventArgs e )
		{
			FontEditor fe = new FontEditor();
			fe.ShowDialog();
			fe.Dispose();
		}

	}
}