using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xperdex.classes;

namespace BingoCardsetCreator
{
	public class ShuffleSpots
	{
		byte[, ,] card_faces;
		byte[] balls;
		static bool seeded;
		static SaltyRandomGenerator rng;

		static ShuffleSpots()
		{
			rng = new SaltyRandomGenerator();
			rng.getsalt += rng_getsalt;
		}

		static void rng_getsalt( SaltyRandomGenerator.SaltData add_data_here )
		{
			if(!seeded)
			{
				seeded = true;
				add_data_here += BitConverter.GetBytes( DateTime.Now.Ticks );
			}
		}


	    static private void Shuffler<T>( ref T[] array )
        {
            int n = 0;
	        SortedList<int, int> rand = new SortedList<int,int>();

			//rngrand.Clear();

			for( int i = 0; i < array.Length; i++ )
			{
				int r;
				do
				{
					r = rng.GetEntropy( 20, false );
				}
				while( rand.IndexOfKey( r ) >= 0 );                rand.Add( r, i );
			}

			T[] tmp = new T[array.Length];

			foreach( int idx in rand.Values )
				tmp[n++] = array[idx];

            array = tmp;
        }

		public static T[] shuffle_list<T>( ref T[] values )
		{
			Shuffler( ref values );
			return values;
		}

		public static byte[] get_list( int length )
		{
			byte[] result = new byte[length];
			int n;
			for(n = 0; n < length; n++)
				result[n] = (byte)(n + 1);
			Shuffler<byte>( ref result );
			return result;
		}

	}
}
