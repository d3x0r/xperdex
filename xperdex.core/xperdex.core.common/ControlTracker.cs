using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using xperdex.core.interfaces;

namespace xperdex.core.common
{
	public class ControlTracker
	{
		public Control c; // the actual control
		public Type i; // interface
		public Type Type; // the actual type (not the low level control type)
		object _object;
		public bool real { get { return ( c == _object ); } }
		public object o { set { _object = value; } get { return _object; } }
		//PTRSZVAL psvInstance;
		public Rectangle grid_rect; // in grid coordinates
		List<string> allow_on;
		List<string> disallow_on;
		public bool selected;

		public ControlTracker( Control control_in, Rectangle r_in
			, Type interface_in
			, Type object_type
			, Object _object
			, bool real )
		{
			allow_on = new List<string>();
			disallow_on = new List<string>();
			c = control_in;
			grid_rect = r_in;
			i = interface_in;
			Type = object_type;
			o = _object;
			{
				IReflectorCreate ICreate = o as IReflectorCreate;
				if( ICreate != null )
					ICreate.OnCreate( c );
			}
		}
	}
}
