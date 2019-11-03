namespace RateRank
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
			this.monthCalendar1 = new Pabo.Calendar.MonthCalendar();
			this.button1 = new System.Windows.Forms.Button();
			this.listBoxSessions = new System.Windows.Forms.ListBox();
			this.labelStatus = new System.Windows.Forms.Label();
			this.button3 = new System.Windows.Forms.Button();
			this.labelStatus2 = new System.Windows.Forms.Label();
			this.button4 = new System.Windows.Forms.Button();
			this.listBoxStatus = new System.Windows.Forms.ListBox();
			this.SuspendLayout();
			// 
			// monthCalendar1
			// 
			this.monthCalendar1.ActiveMonth.Month = 7;
			this.monthCalendar1.ActiveMonth.Year = 2008;
			this.monthCalendar1.Culture = new System.Globalization.CultureInfo( "en-US" );
			this.monthCalendar1.Footer.Font = new System.Drawing.Font( "Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold );
			this.monthCalendar1.Header.Font = new System.Drawing.Font( "Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold );
			this.monthCalendar1.Header.TextColor = System.Drawing.Color.White;
			this.monthCalendar1.ImageList = null;
			this.monthCalendar1.Location = new System.Drawing.Point( 12, 26 );
			this.monthCalendar1.MaxDate = new System.DateTime( 2018, 7, 22, 14, 5, 48, 158 );
			this.monthCalendar1.MinDate = new System.DateTime( 1998, 7, 22, 14, 5, 48, 158 );
			this.monthCalendar1.Month.BackgroundImage = null;
			this.monthCalendar1.Month.DateFont = new System.Drawing.Font( "Microsoft Sans Serif", 8.25F );
			this.monthCalendar1.Month.TextFont = new System.Drawing.Font( "Microsoft Sans Serif", 8.25F );
			this.monthCalendar1.Name = "monthCalendar1";
			this.monthCalendar1.Size = new System.Drawing.Size( 469, 331 );
			this.monthCalendar1.TabIndex = 0;
			this.monthCalendar1.Weekdays.Font = new System.Drawing.Font( "Microsoft Sans Serif", 8.25F );
			this.monthCalendar1.Weeknumbers.Font = new System.Drawing.Font( "Microsoft Sans Serif", 8.25F );
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point( 194, 444 );
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size( 139, 47 );
			this.button1.TabIndex = 2;
			this.button1.Text = "Rank\r\nThis Session";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler( this.button1_Click );
			// 
			// listBoxSessions
			// 
			this.listBoxSessions.FormattingEnabled = true;
			this.listBoxSessions.Location = new System.Drawing.Point( 16, 370 );
			this.listBoxSessions.Name = "listBoxSessions";
			this.listBoxSessions.Size = new System.Drawing.Size( 158, 121 );
			this.listBoxSessions.TabIndex = 3;
			// 
			// labelStatus
			// 
			this.labelStatus.AutoSize = true;
			this.labelStatus.Location = new System.Drawing.Point( 205, 396 );
			this.labelStatus.Name = "labelStatus";
			this.labelStatus.Size = new System.Drawing.Size( 46, 13 );
			this.labelStatus.TabIndex = 4;
			this.labelStatus.Text = "Status...";
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point( 436, 431 );
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size( 75, 44 );
			this.button3.TabIndex = 9;
			this.button3.Text = "Configure\r\nPoints";
			this.button3.UseVisualStyleBackColor = true;
			this.button3.Click += new System.EventHandler( this.button3_Click );
			// 
			// labelStatus2
			// 
			this.labelStatus2.AutoSize = true;
			this.labelStatus2.Location = new System.Drawing.Point( 191, 383 );
			this.labelStatus2.Name = "labelStatus2";
			this.labelStatus2.Size = new System.Drawing.Size( 46, 13 );
			this.labelStatus2.TabIndex = 10;
			this.labelStatus2.Text = "Status...";
			// 
			// button4
			// 
			this.button4.Location = new System.Drawing.Point( 517, 431 );
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size( 75, 44 );
			this.button4.TabIndex = 11;
			this.button4.Text = "Configure\r\nPacks";
			this.button4.UseVisualStyleBackColor = true;
			this.button4.Click += new System.EventHandler( this.button4_Click );
			// 
			// listBoxStatus
			// 
			this.listBoxStatus.FormattingEnabled = true;
			this.listBoxStatus.Location = new System.Drawing.Point( 487, 26 );
			this.listBoxStatus.Name = "listBoxStatus";
			this.listBoxStatus.Size = new System.Drawing.Size( 318, 342 );
			this.listBoxStatus.TabIndex = 12;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size( 817, 515 );
			this.Controls.Add( this.listBoxStatus );
			this.Controls.Add( this.button4 );
			this.Controls.Add( this.labelStatus2 );
			this.Controls.Add( this.button3 );
			this.Controls.Add( this.labelStatus );
			this.Controls.Add( this.listBoxSessions );
			this.Controls.Add( this.button1 );
			this.Controls.Add( this.monthCalendar1 );
			this.Name = "Form1";
			this.Text = "Bingo Rater";
			this.ResumeLayout( false );
			this.PerformLayout();

		}

		#endregion

		private Pabo.Calendar.MonthCalendar monthCalendar1;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.ListBox listBoxSessions;
		private System.Windows.Forms.Label labelStatus;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.Label labelStatus2;
		private System.Windows.Forms.Button button4;
		private System.Windows.Forms.ListBox listBoxStatus;
	}
}

