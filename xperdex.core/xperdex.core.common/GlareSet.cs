using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using System.Xml;
using System.Xml.XPath;
using xperdex.classes;
//using System.

namespace xperdex.core
{


	public class GlareSet
	{
		public GlareSetAttributes attrib;
		public GlareSetData images;

		public enum GlareState
		{
			Normal
			, Pressed
			, Depressed
			, NormalHightlight
			, PressedHightlight
		};

		public GlareState state;
		public Bitmap composite; // temp image which represents the composite glare?

		public GlareSet()
		{
			attrib = new GlareSetAttributes();
			images = core_common.GetGlareSetData( "default" );
			attrib = core_common.GetGlareSetAttributes( "default" );

			if( images.mask != null )
				composite = new Bitmap( images.mask.Width, images.mask.Height );
			state = GlareState.Normal;
		}

		public GlareSet( GlareSet original )
		{
			// maybe just use the same attribute reference...
			attrib = original.attrib;// new GlareSetAttributes( original.attrib );
			images = original.images;
			state = GlareState.Normal;			
		}

		public GlareSet( string name )
		{
			attrib = core_common.GetGlareSetAttributes( "default" );
			images = core_common.GetGlareSetData( name );
			state = GlareState.Normal;
		}
		public GlareSet( string name, string attribs )
		{
			attrib = core_common.GetGlareSetAttributes( attribs );
			images = core_common.GetGlareSetData( name );
			state = GlareState.Normal;
		}

		public bool Load( XPathNavigator r )
		{
			if( r.NodeType == XPathNodeType.Element )
			{
				bool okay = false;
			retry:
				if( String.Compare( r.Name, "glareset", true ) == 0 )
				{
					images = core_common.GetGlareSetData( r.Value );
					r.MoveToNext();
					okay = true;
					goto retry;
				}
				else if( String.Compare( r.Name, "glareset_attributes", true ) == 0 )
				{
					attrib = core_common.GetGlareSetAttributes( r.Value );
					r.MoveToNext();
					okay = true;
					goto retry;
				}
				return okay;
			}
			return false;
		}

		public void Save( XmlWriter w )
		{
			w.WriteElementString( "glareset", this.images.Name );
			if( this.attrib != null )
				w.WriteElementString( "glareset_attributes", this.attrib.Name );
		}


		public delegate bool RenderText( Control c, Graphics g );

		public void OutputGlareSet( PSI_Button c, PaintEventArgs e, RenderText render, GlareState type )
		{
			System.Drawing.Imaging.ImageAttributes ia = new ImageAttributes();
			//ia.
			//if (set != 0)
			if( images.mask != null )
				if( images.mask_rect != null )
				{
					Control parent;
					Canvas canvas = null;
					for( parent = c.Parent; parent != null; parent = parent.Parent )
					{
						canvas = parent as Canvas;
						if( canvas != null )
							break;
					}
					if( images.mask != null )
						//colored_mask = new Bitmap( images.mask.Width, images.mask.Height );
						composite = new Bitmap( c.Width, c.Height );
					Graphics gout = Graphics.FromImage( composite );
					//Color r, g, b;
					//r = Color.FromArgb(unchecked((Int32)0xFF000000));
					//g = Color.FromArgb(unchecked((Int32)0xFF9332c3));
					//b = Color.FromArgb(unchecked((Int32)0x80b7ac23));
					gout.Clear( Color.Transparent );
					if( type == GlareState.NormalHightlight || type == GlareState.PressedHightlight )
						images.ColorMask( images.mask, gout, composite, attrib, true );
					else
						images.ColorMask( images.mask, gout, composite, attrib, false );

					if( c._decal != null )
					{
						Rectangle r = c.ClientRectangle;
						r.X += ( r.Width * ( 100 - c.DecalScale ) ) / 200;
						r.Y += ( r.Height * ( 100 - c.DecalScale ) ) / 200;
						r.Width -= r.X * 2;
						r.Height -= r.Y * 2;
						gout.DrawImage( c._decal, r
							, c._decal_rect, GraphicsUnit.Pixel
							 );
					}

					if( !render( c, gout ) )
					
					if( c.Text != null )
					{
						int offset = 0;
						String realtext = variables.Variables.ResolveVariables( c, c.Text );
			
						List<SizeF> output_size;
						List<string> output;
						output = new List<string>();
						output_size = new List<SizeF>();
						int idx;
						do
						{
							idx = realtext.IndexOf( '_', offset );

							if( idx >= 0 )
							{
								output.Add( realtext.Substring( offset, idx - offset ) );
								offset = idx + 1;
							}
							else
								output.Add( realtext.Substring( offset, realtext.Length - offset ) );

						} while( idx >= 0 );
						int height = 0;
						int lineheight = 0;
						foreach( string s in output )
						{
							SizeF size;
							if( canvas != null )
								output_size.Add( size = c.FontTracker.MeasureString( gout, s, canvas.font_scale_x, canvas.font_scale_y ) );
							else
								output_size.Add( size = c.FontTracker.MeasureString( gout, s ) );
							//output_size.Add( size = new SizeF( gout.MeasureString( s, c.FontTracker ) ) );
							height += (int)((lineheight = (int)size.Height)+ (height > 0 ? 0 : 0));
						}

						Point _point = new Point( c.Size );
						Point point = new Point();

						//SizeF size = new SizeF(gout.MeasureString(realtext, c.Font));
						_point.X /= 2;
						_point.Y /= 2;
						_point.Y -= (int)((height - lineheight) / 2);

						point.Y = _point.Y;
						int n = 0;
						foreach( string s in output )
						{
							point.X = _point.X /*- (int)(output_size[n].Width / 2)*/;
							if( canvas != null )
								c.FontTracker.DrawString( gout, s, attrib.text_output, point, canvas.font_scale_x, canvas.font_scale_y );
							else
								c.FontTracker.DrawString( gout, s, attrib.text_output, point, new Fraction(1,1), new Fraction(1,1) );
							//gout.DrawString( s
							//	 , c.FontTracker
							//	 , attrib.text_output
						//		 , point );
							point.Y += (int)(output_size[n].Height) + ((n > 0) ? 2 : 0);
							n++;
						}
					}

					/*
					 * Draw the top layer over the text/decal above...
					 * 
					 */
					if( images.depressed != null 
						&& ( type == GlareState.Normal || type == GlareState.NormalHightlight) )
					{
						if( type == GlareState.NormalHightlight && images.highlight_depressed != null )
							gout.DrawImage( images.highlight_depressed
								 , c.ClientRectangle
								 , new Rectangle( 0, 0, images.highlight_depressed.Width, images.highlight_depressed.Height )
								 , GraphicsUnit.Pixel );
						else
							gout.DrawImage( images.depressed
								 , c.ClientRectangle
								 , new Rectangle( 0, 0, images.depressed.Width, images.depressed.Height )
								 , GraphicsUnit.Pixel );
					}
					else if( type == GlareState.Pressed || type == GlareState.PressedHightlight )
					{
						if( type == GlareState.PressedHightlight && images.highlight_pressed != null )
							gout.DrawImage( images.highlight_pressed
									, c.ClientRectangle
									, new Rectangle( 0, 0, images.highlight_pressed.Width, images.highlight_pressed.Height )
									, GraphicsUnit.Pixel );
						else
							if( images.pressed != null )
								gout.DrawImage( images.pressed
									 , c.ClientRectangle
									 , new Rectangle( 0, 0, images.pressed.Width, images.pressed.Height )
									 , GraphicsUnit.Pixel );
					}
					else
					{
						if( images.glare != null )
						gout.DrawImage( images.glare
							 , c.ClientRectangle
							 , new Rectangle( 0, 0, images.glare.Width, images.glare.Height )
							 , GraphicsUnit.Pixel );
					}

					// output the final composit image...
					e.Graphics.DrawImage( composite
						, c.ClientRectangle
						, c.ClientRectangle
						, GraphicsUnit.Pixel
						 );
				}
		}

	}
}
