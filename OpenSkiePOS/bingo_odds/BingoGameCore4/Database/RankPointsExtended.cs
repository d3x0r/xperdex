using System.Data;
using OpenSkieScheduler3;
using OpenSkieScheduler3.Relations;
using xperdex.classes;

namespace BingoGameCore4.Database
{
	[MySQLPersistantTable]
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
			Columns.Add( OpenSkieScheduler3.Relations.SessionGame.PrimaryKey, typeof( int ) );
			Columns.Add( "type", typeof( int ) );
			Columns.Add( "points", typeof( int ) );
			//Columns.Add( OpenSkieScheduler.SessionTable.PrimaryKey, typeof( int ) );
			if( relate )
			{
				schedule.Tables.Add( this );
				ParentRelations.Add( new System.Data.DataRelation( "points_for_game"
					, schedule.session_games.Columns[SessionGame.PrimaryKey]
					, Columns[SessionGame.PrimaryKey] ) );
			}
		}

		
		public RankPointsExtended()
		{
			base.TableName = TableName;
			//this.schedule = OpenSkieSchedule.data;
			//connection = OpenSkieScheduler.OpenSkieSchedule.data.schedule_dsn;
			AddColumns( false );
		}
		

		public RankPointsExtended( OpenSkieScheduler3.ScheduleDataSet schedule )
		{
			base.TableName = TableName;
			this.schedule = schedule;
			connection = schedule.schedule_dsn;
			AddColumns( true );
		}
	}
}
