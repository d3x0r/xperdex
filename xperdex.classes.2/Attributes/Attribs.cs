using System;
using System.Collections.Generic;
using System.Text;

namespace xperdex.classes.Attributes
{
	[AttributeUsage(AttributeTargets.Class )]

	class Preload: Attribute
	{
		public int priority = 1000;
	}
}
