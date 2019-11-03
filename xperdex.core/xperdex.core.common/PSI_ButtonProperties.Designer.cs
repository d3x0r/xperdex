using xperdex.classes;
namespace xperdex.core
{
    partial class PSI_ButtonProperties
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
			this.NewName = new System.Windows.Forms.TextBox();
			this.AddSystem = new System.Windows.Forms.Button();
			this.Systems = new System.Windows.Forms.ListBox();
			this.Allow = new System.Windows.Forms.ListBox();
			this.Disallow = new System.Windows.Forms.ListBox();
			this.AddAllow = new System.Windows.Forms.Button();
			this.RemoveAllow = new System.Windows.Forms.Button();
			this.RemoveDisallow = new System.Windows.Forms.Button();
			this.AddDisallow = new System.Windows.Forms.Button();
			this.Okay = new System.Windows.Forms.Button();
			this.Cancel = new System.Windows.Forms.Button();
			this.Security = new System.Windows.Forms.ListBox();
			this.ButtonStyle = new System.Windows.Forms.ListBox();
			this.EditSecurity = new System.Windows.Forms.Button();
			this.PickFont = new System.Windows.Forms.Button();
			this.Pages = new System.Windows.Forms.ListBox();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.GotoPage = new System.Windows.Forms.CheckBox();
			this.trackBarDecalScale = new System.Windows.Forms.TrackBar();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.listBoxButtonAttributes = new System.Windows.Forms.ListBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.listBox1 = new System.Windows.Forms.ListBox();
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.trackBarDecalScale)).BeginInit();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// NewName
			// 
			this.NewName.Location = new System.Drawing.Point(20, 20);
			this.NewName.Name = "NewName";
			this.NewName.Size = new System.Drawing.Size(111, 20);
			this.NewName.TabIndex = 4;
			// 
			// AddSystem
			// 
			this.AddSystem.Location = new System.Drawing.Point(140, 19);
			this.AddSystem.Name = "AddSystem";
			this.AddSystem.Size = new System.Drawing.Size(96, 23);
			this.AddSystem.TabIndex = 5;
			this.AddSystem.Text = "Add System";
			this.AddSystem.UseVisualStyleBackColor = true;
			this.AddSystem.Click += new System.EventHandler(this.AddSystem_Click);
			// 
			// Systems
			// 
			this.Systems.FormattingEnabled = true;
			this.Systems.Location = new System.Drawing.Point(20, 46);
			this.Systems.Name = "Systems";
			this.Systems.Size = new System.Drawing.Size(111, 160);
			this.Systems.TabIndex = 6;
			this.Systems.SelectedIndexChanged += new System.EventHandler(this.Systems_SelectedIndexChanged);
			// 
			// Allow
			// 
			this.Allow.FormattingEnabled = true;
			this.Allow.Location = new System.Drawing.Point(157, 70);
			this.Allow.Name = "Allow";
			this.Allow.Size = new System.Drawing.Size(111, 56);
			this.Allow.TabIndex = 7;
			// 
			// Disallow
			// 
			this.Disallow.FormattingEnabled = true;
			this.Disallow.Location = new System.Drawing.Point(157, 152);
			this.Disallow.Name = "Disallow";
			this.Disallow.Size = new System.Drawing.Size(111, 56);
			this.Disallow.TabIndex = 8;
			// 
			// AddAllow
			// 
			this.AddAllow.Location = new System.Drawing.Point(277, 70);
			this.AddAllow.Name = "AddAllow";
			this.AddAllow.Size = new System.Drawing.Size(96, 23);
			this.AddAllow.TabIndex = 9;
			this.AddAllow.Text = "Add Allow";
			this.AddAllow.UseVisualStyleBackColor = true;
			this.AddAllow.Click += new System.EventHandler(this.AddAllow_Click);
			// 
			// RemoveAllow
			// 
			this.RemoveAllow.Location = new System.Drawing.Point(277, 99);
			this.RemoveAllow.Name = "RemoveAllow";
			this.RemoveAllow.Size = new System.Drawing.Size(96, 23);
			this.RemoveAllow.TabIndex = 10;
			this.RemoveAllow.Text = "Remove Allow";
			this.RemoveAllow.UseVisualStyleBackColor = true;
			this.RemoveAllow.Click += new System.EventHandler(this.RemoveAllow_Click);
			// 
			// RemoveDisallow
			// 
			this.RemoveDisallow.Location = new System.Drawing.Point(274, 181);
			this.RemoveDisallow.Name = "RemoveDisallow";
			this.RemoveDisallow.Size = new System.Drawing.Size(99, 23);
			this.RemoveDisallow.TabIndex = 12;
			this.RemoveDisallow.Text = "Remove Disallow";
			this.RemoveDisallow.UseVisualStyleBackColor = true;
			this.RemoveDisallow.Click += new System.EventHandler(this.RemoveDisallow_Click);
			// 
			// AddDisallow
			// 
			this.AddDisallow.Location = new System.Drawing.Point(274, 152);
			this.AddDisallow.Name = "AddDisallow";
			this.AddDisallow.Size = new System.Drawing.Size(99, 23);
			this.AddDisallow.TabIndex = 11;
			this.AddDisallow.Text = "Add Disallow";
			this.AddDisallow.UseVisualStyleBackColor = true;
			this.AddDisallow.Click += new System.EventHandler(this.AddDisallow_Click);
			// 
			// Okay
			// 
			this.Okay.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.Okay.Location = new System.Drawing.Point(103, 378);
			this.Okay.Name = "Okay";
			this.Okay.Size = new System.Drawing.Size(83, 34);
			this.Okay.TabIndex = 13;
			this.Okay.Text = "Okay";
			this.Okay.UseVisualStyleBackColor = true;
			this.Okay.Click += new System.EventHandler(this.button6_Click);
			// 
			// Cancel
			// 
			this.Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.Cancel.Location = new System.Drawing.Point(14, 378);
			this.Cancel.Name = "Cancel";
			this.Cancel.Size = new System.Drawing.Size(83, 34);
			this.Cancel.TabIndex = 14;
			this.Cancel.Text = "Cancel";
			this.Cancel.UseVisualStyleBackColor = true;
			// 
			// Security
			// 
			this.Security.FormattingEnabled = true;
			this.Security.Location = new System.Drawing.Point(12, 300);
			this.Security.Name = "Security";
			this.Security.Size = new System.Drawing.Size(174, 30);
			this.Security.TabIndex = 15;
			// 
			// ButtonStyle
			// 
			this.ButtonStyle.FormattingEnabled = true;
			this.ButtonStyle.Location = new System.Drawing.Point(12, 73);
			this.ButtonStyle.Name = "ButtonStyle";
			this.ButtonStyle.Size = new System.Drawing.Size(138, 95);
			this.ButtonStyle.TabIndex = 16;
			// 
			// EditSecurity
			// 
			this.EditSecurity.Location = new System.Drawing.Point(12, 336);
			this.EditSecurity.Name = "EditSecurity";
			this.EditSecurity.Size = new System.Drawing.Size(90, 23);
			this.EditSecurity.TabIndex = 19;
			this.EditSecurity.Text = "Edit Security";
			this.EditSecurity.UseVisualStyleBackColor = true;
			this.EditSecurity.Click += new System.EventHandler(this.EditSecurity_Click);
			// 
			// PickFont
			// 
			this.PickFont.Location = new System.Drawing.Point(156, 51);
			this.PickFont.Name = "PickFont";
			this.PickFont.Size = new System.Drawing.Size(75, 23);
			this.PickFont.TabIndex = 20;
			this.PickFont.Text = "Font";
			this.PickFont.UseVisualStyleBackColor = true;
			this.PickFont.Click += new System.EventHandler(this.PickFont_Click);
			// 
			// Pages
			// 
			this.Pages.FormattingEnabled = true;
			this.Pages.Location = new System.Drawing.Point(12, 193);
			this.Pages.Name = "Pages";
			this.Pages.Size = new System.Drawing.Size(138, 95);
			this.Pages.TabIndex = 21;
			this.Pages.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(75, 11);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(174, 20);
			this.textBox1.TabIndex = 22;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(10, 14);
			this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(62, 13);
			this.label1.TabIndex = 23;
			this.label1.Text = "Button Text";
			// 
			// GotoPage
			// 
			this.GotoPage.AutoSize = true;
			this.GotoPage.Location = new System.Drawing.Point(12, 173);
			this.GotoPage.Margin = new System.Windows.Forms.Padding(2);
			this.GotoPage.Name = "GotoPage";
			this.GotoPage.Size = new System.Drawing.Size(86, 17);
			this.GotoPage.TabIndex = 24;
			this.GotoPage.Text = "Goto Page...";
			this.GotoPage.UseVisualStyleBackColor = true;
			// 
			// trackBarDecalScale
			// 
			this.trackBarDecalScale.Location = new System.Drawing.Point(260, 6);
			this.trackBarDecalScale.Maximum = 21;
			this.trackBarDecalScale.Name = "trackBarDecalScale";
			this.trackBarDecalScale.Size = new System.Drawing.Size(188, 45);
			this.trackBarDecalScale.TabIndex = 25;
			// 
			// textBox2
			// 
			this.textBox2.Location = new System.Drawing.Point(352, 51);
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new System.Drawing.Size(194, 20);
			this.textBox2.TabIndex = 26;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(280, 54);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(67, 13);
			this.label2.TabIndex = 27;
			this.label2.Text = "Decal Image";
			// 
			// listBoxButtonAttributes
			// 
			this.listBoxButtonAttributes.FormattingEnabled = true;
			this.listBoxButtonAttributes.Location = new System.Drawing.Point(166, 82);
			this.listBoxButtonAttributes.Name = "listBoxButtonAttributes";
			this.listBoxButtonAttributes.Size = new System.Drawing.Size(181, 82);
			this.listBoxButtonAttributes.TabIndex = 28;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.Allow);
			this.groupBox1.Controls.Add(this.Disallow);
			this.groupBox1.Controls.Add(this.NewName);
			this.groupBox1.Controls.Add(this.RemoveDisallow);
			this.groupBox1.Controls.Add(this.AddDisallow);
			this.groupBox1.Controls.Add(this.AddSystem);
			this.groupBox1.Controls.Add(this.RemoveAllow);
			this.groupBox1.Controls.Add(this.AddAllow);
			this.groupBox1.Controls.Add(this.Systems);
			this.groupBox1.Location = new System.Drawing.Point(212, 193);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(388, 218);
			this.groupBox1.TabIndex = 29;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "System Visibility Configuration";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(154, 136);
			this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(77, 13);
			this.label4.TabIndex = 31;
			this.label4.Text = "Must hide on...";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(154, 54);
			this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(95, 13);
			this.label3.TabIndex = 30;
			this.label3.Text = "Allowed to Show...";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(353, 73);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(215, 52);
			this.label5.TabIndex = 30;
			this.label5.Text = "\'Button Style\' is how the button looks(shape)\r\nButton Attributes is how the butto" +
    "n is\r\ncolored.  Slider at top controls how much\r\npad is around the decal image.." +
    "..";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(11, 56);
			this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(64, 13);
			this.label6.TabIndex = 32;
			this.label6.Text = "Button Style";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(366, 134);
			this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(112, 13);
			this.label7.TabIndex = 35;
			this.label7.Text = "User Allowed to See...";
			// 
			// listBox1
			// 
			this.listBox1.FormattingEnabled = true;
			this.listBox1.Location = new System.Drawing.Point(369, 150);
			this.listBox1.Name = "listBox1";
			this.listBox1.Size = new System.Drawing.Size(111, 30);
			this.listBox1.TabIndex = 32;
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(489, 163);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(96, 23);
			this.button1.TabIndex = 34;
			this.button1.Text = "Remove Allow";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(489, 134);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(96, 23);
			this.button2.TabIndex = 33;
			this.button2.Text = "Add Allow";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// PSI_ButtonProperties
			// 
			this.AcceptButton = this.Okay;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.Cancel;
			this.ClientSize = new System.Drawing.Size(622, 434);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.listBox1);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.listBoxButtonAttributes);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.textBox2);
			this.Controls.Add(this.trackBarDecalScale);
			this.Controls.Add(this.GotoPage);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.Pages);
			this.Controls.Add(this.PickFont);
			this.Controls.Add(this.EditSecurity);
			this.Controls.Add(this.ButtonStyle);
			this.Controls.Add(this.Security);
			this.Controls.Add(this.Cancel);
			this.Controls.Add(this.Okay);
			this.Name = "PSI_ButtonProperties";
			this.Text = "General Button Properties";
			this.Load += new System.EventHandler(this.PSI_ButtonProperties_Load);
			((System.ComponentModel.ISupportInitialize)(this.trackBarDecalScale)).EndInit();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

		private System.Windows.Forms.TextBox NewName;
        private System.Windows.Forms.Button AddSystem;
        private System.Windows.Forms.ListBox Systems;
        private System.Windows.Forms.ListBox Allow;
        private System.Windows.Forms.ListBox Disallow;
        private System.Windows.Forms.Button AddAllow;
        private System.Windows.Forms.Button RemoveAllow;
        private System.Windows.Forms.Button RemoveDisallow;
        private System.Windows.Forms.Button AddDisallow;
        private System.Windows.Forms.Button Okay;
        private System.Windows.Forms.Button Cancel;
        private System.Windows.Forms.ListBox Security;
		private System.Windows.Forms.ListBox ButtonStyle;
        private System.Windows.Forms.Button EditSecurity;
        private System.Windows.Forms.Button PickFont;
        private System.Windows.Forms.ListBox Pages;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
		 private System.Windows.Forms.CheckBox GotoPage;
		private System.Windows.Forms.TrackBar trackBarDecalScale;
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ListBox listBoxButtonAttributes;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.ListBox listBox1;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;

    }
}