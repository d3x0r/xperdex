using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using OpenSkieScheduler3;
using OpenSkieScheduler3.Controls;
using OpenSkieScheduler3.Relations;

namespace OpenSkie.Scheduler.Controls.Controls.Grids
{
	public class GamePackPageAssignment : DataGridView
	{

		bool filling;
		List<DataRow> session_games;
		List<DataRow> session_packs;
		DataTable current_data;
		

		void Init()
		{
			session_games = new List<DataRow>();
			session_packs = new List<DataRow>();
			current_data = ControlList.schedule.Tables["current_session_game_session_pack_assignment"];
			if( current_data == null )
			{
				current_data = new DataTable();
				current_data.TableName = "current_session_game_session_pack_assignment";
				ControlList.schedule.Tables.Add( current_data );
			}
			ControlList.data.SetSessionCurrent += new ScheduleCurrents.OnSetCurrent( data_SetSessionCurrent );

			this.CellValueChanged += new DataGridViewCellEventHandler( GamePackPageAssignment_CellValueChanged );

		}

		public GamePackPageAssignment()
		{
			Init();
		}


		void GamePackPageAssignment_CellValueChanged( object sender, DataGridViewCellEventArgs e )
		{
			if( !filling )
			{
				if( e.ColumnIndex > 0 )
				{
					int page_number;
					DataGridViewCell c = this[e.ColumnIndex, e.RowIndex];
					page_number = Convert.ToInt32( c.Value );

					// this is the real session-game relation point
					DataRow game_row = session_games[e.RowIndex];
					DataRow pack_row = session_packs[e.ColumnIndex - 1];

					DataRow[] this_row = ControlList.schedule.session_game_session_pack.Select( SessionGame.PrimaryKey + "='" + game_row[SessionGame.PrimaryKey] + "' and " + SessionPack.PrimaryKey + "='" + pack_row[SessionPack.PrimaryKey] + "'" );
					if( this_row.Length == 0 )
					{
						int nGame;
						bool prior_progressive = true;
						DataRow newrow = ControlList.schedule.session_game_session_pack.NewRow();
						newrow[SessionGame.PrimaryKey] = game_row[SessionGame.PrimaryKey];
						newrow[SessionPack.PrimaryKey] = pack_row[SessionPack.PrimaryKey];
						newrow["page"] = page_number;
						ControlList.schedule.session_game_session_pack.Rows.Add( newrow );


						// go backwards. to the first game progressing to this one
						for( nGame = e.RowIndex; nGame > 0; nGame-- )
						{
							if( !Convert.ToBoolean( session_games[nGame-1]["progressive"] ) )
							{
								break;
							}
						}
						for( ; nGame < session_games.Count; nGame++ )
						{
							if( !prior_progressive )
								break;

							if( !Convert.ToBoolean( session_games[nGame]["progressive"] ) )
							{
								prior_progressive = false;
								// first game, and it's not progressive, only set this one.
								if( nGame == e.RowIndex )
									break; 
							}
							else
								prior_progressive = true;
							if( nGame == e.RowIndex )
							{
								// this cell was already set
								continue;
							}

							// I don't get a new event when this happens.
							current_data.Rows[nGame][e.ColumnIndex] = page_number;

							newrow = ControlList.schedule.session_game_session_pack.NewRow();
							newrow[SessionGame.PrimaryKey] = session_games[nGame][SessionGame.PrimaryKey];
							newrow[SessionPack.PrimaryKey] = pack_row[SessionPack.PrimaryKey];
							newrow["page"] = page_number;
							ControlList.schedule.session_game_session_pack.Rows.Add( newrow );
						}
					}
					else
					{
						if( !this_row[0]["page"].Equals( page_number ) )
						{
							this_row[0]["page"] = page_number;
						}
					}
				}
			}
		}


		void data_SetSessionCurrent( DataRow current )
		{
			//new current session
			if( !filling )
				FillCurrent();
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
				AllowUserToAddRows = false;
				AllowUserToDeleteRows = false;
				
				session_games.Clear();
				session_packs.Clear();

				DataRow current_session = ControlList.data.current_session;
				current_data.Clear();
				current_data.Columns.Clear();
				DataColumn dc;
				dc = new DataColumn( "Game Name", typeof( String ) );
				dc.AllowDBNull = false;
				current_data.Columns.Add( dc );

				foreach( DataRowView session_pack_view in ControlList.data.current_session_packs )
				{
					DataRow session_pack = session_pack_view.Row;
					if( session_pack.RowState == DataRowState.Deleted )
						continue;
					DataRow tmp_pack = session_pack.GetParentRow( SessionPack.TableName );

					DataRow pack = tmp_pack.GetParentRow( "session_pack_meta_pack_info" );

					session_packs.Add( tmp_pack );
					dc = new DataColumn( pack[PackTable.NameColumn].ToString(), typeof( int ) );
					dc.AllowDBNull = false;
					dc.DefaultValue = 0;
					while( true )
					{
						try
						{
							current_data.Columns.Add( dc );
							break;
						}
						catch( DuplicateNameException dne )
						{
							dc.ColumnName = dc.ColumnName + "?";
						}
					}
				}

				object[] rowdata = new object[session_packs.Count + 1];
				foreach( DataRowView session_game_view in ControlList.data.current_session_games )
				{
					DataRow session_game = session_game_view.Row;
					if( session_game.RowState == DataRowState.Deleted )
						continue;
					int n = 0;
					DataRow tmp_game = session_game;//.GetParentRow( SessionGame.TableName );
					;DataRow game = tmp_game.GetParentRow( "game_in_session" );

					DataRow[] game_has_pack = tmp_game.GetChildRows( "session_game_has_session_pack" );
					session_games.Add( tmp_game );
					//rowdata[0] = String.Format( "{0,3}. {1}"
					//	, tmp_game[SessionGame.NumberColumn]
					//	, session_game[xperdex.classes.XDataTable.Name( session_game.Table )] );
					rowdata[0] = session_game;//[xperdex.classes.XDataTable.Name( session_game.Table )];
					foreach( DataRow session_pack in session_packs )
					{
						//DataRow pack_row = session_pack.GetParentRow( "pack_in_session" );
						rowdata[1 + n] = 0;
						foreach( DataRow game_pack in game_has_pack )
						{
							if( game_pack[SessionPack.PrimaryKey].Equals( session_pack[SessionPack.PrimaryKey] ) )
							{
								rowdata[1 + n] = game_pack["page"];
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
	}
}
