using System;
using System.Data;
using System.Windows.Forms;
using OpenSkieScheduler3;
using xperdex.classes;

namespace RateRank2
{
	public partial class ConfigurePacks : Form
	{
		public class PackConfigDB : MySQLDataTable
		{
			public PackConfigDB()
			{
				this.TableName = "pack_configuration";
				this.connection = Local.input_db;
				DataColumn dc = this.Columns.Add( "pack_config_id", typeof( int ) );
				dc.AutoIncrement = true;
				this.PrimaryKey = new DataColumn[1]{dc};
				
				this.Columns.Add( "pack_name", typeof( string ) );
				this.Columns.Add( "rate", typeof( bool ) );
				DsnSQLUtil.MatchCreate( connection, this );
				DsnSQLUtil.FillDataTable( connection, this );
				//this.Create();
				//this.Fill();
			}
			~PackConfigDB()
			{
				this.connection.Dispose();
			}
		}



		ScheduleDataSet schedule;

		public ConfigurePacks( ScheduleDataSet schedule )
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
						Local.pack_db.CommitChanges();
				}
			}

			xperdex.classes.Options.File( "raterank.ini" )["Config"]["Pack Count To Rate"].Integer = this.textBox1.Text.Length == 0 ? 0 : Convert.ToInt32( this.textBox1.Text );
			xperdex.classes.Options.File( "raterank.ini" )["Config"]["Max Cards To Rate"].Integer = Convert.ToInt32( this.textBoxCards.Text );
			this.Close();
		}

		private void ConfigurePacks_Load( object sender, EventArgs e )
		{
			this.textBox1.Text = xperdex.classes.Options.File( "raterank.ini" )["Config"]["Pack Count To Rate", "2"];
			this.textBoxCards.Text = xperdex.classes.Options.File( "raterank.ini" )["Config"]["Max Cards To Rate", "12"];
			this.dataGridView1.Columns.Add( "PackName", "Pack Name" );

			DataGridViewCheckBoxColumn bc = new DataGridViewCheckBoxColumn();
			bc.HeaderText = "Rate";
			bc.Name = "Rate";
			this.dataGridView1.Columns.Add( bc );

			this.dataGridView1.Columns.Add( "datarow", "datarow" );
			dataGridView1.Columns["datarow"].Visible = false;

			object[] row= new object[3];
			foreach( DataRow pack in schedule.packs.Rows )
			{
				DataRow[] config = Local.pack_db.Select( "pack_name='" + pack["pack_name"].ToString() + "'" );
				row[0] = pack["pack_name"].ToString();
				if( config.Length == 0 )
				{
					object[] newrow = new object[3];
					newrow[1] = row[0];
					newrow[2] = false;
					row[1] = false;
					row[2] = Local.pack_db.Rows.Add( newrow );

				}
				else
				{
					row[1] = config[0]["rate"];
					row[2] = config[0];
				}
				dataGridView1.Rows.Add( row );
			}
			Local.pack_db.CommitChanges();

		}
	}
}