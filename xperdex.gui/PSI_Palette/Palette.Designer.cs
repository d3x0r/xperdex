using System.Xml;
using System;
using System.Drawing;
namespace xperdex.gui.PSI_Palette
{
    partial class Palette
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
			this.trackBar1 = new System.Windows.Forms.TrackBar();
			this.gradient1 = new xperdex.gui.PSI_Palette.Gradient();
			this.colorWell1 = new xperdex.gui.PSI_Palette.ColorWell();
			this.colorMatrix1 = new xperdex.gui.PSI_Palette.ColorMatrix();
			this.gradient2 = new xperdex.gui.PSI_Palette.Gradient();
			this.gradient3 = new xperdex.gui.PSI_Palette.Gradient();
			this.gradient4 = new xperdex.gui.PSI_Palette.Gradient();
			this.setalpha = new System.Windows.Forms.CheckBox();
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.button3 = new System.Windows.Forms.Button();
			this.palettePreset1 = new xperdex.gui.PSI_Palette.PalettePreset();
			( (System.ComponentModel.ISupportInitialize)( this.trackBar1 ) ).BeginInit();
			this.SuspendLayout();
			// 
			// trackBar1
			// 
			this.trackBar1.Location = new System.Drawing.Point( 215, 64 );
			this.trackBar1.Name = "trackBar1";
			this.trackBar1.Orientation = System.Windows.Forms.Orientation.Vertical;
			this.trackBar1.Size = new System.Drawing.Size( 45, 133 );
			this.trackBar1.TabIndex = 2;
			this.trackBar1.TickStyle = System.Windows.Forms.TickStyle.None;
			this.trackBar1.ValueChanged += new System.EventHandler( this.SliderUpdated );
			// 
			// gradient1
			// 
			this.gradient1.BackColor = System.Drawing.Color.Transparent;
			this.gradient1.Location = new System.Drawing.Point( 266, 64 );
			this.gradient1.Movable = false;
			this.gradient1.Name = "gradient1";
			this.gradient1.Size = new System.Drawing.Size( 25, 133 );
			this.gradient1.TabIndex = 3;
			// 
			// colorWell1
			// 
			this.colorWell1.BackColor = System.Drawing.Color.Transparent;
			this.colorWell1.color = System.Drawing.Color.Black;
			this.colorWell1.Location = new System.Drawing.Point( 390, 64 );
			this.colorWell1.Movable = false;
			this.colorWell1.Name = "colorWell1";
			this.colorWell1.Size = new System.Drawing.Size( 84, 133 );
			this.colorWell1.TabIndex = 1;
			// 
			// colorMatrix1
			// 
			this.colorMatrix1.BackColor = System.Drawing.Color.Transparent;
			this.colorMatrix1.Location = new System.Drawing.Point( 79, 64 );
			this.colorMatrix1.Movable = false;
			this.colorMatrix1.Name = "colorMatrix1";
			this.colorMatrix1.Size = new System.Drawing.Size( 130, 133 );
			this.colorMatrix1.TabIndex = 0;
			// 
			// gradient2
			// 
			this.gradient2.BackColor = System.Drawing.Color.Transparent;
			this.gradient2.Location = new System.Drawing.Point( 297, 64 );
			this.gradient2.Movable = false;
			this.gradient2.Name = "gradient2";
			this.gradient2.Size = new System.Drawing.Size( 25, 133 );
			this.gradient2.TabIndex = 4;
			// 
			// gradient3
			// 
			this.gradient3.BackColor = System.Drawing.Color.Transparent;
			this.gradient3.Location = new System.Drawing.Point( 328, 64 );
			this.gradient3.Movable = false;
			this.gradient3.Name = "gradient3";
			this.gradient3.Size = new System.Drawing.Size( 25, 133 );
			this.gradient3.TabIndex = 5;
			// 
			// gradient4
			// 
			this.gradient4.BackColor = System.Drawing.Color.Transparent;
			this.gradient4.Location = new System.Drawing.Point( 359, 64 );
			this.gradient4.Movable = false;
			this.gradient4.Name = "gradient4";
			this.gradient4.Size = new System.Drawing.Size( 25, 133 );
			this.gradient4.TabIndex = 6;
			// 
			// setalpha
			// 
			this.setalpha.AutoSize = true;
			this.setalpha.Location = new System.Drawing.Point( 83, 203 );
			this.setalpha.Name = "setalpha";
			this.setalpha.Size = new System.Drawing.Size( 72, 17 );
			this.setalpha.TabIndex = 7;
			this.setalpha.Text = "Set Alpha";
			this.setalpha.UseVisualStyleBackColor = true;
			this.setalpha.CheckStateChanged += new System.EventHandler( this.PaletteAlphaSet );
			// 
			// button1
			// 
			this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.button1.Location = new System.Drawing.Point( 420, 283 );
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size( 67, 29 );
			this.button1.TabIndex = 9;
			this.button1.Text = "Okay";
			this.button1.UseVisualStyleBackColor = true;
			// 
			// button2
			// 
			this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.button2.Location = new System.Drawing.Point( 347, 283 );
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size( 67, 29 );
			this.button2.TabIndex = 10;
			this.button2.Text = "Cancel";
			this.button2.UseVisualStyleBackColor = true;
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point( 79, 283 );
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size( 67, 29 );
			this.button3.TabIndex = 11;
			this.button3.Text = "Set Preset";
			this.button3.UseVisualStyleBackColor = true;
			this.button3.Click += new System.EventHandler( this.SetupPreset );
			// 
			// palettePreset1
			// 
			this.palettePreset1.Location = new System.Drawing.Point( 83, 226 );
			this.palettePreset1.Name = "palettePreset1";
			this.palettePreset1.Size = new System.Drawing.Size( 14, 15 );
			this.palettePreset1.TabIndex = 12;
			this.palettePreset1.Text = "palettePreset1";
			this.palettePreset1.UseVisualStyleBackColor = true;
			// 
			// Palette
			// 
			this.AcceptButton = this.button1;
			this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.button2;
			this.ClientSize = new System.Drawing.Size( 570, 399 );
			this.Controls.Add( this.palettePreset1 );
			this.Controls.Add( this.button3 );
			this.Controls.Add( this.button2 );
			this.Controls.Add( this.button1 );
			this.Controls.Add( this.setalpha );
			this.Controls.Add( this.gradient4 );
			this.Controls.Add( this.gradient3 );
			this.Controls.Add( this.gradient2 );
			this.Controls.Add( this.gradient1 );
			this.Controls.Add( this.trackBar1 );
			this.Controls.Add( this.colorWell1 );
			this.Controls.Add( this.colorMatrix1 );
			this.Name = "Palette";
			this.Text = "Palette";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler( this.SavePresets );
			( (System.ComponentModel.ISupportInitialize)( this.trackBar1 ) ).EndInit();
			this.ResumeLayout( false );
			this.PerformLayout();

        }

        #endregion

        private ColorMatrix colorMatrix1;
        private ColorWell colorWell1;
        private System.Windows.Forms.TrackBar trackBar1;
        private Gradient gradient1;
        private Gradient gradient2;
        private Gradient gradient3;
        private Gradient gradient4;
        private System.Windows.Forms.CheckBox setalpha;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private PalettePreset palettePreset1;
    }
}