using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Windows.Forms;
using OpenSkieScheduler3.BingoGameDefs;
using xperdex.classes;

namespace BingoGameCore4.CardMaster
{
	public class CardReader : CardData
	{
		const bool offsetByOne = false;  // used if cardset data is 0-E instead of 1-F

		public static CardData GetCardReader( DataRow dataRowCardsetRange )
		{
			/// dataRowCardsetRange[OpenSkieScheduler.BingoGameDefs.CardsetRange.NameColumn].ToString();
			DataRow dataRowCardset = dataRowCardsetRange.GetParentRow( "cardset_has_cardset_range" );

			//OpenSkieScheduler.BingoGameDefs.CardsetInfo.NameColumn  (friendly name)
			String find_name = dataRowCardset["name"].ToString();
			//foreach( CardData reader in readers )
			{
				//if( reader.file_name == find_name )
					//return reader;
			}
			if( find_name == "" )
			{
				CardData tmp = new CardFactory();
				readers.Add( tmp );
				return tmp;
			}
			CardData result = new CardReader( dataRowCardsetRange );
			readers.Add( result );
			return result;
		}

		static List<CardData> readers = new List<CardData>();
		bool random_generator;
		byte[, ,] card_stock;
		bool big3;
		int prior_card;
		CardFactory cf;

		String Name;
        public override string ToString()
        {
            return Name;
        }
		string FileName;

		FileStream fs;
		BinaryReader br;
        int offset; // what starting card is card '1' err 0?

		public static CardReader GetCardReader( string name, bool big3 )
		{
			foreach( CardReader reader in readers )
			{
				if( reader.Name == name )
					return reader;
			}
			return new CardReader( name, big3 );
		}

		void ValidateLoadCard( int card )
		{
			lock( card_stock )
			{
				if( big3 )
				{
					if( card >= card_stock.GetLength( 0 ) )
					{
						Log.log( "Failed to get card from cardset - " + Name + "card:" + card );
						return;
					}
					if( card_stock[card, 0, 0] == 0 )
					{
						int x = 0;
						br.BaseStream.Seek( 3 * ( card ), SeekOrigin.Begin );
						byte[] input = br.ReadBytes( 3 );
						for( int col = 0; col < 1; col++ )
							for( int row = 0; row < 3; row++ )
							{
								card_stock[card, col, row] = (byte)( ( input[x] ) );
								x++;
							}
					}
				}
				else
				{
                    card -= offset;

					if( card >= card_stock.GetLength( 0 ) )
					{
						Log.log( "Failed to get card from cardset - " + Name + "card:" + card );
						return;
					}
					if( card_stock[card, 0, 0] == 0 )
					{
						int x = 0;
						br.BaseStream.Seek( 12 * ( card + offset ), SeekOrigin.Begin );
						byte[] input = br.ReadBytes( 12 );
						for( int col = 0; col < 5; col++ )
							for( int row = 0; row < 5; row++ )
							{
								if( row == 2 && col == 2 )
									continue;
								card_stock[card, col, row] = (byte)( ( input[x / 2] >> ( ( ( x & 1 ) != 0 ) ? 0 : 4 ) & 0xF ) + (offsetByOne?1:0) + ( 15 * col ) );
								x++;
							}
					}
				}
			}
		}

		string SwapPath( string original, string newpath )
		{
			int a = original.LastIndexOfAny( new char[]{'/','\\'} );
			return newpath + "/" + original.Substring( a + 1 );
		}

        public CardReader( DataRow dataRowCardsetRange )
        {
			DataTable ranges = dataRowCardsetRange.Table;
			bool double_action = (dataRowCardsetRange["double_action"]==DBNull.Value)?false:Convert.ToBoolean( dataRowCardsetRange["double_action"] );
			OpenSkieScheduler3.ScheduleDataSet schedule = ranges.DataSet as OpenSkieScheduler3.ScheduleDataSet;
			DataRow Cardset = dataRowCardsetRange.GetParentRow( CardsetRange.CardsetInfoRelationName );
			String default_cardset_path = Options.File( "cardset_files.ini" )["CONFIG"]["Default Cardset Path", "f:\\ftn3000\\data\\cards" ].Value;
            readers.Add( this );
            this.Name = dataRowCardsetRange[OpenSkieScheduler3.BingoGameDefs.CardsetRange.NameColumn].ToString();
			this.FileName = Cardset["name"] as String;
            cf = new CardFactory();
			if( !System.IO.File.Exists( FileName ) )
			{
				FileName = SwapPath( FileName, default_cardset_path );
				if( !System.IO.File.Exists( FileName ) )
				{
					if( FileName == "" )
					{
						return;
					}
					else
					{
						MessageBox.Show( "Cardset " + FileName + " does not exist." );
					}
					throw new Exception( "File not found" );
				}
			}
            {
				fs = new FileStream( FileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite );
                br = new BinaryReader( fs );
				if( double_action )
					card_stock = new byte[ ( Convert.ToInt32( dataRowCardsetRange["end"] )
						- ( offset = ( Convert.ToInt32( dataRowCardsetRange["start"] ) - 1 ) ) ) * 2
						, 5, 5];
				else
					card_stock = new byte[ ( Convert.ToInt32( dataRowCardsetRange["end"] )
						- ( offset = ( Convert.ToInt32( dataRowCardsetRange["start"] ) - 1 ) ) ) 
						, 5, 5];
				offset += (Int32)dataRowCardsetRange["offset"];
            }
        }

		public CardReader( String filename )
		{
			readers.Add( this );
			this.Name = filename;
			cf = new CardFactory();
			if( System.IO.File.Exists( filename ) )
			{
				fs = new FileStream( filename, FileMode.Open, FileAccess.Read, FileShare.ReadWrite );
				br = new BinaryReader( fs );
				card_stock = new byte[fs.Length / 12, 5, 5];
				// cards are delay read now... on request, checked if null, position seeked and read.
			}
			else
				throw new FileNotFoundException( "Card File Not Found", filename );
		}

		public CardReader( String filename, bool big3 )
		{
			readers.Add( this );
			this.Name = filename;
			cf = new CardFactory();
			if( System.IO.File.Exists( filename ) )
			{
				fs = new FileStream( filename, FileMode.Open, FileAccess.Read, FileShare.ReadWrite );
				br = new BinaryReader( fs );
				this.big3 = big3;
				if( big3 )
					// faces, columns, rows
					card_stock = new byte[fs.Length / 3, 1, 3];
				else
					// faces, columns, rows
					card_stock = new byte[fs.Length / 12, 5, 5];
				// cards are delay read now... on request, checked if null, position seeked and read.
			}
			else
				throw new FileNotFoundException( "Card File Not Found", filename );
		}


		~CardReader()
		{
			if( br != null )
				br.Close();
		}

		/// <summary>
		/// Returns the number of cards in this cardfile
		/// </summary>
		public int Length { get { return card_stock!= null?card_stock.GetLength( 0 ):0; } }

		public byte[] Create5Card()
		{
			return cf.Create5Card();
		}

		void DumpFace( int face )
		{
			for( int col = 0; col < 5; col++ )
				for( int row = 0; row < 5; row++ )
				{
					xperdex.classes.Log.log( card_stock[face, col, row].ToString() );
				}
		}

		byte[, ,] CardData.Create( int starting_card, int faces, bool starburst )
		{
			byte[, ,] card;
			if( big3 )
			{
				card = new byte[faces, 1, 3];
				for( int face = 0; face < faces; face++ )
				{
					ValidateLoadCard( starting_card * faces + face );
					for( int col = 0; col < 1; col++ )
						for( int row = 0; row < 3; row++ )
							card[face, col, row] = card_stock[starting_card * faces + face, col, row];
				}
			}
			else
			{
				card = new byte[faces, 5, 5];
				//int card_number = dealer.GetPhysicalNext( starting_card, card_offset );
				for( int face = 0; face < faces; face++ )
				{
					ValidateLoadCard( starting_card * faces + face );
					for( int col = 0; col < 5; col++ )
						for( int row = 0; row < 5; row++ )
						{
							card[face, col, row] = card_stock[(starting_card-offset) * faces + face, col, row];
						}
				}
			}
			return card;
		}

		public byte[, ,] Create( int faces, bool starburst )
		{
			return this.Create( prior_card, faces, 50, 0, card_stock.GetLength(0), starburst );
		}

		byte[, ,] Create( int starting, int faces, int skip, int minrange, int maxrange, bool starburst )
		{
			byte[, ,] card = big3?new byte[faces,3,1]:new byte[faces, 5, 5];
			int cardnum = prior_card;
			for( int face = 0; face < faces; face++ )
			{
				ValidateLoadCard( cardnum * faces + face );
				for( int col = 0; col < (big3?1:5); col++ )
					for( int row = 0; row < (big3?3:5); row++ )
					{
						card[face, col, row] = card_stock[cardnum * faces + face, col, row];
					}
			}
			//.WriteLine( "card is " + prior_card );
			prior_card += skip;
			if( prior_card >= maxrange )
			{
				prior_card -= (maxrange-minrange);
				prior_card++;
				// 
				prior_card -= 4;
				if( prior_card < minrange )
					prior_card += skip;
				Console.WriteLine( "Card wrap to " + prior_card );
			}
			return card;
		}
		byte[, ,] CardData.Create( int starting, int faces, int skip, int minrange, int maxrange, bool starburst )
		{
			return Create( starting, faces, skip, minrange, maxrange, starburst );
		}



		string CardData.file_name
		{
			get { return FileName; }
		}
		string CardData.name
		{
			get { return Name; }
		}
	}
}
