using System;
using System.Collections.Generic;
using System.Text;
using xperdex.classes;
using System.Data;

namespace OpenSkieScheduler.Relations
{
	[SchedulePersistantTable]
	public class SessionGameRelation: MySQLRelationTable
	{
		new public static readonly String TableName = "session_game";
		public static readonly string NameColumn = XDataTable.Name( TableName );
		new public static readonly string PrimaryKey = XDataTable.ID( TableName );

		public static readonly XDataTable XDataTable1;// = typeof( SessionTable );
		public static readonly XDataTable XDataTable2;// = typeof( GameGroupTable );


		public SessionGameRelation()
		{
			base.TableName = "(tmp)" + SessionGameRelation.TableName;
		}
		
		public SessionGameRelation( DsnConnection odbc, DataSet dataset )
			: base( odbc
			, dataset
			, Names.schedule_prefix
			, "session_game"
			, dataset.Tables[SessionTable.TableName]
			, dataset.Tables[GameTable.TableName] 
			, false
			)
		{
		}



		public DataRow Current;// { get; set; }
	}
}
