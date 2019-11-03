namespace ECube.AccrualProcessor
{
	partial class SessionSelectionForm
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
			this.listBoxSessions = new System.Windows.Forms.ListBox();
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// listBoxSessions
			// 
			this.listBoxSessions.FormattingEnabled = true;
			this.listBoxSessions.ItemHeight = 25;
			this.listBoxSessions.Location = new System.Drawing.Point(15, 15);
			this.listBoxSessions.Margin = new System.Windows.Forms.Padding(6);
			this.listBoxSessions.Name = "listBoxSessions";
			this.listBoxSessions.Size = new System.Drawing.Size(747, 254);
			this.listBoxSessions.TabIndex = 0;
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(164, 278);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(198, 45);
			this.button1.TabIndex = 1;
			this.button1.Text = "Load Session";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(400, 278);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(198, 45);
			this.button2.TabIndex = 2;
			this.button2.Text = "Close Session";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// SessionSelectionForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(777, 335);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.listBoxSessions);
			this.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Margin = new System.Windows.Forms.Padding(6);
			this.Name = "SessionSelectionForm";
			this.Text = "Select Next Session To Process";
			this.Load += new System.EventHandler(this.SessionSelectionForm_Load);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ListBox listBoxSessions;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
	}
}