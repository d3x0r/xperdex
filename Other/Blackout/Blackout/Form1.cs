using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using xperdex.core;

namespace Blackout
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            local.main = this;
            InitializeComponent();
            this.Size = new Size(0, 0);
            this.Visible = false;
            //Form form = new Form();


        }

        private void showFloaterToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }
    }
}