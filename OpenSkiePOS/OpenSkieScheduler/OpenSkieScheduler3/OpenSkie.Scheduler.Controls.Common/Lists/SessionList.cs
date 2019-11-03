using OpenSkieScheduler3.Relations;

namespace OpenSkieScheduler3.Controls.Lists
{
	public class SessionList : MyListBox
	{
		public SessionList()
			: base( ControlList.data.current_sessions )
		{
			SetCurrent += ControlList.data.SetCurrentSession;
			//CurrentSessionMacroSessions table = ControlList.schedule.Tables[SessionDayMacroSessionTable.TableName] as SessionDayMacroSessionTable;
			//if( table != null )
			//	AddCurrent += table.AddChildMember;
		}
	}
}
