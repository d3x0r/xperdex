using xperdex.classes;

namespace OpenSkieScheduler3.BingoGameDefs
{
	public class CardsetRangePayoutLevel: MySQLDataTable
	{
		public CardsetRangePayoutLevel( DsnConnection odbc )
			: base( odbc, Names.schedule_prefix, "cardset_range_payout_level", false, false )
		{
			this.connection = odbc;
			Columns.Add( "cardset_ranges_id", typeof( int ) );
			Columns.Add( "payout_level", typeof( int ) );
		}
	}
}
