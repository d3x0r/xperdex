namespace ScheduleBuilder.GameDesigner
{
    partial class GameChooser
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
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point( 21, 12 );
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size( 210, 329 );
            this.listBox1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point( 243, 12 );
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size( 96, 48 );
            this.button1.TabIndex = 1;
            this.button1.Text = "Create Game";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler( this.button1_Click );
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point( 243, 84 );
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size( 96, 53 );
            this.button2.TabIndex = 2;
            this.button2.Text = "Edit Game Patterns";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler( this.button2_Click );
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point( 243, 171 );
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size( 75, 23 );
            this.button3.TabIndex = 3;
            this.button3.Text = "button3";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler( this.button3_Click );
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point( 243, 200 );
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size( 75, 23 );
            this.button4.TabIndex = 4;
            this.button4.Text = "button4";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // GameChooser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size( 560, 364 );
            this.Controls.Add( this.button4 );
            this.Controls.Add( this.button3 );
            this.Controls.Add( this.button2 );
            this.Controls.Add( this.button1 );
            this.Controls.Add( this.listBox1 );
            this.Name = "GameChooser";
            this.Text = "GameChooser";
            this.Load += new System.EventHandler( this.GameChooser_Load );
            this.ResumeLayout( false );

        }

        #endregion

        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
    }
}