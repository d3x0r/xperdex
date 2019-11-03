using System;
using System.Collections.Generic;
using System.Text;
using xperdex.classes;
using System.Data;
using System.Windows.Forms;

namespace OpenSkieScheduler3.Relations
{
    [SchedulePersistantTable]
	public class SessionGame : MySQLRelationTable2<SessionGame.SessionGameDataRow, SessionTable, GameTable>
    {
        new public static readonly String TableName = "session_game";
		new public static readonly String PrimaryKey = XDataTable.ID( TableName );
		new public static readonly String NameColumn = XDataTable.Name( TableName );
		new public static readonly String NumberColumn = "game_number";

        static string color_name;
        public static String[] DataColumns = { 
			"game_number", 
			"ball_timer", 
			"progressive", 
			"bonanza", 
			"wild", 
			"double_wild", 
			"blind", 
			"single_hotball",
			"game_part_number",
			"callers_choice"
												 };

		public class SessionGameDataRow : DataRow
		{
			public SessionGameDataRow( global::System.Data.DataRowBuilder rb ) : 
                    base(rb) 
			{
            }

			public override string ToString()
			{
				bool option_use_part;
				option_use_part = INI.File( "schedule.ini" )["Schedule Options"]["Game default name uses part number", 1].Bool;

				//option_use_part = Options.File( "schedule.ini" )["Schedule Options"]["Game default name uses part number", true].Bool;
				ScheduleDataSet schedule = Table.DataSet as ScheduleDataSet;
				DataRow game = GetParentRow( "game_in_session" );
				DataRow[] patterns = GetChildRows( schedule.game_patterns.ChildrenOfParent );
				String gamename = this[SessionGame.NameColumn].ToString();
				if( gamename == null || gamename.Length == 0 )
				{
					if( option_use_part )
						gamename = "Game " + this["game_part_number"];
					else
						gamename = "Game " + this[SessionGame.NumberColumn];
				}
				return ( ( !option_use_part ) ? String.Format( "{0,3}.\t", this[SessionGame.NumberColumn] )
											: String.Format( "[{0,4}]\t", this["game_part_number"] ) )
					+ ( gamename )
					+ "\t"
					+ ( this["progressive"].GetType() != typeof( DBNull ) && Convert.ToBoolean( this["progressive"] ) ? "(P)" : "" )
					+ ( this["single_hotball"].GetType() != typeof( DBNull ) && Convert.ToBoolean( this["single_hotball"] ) ? "(H)" : "" )
					+ ( this["wild"].GetType() != typeof( DBNull ) && Convert.ToBoolean( this["wild"] ) ? "(W)" : "" )
					+ ( this["double_wild"].GetType() != typeof( DBNull ) && Convert.ToBoolean( this["double_wild"] ) ? "(2W)" : "" )
					+ ( this["blind"].GetType() != typeof( DBNull ) && Convert.ToBoolean( this["blind"] ) ? "(Bld)" : "" )
					+ ( this["bonanza"].GetType() != typeof( DBNull ) && Convert.ToBoolean( this["bonanza"] ) ? "<Bon>" : "" )
					+ ( this["callers_choice"].GetType() != typeof( DBNull ) && Convert.ToBoolean( this["bonanza"] ) ? "<CC>" : "" )
					+ "\t"
					+ ( ( patterns.Length > 0 ) ? patterns[0].GetParentRow( schedule.game_patterns.ParentOfChild )[PatternDescriptionTable.NameColumn] : "<No Pattern>" )
					;
			}
		}
#if a1
		public SessionGameDataRow this[int index]
		{
			get
			{
				return ( (SessionGameDataRow)( this.Rows[index] ) );
			}
		}
#endif
        public SessionGame(  DataSet dataset ) : base( dataset )
        {
			DataColumn dc;
			Columns.Add( new DataColumn( NameColumn, typeof( String ) ) );
            Columns.Add( dc = new DataColumn( "game_part_number", typeof( String ) ) );
			dc.MaxLength = 8;
			Columns.Add( new DataColumn( "ball_timer", typeof( int ) ) );
			Columns.Add( new DataColumn( "progressive", typeof( bool ) ) );
			Columns.Add(  new DataColumn( "bonanza", typeof( bool ) ) );
			Columns.Add(  new DataColumn( "wild", typeof( bool ) ) );
			Columns.Add(  new DataColumn( "double_wild", typeof( bool ) ) );
			Columns.Add(  new DataColumn( "blind", typeof( bool ) ) );
			Columns.Add( new DataColumn( "poker", typeof( bool ) ) );
			Columns.Add( new DataColumn( "special", typeof( bool ) ) );
			Columns.Add( new DataColumn( "single_hotball", typeof( bool ) ) );
			Columns.Add( new DataColumn( "callers_choice", typeof( bool ) ) );
			Columns.Add( new DataColumn( ColorInfoTable.PrimaryKey, XDataTable.DefaultAutoKeyType ) );

            if( dataset != null )
            {
                DataTable child;
                dataset.Relations.Add( SessionGame.color_name = MySQLDataTable.StripPlural( MySQLDataTable.StripInfo( SessionGame.TableName ) )
                    + "_is_"
                    + MySQLDataTable.StripPlural( MySQLDataTable.StripInfo( ColorInfoTable.TableName ) )
                    , dataset.Tables[ColorInfoTable.TableName].Columns[ColorInfoTable.PrimaryKey]
                    , ( child = dataset.Tables[SessionGame.TableName] ).Columns[ColorInfoTable.PrimaryKey]
                    );
                ForeignKeyConstraint fkc = child.Constraints[color_name] as ForeignKeyConstraint;
                if( fkc != null )
                    fkc.DeleteRule = Rule.SetNull;
            }
			number_column = NumberColumn;
			// these are event catches to make sure numbers track correctly.
			CloneRow += new MySQLRelationTable.OnCloneRow( SessionGame_CloneRow );
			AddingRow += new MySQLRelationTable.OnNewRow( initrow );
            ColumnChanged += new DataColumnChangeEventHandler( SessionGame_ColumnChanged );
        }

        void SessionGame_CloneRow( DataRow row, DataRow original )
        {
            foreach( String colname in DataColumns )
            {
                row[colname] = original[colname];
            }
        }

		void UpdatePartNumbers( DataRow session )
		{
			DataRow[] these_rows = this.Select( SessionTable.PrimaryKey + "='" + session[SessionTable.PrimaryKey] + "'", "game_number" );

			int row_id;
			for( row_id = 0; row_id < these_rows.Length; row_id++ )
			{
				DataRow session_game = these_rows[row_id];
				object progressive_flag = session_game["progressive"];
				these_rows[row_id][NumberColumn] = row_id + 1;
				if( progressive_flag == DBNull.Value )
					progressive_flag = false;
				if( row_id == these_rows.Length )
				{
					throw new Exception( "Session_game row passed is not in the table" );
				}
				if( row_id == 0 )
				{
					if( Convert.ToBoolean( progressive_flag ) )
						session_game["game_part_number"] = "1-A";
					else
						session_game["game_part_number"] = "1";
				}
				else
				{
					int game_number;
					string tmp = these_rows[row_id - 1]["game_part_number"].ToString();
					int dash_index;
					char part = tmp[dash_index = tmp.IndexOf('-') + 1];

					if( Convert.ToBoolean( these_rows[row_id - 1]["progressive"] ) )
					{
						game_number = Convert.ToInt32( tmp.Substring( 0, dash_index - 1 ) );
						session_game["game_part_number"] = game_number + "-" + (char)( part + 1 );

					}
					else
					{
						if( dash_index > 0 )
							game_number = Convert.ToInt32( tmp.Substring( 0, dash_index - 1 ) );
						else
							game_number = Convert.ToInt32( tmp );
						if( Convert.ToBoolean( progressive_flag ) )
							session_game["game_part_number"] = ( game_number + 1 ) + "-A";
						else
							session_game["game_part_number"] = ( game_number + 1 ).ToString();
					}
				}
			}
		}

		public void UpdateAllParts( )
		{
			ScheduleDataSet schedule = DataSet as ScheduleDataSet;
			if( schedule != null )
			{
				foreach( DataRow session in schedule.sessions.Rows )
				{
					UpdatePartNumbers( session );
				}
			}

		}

        public bool updating_number = false;
        void SessionGame_ColumnChanged( object sender, DataColumnChangeEventArgs e )
        {
			if( filling )
				return;
			if( e.Column.ColumnName == "progressive" && !e.ProposedValue.Equals(e.Row["progressive"] ) )
				UpdatePartNumbers( e.Row );
        }



        void SessionGame_FixupRow( DataRow row )
        {
            if( updating_number )
                return;
            try
            {
				UpdatePartNumbers( row );

                object max_number = Compute( "Max(" + NumberColumn + ")"
                    , "session_id='" + row["session_id"]
                    + "' and "
                    + NumberColumn + "<" + row[NumberColumn]
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
                updating_number = true;
                if( Convert.ToInt32( row[NumberColumn] ) != new_number )
                    row[NumberColumn] = new_number;
                updating_number = false;
            }
            catch
            {
                updating_number = true;
                row[NumberColumn] = 1;
                updating_number = false;
            }

            //throw new NotImplementedException();
        }

        void initrow( DataRow row )
        {
            try
            {
                SessionGame_FixupRow( row );
            }
            catch
            {
                row[NumberColumn] = 1;
            }
            row["ball_timer"] = 0;
            row["progressive"] = false;
            row["bonanza"] = false;
            row["wild"] = false;
            row["single_hotball"] = false;
			row["callers_choice"] = false;
        }

        /// <summary>
        /// need a copy constructor... (GetChanges)
        /// </summary>
        public SessionGame()
        {
        }

        public DataRow[] GetGroupsFromSession( DataRow dr_session )
        {
            return dr_session.GetChildRows( children_of_parent );
        }

        public DataRow GetGame( DataRow group_game )
        {
            return group_game.GetParentRow( "game_in_session" );
        }

        public DataRow[] GetPackGroup( DataRow group_game )
        {
            return group_game.GetChildRows( "session_game_has_pack_group" );
        }

		public DataRow[] GetPacks( DataRow session_game )
		{
			DataRow[] game_groups = GetPackGroup( session_game );
			foreach( DataRow tmp in game_groups )
			{
				List<DataRow> result = new List<DataRow>();
				DataRow gg = tmp.GetParentRow( "pack_group_in_session_game" );
				DataRow[] pack_rows = gg.GetChildRows( "pack_group_has_pack" );
				foreach( DataRow pack_row in pack_rows )
				{
					result.Add( pack_row.GetParentRow( "pack_in_pack_group" ) );
				}
				return result.ToArray();
			}
			return null;
		}

		public DataRow[] GetGameGroupPacks( DataRow session_game )
		{
			DataRow[] game_groups = GetPackGroup( session_game );
			foreach( DataRow tmp in game_groups )
			{
				List<DataRow> result = new List<DataRow>();
				DataRow gg = tmp.GetParentRow( "session_game_group_in_session_game" );
				DataRow[] pize_rows = gg.GetChildRows( "game_group_has_prize_level" );
				foreach( DataRow prize_row in pize_rows )
				{
					DataRow[] rows = prize_row.GetChildRows( "game_group_prize_level_has_pack" );
					foreach( DataRow row in rows )
					{
						result.Add( row );
					}
				}
				return result.ToArray();
			}
			return null;
		}


		/// <summary>
		/// Return a game_info row for the name specified
		/// </summary>
		/// <param name="game_name">name of the game to return with</param>
		/// <returns>NULL if no game</returns>
		public DataRow GetGame( DataRow session, int game_number )
		{
			DataRow[] these_session_games = session.GetChildRows( ChildrenOfParent );
			foreach( DataRow row in these_session_games )
			{
				if( Convert.ToInt32( row[SessionGame.NumberColumn] ) == game_number )
					return row;
			}
			return null;
		}


		public DataRow NewGame( DataRow session, int game_number )
		{
			DataRow result = GetGame( session, game_number );
			if( result != null )
				return result;


			int count = game_number;

			DataRow[] session_games = Select(
				SessionTable.PrimaryKey + "='" + session[SessionTable.PrimaryKey] + "'"
				, XDataTable.Number( this ) );
			if( session_games.Length < count )
			{
				int idx;
				for( idx = session_games.Length; idx < count; idx++ )
				{
					//DataRow game_row = schedule.games.GetGame( "Game " + ( idx + 1 ) );
					DataRow newgame = AddGroupMember( session, null );
					result = newgame;
				}
			}
			else
			{
				result = session_games[game_number - 1];
			}
			return result;
		}

		/// <summary>
		/// This row passed is a session_game row
		/// </summary>
		/// <param name="game"></param>
		/// <returns></returns>
		public DataRow[] GetPatterns( DataRow session_game )
		{
			if( session_game.Table.TableName == SessionGame.TableName )
			{
				ScheduleDataSet schedule = session_game.Table.DataSet as ScheduleDataSet;
				return session_game.GetChildRows( schedule.game_patterns.ChildrenOfParent );
			}
			return null;
		}


    }
}
