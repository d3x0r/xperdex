namespace PlayerDrawing
{
	partial class PlayerLoader
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
			this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.listBox1 = new System.Windows.Forms.ListBox();
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// dateTimePicker1
			// 
			this.dateTimePicker1.Location = new System.Drawing.Point( 61, 47 );
			this.dateTimePicker1.Margin = new System.Windows.Forms.Padding( 7, 7, 7, 7 );
			this.dateTimePicker1.Name = "dateTimePicker1";
			this.dateTimePicker1.Size = new System.Drawing.Size( 461, 35 );
			this.dateTimePicker1.TabIndex = 0;
			this.dateTimePicker1.ValueChanged += new System.EventHandler( this.dateTimePicker1_ValueChanged );
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point( 10, 11 );
			this.label1.Margin = new System.Windows.Forms.Padding( 7, 0, 7, 0 );
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size( 147, 29 );
			this.label1.TabIndex = 1;
			this.label1.Text = "Select a Day";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point( 10, 116 );
			this.label2.Margin = new System.Windows.Forms.Padding( 7, 0, 7, 0 );
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size( 193, 29 );
			this.label2.TabIndex = 2;
			this.label2.Text = "Select a Session";
			// 
			// listBox1
			// 
			this.listBox1.FormattingEnabled = true;
			this.listBox1.ItemHeight = 29;
			this.listBox1.Location = new System.Drawing.Point( 61, 154 );
			this.listBox1.Margin = new System.Windows.Forms.Padding( 7, 7, 7, 7 );
			this.listBox1.Name = "listBox1";
			this.listBox1.Size = new System.Drawing.Size( 461, 323 );
			this.listBox1.TabIndex = 3;
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point( 536, 426 );
			this.button1.Margin = new System.Windows.Forms.Padding( 7, 7, 7, 7 );
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size( 175, 51 );
			this.button1.TabIndex = 4;
			this.button1.Text = "Load";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler( this.button1_Click );
			// 
			// button2
			// 
			this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.button2.Location = new System.Drawing.Point( 536, 361 );
			this.button2.Margin = new System.Windows.Forms.Padding( 7, 7, 7, 7 );
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size( 175, 51 );
			this.button2.TabIndex = 5;
			this.button2.Text = "Cancel";
			this.button2.UseVisualStyleBackColor = true;
			// 
			// PlayerLoader
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF( 14F, 29F );
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size( 727, 496 );
			this.Controls.Add( this.button2 );
			this.Controls.Add( this.button1 );
			this.Controls.Add( this.listBox1 );
			this.Controls.Add( this.label2 );
			this.Controls.Add( this.label1 );
			this.Controls.Add( this.dateTimePicker1 );
			this.Font = new System.Drawing.Font( "Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( (byte)( 0 ) ) );
			this.Margin = new System.Windows.Forms.Padding( 7, 7, 7, 7 );
			this.Name = "PlayerLoader";
			this.Text = "PlayerLoader";
			this.Load += new System.EventHandler( this.PlayerLoader_Load );
			this.ResumeLayout( false );
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.DateTimePicker dateTimePicker1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ListBox listBox1;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
	}
}