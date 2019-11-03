using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using xperdex.classes;

namespace RateRank
{
	public partial class ConfigurePoints : Form
	{
		DsnConnection dsn;
		public ConfigurePoints()
		{
			InitializeComponent();
		}
		~ConfigurePoints()
		{
			dsn = null;
		}

		private void ConfigurePoints_Load( object sender, EventArgs e )
		{
			dsn = new DsnConnection( Local.output_dsn );
			this.dataGridView1.DataSource = Local.points;
			this.dataGridView1.Columns["rate_rank_point_id"].Visible = false;
		}

		private void button1_Click( object sender, EventArgs e )
		{
			this.Close();
		}
	}
}