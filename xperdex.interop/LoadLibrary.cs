using System;
using System.Collections.Generic;
using System.Text;

namespace xperdex.interop
{
	public class LoadLibrary
	{
#if nothing
		[DllImport( "kernel32.dll", CharSet = CharSet.Auto )]
		//static extern IntPtr LoadLibrary( string lpFileName );

		[DllImport( file )]
		static extern int MyFunc( int i );

		public static void Invoke( string library, string file )
		{
			// Ensure current directory is exe directory
			Environment.CurrentDirectory = Path.GetDirectoryName( Assembly.GetExecutingAssembly().Location );

			string dllPath = Path.GetFullPath( @"..\unmanaged\unmanaged.dll" );
			LoadLibrary( file );
			MyFunc( 5 );

			//System.Reflection.Emit.D, 
		} 
#endif
	}
}
