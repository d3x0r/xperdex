using System;
using System.Data;
using xperdex.classes;


namespace OpenSkieScheduler3.Relations
{
	[SchedulePersistantTable]
	public class CardswipeCalibrateTable : MySQLDataTable
	{

		new public static readonly string TableName = "cardswipe_data";
		//new public static readonly string NameColumn = XDataTable.Name( TableName );
		new public static readonly string PrimaryKey = XDataTable.ID( TableName );
		public static readonly string CardData = "card_number";

		public CardswipeCalibrateTable()
		{
			// UpdateChanges() requires parameterless constructor.
		}

		public CardswipeCalibrateTable(DsnConnection dsn, DataSet dataSet)
			: base( dsn, null, TableName, true, false, false, true )
		{
			dataSet.Tables.Add( this );
			Columns.Add( CardData, typeof( int ) );


		}

		public void AddCardswipeNumber(UInt64 value)
		{
			DataRow tmp;
			tmp = NewRow();
			tmp[CardData] = value;
			Rows.Add(tmp);

			CommitChanges();
		}

	}
}
