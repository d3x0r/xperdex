namespace xperdex.gui
{
    partial class PSI_Frame
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof( PSI_Frame ) );
			this.SuspendLayout();
			// 
			// PSI_Frame
			// 

			try
			{
				this.BackgroundImage = ( (System.Drawing.Image)( resources.GetObject( "$this.BackgroundImage" ) ) );
			}
			catch { }
			this.ClientSize = new System.Drawing.Size( 284, 264 );
			this.DoubleBuffered = true;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Name = "PSI_Frame";
			this.Text = "Your Window Here";
			this.Paint += new System.Windows.Forms.PaintEventHandler( this.PSI_FramePaint );
			this.SizeChanged += new System.EventHandler( this.PSI_Frame_SizeChanged );
			this.MouseUp += new System.Windows.Forms.MouseEventHandler( this.ReleaseFrame );
			this.MouseMove += new System.Windows.Forms.MouseEventHandler( this.MoveFrame );
			this.MouseDown += new System.Windows.Forms.MouseEventHandler( this.GrabFrame );
			this.ResumeLayout( false );

        }

        #endregion
    }
}