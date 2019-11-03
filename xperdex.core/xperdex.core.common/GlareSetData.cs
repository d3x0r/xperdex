using System;
using System.Drawing;
using System.Windows.Forms;
using System.Xml;
using System.Xml.XPath;
using xperdex.core.interfaces;

namespace xperdex.core
{
	public class GlareSetData
	{
		//public Image mask;
		// also need image op on this.

		public enum GlareType
		{
			multishade,
			monoshade,
			noshade
		};
		public GlareType glare_type;

		public string Name;

		//public int set;
		public Bitmap mask;
		public String mask_name;
		public Rectangle mask_rect;
		public Bitmap pressed;
		public String pressed_name;
		public Rectangle pressed_rect;
		public Bitmap depressed;
		public String depressed_name;
		public Rectangle depressed_rect;
		public Bitmap glare;
		public String glare_name;
		public Rectangle glare_rect;
		public Bitmap highlight_depressed;
		public String highlight_depressed_name;
		public Bitmap highlight_pressed;
		public String highlight_pressed_name;

		public override string ToString()
		{
			return Name;
		}

		public void SetGlareMulticolor()
		{
			try
			{
				mask = null;
				if( mask_name != null && mask_name.Length > 0 )
				{
					Image i = Image.FromFile( mask_name );
					//i.PixelFormat
					mask = new Bitmap( i );
				}
				else
					mask = new Bitmap( 32, 32 );
			}
			catch
			{
				mask = new Bitmap( 32, 32 );
			}
			if( mask != null )
				mask_rect = new Rectangle( 0, 0, mask.Width, mask.Height );
			else
				mask_rect = new Rectangle();
			try
			{
				pressed = null;
				if( pressed_name != null && pressed_name.Length > 0 )
					pressed = new Bitmap( Image.FromFile( Environment.CurrentDirectory + "\\" + pressed_name ) );
				//Graphics g = Graphics.FromImage(pressed);
				//g.CompositingMode = System.Drawing.Drawing2D.CompositingMode.SourceOver;
			}
			catch
			{
				pressed = new Bitmap( 32, 32 );
			}
			if( pressed != null )
				pressed_rect = new Rectangle( 0, 0, pressed.Width, pressed.Height );
			else
				pressed_rect = new Rectangle();
			try
			{
				depressed = null;
				if( depressed_name != null && depressed_name.Length > 0 )
					depressed = new Bitmap( depressed_name );
			}
			catch
			{
				depressed = new Bitmap( 32, 32 );
			}
			if( depressed != null )
				depressed_rect = new Rectangle( 0, 0, depressed.Width, depressed.Height );
			else
				depressed_rect = new Rectangle();

			try
			{
				highlight_depressed = null;
				if( highlight_depressed_name != null && highlight_depressed_name.Length > 0 )
					highlight_depressed = new Bitmap( highlight_depressed_name );
			}
			catch
			{
				highlight_depressed = new Bitmap( 32, 32 );
			}

			try
			{
				highlight_pressed = null;
				if( highlight_pressed_name != null && highlight_pressed_name.Length > 0 )
					highlight_pressed = new Bitmap( highlight_pressed_name );
			}
			catch
			{
				highlight_pressed = new Bitmap( 32, 32 );
			}

			glare = null;
			if( glare != null )
				glare_rect = new Rectangle( 0, 0, glare.Width, glare.Height );
			//text = "whatever";
			//decal = new Bitmap(decal_name =path+"redrock.png");
		}


		/// <summary>
		///  this One is invoked for the iRefelectorPlugin instance (which is shared with persitance)
		///   but this gives of application configuration methods.
		/// </summary>
		public GlareSetData()
		{
			string path = "Images/";
			mask_name = path + "colorLayer.png";
			pressed_name = path + "pressedlens.png";
			depressed_name = path + "defaultLens.png";

			SetGlareMulticolor();
			// this one is preloaded?
			this.Name = "Glare Set";
		}
		public GlareSetData( string name )
		{
			string path = "Images/";
			mask_name = path + "colorLayer.png";
			pressed_name = path + "pressedlens.png";
			depressed_name = path + "defaultLens.png";
			SetGlareMulticolor();
			this.Name = name;

		}

		public void ColorMask( Bitmap src, Graphics d, Bitmap dest, GlareSetAttributes imageAtt, bool highlight )
		{
			// Create an ImageAttributes object and set its color matrix.
			d.CompositingMode = System.Drawing.Drawing2D.CompositingMode.SourceCopy;
			d.Clear( Color.Transparent );
			//d.FillRectangle(Brushes.Transparent, 0, 0, dest.Width, dest.Height);
			d.CompositingMode = System.Drawing.Drawing2D.CompositingMode.SourceOver;
			switch( glare_type )
			{
			case GlareType.noshade:
				d.DrawImage( src
					 , new Rectangle( 0, 0, dest.Width, dest.Height )  // destination rectangle
					 , 0.0f                          // source rectangle x 
					 , 0.0f                          // source rectangle y
					 , src.Width                        // source rectangle width
					 , src.Height                       // source rectangle height
					 , GraphicsUnit.Pixel
					 ); // no attribute matrix.
				break;
			case GlareType.monoshade:
				d.DrawImage( src
					 , new Rectangle( 0, 0, dest.Width, dest.Height )  // destination rectangle
					 , 0.0f                          // source rectangle x 
					 , 0.0f                          // source rectangle y
					 , src.Width                        // source rectangle width
					 , src.Height                       // source rectangle height
					 , GraphicsUnit.Pixel
					 , imageAtt.imageAttMono
					 );
				break;
			case GlareType.multishade:
				d.DrawImage( src
					 , new Rectangle( 0, 0, dest.Width, dest.Height )  // destination rectangle
					 , 0.0f                          // source rectangle x 
					 , 0.0f                          // source rectangle y
					 , src.Width                        // source rectangle width
					 , src.Height                       // source rectangle height
					 , GraphicsUnit.Pixel
					 , highlight ? imageAtt.imageAttHighlight : imageAtt.imageAtt
					 );
				break;
			}

		}

		internal static bool Load( XPathNavigator r )
		{
			if( r.NodeType == XPathNodeType.Element )
			{
				switch( r.Name )
				{
				case "glareset":
					bool everokay = false;
					bool okay;
					GlareSetData gsd = null;
					for( okay = r.MoveToFirstAttribute(); okay; okay = r.MoveToNextAttribute() )
					{
						switch( r.Name )
						{
						case "name":
							gsd = core_common.GetGlareSetData( r.Value );
							break;
						case "mask":
							if( gsd != null ) gsd.mask_name = r.Value;
							break;
						case "pressed":
							if( gsd != null ) gsd.pressed_name = r.Value;
							break;
						case "depressed":
							if( gsd != null ) gsd.depressed_name = r.Value;
							break;
						case "highlight_pressed":
							if( gsd != null ) gsd.highlight_pressed_name = r.Value;
							break;
						case "highlight_depressed":
							if( gsd != null ) gsd.highlight_depressed_name = r.Value;
							break;
						case "glare":
							if( gsd != null ) gsd.glare_name = r.Value;
							break;
						case "shade":
							switch( r.Value )
							{
							case "multi":
								gsd.glare_type = GlareType.multishade;
								break;
							case "mono":
								gsd.glare_type = GlareType.monoshade;
								break;
							case "none":
								gsd.glare_type = GlareType.noshade;
								break;
							}
							break;
						}
						everokay = true;
					}
					gsd.SetGlareMulticolor();

					if( everokay )
						r.MoveToParent();
					return true;
				}
			}
			return false;
		}

		internal void Save( XmlWriter w )
		{
			//throw new Exception( "The method or operation is not implemented." );
			w.WriteStartElement( "glareset" );
			w.WriteAttributeString( "name", Name );
			w.WriteAttributeString( "mask", mask_name );
			w.WriteAttributeString( "pressed", pressed_name );
			w.WriteAttributeString( "depressed", depressed_name );
			if( highlight_pressed_name != null )
				w.WriteAttributeString( "highlight_pressed", highlight_pressed_name );
			if( highlight_depressed_name != null )
				w.WriteAttributeString( "highlight_depressed", highlight_depressed_name );
			w.WriteAttributeString( "glare", glare_name );
			switch( this.glare_type )
			{
			case GlareType.multishade:
				w.WriteAttributeString( "shade", "multi" );
				break;
			case GlareType.monoshade:
				w.WriteAttributeString( "shade", "mono" );
				break;
			case GlareType.noshade:	
				w.WriteAttributeString( "shade", "none" );
				break;
			}
			w.WriteEndElement();
			w.WriteRaw( "\r\n" );
		}

	}
}
