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
	public partial class ChoosenPlayersForm : Form
	{
		/*
		GDAL.Players.TopPlayers aTopPlayers = new GDAL.Players.TopPlayers();
		GDAL.Players.PlayersInfo aPlayerInfo = new GDAL.Players.PlayersInfo();
		GDAL.Players.TopPlayerPayout aTopPlayerPayout = new GDAL.Players.TopPlayerPayout();
		GDAL.Players.TopPlayerPrizes aTopPlayerPrizes = new GDAL.Players.TopPlayerPrizes();
		*/

		DataTable aRankPlayers;
		DataTable aTopPlayers;
		
		DateTime StartingDay;
		DateTime EndingDay;
		
		bool main_loaded = true;

		
		public ChoosenPlayersForm()
		{
			InitializeComponent();
		}

		public bool SetReport(DateTime aDateTime, string card_scanned)
		{
			dateTimePickerTo.Value = aDateTime;
			dateTimePickerFrom.Value = dateTimePickerTo.Value.AddDays(-7);
			listBoxCardsRead.Items.Add(card_scanned);
			listBoxCardsRead.SetSelected(listBoxCardsRead.Items.Count - 1, true);
			string item = card_scanned;
			textBoxCard.Text = item.Remove(0, item.LastIndexOf(':') + 1);
			main_loaded = false;
			return LoadPayoutPlayerGrid();	
		}
						
		private void TopPlayersForm_Load(object sender, EventArgs e)
		{
			if (main_loaded)
			{
				dateTimePickerTo.Value = DateTime.Now;
				dateTimePickerFrom.Value = dateTimePickerTo.Value.AddDays(-7);
				//LoadPayoutPlayerGrid();
			}
			RepaintPayoutPlayer();											
		}


		private bool LoadPayoutPlayerGrid()
		{
			if (textBoxCard.Text == "")
				MessageBox.Show("Please Type / Select a Card!");
			else
			{
				string card = textBoxCard.Text;	
				string sql_aux = "";
				if (radioButtonPaidPrizes.Checked)
				{
					sql_aux = " AND paid = 1 ";
				}
				if (radioButtonUnclaim.Checked)
				{
					sql_aux = " AND paid = 0 ";
				}
				if (checkBoxByDate.Checked)
				{
					sql_aux += " AND date_prize >= '" + dateTimePickerFrom.Value.ToString("yyyy-MM-dd") + "' " +
						 " AND date_prize <= '" + dateTimePickerTo.Value.ToString("yyyy-MM-dd") + "' ";
				}

				string sql =
						" SELECT " + RankPlayerPayout.PrimaryKey + ",  date_prize, position, cash_prize/100 'Cash Prize', point_prize 'Points Prize',  " +
						" IF (concat(first_name, ' ' , last_name) IS NULL,card, concat(first_name, ' ' , last_name))Player, " +
						" total_points, paid " +
						" FROM " + Local.aRankPlayerPayouts.CompleteTableName +
						" LEFT OUTER JOIN players_info USING (card) " +
						" WHERE card = " + card +
						" AND removed = 0 " +
						" AND void = 0 " +
						sql_aux +
						" ORDER BY position ASC ";
				aTopPlayers = new MySQLDataTable(Local._dsn, sql);
				dataGridViewTopPlayers.DataSource = aTopPlayers;

				
				if (aTopPlayers.Rows.Count == 0)
				{
					MessageBox.Show("No records for card: " + card);
					labelPlayerName.Text = "";
					return false;
				}
				else
				{
					RepaintPayoutPlayer();
					labelPlayerName.Text = aTopPlayers.Rows[0]["Player"].ToString();
					return true;					
				}
			}
			return false;				
		}

		private void dataGridViewRankPlayers_Sorted(object sender, EventArgs e)
		{
			RepaintPayoutPlayer();
		}

		private void RepaintPayoutPlayer()
		{
			if (aTopPlayers != null)
			{
				if (aTopPlayers.Rows.Count > 0)
				{
					dataGridViewTopPlayers.Columns[RankPlayerPayout.PrimaryKey].Visible = false;
					dataGridViewTopPlayers.Columns["date_prize"].Visible = false;
					dataGridViewTopPlayers.Columns["paid"].Visible = false;
					dataGridViewTopPlayers.Columns["Cash Prize"].DefaultCellStyle.Format = "C2";
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
				}
			}
		}
	
		private void buttonSearchDate_Click(object sender, EventArgs e)
		{
			LoadPayoutPlayerGrid();
		}

		private void dataGridViewTopPlayers_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
			if (dataGridViewTopPlayers.Columns[e.ColumnIndex].Name == "TopPayColumn")
			{
				if (dataGridViewTopPlayers.Rows[e.RowIndex].Cells[e.ColumnIndex].Value == "Pay")
				{
					if (MessageBox.Show("Are you sure to Pay this Player?", "Pay Player", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
					{
						DataRow[] TopPlayersDr = Local.aRankPlayerPayouts.Select("position = " +
							dataGridViewTopPlayers.Rows[e.RowIndex].Cells["position"].Value +
							" AND removed = 0 AND void = 0 AND paid = 0");
						foreach (DataRow TopPlayerdr in TopPlayersDr)
						{
							TopPlayerdr["paid_on"] = DateTime.Now;
							TopPlayerdr["paid"] = 1;
							if (TopPlayerdr["point_prize"].ToString() != "0")
							{
								DateTime aDateTime = DateTime.Parse(TopPlayerdr["date_prize"].ToString());

								string transnum = "1" + aDateTime.ToString("yyMMdd");
								int position = Convert.ToInt32(TopPlayerdr["position"]);
								if (position < 0)
									transnum += "1";
								transnum += (Math.Abs(position)).ToString().PadLeft(2, '0');
								
								DataRow PlayerTrackRow = Local.aPlayerTrack.NewRow();
								PlayerTrackRow["transnum"] = transnum; 
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
									" 0 , '" + TopPlayerdr["card"] + "', 0, -" + TopPlayerdr["point_prize"] + ",0,'RankRater','" + DateTime.Now.ToString("yyyy-MM-dd") + "','" + date_prize + "','" + date_prize + "')";
								Local._dsn.ExecuteNonQuery(sql);
								 * */
							}
							Local.aRankPlayerPayouts.AcceptChanges();
							Local.aPlayerTrack.AcceptChanges();

							if (Local._ReceiptsTopPlayerEnable && Local._ReceiptsSystemEnable)
								PayoutReceipt(TopPlayerdr);
						}
						Local.aRankPlayerPayouts.AcceptChanges();
						Local.aPlayerTrack.AcceptChanges();

					}
				}
				if (dataGridViewTopPlayers.Rows[e.RowIndex].Cells[e.ColumnIndex].Value == "Un-Pay")
				{
					if (MessageBox.Show("Are you sure to Void this Payout?", "Void Payout", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
					{
						DataRow[] TopPlayersDr = Local.aRankPlayerPayouts.Select("position = " +
							dataGridViewTopPlayers.Rows[e.RowIndex].Cells["position"].Value +
							" AND removed = 0 AND void = 0 AND paid = 1");
						foreach (DataRow TopPlayerdr in TopPlayersDr)
						{
							TopPlayerdr["paid"] = 0;
							if (TopPlayerdr["point_prize"].ToString() != "0")
							{
								DateTime aDateTime = DateTime.Parse(TopPlayerdr["date_prize"].ToString());
								string transnum =  "1" + aDateTime.ToString("yyMMdd");
								int position = Convert.ToInt32(TopPlayerdr["position"]);
								if (position < 0 )
									transnum += "1";
								transnum += (Math.Abs(position)).ToString().PadLeft(2, '0');
								
								DataRow PlayerTrackRow = Local.aPlayerTrack.NewRow();
								PlayerTrackRow["transnum"] = transnum; 
								PlayerTrackRow["void_trans"] = 0;
								PlayerTrackRow["card"] = TopPlayerdr["card"]; 
								PlayerTrackRow["value"] = 0;
								PlayerTrackRow["points"] = "-" + TopPlayerdr["point_prize"];
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
									" 0 , '" + TopPlayerdr["card"] + "', 0, -" + TopPlayerdr["point_prize"] + ",0,'RankRater','" + DateTime.Now.ToString("yyyy-MM-dd") + "','" + date_prize + "','" + date_prize + "')";
								Local._dsn.ExecuteNonQuery(sql);
								 * */
							}
							Local.aRankPlayerPayouts.AcceptChanges();
							Local.aPlayerTrack.AcceptChanges();
							if (Local._ReceiptsTopPlayerEnable && Local._ReceiptsSystemEnable)
								UnPayReceipt(TopPlayerdr);
						}
					}
				}
				LoadPayoutPlayerGrid();				
			}
		}

		private void PayoutReceipt(DataRow Winner)
		{
			if( (xperdex.classes.Money)Winner["cash_prize"] == 0 )
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
				"Week Starting On: " + Winner["date_prize"] + Local._PrinterCommands.GetCommand(ReceiptPrinterCommands.genLinefeed, 3) +
				"Payout of: " + Winner["cash_prize"] + Local._PrinterCommands.GetCommand(ReceiptPrinterCommands.genLinefeed) +
				"Player point account credit of: " + Winner["point_prize"] + " points " + Local._PrinterCommands.GetCommand(ReceiptPrinterCommands.genLinefeed, 3) +
				" Printed By: ____________________" + Local._PrinterCommands.GetCommand(ReceiptPrinterCommands.genLinefeed, 4)+
				" Supervisor: ____________________" + Local._PrinterCommands.GetCommand(ReceiptPrinterCommands.genLinefeed, 4)+
				" Manager: ____________________" + Local._PrinterCommands.GetCommand(ReceiptPrinterCommands.genLinefeed, 4);
			if (((xperdex.classes.Money)Winner["cash_prize"]) >= 120000)
					receipt += " **** Needs W2 Form(s) !!! ****" + Local._PrinterCommands.GetCommand(ReceiptPrinterCommands.genLinefeed, 2);
				receipt += " =-=-=-=-=-=-=-=-=--=-=-=-=-=-=-=-=-=-=" + Local._PrinterCommands.GetCommand(ReceiptPrinterCommands.genLinefeed, 4) +
				Local._PrinterCommands.GetCommand(ReceiptPrinterCommands.genEndReceipt) +
				Local._PrinterCommands.GetCommand(ReceiptPrinterCommands.genCutPaper); 
			GenerateReceipt(receipt);			
		}
		private void UnPayReceipt(DataRow Winner)
		{
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
				"Date Printed: " +DateTime.Now.ToString()  + Local._PrinterCommands.GetCommand(ReceiptPrinterCommands.genLinefeed) +
				"Player Card: " + Winner["card"] + Local._PrinterCommands.GetCommand(ReceiptPrinterCommands.genLinefeed) +
				"Player Name: " + player_name + Local._PrinterCommands.GetCommand(ReceiptPrinterCommands.genLinefeed) +
				"Week Starting On: " + Winner["date_prize"] + Local._PrinterCommands.GetCommand(ReceiptPrinterCommands.genLinefeed, 3) +
				"Cancell payout of: " + Winner["cash_prize"] + Local._PrinterCommands.GetCommand(ReceiptPrinterCommands.genLinefeed) +
				"Cancell player point account credit of: " + Winner["point_prize"] + " points " + Local._PrinterCommands.GetCommand(ReceiptPrinterCommands.genLinefeed, 3) +
				" Printed By: ____________________" + Local._PrinterCommands.GetCommand(ReceiptPrinterCommands.genLinefeed, 4)+
				" Supervisor: ____________________" + Local._PrinterCommands.GetCommand(ReceiptPrinterCommands.genLinefeed, 4)+
				" Manager: ____________________" + Local._PrinterCommands.GetCommand(ReceiptPrinterCommands.genLinefeed, 4);
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
		private void buttonPayout_Click(object sender, EventArgs e)
		{
			MessageBox.Show("Under Construction!");
		}

		private void listBoxCardsRead_DoubleClick(object sender, EventArgs e)
		{
			textBoxCard.Text = "";
			if (listBoxCardsRead.SelectedItem != null)
			{
				string item = listBoxCardsRead.SelectedItem.ToString();
				textBoxCard.Text = item.Remove(0, item.LastIndexOf(':') + 1);
			}
			else
			{
				MessageBox.Show("Please Select a Card!");					
			}
			LoadPayoutPlayerGrid();
		}

		private void buttonClose_Click(object sender, EventArgs e)
		{
			this.Dispose();
		}

		private void buttonPrintReport_Click(object sender, EventArgs e)
		{
			 MessageBox.Show("Under Construction");	
		}

				

	}
}