using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BingoGameCore4
{
	/// <summary>
	/// Class which tracks combinations and can step through them resulting in the array of indexes of a combination
	/// 
	/// 		CombinationIterator ci = new CombinationIterator( 5 );
	///			int n;
	///			for( n = 0; n &lt; 1600000; n++ )
	///			{
	///				int[] nums;
	///				bool done = ci.IterateCombination( out nums );
	///				String output = "numbers:";
	///				foreach( int num in nums )
	///					output += "," + num;
	///				Log.log( output );
	///				if( done )
	///					break;
	///			}
	///
	/// </summary>
	public class CombinationIterator
	{
		int size;

		ComboMaker maker;

		public CombinationIterator( int set_size )
		{
			this.size = set_size;
			maker = MakeCombinationIterator( set_size );
		}

		class ComboMaker
		{
			internal int   Size;
			internal int   length;
			internal int[] phases;
			internal long  step;
			internal int[] numbers;  // which number's we're using to fill...
			internal long[]facts;
		};

		public long GetCombinations()
		{
			// the last factorial value is short of the total size by the length
			return maker.length * maker.facts[maker.length - 1];
		}

		ComboMaker MakeCombinationIterator( int Size )
		{
			ComboMaker maker = new ComboMaker();
			int n;
			maker.Size = Size;
			maker.length = Size;
			maker.phases = new int[ maker.length];
			maker.step = 0;
			maker.numbers = new int[maker.length];
			maker.facts = new long[maker.length];

			for( n = 0; n < maker.length; n++ )
				maker.phases[n] = 0;

			maker.facts[0] = 1;
			maker.facts[1] = 1;
 			for( n = 2; n < maker.length; n++ )
			{
				maker.facts[n] = maker.facts[n-1] * n;
			}
			return maker;
		}			

		/// <summary>
		/// Iterate the combination array
		/// </summary>
		/// <param name="result_nums">output numbers, list of numbers that are the length specified in constructor</param>
		/// <returns>TRUE if the result is the last combination; FALSE if there are more combinations.  The first combination is already stepped one position, so the last combination is what one would expect to be the first combination.</returns>
		public bool IterateCombination( out int[] result_nums )
		{
			bool phase_0 = true;
			int level;
			int length = maker.length;
			int[] nums = maker.numbers;
			int[] phases = maker.phases;

			for( level = 1; level < length; level++ )
			{
				phases[level]++;
				if( phases[level] <= level )
				{
					phase_0 = false;
					break;
				}
				else
					phases[level] = 0;
			}

			for( level = 0; level < length; level++ )
				nums[level] = level;

			for( level = maker.length-1; level >= 1; level-- )
			{
				int m;
				int tmp;
				for( m = level-phases[level]; m < level; m++ )
				{
					tmp = nums[m];
					nums[m] = nums[m+1];
					nums[m+1] = tmp;
				}
			}
			result_nums = nums;
			return phase_0;
		}

	}
}
