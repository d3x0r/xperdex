using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ECube.AccrualProcessor.Forms
{
	public partial class bingoDataSourceTableSelector : Form
	{
		public bingoDataSourceTableSelector()
		{
			InitializeComponent();
		}

		private void bingoDataSourceTableSelector_Load( object sender, EventArgs e )
		{
			listBox1.DataSource = Local.BingoDataSet.Tables;
		}
	}
}
