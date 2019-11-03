namespace AutoSessionScheduler
{
	partial class SessionImages
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
			this.imageList = new System.Windows.Forms.ListView();
			this.OkayButton = new System.Windows.Forms.Button();
			this.AddImageButton = new System.Windows.Forms.Button();
			this.ClearImageButton = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// SessionList
			// 
			this.SessionList.FormattingEnabled = true;
			this.SessionList.Location = new System.Drawing.Point( 12, 12 );
			this.SessionList.Name = "SessionList";
			this.SessionList.Size = new System.Drawing.Size( 125, 290 );
			this.SessionList.TabIndex = 0;
			this.SessionList.SelectedValueChanged += new System.EventHandler( this.SessionList_SelectedValueChanged );
			// 
			// imageList
			// 
			this.imageList.Location = new System.Drawing.Point( 152, 12 );
			this.imageList.Name = "imageList";
			this.imageList.Size = new System.Drawing.Size( 397, 290 );
			this.imageList.TabIndex = 1;
			this.imageList.UseCompatibleStateImageBehavior = false;
			this.imageList.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler( this.imageList_ItemSelectionChanged );
			// 
			// OkayButton
			// 
			this.OkayButton.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.OkayButton.Location = new System.Drawing.Point( 474, 308 );
			this.OkayButton.Name = "OkayButton";
			this.OkayButton.Size = new System.Drawing.Size( 75, 41 );
			this.OkayButton.TabIndex = 3;
			this.OkayButton.Text = "Done";
			this.OkayButton.UseVisualStyleBackColor = true;
			// 
			// AddImageButton
			// 
			this.AddImageButton.Location = new System.Drawing.Point( 152, 308 );
			this.AddImageButton.Name = "AddImageButton";
			this.AddImageButton.Size = new System.Drawing.Size( 75, 41 );
			this.AddImageButton.TabIndex = 4;
			this.AddImageButton.Text = "Add Image";
			this.AddImageButton.UseVisualStyleBackColor = true;
			this.AddImageButton.Click += new System.EventHandler( this.AddImageButton_Click );
			// 
			// ClearImageButton
			// 
			this.ClearImageButton.Location = new System.Drawing.Point( 233, 308 );
			this.ClearImageButton.Name = "ClearImageButton";
			this.ClearImageButton.Size = new System.Drawing.Size( 75, 41 );
			this.ClearImageButton.TabIndex = 5;
			this.ClearImageButton.Text = "Clear Image";
			this.ClearImageButton.UseVisualStyleBackColor = true;
			this.ClearImageButton.Click += new System.EventHandler( this.ClearImageButton_Click );
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point( 314, 308 );
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size( 75, 41 );
			this.button1.TabIndex = 6;
			this.button1.Text = "Delete Image";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler( this.button1_Click );
			// 
			// SessionImages
			// 
			this.AcceptButton = this.OkayButton;
			this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.OkayButton;
			this.ClientSize = new System.Drawing.Size( 561, 361 );
			this.ControlBox = false;
			this.Controls.Add( this.button1 );
			this.Controls.Add( this.ClearImageButton );
			this.Controls.Add( this.AddImageButton );
			this.Controls.Add( this.OkayButton );
			this.Controls.Add( this.imageList );
			this.Controls.Add( this.SessionList );
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Name = "SessionImages";
			this.Text = "Edit Image Assignment";
			this.ResumeLayout( false );

		}

		#endregion

		private System.Windows.Forms.ListBox SessionList;
		private System.Windows.Forms.ListView imageList;
		private System.Windows.Forms.Button OkayButton;
		private System.Windows.Forms.Button AddImageButton;
		private System.Windows.Forms.Button ClearImageButton;
		private System.Windows.Forms.Button button1;
	}
}