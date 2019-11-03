namespace OpenSkieScheduler3.Controls.Lists
{
	public class GameList: MyListBox
	{
        public GameList()
            : base( ControlList.schedule.games, false )
		{
			SetCurrent += new SetCurrentMethod( ControlList.data.SetCurrentGame );
			if( ControlList.data != null && ControlList.data.current_session_games != null )
				AddCurrent += new AddCurrentMethod( ControlList.data.current_session_games.AddChildMember );
        }
	}
}
