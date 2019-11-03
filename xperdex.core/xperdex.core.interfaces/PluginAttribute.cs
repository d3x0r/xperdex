using System;
using System.Collections.Generic;
using System.Text;

namespace xperdex.core.interfaces
{
	public class PluginAttribute : Attribute
	{
		string DisplayName = null;
		public string Name
		{
			get { return DisplayName; }
			set { DisplayName = value; }
		}
	}

}
