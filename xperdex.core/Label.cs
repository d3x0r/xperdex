using System;
using System.Collections.Generic;
using System.Drawing;
using xperdex.classes;
using xperdex.core.interfaces;
using xperdex.gui;

namespace xperdex.core
{
	[ControlAttribute( Name="Core.Text+Label" )]
	public class Label: PSI_Control, IReflectorPersistance
	{
		public String text { get; set; }
		internal font_tracker font;
		Color _textcolor;
		internal bool centered = true;
		internal bool right_just;

		public Label()
		{
			Paint += new System.Windows.Forms.PaintEventHandler( Label_Paint );
		}

		internal Color textcolor
		{
			set
			{
				if( _textcolor != value )
				{
					_textcolor = value;
					textbrush = new SolidBrush( value );
				}
			}
			get
			{
				return _textcolor;
			}
		}

		internal Brush textbrush;

		void Label_Paint( object sender, System.Windows.Forms.PaintEventArgs e )
		//protected override void OnPaint( System.Windows.Forms.PaintEventArgs e )
		{
			if( font == null )
				return;
			{
				Canvas canvas = this.Parent as Canvas;
				int offset = 0;
				String realtext = variables.Variables.ResolveVariables( this, text );

				List<SizeF> output_size;
				List<string> output;
				output = new List<string>();
				output_size = new List<SizeF>();
				int idx;
				if( realtext != null )
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
				foreach( string s in output )
				{
					SizeF size;
					output_size.Add( size = font.MeasureString( e.Graphics, s, canvas.font_scale_x, canvas.font_scale_y ) );
					//output_size.Add( size = e.Graphics.MeasureString( s, font ) );
					height += (int)( size.Height + ( height > 0 ? 2 : 0 ) );
				}

				Point _point = new Point( Size );
				Point point = new Point();
				if( centered )
				{
					//SizeF size = new SizeF(gout.MeasureString(realtext, c.Font));
					_point.X /= 2;
					_point.Y /= 2;
					//_point.Y -= (int)( height / 2 );

					point.Y = _point.Y;
					point.X = _point.X;
					int n = 0;
					foreach( string s in output )
					{
						//point.X = _point.X - (int)( output_size[n].Width / 2 );
						if( canvas != null )
							font.DrawString( e.Graphics, s, textbrush, point, canvas.font_scale_x, canvas.font_scale_y );
						else
							font.DrawString( e.Graphics, s, textbrush, point, new Fraction(1,1), new Fraction(1,1) );
						point.Y += (int)( output_size[n].Height ) + ( ( n > 0 ) ? 2 : 0 );
						n++;
					}
				}
				else if( right_just )
				{
					//SizeF size = new SizeF(gout.MeasureString(realtext, c.Font));
					_point.X /= 2;
					_point.Y /= 2;
					//_point.Y -= (int)( height / 2 );

					point.Y = _point.Y;
					int n = 0;
					foreach( string s in output )
					{
						point.X = Width - ( 5 + (int)( output_size[n].Width / 2 ) );
						/*
						e.Graphics.DrawString( s
							 , font
							 , textbrush
							 , point );
						 * */
						font.DrawString( e.Graphics, s, textbrush, point, canvas.font_scale_x, canvas.font_scale_y );
						point.Y += (int)( output_size[n].Height ) + ( ( n > 0 ) ? 2 : 0 );
						n++;
					}
				}
				else
				{
					//SizeF size = new SizeF(gout.MeasureString(realtext, c.Font));
					_point.X /= 2;
					_point.Y /= 2;
					//_point.Y -= (int)( height / 2 );

					point.Y = _point.Y;
					int n = 0;
					foreach( string s in output )
					{
						point.X = 5 + (int)( output_size[n].Width / 2 );
						/*
						e.Graphics.DrawString( s
							 , font
							 , textbrush
							 , point );
						 * */
						font.DrawString( e.Graphics, s, textbrush, point, canvas.font_scale_x, canvas.font_scale_y );
						point.Y += (int)( output_size[n].Height ) + ( ( n > 0 ) ? 2 : 0 );
						n++;
					}
				}
			}
			//base.OnPaint( e );
		}

		#region IReflectorPersistance Members

		bool IReflectorPersistance.Load( System.Xml.XPath.XPathNavigator r )
		{
			switch( r.Name )
			{
			case "TextLabel":
				for( bool okay = r.MoveToFirstAttribute(); okay; okay = r.MoveToNextAttribute() )
					switch( r.Name )
					{
					case "Font":
						font = FontEditor.GetFontTracker( r.Value );
						break;
					case "Color":
						textcolor = Color.FromArgb( Convert.ToInt32( r.Value ) );
						break;
					case "BackColor":
						BackColor = Color.FromArgb( Convert.ToInt32( r.Value ) );
						break;
					case "Text":
						text = r.Value;
						break;
					case "Align":
						switch( r.Value )
						{
						case "Center":
							centered = true;
							right_just = false;
							break;
						case "Right":
							right_just = true;
							centered = false;
							break;
						case "Left":
							centered = false;
							right_just = false;
							break;
						}
						break;
					}
				r.MoveToParent();
				return true;
			}
			return false;
		}

		void IReflectorPersistance.Save( System.Xml.XmlWriter w )
		{
			w.WriteStartElement( "TextLabel" );
			w.WriteAttributeString( "Color", Convert.ToString( _textcolor.ToArgb() ) );
			w.WriteAttributeString( "BackColor", Convert.ToString( BackColor.ToArgb() ) );
			if( font != null )
				w.WriteAttributeString( "Font", font.Name );
			w.WriteAttributeString( "Text", text );
			if( centered )
				w.WriteAttributeString( "Align", "Center" );
			else if( right_just )
				w.WriteAttributeString( "Align", "Right" );
			else
				w.WriteAttributeString( "Align", "Left" );

			w.WriteEndElement();
			w.WriteRaw( "\r\n" );
			//throw new Exception( "The method or operation is not implemented." );
		}

		void IReflectorPersistance.Properties()
		{
			LabelEditor le = new LabelEditor( this );
			le.ShowDialog();
			if( le.DialogResult == System.Windows.Forms.DialogResult.OK )
				le.LabelEditor_Apply();
			le.Dispose();
			//throw new Exception( "The method or operation is not implemented." );
		}

		#endregion
	}
}
