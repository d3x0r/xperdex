using System;
using System.Collections.Generic;
using System.Text;
using OpenSkieScheduler3.Relations;
using System.Data;
using OpenSkieScheduler3;

namespace OpenSkie.Scheduler.CurrentTables
{
	public class CurrentPackPrizeLevel:  CurrentObjectTableView
	{
		new public static readonly String TableName = CurrentObjectTableView.TableName( PackPrizeLevel.TableName );

		public CurrentPackPrizeLevel()
			: base( null, PackPrizeLevel.TableName )
        {
           
        }

		public CurrentPackPrizeLevel( DataSet set )
			: base( set, PackPrizeLevel.TableName )
		{

		}

		public override string GetDisplayMember( DataRow row )
		{
			DataRow row_prize = row.GetParentRow( "prize_level_in_pack" );
			return row_prize[PrizeLevelNames.NameColumn].ToString();
		}
	}
}
