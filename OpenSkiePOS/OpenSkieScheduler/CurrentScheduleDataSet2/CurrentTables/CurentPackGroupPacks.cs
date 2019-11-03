using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using xperdex.classes;

namespace OpenSkieScheduler3.Relations
{
	public class CurrentPackGroupPacks : CurrentObjectDataView
	{
		new public static readonly String TableName = CurrentObjectTableView.TableName( PackGroupPackRelation.TableName );
		public CurrentPackGroupPacks()
			: base( null, PackGroupPackRelation.TableName )
        {
			
        }
		public CurrentPackGroupPacks( DataSet set )
			: base( set, PackGroupPackRelation.TableName )
		{
		}

	}

	/// <summary>
	/// Used when packs realte to game_group-prize_level
	/// </summary>
	public class CurrentMetaGameGroupPacks : CurrentObjectTableView
	{
		new public static readonly String TableName = CurrentObjectTableView.TableName( PackGroupPackMetaRelation.TableName );

        public CurrentMetaGameGroupPacks()
            : base( null, PackGroupPackMetaRelation.TableName )
        {
        }

		public CurrentMetaGameGroupPacks( DataSet set )
			: base( set, PackGroupPackMetaRelation.TableName, true )
		{
		}

		public override string GetDisplayMember( DataRow Relation )
		{
			//DataRow row_packs = Relation.GetParentRow( "pack_in_game_group_prize_level" );
			DataRow row_packs = Relation.GetParentRow( "game_group_pack_meta_pack_info" );
			DataRow row_group_prize = Relation.GetParentRow( "game_group_pack_meta_game_group_prize_level" );
			DataRow row_group = Relation.GetParentRow( "game_group_pack_meta_game_group_info" );
			DataRow row_prize = row_group_prize.GetParentRow( "prize_level_in_game_group" );
			return row_group[PackGroupTable.NameColumn] + ":" + row_prize[PrizeLevelNames.NameColumn] + ":" + row_packs[PackTable.NameColumn].ToString();
			return row_packs[PackTable.NameColumn].ToString();
		}
	}
}
