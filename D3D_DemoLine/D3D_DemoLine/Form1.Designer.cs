namespace D3D_DemoLine
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
			this.button1 = new System.Windows.Forms.Button();
			this.direct3d1 = new Gosub.Direct3d();
			this.SuspendLayout();
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point( 36, 65 );
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size( 75, 23 );
			this.button1.TabIndex = 0;
			this.button1.Text = "button1";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler( this.button1_Click );
			// 
			// direct3d1
			// 
			this.direct3d1.DxAutoResize = false;
			this.direct3d1.DxBackBufferCount = 2;
			this.direct3d1.DxFullScreen = false;
			this.direct3d1.DxSimulateFullScreen = false;
			this.direct3d1.Location = new System.Drawing.Point( 25, 94 );
			this.direct3d1.Name = "direct3d1";
			this.direct3d1.Size = new System.Drawing.Size( 150, 150 );
			this.direct3d1.TabIndex = 0;
			this.direct3d1.DxRender3d += new Gosub.Direct3d.DxDirect3dDelegate( this.direct3d1_DxRender3d_1 );
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size( 284, 264 );
			this.Controls.Add( this.direct3d1 );
			this.Controls.Add( this.button1 );
			this.Name = "Form1";
			this.Text = "Form1";
			this.ResumeLayout( false );

		}

		#endregion

		private System.Windows.Forms.Button button1;
		private Gosub.Direct3d direct3d1;
	}
}

