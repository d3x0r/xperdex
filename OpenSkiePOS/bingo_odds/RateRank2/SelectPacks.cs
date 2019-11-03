using System;
using System.Collections.Generic;
using System.Windows.Forms;
using BingoGameCore4;

namespace RateRank
{
	public partial class SelectPacks : Form
	{
		public List<BingoPack> packlist;
		BingoGameList _bgl;
		public SelectPacks( BingoGameList bgl )
		{
			_bgl = bgl;
			InitializeComponent();
		}

		private void SelectPacks_Load( object sender, EventArgs e )
		{
			packlist = _bgl.pack_list.GetSkeletonPackList();
			listBoxPacks.DataSource = packlist;
		}

		private void button1_Click( object sender, EventArgs e )
		{
			this.Close();
		}
	}
}