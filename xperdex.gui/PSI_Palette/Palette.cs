using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using xperdex.classes;

namespace xperdex.gui.PSI_Palette
{
    public partial class Palette : PSI_Frame
    {
        Color _current_color;
        public Color current_color
        {
            set
            {
                _current_color = value;

                this.gradient1.Refresh();
                this.gradient2.Refresh();
                this.gradient3.Refresh();
                this.gradient4.Refresh();
                this.colorMatrix1.Color = value;
                this.colorWell1.allow_pick = false;
                this.colorWell1.color = value;
                this.setalpha.Checked = false;
                //this.colorWell1.Refresh();
                this.trackBar1.Value = current_color.G;
                if (ColorChanged != null)
                    ColorChanged(value);
            }
            get { 
                return _current_color; 
            }
        }

		public delegate void ColorChangeHandler( Color newColor );
		public event ColorChangeHandler ColorChanged;


        internal bool set_preset; // set to have preset buttons remember color instead of align.
        List<PalettePreset> presets = new List<PalettePreset>();
        public Palette()
        {
            InitializeComponent();

			{
				// added to create palette presets...
				int x, y;
				if( System.IO.File.Exists( "color_presets.xml" ) )
				{
					XmlReader r = null;
					try
					{
						r = XmlReader.Create( "color_presets.xml" );
						r.Read();
					}
					catch( System.Exception e )
					{
						Console.WriteLine( e.Message );
						// file not found?
						if( r != null )
							r.Close();
						r = null;
					}
					if( r != null )
					{
						r.Read();
						if( r.NodeType == XmlNodeType.Element )
							if( String.Compare( r.Name, "Colors", true ) != 0 )
							{
								r.Close();
								r = null;
							}
					}
					for( y = 0; y < 3; y++ )
						for( x = 0; x < 16; x++ )
						{
							if( y == 0 && x == 0 )
							{
								if( r != null )
								{
									r.Read();
									string s = r.ReadString();
									int n;
									if( s.Length == 0 )
										n = 0;
									else
										n = Convert.ToInt32( s );
									this.palettePreset1.color = Color.FromArgb( n );
								}
								this.presets.Add( this.palettePreset1 );
								continue; // skip the first one... 
							}
							PalettePreset pp = new PalettePreset( Color.FromArgb( 128, x * 16, 0, 0 ) );
							this.presets.Add( pp );
							//pp.Click += new EventHandler(pp.PresetClicked);
							Point p = this.palettePreset1.Location;
							if( r != null )
							{
								r.Read();
								string s = r.ReadString();
								int n;
								if( s.Length > 0 )
									n = Convert.ToInt32( s );
								else 
									n = 0;
								pp.color = Color.FromArgb( n );
							}
							pp.Size = this.palettePreset1.Size;
							p.X += x * ( this.palettePreset1.Width + 2 );
							p.Y += y * ( this.palettePreset1.Height + 2 );
							pp.Location = p;
							this.Controls.Add( pp );
							//pp.Visible = 1;
						}
					if( r != null )
						r.Close();
				}
			}
			this.trackBar1.SetRange( 0, 255 );
            _current_color = Color.Gray;

            this.gradient1.mode = Gradient.gradient_mode.black_white;
            this.gradient2.mode = Gradient.gradient_mode.red;
            this.gradient3.mode = Gradient.gradient_mode.green;
            this.gradient4.mode = Gradient.gradient_mode.blue;
            this.trackBar1.TickStyle = TickStyle.None;

            //this.button3.
        }



        private void SliderUpdated(object sender, EventArgs e)
        {
            if (this.setalpha.Checked)
            {
                _current_color = Color.FromArgb(this.trackBar1.Value, _current_color.R, _current_color.G, _current_color.B);
				if( ColorChanged != null )
					ColorChanged( _current_color );
                this.colorMatrix1.Refresh();
            }
            else
            {
                this.colorMatrix1.SetGreen(255 - this.trackBar1.Value);
            }
            //Refresh();
        }

        private void PaletteAlphaSet(object sender, EventArgs e)
        {
            bool is_checked;
            this.colorMatrix1.ShowAlpha(is_checked = this.setalpha.Checked);
            if (is_checked)
                this.trackBar1.Value = _current_color.A;
            else
                this.trackBar1.Value = _current_color.G;
            this.colorMatrix1.Refresh();
        }

        private void SetupPreset(object sender, EventArgs e)
        {
            set_preset = true;
        }

        private void SavePresets(object sender, FormClosingEventArgs e)
        {
            XmlWriter w = XmlWriter.Create("color_presets.xml");
            w.WriteStartElement( "Colors" );
            //w.WriteElementString("color", Convert.ToString(this.palettePreset1.color.ToArgb()));
            foreach (PalettePreset p in presets)
            {
				Color c = p.color;
                w.WriteElementString("color", Convert.ToString(c.ToArgb()));
            }
            w.Close();
        }
    }
}