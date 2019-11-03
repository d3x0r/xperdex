using System.Collections.Generic;
using System.ServiceModel;

namespace MobilePOS
{
	
	class Local
	{
		public class itemlist : List<Item>
		{
			long total_paid;
			public long Total
			{
				get
				{
					long total = 0;
					foreach( Item i in this )
					{
						total += i.Price;
					}
					return total;
				}
			}
			public long Paid
			{
				set
				{
					total_paid += value;
				}
				get
				{
					return total_paid;
				}
			}
		}
		public static ComPort scanner;
		public static ComPort printer;
		public static ComPort cardswipe;
		public static Player player;
		public static Form1 form;
		public static ServiceHost KioskInterface;
		public static ServiceHost BarcodeInterface;
		public static ServiceHost SaleInterface;

		public static itemlist items;
		static Local()
		{
			items = new itemlist();
			//scanner = new ComPort( "COM5", scanner_receive );
			//printer = new ComPort( "COM8", printer_receive );
		}
	}
}
