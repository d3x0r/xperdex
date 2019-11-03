using System;
using System.Data;
using System.Windows.Forms;
using OpenSkieScheduler3;
using xperdex.classes;

namespace RateRank2
{
	public partial class ConfigureGames : Form
	{
		public class GameConfigDB : MySQLDataTable
		{
			public GameConfigDB()
			{
				this.TableName = "rated_game_configuration";
				this.connection = Local.input_db;
				DataColumn dc = this.Columns.Add( "game_config_id", typeof( int ) );
				dc.AutoIncrement = true;
				this.PrimaryKey = new DataColumn[1]{dc};

				this.Columns.Add( "session_game_group_name", typeof( string ) );
				this.Columns.Add( "rate", typeof( bool ) );
				this.Columns.Add( "session_game_group_id", typeof( int ) );
				DsnSQLUtil.MatchCreate( connection, this );
				DsnSQLUtil.FillDataTable( connection, this );
			}
			~GameConfigDB()
			{
				this.connection.Dispose();
			}
		}


		ScheduleDataSet schedule;

		public ConfigureGames( ScheduleDataSet schedule )
		{
			this.schedule = schedule;
			InitializeComponent();
		}


		private void button1_Click( object sender, EventArgs e )
		{
			bool changed = false;
			foreach( DataGridViewRow row in dataGridView1.Rows )
			{
				DataRow dbrow = row.Cells["datarow"].Value as DataRow;
				if( dbrow != null )
				{
					if( dbrow["rate"] != row.Cells[1] )
					{
						changed = true;
						dbrow["rate"] = row.Cells[1].Value;
					}
					if( changed )
						Local.game_db.CommitChanges();
				}
			}

			this.Close();
		}

		private void ConfigureGames_Load( object sender, EventArgs e )
		{
			this.dataGridView1.Columns.Add( "GameName", "Game Name" );

			DataGridViewCheckBoxColumn bc = new DataGridViewCheckBoxColumn();
			bc.HeaderText = "Rate";
			bc.Name = "Rate";
			this.dataGridView1.Columns.Add( bc );

			this.dataGridView1.Columns.Add( "datarow", "datarow" );
			dataGridView1.Columns["datarow"].Visible = false;

			object[] row= new object[3];
			OpenSkieScheduler3.Relations.SessionPackGroup sgg = schedule.session_pack_groups;
			foreach( DataRow game in sgg.Rows )
			{
				DataRow session = game.GetParentRow( "session_has_game_group" );
				DataRow group = game.GetParentRow( "game_group_in_session" );

				String game_name = session[SessionTable.NameColumn] +" - " + group[PackGroupTable.NameColumn];
				DataRow[] config = Local.game_db.Select( "session_game_group_name='" + game_name + "'" );
				row[0] = game_name;
				if( config.Length == 0 )
				{
					DataRow newrow = Local.game_db.NewRow();
					newrow[1] = game_name;
					newrow[2] = false;
					newrow[3] = game["session_game_group_id"];
					row[1] = false;
					row[2] = newrow;
					Local.game_db.Rows.Add( newrow );

				}
				else
				{
					row[1] = config[0]["rate"];
					row[2] = config[0];
				}
				dataGridView1.Rows.Add( row );
			}
			Local.game_db.CommitChanges();

		}
	}
}