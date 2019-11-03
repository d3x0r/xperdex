using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Xml;
using System.Xml.XPath;

namespace xperdex.core
{
	public class GlareSetAttributes
	{

		public String Name; // // PSI_Control Name if not NULL, may be shared for multiple instances of a PSI button
		public override string ToString()
		{
			return Name;
		}

		public ImageAttributes imageAtt;
		public ImageAttributes imageAttMono;
		public ImageAttributes imageAttHighlight;

		ColorMatrix mask_colorMatrix; // used for transforming the mask layer
		ColorMatrix mask_monocolorMatrix; // used for transforming the mask layer
		ColorMatrix mask_colorMatrixHighlight; // used for transforming the mask layer

		Color primary;
		Color secondary;
		Color highlight_primary;
		Color highlight_secondary;
		Color tertiary;
		Color highlight_tertiary;

		Color text;
		public Brush text_output;

		public Color TextColor
		{
			set { text = value; text_output = new SolidBrush( value ); }
			get { return text; }
		}

		//text = "whatever";
		//decal = new Bitmap(decal_name =path+"redrock.png");

		void Init()
		{
			imageAtt = new ImageAttributes();
			imageAttMono = new ImageAttributes();
			imageAttHighlight = new ImageAttributes();

			mask_colorMatrix = new ColorMatrix();
			mask_colorMatrix[0, 0] = 1;
			mask_colorMatrix[1, 1] = 1;
			mask_colorMatrix[2, 2] = 1;
			mask_colorMatrix[3, 3] = 1;
			mask_colorMatrix[4, 4] = 1;

			mask_monocolorMatrix = new ColorMatrix();
			mask_monocolorMatrix[0, 0] = 1;
			mask_monocolorMatrix[1, 1] = 1;
			mask_monocolorMatrix[2, 2] = 1;
			mask_monocolorMatrix[3, 3] = 1;
			mask_monocolorMatrix[4, 4] = 1;

			text = Color.FromKnownColor( KnownColor.ControlText );
			text_output = new SolidBrush( text );

			mask_colorMatrixHighlight = new ColorMatrix();
			mask_colorMatrixHighlight[0, 0] = 1;
			mask_colorMatrixHighlight[1, 1] = 1;
			mask_colorMatrixHighlight[2, 2] = 1;
			mask_colorMatrixHighlight[3, 3] = 1;
			mask_colorMatrixHighlight[4, 4] = 1;

			imageAtt.SetColorMatrix(
				mask_colorMatrix,
				ColorMatrixFlag.Default,
				ColorAdjustType.Bitmap );

			imageAttMono.SetColorMatrix(
				mask_monocolorMatrix,
				ColorMatrixFlag.Default,
				ColorAdjustType.Bitmap );

			imageAttHighlight.SetColorMatrix(
				mask_colorMatrixHighlight,
				ColorMatrixFlag.Default,
				ColorAdjustType.Bitmap );
		}

		public GlareSetAttributes( String name )
		{
			Name = name;
			Init();
		}
		public GlareSetAttributes( GlareSetAttributes original )
		{
			this.Primary = original.Primary;
			this.Secondary = original.Secondary;
			this.Tertiary = original.Tertiary;
			this.TextColor = original.TextColor;
			this.PrimaryHighlight = original.PrimaryHighlight;
			this.secondary = original.SecondaryHighlight;
		}
		public GlareSetAttributes()
		{
			Name = null;
			Init();
		}

		public Color Primary
		{
			set { SetColor( value ); }
			get { return primary; }
		}
		public Color Secondary
		{
			set { SetColor2( value ); }
			get { return secondary; }
		}
		public Color Tertiary
		{
			set { SetColor3( value ); }
			get { return tertiary; }
		}
		public Color PrimaryHighlight
		{
			get { return highlight_primary; }
			set
			{
				highlight_primary = value;
				mask_colorMatrixHighlight[2, 0] = ( highlight_primary.R + 1 ) / 256F;
				mask_colorMatrixHighlight[2, 1] = ( highlight_primary.G + 1 ) / 256F;
				mask_colorMatrixHighlight[2, 2] = ( highlight_primary.B + 1 ) / 256F;
				mask_colorMatrixHighlight[2, 3] = ( highlight_primary.A + 1 ) / 256F;
				mask_colorMatrixHighlight[3, 3] = mask_colorMatrixHighlight[2, 3] * mask_colorMatrixHighlight[1, 3];
				imageAttHighlight.SetColorMatrix(
					mask_colorMatrixHighlight,
					ColorMatrixFlag.Default,
					ColorAdjustType.Bitmap );

			}

		}
		public Color SecondaryHighlight
		{
			get { return highlight_secondary; }
			set
			{
				highlight_secondary = value;
				mask_colorMatrixHighlight[1, 0] = ( highlight_secondary.R + 1 ) / 256F;
				mask_colorMatrixHighlight[1, 1] = ( highlight_secondary.G + 1 ) / 256F;
				mask_colorMatrixHighlight[1, 2] = ( highlight_secondary.B + 1 ) / 256F;
				mask_colorMatrixHighlight[1, 3] = ( highlight_secondary.A + 1 ) / 256F;
				mask_colorMatrixHighlight[3, 3] = mask_colorMatrixHighlight[2, 3] * mask_colorMatrixHighlight[1, 3];
				imageAttHighlight.SetColorMatrix(
					mask_colorMatrixHighlight,
					ColorMatrixFlag.Default,
					ColorAdjustType.Bitmap );

			}
		}
		public Color TertiaryHighlight
		{
			get { return highlight_tertiary; }
			set
			{
				highlight_tertiary = value;
				mask_colorMatrixHighlight[0, 0] = ( highlight_tertiary.R + 1 ) / 256F;
				mask_colorMatrixHighlight[0, 1] = ( highlight_tertiary.G + 1 ) / 256F;
				mask_colorMatrixHighlight[0, 2] = ( highlight_tertiary.B + 1 ) / 256F;
				mask_colorMatrixHighlight[0, 3] = ( highlight_tertiary.A + 1 ) / 256F;
				mask_colorMatrixHighlight[3, 3] = mask_colorMatrixHighlight[2, 3] * mask_colorMatrixHighlight[1, 3];
				imageAttHighlight.SetColorMatrix(
					mask_colorMatrixHighlight,
					ColorMatrixFlag.Default,
					ColorAdjustType.Bitmap );

			}
		}

		void SetMonoShader()
		{
			//mask_monocolorMatrix[2, 0] = (primary.R + 1) / 256F;
			//mask_monocolorMatrix[2, 1] = ( primary.G + 1 ) / 256F;
			mask_monocolorMatrix[2, 2] = ( primary.B + 1 ) / 256F;
			//mask_monocolorMatrix[2, 3] = ( primary.A + 1 ) / 256F;

			//mask_monocolorMatrix[1, 0] = ( primary.R + 1 ) / 256F;
			mask_monocolorMatrix[1, 1] = ( primary.G + 1 ) / 256F;
			//mask_monocolorMatrix[1, 2] = ( primary.B + 1 ) / 256F;
			//mask_monocolorMatrix[1, 3] = ( primary.A + 1 ) / 256F;

			mask_monocolorMatrix[0, 0] = ( primary.R + 1 ) / 256F;
			//mask_monocolorMatrix[0, 1] = ( primary.G + 1 ) / 256F;
			//mask_monocolorMatrix[0, 2] = ( primary.B + 1 ) / 256F;
			//mask_monocolorMatrix[0, 3] = ( primary.A + 1 ) / 256F;

			mask_monocolorMatrix[3, 3] = ( primary.A + 1 ) / 256F;
			imageAttMono.SetColorMatrix(
				mask_monocolorMatrix,
				ColorMatrixFlag.Default,
				ColorAdjustType.Bitmap );
		}

		public void SetColor( Color c )
		{
			primary = c;
			SetMonoShader();
			//secondary = Color.FromArgb( 0 );
			mask_colorMatrix[2, 0] = ( c.R + 1 ) / 256F;
			mask_colorMatrix[2, 1] = ( c.G + 1 ) / 256F;
			mask_colorMatrix[2, 2] = ( c.B + 1 ) / 256F;
			mask_colorMatrix[2, 3] = ( c.A + 1 ) / 256F;
			//mask_colorMatrix[1, 0] = (c.R + 1) / 256F;
			//mask_colorMatrix[1, 1] = (c.G + 1) / 256F;
			//mask_colorMatrix[1, 2] = (c.B + 1) / 256F;
			//mask_colorMatrix[1, 3] = (c.A + 1) / 256F;
			mask_colorMatrix[3, 3] = ( mask_colorMatrix[1, 3] * mask_colorMatrix[2, 3] );
			imageAtt.SetColorMatrix(
				mask_colorMatrix,
				ColorMatrixFlag.Default,
				ColorAdjustType.Bitmap );
		}


		public void SetColor2( Color secondary )
		{
			this.secondary = secondary;
			//mask_colorMatrix[2, 0] = (primary.R + 1) / 256F;
			//mask_colorMatrix[2, 1] = (primary.G + 1) / 256F;
			//mask_colorMatrix[2, 2] = (primary.B + 1) / 256F;
			//mask_colorMatrix[2, 3] = (primary.A + 1) / 256F;
			mask_colorMatrix[1, 0] = ( secondary.R + 1 ) / 256F;
			mask_colorMatrix[1, 1] = ( secondary.G + 1 ) / 256F;
			mask_colorMatrix[1, 2] = ( secondary.B + 1 ) / 256F;
			mask_colorMatrix[1, 3] = ( secondary.A + 1 ) / 256F;
			mask_colorMatrix[3, 3] = ( mask_colorMatrix[1, 3] * mask_colorMatrix[2, 3] );
			imageAtt.SetColorMatrix(
				mask_colorMatrix,
				ColorMatrixFlag.Default,
				ColorAdjustType.Bitmap );
		}

		public void SetColor3( Color tertiary )
		{
			this.tertiary = tertiary;
			mask_colorMatrix[0, 0] = ( tertiary.R + 1 ) / 256F;
			mask_colorMatrix[0, 1] = ( tertiary.G + 1 ) / 256F;
			mask_colorMatrix[0, 2] = ( tertiary.B + 1 ) / 256F;
			mask_colorMatrix[0, 3] = ( tertiary.A + 1 ) / 256F;
			mask_colorMatrix[3, 3] = ( mask_colorMatrix[1, 3] * mask_colorMatrix[2, 3] * mask_colorMatrix[0, 3] );
			imageAtt.SetColorMatrix(
				mask_colorMatrix,
				ColorMatrixFlag.Default,
				ColorAdjustType.Bitmap );
		}

		public void SetColors( Color primary, Color secondary )
		{
			SetColor( primary );
			SetColor2( secondary );
		}
		// alternate secondary
		public void SetColorHighlight( Color c )
		{
		}

		// alternate primary and secondary
		public void SetColorHighlights( Color c )
		{
		}

		public bool LoadData( XPathNavigator r )
		{
			if( r.NodeType == XPathNodeType.Element )
			{
				if( String.Compare( r.Name, "attributes", true ) == 0 )
				{
					bool okay;
					for( okay = r.MoveToFirstAttribute(); okay; okay = r.MoveToNextAttribute() )
					{
						switch( r.Name )
						{
						case "primary":
							Primary = Color.FromArgb( Convert.ToInt32( r.Value, 10 ) );
							break;
						case "secondary":
							Secondary = Color.FromArgb( Convert.ToInt32( r.Value ) );
							break;
						case "highlight_primary":
							PrimaryHighlight = Color.FromArgb( Convert.ToInt32( r.Value ) );
							break;
						case "text_color":
							TextColor = Color.FromArgb( Convert.ToInt32( r.Value ) );
							break;
						case "highlight_secondary":
							SecondaryHighlight = Color.FromArgb( Convert.ToInt32( r.Value ) );
							break;
						//case "decal":
						//	SetDecalName( r.Value );
						//	break;
						}
					}
					r.MoveToParent();
					r.MoveToNext();
					return true;
				}
			}
			return false;
		}


		public static bool Load( XPathNavigator r )
		{
			if( r.NodeType == XPathNodeType.Element )
			{
				if( String.Compare( r.Name, "glare_set_attributes", true ) == 0 )
				{
					bool everokay = false;
					bool okay;
					GlareSetAttributes gsa = null;
					for( okay = r.MoveToFirstAttribute(); okay; okay = r.MoveToNextAttribute() )
					{
						everokay = true;
						switch( r.Name )
						{
						case "name":
							gsa = core_common.GetGlareSetAttributes( r.Value );
							break;
						case "primary":
							gsa.Primary = Color.FromArgb( Convert.ToInt32( r.Value, 10 ) );
							break;
						case "secondary":
							gsa.Secondary = Color.FromArgb( Convert.ToInt32( r.Value ) );
							break;
						case "highlight_primary":
							gsa.PrimaryHighlight = Color.FromArgb( Convert.ToInt32( r.Value ) );
							break;
						case "text_color":
							gsa.TextColor = Color.FromArgb( Convert.ToInt32( r.Value ) );
							break;
						case "highlight_secondary":
							gsa.SecondaryHighlight = Color.FromArgb( Convert.ToInt32( r.Value ) );
							break;
						//case "decal":
						//	gsa.SetDecalName( r.Value );
						//	break;
						}
					}
					if( everokay )
						r.MoveToParent();
					return true;
				}
			}
			return false;
		}

		public void Save( XmlWriter w )
		{
			w.WriteStartElement( "glare_set_attributes" );
			//w.WriteAttributeString("imageset", images.Name);
			w.WriteAttributeString( "name", Name );
			w.WriteAttributeString( "text_color", Convert.ToString( text.ToArgb() ) );
			w.WriteAttributeString( "primary", Convert.ToString( primary.ToArgb() ) );
			w.WriteAttributeString( "secondary", Convert.ToString( secondary.ToArgb() ) );
			w.WriteAttributeString( "highlight_primary", Convert.ToString( highlight_primary.ToArgb() ) );
			w.WriteAttributeString( "highlight_secondary", Convert.ToString( highlight_secondary.ToArgb() ) );
			//w.WriteAttributeString( "decal", decal_name );
			w.WriteEndElement();
			w.WriteRaw( "\r\n" );

		}


	}
}
