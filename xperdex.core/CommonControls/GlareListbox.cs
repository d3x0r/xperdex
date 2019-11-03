using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace xperdex.core.CommonControls
{
    public partial class GlareListbox : ListBox
    {
        public GlareListbox()
        {
            InitializeComponent();
            foreach (GlareSetData gsd in core_common.glaresets)
                this.Items.Add(gsd);
        }        
    }
    //class GlareListItem: List
}
