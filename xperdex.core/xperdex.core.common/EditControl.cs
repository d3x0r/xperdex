using System;
using System.Windows.Forms;
using xperdex.gui;

namespace xperdex.core
{
	public partial class EditControl : Form
	{
		Control control;
		public EditControl( Control edit_this )
		{
			control = edit_this;
			InitializeComponent();
		}

		private void button1_Click( object sender, EventArgs e )
		{
			FontEditor fe = new FontEditor( FontEditor.GetFontTracker( control.Font ) );
			fe.ShowDialog();
			if( fe.DialogResult == DialogResult.OK )
			{
				control.Font = fe.GetFontResult();
			}
			fe.Dispose();
		}

		private void button2_Click( object sender, EventArgs e )
		{
			this.Close();
		}
	}
}