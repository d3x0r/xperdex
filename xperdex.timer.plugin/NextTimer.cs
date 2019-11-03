using System;
using System.Collections.Generic;
using System.Text;
using xperdex.core.interfaces;

namespace xperdex.timer.plugin
{
	class NextTimer : IReflectorButton
	{
		#region IReflectorButton Members

		bool IReflectorButton.OnClick()
		{
			if( Local.SelectedTimer < Local.timers.Count )
			{
				Local.SelectedTimer++;
				xperdex.core.variables.Variables.UpdateVariable( "Selected Timer" );
			}
			return true;
		}

		#endregion
	}
	class PriorTimer : IReflectorButton
	{
		#region IReflectorButton Members

		bool IReflectorButton.OnClick()
		{
			if( Local.SelectedTimer > 0 )
			{
				Local.SelectedTimer--;
				xperdex.core.variables.Variables.UpdateVariable( "Selected Timer" );
			}
			return true;
		}

		#endregion
	}
}
