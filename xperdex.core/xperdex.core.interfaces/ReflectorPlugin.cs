using System;

namespace xperdex.core.interfaces
{
	public interface IReflectorPlugin
	{
		void Preload(); // executed immediatly when the plugin is loaded.
		void FinishInit(); // on finish init (configuration loaded)
	}

}
