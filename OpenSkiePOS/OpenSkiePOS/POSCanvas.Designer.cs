namespace OpenSkiePOS
{
    partial class POSCanvas
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
			this.canvas1 = new xperdex.core.Canvas();
			this.SuspendLayout();
			// 
			// canvas1
			// 
			this.canvas1.AllowDrop = true;
			this.canvas1.BackColor = System.Drawing.Color.Transparent;
			this.canvas1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.canvas1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.canvas1.Location = new System.Drawing.Point( 0, 0 );
			this.canvas1.Movable = false;
			this.canvas1.Name = "canvas1";
			this.canvas1.Size = new System.Drawing.Size( 747, 495 );
			this.canvas1.TabIndex = 0;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size( 747, 495 );
			this.Controls.Add( this.canvas1 );
			this.Name = "Form1";
			this.Text = "OpenSkie Bingo Sales";
			this.Load += new System.EventHandler( this.Form1_Load );
			this.ResumeLayout( false );

        }

        #endregion

		private xperdex.core.Canvas canvas1;
    }
}

