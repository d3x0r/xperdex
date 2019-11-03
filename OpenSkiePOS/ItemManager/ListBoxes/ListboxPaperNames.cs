using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using xperdex.gui;
using System.Data;
using OpenSkieScheduler3;

namespace ItemManager
{
	class ListboxPaperNames : XListbox
	{
		public ListboxPaperNames()
		{
			this.DataSource = ItemManagmentState.schedule.packs;
			this.DisplayMember = PackTable.NameColumn;
			SelectedIndexChanged += new EventHandler( ListboxPaperNames_SelectedIndexChanged );
		}

		void ListboxPaperNames_SelectedIndexChanged( object sender, EventArgs e )
		{
			DataRowView drv = SelectedItem as DataRowView;
			if( drv == null )
				ItemManagmentState.current_paper = null;
			else
				ItemManagmentState.current_paper = drv.Row;
		}

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // ListboxPaperNames
            // 
            this.Sorted = true;
            this.ResumeLayout(false);

        }
	}
}
