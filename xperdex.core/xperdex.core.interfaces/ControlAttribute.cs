using System;
using System.Collections.Generic;
using System.Text;

namespace xperdex.core.interfaces
{
	public class ControlAttribute : Attribute
	{
		string DisplayName = "Control";
		public string Name
		{
			get { return DisplayName; }
			set { DisplayName = value; }
		}
		public ControlAttribute()
		{
		}
	}
	public class SecurityAttribute : Attribute
	{
		string DisplayName = "Security";
		public string Name
		{
			get { return DisplayName; }
			set { DisplayName = value; }
		}
		public SecurityAttribute()
		{
		}
	}

}
