using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using xperdex.classes;
using OpenSkieScheduler3.BingoGameDefs;

namespace OpenSkieScheduler3.Relations
{
	/// <summary>
	/// Represents the currently selected Pack's Cardset Ranges.
	/// </summary>
	public class CurrentPackCardsetRanges: CurrentObjectDataView
	{
		new public static readonly String TableName = CurrentObjectTableView.TableName( PackCardsetRange.TableName );
        public CurrentPackCardsetRanges(): base( null, PackCardsetRange.TableName )
        {
           
        }
		public CurrentPackCardsetRanges( DataSet set )
			: base( set, PackCardsetRange.TableName )
		{

		}
		/*
		public override string GetDisplayMember( DataRow row )
		{
			//cardset_info["friendly_name"] + "(" + cardset_range[CurrentCardsetRanges.DisplayName] + ")";
			DataRow row_range = row.GetParentRow( "cardset_range_in_pack" );

			DataRow cardset_info = row_range.GetParentRow( "cardset_has_cardset_range" );

			return cardset_info["friendly_name"] + "(" + row_range[CardsetRange.NameColumn] + ")"; ;
		}
		 */
	}

	/// <summary>
	/// Represents the currently selected Cardset Ranges' Packs.
	/// </summary>
	public class CurrentCardsetRangePack : CurrentObjectTableView
	{
		new public static readonly String TableName = CurrentObjectTableView.TableName( CardsetRangePack.TableName );
		public CurrentCardsetRangePack()
			: base( null, CardsetRangePack.TableName )
		{

		}
		public CurrentCardsetRangePack( DataSet set )
			: base( set, CardsetRangePack.TableName )
		{

		}
		public override string GetDisplayMember( DataRow row )
		{
			//cardset_info["friendly_name"] + "(" + cardset_range[CurrentCardsetRanges.DisplayName] + ")";
			DataRow row_range = row.GetParentRow( "cardset_range_pack_meta_pack_info" );
			//DataRow cardset_range_row = row.GetParentRow( "cardset_range_pack_meta_cardset_ranges" );
			//DataRow cardset_info = cardset_range_row.GetParentRow( "cardset_has_cardset_range" );

			return row_range[PackTable.NameColumn].ToString();
		}
	}
}
