using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using xperdex.core.interfaces;
using System.Windows.Forms;

namespace xperdex.core
{
	[PluginAttribute( Name="Glare Sets" )]
	class GlareSetPluginExtension: IReflectorPlugin, IReflectorPersistance
	{
		void IReflectorPlugin.Preload()
		{
		}

		void IReflectorPlugin.FinishInit()
		{
		}

		bool IReflectorPersistance.Load( System.Xml.XPath.XPathNavigator r )
		{
			return false;
		}

		void IReflectorPersistance.Save( System.Xml.XmlWriter w )
		{
		}

		void IReflectorPersistance.Properties()
		{
			GlareSetEditor gse = new GlareSetEditor();
			gse.ShowDialog();
			if( gse.DialogResult == DialogResult.OK )
			{
				gse.Apply();
			}
			gse.Dispose();

			//			throw new Exception( "The method or operation is not implemented." );
		}
	}
}
