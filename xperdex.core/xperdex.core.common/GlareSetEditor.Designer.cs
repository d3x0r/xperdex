using xperdex.classes;
using xperdex.gui.PSI_Palette;
namespace xperdex.core
{
	partial class GlareSetEditor
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
			if( disposing && (components != null) )
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
			this.buttonOK = new System.Windows.Forms.Button();
			this.buttonCancel = new System.Windows.Forms.Button();
			this.buttonCreateGlareset = new System.Windows.Forms.Button();
			this.button3 = new System.Windows.Forms.Button();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.radioButton3 = new System.Windows.Forms.RadioButton();
			this.radioButton2 = new System.Windows.Forms.RadioButton();
			this.radioButton1 = new System.Windows.Forms.RadioButton();
			this.label13 = new System.Windows.Forms.Label();
			this.colorWellHighlight = new xperdex.gui.PSI_Palette.ColorWell();
			this.checkboxTextAboveGlare = new System.Windows.Forms.CheckBox();
			this.label10 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.checkBoxTextAboveImage = new System.Windows.Forms.CheckBox();
			this.label7 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.colorWellTertiaryTest = new xperdex.gui.PSI_Palette.ColorWell();
			this.colorWellSecondaryTest = new xperdex.gui.PSI_Palette.ColorWell();
			this.colorWellPrimaryTest = new xperdex.gui.PSI_Palette.ColorWell();
			this.button5 = new System.Windows.Forms.Button();
			this.textBoxGlare = new System.Windows.Forms.TextBox();
			this.button4 = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.buttonImagePick1 = new System.Windows.Forms.Button();
			this.textBoxPressed = new System.Windows.Forms.TextBox();
			this.textBoxNormal = new System.Windows.Forms.TextBox();
			this.textBoxMask = new System.Windows.Forms.TextBox();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.label14 = new System.Windows.Forms.Label();
			this.colorWellText = new xperdex.gui.PSI_Palette.ColorWell();
			this.buttonDeleteStyle = new System.Windows.Forms.Button();
			this.buttonNewStyle = new System.Windows.Forms.Button();
			this.label19 = new System.Windows.Forms.Label();
			this.label18 = new System.Windows.Forms.Label();
			this.colorWellTertiaryHighlight = new xperdex.gui.PSI_Palette.ColorWell();
			this.colorWellSecondaryHighlight = new xperdex.gui.PSI_Palette.ColorWell();
			this.colorWellPrimaryHighlight = new xperdex.gui.PSI_Palette.ColorWell();
			this.label15 = new System.Windows.Forms.Label();
			this.label16 = new System.Windows.Forms.Label();
			this.label17 = new System.Windows.Forms.Label();
			this.colorWellTertiary = new xperdex.gui.PSI_Palette.ColorWell();
			this.colorWellSecondary = new xperdex.gui.PSI_Palette.ColorWell();
			this.colorWellPrimary = new xperdex.gui.PSI_Palette.ColorWell();
			this.label12 = new System.Windows.Forms.Label();
			this.listBox2 = new System.Windows.Forms.ListBox();
			this.textBox4 = new System.Windows.Forms.TextBox();
			this.textBox5 = new System.Windows.Forms.TextBox();
			this.textBox6 = new System.Windows.Forms.TextBox();
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.label1 = new System.Windows.Forms.Label();
			this.label20 = new System.Windows.Forms.Label();
			this.buttonHighlightSelect = new System.Windows.Forms.Button();
			this.textBoxHighlightNormal = new System.Windows.Forms.TextBox();
			this.label21 = new System.Windows.Forms.Label();
			this.buttonHighlightPressSelect = new System.Windows.Forms.Button();
			this.textBoxHighlightPressed = new System.Windows.Forms.TextBox();
			this.label11 = new System.Windows.Forms.Label();
			this.label22 = new System.Windows.Forms.Label();
			this.buttonApply = new System.Windows.Forms.Button();
			this.psI_ButtonHighlightPressed = new xperdex.core.PSI_Button();
			this.psI_ButtonHighlightDepressed = new xperdex.core.PSI_Button();
			this.psI_ButtonPressed = new xperdex.core.PSI_Button();
			this.psI_ButtonDepressed = new xperdex.core.PSI_Button();
			this.psI_Button1 = new xperdex.core.PSI_Button();
			this.psI_Button2 = new xperdex.core.PSI_Button();
			this.tabControl1.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.tabPage2.SuspendLayout();
			this.SuspendLayout();
			// 
			// listBox1
			// 
			this.listBox1.FormattingEnabled = true;
			this.listBox1.Location = new System.Drawing.Point(438, 12);
			this.listBox1.Margin = new System.Windows.Forms.Padding(2);
			this.listBox1.Name = "listBox1";
			this.listBox1.Size = new System.Drawing.Size(221, 186);
			this.listBox1.TabIndex = 0;
			this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
			// 
			// buttonOK
			// 
			this.buttonOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.buttonOK.Location = new System.Drawing.Point(630, 430);
			this.buttonOK.Margin = new System.Windows.Forms.Padding(2);
			this.buttonOK.Name = "buttonOK";
			this.buttonOK.Size = new System.Drawing.Size(56, 31);
			this.buttonOK.TabIndex = 1;
			this.buttonOK.Text = "OK";
			this.buttonOK.UseVisualStyleBackColor = true;
			// 
			// buttonCancel
			// 
			this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.buttonCancel.Location = new System.Drawing.Point(567, 430);
			this.buttonCancel.Margin = new System.Windows.Forms.Padding(2);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(56, 33);
			this.buttonCancel.TabIndex = 2;
			this.buttonCancel.Text = "Cancel";
			this.buttonCancel.UseVisualStyleBackColor = true;
			// 
			// buttonCreateGlareset
			// 
			this.buttonCreateGlareset.Location = new System.Drawing.Point(438, 209);
			this.buttonCreateGlareset.Margin = new System.Windows.Forms.Padding(2);
			this.buttonCreateGlareset.Name = "buttonCreateGlareset";
			this.buttonCreateGlareset.Size = new System.Drawing.Size(107, 49);
			this.buttonCreateGlareset.TabIndex = 4;
			this.buttonCreateGlareset.Text = "Create";
			this.buttonCreateGlareset.UseVisualStyleBackColor = true;
			this.buttonCreateGlareset.Click += new System.EventHandler(this.buttonCreateGlareset_Click);
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(552, 209);
			this.button3.Margin = new System.Windows.Forms.Padding(2);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(107, 49);
			this.button3.TabIndex = 5;
			this.button3.Text = "Destroy";
			this.button3.UseVisualStyleBackColor = true;
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// tabControl1
			// 
			this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Controls.Add(this.tabPage2);
			this.tabControl1.Location = new System.Drawing.Point(11, 32);
			this.tabControl1.Margin = new System.Windows.Forms.Padding(2);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(679, 388);
			this.tabControl1.TabIndex = 6;
			// 
			// tabPage1
			// 
			this.tabPage1.BackColor = System.Drawing.SystemColors.Control;
			this.tabPage1.Controls.Add(this.label11);
			this.tabPage1.Controls.Add(this.label22);
			this.tabPage1.Controls.Add(this.psI_ButtonHighlightPressed);
			this.tabPage1.Controls.Add(this.psI_ButtonHighlightDepressed);
			this.tabPage1.Controls.Add(this.label21);
			this.tabPage1.Controls.Add(this.buttonHighlightPressSelect);
			this.tabPage1.Controls.Add(this.textBoxHighlightPressed);
			this.tabPage1.Controls.Add(this.label20);
			this.tabPage1.Controls.Add(this.buttonHighlightSelect);
			this.tabPage1.Controls.Add(this.textBoxHighlightNormal);
			this.tabPage1.Controls.Add(this.radioButton3);
			this.tabPage1.Controls.Add(this.radioButton2);
			this.tabPage1.Controls.Add(this.radioButton1);
			this.tabPage1.Controls.Add(this.label13);
			this.tabPage1.Controls.Add(this.colorWellHighlight);
			this.tabPage1.Controls.Add(this.button3);
			this.tabPage1.Controls.Add(this.buttonCreateGlareset);
			this.tabPage1.Controls.Add(this.checkboxTextAboveGlare);
			this.tabPage1.Controls.Add(this.label10);
			this.tabPage1.Controls.Add(this.listBox1);
			this.tabPage1.Controls.Add(this.label9);
			this.tabPage1.Controls.Add(this.label8);
			this.tabPage1.Controls.Add(this.checkBoxTextAboveImage);
			this.tabPage1.Controls.Add(this.label7);
			this.tabPage1.Controls.Add(this.label6);
			this.tabPage1.Controls.Add(this.label5);
			this.tabPage1.Controls.Add(this.label4);
			this.tabPage1.Controls.Add(this.label3);
			this.tabPage1.Controls.Add(this.label2);
			this.tabPage1.Controls.Add(this.colorWellTertiaryTest);
			this.tabPage1.Controls.Add(this.colorWellSecondaryTest);
			this.tabPage1.Controls.Add(this.colorWellPrimaryTest);
			this.tabPage1.Controls.Add(this.psI_ButtonPressed);
			this.tabPage1.Controls.Add(this.psI_ButtonDepressed);
			this.tabPage1.Controls.Add(this.button5);
			this.tabPage1.Controls.Add(this.textBoxGlare);
			this.tabPage1.Controls.Add(this.button4);
			this.tabPage1.Controls.Add(this.button1);
			this.tabPage1.Controls.Add(this.buttonImagePick1);
			this.tabPage1.Controls.Add(this.textBoxPressed);
			this.tabPage1.Controls.Add(this.textBoxNormal);
			this.tabPage1.Controls.Add(this.textBoxMask);
			this.tabPage1.Location = new System.Drawing.Point(4, 22);
			this.tabPage1.Margin = new System.Windows.Forms.Padding(2);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(2);
			this.tabPage1.Size = new System.Drawing.Size(671, 362);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "Glare Images";
			this.tabPage1.Click += new System.EventHandler(this.tabPage1_Click);
			// 
			// radioButton3
			// 
			this.radioButton3.AutoSize = true;
			this.radioButton3.Location = new System.Drawing.Point(243, 269);
			this.radioButton3.Name = "radioButton3";
			this.radioButton3.Size = new System.Drawing.Size(193, 17);
			this.radioButton3.TabIndex = 32;
			this.radioButton3.TabStop = true;
			this.radioButton3.Text = "Multishaded (RGB Channel Shader)";
			this.radioButton3.UseVisualStyleBackColor = true;
			// 
			// radioButton2
			// 
			this.radioButton2.AutoSize = true;
			this.radioButton2.Location = new System.Drawing.Point(243, 246);
			this.radioButton2.Name = "radioButton2";
			this.radioButton2.Size = new System.Drawing.Size(135, 17);
			this.radioButton2.TabIndex = 31;
			this.radioButton2.TabStop = true;
			this.radioButton2.Text = "Monochromatic Shader";
			this.radioButton2.UseVisualStyleBackColor = true;
			// 
			// radioButton1
			// 
			this.radioButton1.AutoSize = true;
			this.radioButton1.Location = new System.Drawing.Point(243, 223);
			this.radioButton1.Name = "radioButton1";
			this.radioButton1.Size = new System.Drawing.Size(103, 17);
			this.radioButton1.TabIndex = 30;
			this.radioButton1.TabStop = true;
			this.radioButton1.Text = "True Color Mask";
			this.radioButton1.UseVisualStyleBackColor = true;
			// 
			// label13
			// 
			this.label13.AutoSize = true;
			this.label13.Enabled = false;
			this.label13.Location = new System.Drawing.Point(386, 336);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(195, 13);
			this.label13.TabIndex = 29;
			this.label13.Text = "Highlight (Alt Color 2) (button engaged?)";
			// 
			// colorWellHighlight
			// 
			this.colorWellHighlight.BackColor = System.Drawing.Color.Transparent;
			this.colorWellHighlight.color = System.Drawing.Color.Black;
			this.colorWellHighlight.Enabled = false;
			this.colorWellHighlight.Location = new System.Drawing.Point(598, 332);
			this.colorWellHighlight.Movable = false;
			this.colorWellHighlight.Name = "colorWellHighlight";
			this.colorWellHighlight.Size = new System.Drawing.Size(19, 17);
			this.colorWellHighlight.TabIndex = 28;
			// 
			// checkboxTextAboveGlare
			// 
			this.checkboxTextAboveGlare.AutoSize = true;
			this.checkboxTextAboveGlare.Location = new System.Drawing.Point(243, 316);
			this.checkboxTextAboveGlare.Name = "checkboxTextAboveGlare";
			this.checkboxTextAboveGlare.Size = new System.Drawing.Size(143, 17);
			this.checkboxTextAboveGlare.TabIndex = 26;
			this.checkboxTextAboveGlare.Text = "Text Above Button Glare";
			this.checkboxTextAboveGlare.UseVisualStyleBackColor = true;
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Enabled = false;
			this.label10.Location = new System.Drawing.Point(447, 309);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(98, 13);
			this.label10.TabIndex = 25;
			this.label10.Text = "Shade Color 3 (red)";
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Enabled = false;
			this.label9.Location = new System.Drawing.Point(447, 287);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(110, 13);
			this.label9.TabIndex = 20;
			this.label9.Text = "Shade Color 2 (green)";
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Enabled = false;
			this.label8.Location = new System.Drawing.Point(447, 263);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(134, 13);
			this.label8.TabIndex = 19;
			this.label8.Text = "Shade Color 1 (blue/mono)";
			// 
			// checkBoxTextAboveImage
			// 
			this.checkBoxTextAboveImage.AutoSize = true;
			this.checkBoxTextAboveImage.Location = new System.Drawing.Point(243, 292);
			this.checkBoxTextAboveImage.Name = "checkBoxTextAboveImage";
			this.checkBoxTextAboveImage.Size = new System.Drawing.Size(147, 17);
			this.checkBoxTextAboveImage.TabIndex = 18;
			this.checkBoxTextAboveImage.Text = "Text Above Button Image";
			this.checkBoxTextAboveImage.UseVisualStyleBackColor = true;
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(5, 282);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(101, 13);
			this.label7.TabIndex = 17;
			this.label7.Text = "Button When Down";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(5, 193);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(87, 13);
			this.label6.TabIndex = 16;
			this.label6.Text = "Button When Up";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(5, 94);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(54, 13);
			this.label5.TabIndex = 15;
			this.label5.Text = "Top Glare";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(5, 72);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(111, 13);
			this.label4.TabIndex = 14;
			this.label4.Text = "Pressed Button Image";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(5, 51);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(106, 13);
			this.label3.TabIndex = 13;
			this.label3.Text = "Normal Button Image";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(5, 26);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(94, 13);
			this.label2.TabIndex = 8;
			this.label2.Text = "Background Mask";
			// 
			// colorWellTertiaryTest
			// 
			this.colorWellTertiaryTest.BackColor = System.Drawing.Color.Transparent;
			this.colorWellTertiaryTest.color = System.Drawing.Color.Black;
			this.colorWellTertiaryTest.Enabled = false;
			this.colorWellTertiaryTest.Location = new System.Drawing.Point(598, 309);
			this.colorWellTertiaryTest.Movable = false;
			this.colorWellTertiaryTest.Name = "colorWellTertiaryTest";
			this.colorWellTertiaryTest.Size = new System.Drawing.Size(19, 17);
			this.colorWellTertiaryTest.TabIndex = 12;
			// 
			// colorWellSecondaryTest
			// 
			this.colorWellSecondaryTest.BackColor = System.Drawing.Color.Transparent;
			this.colorWellSecondaryTest.color = System.Drawing.Color.Black;
			this.colorWellSecondaryTest.Enabled = false;
			this.colorWellSecondaryTest.Location = new System.Drawing.Point(598, 286);
			this.colorWellSecondaryTest.Movable = false;
			this.colorWellSecondaryTest.Name = "colorWellSecondaryTest";
			this.colorWellSecondaryTest.Size = new System.Drawing.Size(19, 17);
			this.colorWellSecondaryTest.TabIndex = 11;
			// 
			// colorWellPrimaryTest
			// 
			this.colorWellPrimaryTest.BackColor = System.Drawing.Color.Transparent;
			this.colorWellPrimaryTest.color = System.Drawing.Color.Black;
			this.colorWellPrimaryTest.Enabled = false;
			this.colorWellPrimaryTest.Location = new System.Drawing.Point(598, 263);
			this.colorWellPrimaryTest.Movable = false;
			this.colorWellPrimaryTest.Name = "colorWellPrimaryTest";
			this.colorWellPrimaryTest.Size = new System.Drawing.Size(19, 17);
			this.colorWellPrimaryTest.TabIndex = 10;
			// 
			// button5
			// 
			this.button5.Location = new System.Drawing.Point(354, 91);
			this.button5.Margin = new System.Windows.Forms.Padding(2);
			this.button5.Name = "button5";
			this.button5.Size = new System.Drawing.Size(23, 19);
			this.button5.TabIndex = 7;
			this.button5.Text = "...";
			this.button5.UseVisualStyleBackColor = true;
			this.button5.Click += new System.EventHandler(this.button5_Click);
			// 
			// textBoxGlare
			// 
			this.textBoxGlare.Location = new System.Drawing.Point(143, 91);
			this.textBoxGlare.Margin = new System.Windows.Forms.Padding(2);
			this.textBoxGlare.Name = "textBoxGlare";
			this.textBoxGlare.Size = new System.Drawing.Size(207, 20);
			this.textBoxGlare.TabIndex = 6;
			// 
			// button4
			// 
			this.button4.Location = new System.Drawing.Point(354, 69);
			this.button4.Margin = new System.Windows.Forms.Padding(2);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(23, 19);
			this.button4.TabIndex = 5;
			this.button4.Text = "...";
			this.button4.UseVisualStyleBackColor = true;
			this.button4.Click += new System.EventHandler(this.button4_Click);
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(354, 46);
			this.button1.Margin = new System.Windows.Forms.Padding(2);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(23, 19);
			this.button1.TabIndex = 4;
			this.button1.Text = "...";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// buttonImagePick1
			// 
			this.buttonImagePick1.Location = new System.Drawing.Point(354, 24);
			this.buttonImagePick1.Margin = new System.Windows.Forms.Padding(2);
			this.buttonImagePick1.Name = "buttonImagePick1";
			this.buttonImagePick1.Size = new System.Drawing.Size(23, 19);
			this.buttonImagePick1.TabIndex = 3;
			this.buttonImagePick1.Text = "...";
			this.buttonImagePick1.UseVisualStyleBackColor = true;
			this.buttonImagePick1.Click += new System.EventHandler(this.buttonImagePick1_Click);
			// 
			// textBoxPressed
			// 
			this.textBoxPressed.Location = new System.Drawing.Point(143, 69);
			this.textBoxPressed.Margin = new System.Windows.Forms.Padding(2);
			this.textBoxPressed.Name = "textBoxPressed";
			this.textBoxPressed.Size = new System.Drawing.Size(207, 20);
			this.textBoxPressed.TabIndex = 2;
			// 
			// textBoxNormal
			// 
			this.textBoxNormal.Location = new System.Drawing.Point(143, 46);
			this.textBoxNormal.Margin = new System.Windows.Forms.Padding(2);
			this.textBoxNormal.Name = "textBoxNormal";
			this.textBoxNormal.Size = new System.Drawing.Size(207, 20);
			this.textBoxNormal.TabIndex = 1;
			// 
			// textBoxMask
			// 
			this.textBoxMask.Location = new System.Drawing.Point(143, 23);
			this.textBoxMask.Margin = new System.Windows.Forms.Padding(2);
			this.textBoxMask.Name = "textBoxMask";
			this.textBoxMask.Size = new System.Drawing.Size(207, 20);
			this.textBoxMask.TabIndex = 0;
			// 
			// tabPage2
			// 
			this.tabPage2.BackColor = System.Drawing.SystemColors.Control;
			this.tabPage2.Controls.Add(this.label14);
			this.tabPage2.Controls.Add(this.colorWellText);
			this.tabPage2.Controls.Add(this.buttonDeleteStyle);
			this.tabPage2.Controls.Add(this.buttonNewStyle);
			this.tabPage2.Controls.Add(this.label19);
			this.tabPage2.Controls.Add(this.label18);
			this.tabPage2.Controls.Add(this.colorWellTertiaryHighlight);
			this.tabPage2.Controls.Add(this.colorWellSecondaryHighlight);
			this.tabPage2.Controls.Add(this.colorWellPrimaryHighlight);
			this.tabPage2.Controls.Add(this.label15);
			this.tabPage2.Controls.Add(this.label16);
			this.tabPage2.Controls.Add(this.label17);
			this.tabPage2.Controls.Add(this.colorWellTertiary);
			this.tabPage2.Controls.Add(this.colorWellSecondary);
			this.tabPage2.Controls.Add(this.colorWellPrimary);
			this.tabPage2.Controls.Add(this.label12);
			this.tabPage2.Controls.Add(this.psI_Button1);
			this.tabPage2.Controls.Add(this.psI_Button2);
			this.tabPage2.Controls.Add(this.listBox2);
			this.tabPage2.Location = new System.Drawing.Point(4, 22);
			this.tabPage2.Margin = new System.Windows.Forms.Padding(2);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new System.Windows.Forms.Padding(2);
			this.tabPage2.Size = new System.Drawing.Size(671, 362);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "Glare Attributes";
			// 
			// label14
			// 
			this.label14.AutoSize = true;
			this.label14.Location = new System.Drawing.Point(303, 172);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(55, 13);
			this.label14.TabIndex = 49;
			this.label14.Text = "Text Color";
			// 
			// colorWellText
			// 
			this.colorWellText.BackColor = System.Drawing.Color.Transparent;
			this.colorWellText.color = System.Drawing.Color.Black;
			this.colorWellText.Location = new System.Drawing.Point(515, 170);
			this.colorWellText.Movable = false;
			this.colorWellText.Name = "colorWellText";
			this.colorWellText.Size = new System.Drawing.Size(19, 17);
			this.colorWellText.TabIndex = 48;
			// 
			// buttonDeleteStyle
			// 
			this.buttonDeleteStyle.Location = new System.Drawing.Point(127, 231);
			this.buttonDeleteStyle.Name = "buttonDeleteStyle";
			this.buttonDeleteStyle.Size = new System.Drawing.Size(75, 23);
			this.buttonDeleteStyle.TabIndex = 46;
			this.buttonDeleteStyle.Text = "Delete Style";
			this.buttonDeleteStyle.UseVisualStyleBackColor = true;
			// 
			// buttonNewStyle
			// 
			this.buttonNewStyle.Location = new System.Drawing.Point(18, 231);
			this.buttonNewStyle.Name = "buttonNewStyle";
			this.buttonNewStyle.Size = new System.Drawing.Size(75, 23);
			this.buttonNewStyle.TabIndex = 45;
			this.buttonNewStyle.Text = "New Style";
			this.buttonNewStyle.UseVisualStyleBackColor = true;
			this.buttonNewStyle.Click += new System.EventHandler(this.buttonNewStyle_Click);
			// 
			// label19
			// 
			this.label19.AutoSize = true;
			this.label19.Location = new System.Drawing.Point(568, 74);
			this.label19.Name = "label19";
			this.label19.Size = new System.Drawing.Size(48, 13);
			this.label19.TabIndex = 42;
			this.label19.Text = "Highlight";
			// 
			// label18
			// 
			this.label18.AutoSize = true;
			this.label18.Location = new System.Drawing.Point(494, 74);
			this.label18.Name = "label18";
			this.label18.Size = new System.Drawing.Size(40, 13);
			this.label18.TabIndex = 41;
			this.label18.Text = "Normal";
			// 
			// colorWellTertiaryHighlight
			// 
			this.colorWellTertiaryHighlight.BackColor = System.Drawing.Color.Transparent;
			this.colorWellTertiaryHighlight.color = System.Drawing.Color.Black;
			this.colorWellTertiaryHighlight.Location = new System.Drawing.Point(589, 147);
			this.colorWellTertiaryHighlight.Movable = false;
			this.colorWellTertiaryHighlight.Name = "colorWellTertiaryHighlight";
			this.colorWellTertiaryHighlight.Size = new System.Drawing.Size(19, 17);
			this.colorWellTertiaryHighlight.TabIndex = 40;
			// 
			// colorWellSecondaryHighlight
			// 
			this.colorWellSecondaryHighlight.BackColor = System.Drawing.Color.Transparent;
			this.colorWellSecondaryHighlight.color = System.Drawing.Color.Black;
			this.colorWellSecondaryHighlight.Location = new System.Drawing.Point(589, 124);
			this.colorWellSecondaryHighlight.Movable = false;
			this.colorWellSecondaryHighlight.Name = "colorWellSecondaryHighlight";
			this.colorWellSecondaryHighlight.Size = new System.Drawing.Size(19, 17);
			this.colorWellSecondaryHighlight.TabIndex = 39;
			// 
			// colorWellPrimaryHighlight
			// 
			this.colorWellPrimaryHighlight.BackColor = System.Drawing.Color.Transparent;
			this.colorWellPrimaryHighlight.color = System.Drawing.Color.Black;
			this.colorWellPrimaryHighlight.Location = new System.Drawing.Point(589, 101);
			this.colorWellPrimaryHighlight.Movable = false;
			this.colorWellPrimaryHighlight.Name = "colorWellPrimaryHighlight";
			this.colorWellPrimaryHighlight.Size = new System.Drawing.Size(19, 17);
			this.colorWellPrimaryHighlight.TabIndex = 38;
			// 
			// label15
			// 
			this.label15.AutoSize = true;
			this.label15.Location = new System.Drawing.Point(303, 147);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(98, 13);
			this.label15.TabIndex = 35;
			this.label15.Text = "Shade Color 3 (red)";
			// 
			// label16
			// 
			this.label16.AutoSize = true;
			this.label16.Location = new System.Drawing.Point(303, 125);
			this.label16.Name = "label16";
			this.label16.Size = new System.Drawing.Size(110, 13);
			this.label16.TabIndex = 34;
			this.label16.Text = "Shade Color 2 (green)";
			// 
			// label17
			// 
			this.label17.AutoSize = true;
			this.label17.Location = new System.Drawing.Point(303, 101);
			this.label17.Name = "label17";
			this.label17.Size = new System.Drawing.Size(134, 13);
			this.label17.TabIndex = 33;
			this.label17.Text = "Shade Color 1 (blue/mono)";
			// 
			// colorWellTertiary
			// 
			this.colorWellTertiary.BackColor = System.Drawing.Color.Transparent;
			this.colorWellTertiary.color = System.Drawing.Color.Black;
			this.colorWellTertiary.Location = new System.Drawing.Point(515, 147);
			this.colorWellTertiary.Movable = false;
			this.colorWellTertiary.Name = "colorWellTertiary";
			this.colorWellTertiary.Size = new System.Drawing.Size(19, 17);
			this.colorWellTertiary.TabIndex = 32;
			// 
			// colorWellSecondary
			// 
			this.colorWellSecondary.BackColor = System.Drawing.Color.Transparent;
			this.colorWellSecondary.color = System.Drawing.Color.Black;
			this.colorWellSecondary.Location = new System.Drawing.Point(515, 124);
			this.colorWellSecondary.Movable = false;
			this.colorWellSecondary.Name = "colorWellSecondary";
			this.colorWellSecondary.Size = new System.Drawing.Size(19, 17);
			this.colorWellSecondary.TabIndex = 31;
			// 
			// colorWellPrimary
			// 
			this.colorWellPrimary.BackColor = System.Drawing.Color.Transparent;
			this.colorWellPrimary.color = System.Drawing.Color.Black;
			this.colorWellPrimary.Location = new System.Drawing.Point(515, 101);
			this.colorWellPrimary.Movable = false;
			this.colorWellPrimary.Name = "colorWellPrimary";
			this.colorWellPrimary.Size = new System.Drawing.Size(19, 17);
			this.colorWellPrimary.TabIndex = 30;
			// 
			// label12
			// 
			this.label12.AutoSize = true;
			this.label12.Location = new System.Drawing.Point(271, 35);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(227, 13);
			this.label12.TabIndex = 1;
			this.label12.Text = "I dunno... think I was thinking of attribute sets?";
			// 
			// listBox2
			// 
			this.listBox2.FormattingEnabled = true;
			this.listBox2.Location = new System.Drawing.Point(18, 13);
			this.listBox2.Margin = new System.Windows.Forms.Padding(2);
			this.listBox2.Name = "listBox2";
			this.listBox2.Size = new System.Drawing.Size(184, 212);
			this.listBox2.TabIndex = 0;
			this.listBox2.SelectedIndexChanged += new System.EventHandler(this.listBox2_SelectedIndexChanged);
			// 
			// textBox4
			// 
			this.textBox4.Location = new System.Drawing.Point(87, 82);
			this.textBox4.Name = "textBox4";
			this.textBox4.Size = new System.Drawing.Size(168, 20);
			this.textBox4.TabIndex = 2;
			// 
			// textBox5
			// 
			this.textBox5.Location = new System.Drawing.Point(87, 54);
			this.textBox5.Name = "textBox5";
			this.textBox5.Size = new System.Drawing.Size(168, 20);
			this.textBox5.TabIndex = 1;
			// 
			// textBox6
			// 
			this.textBox6.Location = new System.Drawing.Point(87, 26);
			this.textBox6.Name = "textBox6";
			this.textBox6.Size = new System.Drawing.Size(168, 20);
			this.textBox6.TabIndex = 0;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(35, 13);
			this.label1.TabIndex = 7;
			this.label1.Text = "label1";
			// 
			// label20
			// 
			this.label20.AutoSize = true;
			this.label20.Location = new System.Drawing.Point(5, 118);
			this.label20.Name = "label20";
			this.label20.Size = new System.Drawing.Size(81, 13);
			this.label20.TabIndex = 35;
			this.label20.Text = "HIghlight Image";
			// 
			// buttonHighlightSelect
			// 
			this.buttonHighlightSelect.Location = new System.Drawing.Point(354, 115);
			this.buttonHighlightSelect.Margin = new System.Windows.Forms.Padding(2);
			this.buttonHighlightSelect.Name = "buttonHighlightSelect";
			this.buttonHighlightSelect.Size = new System.Drawing.Size(23, 19);
			this.buttonHighlightSelect.TabIndex = 34;
			this.buttonHighlightSelect.Text = "...";
			this.buttonHighlightSelect.UseVisualStyleBackColor = true;
			this.buttonHighlightSelect.Click += new System.EventHandler(this.buttonHighlightSelect_Click);
			// 
			// textBoxHighlightNormal
			// 
			this.textBoxHighlightNormal.Location = new System.Drawing.Point(143, 115);
			this.textBoxHighlightNormal.Margin = new System.Windows.Forms.Padding(2);
			this.textBoxHighlightNormal.Name = "textBoxHighlightNormal";
			this.textBoxHighlightNormal.Size = new System.Drawing.Size(207, 20);
			this.textBoxHighlightNormal.TabIndex = 33;
			// 
			// label21
			// 
			this.label21.AutoSize = true;
			this.label21.Location = new System.Drawing.Point(5, 142);
			this.label21.Name = "label21";
			this.label21.Size = new System.Drawing.Size(121, 13);
			this.label21.TabIndex = 38;
			this.label21.Text = "Highlight Pressed Image";
			// 
			// buttonHighlightPressSelect
			// 
			this.buttonHighlightPressSelect.Location = new System.Drawing.Point(354, 139);
			this.buttonHighlightPressSelect.Margin = new System.Windows.Forms.Padding(2);
			this.buttonHighlightPressSelect.Name = "buttonHighlightPressSelect";
			this.buttonHighlightPressSelect.Size = new System.Drawing.Size(23, 19);
			this.buttonHighlightPressSelect.TabIndex = 37;
			this.buttonHighlightPressSelect.Text = "...";
			this.buttonHighlightPressSelect.UseVisualStyleBackColor = true;
			this.buttonHighlightPressSelect.Click += new System.EventHandler(this.buttonHighlightPressSelect_Click);
			// 
			// textBoxHighlightPressed
			// 
			this.textBoxHighlightPressed.Location = new System.Drawing.Point(143, 139);
			this.textBoxHighlightPressed.Margin = new System.Windows.Forms.Padding(2);
			this.textBoxHighlightPressed.Name = "textBoxHighlightPressed";
			this.textBoxHighlightPressed.Size = new System.Drawing.Size(207, 20);
			this.textBoxHighlightPressed.TabIndex = 36;
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.Location = new System.Drawing.Point(114, 282);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(69, 13);
			this.label11.TabIndex = 42;
			this.label11.Text = "Highlighted...";
			// 
			// label22
			// 
			this.label22.AutoSize = true;
			this.label22.Location = new System.Drawing.Point(114, 193);
			this.label22.Name = "label22";
			this.label22.Size = new System.Drawing.Size(69, 13);
			this.label22.TabIndex = 41;
			this.label22.Text = "Highlighted...";
			// 
			// buttonApply
			// 
			this.buttonApply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonApply.Location = new System.Drawing.Point(504, 430);
			this.buttonApply.Margin = new System.Windows.Forms.Padding(2);
			this.buttonApply.Name = "buttonApply";
			this.buttonApply.Size = new System.Drawing.Size(56, 33);
			this.buttonApply.TabIndex = 8;
			this.buttonApply.Text = "Apply";
			this.buttonApply.UseVisualStyleBackColor = true;
			this.buttonApply.Click += new System.EventHandler(this.button2_Click);
			// 
			// psI_ButtonHighlightPressed
			// 
			this.psI_ButtonHighlightPressed.BackColor = System.Drawing.Color.Transparent;
			this.psI_ButtonHighlightPressed.Font = new System.Drawing.Font("Arial", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.psI_ButtonHighlightPressed.Location = new System.Drawing.Point(117, 298);
			this.psI_ButtonHighlightPressed.Movable = false;
			this.psI_ButtonHighlightPressed.Name = "psI_ButtonHighlightPressed";
			this.psI_ButtonHighlightPressed.Size = new System.Drawing.Size(103, 59);
			this.psI_ButtonHighlightPressed.TabIndex = 40;
			// 
			// psI_ButtonHighlightDepressed
			// 
			this.psI_ButtonHighlightDepressed.BackColor = System.Drawing.Color.Transparent;
			this.psI_ButtonHighlightDepressed.Font = new System.Drawing.Font("Arial", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.psI_ButtonHighlightDepressed.Location = new System.Drawing.Point(114, 209);
			this.psI_ButtonHighlightDepressed.Movable = false;
			this.psI_ButtonHighlightDepressed.Name = "psI_ButtonHighlightDepressed";
			this.psI_ButtonHighlightDepressed.Size = new System.Drawing.Size(103, 58);
			this.psI_ButtonHighlightDepressed.TabIndex = 39;
			// 
			// psI_ButtonPressed
			// 
			this.psI_ButtonPressed.BackColor = System.Drawing.Color.Transparent;
			this.psI_ButtonPressed.Font = new System.Drawing.Font("Arial", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.psI_ButtonPressed.Location = new System.Drawing.Point(8, 298);
			this.psI_ButtonPressed.Movable = false;
			this.psI_ButtonPressed.Name = "psI_ButtonPressed";
			this.psI_ButtonPressed.Size = new System.Drawing.Size(103, 59);
			this.psI_ButtonPressed.TabIndex = 9;
			// 
			// psI_ButtonDepressed
			// 
			this.psI_ButtonDepressed.BackColor = System.Drawing.Color.Transparent;
			this.psI_ButtonDepressed.Font = new System.Drawing.Font("Arial", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.psI_ButtonDepressed.Location = new System.Drawing.Point(5, 209);
			this.psI_ButtonDepressed.Movable = false;
			this.psI_ButtonDepressed.Name = "psI_ButtonDepressed";
			this.psI_ButtonDepressed.Size = new System.Drawing.Size(103, 58);
			this.psI_ButtonDepressed.TabIndex = 8;
			// 
			// psI_Button1
			// 
			this.psI_Button1.BackColor = System.Drawing.Color.Transparent;
			this.psI_Button1.Font = new System.Drawing.Font("Arial", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.psI_Button1.Location = new System.Drawing.Point(407, 204);
			this.psI_Button1.Movable = false;
			this.psI_Button1.Name = "psI_Button1";
			this.psI_Button1.Size = new System.Drawing.Size(135, 86);
			this.psI_Button1.TabIndex = 47;
			// 
			// psI_Button2
			// 
			this.psI_Button2.BackColor = System.Drawing.Color.Transparent;
			this.psI_Button2.Font = new System.Drawing.Font("Arial", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.psI_Button2.Location = new System.Drawing.Point(266, 204);
			this.psI_Button2.Movable = false;
			this.psI_Button2.Name = "psI_Button2";
			this.psI_Button2.Size = new System.Drawing.Size(135, 86);
			this.psI_Button2.TabIndex = 43;
			// 
			// GlareSetEditor
			// 
			this.AcceptButton = this.buttonOK;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.buttonCancel;
			this.ClientSize = new System.Drawing.Size(700, 472);
			this.Controls.Add(this.buttonApply);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.tabControl1);
			this.Controls.Add(this.buttonCancel);
			this.Controls.Add(this.buttonOK);
			this.Margin = new System.Windows.Forms.Padding(2);
			this.Name = "GlareSetEditor";
			this.Text = "GlareSetEditor";
			this.Load += new System.EventHandler(this.GlareSetEditor_Load);
			this.tabControl1.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.tabPage1.PerformLayout();
			this.tabPage2.ResumeLayout(false);
			this.tabPage2.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ListBox listBox1;
		private System.Windows.Forms.Button buttonOK;
		private System.Windows.Forms.Button buttonCancel;
		private System.Windows.Forms.Button buttonCreateGlareset;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TextBox textBoxPressed;
		private System.Windows.Forms.TextBox textBoxNormal;
		private System.Windows.Forms.TextBox textBoxMask;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.TextBox textBox4;
		private System.Windows.Forms.TextBox textBox5;
		private System.Windows.Forms.TextBox textBox6;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button buttonImagePick1;
		private System.Windows.Forms.TextBox textBoxGlare;
		private System.Windows.Forms.Button button4;
		private System.Windows.Forms.Button button5;
		private System.Windows.Forms.ListBox listBox2;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
		private PSI_Button psI_ButtonDepressed;
		private PSI_Button psI_ButtonPressed;
		private ColorWell colorWellTertiaryTest;
		private ColorWell colorWellSecondaryTest;
		private ColorWell colorWellPrimaryTest;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.CheckBox checkBoxTextAboveImage;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.CheckBox checkboxTextAboveGlare;
		private System.Windows.Forms.Label label13;
		private ColorWell colorWellHighlight;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.Label label18;
		private ColorWell colorWellTertiaryHighlight;
		private ColorWell colorWellSecondaryHighlight;
		private ColorWell colorWellPrimaryHighlight;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.Label label17;
		private ColorWell colorWellTertiary;
		private ColorWell colorWellSecondary;
		private ColorWell colorWellPrimary;
		private PSI_Button psI_Button2;
		private System.Windows.Forms.Label label19;
		private System.Windows.Forms.RadioButton radioButton3;
		private System.Windows.Forms.RadioButton radioButton2;
		private System.Windows.Forms.RadioButton radioButton1;
		private System.Windows.Forms.Button buttonDeleteStyle;
		private System.Windows.Forms.Button buttonNewStyle;
		private PSI_Button psI_Button1;
		private System.Windows.Forms.Label label14;
		private ColorWell colorWellText;
		private System.Windows.Forms.Label label21;
		private System.Windows.Forms.Button buttonHighlightPressSelect;
		private System.Windows.Forms.TextBox textBoxHighlightPressed;
		private System.Windows.Forms.Label label20;
		private System.Windows.Forms.Button buttonHighlightSelect;
		private System.Windows.Forms.TextBox textBoxHighlightNormal;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label label22;
		private PSI_Button psI_ButtonHighlightPressed;
		private PSI_Button psI_ButtonHighlightDepressed;
		private System.Windows.Forms.Button buttonApply;
	}
}