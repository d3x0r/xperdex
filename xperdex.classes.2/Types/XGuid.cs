using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Globalization;

namespace xperdex.classes.Types
{
	public class GuidConverter : TypeConverter
	{
		public override bool CanConvertFrom( ITypeDescriptorContext context, Type sourceType )
		{
			if( sourceType == typeof( string ) )
				return true;
			if( sourceType == typeof( int ) )
				return true;
			if( sourceType == typeof( long ) )
				return true;
			if( sourceType == typeof( Guid ) )
				return true;
			return base.CanConvertFrom( context, sourceType );
		}
		public override object ConvertFrom( ITypeDescriptorContext context, CultureInfo culture, object value )
		{
			if( value is string )
				return new XGuid( (string)value );
			if( value is int )
				return new XGuid( (int)value );
			if( value is long )
				return new XGuid( (long)value );
			return base.ConvertFrom( context, culture, value );
		}
		public override object ConvertTo( ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType )
		{
			if( destinationType == typeof( string ) )
				return value.ToString();

			return base.ConvertTo( context, culture, value, destinationType );
		}
		public override bool IsValid( ITypeDescriptorContext context, object value )
		{
			return base.IsValid( context, value );
		}
		public override object CreateInstance( ITypeDescriptorContext context, System.Collections.IDictionary propertyValues )
		{
			return base.CreateInstance( context, propertyValues );
		}
	}

	[TypeConverter( typeof( GuidConverter ) )]
	public class XGuid
	{
		Guid guid;

		public XGuid( int a )
		{
			Byte[] bytes = Guid.Empty.ToByteArray();
			Byte[] val_bytes = BitConverter.GetBytes( a );
			for( int n = 0; n < 4; n++ )
				bytes[15 - n] = val_bytes[n];
			guid = new Guid( bytes );
		}
		public XGuid( long a )
		{
			Byte[] bytes = Guid.Empty.ToByteArray();
			Byte[] val_bytes = BitConverter.GetBytes( a );
			for( int n = 0; n < 8; n++ )
				bytes[15 - n] = val_bytes[n];
			guid = new Guid( bytes );
		}
		public XGuid( String a )
		{
			try
			{
				guid = new Guid( a );
			}
			catch
			{
				long val = Convert.ToInt64( a );
				Byte[] bytes = Guid.Empty.ToByteArray();
				Byte[] val_bytes = BitConverter.GetBytes( val );
				for( int n = 0; n < 8; n++ )
					bytes[15 - n] = val_bytes[n];
				guid = new Guid( bytes );
			}
		}
		public override string ToString()
		{
			return guid.ToString();
		}
		public static implicit operator Guid( XGuid a )
		{
			return a.guid;
		}
		public static implicit operator XGuid( int a )
		{
			return new XGuid( a );
		}
		public static implicit operator XGuid( String a )
		{
			return new XGuid( a );
		}

	}

}
