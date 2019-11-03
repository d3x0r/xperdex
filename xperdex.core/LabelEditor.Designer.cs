namespace xperdex.core
{
	partial class LabelEditor
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
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.listBoxVariables = new System.Windows.Forms.ListBox();
			this.buttonEditFonts = new System.Windows.Forms.Button();
			this.buttonOkay = new System.Windows.Forms.Button();
			this.buttonCancel = new System.Windows.Forms.Button();
			this.listBoxFonts = new System.Windows.Forms.ListBox();
			this.colorWellBackground = new xperdex.gui.PSI_Palette.ColorWell();
			this.colorWellText = new xperdex.gui.PSI_Palette.ColorWell();
			this.label1 = new System.Windows.Forms.Label();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.radioButton3 = new System.Windows.Forms.RadioButton();
			this.radioButton2 = new System.Windows.Forms.RadioButton();
			this.radioButton1 = new System.Windows.Forms.RadioButton();
			this.label2 = new System.Windows.Forms.Label();
			this.listBoxVariableArrays = new System.Windows.Forms.ListBox();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(12, 39);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(525, 20);
			this.textBox1.TabIndex = 0;
			// 
			// listBoxVariables
			// 
			this.listBoxVariables.FormattingEnabled = true;
			this.listBoxVariables.Location = new System.Drawing.Point(356, 76);
			this.listBoxVariables.Name = "listBoxVariables";
			this.listBoxVariables.Size = new System.Drawing.Size(181, 95);
			this.listBoxVariables.TabIndex = 1;
			this.listBoxVariables.DoubleClick += new System.EventHandler(this.listBoxVariables_SelectedIndexChanged);
			// 
			// buttonEditFonts
			// 
			this.buttonEditFonts.Location = new System.Drawing.Point(138, 195);
			this.buttonEditFonts.Name = "buttonEditFonts";
			this.buttonEditFonts.Size = new System.Drawing.Size(75, 23);
			this.buttonEditFonts.TabIndex = 4;
			this.buttonEditFonts.Text = "Edit Fonts";
			this.buttonEditFonts.UseVisualStyleBackColor = true;
			this.buttonEditFonts.Click += new System.EventHandler(this.buttonEditFonts_Click);
			// 
			// buttonOkay
			// 
			this.buttonOkay.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.buttonOkay.Location = new System.Drawing.Point(439, 301);
			this.buttonOkay.Name = "buttonOkay";
			this.buttonOkay.Size = new System.Drawing.Size(75, 23);
			this.buttonOkay.TabIndex = 5;
			this.buttonOkay.Text = "Okay";
			this.buttonOkay.UseVisualStyleBackColor = true;
			// 
			// buttonCancel
			// 
			this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.buttonCancel.Location = new System.Drawing.Point(520, 301);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(75, 23);
			this.buttonCancel.TabIndex = 6;
			this.buttonCancel.Text = "Cancel";
			this.buttonCancel.UseVisualStyleBackColor = true;
			// 
			// listBoxFonts
			// 
			this.listBoxFonts.FormattingEnabled = true;
			this.listBoxFonts.Location = new System.Drawing.Point(12, 195);
			this.listBoxFonts.Name = "listBoxFonts";
			this.listBoxFonts.Size = new System.Drawing.Size(120, 95);
			this.listBoxFonts.TabIndex = 7;
			// 
			// colorWellBackground
			// 
			this.colorWellBackground.BackColor = System.Drawing.Color.Transparent;
			this.colorWellBackground.color = System.Drawing.Color.Black;
			this.colorWellBackground.Location = new System.Drawing.Point(22, 120);
			this.colorWellBackground.Movable = false;
			this.colorWellBackground.Name = "colorWellBackground";
			this.colorWellBackground.Size = new System.Drawing.Size(26, 24);
			this.colorWellBackground.TabIndex = 3;
			// 
			// colorWellText
			// 
			this.colorWellText.BackColor = System.Drawing.Color.Transparent;
			this.colorWellText.color = System.Drawing.Color.Black;
			this.colorWellText.Location = new System.Drawing.Point(22, 76);
			this.colorWellText.Movable = false;
			this.colorWellText.Name = "colorWellText";
			this.colorWellText.Size = new System.Drawing.Size(26, 24);
			this.colorWellText.TabIndex = 2;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(53, 83);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(55, 13);
			this.label1.TabIndex = 8;
			this.label1.Text = "Text Color";
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.radioButton3);
			this.groupBox1.Controls.Add(this.radioButton2);
			this.groupBox1.Controls.Add(this.radioButton1);
			this.groupBox1.Location = new System.Drawing.Point(178, 76);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(122, 100);
			this.groupBox1.TabIndex = 9;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Alignemnt";
			// 
			// radioButton3
			// 
			this.radioButton3.AutoSize = true;
			this.radioButton3.Location = new System.Drawing.Point(6, 66);
			this.radioButton3.Name = "radioButton3";
			this.radioButton3.Size = new System.Drawing.Size(50, 17);
			this.radioButton3.TabIndex = 2;
			this.radioButton3.TabStop = true;
			this.radioButton3.Text = "Right";
			this.radioButton3.UseVisualStyleBackColor = true;
			// 
			// radioButton2
			// 
			this.radioButton2.AutoSize = true;
			this.radioButton2.Location = new System.Drawing.Point(7, 43);
			this.radioButton2.Name = "radioButton2";
			this.radioButton2.Size = new System.Drawing.Size(56, 17);
			this.radioButton2.TabIndex = 1;
			this.radioButton2.TabStop = true;
			this.radioButton2.Text = "Center";
			this.radioButton2.UseVisualStyleBackColor = true;
			// 
			// radioButton1
			// 
			this.radioButton1.AutoSize = true;
			this.radioButton1.Location = new System.Drawing.Point(7, 20);
			this.radioButton1.Name = "radioButton1";
			this.radioButton1.Size = new System.Drawing.Size(43, 17);
			this.radioButton1.TabIndex = 0;
			this.radioButton1.TabStop = true;
			this.radioButton1.Text = "Left";
			this.radioButton1.UseVisualStyleBackColor = true;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(13, 179);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(37, 13);
			this.label2.TabIndex = 10;
			this.label2.Text = "Font...";
			// 
			// listBoxVariableArrays
			// 
			this.listBoxVariableArrays.FormattingEnabled = true;
			this.listBoxVariableArrays.Location = new System.Drawing.Point(356, 177);
			this.listBoxVariableArrays.Name = "listBoxVariableArrays";
			this.listBoxVariableArrays.Size = new System.Drawing.Size(181, 95);
			this.listBoxVariableArrays.TabIndex = 11;
			this.listBoxVariableArrays.DoubleClick += new System.EventHandler(this.listBoxVariableArrays_SelectedIndexChanged);
			// 
			// LabelEditor
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(607, 336);
			this.Controls.Add(this.listBoxVariableArrays);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.listBoxFonts);
			this.Controls.Add(this.buttonCancel);
			this.Controls.Add(this.buttonOkay);
			this.Controls.Add(this.buttonEditFonts);
			this.Controls.Add(this.colorWellBackground);
			this.Controls.Add(this.colorWellText);
			this.Controls.Add(this.listBoxVariables);
			this.Controls.Add(this.textBox1);
			this.Name = "LabelEditor";
			this.Text = "Label Editor";
			this.Load += new System.EventHandler(this.LabelEditor_Load);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.ListBox listBoxVariables;
		private xperdex.gui.PSI_Palette.ColorWell colorWellText;
		private xperdex.gui.PSI_Palette.ColorWell colorWellBackground;
		private System.Windows.Forms.Button buttonEditFonts;
		private System.Windows.Forms.Button buttonOkay;
		private System.Windows.Forms.Button buttonCancel;
		private System.Windows.Forms.ListBox listBoxFonts;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.RadioButton radioButton3;
		private System.Windows.Forms.RadioButton radioButton2;
		private System.Windows.Forms.RadioButton radioButton1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ListBox listBoxVariableArrays;
	}
}