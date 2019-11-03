using System;
using System.Collections.Generic;
using System.Text;
using xperdex.classes;
using System.Data;

namespace OpenSkieScheduler3.Relations
{
	[SchedulePersistantTable]
	public class PackGroupPrizeRelation: MySQLRelationTable2<DataRow, PackGroupTable, PrizeLevelNames>
	{

		new public static readonly String TableName = MySQLRelationTable2<DataRow,PackGroupTable, PrizeLevelNames>.RelationName;
		public static readonly String NameColumn = XDataTable.Name( TableName );
		new public static readonly String NumberColumn = XDataTable.Number( PrizeLevelNames.TableName );

		public PackGroupPrizeRelation()
		{
			// hooray, AGAIN for GetChanges();
		}

		public PackGroupPrizeRelation( DataSet set ) : base(set)
		{

		}


		public DataRow Current;
	}


}
