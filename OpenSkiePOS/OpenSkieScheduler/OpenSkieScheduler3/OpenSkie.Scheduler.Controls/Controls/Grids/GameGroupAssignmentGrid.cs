using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using OpenSkieScheduler3;
using OpenSkieScheduler3.Controls;
using OpenSkieScheduler3.Relations;
using xperdex.classes;

namespace OpenSkie.Scheduler.Controls.Controls.Grids
{
    public class GameGroupAssignmentGrid : DataGridView
    {
        DataTable current_data;
        List<DataRow> session_games;
        List<DataRow> session_pack_groups;
        bool filling = false;

        public GameGroupAssignmentGrid()
        {
            session_games = new List<DataRow>();
            session_pack_groups = new List<DataRow>();
            current_data = ControlList.schedule.Tables["current_game_game_group_assignment"];
            if( current_data == null )
            {
                current_data = new DataTable();
                current_data.TableName = "current_game_game_group_assignment";
                ControlList.schedule.Tables.Add( current_data );
            }

            ControlList.data.SetSessionCurrent += new ScheduleCurrents.OnSetCurrent( data_SetSessionCurrent );

			if( ControlList.schedule.session_games != null )
			{
				ControlList.schedule.session_games.RowChanged += new DataRowChangeEventHandler( session_pack_groups_RowChanged );
				ControlList.schedule.session_games.RowOrderChange += new MySQLRelationTable.OnRowOrderChange( session_games_RowOrderChange );
				ControlList.schedule.session_games.RowOrderChanged += new MySQLRelationTable.OnRowOrderChanged( session_games_RowOrderChanged );
			}
			ControlList.schedule.session_game_session_pack_group.RowChanged += new DataRowChangeEventHandler( session_pack_groups_RowChanged );
			ControlList.schedule.session_pack_groups.RowChanged += new DataRowChangeEventHandler( session_pack_groups_RowChanged );
			//this.AllowUserToAddRows = false;

			ControlList.schedule.pack_groups.RowChanged += new System.Data.DataRowChangeEventHandler( session_pack_groups_RowChanged );
            //this.AllowUserToAddRows = false;

			this.AutoGenerateColumns = true;
            this.CellValueChanged += new DataGridViewCellEventHandler( GameGroupAssignmentGrid_CellValueChanged );
			FillCurrent();

            //this.
        }

		void session_pack_groups_RowChanged( object sender, DataRowChangeEventArgs e )
		{
			if( e.Action == DataRowAction.Commit )
				return;
			if( !filling )
				FillCurrent();
		}

        void session_games_RowOrderChange()
        {
            filling = true;
        }


        void session_games_RowOrderChanged()
        {
            filling = false;
            FillCurrent();
        }

		void data_SetSessionCurrent( DataRow current )
		{
			//new current session
			if( !filling )
				FillCurrent();
		}

        void GameGroupAssignmentGrid_CellValueChanged( object sender, DataGridViewCellEventArgs e )
        {
            if( !filling )
            {
                if( e.ColumnIndex > 0 )
                {
                    DataGridViewCell c = this[e.ColumnIndex, e.RowIndex];
                    if( Convert.ToBoolean( c.Value ) )
                    {
						ControlList.schedule.session_game_session_pack_group.AddGroupMember( session_games[e.RowIndex]
							, session_pack_groups[e.ColumnIndex - 1] );
						//.GetParentRow( ControlList.schedule.session_pack_groups.ParentOfChild )
                    }
                    else
						ControlList.schedule.session_game_session_pack_group.RemoveGroupMember( session_games[e.RowIndex]
							, session_pack_groups[e.ColumnIndex - 1]);
						//.GetParentRow( ControlList.schedule.session_pack_groups.ParentOfChild ) 
                }
            }
        }
        
        void FillCurrent()
        {
            // entirely recreates the grid layout.
            if( ControlList.data.current_session != null )
            {
                SuspendLayout();
				ScheduleDataSet schedule = ControlList.schedule;
                filling = true;
				DataSource = current_data;
				AutoGenerateColumns = true;  // force this AGAIN because the designer likes to leave this off because I get a datasource?
                session_games.Clear();
                session_pack_groups.Clear();

                DataRow current_session = ControlList.data.current_session;
                current_data.Clear();
                current_data.Columns.Clear();
                DataColumn dc;
                dc = new DataColumn( "Game Name", typeof( String ) );
                dc.AllowDBNull = false;
                current_data.Columns.Add( dc );

                foreach( DataRowView session_pack_group_view in  ControlList.data.current_session_pack_groups )
                {
					DataRow session_pack_group = session_pack_group_view.Row;
					if( session_pack_group.RowState == DataRowState.Deleted )
                        continue;
					DataRow tmp_game = session_pack_group;//.GetParentRow( SessionPackGroup.TableName );
					DataRow pack_group = tmp_game.GetParentRow( ControlList.schedule.session_pack_groups.ParentOfChild );
					bool found = false;
					foreach( DataRow check_session_pack_group in session_pack_groups )
					{
						DataRow check_pack_group = check_session_pack_group.GetParentRow( schedule.session_pack_groups.ParentOfChild );
						if( pack_group == null && check_pack_group == null )
						{
							found = true;
							break;
						}
						if( pack_group != null && check_pack_group != null )
							if( check_pack_group[PackGroupTable.PrimaryKey].Equals( pack_group[PackGroupTable.PrimaryKey] ) )
							{
								found = true;
								break;
							}
					}
					if( found )//session_pack_groups.Contains( tmp_game ) )
						continue;
					session_pack_groups.Add( tmp_game );
					dc = new DataColumn( pack_group==null?"Temp<null>":pack_group[PackGroupTable.NameColumn].ToString(), typeof( bool ) );
                    dc.AllowDBNull = false;
                    dc.DefaultValue = false;
                    current_data.Columns.Add( dc );
                }
                object[] rowdata = new object[session_pack_groups.Count + 1];
                foreach( DataRowView session_game_view in ControlList.data.current_session_games )
                {
					DataRow session_game = session_game_view.Row;
                    if( session_game.RowState == DataRowState.Deleted )
                        continue;
                    int n = 0;
					DataRow game = session_game.GetParentRow( "game_in_session" );
					DataRow[] game_has_group = session_game.GetChildRows( "session_game_has_session_pack_group" );
					session_games.Add( session_game );
                    rowdata[0] = String.Format( "{0,3}. {1}"
						, session_game[SessionGame.NumberColumn]
                        , session_game[SessionGame.NameColumn] );
                    foreach( DataRow game_group in session_pack_groups )
                    {
                        rowdata[1 + n] = false;
                        foreach( DataRow game_group_in_game in game_has_group )
                        {
                            if( game_group_in_game[SessionPackGroup.PrimaryKey].Equals( game_group[SessionPackGroup.PrimaryKey] ) )
                            {
                                rowdata[1 + n] = true;
                                break;
                            }
                        }
                        n++;
                    }
                    current_data.Rows.Add( rowdata );
                }
                filling = false;
				ResumeLayout();
            }
        }

        void session_game_groups_RowChanged( object sender, System.Data.DataRowChangeEventArgs e )
        {
            if( e.Action == DataRowAction.Commit )
                return;
            if( !filling )
                FillCurrent();
            //throw new NotImplementedException();
        }

        void game_groups_RowChanged( object sender, System.Data.DataRowChangeEventArgs e )
        {
            if( e.Action == DataRowAction.Commit )
                return;
            if( !filling )
                FillCurrent();
        }
    }
}
