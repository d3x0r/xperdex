using System;
using System.Collections.Generic;
using System.Text;
using xperdex.classes;
using xperdex.classes.networking;

namespace xperdex.plugin.BingoCore.Tester
{
	internal static class restart_buttons 
	{
		public static bool failed;
		static List<bingocore_restart> _list = new List<bingocore_restart>();
		public static List<bingocore_restart> list { get { return _list; } }
	}
	public class bingocore_tester: IReflectorButton
	{

		#region IReflectorButton Members

		public bool OnClick()
		{
			xperdex.eltanin.protocol.PROT_IP_TWOWAY_UNIT_ID msg = new xperdex.eltanin.protocol.PROT_IP_TWOWAY_UNIT_ID( 0, 888888888 );
			network_client client = new network_client( "172.17.2.100", 25001 );
			if( client.GetSocket().Connected )
			{
				client.Send( msg );
			}
			else
			{
				restart_buttons.failed = true;
				foreach( bingocore_restart button in restart_buttons.list )
				{
					button.me.Show();
				}
				// failed... /// now how to find my peer button?
			}

			return true;
		}

		#endregion
	}
}
