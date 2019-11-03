namespace SessionOddsMaker
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
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.sessionMacroList1 = new OpenSkieScheduler.Controls.Lists.SessionMacroList();
			this.button2 = new System.Windows.Forms.Button();
			this.monthCalendar1 = new Pabo.Calendar.MonthCalendar();
			this.SuspendLayout();
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point( 461, 323 );
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size( 75, 23 );
			this.button1.TabIndex = 0;
			this.button1.Text = "button1";
			this.button1.UseVisualStyleBackColor = true;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point( 153, 244 );
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size( 41, 13 );
			this.label1.TabIndex = 1;
			this.label1.Text = "Players";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point( 153, 266 );
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size( 97, 13 );
			this.label2.TabIndex = 2;
			this.label2.Text = "Packs Players Play";
			// 
			// sessionMacroList1
			// 
			this.sessionMacroList1.DisplayMember = "session_macro_name";
			this.sessionMacroList1.FormattingEnabled = true;
			this.sessionMacroList1.Location = new System.Drawing.Point( 300, 12 );
			this.sessionMacroList1.Name = "sessionMacroList1";
			this.sessionMacroList1.Size = new System.Drawing.Size( 120, 108 );
			this.sessionMacroList1.TabIndex = 3;
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point( 461, 49 );
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size( 75, 23 );
			this.button2.TabIndex = 4;
			this.button2.Text = "button2";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler( this.button2_Click );
			// 
			// monthCalendar1
			// 
			this.monthCalendar1.ActiveMonth.Month = 1;
			this.monthCalendar1.ActiveMonth.Year = 2009;
			this.monthCalendar1.Culture = new System.Globalization.CultureInfo( "en-US" );
			this.monthCalendar1.Footer.Font = new System.Drawing.Font( "Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold );
			this.monthCalendar1.Header.Font = new System.Drawing.Font( "Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold );
			this.monthCalendar1.Header.TextColor = System.Drawing.Color.White;
			this.monthCalendar1.ImageList = null;
			this.monthCalendar1.Location = new System.Drawing.Point( 12, 12 );
			this.monthCalendar1.MaxDate = new System.DateTime( 2019, 1, 19, 0, 28, 2, 137 );
			this.monthCalendar1.MinDate = new System.DateTime( 1999, 1, 19, 0, 28, 2, 137 );
			this.monthCalendar1.Month.BackgroundImage = null;
			this.monthCalendar1.Month.DateFont = new System.Drawing.Font( "Microsoft Sans Serif", 8.25F );
			this.monthCalendar1.Month.TextFont = new System.Drawing.Font( "Microsoft Sans Serif", 8.25F );
			this.monthCalendar1.Name = "monthCalendar1";
			this.monthCalendar1.Size = new System.Drawing.Size( 253, 199 );
			this.monthCalendar1.TabIndex = 5;
			this.monthCalendar1.Weekdays.Font = new System.Drawing.Font( "Microsoft Sans Serif", 8.25F );
			this.monthCalendar1.Weeknumbers.Font = new System.Drawing.Font( "Microsoft Sans Serif", 8.25F );
			this.monthCalendar1.MonthChanged += new Pabo.Calendar.MonthChangedEventHandler( this.monthCalendar1_MonthChanged );
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size( 699, 358 );
			this.Controls.Add( this.monthCalendar1 );
			this.Controls.Add( this.button2 );
			this.Controls.Add( this.sessionMacroList1 );
			this.Controls.Add( this.label2 );
			this.Controls.Add( this.label1 );
			this.Controls.Add( this.button1 );
			this.Name = "Form1";
			this.Text = "Form1";
			this.Load += new System.EventHandler( this.Form1_Load );
			this.ResumeLayout( false );
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private OpenSkieScheduler.Controls.Lists.SessionMacroList sessionMacroList1;
		private System.Windows.Forms.Button button2;
		private Pabo.Calendar.MonthCalendar monthCalendar1;
	}
}

