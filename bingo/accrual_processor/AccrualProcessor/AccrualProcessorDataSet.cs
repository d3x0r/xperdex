using System;
using System.Data;
using xperdex.classes;
namespace ECube.AccrualProcessor {
    
    
    public partial class AccrualProcessorDataSet {
		partial class AccrualGroupDataTable
		{
		}



		[xperdex.classes.SQLPersistantTable]
		public partial class accrual_processor_last_sessionDataTable
		{
			new static public string TableName = "accrual_processor_last_session";
		}

		[xperdex.classes.SQLPersistantTable]
		partial class accrual_processor_computed_sessionsDataTable
		{
			new static public string TableName = "accrual_processor_computed_sessions";
			public void SyncSessions( bingoDataSet.bingoDataSet.sessionDataTable sessions )
			{
				foreach( DataRow row in sessions )
				{
					DataRow[] prows = this.Select( "ses_id='" + row["ses_id"] + "'" );
					if( prows == null || prows.Length == 0 )
					{
						DataRow sessrow = this.NewRow();
						sessrow["ses_id"] = row["ses_id"];
						sessrow["when"] = DBNull.Value;
						sessrow["Processed"] = false;
						sessrow["computed_session_id"] = Guid.NewGuid();
						Rows.Add( sessrow );
					}
				}
			}
		}


	}
}
