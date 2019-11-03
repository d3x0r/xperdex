using System.Windows.Forms;

namespace OpenSkieScheduler3.Controls.Buttons
{
	public class MyButton: Button
	{
		public bool allow_edit = true;
		public void EnableEdit( bool enable )
		{
			allow_edit = enable;
		}
		public MyButton()
		{
			ControlList.controls.Add( this );
		}

	}
}
