using System;
using System.Collections.Generic;
using System.Text;

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
	}
}
