namespace xperd3x.breadboard
{
	partial class EditPlugins
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
			if( disposing && (components != null) )
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
			this.ListPlugins = new System.Windows.Forms.ListBox();
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.button5 = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// ListPlugins
			// 
			this.ListPlugins.FormattingEnabled = true;
			this.ListPlugins.Location = new System.Drawing.Point( 9, 11 );
			this.ListPlugins.Margin = new System.Windows.Forms.Padding( 2, 2, 2, 2 );
			this.ListPlugins.Name = "ListPlugins";
			this.ListPlugins.Size = new System.Drawing.Size( 314, 121 );
			this.ListPlugins.TabIndex = 0;
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point( 192, 138 );
			this.button1.Margin = new System.Windows.Forms.Padding( 2, 2, 2, 2 );
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size( 54, 34 );
			this.button1.TabIndex = 2;
			this.button1.Text = "Add  Plugin";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler( this.button1_Click );
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point( 269, 138 );
			this.button2.Margin = new System.Windows.Forms.Padding( 2, 2, 2, 2 );
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size( 54, 35 );
			this.button2.TabIndex = 3;
			this.button2.Text = "Remove Plugin";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler( this.button2_Click );
			// 
			// button5
			// 
			this.button5.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.button5.Location = new System.Drawing.Point( 269, 177 );
			this.button5.Margin = new System.Windows.Forms.Padding( 2, 2, 2, 2 );
			this.button5.Name = "button5";
			this.button5.Size = new System.Drawing.Size( 54, 34 );
			this.button5.TabIndex = 6;
			this.button5.Text = "Done";
			this.button5.UseVisualStyleBackColor = true;
			this.button5.Click += new System.EventHandler( this.button5_Click );
			// 
			// EditPlugins
			// 
			this.AcceptButton = this.button5;
			this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.button5;
			this.ClientSize = new System.Drawing.Size( 337, 221 );
			this.Controls.Add( this.button5 );
			this.Controls.Add( this.button2 );
			this.Controls.Add( this.button1 );
			this.Controls.Add( this.ListPlugins );
			this.Margin = new System.Windows.Forms.Padding( 2, 2, 2, 2 );
			this.Name = "EditPlugins";
			this.Text = "Edit Plugins";
			this.Load += new System.EventHandler( this.EditPlugins_Load );
			this.ResumeLayout( false );

		}

		#endregion

		private System.Windows.Forms.ListBox ListPlugins;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button5;
	}
}