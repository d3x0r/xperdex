namespace PrizeScheduleEditor
{
	partial class SessionPackEditor
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
			this.comboBox1 = new System.Windows.Forms.ComboBox();
			this.listBox1 = new System.Windows.Forms.ListBox();
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.listBox2 = new System.Windows.Forms.ListBox();
			this.SuspendLayout();
			// 
			// comboBox1
			// 
			this.comboBox1.FormattingEnabled = true;
			this.comboBox1.Location = new System.Drawing.Point( 47, 32 );
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new System.Drawing.Size( 121, 21 );
			this.comboBox1.TabIndex = 0;
			this.comboBox1.SelectedIndexChanged += new System.EventHandler( this.comboBox1_SelectedIndexChanged );
			// 
			// listBox1
			// 
			this.listBox1.FormattingEnabled = true;
			this.listBox1.Location = new System.Drawing.Point( 47, 74 );
			this.listBox1.Name = "listBox1";
			this.listBox1.Size = new System.Drawing.Size( 207, 342 );
			this.listBox1.TabIndex = 1;
			this.listBox1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler( this.listBox1_MouseDoubleClick );
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point( 254, 30 );
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size( 75, 23 );
			this.button1.TabIndex = 2;
			this.button1.Text = "button1";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler( this.button1_Click );
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point( 335, 30 );
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size( 75, 23 );
			this.button2.TabIndex = 3;
			this.button2.Text = "button2";
			this.button2.UseVisualStyleBackColor = true;
			// 
			// listBox2
			// 
			this.listBox2.FormattingEnabled = true;
			this.listBox2.Location = new System.Drawing.Point( 271, 74 );
			this.listBox2.Name = "listBox2";
			this.listBox2.Size = new System.Drawing.Size( 207, 342 );
			this.listBox2.TabIndex = 4;
			// 
			// SessionPackEditor
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size( 567, 454 );
			this.Controls.Add( this.listBox2 );
			this.Controls.Add( this.button2 );
			this.Controls.Add( this.button1 );
			this.Controls.Add( this.listBox1 );
			this.Controls.Add( this.comboBox1 );
			this.Name = "SessionPackEditor";
			this.Text = "SessionPackEditor";
			this.Load += new System.EventHandler( this.SessionPackEditor_Load );
			this.ResumeLayout( false );

		}

		#endregion

		private System.Windows.Forms.ComboBox comboBox1;
		private System.Windows.Forms.ListBox listBox1;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.ListBox listBox2;
	}
}