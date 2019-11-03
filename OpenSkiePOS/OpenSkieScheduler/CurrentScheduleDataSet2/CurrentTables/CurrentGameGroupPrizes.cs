using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace OpenSkieScheduler3.Relations
{
	public class CurrentGameGroupPrizes : CurrentObjectTableView
	{
		new public static readonly String TableName = CurrentObjectTableView.TableName( PackGroupPrizeRelation.TableName );

        public CurrentGameGroupPrizes()
            : base( null, PackGroupPrizeRelation.TableName )
        {
        }

		public CurrentGameGroupPrizes( DataSet set )
			: base( set, PackGroupPrizeRelation.TableName )
		{
		}

		public override string GetDisplayMember( DataRow Relation )
		{
			DataRow row_packs = Relation.GetParentRow( "prize_level_in_pack_group" );
			DataRow row_group = Relation.GetParentRow( "pack_group_has_prize_level" );
			return Relation[PackGroupPrizeRelation.NumberColumn]+". " + row_group[PackGroupTable.NameColumn] + ":" + row_packs[PrizeLevelNames.NameColumn].ToString();
		}
	}

	public class CurrentGameGroupPrizePacks : CurrentObjectTableView
	{
		new public static readonly String TableName = CurrentObjectTableView.TableName( GameGroupPrizePacks.TableName );

        public CurrentGameGroupPrizePacks()
            : base( null, GameGroupPrizePacks.TableName )
        {
        }

        public CurrentGameGroupPrizePacks( DataSet set )
            : base( set, GameGroupPrizePacks.TableName )
        {
        }

        public override string GetDisplayMember( DataRow Relation )
		{
			DataRow row_packs = Relation.GetParentRow( "pack_in_game_group_prize_level" );
			DataRow row_group_prize = Relation.GetParentRow( "game_group_prize_level_has_pack" );
			DataRow row_group = row_group_prize.GetParentRow( "game_group_has_prize_level" );
			DataRow row_prize = row_group_prize.GetParentRow( "prize_level_in_game_group" );
			return Relation[GameGroupPrizePacks.NumberColumn] + ". " + ( row_group == null ? "<NULL>" : row_group[PackGroupTable.NameColumn] ) + ":" + row_prize[PrizeLevelNames.NameColumn] + ":" + row_packs[PackTable.NameColumn].ToString();
		}
	}

}
