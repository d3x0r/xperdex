using System;
using System.Net.Sockets;
using System.Net;

namespace MobilePOS
{
	public class NetCom: TcpClient
	{
		byte[] buffer;
		IPEndPoint connected_to;
		//override 
		void ReadComplete(IAsyncResult result )
		{
			object o = result.AsyncState; // me...



			GetStream().BeginRead( buffer, 0, buffer.Length, ReadComplete, this );
		}
		public NetCom()
		{
			buffer = new byte[4096];
			//this.
			NetworkStream ns = this.GetStream();
			ns.BeginRead( buffer, 0, buffer.Length, ReadComplete, this );
			this.NoDelay = true;
			//this.Connect( connected_to );
		}
	}
}
