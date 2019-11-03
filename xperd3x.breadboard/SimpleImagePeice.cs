using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace xperd3x.breadboard
{
	class SimpleImagePeice: Peice
	{
		Image[] image; // 4 scales of image too..
		Rectangle[,,] cells; // okay so we can just draw from image...
		int span_x = 10;
		int span_y = 10; 

		public SimpleImagePeice( String file )
		{
			// I need like a g context for image manip?
			image = new Image[4];
			image[0] = Image.FromFile( file );
			Graphics g = Graphics.FromImage( image[0] );
			cells = new Rectangle[10, 10, 4];
			for( int s = 0; s < 4; s++ )
			for( int x = 0; x < 10; x++ )
				for( int y = 0; y < 10; y++ )
				{
					cells[x,y,s] = new Rectangle();
						//image.Get
				}
			OnDraw += new Peice.DoDraw( SimpleImagePeice_OnDraw );
		}

		void SimpleImagePeice_OnDraw( Graphics surface, long x, long y, int s )
		{
			surface.DrawImage( image[0], x, y );
		}


		public override Size Size
		{
			get 
			{
				return new Size( span_x, span_y );
			}
		}

	}
}
