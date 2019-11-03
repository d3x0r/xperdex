namespace xperdex.tasks
{
	partial class InternalTaskProperties
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
			this.listBox1 = new System.Windows.Forms.ListBox();
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.button3 = new System.Windows.Forms.Button();
			this.Cancel = new System.Windows.Forms.Button();
			this.Okay = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// listBox1
			// 
			this.listBox1.FormattingEnabled = true;
			this.listBox1.Location = new System.Drawing.Point( 12, 12 );
			this.listBox1.Name = "listBox1";
			this.listBox1.Size = new System.Drawing.Size( 250, 212 );
			this.listBox1.TabIndex = 0;
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point( 269, 13 );
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size( 75, 23 );
			this.button1.TabIndex = 1;
			this.button1.Text = "Create";
			this.button1.UseVisualStyleBackColor = true;
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point( 269, 43 );
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size( 75, 23 );
			this.button2.TabIndex = 2;
			this.button2.Text = "Destroy";
			this.button2.UseVisualStyleBackColor = true;
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point( 269, 73 );
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size( 75, 23 );
			this.button3.TabIndex = 3;
			this.button3.Text = "Edit";
			this.button3.UseVisualStyleBackColor = true;
			// 
			// Cancel
			// 
			this.Cancel.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right ) ) );
			this.Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.Cancel.Location = new System.Drawing.Point( 190, 253 );
			this.Cancel.Name = "Cancel";
			this.Cancel.Size = new System.Drawing.Size( 75, 37 );
			this.Cancel.TabIndex = 15;
			this.Cancel.Text = "Cancel";
			this.Cancel.UseVisualStyleBackColor = true;
			// 
			// Okay
			// 
			this.Okay.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right ) ) );
			this.Okay.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.Okay.Location = new System.Drawing.Point( 271, 253 );
			this.Okay.Name = "Okay";
			this.Okay.Size = new System.Drawing.Size( 75, 37 );
			this.Okay.TabIndex = 14;
			this.Okay.Text = "Okay";
			this.Okay.UseVisualStyleBackColor = true;
			// 
			// InternalTaskProperties
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size( 358, 302 );
			this.Controls.Add( this.Cancel );
			this.Controls.Add( this.Okay );
			this.Controls.Add( this.button3 );
			this.Controls.Add( this.button2 );
			this.Controls.Add( this.button1 );
			this.Controls.Add( this.listBox1 );
			this.Name = "InternalTaskProperties";
			this.Text = "InternalTaskProperties";
			this.ResumeLayout( false );

		}

		#endregion

		private System.Windows.Forms.ListBox listBox1;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.Button Cancel;
		private System.Windows.Forms.Button Okay;
	}
}