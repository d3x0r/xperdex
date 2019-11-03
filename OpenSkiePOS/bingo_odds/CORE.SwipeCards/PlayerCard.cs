using System;
using System.Collections.Generic;
using System.Text;

namespace CORE.SwipeCards
{
	public class PlayerCard
	{
		public string card;
		string _player_name;

		bool bScanMatched;
		internal static class config
		{
			internal static bool bPad = false;
			internal static List<string> formats;
			internal static int PadLength = 18;
			internal static string szPadChar = "0";
		}

		// this should be some sort of property that's loaded...

		void MATCHED(string format, ref int format_offset, int i, ref int first_match)
		{
			if( format_offset < format.Length ) 
				format_offset++; 
			if( first_match == 0 ) 
				first_match = i + 1;
		}


		void FilterMagStripe( String s )
		{
			StringBuilder sb = new StringBuilder();
			string oldcard = card;
			card = null;
			{
				// this is done when the read fails, therefore
				// we have gotten all available data and have built gszData buffer
				foreach( String format in config.formats )
				{
					int i;
					int format_offset = 0;
					//char[] output = new char[256];
					int outofs;
					bool escape = false;
					bool skip = false;
					int charcount = 0;
					int first_match = 0;
					sb.Length = 0;
					for( i = 0; ( ( charcount != 0 ) || ( format_offset < format.Length ) ) && i < s.Length; i++ )
					{
						//lprintf( WIDE("ReadCard %c(%d) %c(%d)"), format[format_offset], format[format_offset]
						//			 , s[i], s[i] );
						if( charcount != 0 )
						{
							if( !skip )
								sb.Append( s[i] );
							charcount--;
							if( charcount == 0 )
								skip = false;
						}
						else if( !escape && format[format_offset] == '-' )
						{
							skip = true;

							MATCHED(format, ref format_offset, i, ref first_match );
							i--;
						}
						else if( !escape && format[format_offset] == '+' )
						{
							while( format[++format_offset] != '+' )
							{
								sb.Append(  format[format_offset] );
							}
							i--; // recheck this character...
							MATCHED( format, ref format_offset, i, ref first_match );
						}
						else if( !escape && format[format_offset] >= '0' && format[format_offset] <= '9' )
						{
							while( format[format_offset] >= '0' && format[format_offset] <= '9' )
							{
								charcount *= 10;
								charcount += format[format_offset] - '0';
								MATCHED( format, ref format_offset, i, ref first_match );
							}
							if( format_offset < format.Length )
								MATCHED( format, ref format_offset, i, ref first_match );
							i--;
						}
						else if( !escape && format[format_offset] == '#' )
						{
							if( s[i] >= '0' && s[i] <= '9' )
							{
								if( !skip )
									sb.Append(  s[i] );
							}
							else
							{
								skip = false;
								MATCHED( format, ref format_offset, i, ref first_match );
								i--; // recheck actual character here...
							}
						}
						else if( !escape && format[format_offset] == '@' )
						{
							if( ( s[i] >= 'a' && s[i] <= 'z' )
								||( s[i] >= 'A' && s[i] <= 'Z' ) )
							{
								if( !skip )
									sb.Append(  s[i] );
							}
							else
							{
								skip = false;
								MATCHED( format, ref format_offset, i, ref first_match );
							}
						}
						else if( !escape && format[format_offset] == '*' )
						{
							if( ( s[i] >= '0' && s[i] <= '9' )
								||( s[i] >= 'a' && s[i] <= 'z' )
								||( s[i] >= 'A' && s[i] <= 'Z' ) )
							{
								if( !skip )
									sb.Append( s[i] );
							}
							else
							{
								skip = false;
								MATCHED( format, ref format_offset, i, ref first_match );
							}
						}
						else if( !escape && format[format_offset] == '\\' )
						{
							escape = true;
							MATCHED( format, ref format_offset, i, ref first_match );
							i--; // recheck actual character here...
						}
						else if( !escape && format[format_offset] == ' ' )
						{
							format_offset++;
							i--;
						}
						else if( format[format_offset] == s[i] )
						{
							escape = false;
							MATCHED(format, ref format_offset, i, ref first_match );
						}
						else // failed match.
						{
							if( first_match != 0 )
							{
								i = first_match - 1;
								first_match = 0;
								format_offset = 0;
							}
						}
					}
					if( format_offset == format.Length )
						bScanMatched = true;
					if( sb.Length == 0 )
					{
						sb.Length = 0;
						continue;
					}
					//output[outofs] = '\0';
					if( config.bPad )
					{
#if asdf
				Log3( WIDE("Building Pad: %d %c %s"), config.PadLength, config.szPadChar, output );
#endif
						int padlen = config.PadLength - sb.Length;
						for( i = 0; i < padlen; i++ )
						{
							sb.Insert( 0, config.szPadChar );
						}
						card = sb.ToString();
					}
					else
					{
						card = sb.ToString();
					}
				}
			}
			if( card == null )
				card = oldcard;
		}

		/// <summary>
		/// Set this to initialize the player from a cardswipe module ... just pass the raw buffer...
		/// </summary>
	
		public string MagStripe
		{
			set
			{
				_player_name = null;
				card = null;
				FilterMagStripe(value);
				
				//card = value;
				// if I have a way to lookup the ID...
			}


		}
		public string Card
		{
			set
			{
				card = value;
#if something_like_this_for_player_lookup
					if( g.flags.bScanMatched )
			{
				lprintf( WIDE("Calling findnamebinsearch with scanned card...%s"), g.szPlayerData );
				if (!FindNameBinSearch(g.szPlayerData, g.szPlayerName))
					g.szPlayerName[0]=0;
				// ecoupons will trigger an update - if scanned, or if
				// anyone gets a card... otherwise it will have cleared data
				// and name...
				if( !g.flags.bUseECoupons ||
				     g.flags.bCouponUsed )
				{
					UpdatePlayerName( NULL, NULL, 0, 0);
				}
			}
			else
			{
            ResetPlayerEx(0);
				output[outofs] = 0;
			}
		}
#endif
		_player_name = null;
				// if I have a way to lookup the ID...
			}


		}
		public string Name
		{
			get {
				if( _player_name != null )
					return _player_name;
				if( card != null )
					return card;
				return "No Player Scanned";
			}

		}

		public PlayerCard()
		{
			config.formats = new List<string>();
			config.formats.Add( ";#" );
			config.formats.Add( "%#" );
	
		}
		
		public void AddFormat(string CardFormat)
		{
			config.formats = new List<string>();
			string[] CardFormatArray = CardFormat.Split(',');
			foreach (string sp in CardFormatArray)
			{
				config.formats.Add(sp);
			}
		}
		
	}
}
	