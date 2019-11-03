namespace xperdex.timer.plugin
{
	partial class TimerButtonEditor
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
			this.checkBox1 = new System.Windows.Forms.CheckBox();
			this.checkBox2 = new System.Windows.Forms.CheckBox();
			this.checkBox3 = new System.Windows.Forms.CheckBox();
			this.textBoxTimerValMinutes = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.textBoxTimerValSeconds = new System.Windows.Forms.TextBox();
			this.textBoxTimerValHours = new System.Windows.Forms.TextBox();
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// checkBox1
			// 
			this.checkBox1.AutoSize = true;
			this.checkBox1.Location = new System.Drawing.Point( 116, 112 );
			this.checkBox1.Name = "checkBox1";
			this.checkBox1.Size = new System.Drawing.Size( 88, 17 );
			this.checkBox1.TabIndex = 0;
			this.checkBox1.Text = "Set To Value";
			this.checkBox1.UseVisualStyleBackColor = true;
			// 
			// checkBox2
			// 
			this.checkBox2.AutoSize = true;
			this.checkBox2.Location = new System.Drawing.Point( 116, 135 );
			this.checkBox2.Name = "checkBox2";
			this.checkBox2.Size = new System.Drawing.Size( 75, 17 );
			this.checkBox2.TabIndex = 1;
			this.checkBox2.Text = "Add Value";
			this.checkBox2.UseVisualStyleBackColor = true;
			// 
			// checkBox3
			// 
			this.checkBox3.AutoSize = true;
			this.checkBox3.Location = new System.Drawing.Point( 116, 158 );
			this.checkBox3.Name = "checkBox3";
			this.checkBox3.Size = new System.Drawing.Size( 83, 17 );
			this.checkBox3.TabIndex = 2;
			this.checkBox3.Text = "Reset Timer";
			this.checkBox3.UseVisualStyleBackColor = true;
			// 
			// textBoxTimerValMinutes
			// 
			this.textBoxTimerValMinutes.Location = new System.Drawing.Point( 80, 41 );
			this.textBoxTimerValMinutes.Name = "textBoxTimerValMinutes";
			this.textBoxTimerValMinutes.Size = new System.Drawing.Size( 33, 20 );
			this.textBoxTimerValMinutes.TabIndex = 3;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point( 24, 25 );
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size( 72, 13 );
			this.label1.TabIndex = 4;
			this.label1.Text = "Timer Amount";
			// 
			// textBoxTimerValSeconds
			// 
			this.textBoxTimerValSeconds.Location = new System.Drawing.Point( 119, 41 );
			this.textBoxTimerValSeconds.Name = "textBoxTimerValSeconds";
			this.textBoxTimerValSeconds.Size = new System.Drawing.Size( 33, 20 );
			this.textBoxTimerValSeconds.TabIndex = 5;
			// 
			// textBoxTimerValHours
			// 
			this.textBoxTimerValHours.Location = new System.Drawing.Point( 39, 41 );
			this.textBoxTimerValHours.Name = "textBoxTimerValHours";
			this.textBoxTimerValHours.Size = new System.Drawing.Size( 34, 20 );
			this.textBoxTimerValHours.TabIndex = 6;
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point( 142, 232 );
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size( 75, 23 );
			this.button1.TabIndex = 7;
			this.button1.Text = "Okay";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler( this.button1_Click );
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point( 142, 203 );
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size( 75, 23 );
			this.button2.TabIndex = 8;
			this.button2.Text = "Reset";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler( this.button2_Click );
			// 
			// TimerButtonEditor
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size( 502, 345 );
			this.Controls.Add( this.button2 );
			this.Controls.Add( this.button1 );
			this.Controls.Add( this.textBoxTimerValHours );
			this.Controls.Add( this.textBoxTimerValSeconds );
			this.Controls.Add( this.label1 );
			this.Controls.Add( this.textBoxTimerValMinutes );
			this.Controls.Add( this.checkBox3 );
			this.Controls.Add( this.checkBox2 );
			this.Controls.Add( this.checkBox1 );
			this.Name = "TimerButtonEditor";
			this.Text = "TimerButtonEditor";
			this.Load += new System.EventHandler( this.TimerButtonEditor_Load );
			this.ResumeLayout( false );
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.CheckBox checkBox1;
		private System.Windows.Forms.CheckBox checkBox2;
		private System.Windows.Forms.CheckBox checkBox3;
		private System.Windows.Forms.TextBox textBoxTimerValMinutes;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox textBoxTimerValSeconds;
		private System.Windows.Forms.TextBox textBoxTimerValHours;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
	}
}