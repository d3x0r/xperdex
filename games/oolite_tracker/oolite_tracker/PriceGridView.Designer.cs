namespace oolite_tracker
{
    partial class PriceGridView
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
			this.components = new System.ComponentModel.Container();
			this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip( this.components );
			this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
			this.SystemJump = new oolite_tracker.SystemSelect();
			this.commoditySelect1 = new oolite_tracker.CommoditySelect();
			this.contextMenuStrip1.SuspendLayout();
			( (System.ComponentModel.ISupportInitialize)( this ) ).BeginInit();
			this.SuspendLayout();
			// 
			// contextMenuStrip1
			// 
			this.contextMenuStrip1.Items.AddRange( new System.Windows.Forms.ToolStripItem[] {
            this.SystemJump,
            this.commoditySelect1,
            this.toolStripMenuItem1,
            this.toolStripMenuItem2} );
			this.contextMenuStrip1.Name = "contextMenuStrip1";
			this.contextMenuStrip1.Size = new System.Drawing.Size( 182, 102 );
			this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler( this.contextMenuStrip1_Opening_1 );
			// 
			// toolStripMenuItem1
			// 
			this.toolStripMenuItem1.Name = "toolStripMenuItem1";
			this.toolStripMenuItem1.Size = new System.Drawing.Size( 181, 22 );
			this.toolStripMenuItem1.Text = "Delete";
			this.toolStripMenuItem1.Click += new System.EventHandler( this.toolStripMenuItem1_Click );
			// 
			// toolStripMenuItem2
			// 
			this.toolStripMenuItem2.CheckOnClick = true;
			this.toolStripMenuItem2.Name = "toolStripMenuItem2";
			this.toolStripMenuItem2.Size = new System.Drawing.Size( 181, 22 );
			this.toolStripMenuItem2.Text = "Use Pivot Table";
			this.toolStripMenuItem2.Click += new System.EventHandler( this.toolStripMenuItem2_Click );
			// 
			// SystemJump
			// 
			this.SystemJump.Name = "SystemJump";
			this.SystemJump.Size = new System.Drawing.Size( 121, 23 );
			// 
			// commoditySelect1
			// 
			this.commoditySelect1.Name = "commoditySelect1";
			this.commoditySelect1.Size = new System.Drawing.Size( 121, 23 );
			// 
			// PriceGridView
			// 
			this.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler( this.PriceGridView_RowAdded );
			this.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler( this.AllowAbortNewRow );
			this.contextMenuStrip1.ResumeLayout( false );
			( (System.ComponentModel.ISupportInitialize)( this ) ).EndInit();
			this.ResumeLayout( false );

        }
															

        #endregion

        private Oolite_System_Info oolite_System_Info1;
        public System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        public SystemSelect SystemJump;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
		private CommoditySelect commoditySelect1;
    }
}
