namespace Blackout
{
    partial class Floater
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
            this.components = new System.ComponentModel.Container();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.newFloaterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lockToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.colorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.destroyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newFloaterToolStripMenuItem,
            this.lockToolStripMenuItem,
            this.colorToolStripMenuItem,
            this.resizeToolStripMenuItem,
            this.destroyToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(138, 114);
            // 
            // newFloaterToolStripMenuItem
            // 
            this.newFloaterToolStripMenuItem.Name = "newFloaterToolStripMenuItem";
            this.newFloaterToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.newFloaterToolStripMenuItem.Text = "New Floater";
            this.newFloaterToolStripMenuItem.Click += new System.EventHandler(this.CreateFloater);
            // 
            // lockToolStripMenuItem
            // 
            this.lockToolStripMenuItem.Name = "lockToolStripMenuItem";
            this.lockToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.lockToolStripMenuItem.Text = "Lock";
            this.lockToolStripMenuItem.Click += new System.EventHandler(this.LockFloater);
            // 
            // colorToolStripMenuItem
            // 
            this.colorToolStripMenuItem.Name = "colorToolStripMenuItem";
            this.colorToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.colorToolStripMenuItem.Text = "Color";
            this.colorToolStripMenuItem.Click += new System.EventHandler(this.PickColor);
            // 
            // resizeToolStripMenuItem
            // 
            this.resizeToolStripMenuItem.Name = "resizeToolStripMenuItem";
            this.resizeToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.resizeToolStripMenuItem.Text = "Resize";
            this.resizeToolStripMenuItem.Click += new System.EventHandler(this.Resize);
            // 
            // destroyToolStripMenuItem
            // 
            this.destroyToolStripMenuItem.Name = "destroyToolStripMenuItem";
            this.destroyToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.destroyToolStripMenuItem.Text = "Destroy";
            this.destroyToolStripMenuItem.Click += new System.EventHandler(this.DestroyFloater);
            // 
            // Floater
            // 
            this.ClientSize = new System.Drawing.Size(284, 264);
            this.ControlBox = false;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Floater";
            this.ShowInTaskbar = false;
            this.TopMost = true;
            this.TransparencyKey = System.Drawing.Color.Maroon;
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.FloaterPaint);
            this.SizeChanged += new System.EventHandler(this.Floater_SizeChanged);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ReleaseFrame);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FloaterClose);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MoveFrame);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.GrabFrame);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem newFloaterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lockToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem colorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem resizeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem destroyToolStripMenuItem;
    }
}
