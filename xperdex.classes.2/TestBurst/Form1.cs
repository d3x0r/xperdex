using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using xperdex.classes.Types;

namespace TestBurst
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private void button1_Click( object sender, EventArgs e )
		{
			xperdex.classes.Types.XString x = xperdex.classes.Types.XString.Burst( textBox1.Text );
			listBox1.Items.Clear();
			for( XString y = x; y != null; y = y.next )
				listBox1.Items.Add( y.Text );
		}
	}
}