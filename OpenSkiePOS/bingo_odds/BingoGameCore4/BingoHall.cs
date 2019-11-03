using System;
using BingoGameInterfaces;
using OpenSkieScheduler3;

namespace BingoGameCore4
{
	/// <summary>
	/// This class is the outermost object for tracking and playing bingo.  If you have a hall, you can then set it to a session.
	/// This provides an interface that contains the events
	/// </summary>
	public class BingoHall : BingoEventInterface
	{
		public BingoEventInterface Events;

		ScheduleDataSet schedule;
		DateTime bingoday;
		int session_number;
		BingoSession next_session;
		BingoSession session;
		BingoSessionEvent next_session_event;
		BingoSessionEvent session_event;
		int game_number;
		BingoGameState game_state;

		BingoSQLTracking.BingoTracking bingo_tracking;

		public BingoHall()
		{
			BingodayChanged += BingoHall_BingodayChanged;
			SessionChanged += BingoHall_SessionChanged;
			GameChanged += BingoHall_GameChanged;
			bingo_tracking = new BingoSQLTracking.BingoTracking();

			bingo_tracking.ConnnectBingoTrackingToDatabase( "game_database3.db" );

			schedule = new ScheduleDataSet();

			Events = new BingoEventInterface();

			bingo_tracking.HookEvents( Events );

			Events.SessionChanging += new BingoEvents.SimpleIntQueryEvent( Events_SessionChanging );
			Events.BingodayChanged += new BingoEvents.SimpleDateEvent( event_interface_BingodayChanged );
			Events.SessionChanged += new BingoEvents.SimpleIntEvent( event_interface_SessionChanged );
			Events.GameChanged += new BingoEvents.SimpleIntEvent( Events_GameChanged );
			
		}

		void Events_SessionChanging( object sender, BingoEvents.BingoSimpleIntPassFailEventArgs e )
		{
			try
			{
				next_session = new BingoSession( schedule, bingoday, e.arg );
				next_session_event = new BingoSessionEvent( next_session, true );
			}
			catch
			{
				e.success = false;
			}
		}

		void Events_GameChanged( object sender, BingoEvents.BingoSimpleIntEventArgs e )
		{
			game_state = session_event.StepTo( e.arg );
		}

		void event_interface_BingodayChanged( object sender, BingoEvents.BingoSimpleDateTimeEventArgs e )
		{
			bingoday = e.arg;
		}


		void event_interface_SessionChanged( object sender, BingoEvents.BingoSimpleIntEventArgs e )
		{
			session_number = e.arg;
			session = next_session;
			session_event = next_session_event;
		}


		void BingoHall_BingodayChanged( object sender, BingoEvents.BingoSimpleDateTimeEventArgs e )
		{
			Events.Bingoday = e.arg;
		}

		void BingoHall_SessionChanged( object sender, BingoEvents.BingoSimpleIntEventArgs e )
		{
			Events.Session = e.arg;
		}

		void BingoHall_GameChanged( object sender, BingoEvents.BingoSimpleIntEventArgs e )
		{
			Events.Game = e.arg;
		}

	}
}
