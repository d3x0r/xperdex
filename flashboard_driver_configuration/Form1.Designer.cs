namespace flashboard_driver_configuration
{
    partial class Form1
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
            if ( disposing && ( components != null ) )
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.tabControl1.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point( 12, 74 );
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size( 196, 238 );
            this.listBox1.TabIndex = 0;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add( this.tabPage1 );
            this.tabControl1.Controls.Add( this.tabPage2 );
            this.tabControl1.Location = new System.Drawing.Point( 224, 13 );
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size( 288, 299 );
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point( 4, 22 );
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding( 3 );
            this.tabPage1.Size = new System.Drawing.Size( 280, 273 );
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point( 4, 22 );
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding( 3 );
            this.tabPage2.Size = new System.Drawing.Size( 192, 74 );
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabControl2
            // 
            this.tabControl2.Controls.Add( this.tabPage3 );
            this.tabControl2.Controls.Add( this.tabPage4 );
            this.tabControl2.Location = new System.Drawing.Point( 86, 13 );
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size( 80, 42 );
            this.tabControl2.TabIndex = 2;
            this.tabControl2.Visible = false;
            // 
            // tabPage3
            // 
            this.tabPage3.Location = new System.Drawing.Point( 4, 22 );
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding( 3 );
            this.tabPage3.Size = new System.Drawing.Size( 72, 16 );
            this.tabPage3.TabIndex = 0;
            this.tabPage3.Text = "tabPage3";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            this.tabPage4.Location = new System.Drawing.Point( 4, 22 );
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding( 3 );
            this.tabPage4.Size = new System.Drawing.Size( 192, 74 );
            this.tabPage4.TabIndex = 1;
            this.tabPage4.Text = "tabPage4";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size( 524, 324 );
            this.Controls.Add( this.tabControl2 );
            this.Controls.Add( this.tabControl1 );
            this.Controls.Add( this.listBox1 );
            this.Name = "Form1";
            this.Text = "Flashboard Driver Configuration";
            this.Load += new System.EventHandler( this.Form1_Load );
            this.tabControl1.ResumeLayout( false );
            this.tabControl2.ResumeLayout( false );
            this.ResumeLayout( false );

        }

        #endregion

        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
    }
}

