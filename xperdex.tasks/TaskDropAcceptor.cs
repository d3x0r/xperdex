using System.Drawing;
using xperdex.core;
using xperdex.core.interfaces;
using xperdex.core.common;

namespace xperdex.tasks
{
	class TaskDropAcceptor : IReflectorPluginDropFileTarget
	{
		#region IReflectorDropFileTarget Members

		bool IReflectorPluginDropFileTarget.Drop( object sender
			, string filename, int x, int y )
		{
			if( ( filename.IndexOf( ".exe" ) == filename.Length - 4 )
			|| ( filename.IndexOf( ".bat" ) == filename.Length - 4 )
			|| ( filename.IndexOf( ".cmd" ) == filename.Length - 4)
				)
			{
				if( core_common.current_mouse_page == null )
				{
					
					return false;
				}

				Rectangle r = new Rectangle( 
				 core_common.partX - (( core_common.current_mouse_page.partsX / 10 )-1)/2
				, core_common.partY - (( core_common.current_mouse_page.partsY / 10 )-1)/2
				, core_common.current_mouse_page.partsX / 10
				, core_common.current_mouse_page.partsY / 10 );
				ControlTracker tracker = core_common.current_mouse_page.MakeControl( typeof( Task )
					, typeof( IReflectorButton )
					, r );
				Task task = tracker.o as Task;
				int last_slash = filename.LastIndexOfAny( new char[]{'/','\\'} );
				if( last_slash == -1 )
					last_slash = 0;
				task.task.ProgramName = filename.Substring( last_slash + 1 );
				task.task.WorkingPath = filename.Substring( 0, last_slash );
				PSI_Button button = tracker.c as PSI_Button;
				button.Text = filename;
				//IReflectorCanvas c = sender as IReflectorCanvas;
				//c.MakeControl( typeof( Task ) );
				return true;
			}	
			return false;
		}

		#endregion
	}
}
