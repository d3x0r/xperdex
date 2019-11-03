using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using xperdex.classes;
using xperdex.classes.Types;
using xperdex.core.interfaces;
using xperdex.gui;
//using xperdex.loader;


namespace xperdex.core
{

	public sealed class osalot
	{
		//List<string> files;

		public class AssemblyObject
		{
			// multiple interfaces may exist...
			// it may be a plugin/variable interface...
			public Type t;
			public object o;
			public bool plugin; // loaded statically...
			public override string ToString()
			{
				return o.ToString();
			}
			public AssemblyObject( Type t, Object o )
			{
				this.t = t;
				this.o = o;
			}
		}

		public class AssemblyTracker
		{
			public Assembly assembly;
			public List<String> allow_on_system;
			internal List<AssemblyObject> objects;
			public bool removed;
			public bool default_load;
			public AssemblyTracker()
			{
				default_load = false;
				objects = new List<AssemblyObject>();
				allow_on_system = new List<string>();
			}
			public AssemblyTracker( Assembly a )
			{
				default_load = false;
				objects = new List<AssemblyObject>();
				allow_on_system = new List<string>();
				assembly = a;
			}
			public override string ToString()
			{
				return StripExeFromName( assembly.ManifestModule.Name );
			}
			public static implicit operator Assembly( AssemblyTracker t )
			{
				return t.assembly;
			}
		}

		osalot()
		{
#if load_assembly_cache
			try
			{
				StreamReader sr = new StreamReader( "assembly.cache" );
				string line;
				while( (line = sr.ReadLine()) != null )
				{
					//files.Add( line );
				}
			}
			catch( Exception e )
			{
				Console.WriteLine( e.Message );
			}
#endif
		}

		void ScanAndCacheAssemblies()
		{

		}

		public static bool MyInterfaceFilter( Type typeObj, Object criteriaObj )
		{
			Type started = typeObj;
			while( typeObj != null )
			{

				if( string.Compare( typeObj.FullName, criteriaObj.ToString(), true ) == 0 )
					return true;
				if( string.Compare( typeObj.Name, criteriaObj.ToString(), true ) == 0 )
					return true;
				typeObj = typeObj.BaseType;
			}
			return false;
		}


		static void InsertMenuItem(ToolStripDropDown menu, ToolStripItem tmi )
		{
			int index = 0;
			bool added = false;
			foreach( ToolStripItem item in menu.Items )
			{
				int comparison = String.Compare( item.Text, tmi.Text );
				if( comparison > 0 )
				{
					added = true;
					menu.Items.Insert( index, tmi );
					break;
				}
				index++;
			}
			if( !added )
				menu.Items.Add( tmi );
		}


		static void InsertMenuItems( ToolStripDropDown menu, List<ToolStripItem> tmi )
		{
			foreach( ToolStripItem tsi in tmi )
			{
				InsertMenuItem( menu, tsi );
			}
		}

		internal static void InvokeFinishInit()
		{
			foreach( AssemblyTracker tracker in core_common.assemblies )
			{
				foreach( AssemblyObject ao in tracker.objects )
				{
					if( ao.plugin )
					{
						IReflectorPlugin plugin = ao.o as IReflectorPlugin;
						if( plugin != null )
							plugin.FinishInit();
					}
				}
			}
		}
		static bool InvokePreload( AssemblyTracker tracker, Type[] assembly_types, EventHandler handler )
		{
			int previous_assemblies = tracker.objects.Count;
			int previous = core_common.persistant_plugins.Count;
			foreach( Type t in assembly_types )
			{
				Type[] interfaces;
				interfaces = t.FindInterfaces( MyInterfaceFilter, "IReflectorPlugin" );
				if( interfaces.Length > 0 )
				{
					AssemblyObject ao;
					object o = Activator.CreateInstance( t );
					tracker.objects.Add( ao = new AssemblyObject( t, o ) );
					try
					{
						IReflectorPlugin plugin = o as IReflectorPlugin;
						if( plugin != null )
						{
							plugin.Preload();
							ao.plugin = true;
						}
					}
					catch( Exception ex )
					{
						Log.log( "Invoke preload threw exception... " + t.ToString()+ ":"+ ex.Message );
					}

					IReflectorPersistance persis = o as IReflectorPersistance;
					if( persis != null ) // it's a plugin, and has properties
					{
						object[] tags = t.GetCustomAttributes( true );
						String name = null;
						foreach( object tag in tags )
						{
							PluginAttribute attr = tag as PluginAttribute;
							if( attr != null )
								name = attr.Name;
						}
						if( name == null )
							name = o.ToString();
						core_common.persistant_plugins.Add( o );
						TypeMenuItem tmi = new TypeMenuItem( o, name );
						InsertMenuItem( core_common.other_drop.DropDown, tmi );
						tmi.Click += handler;
					}

					IReflectorPluginModule module_acceptor = o as IReflectorPluginModule;
					if( module_acceptor != null ) // it's a plugin, and has properties
					{
						core_common.plugin_module_acceptors.Add( module_acceptor );
					}
				}
			}
			if( core_common.persistant_plugins.Count > previous ||
				tracker.objects.Count > previous_assemblies )
				return true;
			return false;
		}

		static bool IsAButton( Type t )
		{
			if( t.IsSubclassOf( typeof( PSI_Button ) ) )
				return true;
			Type[] interfaces;
			interfaces = t.FindInterfaces( MyInterfaceFilter, "IReflectorButton" );
			if( interfaces.Length > 0 )
			{
				return true;
			}
			return false;
		}
		static bool IsCreatable( Type t )
		{
			Type[] interfaces;
			interfaces = t.FindInterfaces( MyInterfaceFilter, "IReflectorCreate" );
			if( interfaces.Length > 0 )
			{
				return true;
			}
			return false;
		}
		static bool IsACanvas( Type t )
		{
			if( t.IsSubclassOf( typeof( IReflectorCanvas ) ) )
				return true;
			Type[] interfaces;
			interfaces = t.FindInterfaces( MyInterfaceFilter, "IReflectorCanvas" );
			if( interfaces.Length > 0 )
			{
				return true;
			}
			return false;
		}

		public static bool IsAControl( Type t )
		{
			if( t.IsSubclassOf( typeof( System.Windows.Forms.Control ) )
				|| t.IsSubclassOf( typeof( System.Windows.Forms.UserControl ) ) )
				return true;
			return false;
		}

		static bool IsAWidget( Type t )
		{
			Type x = t;
			if( x.IsInterface )
				return false;
			Type[] interfaces;

			interfaces = x.FindInterfaces( MyInterfaceFilter
				, "IReflectorWidget" );
			if( interfaces.Length > 0 )
			{
				return true;
				//Console.WriteLine( "..." );
			}
			return false;
		}

		static bool LoadVariables( AssemblyTracker tracker, Type[] assembly_types )
		{
			bool useful = false;
			foreach( Type t in assembly_types )
			{
				Type[] interfaces;
				interfaces = t.FindInterfaces( MyInterfaceFilter, "IReflectorVariable" );
				if( interfaces.Length > 0 )
				{
					object o = null;
					foreach( AssemblyObject ao in tracker.objects )
					{
						if( ao.t == t )
						{
							o = ao.o;
							break;
						}
					}
					if( o == null )
					{
						ConstructorInfo ci = t.GetConstructor( System.Type.EmptyTypes );
						if( ci != null )
						{
							o = Activator.CreateInstance( t );
							tracker.objects.Add( new AssemblyObject( t, o ) );
							useful = true;
							variables.Variables.AddVariableInterface( ( o as IReflectorVariable ).Name
								, o as IReflectorVariable );
						}
					}
				}

				interfaces = t.FindInterfaces( MyInterfaceFilter, "IReflectorVariableArray" );
				if( interfaces.Length > 0 )
				{
					object o = null;
					foreach( AssemblyObject ao in tracker.objects )
					{
						if( ao.t == t )
						{
							o = ao.o;
							break;
						}
					}
					if( o == null )
					{
						ConstructorInfo ci = t.GetConstructor( System.Type.EmptyTypes );
						if( ci != null )
						{
							o = Activator.CreateInstance( t );
							tracker.objects.Add( new AssemblyObject( t, o ) );
							useful = true;
							variables.Variables.AddVariableInterface( ( o as IReflectorVariableArray ).Name
								, o as IReflectorVariableArray );
						}
					}
				}

				interfaces = t.FindInterfaces( MyInterfaceFilter, "IReflectorVariableNamedArray" );
				if( interfaces.Length > 0 )
				{
					object o = null;
					foreach( AssemblyObject ao in tracker.objects )
					{
						if( ao.t == t )
						{
							o = ao.o;
							break;
						}
					}
					if( o == null )
					{
						ConstructorInfo ci = t.GetConstructor( System.Type.EmptyTypes );
						if( ci != null )
						{
							o = Activator.CreateInstance( t );
							tracker.objects.Add( new AssemblyObject( t, o ) );
							useful = true;
							variables.Variables.AddVariableInterface( ( o as IReflectorVariableNamedArray ).Name
								, o as IReflectorVariableNamedArray );
						}
					}
				}

			}

			return useful;
		}

		static bool LoadSecurity( AssemblyTracker tracker, Type[] assembly_types )
		{
			bool useful = false;
			foreach( Type t in assembly_types )
			{
				Type[] interfaces;

				interfaces = t.FindInterfaces( MyInterfaceFilter, "IReflectorSecurity" );
				if( interfaces.Length > 0 )
				{
					string name_override = null;
					object[] tags = t.GetCustomAttributes( true );
					foreach( object o in tags )
					{
						SecurityAttribute attr = o as SecurityAttribute;
						if( attr != null )
						{
							name_override = attr.Name;
							break;
						}
					}

					useful = true;
					TypeName type;
					core_common.security_modules.Add( type = new TypeName( t ) );
					if( name_override != null )
						type.Name = name_override;
				}
			}
			return useful;
		}

		static bool InvokeDirector( AssemblyTracker tracker, Type[] assembly_types )
		{
			bool useful = false;
			foreach( Type t in assembly_types )
			{
				Type[] interfaces;
				interfaces = t.FindInterfaces( MyInterfaceFilter, "IReflectorDirectionShow" );
				if( interfaces.Length > 0 )
				{
					useful = true;
					object o = Activator.CreateInstance( t );
					core_common.directors.Add( o as IReflectorDirectionShow );
				}
			}
			return useful;
		}

		static bool LoadDropAcceptors( AssemblyTracker tracker, Type[] assembly_types )
		{
			bool useful = false;
			foreach( Type t in assembly_types )
			{
				Type[] interfaces;
				interfaces = t.FindInterfaces( MyInterfaceFilter, "IReflectorDropFileTarget" );
				if( interfaces.Length > 0 )
				{
					object o = null;
					// for all created and tracked objects, see if it implements 
					// this drop acceptor interface.
					foreach( AssemblyObject ao in tracker.objects )
					{
						if( ao.t == t )
						{
							o = ao.o;
							useful = true;
							break;
						}
					}
				}
			}
			foreach( Type t in assembly_types )
			{
				Type[] interfaces;
				interfaces = t.FindInterfaces( MyInterfaceFilter, "IReflectorPluginDropFileTarget" );
				if( interfaces.Length > 0 )
				{
					ConstructorInfo ci = t.GetConstructor( System.Type.EmptyTypes );
					if( ci != null )
					{
						object o = Activator.CreateInstance( t );
						//tracker.objects.Add( new AssemblyObject( t, o ) );
						useful = true;
						core_common.drop_acceptors.Add( o as IReflectorPluginDropFileTarget );
					}
				}
			}
			return useful;
		}

		public static Type findtype( Assembly a, string name )
		{
			if( a != null )
				return a.GetType( name );
			return null;
		}

		public static Assembly LoadAssembly( string name )
		{
			Assembly a;
			try
			{
				if( name == null )
				{
					a = Assembly.GetCallingAssembly();
				}
				else
				{
					// Load the requested assembly and get the requested type
					a = Assembly.LoadFrom( name );
				}
				return a;
			}
			catch( FileNotFoundException )
			{
				Log.log( "Could not load Assembly: " + name );
			}
			catch( TypeLoadException tl )
			{
				Log.log( "Could not load Type: \"" + name + "\"\nfrom assembly: " + tl.Message );
			}
			catch( Exception e )
			{
				if( e.Message.Contains( "80131515" ) )
					MessageBox.Show( "Failed to load " + name + "\nTry unblocking it in Explorer" );
				else
					MessageBox.Show( "Unknown exception loading " + name + "\n" + e.Message );
			}
			return null;
		}

		static void AddMenuItem( List<ToolStripItem> menu_root, Type type, Type as_type, EventHandler click_handler )
		{
			AddMenuItem( menu_root, type, null, as_type, click_handler );
		}

		static void AddMenuItem( List<ToolStripItem> menu_root, Type type, String name_override, Type as_type, EventHandler click_handler )
		{
			ToolStripMenuItem item_root = null;
			String name = (name_override==null)?type.FullName:name_override;
			XString names = new XString( name );
			XStringSeg seg;
			int skip = ( name_override == null ) ? 1 : 0;

			for( seg = names.firstseg; seg != null; seg = seg.Next )
			{
				if( (String)seg == "+" )
				{
					XStringSeg begin = seg.Prior.Prior;
					XStringSeg end = seg.Next.Next;

					XStringSeg newseg = new XStringSeg( seg.Prior + "." + seg.Next );
					begin.Next = newseg;
					newseg.Prior = begin;
					if( end != null )
					{
						end.Prior = newseg;
						newseg.Next = end;
					}
					seg.Prior.Next = null;
					seg.Next.Prior = null;
					seg.Prior.Prior = null;
					seg.Next.Next = null;
					seg = newseg;
				}
				if( (String)seg == "." )
					continue;
				if( seg.Next != null )
				{
					while( seg.Next != null && ( (String)seg.Next != "." && (String)seg.Next != "+" ) )
					{
						XStringSeg begin = seg.Prior;
						XStringSeg end = seg.Next.Next;

						XStringSeg newseg = new XStringSeg( seg + "           ".Substring( 0, seg.Next.spaces ) + seg.Next );
						if( begin != null )
							begin.Next = newseg;
						else
							names.firstseg = newseg;
						newseg.Prior = begin;
						if( end != null )
						{
							end.Prior = newseg;
							newseg.Next = end;
						}
						if( seg.Prior != null )
						{
							seg.Prior.Next = null;
							seg.Prior.Prior = null;
						}
						seg.Next.Prior = null;
						seg.Next.Next = null;
						seg = newseg;
					}

				}
			}

			for( seg = names.firstseg; seg != null; seg = seg.Next )
			{
				if( (String)seg == "." )
				{

				}
				else
				{
					if( skip > 0 )
					{
						skip--;
						continue;
					}
					if( item_root == null )
					{
						bool found = false;
						foreach( ToolStripItem item in menu_root )
						{
							if( item.Text == (String)seg )
							{
								found = true;
								item_root = item as ToolStripMenuItem;
								break;
							}
						}
						if( !found )
						{
							if( seg.Next == null )
							{
								TypeMenuItem new_item;
								menu_root.Add( new_item = new TypeMenuItem( type, as_type ) );
								new_item.Text = (String)seg;
								new_item.Click += click_handler;
							}
							else
							{
								menu_root.Add( item_root = new ToolStripMenuItem( (String)seg ) );
								item_root.DropDown = new ToolStripDropDown();
							}
						}
					}
					else
					{
						bool found = false;
						foreach( ToolStripItem item in item_root.DropDown.Items )
						{
							if( item.Text == (String)seg )
							{
								found = true;
								item_root = item as ToolStripMenuItem;
								break;
							}
						}
						if( !found )
						{
							if( seg.Next != null )
							{
								item_root.DropDown.Items.Add( item_root = new ToolStripMenuItem( (String)seg ) );
								item_root.DropDown = new ToolStripDropDown();
							}
							else
							{
								TypeMenuItem new_item;
								InsertMenuItem( item_root.DropDown, new_item = new TypeMenuItem( type, as_type ) );
								new_item.Text = (String)seg;
								new_item.Click += click_handler;
							}
						}
					}
				}
			}
			//TypeMenuItem new_item = new TypeMenuItem( type, typeof( IReflectorButton ) );

		}

		// plugins - these were objects that were instantiated during their load.
		// should probably have an unload for these also... (might just spark their startup class
		// which can cause persistant static classes, and destroy it after load... )

		public static bool LoadAssembly( string name
			, out System.Windows.Forms.ToolStripMenuItem outitems
			, EventHandler click_handler
			, EventHandler persistant_plugin_handler
			, AssemblyTracker tracker )
		{
			Assembly a;
			try
			{
				a = LoadAssembly( name );
				if( a == null )
				{
					outitems = null;
					return false;
				}
				if( tracker == null )
					tracker = new AssemblyTracker( a );
				else
				{
					tracker.assembly = a;
				}

				foreach( AssemblyTracker assembly in core_common.assemblies )
				{
					if( String.Compare( assembly.ToString(), tracker.ToString() ) == 0 )
					{
						// uhmm really trusting garbabe collector here...
						tracker.assembly = null;
						a = null;
						outitems = null;
						return false;
					}
				}
				Type[] assembly_types = null;
				try
				{
					assembly_types = a.GetTypes();
				}
				catch( Exception ex )
				{
					Log.log( "Failed to get types from assembly.  "
						+ name + " : " 
						+ ex.Message );
					a = null;
					tracker.assembly = null;
					core_common.assemblies.Remove( tracker );
					outitems = null;
					return false;
				}
				List<ToolStripItem> items = null;
				/* 
				 * the following 3 are actually filled with TypeMenuItem...
				 * but for ease of use we store them as a list of their base class.
				 */
				List<ToolStripItem> button_items = new List<ToolStripItem>();
				List<ToolStripItem> control_items = new List<ToolStripItem>();
				List<ToolStripItem> canvas_items = new List<ToolStripItem>();
				bool useful = false;

				// search for any objects which implement IReflectorPlugin method Preload()

				if( InvokePreload( tracker, assembly_types, persistant_plugin_handler ) )
					useful = true;

				if( LoadVariables( tracker, assembly_types ) )
					useful = true;

				if( LoadDropAcceptors( tracker, assembly_types ) )
					useful = true;

				if( LoadSecurity( tracker, assembly_types ) )
					useful = true;

				if( InvokeDirector( tracker, assembly_types ) )
					useful = true;

				foreach( Type current_type in assembly_types )
				{
					// 1) a thing must have a constructor of some type
					//   empty conctructor, takes a Canvas or a Control or a PSI_Button
					if( ( current_type.GetConstructor( System.Type.EmptyTypes ) == null )
						&& ( current_type.GetConstructor( new Type[1] { typeof( Canvas ) } ) == null )
						&& ( current_type.GetConstructor( new Type[1] { typeof( Control ) } ) == null )
						&& ( current_type.GetConstructor( new Type[1] { typeof( PSI_Button ) } ) == null ) )
					{
						continue;
					}

					if( IsAWidget( current_type ) )
					{
						useful = true;
					}
					if( IsAButton( current_type ) )
					{
						//TypeMenuItem item;
						useful = true;
						core_common.buttons.Add( current_type );
						String name_override = null;
						object[] tags = current_type.GetCustomAttributes( true );
						bool ignore_button = false;
						foreach( object o in tags )
						{
							ButtonAttribute attr = o as ButtonAttribute;
							if( attr != null )
							{
								if( attr.hidden )
									ignore_button = true;
								name_override = attr.Name;
								break;
							}							
						}
						if( !ignore_button )
							AddMenuItem( button_items, current_type, name_override, typeof( IReflectorButton ), click_handler );
					}
					if( IsACanvas( current_type ) )
					{
						TypeMenuItem item;
						useful = true;
						canvas_items.Add( item = new TypeMenuItem( current_type, typeof( IReflectorCanvas ) ) );
						item.Click += click_handler;
					}

					if( IsAControl( current_type ) )
					{
						String name_override = null;
						object[] tags = current_type.GetCustomAttributes( true );
						foreach( object o in tags )
						{
							ControlAttribute attr = o as ControlAttribute;
							if( attr != null )
								name_override = attr.Name;
						}
						if( name_override != null )
						{
							AddMenuItem( control_items, current_type, name_override, current_type, click_handler );
							useful = true;
						}
						else if( current_type.IsSubclassOf( typeof( XListbox ) ) )
						{
							AddMenuItem( control_items, current_type, null, current_type, click_handler );
							useful = true;
						}
						else if( current_type.IsSubclassOf( typeof( XComboBox ) ) )
						{
							AddMenuItem( control_items, current_type, null, current_type, click_handler );
							useful = true;
						}
						//useful = true;
					}
					if( IsCreatable( current_type ) )
					{
						useful = true;
						String name_override = null;
						object[] tags = current_type.GetCustomAttributes( true );
						foreach( object o in tags )
						{
							ControlAttribute attr = o as ControlAttribute;
							if( attr != null )
								name_override = attr.Name;
						}
						AddMenuItem( control_items, current_type, name_override, typeof( IReflectorCreate ), click_handler );
					}
				}
				foreach( IReflectorPluginModule module in core_common.plugin_module_acceptors )
				{
					if( module.AssemblyUseful( tracker.assembly ) )
						useful = true;
				}

				if( useful )
				{
					core_common.assemblies.Add( tracker );

					ToolStripDropDown dropDown;
					//outitems = items.ToArray();
					int subs = 0;
					if( button_items.Count > 0 )
					{
						items = button_items;
						subs++;
					}
					if( control_items.Count > 0 )
					{
						items = control_items;
						subs++;
					}
					if( canvas_items.Count > 0 )
					{
						items = canvas_items;
						subs++;
					}
					if( subs > 1 )
					{
						ToolStripMenuItem menu_item;
						items = new List<ToolStripItem>();

						if( button_items.Count > 0 )
						{
							dropDown = new ToolStripDropDown();
							InsertMenuItems( dropDown, button_items );
							menu_item = new ToolStripMenuItem("Buttons");
							//menu_item.Text = ;
							menu_item.DropDown = dropDown;
							//menu_item.DropDownDirection = ToolStripDropDownDirection.Default;
							//menu_item.ShowDropDownArrow = true;
							items.Add( menu_item );
						}

						if( control_items.Count > 0 )
						{
							dropDown = new ToolStripDropDown();
							InsertMenuItems( dropDown, control_items );
							menu_item = new ToolStripMenuItem("Controls");
//							menu_item.Text = ;
							menu_item.DropDown = dropDown;
							//menu_item.DropDownDirection = ToolStripDropDownDirection.Default;
							//menu_item.ShowDropDownArrow = true;
							items.Add( menu_item );
						}

						if( canvas_items.Count > 0 )
						{
							dropDown = new ToolStripDropDown();
							InsertMenuItems( dropDown, canvas_items );
							menu_item = new ToolStripMenuItem();
							menu_item.Text = "Page Layout";
							menu_item.DropDown = dropDown;
							menu_item.DropDownDirection = ToolStripDropDownDirection.Default;
							//menu_item.ShowDropDownArrow = true;
							items.Add( menu_item );
						}

					}
					if( subs > 0 )
					{
						dropDown = new ToolStripDropDown();
						foreach( ToolStripItem tsi in items )
							InsertMenuItem( dropDown, tsi );

						ToolStripMenuItem itemx = new ToolStripMenuItem();
						itemx.Text = osalot.StripExeFromName( a.ManifestModule.Name );
						itemx.DropDown = dropDown;
						itemx.DropDownDirection = ToolStripDropDownDirection.Default;
						//itemx.ShowDropDownArrow = true;

						outitems = itemx; // returning this one menu entry....
						return true;
					}
					outitems = null;
					return useful; // just cause there's no menu options (IReflectorSecurity) doesn't mean we didn't use it...
				}
				else
				{
					// help garbage collection...
					tracker.assembly = null;
					tracker = null;
					a = null;
				}
			}
			catch( FileNotFoundException fnf )
			{
				Log.log( "Could not load Assembly: \"" + name + "\" : " + fnf.Message );
			}
			catch( TypeLoadException )
			{
				Log.log( "Could not load Type: \"\"\nfrom assembly: \"" + name + "\"" );
			}

			outitems = null;
			return false;
		}
		public static bool LoadAssembly( string name
			, out System.Windows.Forms.ToolStripMenuItem outitems
			, EventHandler click_handler )
		{
			return LoadAssembly( name, out outitems, click_handler, null, null );
		}

		// Checks a method for a signature match, and invokes it if there is one
		private static Object AttemptMethod( Type type, MethodInfo method, String name, Object[] args )
		{
			// Name does not match?
			if( String.Compare( method.Name, name, false, CultureInfo.InvariantCulture ) != 0 )
			{
				throw new CustomException( method.DeclaringType + "." + method.Name + ": Method Name Doesn't Match!" );
			}

			// Wrong number of parameters?
			ParameterInfo[] param = method.GetParameters();

			bool force_okay = false;
			if( param.Length == 0 && args == null )
			{
				force_okay = true;
			}
			if( !force_okay && (args == null) )
			{
				return false;
			}
			if( (!force_okay) && param.Length != args.Length )
			{
				throw new CustomException( method.DeclaringType + "." + method.Name + ": Method Signatures Don't Match!" );
			}

			// Ok, can we convert the strings to the right types?
			Object[] newArgs = force_okay ? new Object[0] : new Object[args.Length];

			for( int index = 0; index < param.Length; index++ )
			{
				try
				{
					newArgs[index] = Convert.ChangeType( args[index], param[index].ParameterType, CultureInfo.InvariantCulture );
				}
				catch( Exception e )
				{
					throw new CustomException( method.DeclaringType + "." + method.Name + ": Argument Conversion Failed", e );
				}
			}
			return false;
		}

		class CustomException: Exception
		{
			public CustomException( String m ) : base( m ) { }

			public CustomException( String m, Exception n ) : base( m, n ) { }
		}

		public static string StripExeFromName( string s )
		{
			int ext = s.LastIndexOf( ".exe", StringComparison.OrdinalIgnoreCase );
			if( ext < 0 )
				ext = s.LastIndexOf( ".dll", StringComparison.OrdinalIgnoreCase );

			if( ext > 0 )
				return s.Substring( 0, ext );
			return s;
		}




#if this_wasnt_a_bad_idea

		public static void BeginControlPaint( PaintEventArgs e )
		{
			Log.log( "Begin Paint..." );
		}
		public static void EndControlPaint( PaintEventArgs e )
		{
			Log.log( "End Paint..." );
		}

		public static void ExtendListbox( Object o )
		{
			ListBox listbox = o as ListBox;
			if( listbox != null )
			{
				// I don't have a parent yet....
				listbox.DrawItem += new DrawItemEventHandler( listbox_DrawItem );
				//listbox.MeasureItem += new MeasureItemEventHandler( listbox_MeasureItem );
				listbox.FontChanged += new EventHandler( listbox_FontChanged );
				listbox.DrawMode = DrawMode.OwnerDrawFixed;
			}
		}

		static void listbox_FontChanged( object sender, EventArgs e )
		{
			ListBox listbox = sender as ListBox;
			// have to set the item height to the scaled height... so that mouse clicking works.
			Canvas canvas = listbox.Parent as Canvas;
			if( listbox != null )
			{

				listbox.ItemHeight = ( (int)( (float)listbox.Font.Height / canvas.font_scale_y.ToFloat() ) );
			}
		}

		public static void ScaleEventHandler( Object o, Object o2 )
		{

		}

		static void listbox_MeasureItem( object sender, MeasureItemEventArgs e )
		{
			ListBox listbox = sender as ListBox;
			int height = listbox.Font.Height;
			Canvas canvas = listbox.Parent as Canvas;
			if( canvas != null )
			{
				height = ((int)((float)height * canvas.font_scale_y.ToFloat()));
			}
			e.ItemHeight = height;
		}

		static void listbox_DrawItem( object sender, DrawItemEventArgs e )
		{
			Graphics g = e.Graphics;
			ListBox listbox = sender as ListBox;
			Canvas canvas = listbox.Parent as Canvas;
			g.FillRectangle( new SolidBrush( e.BackColor ), e.Bounds );
			PointF pt;// = e.Bounds.Location;
			if( canvas != null )
			{
				g.ScaleTransform( canvas.font_scale_x.ToFloat(), canvas.font_scale_y.ToFloat() );
				pt = new PointF( e.Bounds.Left / canvas.font_scale_x.ToFloat(), e.Bounds.Top / canvas.font_scale_y.ToFloat() ); 
			}
			else
				pt = new PointF( e.Bounds.Left, e.Bounds.Top );
			String text = listbox.GetItemText( listbox.Items[e.Index] );
			g.DrawString( text, e.Font, new SolidBrush( e.ForeColor ), pt );
		}

		static AssemblyName overload_assembly = new AssemblyName( "MyMetaAssembly" );

		internal class MyOverload {
			internal Type t;
			internal Type new_type;

		}
		static List<MyOverload> overloads = new List<MyOverload>();
		static AssemblyBuilder ab;
		static ModuleBuilder mb;
		public static Type OverloadControl( Type t )
		{
			if( !IsAControl( t ) )
			{
				return t;
			}
			if( overloads != null )
				foreach( MyOverload overload in overloads )
				{
					if( t == overload.t )
						return overload.new_type;
				}
			
			{
				// create a dynamic assembly and module
				AssemblyName assemblyName = new AssemblyName();
				assemblyName.Name = "HelloWorld";
				AssemblyBuilder assemblyBuilder = Thread.GetDomain().DefineDynamicAssembly(
				assemblyName, AssemblyBuilderAccess.RunAndSave );

				ModuleBuilder module;
				module = assemblyBuilder.DefineDynamicModule( "HelloWorld.dll" );

				// create a new type to hold our Main method
				TypeBuilder typeBuilder = module.DefineType(
				t.Name,
				TypeAttributes.Public | TypeAttributes.Class );


//DynamicMethod.
				// create the Main(string[] args) method
				MethodBuilder methodbuilder = typeBuilder.DefineMethod(
				"a",
				MethodAttributes.Family,
				CallingConventions.HasThis,
				typeof( void ),
				new Type[] { typeof( PaintEventArgs ) } );

				//Type t2 = changeID.DeclaringType;
				// generate the IL for the Main method
				ILGenerator ilGenerator = methodbuilder.GetILGenerator();


				// Push the current value of the id field onto the
				// evaluation stack. It's an instance field, so load the
				// instance of Example before accessing the field.
				ilGenerator.Emit( OpCodes.Ldarg_0 );
				//ilGenerator.Emit(OpCodes.Ldfld, null);

				// Load the instance of Example again, load the new value
				// of id, and store the new field value.
				ilGenerator.Emit( OpCodes.Ldarg_0 );
				ilGenerator.Emit( OpCodes.Ldarg_1 );
				//ilGenerator.Emit(OpCodes.Stfld, fid);


				// The original value of the id field is now the only
				// thing on the stack, so return from the call.
				ilGenerator.Emit( OpCodes.Ret );

				// bake it
				Type helloWorldType = typeBuilder.CreateType();
				assemblyBuilder.Save( "Helloworld.dll");
			}
			
			{

				MethodInfo mi1 = typeof( osalot ).GetMethod( "BeginControlPaint" );
				MethodInfo mi_extend = typeof( osalot ).GetMethod( "ExtendListbox" );
				ConstructorInfo mi_object_ctor = t.GetConstructor( Type.EmptyTypes );
				MethodInfo mi_scale_event_handler = typeof( osalot ).GetMethod( "ScaleEventHandler" );
				MethodInfo mi2 = t.GetMethod( "OnPaint", BindingFlags.NonPublic | BindingFlags.Instance );
				MethodInfo mi3 = typeof( osalot ).GetMethod( "EndControlPaint" );
				{
					if( ab == null )
						ab = AppDomain.CurrentDomain.DefineDynamicAssembly( overload_assembly
							, AssemblyBuilderAccess.RunAndSave );
					if( mb == null )
						mb = ab.DefineDynamicModule( "MyMetaAssembly.dll" );

					TypeAttributes ta = TypeAttributes.Class | TypeAttributes.Public;
					TypeBuilder tb = mb.DefineType( "MySubclassOf" + t.Name, ta, t );
					//MethodInfo mi_body;
					//MethodInfo mi_decl;
					//tb.DefineMethodOverride( mi_body, mi_decl );

					//MethodAttributes.Public | 
					MethodBuilder mbM = tb.DefineMethod( "OnPaint"
								, MethodAttributes.Family | MethodAttributes.ReuseSlot |
								  MethodAttributes.Virtual | MethodAttributes.HideBySig
								, CallingConventions.HasThis
								, typeof( void )
								, new Type[] { typeof( PaintEventArgs ) } );



					ILGenerator il = mbM.GetILGenerator();
					il.Emit( OpCodes.Ldarg_1 );
					il.Emit( OpCodes.Call, mi1 );

					il.Emit( OpCodes.Ldarg_0 );
					il.Emit( OpCodes.Ldarg_1 );
					il.Emit( OpCodes.Call, mi2 );

					il.Emit( OpCodes.Ldarg_1 );
					il.Emit( OpCodes.Call, mi3 );

					il.Emit( OpCodes.Ret );

					mbM = tb.DefineMethod( "ScaleEventHander"
			, MethodAttributes.Family | MethodAttributes.ReuseSlot | MethodAttributes.HideBySig
			, CallingConventions.HasThis
			, typeof( void )
			, new Type[] { typeof( Canvas ) } );



					il = mbM.GetILGenerator();
					il.Emit( OpCodes.Ldarg_1 );
					il.Emit( OpCodes.Call, mi1 );

					il.Emit( OpCodes.Ldarg_0 );
					il.Emit( OpCodes.Ldarg_1 );
					il.Emit( OpCodes.Call, mi_scale_event_handler );

					il.Emit( OpCodes.Ldarg_1 );
					il.Emit( OpCodes.Call, mi3 );

					il.Emit( OpCodes.Ret );

					ConstructorBuilder cbM = tb.DefineConstructor( MethodAttributes.Public | MethodAttributes.HideBySig, CallingConventions.HasThis, Type.EmptyTypes );
					il = cbM.GetILGenerator();
					il.Emit( OpCodes.Ldarg_0 );
					il.Emit( OpCodes.Call, mi_object_ctor );
					il.Emit( OpCodes.Ldarg_0 );
					il.Emit( OpCodes.Call, mi_extend );

					il.Emit( OpCodes.Ret );


					
					Type result_type = tb.CreateType();

					// save the newly created type so we can re-use it if multiply referenced.
					{
						MyOverload overload = new MyOverload();
						MethodInfo[] meths2 = result_type.GetMethods();
						{
							foreach( MethodInfo mi in meths2 )
							{
								Log.log( mi.ToString() );
							}
						}
						overload.t = t;
						overload.new_type = result_type;
						overloads.Add( overload );
					}
					try
					{
						ab.Save( "MyMetaAssembly.dll" );
						//ab.sa
					}
					catch( Exception ok )
					{
					}
					finally
					{
						// wahtever.
					}
					return result_type;
				}

			}
			return null;

		}
#endif
	}
}
