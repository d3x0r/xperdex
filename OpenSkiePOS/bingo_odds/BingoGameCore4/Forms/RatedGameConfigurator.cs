using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using OpenSkieScheduler3;
using OpenSkieScheduler3.Relations;
using xperdex.classes;
using OpenSkie.Scheduler;

namespace BingoGameCore4.Forms
{
	public partial class RatedGameConfigurator : Form
	{
		ScheduleDataSet schedule;
        ScheduleCurrents schedule_currents;
		DataRow current_session;
		GameConfiguration game_config;

		public RatedGameConfigurator( ScheduleDataSet schedule )
		{
			this.schedule = schedule;
			game_config = new GameConfiguration( schedule );
			DsnSQLUtil.CreateDataTable( schedule.schedule_dsn, game_config );
			InitializeComponent();
		}

		private void RatedGameConfigurator_Load( object sender, EventArgs e )
		{

			dataGridViewGames.Columns.Add( "name", "Game Name" );
			dataGridViewGames.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
			DataGridViewCheckBoxColumn check_col;

			check_col = new DataGridViewCheckBoxColumn();
			check_col.HeaderText = "Rate Game";
			check_col.Name = "rate_game";
			check_col.DataPropertyName = check_col.Name;
			dataGridViewGames.Columns.Add( check_col );

			dataGridViewGames.Columns.Add( "game_id", "Game ID" );
			dataGridViewGames.Columns[2].Visible = false;
			dataGridViewGames.Columns.Add( "original_val", "Original Value" );
			dataGridViewGames.Columns[3].Visible = false;
            dataGridViewGames.DataSource = BingoGameList.manual_dataset;

            int sessionId = 0;
			comboBoxSession.DataSource = schedule.sessions;
			comboBoxSession.DisplayMember = SessionTable.NameColumn;

            if( comboBoxSession.Items.Count > 0 )
            {
                if( BingoGameList.sessionIds != null )
					sessionId = BingoGameList.sessionIds[ comboBoxSession.SelectedIndex ];
            }

		}

		[MySQLPersistantTable]
		public class GameConfiguration : MySQLDataTable
		{
			new public static readonly String TableName = "rate_rank_game_config";
			public GameConfiguration( ScheduleDataSet schedule )
			{
				this.connection = schedule.schedule_dsn;
				base.TableName = TableName;
				//AddDefaultColumns( true, true, false );
				this.Columns.Add( SessionGame.PrimaryKey, typeof( int ) );
				this.Columns.Add( "rate", typeof( bool ) );

				
			}
			public GameConfiguration()
			{
			}
			~GameConfiguration()
			{

				//this.DataSet.Tables.Remove( this );
			}
		}

		void ApplyValues()
		{
			bool asked = false;
			bool accept = false;
			// just before the grid is cleared, check to see if anything changed.
			foreach( DataGridViewRow row in dataGridViewGames.Rows )
			{
				if( row.Cells[1].Value != row.Cells[3].Value )
				{
					if( !asked )
					{
						accept = ( MessageBox.Show( "Save changes?", "Values Changed", MessageBoxButtons.YesNo ) == DialogResult.Yes );
						asked = true;
					}
					if( !accept )
						return;

					DataRow[] conf_row = game_config.Select( SessionGame.PrimaryKey + "=" + row.Cells[2].Value.ToString() );
					if( conf_row.Length > 0 )
						conf_row[0]["rate"] = row.Cells[1].Value;
					else
						MessageBox.Show( "Lost the related session game group game order row/configuration." );
				}
			}
			// asked is also 'changed'
			if( asked )
				game_config.CommitChanges();
		}

		private void comboBoxSession_SelectedIndexChanged( object sender, EventArgs e )
		{
			if( comboBoxSession.SelectedItem == null )
			{
				return;
			}
			DataRowView drv = comboBoxSession.SelectedItem as DataRowView;

			String str = drv.Row[ "session_name" ].ToString();
			Int32 id = (int)drv.Row[ "session_id" ];

			DataRow[] games = schedule.session_games.Select( "session_id=" + id.ToString() );

			//schedule.SetCurrentSession( row );



//			List<object[]> game_list = new List<object[]>();

//			ApplyValues();

			dataGridViewGames.Rows.Clear();
			//DataRow[] games0 = schedule.sessions.Games( current_session );
			//DataRow[] games = schedule.session_macro_sessions.GetGames( current_session );

			game_config.Fill();

			//foreach( DataRowView game_view in schedule_currents.current_session_games )
			foreach( DataRow game in games )
			//for( int x = 0; x < games.Length; x++ )
			{
				//DataRow game = game_view.Row;
				object key;
				object[] newrow = new object[4];
				//newrow[0] = game[XDataTable.Name(game.Table)];
				newrow[ 0 ] = game.ToString(); 
				key = newrow[ 2 ] = game[ SessionGame.PrimaryKey ];

				DataRow[] rate_conf_row = game_config.Select( SessionGame.PrimaryKey + "=" + key.ToString() );

				if( rate_conf_row.Length > 0 )
					newrow[1] = newrow[3] = rate_conf_row[0]["rate"];
				else
				{
					DataRow new_conf_row = game_config.NewRow();
					new_conf_row["rate"] = true;
					new_conf_row[SessionGame.PrimaryKey] = game[SessionGame.PrimaryKey];
					game_config.Rows.Add( new_conf_row );
					game_config.CommitChanges();

					newrow[1] = newrow[3] = true;
				}
				dataGridViewGames.Rows.Add( newrow );
			}


		}

		private void button1_Click( object sender, EventArgs e )
		{
			ApplyValues();
			DialogResult = DialogResult.OK;
		}


	}
}