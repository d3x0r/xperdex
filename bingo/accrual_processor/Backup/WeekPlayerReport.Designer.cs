namespace TopPlayers
{
	partial class WeekPlayerReport
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
			this.crystalReportViewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
			this.dateTimePickerFrom = new System.Windows.Forms.DateTimePicker();
			this.buttonSearchDate = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.labelWeek = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.buttonPrint = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// crystalReportViewer1
			// 
			this.crystalReportViewer1.ActiveViewIndex = -1;
			this.crystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.crystalReportViewer1.DisplayGroupTree = false;
			this.crystalReportViewer1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.crystalReportViewer1.Location = new System.Drawing.Point(0, 95);
			this.crystalReportViewer1.Name = "crystalReportViewer1";
			this.crystalReportViewer1.SelectionFormula = "";
			this.crystalReportViewer1.Size = new System.Drawing.Size(1016, 639);
			this.crystalReportViewer1.TabIndex = 0;
			this.crystalReportViewer1.ViewTimeSelectionFormula = "";
			// 
			// dateTimePickerFrom
			// 
			this.dateTimePickerFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.dateTimePickerFrom.Location = new System.Drawing.Point(171, 18);
			this.dateTimePickerFrom.Name = "dateTimePickerFrom";
			this.dateTimePickerFrom.Size = new System.Drawing.Size(259, 22);
			this.dateTimePickerFrom.TabIndex = 10;
			// 
			// buttonSearchDate
			// 
			this.buttonSearchDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.buttonSearchDate.Location = new System.Drawing.Point(473, 13);
			this.buttonSearchDate.Name = "buttonSearchDate";
			this.buttonSearchDate.Size = new System.Drawing.Size(121, 32);
			this.buttonSearchDate.TabIndex = 9;
			this.buttonSearchDate.Text = "Search";
			this.buttonSearchDate.UseVisualStyleBackColor = true;
			this.buttonSearchDate.Click += new System.EventHandler(this.buttonSearchDate_Click);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point(41, 59);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(58, 16);
			this.label2.TabIndex = 8;
			this.label2.Text = "Period:";
			// 
			// labelWeek
			// 
			this.labelWeek.AutoSize = true;
			this.labelWeek.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelWeek.Location = new System.Drawing.Point(168, 59);
			this.labelWeek.Name = "labelWeek";
			this.labelWeek.Size = new System.Drawing.Size(64, 16);
			this.labelWeek.TabIndex = 7;
			this.labelWeek.Text = "[Period]";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label5.Location = new System.Drawing.Point(41, 21);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(93, 16);
			this.label5.TabIndex = 6;
			this.label5.Text = "Select Date:";
			// 
			// buttonPrint
			// 
			this.buttonPrint.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.buttonPrint.Location = new System.Drawing.Point(473, 51);
			this.buttonPrint.Name = "buttonPrint";
			this.buttonPrint.Size = new System.Drawing.Size(121, 32);
			this.buttonPrint.TabIndex = 9;
			this.buttonPrint.Text = "Print";
			this.buttonPrint.UseVisualStyleBackColor = true;
			this.buttonPrint.Click += new System.EventHandler(this.buttonPrint_Click);
			// 
			// WeekPlayerReport
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1016, 734);
			this.Controls.Add(this.dateTimePickerFrom);
			this.Controls.Add(this.buttonPrint);
			this.Controls.Add(this.buttonSearchDate);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.labelWeek);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.crystalReportViewer1);
			this.Name = "WeekPlayerReport";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "WeekPlayerReport";
			this.Load += new System.EventHandler(this.WeekPlayerReport_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1;
		private System.Windows.Forms.DateTimePicker dateTimePickerFrom;
		private System.Windows.Forms.Button buttonSearchDate;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label labelWeek;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Button buttonPrint;
	}
}