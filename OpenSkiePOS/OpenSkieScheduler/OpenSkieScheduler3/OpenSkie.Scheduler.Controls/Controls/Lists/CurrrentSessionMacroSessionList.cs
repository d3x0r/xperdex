using System.Data;

namespace OpenSkieScheduler3.Controls.Lists
{
	public class CurrrentSessionMacroSessionList: MyListBox
	{
        public CurrrentSessionMacroSessionList()
            : base( ControlList.data.current_session_macro_sessions )
		{
			SetCurrent += new SetCurrentMethod( ControlList.data.SetCurrentSessionMacroSession );
		}

	}
}
