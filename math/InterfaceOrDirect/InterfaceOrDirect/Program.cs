using System;
using System.Collections.Generic;
using System.Text;

namespace InterfaceOrDirect
{
	class Program
	{
		public interface IVector
		{
			void Add( ref Vector a, out Vector r );
		}

		public struct Vector : IVector
		{
			double x, y, z;

			public void Add( ref Vector a, out Vector r )
			{
				r.x = x + a.x;
				r.y = y + a.y;
				r.z = z + a.z;
			}
		}

		static void Main( string[] args )
		{
			Vector a = new Vector(), b = new Vector(), c = new Vector();
			IVector ia = a, ib = b, ic = c;
			Console.WriteLine( "interface" );
			ia.Add( ref b, out c );

			Console.WriteLine( "direct" );
			a.Add( ref b, out c );
		}
	}
}
