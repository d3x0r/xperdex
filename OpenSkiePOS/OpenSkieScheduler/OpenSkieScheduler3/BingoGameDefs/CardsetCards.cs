using System;
using System.Data;
using xperdex.classes;

namespace OpenSkieScheduler3.BingoGameDefs
{
	[SchedulePersistantTable( FillMethod = "None" )]
	public class CardsetCards : MySQLDataTable
	{
		new public static readonly String TableName = "cardset_cards";
		new public static readonly String NumberColumn = "card_number";
		new public static readonly String PrimaryKey = XDataTable.ID( TableName );

		void AddColumns()
		{
			Columns.Add( CardsetInfo.PrimaryKey, AutoKeyType );
			Columns.Add( "card_number", typeof( int ) );
			Columns.Add( "b1", typeof( byte ) );
			Columns.Add( "b2", typeof( byte ) );
			Columns.Add( "b3", typeof( byte ) );
			Columns.Add( "b4", typeof( byte ) );
			Columns.Add( "b5", typeof( byte ) );
			Columns.Add( "i1", typeof( byte ) );
			Columns.Add( "i2", typeof( byte ) );
			Columns.Add( "i3", typeof( byte ) );
			Columns.Add( "i4", typeof( byte ) );
			Columns.Add( "i5", typeof( byte ) );
			Columns.Add( "n1", typeof( byte ) );
			Columns.Add( "n2", typeof( byte ) );
			Columns.Add( "n3", typeof( byte ) );
			Columns.Add( "n4", typeof( byte ) );
			Columns.Add( "g1", typeof( byte ) );
			Columns.Add( "g2", typeof( byte ) );
			Columns.Add( "g3", typeof( byte ) );
			Columns.Add( "g4", typeof( byte ) );
			Columns.Add( "g5", typeof( byte ) );
			Columns.Add( "o1", typeof( byte ) );
			Columns.Add( "o2", typeof( byte ) );
			Columns.Add( "o3", typeof( byte ) );
			Columns.Add( "o4", typeof( byte ) );
			Columns.Add( "o5", typeof( byte ) );
			keys.Add( new XDataTableKey( false, "cardset_id_idx", new String[] { CardsetInfo.PrimaryKey } ) );
			keys.Add( new XDataTableKey( false, "card_number_idx", new String[] { "card_number" } ) );
			keys.Add( new XDataTableKey( false, "card_of_set_idx", new String[] { CardsetInfo.PrimaryKey, "card_number" } ) );
		}

		public CardsetCards()
		{
		}

		public CardsetCards( DataSet dataSet )
			: base( Names.schedule_prefix, TableName, true, false )
		{
			AddColumns();
			dataSet.Tables.Add( this );
		}
	}

	[SchedulePersistantTable( FillMethod = "None" )]
	public class CardsetCards90 : MySQLDataTable
	{
		new public static readonly String TableName = "cardset_cards_c90";
		new public static readonly String NumberColumn = "card_number";
		new public static readonly String PrimaryKey = XDataTable.ID( TableName );

		void AddColumns()
		{
			DataColumn dc;
			Columns.Add( CardsetInfo.PrimaryKey, AutoKeyType );
			Columns.Add( "card_number", typeof( int ) );
			Columns.Add( "sheet_number", typeof( int ) );
			dc = Columns.Add( "flag", typeof( byte ) );
			dc.DefaultValue = DBNull.Value;
			for( int r = 1; r < 4; r++ )
				for( int c = 1; c < 10; c++ )
					Columns.Add( "r" + r + "c" + c, typeof( byte ) );
			keys.Add( new XDataTableKey( false, "cardset_id_idx", new String[] { CardsetInfo.PrimaryKey } ) );
			keys.Add( new XDataTableKey( false, "card_number_idx", new String[] { "card_number" } ) );
			keys.Add( new XDataTableKey( false, "sheet_number_idx", new String[] { "sheet_number" } ) );
			keys.Add( new XDataTableKey( false, "card_of_set_idx", new String[] { CardsetInfo.PrimaryKey, "card_number", "sheet_number" } ) );
		}

		public CardsetCards90()
		{
		}

		public CardsetCards90( DataSet dataSet )
			: base( Names.schedule_prefix, TableName, true, false )
		{
			AddColumns();
			dataSet.Tables.Add( this );
		}
	}
}
