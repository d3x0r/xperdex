namespace OpenSkieScheduler3.Controls.Lists
{
	public class PackList : MyListBox
	{
		public PackList()
            : base( ControlList.schedule.packs, false )
		{
			SetCurrent += new SetCurrentMethod( ControlList.data.SetCurrentPack );
			if( ControlList.data.current_pack_group_packs != null )
			AddCurrent += new AddCurrentMethod( ControlList.data.current_pack_group_packs.AddChildMember );
		}
	}

	public class PackListTargetBundle : MyListBox
	{
		public PackListTargetBundle()
            : base( ControlList.schedule.packs, false )
		{
			SetCurrent += new SetCurrentMethod( ControlList.data.SetCurrentPack );
			AddCurrent += new AddCurrentMethod( ControlList.data.current_session_bundle_packs.AddChildMember );
		}
	}
}
