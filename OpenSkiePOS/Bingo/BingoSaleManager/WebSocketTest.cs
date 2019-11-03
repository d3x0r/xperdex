using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fleck;

namespace BingoSaleManager
{
	class WebSocketTest
	{
		List<IWebSocketConnection> allSockets = new List<IWebSocketConnection>();
		Fleck.WebSocketServer server;
		WebSocketTest()
		{
			server = new Fleck.WebSocketServer( "ws://localhost:8123" );
			//something.
			server.Start( socket => 
				{
					socket.OnOpen = () => allSockets.Add (socket);
					socket.OnClose = () => allSockets.Remove (socket);
					socket.OnMessage = message =>
					{
						foreach( var s in allSockets )
							s.Send( message );
					};
				} );
		}
	}
}
