using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace RateRank2
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
			this.button3 = new System.Windows.Forms.Button();
			this.button4 = new System.Windows.Forms.Button();
			this.listBoxStatus = new System.Windows.Forms.ListBox();
			this.button2 = new System.Windows.Forms.Button();
			this.button5 = new System.Windows.Forms.Button();
			this.buttonInspect = new System.Windows.Forms.Button();
			this.buttonReRank = new System.Windows.Forms.Button();
			this.button6 = new System.Windows.Forms.Button();
			this.buttonOptionEdit = new System.Windows.Forms.Button();
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this.statusHeader = new System.Windows.Forms.Label();
			this.listBoxSessions = new RateRank2.MultiColumnListBox();
			this.button7 = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			this.SuspendLayout();
			// 
			// monthCalendar1
			// 
			this.monthCalendar1.ActiveMonth.Month = 3;
			this.monthCalendar1.ActiveMonth.Year = 2012;
			this.monthCalendar1.Culture = new System.Globalization.CultureInfo("en-US");
			this.monthCalendar1.Footer.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
			this.monthCalendar1.Header.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
			this.monthCalendar1.Header.TextColor = System.Drawing.Color.White;
			this.monthCalendar1.ImageList = null;
			this.monthCalendar1.Location = new System.Drawing.Point(12, 7);
			this.monthCalendar1.MaxDate = new System.DateTime(2048, 7, 22, 14, 5, 48, 158);
			this.monthCalendar1.MinDate = new System.DateTime(1998, 7, 22, 14, 5, 48, 158);
			this.monthCalendar1.Month.BackgroundImage = null;
			this.monthCalendar1.Month.DateFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
			this.monthCalendar1.Month.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
			this.monthCalendar1.Name = "monthCalendar1";
			this.monthCalendar1.Size = new System.Drawing.Size(469, 331);
			this.monthCalendar1.TabIndex = 0;
			this.monthCalendar1.Weekdays.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
			this.monthCalendar1.Weeknumbers.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(194, 518);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(139, 47);
			this.button1.TabIndex = 4;
			this.button1.Text = "Rank\r\nThis Session";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(436, 519);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(75, 44);
			this.button3.TabIndex = 7;
			this.button3.Text = "Configure\r\nPoints";
			this.button3.UseVisualStyleBackColor = true;
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// button4
			// 
			this.button4.Location = new System.Drawing.Point(517, 519);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(75, 44);
			this.button4.TabIndex = 8;
			this.button4.Text = "Configure\r\nPacks";
			this.button4.UseVisualStyleBackColor = true;
			this.button4.Click += new System.EventHandler(this.button4_Click);
			// 
			// listBoxStatus
			// 
			this.listBoxStatus.FormattingEnabled = true;
			this.listBoxStatus.Location = new System.Drawing.Point(487, 35);
			this.listBoxStatus.Name = "listBoxStatus";
			this.listBoxStatus.Size = new System.Drawing.Size(318, 303);
			this.listBoxStatus.TabIndex = 12;
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(715, 519);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(75, 44);
			this.button2.TabIndex = 10;
			this.button2.Text = "Configure\r\nSchedule";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click_1);
			// 
			// button5
			// 
			this.button5.Location = new System.Drawing.Point(598, 519);
			this.button5.Name = "button5";
			this.button5.Size = new System.Drawing.Size(89, 44);
			this.button5.TabIndex = 9;
			this.button5.Text = "Set Rated\r\nGame Groups";
			this.button5.UseVisualStyleBackColor = true;
			this.button5.Click += new System.EventHandler(this.button5_Click);
			// 
			// buttonInspect
			// 
			this.buttonInspect.Location = new System.Drawing.Point(194, 569);
			this.buttonInspect.Name = "buttonInspect";
			this.buttonInspect.Size = new System.Drawing.Size(139, 47);
			this.buttonInspect.TabIndex = 6;
			this.buttonInspect.Text = "Inspect\r\nThis Session";
			this.buttonInspect.UseVisualStyleBackColor = true;
			this.buttonInspect.Click += new System.EventHandler(this.buttonInspect_Click);
			// 
			// buttonReRank
			// 
			this.buttonReRank.Location = new System.Drawing.Point(340, 518);
			this.buttonReRank.Name = "buttonReRank";
			this.buttonReRank.Size = new System.Drawing.Size(75, 47);
			this.buttonReRank.TabIndex = 5;
			this.buttonReRank.Text = "Rerank\r\nAll";
			this.buttonReRank.UseVisualStyleBackColor = true;
			this.buttonReRank.Click += new System.EventHandler(this.buttonReRank_Click);
			// 
			// button6
			// 
			this.button6.Location = new System.Drawing.Point(436, 567);
			this.button6.Name = "button6";
			this.button6.Size = new System.Drawing.Size(110, 44);
			this.button6.TabIndex = 11;
			this.button6.Text = "Configure Session\r\nBonus Points\r\n";
			this.button6.UseVisualStyleBackColor = true;
			this.button6.Click += new System.EventHandler(this.button6_Click);
			// 
			// buttonOptionEdit
			// 
			this.buttonOptionEdit.Location = new System.Drawing.Point(598, 567);
			this.buttonOptionEdit.Name = "buttonOptionEdit";
			this.buttonOptionEdit.Size = new System.Drawing.Size(88, 44);
			this.buttonOptionEdit.TabIndex = 12;
			this.buttonOptionEdit.Text = "Configure\r\nOption Map";
			this.buttonOptionEdit.UseVisualStyleBackColor = true;
			this.buttonOptionEdit.Click += new System.EventHandler(this.button7_Click);
			// 
			// dataGridView1
			// 
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.Location = new System.Drawing.Point(12, 345);
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.dataGridView1.Size = new System.Drawing.Size(793, 153);
			this.dataGridView1.TabIndex = 2;
			// 
			// statusHeader
			// 
			this.statusHeader.BackColor = this.monthCalendar1.Header.BackColor1;
			this.statusHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
			this.statusHeader.ForeColor = System.Drawing.Color.White;
			this.statusHeader.Location = new System.Drawing.Point(487, 7);
			this.statusHeader.Name = "statusHeader";
			this.statusHeader.Size = new System.Drawing.Size(318, 28);
			this.statusHeader.TabIndex = 14;
			this.statusHeader.Text = "Ranking and Inspection Status";
			this.statusHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// listBoxSessions
			// 
			this.listBoxSessions.ColumnCount = 3;
			this.listBoxSessions.ColumnWidth = 173;
			this.listBoxSessions.FormattingEnabled = true;
			this.listBoxSessions.Location = new System.Drawing.Point(12, 505);
			this.listBoxSessions.MatchBufferTimeOut = 1000D;
			this.listBoxSessions.MatchEntryStyle = RateRank2.MatchEntryStyle.ColpleteBestMatch;
			this.listBoxSessions.Name = "listBoxSessions";
			this.listBoxSessions.SelectionMode = System.Windows.Forms.SelectionMode.None;
			this.listBoxSessions.Size = new System.Drawing.Size(173, 121);
			this.listBoxSessions.TabIndex = 13;
			this.listBoxSessions.TextIndex = -1;
			this.listBoxSessions.TextMember = null;
			this.listBoxSessions.ValueIndex = -1;
			// 
			// button7
			// 
			this.button7.Location = new System.Drawing.Point(715, 570);
			this.button7.Name = "button7";
			this.button7.Size = new System.Drawing.Size(75, 23);
			this.button7.TabIndex = 15;
			this.button7.Text = "button7";
			this.button7.UseVisualStyleBackColor = true;
			this.button7.Click += new System.EventHandler(this.button7_Click_1);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(817, 638);
			this.Controls.Add(this.button7);
			this.Controls.Add(this.statusHeader);
			this.Controls.Add(this.listBoxSessions);
			this.Controls.Add(this.dataGridView1);
			this.Controls.Add(this.buttonOptionEdit);
			this.Controls.Add(this.button6);
			this.Controls.Add(this.buttonReRank);
			this.Controls.Add(this.buttonInspect);
			this.Controls.Add(this.button5);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.listBoxStatus);
			this.Controls.Add(this.button4);
			this.Controls.Add(this.button3);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.monthCalendar1);
			this.Name = "Form1";
			this.Text = "Bingo Rater";
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private Pabo.Calendar.MonthCalendar monthCalendar1;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.Button button4;
		private System.Windows.Forms.ListBox listBoxStatus;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button5;
		private System.Windows.Forms.Button buttonInspect;
		private System.Windows.Forms.Button buttonReRank;
		private System.Windows.Forms.Button button6;
		private System.Windows.Forms.Button buttonOptionEdit;
        private System.Windows.Forms.DataGridView dataGridView1;
        private MultiColumnListBox listBoxSessions;
		private Label statusHeader;
		private Button button7;
	}
}

