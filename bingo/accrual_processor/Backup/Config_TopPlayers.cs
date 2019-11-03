using System;
using System.Collections.Generic;
using System.Text;
using xperdex.classes;

namespace CORE.TopPlayersSettings
{
    public class Config_TopPlayers
    {
		private CORE.Config.OptionTree myOptionTree;
		
        private int _StartingSession;
		private int _StartingDayOfWeek;
		private int _TopPlayersNumber;
		private int _BottomPlayersNumber;
		private int _DaysToClaim;
        
        #region Properties
		public int StartingSession
		{
			get { return _StartingSession; }
		}

		public int StartingDayOfWeek
		{
			get { return _StartingDayOfWeek; }
		}
		public int TopPlayersNumber
		{
			get { return _TopPlayersNumber; }
		}

		public int BottomPlayersNumber
		{
			get { return _BottomPlayersNumber; }
		}

		public int DaysToClaim
		{
			get { return _DaysToClaim; }
		}


        # endregion

		public Config_TopPlayers(DsnConnection odbc)
		{
			myOptionTree = new CORE.Config.OptionTree(odbc);

			_StartingSession =
				Convert.ToInt32(myOptionTree.GetSetValueOptionTree(
				"FTNSYS/BINGO/TOP PLAYERS/Start Session", "0",
				"Session Number to start."));

			_StartingDayOfWeek =
				Convert.ToInt32(myOptionTree.GetSetValueOptionTree(
				"FTNSYS/BINGO/TOP PLAYERS/Start Week Day", "4",
				"Week day to start. Monday = 1, Sunday = 7."));

			_TopPlayersNumber=
				Convert.ToInt32(myOptionTree.GetSetValueOptionTree(
				"FTNSYS/BINGO/TOP PLAYERS/Top Players Number", "20",
				"The Top # to Pay."));

			_BottomPlayersNumber =
				Convert.ToInt32(myOptionTree.GetSetValueOptionTree(
				"FTNSYS/BINGO/TOP PLAYERS/Bottom Players Number", "1",
				"The Bottom # to Pay."));

			_DaysToClaim =
				Convert.ToInt32(myOptionTree.GetSetValueOptionTree(
				"FTNSYS/BINGO/TOP PLAYERS/Days To Claim", "30",
				"The Maximum days to hold a Prizes to Pay."));


		}
    }
}
