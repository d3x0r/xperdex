using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.Odbc;
using xperdex.classes;

namespace TopPlayers
{
	public partial class PrizesReport : Form
	{
		
		DateTime StartingDay;
		DateTime EndingDay;
		//CrystalReportWeekPrizes CrystalReport1 = new CrystalReportWeekPrizes();
		bool main_loaded = true;

		public PrizesReport()
		{
			InitializeComponent();
		}

		private void buttonSearchDate_Click(object sender, EventArgs e)
		{
			LoadReport();
		}

		public void SetReport(DateTime aDateTime)
		{
			dateTimePickerTo.Value = aDateTime;
			dateTimePickerFrom.Value = dateTimePickerTo.Value.AddDays(-7);
			main_loaded = false;
		}


		private void LoadReport()
		{
			string sql_aux = "";
			string title = "All Prizes";
			if (radioButtonPaidPrizes.Checked)
			{
				sql_aux = " AND paid = 1 ";
				title = "Paid Prizes";
			}
			if (radioButtonUnclaim.Checked)
			{
				sql_aux = " AND paid = 0 ";
				title = "Unclaimed Prizes";
			}
			
			string sql = " SELECT a1.position, a1.card Player_Card, " +
							" IF (CONCAT(a2.first_name, ' ' ,a2. last_name) IS NULL,'None', concat(a2.first_name, ' ' ,a2. last_name)) Player_Name, " +
							" total_points score," +
							" cash_prize/100 cash_prize," +
							" point_prize point_prize, " +
							" IF (paid=1,'*','') paid, " +
							" date_prize bingoday " +
							" FROM called_game_player_payouts a1 " +
							" LEFT OUTER JOIN players_info a2 USING (card) " +
							" WHERE date_prize between '" + dateTimePickerFrom.Value.ToString("yyyy-MM-dd") + "' AND '" + dateTimePickerTo.Value.ToString("yyyy-MM-dd") + "' " +
							" AND removed = 0 " +
							" AND void = 0 " +
							sql_aux +
							" ORDER BY bingoday DESC, score DESC, cash_prize DESC, point_prize DESC ";

			//MySQLDataTable table = new MySQLDataTable(Local._dsn, sql);
			DataTable table = Local._dsn.GetDataTableQuery(sql);
			/*
			(CrystalReport1.Section2.ReportObjects["TextTitle"] as CrystalDecisions.CrystalReports.Engine.TextObject).Text = title;
			(CrystalReport1.Section2.ReportObjects["WeekRange"] as CrystalDecisions.CrystalReports.Engine.TextObject).Text = dateTimePickerFrom.Value.ToString("yyyy-MM-dd") + "    to    " + dateTimePickerTo.Value.ToString("yyyy-MM-dd");
			CrystalReport1.SetDataSource(table);
			crystalReportViewer1.ReportSource = CrystalReport1;
			 */
		}

		private void WeekPlayerReport_Load(object sender, EventArgs e)
		{
			if (main_loaded)
			{
				dateTimePickerTo.Value = DateTime.Now;
				dateTimePickerFrom.Value = dateTimePickerTo.Value.AddDays(-7);			
			}
			LoadReport();
		}

		private void buttonPrint_Click(object sender, EventArgs e)
		{
			crystalReportViewer1.PrintReport();
		}
	}
}