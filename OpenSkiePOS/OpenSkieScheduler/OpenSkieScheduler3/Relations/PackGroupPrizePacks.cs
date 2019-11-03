using System;
using System.Collections.Generic;
using System.Text;
using xperdex.classes;
using System.Data;

namespace OpenSkieScheduler3.Relations
{
	[SchedulePersistantTable]
	public class GameGroupPrizePacks : MySQLRelationTable2<DataRow,PackGroupPrizeRelation, PackTable>
	{

		new public static readonly String TableName = MySQLRelationTable2<DataRow,PackGroupPrizeRelation, PackTable>.RelationName;
		public static readonly String NameColumn = XDataTable.Name( TableName );
		new public static readonly String NumberColumn = XDataTable.Number( PackTable.TableName );

		public GameGroupPrizePacks()
		{
			// hooray, AGAIN for GetChanges();
		}

		public GameGroupPrizePacks( DsnConnection odbc, DataSet set ) : base( odbc, set )
		{
		}

	}

}
