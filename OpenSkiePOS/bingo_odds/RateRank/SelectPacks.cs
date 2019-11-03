using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BingoGameCore;

namespace RateRank
{
	public partial class SelectPacks : Form
	{
		public List<BingoPack> packlist;
		public SelectPacks()
		{
			InitializeComponent();
		}

		private void SelectPacks_Load( object sender, EventArgs e )
		{
			packlist = BingoPack.GetPackList();
			listBoxPacks.DataSource = packlist;
		}

		private void button1_Click( object sender, EventArgs e )
		{
			this.Close();
		}
	}
}