namespace FantasyFighter
{
	partial class PlayerLoginForm
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
			this.textBoxUserName = new System.Windows.Forms.TextBox();
			this.buttonLogin = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// textBoxUserName
			// 
			this.textBoxUserName.Location = new System.Drawing.Point( 24, 72 );
			this.textBoxUserName.Name = "textBoxUserName";
			this.textBoxUserName.Size = new System.Drawing.Size( 100, 20 );
			this.textBoxUserName.TabIndex = 5;
			// 
			// buttonLogin
			// 
			this.buttonLogin.Location = new System.Drawing.Point( 24, 98 );
			this.buttonLogin.Name = "buttonLogin";
			this.buttonLogin.Size = new System.Drawing.Size( 155, 46 );
			this.buttonLogin.TabIndex = 4;
			this.buttonLogin.Text = "Login with username";
			this.buttonLogin.UseVisualStyleBackColor = true;
			this.buttonLogin.Click += new System.EventHandler( this.buttonLogin_Click );
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point( 24, 12 );
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size( 75, 23 );
			this.button1.TabIndex = 3;
			this.button1.Text = "Connect";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler( this.button1_Click );
			// 
			// PlayerLoginForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size( 284, 264 );
			this.Controls.Add( this.textBoxUserName );
			this.Controls.Add( this.buttonLogin );
			this.Controls.Add( this.button1 );
			this.Name = "PlayerLoginForm";
			this.Text = "PlayerLoginForm";
			this.ResumeLayout( false );
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox textBoxUserName;
		private System.Windows.Forms.Button buttonLogin;
		private System.Windows.Forms.Button button1;
	}
}