namespace xperdex.security.sql
{
	partial class SQLSecurityConfig
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
			this.listBoxAvailableTokens = new System.Windows.Forms.ListBox();
			this.listBoxAppliedTokens = new System.Windows.Forms.ListBox();
			this.ButtonCancel = new System.Windows.Forms.Button();
			this.ButtonOkay = new System.Windows.Forms.Button();
			this.checkBoxDoLogin = new System.Windows.Forms.CheckBox();
			this.SuspendLayout();
			// 
			// listBoxAvailableTokens
			// 
			this.listBoxAvailableTokens.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom )
						| System.Windows.Forms.AnchorStyles.Left ) ) );
			this.listBoxAvailableTokens.FormattingEnabled = true;
			this.listBoxAvailableTokens.Location = new System.Drawing.Point( 12, 25 );
			this.listBoxAvailableTokens.Name = "listBoxAvailableTokens";
			this.listBoxAvailableTokens.Size = new System.Drawing.Size( 145, 173 );
			this.listBoxAvailableTokens.TabIndex = 0;
			this.listBoxAvailableTokens.DoubleClick += new System.EventHandler( this.listBoxAvailableTokens_DoubleClick );
			// 
			// listBoxAppliedTokens
			// 
			this.listBoxAppliedTokens.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom )
						| System.Windows.Forms.AnchorStyles.Right ) ) );
			this.listBoxAppliedTokens.FormattingEnabled = true;
			this.listBoxAppliedTokens.Location = new System.Drawing.Point( 180, 25 );
			this.listBoxAppliedTokens.Name = "listBoxAppliedTokens";
			this.listBoxAppliedTokens.Size = new System.Drawing.Size( 147, 173 );
			this.listBoxAppliedTokens.TabIndex = 1;
			this.listBoxAppliedTokens.DoubleClick += new System.EventHandler( this.listBoxAppliedTokens_DoubleClick );
			// 
			// ButtonCancel
			// 
			this.ButtonCancel.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right ) ) );
			this.ButtonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.ButtonCancel.Location = new System.Drawing.Point( 116, 245 );
			this.ButtonCancel.Name = "ButtonCancel";
			this.ButtonCancel.Size = new System.Drawing.Size( 104, 41 );
			this.ButtonCancel.TabIndex = 2;
			this.ButtonCancel.Text = "Cancel";
			this.ButtonCancel.UseVisualStyleBackColor = true;
			// 
			// ButtonOkay
			// 
			this.ButtonOkay.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right ) ) );
			this.ButtonOkay.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.ButtonOkay.Location = new System.Drawing.Point( 226, 245 );
			this.ButtonOkay.Name = "ButtonOkay";
			this.ButtonOkay.Size = new System.Drawing.Size( 104, 41 );
			this.ButtonOkay.TabIndex = 3;
			this.ButtonOkay.Text = "Okay";
			this.ButtonOkay.UseVisualStyleBackColor = true;
			// 
			// checkBoxDoLogin
			// 
			this.checkBoxDoLogin.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left ) ) );
			this.checkBoxDoLogin.AutoSize = true;
			this.checkBoxDoLogin.Location = new System.Drawing.Point( 15, 215 );
			this.checkBoxDoLogin.Name = "checkBoxDoLogin";
			this.checkBoxDoLogin.Size = new System.Drawing.Size( 163, 17 );
			this.checkBoxDoLogin.TabIndex = 4;
			this.checkBoxDoLogin.Text = "Persistant Context (Do Login)";
			this.checkBoxDoLogin.UseVisualStyleBackColor = true;
			// 
			// SQLSecurityConfig
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size( 342, 298 );
			this.Controls.Add( this.checkBoxDoLogin );
			this.Controls.Add( this.ButtonOkay );
			this.Controls.Add( this.ButtonCancel );
			this.Controls.Add( this.listBoxAppliedTokens );
			this.Controls.Add( this.listBoxAvailableTokens );
			this.Name = "SQLSecurityConfig";
			this.Text = "Configure SQL Security";
			this.Load += new System.EventHandler( this.SQLSecurityConfig_Load );
			this.ResumeLayout( false );
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ListBox listBoxAvailableTokens;
		internal System.Windows.Forms.ListBox listBoxAppliedTokens;
		private System.Windows.Forms.Button ButtonCancel;
		private System.Windows.Forms.Button ButtonOkay;
		private System.Windows.Forms.CheckBox checkBoxDoLogin;
	}
}