using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace xperdex.picture_scroller
{
	public partial class ConfigureScroller : Form
	{
		Scroller scroller;
		public ConfigureScroller( Scroller which )
		{
			scroller = which;
			InitializeComponent();
		}

		private void ConfigureScroller_Load( object sender, EventArgs e )
		{
			listBox1.DataSource = Scroller.images;
		}

		private void button2_Click( object sender, EventArgs e )
		{
			OpenFileDialog ofd = new OpenFileDialog();
			ofd.FileName = null;
			ofd.ShowDialog();

			if( ofd.FileName != null )
			{
				Scroller.images.Add( new Scroller.SomeImage( ofd.FileName ) );
			}
			ofd.Dispose();
		}

		Scroller.SomeImage prior;

		private void listBox1_SelectedIndexChanged( object sender, EventArgs e )
		{
			if( prior != null )
			{
				prior.file = textBox1.Text;
				prior.display_time = new DateTime( Convert.ToInt64( textBox2.Text ) * 1000 * 1000 * 10 );
			}
			Scroller.SomeImage img = listBox1.SelectedItem as Scroller.SomeImage;
			textBox1.Text = img.file;
			textBox2.Text = (img.display_time.Ticks / ( 1000 * 1000 * 10 )).ToString();
			prior = img;
		}
	}
}