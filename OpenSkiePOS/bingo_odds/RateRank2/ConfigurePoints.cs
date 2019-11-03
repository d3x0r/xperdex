using System;
using System.Windows.Forms;

namespace RateRank2
{
	public partial class ConfigurePoints : Form
	{
		public ConfigurePoints()
		{
			InitializeComponent();
		}
		
		private void ConfigurePoints_Load( object sender, EventArgs e )
		{
			this.dataGridView1.DataSource = BingoGameCore4.RateRank.points;
			this.dataGridView1.Columns[BingoGameCore4.RateRank.points.ValueMemberName].Visible = false;
		}

		private void button1_Click( object sender, EventArgs e )
		{
			BingoGameCore4.RateRank.points.CommitChanges();
			this.Close();
		}
	}
}