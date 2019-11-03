using System;
using System.Collections.Generic;
using System.Text;
using OpenSkiePOS;

namespace POS.Department.Electronic
{
	public class ElectronicButton : POSButtonInterface
	{
		public override string ToString()
		{
			return "Electronic Item";
		}
		bool POSButtonInterface.Configure()
		{
			return true;
		}

		void POSButtonInterface.Save( System.Xml.XmlWriter w )
		{

		}

		void POSButtonInterface.Load( System.Xml.XPath.XPathNavigator r )
		{
		}

		bool POSButtonInterface.Click( int qty )
		{
			return false;
		}
	}
}
