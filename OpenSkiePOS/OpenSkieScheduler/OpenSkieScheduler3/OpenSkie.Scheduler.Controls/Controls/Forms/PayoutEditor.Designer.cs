namespace OpenSkieScheduler.Controls.Forms
{
	partial class PayoutEditor
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
			this.listBox2 = new System.Windows.Forms.ListBox();
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this.listBox3 = new System.Windows.Forms.ListBox();
			this.radioButton1 = new System.Windows.Forms.RadioButton();
			this.radioButton2 = new System.Windows.Forms.RadioButton();
			this.radioButton3 = new System.Windows.Forms.RadioButton();
			this.radioButton4 = new System.Windows.Forms.RadioButton();
			this.radioButton5 = new System.Windows.Forms.RadioButton();
			this.radioButton6 = new System.Windows.Forms.RadioButton();
			this.radioButton7 = new System.Windows.Forms.RadioButton();
			this.radioButton8 = new System.Windows.Forms.RadioButton();
			this.radioButton9 = new System.Windows.Forms.RadioButton();
			this.radioButton10 = new System.Windows.Forms.RadioButton();
			this.radioButton11 = new System.Windows.Forms.RadioButton();
			this.checkBox1 = new System.Windows.Forms.CheckBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.radioButtonNoIncrement = new System.Windows.Forms.RadioButton();
			this.label5 = new System.Windows.Forms.Label();
			this.radioButtonPrizeIncrement = new System.Windows.Forms.RadioButton();
			this.textBoxPrizeIncrement = new System.Windows.Forms.TextBox();
			this.radioButtonPrizeMultiplier = new System.Windows.Forms.RadioButton();
			this.label4 = new System.Windows.Forms.Label();
			this.checkBoxAdvancedOptions = new System.Windows.Forms.CheckBox();
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.radioButtonCompound = new System.Windows.Forms.RadioButton();
			( (System.ComponentModel.ISupportInitialize)( this.dataGridView1 ) ).BeginInit();
			this.groupBox1.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.SuspendLayout();
			// 
			// listBox1
			// 
			this.listBox1.FormattingEnabled = true;
			this.listBox1.Location = new System.Drawing.Point( 188, 50 );
			this.listBox1.Name = "listBox1";
			this.listBox1.Size = new System.Drawing.Size( 159, 121 );
			this.listBox1.TabIndex = 1;
			this.listBox1.SelectedIndexChanged += new System.EventHandler( this.listBox1_SelectedIndexChanged );
			// 
			// listBox2
			// 
			this.listBox2.FormattingEnabled = true;
			this.listBox2.Location = new System.Drawing.Point( 352, 50 );
			this.listBox2.Name = "listBox2";
			this.listBox2.Size = new System.Drawing.Size( 180, 147 );
			this.listBox2.TabIndex = 2;
			this.listBox2.SelectedIndexChanged += new System.EventHandler( this.listBox2_SelectedIndexChanged );
			// 
			// dataGridView1
			// 
			this.dataGridView1.AllowUserToAddRows = false;
			this.dataGridView1.AllowUserToDeleteRows = false;
			this.dataGridView1.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom )
						| System.Windows.Forms.AnchorStyles.Left )
						| System.Windows.Forms.AnchorStyles.Right ) ) );
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.Location = new System.Drawing.Point( 22, 212 );
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.RowHeadersVisible = false;
			this.dataGridView1.Size = new System.Drawing.Size( 510, 310 );
			this.dataGridView1.TabIndex = 3;
			// 
			// listBox3
			// 
			this.listBox3.FormattingEnabled = true;
			this.listBox3.Location = new System.Drawing.Point( 22, 50 );
			this.listBox3.Name = "listBox3";
			this.listBox3.Size = new System.Drawing.Size( 159, 147 );
			this.listBox3.TabIndex = 4;
			this.listBox3.SelectedIndexChanged += new System.EventHandler( this.listBox3_SelectedIndexChanged );
			// 
			// radioButton1
			// 
			this.radioButton1.AutoSize = true;
			this.radioButton1.Location = new System.Drawing.Point( 24, 23 );
			this.radioButton1.Name = "radioButton1";
			this.radioButton1.Size = new System.Drawing.Size( 59, 17 );
			this.radioButton1.TabIndex = 5;
			this.radioButton1.TabStop = true;
			this.radioButton1.Text = "Default";
			this.radioButton1.UseVisualStyleBackColor = true;
			// 
			// radioButton2
			// 
			this.radioButton2.AutoSize = true;
			this.radioButton2.Location = new System.Drawing.Point( 24, 46 );
			this.radioButton2.Name = "radioButton2";
			this.radioButton2.Size = new System.Drawing.Size( 63, 17 );
			this.radioButton2.TabIndex = 6;
			this.radioButton2.TabStop = true;
			this.radioButton2.Text = "Monday";
			this.radioButton2.UseVisualStyleBackColor = true;
			this.radioButton2.CheckedChanged += new System.EventHandler( this.radioButton2_CheckedChanged );
			// 
			// radioButton3
			// 
			this.radioButton3.AutoSize = true;
			this.radioButton3.Location = new System.Drawing.Point( 24, 69 );
			this.radioButton3.Name = "radioButton3";
			this.radioButton3.Size = new System.Drawing.Size( 66, 17 );
			this.radioButton3.TabIndex = 7;
			this.radioButton3.TabStop = true;
			this.radioButton3.Text = "Tuesday";
			this.radioButton3.UseVisualStyleBackColor = true;
			this.radioButton3.CheckedChanged += new System.EventHandler( this.radioButton2_CheckedChanged );
			// 
			// radioButton4
			// 
			this.radioButton4.AutoSize = true;
			this.radioButton4.Location = new System.Drawing.Point( 24, 92 );
			this.radioButton4.Name = "radioButton4";
			this.radioButton4.Size = new System.Drawing.Size( 82, 17 );
			this.radioButton4.TabIndex = 8;
			this.radioButton4.TabStop = true;
			this.radioButton4.Text = "Wednesday";
			this.radioButton4.UseVisualStyleBackColor = true;
			this.radioButton4.CheckedChanged += new System.EventHandler( this.radioButton2_CheckedChanged );
			// 
			// radioButton5
			// 
			this.radioButton5.AutoSize = true;
			this.radioButton5.Location = new System.Drawing.Point( 24, 115 );
			this.radioButton5.Name = "radioButton5";
			this.radioButton5.Size = new System.Drawing.Size( 69, 17 );
			this.radioButton5.TabIndex = 9;
			this.radioButton5.TabStop = true;
			this.radioButton5.Text = "Thursday";
			this.radioButton5.UseVisualStyleBackColor = true;
			this.radioButton5.CheckedChanged += new System.EventHandler( this.radioButton2_CheckedChanged );
			// 
			// radioButton6
			// 
			this.radioButton6.AutoSize = true;
			this.radioButton6.Location = new System.Drawing.Point( 24, 138 );
			this.radioButton6.Name = "radioButton6";
			this.radioButton6.Size = new System.Drawing.Size( 53, 17 );
			this.radioButton6.TabIndex = 10;
			this.radioButton6.TabStop = true;
			this.radioButton6.Text = "Friday";
			this.radioButton6.UseVisualStyleBackColor = true;
			this.radioButton6.CheckedChanged += new System.EventHandler( this.radioButton2_CheckedChanged );
			// 
			// radioButton7
			// 
			this.radioButton7.AutoSize = true;
			this.radioButton7.Location = new System.Drawing.Point( 24, 161 );
			this.radioButton7.Name = "radioButton7";
			this.radioButton7.Size = new System.Drawing.Size( 67, 17 );
			this.radioButton7.TabIndex = 11;
			this.radioButton7.TabStop = true;
			this.radioButton7.Text = "Saturday";
			this.radioButton7.UseVisualStyleBackColor = true;
			this.radioButton7.CheckedChanged += new System.EventHandler( this.radioButton2_CheckedChanged );
			// 
			// radioButton8
			// 
			this.radioButton8.AutoSize = true;
			this.radioButton8.Location = new System.Drawing.Point( 24, 184 );
			this.radioButton8.Name = "radioButton8";
			this.radioButton8.Size = new System.Drawing.Size( 61, 17 );
			this.radioButton8.TabIndex = 12;
			this.radioButton8.TabStop = true;
			this.radioButton8.Text = "Sunday";
			this.radioButton8.UseVisualStyleBackColor = true;
			this.radioButton8.CheckedChanged += new System.EventHandler( this.radioButton2_CheckedChanged );
			// 
			// radioButton9
			// 
			this.radioButton9.AutoSize = true;
			this.radioButton9.Location = new System.Drawing.Point( 165, 23 );
			this.radioButton9.Name = "radioButton9";
			this.radioButton9.Size = new System.Drawing.Size( 77, 17 );
			this.radioButton9.TabIndex = 13;
			this.radioButton9.TabStop = true;
			this.radioButton9.Text = "Weekends";
			this.radioButton9.UseVisualStyleBackColor = true;
			this.radioButton9.CheckedChanged += new System.EventHandler( this.radioButton2_CheckedChanged );
			// 
			// radioButton10
			// 
			this.radioButton10.AutoSize = true;
			this.radioButton10.Location = new System.Drawing.Point( 165, 46 );
			this.radioButton10.Name = "radioButton10";
			this.radioButton10.Size = new System.Drawing.Size( 76, 17 );
			this.radioButton10.TabIndex = 14;
			this.radioButton10.TabStop = true;
			this.radioButton10.Text = "Weekdays";
			this.radioButton10.UseVisualStyleBackColor = true;
			this.radioButton10.CheckedChanged += new System.EventHandler( this.radioButton2_CheckedChanged );
			// 
			// radioButton11
			// 
			this.radioButton11.AutoSize = true;
			this.radioButton11.Location = new System.Drawing.Point( 165, 83 );
			this.radioButton11.Name = "radioButton11";
			this.radioButton11.Size = new System.Drawing.Size( 85, 17 );
			this.radioButton11.TabIndex = 15;
			this.radioButton11.TabStop = true;
			this.radioButton11.Text = "Specific Day";
			this.radioButton11.UseVisualStyleBackColor = true;
			this.radioButton11.CheckedChanged += new System.EventHandler( this.radioButton11_CheckedChanged );
			// 
			// checkBox1
			// 
			this.checkBox1.AutoSize = true;
			this.checkBox1.Location = new System.Drawing.Point( 188, 180 );
			this.checkBox1.Name = "checkBox1";
			this.checkBox1.Size = new System.Drawing.Size( 104, 17 );
			this.checkBox1.TabIndex = 16;
			this.checkBox1.Text = "Specific Session";
			this.checkBox1.UseVisualStyleBackColor = true;
			this.checkBox1.CheckedChanged += new System.EventHandler( this.checkBox1_CheckedChanged );
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point( 19, 31 );
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size( 76, 13 );
			this.label1.TabIndex = 17;
			this.label1.Text = "Session Group";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point( 185, 31 );
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size( 44, 13 );
			this.label2.TabIndex = 18;
			this.label2.Text = "Session";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point( 349, 31 );
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size( 67, 13 );
			this.label3.TabIndex = 19;
			this.label3.Text = "Game Group";
			// 
			// groupBox1
			// 
			this.groupBox1.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right ) ) );
			this.groupBox1.Controls.Add( this.groupBox3 );
			this.groupBox1.Controls.Add( this.label4 );
			this.groupBox1.Controls.Add( this.radioButton2 );
			this.groupBox1.Controls.Add( this.radioButton1 );
			this.groupBox1.Controls.Add( this.radioButton3 );
			this.groupBox1.Controls.Add( this.radioButton4 );
			this.groupBox1.Controls.Add( this.radioButton11 );
			this.groupBox1.Controls.Add( this.radioButton5 );
			this.groupBox1.Controls.Add( this.radioButton10 );
			this.groupBox1.Controls.Add( this.radioButton6 );
			this.groupBox1.Controls.Add( this.radioButton9 );
			this.groupBox1.Controls.Add( this.radioButton7 );
			this.groupBox1.Controls.Add( this.radioButton8 );
			this.groupBox1.Location = new System.Drawing.Point( 547, 31 );
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size( 318, 493 );
			this.groupBox1.TabIndex = 20;
			this.groupBox1.TabStop = false;
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add( this.radioButtonCompound );
			this.groupBox3.Controls.Add( this.radioButtonNoIncrement );
			this.groupBox3.Controls.Add( this.label5 );
			this.groupBox3.Controls.Add( this.radioButtonPrizeIncrement );
			this.groupBox3.Controls.Add( this.textBoxPrizeIncrement );
			this.groupBox3.Controls.Add( this.radioButtonPrizeMultiplier );
			this.groupBox3.Location = new System.Drawing.Point( 24, 225 );
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size( 218, 84 );
			this.groupBox3.TabIndex = 1;
			this.groupBox3.TabStop = false;
			// 
			// radioButtonNoIncrement
			// 
			this.radioButtonNoIncrement.AutoSize = true;
			this.radioButtonNoIncrement.Location = new System.Drawing.Point( 14, 12 );
			this.radioButtonNoIncrement.Name = "radioButtonNoIncrement";
			this.radioButtonNoIncrement.Size = new System.Drawing.Size( 90, 17 );
			this.radioButtonNoIncrement.TabIndex = 21;
			this.radioButtonNoIncrement.TabStop = true;
			this.radioButtonNoIncrement.Text = "No Defaulting";
			this.radioButtonNoIncrement.UseVisualStyleBackColor = true;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point( 11, 39 );
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size( 29, 13 );
			this.label5.TabIndex = 20;
			this.label5.Text = "Step";
			// 
			// radioButtonPrizeIncrement
			// 
			this.radioButtonPrizeIncrement.AutoSize = true;
			this.radioButtonPrizeIncrement.Location = new System.Drawing.Point( 119, 12 );
			this.radioButtonPrizeIncrement.Name = "radioButtonPrizeIncrement";
			this.radioButtonPrizeIncrement.Size = new System.Drawing.Size( 98, 17 );
			this.radioButtonPrizeIncrement.TabIndex = 18;
			this.radioButtonPrizeIncrement.TabStop = true;
			this.radioButtonPrizeIncrement.Text = "Prize Increment";
			this.radioButtonPrizeIncrement.UseVisualStyleBackColor = true;
			// 
			// textBoxPrizeIncrement
			// 
			this.textBoxPrizeIncrement.Location = new System.Drawing.Point( 26, 55 );
			this.textBoxPrizeIncrement.Name = "textBoxPrizeIncrement";
			this.textBoxPrizeIncrement.Size = new System.Drawing.Size( 68, 20 );
			this.textBoxPrizeIncrement.TabIndex = 17;
			// 
			// radioButtonPrizeMultiplier
			// 
			this.radioButtonPrizeMultiplier.AutoSize = true;
			this.radioButtonPrizeMultiplier.Location = new System.Drawing.Point( 118, 35 );
			this.radioButtonPrizeMultiplier.Name = "radioButtonPrizeMultiplier";
			this.radioButtonPrizeMultiplier.Size = new System.Drawing.Size( 92, 17 );
			this.radioButtonPrizeMultiplier.TabIndex = 19;
			this.radioButtonPrizeMultiplier.TabStop = true;
			this.radioButtonPrizeMultiplier.Text = "Prize Multiplier";
			this.radioButtonPrizeMultiplier.UseVisualStyleBackColor = true;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point( 201, 107 );
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size( 97, 13 );
			this.label4.TabIndex = 16;
			this.label4.Text = "The Selected Date";
			// 
			// checkBoxAdvancedOptions
			// 
			this.checkBoxAdvancedOptions.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left ) ) );
			this.checkBoxAdvancedOptions.AutoSize = true;
			this.checkBoxAdvancedOptions.Location = new System.Drawing.Point( 22, 531 );
			this.checkBoxAdvancedOptions.Name = "checkBoxAdvancedOptions";
			this.checkBoxAdvancedOptions.Size = new System.Drawing.Size( 114, 17 );
			this.checkBoxAdvancedOptions.TabIndex = 21;
			this.checkBoxAdvancedOptions.Text = "Advanced Options";
			this.checkBoxAdvancedOptions.UseVisualStyleBackColor = true;
			this.checkBoxAdvancedOptions.CheckedChanged += new System.EventHandler( this.checkBox2_CheckedChanged );
			// 
			// button1
			// 
			this.button1.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left ) ) );
			this.button1.Location = new System.Drawing.Point( 187, 528 );
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size( 121, 23 );
			this.button1.TabIndex = 22;
			this.button1.Text = "Save Changes";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler( this.button1_Click );
			// 
			// button2
			// 
			this.button2.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left ) ) );
			this.button2.Location = new System.Drawing.Point( 314, 528 );
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size( 121, 23 );
			this.button2.TabIndex = 23;
			this.button2.Text = "Revert Changes";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler( this.button2_Click );
			// 
			// radioButtonCompound
			// 
			this.radioButtonCompound.AutoSize = true;
			this.radioButtonCompound.Location = new System.Drawing.Point( 118, 59 );
			this.radioButtonCompound.Name = "radioButtonCompound";
			this.radioButtonCompound.Size = new System.Drawing.Size( 76, 17 );
			this.radioButtonCompound.TabIndex = 22;
			this.radioButtonCompound.TabStop = true;
			this.radioButtonCompound.Text = "Compound";
			this.radioButtonCompound.UseVisualStyleBackColor = true;
			// 
			// PayoutEditor
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size( 877, 560 );
			this.Controls.Add( this.button2 );
			this.Controls.Add( this.button1 );
			this.Controls.Add( this.checkBoxAdvancedOptions );
			this.Controls.Add( this.groupBox1 );
			this.Controls.Add( this.label3 );
			this.Controls.Add( this.label2 );
			this.Controls.Add( this.label1 );
			this.Controls.Add( this.checkBox1 );
			this.Controls.Add( this.listBox3 );
			this.Controls.Add( this.dataGridView1 );
			this.Controls.Add( this.listBox2 );
			this.Controls.Add( this.listBox1 );
			this.Name = "PayoutEditor";
			this.Text = "Regular Prize Editor";
			this.Load += new System.EventHandler( this.PayoutEditor_Load );
			( (System.ComponentModel.ISupportInitialize)( this.dataGridView1 ) ).EndInit();
			this.groupBox1.ResumeLayout( false );
			this.groupBox1.PerformLayout();
			this.groupBox3.ResumeLayout( false );
			this.groupBox3.PerformLayout();
			this.ResumeLayout( false );
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ListBox listBox1;
		private System.Windows.Forms.ListBox listBox2;
		private System.Windows.Forms.DataGridView dataGridView1;
		private System.Windows.Forms.ListBox listBox3;
		private System.Windows.Forms.RadioButton radioButton1;
		private System.Windows.Forms.RadioButton radioButton2;
		private System.Windows.Forms.RadioButton radioButton3;
		private System.Windows.Forms.RadioButton radioButton4;
		private System.Windows.Forms.RadioButton radioButton5;
		private System.Windows.Forms.RadioButton radioButton6;
		private System.Windows.Forms.RadioButton radioButton7;
		private System.Windows.Forms.RadioButton radioButton8;
		private System.Windows.Forms.RadioButton radioButton9;
		private System.Windows.Forms.RadioButton radioButton10;
		private System.Windows.Forms.RadioButton radioButton11;
		private System.Windows.Forms.CheckBox checkBox1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.RadioButton radioButtonPrizeIncrement;
		private System.Windows.Forms.TextBox textBoxPrizeIncrement;
		private System.Windows.Forms.RadioButton radioButtonPrizeMultiplier;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.CheckBox checkBoxAdvancedOptions;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.RadioButton radioButtonNoIncrement;
		private System.Windows.Forms.RadioButton radioButtonCompound;
	}
}