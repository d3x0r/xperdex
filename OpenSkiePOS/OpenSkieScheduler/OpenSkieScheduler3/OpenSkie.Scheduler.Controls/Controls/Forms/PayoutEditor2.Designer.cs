namespace OpenSkieScheduler3.Controls.Forms
{
	partial class PayoutEditor2
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
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this.label2 = new System.Windows.Forms.Label();
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.radioButtonCompound = new System.Windows.Forms.RadioButton();
			this.radioButtonNoIncrement = new System.Windows.Forms.RadioButton();
			this.label5 = new System.Windows.Forms.Label();
			this.radioButtonPrizeIncrement = new System.Windows.Forms.RadioButton();
			this.textBoxPrizeIncrement = new System.Windows.Forms.TextBox();
			this.radioButtonPrizeMultiplier = new System.Windows.Forms.RadioButton();
			this.sessionList1 = new OpenSkieScheduler3.Controls.Lists.SessionList();
			this.sessionPrizeExceptionList1 = new OpenSkieScheduler3.Controls.Lists.SessionPrizeExceptionList();
			this.button3 = new System.Windows.Forms.Button();
			this.button4 = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			this.groupBox3.SuspendLayout();
			this.SuspendLayout();
			// 
			// dataGridView1
			// 
			this.dataGridView1.AllowUserToAddRows = false;
			this.dataGridView1.AllowUserToDeleteRows = false;
			this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.Location = new System.Drawing.Point(12, 195);
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.RowHeadersVisible = false;
			this.dataGridView1.Size = new System.Drawing.Size(585, 148);
			this.dataGridView1.TabIndex = 3;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(9, 17);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(44, 13);
			this.label2.TabIndex = 18;
			this.label2.Text = "Session";
			// 
			// button1
			// 
			this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.button1.Location = new System.Drawing.Point(292, 349);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(121, 23);
			this.button1.TabIndex = 22;
			this.button1.Text = "Save Changes";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// button2
			// 
			this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.button2.Location = new System.Drawing.Point(419, 349);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(121, 23);
			this.button2.TabIndex = 23;
			this.button2.Text = "Revert Changes";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.radioButtonCompound);
			this.groupBox3.Controls.Add(this.radioButtonNoIncrement);
			this.groupBox3.Controls.Add(this.label5);
			this.groupBox3.Controls.Add(this.radioButtonPrizeIncrement);
			this.groupBox3.Controls.Add(this.textBoxPrizeIncrement);
			this.groupBox3.Controls.Add(this.radioButtonPrizeMultiplier);
			this.groupBox3.Location = new System.Drawing.Point(458, 33);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(142, 156);
			this.groupBox3.TabIndex = 24;
			this.groupBox3.TabStop = false;
			this.groupBox3.Visible = false;
			// 
			// radioButtonCompound
			// 
			this.radioButtonCompound.AutoSize = true;
			this.radioButtonCompound.Location = new System.Drawing.Point(13, 82);
			this.radioButtonCompound.Name = "radioButtonCompound";
			this.radioButtonCompound.Size = new System.Drawing.Size(76, 17);
			this.radioButtonCompound.TabIndex = 22;
			this.radioButtonCompound.TabStop = true;
			this.radioButtonCompound.Text = "Compound";
			this.radioButtonCompound.UseVisualStyleBackColor = true;
			// 
			// radioButtonNoIncrement
			// 
			this.radioButtonNoIncrement.AutoSize = true;
			this.radioButtonNoIncrement.Location = new System.Drawing.Point(14, 12);
			this.radioButtonNoIncrement.Name = "radioButtonNoIncrement";
			this.radioButtonNoIncrement.Size = new System.Drawing.Size(90, 17);
			this.radioButtonNoIncrement.TabIndex = 21;
			this.radioButtonNoIncrement.TabStop = true;
			this.radioButtonNoIncrement.Text = "No Defaulting";
			this.radioButtonNoIncrement.UseVisualStyleBackColor = true;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(38, 105);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(29, 13);
			this.label5.TabIndex = 20;
			this.label5.Text = "Step";
			// 
			// radioButtonPrizeIncrement
			// 
			this.radioButtonPrizeIncrement.AutoSize = true;
			this.radioButtonPrizeIncrement.Location = new System.Drawing.Point(14, 35);
			this.radioButtonPrizeIncrement.Name = "radioButtonPrizeIncrement";
			this.radioButtonPrizeIncrement.Size = new System.Drawing.Size(98, 17);
			this.radioButtonPrizeIncrement.TabIndex = 18;
			this.radioButtonPrizeIncrement.TabStop = true;
			this.radioButtonPrizeIncrement.Text = "Prize Increment";
			this.radioButtonPrizeIncrement.UseVisualStyleBackColor = true;
			// 
			// textBoxPrizeIncrement
			// 
			this.textBoxPrizeIncrement.Location = new System.Drawing.Point(53, 121);
			this.textBoxPrizeIncrement.Name = "textBoxPrizeIncrement";
			this.textBoxPrizeIncrement.Size = new System.Drawing.Size(68, 20);
			this.textBoxPrizeIncrement.TabIndex = 17;
			// 
			// radioButtonPrizeMultiplier
			// 
			this.radioButtonPrizeMultiplier.AutoSize = true;
			this.radioButtonPrizeMultiplier.Location = new System.Drawing.Point(13, 58);
			this.radioButtonPrizeMultiplier.Name = "radioButtonPrizeMultiplier";
			this.radioButtonPrizeMultiplier.Size = new System.Drawing.Size(92, 17);
			this.radioButtonPrizeMultiplier.TabIndex = 19;
			this.radioButtonPrizeMultiplier.TabStop = true;
			this.radioButtonPrizeMultiplier.Text = "Prize Multiplier";
			this.radioButtonPrizeMultiplier.UseVisualStyleBackColor = true;
			// 
			// sessionList1
			// 
			this.sessionList1.BlockDoubleClick = true;
			this.sessionList1.DisplayMember = "session_name";
			this.sessionList1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			this.sessionList1.FormattingEnabled = true;
			this.sessionList1.Location = new System.Drawing.Point(12, 33);
			this.sessionList1.Name = "sessionList1";
			this.sessionList1.Size = new System.Drawing.Size(164, 147);
			this.sessionList1.TabIndex = 25;
			this.sessionList1.TabStops = null;
			this.sessionList1.TargetList = null;
			// 
			// sessionPrizeExceptionList1
			// 
			this.sessionPrizeExceptionList1.BlockDoubleClick = true;
			this.sessionPrizeExceptionList1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			this.sessionPrizeExceptionList1.FormattingEnabled = true;
			this.sessionPrizeExceptionList1.Location = new System.Drawing.Point(192, 33);
			this.sessionPrizeExceptionList1.Name = "sessionPrizeExceptionList1";
			this.sessionPrizeExceptionList1.Size = new System.Drawing.Size(169, 147);
			this.sessionPrizeExceptionList1.TabIndex = 26;
			this.sessionPrizeExceptionList1.TabStops = null;
			this.sessionPrizeExceptionList1.TargetList = null;
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(367, 33);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(85, 42);
			this.button3.TabIndex = 27;
			this.button3.Text = "Create Prize Exception";
			this.button3.UseVisualStyleBackColor = true;
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// button4
			// 
			this.button4.Location = new System.Drawing.Point(367, 81);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(85, 42);
			this.button4.TabIndex = 28;
			this.button4.Text = "Remove Prize Exception";
			this.button4.UseVisualStyleBackColor = true;
			this.button4.Click += new System.EventHandler(this.button4_Click);
			// 
			// PayoutEditor2
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(609, 384);
			this.Controls.Add(this.button4);
			this.Controls.Add(this.button3);
			this.Controls.Add(this.sessionPrizeExceptionList1);
			this.Controls.Add(this.sessionList1);
			this.Controls.Add(this.groupBox3);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.dataGridView1);
			this.Name = "PayoutEditor2";
			this.Text = "Regular Prize Editor";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PayoutEditor2_FormClosing);
			this.Load += new System.EventHandler(this.PayoutEditor_Load);
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			this.groupBox3.ResumeLayout(false);
			this.groupBox3.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.DataGridView dataGridView1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.RadioButton radioButtonCompound;
		private System.Windows.Forms.RadioButton radioButtonNoIncrement;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.RadioButton radioButtonPrizeIncrement;
		private System.Windows.Forms.TextBox textBoxPrizeIncrement;
		private System.Windows.Forms.RadioButton radioButtonPrizeMultiplier;
		private Lists.SessionList sessionList1;
		private Lists.SessionPrizeExceptionList sessionPrizeExceptionList1;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.Button button4;
	}
}