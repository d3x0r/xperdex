using System;
using BingoGameInterfaces;

namespace BingoGameCore4.CardMaster
{

	public interface CardData
	{
		byte[, ,] Create( int starting_card, int faces, bool starburst );
		byte[, ,] Create( int starting, int faces, int skip, int minrange, int maxrange, bool starburst );
		String name { get; }
		String file_name { get; }
	}

	public class CardFactory : CardData
	{
		static Random entropy = null;
		BallDataInterface bdi;
		int[] nums;

		public CardFactory()
		{
			bdi = new BallData_Random75();
   			entropy = new Random();
			nums = bdi.CallBalls();
		}

		public CardFactory( int balls )
		{
			bdi = new BallData_Random75( balls );
            entropy = new Random();
			nums = bdi.CallBalls();
		}


		//
		// result should refer to an array [sets][toget]
		//  result should refer to an array [sets][cols][rows]
		void GetNofMEx( int sets, int toget, int fromset, int[] counts, byte[] result )
		{
			int n;
			int[] found = new int[5];
			int[] found_base = new int[5];
			; // generate new random sequence
			//byte[] called_nums = bdi.CallBalls();
			//int set;
			//for( set = 0; set < sets; set++ )
			{
				for( n = 0; n < 5; n++ )
				{
					found_base[n] = counts[n];
					//found_base[n] = ( ( n == 2 ) ? 4 : 5 );
					found[n] = 0;
				}
				for( n = 0; n < nums.Length; n++ )
				{
					int col = ( nums[n] - 1 ) / 15;
					int row_offset = found[col] / found_base[col];
					//if( found[col] >= found_base[col] )
					//{
			//			continue;
			//		}
					if( row_offset >= sets )// N's can overflow...
						continue;
					if( col > 4 )
					{
						//DebugBreak();
						continue; // out of range of bingo balls for some reason
					}
						result[( row_offset * toget ) 
							+ ( col * counts[0] )
							+ ( ( col > 2 ) ? ( counts[2] - counts[1] ) : 0 ) 
							+ ( found[col]++ ) 
							- ( row_offset * found_base[col] )] = (byte)(nums[n]);
					//printf( "%d ", nums[n] );
				}
				//printf( "\n " );
			}
		}


		void GetNofM( int toget, int fromset, byte[] result )
		{
			int[] counts = { 5, 5, 4, 5, 5 };
			GetNofMEx( 1, toget, fromset, counts, result );
		}



		void Get24of75Ex( int sets, byte[] result )
		{
			int[] counts = { 5, 5, 4, 5, 5 };
			GetNofMEx( sets, 24, 75, counts, result );
		}

		void Get24of75( byte[] result )
		{
			Get24of75Ex( 1, result );
		}

		void Get5of75( byte[] result )
		{
			int[] counts = { 1, 1, 1, 1, 1 };
			GetNofMEx( 1, 5, 75, counts, result );
		}

		int card = 0;
		public byte[, ,] Create( int faces )
		{
			return Create( null, 0, 0, faces, false );
		}
		/// <summary>
		///  Creates a 25 number bingo card.  The center is marked with a 0.
		/// </summary>
		/// <returns>An array of [col,row]</returns>

		public byte[, ,] Create( BingoDealer dealer
			, int starting_card, int card_offset, int faces, bool starburst )
		//public byte[, ,] Create( int faces, bool starburst )
		{
					
			if( faces == 1 )
			{
				if( card == 0 )
					nums = bdi.CallBalls();
				byte[] face_data = new byte[72];
				Get24of75Ex( 3, face_data );
            	byte[, ,] result = new byte[1, 5, 5];
				int r, c;
				int n = card * 24;
				for( c = 0; c < 5; c++ )
					for( r = 0; r < 5; r++ )
						if( r == 2 && c == 2 )
							result[0, c, r] = 0;
						else
							result[0, c, r] = face_data[n++];

				// min inclusive max exclusive
				int spot = entropy.Next( 24 );
				if( spot >= 12 )
					spot++;
				// bonus spot
				result[0, 2, 2] = result[0,spot/5,spot%5];

				card++;
				if( card == 3 )
					card = 0;
				return result;
			}
			else if( faces == 2 )
			{
				nums = bdi.CallBalls();
				byte[] face_data = new byte[72];

				Get24of75Ex( 3, face_data );
				byte[, ,] result = new byte[2, 5, 5];
				int i, j;
				int n = card * 24;
				for( int c = 0; c < 2; c++ )
				{
					for( i = 0; i < 5; i++ )
						for( j = 0; j < 5; j++ )
							if( i == 2 && j == 2 )
								result[c, i, j] = 0;
							else
								result[c, i, j] = face_data[n++];
					// hotball
					result[0, 2, 2] = (byte)entropy.Next( 1, 76 );
				}
				card = 0;
				return result;
			}
			return null;
		}

		byte[, ,] CardData.Create( int starting_card, int faces, bool starburst )
		//public byte[, ,] Create( int faces, bool starburst )
		{
			return Create( null, starting_card, 0, faces, starburst );
		}
		byte[, ,] CardData.Create( int starting, int faces, int skip, int minrange, int maxrange, bool starburst )
		{
			//return Create( ( BingoDealer)null, starting, skip, faces, starburst );
			return null;
		}

		public byte[] Create5Card()
		{
			byte[] result = new byte[5];
			Get5of75( result );
			return result;
		}

		public byte[, ,] LoadCards( String file, int start, int skip, int count )
		{
			return null;
		}

		public byte[, ,] Create( int faces, int marks )
		{
			byte[, ,] result = new byte[faces, 1, marks];
			int[] card_marks = bdi.CallBalls( marks * faces );
			for( int n = 0; n < marks; n++ )
				result[0, 0, n] = (byte)(card_marks[n]);
			return result;

		}
		public byte[, ,] Create( int faces, bool starbust )
		{
			byte[,,]card = Create( null, 0, 0, faces, starbust );
			if( starbust )
				card[0,2, 2] = (byte)(bdi.CallBalls( 1 )[0]);
			return card;
		}


		string CardData.name
		{
			get { return "RNG Cardset"; }
		}
		string CardData.file_name
		{
			get { return ""; }
		}
	}
}
