using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;
using xperdex.classes;

namespace BingoGameCore3.Networking
{
	public class SlaveCallerReceiver
	{
		public delegate void OnBingodayChange( DateTime new_bingoday );
		public static event OnBingodayChange BingodayChanged;

		public delegate void OnSessionChange( int new_session );
		public static event OnSessionChange SessionChanged;

		public delegate void OnGameChange( int new_Game );
		public static event OnGameChange GameChanged;

		public static DateTime Bingoday;

		static UdpClient socket;

		public static void Start()
		{
			if( socket == null )
			{
				try
				{
					if( Options.Default["System:" + Environment.MachineName]["Bingo Game Core"]["Slave Caller"]["Enable Reciever", "0"].Bool )
					{
						String NetInterface = Options.Default["System:" + Environment.MachineName]["Bingo Game Core"]["Slave Caller"]["Receiver Address", "0.0.0.0", "This is the IP on the interface to listen for Slave Caller broadcast"];

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
								Port_Interface = 25000;
							}
						}
						else
						{
							IP_Interface = "0.0.0.0";
							Port_Interface = 25000;
						}

						IPAddress ipadd = IPAddress.Parse( IP_Interface );

						IPEndPoint ipep = new IPEndPoint( ipadd, Port_Interface );
						socket = new UdpClient( ipep );
						//socket.Client.Connect( new IPEndPoint(IPAddress.Broadcast, 3006 ) );
						//socket.Client.Bind( 
						//IPAddress a = System.Net.IPAddress.Any;
						//a.

						//socket.Client.IOControl( IOControlCode.BindToInterface );
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
		}

		static void read_complete( IAsyncResult result )
		//stateObject st;
		{
			// message back should be a process and machine ID of someone that ran a process
			IPEndPoint from = null;
			byte[] buffer = socket.EndReceive( result, ref from );

			Protocols.SlaveCaller.message msg = Protocols.SlaveCaller.ReadMessage( buffer );

			//xperdex.eltanin.protocol.message msg = xperdex.eltanin.protocol.ReadMessage( buffer );
			//BinaryReader br = new BinaryReader( buffer );
			if( msg != null )
				ProcessGameBlock( msg );

			socket.BeginReceive( read_complete, null );

		}


		//static xperdex.eltanin.protocol.PROT_IP_BLOCK_GAME prior_game_block;
		static void ProcessGameBlock( Protocols.SlaveCaller.message msg )
		{
			if( msg == null )
				return;

#if adsfasfd
			if( prior_game_block == null || msg.date != prior_game_block.date )
			{
				if( DateTime.TryParse( msg.date / 100 + "/" + msg.date % 100 + "/" + DateTime.Today.Year, out Bingoday ) )
				{
				}
				else
				{
					Log.log( "Wtf." );
				}
				//Bingoday.Month = msg.date / 100;
				//Bingoday.Day = msg.date % 100;
			}
			if( prior_game_block == null || msg.date != prior_game_block.date )
			{
				if( BingodayChanged != null )
					BingodayChanged( Bingoday );
			}

			if( prior_game_block == null || msg.session != prior_game_block.session )
			{
				if( SessionChanged != null )
					SessionChanged( msg.session );

			}

			if( prior_game_block == null || msg.game != prior_game_block.game )
			{
				if( GameChanged != null )
					GameChanged( msg.game );

			}

			prior_game_block = msg;
#endif
		}

	}
}
