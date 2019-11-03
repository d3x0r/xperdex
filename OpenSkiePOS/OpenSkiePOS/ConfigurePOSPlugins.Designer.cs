namespace OpenSkiePOS
{
	partial class ConfigurePOSPlugins
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
			this.buttonRemovePlugin = new System.Windows.Forms.Button();
			this.buttonAddPlugin = new System.Windows.Forms.Button();
			this.ListPlugins = new System.Windows.Forms.ListBox();
			this.buttonDone = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// buttonRemovePlugin
			// 
			this.buttonRemovePlugin.Location = new System.Drawing.Point( 363, 78 );
			this.buttonRemovePlugin.Margin = new System.Windows.Forms.Padding( 2 );
			this.buttonRemovePlugin.Name = "buttonRemovePlugin";
			this.buttonRemovePlugin.Size = new System.Drawing.Size( 54, 35 );
			this.buttonRemovePlugin.TabIndex = 6;
			this.buttonRemovePlugin.Text = "Remove Plugin";
			this.buttonRemovePlugin.UseVisualStyleBackColor = true;
			this.buttonRemovePlugin.Click += new System.EventHandler( this.buttonRemovePlugin_Click );
			// 
			// buttonAddPlugin
			// 
			this.buttonAddPlugin.Location = new System.Drawing.Point( 363, 32 );
			this.buttonAddPlugin.Margin = new System.Windows.Forms.Padding( 2 );
			this.buttonAddPlugin.Name = "buttonAddPlugin";
			this.buttonAddPlugin.Size = new System.Drawing.Size( 54, 34 );
			this.buttonAddPlugin.TabIndex = 5;
			this.buttonAddPlugin.Text = "Add  Plugin";
			this.buttonAddPlugin.UseVisualStyleBackColor = true;
			this.buttonAddPlugin.Click += new System.EventHandler( this.buttonAddPlugin_Click );
			// 
			// ListPlugins
			// 
			this.ListPlugins.FormattingEnabled = true;
			this.ListPlugins.Location = new System.Drawing.Point( 45, 31 );
			this.ListPlugins.Margin = new System.Windows.Forms.Padding( 2 );
			this.ListPlugins.Name = "ListPlugins";
			this.ListPlugins.Size = new System.Drawing.Size( 314, 82 );
			this.ListPlugins.TabIndex = 4;
			// 
			// buttonDone
			// 
			this.buttonDone.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.buttonDone.Location = new System.Drawing.Point( 385, 265 );
			this.buttonDone.Margin = new System.Windows.Forms.Padding( 2 );
			this.buttonDone.Name = "buttonDone";
			this.buttonDone.Size = new System.Drawing.Size( 54, 34 );
			this.buttonDone.TabIndex = 7;
			this.buttonDone.Text = "Done";
			this.buttonDone.UseVisualStyleBackColor = true;
			this.buttonDone.Click += new System.EventHandler( this.buttonDone_Click );
			// 
			// ConfigurePOSPlugins
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size( 488, 342 );
			this.Controls.Add( this.buttonDone );
			this.Controls.Add( this.buttonRemovePlugin );
			this.Controls.Add( this.buttonAddPlugin );
			this.Controls.Add( this.ListPlugins );
			this.Name = "ConfigurePOSPlugins";
			this.Text = "ConfigurePOSPlugins";
			this.Load += new System.EventHandler( this.ConfigurePOSPlugins_Load );
			this.ResumeLayout( false );

		}

		#endregion

		private System.Windows.Forms.Button buttonRemovePlugin;
		private System.Windows.Forms.Button buttonAddPlugin;
		private System.Windows.Forms.ListBox ListPlugins;
		private System.Windows.Forms.Button buttonDone;
	}
}