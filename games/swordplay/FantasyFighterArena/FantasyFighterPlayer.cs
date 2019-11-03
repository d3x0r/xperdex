using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using FantasyFighterProtocol;
using System.Windows.Forms;

namespace FantasyFighterArena
{
	/// <summary>
	/// this handles IO to and from the player socket 
	/// </summary>
	public class FantasyFighterPlayer
	{
		FantasyArena arena;
		FighterState fighter;

		TcpClient socket;
		Socket client;

		byte[] buffer;

		MessageReader reader;

		void Dispose()
		{
			arena = null;
			fighter = null;
			socket = null;
			client = null;
			buffer = null;
			reader = null;
		}

		void HandleMessage( MessageCommon msg )
		{
			switch( msg.message_type )
			{
			case MessageCommon.FantasyFighterMessage.Login:
				fighter.name = ( msg as FantasyLoginMessage ).username;
				events( fighter.name + " connected" );
				//MessageBox.Show( (msg as FantasyLoginMessage).username + " connected" );
				break;
			case MessageCommon.FantasyFighterMessage.ChangeWeapon:
				fighter.weapon = ( msg as FantasyFighterWeapon ).weapon;
				arena.NotifyPeers( this );
				events( fighter.name + " new weapon " + fighter.weapon );
				break;
			case MessageCommon.FantasyFighterMessage.ChangeStance:
				fighter.stance = ( msg as FantasyFighterStance ).stance;
				arena.NotifyPeers( this );
				events( fighter.name + " new stance " + fighter.weapon );
				break;
			case MessageCommon.FantasyFighterMessage.CreateArena:
				FantasyArena created = FantasyArenaList.CreateArena( ( msg as FantasyArenaCreate ).arena_name );
				FantasyArenaAdded added = new FantasyArenaAdded( created.name );
				Byte[] output = added.Serialize();
				foreach( FantasyFighterPlayer player in FantasyServer.lobby_fighters )
				{
					player.Send( output );
				}
				break;
			case MessageCommon.FantasyFighterMessage.JoinArena:
				arena = FantasyArenaList.JoinArena( this, ( msg as FantasyArenaJoin ).arena_name );

				{
					FantasyFighterProtocol.FantasyArenaJoined send = new FantasyFighterProtocol.FantasyArenaJoined( arena.name );
					Send( send.Serialize() );
				}
				break;
			case MessageCommon.FantasyFighterMessage.ListArenas:
				{
					FantasyFighterProtocol.FantasyArenaList send = new FantasyFighterProtocol.FantasyArenaList( FantasyArenaList.GetNames() );
					Send( send.Serialize() );
				}
				break;
			}		
		}

		public void PlayerChangedWeapon( FantasyFighterPlayer player )
		{
			FantasyFighterWeapon msg = new FantasyFighterWeapon( player.fighter.ID, player.fighter.weapon );

		}
		void Send( Byte[] output )
		{
			byte[] length = BitConverter.GetBytes( output.Length );
			client.Send( length );
			client.Send( output );
		}

		void ReadComplete( IAsyncResult iar )
		{
			SocketError error;
			int length = client.EndReceive( iar, out error );
			if( error == SocketError.ConnectionReset )
			{
				client.Close();
				this.Dispose();				
				return;
			}
			reader.Add( buffer, length, HandleMessage );
			client.BeginReceive( buffer, 0, 4096, SocketFlags.None, ReadComplete, null );

		}

		void BeginReading()
		{
			client.BeginReceive( buffer, 0, 4096, SocketFlags.None, ReadComplete, null );
		}

		public delegate void AddEvent( String text );
		AddEvent events;
		public FantasyFighterPlayer( AddEvent events, TcpClient client )
		{
			this.fighter = new FighterState();

			this.socket = client;
			this.client = client.Client;
			this.events = events;
			reader = new MessageReader();
			buffer = new byte[4096];
			BeginReading();
		}
	}
}
