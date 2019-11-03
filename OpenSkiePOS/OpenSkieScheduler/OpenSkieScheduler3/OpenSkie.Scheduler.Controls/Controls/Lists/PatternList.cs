namespace OpenSkieScheduler3.Controls.Lists
{
	public partial class PatternList : MyListBox
	{
		public PatternList()
            : base( ControlList.schedule.patterns, false )
		{
			if (ControlList.data.current_game_patterns != null)
			{
				SetCurrent += new SetCurrentMethod(ControlList.data.SetCurrentPattern);
                AddCurrent += new AddCurrentMethod( ControlList.data.current_game_patterns.AddChildMember );
			}
		}

	}

}
