using System;
using System.Collections.Generic;
using System.Text;
using xperdex.core.interfaces;

namespace xperdex.timer.plugin
{
	public class TimerValue: IReflectorVariableArray
	{

		#region IReflectorVariableArray Members

		public string Name
		{
			get { return "Time Remaining"; }
		}

		public string this[int number]
		{
			get {
				if( number < Local.timers.Count )
				{
					return Local.timers[number].Remaining;
				}
				return "No Timer";
			}
		}

		#endregion
	}

	public class NextTimerValue : IReflectorVariable
	{

		#region IReflectorVariableArray Members

		public string Name
		{
			get { return "Initial Time"; }
		}

		public string Text
		{
			get
			{
				return Local.span.ToString();
			}
		}

		#endregion

	}
}
