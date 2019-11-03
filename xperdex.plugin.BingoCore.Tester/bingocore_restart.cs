using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using xperdex.classes;
using System.Windows.Forms;

namespace xperdex.plugin.BingoCore.Tester
{
	class bingocore_restart: IReflectorButton, IReflectorCreate, IReflectorWidget
	{
		internal Control me; // the control that I'm attached to...

		#region IReflectorCreate Members

		public void OnCreate( Control pc )
		{
			restart_buttons.list.Add( this );
			me = pc;
			//throw new Exception( "The method or operation is not implemented." );
		}

		#endregion


		#region IReflectorButton Members

		public bool OnClick()
		{
			ProcessStartInfo ps = new ProcessStartInfo( "launchcmd.exe"
				, "-c caller pskill bingocore" );
			//ps.WorkingDirectory
			try
			{
				Process p = Process.Start( ps );
			}
			catch( Exception e )
			{
				Log.log( "Failed to launch kill command..." + e.Message );
			}
			foreach( bingocore_restart button in restart_buttons.list )
			{
				button.me.Hide();
			}

			return true;
		}

		#endregion


		#region IReflectorWidget Members

		public bool CanShow
		{
			get
			{
				if( restart_buttons.failed )
					return true;
				return false;
			}
		}

		public void OnPaint( PaintEventArgs e )
		{
			//throw new Exception( "The method or operation is not implemented." );
		}

		public void OnKeyPress( KeyPressEventArgs e )
		{
			//throw new Exception( "The method or operation is not implemented." );
		}

		#endregion
	}
}
