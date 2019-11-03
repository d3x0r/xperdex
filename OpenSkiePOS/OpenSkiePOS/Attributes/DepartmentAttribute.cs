using System;

namespace OpenSkiePOS.Attributes
{
	public class DepartmentAttribute: Attribute
	{
		string name = "No Name";
		public string Name
		{
			get { return name; }
			set { name = value; }
		}
		public DepartmentAttribute()
		{
		}
	}
}
