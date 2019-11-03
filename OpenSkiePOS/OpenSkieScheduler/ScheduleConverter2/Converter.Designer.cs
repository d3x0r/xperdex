namespace ScheduleConverter
{
	partial class Converter
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
			this.buttonLoad1 = new System.Windows.Forms.Button();
			this.labelStatus1 = new System.Windows.Forms.Label();
			this.labelStatus2 = new System.Windows.Forms.Label();
			this.buttonConvert = new System.Windows.Forms.Button();
			this.buttonCreateSchedule2 = new System.Windows.Forms.Button();
			this.buttonCreateSchedule1 = new System.Windows.Forms.Button();
			this.buttonStoreSchedule2 = new System.Windows.Forms.Button();
			this.textBoxDsn1 = new System.Windows.Forms.TextBox();
			this.textBoxDsn2 = new System.Windows.Forms.TextBox();
			this.buttonEdit2 = new System.Windows.Forms.Button();
			this.buttonEdit1 = new System.Windows.Forms.Button();
			this.checkBoxLegacySchedule1 = new System.Windows.Forms.CheckBox();
			this.checkBoxLegacySchedule2 = new System.Windows.Forms.CheckBox();
			this.textBoxLegacyPath1 = new System.Windows.Forms.TextBox();
			this.textBoxLegacyPath2 = new System.Windows.Forms.TextBox();
			this.buttonLoadSchedule2 = new System.Windows.Forms.Button();
			this.buttonMergePatterns = new System.Windows.Forms.Button();
			this.buttonDropSchedule1 = new System.Windows.Forms.Button();
			this.checkBoxLoadOldSchedule1 = new System.Windows.Forms.CheckBox();
			this.checkBoxUseEPaperCardset = new System.Windows.Forms.CheckBox();
			this.textBoxBingoINI = new System.Windows.Forms.TextBox();
			this.textBoxFtnSysINI = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// buttonLoad1
			// 
			this.buttonLoad1.Location = new System.Drawing.Point(104, 279);
			this.buttonLoad1.Name = "buttonLoad1";
			this.buttonLoad1.Size = new System.Drawing.Size(127, 34);
			this.buttonLoad1.TabIndex = 0;
			this.buttonLoad1.Text = "Load Schedule";
			this.buttonLoad1.UseVisualStyleBackColor = true;
			this.buttonLoad1.Click += new System.EventHandler(this.buttonLoad1_Click);
			// 
			// labelStatus1
			// 
			this.labelStatus1.AutoSize = true;
			this.labelStatus1.Location = new System.Drawing.Point(100, 356);
			this.labelStatus1.Name = "labelStatus1";
			this.labelStatus1.Size = new System.Drawing.Size(49, 13);
			this.labelStatus1.TabIndex = 6;
			this.labelStatus1.Text = "Status....";
			// 
			// labelStatus2
			// 
			this.labelStatus2.AutoSize = true;
			this.labelStatus2.Location = new System.Drawing.Point(394, 356);
			this.labelStatus2.Name = "labelStatus2";
			this.labelStatus2.Size = new System.Drawing.Size(49, 13);
			this.labelStatus2.TabIndex = 7;
			this.labelStatus2.Text = "Status....";
			// 
			// buttonConvert
			// 
			this.buttonConvert.Location = new System.Drawing.Point(220, 394);
			this.buttonConvert.Name = "buttonConvert";
			this.buttonConvert.Size = new System.Drawing.Size(133, 40);
			this.buttonConvert.TabIndex = 8;
			this.buttonConvert.Text = "Convert ->";
			this.buttonConvert.UseVisualStyleBackColor = true;
			this.buttonConvert.Click += new System.EventHandler(this.buttonConvert_Click);
			// 
			// buttonCreateSchedule2
			// 
			this.buttonCreateSchedule2.Location = new System.Drawing.Point(395, 194);
			this.buttonCreateSchedule2.Name = "buttonCreateSchedule2";
			this.buttonCreateSchedule2.Size = new System.Drawing.Size(127, 34);
			this.buttonCreateSchedule2.TabIndex = 10;
			this.buttonCreateSchedule2.Text = "Create Schedule";
			this.buttonCreateSchedule2.UseVisualStyleBackColor = true;
			this.buttonCreateSchedule2.Click += new System.EventHandler(this.buttonCreateSchedule2_Click);
			// 
			// buttonCreateSchedule1
			// 
			this.buttonCreateSchedule1.Location = new System.Drawing.Point(103, 164);
			this.buttonCreateSchedule1.Name = "buttonCreateSchedule1";
			this.buttonCreateSchedule1.Size = new System.Drawing.Size(127, 34);
			this.buttonCreateSchedule1.TabIndex = 9;
			this.buttonCreateSchedule1.Text = "Create Schedule";
			this.buttonCreateSchedule1.UseVisualStyleBackColor = true;
			this.buttonCreateSchedule1.Click += new System.EventHandler(this.buttonCreateSchedule1_Click);
			// 
			// buttonStoreSchedule2
			// 
			this.buttonStoreSchedule2.Location = new System.Drawing.Point(396, 314);
			this.buttonStoreSchedule2.Name = "buttonStoreSchedule2";
			this.buttonStoreSchedule2.Size = new System.Drawing.Size(127, 34);
			this.buttonStoreSchedule2.TabIndex = 12;
			this.buttonStoreSchedule2.Text = "Store Schedule";
			this.buttonStoreSchedule2.UseVisualStyleBackColor = true;
			this.buttonStoreSchedule2.Click += new System.EventHandler(this.buttonStoreSchedule2_Click);
			// 
			// textBoxDsn1
			// 
			this.textBoxDsn1.Location = new System.Drawing.Point(103, 138);
			this.textBoxDsn1.Name = "textBoxDsn1";
			this.textBoxDsn1.Size = new System.Drawing.Size(100, 20);
			this.textBoxDsn1.TabIndex = 13;
			// 
			// textBoxDsn2
			// 
			this.textBoxDsn2.Location = new System.Drawing.Point(393, 70);
			this.textBoxDsn2.Name = "textBoxDsn2";
			this.textBoxDsn2.Size = new System.Drawing.Size(100, 20);
			this.textBoxDsn2.TabIndex = 14;
			// 
			// buttonEdit2
			// 
			this.buttonEdit2.Location = new System.Drawing.Point(395, 274);
			this.buttonEdit2.Name = "buttonEdit2";
			this.buttonEdit2.Size = new System.Drawing.Size(127, 34);
			this.buttonEdit2.TabIndex = 15;
			this.buttonEdit2.Text = "Edit Schedule";
			this.buttonEdit2.UseVisualStyleBackColor = true;
			this.buttonEdit2.Click += new System.EventHandler(this.buttonEdit2_Click);
			// 
			// buttonEdit1
			// 
			this.buttonEdit1.Location = new System.Drawing.Point(104, 319);
			this.buttonEdit1.Name = "buttonEdit1";
			this.buttonEdit1.Size = new System.Drawing.Size(127, 34);
			this.buttonEdit1.TabIndex = 16;
			this.buttonEdit1.Text = "Edit Schedule";
			this.buttonEdit1.UseVisualStyleBackColor = true;
			this.buttonEdit1.Click += new System.EventHandler(this.buttonEdit1_Click);
			// 
			// checkBoxLegacySchedule1
			// 
			this.checkBoxLegacySchedule1.AutoSize = true;
			this.checkBoxLegacySchedule1.Location = new System.Drawing.Point(103, 22);
			this.checkBoxLegacySchedule1.Name = "checkBoxLegacySchedule1";
			this.checkBoxLegacySchedule1.Size = new System.Drawing.Size(109, 17);
			this.checkBoxLegacySchedule1.TabIndex = 21;
			this.checkBoxLegacySchedule1.Text = "Legacy Schedule";
			this.checkBoxLegacySchedule1.UseVisualStyleBackColor = true;
			this.checkBoxLegacySchedule1.CheckedChanged += new System.EventHandler(this.checkBoxLegacySchedule1_CheckedChanged);
			// 
			// checkBoxLegacySchedule2
			// 
			this.checkBoxLegacySchedule2.AutoSize = true;
			this.checkBoxLegacySchedule2.Location = new System.Drawing.Point(393, 22);
			this.checkBoxLegacySchedule2.Name = "checkBoxLegacySchedule2";
			this.checkBoxLegacySchedule2.Size = new System.Drawing.Size(109, 17);
			this.checkBoxLegacySchedule2.TabIndex = 22;
			this.checkBoxLegacySchedule2.Text = "Legacy Schedule";
			this.checkBoxLegacySchedule2.UseVisualStyleBackColor = true;
			this.checkBoxLegacySchedule2.CheckedChanged += new System.EventHandler(this.checkBoxLegacySchedule2_CheckedChanged);
			// 
			// textBoxLegacyPath1
			// 
			this.textBoxLegacyPath1.Location = new System.Drawing.Point(112, 44);
			this.textBoxLegacyPath1.Name = "textBoxLegacyPath1";
			this.textBoxLegacyPath1.Size = new System.Drawing.Size(216, 20);
			this.textBoxLegacyPath1.TabIndex = 23;
			// 
			// textBoxLegacyPath2
			// 
			this.textBoxLegacyPath2.Location = new System.Drawing.Point(409, 44);
			this.textBoxLegacyPath2.Name = "textBoxLegacyPath2";
			this.textBoxLegacyPath2.Size = new System.Drawing.Size(216, 20);
			this.textBoxLegacyPath2.TabIndex = 24;
			// 
			// buttonLoadSchedule2
			// 
			this.buttonLoadSchedule2.Location = new System.Drawing.Point(393, 234);
			this.buttonLoadSchedule2.Name = "buttonLoadSchedule2";
			this.buttonLoadSchedule2.Size = new System.Drawing.Size(127, 34);
			this.buttonLoadSchedule2.TabIndex = 25;
			this.buttonLoadSchedule2.Text = "Load Schedule";
			this.buttonLoadSchedule2.UseVisualStyleBackColor = true;
			this.buttonLoadSchedule2.Click += new System.EventHandler(this.buttonLoadSchedule2_Click);
			// 
			// buttonMergePatterns
			// 
			this.buttonMergePatterns.Location = new System.Drawing.Point(220, 440);
			this.buttonMergePatterns.Name = "buttonMergePatterns";
			this.buttonMergePatterns.Size = new System.Drawing.Size(133, 40);
			this.buttonMergePatterns.TabIndex = 26;
			this.buttonMergePatterns.Text = "Merge Patterns -->";
			this.buttonMergePatterns.UseVisualStyleBackColor = true;
			this.buttonMergePatterns.Click += new System.EventHandler(this.buttonMergePatterns_Click);
			// 
			// buttonDropSchedule1
			// 
			this.buttonDropSchedule1.Location = new System.Drawing.Point(103, 204);
			this.buttonDropSchedule1.Name = "buttonDropSchedule1";
			this.buttonDropSchedule1.Size = new System.Drawing.Size(126, 33);
			this.buttonDropSchedule1.TabIndex = 27;
			this.buttonDropSchedule1.Text = "Drop Schedule";
			this.buttonDropSchedule1.UseVisualStyleBackColor = true;
			this.buttonDropSchedule1.Click += new System.EventHandler(this.buttonDropSchedule1_Click);
			// 
			// checkBoxLoadOldSchedule1
			// 
			this.checkBoxLoadOldSchedule1.AutoSize = true;
			this.checkBoxLoadOldSchedule1.Location = new System.Drawing.Point(103, 256);
			this.checkBoxLoadOldSchedule1.Name = "checkBoxLoadOldSchedule1";
			this.checkBoxLoadOldSchedule1.Size = new System.Drawing.Size(182, 17);
			this.checkBoxLoadOldSchedule1.TabIndex = 28;
			this.checkBoxLoadOldSchedule1.Text = "Load Database Schedule(merge)";
			this.checkBoxLoadOldSchedule1.UseVisualStyleBackColor = true;
			// 
			// checkBoxUseEPaperCardset
			// 
			this.checkBoxUseEPaperCardset.AutoSize = true;
			this.checkBoxUseEPaperCardset.Location = new System.Drawing.Point(218, 22);
			this.checkBoxUseEPaperCardset.Name = "checkBoxUseEPaperCardset";
			this.checkBoxUseEPaperCardset.Size = new System.Drawing.Size(130, 17);
			this.checkBoxUseEPaperCardset.TabIndex = 29;
			this.checkBoxUseEPaperCardset.Text = "Use E-Paper Cardsets";
			this.checkBoxUseEPaperCardset.UseVisualStyleBackColor = true;
			// 
			// textBoxBingoINI
			// 
			this.textBoxBingoINI.Location = new System.Drawing.Point(112, 70);
			this.textBoxBingoINI.Name = "textBoxBingoINI";
			this.textBoxBingoINI.Size = new System.Drawing.Size(216, 20);
			this.textBoxBingoINI.TabIndex = 30;
			// 
			// textBoxFtnSysINI
			// 
			this.textBoxFtnSysINI.Location = new System.Drawing.Point(112, 96);
			this.textBoxFtnSysINI.Name = "textBoxFtnSysINI";
			this.textBoxFtnSysINI.Size = new System.Drawing.Size(216, 20);
			this.textBoxFtnSysINI.TabIndex = 31;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(13, 50);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(77, 13);
			this.label1.TabIndex = 32;
			this.label1.Text = "Schedule Path";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(13, 77);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(51, 13);
			this.label2.TabIndex = 33;
			this.label2.Text = "Bingo INI";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(13, 99);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(56, 13);
			this.label3.TabIndex = 34;
			this.label3.Text = "FtnSys INI";
			// 
			// Converter
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(727, 531);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.textBoxFtnSysINI);
			this.Controls.Add(this.textBoxBingoINI);
			this.Controls.Add(this.checkBoxUseEPaperCardset);
			this.Controls.Add(this.checkBoxLoadOldSchedule1);
			this.Controls.Add(this.buttonDropSchedule1);
			this.Controls.Add(this.buttonMergePatterns);
			this.Controls.Add(this.buttonLoadSchedule2);
			this.Controls.Add(this.textBoxLegacyPath2);
			this.Controls.Add(this.textBoxLegacyPath1);
			this.Controls.Add(this.checkBoxLegacySchedule2);
			this.Controls.Add(this.checkBoxLegacySchedule1);
			this.Controls.Add(this.buttonEdit1);
			this.Controls.Add(this.buttonEdit2);
			this.Controls.Add(this.textBoxDsn2);
			this.Controls.Add(this.textBoxDsn1);
			this.Controls.Add(this.buttonStoreSchedule2);
			this.Controls.Add(this.buttonCreateSchedule2);
			this.Controls.Add(this.buttonCreateSchedule1);
			this.Controls.Add(this.buttonConvert);
			this.Controls.Add(this.labelStatus2);
			this.Controls.Add(this.labelStatus1);
			this.Controls.Add(this.buttonLoad1);
			this.Name = "Converter";
			this.Text = "Schedule Converter";
			this.Load += new System.EventHandler(this.Converter_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button buttonLoad1;
		private System.Windows.Forms.Label labelStatus1;
		private System.Windows.Forms.Label labelStatus2;
		private System.Windows.Forms.Button buttonConvert;
		private System.Windows.Forms.Button buttonCreateSchedule2;
		private System.Windows.Forms.Button buttonCreateSchedule1;
		private System.Windows.Forms.Button buttonStoreSchedule2;
		private System.Windows.Forms.TextBox textBoxDsn1;
		private System.Windows.Forms.TextBox textBoxDsn2;
		private System.Windows.Forms.Button buttonEdit2;
		private System.Windows.Forms.Button buttonEdit1;
		private System.Windows.Forms.CheckBox checkBoxLegacySchedule1;
		private System.Windows.Forms.CheckBox checkBoxLegacySchedule2;
		private System.Windows.Forms.TextBox textBoxLegacyPath1;
		private System.Windows.Forms.TextBox textBoxLegacyPath2;
		private System.Windows.Forms.Button buttonLoadSchedule2;
		private System.Windows.Forms.Button buttonMergePatterns;
		private System.Windows.Forms.Button buttonDropSchedule1;
		private System.Windows.Forms.CheckBox checkBoxLoadOldSchedule1;
		private System.Windows.Forms.CheckBox checkBoxUseEPaperCardset;
		private System.Windows.Forms.TextBox textBoxBingoINI;
		private System.Windows.Forms.TextBox textBoxFtnSysINI;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
	}
}

