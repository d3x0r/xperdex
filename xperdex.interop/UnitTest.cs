using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;

namespace xperdex
{
	public static class Interop
	{
		[DllImport( "kernel32" )]
		public extern static int LoadLibrary( string lpLibFileName );
		[DllImport( "kernel32" )]
		public extern static bool FreeLibrary( int hLibModule );
		[DllImport( "kernel32", CharSet = CharSet.Ansi )]
		public extern static int GetProcAddress( int hModule, string lpProcName );
		/*
				[DllImport("msjava", CharSet=CharSet.Unicode)]
				public extern static int call(int funcptr, int hwnd, string message, string title, int flags);
		*/
		[DllImport( "d:/xperdex/debug/PInvoke.dll", CharSet = CharSet.Unicode )]
		public extern static int InvokeFunc( int funcptr, int handle );
		//public extern static int InvokeFunc(int funcptr, ...);
		// kind of cool... but I still need a function defined for each signature of thing...
		// kinda annoying I can't just say use this thing ...
		// I dunno ... can find some sort of automation for this maybe...

		// and again, what does it actually get me?

		// OSG for one thing.... but then why not just work in that native environment?

		// box2d for a physics engine
		// flatland for sight (someone has to do it)
		// terrain, global thing....





		class Library
		{
			public string name;
			public int handle;
		}

		static List<Library> libraries;
		static string checkname;
		static bool matchname( Library l )
		{
			if( String.Compare( l.name, checkname ) == 0 )
			{
				return true;
			}
			return false;
		}

		static Interop()
		{
			Interop.libraries = new List<Library>();
		}

		public static int LoadFunction( string library, string function )
		//static void Main(string[] args)	
		{
			//int iLibrary = 
			//Predicate<Library> x;
			//x = new Predicate<Library>(
			checkname = library;
			Library lib = Interop.libraries.Find( matchname );

			//Console.WriteLine
			if( lib == null )
			{
				lib = new Library();
				lib.name = library;
				lib.handle = LoadLibrary( library );
				if( lib.handle == -1 )
				{
					lib = null;
					return 0;
				}
				libraries.Add( lib );
			}



			//int hmod=LoadLibrary("User32");
			// "MessageBoxW"
			return GetProcAddress( lib.handle, function );
#if adsfasdf
			int result = 0;
#if found_a_way_to_dynamic_build_calls
			switch( args.Length )
			{
			case 0:
				result = InvokeFunc( funcaddr );
				break;
			case 1:
				result = InvokeFunc( funcaddr, args[0] );
				break;
			case 2:
				result = InvokeFunc( funcaddr, args[0], args[1] );
				break;
			case 3:
				result = InvokeFunc( funcaddr, args[0], args[1], args[2] );
				break;
			case 4:
				result = InvokeFunc( funcaddr, args[0], args[1], args[2], args[3] );
				break;
			case 5:
				result = InvokeFunc( funcaddr, args[0], args[1], args[2], args[3], args[4] );
				break;
			case 6:
				result = InvokeFunc( funcaddr, args[0], args[1], args[2], args[3], args[4], args[5] );
				break;
			}

			int result=InvokeFunc(funcaddr, args );
#endif									
			Console.WriteLine("Result of invocation is " + result);
			
			// we keep a cache of libraries loaded like this...
			//FreeLibrary(hmod);

			Console.WriteLine("Press any key to continue...");
			Console.ReadLine(); 
			return true;
		}
#endif

		}
#if asdf
		class someclass
		{
			static void Main( string[] args )
			{
				Interop.InvokeSTDPROC( "user32", "MessageBoxW"
									, "Hello World"
										, ".Net dynamic export invocation"
										, 1 /*MB_OKCANCEL*/);
			}
		}
#endif
	}
}
