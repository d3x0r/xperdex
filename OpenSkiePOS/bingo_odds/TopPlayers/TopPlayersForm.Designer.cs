namespace TopPlayers
{
	partial class TopPlayersForm
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
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
			this.labelTopPlayers = new System.Windows.Forms.Label();
			this.dataGridViewTopPlayers = new System.Windows.Forms.DataGridView();
			this.TopPayColumn = new System.Windows.Forms.DataGridViewButtonColumn();
			this.buttonPayTopNonCash = new System.Windows.Forms.Button();
			this.label5 = new System.Windows.Forms.Label();
			this.dateTimePickerFrom = new System.Windows.Forms.DateTimePicker();
			this.buttonSearchDate = new System.Windows.Forms.Button();
			this.labelWeek = new System.Windows.Forms.Label();
			this.labelWeekTitle = new System.Windows.Forms.Label();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.generalSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.rankPrizesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.reportsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.weekPlayersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.paidPrizesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.playerPointsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.playerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.playerWinLossToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.labelBottomPlayers = new System.Windows.Forms.Label();
			this.dataGridViewBottomPlayers = new System.Windows.Forms.DataGridView();
			this.BottomPayColumn = new System.Windows.Forms.DataGridViewButtonColumn();
			this.buttonPayBottomNonCash = new System.Windows.Forms.Button();
			this.buttonCloseWeek = new System.Windows.Forms.Button();
			this.listBoxCardsRead = new System.Windows.Forms.ListBox();
			this.buttonSearchPlayer = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewTopPlayers)).BeginInit();
			this.menuStrip1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewBottomPlayers)).BeginInit();
			this.SuspendLayout();
			// 
			// labelTopPlayers
			// 
			this.labelTopPlayers.AutoSize = true;
			this.labelTopPlayers.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelTopPlayers.Location = new System.Drawing.Point(25, 110);
			this.labelTopPlayers.Name = "labelTopPlayers";
			this.labelTopPlayers.Size = new System.Drawing.Size(135, 24);
			this.labelTopPlayers.TabIndex = 0;
			this.labelTopPlayers.Text = "Top 10 Players";
			// 
			// dataGridViewTopPlayers
			// 
			this.dataGridViewTopPlayers.AllowUserToAddRows = false;
			this.dataGridViewTopPlayers.AllowUserToDeleteRows = false;
			this.dataGridViewTopPlayers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle13.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle13.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle13.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle13.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.dataGridViewTopPlayers.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle13;
			this.dataGridViewTopPlayers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridViewTopPlayers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TopPayColumn});
			dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle14.BackColor = System.Drawing.SystemColors.Window;
			dataGridViewCellStyle14.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle14.ForeColor = System.Drawing.SystemColors.ControlText;
			dataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.dataGridViewTopPlayers.DefaultCellStyle = dataGridViewCellStyle14;
			this.dataGridViewTopPlayers.Location = new System.Drawing.Point(29, 137);
			this.dataGridViewTopPlayers.Name = "dataGridViewTopPlayers";
			this.dataGridViewTopPlayers.ReadOnly = true;
			dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle15.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle15.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle15.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle15.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle15.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.dataGridViewTopPlayers.RowHeadersDefaultCellStyle = dataGridViewCellStyle15;
			this.dataGridViewTopPlayers.RowTemplate.Height = 30;
			this.dataGridViewTopPlayers.Size = new System.Drawing.Size(955, 337);
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
			// buttonPayTopNonCash
			// 
			this.buttonPayTopNonCash.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.buttonPayTopNonCash.Location = new System.Drawing.Point(789, 480);
			this.buttonPayTopNonCash.Name = "buttonPayTopNonCash";
			this.buttonPayTopNonCash.Size = new System.Drawing.Size(195, 30);
			this.buttonPayTopNonCash.TabIndex = 4;
			this.buttonPayTopNonCash.Text = "Pay All non-cash Winners";
			this.buttonPayTopNonCash.UseVisualStyleBackColor = true;
			this.buttonPayTopNonCash.Click += new System.EventHandler(this.buttonPayTopNonCash_Click);
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label5.Location = new System.Drawing.Point(26, 36);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(93, 16);
			this.label5.TabIndex = 1;
			this.label5.Text = "Select Date:";
			// 
			// dateTimePickerFrom
			// 
			this.dateTimePickerFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.dateTimePickerFrom.Location = new System.Drawing.Point(156, 33);
			this.dateTimePickerFrom.Name = "dateTimePickerFrom";
			this.dateTimePickerFrom.Size = new System.Drawing.Size(259, 22);
			this.dateTimePickerFrom.TabIndex = 5;
			// 
			// buttonSearchDate
			// 
			this.buttonSearchDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.buttonSearchDate.Location = new System.Drawing.Point(444, 28);
			this.buttonSearchDate.Name = "buttonSearchDate";
			this.buttonSearchDate.Size = new System.Drawing.Size(201, 32);
			this.buttonSearchDate.TabIndex = 4;
			this.buttonSearchDate.Text = "Search";
			this.buttonSearchDate.UseVisualStyleBackColor = true;
			this.buttonSearchDate.Click += new System.EventHandler(this.buttonSearchDate_Click);
			// 
			// labelWeek
			// 
			this.labelWeek.AutoSize = true;
			this.labelWeek.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelWeek.Location = new System.Drawing.Point(153, 74);
			this.labelWeek.Name = "labelWeek";
			this.labelWeek.Size = new System.Drawing.Size(64, 16);
			this.labelWeek.TabIndex = 1;
			this.labelWeek.Text = "[Period]";
			// 
			// labelWeekTitle
			// 
			this.labelWeekTitle.AutoSize = true;
			this.labelWeekTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelWeekTitle.Location = new System.Drawing.Point(26, 74);
			this.labelWeekTitle.Name = "labelWeekTitle";
			this.labelWeekTitle.Size = new System.Drawing.Size(58, 16);
			this.labelWeekTitle.TabIndex = 1;
			this.labelWeekTitle.Text = "Period:";
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingsToolStripMenuItem,
            this.reportsToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(1016, 24);
			this.menuStrip1.TabIndex = 6;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// settingsToolStripMenuItem
			// 
			this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.generalSettingsToolStripMenuItem,
            this.rankPrizesToolStripMenuItem});
			this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
			this.settingsToolStripMenuItem.Size = new System.Drawing.Size(58, 20);
			this.settingsToolStripMenuItem.Text = "Settings";
			// 
			// generalSettingsToolStripMenuItem
			// 
			this.generalSettingsToolStripMenuItem.Name = "generalSettingsToolStripMenuItem";
			this.generalSettingsToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
			this.generalSettingsToolStripMenuItem.Text = "General Settings";
			this.generalSettingsToolStripMenuItem.Click += new System.EventHandler(this.generalSettingsToolStripMenuItem_Click);
			// 
			// rankPrizesToolStripMenuItem
			// 
			this.rankPrizesToolStripMenuItem.Name = "rankPrizesToolStripMenuItem";
			this.rankPrizesToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
			this.rankPrizesToolStripMenuItem.Text = "Rank Prizes";
			this.rankPrizesToolStripMenuItem.Click += new System.EventHandler(this.rankPrizesToolStripMenuItem_Click);
			// 
			// reportsToolStripMenuItem
			// 
			this.reportsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.weekPlayersToolStripMenuItem,
            this.paidPrizesToolStripMenuItem,
            this.playerPointsToolStripMenuItem,
            this.playerToolStripMenuItem,
            this.playerWinLossToolStripMenuItem});
			this.reportsToolStripMenuItem.Name = "reportsToolStripMenuItem";
			this.reportsToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
			this.reportsToolStripMenuItem.Text = "Reports";
			// 
			// weekPlayersToolStripMenuItem
			// 
			this.weekPlayersToolStripMenuItem.Name = "weekPlayersToolStripMenuItem";
			this.weekPlayersToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
			this.weekPlayersToolStripMenuItem.Text = "Players Report by Period";
			this.weekPlayersToolStripMenuItem.Click += new System.EventHandler(this.weekPlayersToolStripMenuItem_Click);
			// 
			// paidPrizesToolStripMenuItem
			// 
			this.paidPrizesToolStripMenuItem.Name = "paidPrizesToolStripMenuItem";
			this.paidPrizesToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
			this.paidPrizesToolStripMenuItem.Text = "Prizes Report";
			this.paidPrizesToolStripMenuItem.Click += new System.EventHandler(this.paidPrizesToolStripMenuItem_Click_1);
			// 
			// playerPointsToolStripMenuItem
			// 
			this.playerPointsToolStripMenuItem.Name = "playerPointsToolStripMenuItem";
			this.playerPointsToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
			this.playerPointsToolStripMenuItem.Text = "Player Points";
			this.playerPointsToolStripMenuItem.Click += new System.EventHandler(this.buttonSearchPlayer_Click);
			// 
			// playerToolStripMenuItem
			// 
			this.playerToolStripMenuItem.Name = "playerToolStripMenuItem";
			this.playerToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
			this.playerToolStripMenuItem.Text = "Players Participation";
			this.playerToolStripMenuItem.Click += new System.EventHandler(this.playerToolStripMenuItem_Click);
			// 
			// playerWinLossToolStripMenuItem
			// 
			this.playerWinLossToolStripMenuItem.Name = "playerWinLossToolStripMenuItem";
			this.playerWinLossToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
			this.playerWinLossToolStripMenuItem.Text = "Players Win/Loss";
			this.playerWinLossToolStripMenuItem.Click += new System.EventHandler(this.playerWinLossToolStripMenuItem_Click);
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
			// dataGridViewBottomPlayers
			// 
			this.dataGridViewBottomPlayers.AllowUserToAddRows = false;
			this.dataGridViewBottomPlayers.AllowUserToDeleteRows = false;
			this.dataGridViewBottomPlayers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle16.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle16.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle16.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle16.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle16.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle16.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.dataGridViewBottomPlayers.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle16;
			this.dataGridViewBottomPlayers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridViewBottomPlayers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.BottomPayColumn});
			dataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle17.BackColor = System.Drawing.SystemColors.Window;
			dataGridViewCellStyle17.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle17.ForeColor = System.Drawing.SystemColors.ControlText;
			dataGridViewCellStyle17.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle17.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle17.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.dataGridViewBottomPlayers.DefaultCellStyle = dataGridViewCellStyle17;
			this.dataGridViewBottomPlayers.Location = new System.Drawing.Point(29, 529);
			this.dataGridViewBottomPlayers.Name = "dataGridViewBottomPlayers";
			this.dataGridViewBottomPlayers.ReadOnly = true;
			dataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle18.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle18.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle18.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle18.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle18.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle18.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.dataGridViewBottomPlayers.RowHeadersDefaultCellStyle = dataGridViewCellStyle18;
			this.dataGridViewBottomPlayers.RowTemplate.Height = 30;
			this.dataGridViewBottomPlayers.Size = new System.Drawing.Size(955, 157);
			this.dataGridViewBottomPlayers.TabIndex = 3;
			this.dataGridViewBottomPlayers.Sorted += new System.EventHandler(this.dataGridViewRankPlayers_Sorted);
			this.dataGridViewBottomPlayers.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewBottomPlayers_CellContentClick);
			// 
			// BottomPayColumn
			// 
			this.BottomPayColumn.HeaderText = "Pay";
			this.BottomPayColumn.Name = "BottomPayColumn";
			this.BottomPayColumn.ReadOnly = true;
			// 
			// buttonPayBottomNonCash
			// 
			this.buttonPayBottomNonCash.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.buttonPayBottomNonCash.Location = new System.Drawing.Point(789, 692);
			this.buttonPayBottomNonCash.Name = "buttonPayBottomNonCash";
			this.buttonPayBottomNonCash.Size = new System.Drawing.Size(195, 30);
			this.buttonPayBottomNonCash.TabIndex = 4;
			this.buttonPayBottomNonCash.Text = "Pay All non-cash Winners";
			this.buttonPayBottomNonCash.UseVisualStyleBackColor = true;
			this.buttonPayBottomNonCash.Click += new System.EventHandler(this.buttonPayBottomNonCash_Click);
			// 
			// buttonCloseWeek
			// 
			this.buttonCloseWeek.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.buttonCloseWeek.Location = new System.Drawing.Point(444, 66);
			this.buttonCloseWeek.Name = "buttonCloseWeek";
			this.buttonCloseWeek.Size = new System.Drawing.Size(201, 32);
			this.buttonCloseWeek.TabIndex = 4;
			this.buttonCloseWeek.Text = "Close Period";
			this.buttonCloseWeek.UseVisualStyleBackColor = true;
			this.buttonCloseWeek.Click += new System.EventHandler(this.buttonCloseWeek_Click);
			// 
			// listBoxCardsRead
			// 
			this.listBoxCardsRead.FormattingEnabled = true;
			this.listBoxCardsRead.Location = new System.Drawing.Point(683, 29);
			this.listBoxCardsRead.Name = "listBoxCardsRead";
			this.listBoxCardsRead.Size = new System.Drawing.Size(301, 69);
			this.listBoxCardsRead.TabIndex = 7;
			this.listBoxCardsRead.DoubleClick += new System.EventHandler(this.listBoxCardsRead_DoubleClick);
			// 
			// buttonSearchPlayer
			// 
			this.buttonSearchPlayer.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.buttonSearchPlayer.Location = new System.Drawing.Point(846, 104);
			this.buttonSearchPlayer.Name = "buttonSearchPlayer";
			this.buttonSearchPlayer.Size = new System.Drawing.Size(138, 27);
			this.buttonSearchPlayer.TabIndex = 4;
			this.buttonSearchPlayer.Text = "Search Player";
			this.buttonSearchPlayer.UseVisualStyleBackColor = true;
			this.buttonSearchPlayer.Click += new System.EventHandler(this.buttonSearchPlayer_Click);
			// 
			// TopPlayersForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1016, 734);
			this.Controls.Add(this.listBoxCardsRead);
			this.Controls.Add(this.dateTimePickerFrom);
			this.Controls.Add(this.buttonSearchPlayer);
			this.Controls.Add(this.buttonCloseWeek);
			this.Controls.Add(this.buttonSearchDate);
			this.Controls.Add(this.buttonPayBottomNonCash);
			this.Controls.Add(this.buttonPayTopNonCash);
			this.Controls.Add(this.dataGridViewBottomPlayers);
			this.Controls.Add(this.dataGridViewTopPlayers);
			this.Controls.Add(this.labelWeekTitle);
			this.Controls.Add(this.labelWeek);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.labelBottomPlayers);
			this.Controls.Add(this.labelTopPlayers);
			this.Controls.Add(this.menuStrip1);
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "TopPlayersForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Top Players";
			this.Load += new System.EventHandler(this.TopPlayersForm_Load);
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewTopPlayers)).EndInit();
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewBottomPlayers)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label labelTopPlayers;
		private System.Windows.Forms.DataGridView dataGridViewTopPlayers;
		private System.Windows.Forms.Button buttonPayTopNonCash;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.DateTimePicker dateTimePickerFrom;
		private System.Windows.Forms.Button buttonSearchDate;
		private System.Windows.Forms.Label labelWeek;
		private System.Windows.Forms.Label labelWeekTitle;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem reportsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem weekPlayersToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem playerPointsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem paidPrizesToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
		private System.Windows.Forms.Label labelBottomPlayers;
		private System.Windows.Forms.DataGridView dataGridViewBottomPlayers;
		private System.Windows.Forms.Button buttonPayBottomNonCash;
		private System.Windows.Forms.Button buttonCloseWeek;
		private System.Windows.Forms.ToolStripMenuItem generalSettingsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem rankPrizesToolStripMenuItem;
		private System.Windows.Forms.DataGridViewButtonColumn TopPayColumn;
		private System.Windows.Forms.DataGridViewButtonColumn BottomPayColumn;
		private System.Windows.Forms.ListBox listBoxCardsRead;
		private System.Windows.Forms.Button buttonSearchPlayer;
		private System.Windows.Forms.ToolStripMenuItem playerToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem playerWinLossToolStripMenuItem;
	}
}

