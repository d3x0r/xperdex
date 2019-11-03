namespace OpenSkie.Scheduler.Controls
{
	partial class ScrollableMessageBox
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
			this.buttonNegative = new System.Windows.Forms.Button();
			this.buttonPositive = new System.Windows.Forms.Button();
			this.richTextBox1 = new System.Windows.Forms.RichTextBox();
			this.SuspendLayout();
			// 
			// buttonNegative
			// 
			this.buttonNegative.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right ) ) );
			this.buttonNegative.Location = new System.Drawing.Point( 197, 227 );
			this.buttonNegative.Name = "buttonNegative";
			this.buttonNegative.Size = new System.Drawing.Size( 75, 23 );
			this.buttonNegative.TabIndex = 0;
			this.buttonNegative.Text = "Ok";
			this.buttonNegative.UseVisualStyleBackColor = true;
			// 
			// buttonPositive
			// 
			this.buttonPositive.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right ) ) );
			this.buttonPositive.Location = new System.Drawing.Point( 116, 227 );
			this.buttonPositive.Name = "buttonPositive";
			this.buttonPositive.Size = new System.Drawing.Size( 75, 23 );
			this.buttonPositive.TabIndex = 1;
			this.buttonPositive.Text = "Ok";
			this.buttonPositive.UseVisualStyleBackColor = true;
			// 
			// richTextBox1
			// 
			this.richTextBox1.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom )
						| System.Windows.Forms.AnchorStyles.Left )
						| System.Windows.Forms.AnchorStyles.Right ) ) );
			this.richTextBox1.Location = new System.Drawing.Point( 12, 12 );
			this.richTextBox1.Name = "richTextBox1";
			this.richTextBox1.Size = new System.Drawing.Size( 260, 209 );
			this.richTextBox1.TabIndex = 2;
			this.richTextBox1.Text = "";
			// 
			// ScrollableMessageBox
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size( 284, 262 );
			this.Controls.Add( this.richTextBox1 );
			this.Controls.Add( this.buttonPositive );
			this.Controls.Add( this.buttonNegative );
			this.Name = "ScrollableMessageBox";
			this.Text = "ScrollableMessageBox";
			this.ResumeLayout( false );

		}

		#endregion

		private System.Windows.Forms.Button buttonNegative;
		private System.Windows.Forms.Button buttonPositive;
		private System.Windows.Forms.RichTextBox richTextBox1;
	}
}