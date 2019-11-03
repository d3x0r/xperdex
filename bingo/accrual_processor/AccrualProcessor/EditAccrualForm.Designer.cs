namespace ECube.AccrualProcessor
{
	partial class EditAccrualForm
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
			this.buttonOk = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.textBoxPrimaryStart = new System.Windows.Forms.TextBox();
			this.textBoxPrimarySales = new System.Windows.Forms.TextBox();
			this.labelPrimarySales = new System.Windows.Forms.Label();
			this.textBoxPrimaryEnd = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.buttonRedoPayout = new System.Windows.Forms.Button();
			this.textBoxBackupRollover = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.textBoxPrimarySeed = new System.Windows.Forms.TextBox();
			this.label9 = new System.Windows.Forms.Label();
			this.textBoxPrimaryTransfer = new System.Windows.Forms.TextBox();
			this.label10 = new System.Windows.Forms.Label();
			this.textBoxPayout = new System.Windows.Forms.TextBox();
			this.label11 = new System.Windows.Forms.Label();
			this.textBoxPayCount = new System.Windows.Forms.TextBox();
			this.label12 = new System.Windows.Forms.Label();
			this.textBoxSecondaryTransfer = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.textBoxTertiaryRollover = new System.Windows.Forms.TextBox();
			this.labelTertiaryRollover = new System.Windows.Forms.Label();
			this.textBoxSecondaryEnd = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.textBoxSecondarySales = new System.Windows.Forms.TextBox();
			this.labelSecondarySales = new System.Windows.Forms.Label();
			this.textBoxSecondaryStart = new System.Windows.Forms.TextBox();
			this.label14 = new System.Windows.Forms.Label();
			this.textBoxTertiaryTransfer = new System.Windows.Forms.TextBox();
			this.label15 = new System.Windows.Forms.Label();
			this.textBoxTertiaryEnd = new System.Windows.Forms.TextBox();
			this.label18 = new System.Windows.Forms.Label();
			this.textBoxTertiarySales = new System.Windows.Forms.TextBox();
			this.labelTertiarySales = new System.Windows.Forms.Label();
			this.textBoxTertiaryStart = new System.Windows.Forms.TextBox();
			this.label20 = new System.Windows.Forms.Label();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.label2 = new System.Windows.Forms.Label();
			this.textBoxPrimaryPayout = new System.Windows.Forms.TextBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.buttonRecompute = new System.Windows.Forms.Button();
			this.label21 = new System.Windows.Forms.Label();
			this.textBoxSales = new System.Windows.Forms.TextBox();
			this.labelHouse = new System.Windows.Forms.Label();
			this.textBoxHouse = new System.Windows.Forms.TextBox();
			this.buttonClearPayout = new System.Windows.Forms.Button();
			this.checkBoxPost = new System.Windows.Forms.CheckBox();
			this.groupBox4 = new System.Windows.Forms.GroupBox();
			this.checkBoxCountSet = new System.Windows.Forms.CheckBox();
			this.label5 = new System.Windows.Forms.Label();
			this.textBoxBallStart = new System.Windows.Forms.TextBox();
			this.label16 = new System.Windows.Forms.Label();
			this.textBoxBallEnd = new System.Windows.Forms.TextBox();
			this.textBoxRemainingSales = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.checkBoxUnlockSales = new System.Windows.Forms.CheckBox();
			this.checkBoxClosed = new System.Windows.Forms.CheckBox();
			this.buttonReloadSales = new System.Windows.Forms.Button();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.groupBox4.SuspendLayout();
			this.SuspendLayout();
			// 
			// buttonOk
			// 
			this.buttonOk.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.buttonOk.Location = new System.Drawing.Point(453, 401);
			this.buttonOk.Name = "buttonOk";
			this.buttonOk.Size = new System.Drawing.Size(97, 41);
			this.buttonOk.TabIndex = 0;
			this.buttonOk.Text = "Save";
			this.buttonOk.UseVisualStyleBackColor = true;
			this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(17, 26);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(66, 13);
			this.label1.TabIndex = 2;
			this.label1.Text = "Primary Start";
			// 
			// textBoxPrimaryStart
			// 
			this.textBoxPrimaryStart.Location = new System.Drawing.Point(132, 23);
			this.textBoxPrimaryStart.Name = "textBoxPrimaryStart";
			this.textBoxPrimaryStart.ReadOnly = true;
			this.textBoxPrimaryStart.Size = new System.Drawing.Size(100, 20);
			this.textBoxPrimaryStart.TabIndex = 3;
			// 
			// textBoxPrimarySales
			// 
			this.textBoxPrimarySales.Location = new System.Drawing.Point(132, 49);
			this.textBoxPrimarySales.Name = "textBoxPrimarySales";
			this.textBoxPrimarySales.ReadOnly = true;
			this.textBoxPrimarySales.Size = new System.Drawing.Size(100, 20);
			this.textBoxPrimarySales.TabIndex = 5;
			// 
			// labelPrimarySales
			// 
			this.labelPrimarySales.AutoSize = true;
			this.labelPrimarySales.Location = new System.Drawing.Point(17, 52);
			this.labelPrimarySales.Name = "labelPrimarySales";
			this.labelPrimarySales.Size = new System.Drawing.Size(33, 13);
			this.labelPrimarySales.TabIndex = 4;
			this.labelPrimarySales.Text = "Sales";
			// 
			// textBoxPrimaryEnd
			// 
			this.textBoxPrimaryEnd.Location = new System.Drawing.Point(132, 179);
			this.textBoxPrimaryEnd.Name = "textBoxPrimaryEnd";
			this.textBoxPrimaryEnd.Size = new System.Drawing.Size(100, 20);
			this.textBoxPrimaryEnd.TabIndex = 7;
			this.textBoxPrimaryEnd.TextChanged += new System.EventHandler(this.textBoxPrimaryEnd_TextChanged);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(17, 182);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(63, 13);
			this.label3.TabIndex = 6;
			this.label3.Text = "Primary End";
			// 
			// buttonRedoPayout
			// 
			this.buttonRedoPayout.Location = new System.Drawing.Point(9, 346);
			this.buttonRedoPayout.Name = "buttonRedoPayout";
			this.buttonRedoPayout.Size = new System.Drawing.Size(108, 23);
			this.buttonRedoPayout.TabIndex = 16;
			this.buttonRedoPayout.Text = "Redo Payout";
			this.buttonRedoPayout.UseVisualStyleBackColor = true;
			this.buttonRedoPayout.Click += new System.EventHandler(this.button1_Click);
			// 
			// textBoxBackupRollover
			// 
			this.textBoxBackupRollover.Location = new System.Drawing.Point(132, 101);
			this.textBoxBackupRollover.Name = "textBoxBackupRollover";
			this.textBoxBackupRollover.ReadOnly = true;
			this.textBoxBackupRollover.Size = new System.Drawing.Size(100, 20);
			this.textBoxBackupRollover.TabIndex = 18;
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(17, 104);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(86, 13);
			this.label8.TabIndex = 17;
			this.label8.Text = "Backup Rollover";
			// 
			// textBoxPrimarySeed
			// 
			this.textBoxPrimarySeed.Location = new System.Drawing.Point(132, 127);
			this.textBoxPrimarySeed.Name = "textBoxPrimarySeed";
			this.textBoxPrimarySeed.ReadOnly = true;
			this.textBoxPrimarySeed.Size = new System.Drawing.Size(100, 20);
			this.textBoxPrimarySeed.TabIndex = 20;
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(17, 130);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(69, 13);
			this.label9.TabIndex = 19;
			this.label9.Text = "Primary Seed";
			// 
			// textBoxPrimaryTransfer
			// 
			this.textBoxPrimaryTransfer.Location = new System.Drawing.Point(132, 153);
			this.textBoxPrimaryTransfer.Name = "textBoxPrimaryTransfer";
			this.textBoxPrimaryTransfer.ReadOnly = true;
			this.textBoxPrimaryTransfer.Size = new System.Drawing.Size(100, 20);
			this.textBoxPrimaryTransfer.TabIndex = 22;
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(17, 156);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(69, 13);
			this.label10.TabIndex = 21;
			this.label10.Text = "Primary Fixup";
			// 
			// textBoxPayout
			// 
			this.textBoxPayout.Location = new System.Drawing.Point(193, 374);
			this.textBoxPayout.Name = "textBoxPayout";
			this.textBoxPayout.ReadOnly = true;
			this.textBoxPayout.Size = new System.Drawing.Size(72, 20);
			this.textBoxPayout.TabIndex = 26;
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.Location = new System.Drawing.Point(123, 377);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(40, 13);
			this.label11.TabIndex = 25;
			this.label11.Text = "Payout";
			// 
			// textBoxPayCount
			// 
			this.textBoxPayCount.Location = new System.Drawing.Point(193, 348);
			this.textBoxPayCount.Name = "textBoxPayCount";
			this.textBoxPayCount.ReadOnly = true;
			this.textBoxPayCount.Size = new System.Drawing.Size(72, 20);
			this.textBoxPayCount.TabIndex = 24;
			// 
			// label12
			// 
			this.label12.AutoSize = true;
			this.label12.Location = new System.Drawing.Point(123, 351);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(56, 13);
			this.label12.TabIndex = 23;
			this.label12.Text = "Pay Count";
			// 
			// textBoxSecondaryTransfer
			// 
			this.textBoxSecondaryTransfer.Location = new System.Drawing.Point(124, 102);
			this.textBoxSecondaryTransfer.Name = "textBoxSecondaryTransfer";
			this.textBoxSecondaryTransfer.ReadOnly = true;
			this.textBoxSecondaryTransfer.Size = new System.Drawing.Size(100, 20);
			this.textBoxSecondaryTransfer.TabIndex = 38;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(9, 105);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(72, 13);
			this.label4.TabIndex = 37;
			this.label4.Text = "Backup Fixup";
			// 
			// textBoxTertiaryRollover
			// 
			this.textBoxTertiaryRollover.Location = new System.Drawing.Point(124, 76);
			this.textBoxTertiaryRollover.Name = "textBoxTertiaryRollover";
			this.textBoxTertiaryRollover.ReadOnly = true;
			this.textBoxTertiaryRollover.Size = new System.Drawing.Size(100, 20);
			this.textBoxTertiaryRollover.TabIndex = 34;
			// 
			// labelTertiaryRollover
			// 
			this.labelTertiaryRollover.AutoSize = true;
			this.labelTertiaryRollover.Location = new System.Drawing.Point(9, 79);
			this.labelTertiaryRollover.Name = "labelTertiaryRollover";
			this.labelTertiaryRollover.Size = new System.Drawing.Size(84, 13);
			this.labelTertiaryRollover.TabIndex = 33;
			this.labelTertiaryRollover.Text = "Tertiary Rollover";
			// 
			// textBoxSecondaryEnd
			// 
			this.textBoxSecondaryEnd.Location = new System.Drawing.Point(124, 128);
			this.textBoxSecondaryEnd.Name = "textBoxSecondaryEnd";
			this.textBoxSecondaryEnd.Size = new System.Drawing.Size(100, 20);
			this.textBoxSecondaryEnd.TabIndex = 32;
			this.textBoxSecondaryEnd.TextChanged += new System.EventHandler(this.textBoxSecondaryEnd_TextChanged);
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(9, 131);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(66, 13);
			this.label7.TabIndex = 31;
			this.label7.Text = "Backup End";
			// 
			// textBoxSecondarySales
			// 
			this.textBoxSecondarySales.Location = new System.Drawing.Point(124, 52);
			this.textBoxSecondarySales.Name = "textBoxSecondarySales";
			this.textBoxSecondarySales.ReadOnly = true;
			this.textBoxSecondarySales.Size = new System.Drawing.Size(100, 20);
			this.textBoxSecondarySales.TabIndex = 30;
			// 
			// labelSecondarySales
			// 
			this.labelSecondarySales.AutoSize = true;
			this.labelSecondarySales.Location = new System.Drawing.Point(9, 55);
			this.labelSecondarySales.Name = "labelSecondarySales";
			this.labelSecondarySales.Size = new System.Drawing.Size(33, 13);
			this.labelSecondarySales.TabIndex = 29;
			this.labelSecondarySales.Text = "Sales";
			// 
			// textBoxSecondaryStart
			// 
			this.textBoxSecondaryStart.Location = new System.Drawing.Point(124, 26);
			this.textBoxSecondaryStart.Name = "textBoxSecondaryStart";
			this.textBoxSecondaryStart.ReadOnly = true;
			this.textBoxSecondaryStart.Size = new System.Drawing.Size(100, 20);
			this.textBoxSecondaryStart.TabIndex = 28;
			// 
			// label14
			// 
			this.label14.AutoSize = true;
			this.label14.Location = new System.Drawing.Point(9, 29);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(69, 13);
			this.label14.TabIndex = 27;
			this.label14.Text = "Backup Start";
			// 
			// textBoxTertiaryTransfer
			// 
			this.textBoxTertiaryTransfer.Location = new System.Drawing.Point(120, 67);
			this.textBoxTertiaryTransfer.Name = "textBoxTertiaryTransfer";
			this.textBoxTertiaryTransfer.ReadOnly = true;
			this.textBoxTertiaryTransfer.Size = new System.Drawing.Size(100, 20);
			this.textBoxTertiaryTransfer.TabIndex = 50;
			// 
			// label15
			// 
			this.label15.AutoSize = true;
			this.label15.Location = new System.Drawing.Point(5, 70);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(32, 13);
			this.label15.TabIndex = 49;
			this.label15.Text = "Fixup";
			// 
			// textBoxTertiaryEnd
			// 
			this.textBoxTertiaryEnd.Location = new System.Drawing.Point(120, 93);
			this.textBoxTertiaryEnd.Name = "textBoxTertiaryEnd";
			this.textBoxTertiaryEnd.Size = new System.Drawing.Size(100, 20);
			this.textBoxTertiaryEnd.TabIndex = 44;
			this.textBoxTertiaryEnd.TextChanged += new System.EventHandler(this.textBoxTertiaryEnd_TextChanged);
			// 
			// label18
			// 
			this.label18.AutoSize = true;
			this.label18.Location = new System.Drawing.Point(5, 96);
			this.label18.Name = "label18";
			this.label18.Size = new System.Drawing.Size(26, 13);
			this.label18.TabIndex = 43;
			this.label18.Text = "End";
			// 
			// textBoxTertiarySales
			// 
			this.textBoxTertiarySales.Location = new System.Drawing.Point(121, 44);
			this.textBoxTertiarySales.Name = "textBoxTertiarySales";
			this.textBoxTertiarySales.ReadOnly = true;
			this.textBoxTertiarySales.Size = new System.Drawing.Size(100, 20);
			this.textBoxTertiarySales.TabIndex = 42;
			// 
			// labelTertiarySales
			// 
			this.labelTertiarySales.AutoSize = true;
			this.labelTertiarySales.Location = new System.Drawing.Point(6, 47);
			this.labelTertiarySales.Name = "labelTertiarySales";
			this.labelTertiarySales.Size = new System.Drawing.Size(33, 13);
			this.labelTertiarySales.TabIndex = 41;
			this.labelTertiarySales.Text = "Sales";
			// 
			// textBoxTertiaryStart
			// 
			this.textBoxTertiaryStart.Location = new System.Drawing.Point(121, 18);
			this.textBoxTertiaryStart.Name = "textBoxTertiaryStart";
			this.textBoxTertiaryStart.ReadOnly = true;
			this.textBoxTertiaryStart.Size = new System.Drawing.Size(100, 20);
			this.textBoxTertiaryStart.TabIndex = 40;
			// 
			// label20
			// 
			this.label20.AutoSize = true;
			this.label20.Location = new System.Drawing.Point(6, 21);
			this.label20.Name = "label20";
			this.label20.Size = new System.Drawing.Size(29, 13);
			this.label20.TabIndex = 39;
			this.label20.Text = "Start";
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.textBoxPrimaryPayout);
			this.groupBox1.Controls.Add(this.textBoxPrimaryStart);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.labelPrimarySales);
			this.groupBox1.Controls.Add(this.textBoxPrimarySales);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.textBoxPrimaryEnd);
			this.groupBox1.Controls.Add(this.label8);
			this.groupBox1.Controls.Add(this.textBoxBackupRollover);
			this.groupBox1.Controls.Add(this.label9);
			this.groupBox1.Controls.Add(this.textBoxPrimarySeed);
			this.groupBox1.Controls.Add(this.label10);
			this.groupBox1.Controls.Add(this.textBoxPrimaryTransfer);
			this.groupBox1.Location = new System.Drawing.Point(12, 110);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(244, 229);
			this.groupBox1.TabIndex = 51;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Primary";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(17, 78);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(40, 13);
			this.label2.TabIndex = 23;
			this.label2.Text = "Payout";
			// 
			// textBoxPrimaryPayout
			// 
			this.textBoxPrimaryPayout.Location = new System.Drawing.Point(132, 75);
			this.textBoxPrimaryPayout.Name = "textBoxPrimaryPayout";
			this.textBoxPrimaryPayout.ReadOnly = true;
			this.textBoxPrimaryPayout.Size = new System.Drawing.Size(100, 20);
			this.textBoxPrimaryPayout.TabIndex = 24;
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.textBoxSecondaryStart);
			this.groupBox2.Controls.Add(this.label14);
			this.groupBox2.Controls.Add(this.labelSecondarySales);
			this.groupBox2.Controls.Add(this.textBoxSecondarySales);
			this.groupBox2.Controls.Add(this.label7);
			this.groupBox2.Controls.Add(this.textBoxSecondaryEnd);
			this.groupBox2.Controls.Add(this.labelTertiaryRollover);
			this.groupBox2.Controls.Add(this.textBoxTertiaryRollover);
			this.groupBox2.Controls.Add(this.label4);
			this.groupBox2.Controls.Add(this.textBoxSecondaryTransfer);
			this.groupBox2.Location = new System.Drawing.Point(306, 12);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(244, 158);
			this.groupBox2.TabIndex = 52;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Backup";
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.label20);
			this.groupBox3.Controls.Add(this.textBoxTertiaryStart);
			this.groupBox3.Controls.Add(this.labelTertiarySales);
			this.groupBox3.Controls.Add(this.textBoxTertiaryTransfer);
			this.groupBox3.Controls.Add(this.textBoxTertiarySales);
			this.groupBox3.Controls.Add(this.label15);
			this.groupBox3.Controls.Add(this.label18);
			this.groupBox3.Controls.Add(this.textBoxTertiaryEnd);
			this.groupBox3.Location = new System.Drawing.Point(310, 177);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(240, 124);
			this.groupBox3.TabIndex = 53;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Tertiary";
			// 
			// buttonRecompute
			// 
			this.buttonRecompute.Location = new System.Drawing.Point(12, 12);
			this.buttonRecompute.Name = "buttonRecompute";
			this.buttonRecompute.Size = new System.Drawing.Size(167, 31);
			this.buttonRecompute.TabIndex = 54;
			this.buttonRecompute.Text = "Recompute (Update Percents)";
			this.buttonRecompute.UseVisualStyleBackColor = true;
			this.buttonRecompute.Click += new System.EventHandler(this.button2_Click);
			// 
			// label21
			// 
			this.label21.AutoSize = true;
			this.label21.Location = new System.Drawing.Point(15, 52);
			this.label21.Name = "label21";
			this.label21.Size = new System.Drawing.Size(73, 13);
			this.label21.TabIndex = 23;
			this.label21.Text = "Session Sales";
			// 
			// textBoxSales
			// 
			this.textBoxSales.Location = new System.Drawing.Point(130, 49);
			this.textBoxSales.Name = "textBoxSales";
			this.textBoxSales.ReadOnly = true;
			this.textBoxSales.Size = new System.Drawing.Size(70, 20);
			this.textBoxSales.TabIndex = 24;
			this.textBoxSales.TextChanged += new System.EventHandler(this.textBoxSales_TextChanged);
			// 
			// labelHouse
			// 
			this.labelHouse.AutoSize = true;
			this.labelHouse.Location = new System.Drawing.Point(15, 70);
			this.labelHouse.Name = "labelHouse";
			this.labelHouse.Size = new System.Drawing.Size(38, 13);
			this.labelHouse.TabIndex = 55;
			this.labelHouse.Text = "House";
			// 
			// textBoxHouse
			// 
			this.textBoxHouse.Location = new System.Drawing.Point(130, 67);
			this.textBoxHouse.Name = "textBoxHouse";
			this.textBoxHouse.ReadOnly = true;
			this.textBoxHouse.Size = new System.Drawing.Size(70, 20);
			this.textBoxHouse.TabIndex = 56;
			// 
			// buttonClearPayout
			// 
			this.buttonClearPayout.Location = new System.Drawing.Point(8, 372);
			this.buttonClearPayout.Name = "buttonClearPayout";
			this.buttonClearPayout.Size = new System.Drawing.Size(109, 23);
			this.buttonClearPayout.TabIndex = 57;
			this.buttonClearPayout.Text = "Clear Payout";
			this.buttonClearPayout.UseVisualStyleBackColor = true;
			this.buttonClearPayout.Click += new System.EventHandler(this.buttonClearPayout_Click);
			// 
			// checkBoxPost
			// 
			this.checkBoxPost.AutoSize = true;
			this.checkBoxPost.Location = new System.Drawing.Point(10, 401);
			this.checkBoxPost.Name = "checkBoxPost";
			this.checkBoxPost.Size = new System.Drawing.Size(59, 17);
			this.checkBoxPost.TabIndex = 58;
			this.checkBoxPost.Text = "Posted";
			this.checkBoxPost.UseVisualStyleBackColor = true;
			this.checkBoxPost.CheckedChanged += new System.EventHandler(this.checkBoxPost_CheckedChanged);
			// 
			// groupBox4
			// 
			this.groupBox4.Controls.Add(this.checkBoxCountSet);
			this.groupBox4.Controls.Add(this.label5);
			this.groupBox4.Controls.Add(this.textBoxBallStart);
			this.groupBox4.Controls.Add(this.label16);
			this.groupBox4.Controls.Add(this.textBoxBallEnd);
			this.groupBox4.Location = new System.Drawing.Point(306, 307);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new System.Drawing.Size(240, 88);
			this.groupBox4.TabIndex = 59;
			this.groupBox4.TabStop = false;
			this.groupBox4.Text = "Balls";
			// 
			// checkBoxCountSet
			// 
			this.checkBoxCountSet.AutoSize = true;
			this.checkBoxCountSet.Location = new System.Drawing.Point(6, 65);
			this.checkBoxCountSet.Name = "checkBoxCountSet";
			this.checkBoxCountSet.Size = new System.Drawing.Size(230, 17);
			this.checkBoxCountSet.TabIndex = 60;
			this.checkBoxCountSet.Text = "Ball Count Set (starts counting from last set)";
			this.checkBoxCountSet.UseVisualStyleBackColor = true;
			this.checkBoxCountSet.CheckedChanged += new System.EventHandler(this.checkBoxCountSet_CheckedChanged);
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(6, 21);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(29, 13);
			this.label5.TabIndex = 39;
			this.label5.Text = "Start";
			// 
			// textBoxBallStart
			// 
			this.textBoxBallStart.Location = new System.Drawing.Point(121, 18);
			this.textBoxBallStart.Name = "textBoxBallStart";
			this.textBoxBallStart.ReadOnly = true;
			this.textBoxBallStart.Size = new System.Drawing.Size(100, 20);
			this.textBoxBallStart.TabIndex = 40;
			// 
			// label16
			// 
			this.label16.AutoSize = true;
			this.label16.Location = new System.Drawing.Point(6, 44);
			this.label16.Name = "label16";
			this.label16.Size = new System.Drawing.Size(26, 13);
			this.label16.TabIndex = 43;
			this.label16.Text = "End";
			// 
			// textBoxBallEnd
			// 
			this.textBoxBallEnd.Location = new System.Drawing.Point(121, 41);
			this.textBoxBallEnd.Name = "textBoxBallEnd";
			this.textBoxBallEnd.Size = new System.Drawing.Size(100, 20);
			this.textBoxBallEnd.TabIndex = 44;
			this.textBoxBallEnd.TextChanged += new System.EventHandler(this.textBox4_TextChanged);
			// 
			// textBoxRemainingSales
			// 
			this.textBoxRemainingSales.Location = new System.Drawing.Point(130, 88);
			this.textBoxRemainingSales.Name = "textBoxRemainingSales";
			this.textBoxRemainingSales.ReadOnly = true;
			this.textBoxRemainingSales.Size = new System.Drawing.Size(70, 20);
			this.textBoxRemainingSales.TabIndex = 60;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(15, 91);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(86, 13);
			this.label6.TabIndex = 61;
			this.label6.Text = "Remaining Sales";
			// 
			// checkBoxUnlockSales
			// 
			this.checkBoxUnlockSales.AutoSize = true;
			this.checkBoxUnlockSales.Location = new System.Drawing.Point(207, 50);
			this.checkBoxUnlockSales.Name = "checkBoxUnlockSales";
			this.checkBoxUnlockSales.Size = new System.Drawing.Size(60, 17);
			this.checkBoxUnlockSales.TabIndex = 62;
			this.checkBoxUnlockSales.Text = "Unlock";
			this.checkBoxUnlockSales.UseVisualStyleBackColor = true;
			this.checkBoxUnlockSales.CheckedChanged += new System.EventHandler(this.checkBoxUnlockSales_CheckedChanged);
			// 
			// checkBoxClosed
			// 
			this.checkBoxClosed.AutoSize = true;
			this.checkBoxClosed.Location = new System.Drawing.Point(8, 424);
			this.checkBoxClosed.Name = "checkBoxClosed";
			this.checkBoxClosed.Size = new System.Drawing.Size(58, 17);
			this.checkBoxClosed.TabIndex = 63;
			this.checkBoxClosed.Text = "Closed";
			this.checkBoxClosed.UseVisualStyleBackColor = true;
			this.checkBoxClosed.CheckedChanged += new System.EventHandler(this.checkBoxClosed_CheckedChanged);
			// 
			// buttonReloadSales
			// 
			this.buttonReloadSales.Location = new System.Drawing.Point(185, 12);
			this.buttonReloadSales.Name = "buttonReloadSales";
			this.buttonReloadSales.Size = new System.Drawing.Size(115, 32);
			this.buttonReloadSales.TabIndex = 64;
			this.buttonReloadSales.Text = "Reload Sales";
			this.buttonReloadSales.UseVisualStyleBackColor = true;
			this.buttonReloadSales.Click += new System.EventHandler(this.buttonReloadSales_Click);
			// 
			// EditAccrualForm
			// 
			this.AcceptButton = this.buttonOk;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(572, 464);
			this.Controls.Add(this.buttonReloadSales);
			this.Controls.Add(this.checkBoxClosed);
			this.Controls.Add(this.checkBoxUnlockSales);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.textBoxRemainingSales);
			this.Controls.Add(this.groupBox4);
			this.Controls.Add(this.checkBoxPost);
			this.Controls.Add(this.buttonClearPayout);
			this.Controls.Add(this.labelHouse);
			this.Controls.Add(this.textBoxHouse);
			this.Controls.Add(this.label21);
			this.Controls.Add(this.buttonRecompute);
			this.Controls.Add(this.textBoxSales);
			this.Controls.Add(this.groupBox3);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.textBoxPayout);
			this.Controls.Add(this.label11);
			this.Controls.Add(this.textBoxPayCount);
			this.Controls.Add(this.label12);
			this.Controls.Add(this.buttonRedoPayout);
			this.Controls.Add(this.buttonOk);
			this.Name = "EditAccrualForm";
			this.Text = "EditAccrualForm";
			this.Load += new System.EventHandler(this.EditAccrualForm_Load);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.groupBox3.ResumeLayout(false);
			this.groupBox3.PerformLayout();
			this.groupBox4.ResumeLayout(false);
			this.groupBox4.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button buttonOk;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox textBoxPrimaryStart;
		private System.Windows.Forms.TextBox textBoxPrimarySales;
		private System.Windows.Forms.Label labelPrimarySales;
		private System.Windows.Forms.TextBox textBoxPrimaryEnd;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button buttonRedoPayout;
		private System.Windows.Forms.TextBox textBoxBackupRollover;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.TextBox textBoxPrimarySeed;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.TextBox textBoxPrimaryTransfer;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.TextBox textBoxPayout;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.TextBox textBoxPayCount;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.TextBox textBoxSecondaryTransfer;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox textBoxTertiaryRollover;
		private System.Windows.Forms.Label labelTertiaryRollover;
		private System.Windows.Forms.TextBox textBoxSecondaryEnd;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox textBoxSecondarySales;
		private System.Windows.Forms.Label labelSecondarySales;
		private System.Windows.Forms.TextBox textBoxSecondaryStart;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.TextBox textBoxTertiaryTransfer;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.TextBox textBoxTertiaryEnd;
		private System.Windows.Forms.Label label18;
		private System.Windows.Forms.TextBox textBoxTertiarySales;
		private System.Windows.Forms.Label labelTertiarySales;
		private System.Windows.Forms.TextBox textBoxTertiaryStart;
		private System.Windows.Forms.Label label20;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.Button buttonRecompute;
		private System.Windows.Forms.Label label21;
		private System.Windows.Forms.TextBox textBoxSales;
		private System.Windows.Forms.Label labelHouse;
		private System.Windows.Forms.TextBox textBoxHouse;
		private System.Windows.Forms.Button buttonClearPayout;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox textBoxPrimaryPayout;
		private System.Windows.Forms.CheckBox checkBoxPost;
		private System.Windows.Forms.GroupBox groupBox4;
		private System.Windows.Forms.CheckBox checkBoxCountSet;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox textBoxBallStart;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.TextBox textBoxBallEnd;
		private System.Windows.Forms.TextBox textBoxRemainingSales;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.CheckBox checkBoxUnlockSales;
		private System.Windows.Forms.CheckBox checkBoxClosed;
		private System.Windows.Forms.Button buttonReloadSales;
	}
}