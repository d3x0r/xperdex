namespace BingoGameCore4.Forms
{
	partial class ConfigureGamePackPoints
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
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom )
                        | System.Windows.Forms.AnchorStyles.Left )
                        | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point( 26, 317 );
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size( 211, 95 );
            this.listBox1.TabIndex = 0;
            // 
            // comboBox1
            // 
            this.comboBox1.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point( 562, 324 );
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size( 121, 21 );
            this.comboBox1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point( 497, 327 );
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size( 59, 13 );
            this.label1.TabIndex = 2;
            this.label1.Text = "Pack Type";
            // 
            // label2
            // 
            this.label2.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point( 500, 359 );
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size( 36, 13 );
            this.label2.TabIndex = 3;
            this.label2.Text = "Points";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point( 200, 27 );
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size( 35, 13 );
            this.label3.TabIndex = 4;
            this.label3.Text = "Game";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point( 23, 27 );
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size( 44, 13 );
            this.label4.TabIndex = 6;
            this.label4.Text = "Session";
            // 
            // listBox2
            // 
            this.listBox2.FormattingEnabled = true;
            this.listBox2.Location = new System.Drawing.Point( 23, 46 );
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size( 150, 264 );
            this.listBox2.TabIndex = 5;
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.textBox1.Location = new System.Drawing.Point( 562, 356 );
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size( 100, 20 );
            this.textBox1.TabIndex = 7;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point( 203, 46 );
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size( 380, 265 );
            this.dataGridView1.TabIndex = 8;
            // 
            // ConfigureGamePackPoints
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size( 738, 424 );
            this.Controls.Add( this.dataGridView1 );
            this.Controls.Add( this.textBox1 );
            this.Controls.Add( this.label4 );
            this.Controls.Add( this.listBox2 );
            this.Controls.Add( this.label3 );
            this.Controls.Add( this.label2 );
            this.Controls.Add( this.label1 );
            this.Controls.Add( this.comboBox1 );
            this.Controls.Add( this.listBox1 );
            this.Name = "ConfigureGamePackPoints";
            this.Text = "ConfigureGamePackPoints";
            this.Load += new System.EventHandler( this.ConfigureGamePackPoints_Load );
            this.ResumeLayout( false );
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ListBox listBox1;
		private System.Windows.Forms.ComboBox comboBox1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.ListBox listBox2;
		private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.DataGridView dataGridView1;
	}
}