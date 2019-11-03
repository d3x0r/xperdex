using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace xperdex.core.common.Text_Layout
{
	public class TextLabelContent
	{
		//TextLabel for_label; // this content applies to this label... 
		
		public String text;
		//bool override_color;
		//Color color;

		public TextLabelContent()
		{
			//override_color = false;
			text = "No Text";
		}
		public static implicit operator TextLabelContent( string s )
		{
			TextLabelContent tlc = new TextLabelContent();
			tlc.text = s;
			//tlc.override_color = false;
			return tlc;
		}
		public static implicit operator string( TextLabelContent s )
		{
			return s.text;
		}

	}
}
