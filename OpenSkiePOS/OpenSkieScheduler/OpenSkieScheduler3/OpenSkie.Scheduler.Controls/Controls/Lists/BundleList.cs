using OpenSkieScheduler3.Relations;

namespace OpenSkieScheduler3.Controls.Lists
{

	public class BundleList : MyListBox
	{
		public BundleList()
            : base( ControlList.schedule.Tables[BundleTable.TableName], false )
		{
			SetCurrent += ControlList.data.SetCurrentBundle;
		}
	}

}
