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
	public partial class PlayerParticipationReport : Form
	{
		
		DateTime StartingDay;
		DateTime EndingDay;
		//CrystalReportPlayerParticipation CrystalReport1 = new CrystalReportPlayerParticipation();
		bool main_loaded = true;

		public PlayerParticipationReport()
		{
			InitializeComponent();
			comboBoxSessionNumber.SelectedItem = "All";			
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
			string sql_filter = "";
			string title = "Player Participation";
			string title_session = "All";
			long TotalRanked = 0;
			long TotalNotRanked = 0;

			sql_filter = " AND bingoday between '" + dateTimePickerFrom.Value.ToString("yyyy-MM-dd") + "' AND '" + dateTimePickerTo.Value.ToString("yyyy-MM-dd") + "' ";
			if (comboBoxSessionNumber.SelectedItem != null && comboBoxSessionNumber.SelectedItem.ToString() != "All")
			{
				sql_filter += " AND session = " + comboBoxSessionNumber.SelectedItem;
				title_session = comboBoxSessionNumber.SelectedItem.ToString();
			}

			sql_aux = " SELECT COUNT(*) " +
				" FROM (SELECT card" +
				" FROM called_game_player_rank " +
				" WHERE 1 = 1 " +
				sql_filter +
				" GROUP BY card ) a1";

			object result = Local._dsn.ExecuteScalar(sql_aux);
			if (result != null && result.ToString() != "")
				TotalRanked = Convert.ToInt64(result);
			
			sql_aux = " SELECT COUNT(*) " +
				" FROM (SELECT card " +
				" FROM player_track " +
				" WHERE card <> 0" +
				sql_filter +
				" AND card NOT IN  " +
				" ( " +
				" SELECT card" +
				" FROM called_game_player_rank " +
				" WHERE 1 = 1 " +
				sql_filter +
				" ) GROUP BY card ) a1";

			result = Local._dsn.ExecuteScalar(sql_aux);
			if (result != null && result.ToString() != "")
				TotalNotRanked = Convert.ToInt64(result);

			if (checkBoxShowDetails.Checked)
			{
				title += " Details";

				sql_aux = " SELECT 'Ranked' rank_type, card Player_Card, " +
							" IF (CONCAT(a2.first_name, ' ' ,a2. last_name) IS NULL,'None', concat(a2.first_name, ' ' ,a2. last_name)) Player_Name, " +
							" MAX(total_points) Score, COUNT(*) Total_Participations" +
							" FROM called_game_player_rank " +
							" LEFT OUTER JOIN players_info a2 USING (card) " +
							" WHERE 1 = 1 " +
							sql_filter +
							" GROUP BY card " +
							" UNION " +
							" SELECT 'Not Ranked' rank_type, card Player_Card, " +
							" IF (CONCAT(a2.first_name, ' ' ,a2. last_name) IS NULL,'None', concat(a2.first_name, ' ' ,a2. last_name)) Player_Name, " +
							" SUM(points) Score, COUNT(*) Total_Participations" +
							" FROM player_track " +
							" LEFT OUTER JOIN players_info a2 USING (card) " +
							" WHERE card <> 0 " +
							sql_filter +
							" AND card NOT IN  " +
							" ( " +
							" SELECT card" +
							" FROM called_game_player_rank " +
							" WHERE 1 = 1 " +
							sql_filter +
							" )  GROUP BY card " +
							" ORDER BY rank_type DESC, Score DESC ";

				DataTable table = Local._dsn.GetDataTableQuery(sql_aux);
				//CrystalReport1.SetDataSource(table);
				
			}
			/*
			(CrystalReport1.Section2.ReportObjects["TextTitle"] as CrystalDecisions.CrystalReports.Engine.TextObject).Text = title;
			(CrystalReport1.Section2.ReportObjects["WeekRange"] as CrystalDecisions.CrystalReports.Engine.TextObject).Text = dateTimePickerFrom.Value.ToString("yyyy-MM-dd") + "    to    " + dateTimePickerTo.Value.ToString("yyyy-MM-dd");
			(CrystalReport1.Section2.ReportObjects["TextChoosenSession"] as CrystalDecisions.CrystalReports.Engine.TextObject).Text = title_session;
			(CrystalReport1.Section2.ReportObjects["TextTotalRanked"] as CrystalDecisions.CrystalReports.Engine.TextObject).Text = TotalRanked.ToString();
			(CrystalReport1.Section2.ReportObjects["TextTotalNotRanked"] as CrystalDecisions.CrystalReports.Engine.TextObject).Text = TotalNotRanked.ToString();
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