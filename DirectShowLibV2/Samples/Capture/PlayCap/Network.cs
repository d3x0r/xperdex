
using System;
//using System
using xperdex.classes;
using System.IO;
using System.Net.Sockets;
using System.Net;

namespace DirectShowLib.Samples
{
	public class Network
	{
		static UdpClient socket;
		//		static BinaryWriter bw;
		//		static BinaryReader br;
		//		static MemoryStream ms;

		public static void Start()
		{
			try
			{
				if( INI.Default[Environment.MachineName]["Video Player/Enable Reciever", "1"].Integer != 0 )
				{
					String NetInterface = INI.Default[Environment.MachineName]["Video Player/Receiver Address"
						, "127.0.0.1"];

					String IP_Interface;
					int Port_Interface;
					int pos;
					if( NetInterface != null && ( pos = NetInterface.IndexOf( ':' ) ) > 0 )
					{
						IP_Interface = NetInterface.Substring( 0, pos );
						try
						{
							Port_Interface = Convert.ToInt32( NetInterface.Substring( pos + 1 ) );
						}
						catch
						{
							Log.log( "Failed to convert port on interface address... using 25000 default." );
							Port_Interface = 2999;
						}
					}
					else
					{
						if( NetInterface == null )
							IP_Interface = "127.0.0.1";
						else
							IP_Interface = NetInterface;
						Port_Interface = 2999;
					}

					IPAddress ipadd = IPAddress.Parse( IP_Interface );

					last_from = new IPEndPoint( IPAddress.Parse( "127.0.0.1" ), 2998 );
					initial_send = true;

					IPEndPoint ipep = new IPEndPoint( ipadd, Port_Interface );
					socket = new UdpClient( ipep );

					socket.Client.UseOnlyOverlappedIO = true;
					socket.EnableBroadcast = true;
					socket.BeginReceive( read_complete, null );
				}
			}
			catch( Exception ex )
			{
				Log.log( ex.Message );
			}
		}

		//		static EltaninReceiver()
		//		{
		//			ms = new MemoryStream();
		//			br = new BinaryReader( ms );
		//			bw = new BinaryWriter( ms );
		//		}


		public delegate void DoPositionChange( Int32 x, Int32 y, Int32 w, Int32 h );
		public static event DoPositionChange PositionChange;

		public delegate void SimpleEvent();
		public static event SimpleEvent ChannelUp;
		public static event SimpleEvent ChannelDown;
		public static event SimpleEvent VolumeUp;
		public static event SimpleEvent VolumeDown;
		public static event SimpleEvent Hide;
		public static event SimpleEvent TurnOn;
		public static event SimpleEvent TurnOff;
		
		public delegate void SimpleIntEvent( Int32 channel );
		public static event SimpleIntEvent ChannelSet;


		static Int32 last_tick;
		static bool initial_send;
        static IPEndPoint last_from = null;
			
		static void read_complete( IAsyncResult result )
		{
			// message back should be a process and machine ID of someone that ran a process
			//IPEndPoint from = null;
            byte[] buffer;
			try
			{
				buffer = socket.EndReceive( result, ref last_from );
			}
			catch
			{
				socket.BeginReceive( read_complete, null );
				return;
			}

			{
				Int32 tick = BitConverter.ToInt32( buffer, 0 );
				if( tick != last_tick )
				{
					Int32 command = BitConverter.ToInt32( buffer, 4 );
					if( command == 0 )
					{
						Int32 x = BitConverter.ToInt32( buffer, 8 );
						Int32 y = BitConverter.ToInt32( buffer, 12 );
						Int32 w = BitConverter.ToInt32( buffer, 16 );
						Int32 h = BitConverter.ToInt32( buffer, 20 );
						if( PositionChange != null )
							PositionChange( x, y, w, h );
					}
					else if( command == 1 )
					{
						if( ChannelDown != null )
							ChannelDown();
					}
					else if( command == 2 )
					{
						if( ChannelUp != null )
							ChannelUp();
					}
					else if( command == 3 )
					{
						Int32 channel = BitConverter.ToInt32( buffer, 8 );
						if( ChannelSet != null )
							ChannelSet( channel );
					}
					else if( command == 4 )
					{
						if( VolumeDown != null )
							VolumeDown();
					}
					else if( command == 5 )
					{
						if( VolumeUp != null )
							VolumeUp();
					}
					else if( command == 6 )
					{
						if( Hide != null )
							Hide();
					}
					else if( command == 7 )
					{
						Log.log( "7" );
						if( TurnOff != null )
							TurnOff();
					}
					else if( command == 8 )
					{
						Log.log( "8" );
						if( TurnOn != null )
							TurnOn();
					}
					last_tick = tick;
				}
			}

			socket.BeginReceive( read_complete, null );
		}

        public static void SendStatus( int channel, int volume, bool on )
        {
            if( last_from != null )
            {
                byte[] message = new byte[17];
                byte[] tmp;
                int n;
                int ofs = 0;

				tmp = BitConverter.GetBytes( (UInt32)( DateTime.Now.Ticks & 0xFFFFFFFF ) );
				for( n = 0; n < tmp.Length; n++ )
					message[ofs++] = tmp[n];

				if( initial_send )
					tmp = BitConverter.GetBytes( (UInt32)1 );
				else
					tmp = BitConverter.GetBytes( (UInt32)0 );
				for( n = 0; n < tmp.Length; n++ )
                    message[ofs++] = tmp[n];

                tmp = BitConverter.GetBytes( channel );
                for( n = 0; n < tmp.Length; n++ )
                    message[ofs++] = tmp[n];
                tmp = BitConverter.GetBytes( volume );
                for( n = 0; n < tmp.Length; n++ )
                    message[ofs++] = tmp[n];
				tmp = BitConverter.GetBytes( on );
				for( n = 0; n < tmp.Length; n++ )
					message[ofs++] = tmp[n];

				socket.Send( message, ofs, last_from );
				//socket.Send( message, ofs, last_from );
				//socket.Send( message, ofs, last_from );
				initial_send = false;
            }
        }
	}
}