using System;
using System.Collections.Generic;
using System.Text;

namespace xperd3x.breadboard
{
	public class BoardAttributes
	{
		public class RequiredParent : Attribute
		{
			Type Parent;
			public RequiredParent( Type parent_type )
			{
				Parent = parent_type;
			}
		}
	}
}
