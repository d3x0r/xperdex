using System;
using xperdex.classes;

namespace OpenSkieScheduler3.BingoGameDefs
{
	[SchedulePersistantTable]
	public class PaperCardverCheckfirst: MySQLDataTable
	{
		new public static readonly String TableName = "paper_checkfirst_info";

		public PaperCardverCheckfirst( DsnConnection odbc )
			: base( odbc, Names.schedule_prefix, TableName, true, false )
		{
			Columns.Add( "session_number", typeof( int ) );
			Columns.Add( "game_number", typeof( int ) );
			/// this is equivalent to cardset_range_id
			Columns.Add( "cardset_range_id", typeof( int ) );
			//Create();
			//Fill();
		}
	}
}
