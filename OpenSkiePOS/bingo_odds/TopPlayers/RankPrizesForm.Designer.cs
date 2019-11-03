namespace TopPlayers
{
	partial class RankPrizesForm
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
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
			this.dataGridViewRankPrizes = new System.Windows.Forms.DataGridView();
			this.buttonClose = new System.Windows.Forms.Button();
			this.buttonSave = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewRankPrizes)).BeginInit();
			this.SuspendLayout();
			// 
			// dataGridViewRankPrizes
			// 
			this.dataGridViewRankPrizes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.dataGridViewRankPrizes.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
			this.dataGridViewRankPrizes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
			dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
			dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.dataGridViewRankPrizes.DefaultCellStyle = dataGridViewCellStyle2;
			this.dataGridViewRankPrizes.Location = new System.Drawing.Point(28, 26);
			this.dataGridViewRankPrizes.Name = "dataGridViewRankPrizes";
			this.dataGridViewRankPrizes.RowTemplate.Height = 30;
			this.dataGridViewRankPrizes.Size = new System.Drawing.Size(575, 686);
			this.dataGridViewRankPrizes.TabIndex = 0;
			// 
			// buttonClose
			// 
			this.buttonClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.buttonClose.Location = new System.Drawing.Point(811, 133);
			this.buttonClose.Name = "buttonClose";
			this.buttonClose.Size = new System.Drawing.Size(149, 49);
			this.buttonClose.TabIndex = 1;
			this.buttonClose.Text = "Cancel";
			this.buttonClose.UseVisualStyleBackColor = true;
			this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
			// 
			// buttonSave
			// 
			this.buttonSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.buttonSave.Location = new System.Drawing.Point(656, 133);
			this.buttonSave.Name = "buttonSave";
			this.buttonSave.Size = new System.Drawing.Size(149, 49);
			this.buttonSave.TabIndex = 1;
			this.buttonSave.Text = "Save";
			this.buttonSave.UseVisualStyleBackColor = true;
			this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
			// 
			// RankPrizesForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1016, 734);
			this.Controls.Add(this.buttonSave);
			this.Controls.Add(this.buttonClose);
			this.Controls.Add(this.dataGridViewRankPrizes);
			this.Name = "RankPrizesForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "RankPrizesForm";
			this.Load += new System.EventHandler(this.RankPrizesForm_Load);
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.RankPrizesForm_FormClosing);
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewRankPrizes)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.DataGridView dataGridViewRankPrizes;
		private System.Windows.Forms.Button buttonClose;
		private System.Windows.Forms.Button buttonSave;
	}
}