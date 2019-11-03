using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using xperdex.classes;
using System.Data.Common;
using System.Threading;
using OpenSkieScheduler3;
using BingoGameCore4.BallData;

namespace BingoSaleManager
{
	static class SalesManager
	{
		static DateTime bingoday;
		static int session_number;

		static Thread session_sales_monitor;

		static DsnConnection session_sales_monitor_dsn;

		static ScheduleDataSet schedule;

		static BingoGameCore4.BingoSession bingo_session;
		static BingoGameCore4.BingoSessionEvent session_event;

		static FlashdriveController ball_device;


		static SalesManager()
		{
		}

		internal static void Start()
		{
			ball_device = new FlashdriveController();

			session_sales_monitor_dsn = new DsnConnection( StaticDsnConnection.dsn.DataSource );
			session_sales_monitor = new Thread( MonitorSalesSession );
			session_sales_monitor.Start();
		}

		static void MonitorSalesSession()
		{
			while( true )
			{
				DbDataReader reader = session_sales_monitor_dsn.KindExecuteReader( 
					"SELECT session_order,bingoday FROM session_day_sessions where open_for_sales_flag=1" 
					);
//				DbDataReader reader = session_sales_monitor_dsn.KindExecuteReader( "SELECT session_number,bingoday FROM operational_configuration"
					//+ " join session_day_sessions"
					//+ " on current_session_day_sessions_id=session_day_sessions.ID " );
				if( reader != null && reader.HasRows )
				{
					int new_session;
					DateTime new_bingoday;
					reader.Read();
					new_session = reader.GetInt32( 0 );
					new_bingoday = reader.GetDateTime( 1 );
					if( new_session != session_number || new_bingoday != bingoday )
					{
						session_number = new_session;
						bingoday = new_bingoday;

						schedule = new ScheduleDataSet( session_sales_monitor_dsn, bingoday, session_number );
						bingo_session = new BingoGameCore4.BingoSession( schedule.sessions.Rows[0] );
						session_event = new BingoGameCore4.BingoSessionEvent( bingo_session, true );

						session_event.ball_data = ball_device;

					}
				}
				session_sales_monitor_dsn.EndReader( reader );
				Thread.Sleep( 2000 );
			}
		}
	}
}
