namespace xperdex.tasks
{
	partial class TaskProperties
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
			if( disposing && (components != null) )
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
			this.Okay = new System.Windows.Forms.Button();
			this.Cancel = new System.Windows.Forms.Button();
			this.BaseProperties = new System.Windows.Forms.Button();
			this.tabTaskProp = new System.Windows.Forms.TabControl();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.label1 = new System.Windows.Forms.Label();
			this.button2 = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.textBox5 = new System.Windows.Forms.TextBox();
			this.listBox1 = new System.Windows.Forms.ListBox();
			this.tabPageTaskProp = new System.Windows.Forms.TabPage();
			this.checkBoxRemote = new System.Windows.Forms.CheckBox();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.checkBox1 = new System.Windows.Forms.CheckBox();
			this.checkBoxRestart = new System.Windows.Forms.CheckBox();
			this.checkBoxRunOnce = new System.Windows.Forms.CheckBox();
			this.checkBoxExclusive = new System.Windows.Forms.CheckBox();
			this.label7 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.textBoxArguments = new System.Windows.Forms.TextBox();
			this.textBoxWorking = new System.Windows.Forms.TextBox();
			this.textBoxProgram = new System.Windows.Forms.TextBox();
			this.textBoxName = new System.Windows.Forms.TextBox();
			this.button3 = new System.Windows.Forms.Button();
			this.tabTaskProp.SuspendLayout();
			this.tabPage2.SuspendLayout();
			this.tabPageTaskProp.SuspendLayout();
			this.SuspendLayout();
			// 
			// Okay
			// 
			this.Okay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.Okay.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.Okay.Location = new System.Drawing.Point(416, 273);
			this.Okay.Name = "Okay";
			this.Okay.Size = new System.Drawing.Size(75, 37);
			this.Okay.TabIndex = 12;
			this.Okay.Text = "Okay";
			this.Okay.UseVisualStyleBackColor = true;
			// 
			// Cancel
			// 
			this.Cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.Cancel.Location = new System.Drawing.Point(335, 273);
			this.Cancel.Name = "Cancel";
			this.Cancel.Size = new System.Drawing.Size(75, 37);
			this.Cancel.TabIndex = 13;
			this.Cancel.Text = "Cancel";
			this.Cancel.UseVisualStyleBackColor = true;
			// 
			// BaseProperties
			// 
			this.BaseProperties.Location = new System.Drawing.Point(16, 275);
			this.BaseProperties.Name = "BaseProperties";
			this.BaseProperties.Size = new System.Drawing.Size(102, 32);
			this.BaseProperties.TabIndex = 14;
			this.BaseProperties.Text = "Button Properties";
			this.BaseProperties.UseVisualStyleBackColor = true;
			this.BaseProperties.Click += new System.EventHandler(this.BaseProperties_Click);
			// 
			// tabTaskProp
			// 
			this.tabTaskProp.Controls.Add(this.tabPage2);
			this.tabTaskProp.Controls.Add(this.tabPageTaskProp);
			this.tabTaskProp.Location = new System.Drawing.Point(12, 12);
			this.tabTaskProp.Name = "tabTaskProp";
			this.tabTaskProp.SelectedIndex = 0;
			this.tabTaskProp.Size = new System.Drawing.Size(479, 255);
			this.tabTaskProp.TabIndex = 16;
			// 
			// tabPage2
			// 
			this.tabPage2.Controls.Add(this.label1);
			this.tabPage2.Controls.Add(this.button2);
			this.tabPage2.Controls.Add(this.button1);
			this.tabPage2.Controls.Add(this.textBox5);
			this.tabPage2.Controls.Add(this.listBox1);
			this.tabPage2.Location = new System.Drawing.Point(4, 22);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage2.Size = new System.Drawing.Size(471, 229);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "System Permission";
			this.tabPage2.UseVisualStyleBackColor = true;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(6, 15);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(97, 13);
			this.label1.TabIndex = 20;
			this.label1.Text = "New System Name";
			this.label1.Click += new System.EventHandler(this.label1_Click);
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(141, 117);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(75, 49);
			this.button2.TabIndex = 19;
			this.button2.Text = "Delete System";
			this.button2.UseVisualStyleBackColor = true;
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(141, 62);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 49);
			this.button1.TabIndex = 18;
			this.button1.Text = "Add System";
			this.button1.UseVisualStyleBackColor = true;
			// 
			// textBox5
			// 
			this.textBox5.Location = new System.Drawing.Point(15, 31);
			this.textBox5.Name = "textBox5";
			this.textBox5.Size = new System.Drawing.Size(147, 20);
			this.textBox5.TabIndex = 17;
			// 
			// listBox1
			// 
			this.listBox1.FormattingEnabled = true;
			this.listBox1.Location = new System.Drawing.Point(15, 62);
			this.listBox1.Name = "listBox1";
			this.listBox1.Size = new System.Drawing.Size(120, 147);
			this.listBox1.TabIndex = 16;
			// 
			// tabPageTaskProp
			// 
			this.tabPageTaskProp.Controls.Add(this.button3);
			this.tabPageTaskProp.Controls.Add(this.checkBoxRemote);
			this.tabPageTaskProp.Controls.Add(this.label5);
			this.tabPageTaskProp.Controls.Add(this.label6);
			this.tabPageTaskProp.Controls.Add(this.checkBox1);
			this.tabPageTaskProp.Controls.Add(this.checkBoxRestart);
			this.tabPageTaskProp.Controls.Add(this.checkBoxRunOnce);
			this.tabPageTaskProp.Controls.Add(this.checkBoxExclusive);
			this.tabPageTaskProp.Controls.Add(this.label7);
			this.tabPageTaskProp.Controls.Add(this.label8);
			this.tabPageTaskProp.Controls.Add(this.textBoxArguments);
			this.tabPageTaskProp.Controls.Add(this.textBoxWorking);
			this.tabPageTaskProp.Controls.Add(this.textBoxProgram);
			this.tabPageTaskProp.Controls.Add(this.textBoxName);
			this.tabPageTaskProp.Location = new System.Drawing.Point(4, 22);
			this.tabPageTaskProp.Name = "tabPageTaskProp";
			this.tabPageTaskProp.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageTaskProp.Size = new System.Drawing.Size(471, 229);
			this.tabPageTaskProp.TabIndex = 0;
			this.tabPageTaskProp.Text = "Task Properties";
			this.tabPageTaskProp.UseVisualStyleBackColor = true;
			// 
			// checkBoxRemote
			// 
			this.checkBoxRemote.AutoSize = true;
			this.checkBoxRemote.Location = new System.Drawing.Point(13, 192);
			this.checkBoxRemote.Name = "checkBoxRemote";
			this.checkBoxRemote.Size = new System.Drawing.Size(63, 17);
			this.checkBoxRemote.TabIndex = 24;
			this.checkBoxRemote.Text = "Remote";
			this.checkBoxRemote.UseVisualStyleBackColor = true;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(10, 97);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(57, 13);
			this.label5.TabIndex = 23;
			this.label5.Text = "Arguments";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(10, 68);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(72, 13);
			this.label6.TabIndex = 22;
			this.label6.Text = "Working Path";
			// 
			// checkBox1
			// 
			this.checkBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.checkBox1.AutoSize = true;
			this.checkBox1.Location = new System.Drawing.Point(127, 168);
			this.checkBox1.Name = "checkBox1";
			this.checkBox1.Size = new System.Drawing.Size(98, 17);
			this.checkBox1.TabIndex = 19;
			this.checkBox1.Text = "Capture Output";
			this.checkBox1.UseVisualStyleBackColor = true;
			// 
			// checkBoxRestart
			// 
			this.checkBoxRestart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.checkBoxRestart.AutoSize = true;
			this.checkBoxRestart.Location = new System.Drawing.Point(127, 135);
			this.checkBoxRestart.Name = "checkBoxRestart";
			this.checkBoxRestart.Size = new System.Drawing.Size(85, 17);
			this.checkBoxRestart.TabIndex = 18;
			this.checkBoxRestart.Text = "Auto Restart";
			this.checkBoxRestart.UseVisualStyleBackColor = true;
			// 
			// checkBoxRunOnce
			// 
			this.checkBoxRunOnce.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.checkBoxRunOnce.AutoSize = true;
			this.checkBoxRunOnce.Location = new System.Drawing.Point(13, 135);
			this.checkBoxRunOnce.Name = "checkBoxRunOnce";
			this.checkBoxRunOnce.Size = new System.Drawing.Size(75, 17);
			this.checkBoxRunOnce.TabIndex = 17;
			this.checkBoxRunOnce.Text = "Run Once";
			this.checkBoxRunOnce.UseVisualStyleBackColor = true;
			// 
			// checkBoxExclusive
			// 
			this.checkBoxExclusive.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.checkBoxExclusive.AutoSize = true;
			this.checkBoxExclusive.Location = new System.Drawing.Point(13, 168);
			this.checkBoxExclusive.Name = "checkBoxExclusive";
			this.checkBoxExclusive.Size = new System.Drawing.Size(71, 17);
			this.checkBoxExclusive.TabIndex = 16;
			this.checkBoxExclusive.Text = "Exclusive";
			this.checkBoxExclusive.UseVisualStyleBackColor = true;
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(10, 40);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(46, 13);
			this.label7.TabIndex = 21;
			this.label7.Text = "Program";
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(10, 12);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(64, 13);
			this.label8.TabIndex = 20;
			this.label8.Text = "Control Text";
			// 
			// textBoxArguments
			// 
			this.textBoxArguments.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxArguments.Location = new System.Drawing.Point(127, 94);
			this.textBoxArguments.Name = "textBoxArguments";
			this.textBoxArguments.Size = new System.Drawing.Size(193, 20);
			this.textBoxArguments.TabIndex = 15;
			// 
			// textBoxWorking
			// 
			this.textBoxWorking.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxWorking.Location = new System.Drawing.Point(127, 65);
			this.textBoxWorking.Name = "textBoxWorking";
			this.textBoxWorking.Size = new System.Drawing.Size(193, 20);
			this.textBoxWorking.TabIndex = 14;
			// 
			// textBoxProgram
			// 
			this.textBoxProgram.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxProgram.Location = new System.Drawing.Point(127, 37);
			this.textBoxProgram.Name = "textBoxProgram";
			this.textBoxProgram.Size = new System.Drawing.Size(193, 20);
			this.textBoxProgram.TabIndex = 13;
			// 
			// textBoxName
			// 
			this.textBoxName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxName.Location = new System.Drawing.Point(127, 9);
			this.textBoxName.Name = "textBoxName";
			this.textBoxName.Size = new System.Drawing.Size(193, 20);
			this.textBoxName.TabIndex = 12;
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(338, 31);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(75, 29);
			this.button3.TabIndex = 25;
			this.button3.Text = "Browse";
			this.button3.UseVisualStyleBackColor = true;
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// TaskProperties
			// 
			this.AcceptButton = this.Okay;
			this.CancelButton = this.Cancel;
			this.ClientSize = new System.Drawing.Size(506, 331);
			this.Controls.Add(this.BaseProperties);
			this.Controls.Add(this.Cancel);
			this.Controls.Add(this.Okay);
			this.Controls.Add(this.tabTaskProp);
			this.Name = "TaskProperties";
			this.Text = "Task Properties";
			this.Load += new System.EventHandler(this.TaskProperties_Load);
			this.tabTaskProp.ResumeLayout(false);
			this.tabPage2.ResumeLayout(false);
			this.tabPage2.PerformLayout();
			this.tabPageTaskProp.ResumeLayout(false);
			this.tabPageTaskProp.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button Okay;
		private System.Windows.Forms.Button Cancel;
		private System.Windows.Forms.Button BaseProperties;
		private System.Windows.Forms.TabControl tabTaskProp;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.TabPage tabPageTaskProp;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.TextBox textBox5;
		private System.Windows.Forms.ListBox listBox1;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.CheckBox checkBox1;
		private System.Windows.Forms.CheckBox checkBoxRestart;
		private System.Windows.Forms.CheckBox checkBoxRunOnce;
		private System.Windows.Forms.CheckBox checkBoxExclusive;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.TextBox textBoxArguments;
		private System.Windows.Forms.TextBox textBoxWorking;
		private System.Windows.Forms.TextBox textBoxProgram;
		private System.Windows.Forms.TextBox textBoxName;
		private System.Windows.Forms.CheckBox checkBoxRemote;
		private System.Windows.Forms.Button button3;
	}
}