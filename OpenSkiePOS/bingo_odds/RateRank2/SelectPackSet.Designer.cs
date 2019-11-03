namespace RateRank2
{
	partial class SelectPackSet
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
			this.listBoxSession = new System.Windows.Forms.ListBox();
			this.listBoxPacks = new System.Windows.Forms.ListBox();
			this.listBoxPackSeq = new System.Windows.Forms.ListBox();
			this.buttonDone = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// listBoxSession
			// 
			this.listBoxSession.FormattingEnabled = true;
			this.listBoxSession.Location = new System.Drawing.Point( 13, 42 );
			this.listBoxSession.Name = "listBoxSession";
			this.listBoxSession.Size = new System.Drawing.Size( 120, 121 );
			this.listBoxSession.TabIndex = 0;
			// 
			// listBoxPacks
			// 
			this.listBoxPacks.FormattingEnabled = true;
			this.listBoxPacks.Location = new System.Drawing.Point( 13, 224 );
			this.listBoxPacks.Name = "listBoxPacks";
			this.listBoxPacks.Size = new System.Drawing.Size( 120, 147 );
			this.listBoxPacks.TabIndex = 1;
			// 
			// listBoxPackSeq
			// 
			this.listBoxPackSeq.FormattingEnabled = true;
			this.listBoxPackSeq.Location = new System.Drawing.Point( 178, 42 );
			this.listBoxPackSeq.Name = "listBoxPackSeq";
			this.listBoxPackSeq.Size = new System.Drawing.Size( 165, 329 );
			this.listBoxPackSeq.TabIndex = 2;
			// 
			// buttonDone
			// 
			this.buttonDone.Location = new System.Drawing.Point( 372, 344 );
			this.buttonDone.Name = "buttonDone";
			this.buttonDone.Size = new System.Drawing.Size( 75, 23 );
			this.buttonDone.TabIndex = 3;
			this.buttonDone.Text = "Doone";
			this.buttonDone.UseVisualStyleBackColor = true;
			// 
			// SelectPackSet
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size( 487, 435 );
			this.Controls.Add( this.buttonDone );
			this.Controls.Add( this.listBoxPackSeq );
			this.Controls.Add( this.listBoxPacks );
			this.Controls.Add( this.listBoxSession );
			this.Name = "SelectPackSet";
			this.Text = "SelectPackSet";
			this.ResumeLayout( false );

		}

		#endregion

		private System.Windows.Forms.ListBox listBoxSession;
		private System.Windows.Forms.ListBox listBoxPacks;
		private System.Windows.Forms.ListBox listBoxPackSeq;
		private System.Windows.Forms.Button buttonDone;
	}
}