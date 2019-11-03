using System;

namespace xperdex.classes
{
	/// <summary>
	/// Value type which represents a fractional value.
	/// </summary>
	public struct Fraction
	{
		int Numerator;
		int Denominator;
		public Fraction( int numerator, int denominator )
		{
			Numerator = numerator;
			Denominator = denominator;
		}
		public Fraction( float numerator, int denominator )
		{
			Numerator = (int)numerator;
			Denominator = denominator;
		}

		public void Set( int numerator, int denominator )
		{
			Numerator = numerator;
			Denominator = denominator;
		}
		public static Fraction operator *( Fraction a, Fraction b )
		{
			return new Fraction( a.Numerator * b.Numerator, a.Denominator * b.Denominator );
		}
		public static int operator *( Fraction a, int n )
		{
			if( a.Denominator != 0 )
				return n * a.Numerator / a.Denominator;
			return System.Int32.MaxValue;
		}
		public static int operator *( int n, Fraction a )
		{
			if( a.Denominator != 0 )
				return n * a.Numerator / a.Denominator;
			return System.Int32.MaxValue;
		}
		public static float operator *( float n, Fraction a )
		{
			if( a.Denominator != 0 )
				return n * a.Numerator / a.Denominator;
			return System.Int32.MaxValue;
		}
		public static float operator *( Fraction a, float n )
		{
			if( a.Denominator != 0 )
				return n * a.Numerator / a.Denominator;
			return System.Int32.MaxValue;
		}
		public static int operator /( int n, Fraction a )
		{
			if( a.Numerator != 0 )
				return n * a.Denominator / a.Numerator;
			return System.Int32.MaxValue;
		}

		public float ToFloat()
		{
			return (float)Numerator / (float)Denominator;
		}

		public override string ToString()
		{
			return Numerator + "/" + Denominator + "[" +((float)Numerator / (float)Denominator).ToString() + "]" ;
			//return base.ToString();
		}
		public static implicit operator Fraction( String s )
		{
			int slash = s.IndexOf( '/' );
			if( slash < 0 )
			{
				int num = Convert.ToInt32( s );
				return new Fraction( num, 1 );
			}
			else
			{
				int num = Convert.ToInt32( s.Substring( 0, slash ) );
				int den = Convert.ToInt32( s.Substring( slash + 1 ) );
				return new Fraction( num, den );
			}
		}

		public static System.Drawing.Rectangle Scale( System.Drawing.Rectangle rectangle, Fraction scale_x, Fraction scale_y )
		{
			System.Drawing.Rectangle newrect = new System.Drawing.Rectangle();
			newrect.X = rectangle.X * scale_x.Numerator / scale_x.Denominator;
			newrect.Y = rectangle.Y * scale_y.Numerator / scale_y.Denominator;
			newrect.Width = rectangle.Width * scale_x.Numerator / scale_x.Denominator;
			newrect.Height = rectangle.Height * scale_y.Numerator / scale_y.Denominator;
			return newrect;
		}
	}
}
