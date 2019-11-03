using System;
using System.Collections.Generic;
using System.Text;

namespace BingoGameCore3.Networking.Protocols
{
	internal class SlaveCaller
	{

		public class message
		{
		}

		public static message ReadMessage( byte[] buffer )
		{
			//int ID = buffer[0] | buffer[1] << 8;
			//switch( (MessageID)ID )
			{
			//case eltanin.protocol.MessageID.PROT_IP_CMD_GAME_BLOCK:
			//	PROT_IP_BLOCK_GAME game_block = new PROT_IP_BLOCK_GAME( buffer );
			//	return game_block;
			}
			//throw new Exception( "The method or operation is not implemented." );

			return null;

		}
	}
}
