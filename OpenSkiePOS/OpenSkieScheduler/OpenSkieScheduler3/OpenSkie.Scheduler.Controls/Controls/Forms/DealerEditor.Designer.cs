namespace OpenSkieScheduler3.Controls.Forms
{
	partial class DealerEditor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof( DealerEditor ) );
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dataGridView3 = new System.Windows.Forms.DataGridView();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.editCardsets1 = new OpenSkieScheduler3.Controls.Buttons.EditCardsets();
            this.editCardsetRanges1 = new OpenSkieScheduler3.Controls.Buttons.EditCardsetRanges();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            ( (System.ComponentModel.ISupportInitialize)( this.dataGridView1 ) ).BeginInit();
            ( (System.ComponentModel.ISupportInitialize)( this.dataGridView3 ) ).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point( 15, 397 );
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size( 292, 132 );
            this.dataGridView1.TabIndex = 0;
            // 
            // dataGridView3
            // 
            this.dataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView3.Location = new System.Drawing.Point( 167, 37 );
            this.dataGridView3.Name = "dataGridView3";
            this.dataGridView3.Size = new System.Drawing.Size( 535, 199 );
            this.dataGridView3.TabIndex = 2;
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point( 12, 37 );
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size( 149, 199 );
            this.listBox1.TabIndex = 3;
            this.listBox1.SelectedIndexChanged += new System.EventHandler( this.listBox1_SelectedIndexChanged );
            // 
            // listBox2
            // 
            this.listBox2.FormattingEnabled = true;
            this.listBox2.Location = new System.Drawing.Point( 557, 397 );
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size( 120, 95 );
            this.listBox2.TabIndex = 4;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point( 167, 242 );
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size( 140, 17 );
            this.checkBox1.TabIndex = 8;
            this.checkBox1.Text = "Show/Hide Base/Offset";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler( this.checkBox1_CheckedChanged );
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point( 400, 239 );
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size( 193, 39 );
            this.label1.TabIndex = 9;
            this.label1.Text = "Ranges of cards in a cardset.\r\nMay be used for ranges of paper.\r\n(RB Red, RB Blue" +
                " tiny short subranges)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point( 554, 368 );
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size( 192, 26 );
            this.label2.TabIndex = 10;
            this.label2.Text = "This list is systems... may turn out\r\nthat we assign sub-ranges per-system...";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point( 9, 21 );
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size( 85, 13 );
            this.label3.TabIndex = 11;
            this.label3.Text = "Select a Cardset";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point( 164, 8 );
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size( 256, 26 );
            this.label4.TabIndex = 12;
            this.label4.Text = "These are sub-ranges of cards.\r\nThese are assigned a method of dealing (from belo" +
                "w)";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point( 12, 303 );
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size( 465, 91 );
            this.label5.TabIndex = 14;
            this.label5.Text = "Label 5";
            // 
            // editCardsets1
            // 
            this.editCardsets1.Location = new System.Drawing.Point( 12, 242 );
            this.editCardsets1.Name = "editCardsets1";
            this.editCardsets1.Size = new System.Drawing.Size( 68, 45 );
            this.editCardsets1.TabIndex = 13;
            this.editCardsets1.Text = "Edit Cardsets";
            this.editCardsets1.UseVisualStyleBackColor = true;
            // 
            // editCardsetRanges1
            // 
            this.editCardsetRanges1.Location = new System.Drawing.Point( 86, 242 );
            this.editCardsetRanges1.Name = "editCardsetRanges1";
            this.editCardsetRanges1.Size = new System.Drawing.Size( 75, 45 );
            this.editCardsetRanges1.TabIndex = 15;
            this.editCardsetRanges1.Text = "Edit Cardset\r\nRanges";
            this.editCardsetRanges1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point( 313, 461 );
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size( 93, 31 );
            this.button2.TabIndex = 17;
            this.button2.Text = "Save Changes";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler( this.button2_Click );
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point( 313, 498 );
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size( 93, 31 );
            this.button3.TabIndex = 18;
            this.button3.Text = "Cancel Changes";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler( this.button3_Click );
            // 
            // DealerEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size( 857, 550 );
            this.Controls.Add( this.button3 );
            this.Controls.Add( this.button2 );
            this.Controls.Add( this.editCardsetRanges1 );
            this.Controls.Add( this.label5 );
            this.Controls.Add( this.editCardsets1 );
            this.Controls.Add( this.label4 );
            this.Controls.Add( this.label3 );
            this.Controls.Add( this.label2 );
            this.Controls.Add( this.label1 );
            this.Controls.Add( this.checkBox1 );
            this.Controls.Add( this.listBox2 );
            this.Controls.Add( this.listBox1 );
            this.Controls.Add( this.dataGridView3 );
            this.Controls.Add( this.dataGridView1 );
            this.Name = "DealerEditor";
            this.Text = "DealerEditor";
            this.Load += new System.EventHandler( this.DealerEditor_Load );
            ( (System.ComponentModel.ISupportInitialize)( this.dataGridView1 ) ).EndInit();
            ( (System.ComponentModel.ISupportInitialize)( this.dataGridView3 ) ).EndInit();
            this.ResumeLayout( false );
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.DataGridView dataGridView1;
		private System.Windows.Forms.DataGridView dataGridView3;
		private System.Windows.Forms.ListBox listBox1;
		private System.Windows.Forms.ListBox listBox2;
		private System.Windows.Forms.CheckBox checkBox1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private OpenSkieScheduler3.Controls.Buttons.EditCardsets editCardsets1;
		private System.Windows.Forms.Label label5;
		private OpenSkieScheduler3.Controls.Buttons.EditCardsetRanges editCardsetRanges1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button3;
	}
}