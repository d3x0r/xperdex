using System;
using System.Reflection;
using System.Windows.Forms;

namespace OpenSkieScheduler3.Controls.Buttons
{
	public class EnableEdit: CheckBox
	{
		public EnableEdit()
		{
			Click += new EventHandler( EnableEdit_Click );
		}

		void EnableEdit_Click( object sender, EventArgs e )
		{
			bool enable = this.Checked;
			Enable( enable );
		}

		public static void Enable( bool enable )
		{
			foreach( Control c in ControlList.controls )
			{
				MethodInfo method = c.GetType().GetMethod( "EnableEdit" );//, new Type[]{typeof(bool)} );
				if( method != null )
				{
					method.Invoke( c, new object[] { enable } );
				}
			}
		}

	}
}
