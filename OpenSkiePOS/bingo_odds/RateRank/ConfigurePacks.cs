using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BingoGameCore;
using xperdex.classes;

namespace RateRank
{
	public partial class ConfigurePacks : Form
	{
		public class PackConfigDB : MySQLDataTable
		{
			public PackConfigDB()
			{
				this.TableName = "pack_configuration";
				this.connection = new DsnConnection( Local.output_dsn );
				DataColumn dc = this.Columns.Add( "pack_config_id", typeof( int ) );
				dc.AutoIncrement = true;
				
				this.Columns.Add( "pack_name", typeof( string ) );
				this.Columns.Add( "rate", typeof( bool ) );
				this.Create();
				this.Fill();
			}
			~PackConfigDB()
			{
				this.connection.Dispose();
			}
		}



		List<BingoPack> packs;
		public ConfigurePacks( )
		{
			this.packs = new List<BingoPack>();

			foreach( DataRow row in GDAL.BingoSessions.ScheduleData.pi.Rows )
			{
				BingoPack pack = this.packs.Find( delegate(BingoPack p) { return p.name == row["pack_name"]; } );
				if( pack == null )
				{
					pack = BingoPack.GetPack( row["pack_name"].ToString() );
					packs.Add( pack );
				}
			}

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
						Local.db.AcceptChanges();
				}
			}

			xperdex.classes.INI.File( "raterank.ini" )["Config"]["Pack Count To Rate"].Integer = Convert.ToInt32( this.textBox1.Text );
			xperdex.classes.INI.File( "raterank.ini" )["Config"]["Max Cards To Rate"].Integer = Convert.ToInt32( this.textBoxCards.Text );
			this.Close();
		}

		private void ConfigurePacks_Load( object sender, EventArgs e )
		{
			this.textBox1.Text = xperdex.classes.INI.File( "raterank.ini" )["Config"]["Pack Count To Rate", "2"];
			this.textBoxCards.Text = xperdex.classes.INI.File( "raterank.ini" )["Config"]["Max Cards To Rate", "12"];
			this.dataGridView1.Columns.Add( "PackName", "Pack Name" );

			DataGridViewCheckBoxColumn bc = new DataGridViewCheckBoxColumn();
			bc.HeaderText = "Rate";
			bc.Name = "Rate";
			this.dataGridView1.Columns.Add( bc );

			this.dataGridView1.Columns.Add( "datarow", "datarow" );
			dataGridView1.Columns["datarow"].Visible = false;

			object[] row= new object[3];
			foreach( BingoPack pack in packs )
			{
				DataRow[] config = Local.db.Select( "pack_name='"+pack.name+"'" );
				row[0] = pack.name;
				if( config.Length == 0 )
				{
					object[] newrow = new object[3];
					newrow[1] = row[0];
					newrow[2] = false;
					row[1] = false;
					row[2] = Local.db.Rows.Add( newrow );

				}
				else
				{
					row[1] = config[0]["rate"];
					row[2] = config[0];
				}
				dataGridView1.Rows.Add( row );
			}
			Local.db.AcceptChanges();

		}
	}
}