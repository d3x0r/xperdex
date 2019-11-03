using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenSkieScheduler3.Controls.Lists;
using OpenSkieScheduler3.Controls;

namespace OpenSkie.Scheduler.Controls.Controls.Lists
{
	public class SessionTypeList: MyListBox
	{
		public SessionTypeList()
            : base( ControlList.schedule.session_types )
		{
			SetCurrent += new SetCurrentMethod( ControlList.data.SetCurrentSessionType );
		}
	}
}
