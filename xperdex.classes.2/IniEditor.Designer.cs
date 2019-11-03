namespace xperdex.classes
{
	partial class INIEditor
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
			this.buttonRefresh = new System.Windows.Forms.Button();
			this.textBoxDescription = new System.Windows.Forms.TextBox();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.buttonUpdate = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.button1 = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// treeView1
			// 
			this.treeView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.treeView1.Location = new System.Drawing.Point(13, 33);
			this.treeView1.Name = "treeView1";
			this.treeView1.Size = new System.Drawing.Size(298, 223);
			this.treeView1.TabIndex = 0;
			this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
			// 
			// buttonRefresh
			// 
			this.buttonRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.buttonRefresh.Location = new System.Drawing.Point(13, 262);
			this.buttonRefresh.Name = "buttonRefresh";
			this.buttonRefresh.Size = new System.Drawing.Size(94, 42);
			this.buttonRefresh.TabIndex = 2;
			this.buttonRefresh.Text = "Load INI File";
			this.buttonRefresh.UseVisualStyleBackColor = true;
			this.buttonRefresh.Click += new System.EventHandler(this.button1_Click);
			// 
			// textBoxDescription
			// 
			this.textBoxDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxDescription.Location = new System.Drawing.Point(338, 123);
			this.textBoxDescription.Multiline = true;
			this.textBoxDescription.Name = "textBoxDescription";
			this.textBoxDescription.ReadOnly = true;
			this.textBoxDescription.Size = new System.Drawing.Size(228, 154);
			this.textBoxDescription.TabIndex = 3;
			// 
			// textBox2
			// 
			this.textBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox2.Location = new System.Drawing.Point(338, 52);
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new System.Drawing.Size(228, 20);
			this.textBox2.TabIndex = 4;
			// 
			// buttonUpdate
			// 
			this.buttonUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonUpdate.Location = new System.Drawing.Point(338, 79);
			this.buttonUpdate.Name = "buttonUpdate";
			this.buttonUpdate.Size = new System.Drawing.Size(75, 23);
			this.buttonUpdate.TabIndex = 5;
			this.buttonUpdate.Text = "Update";
			this.buttonUpdate.UseVisualStyleBackColor = true;
			this.buttonUpdate.Click += new System.EventHandler(this.buttonUpdate_Click);
			// 
			// label1
			// 
			this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(338, 33);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(176, 13);
			this.label1.TabIndex = 6;
			this.label1.Text = "Current Value (may edit and update)";
			// 
			// label2
			// 
			this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(338, 105);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(60, 13);
			this.label2.TabIndex = 7;
			this.label2.Text = "Description";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(12, 17);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(40, 13);
			this.label3.TabIndex = 8;
			this.label3.Text = "INI File";
			// 
			// button1
			// 
			this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.button1.Location = new System.Drawing.Point(224, 262);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(87, 42);
			this.button1.TabIndex = 9;
			this.button1.Text = "Delete Branch";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click_1);
			// 
			// INIEditor
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(608, 316);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.buttonUpdate);
			this.Controls.Add(this.textBox2);
			this.Controls.Add(this.textBoxDescription);
			this.Controls.Add(this.buttonRefresh);
			this.Controls.Add(this.treeView1);
			this.Name = "INIEditor";
			this.Text = "INI File Editor";
			this.Load += new System.EventHandler(this.OptionEditor_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TreeView treeView1;
		private System.Windows.Forms.Button buttonRefresh;
		private System.Windows.Forms.TextBox textBoxDescription;
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.Button buttonUpdate;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button button1;
	}
}