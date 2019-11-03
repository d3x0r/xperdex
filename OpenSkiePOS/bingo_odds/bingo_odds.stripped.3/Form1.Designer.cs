using System.Windows.Forms;

namespace BingoGameCore4
{
	partial class Form1
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose( bool disposing )
		{
			if( disposing && ( components != null ) )
			{
				components.Dispose();
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.textBoxYears = new System.Windows.Forms.TextBox();
			this.textBoxSessions = new System.Windows.Forms.TextBox();
			this.textBoxHalls = new System.Windows.Forms.TextBox();
			this.textBoxPlayers = new System.Windows.Forms.TextBox();
			this.listBoxPattern = new System.Windows.Forms.ListBox();
			this.textBoxCards = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.buttonGo = new System.Windows.Forms.Button();
			this.checkBoxStarburst = new System.Windows.Forms.CheckBox();
			this.listBoxPatterns = new System.Windows.Forms.ListBox();
			this.checkBoxSimulate = new System.Windows.Forms.CheckBox();
			this.checkBox5Hotball = new System.Windows.Forms.CheckBox();
			this.label6 = new System.Windows.Forms.Label();
			this.textBoxGames = new System.Windows.Forms.TextBox();
			this.checkBoxHotball = new System.Windows.Forms.CheckBox();
			this.dataGridViewGameSet = new System.Windows.Forms.DataGridView();
			this.buttonLoadConfig = new System.Windows.Forms.Button();
			this.buttonSaveGames = new System.Windows.Forms.Button();
			this.label7 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.comboBox1 = new System.Windows.Forms.ComboBox();
			this.label11 = new System.Windows.Forms.Label();
			this.textBoxCardMarks = new System.Windows.Forms.TextBox();
			this.buttonEditPatterns = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.label12 = new System.Windows.Forms.Label();
			this.textBoxDays = new System.Windows.Forms.TextBox();
			this.label14 = new System.Windows.Forms.Label();
			this.textBoxPackSize = new System.Windows.Forms.TextBox();
			this.checkBoxDatabase = new System.Windows.Forms.CheckBox();
			this.checkBoxSaveWinningCards = new System.Windows.Forms.CheckBox();
			this.textBoxThreadCount = new System.Windows.Forms.TextBox();
			this.label13 = new System.Windows.Forms.Label();
			this.buttonLoadSession = new System.Windows.Forms.Button();
			this.button3 = new System.Windows.Forms.Button();
			this.checkBoxQuickshot = new System.Windows.Forms.CheckBox();
			this.button4 = new System.Windows.Forms.Button();
			this.checkBoxCountBINGOCalls = new System.Windows.Forms.CheckBox();
			this.radioRandomNumber = new System.Windows.Forms.RadioButton();
			this.radioBallBlower = new System.Windows.Forms.RadioButton();
			this.cardSetLabel = new System.Windows.Forms.Label();
			this.checkBoxCountColorBINGO = new System.Windows.Forms.CheckBox();
			this.textBoxColorBallCount = new System.Windows.Forms.TextBox();
			this.checkBoxTriggerBalls = new System.Windows.Forms.CheckBox();
			this.textBoxMaxTriggered = new System.Windows.Forms.TextBox();
			this.label15 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewGameSet)).BeginInit();
			this.SuspendLayout();
			// 
			// textBoxYears
			// 
			this.textBoxYears.Location = new System.Drawing.Point(137, 8);
			this.textBoxYears.Name = "textBoxYears";
			this.textBoxYears.Size = new System.Drawing.Size(100, 20);
			this.textBoxYears.TabIndex = 0;
			this.textBoxYears.Text = "1";
			// 
			// textBoxSessions
			// 
			this.textBoxSessions.Location = new System.Drawing.Point(137, 86);
			this.textBoxSessions.Name = "textBoxSessions";
			this.textBoxSessions.Size = new System.Drawing.Size(100, 20);
			this.textBoxSessions.TabIndex = 3;
			this.textBoxSessions.Text = "8";
			// 
			// textBoxHalls
			// 
			this.textBoxHalls.Location = new System.Drawing.Point(137, 60);
			this.textBoxHalls.Name = "textBoxHalls";
			this.textBoxHalls.Size = new System.Drawing.Size(100, 20);
			this.textBoxHalls.TabIndex = 2;
			this.textBoxHalls.Text = "1";
			// 
			// textBoxPlayers
			// 
			this.textBoxPlayers.Location = new System.Drawing.Point(137, 156);
			this.textBoxPlayers.Name = "textBoxPlayers";
			this.textBoxPlayers.Size = new System.Drawing.Size(100, 20);
			this.textBoxPlayers.TabIndex = 5;
			this.textBoxPlayers.Text = "50";
			// 
			// listBoxPattern
			// 
			this.listBoxPattern.Enabled = false;
			this.listBoxPattern.FormattingEnabled = true;
			this.listBoxPattern.Location = new System.Drawing.Point(14, 486);
			this.listBoxPattern.Name = "listBoxPattern";
			this.listBoxPattern.Size = new System.Drawing.Size(224, 17);
			this.listBoxPattern.TabIndex = 13;
			// 
			// textBoxCards
			// 
			this.textBoxCards.Location = new System.Drawing.Point(137, 182);
			this.textBoxCards.Name = "textBoxCards";
			this.textBoxCards.Size = new System.Drawing.Size(100, 20);
			this.textBoxCards.TabIndex = 6;
			this.textBoxCards.Text = "18";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(11, 11);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(34, 13);
			this.label1.TabIndex = 34;
			this.label1.Text = "Years";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(12, 89);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(84, 13);
			this.label2.TabIndex = 37;
			this.label2.Text = "Session per Day";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(12, 63);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(30, 13);
			this.label3.TabIndex = 36;
			this.label3.Text = "Halls";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(12, 159);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(41, 13);
			this.label4.TabIndex = 40;
			this.label4.Text = "Players";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(12, 185);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(34, 13);
			this.label5.TabIndex = 41;
			this.label5.Text = "Cards";
			// 
			// buttonGo
			// 
			this.buttonGo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonGo.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.buttonGo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.buttonGo.Location = new System.Drawing.Point(795, 556);
			this.buttonGo.Name = "buttonGo";
			this.buttonGo.Size = new System.Drawing.Size(76, 42);
			this.buttonGo.TabIndex = 35;
			this.buttonGo.Text = "Go";
			this.buttonGo.UseVisualStyleBackColor = false;
			this.buttonGo.Click += new System.EventHandler(this.buttonGo_Click);
			// 
			// checkBoxStarburst
			// 
			this.checkBoxStarburst.AutoSize = true;
			this.checkBoxStarburst.Location = new System.Drawing.Point(496, 49);
			this.checkBoxStarburst.Name = "checkBoxStarburst";
			this.checkBoxStarburst.Size = new System.Drawing.Size(137, 17);
			this.checkBoxStarburst.TabIndex = 21;
			this.checkBoxStarburst.Text = "Apply Starburst Hotspot";
			this.checkBoxStarburst.UseVisualStyleBackColor = true;
			// 
			// listBoxPatterns
			// 
			this.listBoxPatterns.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.listBoxPatterns.Enabled = false;
			this.listBoxPatterns.FormattingEnabled = true;
			this.listBoxPatterns.Location = new System.Drawing.Point(14, 534);
			this.listBoxPatterns.Name = "listBoxPatterns";
			this.listBoxPatterns.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
			this.listBoxPatterns.Size = new System.Drawing.Size(224, 17);
			this.listBoxPatterns.TabIndex = 14;
			// 
			// checkBoxSimulate
			// 
			this.checkBoxSimulate.AutoSize = true;
			this.checkBoxSimulate.Checked = true;
			this.checkBoxSimulate.CheckState = System.Windows.Forms.CheckState.Checked;
			this.checkBoxSimulate.Location = new System.Drawing.Point(260, 9);
			this.checkBoxSimulate.Name = "checkBoxSimulate";
			this.checkBoxSimulate.Size = new System.Drawing.Size(190, 17);
			this.checkBoxSimulate.TabIndex = 15;
			this.checkBoxSimulate.Text = "Simulate Bingo (find best winner(s))";
			this.checkBoxSimulate.UseVisualStyleBackColor = true;
			// 
			// checkBox5Hotball
			// 
			this.checkBox5Hotball.AutoSize = true;
			this.checkBox5Hotball.Location = new System.Drawing.Point(728, 29);
			this.checkBox5Hotball.Name = "checkBox5Hotball";
			this.checkBox5Hotball.Size = new System.Drawing.Size(104, 17);
			this.checkBox5Hotball.TabIndex = 23;
			this.checkBox5Hotball.Text = "5 ball - Cash Ball";
			this.checkBox5Hotball.UseVisualStyleBackColor = true;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(12, 115);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(99, 13);
			this.label6.TabIndex = 38;
			this.label6.Text = "Games Per Session";
			// 
			// textBoxGames
			// 
			this.textBoxGames.Location = new System.Drawing.Point(137, 112);
			this.textBoxGames.Name = "textBoxGames";
			this.textBoxGames.Size = new System.Drawing.Size(100, 20);
			this.textBoxGames.TabIndex = 4;
			this.textBoxGames.Text = "12";
			// 
			// checkBoxHotball
			// 
			this.checkBoxHotball.AutoSize = true;
			this.checkBoxHotball.Location = new System.Drawing.Point(728, 9);
			this.checkBoxHotball.Name = "checkBoxHotball";
			this.checkBoxHotball.Size = new System.Drawing.Size(95, 17);
			this.checkBoxHotball.TabIndex = 22;
			this.checkBoxHotball.Text = "Single Hot Ball";
			this.checkBoxHotball.UseVisualStyleBackColor = true;
			// 
			// dataGridViewGameSet
			// 
			this.dataGridViewGameSet.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dataGridViewGameSet.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridViewGameSet.Location = new System.Drawing.Point(260, 150);
			this.dataGridViewGameSet.Name = "dataGridViewGameSet";
			this.dataGridViewGameSet.Size = new System.Drawing.Size(610, 400);
			this.dataGridViewGameSet.TabIndex = 26;
			this.dataGridViewGameSet.SizeChanged += new System.EventHandler(this.dataGridView_SizeChanged);
			// 
			// buttonLoadConfig
			// 
			this.buttonLoadConfig.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonLoadConfig.Location = new System.Drawing.Point(352, 558);
			this.buttonLoadConfig.Name = "buttonLoadConfig";
			this.buttonLoadConfig.Size = new System.Drawing.Size(90, 38);
			this.buttonLoadConfig.TabIndex = 30;
			this.buttonLoadConfig.Text = "Load Games...";
			this.buttonLoadConfig.UseVisualStyleBackColor = true;
			this.buttonLoadConfig.Click += new System.EventHandler(this.buttonLoadConfig_Click);
			// 
			// buttonSaveGames
			// 
			this.buttonSaveGames.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonSaveGames.Location = new System.Drawing.Point(448, 558);
			this.buttonSaveGames.Name = "buttonSaveGames";
			this.buttonSaveGames.Size = new System.Drawing.Size(90, 38);
			this.buttonSaveGames.TabIndex = 31;
			this.buttonSaveGames.Text = "Save Games...";
			this.buttonSaveGames.UseVisualStyleBackColor = true;
			this.buttonSaveGames.Click += new System.EventHandler(this.buttonSaveGames_Click);
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Enabled = false;
			this.label7.Location = new System.Drawing.Point(12, 519);
			this.label7.Margin = new System.Windows.Forms.Padding(0);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(175, 13);
			this.label7.TabIndex = 46;
			this.label7.Text = "(External Pattern) Select a pattern...";
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Enabled = false;
			this.label8.Location = new System.Drawing.Point(12, 471);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(171, 13);
			this.label8.TabIndex = 45;
			this.label8.Text = "(Pattern Matcher to use...) [mode?]";
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(12, 134);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(224, 13);
			this.label9.TabIndex = 39;
			this.label9.Text = "(Overriden by selection count from Game Grid)";
			// 
			// label10
			// 
			this.label10.BackColor = System.Drawing.SystemColors.InactiveCaption;
			this.label10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label10.Location = new System.Drawing.Point(260, 128);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(610, 19);
			this.label10.TabIndex = 47;
			this.label10.Text = "Game Grid";
			this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// comboBox1
			// 
			this.comboBox1.FormattingEnabled = true;
			this.comboBox1.Location = new System.Drawing.Point(14, 434);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new System.Drawing.Size(224, 21);
			this.comboBox1.TabIndex = 12;
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.Location = new System.Drawing.Point(12, 211);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(78, 13);
			this.label11.TabIndex = 42;
			this.label11.Text = "Marks On Card";
			// 
			// textBoxCardMarks
			// 
			this.textBoxCardMarks.Location = new System.Drawing.Point(137, 208);
			this.textBoxCardMarks.Name = "textBoxCardMarks";
			this.textBoxCardMarks.Size = new System.Drawing.Size(100, 20);
			this.textBoxCardMarks.TabIndex = 7;
			// 
			// buttonEditPatterns
			// 
			this.buttonEditPatterns.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonEditPatterns.Location = new System.Drawing.Point(544, 558);
			this.buttonEditPatterns.Name = "buttonEditPatterns";
			this.buttonEditPatterns.Size = new System.Drawing.Size(84, 38);
			this.buttonEditPatterns.TabIndex = 32;
			this.buttonEditPatterns.Text = "Edit Patterns";
			this.buttonEditPatterns.UseVisualStyleBackColor = true;
			this.buttonEditPatterns.Click += new System.EventHandler(this.buttonEditPatterns_Click);
			// 
			// button1
			// 
			this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.button1.Location = new System.Drawing.Point(634, 558);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 38);
			this.button1.TabIndex = 33;
			this.button1.Text = "Schedule Designer";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// button2
			// 
			this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.button2.Location = new System.Drawing.Point(714, 558);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(76, 38);
			this.button2.TabIndex = 34;
			this.button2.Text = "Go For One Session";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// label12
			// 
			this.label12.AutoSize = true;
			this.label12.Location = new System.Drawing.Point(12, 37);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(58, 13);
			this.label12.TabIndex = 35;
			this.label12.Text = "Days/Year";
			// 
			// textBoxDays
			// 
			this.textBoxDays.Location = new System.Drawing.Point(137, 34);
			this.textBoxDays.Name = "textBoxDays";
			this.textBoxDays.Size = new System.Drawing.Size(100, 20);
			this.textBoxDays.TabIndex = 1;
			this.textBoxDays.Text = "365";
			// 
			// label14
			// 
			this.label14.AutoSize = true;
			this.label14.Location = new System.Drawing.Point(12, 237);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(55, 13);
			this.label14.TabIndex = 43;
			this.label14.Text = "Pack Size";
			// 
			// textBoxPackSize
			// 
			this.textBoxPackSize.Location = new System.Drawing.Point(137, 234);
			this.textBoxPackSize.Name = "textBoxPackSize";
			this.textBoxPackSize.Size = new System.Drawing.Size(100, 20);
			this.textBoxPackSize.TabIndex = 8;
			this.textBoxPackSize.Text = "6";
			// 
			// checkBoxDatabase
			// 
			this.checkBoxDatabase.AutoSize = true;
			this.checkBoxDatabase.Location = new System.Drawing.Point(260, 29);
			this.checkBoxDatabase.Name = "checkBoxDatabase";
			this.checkBoxDatabase.Size = new System.Drawing.Size(130, 17);
			this.checkBoxDatabase.TabIndex = 16;
			this.checkBoxDatabase.Text = "Save to gamestate.db";
			this.checkBoxDatabase.UseVisualStyleBackColor = true;
			// 
			// checkBoxSaveWinningCards
			// 
			this.checkBoxSaveWinningCards.AutoSize = true;
			this.checkBoxSaveWinningCards.Location = new System.Drawing.Point(282, 47);
			this.checkBoxSaveWinningCards.Name = "checkBoxSaveWinningCards";
			this.checkBoxSaveWinningCards.Size = new System.Drawing.Size(186, 17);
			this.checkBoxSaveWinningCards.TabIndex = 17;
			this.checkBoxSaveWinningCards.Text = "Save winning cards (cardset_info)";
			this.checkBoxSaveWinningCards.UseVisualStyleBackColor = true;
			// 
			// textBoxThreadCount
			// 
			this.textBoxThreadCount.Location = new System.Drawing.Point(137, 261);
			this.textBoxThreadCount.Name = "textBoxThreadCount";
			this.textBoxThreadCount.Size = new System.Drawing.Size(100, 20);
			this.textBoxThreadCount.TabIndex = 9;
			this.textBoxThreadCount.Text = "1";
			// 
			// label13
			// 
			this.label13.AutoSize = true;
			this.label13.Location = new System.Drawing.Point(12, 264);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(110, 13);
			this.label13.TabIndex = 44;
			this.label13.Text = "Threads to run games";
			// 
			// buttonLoadSession
			// 
			this.buttonLoadSession.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonLoadSession.Location = new System.Drawing.Point(256, 558);
			this.buttonLoadSession.Name = "buttonLoadSession";
			this.buttonLoadSession.Size = new System.Drawing.Size(90, 38);
			this.buttonLoadSession.TabIndex = 29;
			this.buttonLoadSession.Text = "Load Session...";
			this.buttonLoadSession.UseVisualStyleBackColor = true;
			this.buttonLoadSession.Click += new System.EventHandler(this.buttonLoadSession_Click);
			// 
			// button3
			// 
			this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.button3.Enabled = false;
			this.button3.Location = new System.Drawing.Point(12, 558);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(116, 38);
			this.button3.TabIndex = 27;
			this.button3.Text = "Configure Games";
			this.button3.UseVisualStyleBackColor = true;
			// 
			// checkBoxQuickshot
			// 
			this.checkBoxQuickshot.AutoSize = true;
			this.checkBoxQuickshot.Location = new System.Drawing.Point(728, 49);
			this.checkBoxQuickshot.Name = "checkBoxQuickshot";
			this.checkBoxQuickshot.Size = new System.Drawing.Size(119, 17);
			this.checkBoxQuickshot.TabIndex = 24;
			this.checkBoxQuickshot.Text = "Call Quickshot Balls";
			this.checkBoxQuickshot.UseVisualStyleBackColor = true;
			// 
			// button4
			// 
			this.button4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.button4.Location = new System.Drawing.Point(134, 558);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(116, 38);
			this.button4.TabIndex = 28;
			this.button4.Text = "Edit Options";
			this.button4.UseVisualStyleBackColor = true;
			this.button4.Click += new System.EventHandler(this.button4_Click);
			// 
			// checkBoxCountBINGOCalls
			// 
			this.checkBoxCountBINGOCalls.AutoSize = true;
			this.checkBoxCountBINGOCalls.Location = new System.Drawing.Point(496, 9);
			this.checkBoxCountBINGOCalls.Name = "checkBoxCountBINGOCalls";
			this.checkBoxCountBINGOCalls.Size = new System.Drawing.Size(121, 17);
			this.checkBoxCountBINGOCalls.TabIndex = 19;
			this.checkBoxCountBINGOCalls.Text = "Count BINGO (calls)";
			this.checkBoxCountBINGOCalls.UseVisualStyleBackColor = true;
			// 
			// radioRandomNumber
			// 
			this.radioRandomNumber.AutoSize = true;
			this.radioRandomNumber.Location = new System.Drawing.Point(14, 291);
			this.radioRandomNumber.Name = "radioRandomNumber";
			this.radioRandomNumber.Size = new System.Drawing.Size(219, 17);
			this.radioRandomNumber.TabIndex = 10;
			this.radioRandomNumber.TabStop = true;
			this.radioRandomNumber.Text = "Use Random Generator for Ball Selection";
			this.radioRandomNumber.UseVisualStyleBackColor = true;
			// 
			// radioBallBlower
			// 
			this.radioBallBlower.AutoSize = true;
			this.radioBallBlower.Location = new System.Drawing.Point(14, 313);
			this.radioBallBlower.Name = "radioBallBlower";
			this.radioBallBlower.Size = new System.Drawing.Size(161, 17);
			this.radioBallBlower.TabIndex = 11;
			this.radioBallBlower.TabStop = true;
			this.radioBallBlower.Text = "Use Blower for Ball Selection";
			this.radioBallBlower.UseVisualStyleBackColor = true;
			// 
			// cardSetLabel
			// 
			this.cardSetLabel.AutoSize = true;
			this.cardSetLabel.Enabled = false;
			this.cardSetLabel.Location = new System.Drawing.Point(12, 419);
			this.cardSetLabel.Name = "cardSetLabel";
			this.cardSetLabel.Size = new System.Drawing.Size(154, 13);
			this.cardSetLabel.TabIndex = 48;
			this.cardSetLabel.Text = "(Card Sets) Select a Card Set...";
			// 
			// checkBoxCountColorBINGO
			// 
			this.checkBoxCountColorBINGO.AutoSize = true;
			this.checkBoxCountColorBINGO.Location = new System.Drawing.Point(496, 29);
			this.checkBoxCountColorBINGO.Name = "checkBoxCountColorBINGO";
			this.checkBoxCountColorBINGO.Size = new System.Drawing.Size(221, 17);
			this.checkBoxCountColorBINGO.TabIndex = 20;
			this.checkBoxCountColorBINGO.Text = "Count Solid Color BINGOs (Random Gen)";
			this.checkBoxCountColorBINGO.UseVisualStyleBackColor = true;
			// 
			// textBoxColorBallCount
			// 
			this.textBoxColorBallCount.Location = new System.Drawing.Point(137, 336);
			this.textBoxColorBallCount.Name = "textBoxColorBallCount";
			this.textBoxColorBallCount.Size = new System.Drawing.Size(99, 20);
			this.textBoxColorBallCount.TabIndex = 49;
			// 
			// checkBoxTriggerBalls
			// 
			this.checkBoxTriggerBalls.AutoSize = true;
			this.checkBoxTriggerBalls.Location = new System.Drawing.Point(260, 70);
			this.checkBoxTriggerBalls.Name = "checkBoxTriggerBalls";
			this.checkBoxTriggerBalls.Size = new System.Drawing.Size(84, 17);
			this.checkBoxTriggerBalls.TabIndex = 50;
			this.checkBoxTriggerBalls.Text = "Trigger Balls";
			this.checkBoxTriggerBalls.UseVisualStyleBackColor = true;
			// 
			// textBoxMaxTriggered
			// 
			this.textBoxMaxTriggered.Location = new System.Drawing.Point(432, 68);
			this.textBoxMaxTriggered.Name = "textBoxMaxTriggered";
			this.textBoxMaxTriggered.Size = new System.Drawing.Size(36, 20);
			this.textBoxMaxTriggered.TabIndex = 51;
			this.textBoxMaxTriggered.Text = "5";
			// 
			// label15
			// 
			this.label15.AutoSize = true;
			this.label15.Location = new System.Drawing.Point(351, 71);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(75, 13);
			this.label15.TabIndex = 52;
			this.label15.Text = "Max Triggered";
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.ClientSize = new System.Drawing.Size(884, 602);
			this.Controls.Add(this.label15);
			this.Controls.Add(this.textBoxMaxTriggered);
			this.Controls.Add(this.checkBoxTriggerBalls);
			this.Controls.Add(this.textBoxColorBallCount);
			this.Controls.Add(this.checkBoxCountColorBINGO);
			this.Controls.Add(this.cardSetLabel);
			this.Controls.Add(this.radioBallBlower);
			this.Controls.Add(this.radioRandomNumber);
			this.Controls.Add(this.checkBoxCountBINGOCalls);
			this.Controls.Add(this.button4);
			this.Controls.Add(this.checkBoxQuickshot);
			this.Controls.Add(this.button3);
			this.Controls.Add(this.buttonLoadSession);
			this.Controls.Add(this.label13);
			this.Controls.Add(this.textBoxThreadCount);
			this.Controls.Add(this.checkBoxSaveWinningCards);
			this.Controls.Add(this.checkBoxDatabase);
			this.Controls.Add(this.label14);
			this.Controls.Add(this.textBoxPackSize);
			this.Controls.Add(this.label12);
			this.Controls.Add(this.textBoxDays);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.buttonEditPatterns);
			this.Controls.Add(this.label11);
			this.Controls.Add(this.textBoxCardMarks);
			this.Controls.Add(this.comboBox1);
			this.Controls.Add(this.label10);
			this.Controls.Add(this.label9);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.buttonSaveGames);
			this.Controls.Add(this.buttonLoadConfig);
			this.Controls.Add(this.dataGridViewGameSet);
			this.Controls.Add(this.checkBoxHotball);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.textBoxGames);
			this.Controls.Add(this.checkBox5Hotball);
			this.Controls.Add(this.checkBoxSimulate);
			this.Controls.Add(this.listBoxPatterns);
			this.Controls.Add(this.checkBoxStarburst);
			this.Controls.Add(this.buttonGo);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.textBoxCards);
			this.Controls.Add(this.listBoxPattern);
			this.Controls.Add(this.textBoxPlayers);
			this.Controls.Add(this.textBoxHalls);
			this.Controls.Add(this.textBoxSessions);
			this.Controls.Add(this.textBoxYears);
			this.Name = "Form1";
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Text = "Setup Bingo Simulation";
			this.Load += new System.EventHandler(this.Form1_Load);
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewGameSet)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private TextBox textBoxYears;
		private TextBox textBoxSessions;
		private TextBox textBoxHalls;
		private TextBox textBoxPlayers;
		private ListBox listBoxPattern;
		private TextBox textBoxCards;
		private Label label1;
		private Label label2;
		private Label label3;
		private Label label4;
		private Label label5;
		private Button buttonGo;
		private CheckBox checkBoxStarburst;
		private ListBox listBoxPatterns;
		private CheckBox checkBoxSimulate;
		private CheckBox checkBox5Hotball;
		private Label label6;
		private TextBox textBoxGames;
		private CheckBox checkBoxHotball;
		private DataGridView dataGridViewGameSet;
		private Button buttonLoadConfig;
		private Button buttonSaveGames;
		private Label label7;
		private Label label8;
		private Label label9;
		private Label label10;
		private ComboBox comboBox1;
		private Label label11;
		private TextBox textBoxCardMarks;
		private Button buttonEditPatterns;
		private Button button1;
		private Button button2;
		private Label label12;
		private TextBox textBoxDays;
		private Label label14;
		private TextBox textBoxPackSize;
		private CheckBox checkBoxDatabase;
		private CheckBox checkBoxSaveWinningCards;
		private TextBox textBoxThreadCount;
		private Label label13;
		private Button buttonLoadSession;
        private Button button3;
		private CheckBox checkBoxQuickshot;
		private Button button4;
        private CheckBox checkBoxCountBINGOCalls;
        private RadioButton radioRandomNumber;
        private RadioButton radioBallBlower;
        private Label cardSetLabel;
        private CheckBox checkBoxCountColorBINGO;
		private TextBox textBoxColorBallCount;
		private CheckBox checkBoxTriggerBalls;
		private TextBox textBoxMaxTriggered;
		private Label label15;
	}
}

