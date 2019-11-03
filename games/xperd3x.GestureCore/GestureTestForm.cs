using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Imaging;

namespace xperd3x.GestureCore
{
	public partial class GestureTestForm : Form
	{
		GestureEngine engine = new GestureEngine();
		ControlMatrix input;
		float[,] raw_data;
		float[,] image_data;

		public GestureTestForm()
		{
			InitializeComponent();
			raw_data = new float[Width, Height];
			input = new ControlMatrix( raw_data );
		}

		bool adding;
		private void psI_Control1_MouseDown( object sender, MouseEventArgs e )
		{
			adding = true;
			raw_data[e.X,e.Y] += 1.0;
			engine.Add( input );
		}

		private void psI_Control1_MouseMove(object sender, MouseEventArgs e)
		{
			if( adding )		
			{
				raw_data[e.X,e.Y] += 1.0;
				engine.Add( input );
				image_data = engine.Velocity;
			}
		}

		private void psI_Control1_MouseUp(object sender, MouseEventArgs e)
		{
			adding = false;		
		}

		private void psI_Control1_Paint( object sender, PaintEventArgs e )
		{
			int w = Width;
			int h = Height;

			Bitmap bm_output = new Bitmap( Width, Height );
			byte[] raw_output = new byte[Width * Height * 4];


			BitmapData raw = bm_output.LockBits( new Rectangle( 0, 0, Width, Height )
				   , System.Drawing.Imaging.ImageLockMode.ReadWrite
				   , System.Drawing.Imaging.PixelFormat.Format32bppArgb );
			unsafe
			{
				byte* imgPtr = (byte*)( raw.Scan0 );
				{
					for( int x = 0; x < w; x++ )
						for( int y = 0; y < h; y++ ) ;
					//e.Graphics.DrawPi

				}
			}
			System.Runtime.InteropServices.Marshal.Copy( raw_output, 0, raw.Scan0, Width * Height * 4 );
			bm_output.UnlockBits( raw );
			e.Graphics.DrawImage( bm_output, new Point() );
			/*
			 * Bitmap image =  new Bitmap( "c:\\images\\image.gif" ); 

  Then get the BitmapData object from it by calling the Lock method as:

BitmapData data = image.LockBits( new Rectangle( 0 , 0 , image.Width , image.Height ) , ImageLockMode.ReadWrite  , PixelFormat.Format24bppRgb  ); 

  Then you can iterate in the image as:

           unsafe
           { 
                 byte* imgPtr = ( byte* )( data.Scan0 ); 
                 for( int i = 0 ; i < data.Height ; i ++ )
                 {
                       for( int j = 0 ;  j < data.Width ;  j ++ )
                       {
                            // write the logic implementation here
                             ptr += 3;  
                       }
                       ptr += data.Stride - data.Width * 3;
                 }
           } 

			 * */
		}
	}
}
