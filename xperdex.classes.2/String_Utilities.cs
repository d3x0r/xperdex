using System;

namespace xperdex.classes
{
    public static class String_Utilities
    {
        public static int CountWords(string StringObject, String StringDelimiter)
        {
            int startPos = 0;
            int foundPos = -1;
            int WC = 0;

            StringObject.ToUpper();
            StringDelimiter.ToUpper();

            //Check to make sure we have valid StringObject and StringDelimiter
            if (StringObject.Length > 0 && StringDelimiter.Length > 0)
            {
                do
                {
                    foundPos = StringObject.IndexOf(StringDelimiter, startPos);
                    if (foundPos > -1)
                    {
                        startPos = foundPos + 1;
                        WC++;
                    }

                } while (foundPos > -1 && startPos < StringObject.Length);

                //Check to see if the string starts with a delimiter
                if (StringObject.StartsWith(StringDelimiter))
                {
                    WC--;
                }

                //Check to see if the string ends with a delimiter
                if (StringObject.EndsWith(StringDelimiter))
                {
                    WC--;
                }

                //We are counting delimiters, so add 1 to represent the number of words found
                if (WC != 0)
                {
                    WC += 1;
                }
            }
            else
            {
                WC = 0;
            }

            return WC;
        }

        public static string GetWord(string StringObject, string StringDelimiter, int Indx)
        {
            int WC = 0;
            int Count = 0;
            int StartPosition = 0;
            int EndPosition = 0;
            string RetString = null;
            int DelimeterSize = 0;

            WC = CountWords(StringObject, StringDelimiter);
            if (Indx < 1 || Indx > WC)
            {
                RetString = null;
            }
            else
            {
                DelimeterSize = StringDelimiter.Length;

                if (StringObject.StartsWith(StringDelimiter))
                {
                    StartPosition = DelimeterSize;
                }
                else
                {
                    StartPosition = 0;
                }

                for (Count = 1; Count < Indx; Count++)
                {
                    StartPosition = StringObject.IndexOf(StringDelimiter, StartPosition) + DelimeterSize;
                }

                EndPosition = StringObject.IndexOf(StringDelimiter, StartPosition);

                if (EndPosition == 0 || EndPosition == -1)
                {
                    EndPosition = StringObject.Length;
                }

                RetString = StringObject.Substring(StartPosition, EndPosition - StartPosition);
            }
            return RetString;
        }

        public static bool GetBooleanValue(string StringObject)
        {
            bool RetVal = false;

            StringObject.ToUpper();
            switch (StringObject)
            {
                //Values that represent TRUE
                case "ON":
                case "+":
                case "1":
                case "YES":
                case "Y":
                case "TRUE":
                case "TURE":
                    RetVal = true;
                    break;

                //Values that represent FALSE
                case "OFF":
                case "-":
                case "0":
                case "2":
                case "-1":
                case "NO":
                case "FALSE":
                case "FLASE":
                    RetVal = false;
                    break;
            }
            return RetVal;
        }

        public static bool CanConvert(TypeCode aTypeCode, string theString)
        {
            bool retVal;
            try
            {
                Convert.ChangeType(theString, aTypeCode);
                retVal = true;
            }
            catch
            {
                retVal = false;
            }

            return retVal;
        }

        public static string AddSlashes(string p_path)
        {
            for (int i = 0; i < p_path.Length; i++)
            {
                if (p_path[i] == '\\')
                {
                    p_path = p_path.Substring(0, i + 1) + p_path.Substring(i, p_path.Length - i);
                    i++;
                }
            }
            return p_path;
        }

		/// <summary>
		/// Builds a range condition including session and bingoday... if there is a session, splits the condition into 3 or parts.
		/// </summary>
		/// <param name="prefix">if null, no prefix, else prefix.bingoday and prefix.session used</param>
		/// <param name="date_in_week">some day of play... the week that contains this day</param>
		/// <param name="session_in_day">session on day in week</param>
		/// <param name="day_of_week_boundry">the day of week that the week starts</param>
		/// <param name="session_boundry">the session number that starts... 0 for starts on that day.</param>
		/// <returns></returns>
		public static string BuildSessionRangeCondition(String prefix
			, DateTime date_in_week, int session_in_day
			, int day_of_week_boundry, int session_boundry
			, out DateTime start_date, out DateTime end_date)
		{
			//StartingDay = date_in_week.AddDays( -( ( Convert.ToInt32( date_in_week.DayOfWeek ) + day_of_week_boundry ) - 1 ) % 7 );
			//StartingDay = date_in_week.AddDays( -( ( Convert.ToInt32( date_in_week.DayOfWeek ) + day_of_week_boundry ) ) % 7 );
			int days;
			bool monthly;
			if( Options.Default["Bingo Game Core"]["Defaults"]["Month span", 1].Integer != 0 )
			{
				monthly = true;
				days = DateTime.DaysInMonth( date_in_week.Year, date_in_week.Month );
				// if there's a session boundry, and the session is at or above it
				// then if the date is the last day of month, then really we're counting 
				// next month's days
				if( session_boundry > 0 )
				{
					if( session_in_day >= session_boundry )
					{
						if( date_in_week.Day == DateTime.DaysInMonth( date_in_week.Year, date_in_week.Month ) )
						{
							days = DateTime.DaysInMonth( date_in_week.Year, date_in_week.Month + 1 );
						}
					}
				}
			}
			else
			{
				monthly = false;
				days = Options.Default["Bingo Game Core"]["Defaults"]["Days To Span", "7"].Integer;
			}

			if( session_boundry == 0 )
			{
				DateTime StartingDay;
				if( monthly )
					StartingDay = date_in_week.AddDays( -( date_in_week.Day - 1 ) );
				else
					StartingDay = date_in_week.AddDays( -( ( Convert.ToInt32( date_in_week.DayOfWeek ) + days - day_of_week_boundry ) % 7 ) );

				DateTime EndingDay = StartingDay.AddDays( days - 1 );
				start_date = StartingDay;
				end_date = EndingDay;
				return "(" + prefix + ( prefix == null ? "" : "." ) + "bingoday between " + StartingDay.ToString( "yyyyMMdd" ) + " and " + EndingDay.ToString( "yyyyMMdd" ) + ")";
			}
			else
			{
				DateTime StartingDay;
				DateTime EndingDay;
				if( monthly )
				{
					StartingDay = date_in_week.AddDays( -( date_in_week.Day ) );
					// when we started, the boundry was recorded wrong...
					if( StartingDay.Month == 6 && StartingDay.Day == 30 && StartingDay.Year == 2009 )
					{
						StartingDay = StartingDay.AddDays( 1 );
						EndingDay = StartingDay.AddDays( days - 1 );
					}
					else
						EndingDay = StartingDay.AddDays( days );
				}
				else
				{
					StartingDay = date_in_week.AddDays( -( ( Convert.ToInt32( date_in_week.DayOfWeek ) + days - day_of_week_boundry ) % 7 ) );
					if( StartingDay == date_in_week )
					{
						StartingDay = StartingDay.AddDays( -days );
					}
					EndingDay = StartingDay.AddDays( days );
				}


				if( EndingDay == date_in_week )
				{
					if( session_in_day >= session_boundry )
					{
						// prior week
						if( !monthly )
						{
							StartingDay = EndingDay;
							EndingDay = StartingDay.AddDays( days );
						}
					}
					else
					{
						// this week.
					}
				}
				if( StartingDay == date_in_week )
				{
					if( session_in_day < session_boundry )
					{
						// prior week
						if( !monthly )
						{
							EndingDay = StartingDay;
							StartingDay = EndingDay.AddDays( -days );
						}
					}
					else
					{
						// this week.
					}
				}


				String s = "((" + prefix + ( prefix == null ? "" : "." ) + "bingoday=" + StartingDay.ToString( "yyyyMMdd" ) + " and " + prefix + ( prefix == null ? "" : "." ) + "session>=" + session_boundry + ")"
					+ " or (" + prefix + ( prefix == null ? "" : "." ) + "bingoday between " + StartingDay.AddDays( 1 ).ToString( "yyyyMMdd" ) + " and " + EndingDay.AddDays( -1 ).ToString( "yyyyMMdd" ) + ")"
					+ " or (" + prefix + ( prefix == null ? "" : "." ) + "bingoday=" + EndingDay.ToString( "yyyyMMdd" ) + " and " + prefix + ( prefix == null ? "" : "." ) + "session<" + session_boundry + "))"
				;
				start_date = StartingDay;
				end_date = EndingDay;
				return s;
			}
		}

		public static string BuildSessionRangeCondition( String prefix, DateTime date_in_week, int day_of_week_boundry, int session_boundry )
		{
			DateTime tmp1, tmp2;
			return BuildSessionRangeCondition( prefix, date_in_week, 0, day_of_week_boundry, session_boundry, out tmp1, out tmp2 );
		}

		//static bool week_configured;
		static int StartDayOfWeek= Options.Default["Bingo Game Core"]["Defaults"]["Day Of week rank start", "3"].Integer;
		static int StartSession = Options.Default["Bingo Game Core"]["Defaults"]["Session rank start", "5"].Integer;
		public static string BuildSessionRangeCondition( String prefix, DateTime date_in_week, int session
			, out DateTime start_day, out DateTime end_day )
		{
			//if( !week_configured )
			{
				//StartDayOfWeek = Options.Default["Bingo Game Core"]["Defaults"]["Day Of week rank start", "3"].Integer;
				//StartSession = Options.Default["Bingo Game Core"]["Defaults"]["Session rank start", "5"].Integer;
				//week_configured = true;
			}
			return BuildSessionRangeCondition( prefix, date_in_week, session, StartDayOfWeek, StartSession, out start_day, out end_day );
		}

		public static string BuildSessionRangeCondition( String prefix, DateTime date_in_week, int session )
		{
			DateTime tmp1, tmp2;
			return BuildSessionRangeCondition( prefix, date_in_week, session, out tmp1, out tmp2 );
		}
	}
}
