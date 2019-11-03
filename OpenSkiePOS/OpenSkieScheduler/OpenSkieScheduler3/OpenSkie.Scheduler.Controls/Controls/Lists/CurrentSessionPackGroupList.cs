using System.Data;
using OpenSkieScheduler3.Relations;

namespace OpenSkieScheduler3.Controls.Lists
{
	public class CurrentSessionPackGroupList : MyListBox
	{
		public CurrentSessionPackGroupList()
			: base( ControlList.data.current_session_pack_groups )
		{
			SetCurrent += new SetCurrentMethod( ControlList.data.SetCurrentSessionPackGroup );
		}
	}

	public class CurrentSessionPackList : MyListBox
	{
		public CurrentSessionPackList(): base( 
			ControlList.data.current_session_packs )
		{
			SetCurrent += new SetCurrentMethod( ControlList.data.SetCurrentSessionPack );
		}

	}

#if asdfasdf
	public class CurrentSessionPrizeList : MyListBox
	{
		public CurrentSessionPrizeList(): base( ControlList.data.current_session_prize_level )
		{
			//SetCurrent += new SetCurrentMethod( ControlList.data.SetCurrentSessionPrize );
		}

	}
#endif

	public class CurrentSessionBundleList : MyListBox
	{
		public CurrentSessionBundleList(): base( ControlList.data.current_session_bundles )
		{
			SetCurrent += new SetCurrentMethod( ControlList.data.SetCurrentSessionBundle );
		}

	}

	public class CurrentSessionBundlePackList : MyListBox
	{
		public CurrentSessionBundlePackList()
			: base( ControlList.data.current_session_bundle_packs )
		{
			SetCurrent += new SetCurrentMethod( ControlList.data.SetCurrentSessionBundlePack );
		}

	}
}
