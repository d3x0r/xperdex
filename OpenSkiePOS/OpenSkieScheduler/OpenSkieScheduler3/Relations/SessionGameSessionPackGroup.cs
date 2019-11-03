using System;
using System.Collections.Generic;
using System.Text;
using xperdex.classes;
using System.Data;

namespace OpenSkieScheduler3.Relations
{
    // this is the assignment of game group to session-game
    [SchedulePersistantTable]
    public class SessionGamePackGroup: MySQLRelationTable2<DataRow,SessionGame,PackGroupTable>
    {
        new public static readonly String TableName = MySQLRelationTable2<DataRow,SessionGame, PackGroupTable>.RelationName;
		new public static readonly String PrimaryKey = XDataTable.ID( TableName );
		// override this if you care.
		//new public static readonly String NumberColumn = MySQLRelationTable.Number( GameTable.TableName );

		public SessionGamePackGroup()
		{
			// hooray for GetChanges(); suck.
		}

        public SessionGamePackGroup(  DataSet dataset )
            : base( dataset )
		{
		}


    }

	// this is the assignment of game group to session-game
	[SchedulePersistantTable( DefaultFill="DefaultFill" )]
	public class SessionGameSessionPackGroup : MySQLRelationTable2<DataRow, SessionGame, SessionPackGroup>
	{
		new public static readonly String TableName = MySQLRelationTable2<DataRow, SessionGame, SessionPackGroup>.RelationName;
		new public static readonly String PrimaryKey = XDataTable.ID( TableName );
		// override this if you care.
		//new public static readonly String NumberColumn = MySQLRelationTable.Number( GameTable.TableName );

		public SessionGameSessionPackGroup()
		{
			// hooray for GetChanges(); suck.
		}

		public SessionGameSessionPackGroup( DataSet dataset )
			: base( dataset )
		{
		}

		public void DefaultFill( )
		{
			if( Rows.Count == 0 )
			{
				/* old migration code
				ScheduleDataSet schedule_dataset = DataSet as ScheduleDataSet;
				if( schedule_dataset != null )
				{
					foreach( DataRow session_game_pack_group in schedule_dataset.session_game_session_pack_group.Rows )
					{
						DataRow pack_group = session_game_pack_group.GetParentRow( "session_pack_group_in_session_game" );
						DataRow session_game = session_game_pack_group.GetParentRow( "session_game_has_session_pack_group" );
						DataRow session = session_game.GetParentRow( "session_has_game" );
						DataRow session_pack_group = schedule_dataset.session_pack_groups.GetGroupMember( session, pack_group );
						if( session_pack_group != null )
							AddGroupMember( session_game, session_pack_group );
						session_game_pack_group.Delete();
					}
				}
				*/
			}
		}
	}

}
