namespace FantasyFighter
{
	partial class PlayerForm
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
			this.buttonLogin = new System.Windows.Forms.Button();
			this.textBoxUserName = new System.Windows.Forms.TextBox();
			this.listBox1 = new System.Windows.Forms.ListBox();
			this.listBox2 = new System.Windows.Forms.ListBox();
			this.SuspendLayout();
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point( 13, 60 );
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size( 75, 23 );
			this.button1.TabIndex = 0;
			this.button1.Text = "button1";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler( this.button1_Click );
			// 
			// buttonLogin
			// 
			this.buttonLogin.Location = new System.Drawing.Point( 159, 60 );
			this.buttonLogin.Name = "buttonLogin";
			this.buttonLogin.Size = new System.Drawing.Size( 75, 23 );
			this.buttonLogin.TabIndex = 1;
			this.buttonLogin.Text = "button2";
			this.buttonLogin.UseVisualStyleBackColor = true;
			this.buttonLogin.Click += new System.EventHandler( this.buttonLogin_Click );
			// 
			// textBoxUserName
			// 
			this.textBoxUserName.Location = new System.Drawing.Point( 159, 34 );
			this.textBoxUserName.Name = "textBoxUserName";
			this.textBoxUserName.Size = new System.Drawing.Size( 100, 20 );
			this.textBoxUserName.TabIndex = 2;
			// 
			// listBox1
			// 
			this.listBox1.FormattingEnabled = true;
			this.listBox1.Location = new System.Drawing.Point( 13, 143 );
			this.listBox1.Name = "listBox1";
			this.listBox1.Size = new System.Drawing.Size( 120, 134 );
			this.listBox1.TabIndex = 3;
			this.listBox1.SelectedIndexChanged += new System.EventHandler( this.listBox1_SelectedIndexChanged );
			// 
			// listBox2
			// 
			this.listBox2.FormattingEnabled = true;
			this.listBox2.Location = new System.Drawing.Point( 140, 143 );
			this.listBox2.Name = "listBox2";
			this.listBox2.Size = new System.Drawing.Size( 120, 251 );
			this.listBox2.TabIndex = 4;
			this.listBox2.SelectedIndexChanged += new System.EventHandler( this.listBox2_SelectedIndexChanged );
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size( 345, 393 );
			this.Controls.Add( this.listBox2 );
			this.Controls.Add( this.listBox1 );
			this.Controls.Add( this.textBoxUserName );
			this.Controls.Add( this.buttonLogin );
			this.Controls.Add( this.button1 );
			this.Name = "Form1";
			this.Text = "Form1";
			this.Load += new System.EventHandler( this.Form1_Load );
			this.ResumeLayout( false );
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button buttonLogin;
		private System.Windows.Forms.TextBox textBoxUserName;
		private System.Windows.Forms.ListBox listBox1;
		private System.Windows.Forms.ListBox listBox2;
	}
}

