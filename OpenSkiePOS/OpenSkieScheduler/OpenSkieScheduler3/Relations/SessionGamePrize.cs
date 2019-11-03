using System;
using System.Data;
using xperdex.classes;

namespace OpenSkieScheduler3
{
#if asdfasdf
	[SchedulePersistantTable]
	public class SessionPrizeTable : MetaMySQLRelation<SessionPrizeTable.SessionPrizeTableDataRow>
	{
		new public static readonly string TableName = "scheduled_prizes";

		public class SessionPrizeTableDataRow : DataRow
		{

			public SessionPrizeTableDataRow( global::System.Data.DataRowBuilder rb ) : 
                    base(rb) 
			{
            }

			public override string ToString()
			{
				DataRow row_prize = this.GetParentRow( "session_prize_level_meta_prize_level" );
				DataRow row_session = this.GetParentRow( "session_prize_level_meta_session_info" );
				if( row_session == null )
					return this[SessionPrizeOrder.NumberColumn] + ". " + "<NULL>" + ":" + row_prize[PrizeLevelNames.NameColumn].ToString();

				return this[SessionPrizeOrder.NumberColumn] + ". " + row_session[SessionTable.NameColumn] + ":" + row_prize[PrizeLevelNames.NameColumn].ToString();
			}
		}

		public SessionPrizeTable()
		{
			// again hooray for GetChanges();
		}

		public SessionPrizeTable( DsnConnection odbc, DataSet dataSet )
			: base( dataSet
					, dataSet.Tables[SessionDayMacroSessionTable.TableName] 

			// session_info->session_game_group->game_group_info->game_group_game->game_info
            ,  new MySQLRelationMap( new object[] { 
				"session_in_session_macro"  // go from session_macro_session to session
				, MySQLRelationMap.MapOp.InvokNameChangeEvent // when session name column changes, update my name
				, MySQLRelationMap.MapOp.FollowToChild  // follow the next link to child node
				, "session_has_game" // go from session info to session_game_group_game
				, MySQLRelationMap.MapOp.SaveRelationPoint  // save game_group_id
				, MySQLRelationMap.MapOp.FollowToChild  // follow next link to child
				, "session_game_has_session_pack_group" // get game group info table 
				, MySQLRelationMap.MapOp.SaveRelationPoint  // save game_group_id
				, MySQLRelationMap.MapOp.FollowToParent  // follow next link to child
				, "session_pack_group_in_session_game" // get game group info table 
				, MySQLRelationMap.MapOp.SaveRelationPoint  // save game_group_id
				, MySQLRelationMap.MapOp.FollowToParent  // follow next link to child
				, "pack_group_in_session"
				, MySQLRelationMap.MapOp.SaveRelationPoint  // save game_group_id
				, MySQLRelationMap.MapOp.FollowToChild  // follow next link to child
				, "pack_group_has_pack" // get game group info table 
				, MySQLRelationMap.MapOp.SaveRelationPoint  // save game_group_id
				, MySQLRelationMap.MapOp.FollowToParent  // follow next link to child
				, "pack_in_pack_group" // get game group info table 
				, MySQLRelationMap.MapOp.SaveRelationPoint  // save game_group_id
				, MySQLRelationMap.MapOp.FollowToChild  // follow next link to child
				, "pack_has_prize_level" // get game group info table 
				, MySQLRelationMap.MapOp.InvokNameChangeEvent  // if prize level changes, change my name
				} ).ToString()
				//, "session_in_session_macro$/session_game_group_game_meta_session_info.\\session_game_group_game_meta_game_group_info./game_group_has_prize_level\\prize_level_in_game_group$"
					, false
					, null
					, false
					)
		{
			//Columns.Add( "prize_amount", typeof( Money ) );

		}
	}

	[SchedulePersistantTable]
	public class SessionPrizeOrder : MetaMySQLRelation<DataRow>
	{
		//basically no reference to a odbc, so it's memory only tracking.
		new public static readonly string TableName = "session_prize_level";
		//public static readonly string PrimaryKey = "session_game_id";
		public static readonly string NameColumn = "Name";
		new public static readonly String NumberColumn = "prize_number";

		public SessionPrizeOrder( DsnConnection odbc, DataSet dataSet )
			: base( odbc
					, dataSet
					, dataSet.Tables[SessionTable.TableName] 
#if direct_translate
			, new MySQLRelationMap( new object[] {
				MySQLRelationMap.MapOp.SaveRelationPoint
				, MySQLRelationMap.MapOp.FollowToChild
				, "session_has_game_group"
				, MySQLRelationMap.MapOp.InvokNameChangeEvent
				, MySQLRelationMap.MapOp.FollowToParent
				, "game_group_in_session"
				, MySQLRelationMap.MapOp.InvokNameChangeEvent
				, MySQLRelationMap.MapOp.FollowToChild
				, "game_group_has_prize_level"
				, MySQLRelationMap.MapOp.InvokNameChangeEvent
				, MySQLRelationMap.MapOp.FollowToParent
				, "prize_level_in_game_group"
				, MySQLRelationMap.MapOp.InvokNameChangeEvent
			} ).ToString()
#endif
			, new MySQLRelationMap( new object[] {
					dataSet.Tables[SessionTable.TableName]
					, MySQLRelationMap.MapOp.InvokNameChangeEvent
					, MySQLRelationMap.MapOp.FollowToChild
					, "session_has_game"
					, MySQLRelationMap.MapOp.FollowToChild
					, "session_game_has_session_pack_group"
					, MySQLRelationMap.MapOp.FollowToParent
					, "session_pack_group_in_session_game"
					, MySQLRelationMap.MapOp.FollowToParent
					, "pack_group_in_session"
					, MySQLRelationMap.MapOp.FollowToParent
					, "pack_group_has_pack"
					, MySQLRelationMap.MapOp.FollowToParent
					, "pack_in_pack_group"
					, MySQLRelationMap.MapOp.FollowToChild
					, "pack_has_prize_level"
					, MySQLRelationMap.MapOp.FollowToParent
					, "prize_level_in_pack"
					, MySQLRelationMap.MapOp.InvokNameChangeEvent
				} ).ToString()
				//, "./session_has_game_group$\\game_group_in_session$/game_group_has_prize_level$\\prize_level_in_game_group$"
					, false
					, false
					, new DataColumn[] { new DataColumn( NameColumn, typeof( String ) )
										, new DataColumn( SessionPrizeOrder.NumberColumn, typeof( int ) ) }
			)
		{
			Init();
		}

		public SessionPrizeOrder()
		{
			base.TableName = TableName;
		}
		void OrderedFill()
		{
			Fill( SessionPrizeOrder.NumberColumn );
		}
		void Init()
		{
			base.TableName = TableName;
			//Columns.Add( "Name", typeof( string ) );
			//Columns.Add( SessionPrizeOrder.NumberColumn, typeof( int ) );

			AddingRow += new OnNewRow( initrow );

			FixupRow += new OnFixupRow( SessionGameGroupPrizeOrder_FixupRow );
			this.RowChanged += new DataRowChangeEventHandler( SessionPrizeMetaRelation_RowChanging );
			//Create();
			
		}

		void SessionPrizeMetaRelation_RowChanging( object sender, DataRowChangeEventArgs e )
		{
			if( e.Action == DataRowAction.Add )
			{
				if( e.Row.RowState == ( DataRowState.Added ) || e.Row.RowState == DataRowState.Detached )
				{
					DataRow Source1 = e.Row.GetParentRow( TableName + "_meta_" + root_table.TableName );
					DataRow Source2 = e.Row.GetParentRow( TableName + "_meta_" + terminal_table.TableName );
					e.Row["Name"] = ( ( Source1 == null ) ? "<NULL>" : Source1[XDataTable.Name(root_table)] ) + " : " + ( ( Source2 == null ) ? "<NULL>" : Source2[terminal_table.NameColumn] );
				}
			}
		}

		void SessionGameGroupPrizeOrder_FixupRow( DataRow row )
		{
			try
			{
				object max_number = Compute( "Max(" + NumberColumn + ")"
					, "session_id='" + row["session_id"] + "'"
					//+ " and "
					//+ NumberColumn + "<" + row[NumberColumn]
					);
				int new_number;
				if( max_number.GetType() == typeof( DBNull ) )
				{
					new_number = 1;
				}
				else
				{
					new_number = Convert.ToInt32( max_number ) + 1;
				}
				if( row[NumberColumn] == DBNull.Value || 
					Convert.ToInt32( row[NumberColumn] ) != new_number )
					row[NumberColumn] = new_number;
			}
			catch
			{
				row[NumberColumn] = 1;
			}

		}

		void initrow( DataRow row )
		{
			try
			{
				SessionGameGroupPrizeOrder_FixupRow( row );
			}
			catch
			{
				row[NumberColumn] = 1;
			}
		}
	}
#endif
}

