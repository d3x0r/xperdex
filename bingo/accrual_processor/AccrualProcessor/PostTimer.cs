using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ECube.AccrualProcessor
{
	public class PostTimer
	{
		internal Timer timer;
		internal bool updating;
		internal bool posting;

		public PostTimer() {
			timer = new Timer();
			timer.Tick += Timer_Tick;
			timer.Interval = Local.postTimerInterval;
			timer.Start();
		}

		private void Timer_Tick( object sender, EventArgs e )
		{
			updating = true;
			xperdex.core.variables.Variables.UpdateVariable( "Post Timer Status" );
			Local.DoUpdateButton();
			updating = false;
			//posting = true;
			xperdex.core.variables.Variables.UpdateVariable( "Post Timer Status" );
			//Local.PostAccruals( false );
			//posting = false;
			//xperdex.core.variables.Variables.UpdateVariable( "Post Timer Status" );
		}
	}
}
