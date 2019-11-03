namespace CMakeProjectManager
{
	partial class CreateTarget
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
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.comboBox1 = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.buttonCancel = new System.Windows.Forms.Button();
			this.buttonOk = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point( 55, 33 );
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size( 186, 20 );
			this.textBox1.TabIndex = 0;
			// 
			// comboBox1
			// 
			this.comboBox1.FormattingEnabled = true;
			this.comboBox1.Location = new System.Drawing.Point( 55, 89 );
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new System.Drawing.Size( 121, 21 );
			this.comboBox1.TabIndex = 1;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point( 22, 13 );
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size( 69, 13 );
			this.label1.TabIndex = 2;
			this.label1.Text = "Target Name";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point( 25, 68 );
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size( 65, 13 );
			this.label2.TabIndex = 3;
			this.label2.Text = "Target Type";
			// 
			// buttonCancel
			// 
			this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.buttonCancel.Location = new System.Drawing.Point( 116, 119 );
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size( 75, 23 );
			this.buttonCancel.TabIndex = 4;
			this.buttonCancel.Text = "Cancel";
			this.buttonCancel.UseVisualStyleBackColor = true;
			this.buttonCancel.Click += new System.EventHandler( this.buttonCancel_Click );
			// 
			// buttonOk
			// 
			this.buttonOk.Location = new System.Drawing.Point( 197, 119 );
			this.buttonOk.Name = "buttonOk";
			this.buttonOk.Size = new System.Drawing.Size( 75, 23 );
			this.buttonOk.TabIndex = 5;
			this.buttonOk.Text = "Ok";
			this.buttonOk.UseVisualStyleBackColor = true;
			this.buttonOk.Click += new System.EventHandler( this.buttonOk_Click );
			// 
			// CreateTarget
			// 
			this.AcceptButton = this.buttonOk;
			this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.buttonCancel;
			this.ClientSize = new System.Drawing.Size( 284, 152 );
			this.Controls.Add( this.buttonOk );
			this.Controls.Add( this.buttonCancel );
			this.Controls.Add( this.label2 );
			this.Controls.Add( this.label1 );
			this.Controls.Add( this.comboBox1 );
			this.Controls.Add( this.textBox1 );
			this.Name = "CreateTarget";
			this.Text = "Create New Target";
			this.Load += new System.EventHandler( this.CreateTarget_Load );
			this.ResumeLayout( false );
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.ComboBox comboBox1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button buttonCancel;
		private System.Windows.Forms.Button buttonOk;
	}
}