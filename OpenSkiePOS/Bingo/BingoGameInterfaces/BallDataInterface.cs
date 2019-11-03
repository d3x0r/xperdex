using System;

namespace BingoGameInterfaces
{

	public class BingoEvents
	{
		public class BingoSimpleIntEventArgs : EventArgs
		{
			public int arg;
			public BingoSimpleIntEventArgs( int arg )
			{
				this.arg = arg;
			}
		}
		public class BingoSimpleIntPassFailEventArgs : EventArgs
		{
			public int arg;
			public bool success;
			public BingoSimpleIntPassFailEventArgs( int arg )
			{
				this.arg = arg;
				success = true;
			}
			
		}
		public class BingoSimpleBoolEventArgs : EventArgs
		{
			bool arg;
			public BingoSimpleBoolEventArgs( bool arg )
			{
				this.arg = arg;
			}
		}

		public class BingoSimpleStringEventArgs : EventArgs
		{
			string arg;
			public BingoSimpleStringEventArgs( string arg )
			{
				this.arg = arg;
			}
		}

		public class BingoSimplePassFailEventArgs : EventArgs
		{
			public bool success;
			public BingoSimplePassFailEventArgs( )
			{
				success = true;
			}

		}
		public class BingoSimpleDateTimeEventArgs : EventArgs
		{
			public DateTime arg;
			public BingoSimpleDateTimeEventArgs( DateTime arg )
			{
				this.arg = arg;
			}
		}
		public class BingoSimpleDateTimePassFailEventArgs : EventArgs
		{
			DateTime arg;
			public BingoSimpleDateTimePassFailEventArgs( DateTime arg )
			{
				this.arg = arg;
			}
		}



		/// <summary>
		/// type for delegate event when a ball is called or drawn, or session/game change where a single int is only used
		/// </summary>
		/// <param name="sender">object generating the event</param>
		/// <param name="e">event argument</param>
		public delegate void SimpleIntEvent( object sender, BingoSimpleIntEventArgs e );

		/// <summary>
		/// type for delegate event when a ball is called or drawn, or session/game change where a single int is only used
		/// </summary>
		/// <param name="sender">object generating the event</param>
		/// <param name="e">event argument</param>
		public delegate void SimpleBoolEvent( object sender, BingoSimpleBoolEventArgs e );

		/// <summary>
		/// type for delegate event when a ball is called or drawn, or session/game change where a single int is only used
		/// </summary>
		/// <param name="sender">object generating the event</param>
		/// <param name="e">event argument</param>
		public delegate void SimpleStringEvent( object sender, BingoSimpleStringEventArgs e );

		/// <summary>
		/// An event for when date/time info changes (only bingoday)
		/// </summary>
		/// <param name="sender">object generating the event</param>
		/// <param name="e">event argument</param>
		public delegate void SimpleDateEvent( object sender, BingoSimpleDateTimeEventArgs e );

		/// <summary>
		/// A simple event - simple notification with no additional data, (balls dropping, balls dropped)
		/// </summary>
		/// <param name="sender">object generating the event</param>
		/// <param name="e">event argument</param>
		public delegate void SimpleEvent( object sender, EventArgs e );


		/// <summary>
		/// type for delegate event when a ball is called or drawn, or session/game change where a single int is only used
		/// </summary>
		/// <param name="sender">object generating the event</param>
		/// <param name="e">event argument, set success=false if you want to chancel</param>
		public delegate void SimpleQueryEvent( object sender, BingoSimplePassFailEventArgs e );
		/// <summary>
		/// type for delegate event when a ball is called or drawn, or session/game change where a single int is only used
		/// </summary>
		/// <param name="sender">object generating the event</param>
		/// <param name="e">event argument, set success=false if you want to chancel</param>
		public delegate void SimpleIntQueryEvent( object sender, BingoSimpleIntPassFailEventArgs e );
	}

	public interface BallDataInterface
	{
		/// <summary>
		/// This results with the current set of balls, but sets up a new set for the next call (GetBalls will be the next set, not these)
		/// </summary>
		/// <returns>array of balls</returns>
		int[] CallBalls( int count );
		
		/// <summary>
		/// This results with the current set of balls, but sets up a new set for the next call (GetBalls will be the next set, not these)
		/// </summary>
		/// <returns>array of balls</returns>
		int[] CallBalls();

        /// <summary>
        /// results with the currently called balls (nothing added, nothing dropped)
        /// </summary>
        /// <returns>array of balls</returns>
        int[] GetBalls();

        /// <summary>
        /// results with the currently called balls (nothing added, nothing dropped)
        /// </summary>
        /// <returns>array of balls</returns>
        int[] GetBalls( bool ignore_b_balls, bool ignore_i_balls, bool ignore_n_balls, bool ignore_g_balls, bool ignore_o_balls );

        /// <summary>
		/// calls one more ball, and returns the entire list of balls. 
		/// </summary>
		/// <returns>list of balls</returns>
		void DrawBall();

		/// <summary>
		/// reset the list of balls called in this interface...
		/// </summary>
		void DropBalls();

		/// <summary>
		/// Waits until a ball is ready - with external devices it may take some amount of time.
		/// </summary>
		void WaitForBall();

		/// <summary>
		/// Add more balls which may be drawn.  These are known by the application.  numbers should be greater than (count) or less than 0.
		/// </summary>
		/// <param name="balls"></param>
		void AddExtraBalls( int[] balls );

        /// <summary>
        /// Returns the current set of random colors per ball
        /// </summary>
        /// <returns>char array randomly filled with five colors</returns>
        char[] GetRandomColors();

        /// <summary>
        /// Returns the current set of random colors, and sets up a new set for the next call 
        /// The next call to GetRandomColors will return the next set, not these
        /// </summary>
        /// <returns>char array randomly filled with five colors</returns>
        char[] CallRandomColors();
    }
}
