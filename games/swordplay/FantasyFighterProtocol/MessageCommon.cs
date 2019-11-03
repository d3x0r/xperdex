using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace FantasyFighterProtocol
{
	[Serializable]
	public class MessageCommon
	{
		public enum FantasyFighterMessage
		{
			Login,
			ChangeStance,
			ChangeWeapon,
			ListArenas,
			CreateArena,
			ArenaList,
			ArenaAdded,
			FighterList,
			JoinArena,
			ArenaJoined,

		} ;


		public FantasyFighterMessage message_type;


		public byte[] Serialize()
		{

			BinaryFormatter bin = new BinaryFormatter();
			MemoryStream mem = new MemoryStream();
			try
			{
				bin.Serialize( mem, this );
			}
			catch
			{
			}
			return mem.GetBuffer();

		}



		public static MessageCommon DeSerialize( byte[] dataBuffer, int used )
		{
			BinaryFormatter bin = new BinaryFormatter();
			MemoryStream mem = new MemoryStream();
			mem.Write( dataBuffer, 0, used );
			mem.Seek( 0, 0 );
			return (MessageCommon)bin.Deserialize( mem );
		}

	}


}
