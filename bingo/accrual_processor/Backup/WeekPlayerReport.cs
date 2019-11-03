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
	public partial class WeekPlayerReport : Form
	{
		
		DateTime StartingDay;
		DateTime EndingDay;
		long WeekId = 0;
		
		DataTable aRankWeeks;

		CrystalReportWeekPlayer CrystalReportWeekPlayer1 = new CrystalReportWeekPlayer();
		bool main_loaded = true;

		public WeekPlayerReport()
		{
			InitializeComponent();
		}

		private void buttonSearchDate_Click(object sender, EventArgs e)
		{
			LoadReport();
		}

		public void SetReport(DateTime aDateTime)
		{
			dateTimePickerFrom.Value = aDateTime;
			main_loaded = false;
		}


		private void LoadReport()
		{
			string label_bingoday;
			//DateTime AuxWeek = dateTimePickerFrom.Value;
			
			/*
			String where_bingoday = String_Utilities.BuildSessionRangeCondition(null, AuxWeek, 0, Local._StartingDayOfWeek, Local._StartingSession, out StartingDay, out EndingDay);
			if (Local._StartingSession == 0)
				label_bingoday = StartingDay.ToString("yyyy-MM-dd") + "    to    " + EndingDay.ToString("yyyy-MM-dd");
			else
				label_bingoday = StartingDay.AddDays(1).ToString("yyyy-MM-dd") + "    to    " + EndingDay.ToString("yyyy-MM-dd");

			
			string sql = " SELECT a1.card Player_Card, " +
							" IF (CONCAT(a2.first_name, ' ' ,a2. last_name) IS NULL,'None', concat(a2.first_name, ' ' ,a2. last_name)) Player_Name, " +
							" total_points Points,bingoday,session" +
							" FROM called_game_player_rank_partial a1 " +
							" LEFT OUTER JOIN players_info a2 USING (card) " +
							" WHERE " + where_bingoday   +
							" GROUP BY Player_Card " +
							" ORDER BY Points DESC ";
			*/

			aRankWeeks = Local._dsn.GetDataTableQuery("SELECT * " +
				" FROM called_game_weeks WHERE bingoday_start < " + dateTimePickerFrom.Value.ToString("yyyyMMdd") +
				" AND bingoday_end >= " + dateTimePickerFrom.Value.ToString("yyyyMMdd"));

			if (aRankWeeks.Rows.Count == 0)
			{
				MessageBox.Show("Sorry That week has not been set up in the System!", "Warning");
			}
			else if (aRankWeeks.Rows.Count > 1)
			{
				MessageBox.Show("Sorry More than one week associated with this day!", "Warning");
			}
			else
			{
				StartingDay = Convert.ToDateTime(aRankWeeks.Rows[0]["bingoday_start"].ToString());
				EndingDay = Convert.ToDateTime(aRankWeeks.Rows[0]["bingoday_end"]).AddDays(-1);
				WeekId = Convert.ToInt64(aRankWeeks.Rows[0]["week_id"]);

				label_bingoday = StartingDay.ToString("yyyy-MM-dd") + "    to    " + EndingDay.AddDays(1).ToString("yyyy-MM-dd");

				string sql = " SELECT a1.card Player_Card, " +
							" IF (CONCAT(a2.first_name, ' ' ,a2. last_name) IS NULL,'None', concat(a2.first_name, ' ' ,a2. last_name)) Player_Name, " +
							" total_points Points,bingoday,session" +
							" FROM called_game_player_rank_partial a1 " +
							" LEFT OUTER JOIN players_info a2 USING (card) " +
							" WHERE week_id = " + WeekId +
							" GROUP BY Player_Card " +
							" ORDER BY Points DESC ";
				
				//MySQLDataTable table = new MySQLDataTable(Local._dsn, sql);
				DataTable table = Local._dsn.GetDataTableQuery(sql);

				labelWeek.Text = label_bingoday;
				(CrystalReportWeekPlayer1.Section2.ReportObjects["WeekRange"] as CrystalDecisions.CrystalReports.Engine.TextObject).Text = label_bingoday; ;

				CrystalReportWeekPlayer1.SetDataSource(table);
				crystalReportViewer1.ReportSource = CrystalReportWeekPlayer1;
			}
		}

		private void WeekPlayerReport_Load(object sender, EventArgs e)
		{
			if (main_loaded)
				dateTimePickerFrom.Value = DateTime.Now;
			LoadReport();
		}

		private void buttonPrint_Click(object sender, EventArgs e)
		{
			crystalReportViewer1.PrintReport();
		}
	}
}