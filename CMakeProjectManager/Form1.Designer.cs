﻿namespace CMakeProjectManager
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
			this.listBox1 = new System.Windows.Forms.ListBox();
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.button3 = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// listBox1
			// 
			this.listBox1.AllowDrop = true;
			this.listBox1.FormattingEnabled = true;
			this.listBox1.Location = new System.Drawing.Point( 12, 12 );
			this.listBox1.Name = "listBox1";
			this.listBox1.Size = new System.Drawing.Size( 243, 290 );
			this.listBox1.TabIndex = 0;
			this.listBox1.DragDrop += new System.Windows.Forms.DragEventHandler( this.listBox1_DragDrop );
			this.listBox1.DragEnter += new System.Windows.Forms.DragEventHandler( this.listBox1_DragEnter );
			this.listBox1.DragOver += new System.Windows.Forms.DragEventHandler( this.listBox1_DragOver );
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point( 283, 24 );
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size( 123, 37 );
			this.button1.TabIndex = 1;
			this.button1.Text = "New Project Group";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler( this.button1_Click );
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point( 283, 67 );
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size( 123, 37 );
			this.button2.TabIndex = 2;
			this.button2.Text = "Edit Project Group";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler( this.button2_Click );
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point( 298, 268 );
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size( 75, 23 );
			this.button3.TabIndex = 3;
			this.button3.Text = "button3";
			this.button3.UseVisualStyleBackColor = true;
			this.button3.Click += new System.EventHandler( this.button3_Click );
			// 
			// Form1
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size( 515, 351 );
			this.Controls.Add( this.button3 );
			this.Controls.Add( this.button2 );
			this.Controls.Add( this.button1 );
			this.Controls.Add( this.listBox1 );
			this.Name = "Form1";
			this.Text = "CMake Project Manager";
			this.Load += new System.EventHandler( this.Form1_Load );
			this.ResumeLayout( false );

		}

		#endregion

		private System.Windows.Forms.ListBox listBox1;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button3;
	}
}

