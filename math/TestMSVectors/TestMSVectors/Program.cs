using System;
using System.Collections.Generic;
using System.Text;
using System.Numerics;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace TestMSVectors
{
	class Program
	{
		internal struct MyVector
		{
			
			Vector4 v;
			public float x { get { return v.X; } set { v.X = value; } }
			public float y { get { return v.Y; } set { v.Y = value; } }
			public float z { get { return v.Z; } set { v.Z = value; } }
			public float w { get { return v.W; } set { v.W = value; } }

			public MyVector( Vector4 i )
			{
				v = i;
			}
			public static MyVector operator *( MyVector a, float s ) { return new MyVector( a.v * s ); }
			public void Mul( out MyVector result, float s ) { result.v = v * s; }
		}
		struct Vector2		{
			public double x, y, z, w;			//[MethodImpl( MethodImplOptions.AggressiveInlining )]			public void Mul( out Vector2 result, double s )
			{ result.x = x * s; result.y = y * s; result.z = z * s; result.w = w * s; }
			//[MethodImpl( MethodImplOptions.AggressiveInlining )]			public void Mul( out Vector2 result, ref Vector2 b )
			{ result.x = x * b.x; result.y = y * b.y; result.z = z * b.z; result.w = w * b.w; }
		}

		static void Main( string[] args )
		{
			Vector4 v1 = new Vector4();
			Vector4 v2 = new Vector4();
			Vector4 v3 = new Vector4();
			MyVector a = new MyVector();
			MyVector b = new MyVector();
			Vector2 c = new Vector2();
			Vector2 d = new Vector2();
			Vector2 e = new Vector2();
			Stopwatch sw = new Stopwatch();
			//Debugger.Break();
			int n;

			//v3 = v1 * 5 + v3;

			sw.Reset();
			sw.Start();
			for( n = 0; n < 1000000; n++ )
			{
				c.Mul( out d, 5 );
			}
			sw.Stop();
			Console.WriteLine( "Mul2 op  " + sw.ElapsedTicks );

			sw.Reset();
			sw.Start();
			for( n = 0; n < 1000000; n++ )
			{
				c.Mul( out d, ref e );
			}
			sw.Stop();
			Console.WriteLine( "Mul2 op  " + sw.ElapsedTicks );

			sw.Reset();
			sw.Start();
			for( n = 0; n < 1000000; n++ )
				a.Mul( out b, 5 );
			sw.Stop();
			Console.WriteLine( "Mul op  " + sw.ElapsedTicks );

			sw.Reset();
			sw.Start();
			for( n = 0; n < 1000000; n++ )
				b = a * 5;
			sw.Stop();
			Console.WriteLine( "Mul op2  " + sw.ElapsedTicks );

			sw.Reset();
			sw.Start();
			for( n = 0; n < 1000000; n++ )
				v2 = v1 * 5;
			sw.Stop();
			Console.WriteLine( "Mul op2  " + sw.ElapsedTicks );
		}
	}
}
