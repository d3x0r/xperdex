using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenSkie.Scheduler.CurrentTables
{
	public class CurrentObjectAttribute  : Attribute
	{
		string[] method = null;
		/// <summary>
		/// Specify multi-part filter condition
		/// </summary>
		public string[] FilterParts
		{
			get { return method; }
			set { method = value; }
		}
		string initial_fill = null;
		/// <summary>
		/// This specifies a method (public void ()) that is called when there is no data in the table; allows building defaults.
		/// </summary>
		public string DefaultFill
		{
			get { return initial_fill; }
			set { initial_fill = value; }
		}
		string fill_condition = null;
		/// <summary>
		/// define fill condition uhmm....
		/// </summary>
		public string FillCondition
		{
			get { return fill_condition; }
			set { fill_condition = value; }
		}
		public CurrentObjectAttribute()
		{
		}

	}
}
