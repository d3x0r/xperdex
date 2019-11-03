using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;

namespace WebInterfaces
{
	[ServiceContract]
	public interface ITransactionServer
	{
		/// <summary>
		/// First use of this interface requires Connect().  This sets up a unique ID for the client process.
		/// </summary>
		/// <param name="bingoday">day to perform sales.</param>
		/// <returns>a unique token for this process.</returns>
		[OperationContract]
		int Connect( DateTime bingoday );
		[OperationContract]
		bool OpenTransaction( int connection_token, out int global_transnum, out int local_transnum );
		[OperationContract]
		bool CloseTransaction( int connection_token );
	}

	public class ClientITransactionServer : ClientBase<ITransactionServer>, ITransactionServer
	{
		public int Connect( DateTime bingoday )
		{
			return base.Channel.Connect( bingoday );
		}
		public bool OpenTransaction( int connection_token, out int global_transnum, out int local_transnum )
		{
			return base.Channel.OpenTransaction( connection_token, out global_transnum, out local_transnum );
		}
		public bool CloseTransaction( int connection_token )
		{
			return base.Channel.CloseTransaction( connection_token );
		}
	}
}
