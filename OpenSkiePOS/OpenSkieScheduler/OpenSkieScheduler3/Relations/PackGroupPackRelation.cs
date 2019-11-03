using System;
using System.Collections.Generic;
using System.Text;
using xperdex.classes;
using System.Data;

namespace OpenSkieScheduler3.Relations
{
	[SchedulePersistantTable]
	public class PackGroupPackRelation: MySQLRelationTable2<PackGroupPackRelation.PackGroupPackRow, PackGroupTable, PackTable >
	{
		new public static readonly String TableName = MySQLRelationTable2<PackGroupPackRelation.PackGroupPackRow, PackGroupTable, PackTable>.RelationName;
		new public static readonly String PrimaryKey = XDataTable.ID( TableName );
		public class PackGroupPackRow : DataRow
		{

			public PackGroupPackRow( global::System.Data.DataRowBuilder rb ) : 
                    base(rb) 
			{
            }


			public override string ToString()
			{
				PackGroupPackRelation table = Table as PackGroupPackRelation;
				DataRow row_packs = this.GetParentRow( table.ParentOfChild );
				if( row_packs == null )
					return "ERR:Related Pack Not Found";
				return row_packs[PackTable.NameColumn].ToString();
			}
		}

		public PackGroupPackRelation( DataSet set ): base( set )
		{
		}
		public PackGroupPackRelation()
		{
		}

		public DataRow[] GetPacks( DataRow game_group )
		{
			DataRow[] result;
			DataRow[] tmp = game_group.GetChildRows( "pack_group_has_pack" );
			result = new DataRow[tmp.Length];
			int idx = 0;
			foreach( DataRow row in tmp )
			{
				result[idx++] = row.GetParentRow( "pack_in_pack_group" );
			}
			return result;
		}

		public DataRow[] GetPrizes( DataRow game_group )
		{
			DataRow[] result;
			DataRow[] tmp = game_group.GetChildRows( "pack_group_has_prize_level" );
			result = new DataRow[tmp.Length];
			int idx = 0;
			foreach( DataRow row in tmp )
			{
				result[idx++] = row.GetParentRow( "prize_level_in_pack_group" );
			}
			return result;
		}
	}

	[SchedulePersistantTable]
	public class PackGroupPackMetaRelation : MetaMySQLRelation<DataRow>
	{
		new public static readonly String TableName = "pack_group_pack";

		public PackGroupPackMetaRelation( DsnConnection odbc, DataSet dataset )
			: base( odbc, dataset
			, dataset.Tables[PackGroupTable.TableName]
			, new MySQLRelationMap( new object[] {
				dataset.Tables[PackGroupTable.TableName]
				, MySQLRelationMap.MapOp.InvokNameChangeEvent
				, MySQLRelationMap.MapOp.FollowToChild
				, "pack_group_has_prize_level"
				, MySQLRelationMap.MapOp.InvokNameChangeEvent
				, MySQLRelationMap.MapOp.FollowToChild
				, "pack_group_prize_level_has_pack"
				, MySQLRelationMap.MapOp.InvokNameChangeEvent
				, MySQLRelationMap.MapOp.FollowToParent
				, "pack_in_pack_group_prize_level"
				, MySQLRelationMap.MapOp.InvokNameChangeEvent
			} ).ToString()
			//, ".session_has_game_group.\\game_group_in_session$/game_group_has_game.\\game_in_game_group$"
			, false
			, false
			, null
			)
		{
		}
		public PackGroupPackMetaRelation()
		{
			base.TableName = "(tmp)" + PackGroupPackMetaRelation.TableName;
		}

	}
}
