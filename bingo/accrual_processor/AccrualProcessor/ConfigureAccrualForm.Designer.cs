namespace ECube.AccrualProcessor
{
	partial class ConfigureAccrualForm
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
			this.textBoxSeedValue = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.checkBoxValidations = new System.Windows.Forms.CheckBox();
			this.checkBoxAnySession = new System.Windows.Forms.CheckBox();
			this.label2 = new System.Windows.Forms.Label();
			this.dataGridViewPercentages = new System.Windows.Forms.DataGridView();
			this.buttonApplyChanges = new System.Windows.Forms.Button();
			this.buttonDone = new System.Windows.Forms.Button();
			this.checkBoxOverride = new System.Windows.Forms.CheckBox();
			this.textBoxPackPriceOverride = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.textBoxHousePortion = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.textBoxCurrentValue = new System.Windows.Forms.TextBox();
			this.labelCurrentValue = new System.Windows.Forms.Label();
			this.textBoxCurrentBackup = new System.Windows.Forms.TextBox();
			this.labelCurrentBackup = new System.Windows.Forms.Label();
			this.textBoxTertiaryValue = new System.Windows.Forms.TextBox();
			this.labelCurrentTertiary = new System.Windows.Forms.Label();
			this.simpleCheckRelationGridListPick = new ECube.AccrualProcessor.SimpleCheckRelationGrid();
			this.simpleCheckRelationGridCategories = new ECube.AccrualProcessor.SimpleCheckRelationGrid();
			this.simpleCheckRelationGrid1 = new ECube.AccrualProcessor.SimpleCheckRelationGrid();
			this.checkBoxDaily = new System.Windows.Forms.CheckBox();
			this.checkBoxParamutual = new System.Windows.Forms.CheckBox();
			this.label5 = new System.Windows.Forms.Label();
			this.textBoxBallCountReset = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.textBoxBallCountMax = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.textBoxBallIncrementDays = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.labelSecondaryFixed = new System.Windows.Forms.Label();
			this.textBoxSecondaryIncrement = new System.Windows.Forms.TextBox();
			this.labelPrimaryFixed = new System.Windows.Forms.Label();
			this.textBoxPrimaryIncrement = new System.Windows.Forms.TextBox();
			this.checkBoxFixedIncrement = new System.Windows.Forms.CheckBox();
			this.labelTertiaryFixed = new System.Windows.Forms.Label();
			this.textBoxTertiaryIncrement = new System.Windows.Forms.TextBox();
			this.checkBoxAccrueWeekly = new System.Windows.Forms.CheckBox();
			this.comboBoxDayOfWeek = new System.Windows.Forms.ComboBox();
			this.label9 = new System.Windows.Forms.Label();
			this.textBoxDisplayOrder = new System.Windows.Forms.TextBox();
			this.checkBoxRemainderToSecondary = new System.Windows.Forms.CheckBox();
			this.checkBoxRemainderToPrimary = new System.Windows.Forms.CheckBox();
			this.textBoxHotballGame = new System.Windows.Forms.TextBox();
			this.label10 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewPercentages)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.simpleCheckRelationGridListPick)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.simpleCheckRelationGridCategories)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.simpleCheckRelationGrid1)).BeginInit();
			this.SuspendLayout();
			// 
			// textBoxSeedValue
			// 
			this.textBoxSeedValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.textBoxSeedValue.Location = new System.Drawing.Point(182, 6);
			this.textBoxSeedValue.Margin = new System.Windows.Forms.Padding(4);
			this.textBoxSeedValue.Name = "textBoxSeedValue";
			this.textBoxSeedValue.Size = new System.Drawing.Size(83, 22);
			this.textBoxSeedValue.TabIndex = 2;
			// 
			// label1
			// 
			this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(35, 10);
			this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(79, 16);
			this.label1.TabIndex = 3;
			this.label1.Text = "Seed Value";
			// 
			// checkBoxValidations
			// 
			this.checkBoxValidations.AutoSize = true;
			this.checkBoxValidations.Location = new System.Drawing.Point(273, 15);
			this.checkBoxValidations.Margin = new System.Windows.Forms.Padding(4);
			this.checkBoxValidations.Name = "checkBoxValidations";
			this.checkBoxValidations.Size = new System.Drawing.Size(122, 20);
			this.checkBoxValidations.TabIndex = 4;
			this.checkBoxValidations.Text = "Use Validations";
			this.checkBoxValidations.UseVisualStyleBackColor = true;
			this.checkBoxValidations.CheckedChanged += new System.EventHandler(this.checkBoxValidations_CheckedChanged);
			// 
			// checkBoxAnySession
			// 
			this.checkBoxAnySession.AutoSize = true;
			this.checkBoxAnySession.Location = new System.Drawing.Point(38, 313);
			this.checkBoxAnySession.Margin = new System.Windows.Forms.Padding(4);
			this.checkBoxAnySession.Name = "checkBoxAnySession";
			this.checkBoxAnySession.Size = new System.Drawing.Size(102, 20);
			this.checkBoxAnySession.TabIndex = 5;
			this.checkBoxAnySession.Text = "Any Session";
			this.checkBoxAnySession.UseVisualStyleBackColor = true;
			this.checkBoxAnySession.CheckedChanged += new System.EventHandler(this.checkBoxAnySession_CheckedChanged);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(517, 68);
			this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(85, 16);
			this.label2.TabIndex = 9;
			this.label2.Text = "Percentages";
			// 
			// dataGridViewPercentages
			// 
			this.dataGridViewPercentages.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridViewPercentages.Location = new System.Drawing.Point(520, 88);
			this.dataGridViewPercentages.Margin = new System.Windows.Forms.Padding(4);
			this.dataGridViewPercentages.Name = "dataGridViewPercentages";
			this.dataGridViewPercentages.Size = new System.Drawing.Size(355, 245);
			this.dataGridViewPercentages.TabIndex = 13;
			// 
			// buttonApplyChanges
			// 
			this.buttonApplyChanges.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonApplyChanges.Location = new System.Drawing.Point(801, 515);
			this.buttonApplyChanges.Margin = new System.Windows.Forms.Padding(4);
			this.buttonApplyChanges.Name = "buttonApplyChanges";
			this.buttonApplyChanges.Size = new System.Drawing.Size(128, 38);
			this.buttonApplyChanges.TabIndex = 14;
			this.buttonApplyChanges.Text = "OK";
			this.buttonApplyChanges.UseVisualStyleBackColor = true;
			this.buttonApplyChanges.Click += new System.EventHandler(this.buttonApplyChanges_Click);
			// 
			// buttonDone
			// 
			this.buttonDone.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonDone.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.buttonDone.Location = new System.Drawing.Point(693, 515);
			this.buttonDone.Margin = new System.Windows.Forms.Padding(4);
			this.buttonDone.Name = "buttonDone";
			this.buttonDone.Size = new System.Drawing.Size(100, 38);
			this.buttonDone.TabIndex = 15;
			this.buttonDone.Text = "Cancel";
			this.buttonDone.UseVisualStyleBackColor = true;
			this.buttonDone.Click += new System.EventHandler(this.buttonDone_Click);
			// 
			// checkBoxOverride
			// 
			this.checkBoxOverride.AutoSize = true;
			this.checkBoxOverride.Location = new System.Drawing.Point(292, 508);
			this.checkBoxOverride.Margin = new System.Windows.Forms.Padding(4);
			this.checkBoxOverride.Name = "checkBoxOverride";
			this.checkBoxOverride.Size = new System.Drawing.Size(147, 20);
			this.checkBoxOverride.TabIndex = 16;
			this.checkBoxOverride.Text = "Override Pack Price";
			this.checkBoxOverride.UseVisualStyleBackColor = true;
			// 
			// textBoxPackPriceOverride
			// 
			this.textBoxPackPriceOverride.Location = new System.Drawing.Point(389, 529);
			this.textBoxPackPriceOverride.Margin = new System.Windows.Forms.Padding(4);
			this.textBoxPackPriceOverride.Name = "textBoxPackPriceOverride";
			this.textBoxPackPriceOverride.Size = new System.Drawing.Size(104, 22);
			this.textBoxPackPriceOverride.TabIndex = 17;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(308, 532);
			this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(73, 16);
			this.label3.TabIndex = 18;
			this.label3.Text = "Pack Price";
			// 
			// textBoxHousePortion
			// 
			this.textBoxHousePortion.Location = new System.Drawing.Point(182, 36);
			this.textBoxHousePortion.Margin = new System.Windows.Forms.Padding(4);
			this.textBoxHousePortion.Name = "textBoxHousePortion";
			this.textBoxHousePortion.Size = new System.Drawing.Size(83, 22);
			this.textBoxHousePortion.TabIndex = 21;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(35, 40);
			this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(93, 16);
			this.label4.TabIndex = 20;
			this.label4.Text = "House Portion";
			// 
			// textBoxCurrentValue
			// 
			this.textBoxCurrentValue.Location = new System.Drawing.Point(182, 105);
			this.textBoxCurrentValue.Margin = new System.Windows.Forms.Padding(4);
			this.textBoxCurrentValue.Name = "textBoxCurrentValue";
			this.textBoxCurrentValue.Size = new System.Drawing.Size(83, 22);
			this.textBoxCurrentValue.TabIndex = 24;
			// 
			// labelCurrentValue
			// 
			this.labelCurrentValue.AutoSize = true;
			this.labelCurrentValue.Location = new System.Drawing.Point(35, 105);
			this.labelCurrentValue.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.labelCurrentValue.Name = "labelCurrentValue";
			this.labelCurrentValue.Size = new System.Drawing.Size(111, 16);
			this.labelCurrentValue.TabIndex = 23;
			this.labelCurrentValue.Text = "Set Current Value";
			// 
			// textBoxCurrentBackup
			// 
			this.textBoxCurrentBackup.Location = new System.Drawing.Point(182, 137);
			this.textBoxCurrentBackup.Margin = new System.Windows.Forms.Padding(4);
			this.textBoxCurrentBackup.Name = "textBoxCurrentBackup";
			this.textBoxCurrentBackup.Size = new System.Drawing.Size(83, 22);
			this.textBoxCurrentBackup.TabIndex = 27;
			// 
			// labelCurrentBackup
			// 
			this.labelCurrentBackup.AutoSize = true;
			this.labelCurrentBackup.Location = new System.Drawing.Point(35, 137);
			this.labelCurrentBackup.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.labelCurrentBackup.Name = "labelCurrentBackup";
			this.labelCurrentBackup.Size = new System.Drawing.Size(115, 16);
			this.labelCurrentBackup.TabIndex = 26;
			this.labelCurrentBackup.Text = "Set Backup Value";
			// 
			// textBoxTertiaryValue
			// 
			this.textBoxTertiaryValue.Location = new System.Drawing.Point(182, 169);
			this.textBoxTertiaryValue.Margin = new System.Windows.Forms.Padding(4);
			this.textBoxTertiaryValue.Name = "textBoxTertiaryValue";
			this.textBoxTertiaryValue.Size = new System.Drawing.Size(83, 22);
			this.textBoxTertiaryValue.TabIndex = 30;
			// 
			// labelCurrentTertiary
			// 
			this.labelCurrentTertiary.AutoSize = true;
			this.labelCurrentTertiary.Location = new System.Drawing.Point(35, 169);
			this.labelCurrentTertiary.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.labelCurrentTertiary.Name = "labelCurrentTertiary";
			this.labelCurrentTertiary.Size = new System.Drawing.Size(115, 16);
			this.labelCurrentTertiary.TabIndex = 29;
			this.labelCurrentTertiary.Text = "Set Tertiary Value";
			// 
			// simpleCheckRelationGridListPick
			// 
			this.simpleCheckRelationGridListPick.AllowUserToAddRows = false;
			this.simpleCheckRelationGridListPick.AllowUserToDeleteRows = false;
			this.simpleCheckRelationGridListPick.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.simpleCheckRelationGridListPick.display_column_header = "Items";
			this.simpleCheckRelationGridListPick.display_column_name = "lst_desc";
			this.simpleCheckRelationGridListPick.Location = new System.Drawing.Point(273, 271);
			this.simpleCheckRelationGridListPick.Margin = new System.Windows.Forms.Padding(4);
			this.simpleCheckRelationGridListPick.Name = "simpleCheckRelationGridListPick";
			this.simpleCheckRelationGridListPick.RowHeadersVisible = false;
			this.simpleCheckRelationGridListPick.Size = new System.Drawing.Size(239, 222);
			this.simpleCheckRelationGridListPick.source_data_relation_member_key = "lst_id";
			this.simpleCheckRelationGridListPick.source_data_relation_member_tablename = "listpick1";
			this.simpleCheckRelationGridListPick.source_data_relation_tablename = "accrual_group_input_list_pick";
			this.simpleCheckRelationGridListPick.source_data_tablename = "some_unique_name_here_list_pick";
			this.simpleCheckRelationGridListPick.TabIndex = 19;
			// 
			// simpleCheckRelationGridCategories
			// 
			this.simpleCheckRelationGridCategories.AllowUserToAddRows = false;
			this.simpleCheckRelationGridCategories.AllowUserToDeleteRows = false;
			this.simpleCheckRelationGridCategories.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.simpleCheckRelationGridCategories.display_column_header = "Category";
			this.simpleCheckRelationGridCategories.display_column_name = "ctg_desc";
			this.simpleCheckRelationGridCategories.Location = new System.Drawing.Point(273, 44);
			this.simpleCheckRelationGridCategories.Margin = new System.Windows.Forms.Padding(4);
			this.simpleCheckRelationGridCategories.Name = "simpleCheckRelationGridCategories";
			this.simpleCheckRelationGridCategories.RowHeadersVisible = false;
			this.simpleCheckRelationGridCategories.Size = new System.Drawing.Size(239, 219);
			this.simpleCheckRelationGridCategories.source_data_relation_member_key = "ctg_id";
			this.simpleCheckRelationGridCategories.source_data_relation_member_tablename = "category";
			this.simpleCheckRelationGridCategories.source_data_relation_tablename = "accrual_group_input_categories";
			this.simpleCheckRelationGridCategories.source_data_tablename = "some_unique_name_here_categories";
			this.simpleCheckRelationGridCategories.TabIndex = 1;
			// 
			// simpleCheckRelationGrid1
			// 
			this.simpleCheckRelationGrid1.AllowUserToAddRows = false;
			this.simpleCheckRelationGrid1.AllowUserToDeleteRows = false;
			this.simpleCheckRelationGrid1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.simpleCheckRelationGrid1.display_column_header = "Session";
			this.simpleCheckRelationGrid1.display_column_name = null;
			this.simpleCheckRelationGrid1.Location = new System.Drawing.Point(38, 338);
			this.simpleCheckRelationGrid1.Margin = new System.Windows.Forms.Padding(4);
			this.simpleCheckRelationGrid1.Name = "simpleCheckRelationGrid1";
			this.simpleCheckRelationGrid1.RowHeadersVisible = false;
			this.simpleCheckRelationGrid1.Size = new System.Drawing.Size(227, 187);
			this.simpleCheckRelationGrid1.source_data_relation_member_key = null;
			this.simpleCheckRelationGrid1.source_data_relation_member_tablename = "uninitialized";
			this.simpleCheckRelationGrid1.source_data_relation_tablename = "uninitialized";
			this.simpleCheckRelationGrid1.source_data_tablename = "uninitialized";
			this.simpleCheckRelationGrid1.TabIndex = 0;
			// 
			// checkBoxDaily
			// 
			this.checkBoxDaily.AutoSize = true;
			this.checkBoxDaily.Location = new System.Drawing.Point(520, 20);
			this.checkBoxDaily.Margin = new System.Windows.Forms.Padding(4);
			this.checkBoxDaily.Name = "checkBoxDaily";
			this.checkBoxDaily.Size = new System.Drawing.Size(103, 20);
			this.checkBoxDaily.TabIndex = 31;
			this.checkBoxDaily.Text = "Accrue Daily";
			this.checkBoxDaily.UseVisualStyleBackColor = true;
			// 
			// checkBoxParamutual
			// 
			this.checkBoxParamutual.AutoSize = true;
			this.checkBoxParamutual.Enabled = false;
			this.checkBoxParamutual.Location = new System.Drawing.Point(520, 48);
			this.checkBoxParamutual.Margin = new System.Windows.Forms.Padding(4);
			this.checkBoxParamutual.Name = "checkBoxParamutual";
			this.checkBoxParamutual.Size = new System.Drawing.Size(143, 20);
			this.checkBoxParamutual.TabIndex = 32;
			this.checkBoxParamutual.Text = "Paramutual Accrual";
			this.checkBoxParamutual.UseVisualStyleBackColor = true;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(517, 460);
			this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(107, 16);
			this.label5.TabIndex = 34;
			this.label5.Text = "Ball Count Reset";
			// 
			// textBoxBallCountReset
			// 
			this.textBoxBallCountReset.Location = new System.Drawing.Point(648, 455);
			this.textBoxBallCountReset.Margin = new System.Windows.Forms.Padding(4);
			this.textBoxBallCountReset.Name = "textBoxBallCountReset";
			this.textBoxBallCountReset.Size = new System.Drawing.Size(55, 22);
			this.textBoxBallCountReset.TabIndex = 33;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(722, 460);
			this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(96, 16);
			this.label6.TabIndex = 36;
			this.label6.Text = "Ball Count Max";
			// 
			// textBoxBallCountMax
			// 
			this.textBoxBallCountMax.Location = new System.Drawing.Point(874, 452);
			this.textBoxBallCountMax.Margin = new System.Windows.Forms.Padding(4);
			this.textBoxBallCountMax.Name = "textBoxBallCountMax";
			this.textBoxBallCountMax.Size = new System.Drawing.Size(55, 22);
			this.textBoxBallCountMax.TabIndex = 35;
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(517, 487);
			this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(115, 16);
			this.label7.TabIndex = 38;
			this.label7.Text = "Increment Balls in ";
			// 
			// textBoxBallIncrementDays
			// 
			this.textBoxBallIncrementDays.Location = new System.Drawing.Point(648, 484);
			this.textBoxBallIncrementDays.Margin = new System.Windows.Forms.Padding(4);
			this.textBoxBallIncrementDays.Name = "textBoxBallIncrementDays";
			this.textBoxBallIncrementDays.Size = new System.Drawing.Size(55, 22);
			this.textBoxBallIncrementDays.TabIndex = 37;
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(712, 487);
			this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(40, 16);
			this.label8.TabIndex = 39;
			this.label8.Text = "Days";
			// 
			// labelSecondaryFixed
			// 
			this.labelSecondaryFixed.AutoSize = true;
			this.labelSecondaryFixed.Location = new System.Drawing.Point(722, 400);
			this.labelSecondaryFixed.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.labelSecondaryFixed.Name = "labelSecondaryFixed";
			this.labelSecondaryFixed.Size = new System.Drawing.Size(135, 16);
			this.labelSecondaryFixed.TabIndex = 43;
			this.labelSecondaryFixed.Text = "Secondary Increment";
			// 
			// textBoxSecondaryIncrement
			// 
			this.textBoxSecondaryIncrement.Location = new System.Drawing.Point(874, 397);
			this.textBoxSecondaryIncrement.Margin = new System.Windows.Forms.Padding(4);
			this.textBoxSecondaryIncrement.Name = "textBoxSecondaryIncrement";
			this.textBoxSecondaryIncrement.Size = new System.Drawing.Size(55, 22);
			this.textBoxSecondaryIncrement.TabIndex = 42;
			// 
			// labelPrimaryFixed
			// 
			this.labelPrimaryFixed.AutoSize = true;
			this.labelPrimaryFixed.Location = new System.Drawing.Point(517, 400);
			this.labelPrimaryFixed.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.labelPrimaryFixed.Name = "labelPrimaryFixed";
			this.labelPrimaryFixed.Size = new System.Drawing.Size(115, 16);
			this.labelPrimaryFixed.TabIndex = 41;
			this.labelPrimaryFixed.Text = "Primary Increment";
			// 
			// textBoxPrimaryIncrement
			// 
			this.textBoxPrimaryIncrement.Location = new System.Drawing.Point(648, 397);
			this.textBoxPrimaryIncrement.Margin = new System.Windows.Forms.Padding(4);
			this.textBoxPrimaryIncrement.Name = "textBoxPrimaryIncrement";
			this.textBoxPrimaryIncrement.Size = new System.Drawing.Size(55, 22);
			this.textBoxPrimaryIncrement.TabIndex = 40;
			// 
			// checkBoxFixedIncrement
			// 
			this.checkBoxFixedIncrement.AutoSize = true;
			this.checkBoxFixedIncrement.Location = new System.Drawing.Point(517, 368);
			this.checkBoxFixedIncrement.Margin = new System.Windows.Forms.Padding(4);
			this.checkBoxFixedIncrement.Name = "checkBoxFixedIncrement";
			this.checkBoxFixedIncrement.Size = new System.Drawing.Size(128, 20);
			this.checkBoxFixedIncrement.TabIndex = 44;
			this.checkBoxFixedIncrement.Text = "Fixed Increments";
			this.checkBoxFixedIncrement.UseVisualStyleBackColor = true;
			this.checkBoxFixedIncrement.CheckedChanged += new System.EventHandler(this.checkBoxFixedIncrement_CheckedChanged);
			// 
			// labelTertiaryFixed
			// 
			this.labelTertiaryFixed.AutoSize = true;
			this.labelTertiaryFixed.Location = new System.Drawing.Point(517, 429);
			this.labelTertiaryFixed.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.labelTertiaryFixed.Name = "labelTertiaryFixed";
			this.labelTertiaryFixed.Size = new System.Drawing.Size(112, 16);
			this.labelTertiaryFixed.TabIndex = 46;
			this.labelTertiaryFixed.Text = "TertiaryIncrement";
			// 
			// textBoxTertiaryIncrement
			// 
			this.textBoxTertiaryIncrement.Location = new System.Drawing.Point(648, 426);
			this.textBoxTertiaryIncrement.Margin = new System.Windows.Forms.Padding(4);
			this.textBoxTertiaryIncrement.Name = "textBoxTertiaryIncrement";
			this.textBoxTertiaryIncrement.Size = new System.Drawing.Size(55, 22);
			this.textBoxTertiaryIncrement.TabIndex = 45;
			// 
			// checkBoxAccrueWeekly
			// 
			this.checkBoxAccrueWeekly.AutoSize = true;
			this.checkBoxAccrueWeekly.Location = new System.Drawing.Point(648, 16);
			this.checkBoxAccrueWeekly.Margin = new System.Windows.Forms.Padding(4);
			this.checkBoxAccrueWeekly.Name = "checkBoxAccrueWeekly";
			this.checkBoxAccrueWeekly.Size = new System.Drawing.Size(118, 20);
			this.checkBoxAccrueWeekly.TabIndex = 47;
			this.checkBoxAccrueWeekly.Text = "Accrue Weekly";
			this.checkBoxAccrueWeekly.UseVisualStyleBackColor = true;
			this.checkBoxAccrueWeekly.CheckedChanged += new System.EventHandler(this.checkBoxAccrueWeekly_CheckedChanged);
			// 
			// comboBoxDayOfWeek
			// 
			this.comboBoxDayOfWeek.FormattingEnabled = true;
			this.comboBoxDayOfWeek.Location = new System.Drawing.Point(790, 10);
			this.comboBoxDayOfWeek.Margin = new System.Windows.Forms.Padding(4);
			this.comboBoxDayOfWeek.Name = "comboBoxDayOfWeek";
			this.comboBoxDayOfWeek.Size = new System.Drawing.Size(134, 24);
			this.comboBoxDayOfWeek.TabIndex = 48;
			this.comboBoxDayOfWeek.SelectedIndexChanged += new System.EventHandler(this.comboBoxDayOfWeek_SelectedIndexChanged);
			// 
			// label9
			// 
			this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(35, 275);
			this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(91, 16);
			this.label9.TabIndex = 50;
			this.label9.Text = "Display Order";
			// 
			// textBoxDisplayOrder
			// 
			this.textBoxDisplayOrder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.textBoxDisplayOrder.Location = new System.Drawing.Point(182, 271);
			this.textBoxDisplayOrder.Margin = new System.Windows.Forms.Padding(4);
			this.textBoxDisplayOrder.Name = "textBoxDisplayOrder";
			this.textBoxDisplayOrder.Size = new System.Drawing.Size(83, 22);
			this.textBoxDisplayOrder.TabIndex = 49;
			// 
			// checkBoxRemainderToSecondary
			// 
			this.checkBoxRemainderToSecondary.AutoSize = true;
			this.checkBoxRemainderToSecondary.Location = new System.Drawing.Point(729, 363);
			this.checkBoxRemainderToSecondary.Margin = new System.Windows.Forms.Padding(4);
			this.checkBoxRemainderToSecondary.Name = "checkBoxRemainderToSecondary";
			this.checkBoxRemainderToSecondary.Size = new System.Drawing.Size(177, 20);
			this.checkBoxRemainderToSecondary.TabIndex = 51;
			this.checkBoxRemainderToSecondary.Text = "Remainder to Secondary";
			this.checkBoxRemainderToSecondary.UseVisualStyleBackColor = true;
			this.checkBoxRemainderToSecondary.CheckedChanged += new System.EventHandler(this.checkBoxRemainderToSecondary_CheckedChanged);
			// 
			// checkBoxRemainderToPrimary
			// 
			this.checkBoxRemainderToPrimary.AutoSize = true;
			this.checkBoxRemainderToPrimary.Location = new System.Drawing.Point(729, 338);
			this.checkBoxRemainderToPrimary.Margin = new System.Windows.Forms.Padding(4);
			this.checkBoxRemainderToPrimary.Name = "checkBoxRemainderToPrimary";
			this.checkBoxRemainderToPrimary.Size = new System.Drawing.Size(157, 20);
			this.checkBoxRemainderToPrimary.TabIndex = 51;
			this.checkBoxRemainderToPrimary.Text = "Remainder to Primary";
			this.checkBoxRemainderToPrimary.UseVisualStyleBackColor = true;
			this.checkBoxRemainderToPrimary.CheckedChanged += new System.EventHandler(this.checkBoxRemainderToPrimary_CheckedChanged);
			// 
			// textBoxHotballGame
			// 
			this.textBoxHotballGame.Location = new System.Drawing.Point(100, 231);
			this.textBoxHotballGame.Margin = new System.Windows.Forms.Padding(4);
			this.textBoxHotballGame.Name = "textBoxHotballGame";
			this.textBoxHotballGame.Size = new System.Drawing.Size(165, 22);
			this.textBoxHotballGame.TabIndex = 53;
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(35, 211);
			this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(203, 16);
			this.label10.TabIndex = 52;
			this.label10.Text = "Game Name to use for cashballs";
			// 
			// ConfigureAccrualForm
			// 
			this.AcceptButton = this.buttonApplyChanges;
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.buttonDone;
			this.ClientSize = new System.Drawing.Size(945, 566);
			this.Controls.Add(this.textBoxHotballGame);
			this.Controls.Add(this.label10);
			this.Controls.Add(this.checkBoxRemainderToSecondary);
			this.Controls.Add(this.checkBoxRemainderToPrimary);
			this.Controls.Add(this.label9);
			this.Controls.Add(this.textBoxDisplayOrder);
			this.Controls.Add(this.comboBoxDayOfWeek);
			this.Controls.Add(this.checkBoxAccrueWeekly);
			this.Controls.Add(this.labelTertiaryFixed);
			this.Controls.Add(this.textBoxTertiaryIncrement);
			this.Controls.Add(this.checkBoxFixedIncrement);
			this.Controls.Add(this.labelSecondaryFixed);
			this.Controls.Add(this.textBoxSecondaryIncrement);
			this.Controls.Add(this.labelPrimaryFixed);
			this.Controls.Add(this.textBoxPrimaryIncrement);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.textBoxBallIncrementDays);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.textBoxBallCountMax);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.textBoxBallCountReset);
			this.Controls.Add(this.checkBoxParamutual);
			this.Controls.Add(this.checkBoxDaily);
			this.Controls.Add(this.textBoxTertiaryValue);
			this.Controls.Add(this.labelCurrentTertiary);
			this.Controls.Add(this.textBoxCurrentBackup);
			this.Controls.Add(this.labelCurrentBackup);
			this.Controls.Add(this.textBoxCurrentValue);
			this.Controls.Add(this.labelCurrentValue);
			this.Controls.Add(this.textBoxHousePortion);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.simpleCheckRelationGridListPick);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.textBoxPackPriceOverride);
			this.Controls.Add(this.checkBoxOverride);
			this.Controls.Add(this.buttonDone);
			this.Controls.Add(this.buttonApplyChanges);
			this.Controls.Add(this.dataGridViewPercentages);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.checkBoxAnySession);
			this.Controls.Add(this.checkBoxValidations);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.textBoxSeedValue);
			this.Controls.Add(this.simpleCheckRelationGridCategories);
			this.Controls.Add(this.simpleCheckRelationGrid1);
			this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Margin = new System.Windows.Forms.Padding(4);
			this.Name = "ConfigureAccrualForm";
			this.Text = "Configure Accrual";
			this.Load += new System.EventHandler(this.ConfigureAccrualForm_Load);
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewPercentages)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.simpleCheckRelationGridListPick)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.simpleCheckRelationGridCategories)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.simpleCheckRelationGrid1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private SimpleCheckRelationGrid simpleCheckRelationGrid1;
		private SimpleCheckRelationGrid simpleCheckRelationGridCategories;
		private System.Windows.Forms.TextBox textBoxSeedValue;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.CheckBox checkBoxValidations;
		private System.Windows.Forms.CheckBox checkBoxAnySession;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.DataGridView dataGridViewPercentages;
		private System.Windows.Forms.Button buttonApplyChanges;
		private System.Windows.Forms.Button buttonDone;
		private System.Windows.Forms.CheckBox checkBoxOverride;
		private System.Windows.Forms.TextBox textBoxPackPriceOverride;
		private System.Windows.Forms.Label label3;
		private SimpleCheckRelationGrid simpleCheckRelationGridListPick;
		private System.Windows.Forms.TextBox textBoxHousePortion;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox textBoxCurrentValue;
		private System.Windows.Forms.Label labelCurrentValue;
		private System.Windows.Forms.TextBox textBoxCurrentBackup;
		private System.Windows.Forms.Label labelCurrentBackup;
		private System.Windows.Forms.TextBox textBoxTertiaryValue;
		private System.Windows.Forms.Label labelCurrentTertiary;
		private System.Windows.Forms.CheckBox checkBoxDaily;
		private System.Windows.Forms.CheckBox checkBoxParamutual;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox textBoxBallCountReset;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox textBoxBallCountMax;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox textBoxBallIncrementDays;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label labelSecondaryFixed;
		private System.Windows.Forms.TextBox textBoxSecondaryIncrement;
		private System.Windows.Forms.Label labelPrimaryFixed;
		private System.Windows.Forms.TextBox textBoxPrimaryIncrement;
		private System.Windows.Forms.CheckBox checkBoxFixedIncrement;
		private System.Windows.Forms.Label labelTertiaryFixed;
		private System.Windows.Forms.TextBox textBoxTertiaryIncrement;
		private System.Windows.Forms.CheckBox checkBoxAccrueWeekly;
		private System.Windows.Forms.ComboBox comboBoxDayOfWeek;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.TextBox textBoxDisplayOrder;
		private System.Windows.Forms.CheckBox checkBoxRemainderToSecondary;
		private System.Windows.Forms.CheckBox checkBoxRemainderToPrimary;
		private System.Windows.Forms.TextBox textBoxHotballGame;
		private System.Windows.Forms.Label label10;
	}
}