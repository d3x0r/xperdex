using System;
//using System.Runtime.Serialization;
using System.ComponentModel;
using System.Globalization;

namespace xperdex.classes
{

#if used_in_data_grids
	
#endif
    public class MoneyConverter : TypeConverter
    {
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            if (sourceType == typeof(string))
                return true;
            return base.CanConvertFrom(context, sourceType);
        }
        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            if (value is string)
                return new Money((string)value);

            return base.ConvertFrom(context, culture, value);
        }
        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            if (destinationType == typeof(string))
                return value.ToString();

            return base.ConvertTo(context, culture, value, destinationType);
        }
    }

    [TypeConverter(typeof(MoneyConverter))]
	public class Money : System.Xml.Serialization.IXmlSerializable
	{
		decimal value;
		//long value;

		public Money()
		{
			value = 0;
		}
		public Money( long value )
		{
			this.value = value;
			this.value /= 100m;
		}
		public Money( string value )
		{
            this.value = Convert.ToDecimal(MyConvert(value)) / 100m;
		}
		static public implicit operator Money( System.String s )
		{
			return new Money( s );
		}
		static public implicit operator Money( long n )
		{
            return new Money(n / 100);
		}
        static public implicit operator Money( Int32 n )
        {
			return new Money(n);
        }
		static public implicit operator String( Money m )
		{
			return m.value.ToString( "c" );
		}
		static public implicit operator long( Money m )
		{
			return (long)decimal.Round( m.value * 100m );
		}

		//static public explicit operator Money( String s )
		//{
		//			return new Money( s );
		//		}
		public long MyConvert( string value )
		{
//			return (long)decimal.Round( Convert.ToDecimal( value ) * 100m );
			bool negative = false;
			int offset = 0;
			long newval = 0;
			int decimal_places = 0;
			bool found_decimal = false;
			for( offset = 0; offset < value.Length; offset++ )
			{
                if ( ( value[offset] == ' ' )
                    || ( value[offset] == ')' ) )
                    continue;
				if(( value[offset] == '-' )
                    || ( value[offset] == '(' ) )
				{
					if( newval == 0 )
						negative = true;
				}
				else if( value[offset] == '$' )
					continue;
				else if( value[offset] == '.' )
				{
					found_decimal = true;
				}
                else if (value[offset] == ',')
                {
                    continue;
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
			if( decimal_places == 0 )
				newval *= 100;
			if( decimal_places == 1 )
				newval *= 10;
			if( decimal_places > 2 )
			{
				newval /= (long)Math.Pow(10, decimal_places - 2);
			}
			if( negative )
				newval = -newval;
			return newval;
		}
		public string MyConvert(long value)
		{
			return (new Money(value) / 100m ).ToString( "c" );
#if asdfasdf
			long cents;
			long dollars;
			string out_val;
			if (value >= 0)
			{
				dollars = value / 100;
				cents = value % 100;
				out_val = "$" + Convert.ToString(dollars) + "." + cents.ToString("00");
			}
			else
			{
				dollars = value / 100 * (-1);
				cents = value % 100 * (-1);
				out_val = "-$" + Convert.ToString(dollars) + "." + cents.ToString("00");
			}
			return out_val;
#endif
		}
		public override string ToString()
		{
			return value.ToString( "c" );
			//return MyConvert(this.value);
			//            return base.ToString();
		}

#if test1
		public string SerializeMoney( Money money )
		{
			return money.ToString();
		}

		public Money DeserializeColor( string money )
		{
			return new Money( money );
		}

		[System.Xml.Serialization.XmlIgnore()]
		public Color ColorType
		{
			get
			{
				return (Color)settings["color"];
			}
			set
			{
				settings["color"] = value;
			}
		}

		[XmlElement( "ColorType" )]
		public string XmlColorType
		{
			get
			{
				return Settings.SerializeColor( ColorType );
			}
			set
			{
				ColorType = Settings.DeserializeColor( value );
			}
		}

#endif
		System.Xml.Schema.XmlSchema System.Xml.Serialization.IXmlSerializable.GetSchema()
		{
			throw new NotImplementedException();
		}

		void System.Xml.Serialization.IXmlSerializable.ReadXml( System.Xml.XmlReader reader )
		{
			string valuez = reader.ReadString();
			this.value = MyConvert( valuez ) / 100m;
		}

		void System.Xml.Serialization.IXmlSerializable.WriteXml( System.Xml.XmlWriter writer )
		{
			writer.WriteString( this.ToString() );
		}
	}
}
