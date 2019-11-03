using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using xperdex.classes;
using System.Drawing.Imaging;


namespace xperdex.gui.PSI_Palette
{
    public partial class ColorMatrix : PSI_Control
    {
        public Color Color
        {
            set { nGreen = value.G; nAlpha = value.A; }
        }
        public ColorMatrix()
        {
            InitializeComponent();
			Load += new EventHandler( ColorMatrix_Load );
        }

		void ColorMatrix_Load(object sender, EventArgs e)
		{
			try
			{
				Palette p = (Palette)this.Parent;
				nGreen = p.current_color.G;
			}
			catch( Exception ex )
			{
				Console.WriteLine( ex.Message );
				nGreen = 128;
			}
			// create the actual color matrix surface.
			UpdateColorGrid();
		}

        //static Image output;
        const int xsize = 130;
        const int ysize = 130;
		// if I had multiple palettes open... this would be trashy.
        Bitmap bm_output;
        byte[] raw_output; // keep this around to copy back in....
        int nGreen;
        int nAlpha;
        bool show_alpha;

        void MySetPixel(Int32[] bits, int stride, int x, int y, Int32 c)
        {
            bits[y * stride + x] = c;
        }

        private byte ClampByte(int x)
        {
            return x>255?(byte)255:(byte)x;
        }
        void UpdateColorGrid( )
        {
            const int nScale = 4;
            const int xbias = 1;
            const int ybias = 1;

            {
                int red, blue, green = 0;
                int stride = xsize;
                if (raw_output == null)
                {
                    //output =Image.From(200, 200);
                    bm_output = new Bitmap(xsize, ysize);
                    raw_output = new byte[xsize * ysize * 4];
                }
                //Int32 *output = (Int32*)raw.Scan0;
                //Bitmap output = (Bitmap)e.Graphics.CopyFromScreen;
                //Control c = (Control)sender;
                int offset;
                const int RED = 2;
                const int BLUE = 0;
                for (green = 0; green < nGreen / nScale; green++)
                {
                    blue = 0;
                    for (red = 0; red < 256 / nScale; red++)
                    {
                        offset = xbias + red + blue + (blue & 1);
                        offset += ( ybias 
                            + (green + 128 / nScale)
                            - red / 2 + blue / 2) * stride;
                        offset <<= 2;
                        raw_output[offset + RED] = ClampByte(255 - red * nScale);
                        raw_output[offset + 1] = ClampByte(255 - green * nScale);
                        raw_output[offset + BLUE] = ClampByte(blue * nScale);
                        raw_output[offset + 3] = (byte)255;
                        //Color COLOR = Color.FromArgb(, , );
                        //MySetPixel( raw_output, 200
                        //, xbias + red + blue + (blue & 1)
                        //, ybias + (green + 128 / nScale) - red / 2 + blue / 2
                        //    , COLOR.ToArgb());
                    }
                    red = 255 / nScale;
                    for (blue = 0; blue < 256 / nScale; blue++)
                    {
                        offset = xbias + red + (red & 1) + blue;
                        offset += (ybias + (green + 128 / nScale) - red / 2 + blue / 2) * stride;
                        offset <<= 2;
                        raw_output[offset + RED] = ClampByte(255 - red * nScale);
                        raw_output[offset + 1] = ClampByte(255 - green * nScale);
                        raw_output[offset + BLUE] = ClampByte(blue * nScale);
                        raw_output[offset + 3] = (byte)255;
                        //Color COLOR = Color.FromArgb((255 - red * nScale), (255 - green * nScale), (blue * nScale));
                        //MySetPixel(raw_output, 200
                        //, xbias + red + (red & 1) + blue
                        //, ybias + (green + 128 / nScale) - red / 2 + blue / 2, COLOR.ToArgb());
                    }
                }

                for (blue = 0; blue <= 255 / nScale; blue++)
                {
                    for (red = 0; red <= 255 / nScale; red++)
                    {
                        offset = xbias + red + blue + (blue & 1);
                        offset += (ybias + (green + 128 / nScale) - red / 2 + blue / 2) * stride;
                        offset <<= 2;

                        raw_output[offset + RED] = ClampByte(255 - red * nScale);
                        raw_output[offset + 1] = ClampByte(255 - green * nScale);
                        raw_output[offset + BLUE] = ClampByte(blue * nScale);
                        raw_output[offset + 3] = (byte)255;
                        //Color COLOR = Color.FromArgb((255 - red * nScale), (255 - green * nScale), (blue * nScale));
                        //MySetPixel(raw_output, 200
                        //, xbias + red + blue + (blue & 1)
                        //, ybias + (green + 128 / nScale) - red / 2 + blue / 2, COLOR.ToArgb());
                    }
                }

                for (; green <= 255 / nScale; green++)
                {
                    blue = 255 / nScale;
                    for (red = 0; red <= 255 / nScale; red++)
                    {
                        offset = xbias + red + blue + (blue & 1);
                        offset += (ybias + (green + 128 / nScale) - red / 2 + blue / 2) * stride;
                        offset <<= 2;
                        raw_output[offset + RED] = ClampByte(255 - red * nScale);
                        raw_output[offset + 1] = ClampByte(255 - green * nScale);
                        raw_output[offset + BLUE] = ClampByte(blue * nScale);
                        raw_output[offset + 3] = (byte)255;
                        //Color COLOR = Color.FromArgb((255 - red * nScale), (255 - green * nScale), (blue * nScale));
                        //MySetPixel(raw_output, 200
                        //  , xbias + red + blue + (blue & 1)
                        //, ybias + (green + 128 / nScale) - red / 2 + blue / 2, COLOR.ToArgb());
                    }
                    red = 0;
                    for (blue = 0; blue < 256 / nScale; blue++)
                    {
                        offset = xbias + red + blue;
                        offset += (ybias + (green + 128 / nScale) - red / 2 + blue / 2) * stride;
                        offset <<= 2;
                        raw_output[offset + RED] = ClampByte(255 - red * nScale);
                        raw_output[offset + 1] = ClampByte(255 - green * nScale);
                        raw_output[offset + BLUE] = ClampByte(blue * nScale);
                        raw_output[offset + 3] = (byte)255;
                        //Color COLOR = Color.FromArgb((255 - red * nScale), (255 - green * nScale), (blue * nScale));
                        //MySetPixel(raw_output, 200
                        //, xbias + red + blue
                        //, ybias + (green + 128 / nScale) - red / 2 + blue / 2, COLOR.ToArgb());
                    }
                }
                BitmapData raw = bm_output.LockBits(new Rectangle(0, 0, xsize, ysize)
                    , System.Drawing.Imaging.ImageLockMode.ReadWrite
                    , System.Drawing.Imaging.PixelFormat.Format32bppArgb);
                System.Runtime.InteropServices.Marshal.Copy(raw_output, 0, raw.Scan0, xsize * ysize * 4);
                bm_output.UnlockBits(raw);
            }
        }

        public void SetGreen(int n)
        {
            if (show_alpha)
            {
                if (nAlpha != n)
                {
                    nAlpha = n;
                    Refresh();
                }
            }
            else
            {
                if (nGreen != n)
                {
                    nGreen = n;
                    UpdateColorGrid();
                    Refresh();
                }
            }
        }

        public void ShowAlpha(bool yesno)
        {
            show_alpha = yesno;
            //Refresh();
        }
        private void PalettePaint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(System.Drawing.Color.FromArgb(0, 0, 0));
            e.Graphics.DrawImage(bm_output, new Rectangle(0,0,Width, Height),new Rectangle(0,0,xsize,ysize),GraphicsUnit.Pixel );
            if (show_alpha)
            {
                try
                {
                    PSI_Palette.Palette p = (Palette)this.Parent;
                    Brush b = new SolidBrush(p.current_color);
                    e.Graphics.FillRectangle(b, 0, 0, Width, Height);
                }
                catch (Exception e2)
                {
					Console.WriteLine( e2.Message );
				}
            }

        }

        private void CM_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                if (e.Button == MouseButtons.Left)
                {
                    PSI_Palette.Palette p = (Palette)this.Parent;
                    int x, y;
                    x = (e.X * xsize) / Width;
                    y = (e.Y * ysize) / Height;
                    Color c = bm_output.GetPixel(x, y);
                    p.current_color = System.Drawing.Color.FromArgb( nAlpha, c.R, c.G, c.B );
                    //p.Refresh();
                }
            }
            catch (Exception e2)
            {
				Console.WriteLine( e2.Message );
			}
        }
    }
}
