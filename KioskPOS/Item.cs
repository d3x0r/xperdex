using System;

namespace MobilePOS
{
	internal class Item
	{
		string barcode_type;
		string barcode_series;
		string barcode_three;
		string barcode_pack_id;
		string level;
		Money price;
		public Money Price
		{
			get
			{
				return price;
			}
		}
		public string Level
		{
			get
			{
				return level;
			}
		}

		int pack;
		void ResolveStuff()
		{
			try
			{
				pack = Convert.ToInt32( barcode_pack_id );
			}
			catch( Exception ex )
			{
				throw new Exception( "failed conversion...", ex );
			}
			if( pack >= 0 && pack < 20 )
			{
				price = 800;
				level = "Level 1";
			}
			else if( pack >= 20 && pack < 40 )
			{
				price =( 1200 );
				level = "Level 2";
			}
			else if( pack >= 40 && pack < 60 )
			{
				price =( 2500 );
				level = "Level 3";
			}
			else if( pack >= 60 && pack < 80 )
			{
				price =( 300 );
				level = "Warmup";
			}
			else if( pack >= 80 && pack < 100 )
			{
				price =( 2400 );
				level = "Early Bird";
			}
			else if( pack >= 100 && pack < 120 )
			{
				price =( 1400 );
				level = "Late Bird";
			}
			else if( pack >= 120 && pack < 140 )
			{
				price = ( 800 );
				level = "Payday Jackpot";
			}
			else if( pack == 5303 )
			{
				price = ( 2800 );
				level = "Test 2";
			}
			else if( pack == 11701 )
			{
				price = ( 16800 );
				level = "Test 3";
			}
			else
			{
				price =( 100 );
				level = "Paper";
			}

		}

		internal Item( String line_item, long value )
		{
			level = line_item;
			price = value;
		}

		internal Item( String barcode )
		{
			barcode_type = barcode.Substring( 0, 1 );
			barcode_series = barcode.Substring( 1, 4 );
			barcode_three = barcode.Substring( 5, 3 );
			barcode_pack_id = barcode.Substring( 8, 5 );
			ResolveStuff();
		}

		public override string ToString()
		{
			return Level +"\t" + price;
			//return base.ToString();
		}
	}
}
