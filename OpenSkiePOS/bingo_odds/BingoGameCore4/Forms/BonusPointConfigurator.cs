using System;
using System.Windows.Forms;
using xperdex.classes;
using System.Data;

namespace BingoGameCore4.Forms
{
	public partial class BonusPointConfigurator : Form
	{
		BonusPointTable points;
		public BonusPointConfigurator()
		{
			InitializeComponent();
		}

		private void BonusPointConfigurator_Load( object sender, EventArgs e )
		{
			points = new BonusPointTable();
			DsnSQLUtil.MatchCreate( StaticDsnConnection.dsn, points );
			DsnSQLUtil.FillDataTable( StaticDsnConnection.dsn, points );
			dataGridView1.DataSource = points;
			dataGridView1.Columns[ 0 ].Width = ( this.dataGridView1.Width / 2 ) - 1;
			dataGridView1.Columns[ 1 ].Width = ( this.dataGridView1.Width / 2 ) - 1;
		}

		[MySQLPersistantTable]
		internal class BonusPointTable : MySQLDataTable
		{
			new public readonly static string TableName = "rate_rank_bonus_points";
			new public readonly static string PrimaryKey = XDataTable.ID( TableName );

			internal BonusPointTable()
			{
				connection = StaticDsnConnection.dsn;
				base.TableName = TableName;
				Columns.Add( "place_in_session", typeof( int ) );
				Columns.Add( "bonus_points", typeof( int ) );
			}
		}

		private void button1_Click( object sender, EventArgs e )
		{
			points.CommitChanges();
			this.DialogResult = DialogResult.OK;
		}

		private void button2_Click( object sender, EventArgs e )
		{
			this.DialogResult = DialogResult.Cancel;
		}
	}
}