using OpenSkie.Scheduler.CurrentTables;

namespace OpenSkieScheduler3.Controls.Lists
{

	public class SessionPrizeExceptionList : MyListBox
	{
		public SessionPrizeExceptionList()
			: base( ControlList.data.current_session_prize_exception_sets )
		{
			SetCurrent += ControlList.data.SetCurrentSessionPrizeExceptionSet;
		}

	}
}
