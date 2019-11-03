using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using xperdex.classes;

namespace xperdex.internet_explorer
{
	public class Explorer : WebBrowser, IReflectorPersistance
	{
		public Explorer()
		{
			this.Navigate( "www.google.com" );
		}

		#region IReflectorPersistance Members

		bool IReflectorPersistance.Load( System.Xml.XPath.XPathNavigator r )
		{
			return false;
			//throw new NotImplementedException();
		}

		void IReflectorPersistance.Save( System.Xml.XmlWriter w )
		{
			//throw new NotImplementedException();
		}

		void IReflectorPersistance.Properties()
		{
			//throw new NotImplementedException();

		}

		#endregion
	}
}
