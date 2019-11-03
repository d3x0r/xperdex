using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace xperd3x.GestureCore
{
	public class ControlMatrix
	{
		internal float[,] data;

		public ControlMatrix( float[,] data_plane )
		{
			data = data_plane;
		}

		public static float[,] Diff( float[,] a, float[,] b )
		{
			int w, h;
			float[,] result = new float[w =a.data.GetLength( 0 ), h =a.data.GetLength( 1 )];
			for( int x = 0; x < w; x++ )
			{
				for( int y = 0; y < h; y++ )
				{
					result[x, y] = a[x, y] - b[x, y];
				}
			}
		}

		public static float[,] AbsDiff( float[,] a, float[,] b )
		{
			int w, h;
			float[,] result = new float[w = a.data.GetLength( 0 ), h = a.data.GetLength( 1 )];
			for( int x = 0; x < w; x++ )
			{
				for( int y = 0; y < h; y++ )
				{
					float c = a[x, y];
					float d = b[x, y];
					if( c > d )
						result[x, y] = c - d;
					else
						result[x, y] = d - c;
				}
			}
		}

		public static void Scale( float[,] data, float scale )
		{
			int w, h;
			w = a.data.GetLength( 0 );
			h = a.data.GetLength( 1 );
			for( int x = 0; x < w; x++ )
			{
				for( int y = 0; y < h; y++ )
				{
					data[x,y] = data[x,y] * scale;
				}
			}
		}

		public static float[,] AbsVelocity( float[,] baseline, float[,] a, float[,] b )
		{
			float[,] a1 = AbsDiff( a, b );
			return AbsDiff( baseline, a1 );
		}

		public static float[,] AbsAcceleration( float[,] baseline, float[,] a, float[,] b )
		{
			float[,] a1 = AbsVelocity( a, b );
			return AbsVelocity( baseline, a1 );
		}

		static List<Point> FindPeeks()
		{
			//List
		}

	}
}
