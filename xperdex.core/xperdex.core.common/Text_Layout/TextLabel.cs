using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using xperdex.classes;
using xperdex.gui;

namespace xperdex.core.common.Text_Layout
{
	/// <summary>
	/// Label within a button text layout
	/// </summary>
	public class TextLabel
	{
		public enum AnchorPoint
		{
			TopLeft
				, TopRight
					, BottomLeft
						, BottomRight
		};
		public font_tracker font;
		AnchorPoint _anchor;
		public AnchorPoint anchor
		{
			set
			{

				_anchor = value;
			}
			get
			{
				return _anchor;
			}
		}

		public String Name;
		public TextLabel( string name )
		{
			Name = name;
			font = FontEditor.GetFontTracker( "Default" );
			textColor = Color.DarkKhaki;
			updated = true;
		}
		public TextLabel( string name, int x, int y, AnchorPoint anchor, String fontname, Color color )
		{
			this._orig_x = x;
			this._orig_y = y;
			this.anchor = anchor;
			this.font = FontEditor.GetFontTracker( fontname );
			this.textColor = color; // use accessor to get brush set...
			this.Name = name;
			this.updated = true;
		}
		public override string ToString()
		{
			return Name;
		}

		//	DeclareLink( struct text_placement_tag );
		public bool bHorizCenter;
		public bool bDrawRightJustified;
		float x, y; // not sure why strings are floats ... 
		internal int _orig_x, _orig_y; // might as well make origin points int?(float?) 
		public int orig_x
		{
			set
			{
				_orig_x = value / scaleX;
			}
			get
			{
				return _orig_x;
			}
		}
		public int orig_y
		{
			set
			{
				_orig_y = value / scaleY;
			}
			get
			{
				return _orig_y;
			}
		}
		public Point GetVisiblePoint()
		{
			return new Point( orig_x * scaleX, orig_y * scaleY );
		}
		public void MoveLabelRelative( Point origin, int lockx, int x, int locky, int y )
		{
			_orig_x = (x - ( lockx - origin.X ) ) / scaleX;
			_orig_y = (y - ( locky - origin.Y ) ) / scaleY;
			updated = true;
		}
		public void MoveLabelAbsolute( int x, int y )
		{
			_orig_x += x / scaleX;
			_orig_y += y / scaleY;
			updated = true;
		}
		// might as well make origin points int?(float?) 
		// also causes a retrigger of reposition....
		//int prior_width, prior_height;
		// keep the reference of the application's font
		// so that we don't have to do anything but redraw to
		// get a new font on a tag.

		//public String SampleText; // so we can see what some text would look like...
		//Font *font;
		//Font last_font; // last time we looked at (*font) this is what it was.
		Color _textColor;
		public Color textColor
		{
			set
			{
				_textColor = value;
				brush = new SolidBrush( value );
			}
			get
			{
				return _textColor;
			}
		}
		internal bool updated; // this is updated when either content or font is updated which changes origin of text draw.

		Brush brush;
		public bool greyed;
		Rectangle effective_space;
		Fraction scaleX;
		Fraction scaleY;

		internal void Render( Control c, Graphics g, bool fill_back, Color fill_color, String _text, Fraction _scaleX, Fraction _scaleY )
		{
			//this.scaleX = scaleX;
			//this.scaleY = scaleY;
			if( updated )
			{
				//SizeF size = g.MeasureString( "M", font.f );
				//scaleX = new Fraction( size.Width, 10 );
				//scaleY = new Fraction( size.Height, 10 );
				this.scaleX = new Fraction( c.Width, 250 );
				this.scaleY = new Fraction( c.Height, 250 );
				updated = false;

			}
			{
				switch( _anchor )
				{
				case AnchorPoint.TopLeft:
					x = scaleX * _orig_x;
					y = scaleY * _orig_y;
					break;
				case AnchorPoint.TopRight:
					x = c.Width - scaleX * _orig_x;
					y = scaleY * _orig_y;
					break;
				case AnchorPoint.BottomLeft:
					x = scaleX * _orig_x;
					y = c.Height - scaleY * _orig_y;
					break;
				case AnchorPoint.BottomRight:
					x = c.Width - scaleX * _orig_x;
					y = c.Height - scaleY * _orig_y;
					break;
				}
			}


			float xofs = 0;
			float yofs = 0;

			// right anchored labels are deault behavior  right justified
			// Let anchored labels are deault behavior left justified

			// this is mode normal....
			// center should set text against the offset point middle
			// Right should set text against this point as the right point
			// normal (left) justify is exactly what this is now...
			{
				SizeF size = g.MeasureString( ( _text == null ) ? Name : _text, font.font );
				size.Width = _scaleX.ToFloat() * size.Width;
				size.Height = _scaleY.ToFloat() * size.Height;
				switch( anchor )
				{
				case AnchorPoint.TopLeft:
					xofs = size.Width/2;
					yofs = size.Height/2;
					break;
				case AnchorPoint.TopRight:
					xofs = -size.Width/2;
					yofs = size.Height/2;
					break;
				case AnchorPoint.BottomLeft:
					xofs = size.Width/2;
					yofs = -size.Height/2;
					break;
				case AnchorPoint.BottomRight:
					xofs = -size.Width/2;
					yofs = -size.Height/2;
					break;
				}
				if( bHorizCenter )
				{
					x = c.Width / 2;
					xofs = 0;
					/*
					if( size.Width >= c.Width )
					{
						// string too wide... just drop it to the left...
						// ( x + (-x ) = 0 ) draw at 0
						xofs = -x;
					}
					else
					{
						xofs = ( ( c.Width - size.Width ) / 2 );
						xofs -= x; // then rebiasing later corrects this ...
					}
					 */
					effective_space = new Rectangle( (int)( x + xofs - ( size.Width / 2 ) ), (int)( y + yofs - ( size.Height / 2 ) ), (int)size.Width, (int)size.Height );
				}
				else
					effective_space = new Rectangle( (int)( x + xofs - ( size.Width / 2 ) ), (int)( y + yofs - ( size.Height / 2 ) ), (int)size.Width, (int)size.Height );
			}

			if( bHorizCenter || bDrawRightJustified )
			{
				if( fill_back )
					g.FillRectangle( new SolidBrush( fill_color ), effective_space );
#if asdfsadf
				SizeF size = g.MeasureString( ( _text == null ) ? Name : _text, font.f );
				if( bDrawRightJustified )
				{
					xofs = -size.Width;
				}
				if( bHorizCenter )
				{
					if( size.Width >= c.Width )
					{
						// string too wide... just drop it to the left...
						// ( x + (-x ) = 0 ) draw at 0
						xofs = -x;
					}
					else
					{
						xofs = ( ( c.Width - size.Width ) / 2 );
						xofs -= x; // then rebiasing later corrects this ...
					}
				}
#endif
			}
			else
			{
				//SizeF size = g.MeasureString( ( _text == null ) ? Name : _text, font.f );
				//effective_space = new Rectangle( (int)x, (int)y, (int)size.Width, (int)size.Height );
				if( fill_back )
					g.FillRectangle( new SolidBrush( fill_color ), effective_space );
			}
			//lprintf( WIDE("output %s at %ld"), layout->content, layout->y );

			if( greyed )
			{
				//, key->flags.bGreyed ? BASE_COLOR_WHITE : layout->text
			}
			else
			{
				if( brush != null )
				{
					font.DrawString( g, ( _text == null ) ? Name : _text
						, brush, new Point( (int)( x + xofs ), (int)( y + yofs ) ), _scaleX, _scaleY );
				}
			}
		}

		internal bool HasPoint( Point p )
		{
			if( p.X >= effective_space.X && p.Y >= effective_space.Y &&
				p.X < effective_space.Right && p.Y < effective_space.Bottom )
				return true;
			return false;
		}

		internal void Save( System.Xml.XmlWriter w )
		{
			w.WriteStartElement( "TextLabel" );
			w.WriteAttributeString( "X", _orig_x.ToString() );
			w.WriteAttributeString( "Y", _orig_y.ToString() );
			w.WriteAttributeString( "Anchor", anchor.ToString() );
			w.WriteAttributeString( "Name", Name );
			w.WriteAttributeString( "AlignCenter", bHorizCenter?Boolean.TrueString:Boolean.FalseString );
			w.WriteAttributeString( "AlignRight", bDrawRightJustified ? Boolean.TrueString : Boolean.FalseString );
			if( font != null )
				w.WriteAttributeString( "font", font.Name );
			w.WriteAttributeString( "color", Convert.ToString( _textColor.ToArgb() ) );
			w.WriteEndElement();
			w.WriteRaw( "\r\n" );
		}

		internal static bool Load( TextLayout layout, System.Xml.XPath.XPathNavigator r )
		{
			switch( r.Name )
			{
			case "TextLabel":
				bool okay;
				int x = 0;
				int y = 0;
				Color color = Color.Black;
				string name = "NoName";
				string fontname = "Default";
				AnchorPoint anchor = AnchorPoint.TopLeft;
				bool everokay = false;
				bool center = false;
				bool right = false;
				TextLabel label = null;
				for( okay = r.MoveToFirstAttribute(); okay; okay = r.MoveToNextAttribute() )
				{
					everokay = true;
					switch( r.Name )
					{
					case "AlignCenter":
						center = Convert.ToBoolean( r.Value );
						break;
					case "AlignRight":
						right = Convert.ToBoolean( r.Value );
						break;
					case "color":
						color = Color.FromArgb( Convert.ToInt32( r.Value ) );
						break;
					case "font":
						fontname = r.Value;
						break;
					case "Name":
						name = r.Value;
						break;
					case "X":
						x = Convert.ToInt32( r.Value );
						break;
					case "Y":
						y = Convert.ToInt32( r.Value );
						break;
					case "Anchor":
						switch( r.Value )
						{
						case "TopLeft":
							anchor = AnchorPoint.TopLeft;
							break;
						case "TopRight":
							anchor = AnchorPoint.TopRight;
							break;
						case "BottomLeft":
							anchor = AnchorPoint.BottomLeft;
							break;
						case "BottomRight":
							anchor = AnchorPoint.BottomRight;
							break;
						}
						break;
					}
				}
				label = new TextLabel( name, x, y, anchor, fontname, color );
				if( label != null )
				{
					label.bDrawRightJustified = right;
					label.bHorizCenter = center;
					layout.placements.Add( label );
				}
				if( everokay )
					r.MoveToParent();
				break;
			}
			return false;
		}
	}
}
