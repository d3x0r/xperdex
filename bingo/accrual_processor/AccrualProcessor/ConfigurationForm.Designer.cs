namespace ECube.AccrualProcessor
{
	partial class ConfigurationForm
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
			this.buttonEditAccrual = new System.Windows.Forms.Button();
			this.listBoxAccruals = new System.Windows.Forms.ListBox();
			this.buttonApplyChanges = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.dataGridViewSesSlotConfig = new System.Windows.Forms.DataGridView();
			this.buttonSaveAccruals = new System.Windows.Forms.Button();
			this.buttonLoadAccruals = new System.Windows.Forms.Button();
			this.buttonReloadAllGroups = new System.Windows.Forms.Button();
			this.buttonRenameAccrual = new System.Windows.Forms.Button();
			this.button3 = new System.Windows.Forms.Button();
			this.buttonForkAccrual = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewSesSlotConfig)).BeginInit();
			this.SuspendLayout();
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(22, 44);
			this.button1.Margin = new System.Windows.Forms.Padding(6);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(198, 76);
			this.button1.TabIndex = 2;
			this.button1.Text = "Create Accrual";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// buttonEditAccrual
			// 
			this.buttonEditAccrual.Location = new System.Drawing.Point(680, 44);
			this.buttonEditAccrual.Margin = new System.Windows.Forms.Padding(6);
			this.buttonEditAccrual.Name = "buttonEditAccrual";
			this.buttonEditAccrual.Size = new System.Drawing.Size(244, 47);
			this.buttonEditAccrual.TabIndex = 4;
			this.buttonEditAccrual.Text = "Edit Accrual";
			this.buttonEditAccrual.UseVisualStyleBackColor = true;
			this.buttonEditAccrual.Click += new System.EventHandler(this.button2_Click);
			// 
			// listBoxAccruals
			// 
			this.listBoxAccruals.FormattingEnabled = true;
			this.listBoxAccruals.ItemHeight = 24;
			this.listBoxAccruals.Location = new System.Drawing.Point(414, 44);
			this.listBoxAccruals.Margin = new System.Windows.Forms.Padding(6);
			this.listBoxAccruals.Name = "listBoxAccruals";
			this.listBoxAccruals.Size = new System.Drawing.Size(252, 436);
			this.listBoxAccruals.TabIndex = 5;
			this.listBoxAccruals.SelectedIndexChanged += new System.EventHandler(this.listBoxAccruals_SelectedIndexChanged);
			// 
			// buttonApplyChanges
			// 
			this.buttonApplyChanges.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonApplyChanges.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.buttonApplyChanges.Location = new System.Drawing.Point(761, 516);
			this.buttonApplyChanges.Margin = new System.Windows.Forms.Padding(6);
			this.buttonApplyChanges.Name = "buttonApplyChanges";
			this.buttonApplyChanges.Size = new System.Drawing.Size(176, 64);
			this.buttonApplyChanges.TabIndex = 16;
			this.buttonApplyChanges.Text = "Done";
			this.buttonApplyChanges.UseVisualStyleBackColor = true;
			this.buttonApplyChanges.Click += new System.EventHandler(this.buttonApplyChanges_Click);
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(22, 132);
			this.button2.Margin = new System.Windows.Forms.Padding(6);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(198, 76);
			this.button2.TabIndex = 17;
			this.button2.Text = "Set Sessions to Use";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click_1);
			// 
			// dataGridViewSesSlotConfig
			// 
			this.dataGridViewSesSlotConfig.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridViewSesSlotConfig.Location = new System.Drawing.Point(22, 218);
			this.dataGridViewSesSlotConfig.Margin = new System.Windows.Forms.Padding(6);
			this.dataGridViewSesSlotConfig.Name = "dataGridViewSesSlotConfig";
			this.dataGridViewSesSlotConfig.Size = new System.Drawing.Size(347, 266);
			this.dataGridViewSesSlotConfig.TabIndex = 18;
			// 
			// buttonSaveAccruals
			// 
			this.buttonSaveAccruals.Location = new System.Drawing.Point(680, 344);
			this.buttonSaveAccruals.Margin = new System.Windows.Forms.Padding(6);
			this.buttonSaveAccruals.Name = "buttonSaveAccruals";
			this.buttonSaveAccruals.Size = new System.Drawing.Size(165, 62);
			this.buttonSaveAccruals.TabIndex = 19;
			this.buttonSaveAccruals.Text = "Save Accruals to File";
			this.buttonSaveAccruals.UseVisualStyleBackColor = true;
			this.buttonSaveAccruals.Click += new System.EventHandler(this.buttonSaveAccruals_Click);
			// 
			// buttonLoadAccruals
			// 
			this.buttonLoadAccruals.Location = new System.Drawing.Point(680, 418);
			this.buttonLoadAccruals.Margin = new System.Windows.Forms.Padding(6);
			this.buttonLoadAccruals.Name = "buttonLoadAccruals";
			this.buttonLoadAccruals.Size = new System.Drawing.Size(165, 66);
			this.buttonLoadAccruals.TabIndex = 20;
			this.buttonLoadAccruals.Text = "Load Accruals from File";
			this.buttonLoadAccruals.UseVisualStyleBackColor = true;
			this.buttonLoadAccruals.Click += new System.EventHandler(this.buttonLoadAccruals_Click);
			// 
			// buttonReloadAllGroups
			// 
			this.buttonReloadAllGroups.Location = new System.Drawing.Point(680, 234);
			this.buttonReloadAllGroups.Margin = new System.Windows.Forms.Padding(6);
			this.buttonReloadAllGroups.Name = "buttonReloadAllGroups";
			this.buttonReloadAllGroups.Size = new System.Drawing.Size(165, 70);
			this.buttonReloadAllGroups.TabIndex = 21;
			this.buttonReloadAllGroups.Text = "Load ALL Groups";
			this.buttonReloadAllGroups.UseVisualStyleBackColor = true;
			this.buttonReloadAllGroups.Click += new System.EventHandler(this.buttonReloadAllGroups_Click);
			// 
			// buttonRenameAccrual
			// 
			this.buttonRenameAccrual.Location = new System.Drawing.Point(680, 103);
			this.buttonRenameAccrual.Margin = new System.Windows.Forms.Padding(6);
			this.buttonRenameAccrual.Name = "buttonRenameAccrual";
			this.buttonRenameAccrual.Size = new System.Drawing.Size(244, 45);
			this.buttonRenameAccrual.TabIndex = 22;
			this.buttonRenameAccrual.Text = "Rename Accrual";
			this.buttonRenameAccrual.UseVisualStyleBackColor = true;
			this.buttonRenameAccrual.Click += new System.EventHandler(this.buttonRenameAccrual_Click);
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(232, 44);
			this.button3.Margin = new System.Windows.Forms.Padding(6);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(137, 76);
			this.button3.TabIndex = 23;
			this.button3.Text = "Delete Accrual";
			this.button3.UseVisualStyleBackColor = true;
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// buttonForkAccrual
			// 
			this.buttonForkAccrual.Location = new System.Drawing.Point(680, 163);
			this.buttonForkAccrual.Margin = new System.Windows.Forms.Padding(6);
			this.buttonForkAccrual.Name = "buttonForkAccrual";
			this.buttonForkAccrual.Size = new System.Drawing.Size(244, 45);
			this.buttonForkAccrual.TabIndex = 24;
			this.buttonForkAccrual.Text = "Fork Accrual";
			this.buttonForkAccrual.UseVisualStyleBackColor = true;
			this.buttonForkAccrual.Click += new System.EventHandler(this.buttonForkAccrual_Click);
			// 
			// ConfigurationForm
			// 
			this.AcceptButton = this.buttonApplyChanges;
			this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.buttonApplyChanges;
			this.ClientSize = new System.Drawing.Size(959, 604);
			this.Controls.Add(this.buttonForkAccrual);
			this.Controls.Add(this.button3);
			this.Controls.Add(this.buttonRenameAccrual);
			this.Controls.Add(this.buttonReloadAllGroups);
			this.Controls.Add(this.buttonLoadAccruals);
			this.Controls.Add(this.buttonSaveAccruals);
			this.Controls.Add(this.dataGridViewSesSlotConfig);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.buttonApplyChanges);
			this.Controls.Add(this.listBoxAccruals);
			this.Controls.Add(this.buttonEditAccrual);
			this.Controls.Add(this.button1);
			this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Margin = new System.Windows.Forms.Padding(6);
			this.Name = "ConfigurationForm";
			this.Text = "Configuration";
			this.Load += new System.EventHandler(this.ConfigurationForm_Load);
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewSesSlotConfig)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button buttonEditAccrual;
		private System.Windows.Forms.ListBox listBoxAccruals;
		private System.Windows.Forms.Button buttonApplyChanges;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.DataGridView dataGridViewSesSlotConfig;
		private System.Windows.Forms.Button buttonSaveAccruals;
		private System.Windows.Forms.Button buttonLoadAccruals;
		private System.Windows.Forms.Button buttonReloadAllGroups;
		private System.Windows.Forms.Button buttonRenameAccrual;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.Button buttonForkAccrual;
	}
}