namespace InitScheduleDatabase
{
	partial class Form1
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
			this.button1 = new System.Windows.Forms.Button();
			this.textBoxDSN = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.buttonDropSchedule = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(12, 76);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(180, 44);
			this.button1.TabIndex = 0;
			this.button1.Text = "Create Schedule";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// textBoxDSN
			// 
			this.textBoxDSN.Location = new System.Drawing.Point(138, 30);
			this.textBoxDSN.Name = "textBoxDSN";
			this.textBoxDSN.Size = new System.Drawing.Size(100, 20);
			this.textBoxDSN.TabIndex = 1;
			this.textBoxDSN.Text = "MySQL";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 33);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(110, 13);
			this.label1.TabIndex = 2;
			this.label1.Text = "Select database DSN";
			// 
			// buttonDropSchedule
			// 
			this.buttonDropSchedule.Location = new System.Drawing.Point(15, 126);
			this.buttonDropSchedule.Name = "buttonDropSchedule";
			this.buttonDropSchedule.Size = new System.Drawing.Size(180, 44);
			this.buttonDropSchedule.TabIndex = 3;
			this.buttonDropSchedule.Text = "Drop Schedule";
			this.buttonDropSchedule.UseVisualStyleBackColor = true;
			this.buttonDropSchedule.Click += new System.EventHandler(this.buttonDropSchedule_Click);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(282, 206);
			this.Controls.Add(this.buttonDropSchedule);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.textBoxDSN);
			this.Controls.Add(this.button1);
			this.Name = "Form1";
			this.Text = "Initialize Database";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.TextBox textBoxDSN;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button buttonDropSchedule;
	}
}

