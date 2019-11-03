namespace OpenSkieScheduler3.Controls.Forms
{
	partial class ColorEditor
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
			this.colorWell1 = new xperdex.gui.PSI_Palette.ColorWell();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.button1 = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// listBox1
			// 
			this.listBox1.FormattingEnabled = true;
			this.listBox1.Location = new System.Drawing.Point( 24, 43 );
			this.listBox1.Name = "listBox1";
			this.listBox1.Size = new System.Drawing.Size( 191, 316 );
			this.listBox1.TabIndex = 0;
			this.listBox1.SelectedIndexChanged += new System.EventHandler( this.listBox1_SelectedIndexChanged );
			// 
			// colorWell1
			// 
			this.colorWell1.BackColor = System.Drawing.Color.Transparent;
			this.colorWell1.color = System.Drawing.Color.Black;
			this.colorWell1.Location = new System.Drawing.Point( 238, 132 );
			this.colorWell1.Movable = false;
			this.colorWell1.Name = "colorWell1";
			this.colorWell1.Size = new System.Drawing.Size( 101, 53 );
			this.colorWell1.TabIndex = 1;
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point( 238, 43 );
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size( 169, 20 );
			this.textBox1.TabIndex = 2;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point( 224, 27 );
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size( 83, 13 );
			this.label1.TabIndex = 3;
			this.label1.Text = "Edit Color Name";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point( 221, 116 );
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size( 161, 13 );
			this.label2.TabIndex = 4;
			this.label2.Text = "Sample - click in color to change";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point( 12, 25 );
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size( 48, 13 );
			this.label3.TabIndex = 5;
			this.label3.Text = "Colors....";
			// 
			// button1
			// 
			this.button1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.button1.Location = new System.Drawing.Point( 361, 336 );
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size( 75, 23 );
			this.button1.TabIndex = 6;
			this.button1.Text = "Done";
			this.button1.UseVisualStyleBackColor = true;
			// 
			// ColorEditor
			// 
			this.AcceptButton = this.button1;
			this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.button1;
			this.ClientSize = new System.Drawing.Size( 448, 371 );
			this.Controls.Add( this.button1 );
			this.Controls.Add( this.label3 );
			this.Controls.Add( this.label2 );
			this.Controls.Add( this.label1 );
			this.Controls.Add( this.textBox1 );
			this.Controls.Add( this.colorWell1 );
			this.Controls.Add( this.listBox1 );
			this.Name = "ColorEditor";
			this.Text = "Color Editor";
			this.Load += new System.EventHandler( this.ColorEditor_Load );
			this.ResumeLayout( false );
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ListBox listBox1;
		private xperdex.gui.PSI_Palette.ColorWell colorWell1;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button button1;
	}
}