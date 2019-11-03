using System;
using System.Collections.Generic;
using System.Text;
using xperdex.classes;
using OpenSkieScheduler;
using OpenSkieScheduler.Relations;
using System.Data;

namespace BingoGameCore3.Database
{
	public class RankPointsExtended : MySQLDataTable
	{
		public class PointTypeDataTable : DataTable
		{
			public PointTypeDataTable()
			{
				Columns.Add( "ID", typeof( int ) );
				Columns.Add( "name", typeof( string ) );

				DataRow dr;
				dr = NewRow();
				dr[0] = "1";
				dr[1] = "Electronic";
				Rows.Add( dr );
				dr = NewRow();
				dr[0] = "2";
				dr[1] = "Paper";
				Rows.Add( dr );
				AcceptChanges();
			}
		}

		public new static readonly string TableName = "rate_rank_points_extended";
		ScheduleDataSet schedule;

		static public PointTypeDataTable types = new PointTypeDataTable();


		void AddColumns( bool relate )
		{
			base.AddDefaultColumns( true, true, false );
			Columns.Add( OpenSkieScheduler.Relations.SessionGameGroupGameOrder.PrimaryKey, typeof( int ) );
			Columns.Add( "type", typeof( int ) );
			Columns.Add( "points", typeof( int ) );
			//Columns.Add( OpenSkieScheduler.SessionTable.PrimaryKey, typeof( int ) );
			if( relate )
			{
				schedule.Tables.Add( this );
				ParentRelations.Add( new System.Data.DataRelation( "points_for_game"
					, schedule.session_game_group_game_order.Columns[SessionGameGroupGameOrder.PrimaryKey]
					, Columns[SessionGameGroupGameOrder.PrimaryKey] ) );
			}
		}

		
		public RankPointsExtended()
		{
			base.TableName = TableName;
			//this.schedule = OpenSkieSchedule.data;
			//connection = OpenSkieScheduler.OpenSkieSchedule.data.schedule_dsn;
			AddColumns( false );
		}
		

		public RankPointsExtended( OpenSkieScheduler.ScheduleDataSet schedule )
		{
			base.TableName = TableName;
			this.schedule = schedule;
			connection = schedule.schedule_dsn;
			AddColumns( true );
			Create();
			Fill();
		}
	}
}
