namespace xperdex.gui
{
    partial class FontEditor
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
			this.FontList = new System.Windows.Forms.ListBox();
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.NewFont = new System.Windows.Forms.Button();
			this.EditFont = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// FontList
			// 
			this.FontList.FormattingEnabled = true;
			this.FontList.Location = new System.Drawing.Point( 23, 25 );
			this.FontList.Name = "FontList";
			this.FontList.Size = new System.Drawing.Size( 163, 160 );
			this.FontList.TabIndex = 0;
			// 
			// button1
			// 
			this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.button1.Location = new System.Drawing.Point( 196, 227 );
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size( 76, 25 );
			this.button1.TabIndex = 1;
			this.button1.Text = "Okay";
			this.button1.UseVisualStyleBackColor = true;
			// 
			// button2
			// 
			this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.button2.Location = new System.Drawing.Point( 110, 227 );
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size( 76, 25 );
			this.button2.TabIndex = 2;
			this.button2.Text = "Cancel";
			this.button2.UseVisualStyleBackColor = true;
			// 
			// NewFont
			// 
			this.NewFont.Location = new System.Drawing.Point( 192, 24 );
			this.NewFont.Name = "NewFont";
			this.NewFont.Size = new System.Drawing.Size( 76, 25 );
			this.NewFont.TabIndex = 3;
			this.NewFont.Text = "New Font";
			this.NewFont.UseVisualStyleBackColor = true;
			this.NewFont.Click += new System.EventHandler( this.NewFont_Click );
			// 
			// EditFont
			// 
			this.EditFont.Location = new System.Drawing.Point( 192, 55 );
			this.EditFont.Name = "EditFont";
			this.EditFont.Size = new System.Drawing.Size( 76, 25 );
			this.EditFont.TabIndex = 4;
			this.EditFont.Text = "Edit Font";
			this.EditFont.UseVisualStyleBackColor = true;
			this.EditFont.Click += new System.EventHandler( this.EditFont_Click );
			// 
			// FontEditor
			// 
			this.AcceptButton = this.button1;
			this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.button2;
			this.ClientSize = new System.Drawing.Size( 284, 264 );
			this.Controls.Add( this.EditFont );
			this.Controls.Add( this.NewFont );
			this.Controls.Add( this.button2 );
			this.Controls.Add( this.button1 );
			this.Controls.Add( this.FontList );
			this.Name = "FontEditor";
			this.Text = "Font Editor";
			this.Load += new System.EventHandler( this.LoadFonts );
			this.ResumeLayout( false );

        }

        #endregion

        private System.Windows.Forms.ListBox FontList;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button NewFont;
        private System.Windows.Forms.Button EditFont;
    }
}