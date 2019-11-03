namespace xperdex.core
{
    partial class Canvas
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
			this.SuspendLayout();
			// 
			// Canvas
			// 
			this.AllowDrop = true;
			this.Name = "Canvas";
			this.Size = new System.Drawing.Size( 348, 249 );
			this.LocationChanged += new System.EventHandler( this.Canvas_LocationChanged );
			this.MouseLeave += new System.EventHandler( this.CanvasLeave );
			this.Paint += new System.Windows.Forms.PaintEventHandler( this.CanvasGridPaint );
			this.DragOver += new System.Windows.Forms.DragEventHandler( this.Canvas_DragOver );
			this.DragDrop += new System.Windows.Forms.DragEventHandler( this.Canvas_DragDrop );
			this.MouseDown += new System.Windows.Forms.MouseEventHandler( this.CanvasButtonDown );
			this.MouseUp += new System.Windows.Forms.MouseEventHandler( this.CanvasButtonUp );
			this.MouseEnter += new System.EventHandler( this.CanvasEnter );
			this.ClientSizeChanged += new System.EventHandler( this.Canvas_ClientSizeChanged );
			this.ResumeLayout( false );

        }

        #endregion
    }
}
