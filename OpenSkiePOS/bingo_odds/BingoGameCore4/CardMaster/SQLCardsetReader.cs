using OpenSkieScheduler3.BingoGameDefs;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using xperdex.classes;

namespace BingoGameCore4.CardMaster
{
	class CardSQLReader : CardData
	{
		// buffer to cache read bingo cards... maybe should make it a keyed list.
		byte[, ,] card_stock;
		int offset; // amount of cards to skip from set

		OpenSkieScheduler3.ScheduleDataSet schedule;
		DataRow dataRowCardset;
		public static CardData GetCardReader( DataRow dataRowCardsetRange )
		{
			return new CardSQLReader( dataRowCardsetRange );
		}

		public CardSQLReader( DataRow dataRowCardsetRange )
        {
			dataRowCardset = dataRowCardsetRange.GetParentRow( "cardset_has_cardset_range" );
			DataTable ranges = dataRowCardsetRange.Table;
			bool double_action = (dataRowCardsetRange["double_action"]==DBNull.Value)?false:Convert.ToBoolean( dataRowCardsetRange["double_action"] );
			card_stock = new byte[Convert.ToInt32( dataRowCardset["cards"] ), 5, 5];
			schedule = ranges.DataSet as OpenSkieScheduler3.ScheduleDataSet;
			DataRow Cardset = dataRowCardsetRange.GetParentRow( CardsetRange.CardsetInfoRelationName );
            readers.Add( this );

        }

		static List<CardData> readers = new List<CardData>();

		void ValidateLoadCard( int card )
		{
			if( card_stock[card, 0, 0] == 0 )
			{
				DataRow[] cardset_card = schedule.cardset_cards.Select( CardsetInfo.PrimaryKey + "='" + dataRowCardset[CardsetInfo.PrimaryKey] + "' and " + "card_number=" + ( card + offset + 1 ) );
				List<DataRow> rows;
				DataRow card_data;
				if( cardset_card == null || cardset_card.Length == 0 )
				{
					rows = DsnSQLUtil.FillDataTable( schedule.schedule_dsn, schedule.cardset_cards, CardsetInfo.PrimaryKey + "='" + dataRowCardset[CardsetInfo.PrimaryKey] + "' and " + "card_number=" + ( card + offset + 1 ) );
					card_data = rows[0];
				}
				else
					card_data = cardset_card[0];

				card_stock[card, 0, 0] = (byte)card_data["b1"];
				card_stock[card, 0, 1] = (byte)card_data["b2"];
				card_stock[card, 0, 2] = (byte)card_data["b3"];
				card_stock[card, 0, 3] = (byte)card_data["b4"];
				card_stock[card, 0, 4] = (byte)card_data["b5"];
				card_stock[card, 1, 0] = (byte)card_data["i1"];
				card_stock[card, 1, 1] = (byte)card_data["i2"];
				card_stock[card, 1, 2] = (byte)card_data["i3"];
				card_stock[card, 1, 3] = (byte)card_data["i4"];
				card_stock[card, 1, 4] = (byte)card_data["i5"];
				card_stock[card, 2, 0] = (byte)card_data["n1"];
				card_stock[card, 2, 1] = (byte)card_data["n2"];
				card_stock[card, 2, 3] = (byte)card_data["n3"];
				card_stock[card, 2, 4] = (byte)card_data["n4"];
				card_stock[card, 3, 0] = (byte)card_data["g1"];
				card_stock[card, 3, 1] = (byte)card_data["g2"];
				card_stock[card, 3, 2] = (byte)card_data["g3"];
				card_stock[card, 3, 3] = (byte)card_data["g4"];
				card_stock[card, 3, 4] = (byte)card_data["g5"];
				card_stock[card, 4, 0] = (byte)card_data["o1"];
				card_stock[card, 4, 1] = (byte)card_data["o2"];
				card_stock[card, 4, 2] = (byte)card_data["o3"];
				card_stock[card, 4, 3] = (byte)card_data["o4"];
				card_stock[card, 4, 4] = (byte)card_data["o5"];
			}

		}

		byte[, ,] CardData.Create( int starting_card, int faces, bool starburst )
		{
			byte[, ,] card;
			/*
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
			*/
			{
				card = new byte[faces, 5, 5];
				//int card_number = dealer.GetPhysicalNext( starting_card, card_offset );
				for( int face = 0; face < faces; face++ )
				{
					ValidateLoadCard( starting_card * faces + face );
					for( int col = 0; col < 5; col++ )
						for( int row = 0; row < 5; row++ )
						{
							card[face, col, row] = card_stock[( starting_card - offset ) * faces + face, col, row];
						}
				}
			}
			return card;
		}

		byte[, ,] CardData.Create( int starting, int faces, int skip, int minrange, int maxrange, bool starburst )
		{
			throw new NotImplementedException();
		}

		string CardData.name
		{
			get { throw new NotImplementedException(); }
		}

		string CardData.file_name
		{
			get { throw new NotImplementedException(); }
		}
	}
}
