using xperdex.core.interfaces;
using xperdex.gui;

namespace xperdex.core
{
	internal class EditFonts: IReflectorPlugin, IReflectorPersistance
	{
		public override string ToString()
		{
			return "Edit Fonts";
		}
		#region IReflectorPlugin Members

		void IReflectorPlugin.Preload()
		{
			//throw new Exception( "The method or operation is not implemented." );
		}

		void IReflectorPlugin.FinishInit()
		{
			//throw new Exception( "The method or operation is not implemented." );
		}

		#endregion

		#region IReflectorPersistance Members

		bool IReflectorPersistance.Load( System.Xml.XPath.XPathNavigator r )
		{
			return font_tracker.Load( r );
			//throw new Exception( "The method or operation is not implemented." );
		}

		void IReflectorPersistance.Save( System.Xml.XmlWriter w )
		{
			font_tracker.Save( w );
			
			//throw new Exception( "The method or operation is not implemented." );
		}

		void IReflectorPersistance.Properties()
		{
			FontEditor fe = new FontEditor();
			fe.ShowDialog();
			fe.Dispose();
			//throw new Exception( "The method or operation is not implemented." );
		}

		#endregion
	}
}
