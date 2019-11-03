namespace OpenSkieScheduler3.Controls.PackControl
{
	partial class PackItemGen
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

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.labelName = new System.Windows.Forms.Label();
			this.labelDescription = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// labelName
			// 
			this.labelName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelName.Location = new System.Drawing.Point(3, 3);
			this.labelName.Name = "labelName";
			this.labelName.Size = new System.Drawing.Size(64, 50);
			this.labelName.TabIndex = 0;
			this.labelName.Text = "Name";
			this.labelName.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PackControl_MouseDown);
			// 
			// labelDescription
			// 
			this.labelDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelDescription.Location = new System.Drawing.Point(3, 53);
			this.labelDescription.Name = "labelDescription";
			this.labelDescription.Size = new System.Drawing.Size(64, 13);
			this.labelDescription.TabIndex = 1;
			this.labelDescription.Text = "Description";
			this.labelDescription.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PackControl_MouseDown);
			// 
			// PackItem
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.Controls.Add(this.labelDescription);
			this.Controls.Add(this.labelName);
			this.Name = "PackItem";
			this.Size = new System.Drawing.Size(70, 70);
			this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PackControl_MouseDown);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Label labelName;
		private System.Windows.Forms.Label labelDescription;
	}
}
