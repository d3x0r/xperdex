using System;
using System.Collections.Generic;
using System.Management.Automation;
using System.Text;

namespace ClearShell
{
	public static class PowerShellHost
	{
		static PowerShell ps = PowerShell.Create();
		static PowerShellHost()
		{
		}
		public static void DoCommand( string command, object[] args )
		{
			ps.AddCommand( command );
			if( args != null )
				foreach( object s in args )
					ps.AddArgument( s );
			ps.Invoke();
			/*
			foreach (PSObject result in ps.Invoke())
			{
				Console.WriteLine(
						"{0,-24}{1}",
						result.Members["ProcessName"].Value,
						result.Members["Id"].Value);
			}
			 */
		}
		public static object DoQuery( string command, object[] args )
		{
			ps.AddCommand( command );
			PSObject tmp = null;
			if( args != null )
				foreach( object s in args )
					ps.AddArgument( s );

			foreach( PSObject result in ps.Invoke() )
			{
				tmp = result;
				//Console.WriteLine(
				//		"{0,-24}{1}",
				//		result.Members["ProcessName"].Value,
				//		result.Members["Id"].Value );
			}
			return tmp;
		}
		[STAThread]
		static void Main( string[] args )
		{
			bool first = true;
			String tmp = "";
			if( args.Length > 1 )
			{
				List<String> other_args = new List<string>();
				foreach( String arg in args )
				{
					if( !first )
						tmp += " ";
					if( !first )
						other_args.Add( arg );
					tmp += arg;
					first = false;
				}
				object old_setting = DoQuery( "Get-ExecutionPolicy", null );
				ps.Commands.Clear();
				DoCommand( "Set-ExecutionPolicy", new object[] { "Unrestricted" } );

				ps.Commands.Clear();
				try
				{
					DoCommand( args[0], other_args.ToArray() );
				}
				catch
				{
				}
				ps.Commands.Clear();
				DoCommand( "Set-ExecutionPolicy", new object[] { old_setting } );
				ps.Commands.Clear();
			}
		}
	}

}
