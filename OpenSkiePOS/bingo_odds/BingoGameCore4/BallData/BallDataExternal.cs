using System.Collections.Generic;
using BingoGameInterfaces;

namespace BingoGameCore4
{
	public class BallDataExternal : BallDataInterface
	{
		int[] balls;
		int[] extra_balls;
		int called_count;
		int ball_count;
		public bool log;
		//BallData_Random75 random_extra = new BallData_Random75();

		public BallDataExternal()
		{
			ball_count = 75;
		}

		public BallDataExternal( int count )
		{
			ball_count = count;
		}

		public int[] Balls
		{
			set
			{
				balls = value;
			}
		} 

		#region BallDataInterface Members

		int[] BallDataInterface.CallBalls()
		{
			called_count = 0;
			return balls;
		}

		int[] BallDataInterface.GetBalls()
		{
			if( called_count < ball_count )
			{
				int[] result = new int[called_count];
				for( int n = 0; n < called_count; n++ )
				{
					result[n] = balls[n];
				}
				return result;
			}
			// return private copy so write modifications don't happen.
			int[] array = (int[])balls.Clone();
			return array;// (int[])balls.Clone();
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
			int[] prior = (int[])balls.Clone();
			// can only return a max of called balls...
			if( count > ball_count )
				count = ball_count;

			int[] result = new int[count];
			for( int i = 0; i < count; i++ )
				result[i] = prior[i];

			return result;
		}


		void BallDataInterface.DrawBall()
		{
			if( called_count < ball_count )
			{
				called_count++;
			}
		}

		void BallDataInterface.DropBalls()
		{
			called_count = 0;
		}
		void BallDataInterface.WaitForBall()
		{
			// no wait.
		}

		void BallDataInterface.AddExtraBalls( int[] balls )
		{
		}

		char[] BallDataInterface.CallRandomColors()
        {
            return null;
        }

		char[] BallDataInterface.GetRandomColors()
        {
            return null;
        }
        #endregion

	}
}
