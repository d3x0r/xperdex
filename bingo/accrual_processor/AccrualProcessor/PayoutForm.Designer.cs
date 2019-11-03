namespace ECube.AccrualProcessor
{
	partial class PayoutForm
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
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.labelTotalPay = new System.Windows.Forms.Label();
			this.textBoxPrizeAmount = new System.Windows.Forms.TextBox();
			this.textBoxWinners = new System.Windows.Forms.TextBox();
			this.textBoxSplitAmount = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.checkBoxSplitWin = new System.Windows.Forms.CheckBox();
			this.buttonPay = new System.Windows.Forms.Button();
			this.buttonCancel = new System.Windows.Forms.Button();
			this.label3 = new System.Windows.Forms.Label();
			this.textBoxPrizePercent = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.textBoxBasePay = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.labelAccrualName = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(27, 48);
			this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(194, 25);
			this.label1.TabIndex = 0;
			this.label1.Text = "Total Prize Amount";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(101, 183);
			this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(91, 25);
			this.label2.TabIndex = 1;
			this.label2.Text = "Winners";
			// 
			// labelTotalPay
			// 
			this.labelTotalPay.AutoSize = true;
			this.labelTotalPay.Location = new System.Drawing.Point(245, 270);
			this.labelTotalPay.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
			this.labelTotalPay.Name = "labelTotalPay";
			this.labelTotalPay.Size = new System.Drawing.Size(108, 25);
			this.labelTotalPay.TabIndex = 2;
			this.labelTotalPay.Text = "(total pay)";
			// 
			// textBoxPrizeAmount
			// 
			this.textBoxPrizeAmount.Location = new System.Drawing.Point(251, 45);
			this.textBoxPrizeAmount.Margin = new System.Windows.Forms.Padding(6);
			this.textBoxPrizeAmount.Name = "textBoxPrizeAmount";
			this.textBoxPrizeAmount.ReadOnly = true;
			this.textBoxPrizeAmount.Size = new System.Drawing.Size(196, 31);
			this.textBoxPrizeAmount.TabIndex = 3;
			this.textBoxPrizeAmount.TextChanged += new System.EventHandler(this.textBoxPrizeAmount_TextChanged);
			// 
			// textBoxWinners
			// 
			this.textBoxWinners.Location = new System.Drawing.Point(251, 177);
			this.textBoxWinners.Margin = new System.Windows.Forms.Padding(6);
			this.textBoxWinners.Name = "textBoxWinners";
			this.textBoxWinners.Size = new System.Drawing.Size(196, 31);
			this.textBoxWinners.TabIndex = 4;
			this.textBoxWinners.TextChanged += new System.EventHandler(this.textBoxWinners_TextChanged);
			// 
			// textBoxSplitAmount
			// 
			this.textBoxSplitAmount.Location = new System.Drawing.Point(251, 220);
			this.textBoxSplitAmount.Margin = new System.Windows.Forms.Padding(6);
			this.textBoxSplitAmount.Name = "textBoxSplitAmount";
			this.textBoxSplitAmount.Size = new System.Drawing.Size(196, 31);
			this.textBoxSplitAmount.TabIndex = 6;
			this.textBoxSplitAmount.TextChanged += new System.EventHandler(this.textBoxSplitAmount_TextChanged);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(95, 226);
			this.label4.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(133, 25);
			this.label4.TabIndex = 5;
			this.label4.Text = "Split Amount";
			// 
			// checkBoxSplitWin
			// 
			this.checkBoxSplitWin.AutoSize = true;
			this.checkBoxSplitWin.Location = new System.Drawing.Point(463, 224);
			this.checkBoxSplitWin.Margin = new System.Windows.Forms.Padding(6);
			this.checkBoxSplitWin.Name = "checkBoxSplitWin";
			this.checkBoxSplitWin.Size = new System.Drawing.Size(127, 29);
			this.checkBoxSplitWin.TabIndex = 7;
			this.checkBoxSplitWin.Text = "Fixed Pay";
			this.checkBoxSplitWin.UseVisualStyleBackColor = true;
			this.checkBoxSplitWin.CheckedChanged += new System.EventHandler(this.checkBoxSplitWin_CheckedChanged);
			// 
			// buttonPay
			// 
			this.buttonPay.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.buttonPay.Location = new System.Drawing.Point(266, 316);
			this.buttonPay.Margin = new System.Windows.Forms.Padding(6);
			this.buttonPay.Name = "buttonPay";
			this.buttonPay.Size = new System.Drawing.Size(150, 44);
			this.buttonPay.TabIndex = 8;
			this.buttonPay.Text = "Pay!";
			this.buttonPay.UseVisualStyleBackColor = true;
			this.buttonPay.Click += new System.EventHandler(this.buttonPay_Click);
			// 
			// buttonCancel
			// 
			this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.buttonCancel.Location = new System.Drawing.Point(428, 316);
			this.buttonCancel.Margin = new System.Windows.Forms.Padding(6);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(150, 44);
			this.buttonCancel.TabIndex = 9;
			this.buttonCancel.Text = "Cancel";
			this.buttonCancel.UseVisualStyleBackColor = true;
			this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(77, 270);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(133, 25);
			this.label3.TabIndex = 10;
			this.label3.Text = "Total Payout";
			// 
			// textBoxPrizePercent
			// 
			this.textBoxPrizePercent.Location = new System.Drawing.Point(251, 82);
			this.textBoxPrizePercent.Margin = new System.Windows.Forms.Padding(6);
			this.textBoxPrizePercent.Name = "textBoxPrizePercent";
			this.textBoxPrizePercent.ReadOnly = true;
			this.textBoxPrizePercent.Size = new System.Drawing.Size(196, 31);
			this.textBoxPrizePercent.TabIndex = 12;
			this.textBoxPrizePercent.TextChanged += new System.EventHandler(this.textBoxPrizePercent_TextChanged);
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(27, 85);
			this.label5.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(195, 25);
			this.label5.TabIndex = 11;
			this.label5.Text = "Payout Percentage";
			// 
			// textBoxBasePay
			// 
			this.textBoxBasePay.Location = new System.Drawing.Point(251, 119);
			this.textBoxBasePay.Margin = new System.Windows.Forms.Padding(6);
			this.textBoxBasePay.Name = "textBoxBasePay";
			this.textBoxBasePay.ReadOnly = true;
			this.textBoxBasePay.Size = new System.Drawing.Size(196, 31);
			this.textBoxBasePay.TabIndex = 14;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(27, 122);
			this.label6.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(134, 25);
			this.label6.TabIndex = 13;
			this.label6.Text = "Base Payout";
			// 
			// labelAccrualName
			// 
			this.labelAccrualName.AutoSize = true;
			this.labelAccrualName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.labelAccrualName.Location = new System.Drawing.Point(224, 12);
			this.labelAccrualName.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
			this.labelAccrualName.Name = "labelAccrualName";
			this.labelAccrualName.Size = new System.Drawing.Size(344, 27);
			this.labelAccrualName.TabIndex = 15;
			this.labelAccrualName.Text = "Total Prize Amount and then some";
			this.labelAccrualName.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// PayoutForm
			// 
			this.AcceptButton = this.buttonPay;
			this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.buttonCancel;
			this.ClientSize = new System.Drawing.Size(593, 375);
			this.Controls.Add(this.labelAccrualName);
			this.Controls.Add(this.textBoxBasePay);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.textBoxPrizePercent);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.buttonCancel);
			this.Controls.Add(this.buttonPay);
			this.Controls.Add(this.checkBoxSplitWin);
			this.Controls.Add(this.textBoxSplitAmount);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.textBoxWinners);
			this.Controls.Add(this.textBoxPrizeAmount);
			this.Controls.Add(this.labelTotalPay);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Margin = new System.Windows.Forms.Padding(6);
			this.Name = "PayoutForm";
			this.Text = "Do Payout";
			this.Load += new System.EventHandler(this.PayoutForm_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label labelTotalPay;
		private System.Windows.Forms.TextBox textBoxPrizeAmount;
		private System.Windows.Forms.TextBox textBoxWinners;
		private System.Windows.Forms.TextBox textBoxSplitAmount;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.CheckBox checkBoxSplitWin;
		private System.Windows.Forms.Button buttonPay;
		private System.Windows.Forms.Button buttonCancel;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox textBoxPrizePercent;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox textBoxBasePay;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label labelAccrualName;
	}
}