using System;

namespace BingoGameInterfaces
{
	interface BingoEventInterface_
	{
		/// <summary>
		/// When a ball is called, this is the ball.  If ball is negative, the ball has been put back into queue
		/// </summary>
		event BingoEvents.SimpleIntEvent BallPulled;

		/// <summary>
		/// When a ball is moved from the input queue to the called state, this event is triggered.
		/// </summary>
		event BingoEvents.SimpleIntEvent BallCalled;


		event BingoEvents.SimpleQueryEvent SessionChanging;
		event BingoEvents.SimpleIntEvent SessionChanged;

		event BingoEvents.SimpleQueryEvent GameChanging;
		event BingoEvents.SimpleIntEvent GameChanged;

		event BingoEvents.SimpleEvent BallsDropping;
		event BingoEvents.SimpleEvent BallsDropped;

		/// <summary>
		/// The pattern literally changed within this game.  
		/// </summary>
		event BingoEvents.SimpleEvent PatternChanged;
		/// <summary>
		/// Internally, the pattern block shown to the world has updated
		/// </summary>
		event BingoEvents.SimpleEvent PatternCycled;

		/// <summary>
		/// 
		/// </summary>
		//event BingoEvents.SimpleBingoCardEvent NewWinner;


		// recover balls
		event BingoEvents.SimpleEvent BeginStateForce;
		event BingoEvents.SimpleEvent EndStateForce;


		event BingoEvents.SimpleIntEvent HotballAdded;
		event BingoEvents.SimpleEvent HotballsCleared;

		event BingoEvents.SimpleEvent FlashboardLocked;
		event BingoEvents.SimpleEvent FlashboardUnlocked;

		event BingoEvents.SimpleBoolEvent LinkBeMaster;
		event BingoEvents.SimpleBoolEvent LinkBeSlave;

		event BingoEvents.SimpleBoolEvent EnableTestOutput;
		event BingoEvents.SimpleBoolEvent EnableBonanaza;
		event BingoEvents.SimpleBoolEvent EnableSingleWild;
		event BingoEvents.SimpleBoolEvent EnableDoubleWild;

		event BingoEvents.SimpleStringEvent BingoStreamCreated;
		event BingoEvents.SimpleStringEvent BingoStreamChanged;

		/// <summary>
		/// dispatched to denote that we will be calling several balls.
		/// </summary>
		event BingoEvents.SimpleEvent BeginWildCall;
		/// <summary>
		/// This is called with the real ball that is causing the wild marks to start.  (double wild may be 2 balls)
		/// </summary>
		event BingoEvents.SimpleIntEvent ContinueWildCall;
		/// <summary>
		/// This is sent when all balls that have been marked because of a wild ball operation are completed.
		/// Each ball called will be sent as a normal 'call ball' 
		/// </summary>
		event BingoEvents.SimpleEvent EndWildCall;

	}

	public class BingoEventInterface
	{
		/// <summary>
		/// When a ball is called, this is the ball.  If ball is negative, the ball has been put back into queue
		/// </summary>
		public event BingoEvents.SimpleIntEvent BallPulled;

		/// <summary>
		/// When a ball is moved from the input queue to the called state, this event is triggered.
		/// </summary>
		public event BingoEvents.SimpleIntEvent BallCalled;

		public event BingoEvents.SimpleDateEvent BingodayChanged;

		public event BingoEvents.SimpleIntQueryEvent SessionChanging;
		public event BingoEvents.SimpleIntEvent SessionChanged;

		public event BingoEvents.SimpleIntQueryEvent GameChanging;
		public event BingoEvents.SimpleIntEvent GameChanged;

		public event BingoEvents.SimpleEvent BallsDropping;
		public event BingoEvents.SimpleEvent BallsDropped;

		/// <summary>
		/// The pattern literally changed within this game.  
		/// </summary>
		public event BingoEvents.SimpleEvent PatternChanged;
		/// <summary>
		/// Internally, the pattern block shown to the world has updated
		/// </summary>
		public event BingoEvents.SimpleEvent PatternCycled;

		/// <summary>
		/// 
		/// </summary>
		//event BingoEvents.SimpleBingoCardEvent NewWinner;


		// recover balls
		public event BingoEvents.SimpleEvent BeginStateForce;
		public event BingoEvents.SimpleEvent EndStateForce;


		public event BingoEvents.SimpleIntEvent HotballAdded;
		public event BingoEvents.SimpleEvent HotballsCleared;

		public event BingoEvents.SimpleEvent FlashboardLocked;
		public event BingoEvents.SimpleEvent FlashboardUnlocked;

		public event BingoEvents.SimpleBoolEvent LinkBeMaster;
		public event BingoEvents.SimpleBoolEvent LinkBeSlave;

		public event BingoEvents.SimpleBoolEvent EnableTestOutput;
		public event BingoEvents.SimpleBoolEvent EnableBonanaza;
		public event BingoEvents.SimpleBoolEvent EnableSingleWild;
		public event BingoEvents.SimpleBoolEvent EnableDoubleWild;

		public event BingoEvents.SimpleStringEvent BingoStreamCreated;
		public event BingoEvents.SimpleStringEvent BingoStreamChanged;

		/// <summary>
		/// dispatched to denote that we will be calling several balls.
		/// </summary>
		public event BingoEvents.SimpleEvent BeginWildCall;
		/// <summary>
		/// This is called with the real ball that is causing the wild marks to start.  (double wild may be 2 balls)
		/// </summary>
		public event BingoEvents.SimpleIntEvent ContinueWildCall;
		/// <summary>
		/// This is sent when all balls that have been marked because of a wild ball operation are completed.
		/// Each ball called will be sent as a normal 'call ball' 
		/// </summary>
		public event BingoEvents.SimpleEvent EndWildCall;

		DateTime _bingoday;
		public DateTime Bingoday
		{
			set
			{
				if( _bingoday != value )
				{
					_bingoday = value;
					if( BingodayChanged != null )
						BingodayChanged( this, new BingoEvents.BingoSimpleDateTimeEventArgs( value ) );
				}
			}
			get
			{
				return _bingoday;
			}
		}

		int _session;
		public int Session
		{
			set
			{
				if( _session != value )
				{
					_session = value;
					if( SessionChanging != null )
					{
						BingoEvents.BingoSimpleIntPassFailEventArgs result;
						SessionChanging( this, result = new BingoEvents.BingoSimpleIntPassFailEventArgs( value ) );
						if( !result.success )
							return;
					}
					if( SessionChanged != null )
						SessionChanged( this, new BingoEvents.BingoSimpleIntEventArgs( value ) );
				}
			}
			get
			{
				return _session;
			}
		}

		int _game;
		public int Game
		{
			set
			{
				if( _game != value )
				{
					_game = value;
					if( GameChanging != null )
					{
						BingoEvents.BingoSimpleIntPassFailEventArgs result;
						GameChanging( this, result = new BingoEvents.BingoSimpleIntPassFailEventArgs( value ) );
						if( !result.success )
							return;
					}
					if( GameChanged != null )
						GameChanged( this, new BingoEvents.BingoSimpleIntEventArgs( value ) );
				}
			}
			get
			{
				return _game;
			}
		}

	}

}

