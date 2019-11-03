using System;
using System.Collections.Generic;
using System.Text;
using xperdex.core.interfaces;

namespace xperdex.timer.plugin
{
	class DeleteTimer : IReflectorButton
	{
		#region IReflectorButton Members

		public bool OnClick()
		{
			if( Local.SelectedTimer < Local.timers.Count )
			{
				Local.timers.RemoveAt( Local.SelectedTimer );
				if( Local.SelectedTimer > 0 )
					Local.SelectedTimer--;
			}
			xperdex.core.variables.Variables.UpdateVariable( "Time Remaining" );
			return true;
		}

		#endregion
	}
}
