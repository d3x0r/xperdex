using System;

namespace xperdex.classes
{
	/// <summary>
	/// Quick port of vector math part.  Hanldes FindIntersectionTime.  (two lines)
	/// </summary>
	public static class VectorGeometry
	{
		public struct Vector
		{
			double x, y, z;
			public double this[int n] { get { return ( n == 0 ) ? x : ( n == 1 ) ? y : z; } 
				set { if( n == 0 ) x = value;else if ( n == 1 )  y = value  ;else  z = value ; } }

			public Vector( double x, double y, double z )
			{
				this.x = x;
				this.y = y;
				this.z = z;
			}
			public Vector( double x, double y )
			{
				this.x = x;
				this.y = y;
				this.z = 0;
			}

			public static void addscaled( ref Vector v1, Vector v2, Vector v3, double scalar )
			{
				v1[0] = v2[0] + ( v3[0] * scalar );
				v1[1] = v2[1] + ( v3[1] * scalar );
				v1[2] = v2[2] + ( v3[2] * scalar );
			}

			public bool zero()
			{
				if( x == 0 && y == 0 && z == 0 )
					return true;
				return false;
			}

			public static void crossproduct( ref Vector pr, Vector pv1, Vector pv2 )
			{
				// this must be limited to 3D only, huh???
				// what if we are 4D?  how does this change??
				// evalutation of 4d matrix is 3 cross products of sub matriccii...
				pr[0] = pv2[2] * pv1[1] - pv2[1] * pv1[2]; //b2c1-c2b1
				pr[1] = pv2[0] * pv1[2] - pv2[2] * pv1[0]; //a2c1-c2a1 ( - determinaent )
				pr[2] = pv2[1] * pv1[0] - pv2[0] * pv1[1]; //b2a1-a2b1 
			}

			public static bool NearZero( double d )
			{
				if( d < 0.00001 && d > -0.00001  )
					return true;
				return false;
			}

			internal static bool COMPARE( double n1, double n2 )
			{
				return Math.Abs( n1 - n2 ) < 0.001;
#if asdasdf
				double tmp1, tmp2;
				int compare_result;
				//#define RCOORDBITS(v)  (*(_64*)&(v))

				tmp1 = n1 - n2;
				/*
				 lprintf( WIDE("exponents %ld %ld"), EXPON( n1 ), EXPON( n2 ) );
				 lprintf("%9.9g-%9.9g=%9.9g %s %s %ld %ld %ld"
						  , (n1),(n2),(tmp1)
						  ,!RCOORDBITS(n1)?"zero":"    ",!RCOORDBITS(n2)?"zero":"    "
					  ,EXPON(n1)-THRESHOLD
						  ,EXPON(n2)-THRESHOLD
						  ,EXPON(tmp1) );
					   */
				tmp2 = n2 - n1;
				/*
				 lprintf("%9.9g-%9.9g=%9.9g %s %s %ld %ld %ld"
						  , (n2),(n1),(tmp2)
						  ,!RCOORDBITS(n2)?"zero":"    ",!RCOORDBITS(n1)?"zero":"    "
						  ,EXPON(n2)-THRESHOLD,EXPON(n1)-THRESHOLD,EXPON(tmp2));
						  */
				compare_result = ( ( !RCOORDBITS( n1 ) ) ? ( ( n2 ) < 0.0000001 &&
																	 ( n2 ) > -0.0000001 ) ? 1 : 0
										: ( !RCOORDBITS( n2 ) ) ? ( ( n1 ) < 0.0000001 &&
																	 ( n1 ) > -0.0000001 ) ? 1 : 0
										: ( ( n1 ) == ( n2 ) ) ? 1
										: ( ( EXPON( n1 ) - THRESHOLD ) >=
										  ( EXPON( tmp1 ) ) ) &&
										( ( EXPON( n2 ) - THRESHOLD ) >=
										 ( EXPON( tmp2 ) ) ) ? 1 : 0
									  );
				/*
				  lprintf( WIDE("result=%d"), compare_result );
				 */
				return compare_result;
#endif
			}
		}




		public static bool FindIntersectionTime( out double pT1,  Vector o1,  Vector s1
                        , out double pT2,  Vector o2,  Vector s2 )
{
	Vector R1 = new Vector();
			Vector R2 = new Vector();
			Vector denoms = new Vector();
   double t1, t2, denom;
   pT1 = 0;
   pT2 = 0;
   if( s1.zero() || s2.zero() )
      return false;
	Vector.crossproduct( ref denoms, s1, s2 ); // - (negative) result...
	denom = denoms[2];
//   denom =  ( s2[1] * s1[0] ) - ( s2[0] * s1[1] );
	if( Vector.NearZero( denom ) )
	{
		denom = denoms[1];
//      denom = ( s2[0] * s1[2] ) - (s2[2] * s1[0] );
		if( Vector.NearZero( denom ) )
		{
			denom = denoms[0];
//         denom = ( s1[1] * s2[2] ) - ( s2[1] * s1[2] );
			if( Vector.NearZero( denom ) )
			{
            /*
//#ifdef FULL_DEBUG
				Log( "Bad!-------------------------------------------\n" );
//#endif
				Log6( "Line 1: <%g %g %g> <%g %g %g>"
							, s1[0], s1[1], s1[2] 
							, o1[0], o1[1], o1[2] );
				Log6( "Line 2:<%g %g %g> <%g %g %g>"
							, s2[0], s2[1], s2[2] 
							, o2[0], o2[1], o2[2] );
				*/
				return false;
			}
			else
			{
				t1 = ( s2[1] * ( o1[2] - o2[2] ) + s2[2] * ( o2[1] - o1[1] ) ) / denom;
				t2 = ( s1[1] * ( o1[2] - o2[2] ) + s1[2] * ( o2[1] - o1[1] ) ) / denom;
			}
		}
		else
		{
			t1 = ( s2[0] * ( o2[2] - o1[2] ) + s2[2] * ( o1[0] - o2[0] ) ) / denom;
			t2 = ( s1[0] * ( o2[2] - o1[2] ) + s1[2] * ( o1[0] - o2[0] ) ) / denom;
		}
	}
	else
	{
		// this one has been tested.......
		t1 = ( s2[0] * ( o1[1] - o2[1] ) + s2[1] * ( o2[0] - o1[0] ) ) / denom;
		t2 = ( s1[0] * ( o1[1] - o2[1] ) + s1[1] * ( o2[0] - o1[0] ) ) / denom;
	}
	Vector.addscaled( ref R1, o1, s1, t1 );
	Vector.addscaled( ref R2, o2, s2, t2 );
	Log.log( "o1 : (" + o1[0] + "," + o1[1] + "," + o1[2] + ")" );
	Log.log( "s1 : (" + s1[0] + "," + s1[1] + "," + s1[2] + ")" );
	Log.log( "o2 : (" + o2[0] + "," + o2[1] + "," + o2[2] + ")" );
	Log.log( "s2 : (" + s2[0] + "," + s2[1] + "," + s2[2] + ")" );
	Log.log( "Intersect1 : (" + R1[0] + "," + R1[1] + "," + R1[2] + ")" );
	Log.log( "Intersect1 : (" + R2[0] + "," + R2[1] + "," + R2[2] + ")" );
	pT2 = t2;
	pT1 = t1;
	{	
		//int i;
		if( ( (!Vector.COMPARE(R1[0],R2[0]) )) ||
			( (!Vector.COMPARE(R1[1],R2[1]) )) ||
			( (!Vector.COMPARE(R1[2],R2[2]) )) )
		{ 
			/*
			Log7( "Points (%12.12g,%12.12g,%12.12g) and (%12.12g,%12.12g,%12.12g) coord %o2[0] is too far apart"
			, R1[0], R1[1], R1[2]
			, R2[0], R2[1], R2[2] 
			, i );
			Log7( "Points (%08X,%08X,%08X) and (%08X,%08X,%08X) coord %o2[0] is too far apart"
			, *(int*)&R1[0], *(int*)&R1[1], *(int*)&R1[2]
			, *(int*)&R2[0], *(int*)&R2[1], *(int*)&R2[2] 
			, i );
			*/
			return false;
		}
	}
	return true;
}

	}




}
