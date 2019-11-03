using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using xperdex.classes;
using BingoSQLTracking;

namespace GameDatabaseImporter
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private void buttonDone_Click( object sender, EventArgs e )
		{
			Close();
		}

		private void button1_Click( object sender, EventArgs e )
		{
			DsnConnection source = new DsnConnection( textBox1.Text );
			DsnConnection dest = new DsnConnection( textBox2.Text );
			BingoTracking dataset = new BingoTracking();
			DsnSQLUtil.CreateDataTable( dest, dataset );
			DsnSQLUtil.FillDataSet( source, dataset );
			DsnSQLUtil.AppendToDatabase( dest, dataset );
			//DsnSQLUtil.
		}
	}
}
