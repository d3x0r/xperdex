namespace PlayerDrawing
{
	partial class Form1
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.ballImage5 = new BingoGameCore4.Controls.BallImage();
            this.ballImage4 = new BingoGameCore4.Controls.BallImage();
            this.ballImage3 = new BingoGameCore4.Controls.BallImage();
            this.ballImage2 = new BingoGameCore4.Controls.BallImage();
            this.ballImage1 = new BingoGameCore4.Controls.BallImage();
            this.button7 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point( 50, 23 );
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size( 83, 13 );
            this.label1.TabIndex = 0;
            this.label1.Text = "Count of players";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point( 50, 56 );
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size( 35, 13 );
            this.label2.TabIndex = 1;
            this.label2.Text = "label2";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point( 334, 12 );
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size( 125, 54 );
            this.button1.TabIndex = 7;
            this.button1.Text = "Load Random\r\nPlayers";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler( this.button1_Click );
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point( 468, 135 );
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size( 125, 54 );
            this.button2.TabIndex = 8;
            this.button2.Text = "Call Winner";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler( this.button2_Click );
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point( 146, 23 );
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size( 35, 13 );
            this.label3.TabIndex = 9;
            this.label3.Text = "label3";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point( 146, 53 );
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size( 35, 13 );
            this.label4.TabIndex = 10;
            this.label4.Text = "label4";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point( 69, 294 );
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size( 35, 13 );
            this.label5.TabIndex = 11;
            this.label5.Text = "label5";
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point( 203, 212 );
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size( 237, 186 );
            this.listBox1.TabIndex = 12;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point( 468, 72 );
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size( 125, 54 );
            this.button3.TabIndex = 13;
            this.button3.Text = "Load Players\r\n(From PlayerTrack)";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Visible = false;
            this.button3.Click += new System.EventHandler( this.button3_Click );
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point( 518, 419 );
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size( 75, 23 );
            this.button4.TabIndex = 14;
            this.button4.Text = "Edit Options";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler( this.button4_Click );
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point( 468, 195 );
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size( 125, 54 );
            this.button5.TabIndex = 15;
            this.button5.Text = "Retry\r\nSave Winners";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler( this.button5_Click );
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point( 468, 344 );
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size( 125, 54 );
            this.button6.TabIndex = 16;
            this.button6.Text = "Setup Drawing";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler( this.button6_Click );
            // 
            // ballImage5
            // 
            this.ballImage5.BackColor = System.Drawing.Color.Transparent;
            this.ballImage5.Ball = 0;
            this.ballImage5.Location = new System.Drawing.Point( 304, 112 );
            this.ballImage5.Movable = false;
            this.ballImage5.Name = "ballImage5";
            this.ballImage5.Size = new System.Drawing.Size( 52, 53 );
            this.ballImage5.TabIndex = 6;
            // 
            // ballImage4
            // 
            this.ballImage4.BackColor = System.Drawing.Color.Transparent;
            this.ballImage4.Ball = 0;
            this.ballImage4.Location = new System.Drawing.Point( 246, 112 );
            this.ballImage4.Movable = false;
            this.ballImage4.Name = "ballImage4";
            this.ballImage4.Size = new System.Drawing.Size( 52, 53 );
            this.ballImage4.TabIndex = 5;
            // 
            // ballImage3
            // 
            this.ballImage3.BackColor = System.Drawing.Color.Transparent;
            this.ballImage3.Ball = 0;
            this.ballImage3.Location = new System.Drawing.Point( 188, 112 );
            this.ballImage3.Movable = false;
            this.ballImage3.Name = "ballImage3";
            this.ballImage3.Size = new System.Drawing.Size( 52, 53 );
            this.ballImage3.TabIndex = 4;
            // 
            // ballImage2
            // 
            this.ballImage2.BackColor = System.Drawing.Color.Transparent;
            this.ballImage2.Ball = 0;
            this.ballImage2.Location = new System.Drawing.Point( 130, 112 );
            this.ballImage2.Movable = false;
            this.ballImage2.Name = "ballImage2";
            this.ballImage2.Size = new System.Drawing.Size( 52, 53 );
            this.ballImage2.TabIndex = 3;
            // 
            // ballImage1
            // 
            this.ballImage1.BackColor = System.Drawing.Color.Transparent;
            this.ballImage1.Ball = 0;
            this.ballImage1.Location = new System.Drawing.Point( 72, 112 );
            this.ballImage1.Movable = false;
            this.ballImage1.Name = "ballImage1";
            this.ballImage1.Size = new System.Drawing.Size( 52, 53 );
            this.ballImage1.TabIndex = 2;
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point( 468, 12 );
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size( 125, 54 );
            this.button7.TabIndex = 17;
            this.button7.Text = "Load Players\r\n(From SQL)";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler( this.button7_Click );
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size( 605, 450 );
            this.Controls.Add( this.button7 );
            this.Controls.Add( this.button6 );
            this.Controls.Add( this.button5 );
            this.Controls.Add( this.button4 );
            this.Controls.Add( this.button3 );
            this.Controls.Add( this.listBox1 );
            this.Controls.Add( this.label5 );
            this.Controls.Add( this.label4 );
            this.Controls.Add( this.label3 );
            this.Controls.Add( this.button2 );
            this.Controls.Add( this.button1 );
            this.Controls.Add( this.ballImage5 );
            this.Controls.Add( this.ballImage4 );
            this.Controls.Add( this.ballImage3 );
            this.Controls.Add( this.ballImage2 );
            this.Controls.Add( this.ballImage1 );
            this.Controls.Add( this.label2 );
            this.Controls.Add( this.label1 );
            this.Name = "Form1";
            this.Text = "Player Drawing";
            this.ResumeLayout( false );
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private BingoGameCore4.Controls.BallImage ballImage1;
		private BingoGameCore4.Controls.BallImage ballImage2;
		private BingoGameCore4.Controls.BallImage ballImage3;
		private BingoGameCore4.Controls.BallImage ballImage4;
		private BingoGameCore4.Controls.BallImage ballImage5;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.ListBox listBox1;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.Button button4;
		private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
	}
}

