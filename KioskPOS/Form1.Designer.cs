namespace MobilePOS
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
			this.listBox1 = new MobilePOS.MyListBox();
			this.psI_Button1 = new xperdex.core.PSI_Button();
			this.psI_Button2 = new xperdex.core.PSI_Button();
			this.textBoxSaleTotal = new System.Windows.Forms.TextBox();
			this.textBoxCash = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// listBox1
			// 
			this.listBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.listBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.listBox1.FormattingEnabled = true;
			this.listBox1.ItemHeight = 31;
			this.listBox1.Location = new System.Drawing.Point(12, 12);
			this.listBox1.Name = "listBox1";
			this.listBox1.Size = new System.Drawing.Size(448, 314);
			this.listBox1.TabIndex = 0;
			this.listBox1.TabStops = null;
			// 
			// psI_Button1
			// 
			this.psI_Button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.psI_Button1.BackColor = System.Drawing.Color.Transparent;
			this.psI_Button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.psI_Button1.Location = new System.Drawing.Point(472, 75);
			this.psI_Button1.Movable = false;
			this.psI_Button1.Name = "psI_Button1";
			this.psI_Button1.Size = new System.Drawing.Size(129, 57);
			this.psI_Button1.TabIndex = 1;
			this.psI_Button1.Visible = false;
            this.psI_Button1.Click += new /*EventHandler*/ xperdex.core.PSI_Button.ClickProc( this.psI_Button1_Click );
			// 
			// psI_Button2
			// 
			this.psI_Button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.psI_Button2.BackColor = System.Drawing.Color.Transparent;
			this.psI_Button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.psI_Button2.Location = new System.Drawing.Point(483, 12);
			this.psI_Button2.Movable = false;
			this.psI_Button2.Name = "psI_Button2";
			this.psI_Button2.Size = new System.Drawing.Size(129, 57);
			this.psI_Button2.TabIndex = 2;
            this.psI_Button2.Click += new /*EventHandler*/ xperdex.core.PSI_Button.ClickProc( this.psI_Button2_Click );
			// 
			// textBoxSaleTotal
			// 
			this.textBoxSaleTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxSaleTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold);
			this.textBoxSaleTotal.Location = new System.Drawing.Point(487, 207);
			this.textBoxSaleTotal.Name = "textBoxSaleTotal";
			this.textBoxSaleTotal.Size = new System.Drawing.Size(129, 38);
			this.textBoxSaleTotal.TabIndex = 3;
			// 
			// textBoxCash
			// 
			this.textBoxCash.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxCash.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold);
			this.textBoxCash.Location = new System.Drawing.Point(487, 288);
			this.textBoxCash.Name = "textBoxCash";
			this.textBoxCash.Size = new System.Drawing.Size(129, 38);
			this.textBoxCash.TabIndex = 4;
			// 
			// label1
			// 
			this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold);
			this.label1.Location = new System.Drawing.Point(466, 173);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(146, 31);
			this.label1.TabIndex = 5;
			this.label1.Text = "Sale Total";
			// 
			// label2
			// 
			this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold);
			this.label2.Location = new System.Drawing.Point(466, 254);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(82, 31);
			this.label2.TabIndex = 6;
			this.label2.Text = "Cash";
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(640, 356);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.textBoxCash);
			this.Controls.Add(this.textBoxSaleTotal);
			this.Controls.Add(this.psI_Button2);
			this.Controls.Add(this.psI_Button1);
			this.Controls.Add(this.listBox1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Name = "Form1";
			this.Text = "Form1";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private MobilePOS.MyListBox listBox1;
		private xperdex.core.PSI_Button psI_Button1;
		private xperdex.core.PSI_Button psI_Button2;
		private System.Windows.Forms.TextBox textBoxSaleTotal;
		private System.Windows.Forms.TextBox textBoxCash;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
	}
}

