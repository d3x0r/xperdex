using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using xperdex.classes;

namespace OpenSkieScheduler3.Relations
{
#if asdfasdf
	public class CurrentSessionGamePackPrize: CurrentObjectTableView
	{
		new public static readonly String TableName = CurrentObjectTableView.TableName( SessionPrizeTable.TableName );
		new public static readonly String NameColumn = XDataTable.Name( TableName );

		XDataTable<DataRow> source_table;
		ScheduleDataSet schedule;

        public CurrentSessionGamePackPrize()
            : base( null, SessionPrizeTable.TableName )
        {
        }
		public CurrentSessionGamePackPrize( DataSet set )
			: base( set, SessionPrizeTable.TableName, true )
		{
			schedule = set as ScheduleDataSet;
			Columns.Add( new DataColumn( PrizeLevelNames.PrimaryKey, typeof( int ) ) );
			Columns.Add( new DataColumn( GameTable.PrimaryKey, typeof( int ) ) );
			Columns.Add( new DataColumn( "Prize", typeof( Money ) ) );
			source_table = set.Tables[SessionPrizeTable.TableName] as XDataTable<DataRow>;
		}

		public override string GetDisplayMember( DataRow Relation )
		{
			return "PRIZE!";
		}


		DataRow current_session_macro_session;
		DataRow current_session_game_group;

		new public DataRow Current
		{
			set
			{
				if( value != null )
				{

					if( value.Table.TableName == SessionDayMacroSessionTable.TableName )
					{
						current_session_macro_session = value;
					}


					if( current_session_game_group == null )
						return;
					if( current_session_macro_session == null )
						return;
				}

				DataRow game_group = null;
				DataRow session = null;
				if( current_session_game_group != null )
				{
					game_group = current_session_game_group.GetParentRow( "game_group_in_session" );
					session = current_session_game_group.GetParentRow( "session_has_game_group" );
				}

				//Clear();

			}
		}

	}
#endif
}
