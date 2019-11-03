using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using BingoGameCore4.CardMaster;
using OpenSkieScheduler3;
using OpenSkieScheduler3.BingoGameDefs;
using xperdex.classes;

namespace BingoGameCore4
{
	public class BingoDealer
	{
		public string Name
		{
			get
			{
				return CardsetName + ":" + RangeName + ":" + DealerName;
			}
		}
		public string CardsetName;
		public string RangeName;
		public string DealerName;

		public bool superstack_page_algorithm; // account for game skip as a pack rotation skip by 50
		public int min_range;  // start of the range;
		public int max_range;  // end of the range
		public int real_min_range;  // start of the range (with base applied)
		public int real_max_range;  // end of the range (with base applied)
		//public BingoCardset cardset;
		public bool group_wrap_games;// whether to use card_skip to wrap when dealing with game_skip
		public int packs_db_base; // this shouldn't have been used, but apparently cards written to access_db_packs are wrong.

		// these are really per-dealer (err cardset-range)
		public int card_skip;
		public int game_skip;
		public int row_skip;
		public int column_skip;
		public int card_offset; // added to number read from file...

		public int last_dealt = 0;
		public object prize_level_id;
		public int upick_size;
		//internal int pack;

		public CardMaster.CardData card_data;
		
		public BingoDealer( String name )
		{
			CardsetName = "No Cardset";
			DealerName = name;
			RangeName = "Internal";
			card_skip = 50;
			game_skip = 1;
			min_range = 1;
			// 1 billion maximum cards?
			max_range = 400000;
			card_data = new CardMaster.CardFactory();
			last_dealt = min_range;
			//cardset = card_set;
		}

		public BingoDealer( String name, int upick_size )
		{
			CardsetName = "No Cardset";
			DealerName = name;
			RangeName = "Internal";
			card_skip = 50;
			game_skip = 1;
			min_range = 1;
			// 1 billion maximum cards?
			max_range = 400000;
			this.upick_size = upick_size;
			card_data = new CardMaster.UPickFactory( upick_size );
			last_dealt = min_range;
			//cardset = card_set;
		}

		internal BingoDealer( DataRow range )
		{
			DataTable ranges = range.Table;
			OpenSkieScheduler3.ScheduleDataSet schedule = ranges.DataSet as OpenSkieScheduler3.ScheduleDataSet;
			DataRow cardset_row = range.GetParentRow( CardsetRange.CardsetInfoRelationName );
			DataRow dealer_row = range.GetParentRow( CardsetRange.DealerRelationName );

			if( cardset_row["name"] != DBNull.Value && cardset_row["name"] != "" )
				card_data = CardReader.GetCardReader( range );
			else
				card_data = CardSQLReader.GetCardReader( range );

			//BingoCardset bingo_cardset = null;
			DataRow cardset = range.GetParentRow( "cardset_has_cardset_range" );

			DataRow dealerRow = range.GetParentRow( "cardset_range_has_dealer" );
			RangeName = range[CardsetRange.NameColumn] as String;
			CardsetName = cardset[CardsetInfo.NameColumn] as String;
			DealerName = dealerRow[Dealer.NameColumn] as String;

			prize_level_id = range[PrizeLevelNames.PrimaryKey];

			//pack = Convert.ToInt32( pack[PackTable.PrimaryKey] );
			min_range = Convert.ToInt32( range["start"] );
			max_range = Convert.ToInt32( range["end"] );
			object tmp_base = range["base"];
			if( tmp_base == DBNull.Value )
				packs_db_base = 0;
			else
				packs_db_base = Convert.ToInt32( tmp_base );
			//Name = range[CardsetRange.NameColumn].ToString();
			if( dealerRow != null )
			{
				card_skip = Convert.ToInt32( dealerRow["card_skip"] );
				game_skip = Convert.ToInt32( dealerRow["page_skip"] );
				row_skip = Convert.ToInt32( dealerRow["row_skip"] );
				column_skip = Convert.ToInt32( dealerRow["column_skip"] );
			}
			else
				Log.log( "cardset_range has no dealer... default dealer cardskip=" + card_skip + " gameskip=" + game_skip );
			//bingo_cardset.range_base = Convert.ToInt32( range["base"] );
			object tmp_offset = range["offset"];
			if( tmp_offset == DBNull.Value )
				card_offset = 0;
			else
				card_offset = Convert.ToInt32( tmp_offset );
			real_min_range = min_range + packs_db_base;
			real_max_range = max_range + packs_db_base;
			last_dealt = real_min_range;
			group_wrap_games = false;
			//cardset = bingo_cardset;

		}

		/// <summary>
		/// This is getting physical cards in cardfile to play
		/// the start number is the biased number from access_db_packs (as shown on unit and printed)
		/// </summary>
		/// <param name="start"></param>
		/// <param name="quantity"></param>
		/// <param name="game_offset"></param>
		/// <returns></returns>
		public int[] GetRealCardsFromFakeStart( int start, int quantity, int game_offset )
		{
			int[] result = new int[quantity];
			if( start < packs_db_base )
			{
				throw new Exception( "blah." );
			}
			start -= packs_db_base;
			for( int n = 0; n < quantity; n++ )
			{
				result[n] = start;
				if( card_skip == 0 )
				{
					
				}
				else
				{
					start += card_skip;
					if( start > max_range )
						start += min_range - max_range + game_offset;
				}
			}
			return result;
		}

		public int Add( int base_card, int offset )
		{
			if( ( base_card + offset ) >= real_max_range )
				return base_card + offset - ( real_max_range - real_min_range );
			return base_card + offset;
		}

		internal int GetNext( int starting_card, int row, int col, int card_count )
		{
			if( starting_card < packs_db_base )
			{
				throw new Exception( "blah." );
			}
			starting_card -= packs_db_base;

			if( card_skip == 0 )
			{
				//Log.log( "My Row is " + row + " col " + col );
				int skip = ( row * row_skip );
				//starting_card += ( row * row_skip ) + ( col * column_skip );
				//Log.log( "Setting card offset as " + skip + " from " + starting_card + " is now " + ( starting_card + skip ).ToString() );
				starting_card += skip;
				if( starting_card > max_range )
					starting_card += min_range - max_range;
				//Log.log( "(wrap)Setting card offset as " + skip + " from " + starting_card + " is now " + ( starting_card + skip ).ToString() );
			}
			else
				for( int n = 0; n < card_count; n++ )
				{
					starting_card += card_skip;
					if( starting_card > max_range )
						starting_card += min_range - max_range;
				}
			return starting_card + packs_db_base;

		}

		internal int GetPhysicalNext( int starting_card, int row, int col, int card_offset )
		{
			// physical card of card 1 is 0
			return ( GetNext( starting_card, row, col, card_offset ) - packs_db_base ) - 1 + this.card_offset;
		}


		
		internal int Deal( int row, int col, int card_count )
		{
			int result = last_dealt;
			last_dealt = GetNext( last_dealt, row, col, card_count );
			return result;
		}

	}

	//---------------------------------------------------------------------------------------------------------------
#if bingo_cardset_not_obsolete
	public class BingoCardset: List<BingoDealer>
	{
		public string Name;
		public CardMaster.CardData card_data;
		public object ID; // this will match the database ID... if we ever load it.
		static List<BingoCardset> cardsets;
		internal static BingoCardset GetCardset( string File, bool big3 )
		{
			foreach( BingoCardset cardset in cardsets )
			{
				if( cardset.Name == File )
					return cardset;
			}
			BingoCardset newcardset;
			cardsets.Add( newcardset = new BingoCardset( File, big3 );
			return newcardset;
		}
		internal BingoCardset( String file, bool big3 )
		{
			int try_count = 0;
			retry:
			try
			{
				card_data = CardMaster.CardReader.GetCardReader( file, big3 );
			}
			catch( FileNotFoundException e )
			{
				if( try_count >= 15 )
				{
					MessageBox.Show( "Failed to open card file [" + file + "]\nDefaulting to random card generation\nWait was 15 seconds..." );
					card_data = new CardMaster.CardFactory();
				}
				else
				{
					Log.log( "Failed to open cardfile ["+file+"], sleep one second, and retry..." );
					Thread.Sleep( 1000 );
					try_count++;
					goto retry;
				}
			}
		}
		internal BingoCardset()
		{
			card_data = new CardMaster.CardFactory();
		}


		internal BingoDealer GetDealer( string p )
		{
			foreach( BingoDealer dealer in this )
			{
				if( dealer.Name == p )
					return dealer;
			}
		//	BingoDealer new_dealer = new BingoDealer( this, p );
			this.Add( new_dealer );
			return new_dealer;
		}
	}
#endif
	//---------------------------------------------------------------------------------------------------------------

	public static class BingoDealers
	{
		static List<BingoDealer> dealers = new List<BingoDealer>();

		//static List<int> cardset_deals_from;

		public static BingoDealer CreateSimpleDealer()
		{
			BingoDealer dealer;
			if( dealers.Count == 0 )
			{
				dealers.Add( dealer = new BingoDealer( "Simple Dealer" ) );
				return dealer;
			}
			else
				return dealers[0];
		}

		public static BingoDealer CreateUpickDealer( int size )
		{
			BingoDealer dealer;
			foreach( BingoDealer check_dealer in dealers )
			{
				if( check_dealer.Name == "Upickem Dealer" && check_dealer.upick_size == size )
					return check_dealer;
			}
			//if( dealers.Contains( ) )
			dealers.Add( dealer = new BingoDealer( "Upickem Dealer", size ) );
			return dealer;
		}

		public static void LoadDealers( XDataTable<DataRow> packs )
		{
			// well, they could have changed, I guess re-cycling these is better...
			dealers.Clear();

			foreach( DataRow pack in packs.Rows )
			{
				DataRow[] pack_ranges = pack.GetChildRows( "pack_has_cardset_range" );
				foreach( DataRow pack_range in pack_ranges )
				{
					DataRow range = pack_range.GetParentRow( "cardset_range_in_pack" );
					GetDealer( range );
				}
			}
		}

		static BingoDealers( )
		{
#if use_legacy_config
			// 32 packs.  ( this should come from an ini option... but I don't know what it is right now.
			cardset_deals_from = new List<int>();

			xperdex.classes.INIFile mini_ini = xperdex.classes.INI.LegacyFile( "mini.ini" );

			xperdex.classes.INIFile ftnsys = xperdex.classes.INI.Default;//"c:/ftn3000/working/sams/caller/ftnsys.ini" );
			xperdex.classes.INIFile bingo = xperdex.classes.INI.File( xperdex.classes.INI.Default["DATA FILES"]["Cardset INI","c:/ftn3000/working/bingo.ini"] );
			//int sets = Convert.ToInt32( bingo["CARDS"]["Max Ranges"] );

			int pos_count = ftnsys["SYSTEM"]["POS Count","5"];
			int card_game_skip = ftnsys["CARDS"]["Game Step"];

			for( int pack = 1; pack <= 32; pack++ )
			{
				cardset_deals_from[pack - 1] = ftnsys["CARDS"]["pack " + pack + " deals from cardset","0"];

				//for( int set = 0; set < sets; set++ )
				{
					//String line = bingo["CARDS"]["set" + set];
					//String[] parts = line.Split( new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries );
					//if( parts[4].Substring( 0, 1 ).ToUpper() == "E" )
					{
						// expect a dealer set for this cardset...
						int cardset = cardset_deals_from[pack - 1];

						if( cardset_deals_from[pack - 1] >= dealers.Count )
						{
							int card_base = ftnsys["cardset " + cardset]["Card Base"];
							int card_base_old = mini_ini["CARDS"]["Base"];
							if( card_base_old != card_base && ( cardset_deals_from[pack-1] == 0 ) )
							{
								xperdex.classes.Log.log( "Notice, configuration error has happeend between ftnsys cardset 0 and mini.ini base." );
								//card_base = card_base_old;
							}
							int card_skip = ftnsys["cardset " + cardset]["Card Skip"];

							// voted nastiest line this month.
							String line = bingo["CARDS"]["SET"+ftnsys["cardset "+cardset]["bingo.ini card set"]];

							BingoCardset bingo_cardset;
							if( line != null )
							{
								xperdex.classes.Log.log( "set = " + line );
								String[] parts = line.Split( new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries );
								xperdex.classes.Log.log( "set = " + line );
								bingo_cardset = new BingoCardset( parts[1] );
							}	
							else
								bingo_cardset = new BingoCardset();


							bingo_cardset.card_skip = card_skip;
							bingo_cardset.game_skip = card_game_skip;
							bingo_cardset.range_base = card_base;
							bingo_cardset.card_offset = ftnsys["cardset " + cardset]["Eltanin Card Offset (CV2)"];

							dealers.Add( bingo_cardset );

							for( int pos = 0; pos < pos_count; pos++ )
							{
								String range = ftnsys["cardset " + cardset]["Range on POS " + (pos+1),"1,12000000"];
								String[] ranges = range.Split( new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries );
								Int32 min = Convert.ToInt32( ranges[0] );
								Int32 max = Convert.ToInt32( ranges[1] );
								BingoDealer dealer = new BingoDealer();
								dealer.min_range = min;
								dealer.max_range = max;
								dealer.packs_db_base = card_base_old;
								dealer.group_wrap_games = false;
								dealer.cardset = bingo_cardset;
								bingo_cardset.Add( dealer );
							}
						}
					}
				}

			}
#endif			/*
			[Cardset 1]

Card Base=200000
bingo.ini card set=1Dealer must deal in groups of=0Dealer garbage wrap at=41Card Skip=50Range on POS 1=1,8650Range on POS 2=8651,17300Range on POS 3=17301,25950Range on POS 4=25951,34600Range on POS 5=34601,43300Range on POS 6=43301,52000Eltanin Card Offset (CV2)=0			  */
		}

		public static BingoDealer nodealer = BingoDealers.CreateSimpleDealer();

		public static BingoDealer GetDealer( String range )
		{
			foreach( BingoDealer dealer in dealers )
			{
				if( dealer.RangeName == range )
					return dealer;
			}
			return null;

		}

        public static BingoDealer GetDealer( DataRow dataRowCardsetRange )
        {
			DataTable ranges = dataRowCardsetRange.Table;
			OpenSkieScheduler3.ScheduleDataSet schedule = ranges.DataSet as OpenSkieScheduler3.ScheduleDataSet;
			String RangeName = dataRowCardsetRange[CardsetRange.NameColumn] as String;
			DataRow cardset_row = dataRowCardsetRange.GetParentRow( CardsetRange.CardsetInfoRelationName );
			String CardsetName = cardset_row[CardsetInfo.NameColumn] as String;
			DataRow dealer_row = dataRowCardsetRange.GetParentRow( CardsetRange.DealerRelationName );
			if( dealer_row == null )
			{
				MessageBox.Show( "Cardset range [" + RangeName + "] does not have a dealer" );
				return null;
			}

			String DealerName = dealer_row[Dealer.NameColumn] as String;

			foreach( BingoDealer dealer in dealers )
			{
				if( dealer.CardsetName == CardsetName &&
					dealer.RangeName == RangeName &&
					dealer.DealerName == DealerName )
					return dealer;
			}

            //BingoCardset new_cardset = new BingoCardset();

            BingoDealer new_dealer = new BingoDealer( dataRowCardsetRange );
			dealers.Add( new_dealer );
            return new_dealer;
        }

        public static BingoDealer GetDealer( CardMaster.CardData cards, int card_skip, int page_skip )
        {
			return null;
#if asdfadfs
			foreach( BingoCardset dealer in dealers )
			{
                if( dealer.card_data == cards )
                {
                    foreach( BingoDealer d in dealer )
                    {
                        if( d.card_skip == card_skip && d.game_skip == page_skip )
                            return d;
                    }
                    BingoDealer new_dealer;
					new_dealer = new BingoDealer( dealer, "Internal " + card_skip.ToString() + ":" + page_skip.ToString() );
					//new_dealer.prize_level_id = null;
                    new_dealer.card_offset = 0;
                    new_dealer.card_skip = card_skip;
                    new_dealer.game_skip = page_skip;
                    dealer.Add( new_dealer );
                    return new_dealer;
                    //new_dealer.min_range = 
                }
            }

            BingoCardset cardset = new BingoCardset( );
            cardset.card_data = cards;
            dealers.Add( cardset );

            BingoDealer a_new_dealer;
            a_new_dealer = new BingoDealer( cardset, "Internal2 " + card_skip.ToString() + ":" + page_skip.ToString() );
            a_new_dealer.card_offset = 0;
            a_new_dealer.card_skip = card_skip;
            a_new_dealer.game_skip = page_skip;
            return a_new_dealer;
#endif
        }

		public static BingoDealer GetDealer( int start_card, int pack )
		{
			if( dealers == null )
			{
				MessageBox.Show( "BingoDealers did not have .Load invoked." );
				return nodealer;
			}
			foreach( BingoDealer d in dealers )
			{
				{
					//if( d.pack == pack )
					{
						int base_card = start_card - d.packs_db_base;
						if( base_card > 0 )
						{
							if( d.min_range <= base_card && d.max_range >= base_card )
								return d;
						}
					}
				}
			}
			return nodealer;
		}


		internal static void LoadDealers( PackTable packTable )
		{
			foreach( DataRow pack in packTable.Rows )
			{
				DataRow[] pack_ranges = pack.GetChildRows( "pack_has_cardset_range" );
				foreach( DataRow pack_range in pack_ranges )
				{
					DataRow cardset_range = pack_range.GetParentRow( "cardset_range_in_pack" );
					GetDealer( cardset_range );
				}
			}
			//throw new NotImplementedException();
		}
	}
}
