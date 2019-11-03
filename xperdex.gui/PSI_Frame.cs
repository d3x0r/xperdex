using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace xperdex.gui
{
    public partial class PSI_Frame : Form
    {
        public bool locked;
		private int center_pad_x;
		private int center_pad_y;
		public PSI_Frame()
        {
            InitializeComponent();
//#if fancy_extend_form
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.DoubleBuffer, true);
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            SetStyle(ControlStyles.Opaque, false);
            SetStyle(ControlStyles.ContainerControl, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            //SetStyle(ControlStyles.
            this.BackColor = Color.Transparent;
			//this.F
			//SetStyle(ControlStyles.Bor
			//this.BorderWidth = 100;
//#endif
			center_pad_x = 295;
			center_pad_y = 202;
			center_pad_x = 2;
			center_pad_y = 2;
			//this.LocationChanged += new EventHandler( PSI_Frame_LocationChanged );
        }

		void PSI_Frame_LocationChanged( object sender, EventArgs e )
		{
			//this.Invalidate();
			//throw new Exception( "The method or operation is not implemented." );
		}

		Region MyPath;
		Region PaintRegion;

		public override Image BackgroundImage
		{
			get
			{
				return base.BackgroundImage;
			}
			set
			{
				bool began;
				bool began_solid;
				int StartPosition;
				Image imageRegion = value;
				// First we get the dimensions of our image

				int imageWidth = imageRegion.Width;
				int imageHeight = imageRegion.Height;

				// This will be the path for our Region
				GraphicsPath regionPath = new GraphicsPath();

				// We loop over every line in our image, and every pixel per line
				began = false;
				began_solid = false;
				Bitmap bm = (Bitmap)imageRegion;
				Color testcolor = bm.GetPixel( 15, 15 );
				for( int intY = 0; intY < imageHeight; intY++ )
				{

					StartPosition = 0; // start at first.
					for( int intX = 0; intX < imageWidth; intX++ )
					{
						Color p = bm.GetPixel( intX, intY );

						if( bm.GetPixel( intX, intY ).A > 32 )
							//testcolor
							//Color.Black
							//Color.Transparent 
							
							//if( bm.GetPixel( intX, intY ) != 
							//testcolor
							////Color.Black
							////Color.Transparent 
							//)
						{
							if( !began_solid )
							{
								began_solid = true;
								// this is an outer rectangle....
								StartPosition = intX;

								//regionPath.AddRectangle( new Rectangle( StartPosition, intY, intX - StartPosition, 1 ) );
							}
							// end collecting the transparent part...
							if( began )
							{
								began = false;
								//StartPosition = intX;
							}
							// We have to see this pixel!

							//regionPath.AddRectangle( new Rectangle( intX, intY, 1, 1 ) );

						}
						else // it's transparent, end any region that has begun.
						{
							if( began_solid )
							{
								began_solid = false;
								regionPath.AddRectangle( new Rectangle( StartPosition, intY, intX - StartPosition - 1, 1 ) );
							}
							// toherwise we're not collecting
							if( !began )
							{
								began = true;
								StartPosition = intX; 
							}
						
						}

					}
					if( began )
					{
						began = false;
						//regionPath.AddRectangle( new Rectangle( StartPosition, intY, imageWidth - StartPosition, 1 ) );
					}
					if( began_solid )
					{
						began_solid = false;
						regionPath.AddRectangle( new Rectangle( StartPosition, intY, imageWidth - StartPosition, 1 ) );
					}

				}

				// create this as the path I'd like to use...
				// resize event should transform this into the screen view (stretched)
				MyPath = new Region( regionPath );

				regionPath.Dispose();


				base.BackgroundImage = value;
			}
		}

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                //cp.ExStyle |= 0x20; // turn on WS_EX_TRANSPARENT
                //cp.Style &= ~0x04000000; // attempt turn off clip_siblings... clip children needed else we flash.
                //cp.Style &= ~0x02000000; //WS_CLIPCHILDREN 0x2000000
                return cp;
            }
        }

		public int CenterPadX
		{
			set
			{
				center_pad_x = value;
			}
			get
			{
				return center_pad_x;
			}
		}
		public int CenterPadY
		{
			set
			{
				center_pad_y = value;
			}
			get
			{
				return center_pad_y;
			}
		}

        
        protected override void OnPaintBackground(PaintEventArgs e)
        {


        }

		

        private void PSI_FramePaint(object sender, PaintEventArgs e)
		{
			//if (e.ClipRectangle.X == 0 && e.ClipRectangle.Y == 0 &&
			//    e.ClipRectangle.Width == Width && e.ClipRectangle.Height == Height)
			{
				Image bm = this.BackgroundImage;
				if( bm != null )
				{
					this.Region = PaintRegion;

					Rectangle r = new Rectangle();
					Rectangle sr = new Rectangle();
					//e.Graphics.Clear(Color.Transparent);
					//------------------ TOP LEFT CORNER 
					sr.X = 0;
					sr.Width = bm.Width / 2 - center_pad_x;
					sr.Y = 0;
					sr.Height = bm.Height / 2 - center_pad_y;
					r.X = 0;
					r.Y = 0;
					r.Width = sr.Width;
					r.Height = sr.Height;
					e.Graphics.DrawImage( bm, r, sr, GraphicsUnit.Pixel );

					//------------------ TOP EDGE
					sr.X = bm.Width / 2 - center_pad_x;
					sr.Width = bm.Width - 2 * ( bm.Width / 2 - center_pad_x );
					sr.Y = 0;
					sr.Height = sr.Height;
					r.X += r.Width;
					r.Y = 0;
					r.Width = Width - 2 * ( bm.Width / 2 - center_pad_x );
					r.Height = sr.Height;
					e.Graphics.DrawImage( bm, r, sr, GraphicsUnit.Pixel );

					//------------------ TOP RIght Corner
					sr.X = bm.Width - ( bm.Width / 2 - center_pad_x );
					sr.Width = bm.Width / 2 - center_pad_x;
					sr.Y = 0;
					sr.Height = sr.Height;

					r.X += r.Width;
					r.Y = 0;
					r.Width = bm.Width / 2 - center_pad_x;
					r.Height = sr.Height;
					e.Graphics.DrawImage( bm, r, sr, GraphicsUnit.Pixel );

					//------------------ BOTTOM LEFT CONRER
					sr.X = 0;
					sr.Width = bm.Width / 2 - center_pad_x;
					sr.Y = bm.Height - ( bm.Height / 2 - center_pad_y );
					sr.Height = bm.Height / 2 - center_pad_y;
					r.X = 0;
					r.Y = Height - ( bm.Height / 2 - center_pad_y );
					r.Width = sr.Width;
					r.Height = sr.Height;
					e.Graphics.DrawImage( bm, r, sr, GraphicsUnit.Pixel );

					//------------------ BOTTOM EDGE
					sr.X = bm.Width / 2 - center_pad_x;
					sr.Width = bm.Width - 2 * ( bm.Width / 2 - center_pad_x );
					//sr.Y = 0;
					//sr.Height = sr.Height;
					r.X += r.Width;
					//r.Y = 0;
					r.Width = Width - 2 * ( bm.Width / 2 - center_pad_x );
					//r.Height = sr.Height;
					e.Graphics.DrawImage( bm, r, sr, GraphicsUnit.Pixel );

					//------------------ BOTTOM RIGHT CORNER
					sr.X = bm.Width - ( bm.Width / 2 - center_pad_x );
					sr.Width = bm.Width / 2 - center_pad_x;
					//sr.Y = 0;
					//sr.Height = sr.Height;

					r.X += r.Width;
					//r.Y = 0;
					r.Width = bm.Width / 2 - center_pad_x;
					//r.Height = sr.Height;

					e.Graphics.DrawImage( bm, r, sr, GraphicsUnit.Pixel );

					//------------------ LEFT EDGE
					sr.X = 0;
					sr.Width = bm.Width / 2 - center_pad_x;
					sr.Y = bm.Height / 2 - center_pad_y;
					sr.Height = bm.Height - 2 * ( bm.Height / 2 - center_pad_y );
					r.X = 0;
					r.Y = bm.Height / 2 - center_pad_y;
					r.Width = sr.Width;
					r.Height = Height - 2 * ( bm.Height / 2 - center_pad_y );
					e.Graphics.DrawImage( bm, r, sr, GraphicsUnit.Pixel );

					//------------------ RIGHT EDGE ( same as left, but on the right
					sr.X = bm.Width - sr.Width;
					r.X = Width - sr.Width;
					e.Graphics.DrawImage( bm, r, sr, GraphicsUnit.Pixel );


					sr.X = bm.Width / 2 - center_pad_x;
					sr.Y = bm.Height / 2 - center_pad_y;
					sr.Width = bm.Width - 2 * ( bm.Width / 2 - center_pad_x );
					sr.Height = bm.Height - 2 * ( bm.Height / 2 - center_pad_y );
					r.X = bm.Width / 2 - center_pad_x;
					r.Y = bm.Height / 2 - center_pad_y;
					r.Width = Width - 2 * ( bm.Width / 2 - center_pad_x );
					r.Height = Height - 2 * ( bm.Height / 2 - center_pad_y );
					//e.Graphics.FillRectangle( new SolidBrush( Color.FromArgb( 32, Color.Red ) ), r );
					e.Graphics.DrawImage( bm, r, sr, GraphicsUnit.Pixel );
				}
				else
					e.Graphics.FillRectangle( SystemBrushes.Control, this.ClientRectangle );
			}
			//e.Graphics.DrawImage(bm, r, sr, GraphicsUnit.Pixel);
			//e.Graphics.DrawImage(bm, r, sr, GraphicsUnit.Pixel);
			//e.Graphics.DrawImage(bm, r, sr, GraphicsUnit.Pixel);
			//e.Graphics.DrawImage(bm, r, sr, GraphicsUnit.Pixel);
			//e.Graphics.DrawImage(bm, r, sr, GraphicsUnit.Pixel);
			//e.Graphics.DrawImage(bm, r, sr, GraphicsUnit.Pixel);

		}

        bool grabbed;
        int _x, _y;
        private void GrabFrame(object sender, MouseEventArgs e)
        {
            if (locked) return;
            if (e.Button == MouseButtons.Left)
            {
                _x = e.X;
                _y = e.Y;
                grabbed = true;
            }
        }
        private void MoveFrame(object sender, MouseEventArgs e)
        {
            if (locked) return;
            if (grabbed)
            {
                Point del = new Point(e.X - _x, e.Y - _y);
                del.X += this.Location.X;
                del.Y += this.Location.Y;
                this.Location = del;
            }
        }
        private void ReleaseFrame(object sender, MouseEventArgs e)
        {
            if (locked) return;
            if (e.Button == MouseButtons.Left)
                grabbed = false;

        }

		int _width;
		int _height;
		static Matrix identity = new Matrix();
		Matrix m = new Matrix();
		private void PSI_Frame_SizeChanged( object sender, EventArgs e )
		{
			// short out if the size isn't really changing.
			if( _width != Width )
			{
				_height = Height;
				_width = Width;			
			}
			else 
				if( _height != Height )
					_height = Height;
				else 
					return;

			// cleanup old region...
			if( PaintRegion != null )
			{
				if( PaintRegion.Equals( this.Region ) )
				{
					this.Region = null;
					PaintRegion.Dispose();
				}
			}

			try
			{

				// this is the pather we're building

				Image bm = this.BackgroundImage;
				Image imageRegion = this.BackgroundImage;
				if( imageRegion != null )
				{
					GraphicsPath regionPath = new GraphicsPath();
					Region tmp_region;
					// First we get the dimensions of our image

					int imageWidth = imageRegion.Width;
					int imageHeight = imageRegion.Height;

					// This will be the path for our Region

					Rectangle r = new Rectangle();
					Rectangle sr = new Rectangle();
					//e.Graphics.Clear(Color.Transparent);
					//------------------ TOP LEFT CORNER 
					sr.X = 0;
					sr.Width = bm.Width / 2 - center_pad_x;
					sr.Y = 0;
					sr.Height = bm.Height / 2 - center_pad_y;
					r.X = 0;
					r.Y = 0;
					r.Width = sr.Width;
					r.Height = sr.Height;

					{
						tmp_region = MyPath.Clone();
						// sr and r are the same (not scaling image corners...
						tmp_region.Intersect( r );
						regionPath.AddRectangles( tmp_region.GetRegionScans( identity ) );
						tmp_region.Dispose();
					}

					//------------------ TOP EDGE
					sr.X = bm.Width / 2 - center_pad_x;
					sr.Width = bm.Width - 2 * ( bm.Width / 2 - center_pad_x );
					sr.Y = 0;
					sr.Height = sr.Height;
					r.X += r.Width;
					r.Y = 0;
					r.Width = Width - 2 * ( bm.Width / 2 - center_pad_x );
					r.Height = sr.Height;
					{
						tmp_region = MyPath.Clone();
						tmp_region.Intersect( sr );

						m.Reset();
						m.Translate( (float)( sr.X ) //* (float)sr.Width / (float)r.Width )
							, 0 );
						m.Scale( (float)r.Width / (float)sr.Width, 1.0F );
						m.Translate( (float)( -r.X )
							, 0 );
						regionPath.AddRectangles( tmp_region.GetRegionScans( m ) );
						tmp_region.Dispose();
					}

					//------------------ TOP RIght Corner
					sr.X = bm.Width - ( bm.Width / 2 - center_pad_x );
					sr.Width = bm.Width / 2 - center_pad_x;
					sr.Y = 0;
					sr.Height = sr.Height;

					r.X += r.Width;
					r.Y = 0;
					r.Width = bm.Width / 2 - center_pad_x;
					r.Height = sr.Height;
					{
						tmp_region = MyPath.Clone();
						tmp_region.Intersect( sr );

						m.Reset();
						m.Translate( ( r.X - sr.X ), 0 );
						regionPath.AddRectangles( tmp_region.GetRegionScans( m ) );
						tmp_region.Dispose();
					}

					//------------------ BOTTOM LEFT CONRER
					sr.X = 0;
					sr.Width = bm.Width / 2 - center_pad_x;
					sr.Y = bm.Height - ( bm.Height / 2 - center_pad_y );
					sr.Height = bm.Height / 2 - center_pad_y;
					r.X = 0;
					r.Y = Height - ( bm.Height / 2 - center_pad_y );
					r.Width = sr.Width;
					r.Height = sr.Height;
					{
						tmp_region = MyPath.Clone();
						tmp_region.Intersect( sr );

						m.Reset();
						m.Translate( 0, r.Y - sr.Y );
						regionPath.AddRectangles( tmp_region.GetRegionScans( m ) );
						tmp_region.Dispose();
					}

					//------------------ BOTTOM EDGE
					sr.X = bm.Width / 2 - center_pad_x;
					sr.Width = bm.Width - 2 * ( bm.Width / 2 - center_pad_x );
					//sr.Y = 0;
					//sr.Height = sr.Height;
					r.X += r.Width;
					//r.Y = 0;
					r.Width = Width - 2 * ( bm.Width / 2 - center_pad_x );
					//r.Height = sr.Height;
					{
						tmp_region = MyPath.Clone();
						tmp_region.Intersect( sr );

						m.Reset();
						m.Translate( (float)( +sr.X ) //* (float)sr.Width / (float)r.Width )
							, 0 );
						m.Scale( (float)r.Width / (float)sr.Width, 1.0F );
						m.Translate( (float)( -r.X )
							, r.Y - sr.Y );
						regionPath.AddRectangles( tmp_region.GetRegionScans( m ) );
						tmp_region.Dispose();
					}

					//------------------ BOTTOM RIGHT CORNER
					sr.X = bm.Width - ( bm.Width / 2 - center_pad_x );
					sr.Width = bm.Width / 2 - center_pad_x;
					//sr.Y = 0;
					//sr.Height = sr.Height;

					r.X += r.Width;
					//r.Y = 0;
					r.Width = bm.Width / 2 - center_pad_x;
					//r.Height = sr.Height;

					{
						tmp_region = MyPath.Clone();
						tmp_region.Intersect( sr );

						m.Reset();
						m.Translate( (float)( r.X - sr.Y ), (float)( r.Y - sr.Y ) );
						regionPath.AddRectangles( tmp_region.GetRegionScans( m ) );
						tmp_region.Dispose();
					}

					//------------------ LEFT EDGE
					sr.X = 0;
					sr.Width = bm.Width / 2 - center_pad_x;
					sr.Y = bm.Height / 2 - center_pad_y;
					sr.Height = bm.Height - 2 * ( bm.Height / 2 - center_pad_y );
					r.X = 0;
					r.Y = bm.Height / 2 - center_pad_y;
					r.Width = sr.Width;
					r.Height = Height - 2 * ( bm.Height / 2 - center_pad_y );
					{
						tmp_region = MyPath.Clone();
						tmp_region.Intersect( sr );

						m.Reset();
						m.Translate( 0, (float)( sr.Y ) );
						m.Scale( 1.0F, (float)r.Height / (float)sr.Height );
						m.Translate( 0, (float)( -r.Y ) );
						regionPath.AddRectangles( tmp_region.GetRegionScans( m ) );
						tmp_region.Dispose();
					}

					//------------------ RIGHT EDGE ( same as left, but on the right
					sr.X = bm.Width - sr.Width;
					r.X = Width - sr.Width;
					{
						tmp_region = MyPath.Clone();
						tmp_region.Intersect( sr );

						m.Reset();
						m.Translate( 0, (float)( sr.Y ) );
						m.Scale( 1.0F, (float)r.Height / (float)sr.Height );
						m.Translate( (float)( r.X - sr.X ), (float)( -r.Y ) );
						regionPath.AddRectangles( tmp_region.GetRegionScans( m ) );
						tmp_region.Dispose();
					}


					sr.X = bm.Width / 2 - center_pad_x;
					sr.Y = bm.Height / 2 - center_pad_y;
					sr.Width = bm.Width - 2 * ( bm.Width / 2 - center_pad_x );
					sr.Height = bm.Height - 2 * ( bm.Height / 2 - center_pad_y );
					r.X = bm.Width / 2 - center_pad_x;
					r.Y = bm.Height / 2 - center_pad_y;
					r.Width = Width - 2 * ( bm.Width / 2 - center_pad_x );
					r.Height = Height - 2 * ( bm.Height / 2 - center_pad_y );

					// the final output rect is easy :)
					regionPath.AddRectangle( r );

					PaintRegion = new Region( regionPath );
				}
			}
			catch( Exception ex )
			{
				xperdex.classes.Log.log( "Uhmm too small?! bounding error on internal thing." + ex.Message );
			}
		}
    }
}