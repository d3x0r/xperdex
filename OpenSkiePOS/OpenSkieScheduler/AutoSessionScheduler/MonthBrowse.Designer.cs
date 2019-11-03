namespace AutoSessionScheduler
{
	partial class MonthBrowse
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
			this.components = new System.ComponentModel.Container();
			this.monthCalendar1 = new Pabo.Calendar.MonthCalendar();
			this.imageList1 = new System.Windows.Forms.ImageList( this.components );
			this.SessionList = new System.Windows.Forms.ListBox();
			this.button4 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.EditEnable = new System.Windows.Forms.CheckBox();
			this.SuspendLayout();
			// 
			// monthCalendar1
			// 
			//this.monthCalendar1.ActiveMonth.Month = DateTime.Now.Month;
			//this.monthCalendar1.ActiveMonth.Year = DateTime.Now.Year;
			this.monthCalendar1.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom )
						| System.Windows.Forms.AnchorStyles.Left )
						| System.Windows.Forms.AnchorStyles.Right ) ) );
			this.monthCalendar1.Culture = new System.Globalization.CultureInfo( "en-US" );
			this.monthCalendar1.Footer.Font = new System.Drawing.Font( "Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold );
			this.monthCalendar1.Header.Font = new System.Drawing.Font( "Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold );
			this.monthCalendar1.Header.TextColor = System.Drawing.Color.White;
			this.monthCalendar1.ImageList = null;
			this.monthCalendar1.Location = new System.Drawing.Point( 223, 12 );
			this.monthCalendar1.MaxDate = new System.DateTime( 2017, 10, 2, 17, 12, 42, 708 );
			this.monthCalendar1.MinDate = new System.DateTime( 1997, 10, 2, 17, 12, 42, 708 );
			this.monthCalendar1.Month.BackgroundImage = null;
			this.monthCalendar1.Month.DateAlign = Pabo.Calendar.mcItemAlign.TopRight;
			this.monthCalendar1.Month.DateFont = new System.Drawing.Font( "Microsoft Sans Serif", 8.25F );
			this.monthCalendar1.Month.TextFont = new System.Drawing.Font( "Microsoft Sans Serif", 8.25F );
			this.monthCalendar1.Name = "monthCalendar1";
			this.monthCalendar1.Size = new System.Drawing.Size( 773, 708 );
			this.monthCalendar1.TabIndex = 0;
			this.monthCalendar1.Weekdays.Font = new System.Drawing.Font( "Microsoft Sans Serif", 8.25F );
			this.monthCalendar1.Weeknumbers.Font = new System.Drawing.Font( "Microsoft Sans Serif", 8.25F );
			this.monthCalendar1.DayQueryInfo += new Pabo.Calendar.DayQueryInfoEventHandler( this.monthCalendar1_DayQueryInfo_1 );
			this.monthCalendar1.DaySelected += new Pabo.Calendar.DaySelectedEventHandler( this.monthCalendar1_DaySelected );
			// 
			// imageList1
			// 
			this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
			this.imageList1.ImageSize = new System.Drawing.Size( 256, 256 );
			this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// SessionList
			// 
			this.SessionList.FormattingEnabled = true;
			this.SessionList.Location = new System.Drawing.Point( 12, 43 );
			this.SessionList.Name = "SessionList";
			this.SessionList.Size = new System.Drawing.Size( 190, 290 );
			this.SessionList.TabIndex = 1;
			this.SessionList.SelectedValueChanged += new System.EventHandler( this.SessionList_SelectedValueChanged );
			// 
			// button4
			// 
			this.button4.Location = new System.Drawing.Point( 12, 590 );
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size( 190, 62 );
			this.button4.TabIndex = 5;
			this.button4.Text = "Select Session Images";
			this.button4.UseVisualStyleBackColor = true;
			this.button4.Click += new System.EventHandler( this.button4_MouseClick );
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point( 12, 522 );
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size( 190, 62 );
			this.button2.TabIndex = 4;
			this.button2.Text = "Edit Page Unlocks";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler( this.button2_Click );
			// 
			// button1
			// 
			this.button1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.button1.Location = new System.Drawing.Point( 12, 359 );
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size( 190, 62 );
			this.button1.TabIndex = 6;
			this.button1.Text = "Done";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler( this.button1_Click );
			// 
			// EditEnable
			// 
			this.EditEnable.AutoSize = true;
			this.EditEnable.Location = new System.Drawing.Point( 25, 461 );
			this.EditEnable.Name = "EditEnable";
			this.EditEnable.Size = new System.Drawing.Size( 80, 17 );
			this.EditEnable.TabIndex = 7;
			this.EditEnable.Text = "Enable Edit";
			this.EditEnable.UseVisualStyleBackColor = true;
			// 
			// MonthBrowse
			// 
			this.AcceptButton = this.button1;
			this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.button1;
			this.ClientSize = new System.Drawing.Size( 1008, 732 );
			this.ControlBox = false;
			this.Controls.Add( this.EditEnable );
			this.Controls.Add( this.button1 );
			this.Controls.Add( this.button4 );
			this.Controls.Add( this.button2 );
			this.Controls.Add( this.SessionList );
			this.Controls.Add( this.monthCalendar1 );
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Name = "MonthBrowse";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Assign Sessions To Days";
			this.ResumeLayout( false );
			this.PerformLayout();

		}

		#endregion

		private Pabo.Calendar.MonthCalendar monthCalendar1;
		private System.Windows.Forms.ImageList imageList1;
		private System.Windows.Forms.ListBox SessionList;
		private System.Windows.Forms.Button button4;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.CheckBox EditEnable;
	}
}