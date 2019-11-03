namespace xperdex.picture_scroller
{
	partial class ConfigureScroller
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
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// listBox1
			// 
			this.listBox1.FormattingEnabled = true;
			this.listBox1.Location = new System.Drawing.Point( 12, 39 );
			this.listBox1.Name = "listBox1";
			this.listBox1.Size = new System.Drawing.Size( 153, 186 );
			this.listBox1.TabIndex = 0;
			this.listBox1.SelectedIndexChanged += new System.EventHandler( this.listBox1_SelectedIndexChanged );
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point( 233, 12 );
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size( 265, 20 );
			this.textBox1.TabIndex = 1;
			// 
			// textBox2
			// 
			this.textBox2.Location = new System.Drawing.Point( 259, 97 );
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new System.Drawing.Size( 53, 20 );
			this.textBox2.TabIndex = 2;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point( 192, 16 );
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size( 23, 13 );
			this.label1.TabIndex = 3;
			this.label1.Text = "File";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point( 192, 100 );
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size( 61, 13 );
			this.label2.TabIndex = 4;
			this.label2.Text = "Show For...";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point( 12, 20 );
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size( 67, 13 );
			this.label3.TabIndex = 5;
			this.label3.Text = "All Images....";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point( 318, 100 );
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size( 49, 13 );
			this.label4.TabIndex = 6;
			this.label4.Text = "Seconds";
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point( 178, 182 );
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size( 75, 23 );
			this.button1.TabIndex = 7;
			this.button1.Text = "Remove";
			this.button1.UseVisualStyleBackColor = true;
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point( 178, 153 );
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size( 75, 23 );
			this.button2.TabIndex = 8;
			this.button2.Text = "Add New";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler( this.button2_Click );
			// 
			// ConfigureScroller
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size( 527, 264 );
			this.Controls.Add( this.button2 );
			this.Controls.Add( this.button1 );
			this.Controls.Add( this.label4 );
			this.Controls.Add( this.label3 );
			this.Controls.Add( this.label2 );
			this.Controls.Add( this.label1 );
			this.Controls.Add( this.textBox2 );
			this.Controls.Add( this.textBox1 );
			this.Controls.Add( this.listBox1 );
			this.Name = "ConfigureScroller";
			this.Text = "Configure Scroller";
			this.Load += new System.EventHandler( this.ConfigureScroller_Load );
			this.ResumeLayout( false );
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ListBox listBox1;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
	}
}