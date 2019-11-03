using System;
using System.Collections.Generic;
using System.Management;
using System.Net;
using xperdex.classes;

namespace xperdex.tasks
{
	internal static class Local
	{
		internal static List<TaskItem> tasks;

		internal static List<Interface> addrlist;

		static Local()
		{
			tasks = new List<TaskItem>();
			//IPEndPoint ipep = new IPEndPoint( new IPAddress( 
			Log.log( "Loading interfaces..." );
			addrlist = new List<Interface>();
			IPArray( addrlist );
			ComputeBroadcast( addrlist );
			Log.log( "Loaded interfaces..." );
		}

		internal class Interface
		{
			public bool v6;
			public IPAddress addr;
			public IPAddress subnet;
			public int mask;
			//IPAddress add
			public IPAddress broadcast;
			public IPEndPoint broadcast_ep;
		}

		internal static bool IsAddressLocal( IPAddress address )
		{
			foreach( Interface if_addr in addrlist )
			{
				if( if_addr.addr.Equals( address ) )
					return true;
			}
			return false;
		}

		static void ComputeBroadcast( List<Interface> ipList )
		{
			foreach( Interface a in ipList )
			{
				if( a.v6 ) // only building masks for v4...
					continue;
				byte[] if_bytes = a.addr.GetAddressBytes();
				byte[] mask_bytes = a.subnet.GetAddressBytes();
				byte[] addresss = new byte[if_bytes.Length];
				for( int n = 0; n < if_bytes.Length; n++ )
				{
					addresss[n] = (byte)( if_bytes[n] & mask_bytes[n] );
					addresss[n] |= (byte)( ( 0xFF ) & ( ~mask_bytes[n] ) );
				}

				a.broadcast = new IPAddress( addresss );
				a.broadcast_ep = new IPEndPoint( a.broadcast, 3006 );
			}
		}


		/// Returns an ArrayList of all IP addresses for all network connections starting with "Local Area Connection"
		/// </summary>
		static void IPArray( List<Interface> ipList )
		{
			//ArrayList ipList = new ArrayList();
			EnumerationOptions objEO = new EnumerationOptions();
			objEO.Rewindable = true;
			objEO.ReturnImmediately = false;
			ManagementClass objMC = new ManagementClass( "Win32_NetworkAdapterConfiguration" );
			ManagementClass objMC2 = new ManagementClass( "Win32_NetworkAdapter" );
			ManagementObjectCollection objMOC = objMC.GetInstances( objEO );
			ManagementObjectCollection objMOC2 = objMC2.GetInstances( objEO );
			foreach( ManagementObject objMO in objMOC )
			{
				if( !(Boolean)objMO["IPEnabled"] )
				{
					continue;
				}
				if( Environment.OSVersion.Platform == PlatformID.Win32Windows )
				{
					String[] ipaddresses = (String[])objMO["IPAddress"];
					String[] subipaddresses = (String[])objMO["IPSubnet"];
					int n = 0;
					foreach( String s in ipaddresses )
					{
						Interface a = new Interface();
						a.addr = IPAddress.Parse( s );
						if( subipaddresses[n].IndexOf( '.' ) > 0 )
							a.subnet = IPAddress.Parse( subipaddresses[n++] );
						else
						{
							a.v6 = true;
							a.mask = Convert.ToInt32( subipaddresses[n++] );
						}
						ipList.Add( a );
					}
				}
				else
				{
					foreach( ManagementObject objMO2 in objMOC2 )
					{
						if( objMO2["Caption"] == null || objMO2["AdapterType"] == null )
						{
							continue;
						}
						if( String.Equals( objMO2["Caption"] as String, objMO["Caption"] as String ) )
						{
							/*
							if(
								String.Equals( objMO2["AdapterType"] as String, "Ethernet 802.3" )
								&& ( objMO2["NetConnectionID"] as String ).StartsWith(
									"local area connection"
									, StringComparison.InvariantCultureIgnoreCase
									)
								)
							 * */
							{
								//objMO.
								String[] ipaddresses = (String[])objMO["IPAddress"];
								String[] subipaddresses = (String[])objMO["IPSubnet"];

								int n = 0;
								foreach( String s in ipaddresses )
								{
									Interface a = new Interface();
									a.addr = IPAddress.Parse( s );
									if( subipaddresses[n].IndexOf( '.' ) > 0 )
										a.subnet = IPAddress.Parse( subipaddresses[n++] );
									else
									{
										a.v6 = true;
										a.mask = Convert.ToInt32( subipaddresses[n++] );
									}
									ipList.Add( a );
								}
							}
							break;
						}
					}
				}
			}
			//return ipList;
		}

	}
}
