namespace OpenSkieScheduler3.Controls.Forms
{
	partial class PackEditor
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.listBox2 = new OpenSkieScheduler3.Controls.Lists.MyListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.textBoxWidth = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxHeight = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.panelPackLayout = new System.Windows.Forms.Panel();
            this.panelPackCardset = new System.Windows.Forms.Panel();
            this.buttonCardsetRangeEdit = new System.Windows.Forms.Button();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.buttonChangeLevel = new System.Windows.Forms.Button();
            this.buttonUnSelectAll = new System.Windows.Forms.Button();
            this.buttonSelectAll = new System.Windows.Forms.Button();
            this.panelPackSelection = new System.Windows.Forms.Panel();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.comboBoxLevelColor = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.comboBoxPackLevel = new System.Windows.Forms.ComboBox();
            this.comboBoxColor = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.checkBoxJumpingJackpot = new System.Windows.Forms.CheckBox();
            this.panelPackCardset.SuspendLayout();
            this.panelPackSelection.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(463, 6);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 1;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(122, 10);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 2;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(161, 38);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(121, 21);
            this.comboBox2.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Select a cardset...";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Select a series...";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(352, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(105, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Face Count(On-Size)";
            // 
            // listBox2
            // 
            this.listBox2.BlockDoubleClick = true;
            this.listBox2.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.listBox2.FormattingEnabled = true;
            this.listBox2.Location = new System.Drawing.Point(14, 119);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(268, 95);
            this.listBox2.TabIndex = 8;
            this.listBox2.TabStops = null;
            this.listBox2.TargetList = null;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 103);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(154, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Cardset Ranges this pack uses";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(12, 67);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(132, 23);
            this.button2.TabIndex = 10;
            this.button2.Text = "Add Cardset Range";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(150, 67);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(132, 23);
            this.button3.TabIndex = 11;
            this.button3.Text = "Remove Cardset Range";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // textBoxWidth
            // 
            this.textBoxWidth.Location = new System.Drawing.Point(227, 6);
            this.textBoxWidth.MaxLength = 2;
            this.textBoxWidth.Name = "textBoxWidth";
            this.textBoxWidth.Size = new System.Drawing.Size(22, 20);
            this.textBoxWidth.TabIndex = 2;
            this.textBoxWidth.TextChanged += new System.EventHandler(this.textBox_TextChanged);
            this.textBoxWidth.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.OnlyNumbers);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(116, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Pack Layout";
            // 
            // textBoxHeight
            // 
            this.textBoxHeight.Location = new System.Drawing.Point(274, 6);
            this.textBoxHeight.MaxLength = 2;
            this.textBoxHeight.Name = "textBoxHeight";
            this.textBoxHeight.Size = new System.Drawing.Size(22, 20);
            this.textBoxHeight.TabIndex = 3;
            this.textBoxHeight.TextChanged += new System.EventHandler(this.textBox_TextChanged);
            this.textBoxHeight.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.OnlyNumbers);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(254, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(14, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "X";
            // 
            // panelPackLayout
            // 
            this.panelPackLayout.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelPackLayout.AutoScroll = true;
            this.panelPackLayout.Location = new System.Drawing.Point(113, 93);
            this.panelPackLayout.Name = "panelPackLayout";
            this.panelPackLayout.Size = new System.Drawing.Size(459, 208);
            this.panelPackLayout.TabIndex = 12;
            // 
            // panelPackCardset
            // 
            this.panelPackCardset.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelPackCardset.Controls.Add(this.buttonCardsetRangeEdit);
            this.panelPackCardset.Controls.Add(this.label1);
            this.panelPackCardset.Controls.Add(this.comboBox1);
            this.panelPackCardset.Controls.Add(this.button3);
            this.panelPackCardset.Controls.Add(this.comboBox2);
            this.panelPackCardset.Controls.Add(this.button2);
            this.panelPackCardset.Controls.Add(this.label2);
            this.panelPackCardset.Controls.Add(this.label4);
            this.panelPackCardset.Controls.Add(this.listBox2);
            this.panelPackCardset.Location = new System.Drawing.Point(113, 373);
            this.panelPackCardset.Name = "panelPackCardset";
            this.panelPackCardset.Size = new System.Drawing.Size(459, 236);
            this.panelPackCardset.TabIndex = 13;
            // 
            // buttonCardsetRangeEdit
            // 
            this.buttonCardsetRangeEdit.Location = new System.Drawing.Point(375, 164);
            this.buttonCardsetRangeEdit.Name = "buttonCardsetRangeEdit";
            this.buttonCardsetRangeEdit.Size = new System.Drawing.Size(75, 50);
            this.buttonCardsetRangeEdit.TabIndex = 61;
            this.buttonCardsetRangeEdit.Text = "Edit Cardset Ranges";
            this.buttonCardsetRangeEdit.UseVisualStyleBackColor = true;
            this.buttonCardsetRangeEdit.Click += new System.EventHandler(this.buttonCardsetRangeEdit_Click);
            // 
            // comboBox3
            // 
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Location = new System.Drawing.Point(191, 30);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(108, 21);
            this.comboBox3.TabIndex = 4;
            // 
            // buttonChangeLevel
            // 
            this.buttonChangeLevel.Location = new System.Drawing.Point(323, 30);
            this.buttonChangeLevel.Name = "buttonChangeLevel";
            this.buttonChangeLevel.Size = new System.Drawing.Size(124, 23);
            this.buttonChangeLevel.TabIndex = 5;
            this.buttonChangeLevel.Text = "Change Level";
            this.buttonChangeLevel.UseVisualStyleBackColor = true;
            this.buttonChangeLevel.Click += new System.EventHandler(this.buttonChangeLevel_Click);
            // 
            // buttonUnSelectAll
            // 
            this.buttonUnSelectAll.Location = new System.Drawing.Point(6, 28);
            this.buttonUnSelectAll.Name = "buttonUnSelectAll";
            this.buttonUnSelectAll.Size = new System.Drawing.Size(108, 23);
            this.buttonUnSelectAll.TabIndex = 14;
            this.buttonUnSelectAll.Text = "Un-Select All";
            this.buttonUnSelectAll.UseVisualStyleBackColor = true;
            this.buttonUnSelectAll.Click += new System.EventHandler(this.buttonUnSelectAll_Click);
            // 
            // buttonSelectAll
            // 
            this.buttonSelectAll.Location = new System.Drawing.Point(6, 5);
            this.buttonSelectAll.Name = "buttonSelectAll";
            this.buttonSelectAll.Size = new System.Drawing.Size(108, 23);
            this.buttonSelectAll.TabIndex = 15;
            this.buttonSelectAll.Text = "Select All";
            this.buttonSelectAll.UseVisualStyleBackColor = true;
            this.buttonSelectAll.Click += new System.EventHandler(this.buttonSelectAll_Click);
            // 
            // panelPackSelection
            // 
            this.panelPackSelection.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelPackSelection.Controls.Add(this.label10);
            this.panelPackSelection.Controls.Add(this.label9);
            this.panelPackSelection.Controls.Add(this.comboBoxLevelColor);
            this.panelPackSelection.Controls.Add(this.buttonSelectAll);
            this.panelPackSelection.Controls.Add(this.comboBox3);
            this.panelPackSelection.Controls.Add(this.buttonUnSelectAll);
            this.panelPackSelection.Controls.Add(this.buttonChangeLevel);
            this.panelPackSelection.Location = new System.Drawing.Point(113, 307);
            this.panelPackSelection.Name = "panelPackSelection";
            this.panelPackSelection.Size = new System.Drawing.Size(459, 60);
            this.panelPackSelection.TabIndex = 18;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(128, 33);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(57, 13);
            this.label10.TabIndex = 63;
            this.label10.Text = "Pick Level";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(128, 10);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(55, 13);
            this.label9.TabIndex = 62;
            this.label9.Text = "Pick Color";
            // 
            // comboBoxLevelColor
            // 
            this.comboBoxLevelColor.FormattingEnabled = true;
            this.comboBoxLevelColor.Location = new System.Drawing.Point(191, 7);
            this.comboBoxLevelColor.Name = "comboBoxLevelColor";
            this.comboBoxLevelColor.Size = new System.Drawing.Size(108, 21);
            this.comboBoxLevelColor.TabIndex = 61;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(110, 65);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(97, 13);
            this.label7.TabIndex = 7;
            this.label7.Text = "Pack Payout Level";
            // 
            // comboBoxPackLevel
            // 
            this.comboBoxPackLevel.FormattingEnabled = true;
            this.comboBoxPackLevel.Location = new System.Drawing.Point(220, 62);
            this.comboBoxPackLevel.Name = "comboBoxPackLevel";
            this.comboBoxPackLevel.Size = new System.Drawing.Size(108, 21);
            this.comboBoxPackLevel.TabIndex = 61;
            this.comboBoxPackLevel.SelectedValueChanged += new System.EventHandler(this.comboBoxPackLevel_SelectedValueChanged);
            // 
            // comboBoxColor
            // 
            this.comboBoxColor.FormattingEnabled = true;
            this.comboBoxColor.Location = new System.Drawing.Point(220, 35);
            this.comboBoxColor.Name = "comboBoxColor";
            this.comboBoxColor.Size = new System.Drawing.Size(108, 21);
            this.comboBoxColor.TabIndex = 63;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(110, 38);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(59, 13);
            this.label8.TabIndex = 62;
            this.label8.Text = "Pack Color";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(355, 32);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 64;
            this.button4.Text = "Edit Colors";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // checkBoxJumpingJackpot
            // 
            this.checkBoxJumpingJackpot.AutoSize = true;
            this.checkBoxJumpingJackpot.Location = new System.Drawing.Point(365, 64);
            this.checkBoxJumpingJackpot.Name = "checkBoxJumpingJackpot";
            this.checkBoxJumpingJackpot.Size = new System.Drawing.Size(106, 17);
            this.checkBoxJumpingJackpot.TabIndex = 65;
            this.checkBoxJumpingJackpot.Text = "Jumping Jackpot";
            this.checkBoxJumpingJackpot.UseVisualStyleBackColor = true;
            // 
            // PackEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(579, 647);
            this.Controls.Add(this.checkBoxJumpingJackpot);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.comboBoxColor);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.comboBoxPackLevel);
            this.Controls.Add(this.panelPackSelection);
            this.Controls.Add(this.panelPackCardset);
            this.Controls.Add(this.panelPackLayout);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBoxHeight);
            this.Controls.Add(this.textBoxWidth);
            this.Controls.Add(this.textBox1);
            this.Name = "PackEditor";
            this.Text = "Pack Editor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PackEditor_FormClosing_1);
            this.Load += new System.EventHandler(this.PackEditor_Load);
            this.panelPackCardset.ResumeLayout(false);
            this.panelPackCardset.PerformLayout();
            this.panelPackSelection.ResumeLayout(false);
            this.panelPackSelection.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ComboBox comboBox2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private OpenSkieScheduler3.Controls.Lists.MyListBox listBox2;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.TextBox textBoxWidth;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox textBoxHeight;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Panel panelPackLayout;
		private System.Windows.Forms.Panel panelPackCardset;
		private System.Windows.Forms.ComboBox comboBox3;
		private System.Windows.Forms.Button buttonChangeLevel;
		private System.Windows.Forms.Button buttonUnSelectAll;
		private System.Windows.Forms.Button buttonSelectAll;
		private System.Windows.Forms.Panel panelPackSelection;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.ComboBox comboBoxPackLevel;
		private System.Windows.Forms.ComboBox comboBoxColor;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Button button4;
		private System.Windows.Forms.CheckBox checkBoxJumpingJackpot;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox comboBoxLevelColor;
        private System.Windows.Forms.Button buttonCardsetRangeEdit;
	}
}