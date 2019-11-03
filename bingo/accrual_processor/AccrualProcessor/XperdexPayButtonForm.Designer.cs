namespace ECube.AccrualProcessor
{
	partial class XperdexPayButtonForm
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
			this.button2 = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.textBoxButtonText = new System.Windows.Forms.TextBox();
			this.textBoxPayPercent = new System.Windows.Forms.TextBox();
			this.listBoxAccrualGroup = new System.Windows.Forms.ListBox();
			this.textBoxPayAmount = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.checkBoxPayKitty = new System.Windows.Forms.CheckBox();
			this.SuspendLayout();
			// 
			// buttonOk
			// 
			this.buttonOk.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.buttonOk.Location = new System.Drawing.Point(354, 198);
			this.buttonOk.Name = "buttonOk";
			this.buttonOk.Size = new System.Drawing.Size(75, 23);
			this.buttonOk.TabIndex = 0;
			this.buttonOk.Text = "OK";
			this.buttonOk.UseVisualStyleBackColor = true;
			this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
			// 
			// button2
			// 
			this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.button2.Location = new System.Drawing.Point(354, 227);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(75, 23);
			this.button2.TabIndex = 1;
			this.button2.Text = "Cancel";
			this.button2.UseVisualStyleBackColor = true;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(37, 24);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(62, 13);
			this.label1.TabIndex = 2;
			this.label1.Text = "Button Text";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(37, 56);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(83, 13);
			this.label2.TabIndex = 3;
			this.label2.Text = "Pay Percentage";
			// 
			// textBoxButtonText
			// 
			this.textBoxButtonText.Location = new System.Drawing.Point(127, 21);
			this.textBoxButtonText.Name = "textBoxButtonText";
			this.textBoxButtonText.Size = new System.Drawing.Size(100, 20);
			this.textBoxButtonText.TabIndex = 4;
			// 
			// textBoxPayPercent
			// 
			this.textBoxPayPercent.Location = new System.Drawing.Point(126, 53);
			this.textBoxPayPercent.Name = "textBoxPayPercent";
			this.textBoxPayPercent.Size = new System.Drawing.Size(100, 20);
			this.textBoxPayPercent.TabIndex = 5;
			// 
			// listBoxAccrualGroup
			// 
			this.listBoxAccrualGroup.FormattingEnabled = true;
			this.listBoxAccrualGroup.Location = new System.Drawing.Point(270, 12);
			this.listBoxAccrualGroup.Name = "listBoxAccrualGroup";
			this.listBoxAccrualGroup.Size = new System.Drawing.Size(159, 147);
			this.listBoxAccrualGroup.TabIndex = 6;
			this.listBoxAccrualGroup.SelectedIndexChanged += new System.EventHandler(this.listBoxAccrualGroup_SelectedIndexChanged);
			// 
			// textBoxPayAmount
			// 
			this.textBoxPayAmount.Location = new System.Drawing.Point(126, 100);
			this.textBoxPayAmount.Name = "textBoxPayAmount";
			this.textBoxPayAmount.Size = new System.Drawing.Size(100, 20);
			this.textBoxPayAmount.TabIndex = 8;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(37, 103);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(64, 13);
			this.label3.TabIndex = 7;
			this.label3.Text = "Pay Amount";
			// 
			// checkBoxPayKitty
			// 
			this.checkBoxPayKitty.AutoSize = true;
			this.checkBoxPayKitty.Location = new System.Drawing.Point(40, 162);
			this.checkBoxPayKitty.Name = "checkBoxPayKitty";
			this.checkBoxPayKitty.Size = new System.Drawing.Size(90, 17);
			this.checkBoxPayKitty.TabIndex = 9;
			this.checkBoxPayKitty.Text = "Pay from Kitty";
			this.checkBoxPayKitty.UseVisualStyleBackColor = true;
			// 
			// XperdexPayButtonForm
			// 
			this.AcceptButton = this.buttonOk;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.button2;
			this.ClientSize = new System.Drawing.Size(450, 262);
			this.Controls.Add(this.checkBoxPayKitty);
			this.Controls.Add(this.textBoxPayAmount);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.listBoxAccrualGroup);
			this.Controls.Add(this.textBoxPayPercent);
			this.Controls.Add(this.textBoxButtonText);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.buttonOk);
			this.Name = "XperdexPayButtonForm";
			this.Text = "XperdexPayButtonForm";
			this.Load += new System.EventHandler(this.XperdexPayButtonForm_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button buttonOk;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox textBoxButtonText;
		private System.Windows.Forms.TextBox textBoxPayPercent;
		private System.Windows.Forms.ListBox listBoxAccrualGroup;
		private System.Windows.Forms.TextBox textBoxPayAmount;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.CheckBox checkBoxPayKitty;
	}
}