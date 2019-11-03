using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using xperdex.gui;


namespace xperdex.toolbin
{
    public class ToolBin : PSI_Control
    {
        public ToolBin()
        {
            this.Paint += new System.Windows.Forms.PaintEventHandler( ToolBin_Paint );
        }

        void ToolBin_Paint( object sender, System.Windows.Forms.PaintEventArgs e )
        {
               
        }
    }
}
