using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using FantasyFighterProtocol;
using FantasyFighterArena;
using System.Data;

namespace FantasyFighter
{
	public class ClientPort
	{

		internal DataTable ArenaTable;
		internal FantasyArena arena;
		internal FighterState player;	



		TcpClient socket;
		Socket client;

		byte[] buffer;
		MessageReader reader;



		public ClientPort()
		{
			ArenaTable = new DataTable();
			ArenaTable.Columns.Add( "name", typeof( String ) );
		}

		void HandleMessage( MessageCommon msg )
		{
			switch( msg.message_type )
			{
			case MessageCommon.FantasyFighterMessage.ChangeWeapon:
				{
					FantasyFighterWeapon Msg = (FantasyFighterWeapon)msg;
					if( Msg.id == Guid.Empty )
					{
					}
					else
					{
						FighterState fighter = arena.GetFighter( Msg.id );
						if( fighter != null )
							fighter.weapon = Msg.weapon;
					}
				}
				break;
			case MessageCommon.FantasyFighterMessage.ChangeStance:
				{
					FantasyFighterStance Msg = (FantasyFighterStance)msg;
					if( Msg.id == Guid.Empty )
					{
					}
					else
					{
						FighterState fighter = arena.GetFighter( Msg.id );
						if( fighter != null )
							fighter.stance = Msg.stance;
					}
				}
				break;
			case MessageCommon.FantasyFighterMessage.ArenaList:
				{
					FantasyArenaList list = (FantasyArenaList)msg;
					ArenaTable.Rows.Clear();
					foreach( String s in list.arenas )
					{
						DataRow row = ArenaTable.NewRow();
						row["name"] = s;
						ArenaTable.Rows.Add( row );
					}
					ArenaTable.AcceptChanges();
				}
				break;
			case MessageCommon.FantasyFighterMessage.ArenaAdded:
				{
					FantasyArenaAdded list = (FantasyArenaAdded)msg;

						DataRow row = ArenaTable.NewRow();
						row["name"] = list.arenas;
						ArenaTable.Rows.Add( row );

					ArenaTable.AcceptChanges();
				}
				break;
			case MessageCommon.FantasyFighterMessage.ArenaJoined:
				{
					FantasyArenaJoined list = (FantasyArenaJoined)msg;
					arena = new FantasyArena();
					
					new Arena( this ).Show();
				}
				break;
			}
		}

		void ReadComplete( IAsyncResult iar )
		{
			SocketError error;
			int length = client.EndReceive( iar, out error );
			if( error == SocketError.ConnectionReset )
			{

				return;
			}
			reader.Add( buffer, length, HandleMessage );
			client.BeginReceive( buffer, 0, 4096, SocketFlags.None, ReadComplete, null );			
		}


		void Connected( IAsyncResult iar )
		{
			try
			{
				client.EndConnect( iar );
				client.BeginReceive( buffer, 0, 4, SocketFlags.None, ReadComplete, null );
			}
			catch
			{
			}
		}

		public void Start()
		{
			//"d3x0rbbs.homeip.net"
			buffer = new byte[4096];

			socket = new TcpClient();
			reader = new MessageReader();
			
			socket.BeginConnect( "localhost", 5544, Connected, null );
			client = socket.Client;
		}

		void Send( Byte[] output )
		{
			if( client.Connected )
			{
				byte[] length = BitConverter.GetBytes( output.Length );
				client.Send( length );
				client.Send( output );
			}
		}



		public void Login( string username )
		{
			FantasyLoginMessage login = new FantasyLoginMessage( username );
			Send( login.Serialize() );

			ArenaSelector pick_arena = new ArenaSelector( this );
			pick_arena.Show();
		}

		public void ChangeStance( int stance )
		{
			FantasyFighterStance msg = new FantasyFighterStance( (FighterStates.Stance)stance );
			Send( msg.Serialize() );
		}
		public void ChangeWeapon( int stance )
		{
			FantasyFighterWeapon msg = new FantasyFighterWeapon( (FighterStates.WieldedWeapon)stance );
			Send( msg.Serialize() );
		}

		internal void GetArenaList()
		{
			FantasyArenaRequest msg = new FantasyArenaRequest();
			Send( msg.Serialize() );
		}

		internal void CreateArena( string s )
		{
			FantasyArenaCreate msg = new FantasyArenaCreate( s );
			Send( msg.Serialize() );
		}

		internal void JoinArena( string s )
		{
			FantasyArenaJoin msg = new FantasyArenaJoin( s );
			Send( msg.Serialize() );
		}
	}
}
