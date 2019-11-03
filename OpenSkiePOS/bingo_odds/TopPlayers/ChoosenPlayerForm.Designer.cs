namespace TopPlayers
{
	partial class ChoosenPlayersForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
			this.dataGridViewTopPlayers = new System.Windows.Forms.DataGridView();
			this.TopPayColumn = new System.Windows.Forms.DataGridViewButtonColumn();
			this.buttonPayTop = new System.Windows.Forms.Button();
			this.buttonSearchDate = new System.Windows.Forms.Button();
			this.labelBottomPlayers = new System.Windows.Forms.Label();
			this.buttonPrintReport = new System.Windows.Forms.Button();
			this.checkBoxByDate = new System.Windows.Forms.CheckBox();
			this.radioButtonPaidPrizes = new System.Windows.Forms.RadioButton();
			this.radioButtonAllPrizes = new System.Windows.Forms.RadioButton();
			this.radioButtonUnclaim = new System.Windows.Forms.RadioButton();
			this.dateTimePickerTo = new System.Windows.Forms.DateTimePicker();
			this.dateTimePickerFrom = new System.Windows.Forms.DateTimePicker();
			this.label1 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.listBoxCardsRead = new System.Windows.Forms.ListBox();
			this.buttonClose = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.labelPlayerName = new System.Windows.Forms.Label();
			this.textBoxCard = new System.Windows.Forms.TextBox();
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewTopPlayers)).BeginInit();
			this.SuspendLayout();
			// 
			// dataGridViewTopPlayers
			// 
			this.dataGridViewTopPlayers.AllowUserToAddRows = false;
			this.dataGridViewTopPlayers.AllowUserToDeleteRows = false;
			this.dataGridViewTopPlayers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.dataGridViewTopPlayers.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
			this.dataGridViewTopPlayers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridViewTopPlayers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TopPayColumn});
			dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
			dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
			dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.dataGridViewTopPlayers.DefaultCellStyle = dataGridViewCellStyle8;
			this.dataGridViewTopPlayers.Location = new System.Drawing.Point(29, 187);
			this.dataGridViewTopPlayers.Name = "dataGridViewTopPlayers";
			this.dataGridViewTopPlayers.ReadOnly = true;
			dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.dataGridViewTopPlayers.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
			this.dataGridViewTopPlayers.RowTemplate.Height = 30;
			this.dataGridViewTopPlayers.Size = new System.Drawing.Size(955, 464);
			this.dataGridViewTopPlayers.TabIndex = 3;
			this.dataGridViewTopPlayers.Sorted += new System.EventHandler(this.dataGridViewRankPlayers_Sorted);
			this.dataGridViewTopPlayers.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewTopPlayers_CellContentClick);
			// 
			// TopPayColumn
			// 
			this.TopPayColumn.HeaderText = "Pay";
			this.TopPayColumn.Name = "TopPayColumn";
			this.TopPayColumn.ReadOnly = true;
			// 
			// buttonPayTop
			// 
			this.buttonPayTop.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.buttonPayTop.Location = new System.Drawing.Point(827, 675);
			this.buttonPayTop.Name = "buttonPayTop";
			this.buttonPayTop.Size = new System.Drawing.Size(157, 30);
			this.buttonPayTop.TabIndex = 4;
			this.buttonPayTop.Text = "Pay All";
			this.buttonPayTop.UseVisualStyleBackColor = true;
			this.buttonPayTop.Click += new System.EventHandler(this.buttonPayout_Click);
			// 
			// buttonSearchDate
			// 
			this.buttonSearchDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.buttonSearchDate.Location = new System.Drawing.Point(827, 85);
			this.buttonSearchDate.Name = "buttonSearchDate";
			this.buttonSearchDate.Size = new System.Drawing.Size(153, 32);
			this.buttonSearchDate.TabIndex = 4;
			this.buttonSearchDate.Text = "Search";
			this.buttonSearchDate.UseVisualStyleBackColor = true;
			this.buttonSearchDate.Click += new System.EventHandler(this.buttonSearchDate_Click);
			// 
			// labelBottomPlayers
			// 
			this.labelBottomPlayers.AutoSize = true;
			this.labelBottomPlayers.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelBottomPlayers.Location = new System.Drawing.Point(25, 502);
			this.labelBottomPlayers.Name = "labelBottomPlayers";
			this.labelBottomPlayers.Size = new System.Drawing.Size(159, 24);
			this.labelBottomPlayers.TabIndex = 0;
			this.labelBottomPlayers.Text = "Bottom 10 Players";
			// 
			// buttonPrintReport
			// 
			this.buttonPrintReport.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.buttonPrintReport.Location = new System.Drawing.Point(827, 123);
			this.buttonPrintReport.Name = "buttonPrintReport";
			this.buttonPrintReport.Size = new System.Drawing.Size(153, 32);
			this.buttonPrintReport.TabIndex = 4;
			this.buttonPrintReport.Text = "Print Report";
			this.buttonPrintReport.UseVisualStyleBackColor = true;
			this.buttonPrintReport.Click += new System.EventHandler(this.buttonPrintReport_Click);
			// 
			// checkBoxByDate
			// 
			this.checkBoxByDate.AutoSize = true;
			this.checkBoxByDate.Checked = true;
			this.checkBoxByDate.CheckState = System.Windows.Forms.CheckState.Checked;
			this.checkBoxByDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.checkBoxByDate.Location = new System.Drawing.Point(367, 49);
			this.checkBoxByDate.Name = "checkBoxByDate";
			this.checkBoxByDate.Size = new System.Drawing.Size(125, 20);
			this.checkBoxByDate.TabIndex = 8;
			this.checkBoxByDate.Text = "Filter By Date:";
			this.checkBoxByDate.UseVisualStyleBackColor = true;
			// 
			// radioButtonPaidPrizes
			// 
			this.radioButtonPaidPrizes.AutoSize = true;
			this.radioButtonPaidPrizes.Location = new System.Drawing.Point(709, 108);
			this.radioButtonPaidPrizes.Name = "radioButtonPaidPrizes";
			this.radioButtonPaidPrizes.Size = new System.Drawing.Size(77, 17);
			this.radioButtonPaidPrizes.TabIndex = 16;
			this.radioButtonPaidPrizes.Text = "Paid Prizes";
			this.radioButtonPaidPrizes.UseVisualStyleBackColor = true;
			// 
			// radioButtonAllPrizes
			// 
			this.radioButtonAllPrizes.AutoSize = true;
			this.radioButtonAllPrizes.Checked = true;
			this.radioButtonAllPrizes.Location = new System.Drawing.Point(709, 85);
			this.radioButtonAllPrizes.Name = "radioButtonAllPrizes";
			this.radioButtonAllPrizes.Size = new System.Drawing.Size(67, 17);
			this.radioButtonAllPrizes.TabIndex = 17;
			this.radioButtonAllPrizes.TabStop = true;
			this.radioButtonAllPrizes.Text = "All Prizes";
			this.radioButtonAllPrizes.UseVisualStyleBackColor = true;
			// 
			// radioButtonUnclaim
			// 
			this.radioButtonUnclaim.AutoSize = true;
			this.radioButtonUnclaim.Location = new System.Drawing.Point(709, 131);
			this.radioButtonUnclaim.Name = "radioButtonUnclaim";
			this.radioButtonUnclaim.Size = new System.Drawing.Size(94, 17);
			this.radioButtonUnclaim.TabIndex = 18;
			this.radioButtonUnclaim.Text = "Unclaim Prizes";
			this.radioButtonUnclaim.UseVisualStyleBackColor = true;
			// 
			// dateTimePickerTo
			// 
			this.dateTimePickerTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.dateTimePickerTo.Location = new System.Drawing.Point(417, 124);
			this.dateTimePickerTo.Name = "dateTimePickerTo";
			this.dateTimePickerTo.Size = new System.Drawing.Size(259, 22);
			this.dateTimePickerTo.TabIndex = 15;
			// 
			// dateTimePickerFrom
			// 
			this.dateTimePickerFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.dateTimePickerFrom.Location = new System.Drawing.Point(417, 86);
			this.dateTimePickerFrom.Name = "dateTimePickerFrom";
			this.dateTimePickerFrom.Size = new System.Drawing.Size(259, 22);
			this.dateTimePickerFrom.TabIndex = 14;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(364, 127);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(31, 16);
			this.label1.TabIndex = 12;
			this.label1.Text = "To:";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label5.Location = new System.Drawing.Point(364, 89);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(47, 16);
			this.label5.TabIndex = 13;
			this.label5.Text = "From:";
			// 
			// listBoxCardsRead
			// 
			this.listBoxCardsRead.FormattingEnabled = true;
			this.listBoxCardsRead.Location = new System.Drawing.Point(29, 46);
			this.listBoxCardsRead.Name = "listBoxCardsRead";
			this.listBoxCardsRead.Size = new System.Drawing.Size(301, 108);
			this.listBoxCardsRead.TabIndex = 7;
			this.listBoxCardsRead.DoubleClick += new System.EventHandler(this.listBoxCardsRead_DoubleClick);
			// 
			// buttonClose
			// 
			this.buttonClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.buttonClose.Location = new System.Drawing.Point(668, 675);
			this.buttonClose.Name = "buttonClose";
			this.buttonClose.Size = new System.Drawing.Size(153, 30);
			this.buttonClose.TabIndex = 4;
			this.buttonClose.Text = "Close";
			this.buttonClose.UseVisualStyleBackColor = true;
			this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point(26, 13);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(94, 16);
			this.label2.TabIndex = 13;
			this.label2.Text = "Player Card:";
			// 
			// labelPlayerName
			// 
			this.labelPlayerName.AutoSize = true;
			this.labelPlayerName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelPlayerName.Location = new System.Drawing.Point(364, 13);
			this.labelPlayerName.Name = "labelPlayerName";
			this.labelPlayerName.Size = new System.Drawing.Size(108, 16);
			this.labelPlayerName.TabIndex = 13;
			this.labelPlayerName.Text = "[Player Name]";
			// 
			// textBoxCard
			// 
			this.textBoxCard.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.textBoxCard.Location = new System.Drawing.Point(126, 10);
			this.textBoxCard.Name = "textBoxCard";
			this.textBoxCard.Size = new System.Drawing.Size(204, 22);
			this.textBoxCard.TabIndex = 19;
			// 
			// ChoosenPlayersForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1016, 734);
			this.Controls.Add(this.textBoxCard);
			this.Controls.Add(this.radioButtonPaidPrizes);
			this.Controls.Add(this.radioButtonAllPrizes);
			this.Controls.Add(this.radioButtonUnclaim);
			this.Controls.Add(this.dateTimePickerTo);
			this.Controls.Add(this.dateTimePickerFrom);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.labelPlayerName);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.checkBoxByDate);
			this.Controls.Add(this.listBoxCardsRead);
			this.Controls.Add(this.buttonPrintReport);
			this.Controls.Add(this.buttonSearchDate);
			this.Controls.Add(this.buttonClose);
			this.Controls.Add(this.buttonPayTop);
			this.Controls.Add(this.dataGridViewTopPlayers);
			this.Controls.Add(this.labelBottomPlayers);
			this.Name = "ChoosenPlayersForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Player Form";
			this.Load += new System.EventHandler(this.TopPlayersForm_Load);
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewTopPlayers)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.DataGridView dataGridViewTopPlayers;
		private System.Windows.Forms.Button buttonPayTop;
		private System.Windows.Forms.Button buttonSearchDate;
		private System.Windows.Forms.Label labelBottomPlayers;
		private System.Windows.Forms.Button buttonPrintReport;
		private System.Windows.Forms.DataGridViewButtonColumn TopPayColumn;
		private System.Windows.Forms.CheckBox checkBoxByDate;
		private System.Windows.Forms.RadioButton radioButtonPaidPrizes;
		private System.Windows.Forms.RadioButton radioButtonAllPrizes;
		private System.Windows.Forms.RadioButton radioButtonUnclaim;
		private System.Windows.Forms.DateTimePicker dateTimePickerTo;
		private System.Windows.Forms.DateTimePicker dateTimePickerFrom;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.ListBox listBoxCardsRead;
		private System.Windows.Forms.Button buttonClose;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label labelPlayerName;
		private System.Windows.Forms.TextBox textBoxCard;
	}
}

