using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using xperdex.core.interfaces;

namespace ItemManager
{
	public class XperdexPlugin : IReflectorPlugin
	{
		public XperdexPlugin()
		{
			ItemManagmentState.Init();
		}

		void IReflectorPlugin.Preload()
		{
			
		}

		void IReflectorPlugin.FinishInit()
		{
			
		}
	}
}
