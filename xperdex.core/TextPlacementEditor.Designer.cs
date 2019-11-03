namespace xperdex.core
{
	partial class TextPlacementEditor
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
			this.listBoxLabel = new System.Windows.Forms.ListBox();
			this.buttonAddLabel = new System.Windows.Forms.Button();
			this.buttonDeleteLabel = new System.Windows.Forms.Button();
			this.checkBoxAnchorBottom = new System.Windows.Forms.CheckBox();
			this.checkBoxAnchorRight = new System.Windows.Forms.CheckBox();
			this.listBoxFonts = new System.Windows.Forms.ListBox();
			this.buttonCancel = new System.Windows.Forms.Button();
			this.buttonOkay = new System.Windows.Forms.Button();
			this.listBoxLayout = new System.Windows.Forms.ListBox();
			this.buttonDeleteLayout = new System.Windows.Forms.Button();
			this.buttonCreateLayout = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.buttonEditFonts = new System.Windows.Forms.Button();
			this.trackBarSampleHoriz = new System.Windows.Forms.TrackBar();
			this.trackBarSampelVert = new System.Windows.Forms.TrackBar();
			this.checkBoxCenter = new System.Windows.Forms.CheckBox();
			this.checkBoxRightAlign = new System.Windows.Forms.CheckBox();
			this.textPlacementLayoutEditor1 = new xperdex.core.common.TextPlacementLayoutEditor();
			this.colorWell1 = new xperdex.gui.PSI_Palette.ColorWell();
			( (System.ComponentModel.ISupportInitialize)( this.trackBarSampleHoriz ) ).BeginInit();
			( (System.ComponentModel.ISupportInitialize)( this.trackBarSampelVert ) ).BeginInit();
			this.SuspendLayout();
			// 
			// listBoxLabel
			// 
			this.listBoxLabel.FormattingEnabled = true;
			this.listBoxLabel.Location = new System.Drawing.Point( 184, 36 );
			this.listBoxLabel.Name = "listBoxLabel";
			this.listBoxLabel.Size = new System.Drawing.Size( 156, 160 );
			this.listBoxLabel.TabIndex = 1;
			this.listBoxLabel.SelectedIndexChanged += new System.EventHandler( this.listBoxLabel_SelectedIndexChanged );
			// 
			// buttonAddLabel
			// 
			this.buttonAddLabel.Location = new System.Drawing.Point( 184, 202 );
			this.buttonAddLabel.Name = "buttonAddLabel";
			this.buttonAddLabel.Size = new System.Drawing.Size( 75, 41 );
			this.buttonAddLabel.TabIndex = 2;
			this.buttonAddLabel.Text = "Add Label";
			this.buttonAddLabel.UseVisualStyleBackColor = true;
			this.buttonAddLabel.Click += new System.EventHandler( this.buttonAddLabel_Click );
			// 
			// buttonDeleteLabel
			// 
			this.buttonDeleteLabel.Location = new System.Drawing.Point( 265, 202 );
			this.buttonDeleteLabel.Name = "buttonDeleteLabel";
			this.buttonDeleteLabel.Size = new System.Drawing.Size( 75, 41 );
			this.buttonDeleteLabel.TabIndex = 3;
			this.buttonDeleteLabel.Text = "Delete Label";
			this.buttonDeleteLabel.UseVisualStyleBackColor = true;
			// 
			// checkBoxAnchorBottom
			// 
			this.checkBoxAnchorBottom.AutoSize = true;
			this.checkBoxAnchorBottom.Location = new System.Drawing.Point( 184, 262 );
			this.checkBoxAnchorBottom.Name = "checkBoxAnchorBottom";
			this.checkBoxAnchorBottom.Size = new System.Drawing.Size( 108, 17 );
			this.checkBoxAnchorBottom.TabIndex = 6;
			this.checkBoxAnchorBottom.Text = "Anchor to Bottom";
			this.checkBoxAnchorBottom.UseVisualStyleBackColor = true;
			this.checkBoxAnchorBottom.CheckedChanged += new System.EventHandler( this.checkBoxAnchorBottom_CheckedChanged );
			// 
			// checkBoxAnchorRight
			// 
			this.checkBoxAnchorRight.AutoSize = true;
			this.checkBoxAnchorRight.Location = new System.Drawing.Point( 184, 285 );
			this.checkBoxAnchorRight.Name = "checkBoxAnchorRight";
			this.checkBoxAnchorRight.Size = new System.Drawing.Size( 100, 17 );
			this.checkBoxAnchorRight.TabIndex = 7;
			this.checkBoxAnchorRight.Text = "Anchor to Right";
			this.checkBoxAnchorRight.UseVisualStyleBackColor = true;
			this.checkBoxAnchorRight.CheckedChanged += new System.EventHandler( this.checkBoxAnchorRight_CheckedChanged );
			// 
			// listBoxFonts
			// 
			this.listBoxFonts.FormattingEnabled = true;
			this.listBoxFonts.Location = new System.Drawing.Point( 12, 285 );
			this.listBoxFonts.Name = "listBoxFonts";
			this.listBoxFonts.Size = new System.Drawing.Size( 156, 95 );
			this.listBoxFonts.TabIndex = 8;
			this.listBoxFonts.SelectedIndexChanged += new System.EventHandler( this.listBoxFonts_SelectedIndexChanged );
			// 
			// buttonCancel
			// 
			this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.buttonCancel.Location = new System.Drawing.Point( 436, 363 );
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size( 95, 35 );
			this.buttonCancel.TabIndex = 10;
			this.buttonCancel.Text = "Cancel";
			this.buttonCancel.UseVisualStyleBackColor = true;
			// 
			// buttonOkay
			// 
			this.buttonOkay.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.buttonOkay.Location = new System.Drawing.Point( 537, 363 );
			this.buttonOkay.Name = "buttonOkay";
			this.buttonOkay.Size = new System.Drawing.Size( 95, 35 );
			this.buttonOkay.TabIndex = 9;
			this.buttonOkay.Text = "Okay";
			this.buttonOkay.UseVisualStyleBackColor = true;
			this.buttonOkay.Click += new System.EventHandler( this.buttonOkay_Click );
			// 
			// listBoxLayout
			// 
			this.listBoxLayout.FormattingEnabled = true;
			this.listBoxLayout.Location = new System.Drawing.Point( 12, 36 );
			this.listBoxLayout.Name = "listBoxLayout";
			this.listBoxLayout.Size = new System.Drawing.Size( 156, 160 );
			this.listBoxLayout.TabIndex = 11;
			this.listBoxLayout.SelectedValueChanged += new System.EventHandler( this.listBoxLayout_SelectedValueChanged );
			// 
			// buttonDeleteLayout
			// 
			this.buttonDeleteLayout.Location = new System.Drawing.Point( 93, 202 );
			this.buttonDeleteLayout.Name = "buttonDeleteLayout";
			this.buttonDeleteLayout.Size = new System.Drawing.Size( 75, 41 );
			this.buttonDeleteLayout.TabIndex = 13;
			this.buttonDeleteLayout.Text = "Delete Layout";
			this.buttonDeleteLayout.UseVisualStyleBackColor = true;
			// 
			// buttonCreateLayout
			// 
			this.buttonCreateLayout.Location = new System.Drawing.Point( 12, 202 );
			this.buttonCreateLayout.Name = "buttonCreateLayout";
			this.buttonCreateLayout.Size = new System.Drawing.Size( 75, 41 );
			this.buttonCreateLayout.TabIndex = 12;
			this.buttonCreateLayout.Text = "Create Layout";
			this.buttonCreateLayout.UseVisualStyleBackColor = true;
			this.buttonCreateLayout.Click += new System.EventHandler( this.buttonCreateLayout_Click );
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point( 13, 266 );
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size( 70, 13 );
			this.label1.TabIndex = 14;
			this.label1.Text = "Select Font...";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point( 213, 362 );
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size( 55, 13 );
			this.label2.TabIndex = 16;
			this.label2.Text = "Text Color";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point( 184, 395 );
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size( 66, 13 );
			this.label3.TabIndex = 17;
			this.label3.Text = "Sample Text";
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point( 265, 392 );
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size( 131, 20 );
			this.textBox1.TabIndex = 18;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point( 370, 36 );
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size( 114, 13 );
			this.label4.TabIndex = 20;
			this.label4.Text = "Sample Layout Area... ";
			// 
			// buttonEditFonts
			// 
			this.buttonEditFonts.Location = new System.Drawing.Point( 16, 387 );
			this.buttonEditFonts.Name = "buttonEditFonts";
			this.buttonEditFonts.Size = new System.Drawing.Size( 75, 23 );
			this.buttonEditFonts.TabIndex = 21;
			this.buttonEditFonts.Text = "Edit Fonts";
			this.buttonEditFonts.UseVisualStyleBackColor = true;
			this.buttonEditFonts.Click += new System.EventHandler( this.buttonEditFonts_Click );
			// 
			// trackBarSampleHoriz
			// 
			this.trackBarSampleHoriz.AutoSize = false;
			this.trackBarSampleHoriz.Location = new System.Drawing.Point( 390, 282 );
			this.trackBarSampleHoriz.Name = "trackBarSampleHoriz";
			this.trackBarSampleHoriz.Size = new System.Drawing.Size( 228, 26 );
			this.trackBarSampleHoriz.TabIndex = 22;
			this.trackBarSampleHoriz.TickStyle = System.Windows.Forms.TickStyle.None;
			this.trackBarSampleHoriz.ValueChanged += new System.EventHandler( this.trackBarSampleHoriz_ValueChanged );
			// 
			// trackBarSampelVert
			// 
			this.trackBarSampelVert.AutoSize = false;
			this.trackBarSampelVert.Location = new System.Drawing.Point( 358, 64 );
			this.trackBarSampelVert.Name = "trackBarSampelVert";
			this.trackBarSampelVert.Orientation = System.Windows.Forms.Orientation.Vertical;
			this.trackBarSampelVert.Size = new System.Drawing.Size( 26, 215 );
			this.trackBarSampelVert.TabIndex = 23;
			this.trackBarSampelVert.TickStyle = System.Windows.Forms.TickStyle.None;
			this.trackBarSampelVert.ValueChanged += new System.EventHandler( this.trackBarSampelVert_ValueChanged );
			// 
			// checkBoxCenter
			// 
			this.checkBoxCenter.AutoSize = true;
			this.checkBoxCenter.Location = new System.Drawing.Point( 184, 308 );
			this.checkBoxCenter.Name = "checkBoxCenter";
			this.checkBoxCenter.Size = new System.Drawing.Size( 83, 17 );
			this.checkBoxCenter.TabIndex = 24;
			this.checkBoxCenter.Text = "Align Center";
			this.checkBoxCenter.UseVisualStyleBackColor = true;
			this.checkBoxCenter.CheckedChanged += new System.EventHandler( this.checkBoxCenter_CheckedChanged );
			// 
			// checkBoxRightAlign
			// 
			this.checkBoxRightAlign.AutoSize = true;
			this.checkBoxRightAlign.Location = new System.Drawing.Point( 184, 331 );
			this.checkBoxRightAlign.Name = "checkBoxRightAlign";
			this.checkBoxRightAlign.Size = new System.Drawing.Size( 77, 17 );
			this.checkBoxRightAlign.TabIndex = 25;
			this.checkBoxRightAlign.Text = "Align Right";
			this.checkBoxRightAlign.UseVisualStyleBackColor = true;
			this.checkBoxRightAlign.CheckedChanged += new System.EventHandler( this.checkBoxRightAlign_CheckedChanged );
			// 
			// textPlacementLayoutEditor1
			// 
			this.textPlacementLayoutEditor1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.textPlacementLayoutEditor1.Location = new System.Drawing.Point( 390, 64 );
			this.textPlacementLayoutEditor1.Name = "textPlacementLayoutEditor1";
			this.textPlacementLayoutEditor1.Size = new System.Drawing.Size( 228, 215 );
			this.textPlacementLayoutEditor1.TabIndex = 19;
			// 
			// colorWell1
			// 
			this.colorWell1.BackColor = System.Drawing.Color.Transparent;
			this.colorWell1.color = System.Drawing.Color.Black;
			this.colorWell1.Location = new System.Drawing.Point( 184, 356 );
			this.colorWell1.Movable = false;
			this.colorWell1.Name = "colorWell1";
			this.colorWell1.Size = new System.Drawing.Size( 23, 24 );
			this.colorWell1.TabIndex = 15;
			// 
			// TextPlacementEditor
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size( 644, 424 );
			this.Controls.Add( this.checkBoxRightAlign );
			this.Controls.Add( this.checkBoxCenter );
			this.Controls.Add( this.trackBarSampelVert );
			this.Controls.Add( this.trackBarSampleHoriz );
			this.Controls.Add( this.buttonEditFonts );
			this.Controls.Add( this.label4 );
			this.Controls.Add( this.textPlacementLayoutEditor1 );
			this.Controls.Add( this.textBox1 );
			this.Controls.Add( this.label3 );
			this.Controls.Add( this.label2 );
			this.Controls.Add( this.colorWell1 );
			this.Controls.Add( this.label1 );
			this.Controls.Add( this.buttonDeleteLayout );
			this.Controls.Add( this.buttonCreateLayout );
			this.Controls.Add( this.listBoxLayout );
			this.Controls.Add( this.buttonCancel );
			this.Controls.Add( this.buttonOkay );
			this.Controls.Add( this.listBoxFonts );
			this.Controls.Add( this.checkBoxAnchorRight );
			this.Controls.Add( this.checkBoxAnchorBottom );
			this.Controls.Add( this.buttonDeleteLabel );
			this.Controls.Add( this.buttonAddLabel );
			this.Controls.Add( this.listBoxLabel );
			this.Name = "TextPlacementEditor";
			this.Text = "TextPlacementEditor";
			this.Load += new System.EventHandler( this.TextPlacementEditor_Load );
			( (System.ComponentModel.ISupportInitialize)( this.trackBarSampleHoriz ) ).EndInit();
			( (System.ComponentModel.ISupportInitialize)( this.trackBarSampelVert ) ).EndInit();
			this.ResumeLayout( false );
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ListBox listBoxLabel;
		private System.Windows.Forms.Button buttonAddLabel;
		private System.Windows.Forms.Button buttonDeleteLabel;
		private System.Windows.Forms.CheckBox checkBoxAnchorBottom;
		private System.Windows.Forms.CheckBox checkBoxAnchorRight;
		private System.Windows.Forms.ListBox listBoxFonts;
		private System.Windows.Forms.Button buttonCancel;
		private System.Windows.Forms.Button buttonOkay;
		private System.Windows.Forms.ListBox listBoxLayout;
		private System.Windows.Forms.Button buttonDeleteLayout;
		private System.Windows.Forms.Button buttonCreateLayout;
		private System.Windows.Forms.Label label1;
		private xperdex.gui.PSI_Palette.ColorWell colorWell1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox textBox1;
		private xperdex.core.common.TextPlacementLayoutEditor textPlacementLayoutEditor1;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Button buttonEditFonts;
		private System.Windows.Forms.TrackBar trackBarSampleHoriz;
		private System.Windows.Forms.TrackBar trackBarSampelVert;
		private System.Windows.Forms.CheckBox checkBoxCenter;
		private System.Windows.Forms.CheckBox checkBoxRightAlign;
	}
}