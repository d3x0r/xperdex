using System;
using System.Windows.Forms;

namespace xperdex.core
{
	public class TypeMenuItem : ToolStripLabel
	{
		Type type;
		public Type Type
		{
			get
			{
				return type;
			}
		}
		Type _interface;
		object _o;
		public object o { get { return _o; } }
		public Type Interface { get { return _interface; } }
		public TypeMenuItem( object o )
			: base()
		{
			Text = o.ToString();
			_o = o;
		}
		public TypeMenuItem( object o, String name )
			: base()
		{
			Text = name;
			_o = o;
		}
		public TypeMenuItem( Type t )
			: base()
		{
			//i.Name = x.FullName;
			//new 
			type = t;
			_interface = t;
			Text = t.FullName;
			//Name = t.FullName;
			//this.Visible = true;
		}
		public TypeMenuItem( Type t, Type Interface )
			: base()
		{
			//i.Name = x.FullName;
			//new 
			type = t;
			_interface = Interface;
			Text = t.FullName;
			//Name = t.FullName;
			//this.Visible = true;
		}
	}
}
