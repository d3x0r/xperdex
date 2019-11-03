using System;
using System.Collections.Generic;
using System.Text;
using xperdex.classes;
using System.Windows.Forms;
using System.Reflection;
using System.Diagnostics;
using System.IO;

namespace xperdex.xplorer
{
	public class Xplorer: PSI_Control, IReflectorWidget
	{
		// aximp “SystemRoot\system32\SHDocVw.dll”
		public Xplorer()
		{
			InitializeComponent();
		}

		#region IReflectorWidget Members

		public bool CanShow
		{
			get
			{
				//throw new Exception("The method or operation is not implemented."); 
				return true;
			}
		}

		void IReflectorWidget.OnPaint( System.Windows.Forms.PaintEventArgs e )
		{
			//throw new Exception("The method or operation is not implemented.");
		}

        void IReflectorWidget.OnKeyPress(System.Windows.Forms.KeyPressEventArgs e)
		{
			//throw new Exception("The method or operation is not implemented.");
		}

		#endregion

		WebBrowser webBrowser1;

		private void InitializeComponent()
		{
			this.webBrowser1 = new System.Windows.Forms.WebBrowser();
			this.SuspendLayout();
			// 
			// webBrowser1
			// 
			this.webBrowser1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.webBrowser1.Location = new System.Drawing.Point( 0, 0 );
			this.webBrowser1.MinimumSize = new System.Drawing.Size( 20, 20 );
			this.webBrowser1.Name = "webBrowser1";
			this.webBrowser1.Size = new System.Drawing.Size( 277, 98 );
			this.webBrowser1.TabIndex = 0;
			this.webBrowser1.Navigate( "file:///" + Directory.GetCurrentDirectory() + "/Startup.html" );
			// 
			// Xplorer
			// 
			this.Controls.Add( this.webBrowser1 );
			this.Name = "Xplorer";
			this.ResumeLayout( false );

		}
	}
}
