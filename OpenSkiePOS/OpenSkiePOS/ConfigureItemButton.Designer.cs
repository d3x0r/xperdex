namespace OpenSkiePOS
{
	partial class ConfigureItemButton
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
			this.Okay = new System.Windows.Forms.Button();
			this.Cancel = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// listBox1
			// 
			this.listBox1.FormattingEnabled = true;
			this.listBox1.Location = new System.Drawing.Point( 12, 12 );
			this.listBox1.Name = "listBox1";
			this.listBox1.Size = new System.Drawing.Size( 353, 251 );
			this.listBox1.TabIndex = 0;
			// 
			// Okay
			// 
			this.Okay.Location = new System.Drawing.Point( 12, 270 );
			this.Okay.Name = "Okay";
			this.Okay.Size = new System.Drawing.Size( 109, 39 );
			this.Okay.TabIndex = 1;
			this.Okay.Text = "Set And Configure";
			this.Okay.UseVisualStyleBackColor = true;
			this.Okay.Click += new System.EventHandler( this.Okay_Click );
			// 
			// Cancel
			// 
			this.Cancel.Location = new System.Drawing.Point( 269, 270 );
			this.Cancel.Name = "Cancel";
			this.Cancel.Size = new System.Drawing.Size( 96, 40 );
			this.Cancel.TabIndex = 2;
			this.Cancel.Text = "Cancel";
			this.Cancel.UseVisualStyleBackColor = true;
			this.Cancel.Click += new System.EventHandler( this.Cancel_Click );
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point( 127, 270 );
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size( 112, 39 );
			this.button1.TabIndex = 3;
			this.button1.Text = "Configure Department Items";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler( this.button1_Click );
			// 
			// ConfigureItemButton
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size( 379, 320 );
			this.Controls.Add( this.button1 );
			this.Controls.Add( this.Cancel );
			this.Controls.Add( this.Okay );
			this.Controls.Add( this.listBox1 );
			this.Name = "ConfigureItemButton";
			this.Text = "Configure Item Button";
			this.Load += new System.EventHandler( this.ConfigureItemButton_Load );
			this.ResumeLayout( false );

		}

		#endregion

		private System.Windows.Forms.ListBox listBox1;
		private System.Windows.Forms.Button Okay;
		private System.Windows.Forms.Button Cancel;
		private System.Windows.Forms.Button button1;
	}
}