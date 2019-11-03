using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using xperdex.classes;

namespace xperdex.gui.PSI_Palette
{
    public partial class ColorWell : PSI_Control
    {
		public bool live_palette;
        public Color _color;
        public Color color {
            set
            {
                _color = value;
                Refresh();
            }
            get
            {
                return _color;
            }
        }
		public delegate void ColorChangeHandler( Color newColor );
		public event ColorChangeHandler ColorChanged;
        public bool allow_pick;
        public ColorWell( Color c )
        {
            allow_pick = true;
            this.color = c;
            InitializeComponent();
        }
        public ColorWell()
        {
            allow_pick = true;
            color = Color.Black;
            InitializeComponent();
        }
        private void ColorWellClick(object sender, EventArgs e)
        {
            if (allow_pick)
            {
                System.Windows.Forms.ColorDialog cd = new ColorDialog();
					 PSI_Palette.Palette p = new xperdex.gui.PSI_Palette.Palette();
                p.current_color = color;
				if( live_palette )
					p.ColorChanged += new xperdex.gui.PSI_Palette.Palette.ColorChangeHandler( p_ColorChanged );
                p.ShowDialog();
				if( p.DialogResult == DialogResult.OK )
				{
					this.color = p.current_color;
					if( !live_palette && ColorChanged != null )
						ColorChanged( this.color );
					Refresh();
				}
            }
        }

		void p_ColorChanged( Color newColor )
		{
			color = newColor;
			ColorChanged( color );
		}

        private void ColorWellDraw(object sender, PaintEventArgs e)
        {
            PSI_Palette.Palette p = this.Parent as PSI_Palette.Palette;
			if( p != null )
                _color = Color.FromArgb(255, p.current_color);
            e.Graphics.Clear(_color);
        }
    }
}
