using System.Windows.Forms;

namespace OpenSkieScheduler3.Controls.Grids
{
	public class MyDataGrid: DataGrid
	{
		internal bool allow_edit;
		public void EnableEdit( bool enable )
		{
			allow_edit = enable;
		}

		public MyDataGrid()
		{
			ControlList.controls.Add( this );
		}
	}
}
