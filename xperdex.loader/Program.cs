using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Diagnostics;

namespace xperdex.loader
{
	static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main( string[] args )
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault( false );

			String path = ( xperdex.classes.INI.Default[Process.GetCurrentProcess().ProcessName]["Resource Path", "../resources"] );
			if( System.IO.Directory.Exists( path ) )
				Environment.CurrentDirectory = path;

			bool created;
			System.Threading.Mutex m = new System.Threading.Mutex( false, Process.GetCurrentProcess().ProcessName + "Auto Exclusion Mutex", out   created );
			if( !created )
			{
				xperdex.classes.Log.log( "Previous instance still open.  Exiting." );
				Application.Exit();
				return;
			}
			xperdex.gui.Banner.Show( "Loading GUI...", true );
			xperdex.classes.TypeMap.assemblies.Load( "xperdex.core" );
			List<Type> types = xperdex.classes.TypeMap.Locate( "XperdexDefaultForm" );
			object[] paramlist = new object[] { args };
			Form f = Activator.CreateInstance( types[0], paramlist ) as Form;
			Application.Run( f );
		}
	}
}