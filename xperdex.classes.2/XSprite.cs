using System.Drawing;
using System.Drawing.Drawing2D;

namespace xperdex.classes
{
	public class XSprite
	{
		Image image;
		int hotx, hoty;
		int rotation;
		int curx, cury;
		public Fraction ScaleX = new Fraction( 1, 1 ), ScaleY = new Fraction( 1, 1 );
		Matrix cur_transform;
		public XSprite( Image image )
		{
			curx = 0;
			cury = 0;
			hotx = image.Width / 2;
			hoty = image.Height / 2;
			rotation = 0;
			cur_transform = new Matrix();
			this.image = image;
			UpdateTransform();
		}


		public void Render( Graphics g )
		{
			Matrix prior = g.Transform;
			g.Transform = cur_transform;
			g.DrawImage( image, 0f, 0f );
			g.Transform = prior;
		}
		public void Render( Graphics g, int x, int y )
		{
			GraphicsContainer gc = g.BeginContainer();
			g.ResetTransform();
			g.TranslateTransform( x, y );
			g.RotateTransform( rotation );
			g.TranslateTransform( hotx * ScaleX, hoty * ScaleY );
			g.DrawImage( image, 0f, 0f );
			g.EndContainer( gc );
		}

		void UpdateTransform()
		{
			cur_transform.Reset();
			cur_transform.Translate( curx - (hotx * ScaleX), cury - (hoty *ScaleY) );
			//cur_transform.Rotate( rotation );
			cur_transform.RotateAt( rotation, new PointF( hotx * ScaleX, hoty * ScaleX ) );
			cur_transform.Scale( ScaleX.ToFloat(), ScaleY.ToFloat() );
			//cur_transform.Translate( hotx, hoty );
		}

		public int X
		{
			get
			{
				return curx;
			}
			set
			{
				curx = value;
				UpdateTransform();
			}
		}
		public int Y
		{
			get
			{
				return cury;
			}
			set
			{
				cury = value;
				UpdateTransform();
			}
		}
		public int CenterX
		{
			get
			{
				return hotx;
			}
			set
			{
				hotx = value;
				UpdateTransform();
			}
		}
		public int CenterY
		{
			get
			{
				return hoty;
			}
			set
			{
				hoty = value;
				UpdateTransform();
			}
		}
		public void Rotate( int degrees )
		{
			rotation = degrees;
			UpdateTransform();
		}
	}
}
