using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Timers;
using xperdex.classes;

namespace xperdex.tasks
{
	/// <summary>
	/// This class is used to actually generate launches at a launch pad.
	/// This is, this triggers and tracks processes launched by remote systems (satillites/orbitals)
	/// 
	/// </summary>
	static class LaunchCommandPost
	{		
		static UdpClient socket;
		static BinaryWriter bw;
		static BinaryReader br;
		static MemoryStream ms;

		static Timer timer;

		static LaunchCommandPost()
		{
			RemoteConnectivity rc = new RemoteConnectivity();
			timer = new Timer( 1000F );
			timer.AutoReset = true;
			timer.Elapsed += new ElapsedEventHandler( MyTimer );
			timer.Start();
			ms = new MemoryStream();
			br = new BinaryReader( ms );
			bw = new BinaryWriter( ms );
			if( socket == null )
			{
				try
				{
					socket = new UdpClient( 3008 );
					//socket.Client.Connect( new IPEndPoint(IPAddress.Broadcast, 3006 ) );
					//socket.Client.Bind( 
					IPAddress a = System.Net.IPAddress.Any;
					//a.

					//socket.Client.IOControl( IOControlCode.BindToInterface );
					socket.Client.UseOnlyOverlappedIO = true;
					socket.EnableBroadcast = true;
					socket.BeginReceive( read_complete, null );
				}
				catch( Exception ex )
				{
					Log.log( ex.Message );
				}
			}
		}


		class Satillites
		{
			public String Machine;
			public int process_id;
			public Process process;
		}
		class Launch
		{
			public long timestamp;
			TaskItem task;
			public List<Satillites> orbitals = new List<Satillites>();
		}
		static List<Launch> launches = new List<Launch>();

		static Launch GetTracker( long timestamp )
		{
			foreach( Launch tracker in launches )
			{
				if( tracker.timestamp == timestamp )
					return tracker;
			}
			return null;
		}


		static void read_complete( IAsyncResult result )
		//stateObject st;
		{
			// message back should be a process and machine ID of someone that ran a process
			IPEndPoint from = null;
			byte[] buffer = socket.EndReceive( result, ref from );
			//BinaryReader br = new BinaryReader( buffer );
			Satillites satellite = null;
			Launch tracker = null;

			//Process p = Process.GetProcessById( 5208, "D3X0R-PC" );
			int Process_id = 0;

			Satillites orbital = null ;
			for( int n = 0; n < buffer.Length; n++ )
			{
				switch( buffer[n] )
				{
				case (byte)'$':
					{
						long timestamp = 0;
						int end;
						for( end = n + 1; buffer[end] != '^'; end++ )
						{
							timestamp = ( timestamp * 10 ) + ( buffer[end] - '0' );
						}
						if( ( tracker = GetTracker( timestamp ) ) == null )
						{
							n = buffer.Length;
							break;
						}
						orbital = new Satillites();
						n = end - 1; // post increment will put N on the '#'
					}
					break;
				case (byte)'^':
					{
						int end;
						for( end = n + 1; buffer[end] != '#'; end++ )
						{
							Process_id = ( Process_id * 10 ) + ( buffer[end] - '0' );
						}
						orbital.process_id = Process_id;
						n = end - 1; // post increment will put N on the '#'
					}
					break;
				case (byte)'#':
					{
						int end;
						for( end = n + 1; end < buffer.Length && buffer[end] != 0; end++ )
						{
							//	Encoding.ASCII.GetString( bytesRead, 0, bytesRead.Length )
						}
						orbital.Machine = Encoding.ASCII.GetString( buffer, n + 1, end - n - 1 );
						n = end - 1;
					}
					break;
				}
			}
			if( tracker != null )
				if( orbital != null )
				{
					try
					{
						if( Local.IsAddressLocal( from.Address ) )
							orbital.process = Process.GetProcessById( orbital.process_id
							);
						else
						//Process.
						orbital.process = Process.GetProcessById( orbital.process_id
							, from.Address.ToString() //orbital.Machine 
						);
						tracker.orbitals.Add( orbital );
					}
					catch( Exception ex )
					{
						Log.log( "Last I saw this was 'task not running (anymore)' : " + ex.Message );
						// orbital.dispose
					}
				}

			socket.BeginReceive( read_complete, null );

		}


		static void MyTimer( object sender, ElapsedEventArgs e )
		{
			lock( launches )
			{
				foreach( Launch tracker in launches )
				{
					foreach( Satillites s in tracker.orbitals )
					{
						s.process.Refresh();
						if( s.process.HasExited )
						{
							Log.log( "Process has exited..." );
							s.process.Close();
							s.process = null;
							tracker.orbitals.Remove( s );
							break;
							// something...
						}
						Log.log( s.process.ToString() );
					}
				}
			}
		}

		static void MySend( byte[] array )
		{
			foreach( Local.Interface if_addr in Local.addrlist )
			{
				if( if_addr.v6 )
					continue;
				socket.Send( array, (int)array.Length, if_addr.broadcast_ep );
			}

		}

		internal static bool PerformLaunch( TaskItem task )
		{
			if( socket == null )
			{
				Log.log( "Failed to open socket to send." );
				return false;
			}
			Launch launch = new Launch();
			
			launch.timestamp = DateTime.Now.Ticks ;
			//bw.Seek
			ms.SetLength( 0);
			ms.Position = 0;
			bw.Write( '^' );
			bw.Write( launch.timestamp.ToString().ToCharArray() );
			bw.Write( '#' );
			bw.Write( task.ProgramName.ToCharArray() );
			bw.Write( (byte)0 );
			String[] args = task.Args;
			if( args != null )
				foreach( string s in args )
				{
					bw.Write( s.ToCharArray() );
					bw.Write( (byte)0 );
				}
			bw.Write( (byte)0 );
			ms.Position = 0;
			//br.
			byte[] array = br.ReadBytes( (int)ms.Length );
			launches.Add( launch );
			for( int x = 0; x < 5; x++ )
			{
				MySend( array );
				//socket.Send( array, (int)ms.Length, "255.255.255.255", 3006 );
				System.Threading.Thread.Sleep( 40 );
			}

			return true;
			//Process p = Process.GetCurrentProcess();
			//string args = Process.GetCurrentProcess().StartInfo.Arguments;
			//throw new Exception( "The method or operation is not implemented." );
		}
	}
}
