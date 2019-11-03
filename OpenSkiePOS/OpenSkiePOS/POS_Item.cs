using System;
using System.Collections.Generic;
using System.Text;
using xperdex.core;
using xperdex.classes;
using xperdex.classes.Text_Layout;

namespace OpenSkiePOS
{
	class POS_Item : ButtonWithLabelAreas
    {
		public POS_Item(): base( "POS Sale Button" ) 
		{
			layout["Quantity"] = "0";
			layout["Item Name 1"] = "Some";
			layout["Item Name 2"] = "Name";
			layout["Price"] = "1.00";
		}
    }
}
