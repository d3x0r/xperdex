using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using xperdex.core.interfaces;

namespace POS.Department.Electronic
{
	class ElectronicXperdexPlugin : IReflectorDirectionShow
	{

		void IReflectorDirectionShow.PageChanged()
		{
			Local.ItemIndex = 0;
		}

		void IReflectorDirectionShow.Shown()
		{
			// unused, becasue it's not a control; should probably re-architect the PageChanged event.
		}

		void IReflectorDirectionShow.Hidden()
		{
			// unused, becasue it's not a control; should probably re-architect the PageChanged event.
			
		}
	}
}
