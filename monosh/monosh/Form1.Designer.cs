namespace monosh
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
			this.treeView1 = new System.Windows.Forms.TreeView();
			this.listViewPrograms = new System.Windows.Forms.ListView();
			this.button1 = new System.Windows.Forms.Button();
			this.listViewAllFiles = new System.Windows.Forms.ListView();
			this.SuspendLayout();
			// 
			// treeView1
			// 
			this.treeView1.Location = new System.Drawing.Point( 13, 13 );
			this.treeView1.Name = "treeView1";
			this.treeView1.Size = new System.Drawing.Size( 383, 463 );
			this.treeView1.TabIndex = 0;
			this.treeView1.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler( this.treeView1_BeforeExpand );
			this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler( this.treeView1_AfterSelect );
			// 
			// listViewPrograms
			// 
			this.listViewPrograms.Location = new System.Drawing.Point( 422, 13 );
			this.listViewPrograms.MultiSelect = false;
			this.listViewPrograms.Name = "listViewPrograms";
			this.listViewPrograms.Size = new System.Drawing.Size( 351, 176 );
			this.listViewPrograms.TabIndex = 1;
			this.listViewPrograms.UseCompatibleStateImageBehavior = false;
			this.listViewPrograms.View = System.Windows.Forms.View.List;
			this.listViewPrograms.DoubleClick += new System.EventHandler( this.listView1_DoubleClick );
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point( 413, 442 );
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size( 75, 23 );
			this.button1.TabIndex = 2;
			this.button1.Text = "Reload";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler( this.button1_Click );
			// 
			// listViewAllFiles
			// 
			this.listViewAllFiles.Location = new System.Drawing.Point( 422, 223 );
			this.listViewAllFiles.MultiSelect = false;
			this.listViewAllFiles.Name = "listViewAllFiles";
			this.listViewAllFiles.Size = new System.Drawing.Size( 351, 176 );
			this.listViewAllFiles.TabIndex = 3;
			this.listViewAllFiles.UseCompatibleStateImageBehavior = false;
			this.listViewAllFiles.View = System.Windows.Forms.View.List;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size( 802, 488 );
			this.Controls.Add( this.listViewAllFiles );
			this.Controls.Add( this.button1 );
			this.Controls.Add( this.listViewPrograms );
			this.Controls.Add( this.treeView1 );
			this.Name = "Form1";
			this.Text = "Form1";
			this.Load += new System.EventHandler( this.Form1_Load );
			this.ResumeLayout( false );

		}

		#endregion

		private System.Windows.Forms.TreeView treeView1;
		private System.Windows.Forms.ListView listViewPrograms;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.ListView listViewAllFiles;
	}
}

