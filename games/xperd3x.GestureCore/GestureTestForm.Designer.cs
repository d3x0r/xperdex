namespace xperd3x.GestureCore
{
	partial class GestureTestForm
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
			this.psI_Control1 = new xperdex.classes.PSI_Control();
			this.SuspendLayout();
			// 
			// psI_Control1
			// 
			this.psI_Control1.BackColor = System.Drawing.Color.Transparent;
			this.psI_Control1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.psI_Control1.Location = new System.Drawing.Point( 0, 0 );
			this.psI_Control1.Movable = false;
			this.psI_Control1.Name = "psI_Control1";
			this.psI_Control1.Size = new System.Drawing.Size( 284, 264 );
			this.psI_Control1.TabIndex = 0;
			this.psI_Control1.Paint += new System.Windows.Forms.PaintEventHandler( this.psI_Control1_Paint );
			this.psI_Control1.MouseMove += new System.Windows.Forms.MouseEventHandler( this.psI_Control1_MouseMove );
			this.psI_Control1.MouseDown += new System.Windows.Forms.MouseEventHandler( this.psI_Control1_MouseDown );
			this.psI_Control1.MouseUp += new System.Windows.Forms.MouseEventHandler( this.psI_Control1_MouseUp );
			// 
			// GestureTestForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size( 284, 264 );
			this.Controls.Add( this.psI_Control1 );
			this.Name = "GestureTestForm";
			this.Text = "GestureTestForm";
			this.ResumeLayout( false );

		}

		#endregion

		private xperdex.classes.PSI_Control psI_Control1;
	}
}