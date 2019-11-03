using System;
using System.Collections.Generic;
using System.Text;

namespace xperdex.timer.plugin
{
	internal static class Local
	{
		static internal List<Timer> timers = new List<Timer>();

		static internal int SelectedTimer;
		static internal TimeSpan span;
	}
}
