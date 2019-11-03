using System.Data;

namespace OpenSkieScheduler3.Controls.Lists
{
    public class CurrentSessionGameOrderList : MyListBox
    {
		public CurrentSessionGameOrderList()
            : base( (DataView)ControlList.data.current_session_games  )
        {
            SetCurrent += new SetCurrentMethod( ControlList.data.SetCurrentSessionGame );
            this.TabStops = new int[] { 40, 130, 250, 270, 290 };
        }
    }

	public class CurrentSessionPackOrderList : MyListBox
	{
		public CurrentSessionPackOrderList(): base( ControlList.data.current_session_packs )
		{
		}
	}

#if asdfasdf
	public class CurrentSessionPrizeOrderList : MyListBox
	{
		public CurrentSessionPrizeOrderList(): base( ControlList.data.current_session_prize_level_order )
		{
		}
	}
#endif
	public class SessionPackOrderList : MyListBox
	{
        public SessionPackOrderList()
            : base( ControlList.schedule.session_packs )
		{
		}
	}
#if asdfasdf
	public class SessionPrizeOrderList : MyListBox
	{
        public SessionPrizeOrderList()
            : base( ControlList.schedule.session_prize_level_order )
		{
		}
	}
#endif
}
