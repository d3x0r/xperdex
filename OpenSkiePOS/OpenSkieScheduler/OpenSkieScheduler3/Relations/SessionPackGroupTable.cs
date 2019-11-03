using System;
using System.Collections.Generic;
using System.Text;
using xperdex.classes;
using System.Data;

namespace OpenSkieScheduler3.Relations
{
	[SchedulePersistantTable]
	public class SessionPackGroup : MySQLRelationTable2<SessionPackGroup.SessionPackGroupRow, SessionTable, PackGroupTable>
	{
		new public static readonly String TableName = "session_pack_group";
		new public static readonly String PrimaryKey = XDataTable.ID( TableName );
		new public static readonly String NumberColumn = "pack_number";

		public class SessionPackGroupRow : DataRow
		{
			public SessionPackGroupRow( global::System.Data.DataRowBuilder rb ) : 
                    base(rb) 
			{
            }

			public override string ToString()
			{
				if( RowState == DataRowState.Deleted )
					return "<Deleted>";
				else if( RowState == DataRowState.Detached )
					return "<Detached>";
				DataRow pack = GetParentRow( "pack_group_in_session" );
				DataRow session = GetParentRow( "session_has_pack_group" );
				return String.Format( "{0,3}. ", this[SessionPack.NumberColumn] ) + pack[PackGroupTable.NameColumn] + " in " + session[SessionTable.NameColumn];
			}
		}

		/// <summary>
		/// need a copy constructor... (GetChanges)
		/// </summary>
		public SessionPackGroup()
		{
		}

		public SessionPackGroup( DataSet dataset )
			: base( dataset )
		{
		}
	}

}
