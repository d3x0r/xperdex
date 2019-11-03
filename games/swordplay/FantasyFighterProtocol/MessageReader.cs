using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FantasyFighterProtocol
{
	public class MessageReader
	{

		public MessageReader()
		{
			reading_length = true;
			collector = new byte[4096];
		}

		~MessageReader()
		{
			collector = null;
		}

		bool reading_length;
		byte[] collector;
		int collected;
		int msglength;

		public delegate void MessageHandler( MessageCommon msg );
		public void Add( byte[] buffer, int length, MessageHandler handler )
		{
			int consumed = 0;
			int n;
			do
			{
				if( reading_length )
				{
					int offset = collected;
					for( n = 0; offset < 4 && consumed < length; n++ )
					{
						collector[offset] = buffer[consumed];
						offset++;
						consumed++;
					}
					collected += n;
					if( collected == 4 )
					{
						reading_length = false;
						msglength = BitConverter.ToInt32( collector, 0 );
						collected = 0;
					}
				}
				if( !reading_length )
				{
					if( msglength > collector.Length )
						collector = new byte[4096];

					int offset = collected;
					for( n = 0; offset < msglength && consumed < length; n++ )
					{
						collector[offset] = buffer[consumed];
						offset++;
						consumed++;
					}
					collected += n;

					if( collected == msglength )
					{
						handler( MessageCommon.DeSerialize( collector, collected ) );
						msglength = 4;
						collected = 0;
						reading_length = true;
					}
				}
			} while( consumed < length );
		}
	}
}
