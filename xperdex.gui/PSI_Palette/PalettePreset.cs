using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace xperdex.gui.PSI_Palette
{
    public partial class PalettePreset : Button
    {
        public Color color;
        public PalettePreset(Color c )
        {
            InitializeComponent();
        }

        public PalettePreset()
        {
            color = Color.Black;
            InitializeComponent();
        }

        private void PalettePreset_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(Color.FromArgb(255,color));
            //base.InvokePaint(this, e); 
        }

        private void PresetClicked(object sender, EventArgs e)
        {
            try
            {
                Palette p = (Palette)this.Parent;
                if (p.set_preset)
                {
                    color = p.current_color;
                    p.set_preset = false;
                    Refresh();
                }
                else
                {
                    p.current_color = color;
                }
            }
            catch (Exception ex)
            {
				Console.WriteLine( ex.Message );
            }
        }
    }
}
