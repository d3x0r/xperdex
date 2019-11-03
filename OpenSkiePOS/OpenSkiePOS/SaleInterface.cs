using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebInterfaces;

namespace OpenSkiePOS
{
	public class SaleInterface: ISaleModule
	{
		public static ISaleModule OpenSaleInterface()
		{
			if( POS.Local.sale_interface == null )
				POS.Local.sale_interface = new SaleInterface();
			return POS.Local.sale_interface;
		}

		void ISaleModule.Start()
		{
			
		}

		void ISaleModule.SetBingoday( DateTime date )
		{
			POS.Local.SetBingoday( date );	
		}

		void ISaleModule.SetSession( int session_number )
		{
			POS.Local.SetSession( session_number );				
		}

		void ISaleModule.BeginTransaction( object transaction_id )
		{
			
		}

		void ISaleModule.EndTransaction()
		{
			
		}

		void ISaleModule.ClearAll()
		{
			
		}

		void ISaleModule.ClearItem( object item_id )
		{
			
		}

		void ISaleModule.VoidTransaction( object transaction_id )
		{
			
		}

		void ISaleModule.VoidTransactionItem( object transaction_id, object item_id )
		{
			
		}
	}
}
