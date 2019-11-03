using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PullPosition
{
	public partial class Form1 : Form
	{
		PSI_DirectFrame thing;
		public Form1()
		{
			InitializeComponent();
			thing = new PSI_DirectFrame( this );
			
		}

		private void Form1_Paint( object sender, PaintEventArgs e )
		{

		}
	}
}