using System;
using System.Collections.Generic;
using System.Text;
using xperdex.classes;
using System.Windows.Forms;
using xperdex.core.interfaces;

namespace PlayList_Manager
{
	public class FileAcceptor2: IReflectorPluginDropFileTarget
	{
		public FileAcceptor2()
		{
		}

		#region IReflectorDropFileTarget Members

		bool IReflectorPluginDropFileTarget.Drop( object sender, string filename, int X, int Y )
		{
			String destination = Local._current_fileset["Path"].ToString();
			int namestart = filename.LastIndexOfAny( new char[] { '\\', '/' } );
			if( namestart < 0 )
				namestart = 0;
			else
				namestart++;
			try
			{
				System.IO.File.Copy( filename, destination + "/" + filename.Substring( namestart ), true );
			}
			catch( Exception e )
			{
				Log.log( e.Message );
			}
			Local.RefreshFiles();
			return true;
			//throw new NotImplementedException();
		}

		#endregion
	}
}
