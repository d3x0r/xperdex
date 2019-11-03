namespace AutoSessionScheduler
{
	partial class SessionSalesDefine
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
			if( disposing && ( components != null ) )
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
			this.SessionList = new System.Windows.Forms.ListBox();
			this.PageList = new System.Windows.Forms.DataGridView();
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.button3 = new System.Windows.Forms.Button();
			this.button4 = new System.Windows.Forms.Button();
			this.button5 = new System.Windows.Forms.Button();
			( (System.ComponentModel.ISupportInitialize)( this.PageList ) ).BeginInit();
			this.SuspendLayout();
			// 
			// SessionList
			// 
			this.SessionList.FormattingEnabled = true;
			this.SessionList.Location = new System.Drawing.Point( 12, 42 );
			this.SessionList.Name = "SessionList";
			this.SessionList.Size = new System.Drawing.Size( 159, 225 );
			this.SessionList.TabIndex = 0;
			this.SessionList.SelectedValueChanged += new System.EventHandler( this.SessionList_SelectedValueChanged );
			// 
			// PageList
			// 
			this.PageList.AllowUserToAddRows = false;
			this.PageList.AllowUserToDeleteRows = false;
			this.PageList.AllowUserToResizeColumns = false;
			this.PageList.AllowUserToResizeRows = false;
			this.PageList.BackgroundColor = System.Drawing.SystemColors.Window;
			this.PageList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.PageList.Location = new System.Drawing.Point( 194, 42 );
			this.PageList.Name = "PageList";
			this.PageList.RowHeadersVisible = false;
			this.PageList.Size = new System.Drawing.Size( 354, 225 );
			this.PageList.TabIndex = 1;
			this.PageList.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler( this.PageList_CellDoubleClick );
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point( 12, 287 );
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size( 105, 39 );
			this.button1.TabIndex = 2;
			this.button1.Text = "Create Session";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler( this.button1_Click );
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point( 194, 287 );
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size( 105, 39 );
			this.button2.TabIndex = 3;
			this.button2.Text = "Add Page";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler( this.button2_Click );
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point( 13, 13 );
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size( 78, 13 );
			this.label1.TabIndex = 4;
			this.label1.Text = "Sales Sessions";
			this.label1.Click += new System.EventHandler( this.label1_Click );
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point( 191, 13 );
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size( 62, 13 );
			this.label2.TabIndex = 5;
			this.label2.Text = "POS Pages";
			this.label2.Click += new System.EventHandler( this.label2_Click );
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point( 194, 332 );
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size( 105, 39 );
			this.button3.TabIndex = 6;
			this.button3.Text = "Delete Page";
			this.button3.UseVisualStyleBackColor = true;
			this.button3.Click += new System.EventHandler( this.button3_Click );
			// 
			// button4
			// 
			this.button4.Location = new System.Drawing.Point( 12, 332 );
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size( 105, 39 );
			this.button4.TabIndex = 7;
			this.button4.Text = "Delete Session";
			this.button4.UseVisualStyleBackColor = true;
			this.button4.Click += new System.EventHandler( this.button4_Click );
			// 
			// button5
			// 
			this.button5.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.button5.Location = new System.Drawing.Point( 460, 346 );
			this.button5.Name = "button5";
			this.button5.Size = new System.Drawing.Size( 105, 39 );
			this.button5.TabIndex = 8;
			this.button5.Text = "Done";
			this.button5.UseVisualStyleBackColor = true;
			// 
			// SessionSalesDefine
			// 
			this.AcceptButton = this.button5;
			this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.button5;
			this.ClientSize = new System.Drawing.Size( 577, 397 );
			this.ControlBox = false;
			this.Controls.Add( this.button5 );
			this.Controls.Add( this.button4 );
			this.Controls.Add( this.button3 );
			this.Controls.Add( this.label2 );
			this.Controls.Add( this.label1 );
			this.Controls.Add( this.button2 );
			this.Controls.Add( this.button1 );
			this.Controls.Add( this.PageList );
			this.Controls.Add( this.SessionList );
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Name = "SessionSalesDefine";
			this.Text = "Set POS Page Unlocks";
			( (System.ComponentModel.ISupportInitialize)( this.PageList ) ).EndInit();
			this.ResumeLayout( false );
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ListBox SessionList;
		private System.Windows.Forms.DataGridView PageList;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.Button button4;
		private System.Windows.Forms.Button button5;
	}
}