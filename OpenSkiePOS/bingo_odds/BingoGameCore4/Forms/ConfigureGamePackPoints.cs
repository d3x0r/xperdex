using System;
using System.Data;
using System.Windows.Forms;
using BingoGameCore4.Database;
using OpenSkie.Scheduler;
using OpenSkieScheduler3;
using OpenSkieScheduler3.Relations;

namespace BingoGameCore4.Forms
{
	public partial class ConfigureGamePackPoints : Form
	{
		OpenSkieScheduler3.ScheduleDataSet schedule;
        ScheduleCurrents schedule_currents;

		BindingSource current_points;
		BingoGameCore4.Database.RankPointsExtended points_table;

		public ConfigureGamePackPoints( OpenSkieScheduler3.ScheduleDataSet sched )
		{
			schedule = sched;
            schedule_currents = new ScheduleCurrents( schedule );
			current_points = new BindingSource();
			points_table = sched.Tables[RankPointsExtended.TableName] as RankPointsExtended;
			if( points_table == null )
				points_table = new BingoGameCore4.Database.RankPointsExtended( sched );
			current_points.DataSource = points_table;

			InitializeComponent();
		}

		private void ConfigureGamePackPoints_Load( object sender, EventArgs e )
		{
            if( schedule.sessions.Rows.Count == 0 )
                schedule.sessions.Fill();
            listBox2.DataSource = schedule.sessions;
			listBox2.DisplayMember = SessionTable.NameColumn;
			listBox2.SelectedIndexChanged += new EventHandler( listBox2_SelectedIndexChanged );

			if( schedule_currents.current_session_game == null )
			{
				schedule.session_games.Fill();
//
//				DataRow[] rows = schedule.session_games.Select( "session_id=" + );
//					
//					(
//					"session_id=" + schedule.sessions.Rows[ 0 ][ 0 ].ToString(),
//					"game_number" );
//				listBox1.DisplayMember = SessionGame.NameColumn;
				
//				listBox1.DataSource = schedule.session_games.Select( "session_id=" + schedule.sessions.Rows[0][0].ToString() );
//				schedule_currents.current_session_game = schedule.sessions.Rows[0];//
//				schedule.session_games.Fill();

                //schedule_currents.SetCurrentSession( schedule.sessions.Rows[ 1 ] );

//                schedule.games.Fill();
//				foreach( DataRow row in schedule.session_games.Rows )
//				{
//					listBox1.Items.Add( row[ "session_game_name" ] );
//				}
            }

//			listBox1.DataSource = schedule_currents.current_session_game;
			//listBox1.DisplayMember = CurrentSessionGames2.NameColumn;
			listBox1.SelectedIndexChanged += new EventHandler( listBox1_SelectedIndexChanged );

            if( RankPointsExtended.types.Rows.Count == 0 )
                RankPointsExtended.types.Select();

			comboBox1.DataSource = RankPointsExtended.types;
			comboBox1.DisplayMember = "name";
			comboBox1.ValueMember = "ID";
			comboBox1.SelectedIndexChanged += new EventHandler( comboBox1_SelectedIndexChanged );
			//comboBox1.DataBindings.Add( new Binding( "SelectedValue", current_points, "type", true ) );

			textBox1.DataBindings.Add( new Binding( "Text", current_points, "points", true ) );
		}

		void comboBox1_SelectedIndexChanged( object sender, EventArgs e )
		{
			SetCurrent();
		}

		void SetCurrent()
		{
			int session_game_group_game_id;
			int type_id;
			//throw new Exception( "The method or operation is not implemented." );

            if( listBox1.Items.Count > 0 )
            {
                DataRow[ ] rows = points_table.Select(
                        OpenSkieScheduler3.Relations.SessionGame.PrimaryKey + "="
                    + ( session_game_group_game_id = Convert.ToInt32( ( listBox1.SelectedItem as DataRowView ).Row[ SessionGame.PrimaryKey ] ) )
                    + " and type="
                    + ( type_id = Convert.ToInt32( ( comboBox1.SelectedItem as DataRowView ).Row[ "ID" ] ) )
                    );
                if( rows.Length < 1 )
                {
                    DataRow row = points_table.NewRow();
                    //row[SessionTable.PrimaryKey] = session_id;
                    row[ SessionGame.PrimaryKey ] = session_game_group_game_id;
                    row[ "type" ] = type_id;
                    row[ "points" ] = 0;
                    points_table.Rows.Add( row );
                    current_points.Position = points_table.Rows.IndexOf( row );
                }
                else if( rows.Length == 1 )
                    current_points.Position = points_table.Rows.IndexOf( rows[ 0 ] );
                else
                    MessageBox.Show( "Failed to get a current singular row." );
                points_table.CommitChanges();
            }
		}


		void listBox1_SelectedIndexChanged( object sender, EventArgs e )
		{
			SetCurrent();
		}

		void listBox2_SelectedIndexChanged( object sender, EventArgs e )
		{
			if( listBox2.SelectedItem == null )
				return;
			schedule_currents.SetCurrentSession( (listBox2.SelectedItem as DataRowView ).Row );
			//Listbox2
		}
	}
}