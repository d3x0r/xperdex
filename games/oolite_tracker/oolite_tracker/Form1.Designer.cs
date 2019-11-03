namespace oolite_tracker
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
            this.priceGridView1 = new oolite_tracker.PriceGridView();
            ((System.ComponentModel.ISupportInitialize)(this.priceGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // priceGridView1
            // 
            this.priceGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.priceGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.priceGridView1.Location = new System.Drawing.Point(0, 0);
            this.priceGridView1.Name = "priceGridView1";
            this.priceGridView1.Size = new System.Drawing.Size(565, 326);
            this.priceGridView1.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(565, 326);
            this.Controls.Add(this.priceGridView1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.priceGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private PriceGridView priceGridView1;
    }
}