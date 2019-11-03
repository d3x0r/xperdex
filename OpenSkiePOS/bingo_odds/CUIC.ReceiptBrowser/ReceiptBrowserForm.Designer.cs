namespace CUIC.ReceiptBrowser
{
	partial class ReceiptBrowserForm
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
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.code_txt = new System.Windows.Forms.TextBox();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.htmlEditor2 = new CUIC.ReceiptBrowser.HtmlEditor();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.buttonStart = new System.Windows.Forms.Button();
			this.buttonEpson = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.tabControl1.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.tabPage2.SuspendLayout();
			this.SuspendLayout();
			// 
			// code_txt
			// 
			this.code_txt.Location = new System.Drawing.Point(20, 18);
			this.code_txt.Margin = new System.Windows.Forms.Padding(2);
			this.code_txt.Multiline = true;
			this.code_txt.Name = "code_txt";
			this.code_txt.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.code_txt.Size = new System.Drawing.Size(380, 616);
			this.code_txt.TabIndex = 6;
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Controls.Add(this.tabPage2);
			this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tabControl1.Location = new System.Drawing.Point(12, 12);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(425, 691);
			this.tabControl1.TabIndex = 8;
			// 
			// tabPage1
			// 
			this.tabPage1.BackColor = System.Drawing.Color.LightGray;
			this.tabPage1.Controls.Add(this.htmlEditor2);
			this.tabPage1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tabPage1.Location = new System.Drawing.Point(4, 25);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new System.Drawing.Size(417, 662);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "    Html Viewer   ";
			this.tabPage1.UseVisualStyleBackColor = true;
			// 
			// htmlEditor2
			// 
			this.htmlEditor2.AbsolutePositioningEnabled = false;
			this.htmlEditor2.AllowInPlaceNavigation = false;
			this.htmlEditor2.Border3d = false;
			this.htmlEditor2.BordersVisible = false;
			this.htmlEditor2.DesignModeEnabled = false;
			this.htmlEditor2.FlatScrollBars = false;
			this.htmlEditor2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.htmlEditor2.Location = new System.Drawing.Point(19, 20);
			this.htmlEditor2.MultipleSelectionEnabled = false;
			this.htmlEditor2.Name = "htmlEditor2";
			this.htmlEditor2.ScriptEnabled = false;
			this.htmlEditor2.ScriptObject = null;
			this.htmlEditor2.ScrollBarsEnabled = true;
			this.htmlEditor2.Size = new System.Drawing.Size(374, 612);
			this.htmlEditor2.TabIndex = 7;
			this.htmlEditor2.Text = "htmlEditor2";
			// 
			// tabPage2
			// 
			this.tabPage2.BackColor = System.Drawing.Color.LightGray;
			this.tabPage2.Controls.Add(this.code_txt);
			this.tabPage2.Location = new System.Drawing.Point(4, 25);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage2.Size = new System.Drawing.Size(417, 662);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "   Code Viewer   ";
			this.tabPage2.UseVisualStyleBackColor = true;
			// 
			// buttonStart
			// 
			this.buttonStart.Enabled = false;
			this.buttonStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.buttonStart.Location = new System.Drawing.Point(492, 119);
			this.buttonStart.Name = "buttonStart";
			this.buttonStart.Size = new System.Drawing.Size(196, 69);
			this.buttonStart.TabIndex = 9;
			this.buttonStart.Text = "Print Start TSP700";
			this.buttonStart.UseVisualStyleBackColor = true;
			this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
			// 
			// buttonEpson
			// 
			this.buttonEpson.Enabled = false;
			this.buttonEpson.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.buttonEpson.Location = new System.Drawing.Point(492, 194);
			this.buttonEpson.Name = "buttonEpson";
			this.buttonEpson.Size = new System.Drawing.Size(196, 69);
			this.buttonEpson.TabIndex = 9;
			this.buttonEpson.Text = "Print Epson";
			this.buttonEpson.UseVisualStyleBackColor = true;
			this.buttonEpson.Click += new System.EventHandler(this.buttonEpson_Click);
			// 
			// button1
			// 
			this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.button1.Location = new System.Drawing.Point(492, 402);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(196, 69);
			this.button1.TabIndex = 9;
			this.button1.Text = "Close";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// ReceiptBrowserForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(716, 734);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.buttonEpson);
			this.Controls.Add(this.buttonStart);
			this.Controls.Add(this.tabControl1);
			this.Name = "ReceiptBrowserForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Html Editor";
			this.Load += new System.EventHandler(this.ReceiptBrowserForm_Load);
			this.tabControl1.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.tabPage2.ResumeLayout(false);
			this.tabPage2.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TextBox code_txt;
		private HtmlEditor htmlEditor2;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.Button buttonStart;
		private System.Windows.Forms.Button buttonEpson;
		private System.Windows.Forms.Button button1;
			
	}
}

