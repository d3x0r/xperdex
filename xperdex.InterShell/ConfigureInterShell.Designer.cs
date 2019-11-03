namespace xperdex.InterShell
{
	partial class ConfigureInterShell
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
			this.textBoxConfigName = new System.Windows.Forms.TextBox();
			this.buttonOkay = new System.Windows.Forms.Button();
			this.buttonCancel = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// textBoxConfigName
			// 
			this.textBoxConfigName.Location = new System.Drawing.Point( 25, 81 );
			this.textBoxConfigName.Name = "textBoxConfigName";
			this.textBoxConfigName.Size = new System.Drawing.Size( 247, 20 );
			this.textBoxConfigName.TabIndex = 0;
			// 
			// buttonOkay
			// 
			this.buttonOkay.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.buttonOkay.Location = new System.Drawing.Point( 197, 181 );
			this.buttonOkay.Name = "buttonOkay";
			this.buttonOkay.Size = new System.Drawing.Size( 75, 23 );
			this.buttonOkay.TabIndex = 1;
			this.buttonOkay.Text = "Okay";
			this.buttonOkay.UseVisualStyleBackColor = true;
			// 
			// buttonCancel
			// 
			this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.buttonCancel.Location = new System.Drawing.Point( 197, 152 );
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size( 75, 23 );
			this.buttonCancel.TabIndex = 2;
			this.buttonCancel.Text = "Cancel";
			this.buttonCancel.UseVisualStyleBackColor = true;
			// 
			// ConfigureInterShell
			// 
			this.AcceptButton = this.buttonOkay;
			this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.buttonCancel;
			this.ClientSize = new System.Drawing.Size( 284, 264 );
			this.Controls.Add( this.buttonCancel );
			this.Controls.Add( this.buttonOkay );
			this.Controls.Add( this.textBoxConfigName );
			this.Name = "ConfigureInterShell";
			this.Text = "ConfigureInterShell";
			this.ResumeLayout( false );
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button buttonOkay;
		private System.Windows.Forms.Button buttonCancel;
		internal System.Windows.Forms.TextBox textBoxConfigName;
	}
}