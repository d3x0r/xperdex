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
			this.checkBoxUseGuid1 = new System.Windows.Forms.CheckBox();
			this.checkBoxPackToPrizes1 = new System.Windows.Forms.CheckBox();
			this.checkBoxPackToPrizes2 = new System.Windows.Forms.CheckBox();
			this.checkBoxUseGuid2 = new System.Windows.Forms.CheckBox();
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
			this.checkBoxGameToSessions1 = new System.Windows.Forms.CheckBox();
			this.checkBoxGameToSessions2 = new System.Windows.Forms.CheckBox();
			this.checkBoxLegacySchedule1 = new System.Windows.Forms.CheckBox();
			this.checkBoxLegacySchedule2 = new System.Windows.Forms.CheckBox();
			this.textBoxLegacyPath1 = new System.Windows.Forms.TextBox();
			this.textBoxLegacyPath2 = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// buttonLoad1
			// 
			this.buttonLoad1.Location = new System.Drawing.Point( 102, 234 );
			this.buttonLoad1.Name = "buttonLoad1";
			this.buttonLoad1.Size = new System.Drawing.Size( 127, 34 );
			this.buttonLoad1.TabIndex = 0;
			this.buttonLoad1.Text = "Load Schedule";
			this.buttonLoad1.UseVisualStyleBackColor = true;
			this.buttonLoad1.Click += new System.EventHandler( this.buttonLoad1_Click );
			// 
			// checkBoxUseGuid1
			// 
			this.checkBoxUseGuid1.AutoSize = true;
			this.checkBoxUseGuid1.Location = new System.Drawing.Point( 101, 111 );
			this.checkBoxUseGuid1.Name = "checkBoxUseGuid1";
			this.checkBoxUseGuid1.Size = new System.Drawing.Size( 75, 17 );
			this.checkBoxUseGuid1.TabIndex = 1;
			this.checkBoxUseGuid1.Text = "Uses Guid";
			this.checkBoxUseGuid1.UseVisualStyleBackColor = true;
			// 
			// checkBoxPackToPrizes1
			// 
			this.checkBoxPackToPrizes1.AutoSize = true;
			this.checkBoxPackToPrizes1.Location = new System.Drawing.Point( 101, 134 );
			this.checkBoxPackToPrizes1.Name = "checkBoxPackToPrizes1";
			this.checkBoxPackToPrizes1.Size = new System.Drawing.Size( 127, 17 );
			this.checkBoxPackToPrizes1.TabIndex = 2;
			this.checkBoxPackToPrizes1.Text = "Packs relate to prizes";
			this.checkBoxPackToPrizes1.UseVisualStyleBackColor = true;
			// 
			// checkBoxPackToPrizes2
			// 
			this.checkBoxPackToPrizes2.AutoSize = true;
			this.checkBoxPackToPrizes2.Location = new System.Drawing.Point( 345, 134 );
			this.checkBoxPackToPrizes2.Name = "checkBoxPackToPrizes2";
			this.checkBoxPackToPrizes2.Size = new System.Drawing.Size( 127, 17 );
			this.checkBoxPackToPrizes2.TabIndex = 5;
			this.checkBoxPackToPrizes2.Text = "Packs relate to prizes";
			this.checkBoxPackToPrizes2.UseVisualStyleBackColor = true;
			// 
			// checkBoxUseGuid2
			// 
			this.checkBoxUseGuid2.AutoSize = true;
			this.checkBoxUseGuid2.Location = new System.Drawing.Point( 345, 111 );
			this.checkBoxUseGuid2.Name = "checkBoxUseGuid2";
			this.checkBoxUseGuid2.Size = new System.Drawing.Size( 75, 17 );
			this.checkBoxUseGuid2.TabIndex = 4;
			this.checkBoxUseGuid2.Text = "Uses Guid";
			this.checkBoxUseGuid2.UseVisualStyleBackColor = true;
			// 
			// labelStatus1
			// 
			this.labelStatus1.AutoSize = true;
			this.labelStatus1.Location = new System.Drawing.Point( 100, 356 );
			this.labelStatus1.Name = "labelStatus1";
			this.labelStatus1.Size = new System.Drawing.Size( 49, 13 );
			this.labelStatus1.TabIndex = 6;
			this.labelStatus1.Text = "Status....";
			// 
			// labelStatus2
			// 
			this.labelStatus2.AutoSize = true;
			this.labelStatus2.Location = new System.Drawing.Point( 346, 356 );
			this.labelStatus2.Name = "labelStatus2";
			this.labelStatus2.Size = new System.Drawing.Size( 49, 13 );
			this.labelStatus2.TabIndex = 7;
			this.labelStatus2.Text = "Status....";
			// 
			// buttonConvert
			// 
			this.buttonConvert.Location = new System.Drawing.Point( 220, 394 );
			this.buttonConvert.Name = "buttonConvert";
			this.buttonConvert.Size = new System.Drawing.Size( 133, 40 );
			this.buttonConvert.TabIndex = 8;
			this.buttonConvert.Text = "Convert ->";
			this.buttonConvert.UseVisualStyleBackColor = true;
			this.buttonConvert.Click += new System.EventHandler( this.buttonConvert_Click );
			// 
			// buttonCreateSchedule2
			// 
			this.buttonCreateSchedule2.Location = new System.Drawing.Point( 347, 194 );
			this.buttonCreateSchedule2.Name = "buttonCreateSchedule2";
			this.buttonCreateSchedule2.Size = new System.Drawing.Size( 127, 34 );
			this.buttonCreateSchedule2.TabIndex = 10;
			this.buttonCreateSchedule2.Text = "Create Schedule";
			this.buttonCreateSchedule2.UseVisualStyleBackColor = true;
			this.buttonCreateSchedule2.Click += new System.EventHandler( this.buttonCreateSchedule2_Click );
			// 
			// buttonCreateSchedule1
			// 
			this.buttonCreateSchedule1.Location = new System.Drawing.Point( 102, 194 );
			this.buttonCreateSchedule1.Name = "buttonCreateSchedule1";
			this.buttonCreateSchedule1.Size = new System.Drawing.Size( 127, 34 );
			this.buttonCreateSchedule1.TabIndex = 9;
			this.buttonCreateSchedule1.Text = "Create Schedule";
			this.buttonCreateSchedule1.UseVisualStyleBackColor = true;
			this.buttonCreateSchedule1.Click += new System.EventHandler( this.buttonCreateSchedule1_Click );
			// 
			// buttonStoreSchedule2
			// 
			this.buttonStoreSchedule2.Location = new System.Drawing.Point( 347, 274 );
			this.buttonStoreSchedule2.Name = "buttonStoreSchedule2";
			this.buttonStoreSchedule2.Size = new System.Drawing.Size( 127, 34 );
			this.buttonStoreSchedule2.TabIndex = 12;
			this.buttonStoreSchedule2.Text = "Store Schedule";
			this.buttonStoreSchedule2.UseVisualStyleBackColor = true;
			this.buttonStoreSchedule2.Click += new System.EventHandler( this.buttonStoreSchedule2_Click );
			// 
			// textBoxDsn1
			// 
			this.textBoxDsn1.Location = new System.Drawing.Point( 101, 75 );
			this.textBoxDsn1.Name = "textBoxDsn1";
			this.textBoxDsn1.Size = new System.Drawing.Size( 100, 20 );
			this.textBoxDsn1.TabIndex = 13;
			// 
			// textBoxDsn2
			// 
			this.textBoxDsn2.Location = new System.Drawing.Point( 345, 70 );
			this.textBoxDsn2.Name = "textBoxDsn2";
			this.textBoxDsn2.Size = new System.Drawing.Size( 100, 20 );
			this.textBoxDsn2.TabIndex = 14;
			// 
			// buttonEdit2
			// 
			this.buttonEdit2.Location = new System.Drawing.Point( 346, 234 );
			this.buttonEdit2.Name = "buttonEdit2";
			this.buttonEdit2.Size = new System.Drawing.Size( 127, 34 );
			this.buttonEdit2.TabIndex = 15;
			this.buttonEdit2.Text = "Edit Schedule";
			this.buttonEdit2.UseVisualStyleBackColor = true;
			this.buttonEdit2.Click += new System.EventHandler( this.buttonEdit2_Click );
			// 
			// buttonEdit1
			// 
			this.buttonEdit1.Location = new System.Drawing.Point( 102, 274 );
			this.buttonEdit1.Name = "buttonEdit1";
			this.buttonEdit1.Size = new System.Drawing.Size( 127, 34 );
			this.buttonEdit1.TabIndex = 16;
			this.buttonEdit1.Text = "Edit Schedule";
			this.buttonEdit1.UseVisualStyleBackColor = true;
			this.buttonEdit1.Click += new System.EventHandler( this.buttonEdit1_Click );
			// 
			// checkBoxGameToSessions1
			// 
			this.checkBoxGameToSessions1.AutoSize = true;
			this.checkBoxGameToSessions1.Location = new System.Drawing.Point( 101, 157 );
			this.checkBoxGameToSessions1.Name = "checkBoxGameToSessions1";
			this.checkBoxGameToSessions1.Size = new System.Drawing.Size( 154, 17 );
			this.checkBoxGameToSessions1.TabIndex = 17;
			this.checkBoxGameToSessions1.Text = "Games Relate To Sessions";
			this.checkBoxGameToSessions1.UseVisualStyleBackColor = true;
			// 
			// checkBoxGameToSessions2
			// 
			this.checkBoxGameToSessions2.AutoSize = true;
			this.checkBoxGameToSessions2.Location = new System.Drawing.Point( 345, 157 );
			this.checkBoxGameToSessions2.Name = "checkBoxGameToSessions2";
			this.checkBoxGameToSessions2.Size = new System.Drawing.Size( 154, 17 );
			this.checkBoxGameToSessions2.TabIndex = 18;
			this.checkBoxGameToSessions2.Text = "Games Relate To Sessions";
			this.checkBoxGameToSessions2.UseVisualStyleBackColor = true;
			// 
			// checkBoxLegacySchedule1
			// 
			this.checkBoxLegacySchedule1.AutoSize = true;
			this.checkBoxLegacySchedule1.Location = new System.Drawing.Point( 103, 22 );
			this.checkBoxLegacySchedule1.Name = "checkBoxLegacySchedule1";
			this.checkBoxLegacySchedule1.Size = new System.Drawing.Size( 109, 17 );
			this.checkBoxLegacySchedule1.TabIndex = 21;
			this.checkBoxLegacySchedule1.Text = "Legacy Schedule";
			this.checkBoxLegacySchedule1.UseVisualStyleBackColor = true;
			this.checkBoxLegacySchedule1.CheckedChanged += new System.EventHandler( this.checkBoxLegacySchedule1_CheckedChanged );
			// 
			// checkBoxLegacySchedule2
			// 
			this.checkBoxLegacySchedule2.AutoSize = true;
			this.checkBoxLegacySchedule2.Location = new System.Drawing.Point( 345, 22 );
			this.checkBoxLegacySchedule2.Name = "checkBoxLegacySchedule2";
			this.checkBoxLegacySchedule2.Size = new System.Drawing.Size( 109, 17 );
			this.checkBoxLegacySchedule2.TabIndex = 22;
			this.checkBoxLegacySchedule2.Text = "Legacy Schedule";
			this.checkBoxLegacySchedule2.UseVisualStyleBackColor = true;
			this.checkBoxLegacySchedule2.CheckedChanged += new System.EventHandler( this.checkBoxLegacySchedule2_CheckedChanged );
			// 
			// textBoxLegacyPath1
			// 
			this.textBoxLegacyPath1.Location = new System.Drawing.Point( 112, 44 );
			this.textBoxLegacyPath1.Name = "textBoxLegacyPath1";
			this.textBoxLegacyPath1.Size = new System.Drawing.Size( 216, 20 );
			this.textBoxLegacyPath1.TabIndex = 23;
			// 
			// textBoxLegacyPath2
			// 
			this.textBoxLegacyPath2.Location = new System.Drawing.Point( 361, 44 );
			this.textBoxLegacyPath2.Name = "textBoxLegacyPath2";
			this.textBoxLegacyPath2.Size = new System.Drawing.Size( 216, 20 );
			this.textBoxLegacyPath2.TabIndex = 24;
			// 
			// Converter
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size( 727, 448 );
			this.Controls.Add( this.textBoxLegacyPath2 );
			this.Controls.Add( this.textBoxLegacyPath1 );
			this.Controls.Add( this.checkBoxLegacySchedule2 );
			this.Controls.Add( this.checkBoxLegacySchedule1 );
			this.Controls.Add( this.checkBoxGameToSessions2 );
			this.Controls.Add( this.checkBoxGameToSessions1 );
			this.Controls.Add( this.buttonEdit1 );
			this.Controls.Add( this.buttonEdit2 );
			this.Controls.Add( this.textBoxDsn2 );
			this.Controls.Add( this.textBoxDsn1 );
			this.Controls.Add( this.buttonStoreSchedule2 );
			this.Controls.Add( this.buttonCreateSchedule2 );
			this.Controls.Add( this.buttonCreateSchedule1 );
			this.Controls.Add( this.buttonConvert );
			this.Controls.Add( this.labelStatus2 );
			this.Controls.Add( this.labelStatus1 );
			this.Controls.Add( this.checkBoxPackToPrizes2 );
			this.Controls.Add( this.checkBoxUseGuid2 );
			this.Controls.Add( this.checkBoxPackToPrizes1 );
			this.Controls.Add( this.checkBoxUseGuid1 );
			this.Controls.Add( this.buttonLoad1 );
			this.Name = "Converter";
			this.Text = "Schedule Converter";
			this.Load += new System.EventHandler( this.Converter_Load );
			this.ResumeLayout( false );
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button buttonLoad1;
		private System.Windows.Forms.CheckBox checkBoxUseGuid1;
		private System.Windows.Forms.CheckBox checkBoxPackToPrizes1;
		private System.Windows.Forms.CheckBox checkBoxPackToPrizes2;
		private System.Windows.Forms.CheckBox checkBoxUseGuid2;
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
        private System.Windows.Forms.CheckBox checkBoxGameToSessions1;
        private System.Windows.Forms.CheckBox checkBoxGameToSessions2;
		private System.Windows.Forms.CheckBox checkBoxLegacySchedule1;
		private System.Windows.Forms.CheckBox checkBoxLegacySchedule2;
		private System.Windows.Forms.TextBox textBoxLegacyPath1;
		private System.Windows.Forms.TextBox textBoxLegacyPath2;
	}
}

