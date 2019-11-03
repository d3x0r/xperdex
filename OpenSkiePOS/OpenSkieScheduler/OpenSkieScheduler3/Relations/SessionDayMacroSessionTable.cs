using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
//using Csx.kind_classes;
using System.Data.Odbc;
using xperdex.classes;
using OpenSkieScheduler3.Relations;
using OpenSkieScheduler3.BingoGameDefs;

namespace OpenSkieScheduler3
{
	[SchedulePersistantTable]
    /// <summary>
    /// Describes what sessions are in a Session-Day Macro
    /// </summary>
    public class SessionDayMacroSessionTable: MySQLRelationTable2<SessionDayMacroSessionTable.SessionMacroSessionRow,SessionMacroTable,SessionTable>
    {
		new public static readonly String TableName = MySQLRelationTable2<DataRow,SessionMacroTable, SessionTable>.RelationName;
		public static readonly string NameColumn = XDataTable.Name( TableName );
		new public static readonly string NumberColumn = "session_number";//Number( TableName );
		new public static readonly string PrimaryKey = XDataTable.ID( TableName );

		public bool return_session_only;

		public class SessionMacroSessionRow : DataRow
		{
			public SessionMacroSessionRow( global::System.Data.DataRowBuilder rb ) :
				base( rb )
			{
			}

			public override string ToString()
			{
				SessionDayMacroSessionTable table = this.Table as SessionDayMacroSessionTable;
				if( table.return_session_only )
				{
					DataRow row_session = this.GetParentRow( "session_in_session_macro" );
					return row_session[SessionTable.NameColumn].ToString();
				}
				else
				{
					DataRow row_session = this.GetParentRow( "session_in_session_macro" );
					DataRow session_type = this.GetParentRow( "session_macro_session_type" );
					String session_type_name = ( session_type == null ) ? "<Undefined>" : session_type[SessionTypeTable.NameColumn].ToString();
					//if( session_type == null )
					//	row[SessionTypeTable.PrimaryKey] = schedule.session_types.GetDefault();
					DataRow Prizes = this.GetParentRow( "session_macro_prize_exceception" );
					String session_prize_name = ( Prizes == null ) ? "<Undefined>" : Prizes[PrizeExceptionSet.NameColumn].ToString();

					DataRow Prices = this.GetParentRow( "session_macro_price_exceception" );
					String session_price_name = ( Prices == null ) ? "<Undefined>" : Prices[PriceExceptionSet.NameColumn].ToString();


					if( this[SessionDayMacroSessionTable.NameColumn].GetType() == typeof( DBNull ) ||
						this[SessionDayMacroSessionTable.NameColumn].ToString().Length == 0 )
						return this[SessionDayMacroSessionTable.NumberColumn] + ") "
							+ session_type_name
							+ ":" + row_session[XDataTable.Name( row_session.Table.TableName )].ToString()
							+ "[" + session_price_name + "]"
							+ "[" + session_prize_name + "]"
							;

					return this[SessionDayMacroSessionTable.NumberColumn] + ") "
						+ session_type_name
						+ ":" + this[SessionDayMacroSessionTable.NameColumn].ToString()
						+ "<" + row_session[XDataTable.Name( row_session.Table.TableName )].ToString() + ">"
						+ "[" + session_price_name + "]"
						+ "[" + session_prize_name + "]"
						;
				}
			}

			public String DisplayMember
			{
				get
				{
					return this.ToString();
				}
			}
		}


		public SessionDayMacroSessionTable()
		{
            // these tables should also forego event trigger...
			base.TableName = TableName + "(tmp)";
		}

		public string price_relation;
		public string prize_relation;
		public string session_type_relation;

		public SessionDayMacroSessionTable( ScheduleDataSet dataset )
			: base( dataset )
        {
			Columns.Add( NameColumn, typeof( String ) );
			Columns.Add( PrizeExceptionSet.PrimaryKey, XDataTable.DefaultAutoKeyType );
			Columns.Add( PriceExceptionSet.PrimaryKey, XDataTable.DefaultAutoKeyType );
			Columns.Add( SessionTypeTable.PrimaryKey, XDataTable.DefaultAutoKeyType );

            if( !dataset.Tables.Contains( ( this as DataTable ).TableName ) )
                dataset.Tables.Add( this );

			dataset.Relations.Add( prize_relation = "session_macro_prize_exceception"
					, dataset.Tables[PrizeExceptionSet.TableName].Columns[PrizeExceptionSet.PrimaryKey]
					, this.Columns[PrizeExceptionSet.PrimaryKey]
				);
			dataset.Relations.Add( price_relation = "session_macro_price_exceception"
					, dataset.Tables[PriceExceptionSet.TableName].Columns[PriceExceptionSet.PrimaryKey]
					, this.Columns[PriceExceptionSet.PrimaryKey]
				);
			dataset.Relations.Add( session_type_relation = "session_macro_session_type"
					, dataset.Tables[SessionTypeTable.TableName].Columns[SessionTypeTable.PrimaryKey]
					, this.Columns[SessionTypeTable.PrimaryKey]
				);

		}

		/// <summary>
		/// Returns the session from a session_macro_session datarow...
		/// </summary>
		/// <param name="row">row from session_macro_session...</param>
		/// <returns></returns>
		public DataRow GetSession( DataRow row )
		{
			return row.GetParentRow( parent_of_child );
		}

		public DataRow[] GetSessions( DataRow session_macro )
		{
			return session_macro.GetChildRows( children_of_parent );
		}

		public DataRow GetSession( DataRow session_macro, int session_number )
		{
			if( session_macro != null )
			{
				DataRow[] sessions = GetSessions( session_macro );
                String number_col = SessionDayMacroSessionTable.NumberColumn;
                
                foreach( DataRow row in sessions )
				{
                    if( ( row[ number_col ].GetType() == typeof( DBNull ) ) ||
						( Convert.ToInt32( row[number_col] ) != session_number ) )
						continue;
					return row.GetParentRow( parent_of_child );
				}
			}
			return null;
		}


		/// <summary>
		/// returns an array of SessionGameGroupGameOrder datarows
		/// </summary>
		/// <param name="session_macro"></param>
		/// <param name="session"></param>
		/// <returns></returns>
		public DataRow[] GetGames( DataRow session_macro, int session )
		{
			DataRow dr_session = GetSession( session_macro, session );
			if( dr_session != null )
			{
				// I would need this name to get to the table through the relation...
				// so I might as well just use the name and get the result.
				DataRow[] game_list = dr_session.GetChildRows( "session_game_group_game_meta_session_info" );
				//DataRow[] result = new DataRow[game_list.Length];
				//int index = 0;
				//foreach( DataRow game in game_list )
				//   result[index++] = game.GetParentRow( "session_game_group_game_meta_game_info" );
				return game_list;
			}
			return null;
		}

		/// <summary>
		/// returns an array of SessionGameGroupGameOrder datarows
		/// </summary>
		/// <param name="session">Data Row from sessions</param>
		/// <returns></returns>
		public DataRow[] GetGames( DataRow dr_session )
		{
			if( dr_session != null )
			{
				// I would need this name to get to the table through the relation...
				// so I might as well just use the name and get the result.
				DataRow[] game_list = dr_session.GetChildRows( "session_game_group_game_meta_session_info" );
				//DataRow[] result = new DataRow[game_list.Length];
				//int index = 0;
				//foreach( DataRow game in game_list )
				//   result[index++] = game.GetParentRow( "session_game_group_game_meta_game_info" );
				return game_list;
			}
			return null;
		}

		public DataRow[] GetPacks( DataRow session_macro )
		{
			//schedule.session_game_group_game_order.GetGameGroupPacks( group_game )
			DataRow dr_session = GetSession( session_macro );
			
			throw new Exception( "The method or operation is not implemented." );
		}

	}
}
