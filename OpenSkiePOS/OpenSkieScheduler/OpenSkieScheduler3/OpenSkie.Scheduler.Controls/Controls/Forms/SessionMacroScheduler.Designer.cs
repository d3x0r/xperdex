using System;
namespace OpenSkieScheduler3.Controls.Forms
{
	partial class SessionMacroScheduler
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
			this.panelColorsConvention = new System.Windows.Forms.Panel();
			this.labelColorTitle = new System.Windows.Forms.Label();
			this.panel3 = new System.Windows.Forms.Panel();
			this.labelTitleDetails = new System.Windows.Forms.Label();
			this.buttonMacroChangeTo = new System.Windows.Forms.Button();
			this.labelDetailsII = new System.Windows.Forms.Label();
			this.labelDetails = new System.Windows.Forms.Label();
			this.comboBoxMacroSessionChange = new System.Windows.Forms.ComboBox();
			this.monthCalendarMacroSchedule = new Pabo.Calendar.MonthCalendar();
			this.panelColorsConvention.SuspendLayout();
			this.panel3.SuspendLayout();
			this.SuspendLayout();
			// 
			// panelColorsConvention
			// 
			this.panelColorsConvention.BackColor = System.Drawing.Color.White;
			this.panelColorsConvention.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panelColorsConvention.Controls.Add( this.labelColorTitle );
			this.panelColorsConvention.Location = new System.Drawing.Point( 21, 404 );
			this.panelColorsConvention.Name = "panelColorsConvention";
			this.panelColorsConvention.Size = new System.Drawing.Size( 932, 252 );
			this.panelColorsConvention.TabIndex = 11;
			// 
			// labelColorTitle
			// 
			this.labelColorTitle.AutoSize = true;
			this.labelColorTitle.Location = new System.Drawing.Point( 14, 11 );
			this.labelColorTitle.Name = "labelColorTitle";
			this.labelColorTitle.Size = new System.Drawing.Size( 82, 13 );
			this.labelColorTitle.TabIndex = 4;
			this.labelColorTitle.Text = "Macro Sessions";
			// 
			// panel3
			// 
			this.panel3.BackColor = System.Drawing.Color.White;
			this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel3.Controls.Add( this.labelTitleDetails );
			this.panel3.Controls.Add( this.buttonMacroChangeTo );
			this.panel3.Controls.Add( this.labelDetailsII );
			this.panel3.Controls.Add( this.labelDetails );
			this.panel3.Controls.Add( this.comboBoxMacroSessionChange );
			this.panel3.Location = new System.Drawing.Point( 618, 18 );
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size( 335, 368 );
			this.panel3.TabIndex = 10;
			// 
			// labelTitleDetails
			// 
			this.labelTitleDetails.AutoSize = true;
			this.labelTitleDetails.Location = new System.Drawing.Point( 17, 9 );
			this.labelTitleDetails.Name = "labelTitleDetails";
			this.labelTitleDetails.Size = new System.Drawing.Size( 113, 13 );
			this.labelTitleDetails.TabIndex = 4;
			this.labelTitleDetails.Text = "Selected Date Details:";
			// 
			// buttonMacroChangeTo
			// 
			this.buttonMacroChangeTo.Location = new System.Drawing.Point( 60, 325 );
			this.buttonMacroChangeTo.Name = "buttonMacroChangeTo";
			this.buttonMacroChangeTo.Size = new System.Drawing.Size( 242, 31 );
			this.buttonMacroChangeTo.TabIndex = 6;
			this.buttonMacroChangeTo.Text = "Change Macro Session";
			this.buttonMacroChangeTo.UseVisualStyleBackColor = true;
			this.buttonMacroChangeTo.Visible = false;
			this.buttonMacroChangeTo.Click += new System.EventHandler( this.buttonMacroChangeTo_Click );
			// 
			// labelDetailsII
			// 
			this.labelDetailsII.AutoSize = true;
			this.labelDetailsII.Location = new System.Drawing.Point( 196, 40 );
			this.labelDetailsII.Name = "labelDetailsII";
			this.labelDetailsII.Size = new System.Drawing.Size( 45, 13 );
			this.labelDetailsII.TabIndex = 4;
			this.labelDetailsII.Text = "[Details]";
			this.labelDetailsII.Visible = false;
			// 
			// labelDetails
			// 
			this.labelDetails.AutoSize = true;
			this.labelDetails.Location = new System.Drawing.Point( 17, 40 );
			this.labelDetails.Name = "labelDetails";
			this.labelDetails.Size = new System.Drawing.Size( 45, 13 );
			this.labelDetails.TabIndex = 4;
			this.labelDetails.Text = "[Details]";
			this.labelDetails.Visible = false;
			// 
			// comboBoxMacroSessionChange
			// 
			this.comboBoxMacroSessionChange.FormattingEnabled = true;
			this.comboBoxMacroSessionChange.Location = new System.Drawing.Point( 60, 291 );
			this.comboBoxMacroSessionChange.Name = "comboBoxMacroSessionChange";
			this.comboBoxMacroSessionChange.Size = new System.Drawing.Size( 242, 21 );
			this.comboBoxMacroSessionChange.TabIndex = 5;
			this.comboBoxMacroSessionChange.Visible = false;
			// 
			// monthCalendarMacroSchedule
			// 
			this.monthCalendarMacroSchedule.Culture = new System.Globalization.CultureInfo( "en-US" );
			this.monthCalendarMacroSchedule.Footer.Font = new System.Drawing.Font( "Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold );
			this.monthCalendarMacroSchedule.Header.Font = new System.Drawing.Font( "Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold );
			this.monthCalendarMacroSchedule.Header.TextColor = System.Drawing.Color.White;
			this.monthCalendarMacroSchedule.ImageList = null;
			this.monthCalendarMacroSchedule.Location = new System.Drawing.Point( 21, 18 );
			this.monthCalendarMacroSchedule.MaxDate = new System.DateTime( 2018, 4, 23, 14, 21, 12, 64 );
			this.monthCalendarMacroSchedule.MinDate = new System.DateTime( 1998, 4, 23, 14, 21, 12, 64 );
			this.monthCalendarMacroSchedule.Month.BackgroundImage = null;
			this.monthCalendarMacroSchedule.Month.DateFont = new System.Drawing.Font( "Microsoft Sans Serif", 8.25F );
			this.monthCalendarMacroSchedule.Month.TextFont = new System.Drawing.Font( "Microsoft Sans Serif", 8.25F );
			this.monthCalendarMacroSchedule.Name = "monthCalendarMacroSchedule";
			this.monthCalendarMacroSchedule.Size = new System.Drawing.Size( 577, 368 );
			this.monthCalendarMacroSchedule.TabIndex = 9;
			this.monthCalendarMacroSchedule.Weekdays.Font = new System.Drawing.Font( "Microsoft Sans Serif", 8.25F );
			this.monthCalendarMacroSchedule.Weeknumbers.Font = new System.Drawing.Font( "Microsoft Sans Serif", 8.25F );
			this.monthCalendarMacroSchedule.DayQueryInfo += new Pabo.Calendar.DayQueryInfoEventHandler( this.monthCalendarMacroSchedule_DayQueryInfo );
			this.monthCalendarMacroSchedule.DaySelected += new Pabo.Calendar.DaySelectedEventHandler( this.monthCalendarMacroSchedule_DaySelected );

			// 
			// SessionMacroScheduler
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size( 976, 671 );
			this.Controls.Add( this.panelColorsConvention );
			this.Controls.Add( this.panel3 );
			this.Controls.Add( this.monthCalendarMacroSchedule );
			this.Name = "SessionMacroScheduler";
			this.Text = "SessionMacroScheduler";
			this.Load += new System.EventHandler( this.SessionMacroScheduler_Load );
			this.panelColorsConvention.ResumeLayout( false );
			this.panelColorsConvention.PerformLayout();
			this.panel3.ResumeLayout( false );
			this.panel3.PerformLayout();
			this.ResumeLayout( false );

		}

		#endregion

		private System.Windows.Forms.Panel panelColorsConvention;
		private System.Windows.Forms.Label labelColorTitle;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.Label labelTitleDetails;
		private System.Windows.Forms.Button buttonMacroChangeTo;
		private System.Windows.Forms.Label labelDetailsII;
		private System.Windows.Forms.Label labelDetails;
		private System.Windows.Forms.ComboBox comboBoxMacroSessionChange;
		private Pabo.Calendar.MonthCalendar monthCalendarMacroSchedule;
	}
}