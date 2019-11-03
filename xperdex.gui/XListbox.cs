
using System;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using xperdex.classes;
using xperdex.core.interfaces;

namespace xperdex.gui
{
	public class XListbox : ListBox, IReflectorScale
	{

		public Fraction scale_x = new Fraction( 1, 1 );
		public Fraction scale_y = new Fraction(1,1);
		private font_tracker FontTracker;

		int max_width;

		public XListbox()
		{
			DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			MeasureItem += new MeasureItemEventHandler( XListbox_MeasureItem );
			DrawItem += new DrawItemEventHandler( XListbox_DrawItem );
			this.FontChanged += new EventHandler( XListbox_FontChanged );

			Scale( new SizeF( scale_x.ToFloat(), scale_y.ToFloat() ) );

			FontTracker = new font_tracker( this.Font );
			SizeF szf = FontTracker.MeasureString( this.CreateGraphics(), "X", scale_x, scale_y );
			ItemHeight = (int)( scale_y * szf.Height );
		}

		void XListbox_FontChanged( object sender, EventArgs e )
		{
			FontTracker = new font_tracker( this.Font );
			SizeF szf = FontTracker.MeasureString( this.CreateGraphics(), "X", scale_x, scale_y );
			ItemHeight = (int)( scale_y * szf.Height );			
		}

		void IReflectorScale.SetScale( Fraction scale_x, Fraction scale_y )
		{
			this.scale_x = scale_x;
			this.scale_y = scale_y;
			SizeF szf = FontTracker.MeasureString( this.CreateGraphics(), "X", scale_x, scale_y ); ;
			ItemHeight = (int)( scale_y * szf.Height );
		}

		Timer UpdateExtentTimer;
		void UpdateExtents()
		{
			this.HorizontalScrollbar = true;
			this.HorizontalExtent = max_width + 10;
			//Log.log( "Extent change caused immediate redraw" + max_width );

			UpdateExtentTimer.Stop();
			UpdateExtentTimer.Dispose();
			UpdateExtentTimer = null;
		}


		void XListbox_DrawItem( object sender, DrawItemEventArgs e )
		{
			bool max_width_updated = false;
			if( e.Index < 0 )
				return;
			//Log.log( "Draw Item " + e.Index + " in " + Name );
			GraphicsContainer gc = e.Graphics.BeginContainer();

			try
			{
				object item = this.Items[e.Index];
				if( item == null )
					Log.log( "No Item?!" );
				//Log.log( "Item is a " + item.GetType() );
				object display_member = item;  // default value.

				if( this.DisplayMember != null )
				{
					if( this.DisplayMember == "" )
					{
						// not really a display member..
						DataRowView drv = display_member as DataRowView;
						if( drv != null )
						{
							if( drv.Row.RowState == DataRowState.Deleted )
								display_member = "<Deleted Row>";
							else if( drv.Row.RowState == DataRowState.Detached )
								display_member = "<Detached Row>";
							else
								display_member = drv.Row;
						}
						else
						{
							DataRow row = display_member as DataRow;
							if( drv != null )
							{
								display_member = row;
							}
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
							DataRow row = item as DataRow;
							if( row != null && row.RowState != DataRowState.Detached && row.RowState != DataRowState.Deleted )
							{
								try
								{
									display_member = row[DisplayMember];
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

				//Log.log( "...Putting String " + output );
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
						SizeF szf = FontTracker.MeasureString( e.Graphics, segment, scale_x, scale_y );
						FontTracker.DrawString( e.Graphics
							, segment
							, textbrush
							, new Point( e.Bounds.X + tabpos + (int)( szf.Width / 2 )
									, e.Bounds.Y + (int)( szf.Height / 2 ) )
							, scale_x
							, scale_y );
						/*
						e.Graphics.DrawString( segment
							, Font
							, textbrush
							, e.Bounds.X + tabpos
							, e.Bounds.Y );
						*/
						output = output.Substring( output.IndexOf( '\t' ) + 1 );
                        if( output.Contains( "\t" ) )
							segment = output.Substring( 0, output.IndexOf( '\t' ) );
						else
							segment = null;
					}
					if( tabstop > 0 )
					{
						if( tab_stops != null && tabstop <= tab_stops.Length )
							tabpos = tab_stops[tabstop - 1];
						else
						{
							Log.log( "Using default tabstop" );
							tabpos = 96 * tabstop;
						}
					}
					//Log.log( "... " + output );
					{
						SizeF szf = FontTracker.MeasureString( e.Graphics, output, scale_x, scale_y );
						FontTracker.DrawString( e.Graphics
							, output
							, textbrush
							, new Point( e.Bounds.X + tabpos + (int)( szf.Width / 2 )
									, e.Bounds.Y + (int)( szf.Height / 2 ) )
							, scale_x
							, scale_y );
					}
					/*
					e.Graphics.DrawString( output
						, Font
						, textbrush
						, e.Bounds.X + tabpos
						, e.Bounds.Y );
					*/
					if( segment == null ) // last one to go out
					{
						SizeF szf = FontTracker.MeasureString( e.Graphics, output, scale_x, scale_y );
						if( e.Bounds.X + tabpos + (int)szf.Width > max_width )
						{
							max_width_updated = true;
							max_width = e.Bounds.X + tabpos + (int)szf.Width;
						}
					}
				}
				else
				{
					SizeF szf = FontTracker.MeasureString( e.Graphics, output, scale_x, scale_y );
					FontTracker.DrawString( e.Graphics
						, output
						, textbrush
						, new Point( e.Bounds.X + (int)( szf.Width / 2 )
								, e.Bounds.Y + (int)( szf.Height / 2 ) )
						, scale_x
						, scale_y );
					if( e.Bounds.X + (int)szf.Width > max_width )
					{
						max_width_updated = true;
						max_width = e.Bounds.X + (int)szf.Width;
					}
				}
				if( max_width_updated )
				{
					//Log.log( "..." + max_width + "..." + scale_x );
					//Log.log( "w:" + Width );
					max_width = scale_x * max_width;
					//Log.log( "...becomes " + max_width );
					if( max_width > HorizontalExtent && UpdateExtentTimer == null )
					{
						//Log.log( "New Timer" );
						UpdateExtentTimer = new Timer();
						UpdateExtentTimer.Tick += new EventHandler( UpdateExtentTimer_Tick );
						UpdateExtentTimer.Interval = 25;
						UpdateExtentTimer.Start();
						//this.HorizontalScrollbar = true;
						//this.HorizontalExtent = max_width + 10;
						//Log.log( "Extent change caused immediate redraw" + max_width );
					}
				}
			}
			catch( Exception excep )
			{
				Log.log( excep.Message );
			}
			e.Graphics.EndContainer( gc );
		}

		void UpdateExtentTimer_Tick( object sender, EventArgs e )
		{
			UpdateExtents();
		}

		/// <summary>
		/// This has to return the physical size for click to track correctly
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void XListbox_MeasureItem( object sender, MeasureItemEventArgs e )
		{
			Log.log( "Start measure item..." );
			SizeF szf = FontTracker.MeasureString( e.Graphics, this.Items[e.Index].ToString(), scale_x, scale_y );
			// need to lie and claim the box is bigger than it actually is.
			szf.Height += 5;
			szf.Width *= scale_x;
			szf.Height *= scale_y;

			//szf.Height += ( 5 / scale_y.ToFloat() );
			//g.EndContainer( gc );
			e.ItemHeight = (int)szf.Height;
			e.ItemWidth = (int)szf.Width;
			Log.log( "Return measure item..." );
		}

		protected override void OnDragDrop( DragEventArgs drgevent )
		{
			base.OnDragDrop( drgevent );
		}
		protected override void OnDragOver( DragEventArgs drgevent )
		{
			base.OnDragOver( drgevent );
		}
		protected override void OnDragLeave( EventArgs e )
		{
			base.OnDragLeave( e );
		}


		private const int LB_SETTABSTOPS = 0x192;
		// Declaration of external function
		[System.Runtime.InteropServices.DllImport( "user32.dll" )]
		private static extern int SendMessage( int hWnd, int wMsg, int wParam, ref int lParam );
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
				if( tab_stops != null )
				{
					int result;
					// Send LB_SETTABSTOPS message to ListBox
					result = SendMessage( this.Handle.ToInt32(), LB_SETTABSTOPS, tab_stops.Length, ref tab_stops[0] );

					// Refresh the ListBox control.
					//this.Refresh();
				}
			}
		}
	}
}
