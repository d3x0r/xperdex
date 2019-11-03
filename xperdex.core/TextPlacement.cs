using xperdex.core.common.Text_Layout;
using xperdex.core.interfaces;

namespace xperdex.core
{
	/// <summary>
	/// Text layout plugin level interface for 'More Properties' menu.
	/// Only one instance of this class will be created, it is almost 'static' but not.
	/// </summary>
	public class TextLayoutEditor : IReflectorPlugin, IReflectorPersistance
	{
		static TextLayoutEditor()
		{
		}
		public override string ToString()
		{
			return "Text Layouts";
		}
		#region IReflectorPersistance Members

		bool IReflectorPersistance.Load( System.Xml.XPath.XPathNavigator r )
		{
			return TextLayout.Load( r );
		}

		void IReflectorPersistance.Save( System.Xml.XmlWriter w )
		{
			TextLayout.Save( w );
		}

		void IReflectorPersistance.Properties()
		{
			TextPlacementEditor tpe = new TextPlacementEditor();
			tpe.ShowDialog();
			tpe.Dispose();
		}

		#endregion

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
	}
}
