namespace OpenSkieScheduler3.Controls.Forms
{
	partial class PayoutDateSelector
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
			this.SuspendLayout();
			// 
			// monthCalendar1
			// 
			this.monthCalendar1.ActiveMonth.Month = 5;
			this.monthCalendar1.ActiveMonth.Year = 2009;
			this.monthCalendar1.Culture = new System.Globalization.CultureInfo( "en-US" );
			this.monthCalendar1.Footer.Font = new System.Drawing.Font( "Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold );
			this.monthCalendar1.Header.Font = new System.Drawing.Font( "Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold );
			this.monthCalendar1.Header.TextColor = System.Drawing.Color.White;
			this.monthCalendar1.ImageList = null;
			this.monthCalendar1.Location = new System.Drawing.Point( 12, 12 );
			this.monthCalendar1.MaxDate = new System.DateTime( 2019, 5, 4, 15, 41, 32, 250 );
			this.monthCalendar1.MinDate = new System.DateTime( 1999, 5, 4, 15, 41, 32, 250 );
			this.monthCalendar1.Month.BackgroundImage = null;
			this.monthCalendar1.Month.DateFont = new System.Drawing.Font( "Microsoft Sans Serif", 8.25F );
			this.monthCalendar1.Month.TextFont = new System.Drawing.Font( "Microsoft Sans Serif", 8.25F );
			this.monthCalendar1.Name = "monthCalendar1";
			this.monthCalendar1.Size = new System.Drawing.Size( 450, 326 );
			this.monthCalendar1.TabIndex = 0;
			this.monthCalendar1.Weekdays.Font = new System.Drawing.Font( "Microsoft Sans Serif", 8.25F );
			this.monthCalendar1.Weeknumbers.Font = new System.Drawing.Font( "Microsoft Sans Serif", 8.25F );
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point( 387, 348 );
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size( 75, 23 );
			this.button1.TabIndex = 1;
			this.button1.Text = "button1";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler( this.button1_Click );
			// 
			// PayoutDateSelector
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size( 474, 383 );
			this.Controls.Add( this.button1 );
			this.Controls.Add( this.monthCalendar1 );
			this.Name = "PayoutDateSelector";
			this.Text = "PayoutDateSelector";
			this.ResumeLayout( false );

		}

		#endregion

		private Pabo.Calendar.MonthCalendar monthCalendar1;
		private System.Windows.Forms.Button button1;
	}
}