using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

namespace xperdex.core.interfaces
{
	public interface IReflectorPluginModule
	{
		bool AssemblyUseful( Assembly assembly );
	}
}
