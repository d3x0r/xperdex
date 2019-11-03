using System;
using System.Data;
using xperdex.classes;

namespace OpenSkieScheduler3
{
	[SchedulePersistantTable( DefaultFill="DefaultFill" )]
	public class SessionTable : MySQLDataTable<SessionTable.SessionRow>
    {
		public class SessionRow : DataRow
		{
			public SessionRow( global::System.Data.DataRowBuilder rb ) : 
                    base(rb) 
			{
            }

			public override string ToString()
			{
				if( Table.DataSet != null )
				{
					ScheduleDataSet schedule = Table.DataSet as ScheduleDataSet;
					if( schedule != null )
						if( schedule.snapshot )
						{
							return this[SessionTable.NameColumn].ToString();
						}
				}
				return this[SessionTable.NameColumn].ToString();
			}

		}


		new public static readonly String TableName = "session_info";
		public static readonly String NameColumn = XDataTable.Name( TableName );
		new public static readonly String PrimaryKey = XDataTable.ID( TableName );

		void AddColumns(bool add_id)
		{
			DataColumn dc;
			AddDefaultColumns( true, add_id, true );
			//dc = Columns.Add( NameColumn, typeof( string ) );
			//this.Columns.
			dc = Columns.Add( "session_board_size", typeof( int ) );
			dc = Columns.Add( "special", typeof( int ) );
			dc = Columns.Add( "max_cards", typeof( int ) );
			dc = Columns.Add( "max_bonanza", typeof( int ) );
			dc = Columns.Add( "last_bonanza", typeof( int ) );
			dc = Columns.Add( "bonus_size", typeof( int ) );
		}

		public SessionTable()
		{
			base.TableName = "(tmp)" + TableName;
			AddColumns(true);
		}
		public SessionTable( ScheduleDataSet dataSet )
			: base( null, Names.schedule_prefix, TableName, true, true )
		{
			// base initializer adds _id 
			AddColumns(false);
			if( dataSet.snapshot )
				Columns[NameColumn].Unique = false;
			if( !dataSet.Tables.Contains( ( this as DataTable ).TableName ) )
			{
				dataSet.Tables.Add( this );
			}
		}
		DataRow GetSession( int id )
		{
			foreach( DataRow dr in this.Rows )
				if( Convert.ToInt32( dr[PrimaryKey] ) == id )
					return dr;
			return null;
		}

		/// <summary>
		/// Will create a new session with the specified name, or it will result with the existing session that already has that name.
		/// </summary>
		/// <param name="name">Session Name</param>
		/// <returns>session with the name specified, creating the row if it doesn't exist.</returns>
        public DataRow NewSession(String name)
        {
			return NewSimpleName( name );
        }

		/// <summary>
		/// Returns a DataRow[] of the game_info's in this session
		/// </summary>
		/// <returns></returns>
		public DataRow[] Games( DataRow _row )
		{
			DataRow[] games_rel = _row.GetChildRows( _row.Table.ChildRelations["session_has_game"] );
			DataRow[] games = new DataRow[games_rel.Length];
			int i = 0;
			if( games_rel.Length > 0 )
			{
				DataRelation rel = games_rel[0].Table.ParentRelations["game_in_session"];
				foreach( DataRow dr in games_rel )
				{
					games[i++] = dr.GetParentRow(rel);
				}
			}
			return games;
		}

		public DataRow[] Prizes( DataRow _row )
		{
			//_row.Table.CreateDataReader();
			DataRow[] prizes_rel = _row.GetChildRows( _row.Table.ChildRelations["session_has_prize_level"] );
			DataRow[] prizes = new DataRow[prizes_rel.Length];
			int i = 0;
			if( prizes_rel.Length > 0 )
			{
				DataRelation rel = prizes_rel[0].Table.ParentRelations["prize_level_in_session"];
				foreach( DataRow dr in prizes_rel )
				{
					prizes[i++] = dr.GetParentRow( rel );
				}
			}
			return prizes;
		}

		public void DefaultFill()
		{
			if( Rows.Count == 0 )
			{
				DataRow nogroup_row = NewRow();
				if( Columns[PrimaryKey].DataType == typeof( Guid ) )
					nogroup_row[PrimaryKey] = Guid.Empty;
				nogroup_row[NameColumn] = "No Session";
				Rows.Add( nogroup_row );
				RowDeleting += new DataRowChangeEventHandler( SessionTable_RowDeleting );
			}
		}

		void SessionTable_RowDeleting( object sender, DataRowChangeEventArgs e )
		{
			if( e.Row[PrimaryKey].Equals( Guid.Empty ) || e.Row[NameColumn].Equals( "No Session" ) )
				throw new Exception( "Cannot delete from empty Session list." );
		}
	}
}
