namespace xperdex.core
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
			this.SystemList = new System.Windows.Forms.ListBox();
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.button3 = new System.Windows.Forms.Button();
			this.button4 = new System.Windows.Forms.Button();
			this.button5 = new System.Windows.Forms.Button();
			this.textBox_NewSystem = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// ListPlugins
			// 
			this.ListPlugins.FormattingEnabled = true;
			this.ListPlugins.Location = new System.Drawing.Point( 9, 11 );
			this.ListPlugins.Margin = new System.Windows.Forms.Padding( 2, 2, 2, 2 );
			this.ListPlugins.Name = "ListPlugins";
			this.ListPlugins.Size = new System.Drawing.Size( 314, 82 );
			this.ListPlugins.TabIndex = 0;
			this.ListPlugins.SelectedValueChanged += new System.EventHandler( this.ListPlugins_SelectedValueChanged );
			// 
			// SystemList
			// 
			this.SystemList.FormattingEnabled = true;
			this.SystemList.Location = new System.Drawing.Point( 9, 110 );
			this.SystemList.Margin = new System.Windows.Forms.Padding( 2, 2, 2, 2 );
			this.SystemList.Name = "SystemList";
			this.SystemList.Size = new System.Drawing.Size( 314, 95 );
			this.SystemList.TabIndex = 1;
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point( 327, 11 );
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
			this.button2.Location = new System.Drawing.Point( 327, 58 );
			this.button2.Margin = new System.Windows.Forms.Padding( 2, 2, 2, 2 );
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size( 54, 35 );
			this.button2.TabIndex = 3;
			this.button2.Text = "Remove Plugin";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler( this.button2_Click );
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point( 327, 169 );
			this.button3.Margin = new System.Windows.Forms.Padding( 2, 2, 2, 2 );
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size( 54, 35 );
			this.button3.TabIndex = 5;
			this.button3.Text = "Remove System";
			this.button3.UseVisualStyleBackColor = true;
			this.button3.Click += new System.EventHandler( this.button3_Click );
			// 
			// button4
			// 
			this.button4.Location = new System.Drawing.Point( 138, 216 );
			this.button4.Margin = new System.Windows.Forms.Padding( 2, 2, 2, 2 );
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size( 56, 34 );
			this.button4.TabIndex = 4;
			this.button4.Text = "Add System";
			this.button4.UseVisualStyleBackColor = true;
			this.button4.Click += new System.EventHandler( this.button4_Click );
			// 
			// button5
			// 
			this.button5.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.button5.Location = new System.Drawing.Point( 327, 216 );
			this.button5.Margin = new System.Windows.Forms.Padding( 2, 2, 2, 2 );
			this.button5.Name = "button5";
			this.button5.Size = new System.Drawing.Size( 54, 34 );
			this.button5.TabIndex = 6;
			this.button5.Text = "Done";
			this.button5.UseVisualStyleBackColor = true;
			this.button5.Click += new System.EventHandler( this.button5_Click );
			// 
			// textBox_NewSystem
			// 
			this.textBox_NewSystem.Location = new System.Drawing.Point( 10, 232 );
			this.textBox_NewSystem.Margin = new System.Windows.Forms.Padding( 2, 2, 2, 2 );
			this.textBox_NewSystem.Name = "textBox_NewSystem";
			this.textBox_NewSystem.Size = new System.Drawing.Size( 116, 20 );
			this.textBox_NewSystem.TabIndex = 7;
			this.textBox_NewSystem.Text = "*";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point( 8, 213 );
			this.label1.Margin = new System.Windows.Forms.Padding( 2, 0, 2, 0 );
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size( 94, 13 );
			this.label1.TabIndex = 8;
			this.label1.Text = "Add System Name";
			// 
			// EditPlugins
			// 
			this.AcceptButton = this.button5;
			this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.button5;
			this.ClientSize = new System.Drawing.Size( 390, 261 );
			this.Controls.Add( this.label1 );
			this.Controls.Add( this.textBox_NewSystem );
			this.Controls.Add( this.button5 );
			this.Controls.Add( this.button3 );
			this.Controls.Add( this.button4 );
			this.Controls.Add( this.button2 );
			this.Controls.Add( this.button1 );
			this.Controls.Add( this.SystemList );
			this.Controls.Add( this.ListPlugins );
			this.Margin = new System.Windows.Forms.Padding( 2, 2, 2, 2 );
			this.Name = "EditPlugins";
			this.Text = "Edit Plugins";
			this.Load += new System.EventHandler( this.EditPlugins_Load );
			this.ResumeLayout( false );
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ListBox ListPlugins;
		private System.Windows.Forms.ListBox SystemList;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.Button button4;
		private System.Windows.Forms.Button button5;
		private System.Windows.Forms.TextBox textBox_NewSystem;
		private System.Windows.Forms.Label label1;
	}
}