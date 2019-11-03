namespace BingoGameCore4.Forms
{
	partial class RatedPackConfigurator
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
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.labelCardCount = new System.Windows.Forms.Label();
			this.button1 = new System.Windows.Forms.Button();
			this.comboBoxSession = new System.Windows.Forms.ComboBox();
			this.label4 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// listBox1
			// 
			this.listBox1.FormattingEnabled = true;
			this.listBox1.Location = new System.Drawing.Point(13, 94);
			this.listBox1.Name = "listBox1";
			this.listBox1.Size = new System.Drawing.Size(169, 160);
			this.listBox1.TabIndex = 0;
			this.listBox1.DoubleClick += new System.EventHandler(this.listBox1_DoubleClick);
			// 
			// listBox2
			// 
			this.listBox2.FormattingEnabled = true;
			this.listBox2.Location = new System.Drawing.Point(200, 42);
			this.listBox2.Name = "listBox2";
			this.listBox2.Size = new System.Drawing.Size(178, 212);
			this.listBox2.TabIndex = 1;
			this.listBox2.DoubleClick += new System.EventHandler(this.listBox2_DoubleClick);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 78);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(83, 13);
			this.label1.TabIndex = 2;
			this.label1.Text = "Available Packs";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(200, 22);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(82, 13);
			this.label2.TabIndex = 3;
			this.label2.Text = "Selected Packs";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(385, 66);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(60, 13);
			this.label3.TabIndex = 4;
			this.label3.Text = "Card Count";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// labelCardCount
			// 
			this.labelCardCount.Location = new System.Drawing.Point(385, 79);
			this.labelCardCount.Name = "labelCardCount";
			this.labelCardCount.Size = new System.Drawing.Size(60, 13);
			this.labelCardCount.TabIndex = 5;
			this.labelCardCount.Text = "0";
			this.labelCardCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.labelCardCount.Click += new System.EventHandler(this.labelCardCount_Click);
			// 
			// button1
			// 
			this.button1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.button1.Location = new System.Drawing.Point(433, 231);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 23);
			this.button1.TabIndex = 6;
			this.button1.Text = "Done";
			this.button1.UseVisualStyleBackColor = true;
			// 
			// comboBoxSession
			// 
			this.comboBoxSession.FormattingEnabled = true;
			this.comboBoxSession.Location = new System.Drawing.Point(15, 42);
			this.comboBoxSession.Name = "comboBoxSession";
			this.comboBoxSession.Size = new System.Drawing.Size(167, 21);
			this.comboBoxSession.TabIndex = 7;
			this.comboBoxSession.SelectedIndexChanged += new System.EventHandler(this.comboBoxSession_SelectedIndexChanged);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(15, 23);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(86, 13);
			this.label4.TabIndex = 8;
			this.label4.Text = "Select Session...";
			// 
			// RatedPackConfigurator
			// 
			this.AcceptButton = this.button1;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.button1;
			this.ClientSize = new System.Drawing.Size(523, 300);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.comboBoxSession);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.labelCardCount);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.listBox2);
			this.Controls.Add(this.listBox1);
			this.Name = "RatedPackConfigurator";
			this.Text = "Pack Configuration";
			this.Load += new System.EventHandler(this.PackConfigurator_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ListBox listBox1;
		private System.Windows.Forms.ListBox listBox2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label labelCardCount;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.ComboBox comboBoxSession;
		private System.Windows.Forms.Label label4;
	}
}