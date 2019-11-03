using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Xml;

namespace xperdex.core.common.Text_Layout
{

	public class TextLayout
	{
		//GlareSet gs;
		public List<TextLabel> placements;
		string Name;
		public override string ToString()
		{
			return Name;
		}

		public TextLayout( string Name )
		{
			this.Name = Name;
			placements = new List<TextLabel>();
		}

	
		public TextLabel this[String name]
		{
			get
			{
				foreach( TextLabel Label in placements )
					if( string.Compare( Label.Name, name, 0 ) == 0 )
						return Label;
				return null;
			}
		}

		public void AddLabel( string name, int x, int y, TextLabel.AnchorPoint p )
		{
			TextLabel tp = new TextLabel( name );
			tp.orig_x = x;
			tp.orig_y = y;
			tp.anchor = p;
			tp.updated = true;
			placements.Add( tp );
		}

		string testname;

		bool isname( object o )
		{
			TextLabel tl = o as TextLabel;
			if( tl != null )
				return String.Compare( tl.Name, testname, true ) == 0;
			return false;
		}


		public bool AddLayout( string name )
		{
			testname = name;
			if( placements.FindIndex( isname ) < 0 )
			{
				placements.Add( new TextLabel( name, 10, 10, TextLabel.AnchorPoint.TopLeft, "Default", Color.White ) );
				return true;
			}
			return false;
		}

		
		void DoSave( System.Xml.XmlWriter w )
		{
			w.WriteStartElement( "TextLayout" );
			w.WriteAttributeString( "Name", Name );
			w.WriteRaw( "\r\n" );
			foreach( TextLabel label in placements )
				label.Save( w );
			w.WriteEndElement();
			w.WriteRaw( "\r\n" );
		}
		public static void Save( XmlWriter w )
		{
			foreach( TextLayout layout in core_common.layouts )
				layout.DoSave( w );
		}

		public static bool Load( System.Xml.XPath.XPathNavigator r )
		{
			switch( r.Name )
			{
			case "TextLayout":
				bool okay;
				bool everokay = false;
				TextLayout loading = null;
				for( okay = r.MoveToFirstAttribute();
					okay;
					okay = r.MoveToNextAttribute() )
				{
					everokay = true;
					switch( r.Name )
					{
					case "Name":
						loading = core_common.GetLayout( r.Value );
						break;
					}
				}
				if( everokay )
					r.MoveToParent();
				if( loading != null )
				{
					bool okay2;
					bool everokay2 = false;
					for( okay2 = r.MoveToFirstChild(); okay2; okay2 = r.MoveToNext() )
					{
						everokay2 = true;
						TextLabel.Load( loading, r );
					}
					if( everokay2 )
						r.MoveToParent();
				}
				return true;
			}
			return false;
		}
	}
}
