namespace TopPlayers
{
	partial class PlayerParticipationReport
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
			this.label5 = new System.Windows.Forms.Label();
			this.buttonPrint = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.dateTimePickerTo = new System.Windows.Forms.DateTimePicker();
			this.comboBoxSessionNumber = new System.Windows.Forms.ComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.checkBoxShowDetails = new System.Windows.Forms.CheckBox();
			this.SuspendLayout();
			// 
			// crystalReportViewer1
			// 
			this.crystalReportViewer1.ActiveViewIndex = -1;
			this.crystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.crystalReportViewer1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.crystalReportViewer1.Location = new System.Drawing.Point(0, 147);
			this.crystalReportViewer1.Name = "crystalReportViewer1";
			this.crystalReportViewer1.SelectionFormula = "";
			this.crystalReportViewer1.Size = new System.Drawing.Size(1016, 587);
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
			this.buttonSearchDate.Location = new System.Drawing.Point(673, 13);
			this.buttonSearchDate.Name = "buttonSearchDate";
			this.buttonSearchDate.Size = new System.Drawing.Size(121, 32);
			this.buttonSearchDate.TabIndex = 9;
			this.buttonSearchDate.Text = "Search";
			this.buttonSearchDate.UseVisualStyleBackColor = true;
			this.buttonSearchDate.Click += new System.EventHandler(this.buttonSearchDate_Click);
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label5.Location = new System.Drawing.Point(70, 21);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(47, 16);
			this.label5.TabIndex = 6;
			this.label5.Text = "From:";
			// 
			// buttonPrint
			// 
			this.buttonPrint.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.buttonPrint.Location = new System.Drawing.Point(673, 51);
			this.buttonPrint.Name = "buttonPrint";
			this.buttonPrint.Size = new System.Drawing.Size(121, 32);
			this.buttonPrint.TabIndex = 9;
			this.buttonPrint.Text = "Print";
			this.buttonPrint.UseVisualStyleBackColor = true;
			this.buttonPrint.Click += new System.EventHandler(this.buttonPrint_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(70, 59);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(31, 16);
			this.label1.TabIndex = 6;
			this.label1.Text = "To:";
			// 
			// dateTimePickerTo
			// 
			this.dateTimePickerTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.dateTimePickerTo.Location = new System.Drawing.Point(171, 56);
			this.dateTimePickerTo.Name = "dateTimePickerTo";
			this.dateTimePickerTo.Size = new System.Drawing.Size(259, 22);
			this.dateTimePickerTo.TabIndex = 10;
			// 
			// comboBoxSessionNumber
			// 
			this.comboBoxSessionNumber.FormattingEnabled = true;
			this.comboBoxSessionNumber.Items.AddRange(new object[] {
            "All",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9"});
			this.comboBoxSessionNumber.Location = new System.Drawing.Point(171, 96);
			this.comboBoxSessionNumber.Name = "comboBoxSessionNumber";
			this.comboBoxSessionNumber.Size = new System.Drawing.Size(121, 21);
			this.comboBoxSessionNumber.TabIndex = 11;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point(70, 97);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(68, 16);
			this.label2.TabIndex = 6;
			this.label2.Text = "Session:";
			// 
			// checkBoxShowDetails
			// 
			this.checkBoxShowDetails.AutoSize = true;
			this.checkBoxShowDetails.Location = new System.Drawing.Point(476, 20);
			this.checkBoxShowDetails.Name = "checkBoxShowDetails";
			this.checkBoxShowDetails.Size = new System.Drawing.Size(149, 17);
			this.checkBoxShowDetails.TabIndex = 12;
			this.checkBoxShowDetails.Text = "Show Particiaption Details";
			this.checkBoxShowDetails.UseVisualStyleBackColor = true;
			// 
			// PlayerParticipationReport
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1016, 734);
			this.Controls.Add(this.checkBoxShowDetails);
			this.Controls.Add(this.comboBoxSessionNumber);
			this.Controls.Add(this.dateTimePickerTo);
			this.Controls.Add(this.dateTimePickerFrom);
			this.Controls.Add(this.buttonPrint);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.buttonSearchDate);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.crystalReportViewer1);
			this.Name = "PlayerParticipationReport";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Prizes Report";
			this.Load += new System.EventHandler(this.WeekPlayerReport_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1;
		private System.Windows.Forms.DateTimePicker dateTimePickerFrom;
		private System.Windows.Forms.Button buttonSearchDate;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Button buttonPrint;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.DateTimePicker dateTimePickerTo;
		private System.Windows.Forms.ComboBox comboBoxSessionNumber;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.CheckBox checkBoxShowDetails;
	}
}