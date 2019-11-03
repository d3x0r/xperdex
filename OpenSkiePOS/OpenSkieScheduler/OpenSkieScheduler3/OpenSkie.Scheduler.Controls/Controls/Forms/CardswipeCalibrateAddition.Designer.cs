namespace OpenSkie.Scheduler.Controls.Controls.Forms
{
	partial class CardswipeCalibrateAddition
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.ButtonOk = new System.Windows.Forms.Button();
			this.Cancel = new System.Windows.Forms.Button();
			this.textBoxValue = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// ButtonOk
			// 
			this.ButtonOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.ButtonOk.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.ButtonOk.Location = new System.Drawing.Point(203, 26);
			this.ButtonOk.Name = "ButtonOk";
			this.ButtonOk.Size = new System.Drawing.Size(75, 23);
			this.ButtonOk.TabIndex = 0;
			this.ButtonOk.Text = "Ok";
			this.ButtonOk.UseVisualStyleBackColor = true;
			this.ButtonOk.Click += new System.EventHandler(this.ButtonOk_Click);
			// 
			// Cancel
			// 
			this.Cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.Cancel.Location = new System.Drawing.Point(0, 26);
			this.Cancel.Name = "Cancel";
			this.Cancel.Size = new System.Drawing.Size(75, 23);
			this.Cancel.TabIndex = 1;
			this.Cancel.Text = "Cancel";
			this.Cancel.UseVisualStyleBackColor = true;
			// 
			// textBoxValue
			// 
			this.textBoxValue.Dock = System.Windows.Forms.DockStyle.Top;
			this.textBoxValue.Location = new System.Drawing.Point(0, 0);
			this.textBoxValue.Name = "textBoxValue";
			this.textBoxValue.Size = new System.Drawing.Size(290, 20);
			this.textBoxValue.TabIndex = 2;
			// 
			// CardswipeCalibrateAddition
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(290, 60);
			this.Controls.Add(this.textBoxValue);
			this.Controls.Add(this.Cancel);
			this.Controls.Add(this.ButtonOk);
			this.Name = "CardswipeCalibrateAddition";
			this.Text = "CardswipeCalibrateAddition";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button ButtonOk;
		private System.Windows.Forms.Button Cancel;
		private System.Windows.Forms.TextBox textBoxValue;
	}
}