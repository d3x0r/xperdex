using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenSkieTransactionServer
{
	internal class ClientInfo
	{
		internal String address;
		internal int port;
		internal int identifier;

		internal bool pending_transaction;
		internal int local_transnum;
		internal int global_transnum;
	}
}
