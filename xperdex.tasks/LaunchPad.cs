using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;
using System.Xml;
//using xperdex.core;
using System.Xml.XPath;
using xperdex.classes;
using xperdex.core.interfaces;

namespace xperdex.tasks
{
	public class LaunchPad : IReflectorPlugin//, IReflectorPersistance
	{
		class Pad {
			string classname;
			List<String> system_masks;


			public bool Load( XPathNavigator r )
			{
				return false;
			}
			public void Save( XmlWriter w )
			{
			}
		}
		List<Pad> pads = new List<Pad>();

		static StateObject state;
		public class StateObject
		{
			public UdpClient workSocket;



			class tracked_launch
			{
				public TaskItem task;
				public long timestamp;
			}
			List<tracked_launch> trackers = new List<tracked_launch>();

			tracked_launch GetTracker( long timestamp )
			{
				foreach( tracked_launch tracker in trackers )
				{
					if( tracker.timestamp == timestamp )
						return null;
				}
				tracked_launch new_tracker = new tracked_launch();
				new_tracker.timestamp = timestamp;
				trackers.Add( new_tracker );
				return new_tracker;
			}

			void read_complete( IAsyncResult result )
			//stateObject st;
			{


				try
				{
					tracked_launch tracker = null;
					//StateObject state = (StateObject)result.AsyncState;
					IPEndPoint from = null;
					byte[] buffer = state.workSocket.EndReceive( result, ref from );
					TaskItem task = null;
					// decode the packet.
					long timestamp = 0;
					if( from.Port == 3007 || from.Port == 3008 )
					{
						for( int n = 0; n < buffer.Length; n++ )
						{
							switch( buffer[n] )
							{
							case (byte)'^':
								{
									int end;
									for( end = n + 1; buffer[end] != '#'; end++ )
									{
										timestamp = (timestamp * 10) + (buffer[end] - '0');
									}															
									if( (tracker = GetTracker( timestamp )) == null )
									{
										n = buffer.Length;
										break;
									}
									task = new TaskItem();
									tracker.task = task;
									n = end - 1; // post increment will put N on the '#'
								}
								break;
							case (byte)'#':
								{
									int end;
									for( end = n + 1; buffer[end] != 0; end++ )
									{
										//	Encoding.ASCII.GetString( bytesRead, 0, bytesRead.Length )
									}
									task.ProgramName = Encoding.ASCII.GetString( buffer, n + 1, end - n - 1 );
									n = end;
									while( buffer.Length > n )
									{
										n = end;
										for( end = n + 1; end < buffer.Length && (buffer[end] != 0); end++ )
										{
											//	Encoding.ASCII.GetString( bytesRead, 0, bytesRead.Length )
										}
										// there is a double null at the end, resulting in the last argument's length being 0.
										if( end - n - 1 > 0 )
											task.Argument = Encoding.ASCII.GetString( buffer, n + 1, end - n - 1 );
										n = end;
									}
									n--;
								}
								break;
							}
						}
						if( task != null )
						{
							Process process;
							if( task.Execute( out process ) )
							{
								if( from.Port == 3008 ) // if the service disappears, we stop being able to listen.. get a forcable close reset on a half open socket!
								{
									MemoryStream ms = new MemoryStream();
									BinaryWriter bw = new BinaryWriter( ms );
									BinaryReader br = new BinaryReader( ms );
									bw.Write( '$' );
									bw.Write( tracker.timestamp.ToString().ToCharArray() );
									bw.Write( '^' );
									bw.Write( process.Id.ToString().ToCharArray() );
									bw.Write( '#' );
									bw.Write( SystemInformation.ComputerName.ToCharArray() );
									ms.Position = 0;
									workSocket.Send( br.ReadBytes( (int)ms.Length )
										, (int)ms.Length
										, from );
								}
							}

						}
					}
					// start another receive
					state.workSocket.BeginReceive( read_complete, state );
				}
				catch( SocketException e )
				{

					if( e.ErrorCode == 10053 )
						Application.Exit();
						//workSocket.Client.
					//	workSocket.Connect();
					//Debug.WriteLine( e.ToString() );
				}


			}

			public StateObject( int port )
			{
				try
				{
					workSocket = new UdpClient( port );
					workSocket.EnableBroadcast = true;
					workSocket.Ttl = 3;
					workSocket.BeginReceive( read_complete, this );
				}
				catch( Exception ex )
				{
					Log.log( ex.Message );
				}
				//workSocket.ExclusiveAddressUse = false;
			}
		}

		#region IReflectorPlugin Members

		void IReflectorPlugin.Preload()
		{
			//Log.log( "Maybe want to enable receiving.." );
			state = new StateObject( 3006 );
		}

		void IReflectorPlugin.FinishInit()
		{
			//throw new Exception( "The method or operation is not implemented." );
			// having processed load, can now adjust to our configuration?
		}

		#endregion
	}
}
