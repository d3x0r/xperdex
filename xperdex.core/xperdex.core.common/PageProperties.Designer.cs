using xperdex.classes;
using xperdex.gui.PSI_Palette;
namespace xperdex.core
{
    partial class PageProperties
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
			this.colorDialog1 = new System.Windows.Forms.ColorDialog();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.Cancel = new System.Windows.Forms.Button();
			this.Okay = new System.Windows.Forms.Button();
			this.textBox3 = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.colorWell1 = new xperdex.gui.PSI_Palette.ColorWell();
			this.listBoxSecurity = new System.Windows.Forms.ListBox();
			this.buttonConfigureSecurity = new System.Windows.Forms.Button();
			this.buttonPickFile = new System.Windows.Forms.Button();
			this.textBoxPageTitle = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(155, 65);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(43, 20);
			this.textBox1.TabIndex = 0;
			// 
			// textBox2
			// 
			this.textBox2.Location = new System.Drawing.Point(204, 65);
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new System.Drawing.Size(43, 20);
			this.textBox2.TabIndex = 1;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.BackColor = System.Drawing.Color.Transparent;
			this.label1.Location = new System.Drawing.Point(24, 68);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(115, 13);
			this.label1.TabIndex = 2;
			this.label1.Text = "Grid Resolution (x by y)";
			// 
			// Cancel
			// 
			this.Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.Cancel.Location = new System.Drawing.Point(310, 223);
			this.Cancel.Name = "Cancel";
			this.Cancel.Size = new System.Drawing.Size(86, 28);
			this.Cancel.TabIndex = 3;
			this.Cancel.Text = "Cancel";
			this.Cancel.UseVisualStyleBackColor = true;
			// 
			// Okay
			// 
			this.Okay.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.Okay.Location = new System.Drawing.Point(402, 223);
			this.Okay.Name = "Okay";
			this.Okay.Size = new System.Drawing.Size(86, 28);
			this.Okay.TabIndex = 4;
			this.Okay.Text = "Okay";
			this.Okay.UseVisualStyleBackColor = true;
			this.Okay.Click += new System.EventHandler(this.Okay_Click);
			// 
			// textBox3
			// 
			this.textBox3.Location = new System.Drawing.Point(27, 108);
			this.textBox3.Name = "textBox3";
			this.textBox3.Size = new System.Drawing.Size(461, 20);
			this.textBox3.TabIndex = 5;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.BackColor = System.Drawing.Color.Transparent;
			this.label2.Location = new System.Drawing.Point(24, 92);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(97, 13);
			this.label2.TabIndex = 6;
			this.label2.Text = "Background Image";
			this.label2.Click += new System.EventHandler(this.label2_Click);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.BackColor = System.Drawing.Color.Transparent;
			this.label3.Location = new System.Drawing.Point(345, 29);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(92, 13);
			this.label3.TabIndex = 8;
			this.label3.Text = "Background Color";
			// 
			// colorWell1
			// 
			this.colorWell1.BackColor = System.Drawing.Color.Transparent;
			this.colorWell1.color = System.Drawing.Color.Black;
			this.colorWell1.Location = new System.Drawing.Point(443, 19);
			this.colorWell1.Movable = false;
			this.colorWell1.Name = "colorWell1";
			this.colorWell1.Size = new System.Drawing.Size(30, 30);
			this.colorWell1.TabIndex = 7;
			// 
			// listBoxSecurity
			// 
			this.listBoxSecurity.FormattingEnabled = true;
			this.listBoxSecurity.Location = new System.Drawing.Point(27, 154);
			this.listBoxSecurity.Name = "listBoxSecurity";
			this.listBoxSecurity.Size = new System.Drawing.Size(199, 56);
			this.listBoxSecurity.TabIndex = 10;
			// 
			// buttonConfigureSecurity
			// 
			this.buttonConfigureSecurity.Location = new System.Drawing.Point(27, 215);
			this.buttonConfigureSecurity.Name = "buttonConfigureSecurity";
			this.buttonConfigureSecurity.Size = new System.Drawing.Size(87, 36);
			this.buttonConfigureSecurity.TabIndex = 11;
			this.buttonConfigureSecurity.Text = "Configure Security";
			this.buttonConfigureSecurity.UseVisualStyleBackColor = true;
			this.buttonConfigureSecurity.Click += new System.EventHandler(this.buttonConfigureSecurity_Click);
			// 
			// buttonPickFile
			// 
			this.buttonPickFile.Location = new System.Drawing.Point(402, 135);
			this.buttonPickFile.Name = "buttonPickFile";
			this.buttonPickFile.Size = new System.Drawing.Size(86, 28);
			this.buttonPickFile.TabIndex = 12;
			this.buttonPickFile.Text = "Pick File";
			this.buttonPickFile.UseVisualStyleBackColor = true;
			this.buttonPickFile.Click += new System.EventHandler(this.pickfile_MouseClick);
			// 
			// textBoxPageTitle
			// 
			this.textBoxPageTitle.Location = new System.Drawing.Point(155, 19);
			this.textBoxPageTitle.Name = "textBoxPageTitle";
			this.textBoxPageTitle.Size = new System.Drawing.Size(146, 20);
			this.textBoxPageTitle.TabIndex = 13;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.BackColor = System.Drawing.Color.Transparent;
			this.label4.Location = new System.Drawing.Point(24, 22);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(55, 13);
			this.label4.TabIndex = 14;
			this.label4.Text = "Page Title";
			// 
			// PageProperties
			// 
			this.AcceptButton = this.Okay;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.Control;
			this.CancelButton = this.Cancel;
			this.ClientSize = new System.Drawing.Size(509, 274);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.textBoxPageTitle);
			this.Controls.Add(this.buttonPickFile);
			this.Controls.Add(this.buttonConfigureSecurity);
			this.Controls.Add(this.listBoxSecurity);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.colorWell1);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.textBox3);
			this.Controls.Add(this.Okay);
			this.Controls.Add(this.Cancel);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.textBox2);
			this.Controls.Add(this.textBox1);
			this.Name = "PageProperties";
			this.Text = "Page Properties";
			this.Load += new System.EventHandler(this.PageProperties_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ColorDialog colorDialog1;
        public System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Cancel;
        private System.Windows.Forms.Button Okay;
        public System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        public ColorWell colorWell1;
        public System.Windows.Forms.TextBox textBox3;
		private System.Windows.Forms.ListBox listBoxSecurity;
		private System.Windows.Forms.Button buttonConfigureSecurity;
		private System.Windows.Forms.Button buttonPickFile;
		private System.Windows.Forms.TextBox textBoxPageTitle;
		private System.Windows.Forms.Label label4;

    }
}