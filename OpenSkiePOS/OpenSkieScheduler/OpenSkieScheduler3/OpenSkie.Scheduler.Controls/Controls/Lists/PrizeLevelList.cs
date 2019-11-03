using OpenSkieScheduler3.Relations;

namespace OpenSkieScheduler3.Controls.Lists
{
	public class PrizeLevelList : MyListBox
	{
		public PrizeLevelList()
            : base( ControlList.schedule.Tables[PrizeLevelNames.TableName], false )
		{
			//SetCurrent += new SetCurrentMethod( ControlList.data.SetCurrentSession );
            CurrentObjectTableView table = ControlList.schedule.Tables[CurrentGameGroupPrizes.TableName] as CurrentObjectTableView;
			if( table != null )
			{
                AddCurrent += new AddCurrentMethod( table.AddChildMember );
				SetCurrent += new SetCurrentMethod( ControlList.data.SetCurrentPrize );
			}
		}

	}
}
