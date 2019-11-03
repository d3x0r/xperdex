namespace OpenSkieScheduler3.Controls.Lists
{
	public class SessionMacroList: MyListBox
	{
        public SessionMacroList()
            : base( ControlList.schedule.session_macros )
		{
			SetCurrent += new SetCurrentMethod( ControlList.data.SetCurrentSessionMacro );
		}

	}
}
