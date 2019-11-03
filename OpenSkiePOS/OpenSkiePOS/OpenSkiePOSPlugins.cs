using xperdex.core;
using xperdex.core.interfaces;

namespace OpenSkiePOS
{
	[PluginAttribute( Name="POS Plugins" )]
	public class OpenSkiePOSPlugins: IReflectorPlugin, IReflectorPersistance
	{
		public override string ToString()
		{
			return "POS Plugins";
		}
		void IReflectorPlugin.Preload()
		{
			//throw new NotImplementedException();
		}

		void IReflectorPlugin.FinishInit()
		{
			//throw new NotImplementedException();
		}

		bool IReflectorPersistance.Load( System.Xml.XPath.XPathNavigator r )
		{
			if( r.Name == "POS.plugin" )
			{
				xperdex.core.osalot.AssemblyTracker tracker;
				POS.Local.LoadAssembly( r.Value, out tracker );
				return true;
			}
			return false;
		}

		void IReflectorPersistance.Save( System.Xml.XmlWriter w )
		{
			foreach( osalot.AssemblyTracker tracker in POS.Local.assemblies )
			{
				w.WriteElementString( "POS.plugin", tracker.assembly.Location );
				w.WriteRaw( "\r\n" );
			}
		}

		void IReflectorPersistance.Properties()
		{
			ConfigurePOSPlugins dialog = new ConfigurePOSPlugins();
			dialog.ShowDialog();
			dialog.Dispose();
		}
	}
}
