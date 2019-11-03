namespace OpenSkie.classes
{
	partial class DataTableButtonEditor
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
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.radioButton1 = new System.Windows.Forms.RadioButton();
			this.radioButton2 = new System.Windows.Forms.RadioButton();
			this.radioButton3 = new System.Windows.Forms.RadioButton();
			this.radioButton4 = new System.Windows.Forms.RadioButton();
			this.radioButton5 = new System.Windows.Forms.RadioButton();
			this.listViewDisplayMember = new System.Windows.Forms.ListView();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.listView1 = new System.Windows.Forms.ListView();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add( this.radioButton5 );
			this.groupBox1.Controls.Add( this.radioButton4 );
			this.groupBox1.Controls.Add( this.radioButton3 );
			this.groupBox1.Controls.Add( this.radioButton2 );
			this.groupBox1.Controls.Add( this.radioButton1 );
			this.groupBox1.Location = new System.Drawing.Point( 25, 41 );
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size( 112, 150 );
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "groupBox1";
			// 
			// radioButton1
			// 
			this.radioButton1.AutoSize = true;
			this.radioButton1.Location = new System.Drawing.Point( 7, 20 );
			this.radioButton1.Name = "radioButton1";
			this.radioButton1.Size = new System.Drawing.Size( 82, 17 );
			this.radioButton1.TabIndex = 0;
			this.radioButton1.TabStop = true;
			this.radioButton1.Text = "Data Button";
			this.radioButton1.UseVisualStyleBackColor = true;
			// 
			// radioButton2
			// 
			this.radioButton2.AutoSize = true;
			this.radioButton2.Location = new System.Drawing.Point( 7, 43 );
			this.radioButton2.Name = "radioButton2";
			this.radioButton2.Size = new System.Drawing.Size( 70, 17 );
			this.radioButton2.TabIndex = 1;
			this.radioButton2.TabStop = true;
			this.radioButton2.Text = "Next Item";
			this.radioButton2.UseVisualStyleBackColor = true;
			// 
			// radioButton3
			// 
			this.radioButton3.AutoSize = true;
			this.radioButton3.Location = new System.Drawing.Point( 7, 66 );
			this.radioButton3.Name = "radioButton3";
			this.radioButton3.Size = new System.Drawing.Size( 69, 17 );
			this.radioButton3.TabIndex = 2;
			this.radioButton3.TabStop = true;
			this.radioButton3.Text = "Prior Item";
			this.radioButton3.UseVisualStyleBackColor = true;
			// 
			// radioButton4
			// 
			this.radioButton4.AutoSize = true;
			this.radioButton4.Location = new System.Drawing.Point( 7, 89 );
			this.radioButton4.Name = "radioButton4";
			this.radioButton4.Size = new System.Drawing.Size( 75, 17 );
			this.radioButton4.TabIndex = 1;
			this.radioButton4.TabStop = true;
			this.radioButton4.Text = "Next Page";
			this.radioButton4.UseVisualStyleBackColor = true;
			// 
			// radioButton5
			// 
			this.radioButton5.AutoSize = true;
			this.radioButton5.Location = new System.Drawing.Point( 6, 112 );
			this.radioButton5.Name = "radioButton5";
			this.radioButton5.Size = new System.Drawing.Size( 74, 17 );
			this.radioButton5.TabIndex = 3;
			this.radioButton5.TabStop = true;
			this.radioButton5.Text = "Prior Page";
			this.radioButton5.UseVisualStyleBackColor = true;
			// 
			// listViewDisplayMember
			// 
			this.listViewDisplayMember.Location = new System.Drawing.Point( 171, 173 );
			this.listViewDisplayMember.Name = "listViewDisplayMember";
			this.listViewDisplayMember.Size = new System.Drawing.Size( 121, 97 );
			this.listViewDisplayMember.TabIndex = 1;
			this.listViewDisplayMember.UseCompatibleStateImageBehavior = false;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point( 168, 157 );
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size( 119, 13 );
			this.label1.TabIndex = 2;
			this.label1.Text = "Primary Display Member";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point( 168, 25 );
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size( 71, 13 );
			this.label2.TabIndex = 4;
			this.label2.Text = "Primary Table";
			// 
			// listView1
			// 
			this.listView1.Location = new System.Drawing.Point( 171, 41 );
			this.listView1.Name = "listView1";
			this.listView1.Size = new System.Drawing.Size( 121, 97 );
			this.listView1.TabIndex = 3;
			this.listView1.UseCompatibleStateImageBehavior = false;
			// 
			// DataTableButtonEditor
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size( 482, 322 );
			this.Controls.Add( this.label2 );
			this.Controls.Add( this.listView1 );
			this.Controls.Add( this.label1 );
			this.Controls.Add( this.listViewDisplayMember );
			this.Controls.Add( this.groupBox1 );
			this.Name = "DataTableButtonEditor";
			this.Text = "DataTableButtonEditor";
			this.groupBox1.ResumeLayout( false );
			this.groupBox1.PerformLayout();
			this.ResumeLayout( false );
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.RadioButton radioButton3;
		private System.Windows.Forms.RadioButton radioButton2;
		private System.Windows.Forms.RadioButton radioButton1;
		private System.Windows.Forms.RadioButton radioButton5;
		private System.Windows.Forms.RadioButton radioButton4;
		private System.Windows.Forms.ListView listViewDisplayMember;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ListView listView1;
	}
}