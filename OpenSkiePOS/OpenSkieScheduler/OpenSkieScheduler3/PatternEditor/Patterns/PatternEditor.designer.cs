namespace BingoGameCore4.Controls
{
	partial class PatternEditor
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
			this.listBox1 = new System.Windows.Forms.ListBox();
			this.buttonAddBlock = new System.Windows.Forms.Button();
			this.buttonApply = new System.Windows.Forms.Button();
			this.buttonUndo = new System.Windows.Forms.Button();
			this.textBoxRepeat = new System.Windows.Forms.TextBox();
			this.comboBox1 = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.buttonCreate = new System.Windows.Forms.Button();
			this.buttonRename = new System.Windows.Forms.Button();
			this.buttonCopy = new System.Windows.Forms.Button();
			this.buttonDeletePattern = new System.Windows.Forms.Button();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.radioButtonAnyWhereAnyRotationHardway = new System.Windows.Forms.RadioButton();
			this.radioButtonAnyWhereAnyRotation = new System.Windows.Forms.RadioButton();
			this.checkBoxNoOverlap = new System.Windows.Forms.CheckBox();
			this.checkBoxAllowMirror = new System.Windows.Forms.CheckBox();
			this.button1 = new System.Windows.Forms.Button();
			this.radioButtonNoExpand = new System.Windows.Forms.RadioButton();
			this.radioButtonAnyRotationHardway = new System.Windows.Forms.RadioButton();
			this.radioButtonAnyHardway = new System.Windows.Forms.RadioButton();
			this.radioButtonAnyRotation = new System.Windows.Forms.RadioButton();
			this.radioButtonAnywhere = new System.Windows.Forms.RadioButton();
			this.patternBlockGroup1 = new BingoGameCore4.Controls.Patterns.PatternBlockGroup();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.checkBoxMultiPatternOrderDependant = new System.Windows.Forms.CheckBox();
			this.buttonExpand2 = new System.Windows.Forms.Button();
			this.checkBoxSingleCard = new System.Windows.Forms.CheckBox();
			this.label3 = new System.Windows.Forms.Label();
			this.radioButtonNoOverlap = new System.Windows.Forms.RadioButton();
			this.radioButtonMustOverlap = new System.Windows.Forms.RadioButton();
			this.radioButtonOverlapOk = new System.Windows.Forms.RadioButton();
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this.tabPage3 = new System.Windows.Forms.TabPage();
			this.checkBoxCrazyHardway = new System.Windows.Forms.CheckBox();
			this.textBoxCrazyCount = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.tabPageJavaServer = new System.Windows.Forms.TabPage();
			this.label5 = new System.Windows.Forms.Label();
			this.textBoxJavaServerString = new System.Windows.Forms.TextBox();
			this.currentPatternScroller2 = new BingoGameCore4.Controls.Patterns.CurrentPatternScroller();
			this.currentPatternScroller1 = new BingoGameCore4.Controls.Patterns.CurrentPatternScroller();
			this.tabControl2 = new System.Windows.Forms.TabControl();
			this.checkBox2 = new System.Windows.Forms.CheckBox();
			this.tabControl1.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.tabPage2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			this.tabPage3.SuspendLayout();
			this.tabPageJavaServer.SuspendLayout();
			this.SuspendLayout();
			// 
			// listBox1
			// 
			this.listBox1.FormattingEnabled = true;
			this.listBox1.Location = new System.Drawing.Point(12, 12);
			this.listBox1.Name = "listBox1";
			this.listBox1.Size = new System.Drawing.Size(155, 329);
			this.listBox1.TabIndex = 0;
			// 
			// buttonAddBlock
			// 
			this.buttonAddBlock.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonAddBlock.Location = new System.Drawing.Point(375, 331);
			this.buttonAddBlock.Name = "buttonAddBlock";
			this.buttonAddBlock.Size = new System.Drawing.Size(105, 41);
			this.buttonAddBlock.TabIndex = 6;
			this.buttonAddBlock.Text = "Add Pattern Block";
			this.buttonAddBlock.UseVisualStyleBackColor = true;
			this.buttonAddBlock.Click += new System.EventHandler(this.buttonAddBlock_Click);
			// 
			// buttonApply
			// 
			this.buttonApply.Location = new System.Drawing.Point(12, 391);
			this.buttonApply.Name = "buttonApply";
			this.buttonApply.Size = new System.Drawing.Size(75, 37);
			this.buttonApply.TabIndex = 7;
			this.buttonApply.Text = "Apply Changes";
			this.buttonApply.UseVisualStyleBackColor = true;
			this.buttonApply.Click += new System.EventHandler(this.buttonApply_Click);
			// 
			// buttonUndo
			// 
			this.buttonUndo.Location = new System.Drawing.Point(12, 347);
			this.buttonUndo.Name = "buttonUndo";
			this.buttonUndo.Size = new System.Drawing.Size(75, 38);
			this.buttonUndo.TabIndex = 8;
			this.buttonUndo.Text = "Undo Changes";
			this.buttonUndo.UseVisualStyleBackColor = true;
			this.buttonUndo.Click += new System.EventHandler(this.buttonUndo_Click);
			// 
			// textBoxRepeat
			// 
			this.textBoxRepeat.Location = new System.Drawing.Point(447, 13);
			this.textBoxRepeat.Name = "textBoxRepeat";
			this.textBoxRepeat.Size = new System.Drawing.Size(58, 20);
			this.textBoxRepeat.TabIndex = 9;
			// 
			// comboBox1
			// 
			this.comboBox1.FormattingEnabled = true;
			this.comboBox1.Location = new System.Drawing.Point(305, 23);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new System.Drawing.Size(132, 21);
			this.comboBox1.TabIndex = 10;
			this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(190, 26);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(71, 13);
			this.label1.TabIndex = 11;
			this.label1.Text = "Pattern Mode";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(372, 6);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(42, 26);
			this.label2.TabIndex = 12;
			this.label2.Text = "Repeat\r\nCount";
			// 
			// buttonCreate
			// 
			this.buttonCreate.Location = new System.Drawing.Point(92, 348);
			this.buttonCreate.Name = "buttonCreate";
			this.buttonCreate.Size = new System.Drawing.Size(75, 37);
			this.buttonCreate.TabIndex = 13;
			this.buttonCreate.Text = "Create Pattern";
			this.buttonCreate.UseVisualStyleBackColor = true;
			this.buttonCreate.Click += new System.EventHandler(this.buttonCreate_Click);
			// 
			// buttonRename
			// 
			this.buttonRename.Location = new System.Drawing.Point(92, 391);
			this.buttonRename.Name = "buttonRename";
			this.buttonRename.Size = new System.Drawing.Size(75, 37);
			this.buttonRename.TabIndex = 14;
			this.buttonRename.Text = "Rename Pattern";
			this.buttonRename.UseVisualStyleBackColor = true;
			this.buttonRename.Click += new System.EventHandler(this.buttonRename_Click);
			// 
			// buttonCopy
			// 
			this.buttonCopy.Location = new System.Drawing.Point(92, 434);
			this.buttonCopy.Name = "buttonCopy";
			this.buttonCopy.Size = new System.Drawing.Size(75, 37);
			this.buttonCopy.TabIndex = 15;
			this.buttonCopy.Text = "Copy Pattern";
			this.buttonCopy.UseVisualStyleBackColor = true;
			this.buttonCopy.Click += new System.EventHandler(this.buttonCopy_Click);
			// 
			// buttonDeletePattern
			// 
			this.buttonDeletePattern.Location = new System.Drawing.Point(12, 434);
			this.buttonDeletePattern.Name = "buttonDeletePattern";
			this.buttonDeletePattern.Size = new System.Drawing.Size(75, 37);
			this.buttonDeletePattern.TabIndex = 16;
			this.buttonDeletePattern.Text = "Delete Pattern";
			this.buttonDeletePattern.UseVisualStyleBackColor = true;
			this.buttonDeletePattern.Click += new System.EventHandler(this.buttonDeletePattern_Click);
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Controls.Add(this.tabPage2);
			this.tabControl1.Controls.Add(this.tabPage3);
			this.tabControl1.Controls.Add(this.tabPageJavaServer);
			this.tabControl1.Location = new System.Drawing.Point(193, 50);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(579, 407);
			this.tabControl1.TabIndex = 19;
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.radioButtonAnyWhereAnyRotationHardway);
			this.tabPage1.Controls.Add(this.radioButtonAnyWhereAnyRotation);
			this.tabPage1.Controls.Add(this.checkBoxNoOverlap);
			this.tabPage1.Controls.Add(this.checkBoxAllowMirror);
			this.tabPage1.Controls.Add(this.button1);
			this.tabPage1.Controls.Add(this.radioButtonNoExpand);
			this.tabPage1.Controls.Add(this.radioButtonAnyRotationHardway);
			this.tabPage1.Controls.Add(this.radioButtonAnyHardway);
			this.tabPage1.Controls.Add(this.radioButtonAnyRotation);
			this.tabPage1.Controls.Add(this.radioButtonAnywhere);
			this.tabPage1.Controls.Add(this.patternBlockGroup1);
			this.tabPage1.Controls.Add(this.label2);
			this.tabPage1.Controls.Add(this.buttonAddBlock);
			this.tabPage1.Controls.Add(this.textBoxRepeat);
			this.tabPage1.Location = new System.Drawing.Point(4, 22);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new System.Drawing.Size(571, 381);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "Flat Pattern";
			this.tabPage1.UseVisualStyleBackColor = true;
			// 
			// radioButtonAnyWhereAnyRotationHardway
			// 
			this.radioButtonAnyWhereAnyRotationHardway.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.radioButtonAnyWhereAnyRotationHardway.AutoSize = true;
			this.radioButtonAnyWhereAnyRotationHardway.Location = new System.Drawing.Point(375, 197);
			this.radioButtonAnyWhereAnyRotationHardway.Name = "radioButtonAnyWhereAnyRotationHardway";
			this.radioButtonAnyWhereAnyRotationHardway.Size = new System.Drawing.Size(137, 30);
			this.radioButtonAnyWhereAnyRotationHardway.TabIndex = 16;
			this.radioButtonAnyWhereAnyRotationHardway.TabStop = true;
			this.radioButtonAnyWhereAnyRotationHardway.Text = "Anywhere\r\n Hardway, Any Rotation";
			this.radioButtonAnyWhereAnyRotationHardway.UseVisualStyleBackColor = true;
			this.radioButtonAnyWhereAnyRotationHardway.CheckedChanged += new System.EventHandler(this.radioButtonAnyWhereAnyRotationHardway_CheckedChanged);
			// 
			// radioButtonAnyWhereAnyRotation
			// 
			this.radioButtonAnyWhereAnyRotation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.radioButtonAnyWhereAnyRotation.AutoSize = true;
			this.radioButtonAnyWhereAnyRotation.Location = new System.Drawing.Point(375, 174);
			this.radioButtonAnyWhereAnyRotation.Name = "radioButtonAnyWhereAnyRotation";
			this.radioButtonAnyWhereAnyRotation.Size = new System.Drawing.Size(139, 17);
			this.radioButtonAnyWhereAnyRotation.TabIndex = 15;
			this.radioButtonAnyWhereAnyRotation.TabStop = true;
			this.radioButtonAnyWhereAnyRotation.Text = "Anywhere, Any Rotation";
			this.radioButtonAnyWhereAnyRotation.UseVisualStyleBackColor = true;
			this.radioButtonAnyWhereAnyRotation.CheckedChanged += new System.EventHandler(this.radioButtonAnyWhereAnyRotation_CheckedChanged);
			// 
			// checkBoxNoOverlap
			// 
			this.checkBoxNoOverlap.AutoSize = true;
			this.checkBoxNoOverlap.Location = new System.Drawing.Point(447, 39);
			this.checkBoxNoOverlap.Name = "checkBoxNoOverlap";
			this.checkBoxNoOverlap.Size = new System.Drawing.Size(80, 17);
			this.checkBoxNoOverlap.TabIndex = 14;
			this.checkBoxNoOverlap.Text = "No Overlap";
			this.checkBoxNoOverlap.UseVisualStyleBackColor = true;
			this.checkBoxNoOverlap.CheckedChanged += new System.EventHandler(this.checkBoxNoOverlap_CheckedChanged);
			// 
			// checkBoxAllowMirror
			// 
			this.checkBoxAllowMirror.AutoSize = true;
			this.checkBoxAllowMirror.Location = new System.Drawing.Point(375, 233);
			this.checkBoxAllowMirror.Name = "checkBoxAllowMirror";
			this.checkBoxAllowMirror.Size = new System.Drawing.Size(127, 17);
			this.checkBoxAllowMirror.TabIndex = 13;
			this.checkBoxAllowMirror.Text = "Include Mirror Pattern";
			this.checkBoxAllowMirror.UseVisualStyleBackColor = true;
			this.checkBoxAllowMirror.CheckedChanged += new System.EventHandler(this.checkBoxAllowMirror_CheckedChanged);
			// 
			// button1
			// 
			this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.button1.Location = new System.Drawing.Point(476, 265);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 48);
			this.button1.TabIndex = 8;
			this.button1.Text = "Show Expanded";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// radioButtonNoExpand
			// 
			this.radioButtonNoExpand.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.radioButtonNoExpand.AutoSize = true;
			this.radioButtonNoExpand.Location = new System.Drawing.Point(375, 91);
			this.radioButtonNoExpand.Name = "radioButtonNoExpand";
			this.radioButtonNoExpand.Size = new System.Drawing.Size(78, 17);
			this.radioButtonNoExpand.TabIndex = 3;
			this.radioButtonNoExpand.TabStop = true;
			this.radioButtonNoExpand.Text = "No Expand";
			this.radioButtonNoExpand.UseVisualStyleBackColor = true;
			this.radioButtonNoExpand.CheckedChanged += new System.EventHandler(this.radioButton5_CheckedChanged);
			// 
			// radioButtonAnyRotationHardway
			// 
			this.radioButtonAnyRotationHardway.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.radioButtonAnyRotationHardway.AutoSize = true;
			this.radioButtonAnyRotationHardway.Location = new System.Drawing.Point(375, 137);
			this.radioButtonAnyRotationHardway.Name = "radioButtonAnyRotationHardway";
			this.radioButtonAnyRotationHardway.Size = new System.Drawing.Size(86, 30);
			this.radioButtonAnyRotationHardway.TabIndex = 7;
			this.radioButtonAnyRotationHardway.TabStop = true;
			this.radioButtonAnyRotationHardway.Text = "Any Rotation\r\nHardway";
			this.radioButtonAnyRotationHardway.UseVisualStyleBackColor = true;
			this.radioButtonAnyRotationHardway.CheckedChanged += new System.EventHandler(this.radioButton4_CheckedChanged);
			// 
			// radioButtonAnyHardway
			// 
			this.radioButtonAnyHardway.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.radioButtonAnyHardway.AutoSize = true;
			this.radioButtonAnyHardway.Location = new System.Drawing.Point(476, 137);
			this.radioButtonAnyHardway.Name = "radioButtonAnyHardway";
			this.radioButtonAnyHardway.Size = new System.Drawing.Size(72, 30);
			this.radioButtonAnyHardway.TabIndex = 6;
			this.radioButtonAnyHardway.TabStop = true;
			this.radioButtonAnyHardway.Text = "Anywhere\r\nHardway";
			this.radioButtonAnyHardway.UseVisualStyleBackColor = true;
			this.radioButtonAnyHardway.CheckedChanged += new System.EventHandler(this.radioButton3_CheckedChanged);
			// 
			// radioButtonAnyRotation
			// 
			this.radioButtonAnyRotation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.radioButtonAnyRotation.AutoSize = true;
			this.radioButtonAnyRotation.Location = new System.Drawing.Point(375, 114);
			this.radioButtonAnyRotation.Name = "radioButtonAnyRotation";
			this.radioButtonAnyRotation.Size = new System.Drawing.Size(86, 17);
			this.radioButtonAnyRotation.TabIndex = 5;
			this.radioButtonAnyRotation.TabStop = true;
			this.radioButtonAnyRotation.Text = "Any Rotation\r\n";
			this.radioButtonAnyRotation.UseVisualStyleBackColor = true;
			this.radioButtonAnyRotation.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
			// 
			// radioButtonAnywhere
			// 
			this.radioButtonAnywhere.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.radioButtonAnywhere.AutoSize = true;
			this.radioButtonAnywhere.Location = new System.Drawing.Point(476, 114);
			this.radioButtonAnywhere.Name = "radioButtonAnywhere";
			this.radioButtonAnywhere.Size = new System.Drawing.Size(72, 17);
			this.radioButtonAnywhere.TabIndex = 4;
			this.radioButtonAnywhere.TabStop = true;
			this.radioButtonAnywhere.Text = "Anywhere";
			this.radioButtonAnywhere.UseVisualStyleBackColor = true;
			this.radioButtonAnywhere.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
			// 
			// patternBlockGroup1
			// 
			this.patternBlockGroup1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.patternBlockGroup1.AutoScroll = true;
			this.patternBlockGroup1.BackColor = System.Drawing.Color.Transparent;
			this.patternBlockGroup1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.patternBlockGroup1.Location = new System.Drawing.Point(3, 0);
			this.patternBlockGroup1.Movable = false;
			this.patternBlockGroup1.Name = "patternBlockGroup1";
			this.patternBlockGroup1.pattern = null;
			this.patternBlockGroup1.Size = new System.Drawing.Size(363, 379);
			this.patternBlockGroup1.TabIndex = 2;
			// 
			// tabPage2
			// 
			this.tabPage2.Controls.Add(this.checkBoxMultiPatternOrderDependant);
			this.tabPage2.Controls.Add(this.buttonExpand2);
			this.tabPage2.Controls.Add(this.checkBoxSingleCard);
			this.tabPage2.Controls.Add(this.label3);
			this.tabPage2.Controls.Add(this.radioButtonNoOverlap);
			this.tabPage2.Controls.Add(this.radioButtonMustOverlap);
			this.tabPage2.Controls.Add(this.radioButtonOverlapOk);
			this.tabPage2.Controls.Add(this.dataGridView1);
			this.tabPage2.Location = new System.Drawing.Point(4, 22);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage2.Size = new System.Drawing.Size(571, 381);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "Multi-Pattern";
			this.tabPage2.UseVisualStyleBackColor = true;
			// 
			// checkBoxMultiPatternOrderDependant
			// 
			this.checkBoxMultiPatternOrderDependant.AutoSize = true;
			this.checkBoxMultiPatternOrderDependant.Location = new System.Drawing.Point(290, 131);
			this.checkBoxMultiPatternOrderDependant.Name = "checkBoxMultiPatternOrderDependant";
			this.checkBoxMultiPatternOrderDependant.Size = new System.Drawing.Size(90, 17);
			this.checkBoxMultiPatternOrderDependant.TabIndex = 10;
			this.checkBoxMultiPatternOrderDependant.Text = "Order Matters";
			this.checkBoxMultiPatternOrderDependant.UseVisualStyleBackColor = true;
			this.checkBoxMultiPatternOrderDependant.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
			// 
			// buttonExpand2
			// 
			this.buttonExpand2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonExpand2.Location = new System.Drawing.Point(450, 108);
			this.buttonExpand2.Name = "buttonExpand2";
			this.buttonExpand2.Size = new System.Drawing.Size(75, 48);
			this.buttonExpand2.TabIndex = 9;
			this.buttonExpand2.Text = "Show Expanded";
			this.buttonExpand2.UseVisualStyleBackColor = true;
			this.buttonExpand2.Click += new System.EventHandler(this.buttonExpand2_Click);
			// 
			// checkBoxSingleCard
			// 
			this.checkBoxSingleCard.AutoSize = true;
			this.checkBoxSingleCard.Location = new System.Drawing.Point(290, 108);
			this.checkBoxSingleCard.Name = "checkBoxSingleCard";
			this.checkBoxSingleCard.Size = new System.Drawing.Size(80, 17);
			this.checkBoxSingleCard.TabIndex = 6;
			this.checkBoxSingleCard.Text = "Single Card";
			this.checkBoxSingleCard.UseVisualStyleBackColor = true;
			this.checkBoxSingleCard.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(288, 185);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(0, 13);
			this.label3.TabIndex = 4;
			this.label3.Text = this.label3.Text;
			// 
			// radioButtonNoOverlap
			// 
			this.radioButtonNoOverlap.AutoSize = true;
			this.radioButtonNoOverlap.Location = new System.Drawing.Point(291, 69);
			this.radioButtonNoOverlap.Name = "radioButtonNoOverlap";
			this.radioButtonNoOverlap.Size = new System.Drawing.Size(79, 17);
			this.radioButtonNoOverlap.TabIndex = 3;
			this.radioButtonNoOverlap.TabStop = true;
			this.radioButtonNoOverlap.Text = "No Overlap";
			this.radioButtonNoOverlap.UseVisualStyleBackColor = true;
			this.radioButtonNoOverlap.CheckedChanged += new System.EventHandler(this.radioButtonNoOverlap_CheckedChanged);
			// 
			// radioButtonMustOverlap
			// 
			this.radioButtonMustOverlap.AutoSize = true;
			this.radioButtonMustOverlap.Location = new System.Drawing.Point(291, 46);
			this.radioButtonMustOverlap.Name = "radioButtonMustOverlap";
			this.radioButtonMustOverlap.Size = new System.Drawing.Size(88, 17);
			this.radioButtonMustOverlap.TabIndex = 2;
			this.radioButtonMustOverlap.TabStop = true;
			this.radioButtonMustOverlap.Text = "Must Overlap";
			this.radioButtonMustOverlap.UseVisualStyleBackColor = true;
			this.radioButtonMustOverlap.CheckedChanged += new System.EventHandler(this.radioButtonMustOverlap_CheckedChanged);
			// 
			// radioButtonOverlapOk
			// 
			this.radioButtonOverlapOk.AutoSize = true;
			this.radioButtonOverlapOk.Location = new System.Drawing.Point(291, 23);
			this.radioButtonOverlapOk.Name = "radioButtonOverlapOk";
			this.radioButtonOverlapOk.Size = new System.Drawing.Size(79, 17);
			this.radioButtonOverlapOk.TabIndex = 1;
			this.radioButtonOverlapOk.TabStop = true;
			this.radioButtonOverlapOk.Text = "Overlap Ok";
			this.radioButtonOverlapOk.UseVisualStyleBackColor = true;
			this.radioButtonOverlapOk.CheckedChanged += new System.EventHandler(this.radioButtonOverlapOk_CheckedChanged);
			// 
			// dataGridView1
			// 
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Left;
			this.dataGridView1.Location = new System.Drawing.Point(3, 3);
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.Size = new System.Drawing.Size(249, 375);
			this.dataGridView1.TabIndex = 0;
			// 
			// tabPage3
			// 
			this.tabPage3.Controls.Add(this.checkBoxCrazyHardway);
			this.tabPage3.Controls.Add(this.textBoxCrazyCount);
			this.tabPage3.Controls.Add(this.label4);
			this.tabPage3.Location = new System.Drawing.Point(4, 22);
			this.tabPage3.Name = "tabPage3";
			this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage3.Size = new System.Drawing.Size(571, 381);
			this.tabPage3.TabIndex = 2;
			this.tabPage3.Text = "Crazy";
			this.tabPage3.UseVisualStyleBackColor = true;
			// 
			// checkBoxCrazyHardway
			// 
			this.checkBoxCrazyHardway.AutoSize = true;
			this.checkBoxCrazyHardway.Location = new System.Drawing.Point(31, 74);
			this.checkBoxCrazyHardway.Name = "checkBoxCrazyHardway";
			this.checkBoxCrazyHardway.Size = new System.Drawing.Size(68, 17);
			this.checkBoxCrazyHardway.TabIndex = 2;
			this.checkBoxCrazyHardway.Text = "Hardway";
			this.checkBoxCrazyHardway.UseVisualStyleBackColor = true;
			// 
			// textBoxCrazyCount
			// 
			this.textBoxCrazyCount.Location = new System.Drawing.Point(140, 37);
			this.textBoxCrazyCount.Name = "textBoxCrazyCount";
			this.textBoxCrazyCount.Size = new System.Drawing.Size(100, 20);
			this.textBoxCrazyCount.TabIndex = 1;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(28, 40);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(84, 13);
			this.label4.TabIndex = 0;
			this.label4.Text = "Spots Anywhere";
			// 
			// tabPageJavaServer
			// 
			this.tabPageJavaServer.Controls.Add(this.label5);
			this.tabPageJavaServer.Controls.Add(this.textBoxJavaServerString);
			this.tabPageJavaServer.Location = new System.Drawing.Point(4, 22);
			this.tabPageJavaServer.Name = "tabPageJavaServer";
			this.tabPageJavaServer.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageJavaServer.Size = new System.Drawing.Size(571, 381);
			this.tabPageJavaServer.TabIndex = 3;
			this.tabPageJavaServer.Text = "Java Server";
			this.tabPageJavaServer.UseVisualStyleBackColor = true;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(6, 91);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(94, 13);
			this.label5.TabIndex = 1;
			this.label5.Text = "Java Server String";
			// 
			// textBoxJavaServerString
			// 
			this.textBoxJavaServerString.Location = new System.Drawing.Point(7, 107);
			this.textBoxJavaServerString.Name = "textBoxJavaServerString";
			this.textBoxJavaServerString.Size = new System.Drawing.Size(558, 20);
			this.textBoxJavaServerString.TabIndex = 0;
			// 
			// currentPatternScroller2
			// 
			this.currentPatternScroller2.BackColor = System.Drawing.Color.Transparent;
			this.currentPatternScroller2.Composite = true;
			this.currentPatternScroller2.Location = new System.Drawing.Point(305, 463);
			this.currentPatternScroller2.Margin = new System.Windows.Forms.Padding(4);
			this.currentPatternScroller2.Movable = false;
			this.currentPatternScroller2.Name = "currentPatternScroller2";
			this.currentPatternScroller2.Pattern = null;
			this.currentPatternScroller2.Rate = 75;
			this.currentPatternScroller2.Size = new System.Drawing.Size(93, 89);
			this.currentPatternScroller2.TabIndex = 18;
			// 
			// currentPatternScroller1
			// 
			this.currentPatternScroller1.BackColor = System.Drawing.Color.Transparent;
			this.currentPatternScroller1.Composite = false;
			this.currentPatternScroller1.Location = new System.Drawing.Point(200, 463);
			this.currentPatternScroller1.Margin = new System.Windows.Forms.Padding(4);
			this.currentPatternScroller1.Movable = false;
			this.currentPatternScroller1.Name = "currentPatternScroller1";
			this.currentPatternScroller1.Pattern = null;
			this.currentPatternScroller1.Rate = 250;
			this.currentPatternScroller1.Size = new System.Drawing.Size(92, 89);
			this.currentPatternScroller1.TabIndex = 17;
			// 
			// tabControl2
			// 
			this.tabControl2.Location = new System.Drawing.Point(572, 12);
			this.tabControl2.Name = "tabControl2";
			this.tabControl2.SelectedIndex = 0;
			this.tabControl2.Size = new System.Drawing.Size(200, 54);
			this.tabControl2.TabIndex = 20;
			// 
			// checkBox2
			// 
			this.checkBox2.AutoSize = true;
			this.checkBox2.Location = new System.Drawing.Point(290, 108);
			this.checkBox2.Name = "checkBox2";
			this.checkBox2.Size = new System.Drawing.Size(80, 17);
			this.checkBox2.TabIndex = 6;
			this.checkBox2.Text = "Single Card";
			this.checkBox2.UseVisualStyleBackColor = true;
			this.checkBox2.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
			// 
			// PatternEditor
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(784, 564);
			this.Controls.Add(this.tabControl2);
			this.Controls.Add(this.tabControl1);
			this.Controls.Add(this.currentPatternScroller2);
			this.Controls.Add(this.currentPatternScroller1);
			this.Controls.Add(this.buttonDeletePattern);
			this.Controls.Add(this.buttonCopy);
			this.Controls.Add(this.buttonRename);
			this.Controls.Add(this.buttonCreate);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.comboBox1);
			this.Controls.Add(this.buttonUndo);
			this.Controls.Add(this.buttonApply);
			this.Controls.Add(this.listBox1);
			this.Name = "PatternEditor";
			this.Text = "Pattern Editor";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PatternEditor_FormClosing);
			this.Load += new System.EventHandler(this.PatternEditor_Load);
			this.tabControl1.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.tabPage1.PerformLayout();
			this.tabPage2.ResumeLayout(false);
			this.tabPage2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			this.tabPage3.ResumeLayout(false);
			this.tabPage3.PerformLayout();
			this.tabPageJavaServer.ResumeLayout(false);
			this.tabPageJavaServer.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ListBox listBox1;
		private BingoGameCore4.Controls.Patterns.PatternBlockGroup patternBlockGroup1;
		private System.Windows.Forms.Button buttonAddBlock;
		private System.Windows.Forms.Button buttonApply;
		private System.Windows.Forms.Button buttonUndo;
		private System.Windows.Forms.TextBox textBoxRepeat;
		private System.Windows.Forms.ComboBox comboBox1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button buttonCreate;
		private System.Windows.Forms.Button buttonRename;
		private System.Windows.Forms.Button buttonCopy;
		private System.Windows.Forms.Button buttonDeletePattern;
        private BingoGameCore4.Controls.Patterns.CurrentPatternScroller currentPatternScroller1;
        private BingoGameCore4.Controls.Patterns.CurrentPatternScroller currentPatternScroller2;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.RadioButton radioButtonNoOverlap;
		private System.Windows.Forms.RadioButton radioButtonMustOverlap;
		private System.Windows.Forms.RadioButton radioButtonOverlapOk;
		private System.Windows.Forms.DataGridView dataGridView1;
		private System.Windows.Forms.RadioButton radioButtonNoExpand;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.CheckBox checkBoxSingleCard;
		private System.Windows.Forms.CheckBox checkBoxAllowMirror;
		private System.Windows.Forms.CheckBox checkBoxNoOverlap;
		private System.Windows.Forms.TabControl tabControl2;
		private System.Windows.Forms.TabPage tabPage3;
		private System.Windows.Forms.CheckBox checkBoxCrazyHardway;
		private System.Windows.Forms.TextBox textBoxCrazyCount;
		private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button buttonExpand2;
		private System.Windows.Forms.CheckBox checkBoxMultiPatternOrderDependant;
		private System.Windows.Forms.RadioButton radioButtonAnyWhereAnyRotationHardway;
		private System.Windows.Forms.RadioButton radioButtonAnyWhereAnyRotation;
		private System.Windows.Forms.RadioButton radioButtonAnyRotationHardway;
		private System.Windows.Forms.RadioButton radioButtonAnyHardway;
		private System.Windows.Forms.RadioButton radioButtonAnyRotation;
		private System.Windows.Forms.RadioButton radioButtonAnywhere;
		private System.Windows.Forms.TabPage tabPageJavaServer;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox textBoxJavaServerString;
		private System.Windows.Forms.CheckBox checkBox2;
	}
}