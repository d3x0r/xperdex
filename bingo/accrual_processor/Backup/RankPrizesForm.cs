using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TopPlayers
{
	public partial class RankPrizesForm : Form
	{
		public RankPrizesForm()
		{
			InitializeComponent();
		}

		private void RankPrizesForm_Load(object sender, EventArgs e)
		{
			dataGridViewRankPrizes.DataSource = Local.aRankPlayerPrizes;
			RepaintRankPlayers();
		}

		private void RepaintRankPlayers()
		{
			dataGridViewRankPrizes.Columns[RankPlayerPrizes.PrimaryKey].Visible = false;
		}

		private void buttonClose_Click(object sender, EventArgs e)
		{
			Local.aRankPlayerPrizes.RejectChanges();
			this.Dispose();
		}

		private void buttonSave_Click(object sender, EventArgs e)
		{
			Local.aRankPlayerPrizes.AcceptChanges();
			this.Dispose();
		}

		private void RankPrizesForm_FormClosing(object sender, FormClosingEventArgs e)
		{
		   Local.aRankPlayerPrizes.RejectChanges();
		}
	}
}