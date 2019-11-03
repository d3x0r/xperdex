using System;
using System.Collections.Generic;
using System.Text;

namespace BingoGameCore4.Networking.Protocols
{
	internal static class BingoGameServerProtocol
	{
		internal enum Commands
		{
			None,
			SetCardCount,
			SendCardInfo,
		};
	}
}
