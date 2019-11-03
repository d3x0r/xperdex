using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using OpenSkieScheduler.Relations;
using System.Data;

namespace OpenSkieScheduler.Controls.Lists
{
	public class CurrentGameGroupPackList : MyListBox
	{
		public CurrentGameGroupPackList()
		{
			this.DataSource = OpenSkieSchedule.data.current_game_group_packs;
			this.DisplayMember = OpenSkieSchedule.data.current_game_group_packs.NameColumn;
			this.SelectedIndexChanged += new EventHandler( CurrentGameGroupPackList_SelectedIndexChanged );
			this.DoubleClick += new EventHandler( CurrentGameGroupPackList_DoubleClick );
		}

		void CurrentGameGroupPackList_DoubleClick( object sender, EventArgs e )
		{
			if( allow_edit )
			{
				DataRowView drv = this.SelectedItem as DataRowView;
				drv.Row.Delete();
			}
		}

		void CurrentGameGroupPackList_SelectedIndexChanged( object sender, EventArgs e )
		{
			//OpenSkieSchedule.data.SetCurrentPack( ( this.SelectedItem as DataRowView ).Row );
		}
	}
}
