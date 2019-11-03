using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml.XPath;
using xperdex.core.interfaces;

namespace xperdex.core
{
	class Plugins: IReflectorPlugin, IReflectorPersistance
	{
		public override string ToString()
		{
			return "Plugins";
		}

		#region IReflectorPlugin Members

		public void Preload()
		{
			//throw new Exception( "The method or operation is not implemented." );
		}

		public void FinishInit()
		{
			//throw new Exception( "The method or operation is not implemented." );
		}

		#endregion

		#region IReflectorPersistance Members

		void IReflectorPersistance.Properties()
		{
			EditPlugins dialog = new EditPlugins();
			dialog.ShowDialog();
			//throw new Exception( "The method or operation is not implemented." );
		}

		bool IReflectorPersistance.Load( System.Xml.XPath.XPathNavigator r )
		{
			if( r.NodeType == XPathNodeType.Element )
			{
				osalot.AssemblyTracker tracker = new osalot.AssemblyTracker();
				string location = null;
				switch( r.Name )
				{
				case "Plugins":
					bool everokay = false;
					bool okay;
					for( okay = r.MoveToFirstAttribute(); okay; okay = r.MoveToNextAttribute() )
					{
						everokay = true;
						switch( r.Name )
						{
						case "Location":
							location = r.Value;
							break;
						}
					}
					if( everokay )
						r.MoveToParent();

					everokay = false;
					for( okay = r.MoveToFirstChild(); okay; okay = r.MoveToNext() )
					{
						everokay = true;
						switch( r.Name )
						{
						case "System Mask":
							tracker.allow_on_system.Add( r.Value );
							break;
						}
					}
					if( everokay )
						r.MoveToParent();
					if( tracker.allow_on_system.Count == 0 )
					{
						core_common.LoadAssembly( location, tracker );
					}
					else foreach( String s in tracker.allow_on_system )
					{
						Match m = Regex.Match( SystemInformation.ComputerName, s );
						if( m.Success )
						{
							core_common.LoadAssembly( location, tracker );
							break;							
						}
					}
					return true;
				}
				return false;
			}
			return false;
		}

		void IReflectorPersistance.Save( System.Xml.XmlWriter w )
		{
			foreach( osalot.AssemblyTracker tracker in core_common.assemblies )
			{
				// skip anything which we loaded via this program itself.
				if( tracker.default_load )
					continue;
				if( !tracker.removed )
				{
					w.WriteStartElement( "Plugins" );
					w.WriteAttributeString( "Location", core_common.GetRelativePath( tracker.assembly.Location ) );
					foreach( string system_mask in tracker.allow_on_system )
					{
						w.WriteElementString( "System Mask", system_mask );
					}
					w.WriteEndElement();
					w.WriteRaw( "\r\n" );
				}
			}
		}

		#endregion
	}
}
