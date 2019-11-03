namespace OpenSkieScheduler3.Controls.Lists
{
	public class CurrentGamePatternList : MyListBox
	{
		public CurrentGamePatternList(): base( ControlList.data.current_game_patterns )
		{
			//SetCurrent += new SetCurrentMethod( ControlList.data.SetCurrentGamePattern );

		}
	}
}
