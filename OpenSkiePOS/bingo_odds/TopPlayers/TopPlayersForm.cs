using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using xperdex.classes;

namespace TopPlayers
{
	public partial class TopPlayersForm : Form
	{
		/*
		GDAL.Players.TopPlayers aTopPlayers = new GDAL.Players.TopPlayers();
		GDAL.Players.PlayersInfo aPlayerInfo = new GDAL.Players.PlayersInfo();
		GDAL.Players.TopPlayerPayout aTopPlayerPayout = new GDAL.Players.TopPlayerPayout();
		GDAL.Players.TopPlayerPrizes aTopPlayerPrizes = new GDAL.Players.TopPlayerPrizes();
		*/

		DataTable aRankPlayers;
		DataTable aTopPlayers;
		DataTable aBottomPlayers;
		DataTable aRankWeeks;

		int aTopPlayerIndex = -1;
		int aBottomPlayerIndex = -1;

		DateTime StartingDay;
		DateTime EndingDay;
		long WeekId = 0;

		bool scanning = true;

		ChoosenPlayersForm aChoosenPlayersForm;

		public TopPlayersForm()
		{
			InitializeComponent();
		}

		private void TopPlayersForm_Load(object sender, EventArgs e)
		{
			dateTimePickerFrom.Value = DateTime.Now.AddDays(-7);
			labelTopPlayers.Text = " Top Players";
			labelBottomPlayers.Text = " Bottom Players";
			LoadRankPlayerGrids();
			//Local.swipeCardPort = new CORE.SwipeCards.ComPort(Local._SwipeCardsSystemPort, cardswipe_receive);
		}

		void cardswipe_receive(string s)
		{

			//// player card received...
			//if (this.listBoxCardsRead.InvokeRequired)
			//{
			//    SetTextCallback d = new SetTextCallback(cardswipe_receive);
			//    this.Invoke(d, new object[] { s });
			//}
			//else
			{

				scanning = true;
				//Local.playerCard.MagStripe = s;
				//Local.swipeCardPort.FinishTick();

				scanning = false;
				string card_scanned = DateTime.Now.ToShortTimeString() + " - Card :" + Local.playerCard.Name;
				listBoxCardsRead.Items.Add(card_scanned);
				listBoxCardsRead.SetSelected(listBoxCardsRead.Items.Count - 1, true);
				if (false )//Local.playerCard.Name != "No Player Scanned" && Local.playerCard.card != null)
				{
					if (!scanning)
					{
						if (aChoosenPlayersForm == null || aChoosenPlayersForm.IsDisposed)
						{
							aChoosenPlayersForm = new ChoosenPlayersForm();
							if (aChoosenPlayersForm.SetReport(dateTimePickerFrom.Value, card_scanned))
							{
								aChoosenPlayersForm.ShowDialog();
								LoadRankPlayerGrids();
							}
						}
						else
						{
							if (aChoosenPlayersForm.SetReport(dateTimePickerFrom.Value, card_scanned))
							{
								if (!aChoosenPlayersForm.ContainsFocus)
								{
									aChoosenPlayersForm.ShowDialog();
									LoadRankPlayerGrids();
								}
							}
						}
						//SelectPlayer(Local.playerCard.card);
					}
				}

			}
		}


		private bool LoadRankPlayerGrids()
		{
			/*
			String_Utilities.BuildSessionRangeCondition(null, dateTimePickerFrom.Value, 0, Local._StartingDayOfWeek, Local._StartingSession, out StartingDay, out EndingDay);
			if (Local._StartingSession != 0)
				StartingDay = StartingDay.AddDays(1);
			labelWeek.Text = StartingDay.ToString("yyyy-MM-dd") + "    to    " + EndingDay.ToString("yyyy-MM-dd");

			string sql =
					" SELECT " + RankPlayerPayout.PrimaryKey + ",  date_prize, position, cash_prize/100 'Cash Prize', point_prize 'Points Prize',  " +
					" IF (concat(first_name, ' ' , last_name) IS NULL,card, concat(first_name, ' ' , last_name))Player, " +
					" total_points, paid " +
					" FROM " + Local.aRankPlayerPayouts.CompleteTableName + 
					" LEFT OUTER JOIN players_info USING (card) " +
					" WHERE date_prize >= '" + StartingDay.ToString("yyyy-MM-dd") + "' " +
					" AND date_prize <= '" + EndingDay.ToString("yyyy-MM-dd") + "' " +
					" AND position > 0 " +
					" AND removed = 0 " +
					" AND void = 0 " +
					" ORDER BY position ASC ";
			aTopPlayers = new MySQLDataTable(Local._dsn, sql);
			dataGridViewTopPlayers.DataSource = aTopPlayers;

			sql = " SELECT " + RankPlayerPayout.PrimaryKey + ", date_prize, position, cash_prize/100 'Cash Prize', point_prize 'Points Prize', " +
					" IF (concat(first_name, ' ' , last_name) IS NULL,card, concat(first_name, ' ' , last_name))Player, " +
					" total_points, paid " +
					" FROM " + Local.aRankPlayerPayouts.CompleteTableName +
					" LEFT OUTER JOIN players_info USING (card) " +
					" WHERE date_prize >= '" + StartingDay.ToString("yyyy-MM-dd") + "' " +
					" AND date_prize <= '" + EndingDay.ToString("yyyy-MM-dd") + "' " +
					" AND position < 0 " +
					" AND removed = 0 " +
					" AND void = 0 " +
					" ORDER BY position ASC ";
			aBottomPlayers = new MySQLDataTable(Local._dsn, sql);
			dataGridViewBottomPlayers.DataSource = aBottomPlayers;
			*/

			aRankWeeks = Local._dsn.GetDataTableQuery("SELECT * " +
				" FROM called_game_weeks WHERE bingoday_start < " + dateTimePickerFrom.Value.ToString("yyyyMMdd") +
				" AND bingoday_end >= " + dateTimePickerFrom.Value.ToString("yyyyMMdd"));

			if (aRankWeeks.Rows.Count == 0)
			{
				MessageBox.Show("Sorry That Period has not been set up in the System!", "Warning");
				return false;
			}
			else if (aRankWeeks.Rows.Count > 1)
			{
				MessageBox.Show("Sorry More than one Period associated with this day!", "Warning");
				return false;
			}
			else
			{
				StartingDay = Convert.ToDateTime(aRankWeeks.Rows[0]["bingoday_start"].ToString());
				EndingDay = Convert.ToDateTime(aRankWeeks.Rows[0]["bingoday_end"]).AddDays(-1);
				WeekId = Convert.ToInt64(aRankWeeks.Rows[0]["week_id"]);

				labelWeekTitle.Text = "Period: (" + WeekId + ") ";
				labelWeek.Text = StartingDay.ToString("yyyy-MM-dd") + "    to    " + EndingDay.AddDays(1).ToString("yyyy-MM-dd");

				string sql =
					" SELECT " + RankPlayerPayout.PrimaryKey + ",  date_prize, position, cash_prize/100 'Cash Prize', point_prize 'Points Prize',  " +
					" IF (concat(first_name, ' ' , last_name) IS NULL,card, concat(first_name, ' ' , last_name))Player, " +
					" total_points, paid " +
					" FROM " + Local.aRankPlayerPayouts.CompleteTableName +
					" LEFT OUTER JOIN players_info USING (card) " +
					" WHERE date_prize >= '" + StartingDay.ToString("yyyy-MM-dd") + "' " +
					" AND date_prize <= '" + EndingDay.ToString("yyyy-MM-dd") + "' " +
					" AND position > 0 " +
					" AND removed = 0 " +
					" AND void = 0 " +
					" ORDER BY position ASC ";
				aTopPlayers = new MySQLDataTable(Local._dsn, sql);
				int original_index = dataGridViewTopPlayers.FirstDisplayedScrollingRowIndex;
				dataGridViewTopPlayers.DataSource = aTopPlayers;
				if( original_index >= 0 && original_index < dataGridViewTopPlayers.Rows.Count )
					dataGridViewTopPlayers.FirstDisplayedScrollingRowIndex = original_index;

				sql = " SELECT " + RankPlayerPayout.PrimaryKey + ", date_prize, position, cash_prize/100 'Cash Prize', point_prize 'Points Prize', " +
						" IF (concat(first_name, ' ' , last_name) IS NULL,card, concat(first_name, ' ' , last_name))Player, " +
						" total_points, paid " +
						" FROM " + Local.aRankPlayerPayouts.CompleteTableName +
						" LEFT OUTER JOIN players_info USING (card) " +
						" WHERE date_prize >= '" + StartingDay.ToString("yyyy-MM-dd") + "' " +
						" AND date_prize <= '" + EndingDay.ToString("yyyy-MM-dd") + "' " +
						" AND position < 0 " +
						" AND removed = 0 " +
						" AND void = 0 " +
						" ORDER BY position ASC ";
				aBottomPlayers = new MySQLDataTable(Local._dsn, sql);
				original_index = dataGridViewBottomPlayers.FirstDisplayedScrollingRowIndex;
				dataGridViewBottomPlayers.DataSource = aBottomPlayers;
				if( original_index >= 0 && original_index < aBottomPlayers.Rows.Count )
					dataGridViewBottomPlayers.FirstDisplayedScrollingRowIndex = original_index;
				RepaintRankPlayers();
				return true;
			}
		}

		private void dataGridViewRankPlayers_Sorted(object sender, EventArgs e)
		{
			RepaintRankPlayers();
		}

		private void RepaintRankPlayers()
		{
			buttonCloseWeek.Text = "Close Period";
			if (aTopPlayers.Rows.Count > 0)
			{
				buttonCloseWeek.Text = "Re-Close Period";
				dataGridViewTopPlayers.Columns[RankPlayerPayout.PrimaryKey].Visible = false;
				dataGridViewTopPlayers.Columns["date_prize"].Visible = false;
				dataGridViewTopPlayers.Columns["paid"].Visible = false;
				dataGridViewTopPlayers.Columns["Cash Prize"].DefaultCellStyle.Format = "C2";

			}
			if (aBottomPlayers.Rows.Count > 0)
			{
				buttonCloseWeek.Text = "Re-Close Period";
				dataGridViewBottomPlayers.Columns[RankPlayerPayout.PrimaryKey].Visible = false;
				dataGridViewBottomPlayers.Columns["paid"].Visible = false;
				dataGridViewBottomPlayers.Columns["date_prize"].Visible = false;
				dataGridViewBottomPlayers.Columns["Cash Prize"].DefaultCellStyle.Format = "C2";
			}

			foreach (DataGridViewRow dgvr in dataGridViewTopPlayers.Rows)
			{
				if (dgvr.Cells["paid"].Value.ToString() == "0")
				{
					dgvr.Cells["TopPayColumn"].Value = "Pay";
					dgvr.DefaultCellStyle.BackColor = Color.White;
				}
				else
				{
					dgvr.Cells["TopPayColumn"].Value = "Un-Pay";
					dgvr.DefaultCellStyle.BackColor = Color.Coral;
				}
				if (dgvr.Index == aTopPlayerIndex)
					dgvr.Selected = true;
				else
					dgvr.Selected = false;
			}
			aTopPlayerIndex = -1;

			foreach (DataGridViewRow dgvr in dataGridViewBottomPlayers.Rows)
			{
				if (dgvr.Cells["paid"].Value.ToString() == "0")
				{
					dgvr.Cells["BottomPayColumn"].Value = "Pay";
					dgvr.DefaultCellStyle.BackColor = Color.White;
				}
				else
				{
					dgvr.Cells["BottomPayColumn"].Value = "Un-Pay";
					dgvr.DefaultCellStyle.BackColor = Color.Coral;
				}
				if (dgvr.Index == aBottomPlayerIndex)
					dgvr.Selected = true;
				else
					dgvr.Selected = false;
			}
			aBottomPlayerIndex = -1;

		}

		private void buttonSearchDate_Click(object sender, EventArgs e)
		{
			LoadRankPlayerGrids();
		}

		private void dataGridViewTopPlayers_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
			if (dataGridViewTopPlayers.Columns[e.ColumnIndex].Name == "TopPayColumn")
			{
				if (dataGridViewTopPlayers.Rows[e.RowIndex].Cells[e.ColumnIndex].Value == "Pay")
				{
					if (MessageBox.Show("Are you sure to Pay this Player?", "Pay Player", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
					{
						string sql = "position = " +
							dataGridViewTopPlayers.Rows[e.RowIndex].Cells["position"].Value +
							" AND date_prize >= '" + StartingDay.ToString("yyyy-MM-dd") + "' " +
							" AND date_prize <= '" + EndingDay.ToString("yyyy-MM-dd") + "' " +
							" AND removed = 0 AND void = 0 AND paid = 0";
						DataRow[] TopPlayersDr = Local.aRankPlayerPayouts.Select(sql);
						foreach (DataRow TopPlayerdr in TopPlayersDr)
						{
							TopPlayerdr["paid_on"] = DateTime.Now;
							TopPlayerdr["paid"] = 1;
							
							if (TopPlayerdr["point_prize"].ToString() != "0")
							{
								DateTime aDateTime = DateTime.Parse(TopPlayerdr["date_prize"].ToString());

								DataRow PlayerTrackRow = Local.aPlayerTrack.NewRow();
								PlayerTrackRow["transnum"] = "1" + aDateTime.ToString("yyMMdd") + TopPlayerdr["position"].ToString().PadLeft(3, '0');
								PlayerTrackRow["void_trans"] = 0;
								PlayerTrackRow["card"] = TopPlayerdr["card"];
								PlayerTrackRow["value"] = 0;
								PlayerTrackRow["points"] = TopPlayerdr["point_prize"];
								PlayerTrackRow["session"] = 0;
								PlayerTrackRow["cashier"] = "RankRater";
								PlayerTrackRow["bingoday"] = DateTime.Now;
								PlayerTrackRow["dummy_timestamp"] = DateTime.Now;
								PlayerTrackRow["transaction_whenstamp"] = DateTime.Now;
								Local.aPlayerTrack.Rows.Add(PlayerTrackRow);
								/*
								string date_prize = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
								string sql = "INSERT INTO player_track (transnum,void_trans,card,value,points,session,cashier,bingoday,dummy_timestamp,transaction_whenstamp)" +
									" VALUES ('" + "1" + aDateTime.ToString("yyMMdd") + TopPlayerdr["position"].ToString().PadLeft(3, '0') + "', " +
									" 0 , '" + TopPlayerdr["card"] + "', 0, " + TopPlayerdr["point_prize"] + ",0,'RankRater','" + DateTime.Now.ToString("yyyy-MM-dd") + "','" + date_prize + "','" + date_prize + "')";
								Local._dsn.ExecuteNonQuery(sql); 
								*/

							}
							Local.aRankPlayerPayouts.AcceptChanges();
							Local.aPlayerTrack.AcceptChanges();

							if (Local._ReceiptsTopPlayerEnable && Local._ReceiptsSystemEnable)
								PayoutReceipt(TopPlayerdr);
						}
					}
				}
				if (dataGridViewTopPlayers.Rows[e.RowIndex].Cells[e.ColumnIndex].Value == "Un-Pay")
				{
					if (MessageBox.Show("Are you sure to Void this Payout?", "Void Payout", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
					{
						string sql = "position = " +
							dataGridViewTopPlayers.Rows[e.RowIndex].Cells["position"].Value +
							" AND date_prize >= '" + StartingDay.ToString("yyyy-MM-dd") + "' " +
							" AND date_prize <= '" + EndingDay.ToString("yyyy-MM-dd") + "' " +
							" AND removed = 0 AND void = 0 AND paid = 1";
						DataRow[] TopPlayersDr = Local.aRankPlayerPayouts.Select(sql);
						foreach (DataRow TopPlayerdr in TopPlayersDr)
						{
							TopPlayerdr["paid"] = 0;
							
							if (TopPlayerdr["point_prize"].ToString() != "0")
							{
								DateTime aDateTime = DateTime.Parse(TopPlayerdr["date_prize"].ToString());
								DataRow PlayerTrackRow = Local.aPlayerTrack.NewRow();
								PlayerTrackRow["transnum"] = "1" + aDateTime.ToString("yyMMdd") + TopPlayerdr["position"].ToString().PadLeft(3, '0');
								PlayerTrackRow["void_trans"] = 0;
								PlayerTrackRow["card"] = TopPlayerdr["card"];
								PlayerTrackRow["value"] = 0;
								PlayerTrackRow["points"] = "-" + TopPlayerdr["point_prize"];
								PlayerTrackRow["session"] = 0;
								PlayerTrackRow["cashier"] = "RankRater";
								PlayerTrackRow["bingoday"] = DateTime.Now;
								PlayerTrackRow["transaction_whenstamp"] = DateTime.Now;
								Local.aPlayerTrack.Rows.Add(PlayerTrackRow);
								/*
								string date_prize = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
								string sql = "INSERT INTO player_track (transnum,void_trans,card,value,points,session,cashier,bingoday,dummy_timestamp,transaction_whenstamp)" +
									" VALUES ('" + "1" + aDateTime.ToString("yyMMdd") + TopPlayerdr["position"].ToString().PadLeft(3, '0') + "', " +
									" 0 , '" + TopPlayerdr["card"] + "', 0, -" + TopPlayerdr["point_prize"] + ",0,'RankRater','" + DateTime.Now.ToString("yyyy-MM-dd") + "','" + date_prize + "','" + date_prize + "')";
								Local._dsn.ExecuteNonQuery(sql);
								*/
							}
							Local.aRankPlayerPayouts.AcceptChanges();
							Local.aPlayerTrack.AcceptChanges();

							if (Local._ReceiptsTopPlayerEnable && Local._ReceiptsSystemEnable)
								UnPayReceipt(TopPlayerdr);
						}
					}
				}
				aTopPlayerIndex = e.RowIndex;
				LoadRankPlayerGrids();
				dataGridViewTopPlayers.FirstDisplayedScrollingRowIndex = e.RowIndex;
			}
		}

		private void dataGridViewBottomPlayers_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
			if (dataGridViewBottomPlayers.Columns[e.ColumnIndex].Name == "BottomPayColumn")
			{
				if (dataGridViewBottomPlayers.Rows[e.RowIndex].Cells[e.ColumnIndex].Value == "Pay")
				{
					if (MessageBox.Show("Are you sure to Pay this Player?", "Pay Player", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
					{
						string sql = "position = " +
							dataGridViewBottomPlayers.Rows[e.RowIndex].Cells["position"].Value +
							" AND date_prize >= '" + StartingDay.ToString("yyyy-MM-dd") + "' " +
							" AND date_prize <= '" + EndingDay.ToString("yyyy-MM-dd") + "' " +
							" AND removed = 0 AND void = 0 AND paid = 0";
						DataRow[] BottomPlayersDr = Local.aRankPlayerPayouts.Select(sql);
						foreach (DataRow BottomPlayerdr in BottomPlayersDr)
						{
							BottomPlayerdr["paid_on"] = DateTime.Now;
							BottomPlayerdr["paid"] = 1;
							if (BottomPlayerdr["point_prize"].ToString() != "0")
							{
								DateTime aDateTime = DateTime.Parse(BottomPlayerdr["date_prize"].ToString());
								int position = Convert.ToInt32(BottomPlayerdr["position"]);
								string transnum = "1" + aDateTime.ToString("yyMMdd") + "1" + (Math.Abs(position)).ToString().PadLeft(2, '0');

								DataRow PlayerTrackRow = Local.aPlayerTrack.NewRow();
								PlayerTrackRow["transnum"] = transnum;
								PlayerTrackRow["void_trans"] = 0;
								PlayerTrackRow["card"] = BottomPlayerdr["card"];
								PlayerTrackRow["value"] = 0;
								PlayerTrackRow["points"] = "-" + BottomPlayerdr["point_prize"];
								PlayerTrackRow["session"] = 0;
								PlayerTrackRow["cashier"] = "RankRater";
								PlayerTrackRow["bingoday"] = DateTime.Now;
								PlayerTrackRow["dummy_timestamp"] = DateTime.Now;
								PlayerTrackRow["transaction_whenstamp"] = DateTime.Now;
								Local.aPlayerTrack.Rows.Add(PlayerTrackRow);
								
								/*
								string date_prize = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

								string sql = "INSERT INTO player_track (transnum,void_trans,card,value,points,session,cashier,bingoday,dummy_timestamp,transaction_whenstamp)" +
									" VALUES ('" + "1" + aDateTime.ToString("yyMMdd") + BottomPlayerdr["position"].ToString().PadLeft(3, '0') + "', " +
									" 0 , '" + BottomPlayerdr["card"] + "', 0, " + BottomPlayerdr["point_prize"] + ",0,'RankRater','" + DateTime.Now.ToString("yyyy-MM-dd") + "','" + date_prize + "','" + date_prize + "')";
								Local._dsn.ExecuteNonQuery(sql);
								*/
							}
							Local.aRankPlayerPayouts.AcceptChanges();
							Local.aPlayerTrack.AcceptChanges();

							if (Local._ReceiptsTopPlayerEnable && Local._ReceiptsSystemEnable)
								PayoutReceipt(BottomPlayerdr);
						}
					}
				}
				if (dataGridViewBottomPlayers.Rows[e.RowIndex].Cells[e.ColumnIndex].Value == "Un-Pay")
				{
					if (MessageBox.Show("Are you sure to Void this Payout?", "Void Payout", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
					{
						string sql = "position = -" +
							dataGridViewBottomPlayers.Rows[e.RowIndex].Cells["position"].Value +
							" AND date_prize >= '" + StartingDay.ToString("yyyy-MM-dd") + "' " +
							" AND date_prize <= '" + EndingDay.ToString("yyyy-MM-dd") + "' " +
							" AND removed = 0 AND void = 0 AND paid = 1";

						DataRow[] BottomPlayersDr = Local.aRankPlayerPayouts.Select(sql);
						foreach (DataRow BottomPlayerdr in BottomPlayersDr)
						{
							BottomPlayerdr["paid"] = 0;
							if (BottomPlayerdr["point_prize"].ToString() != "0")
							{
								DateTime aDateTime = DateTime.Parse(BottomPlayerdr["date_prize"].ToString());
								int position = Convert.ToInt32(BottomPlayerdr["position"]);
								string transnum = "1" + aDateTime.ToString("yyMMdd") + "1" + (Math.Abs(position)).ToString().PadLeft(2, '0');

								DataRow PlayerTrackRow = Local.aPlayerTrack.NewRow();
								PlayerTrackRow["transnum"] = transnum;
								PlayerTrackRow["void_trans"] = 0;
								PlayerTrackRow["card"] = BottomPlayerdr["card"];
								PlayerTrackRow["value"] = 0;
								PlayerTrackRow["points"] = "-" + BottomPlayerdr["point_prize"];
								PlayerTrackRow["session"] = 0;
								PlayerTrackRow["cashier"] = "RankRater";
								PlayerTrackRow["bingoday"] = DateTime.Now;
								PlayerTrackRow["dummy_timestamp"] = DateTime.Now;
								PlayerTrackRow["transaction_whenstamp"] = DateTime.Now;
								Local.aPlayerTrack.Rows.Add(PlayerTrackRow);
								
								/*
								string date_prize = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

								string sql = "INSERT INTO player_track (transnum,void_trans,card,value,points,session,cashier,bingoday,dummy_timestamp,transaction_whenstamp)" +
									" VALUES ('" + "1" + aDateTime.ToString("yyMMdd") + BottomPlayerdr["position"].ToString().PadLeft(3, '0') + "', " +
									" 0 , '" + BottomPlayerdr["card"] + "', 0, -" + BottomPlayerdr["point_prize"] + ",0,'RankRater','" + DateTime.Now.ToString("yyyy-MM-dd") + "','" + date_prize + "','" + date_prize + "')";
								Local._dsn.ExecuteNonQuery(sql);
								*/
							}
							Local.aRankPlayerPayouts.AcceptChanges();
							Local.aPlayerTrack.AcceptChanges();

							if (Local._ReceiptsTopPlayerEnable && Local._ReceiptsSystemEnable)
								UnPayReceipt(BottomPlayerdr);
						}
					}
				}
				aBottomPlayerIndex = e.RowIndex;
				LoadRankPlayerGrids();
				dataGridViewBottomPlayers.FirstDisplayedScrollingRowIndex = e.RowIndex;
			}
		}

		private void PayoutReceipt(DataRow Winner)
		{
			if (((xperdex.classes.Money)Winner["cash_prize"]) == 0)
				return;
			string player_name = "Unknown";
			string hall_name = "Unknown";

			object result = Local._dsn.ExecuteScalar("SELECT CONCAT(first_name, ' ' , last_name) FROM players_info WHERE card = " + Winner["card"]);
			if (result != null)
				player_name = result.ToString();
			result = Local._dsn.ExecuteScalar("SELECT hall_name FROM hall_info WHERE hall_id = 1");
			if (result != null)
				hall_name = result.ToString();
			string receipt = Local._PrinterCommands.GetCommand(ReceiptPrinterCommands.genInitReceipt) +
				Local._PrinterCommands.GetCommand(ReceiptPrinterCommands.genLinefeed) +
				" !!! Payout Rank Prize !!! " +
				Local._PrinterCommands.GetCommand(ReceiptPrinterCommands.genLinefeed, 2) +
				"Hall: " + hall_name + Local._PrinterCommands.GetCommand(ReceiptPrinterCommands.genLinefeed) +
				"Version: 1.0 " + Local._PrinterCommands.GetCommand(ReceiptPrinterCommands.genLinefeed) +
				"Receipt Type: Payout Rank Prize" + Local._PrinterCommands.GetCommand(ReceiptPrinterCommands.genLinefeed) +
				"Date Printed: " + DateTime.Now.ToString() + Local._PrinterCommands.GetCommand(ReceiptPrinterCommands.genLinefeed) +
				"Player Card: " + Winner["card"] + Local._PrinterCommands.GetCommand(ReceiptPrinterCommands.genLinefeed) +
				"Player Name: " + player_name + Local._PrinterCommands.GetCommand(ReceiptPrinterCommands.genLinefeed) +
				"Period Starting On: " + Winner["date_prize"] + Local._PrinterCommands.GetCommand(ReceiptPrinterCommands.genLinefeed, 3) +
				"Payout of: " + Winner["cash_prize"] + Local._PrinterCommands.GetCommand(ReceiptPrinterCommands.genLinefeed) +
				"Player point account credit of: " + Winner["point_prize"] + " points " + Local._PrinterCommands.GetCommand(ReceiptPrinterCommands.genLinefeed, 3) +
				" Winner    : ____________________" + Local._PrinterCommands.GetCommand(ReceiptPrinterCommands.genLinefeed, 4) +
				" Supervisor: ____________________" + Local._PrinterCommands.GetCommand(ReceiptPrinterCommands.genLinefeed, 4) +
				" Agent     : ____________________" + Local._PrinterCommands.GetCommand(ReceiptPrinterCommands.genLinefeed, 4);
			if (((xperdex.classes.Money)Winner["cash_prize"]) >= 120000)
				receipt += " **** Needs W2 Form(s) !!! ****" + Local._PrinterCommands.GetCommand(ReceiptPrinterCommands.genLinefeed, 2);
			receipt += " =-=-=-=-=-=-=-=-=--=-=-=-=-=-=-=-=-=-=" + Local._PrinterCommands.GetCommand(ReceiptPrinterCommands.genLinefeed, 4) +
			Local._PrinterCommands.GetCommand(ReceiptPrinterCommands.genEndReceipt) +
			Local._PrinterCommands.GetCommand(ReceiptPrinterCommands.genCutPaper);
			GenerateReceipt(receipt);
		}
		private void UnPayReceipt(DataRow Winner)
		{
			if (((xperdex.classes.Money)Winner["cash_prize"]) == 0)
				return;
			string player_name = "Unknown";
			string hall_name = "Unknown";

			object result = Local._dsn.ExecuteScalar("SELECT CONCAT(first_name, ' ' , last_name) FROM players_info WHERE card = " + Winner["card"]);
			if (result != null)
				player_name = result.ToString();
			result = Local._dsn.ExecuteScalar("SELECT hall_name FROM hall_info WHERE hall_id = 1");
			if (result != null)
				hall_name = result.ToString();
			string receipt = Local._PrinterCommands.GetCommand(ReceiptPrinterCommands.genInitReceipt) +
				Local._PrinterCommands.GetCommand(ReceiptPrinterCommands.genLinefeed) +
				" !!! Un- Pay Rank Prize !!! " +
				Local._PrinterCommands.GetCommand(ReceiptPrinterCommands.genLinefeed, 2) +
				"Hall: " + hall_name + Local._PrinterCommands.GetCommand(ReceiptPrinterCommands.genLinefeed) +
				"Version: 1.0 " + Local._PrinterCommands.GetCommand(ReceiptPrinterCommands.genLinefeed) +
				"Receipt Type: Un Pay Rank Prize" + Local._PrinterCommands.GetCommand(ReceiptPrinterCommands.genLinefeed) +
				"Date Printed: " + DateTime.Now.ToString() + Local._PrinterCommands.GetCommand(ReceiptPrinterCommands.genLinefeed) +
				"Player Card: " + Winner["card"] + Local._PrinterCommands.GetCommand(ReceiptPrinterCommands.genLinefeed) +
				"Player Name: " + player_name + Local._PrinterCommands.GetCommand(ReceiptPrinterCommands.genLinefeed) +
				"Period Starting On: " + Winner["date_prize"] + Local._PrinterCommands.GetCommand(ReceiptPrinterCommands.genLinefeed, 3) +
				"Cancell payout of: " + Winner["cash_prize"] + Local._PrinterCommands.GetCommand(ReceiptPrinterCommands.genLinefeed) +
				"Cancell player point account credit of: " + Winner["point_prize"] + " points " + Local._PrinterCommands.GetCommand(ReceiptPrinterCommands.genLinefeed, 3) +
				" Supervisor: ____________________" + Local._PrinterCommands.GetCommand(ReceiptPrinterCommands.genLinefeed, 4);
			receipt += " =-=-=-=-=-=-=-=-=--=-=-=-=-=-=-=-=-=-=" + Local._PrinterCommands.GetCommand(ReceiptPrinterCommands.genLinefeed, 4) +
			Local._PrinterCommands.GetCommand(ReceiptPrinterCommands.genEndReceipt) +
			Local._PrinterCommands.GetCommand(ReceiptPrinterCommands.genCutPaper);
			GenerateReceipt(receipt);
		}

		private void GenerateReceipt(string receipt)
		{
			for (int count_copies = 1; count_copies <= Local._ReceiptsCopies; count_copies++)
			{
				if (Local._ReceiptsSystemProtocol == "POS")
				{
					CUIC.ThermPrints.POSThermPrint printReceipt = new CUIC.ThermPrints.POSThermPrint();
					printReceipt.PrintString(receipt);
				}
				else if (Local._ReceiptsSystemProtocol == "REG")
				{
					CUIC.ThermPrints.REGThermPrint printReceipt = new CUIC.ThermPrints.REGThermPrint();
					printReceipt.Port = Local._ReceiptsSystemPort;
					printReceipt.PrintString(receipt);
				}
				else if (Local._ReceiptsSystemProtocol == "HTML")
				{
					CUIC.ReceiptBrowser.ReceiptBrowserForm aReceiptBrowserForm = new CUIC.ReceiptBrowser.ReceiptBrowserForm();
					aReceiptBrowserForm.LoadReceipt(receipt);
					aReceiptBrowserForm.ShowDialog();
					return;
				}
			}
		}

		private void buttonCloseWeek_Click(object sender, EventArgs e)
		{
			bool continue_flag = LoadRankPlayerGrids();
			bool paid_void_flag = true;
			int position = 0;
			if (continue_flag && (aTopPlayers.Rows.Count > 0 || aBottomPlayers.Rows.Count > 0))
				continue_flag = (MessageBox.Show("Are you sure to Re-Close this Period?", "Re-Close Period", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes);
			if (continue_flag)
			{
				string sql = " SELECT a1.card, total_points" +
								" FROM called_game_player_rank_partial a1 " +
								" WHERE week_id = " + WeekId +
								" ORDER BY total_points DESC ";

				aRankPlayers = new MySQLDataTable(Local._dsn, sql);


				if (aRankPlayers.Rows.Count == 0)
				{
					MessageBox.Show("No Winners for this Period!");
				}
				else
				{
					DataRow[] PayoutTopPrizes = Local.aRankPlayerPrizes.Select("position > 0 ", "position");
					string calculated_positions = "";
					foreach (DataRow PayoutTopPrizesdr in PayoutTopPrizes)
					{
						position = Convert.ToInt32(PayoutTopPrizesdr["position"]);
						calculated_positions += " ," + PayoutTopPrizesdr["position"].ToString();
						
						paid_void_flag = false;
						DataRow[] TopPlayersDr = Local.aRankPlayerPayouts.Select("date_prize= '" + StartingDay.ToString("yyyy-MM-dd") + "' AND position = " + position + " AND removed = 0 ");
						foreach (DataRow TopPlayerdr in TopPlayersDr)
						{
							if (TopPlayerdr["paid"].ToString() != "1" && TopPlayerdr["void"].ToString() != "1")
							{
								TopPlayerdr["removed"] = "1";
								TopPlayerdr["removed_on"] = DateTime.Now;
							}
							else
								paid_void_flag = true;
						}
						if (!paid_void_flag && aRankPlayers.Rows.Count >= position)
						{
							DataRow TopPlayerPayout = Local.aRankPlayerPayouts.NewRow();
							TopPlayerPayout["date_prize"] = StartingDay.ToString("yyyy-MM-dd");
							TopPlayerPayout["position"] = position;
							TopPlayerPayout["card"] = aRankPlayers.Rows[position - 1]["card"];
							TopPlayerPayout["total_points"] = aRankPlayers.Rows[position - 1]["total_points"];

							TopPlayerPayout["cash_prize"] = (Money)PayoutTopPrizesdr["cash_prize"];
							TopPlayerPayout["point_prize"] = PayoutTopPrizesdr["point_prize"];
							TopPlayerPayout["created_on"] = DateTime.Now;
							TopPlayerPayout["paid"] = 0;
							TopPlayerPayout["void"] = 0;
							TopPlayerPayout["removed"] = 0;
							Local.aRankPlayerPayouts.Rows.Add(TopPlayerPayout);
						}
					}
					Local.aRankPlayerPayouts.AcceptChanges();
					
					sql = " SELECT a1.card, total_points" +
									" FROM called_game_player_rank_partial a1 " +
									" WHERE week_id = " + WeekId +
									" ORDER BY total_points ASC ";

					aRankPlayers = new MySQLDataTable(Local._dsn, sql);


					DataRow[] PayoutBottomPrizes = Local.aRankPlayerPrizes.Select("position < 0", "position DESC");
					foreach (DataRow PayoutBottomPrizedr in PayoutBottomPrizes)
					{
						position = Math.Abs(Convert.ToInt32(PayoutBottomPrizedr["position"]));
						calculated_positions += " ,-" + PayoutBottomPrizedr["position"].ToString();
						paid_void_flag = false;
						DataRow[] BottomPlayersDr = Local.aRankPlayerPayouts.Select("date_prize= '" + StartingDay.ToString("yyyy-MM-dd") + "' AND position = -" + position + " AND removed = 0 ");
						foreach (DataRow BottomPlayerdr in BottomPlayersDr)
						{
							if (BottomPlayerdr["paid"].ToString() != "1" && BottomPlayerdr["void"].ToString() != "1")
							{
								BottomPlayerdr["removed"] = "1";
								BottomPlayerdr["removed_on"] = DateTime.Now;
							}
							else
								paid_void_flag = true;
						}
						if (!paid_void_flag && aRankPlayers.Rows.Count >= position)
						{
							DataRow BottomPlayerPayout = Local.aRankPlayerPayouts.NewRow();
							BottomPlayerPayout["date_prize"] = StartingDay.ToString("yyyy-MM-dd");
							BottomPlayerPayout["position"] = "-" + position;
							BottomPlayerPayout["card"] = aRankPlayers.Rows[position - 1]["card"];
							BottomPlayerPayout["total_points"] = aRankPlayers.Rows[position - 1]["total_points"];

							BottomPlayerPayout["cash_prize"] = (Money)PayoutBottomPrizedr["cash_prize"];
							BottomPlayerPayout["point_prize"] = PayoutBottomPrizedr["point_prize"];
							BottomPlayerPayout["created_on"] = DateTime.Now;
							BottomPlayerPayout["paid"] = 0;
							BottomPlayerPayout["void"] = 0;
							BottomPlayerPayout["removed"] = 0;
							Local.aRankPlayerPayouts.Rows.Add(BottomPlayerPayout);
						}
					}
					Local.aRankPlayerPayouts.AcceptChanges();

					if (calculated_positions.Length > 0)
					{
						calculated_positions = calculated_positions.Remove(0,2);
						DataRow[] OtherPositionPlayersDr = Local.aRankPlayerPayouts.Select("date_prize= '" + StartingDay.ToString("yyyy-MM-dd") + "' AND position NOT IN (" + calculated_positions + ") AND removed = 0 ");
						foreach (DataRow OtherPositionPlayer in OtherPositionPlayersDr)
						{
							if (OtherPositionPlayer["paid"].ToString() != "1" && OtherPositionPlayer["void"].ToString() != "1")
							{
								OtherPositionPlayer["removed"] = "1";
								OtherPositionPlayer["removed_on"] = DateTime.Now;
							}							
						}
						Local.aRankPlayerPayouts.AcceptChanges();
					}
				}

				LoadRankPlayerGrids();
			}
		}

		private void weekPlayersToolStripMenuItem_Click(object sender, EventArgs e)
		{
			WeekPlayerReport aWeekPlayerReport = new WeekPlayerReport();
			aWeekPlayerReport.SetReport(dateTimePickerFrom.Value);
			aWeekPlayerReport.ShowDialog();
		}

		private void rankPrizesToolStripMenuItem_Click(object sender, EventArgs e)
		{
			RankPrizesForm aRankPrizesForm = new RankPrizesForm();
			aRankPrizesForm.ShowDialog();
		}

		private void generalSettingsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			(new OptionEditor()).ShowDialog();
		}


		private void playerPointsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			MessageBox.Show("Under Construction!");
		}

		private void paidPrizesToolStripMenuItem_Click_1(object sender, EventArgs e)
		{
			PrizesReport aUnclaimPrizesReport = new PrizesReport();
			aUnclaimPrizesReport.SetReport(dateTimePickerFrom.Value);
			aUnclaimPrizesReport.ShowDialog();
		}

		private void listBoxCardsRead_DoubleClick(object sender, EventArgs e)
		{
			SearchPlayer();
		}

		private void buttonSearchPlayer_Click(object sender, EventArgs e)
		{
			SearchPlayer();
		}

		private void SearchPlayer()
		{
			if (listBoxCardsRead.SelectedItem == null)
			{
				if (aChoosenPlayersForm == null || aChoosenPlayersForm.IsDisposed)
				{
					aChoosenPlayersForm = new ChoosenPlayersForm();
					aChoosenPlayersForm.ShowDialog();
				}
				else
				{
					if (!aChoosenPlayersForm.ContainsFocus)
						aChoosenPlayersForm.ShowDialog();
				}
			}
			else
			{
				if (aChoosenPlayersForm == null || aChoosenPlayersForm.IsDisposed)
				{
					aChoosenPlayersForm = new ChoosenPlayersForm();
					aChoosenPlayersForm.SetReport(dateTimePickerFrom.Value, listBoxCardsRead.SelectedItem.ToString());
					aChoosenPlayersForm.ShowDialog();
				}
				else
				{
					aChoosenPlayersForm.SetReport(dateTimePickerFrom.Value, listBoxCardsRead.SelectedItem.ToString());
					if (!aChoosenPlayersForm.ContainsFocus)
						aChoosenPlayersForm.ShowDialog();
				}
			}
			LoadRankPlayerGrids();
			listBoxCardsRead.SelectedItem = null;
		}

		private void playerToolStripMenuItem_Click(object sender, EventArgs e)
		{
			PlayerParticipationReport aPlayerParticipationReport = new PlayerParticipationReport();
			aPlayerParticipationReport.SetReport(dateTimePickerFrom.Value);
			aPlayerParticipationReport.ShowDialog();
		}

		

		private void buttonPayTopNonCash_Click(object sender, EventArgs e)
		{
			PayToNonCashWinners("Top");
		}

		private void buttonPayBottomNonCash_Click(object sender, EventArgs e)
		{
			PayToNonCashWinners("Bottom");
		}

		private void playerWinLossToolStripMenuItem_Click(object sender, EventArgs e)
		{
			MessageBox.Show("Under Construction!");
		}

		private void PayToNonCashWinners(string position_side)
		{


			if (MessageBox.Show("Are you sure to Pay All non cash " + position_side  + " Prizes?", "Pay Non Cash Prizes", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
			{
				if (position_side == "Top")
					position_side = " and position > 0 ";
				if (position_side == "Bottom")
					position_side = " and position < 0 ";
				string sql = " date_prize >= '" + StartingDay.ToString("yyyy-MM-dd") + "' " +
					" AND date_prize <= '" + EndingDay.ToString("yyyy-MM-dd") + "' " +
					" AND removed = 0 AND void = 0 AND paid = 0 " + position_side;
				DataRow[] NonCashPayoutsDr = Local.aRankPlayerPayouts.Select(sql);
				foreach (DataRow NonCashPayoutDr in NonCashPayoutsDr)
				{
					if (NonCashPayoutDr["cash_prize"].ToString() == "$0.00")
					{
						NonCashPayoutDr["paid_on"] = DateTime.Now;
						NonCashPayoutDr["paid"] = 1;
						if (NonCashPayoutDr["point_prize"].ToString() != "0")
						{
							DateTime aDateTime = DateTime.Parse(NonCashPayoutDr["date_prize"].ToString());
							int position = Convert.ToInt32(NonCashPayoutDr["position"]);
							string transnum = "1" + aDateTime.ToString("yyMMdd") + "1" + (Math.Abs(position)).ToString().PadLeft(2, '0');

							DataRow PlayerTrackRow = Local.aPlayerTrack.NewRow();
							PlayerTrackRow["transnum"] = transnum;
							PlayerTrackRow["void_trans"] = 0;
							PlayerTrackRow["card"] = NonCashPayoutDr["card"];
							PlayerTrackRow["value"] = 0;
							PlayerTrackRow["points"] = NonCashPayoutDr["point_prize"];
							PlayerTrackRow["session"] = 0;
							PlayerTrackRow["cashier"] = "RankRater";
							PlayerTrackRow["bingoday"] = DateTime.Now;
							PlayerTrackRow["dummy_timestamp"] = DateTime.Now;
							PlayerTrackRow["transaction_whenstamp"] = DateTime.Now;
							Local.aPlayerTrack.Rows.Add(PlayerTrackRow);

							/*
							string date_prize = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

							string sql = "INSERT INTO player_track (transnum,void_trans,card,value,points,session,cashier,bingoday,dummy_timestamp,transaction_whenstamp)" +
								" VALUES ('" + "1" + aDateTime.ToString("yyMMdd") + BottomPlayerdr["position"].ToString().PadLeft(3, '0') + "', " +
								" 0 , '" + BottomPlayerdr["card"] + "', 0, " + BottomPlayerdr["point_prize"] + ",0,'RankRater','" + DateTime.Now.ToString("yyyy-MM-dd") + "','" + date_prize + "','" + date_prize + "')";
							Local._dsn.ExecuteNonQuery(sql);
							*/


						}
						/*
						 * // WILL NEVER HAPPEN
						 * 
						if (NonCashPayoutDr["cash_prize"].ToString() != "$0.00")
						{
							if (Local._ReceiptsTopPlayerEnable && Local._ReceiptsSystemEnable)
								PayoutReceipt(NonCashPayoutDr);
						}
						*/
						Local.aRankPlayerPayouts.AcceptChanges();
						Local.aPlayerTrack.AcceptChanges();
					}
				}
				LoadRankPlayerGrids();
			}
		}

		private void PayToCashWinners(string position_side)
		{
			if (MessageBox.Show("Are you sure to Pay All Cash " + position_side + " Prizes?", "Pay Cash Prizes", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
			{
				if (position_side == "Top")
					position_side = " and position > 0 ";
				if (position_side == "Bottom")
					position_side = " and position < 0 ";
				string sql = " date_prize >= '" + StartingDay.ToString("yyyy-MM-dd") + "' " +
					" AND date_prize <= '" + EndingDay.ToString("yyyy-MM-dd") + "' " +
					" AND removed = 0 AND void = 0 AND paid = 0 " + position_side;
				DataRow[] CashPayoutsDr = Local.aRankPlayerPayouts.Select(sql);
				foreach (DataRow CashPayoutDr in CashPayoutsDr)
				{
					if (CashPayoutDr["cash_prize"].ToString() != "$0.00")
					{
						CashPayoutDr["paid_on"] = DateTime.Now;
						CashPayoutDr["paid"] = 1;
						if (CashPayoutDr["point_prize"].ToString() != "0")
						{
							DateTime aDateTime = DateTime.Parse(CashPayoutDr["date_prize"].ToString());
							int position = Convert.ToInt32(CashPayoutDr["position"]);
							string transnum = "1" + aDateTime.ToString("yyMMdd") + "1" + (Math.Abs(position)).ToString().PadLeft(2, '0');

							DataRow PlayerTrackRow = Local.aPlayerTrack.NewRow();
							PlayerTrackRow["transnum"] = transnum;
							PlayerTrackRow["void_trans"] = 0;
							PlayerTrackRow["card"] = CashPayoutDr["card"];
							PlayerTrackRow["value"] = 0;
							PlayerTrackRow["points"] = CashPayoutDr["point_prize"];
							PlayerTrackRow["session"] = 0;
							PlayerTrackRow["cashier"] = "RankRater";
							PlayerTrackRow["bingoday"] = DateTime.Now;
							PlayerTrackRow["dummy_timestamp"] = DateTime.Now;
							PlayerTrackRow["transaction_whenstamp"] = DateTime.Now;
							Local.aPlayerTrack.Rows.Add(PlayerTrackRow);

							/*
							string date_prize = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

							string sql = "INSERT INTO player_track (transnum,void_trans,card,value,points,session,cashier,bingoday,dummy_timestamp,transaction_whenstamp)" +
								" VALUES ('" + "1" + aDateTime.ToString("yyMMdd") + BottomPlayerdr["position"].ToString().PadLeft(3, '0') + "', " +
								" 0 , '" + BottomPlayerdr["card"] + "', 0, " + BottomPlayerdr["point_prize"] + ",0,'RankRater','" + DateTime.Now.ToString("yyyy-MM-dd") + "','" + date_prize + "','" + date_prize + "')";
							Local._dsn.ExecuteNonQuery(sql);
							*/


						}
						if (Local._ReceiptsTopPlayerEnable && Local._ReceiptsSystemEnable)
							PayoutReceipt(CashPayoutDr);
						Local.aRankPlayerPayouts.AcceptChanges();
						Local.aPlayerTrack.AcceptChanges();
					}
				}
				LoadRankPlayerGrids();
			}
		}

	}
}
