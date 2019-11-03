using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Xml;
using System.Xml.XPath;
using xperdex.core.common.Text_Layout;
using xperdex.core.interfaces;
using xperdex.gui;
using xperdex.core.common;
//using xperdex.loader;

namespace xperdex.core
{
	public class buttons_class
	{
		public bool clicked;
		public bool want_click;
		public Point Location;
		public bool l;
		public bool r;
		public bool m;
		public bool l_delta_down;
		public bool r_delta_down;
		public bool m_delta_down;
		public bool l_delta_up;
		public bool r_delta_up;
		public bool m_delta_up;

		public buttons_class()
		{
			l = false;
			r = false;
			m = false;
		}
	};
	public class _flags
	{
		public bool PreventPageChange;
		//public bool editing = false;
	};

	public class TypeName
	{
		public String Name;
		public Type Type;
		public TypeName( Type t )
		{
			object o = Activator.CreateInstance( t );
			Name = o.ToString();
			Type = t;
		}
		public static implicit operator Type ( TypeName obj )
		{
			return obj.Type;
		}
		public override string ToString()
		{
			return Name;
		}
	}

	public static class core_common
	{
		/// <summary>
		/// interfaces which may apply security to control access...
		/// </summary>
		public static List<TypeName> security_modules; // just the list of types which are security modules... so additions can be created later.
		public static List<IReflectorPluginDropFileTarget> drop_acceptors;
		public static List<GlareSetData> glaresets;
		public static List<IReflectorDirectionShow> directors;
		public static buttons_class mouse_b;
		//public static List<Control> controls;
		public static _flags flags;
		public static List<GlareSetAttributes> glare_attribs;

		public static String ConfigName;

		//public static List<page> pages = new List<page>();

		public static ToolStripMenuItem plugin_drop; // drop list for create other
		public static ToolStripMenuItem other_drop; // drop list for 'other prop'
		public static List<osalot.AssemblyTracker> assemblies;
		public static List<IReflectorPluginModule> plugin_module_acceptors;
		public static List<object> persistant_plugins;

		public static int partX;
		public static int partY;
		public static page current_mouse_page; // the mouse was only in one page...
		public static ControlTracker current_mouse_control; // the mouse was only in one page...
		public static Canvas loading_canvas; // the canvas that is loading...
		public static List<string> systems;
		public static ControlTracker clone_control;
		public static List<ControlTracker> clone_controls = new List<ControlTracker>();
		public static List<Type> buttons; // just controls that implement IReflectorButton (for macros)
		static core_common()
		{
			try
			{
				buttons = new List<Type>();
				systems = new List<string>();
				drop_acceptors = new List<IReflectorPluginDropFileTarget>();
				directors = new List<IReflectorDirectionShow>();
				security_modules = new List<TypeName>();
				plugin_module_acceptors = new List<IReflectorPluginModule>();
				persistant_plugins = new List<object>();
				assemblies = new List<osalot.AssemblyTracker>();
				flags = new _flags();
				glaresets = new List<GlareSetData>();
				mouse_b = new buttons_class();

				//fonts = new List<font_tracker>();
				layouts = new List<TextLayout>();
				//controls = new List<Control>();

				glare_attribs = new List<GlareSetAttributes>();
				GlareSetAttributes DefaultAttrib = core_common.GetGlareSetAttributes( "default" );
				DefaultAttrib.Primary = Color.FromArgb( 64, Color.Red );
				DefaultAttrib.Secondary = Color.LightCoral;
				DefaultAttrib.TextColor = Color.White;


				core_common.other_drop = new ToolStripMenuItem( "More Properties" );
				core_common.other_drop.DropDown = new ToolStripDropDown();
				// items is expected to be a single toolstrip dropdown type widget
				// it then points at a dropdown of more layers...
				core_common.plugin_drop = new ToolStripMenuItem( "Create Other" );
				core_common.plugin_drop.DropDown = new ToolStripDropDown();

				{
					string workpath = Environment.CurrentDirectory;
					string s = Application.ExecutablePath;
					int end1 = s.LastIndexOf( '/' );
					int end2 = s.LastIndexOf( '\\' );
					string program;
					if( end1 > end2 )
						program = s.Substring( end1 + 1 );
					else
						program = s.Substring( end2 + 1 );
					end1 = program.LastIndexOf( '.' );
						program = program.Substring( 0, end1 );

					ConfigName = workpath + "/"  + program + ".config.xml";

					if( Environment.OSVersion.Platform == PlatformID.Unix )
						if( ConfigName[0] != '/' )
							ConfigName = "/" + ConfigName;
					xperdex.classes.Log.log( "Config name is " + ConfigName );
				}


				core_common.LoadAssembly( Application.ExecutablePath ); // load me, myself and I
				core_common.LoadAssembly( "xperdex.core.dll" );
				core_common.LoadAssembly( null ); // load me, myself and I : xperdex.core.common.dll

				foreach( osalot.AssemblyTracker tracker in core_common.assemblies )
				{
					tracker.default_load = true;
				}
			}
			catch( Exception e )
			{
				Console.WriteLine( "Local failed init: " + e.Message );
			}
			//local.LoadAssembly( Application.ExecutablePath ); // load me, myself and I

		}

		internal static bool Load( XPathNavigator r )
		{
			if( font_tracker.Load( r ) )
				return true;
			if( GlareSetAttributes.Load( r ) )
				return true;
			if( GlareSetData.Load( r ) )
				return true;
			switch( r.Name.ToLower() )
			{
			case "systemname":
				systems.Add( r.Value );
				break;
			}
			return false;
		}

		internal static void Save( XmlWriter w )
		{
			// but if read comes in from a certain place
			// then why doesn't write?
			//   how is it on one side we have an object
			//   and the other side we're creating objects...
			foreach( GlareSetData gsd in glaresets )
			{
				gsd.Save( w );
			}
			foreach( GlareSetAttributes gsa in glare_attribs )
			{
				gsa.Save( w );
			}
			foreach( object plugin in persistant_plugins )
			{
				// for all plugins that were loaded, if they have peristance
				// allow them to load...
				GlareSetData gsd = plugin as GlareSetData;
				if( gsd != null ) // skip glare set:plugin save.
					continue;
				IReflectorPersistance persis = plugin as IReflectorPersistance;
				if( persis != null )
				{
					try
					{
						persis.Save( w );
					}
					catch
					{
						// might be 'not implemented'
					}
				}
			}
			foreach( String system in systems )
			{
				w.WriteElementString( "systemname", system );
			}
		}

		public delegate void InitGlareSetData( GlareSetData gsd );

		public static GlareSetData GetGlareSetData( string name, InitGlareSetData init_proc )
		{
			GlareSetData gsd = null;
			if( core_common.glaresets != null )
				foreach( GlareSetData d in core_common.glaresets )
				{
					if( String.Compare( d.Name, name, true ) == 0 )
						gsd = d;
				}
			if( gsd == null )
			{
				gsd = new GlareSetData( name );
				core_common.glaresets.Add( gsd );
				if( init_proc != null )
					init_proc( gsd );
			}
			return gsd;
		}

		public static GlareSetData GetGlareSetData( string name )
		{
			return GetGlareSetData( name, null );
		}


		public delegate void InitGlareSetAttributes( GlareSetAttributes gsd );

		public static GlareSetAttributes GetGlareSetAttributes( string name, InitGlareSetAttributes init_attributes )
		{
			GlareSetAttributes gsd = null;
			if( core_common.glaresets != null )
				foreach( GlareSetAttributes d in core_common.glare_attribs )
				{
					if( String.Compare( d.Name, name, true ) == 0 )
						gsd = d;
				}
			if( gsd == null )
			{
				gsd = new GlareSetAttributes( name );
				core_common.glare_attribs.Add( gsd );
				if( init_attributes != null )
					init_attributes( gsd );
			}
			return gsd;
		}
		public static GlareSetAttributes GetGlareSetAttributes( string name )
		{
			return GetGlareSetAttributes( name, null );
		}

		internal static void MenuClick( object sender, EventArgs e )
		{
			//ToolStripItemClickedEventArgs itemclick_e = e as ToolStripItemClickedEventArgs;
			TypeMenuItem item = sender as TypeMenuItem;
			if( item != null )
			{
				if( core_common.current_mouse_page != null )
				{
					current_mouse_page.MakeControl( item.Type, item.Interface
							, current_mouse_page.canvas.selection );
					current_mouse_page.canvas.flags.selecting = false;
					current_mouse_page.canvas.Refresh();
				}
			}
		}

		internal static void item_Click( object sender, EventArgs e )
		{
			object plugin = (sender as TypeMenuItem).o;
			IReflectorPersistance persis = plugin as IReflectorPersistance;
			persis.Properties();
		}

		public static bool LoadAssembly( string p, osalot.AssemblyTracker use_assembly )
		{
			ToolStripMenuItem items;
			if( osalot.LoadAssembly( p, out items, MenuClick
				, new EventHandler(item_Click), use_assembly ) )
			{
				if( items != null )
					core_common.plugin_drop.DropDown.Items.Add( items );
				return true;
			}
			return false;
		}

		public static bool LoadAssembly( string p )
		{
			return LoadAssembly( p, null );
		}


		static void BackupFile( String source, int namelen, int n )
		{
			String backup;
			if( System.IO.File.Exists( source ) )
				if( n < 10 )
				{
					BackupFile( (backup = source.Substring( 0, namelen ) + n.ToString()), namelen, n+ 1 );
					System.IO.File.Move( source, backup );
				}
				else
					System.IO.File.Delete( source );
		}

		internal static void AutoBackup( string filename )
		{
			BackupFile( filename, filename.Length, 1 );	
			//throw new Exception( "The method or operation is not implemented." );
		}


		public static List<TextLayout> layouts;

		public static TextLayout GetLayout( string s )
		{
			if( layouts == null )
				layouts = new List<TextLayout>();
			foreach( TextLayout layout in layouts )
			{
				if( String.Compare( layout.ToString(), s, true ) == 0 )
				{
					return layout;
				}
			}
			TextLayout newlayout = new TextLayout( s );
			layouts.Add( newlayout );
			return newlayout;
		}

		static String AssemblyRoot;

		static void InitAssemblyRoot()
		{
			//get the full location of the assembly with DaoTests in it 
			string fullPath = System.Reflection.Assembly.GetAssembly(typeof(core_common)).Location; 
 
			//get the folder that's in 
			AssemblyRoot = Path.GetDirectoryName( fullPath ); 			
		}

		public static String GetRelativePath( String path )
		{
			if( AssemblyRoot == null )
			{
				InitAssemblyRoot();
			}
			int levels = 0;
			String subpath = AssemblyRoot;
			while( subpath.Length > 0 )
			{
				if( path.Contains( subpath ) )
				{
					path = path.Substring( subpath.Length + 1 );
					break;
				}
				levels++;
				subpath = Path.GetDirectoryName( subpath );
			}
			for( int level = 0; level < levels; level++ )
				path = path.Insert( 0, "..\\" );
			return path;
		}
	}
}
