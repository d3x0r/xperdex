using System;
using xperdex.classes;
using System.Data.Common;
namespace OpenSkieSessionState
{
    
    
    public partial class SessionStateDataset {
        partial class operational_configurationDataTable
        {
            public override void EndInit()
            {
                base.EndInit();
                Columns["current_bingoday"].ExtendedProperties.Add( "Extra Type", "date" );
            }
            
        }

		partial class session_day_sessionsDataTable
		{
			public static new string PrimaryKey = "ID";
			public static new string NumberColumn = "session_order";
			public override void EndInit()
			{
				RowChanged += new System.Data.DataRowChangeEventHandler( session_day_sessionsDataTable_RowChanged );
				base.EndInit();
				Columns["dummy_timestamp"].ExtendedProperties.Add( "Extra Type", "createstamp" );
				Columns["bingoday"].ExtendedProperties.Add( "Extra Type", "date" );
				base.PrimaryKey = new System.Data.DataColumn[1] { Columns[PrimaryKey] };
			}

			void session_day_sessionsDataTable_RowChanged( object sender, System.Data.DataRowChangeEventArgs e )
			{
				// if a row is being added, check to make sure we have good values.
				if( e.Action == System.Data.DataRowAction.Add )
				{
					// if the session number is not already set...
					if( e.Row[NumberColumn] == DBNull.Value )
					{
						String condition = "bingoday='"
							+ DsnSQLUtil.MakeDateOnly( DsnConnection.ConnectionMode.NativeDataTable, DsnConnection.ConnectionFlavor.Unknown, (DateTime)e.Row["Bingoday"] ) + "'";
						object o = Compute( "max(" + NumberColumn + ")", condition );
						int max = ( DBNull.Value == o ) ? 0 : Convert.ToInt32( o );
						e.Row[NumberColumn] = max + 1;
					}
				}
			}
		}

		partial class session_day_sessionsRow
		{
			public override string ToString()
			{
				return this["session_name"].ToString() + this["bingoday"].ToString();
			}
		}

		public void Fill( DsnConnection db, DateTime bingoday )
		{
			// in case session_order is 0, then sort on legacy number.
			DsnSQLUtil.FillDataTable( db, session_day_sessions, "bingoday=" + DsnSQLUtil.MakeDateOnly( db, bingoday )
				, "session_order,session_number" );
		}

        public void Fill( DsnConnection db )
        {
            // in case session_order is 0, then sort on legacy number.
            DsnSQLUtil.FillDataTable( db, session_day_sessions, "open_for_sales_flag<>1 OR open_for_play_flag<>1 OR open_for_issue_flag OR ( opened_for_issue=0 AND opened_for_sales=0 AND opened_for_play=0 )" 
                , "session_order,session_number" );
            DsnSQLUtil.FillDataTable( db, operational_configuration );
        }
	}

}
