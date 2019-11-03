using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using xperdex.core;
using xperdex.classes;


namespace Blackout
{
    public partial class Floater : Form
    {
        internal Canvas canvas;
        public Floater()
        {            
            InitializeComponent();
            this.TopMost = true;
            this.ControlBox = false;
            lockToolStripMenuItem.Checked = local.locked;
            resizeToolStripMenuItem.Checked = local.resize;
            if( local.resize )
                ((Form)this).FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            else 
                ((Form)this).FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Size = new Size(200, 200);

            ContextMenuStrip = contextMenuStrip1;
            this.SetStyle(ControlStyles.Opaque, false);
            this.DoubleBuffered = true;

            canvas = new Canvas();
            canvas.Dock = DockStyle.Fill;
            canvas.Width = this.Width;
            canvas.Height = this.Height;
            // the top level form should load a configuration
            // there are NO pages yet...
            //canvas.Location.X = 0;
            //canvas.Location.Y = 0;
            this.Controls.Add(canvas);
            canvas.LoadConfig("floater" + local.floaters.Count);
            canvas.Visible = true;
        
        }

        private void FloaterPaint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(local.color);
        }

        private void LockFloater(object sender, EventArgs e)
        {
            local.locked = !local.locked;
            foreach (Floater f in local.floaters)
            {
                f.lockToolStripMenuItem.Checked = local.locked;
            }
            local.WriteFloaters();
        }
        private void CreateFloater(object sender, EventArgs e)
        {
            Floater f;
            local.floaters.Add(f = new Floater());
            f.Show();
            local.WriteFloaters();
        }
        private void PickColor(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            cd.Color = local.color;
            cd.ShowDialog();
            local.color = cd.Color;
            cd.Dispose();
            foreach (Floater f in local.floaters)
            {
                f.Refresh();
            }
            local.WriteFloaters();
        }

        private void Resize(object sender, EventArgs e)
        {
            if (resizeToolStripMenuItem.Checked)
            {
                foreach (Floater f in local.floaters)
                {
                    Size size = f.Size;
                    ((Form)f).FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                    f.resizeToolStripMenuItem.Checked = false;
                    f.Size = size;
                }
                local.resize = false;
                //f.Refresh();
                //resizeToolStripMenuItem.Checked = false;
            }
            else
            {
                foreach (Floater f in local.floaters)
                {
                    Size size = f.Size;
                    ((Form)f).FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
                    f.resizeToolStripMenuItem.Checked = true;
                    f.Size = size;
                }

                local.resize = true;
                //f.Refresh();
            }
            local.WriteFloaters();
        }

        bool allow_close;

        private void DestroyFloater(object sender, EventArgs e)
        {
            allow_close = true;
            local.floaters.Remove(this);
            this.Dispose();
            if (local.floaters.Count == 0)
                local.main.Dispose();
            local.WriteFloaters();
        }

        private void FloaterClose(object sender, FormClosingEventArgs e)
        {
            if (allow_close)
                return;
            local.main.Dispose(); //uhmm
            
        }

        bool grabbed;
        int _x, _y;
        private void GrabFrame(object sender, MouseEventArgs e)
        {
            if (local.locked) return;
            if (e.Button == MouseButtons.Left)
            {
                _x = e.X;
                _y = e.Y;
                grabbed = true;
            }
        }
        private void MoveFrame(object sender, MouseEventArgs e)
        {
            if (local.locked) return;
            if (grabbed)
            {
                Point del = new Point(e.X - _x, e.Y - _y);
                del.X += this.Location.X;
                del.Y += this.Location.Y;
                this.Location = del;
                local.WriteFloaters();
            }
        }
        private void ReleaseFrame(object sender, MouseEventArgs e)
        {
            if (local.locked) return;
            if (e.Button == MouseButtons.Left)
                grabbed = false;

        }

        private void Floater_SizeChanged(object sender, EventArgs e)
        {
            local.WriteFloaters();
        }
 
    }
}

