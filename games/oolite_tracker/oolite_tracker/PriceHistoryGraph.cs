using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace oolite_tracker
{
    public partial class PriceHistoryGraph : UserControl
    {
        public PriceHistoryGraph()
        {
            InitializeComponent();
        }

        private void DrawHistory(object sender, PaintEventArgs e)
        {
            foreach (Oolite_System_Info info in Local.Systems)
            {
#if adsfasdf
                foreach (Commodity commodity in info.data.ItemArray)
                    foreach (DataRow dr in commodity.history.Rows)
                    {
                        e.Graphics.DrawLine(commodity.pen, 0, Height / 2, 10, Height / 2 - (50));
                    }
#endif
            }
        }
    }
}
