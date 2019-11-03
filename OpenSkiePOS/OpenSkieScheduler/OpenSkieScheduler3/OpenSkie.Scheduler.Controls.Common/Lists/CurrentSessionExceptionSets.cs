using OpenSkie.Scheduler.CurrentTables;

namespace OpenSkieScheduler3.Controls.Lists
{

	public class SessionPriceExceptionList : MyListBox
	{
		public SessionPriceExceptionList()
			: base( ControlList.data.current_session_price_exception_sets )
		{
			SetCurrent += ControlList.data.SetCurrentSessionPriceExceptionSet;
		}

	}
}
