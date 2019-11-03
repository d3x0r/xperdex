using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Xml;
using System.Xml.XPath;
using BingoGameCore4.Networking.Protocols;
using xperdex.classes;

namespace BingoGameCore4.Networking
{
	internal class BingoGameServer
	{
		BingoHall current_hall;

		internal class BingoGameServerSocketState
		{
			internal byte[] data;
			internal int size;
			internal bool reading_size;
		}

		internal BingoGameServer( BingoHall bingo_hall )
		{
			current_hall = bingo_hall;
			SetupServer();
		}

		Socket socket;

		String host_address;
		IPAddress host_address_ip;
		int host_address_port;
		void SetupServer()
		{
			host_address = Options.Default["Game Protocol Server"]["Host Address", "0.0.0.0:738", "Address to serve protocol from"].Value;
			Uri url; 
			//IPAddress ip; 
			if ( Uri.TryCreate(String.Format("slvp://{0}", host_address)
					, UriKind.Absolute, out url) )
			{
				switch( url.HostNameType )
				{
				case UriHostNameType.Dns:
					IPHostEntry host = Dns.GetHostEntry( url.DnsSafeHost );
					if( host.AddressList.Length > 0 )
						host_address_ip = host.AddressList[0];
					break;
				case UriHostNameType.IPv4:
				case UriHostNameType.IPv6:
					IPAddress.TryParse( url.Host, out host_address_ip );
					break;
				case UriHostNameType.Basic:
				case UriHostNameType.Unknown:
					throw new Exception( "Slave Protocol host address settting is an unrecognized address {" + host_address + "}" );
					break;
				}
				host_address_port = url.Port;
			} 
		}

		public void Start()
		{
			System.Windows.Forms.Timer t = new System.Windows.Forms.Timer();

			socket = new Socket( AddressFamily.InterNetwork,
					SocketType.Stream, ProtocolType.Tcp );
			IPEndPoint iep = new IPEndPoint( host_address_ip, host_address_port );
			socket.Bind( iep );
			socket.Listen( 5 );
			socket.BeginAccept( Connected, this );

			t.Interval = 1000;
			t.Tick += new EventHandler( t_Tick );
			t.Start();
		}

		void t_Tick( object sender, EventArgs e )
		{
			if( socket != null )
			{
				/// alive probe?
			}

		}

		void Connected( IAsyncResult iar )
		{
			Socket client = (Socket)iar.AsyncState;
			try
			{
				BingoGameServerSocketState state = new BingoGameServerSocketState();
				client.EndConnect( iar );
				//conStatus.Text = "Connected to: " + client.RemoteEndPoint.ToString();
				state.data = new byte[4096];
				state.size = 4096;
				state.reading_size = true;
				client.BeginReceive( state.data, 0, 4, SocketFlags.None, read_complete, state );
			}
			catch( SocketException )
			{
				client.Close();
				socket = null;
				//conStatus.Text = "Error connecting";
			}
		}

		void read_complete( IAsyncResult iar )
		{
			BingoGameServerSocketState state = (BingoGameServerSocketState)iar.AsyncState;
			SocketError error;
			int to_read = 4;

			int recv = socket.EndReceive( iar, out error );
			if( recv == 0 )
			{
				// closed?
				socket.Close();
				socket = null;
				return;
			}
			if( error == SocketError.ConnectionReset )
			{
				socket.Close();
				socket = null;
				return;
			}

			if( state.reading_size )
			{
				to_read = BitConverter.ToInt32( state.data, 0 );
				state.reading_size = false;
			}
			else
			{
				string stringData = Encoding.ASCII.GetString( state.data, 0, recv );
				//System.Xml.XPath.XPathNavigator xnav = new XPathNavigator();
				XmlDocument xd = new XmlDocument();
				xd.LoadXml( stringData );
				XPathNavigator xn = xd.CreateNavigator();
				bool okay;
				//XPathNavigator xn2 = xn.CreateNavigator();
				xn.MoveToFirst();
				for( okay = xn.MoveToFirstChild(); okay; okay = xn.MoveToNext() )
				{
					if( xn.NodeType == XPathNodeType.Element )
					{
						String command_data = null;
						String called = null;
						String uncalled = null;
						switch( xn.Name )
						{
						case "Command":
							bool need_do_command = true;
							BingoGameServerProtocol.Commands current_command = BingoGameServerProtocol.Commands.None;
							bool okay2;
							bool everokay = false;
							for( okay2 = xn.MoveToFirstAttribute(); okay2; okay2 = xn.MoveToNextAttribute() )
							{
								switch( xn.Name )
								{
								case "CODE":

									break;
								}
							}
							break;

						}
					}
				}
				state.reading_size = true;
			}
			socket.BeginReceive( state.data, 0, to_read, SocketFlags.None, read_complete, null );
		}
	}
}
