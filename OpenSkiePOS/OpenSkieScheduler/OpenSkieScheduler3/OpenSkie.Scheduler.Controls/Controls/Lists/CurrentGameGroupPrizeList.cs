using System;
using System.Data;

namespace OpenSkieScheduler3.Controls.Lists
{
	public class CurrentGameGroupPrizeList : MyListBox
	{
		public CurrentGameGroupPrizeList(): base( ControlList.data.current_game_group_prizes )
		{
			this.SelectedIndexChanged += new EventHandler( CurrentGameGroupPrizeList_SelectedIndexChanged );
			this.DoubleClick += new EventHandler( CurrentGameGroupPrizeList_DoubleClick );
		}

		void CurrentGameGroupPrizeList_DoubleClick( object sender, EventArgs e )
		{
			if( allow_edit )
			{
				DataRowView drv = this.SelectedItem as DataRowView;
				drv.Row.Delete();
			}
		}

		void CurrentGameGroupPrizeList_SelectedIndexChanged( object sender, EventArgs e )
		{
		}
	}
	public class CurrentGameGroupPrizePackList : MyListBox
	{
		public CurrentGameGroupPrizePackList(): base( ControlList.data.current_game_group_prize_packs )
		{
			this.SelectedIndexChanged += new EventHandler( CurrentGameGroupPrizeList_SelectedIndexChanged );
			this.DoubleClick += new EventHandler( CurrentGameGroupPrizeList_DoubleClick );
		}

		void CurrentGameGroupPrizeList_DoubleClick( object sender, EventArgs e )
		{
			if( allow_edit )
			{
				DataRowView drv = this.SelectedItem as DataRowView;
				drv.Row.Delete();
			}
		}

		void CurrentGameGroupPrizeList_SelectedIndexChanged( object sender, EventArgs e )
		{
		}
	}
}
