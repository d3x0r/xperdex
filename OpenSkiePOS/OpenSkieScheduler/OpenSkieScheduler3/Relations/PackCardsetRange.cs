using System;
using System.Collections.Generic;
using System.Text;
using xperdex.classes;
using System.Data;
using OpenSkieScheduler3.BingoGameDefs;

namespace OpenSkieScheduler3.Relations
{
	[SchedulePersistantTable]
	/// <summary>
	/// Represents the relation between packs and the ranges that apply to the pack.
	/// </summary>
	public class PackCardsetRange : MySQLRelationTable2< PackCardsetRange.PackCardsetRangeRow, PackTable, CardsetRange>
	{

		public class PackCardsetRangeRow : DataRow
		{
			public PackCardsetRangeRow( global::System.Data.DataRowBuilder rb ) : 
                    base(rb) 
			{
            }


			public override string ToString()
			{

				//cardset_info["friendly_name"] + "(" + cardset_range[CurrentCardsetRanges.DisplayName] + ")";
				DataRow row_range = GetParentRow( "cardset_range_in_pack" );

				DataRow cardset_info = row_range.GetParentRow( "cardset_has_cardset_range" );

				return cardset_info["friendly_name"] + "(" + row_range[CardsetRange.NameColumn] + ")"; ;
			}
		}

		new public static readonly string TableName = MySQLRelationTable2<DataRow,PackTable, CardsetRange>.RelationName;
		new public static readonly string PrimaryKey = XDataTable.ID( TableName );

		public PackCardsetRange()
		{
		}
		public PackCardsetRange( DataSet dataset ) : base( dataset )
		{
		}
	}


	[ScheduleTable( Fill="BuildDataRows" )]
	public class CardsetRangePack : MetaMySQLRelation<DataRow>
	{
		new public static readonly string TableName = "cardset_range_pack";
		new public static readonly string PrimaryKey = XDataTable.ID( TableName );

		static MySQLRelationMap map = new MySQLRelationMap( new object[] {
				MySQLRelationMap.MapOp.SaveRelationPoint
				, MySQLRelationMap.MapOp.FollowToChild
				, "cardset_range_in_pack"
				, MySQLRelationMap.MapOp.FollowToParent
				, "pack_has_cardset_range"
				, MySQLRelationMap.MapOp.SaveRelationPoint
			} );



		public CardsetRangePack()
		{
		}

		public CardsetRangePack( DataSet dataset )
			: base( null
					, dataset
					, dataset.Tables[CardsetRange.TableName]
					,  map.ToString()
					//, "./session_has_game_group$\\game_group_in_session$/game_group_has_pack$\\pack_in_game_group$"
                    , false // add number column (table name is bad, so we define our own)
                    , false // auto fill
                    , null //, new DataColumn[] { new DataColumn( NameColumn, typeof( string ) )
					//					, new DataColumn( SessionPackOrder.NumberColumn, typeof( int ) ) }
			)
		{
		}
	}

}
