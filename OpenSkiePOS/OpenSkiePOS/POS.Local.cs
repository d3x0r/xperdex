using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using xperdex.classes;
using xperdex.core;

namespace OpenSkiePOS
{
	public static class POS
	{


		public static class Local
		{
			static MobilePOS.IKioskFrontend kiosk_frontend;
			internal static WebInterfaces.ISaleModule sale_interface;
			static public MobilePOS.IKioskFrontend KioskFrontend
			{
				set
				{
					kiosk_frontend = value;
				}
			}


			static public WebInterfaces.ISaleModule SaleInterface
			{
				get
				{
					return sale_interface;
				}
			}

			internal static List<osalot.AssemblyTracker> assemblies = new List<osalot.AssemblyTracker>();
			internal static List<DepartmentInterface> Departments = new List<DepartmentInterface>();

			internal static OpenSkieScheduler.ScheduleDataSet schedule;
			internal static OpenSkie.Scheduler.ScheduleCurrents schedule_currents;

			static Local()
			{
				schedule = new OpenSkieScheduler.ScheduleDataSet();
				schedule_currents = new OpenSkie.Scheduler.ScheduleCurrents( schedule );
			}

			static DateTime current_date;
			internal static void SetBingoday( DateTime date )
			{
				current_date = date;
				schedule.Fill( current_date );
			}

			static int current_session;
			internal static void SetSession( int session )
			{
				current_session = session;

				schedule_currents.current_session = schedule.GetSession( current_date, current_session );
			}


			static Assembly LoadAssembly( string name )
			{
				Assembly a;
				try
				{
					if( name == null )
					{
						a = Assembly.GetCallingAssembly();
					}
					else
						// Load the requested assembly and get the requested type
						a = Assembly.LoadFrom( name );
					return a;
				}
				catch( FileNotFoundException )
				{
					Console.WriteLine( "Could not load Assembly: \"{0}\"", name );
				}
				catch( TypeLoadException )
				{
					Console.WriteLine( "Could not load Type: \"{0}\"\nfrom assembly: \"{1}\"", name );
				}
				return null;
			}

			static bool MyInterfaceFilter( Type typeObj, Object criteriaObj )
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

			static bool LoadDepartments( osalot.AssemblyTracker tracker, Type[] assembly_types )
			{
				bool useful = false;
				foreach( Type t in assembly_types )
				{
					Type[] interfaces;
					interfaces = t.FindInterfaces( MyInterfaceFilter, "DepartmentInterface" );
					if( interfaces.Length > 0 )
					{
						DepartmentInterface Department = Activator.CreateInstance( t ) as DepartmentInterface;
						useful = true;
						Departments.Add( Department );
					}
				}
				return useful;
			}
		

			internal static bool LoadAssembly( string name, out xperdex.core.osalot.AssemblyTracker tracker )
			{
				Assembly a;
				tracker = null;
				try
				{
					a = LoadAssembly( name );
					if( a == null )
					{
						return false;
					}

					if( tracker == null )
						tracker = new osalot.AssemblyTracker( a );
					else
					{
						tracker.assembly = a;
					}

					foreach( osalot.AssemblyTracker assembly in POS.Local.assemblies )
					{
						if( String.Compare( assembly.ToString(), tracker.ToString() ) == 0 )
						{
							// uhmm really trusting garbabe collector here...
							tracker.assembly = null;
							a = null;
							//outitems = null;
							tracker = null;
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
						Log.log( "Failed to get types from assembly." + ex.Message );
						a = null;
						tracker.assembly = null;
						POS.Local.assemblies.Remove( tracker );
						tracker = null;
						return false;
					}

					bool useful = false;

					// search for any objects which implement IReflectorPlugin method Preload()

					if( LoadDepartments( tracker, assembly_types ) )
						useful = true;


					if( useful )
					{
						POS.Local.assemblies.Add( tracker );

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
				catch( FileNotFoundException )
				{
					Console.WriteLine( "Could not load Assembly: \"{0}\"", name );
				}
				catch( TypeLoadException )
				{
					Console.WriteLine( "Could not load Type: \"{0}\"\nfrom assembly: \"{1}\"", name );
				}

				return false;
			}


		}
	}
}
