﻿namespace CMakeProjectManager
{
	partial class EditProjectGroup
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
			this.button3 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.listBox1 = new System.Windows.Forms.ListBox();
			this.SuspendLayout();
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point( 298, 268 );
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size( 75, 23 );
			this.button3.TabIndex = 7;
			this.button3.Text = "button3";
			this.button3.UseVisualStyleBackColor = true;
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point( 283, 67 );
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size( 123, 37 );
			this.button2.TabIndex = 6;
			this.button2.Text = "Edit Project";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler( this.button2_Click );
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point( 283, 24 );
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size( 123, 37 );
			this.button1.TabIndex = 5;
			this.button1.Text = "New Project";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler( this.button1_Click );
			// 
			// listBox1
			// 
			this.listBox1.FormattingEnabled = true;
			this.listBox1.Location = new System.Drawing.Point( 12, 12 );
			this.listBox1.Name = "listBox1";
			this.listBox1.Size = new System.Drawing.Size( 243, 290 );
			this.listBox1.TabIndex = 4;
			// 
			// EditProjectGroup
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size( 715, 454 );
			this.Controls.Add( this.button3 );
			this.Controls.Add( this.button2 );
			this.Controls.Add( this.button1 );
			this.Controls.Add( this.listBox1 );
			this.Name = "EditProjectGroup";
			this.Text = "EditProjectGroup";
			this.Load += new System.EventHandler( this.EditProjectGroup_Load );
			this.ResumeLayout( false );

		}

		#endregion

		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.ListBox listBox1;
	}
}