using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using OpenSkieScheduler3;
using xperdex.classes;

namespace BingoGameCore4.Forms
{
	public partial class RatedPackConfigurator : Form
	{
		ScheduleDataSet schedule;
		//DataTable packs;
		DataRow current_session;
		static PackConfiguration pack_config;

		public RatedPackConfigurator( ScheduleDataSet schedule )
		{
			this.schedule = schedule;
			if( pack_config == null )
			{
				pack_config = new PackConfiguration( schedule.schedule_dsn );
				DsnSQLUtil.MatchCreate( schedule.schedule_dsn, pack_config );
				DsnSQLUtil.FillDataTable( schedule.schedule_dsn, pack_config );
			}
			InitializeComponent();
		}

		private void PackConfigurator_Load( object sender, EventArgs e )
		{
			comboBoxSession.DataSource = schedule.sessions;
			comboBoxSession.DisplayMember = SessionTable.NameColumn;
		}

		void UpdateList2()
		{
			int total = 0;
			List<String> current_packs = new List<string>();
			DataRow[] current_pack_rows = pack_config.Select( SessionTable.PrimaryKey + "=" +current_session[SessionTable.PrimaryKey] );
			foreach( DataRow current_pack_row in current_pack_rows )
			{
				current_packs.Add( current_pack_row["pack_name"] as String );
			}

			listBox2.DataSource = current_packs;


		}

		private void comboBoxSession_SelectedIndexChanged( object sender, EventArgs e )
		{
			DataRowView drv = comboBoxSession.SelectedItem as DataRowView;
			if( drv == null )
				return;

			DataRow row = drv.Row;
			current_session = row;
			List<String> pack_list = new List<String>();
			DataRow[] packs = row.GetChildRows( "session_pack_meta_session_info" );
			foreach( DataRow pack in packs )
			{
				DataRow pack_info = pack.GetParentRow( "session_pack_meta_pack_info" );
				String pack_name = pack_info[PackTable.NameColumn] as String;
				if( pack_list.IndexOf( pack_name ) >= 0 )
					continue;
				pack_list.Add( pack_name );
			}
			pack_list.Sort();
			listBox1.DataSource = pack_list;

			UpdateList2();

		}

		public static PackDNA GetPackDNA( BingoSession session )
		{
			PackDNA pack_sequence = new PackDNA();
			if( pack_config == null )
				pack_config = new PackConfiguration( session.schedule.schedule_dsn );

			DataRow session_row = session.schedule.GetSession( session.bingoday, session.session );
			if( session_row != null )
			{
				DataRow[] packs = pack_config.Select( SessionTable.PrimaryKey + "=" + session_row[SessionTable.PrimaryKey] );
				foreach( DataRow pack in packs )
				{
					pack_sequence.pack_sequence.Add( session.GameList.pack_list.GetPack( pack["pack_name"] as String, (String)null ) );
				}
			}
			return pack_sequence;

		}

[MySQLPersistantTable]
		class PackConfiguration : MySQLDataTable
		{
			new public static readonly String TableName = "rate_rank_pack_config";
			public PackConfiguration( DsnConnection dsn )
			{
				this.connection = dsn;
				base.TableName = TableName;
				//AddDefaultColumns( true, true, false );
				this.Columns.Add( "pack_name", typeof( String ) );
				this.Columns.Add( "faces", typeof( int ) );
				this.Columns.Add( SessionTable.PrimaryKey, typeof( int ) );
			}
			public PackConfiguration()
			{
			}
		}

		private void listBox1_DoubleClick( object sender, EventArgs e )
		{
			// add a pack to current list.
			DataRow row = pack_config.NewRow();
			row[SessionTable.PrimaryKey] = current_session[SessionTable.PrimaryKey];
			row["pack_name"] = listBox1.SelectedItem;
			pack_config.Rows.Add( row );
			pack_config.CommitChanges();
			UpdateList2();
		}

		private void listBox2_DoubleClick( object sender, EventArgs e )
		{
			// remove a pack from current list
			DataRow[] row = pack_config.Select( SessionTable.PrimaryKey + "=" + current_session[SessionTable.PrimaryKey] + " and pack_name='" + listBox2.SelectedItem + "'" );
			if( row.Length > 0 )
			{
				row[0].Delete();
				pack_config.CommitChanges();
				UpdateList2();
			}
			else
				MessageBox.Show( "Uhmm... it's in the list, but not in the table?!" );
		}

		private void labelCardCount_Click( object sender, EventArgs e )
		{

		}
	}
}