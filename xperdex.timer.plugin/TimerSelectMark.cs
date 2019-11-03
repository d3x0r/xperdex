using System;
using System.Collections.Generic;
using System.Text;
using xperdex.core.interfaces;

namespace xperdex.timer.plugin
{
	class TimerSelectMark: IReflectorVariableArray
	{
		#region IReflectorVariable Members

		public string Name
		{
			get { return "Selected Timer"; }
		}

		public string this[int index]
		{
			get {
				if( index == Local.SelectedTimer )
				{
					return "<<<";
				}
				return "";
			}
		}

		#endregion
	}
}
