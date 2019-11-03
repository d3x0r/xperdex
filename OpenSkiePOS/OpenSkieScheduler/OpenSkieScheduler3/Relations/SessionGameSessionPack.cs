using System;
using System.Collections.Generic;
using System.Text;
using xperdex.classes;
using System.Data;

namespace OpenSkieScheduler3.Relations
{
#if not_obsolete
	[SchedulePersistantTable]
	public class SessionGameSessionPack: MySQLRelationTable2<DataRow, SessionGame, SessionPack >
	{
		public static new String TableName = "session_game_session_pack";

		public SessionGameSessionPack()
		{
		}

		public SessionGameSessionPack( DsnConnection dsn, DataSet dataSet )
			: base( dsn, dataSet, false, false )
		{
			Columns.Add( new DataColumn( "page", typeof( int ) ) );			
		}
	}
#endif
}
