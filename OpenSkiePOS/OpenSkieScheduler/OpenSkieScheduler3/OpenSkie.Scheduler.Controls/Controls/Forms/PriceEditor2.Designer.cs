namespace OpenSkieScheduler3.Controls.Forms
{
	partial class PriceEditor2
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
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this.label2 = new System.Windows.Forms.Label();
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.button3 = new System.Windows.Forms.Button();
			this.button4 = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.sessionPriceExceptionList1 = new OpenSkieScheduler3.Controls.Lists.SessionPriceExceptionList();
			this.sessionList1 = new OpenSkieScheduler3.Controls.Lists.SessionList();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			this.SuspendLayout();
			// 
			// dataGridView1
			// 
			this.dataGridView1.AllowUserToAddRows = false;
			this.dataGridView1.AllowUserToDeleteRows = false;
			this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.Location = new System.Drawing.Point(22, 212);
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.RowHeadersVisible = false;
			this.dataGridView1.Size = new System.Drawing.Size(423, 173);
			this.dataGridView1.TabIndex = 3;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(19, 31);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(44, 13);
			this.label2.TabIndex = 18;
			this.label2.Text = "Session";
			// 
			// button1
			// 
			this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.button1.Location = new System.Drawing.Point(187, 391);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(121, 23);
			this.button1.TabIndex = 22;
			this.button1.Text = "Save Changes";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// button2
			// 
			this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.button2.Location = new System.Drawing.Point(314, 391);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(121, 23);
			this.button2.TabIndex = 23;
			this.button2.Text = "Revert Changes";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(372, 50);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(75, 44);
			this.button3.TabIndex = 27;
			this.button3.Text = "Create Price Set";
			this.button3.UseVisualStyleBackColor = true;
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// button4
			// 
			this.button4.Location = new System.Drawing.Point(372, 100);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(75, 43);
			this.button4.TabIndex = 28;
			this.button4.Text = "Schedule Prices";
			this.button4.UseVisualStyleBackColor = true;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(184, 31);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(50, 13);
			this.label1.TabIndex = 29;
			this.label1.Text = "Price Set";
			// 
			// sessionPriceExceptionList1
			// 
			this.sessionPriceExceptionList1.BlockDoubleClick = true;
			this.sessionPriceExceptionList1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			this.sessionPriceExceptionList1.FormattingEnabled = true;
			this.sessionPriceExceptionList1.Location = new System.Drawing.Point(188, 50);
			this.sessionPriceExceptionList1.Name = "sessionPriceExceptionList1";
			this.sessionPriceExceptionList1.Size = new System.Drawing.Size(178, 147);
			this.sessionPriceExceptionList1.TabIndex = 30;
			this.sessionPriceExceptionList1.TabStops = null;
			this.sessionPriceExceptionList1.TargetList = null;
			// 
			// sessionList1
			// 
			this.sessionList1.BlockDoubleClick = true;
			this.sessionList1.DisplayMember = "session_name";
			this.sessionList1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			this.sessionList1.FormattingEnabled = true;
			this.sessionList1.Location = new System.Drawing.Point(22, 50);
			this.sessionList1.Name = "sessionList1";
			this.sessionList1.Size = new System.Drawing.Size(149, 147);
			this.sessionList1.TabIndex = 30;
			this.sessionList1.TabStops = null;
			this.sessionList1.TargetList = null;
			this.sessionList1.SelectedIndexChanged += new System.EventHandler(this.sessionList1_SelectedIndexChanged);
			// 
			// PriceEditor2
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(470, 423);
			this.Controls.Add(this.dataGridView1);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button3);
			this.Controls.Add(this.button4);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.sessionPriceExceptionList1);
			this.Controls.Add(this.sessionList1);
			this.Name = "PriceEditor2";
			this.Text = "Regular Price Editor";
			this.Load += new System.EventHandler(this.PriceEditor_Load);
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.DataGridView dataGridView1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.Button button4;
		private System.Windows.Forms.Label label1;
		private OpenSkieScheduler3.Controls.Lists.SessionPriceExceptionList sessionPriceExceptionList1;
		private Lists.SessionList sessionList1;
	}
}