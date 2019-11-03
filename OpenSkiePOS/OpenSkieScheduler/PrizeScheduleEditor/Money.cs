using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;
using System.ComponentModel;
using System.Globalization;

namespace PrizeScheduleEditor
{

	public class MoneyConverter : TypeConverter
	{
		public override bool CanConvertFrom( ITypeDescriptorContext context, Type sourceType )
		{
			if( sourceType == typeof( string ) )
				return true;
			return base.CanConvertFrom( context, sourceType );
		}
		public override object ConvertFrom( ITypeDescriptorContext context, CultureInfo culture, object value )
		{
			if( value is string )
				return new Money( (string)value );

			return base.ConvertFrom( context, culture, value );
		}
		public override object ConvertTo( ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType )
		{
			if( destinationType == typeof( string ) )
				return value.ToString();

			return base.ConvertTo( context, culture, value, destinationType );
		}
	}

	[TypeConverter( typeof( MoneyConverter ) )]

	public class Money 
    {
        long value;

        public Money()
        {
            value = 0;
        }
        public Money( long value )
        {
            this.value = value;
        }
        public Money(string value)
        {
            this.value = MyConvert(value);
        }
		static public implicit operator Money( System.String s )
		{
			return new Money( s );
		}
	
		//static public explicit operator Money( String s )
		//{
//			return new Money( s );
//		}
		public long MyConvert( string value )
        {
			bool negative = false;
            int offset = 0;
            long newval = 0;
            int decimal_places = 0;
            bool found_decimal = false ;
            for( offset = 0; offset < value.Length; offset++ )
            {
				if( value[offset] == '-' )
				{
					if( newval == 0 )
						negative = true;
				}
                else if (value[offset] == '$')
                    continue;
                else if (value[offset] == '.')
                {
                    found_decimal = true;
                }
                else if (value[offset] >= '0' && value[offset] <= '9')
                {
                    newval = newval * 10;
                    newval += value[offset] - '0';
                    if (found_decimal)
                        decimal_places++;
                }
                else
                    throw new Exception("Bad format for currency value");
            }
            if (decimal_places == 0 )
                newval *= 100; 
            if( decimal_places == 1 )
                newval *= 10;
            if (decimal_places > 2)
            {
                newval /= 10 ^ (decimal_places - 2);
            }
			if( negative )
				newval = -newval;
            return newval;
        }
        public string MyConvert(long value)
        {
			long cents;
			long dollars;
            string out_val;
			if( value >= 0 )
			{
				dollars = value / 100;
				cents = value % 100;
				out_val = "$" + Convert.ToString( value / 100 ) + "." + cents.ToString( "00" );
			}
			else
			{
				dollars = value / 100;
				cents = value % 100;
				out_val = "-$" + Convert.ToString( ( -value ) / 100 ) + "." + cents.ToString( "00" );
			}
            return out_val;
        }
        public override string ToString()
        {

            return MyConvert(this.value);
//            return base.ToString();
        }


	}
}
