using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace BingoGameControls
{
	public partial class Flashboard_Simple : UserControl
	{
		public Flashboard_Simple()
		{
			InitializeComponent();
		}

		private void checkBox1_CheckedChanged( object sender, EventArgs e )
		{

		}

		private void Flashboard_Simple_Load( object sender, EventArgs e )
		{
			for( int r = 0; r < 5; r++ )
				for( int col = 0; col < 5; col++ )
				{
					Control c = tableLayoutPanel1.GetControlFromPosition( col, r );
					c.Dock = DockStyle.Fill;
					c.Text = ( r * 15 + col + 1 ).ToString();
				}
		}
	}
}
