using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using xperdex.classes;
using System.Drawing.Drawing2D;
using System.Data;
using xperdex.core.interfaces;

namespace xperdex.gui
{
	public class XComboBox : ComboBox, IReflectorScale
	{
		public Fraction scale_x = new Fraction( 1, 1 );
		public Fraction scale_y = new Fraction( 1, 1 );

		int max_width;

		public XComboBox()
		{
			this.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			this.DrawItem += new DrawItemEventHandler( XComboBox_DrawItem );
			this.MeasureItem += new MeasureItemEventHandler( XComboBox_MeasureItem );
			this.DropDownStyle = ComboBoxStyle.DropDownList;

			FontChanged += new EventHandler( XComboBox_FontChanged );

			Scale( new SizeF( scale_x.ToFloat(), scale_y.ToFloat() ) );

			SizeF szf = this.CreateGraphics().MeasureString( "X", Font );
			ItemHeight = (int)( scale_y * szf.Height );
		}

		void XComboBox_FontChanged( object sender, EventArgs e )
		{
			SizeF szf = this.CreateGraphics().MeasureString( "X", Font );
			ItemHeight = (int)( scale_y * szf.Height );
		}

		void IReflectorScale.SetScale( Fraction scale_x, Fraction scale_y )
		{
			this.scale_x = scale_x;
			this.scale_y = scale_y;
			SizeF szf = this.CreateGraphics().MeasureString( "X", Font );
			ItemHeight = (int)( scale_y * szf.Height );
		}

		void XComboBox_MeasureItem( object sender, MeasureItemEventArgs e )
		{
			SizeF szf = e.Graphics.MeasureString( this.Items[e.Index].ToString(), Font );
			// need to lie and claim the box is bigger than it actually is.
			szf.Height += 5;
			szf.Width *= scale_x;
			szf.Height *= scale_y;

			//szf.Height += ( 5 / scale_y.ToFloat() );
			//g.EndContainer( gc );
			e.ItemHeight = (int)szf.Height;
			e.ItemWidth = (int)szf.Width;
		}

		void XComboBox_DrawItem( object sender, DrawItemEventArgs e )
		{
			bool max_width_updated = false;
			if( e.Index < 0 )
				return;

			GraphicsContainer gc = e.Graphics.BeginContainer();

			try
			{
				object item = this.Items[e.Index];

				object display_member = item;  // default value.

				if( this.DisplayMember != null )
				{
					if( this.DisplayMember == "" )
					{
						// not really a display member..
						DataRowView drv = display_member as DataRowView;
						if( drv != null )
						{
							display_member = drv.Row;
						}
					}
					else
					{
						System.Reflection.PropertyInfo pi = item.GetType().GetProperty( this.DisplayMember );
						if( pi != null )
							display_member = pi.GetValue( item, null );
						else
						{
							DataRowView drv = item as DataRowView;
							if( drv != null && drv.Row.RowState != DataRowState.Detached && drv.Row.RowState != DataRowState.Deleted )
							{
								try
								{
									display_member = drv.Row[DisplayMember];
								}
								catch( Exception ex )
								{
									display_member = ex.Message;
								}
							}
						}
					}
				}

				String output = display_member.ToString();
				//String output = this.Items[e.Index].ToString();
				//SizeF szf = e.Graphics.MeasureString( output, Font );

				if( e.State.HasFlag( DrawItemState.Selected ) )
					e.Graphics.FillRectangle( SystemBrushes.Highlight, e.Bounds );
				else
					e.Graphics.FillRectangle( new SolidBrush( this.BackColor ), e.Bounds );

				// bounds should be the result of the measure, and the measure should be resulting in real size.

				e.Graphics.TranslateTransform( e.Bounds.X - ( scale_x * e.Bounds.X )
					, e.Bounds.Y - ( scale_y * e.Bounds.Y ) );
				e.Graphics.ScaleTransform( scale_x.ToFloat(), scale_y.ToFloat() );

				Brush textbrush;
				if( e.State.HasFlag( DrawItemState.Selected ) )
				{
					textbrush = SystemBrushes.HighlightText;
				}
				else
					textbrush = new SolidBrush( this.ForeColor );

				//Rectangle actual = Fraction.Scale( e.Bounds, scale_x, scale_y );

				if( output.Contains( "\t" ) )
				{
					int tabstop = 0;
					int tabpos = 0;
					String segment;
					for( segment = output.Substring( 0, output.IndexOf( "\t" ) ); segment != null; )
					{
						if( tabstop > 0 )
						{
							if( tab_stops != null && tabstop <= tab_stops.Length )
								tabpos = tab_stops[tabstop - 1];
							else
								tabpos = 96 * tabstop;
						}
						tabstop++;

						e.Graphics.DrawString( segment
							, Font
							, textbrush
							, e.Bounds.X + tabpos
							, e.Bounds.Y );
						output = output.Substring( output.IndexOf( "\t" ) + 1 );
                        if( output.Contains( "\t" ) )
                            segment = output.Substring( 0, output.IndexOf( "\t" ) );
						else
							segment = null;
					}
					if( tabstop > 0 )
					{
						if( tab_stops != null && tabstop <= tab_stops.Length )
							tabpos = tab_stops[tabstop - 1];
						else
							tabpos = 96 * tabstop;
					}
					e.Graphics.DrawString( output
						, Font
						, textbrush
						, e.Bounds.X + tabpos
						, e.Bounds.Y );

					if( segment == null ) // last one to go out
					{
						SizeF szf = e.Graphics.MeasureString( output, Font );
						if( e.Bounds.X + tabpos + (int)szf.Width > max_width )
						{
							max_width_updated = true;
							max_width = e.Bounds.X + tabpos + (int)szf.Width;
						}
					}
				}
				else
				{
					e.Graphics.DrawString( output
						, Font
						, textbrush
						, e.Bounds.X
						, e.Bounds.Y );
					SizeF szf = e.Graphics.MeasureString( output, Font );
					if( e.Bounds.X + (int)szf.Width > max_width )
					{
						max_width_updated = true;
						max_width = e.Bounds.X + (int)szf.Width;
					}
				}
				if( max_width_updated )
				{
					max_width = scale_x * max_width;
					if( max_width > Width )
					{
						//this.HorizontalScrollbar = true;
						//this.HorizontalExtent = max_width + 10;
					}
				}
			}
			catch( Exception excep )
			{
				Log.log( excep.Message );
			}
			e.Graphics.EndContainer( gc );
		}

		private const int LB_SETTABSTOPS = 0x192;
		// Declaration of external function
		//[System.Runtime.InteropServices.DllImport( "user32.dll" )]
		//private static extern int SendMessage( int hWnd, int wMsg, int wParam, ref int lParam );
		int[] tab_stops;
		public int[] TabStops
		{
			get
			{
				return tab_stops;
			}
			set
			{
				tab_stops = value;
			}
		}

	}
}
