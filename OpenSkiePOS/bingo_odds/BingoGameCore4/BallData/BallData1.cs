using System;
using System.Collections.Generic;
using BingoGameInterfaces;

namespace BingoGameCore4
{
	/// <summary>
	/// This is random ball drawer.  Default (keeps the '1') indicator.
	/// </summary>
	public class BallData_Random75 : BallDataInterface
	{
		int[] balls;
        public char[] randomColors;
        SortedList<int, int> rand;
        static Random entropy;
		int called_count;
		int ball_count;
        public bool log;

        char[] colorWheel = { 'B', 'I', 'N', 'G', 'O' };

        public BallData_Random75()
		{
            BallDataInit( 75 );
		}

		public BallData_Random75( int count )
        {
            BallDataInit( count );
        }
        
        private void BallDataInit( int count )
        {
            ball_count = count;

            entropy = new Random();

            balls = new int[count];
            randomColors = new char[count];

            for( int i = 1; i <= count; i++ )
                balls[i - 1] = i;

            for( int i = 0; i < count; i++ )
                randomColors[i] = colorWheel[i/15];

            rand = new SortedList<int, int>();

            DoShuffle();
        }

        private void Shuffler<T>( ref T[] array )
        {
            int n = 0;

			rand.Clear();

			for( int i = 0; i < array.Length; i++ )
			{
				int r;
				do
				{
					r = entropy.Next();
				}
				while( rand.IndexOfKey( r ) >= 0 );                rand.Add( r, i );
			}

			T[] tmp = new T[array.Length];

			foreach( int idx in rand.Values )
				tmp[n++] = array[idx];

            array = tmp;
        }

		void DoShuffle()
		{
            Shuffler( ref balls );
            Shuffler( ref randomColors );
		}

		#region BallDataInterface Members

		int[] BallDataInterface.CallBalls()
		{
            called_count = 0;
            int[] result = balls;

            Shuffler( ref result );

			return result;
		}

		int[] BallDataInterface.GetBalls()
		{
            int[] result;

			if( called_count < balls.Length )
			{
				result = new int[called_count];
				for( int n = 0; n < called_count; n++ )
					result[n] = balls[n];
			}
            else
            {
                result = (int[])balls.Clone();
            }

            return result;
		}

        int[] BallDataInterface.GetBalls( bool ignore_b_balls, bool ignore_i_balls, bool ignore_n_balls, bool ignore_g_balls, bool ignore_o_balls )
        {
            List<int> newlist = new List<int>();
            for( int n = 0; n < called_count; n++ )
            {
                int ball = balls[n];
                int col = ( ball - 1 ) / 15;
                if( col == 0 && ignore_b_balls )
                    continue;
                if( col == 1 && ignore_i_balls )
                    continue;
                if( col == 2 && ignore_n_balls )
                    continue;
                if( col == 3 && ignore_g_balls )
                    continue;
                if( col == 4 && ignore_o_balls )
                    continue;
                newlist.Add( ball );
            }
            return newlist.ToArray();
        }

		int[] BallDataInterface.CallBalls( int count )
		{
			if( count > 0 )
			{
				Shuffler( ref balls );

				// can only return a max of called balls...
				if( count > balls.Length )
					count = balls.Length;

				int[] result = new int[count];

				for( int i = 0; i < count; i++ )
					result[i] = balls[i];

				Shuffler( ref balls );
				return result;
			}
			return new int[0];
		}

		void BallDataInterface.DrawBall()
		{
			if( called_count < balls.Length )
				called_count++;
		}

		void BallDataInterface.DropBalls()
		{
			called_count = 0;
			Shuffler( ref balls );
		}

        void BallDataInterface.WaitForBall()
		{
			// no wait.
		}
 

        char[] BallDataInterface.CallRandomColors( )
        {
            char[] result = (char[])randomColors.Clone();
            called_count = 0;

            Shuffler( ref result );

            return result;
        }

		void BallDataInterface.AddExtraBalls( int[] more_balls )
		{
			balls = new int[ball_count + more_balls.Length];
			int i;
			for( i = 1; i <= ball_count; i++ )
				balls[i - 1] = i;

			foreach( int ball in more_balls )
			{
				balls[i - 1] = ball;
				i++;
			}
            Shuffler(ref balls);
        }


        char[] BallDataInterface.GetRandomColors( )
		{
#if null
            char[] result;
            if (called_count < ball_count)
            {
                result = new int[called_count];
                for (int n = 0; n < called_count; n++)
                    result[n] = randomColors[n];
            }
            else
#endif
			return (char[])randomColors.Clone();
        }
        #endregion
    }
}
