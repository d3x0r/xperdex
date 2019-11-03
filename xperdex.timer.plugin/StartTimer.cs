using System;
using System.Collections.Generic;
using System.Text;
using xperdex.core.interfaces;

namespace xperdex.timer.plugin
{
	class StartTimer: IReflectorButton
	{
		#region IReflectorButton Members

		public bool OnClick()
		{
			// get the current timer's value, and add the timer to the list of timers...
			Local.timers.Add( new Timer( Local.span ) );
			Local.span = TimeSpan.Zero;
			xperdex.core.variables.Variables.UpdateVariable( "Initial Time" );
			return true;
		}

		#endregion
	}
}
