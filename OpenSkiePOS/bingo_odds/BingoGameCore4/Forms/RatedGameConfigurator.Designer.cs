namespace BingoGameCore4.Forms
{
	partial class RatedGameConfigurator
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
			this.dataGridViewGames = new System.Windows.Forms.DataGridView();
			this.comboBoxSession = new System.Windows.Forms.ComboBox();
			this.button1 = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewGames)).BeginInit();
			this.SuspendLayout();
			// 
			// dataGridViewGames
			// 
			this.dataGridViewGames.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dataGridViewGames.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridViewGames.Location = new System.Drawing.Point(12, 85);
			this.dataGridViewGames.Name = "dataGridViewGames";
			this.dataGridViewGames.Size = new System.Drawing.Size(356, 318);
			this.dataGridViewGames.TabIndex = 0;
			// 
			// comboBoxSession
			// 
			this.comboBoxSession.FormattingEnabled = true;
			this.comboBoxSession.Location = new System.Drawing.Point(13, 35);
			this.comboBoxSession.Name = "comboBoxSession";
			this.comboBoxSession.Size = new System.Drawing.Size(188, 21);
			this.comboBoxSession.TabIndex = 1;
			this.comboBoxSession.SelectedIndexChanged += new System.EventHandler(this.comboBoxSession_SelectedIndexChanged);
			// 
			// button1
			// 
			this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.button1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.button1.Location = new System.Drawing.Point(293, 35);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 23);
			this.button1.TabIndex = 2;
			this.button1.Text = "Done";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(13, 13);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(89, 13);
			this.label1.TabIndex = 3;
			this.label1.Text = "Select Session....";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(12, 66);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(115, 13);
			this.label2.TabIndex = 4;
			this.label2.Text = "Select Games To Rate";
			// 
			// RatedGameConfigurator
			// 
			this.AcceptButton = this.button1;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.button1;
			this.ClientSize = new System.Drawing.Size(381, 418);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.comboBoxSession);
			this.Controls.Add(this.dataGridViewGames);
			this.Name = "RatedGameConfigurator";
			this.Text = "Rated Game Selector";
			this.Load += new System.EventHandler(this.RatedGameConfigurator_Load);
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewGames)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.DataGridView dataGridViewGames;
		private System.Windows.Forms.ComboBox comboBoxSession;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
	}
}