using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace xperdex.core.CommonControls
{
    public partial class PageListbox : ListBox
    {
        public PageListbox()
        {
            InitializeComponent();
#if asdff
            foreach (Canvas c in local.controls)
            {
                foreach( page p in c.pages )
                    this.Items.Add(p);
                //this.Item
            }
#endif
        }

    }
}
