namespace OpenSkieScheduler3.Controls.Lists
{
    public class CurrentSessionGameList : MyListBox
    {
        public CurrentSessionGameList(): base( ControlList.data.current_session_games )
        {
            //this.DisplayMember = ControlList.data.current_session_games.Name;
            SetCurrent += new SetCurrentMethod( ControlList.data.SetCurrentSessionGame );
			this.TabStops = new int[] { 40, 130, 250, 270, 290 };
			//this.TabStops = new int[] { 90, 120, 210, 230 };
        }
    }

	public class CurrentGameGroupPackList : MyListBox
	{
		public CurrentGameGroupPackList()
			: base( ControlList.data.current_pack_group_packs )
		{
		}
	}
}
