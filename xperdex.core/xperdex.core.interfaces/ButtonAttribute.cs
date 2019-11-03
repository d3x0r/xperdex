using System;
using System.Collections.Generic;
using System.Text;

namespace xperdex.core.interfaces
{
	public class ButtonAttribute : Attribute
	{
		string DisplayName = null;
		public string Name
		{
			get { return DisplayName; }
			set { DisplayName = value; }
		}
		bool _hidden;
		public bool hidden
		{
			get { return _hidden; }
			set { _hidden = hidden; }
		}
		public ButtonAttribute()
		{
		}
	}
}
