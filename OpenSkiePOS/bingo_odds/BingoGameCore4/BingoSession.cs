using System;
//using bingo_odds.CardMaster;
using System.Data;
using System.Windows.Forms;
using OpenSkieScheduler3;
using xperdex.classes;

namespace BingoGameCore4
{
	public class BingoSession
	{
		public ScheduleDataSet schedule;

		/// <summary>
		/// the name of this session
		/// </summary>
		public String session_name;

		/// <summary>
		/// the date that the session is meant for.
		/// </summary>
		internal DateTime bingoday;

		/// <summary>
		/// this is the session number on the day in question.
		/// </summary>
		internal int session;

		/// <summary>
		/// Defines the list of groups of games, a pack plays in all games in a group (pack_type_list?)
		/// </summary>
		public BingoGameGroupList GameGroups
		{
			get
			{
				return GameList.game_group_list;
			}
		}

		/// <summary>
		/// the list of games this session uses.
		/// </summary>
		public BingoGameList GameList;

		/// <summary>
		/// maximum balls used for this bingo session.  Default to 75.  Might someday be 90?
		/// </summary>
		public int max_balls;

		/// <summary>
		/// This is the representative row of this session from session_info in schedule dataset.
		/// </summary>
		public DataRow dataRowSession;

		void DefaultCharacteristics()
		{
			session_name = "Session";
			bingoday = DateTime.Now;
			session = 1;
			max_balls = 75;
		}

		public BingoSession()
		{
			DefaultCharacteristics();
		}



		/// <summary>
		/// this specifically creates a BingoSession appropriate for RateRank application.
		/// </summary>
		/// <param name="schedule">OpenSkieSchedule.ScheduleDataset</param>
		/// <param name="bingoday">day to load</param>
		/// <param name="session_number">session number on that day to load</param>
		public BingoSession( ScheduleDataSet schedule, DateTime bingoday, int session_number )
		{
			// this retains '75' as max_balls.
			DefaultCharacteristics();

			BingoDealers.LoadDealers( schedule.packs );

			this.dataRowSession = schedule.GetSession( bingoday, session_number );
			if( this.dataRowSession == null )
			{
				MessageBox.Show( "Could not find session " + session_number + " scheduled on " + bingoday.ToShortDateString() );
				throw new Exception( "Session Creation Failed" );
			}
			else
			{
				this.schedule = schedule;
				this.bingoday = bingoday;
				this.session = session_number;
				this.session_name = this.dataRowSession.ItemArray[ 7 ].ToString();

				this.GameList = new BingoGameList( this );
			}
		}



		/// <summary>
		/// Creates a fully populated session object
		/// </summary>
		/// <param name="bingoday"></param>
		/// <param name="session">DataRow from session_info table in OpenSkieScheduler</param>
		public BingoSession( DataRow session )
		{
			// this retains '75' as max_balls.
			DefaultCharacteristics();

			this.schedule = session.Table.DataSet as ScheduleDataSet;
			BingoDealers.LoadDealers( schedule.packs );

			this.dataRowSession = session;

			this.session_name = session[SessionTable.NameColumn].ToString();
			this.bingoday = DateTime.Now;
			this.session = 1;

			this.GameList = new BingoGameList( this );

		}


		/// <summary>
		/// this specifically creates a BingoSession appropriate for RateRank application.
		/// </summary>
		/// <param name="schedule">OpenSkieSchedule.ScheduleDataset</param>
		/// <param name="bingoday">day to load</param>
		/// <param name="session_number">session number on that day to load</param>
		public BingoSession( DsnConnection schedule_dsn, DateTime bingoday, int session_number )
		{
			this.schedule = new ScheduleDataSet( schedule_dsn, bingoday, session );
		}

		public BingoSession( BingoGameList gamelist )
		{
			
			DefaultCharacteristics();
			this.GameList = gamelist;
			
			// need games before players, assigning players updates total cards played.
			//this.PlayerList = players;
		}

		~BingoSession()
		{
			//db.Dispose();
		}


		public delegate void OnStatusUpdate( String s );
		public event OnStatusUpdate StatusUpdate;

		//internal Control status_update;
        //delegate void SetTextCallback(string text);

		internal void UpdateStatus( string textToWrite )
		{
			Log.log( textToWrite, 1 );
			if( StatusUpdate != null )
				StatusUpdate( textToWrite );
		}


	}



}
