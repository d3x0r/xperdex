namespace OpenSkieScheduler3.Controls.Lists
{
	public class PackGroupList : MyListBox
	{
		public PackGroupList()
			: base( ControlList.schedule.pack_groups, false )
		{
			SetCurrent += new SetCurrentMethod( ControlList.data.SetCurrentGameGroup );
		}
	}

	public class PackGroupPrizeList : MyListBox
	{
		public PackGroupPrizeList()
			: base( ControlList.data.current_game_group_prizes, false )
		{
			if( ControlList.data.current_game_group_prize_packs != null )
			{
				AddCurrent += ControlList.data.current_game_group_prize_packs.AddChildMember;
				SetCurrent += ControlList.data.SetCurrentGameGroupPrize;
			}
		}
	}
	public class PackGroupPackSummaryList : MyListBox
	{
		public PackGroupPackSummaryList()
			: base( ControlList.data.current_meta_pack_group_packs, false )
		{
		}
	}
}
