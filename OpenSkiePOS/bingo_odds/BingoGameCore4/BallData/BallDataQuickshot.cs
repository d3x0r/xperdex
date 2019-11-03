using System;
using System.Collections.Generic;
using System.Text;

namespace BingoGameCore3.BallData
{
	class BallDataQuickshot : BallDataInterface
	{
		byte[] balls;
        char[] randomColors;

		public BallDataQuickshot()
		{
			// re-calls a set of balls.
			this.DropBalls();
		}

		#region BallDataInterface Members

		public byte[] CallBalls( int count )
		{
			return balls;
		}

		public byte[] CallBalls()
		{
			return balls;
		}

		public byte[] GetBalls()
		{
			return balls;
		}

		public byte[] DrawBall()
		{
			return balls;
		}

		public void DropBalls()
		{

			CardMaster.CardFactory cf = new BingoGameCore3.CardMaster.CardFactory();
			byte[, ,] card = cf.Create( 1, false );
			balls = new byte[24];
			int n = 0;
			for( int col = 0; col < 5; col++ )
				for( int row = 0; row < 5; row++ )
				{
					if( row == 2 && col == 2 )
						continue;
					balls[n++] = card[0, col, row];
				}
			//throw new Exception("The method or operation is not implemented.");
		}

        public char[] CallRandomColors()
        {
            return randomColors;
        }

        public char[] GetRandomColors()
        {
            return randomColors;
        }

        #endregion
	}
}
