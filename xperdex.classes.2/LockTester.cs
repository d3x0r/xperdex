using System;
using System.Collections.Generic;
using System.Drawing;

namespace xperdex.classes
{
	/// <summary>
	/// Tests whether a point is in a list of points for example to lock the mouse to the point.
	/// </summary>
	public static class LockTester
	{
		public static int TestPoints( Point p, IList<Point> list, ref int tolerance )
		{
			int i = 0;
			foreach( Point test in list )
			{
				int delx = test.X - p.X;
				int dely = test.Y - p.Y;

				if( ( Math.Abs( delx ) <= tolerance ) 
					&& ( Math.Abs( dely ) <= tolerance ) )
				{
					tolerance = Math.Min( Math.Abs( delx ), Math.Abs( dely ) );
					return i;
				}
				i++;
			}
			return -1;
		}
		public static int TestPoints( Point p, IList<Point> list )
		{
			int t = 3;
			return TestPoints( p, list, ref t );
		}
	}
}
