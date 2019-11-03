using System;
using System.Collections.Generic;
using System.Reflection;

namespace xperdex.classes
{
	public static class TypeMap
	{

		public class AssemblyNode
		{
			Assembly assembly;
			List<String> items_searched;
			List<bool> searched;

			// some associated data with this assembly.
			internal Type[] assembly_types = null;

			internal AssemblyNode( Assembly a )
			{
				assembly = a;
				items_searched = new List<string>();
				searched = new List<bool>();
				{
					try
					{
						assembly_types = a.GetTypes();
					}
					catch( Exception ex )
					{
						Log.log( "Failed to get types from assembly  [" + a.FullName + "] : " + ex.Message );
					}
				}
			}
			public static implicit operator Assembly( AssemblyNode node )
			{
				return node.assembly;
			}
			public override string ToString()
			{
				return assembly.ToString();
			}
		}
		

		static public class assemblies
		{

			static List<AssemblyNode> loaded_assemblies = new List<AssemblyNode>();

			static void RecurseLoaded()
			{
			retry_scan:
				try
				{
					foreach( AssemblyNode a in loaded_assemblies )
					{
						bool added = false;
						AssemblyName[] list = ( (Assembly)a ).GetReferencedAssemblies();
						foreach( AssemblyName item in list )
						{
							bool found = false;
							Assembly x = Assembly.Load( item );
							foreach( AssemblyNode node in loaded_assemblies )
							{
								if( (Assembly)node == x )
								{
									found = true;
									break;
								}
							}
							if( found )
								continue;
							else
							{
								added = true;
								loaded_assemblies.Add( new AssemblyNode( x ) );
							}
						}
						if( added )
							goto retry_scan;
					}
				}
				catch { }
			}

			static public List<AssemblyNode> Assemblies
			{
				get
				{
					// get all aseemblies currently loaded?
					if( loaded_assemblies.Count == 0 )
					{
						// start with the program core.
						Assembly a = Assembly.GetEntryAssembly();
						loaded_assemblies.Add( new AssemblyNode( a ) );
					}
					// check to see if more assemblies have been loaded...
					RecurseLoaded();
					// return the list of all assemblies loaded.
					return loaded_assemblies;
				}
			}

			public static void Load( String name )
			{
				Assembly a = Assembly.Load( name );
				loaded_assemblies.Add( new AssemblyNode( a ) );
			}
			public static void Load( Assembly a )
			{
				loaded_assemblies.Add( new AssemblyNode( a ) );
			}
		}


		internal static bool MyInterfaceFilter( Type typeObj, Object criteriaObj )
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

		internal static bool IsAType( String type, Type t )
		{
			Type x = t;
			while( x != null && x.BaseType != null )
			{
				if( String.Compare( type, x.BaseType.FullName ) == 0 )
				{
					return true;
				}
				x = x.BaseType;
			}
			return false;
		}


		public static List<Type> Locate( Type t, bool include_base )
		{
			// locate types which have T as an inherited class...
			List<Type> results = new List<Type>();
			List<AssemblyNode> a = assemblies.Assemblies;
			foreach( AssemblyNode node in a )
			{
				foreach( Type test_type in node.assembly_types )
				{
					bool added = false;
					Type check = test_type;
					while( check != null && check.BaseType != null )
					{
						if( check == t )
						{
							results.Add( test_type );
							added = true;
							break;
						}
						check = check.BaseType;
					}

					if( !added )
					{
						Type[] interfaces;
						interfaces = test_type.FindInterfaces( MyInterfaceFilter, t.ToString() );
						if( interfaces.Length > 0 )
						{
							added = true;
							results.Add( test_type );
						}
					}
				}
			}
			return results;
		}

		public static List<Type> Locate( String TypeName )
		{
			// locate types which have T as an inherited class...
			List<Type> results = new List<Type>();
			List<AssemblyNode> a = assemblies.Assemblies;
			foreach( AssemblyNode node in a )
			{
				Type[] types = node.assembly_types;
				if( types != null )
					foreach( Type test_type in types )
					{
						bool added = false;
						Type check = test_type;
						while( check != null && check.BaseType != null )
						{
							if( check.Name == TypeName )
							{
								results.Add( test_type );
								added = true;
								break;
							}
							check = check.BaseType;
						}

						if( !added )
						{
							Type[] interfaces;
							interfaces = test_type.FindInterfaces( MyInterfaceFilter, TypeName );
							if( interfaces.Length > 0 )
							{
								added = true;
								results.Add( test_type );
							}
						}
					}
			}
			return results;
		}

	}
}
