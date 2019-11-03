using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using xperdex.classes;
using System.Runtime.InteropServices;
using System.Diagnostics;
using xperdex.core.interfaces;

namespace xperdex.InterShell
{
	[ControlAttribute( Name= "Intershell Canvas" )]
	public class Plugin: Control, IReflectorPersistance, IReflectorWindow
	{
		sack.InterShell.InterShell_Canvas canvas;

		public override string ToString()
		{
			//using SACK
			return "InterShell Interfacer...";
		}

		public Plugin()
		{
			ConfigName = ".default.config";
			canvas = new sack.InterShell.InterShell_Canvas( this.Handle );
			Paint += new PaintEventHandler( Plugin_Paint );
		}

		void Plugin_Paint( object sender, PaintEventArgs e )
		{
			e.Graphics.DrawString( "whatever", SystemFonts.DefaultFont, SystemBrushes.Control, new PointF( 10, 10 ) );
		}


		protected override void OnSizeChanged( EventArgs e )
		{
			canvas.Resize( this.Width, this.Height );
		}

		protected override void OnGotFocus( EventArgs e )
		{
			canvas.Focus();
		}

		#region IReflectorPersistance Members

		bool IReflectorPersistance.Load( System.Xml.XPath.XPathNavigator r )
		{
			switch( r.Name )
			{
			case "InterShell_Config":
				ConfigName = r.Value;
				canvas.Load( ConfigName );
				return true;
			}
			return false;
		}

		void IReflectorPersistance.Save( System.Xml.XmlWriter w )
		{
			if( ConfigName != null )
			{
				w.WriteElementString( "InterShell_Config", ConfigName );
				canvas.Save( ConfigName );
			}
				
		}

		string ConfigName;

		void IReflectorPersistance.Properties()
		{
			ConfigureInterShell cm = new ConfigureInterShell();
			cm.ShowDialog();
			if( cm.DialogResult == DialogResult.OK )
			{
				ConfigName = cm.textBoxConfigName.Text;
			}
		}

		#endregion

		#region IReflectorWindow Members

		void IReflectorWindow.Move()
		{
			canvas.Resize( this.Width, this.Height );
			//throw new Exception( "The method or operation is not implemented." );
		}

		void IReflectorWindow.Resize( int width, int height )
		{
			//throw new Exception( "The method or operation is not implemented." );
		}

		#endregion
	}
}
