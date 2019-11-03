using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BingoGameCore;

namespace SessionOddsMaker
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private void button2_Click( object sender, EventArgs e )
		{

		}

		private void monthCalendar1_MonthChanged( object sender, Pabo.Calendar.MonthChangedEventArgs e )
		{

		}

		private void Form1_Load( object sender, EventArgs e )
		{
			BingoGameCore.BingoSession session = new BingoSession();

			//session.win
			//session.
		}
	}
}
