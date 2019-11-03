using System.Collections.Generic;
//using System.Linq;
using System.Drawing;
using xperdex.gui;

namespace BingoGameCore4.Controls
{
	public class BallImage : PSI_Control
	{
		static List<Bitmap> images;

		static BallImage()
		{
			images = new List<Bitmap>();
			images.Add( new Bitmap( 32, 32 ) );
			Graphics tmp = Graphics.FromImage( images[0] );
			tmp.FillRectangle( Brushes.White, 0, 0, 32, 32 );
			//images[0].
			for( int n = 1; n <= 75; n++ )
			{
				try
				{
				images.Add( new Bitmap( "images/balls/ball" + n + ".png" ) );
				}
				catch
				{
				}
			}
		}

		public BallImage()
		{
			this.Paint += new System.Windows.Forms.PaintEventHandler( BallImage_Paint );
		}

		void BallImage_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
			if( ball < images.Count && images[ball] != null )
				e.Graphics.DrawImage( images[ball], 0, 0, Width, Height );
		}

		int ball;
		public int Ball
		{
			set
			{
				ball = value;
				Refresh();
			}
			get
			{
				return ball;
			}
		}
	}
}
