namespace BingoGameCore4.Controls.Patterns
{
	partial class ShowExpandedPattern
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
            this.currentPatternScroller2 = new BingoGameCore4.Controls.Patterns.CurrentPatternScroller();
            this.currentPatternScroller1 = new BingoGameCore4.Controls.Patterns.CurrentPatternScroller();
			this.patternBlockGroup1 = new BingoGameCore4.Controls.Patterns.PatternBlockGroup();
			this.label1 = new System.Windows.Forms.Label();
			this.textBoxCount = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point( 439, 370 );
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size( 75, 23 );
			this.button1.TabIndex = 20;
			this.button1.Text = "Done";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler( this.button1_Click );
			// 
			// currentPatternScroller2
			// 
			this.currentPatternScroller2.BackColor = System.Drawing.Color.Transparent;
			this.currentPatternScroller2.Composite = false;
			this.currentPatternScroller2.Location = new System.Drawing.Point( 422, 152 );
			this.currentPatternScroller2.Movable = false;
			this.currentPatternScroller2.Name = "currentPatternScroller2";
			this.currentPatternScroller2.Pattern = null;
			this.currentPatternScroller2.Rate = 250;
			this.currentPatternScroller2.Size = new System.Drawing.Size( 92, 89 );
			this.currentPatternScroller2.TabIndex = 19;
			// 
			// currentPatternScroller1
			// 
			this.currentPatternScroller1.BackColor = System.Drawing.Color.Transparent;
			this.currentPatternScroller1.Composite = false;
			this.currentPatternScroller1.Location = new System.Drawing.Point( 422, 57 );
			this.currentPatternScroller1.Movable = false;
			this.currentPatternScroller1.Name = "currentPatternScroller1";
			this.currentPatternScroller1.Pattern = null;
			this.currentPatternScroller1.Rate = 250;
			this.currentPatternScroller1.Size = new System.Drawing.Size( 92, 89 );
			this.currentPatternScroller1.TabIndex = 18;
			// 
			// patternBlockGroup1
			// 
			this.patternBlockGroup1.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom )
						| System.Windows.Forms.AnchorStyles.Left )
						| System.Windows.Forms.AnchorStyles.Right ) ) );
			this.patternBlockGroup1.AutoScroll = true;
			this.patternBlockGroup1.BackColor = System.Drawing.Color.Transparent;
			this.patternBlockGroup1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.patternBlockGroup1.Location = new System.Drawing.Point( 12, 12 );
			this.patternBlockGroup1.Movable = false;
			this.patternBlockGroup1.Name = "patternBlockGroup1";
			this.patternBlockGroup1.pattern = null;
			this.patternBlockGroup1.Size = new System.Drawing.Size( 392, 381 );
			this.patternBlockGroup1.TabIndex = 3;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point( 419, 265 );
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size( 72, 13 );
			this.label1.TabIndex = 21;
			this.label1.Text = "Pattern Count";
			// 
			// textBoxCount
			// 
			this.textBoxCount.Location = new System.Drawing.Point( 439, 281 );
			this.textBoxCount.Name = "textBoxCount";
			this.textBoxCount.ReadOnly = true;
			this.textBoxCount.Size = new System.Drawing.Size( 52, 20 );
			this.textBoxCount.TabIndex = 22;
			// 
			// ShowExpandedPattern
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size( 526, 405 );
			this.Controls.Add( this.textBoxCount );
			this.Controls.Add( this.label1 );
			this.Controls.Add( this.button1 );
			this.Controls.Add( this.currentPatternScroller2 );
			this.Controls.Add( this.currentPatternScroller1 );
			this.Controls.Add( this.patternBlockGroup1 );
			this.Name = "ShowExpandedPattern";
			this.Text = "Show Expanded Pattern";
			this.Load += new System.EventHandler( this.ShowExpandedPattern_Load );
			this.ResumeLayout( false );
			this.PerformLayout();

		}

		#endregion

        private BingoGameCore4.Controls.Patterns.PatternBlockGroup patternBlockGroup1;
        private BingoGameCore4.Controls.Patterns.CurrentPatternScroller currentPatternScroller1;
        private BingoGameCore4.Controls.Patterns.CurrentPatternScroller currentPatternScroller2;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox textBoxCount;
	}
}