namespace OpenSkieScheduler
{
    partial class RelatedTableEditor
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
			this.buttonNewSession = new System.Windows.Forms.Button();
			this.buttonNewMacro = new System.Windows.Forms.Button();
			this.buttonSessionEdit = new System.Windows.Forms.Button();
			this.dataGridViewMaster1 = new System.Windows.Forms.DataGridView();
			this.dataGridViewMaster2 = new System.Windows.Forms.DataGridView();
			this.dataGridViewRelation1 = new System.Windows.Forms.DataGridView();
			( (System.ComponentModel.ISupportInitialize)( this.dataGridViewMaster1 ) ).BeginInit();
			( (System.ComponentModel.ISupportInitialize)( this.dataGridViewMaster2 ) ).BeginInit();
			( (System.ComponentModel.ISupportInitialize)( this.dataGridViewRelation1 ) ).BeginInit();
			this.SuspendLayout();
			// 
			// buttonNewSession
			// 
			this.buttonNewSession.Location = new System.Drawing.Point( 22, 388 );
			this.buttonNewSession.Name = "buttonNewSession";
			this.buttonNewSession.Size = new System.Drawing.Size( 67, 42 );
			this.buttonNewSession.TabIndex = 3;
			this.buttonNewSession.Text = "New Session";
			this.buttonNewSession.UseVisualStyleBackColor = true;
			this.buttonNewSession.Click += new System.EventHandler( this.buttonNewSession_Click );
			// 
			// buttonNewMacro
			// 
			this.buttonNewMacro.Location = new System.Drawing.Point( 22, 184 );
			this.buttonNewMacro.Name = "buttonNewMacro";
			this.buttonNewMacro.Size = new System.Drawing.Size( 67, 42 );
			this.buttonNewMacro.TabIndex = 7;
			this.buttonNewMacro.Text = "New Macro";
			this.buttonNewMacro.UseVisualStyleBackColor = true;
			this.buttonNewMacro.Click += new System.EventHandler( this.buttonNewMacro_Click );
			// 
			// buttonSessionEdit
			// 
			this.buttonSessionEdit.Location = new System.Drawing.Point( 96, 388 );
			this.buttonSessionEdit.Name = "buttonSessionEdit";
			this.buttonSessionEdit.Size = new System.Drawing.Size( 67, 42 );
			this.buttonSessionEdit.TabIndex = 12;
			this.buttonSessionEdit.Text = "Edit Session";
			this.buttonSessionEdit.UseVisualStyleBackColor = true;
			// 
			// dataGridViewMaster1
			// 
			this.dataGridViewMaster1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridViewMaster1.Location = new System.Drawing.Point( 22, 28 );
			this.dataGridViewMaster1.Name = "dataGridViewMaster1";
			this.dataGridViewMaster1.Size = new System.Drawing.Size( 587, 150 );
			this.dataGridViewMaster1.TabIndex = 13;
			// 
			// dataGridViewMaster2
			// 
			this.dataGridViewMaster2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridViewMaster2.Location = new System.Drawing.Point( 22, 232 );
			this.dataGridViewMaster2.Name = "dataGridViewMaster2";
			this.dataGridViewMaster2.Size = new System.Drawing.Size( 587, 150 );
			this.dataGridViewMaster2.TabIndex = 14;
			// 
			// dataGridViewRelation1
			// 
			this.dataGridViewRelation1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridViewRelation1.Location = new System.Drawing.Point( 22, 443 );
			this.dataGridViewRelation1.Name = "dataGridViewRelation1";
			this.dataGridViewRelation1.Size = new System.Drawing.Size( 587, 150 );
			this.dataGridViewRelation1.TabIndex = 15;
			// 
			// RelatedTableEditor
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size( 711, 605 );
			this.Controls.Add( this.dataGridViewRelation1 );
			this.Controls.Add( this.dataGridViewMaster2 );
			this.Controls.Add( this.dataGridViewMaster1 );
			this.Controls.Add( this.buttonSessionEdit );
			this.Controls.Add( this.buttonNewMacro );
			this.Controls.Add( this.buttonNewSession );
			this.Name = "RelatedTableEditor";
			this.Text = "Session Macros";
			( (System.ComponentModel.ISupportInitialize)( this.dataGridViewMaster1 ) ).EndInit();
			( (System.ComponentModel.ISupportInitialize)( this.dataGridViewMaster2 ) ).EndInit();
			( (System.ComponentModel.ISupportInitialize)( this.dataGridViewRelation1 ) ).EndInit();
			this.ResumeLayout( false );

        }

        #endregion

		private System.Windows.Forms.Button buttonNewSession;
		private System.Windows.Forms.Button buttonNewMacro;
		private System.Windows.Forms.Button buttonSessionEdit;
		private System.Windows.Forms.DataGridView dataGridViewMaster1;
		private System.Windows.Forms.DataGridView dataGridViewMaster2;
		private System.Windows.Forms.DataGridView dataGridViewRelation1;
    }
}

