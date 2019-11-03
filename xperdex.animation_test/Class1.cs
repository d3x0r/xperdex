using System;
using System.Collections.Generic;
using System.Text;
using xperdex.classes;
using System.Windows.Forms;
using System.Drawing;

namespace xperdex.animation_test
{
	public class Class1: PSI_Control
	{
		public Class1()
		{

			Paint += new System.Windows.Forms.PaintEventHandler( Class1_Paint );
			Timer t = new Timer();
			t.Interval = 50;
			t.Tick += new EventHandler( t_Tick );
			t.Start();
			f = Xperdex.GetFontTracker( "test tracker" ).f;
		}

		int offset;
		void t_Tick( object sender, EventArgs e )
		{
			offset++;
			Refresh();
			//throw new Exception( "The method or operation is not implemented." );
		}

		Font f;
		void Class1_Paint( object sender, System.Windows.Forms.PaintEventArgs e )
		{
			for( int n = 0; n < 100; n++ )
				e.Graphics.DrawString( "hahahah yeah flicer this", f, Brushes.White, new PointF( 0, offset + n * 20 ) );	
			e.Graphics.DrawLine( Pens.White, new Point( 0, offset ), new Point( 100, offset ) );
			//e.Graphics.
			//throw new Exception( "The method or operation is not implemented." );
		}
	}
}