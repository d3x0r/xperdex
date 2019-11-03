using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Net;

namespace FantasyFighterArena
{
	class ServerPort
	{
		TcpListener listener;
		TcpListener listener6;
		Form1 form;
		//List<FantasyFighterPlayer> clients;

		public ServerPort(Form1 form)
		{
			this.form = form;
			//clients = new List<FantasyFighterPlayer>();
		}


		void Connected( IAsyncResult iar )
		{
			ServerPort sp = iar.AsyncState as ServerPort;
			TcpClient client = sp.listener.EndAcceptTcpClient( iar );

			FantasyFighterPlayer player;
			FantasyServer.fighters.AddLast( player = new FantasyFighterPlayer( form.AddEvent, client ) );
			FantasyServer.lobby_fighters.AddLast( player );
			form.AddEvent( "New player connected..." );

			listener.BeginAcceptTcpClient( Connected, this );
		}

		public void Start()
		{
			listener = new TcpListener( IPAddress.Any, 5544 );
			listener.Start();
			listener.BeginAcceptTcpClient( Connected, this );
			form.AddEvent( "Serving IPv4" );

			listener6 = new TcpListener( IPAddress.IPv6Any, 5544 );
			listener6.Start();
			listener6.BeginAcceptTcpClient( Connected, this );
			form.AddEvent( "Serving IPv6" );
		}
	}
}
