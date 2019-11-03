namespace OpenSkieScheduler3.Controls.Forms
{
	partial class CardsetRangeEditor
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
			this.CardsetList = new System.Windows.Forms.ListBox();
			this.label1 = new System.Windows.Forms.Label();
			this.CardsetRanges = new System.Windows.Forms.DataGridView();
			this.label2 = new System.Windows.Forms.Label();
			this.button1 = new System.Windows.Forms.Button();
			this.listBoxPacksInRange = new System.Windows.Forms.ListBox();
			this.label3 = new System.Windows.Forms.Label();
			( (System.ComponentModel.ISupportInitialize)( this.CardsetRanges ) ).BeginInit();
			this.SuspendLayout();
			// 
			// CardsetList
			// 
			this.CardsetList.FormattingEnabled = true;
			this.CardsetList.Location = new System.Drawing.Point( 12, 49 );
			this.CardsetList.Name = "CardsetList";
			this.CardsetList.Size = new System.Drawing.Size( 194, 82 );
			this.CardsetList.TabIndex = 0;
			this.CardsetList.SelectedIndexChanged += new System.EventHandler( this.CardsetList_SelectedIndexChanged );
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point( 12, 26 );
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size( 76, 13 );
			this.label1.TabIndex = 1;
			this.label1.Text = "Select Cardset";
			// 
			// CardsetRanges
			// 
			this.CardsetRanges.BackgroundColor = System.Drawing.SystemColors.Window;
			this.CardsetRanges.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.CardsetRanges.Location = new System.Drawing.Point( 12, 165 );
			this.CardsetRanges.Name = "CardsetRanges";
			this.CardsetRanges.Size = new System.Drawing.Size( 395, 236 );
			this.CardsetRanges.TabIndex = 2;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point( 12, 149 );
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size( 129, 13 );
			this.label2.TabIndex = 7;
			this.label2.Text = "Define Cardset Ranges....";
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point( 213, 49 );
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size( 75, 37 );
			this.button1.TabIndex = 12;
			this.button1.Text = "Edit\r\nCardsets";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler( this.button1_Click );
			// 
			// listBoxPacksInRange
			// 
			this.listBoxPacksInRange.FormattingEnabled = true;
			this.listBoxPacksInRange.Location = new System.Drawing.Point( 456, 165 );
			this.listBoxPacksInRange.Name = "listBoxPacksInRange";
			this.listBoxPacksInRange.Size = new System.Drawing.Size( 218, 238 );
			this.listBoxPacksInRange.TabIndex = 13;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point( 453, 149 );
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size( 116, 13 );
			this.label3.TabIndex = 14;
			this.label3.Text = "Packs Using this range";
			// 
			// CardsetRangeEditor
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size( 734, 427 );
			this.Controls.Add( this.label3 );
			this.Controls.Add( this.listBoxPacksInRange );
			this.Controls.Add( this.button1 );
			this.Controls.Add( this.label2 );
			this.Controls.Add( this.CardsetRanges );
			this.Controls.Add( this.label1 );
			this.Controls.Add( this.CardsetList );
			this.Name = "CardsetRangeEditor";
			this.Text = "Paper Cardset Range Editor";
			this.Load += new System.EventHandler( this.CardsetRangeEditor_Load );
			( (System.ComponentModel.ISupportInitialize)( this.CardsetRanges ) ).EndInit();
			this.ResumeLayout( false );
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ListBox CardsetList;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.DataGridView CardsetRanges;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.ListBox listBoxPacksInRange;
		private System.Windows.Forms.Label label3;
	}
}