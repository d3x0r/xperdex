using System;
using System.Collections.Generic;
using System.Text;
using xperdex.classes;
using BingoGameCore4;
using BingoGameInterfaces;

namespace BingoGameCoreVerifier
{
	public class BingoGameVerifier
	{
		DateTime bingoday;
		BingoEventInterface bingo_events;
		BingoSession session;
		BingoSessionEvent session_event;

		//BingoGameCore4.Networking.FlashdriveSlaveHost bingo_game_core;
		//BingoGameInterfaces.BallDataInterface.FlashdriveController bingo_game_core_data;
		BallDataInterface bingo_game_ball_device;
		BingoSQLTracking.BingoTracking bingo_game_tracking;
		OpenSkieScheduler3.ScheduleDataSet schedule;

		BingoGameState bingo_game_state;

		public BingoGameVerifier()
		{
			schedule = new OpenSkieScheduler3.ScheduleDataSet( StaticDsnConnection.dsn );
			schedule.Create();
			schedule.Fill();

			bingo_events = new BingoEventInterface();
			bingo_game_tracking = new BingoSQLTracking.BingoTracking();
			bingo_game_tracking.ConnnectBingoTrackingToDatabase( StaticDsnConnection.dsn.DataSource );
			bingo_game_tracking.Create();
			bingo_game_tracking.HookEvents( bingo_events );
			bingo_game_tracking.LoadCurrent();

			// setup to be able to serve information to others.
			//bingo_game_core = new BingoGameCore3.Networking.FlashdriveSlaveHost();
			//bingo_game_core.Start();

			//bingo_game_core_data = new BingoGameCore3.BallData.FlashdriveController();
			//bingo_game_core_data.Events = bingo_events;
			//bingo_game_core_data.Start();
			//bingo_game_ball_device = bingo_game_core_data;

			// setup events to track the state of the current game.
			bingo_events.BingodayChanged += new BingoEvents.SimpleDateEvent( bingo_events_BingodayChanged );
			bingo_events.SessionChanged += new BingoEvents.SimpleIntEvent( bingo_events_SessionChanged );
			bingo_events.GameChanged += new BingoEvents.SimpleIntEvent( bingo_events_GameChanged );
			bingo_events.BallPulled += new BingoEvents.SimpleIntEvent( bingo_events_BallPulled );


		}

		void bingo_events_BallPulled( object sender, BingoEvents.BingoSimpleIntEventArgs e )
		{
			session_event.LoadPlayers();
		}

		void bingo_events_GameChanged( object sender, BingoEvents.BingoSimpleIntEventArgs e )
		{
			bingo_game_core_data_GameChanged( e.arg );
		}

		void bingo_events_SessionChanged( object sender, BingoEvents.BingoSimpleIntEventArgs e )
		{
			bingo_game_core_data_SessionChanged( e.arg );
		}

		void bingo_events_BingodayChanged( object sender, BingoEvents.BingoSimpleDateTimeEventArgs e )
		{
			bingo_game_core_data_BingodayChanged( e.arg );
		}

		void bingo_game_core_data_BingodayChanged( DateTime Bingoday )
		{
			bingoday = Bingoday;
		}

		int _session;
		void bingo_game_core_data_SessionChanged( int session_number )
		{
			if( bingo_game_state != null )
			{
				//delete bingo_game_state;
			}
			if( _session == session_number )
				return;
			_session = session_number;
				
			try
			{
				this.session = new BingoSession( schedule, bingoday, session_number );

				this.session_event = new BingoSessionEvent( this.session, null );
			}
			catch
			{
				this.session = null;
			}
		}

		int _game;
		void bingo_game_core_data_GameChanged( int game )
		{
			if( session != null )
			{
				if( game == _game )
					return;
				_game = game;
				if( game > 0 )
				{
					BingoGameState game_state = session_event.StepTo( game - 1 );
					//This begins a thread to do the playing and returns.
					session_event.BeginGame( game_state );
				}
				else
				{

				}
			}
		}


	}
}
