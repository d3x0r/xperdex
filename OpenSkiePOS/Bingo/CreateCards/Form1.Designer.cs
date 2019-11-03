namespace CreateCards
{
	partial class Form1
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components;

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
			this.textBoxFile = new System.Windows.Forms.TextBox();
			this.textBoxCards = new System.Windows.Forms.TextBox();
			this.button1 = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// textBoxFile
			// 
			this.textBoxFile.Location = new System.Drawing.Point( 42, 40 );
			this.textBoxFile.Name = "textBoxFile";
			this.textBoxFile.Size = new System.Drawing.Size( 100, 20 );
			this.textBoxFile.TabIndex = 0;
			// 
			// textBoxCards
			// 
			this.textBoxCards.Location = new System.Drawing.Point( 60, 85 );
			this.textBoxCards.Name = "textBoxCards";
			this.textBoxCards.Size = new System.Drawing.Size( 100, 20 );
			this.textBoxCards.TabIndex = 1;
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point( 197, 229 );
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size( 75, 23 );
			this.button1.TabIndex = 2;
			this.button1.Text = "button1";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler( this.button1_Click );
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size( 284, 264 );
			this.Controls.Add( this.button1 );
			this.Controls.Add( this.textBoxCards );
			this.Controls.Add( this.textBoxFile );
			this.Name = "Form1";
			this.Text = "Form1";
			this.ResumeLayout( false );
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox textBoxFile;
		private System.Windows.Forms.TextBox textBoxCards;
		private System.Windows.Forms.Button button1;
	}
}

