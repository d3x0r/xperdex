using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Sockets;
using System.Net;


namespace xperdex.classes.UpdateService
{
	static public class EventListener
	{
		static List<EventWatcher> watchers = new List<EventWatcher>();

		public class EventWatcher
		{
			public delegate void OnEvent();
			internal String name;
			internal OnEvent event_handler;
			internal EventWatcher( String event_name, OnEvent handler )
			{
				name = event_name;
				event_handler = handler;
				EventListener.watchers.Add( this );
			}
		}


		static UdpClient socket;

		static void Recieve( IAsyncResult packet )
		{
			IPEndPoint remote = null;
			byte[] data = socket.EndReceive( packet, ref remote );
			ASCIIEncoding ae = new ASCIIEncoding();
			String test = ae.GetString( data );
			foreach( EventWatcher watcher in watchers )
			{
				if( watcher.name == test )
				{
					watcher.event_handler();
				}
			}
			socket.BeginReceive( Recieve, null );
		}

		static EventListener()
		{
			socket = new UdpClient();
			socket.ExclusiveAddressUse = false;
			socket.EnableBroadcast = true;
			try
			{
				socket.Client.Bind( new IPEndPoint( 0, 3090 ) );
				socket.BeginReceive( Recieve, null );
			}
			catch
			{
			}
		}

		public static void ListenFor( String name, EventWatcher.OnEvent handler )
		{
			EventWatcher w = new EventWatcher( name, handler );
		}
	}
}
