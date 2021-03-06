using System;
using System.IO;
using System.Windows.Forms;

namespace xperdex.classes
{
	public static class Log
	{
		public static string LoggingRoot = Environment.GetFolderPath( Environment.SpecialFolder.CommonApplicationData );
		public static string ApplicationProducer = "Freedom Collective";
		public static string ApplicationName;
		static FileStream fs;
		static StreamWriter sw;
		static void BackupFile( String source, int namelen, int n )
		{
			String backup;
			if( System.IO.File.Exists( source ) )
				if( n < 10 )
				{
					BackupFile( ( backup = source.Substring( 0, namelen ) + n.ToString() ), namelen, n + 1 );
					System.IO.File.Move( source, backup );
				}
				else
					System.IO.File.Delete( source );

		}
		static void AutoBackup( string filename )
		{
			BackupFile( filename, filename.Length, 1 );
			//throw new Exception( "The method or operation is not implemented." );
		}
		static Log()
		{
			int retry = 1;
			int idx1 = Application.ExecutablePath.LastIndexOfAny( new char[] { '/', '\\' } );
			int idx2 = Application.ExecutablePath.LastIndexOfAny( new char[] { '.' } );
			if( ApplicationName == null )
				ApplicationName = Application.ExecutablePath.Substring( idx1 + 1, (idx2 - idx1) - 1 );
			//return;
			string logpath = LoggingRoot
							+ "/" + ApplicationProducer + "/"
							+ ApplicationName;
			if( !Directory.Exists( logpath ) )
				Directory.CreateDirectory( logpath );
			string logname = logpath + "/" + ApplicationName + ".Log";
			retry:
			try
			{
				
				AutoBackup( logname );
				fs = new FileStream( logname, FileMode.Create );
				sw = new StreamWriter( fs );
			}
			catch( IOException )
			{
				logname = Application.CommonAppDataPath 
							+ Application.ExecutablePath.Substring( idx1 ) + "-" + ( retry++ ) + ".Log";
				//Log.log( "In use, attempting new name..." + logname );
				goto retry;
			}
			LogToConsole = true || INI.Default["xperdex"]["Log to debug console", "0"].Integer != 0;
			LogToFile = false || INI.Default["xperdex"]["Log to debug file", "1"].Integer != 0;
            LogTimeDelta = INI.Default["xperdex"]["Log Time Delta", "0"].Integer != 0;
		}
		static DateTime then;

		static bool LogToConsole = true;
		static bool LogToFile = true;
        static bool LogTimeDelta = false;
	
		public static void log( string s, System.Diagnostics.StackFrame sf )
		{
			String time = "";
			String file = sf.GetFileName();
			if( file != null )
				file = file.Substring( file.LastIndexOf( "\\" ) + 1 );
			if( LogToFile )
				lock( sw )
				{
                    if (LogTimeDelta)
                    {
                        TimeSpan delta = DateTime.Now.Subtract(then);
                        sw.WriteLine((time = delta.ToString())
                            //DateTime.Now.ToString("hh.mm.ss.fff")
                            + "@" + file + "(" + sf.GetFileLineNumber() + "):" + s);
                        then = DateTime.Now;
                        sw.Flush();
                    }
                    else
                    {
                        sw.WriteLine((DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"))
                            + "@" + file + "(" + sf.GetFileLineNumber() + "):" + s);
                        sw.Flush();
                    }
				}

			if( LogToConsole )
			{
				System.Diagnostics.Debug.WriteLine(
					//Console.WriteLine( //"{0}{1}"
					 file + "(" + sf.GetFileLineNumber() + "):"
					+ s );
			}
			 
		}

        /// <summary>
        /// adds the given string as an entry in the log
        /// </summary>
        /// <param name="s"></param>
		public static void log( string s )
		{
			log( s, new System.Diagnostics.StackFrame( 1, true ) );
		}
		public static void log( string s, int frame_skip )
		{
			System.Diagnostics.StackFrame sf = new System.Diagnostics.StackFrame( 1 + frame_skip, true );
			int counter = 0;
			//while( sf.GetFileLineNumber() == 0 )
			{
				counter++;
				//sf = new System.Diagnostics.StackFrame( 1 + frame_skip + counter, true );
			}
			log( s, sf );
		}

        /// <summary>
        /// Adds a hex dump of the given string to the log.
        /// </summary>
        /// <param name="s"></param>
        public static void LogBinary(string s)
        {
            string sHex = "Hex breakdown of "+s.Length.ToString()+" byte(s):", sDisp = "";
            byte charAsByte = 0;

            for (int n = 0; n < s.Length; n++)
            {
                if (n % 16 == 0)
                {
                    sHex += "   " + sDisp;
                    sDisp = "";

                    sHex += "\r\n\t\t";
                }

                charAsByte = Convert.ToByte(s[n]);

                sHex += charAsByte.ToString("X2")+" ";

                if (charAsByte < ' ' || charAsByte > '~')
                    sDisp += '.';
                else
                    sDisp += s[n];
            }

            if (sDisp != "")
            {
                for (int x = s.Length % 16; x < 16; x++)
                    sHex += "   ";

                sHex += "   " + sDisp;
            }

            System.Diagnostics.StackFrame sf = new System.Diagnostics.StackFrame(1, true);
            log(sHex, sf);
        }

        /// <summary>
        /// Adds a hex dump of the given byte array to the log.
        /// </summary>
        /// <param name="byteArray"></param>
        public static void LogBinary(byte[] byteArray)
        {
            string sHex = "Hex breakdown of " + byteArray.GetLength(0).ToString() + " byte(s):", sDisp = "";

            for (int n = 0; n < byteArray.GetLength(0); n++)
            {
                if (n % 16 == 0)
                {
                    sHex += "   " + sDisp;
                    sDisp = "";

                    sHex += "\r\n\t\t";
                }

                sHex += byteArray[n].ToString("X2") + " ";

                if (byteArray[n] < ' ' || byteArray[n] > '~')
                    sDisp += '.';
                else
                    sDisp += (char) byteArray[n];
            }

            if (sDisp != "")
            {
                for (int x = byteArray.GetLength(0) % 16; x < 16; x++)
                    sHex += "   ";

                sHex += "   " + sDisp;
            }

            System.Diagnostics.StackFrame sf = new System.Diagnostics.StackFrame(1, true);
            log(sHex, sf);
        }
    }
}
