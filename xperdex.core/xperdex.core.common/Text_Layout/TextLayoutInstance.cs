using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using xperdex.classes;

namespace xperdex.core.common.Text_Layout
{
	public class TextLayoutInstance
	{
		Control control;
		TextLayout Layout;
		List<TextLabelContent> content;
		public static TextLayoutInstance AttachInstance( Control c, String Layout )
		{
			TextLayoutInstance tli = new TextLayoutInstance( c, core_common.GetLayout( Layout ) );
			return tli;
		}

		public TextLayoutInstance( Control c, TextLayout layout )
		{
			control = c;
			Layout = layout;
			content = new List<TextLabelContent>();
		}

		public string this[string name]
		{
			set
			{
				int n = 0;
				foreach( TextLabel label in Layout.placements )
				{
					if( content.Count == n )
						content.Add( new TextLabelContent() );
					if( String.Compare( label.Name, name, 0 ) == 0 )
					{
						content[n].text = value;
						break;
					}
					n++;
				}
				if( n == Layout.placements.Count )
				{
					Layout.placements.Add( new TextLabel( name ) );
					content.Add( value );
				}
			}
		}

		public void Resize( Control c )
		{
			foreach( TextLabel placement in Layout.placements )
			{
				placement.updated = true;
			}
		}
		public void Render( Control c, Graphics g, Fraction scaleX, Fraction scaleY )
		{
			int n = 0;
			foreach( TextLabel placement in Layout.placements )
			{
				placement.Render( c, g, false, Color.Transparent, n<content.Count?content[n++].text:(placement.Name), scaleX, scaleY );
			}

		}

#if asdasdf
		public Color this[string name]
		{
			set
			{
				int n = 0;
				foreach( TextLabel label in Layout.placements )
				{
					if( content.Count == n )
						content.Add( new TextLabelContent() );
					if( String.Compare( label.Name, name, 0 ) == 0 )
					{
						if( value != Color.Transparent )
						{
							content[n].override_color = true;
							content[n].color = value;
						}
						else
						{
							content[n].override_color = false;
							content[n].color = value;
						}
						break;
					}
					n++;
				}
			}
		}
#endif
	}
}
