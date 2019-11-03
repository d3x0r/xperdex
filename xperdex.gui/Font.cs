using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Xml;
using System.Xml.XPath;
using xperdex.classes;
using System.Collections.Generic;
using System.Windows.Forms;

namespace xperdex.gui
{

	public class font_tracker
	{
		public Font f;
		public Font font{ get { return f; }	}
		public string Name;
		public List<Control> Controls = new List<Control>();

		public string family = "Lucida Console";
		public float size = 12.0f;
		public GraphicsUnit unit = GraphicsUnit.Pixel;
		public FontStyle style = FontStyle.Regular;
		public font_tracker ft = null;

		public delegate void FontChanged();
		public event FontChanged OnFontChange;


		public static implicit operator Font( font_tracker f )
		{
			if( f != null )
				return f.f;
			return null;
		}
		// this is used when a font is created
		// please use FontEditor.GetFontTracker( "name" ) instead.
		internal font_tracker( string s )
		{
			f = new Font( "arial", 25, GraphicsUnit.Pixel );
			//f = new Font();
			Name = s;
		}
		public font_tracker( Font font )
		{
			f = font;// new Font( font.FontFamily, font.Size, font.Unit );
			Name = "Default["+font.FontFamily+"]";
		}
		public font_tracker( string s, string font_family, int size )
		{
			f = new Font( font_family, size, GraphicsUnit.Pixel );
			Name = s;
		}
		public static bool Load( XPathNavigator r )
		{
			if( r.NodeType == XPathNodeType.Element )
			{
				switch( r.Name )
				{
				case "Font":
					//string family = "Lucida Console";
					//float size = 12.0f;
					//GraphicsUnit unit = GraphicsUnit.Pixel;
					//FontStyle style = FontStyle.Regular;
					font_tracker ft = null;
					bool everokay = false;
					bool okay;
					for( okay = r.MoveToFirstAttribute(); okay; okay = r.MoveToNextAttribute() )
					{
						everokay = true;
						switch( r.Name )
						{
						case "name":
							ft = FontEditor.GetFontTracker( r.Value );
							break;
						case "face":
							ft.family = r.Value;
							break;
						case "size":
							ft.size = Convert.ToSingle( r.Value );

							break;
						case "style":
							switch( r.Value )
							{
							case "Regular":
								ft.style = FontStyle.Regular;
								break;
							case "Bold":
								ft.style = FontStyle.Bold;
								break;
							case "Italic":
								ft.style = FontStyle.Italic;
								break;
							case "Strikeout":
								ft.style = FontStyle.Strikeout;
								break;
							}
							break;
						case "units":
							switch( r.Value )
							{
							case "Point":
								ft.unit = GraphicsUnit.Point;
								break;
							case "Display":
								ft.unit = GraphicsUnit.Display;
								break;
							case "Pixel":
								ft.unit = GraphicsUnit.Pixel;
								break;
							default:
								throw new Exception( "Unsupported 'units' saved in font.." );
								//break;
							}
							break;
						}
						if( ft == null )
							break;
						
					}
					ft.f = new Font( ft.family, ft.size, ft.style, ft.unit );
					if( everokay )
						r.MoveToParent();
					return true;
				}

			}
			return false;
		}

		void DoSave( XmlWriter w )
		{
			w.WriteStartElement( "Font" );
			w.WriteAttributeString( "name", this.Name );
			w.WriteAttributeString( "face", f.Name );
			w.WriteAttributeString( "size", Convert.ToString( f.Size ) );
			w.WriteAttributeString( "style", Convert.ToString( f.Style ) );
			w.WriteAttributeString( "units", f.Unit.ToString() );
			w.WriteEndElement();
			w.WriteRaw( "\r\n" );
		}
		public static void Save( XmlWriter w )
		{
			foreach( font_tracker font in FontEditor.fonts )
				font.DoSave( w );
		}
		public override string ToString()
		{
			return Name;
		}

		public SizeF MeasureString( Graphics g, string s )
		{
			SizeF szf = g.MeasureString( s, f );
			return szf;
		}

		public SizeF MeasureString( Graphics g, string s, Fraction scale_x, Fraction scale_y, Font NewFont )
		{
			GraphicsContainer gc = g.BeginContainer();
			g.ScaleTransform( scale_x.ToFloat(), scale_y.ToFloat() );
			SizeF szf = g.MeasureString( s, NewFont );
			g.EndContainer( gc );
			return szf;
		}
		public SizeF MeasureString( Graphics g, string s, Fraction scale_x, Fraction scale_y )
		{
			//GraphicsContainer gc = g.BeginContainer();
			//g.ScaleTransform( scale_x.ToFloat(), scale_y.ToFloat() );
			SizeF szf = g.MeasureString( s, f );
			szf.Width *= scale_x.ToFloat();
			szf.Height *= scale_y.ToFloat();
			//g.EndContainer( gc );
			return szf;
		}

		public void DrawString( Graphics g, string s, Brush brush, Point p, Fraction scale_x, Fraction scale_y )
		{
			GraphicsContainer gc = g.BeginContainer();
			try
			{
				g.TranslateTransform( p.X - ( scale_x * p.X ), p.Y - ( scale_y * p.Y ) );
				g.ScaleTransform( scale_x.ToFloat(), scale_y.ToFloat() );
				//SizeF size = MeasureString( g, s, scale_x, scale_y );
				SizeF size = g.MeasureString( s, f );
			
				//g.TranslateTransform( p.X , p.Y );
				g.DrawString( s, f, brush, p.X - size.Width/2, p.Y - size.Height/2 );
			}
			catch( Exception e )
			{
				Log.log( e.Message );
			}
			g.EndContainer( gc );
		}
		public void OldDrawString( Graphics g, string s, Brush brush, Point p )
		{
			DrawString( g, s, brush, p, new Fraction(1,1), new Fraction(1,1) );
		}
		internal void InvokeChanged()
		{
			if( OnFontChange != null )
				OnFontChange();
		}
	}
}
