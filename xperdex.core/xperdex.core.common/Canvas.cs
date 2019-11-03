using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Xml.XPath;
using System.Diagnostics;
using System.Threading;
using System.IO;
using xperdex.gui;
using xperdex.core.interfaces;
using xperdex.classes;
using xperdex.core.common;

namespace xperdex.core
{
    //UserControl
	public partial class Canvas: PSI_Control , IReflectorPersistance
	{
		public enum corners
		{
			// corners.None means not sizing by a corner...
			None, UpperLeft, UpperRight, LowerLeft, LowerRight
		}

		public class canvas_flags
		{
			public bool editing;
			public bool active;
			public bool selecting;
			public bool loading;
			public bool dragging;
			public bool moved;
			public bool moved_block;
			public corners sizing_corner;
		}

		//Rectangle scaledr;
		Rectangle _selection;
		public Rectangle selection;
		public canvas_flags flags;

		// actual interface to this canavas object 
		// may be a child.
		IReflectorCanvas ICanvas;
		public List<page> pages;

		public List<ControlTracker> selected = new List<ControlTracker>();

		Brush edit_background = new SolidBrush( Color.FromArgb( 32, 0, 84, 84 ) );
		Brush selecting_brush = new SolidBrush( Color.FromArgb(128, 0, 0, 128 ) );
		Brush selected_control = new SolidBrush( Color.FromArgb( 192, 128, 128, 0 ) );
		Brush moving_control = new SolidBrush( Color.FromArgb(192, 0, 128, 0 ) );
		Brush Sizing_corner = new SolidBrush( Color.FromArgb(192, 128, 128, 0 ) );
		Brush control_edit = new SolidBrush( Color.FromArgb( 128, 128, 128, 0 ) );
		Brush control_corner_edit = new SolidBrush( Color.FromArgb( 128, 128, 128, 0 ) );

		//Font defaultFont;
		
		page _current_page;

		public page current_page
		{
			set
			{
				if( !flags.loading )
					//this.canvas.current_page
					foreach( IReflectorSecurity tag in value.security_tags )
					{
						if( !tag.Test() )
							return;
					}
				SuspendLayout();
				if( _current_page != null )
				{
					_current_page.Hide();
				}

				if( !returning_page )
					if( value != null )
					{
						value.PreviousPage = _current_page;
					}

				if( (_current_page = value) != null )
				{
					if( !flags.loading )
					{
						// don't have to show page when loading...
						if( !flags.editing )
							_current_page.Show();
						this.BackgroundImage = _current_page.background_image;
						this.BackColor = current_page.background_color;
					}
				}
				ResumeLayout();
				this.Refresh();
			}
			get { return _current_page; }
		}

		string findpage;
		bool FindPageThing( page p )
		{
			if( findpage == null )
				return false;
			if( String.Compare( p.Name, findpage, true ) == 0 )
				return true;
			return false;
		}

		static object syncroot = new object();
		bool returning_page; 

		public page FindPage( string name )
		{			
			lock( syncroot )
			{
				page result_page = null;
				returning_page = false;
				if( name == "<Previous>" )
				{
					result_page = current_page.PreviousPage;
					returning_page = true;
				}
				else if( name == "<Next>" )
				{
					int this_page = pages.IndexOf( _current_page );
					if( this_page < pages.Count )
						result_page = pages[this_page + 1];
				}
				else if( name == "<Prior>" )
				{
					int this_page = pages.IndexOf( _current_page );
					if( this_page > 0 )
						result_page = pages[this_page - 1];
				}
				else if( name == "<Startup>" )
				{
					result_page = pages[0];
				}
				else
				{
					findpage = name;
					result_page = pages.Find( FindPageThing );
				}
				if( result_page == null )
					result_page = new page( this, name );
				return result_page;
			}
		}


		//static Keyboard keyboard;


		public Rectangle GetWhere()
		{
			return this.GetScaledBounds( new Rectangle( current_page.PARTX( selection.X )
				 , current_page.PARTY( selection.Y )
				 , current_page.PARTW( selection.X, selection.Width )
				 , current_page.PARTH( selection.Y, selection.Height ) )
				 , ((Form)this.Parent).AutoScaleDimensions, BoundsSpecified.Location );
		}


		protected override CreateParams CreateParams
		{
			get
			{
				CreateParams cp = base.CreateParams;
				//cp.ExStyle |= 0x20; // turn on WS_EX_TRANSPARENT
				// this is so controls can overlap transparency
				cp.Style &= ~0x02000000; // turn off clip children(?) might be clip_siblings
				cp.ExStyle |= 0x02000000; //WS_EX_COMPOSITED
				return cp;
			}
		}

		void EndEdit()
		{
			if( flags.editing )
			{
				flags.editing = false;
				foreach( IReflectorPluginDropFileTarget acceptor in core_common.drop_acceptors )
				{
					IReflectorEdit edit = acceptor as IReflectorEdit;
					if( edit != null )
						edit.EndEdit();
				}
				SaveConfig();
				ContextMenuStrip = null;
				this.SuspendLayout();
				// at this point if a canvas was created
				// this will be the first time it is shown...
				// default page must be created (and will be within display)
				current_page.Show();
				Refresh();
				this.ResumeLayout();
			}
		}

		void StartEdit()
		{
			if( !flags.editing )
			{
				flags.editing = true;
				foreach( IReflectorPluginDropFileTarget acceptor in core_common.drop_acceptors )
				{
					IReflectorEdit edit = acceptor as IReflectorEdit;
					if( edit != null )
						edit.BeginEdit();
				}
				ContextMenuStrip = my_context_menu;
				current_page.Hide();
				Refresh();
			}
		}

		void EndEdit( Object s, EventArgs e )
		{
			EndEdit();
		}

		void EditProperties( Object s, EventArgs e )
		{

		}

		void EditCommonProperties( Object s, EventArgs e )
		{

		}

		void CloneButton( Object s, EventArgs e )
		{
			if( selected.Count > 0 )
			{
				core_common.clone_controls = new List<ControlTracker>();
				foreach( ControlTracker c in selected )
				{
					core_common.clone_controls.Add( c );
					IReflectorCopyPaste copy = c.o as IReflectorCopyPaste;
					if( copy != null )
						copy.OnClone();
					copy = c.c as IReflectorCopyPaste;
					if( copy != null )
						copy.OnClone();
				}
			}
			else
			{
				core_common.clone_control = current_control;
				IReflectorCopyPaste copy = core_common.clone_control.o as IReflectorCopyPaste;
				if( copy != null )
					copy.OnClone();
				copy = core_common.clone_control.c as IReflectorCopyPaste;
				if( copy != null )
					copy.OnClone();
			}
		}

		ControlTracker current_control;

		static void PropertyClick( Object s, EventArgs e )
		{
			bool did_property = false;
			if( core_common.current_mouse_control != null )
			{
				IReflectorPersistance pc = core_common.current_mouse_control.o as IReflectorPersistance;
				if( pc != null )
				{
					pc.Properties();
					did_property = true;
				}
				if( !did_property )
				{
					pc = core_common.current_mouse_control.c as IReflectorPersistance;
					if( pc != null )
					{
						pc.Properties();
						did_property = true;
					}
				}
			}
			if( !did_property && core_common.current_mouse_control != null )
			{
				Control c = core_common.current_mouse_control.o as Control;
				if( c != null )
				{
					new EditControl( c ).ShowDialog();
					did_property = true;
				}
			}
			if( !did_property )
			{
				if( core_common.current_mouse_page != null )
				{
					core_common.current_mouse_page.PropertyClick();
				}
			}
		}

		void PropertyClickBypass( Object s, EventArgs e )
		{
			bool did_property = false;
			if( current_control != null )
			{
				IReflectorPersistance pc = current_control.c as IReflectorPersistance;
				if( pc != null )
				{
					pc.Properties();
					did_property = true;
				}
			}
			if( !did_property )
			{
				current_page.PropertyClick();
				Refresh();
				this.BackgroundImage = current_page.background_image;
			}
		}

		void CreateAClone( Object s, EventArgs e )
		{
			if( core_common.clone_controls.Count > 0 )
			{
				foreach( ControlTracker c in core_common.clone_controls )
				{
					Rectangle r = c.grid_rect;
					ControlTracker ct = current_page.MakeControl( c.Type, c.i, r );
					IReflectorCopyPaste copy = ct.o as IReflectorCopyPaste;
					if( copy != null )
						copy.OnPaste( c.o );
					copy = ct.c as IReflectorCopyPaste;
					if( copy != null )
						copy.OnPaste( c.c );
				}
			}
			else
				if( core_common.clone_control != null )
				{
					Rectangle r = core_common.clone_control.grid_rect;
					r.X = core_common.partX;
					r.Y = core_common.partY;
					ControlTracker ct = current_page.MakeControl( core_common.clone_control.Type, core_common.clone_control.i, r );
					IReflectorCopyPaste copy = ct.o as IReflectorCopyPaste;
					if( copy != null )
						copy.OnPaste( core_common.clone_control.o );
					copy = ct.c as IReflectorCopyPaste;
					if( copy != null )
						copy.OnPaste( core_common.clone_control.c );
				}
		}

		void MakeAPage( Object s, EventArgs e )
		{
			// add the page to pages list
			// also adds page to change page menu
			String name = QueryNewName.Show( "Enter new page name" );
			current_page = new page( this, name );
		}
		void RenameAPage( Object s, EventArgs e )
		{
			// add the page to pages list
			// also adds page to change page menu
			String name = QueryNewName.Show( "Enter new page name (DANGER, BREAKS BUTTON NAVIGATION)", _current_page.Name );
			if( name.Length > 0 )
				_current_page.Name = name;
		}
		void DeleteButton( Object s, EventArgs e )
		{
			current_page.Remove( current_control );
			Refresh();
		}

		ContextMenuStrip _my_context_menu;
		ContextMenuStrip my_context_menu
		{
			get
			{
				if( _my_context_menu == null  || _my_context_menu.IsDisposed )
				{
					_my_context_menu = new ContextMenuStrip();
					_my_context_menu.Items.Add( new ToolStripLabel( "Properties", null, false, PropertyClick ) );
					_my_context_menu.Items.Add( new ToolStripLabel( "New Page", null, false, MakeAPage ) );
					_my_context_menu.Items.Add( new ToolStripLabel( "Rename Page", null, false, RenameAPage ) );
					_my_context_menu.Items.Add( new ToolStripLabel( "Create Clone", null, false, CreateAClone ) );
					ToolStripMenuItem label;
					_my_context_menu.Items.Add( label = new ToolStripMenuItem( "Change Page" ) );
					label.DropDown = change_page_context_menu;

					if( core_common.plugin_drop.GetCurrentParent() != null )
						core_common.plugin_drop.GetCurrentParent().Dispose();
					_my_context_menu.Items.Add( core_common.plugin_drop );
					if( core_common.other_drop.GetCurrentParent() != null )
						core_common.other_drop.GetCurrentParent().Dispose();
					_my_context_menu.Items.Add( core_common.other_drop );
					//local.plugin_drop.OwnerChanged += plugin_drop_OwnerChanged;
					//local.other_drop.OwnerChanged += plugin_drop_OwnerChanged;
					_my_context_menu.Items.Add( new ToolStripLabel( "Done", null, false, EndEdit ) );
				}
				return _my_context_menu;
			}
			set
			{
				if( value == null )
					_my_context_menu.Dispose();
				else
					if( value.Equals( _my_context_menu ) )
						return;
				_my_context_menu = value;
			}
		}
		ContextMenuStrip control_context_menu;
		internal ContextMenuStrip change_page_context_menu; // for navigating pages. 
		//ContextMenuStrip my_context_menu;

		void StaticInit()
		{
			change_page_context_menu = new ContextMenuStrip();

			if( control_context_menu == null )
			{
				control_context_menu = new ContextMenuStrip();
				control_context_menu.Items.Add( new ToolStripLabel( "Edit", null, false, PropertyClick ) );
				control_context_menu.Items.Add( new ToolStripLabel( "Edit General", null, false, PropertyClickBypass ) );
				control_context_menu.Items.Add( new ToolStripLabel( "Clone", null, false, CloneButton ) );
				control_context_menu.Items.Add( new ToolStripLabel( "Delete", null, false, DeleteButton ) );
			}
		}

		void plugin_drop_OwnerChanged( object sender, EventArgs e )
		{
			ToolStripMenuItem tsmi = sender as ToolStripMenuItem;
			if( tsmi != null )
				tsmi.OwnerChanged -= plugin_drop_OwnerChanged;
			if( tsmi.Owner != null && !tsmi.Owner.Equals( my_context_menu ) )
				my_context_menu = null;
			//throw new Exception( "The method or operation is not implemented." );
		}

		void InitDefault( font_tracker font_tracker )
		{
			// some 3/4 aspect ratio... the font scale is based against this... so we'd have double applied scaling
			// to the default font.
			SizeF target_size = new SizeF( 1024 / 40, 768 / 20 );

			int height = (int)target_size.Height;
			font_tracker.f = new Font( "Lucida Console", height, GraphicsUnit.Pixel );
		}

		void InitCanvas( IReflectorCanvas i )
		{
			StaticInit();

			font_tracker default_font = FontEditor.GetFontTracker( "Default", InitDefault );

			//keyboard = new Keyboard();
			ICanvas = i;
			flags = new canvas_flags();
			pages = new List<page>();
			ContextMenuStrip = null;
				
			InitializeComponent();
			SetStyle( ControlStyles.UserPaint, true );
			SetStyle( ControlStyles.AllPaintingInWmPaint, true );
			SetStyle( ControlStyles.DoubleBuffer, true );
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            SetStyle(ControlStyles.Opaque, false);  // no background
            SetStyle(ControlStyles.UserPaint, true); // generate paint
            SetStyle(ControlStyles.AllPaintingInWmPaint, true); // skip paintbackground

			this.MouseMove += new MouseEventHandler(Canvas_MouseMove);
			//this.BackgroundImage = current_page.background_image;
			this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			//base.
			this.ControlAdded += new ControlEventHandler( Canvas_ControlAdded );

			buttons = new buttons_class();  // mouse buttons
		}

		public Canvas(): base()
		{
			InitCanvas( this as IReflectorCanvas );
		}

		public Canvas( IReflectorCanvas i )
		{
			InitCanvas( i );
		}

		private void CanvasGridPaint( object sender, PaintEventArgs e )
		{
		}

		buttons_class buttons;

        void Canvas_MouseMove(Object sender, MouseEventArgs e)
        {
			buttons.Location = e.Location;
			if( !flags.editing )
            {

                //this.Parent.Capture = true; 
                return;
            }

            if (current_page == null)
				return;

			int px = current_page.PARTOFX( e.Location.X );
			int py = current_page.PARTOFY( e.Location.Y );

			int dx = px - core_common.partX;
			int dy = py - core_common.partY;

			core_common.partX = px;
			core_common.partY = py;

			if( !flags.dragging && !flags.selecting && (flags.sizing_corner == corners.None ) )
			{
				if( ( current_control = current_page.ControlAt( core_common.partX, core_common.partY ) ) != null )
				{
					ContextMenuStrip = control_context_menu;
				}
				else
					ContextMenuStrip = my_context_menu;

				core_common.current_mouse_control = current_control;
				core_common.current_mouse_page = current_page;
			}


			if( buttons.l )
			{
				flags.moved = false;
				//return;
				if( flags.selecting )
				{
					//   e.Button
					int nx, ny, nw, nh;
					// kinda hard to explain why the subtract is -2...
					// but the cell which we start in is always selected,
					// and is one of the corners of the resulting rectangle.
					nx = _selection.X;
					if( (nw = (core_common.partX - _selection.X + 1)) <= 0 )
					{
						nx = _selection.X + (nw - 1);
						nw = -(nw - 2);
					}
					ny = _selection.Y;
					if( (nh = (core_common.partY - _selection.Y + 1)) <= 0 )
					{
						ny = _selection.Y + (nh - 1);
						nh = -(nh - 2);
					}
					//if( IsSelectionValidEx( nx, ny, NULL, NULL, nw, nh ) )
					{
						selection.X = nx;
						selection.Y = ny;
						selection.Width = nw;
						selection.Height = nh;
					}
					current_page.GetSelectedControls( selected, selection );

					//Log.log( WIDE("And now our selection is %d,%d %d,%d") );
					Refresh();
				}
				else if( flags.dragging )
				{
					if( dx == 0 && dy == 0 )
						return;
					if( selected.Count > 0 )
						foreach( ControlTracker c in selected )
						{
							c.grid_rect.X += dx;
							c.grid_rect.Y += dy;
							flags.moved_block = true;
						}
					else
					{
						current_control.grid_rect.X += dx;
						current_control.grid_rect.Y += dy;
						flags.moved = true;
					}
				}
				else if( flags.sizing_corner != corners.None )
				{
					if( dx == 0 && dy == 0 )
						return;
				retry:
					switch( flags.sizing_corner )
					{
					case corners.UpperLeft:
						if( ( current_control.grid_rect.Width - dx ) <= 0 )
						{
							flags.sizing_corner = corners.UpperRight;
							goto retry;
						}
						if( ( current_control.grid_rect.Height - dy ) <= 0 )
						{

							flags.sizing_corner = corners.LowerLeft;
							goto retry;
						}

						current_control.grid_rect.X += dx;
						current_control.grid_rect.Y += dy;
						current_control.grid_rect.Width -= dx;
						current_control.grid_rect.Height -= dy;
						flags.moved = true;

						break;
					case corners.UpperRight:
						if( ( current_control.grid_rect.Width + dx ) <= 0 )
						{
							flags.sizing_corner = corners.UpperLeft;
							goto retry;
						}
						if( ( current_control.grid_rect.Height - dy ) <= 0 )
						{
							flags.sizing_corner = corners.LowerRight;
							goto retry;
						}

						current_control.grid_rect.Y += dy;
						current_control.grid_rect.Width += dx;
						current_control.grid_rect.Height -= dy;
						flags.moved = true;
						break;
					case corners.LowerLeft:
						if( ( current_control.grid_rect.Width - dx ) <= 0 )
						{
							flags.sizing_corner = corners.LowerRight;
							goto retry;
						}
						if( ( current_control.grid_rect.Height + dy ) <= 0 )
						{
							flags.sizing_corner = corners.UpperLeft;
							goto retry;
						}

						current_control.grid_rect.X += dx;
						//current_control.grid_rect.Y += dy;
						current_control.grid_rect.Width -= dx;
						current_control.grid_rect.Height += dy;
						flags.moved = true;
						break;
					case corners.LowerRight:
						if( ( current_control.grid_rect.Width + dx ) <= 0 )
						{
							flags.sizing_corner = corners.LowerLeft;
							goto retry;
						}
						if( ( current_control.grid_rect.Height + dy ) <= 0 )
						{
							flags.sizing_corner = corners.UpperRight;
							goto retry;
						}

						current_control.grid_rect.Width += dx;
						current_control.grid_rect.Height += dy;
						flags.moved = true;
						break;
					}
				}
				else
				{
					if( current_control == null )
					{
						_selection.X = selection.X = core_common.partX;
						_selection.Y = selection.Y = core_common.partY;
						selection.Width = 1;
						selection.Height = 1;
						flags.selecting = true;
						Refresh();
					}
					else
					{
						flags.sizing_corner = corners.None;
						if( ( e.Location.X >= current_control.c.Left ) &&
							( e.Location.X <= current_control.c.Left + 20 ) &&
							( e.Location.Y >= current_control.c.Top ) &&
							( e.Location.Y <= current_control.c.Top + 20 ) )
							flags.sizing_corner = corners.UpperLeft;
						else if( ( e.Location.X >= current_control.c.Left ) &&
							( e.Location.X <= current_control.c.Left + 20 ) &&
							( e.Location.Y >= current_control.c.Top + current_control.c.Height - 20 ) &&
							( e.Location.Y <= current_control.c.Top + current_control.c.Height ) ) 
							flags.sizing_corner = corners.LowerLeft;
						else if( ( e.Location.X >= current_control.c.Left + current_control.c.Width - 20 ) &&
							( e.Location.X <= current_control.c.Left + current_control.c.Width ) &&
							( e.Location.Y >= current_control.c.Top  ) &&
							( e.Location.Y <= current_control.c.Top + 20 ) ) 
							flags.sizing_corner = corners.UpperRight;
						else if( ( e.Location.X >= current_control.c.Left + current_control.c.Width - 20 ) &&
							( e.Location.X <= current_control.c.Left + current_control.c.Width ) &&
							( e.Location.Y >= current_control.c.Top + current_control.c.Height - 20 ) &&
							( e.Location.Y <= current_control.c.Top + current_control.c.Height ) ) 
							flags.sizing_corner = corners.LowerRight;
						else
							flags.dragging = true;
						Refresh();
					}
				}

				if( flags.moved || flags.moved_block )
				{
					flags.moved = false;
					flags.moved_block = false;
					foreach( ControlTracker c in selected )
					{
						c.c.Location = new Point( current_page.PARTX( c.grid_rect.X )
							, current_page.PARTY( c.grid_rect.Y ) );
						c.c.Size = new Size( current_page.PARTW( c.grid_rect.X, c.grid_rect.Width )
							, current_page.PARTH( c.grid_rect.Y, c.grid_rect.Height ) );
					}
					current_control.c.Location = new Point( current_page.PARTX( current_control.grid_rect.X )
						, current_page.PARTY( current_control.grid_rect.Y ) );
					current_control.c.Size = new Size( current_page.PARTW( current_control.grid_rect.X, current_control.grid_rect.Width )
						, current_page.PARTH( current_control.grid_rect.Y, current_control.grid_rect.Height ) );
					Refresh();
				}
			}
			else
			{
				flags.sizing_corner = corners.None;
				flags.dragging = false;
				flags.selecting = false;
			}
			//e.Location.X, e.Location.Y;
		}

		protected override void OnPaintBackground( PaintEventArgs e )
		{
		// do nothing
			if( current_page == null )
				current_page = new page( this );
				if( BackgroundImage != null ) // guess we can let it paint the image...
			{
				e.Graphics.DrawImage( this.BackgroundImage, this.ClientRectangle
					, new RectangleF( 0, 0, this.BackgroundImage.Size.Width, this.BackgroundImage.Size.Height ), GraphicsUnit.Pixel
					 );

				//base.OnPaintBackground( e );
			}
			else
				e.Graphics.FillRectangle( new SolidBrush( current_page.background_color ), this.ClientRectangle );



			if( current_page.Count == 0 )
			{
				font_tracker ft = FontEditor.GetFontTracker( "Default" );

				SizeF size = ft.MeasureString( e.Graphics, "No Objects\nALT-V to Configure\nLeft click drag region\nRight click in region to add control", font_scale_x, font_scale_y );
				ft.DrawString( e.Graphics, "No Objects\nALT-V to Configure\nLeft click drag region\nRight click in region to add control"
								, new SolidBrush( Color.Azure )
								, new Point( (int)(size.Width / 2), (int)(size.Height / 2 ) )
								, font_scale_x, font_scale_y
									//, StringFormat.GenericTypographic
								);
			}
			else
			{
			}

            if (flags.editing)
            {
                // hazy green edit...
                Brush b = edit_background;
                Pen p = new Pen(Color.FromArgb(43, 255, 255, 255));
                Pen p2 = new Pen(Color.FromArgb(43, 0, 0, 0));
                // r is a global variable that determines scaling for parts.
                current_page.rect = this.ClientRectangle;

                e.Graphics.FillRectangle(b, this.ClientRectangle);


                {
                    int x, y;
					int del = 0;
					int nDraw, nLastDraw = 0;
                    for (x = 0; x <= current_page.partsX; x++)
                    {
						nDraw = current_page.PARTX( x );

						del += nDraw - nLastDraw;
						if( del < 10 )
							continue;
						del = 0;
						nLastDraw = nDraw;
                        e.Graphics.DrawLine(p
                             , nDraw, 0
							 , nDraw, current_page.PARTY( current_page.partsY ) );
						e.Graphics.DrawLine( p2, nDraw + 1, 0
							 , nDraw + 1, current_page.PARTY( current_page.partsY ) );
                    }
					del = 0;
					nLastDraw = 0;
                    for (y = 0; y <= current_page.partsY; y++)
                    {
						nDraw = current_page.PARTY( y );

						del += nDraw - nLastDraw;
						if( del < 10 )
							continue;
						del = 0;
						nLastDraw = nDraw;
						e.Graphics.DrawLine( p, 0, nDraw
							 , current_page.PARTX( current_page.partsX ), nDraw );
						e.Graphics.DrawLine( p2, 0, nDraw + 1
							 , current_page.PARTX( current_page.partsX ), nDraw + 1 );
                    }

					Font c_label = FontEditor.GetFontTracker( "Default Fixed(Fixed)", "Lucida Console", 10 );
                    foreach (ControlTracker c in current_page)
					{
						Brush selected_brush = new SolidBrush( Color.FromArgb( 80, 0, 128, 0 ) );
						if( c.selected )
							selected_brush = selected_control;
						else
							selected_brush = control_edit;
						//lprintf( WIDE("Our fancy coords could be %d,%d %d,%d"), PARTX( selection.x ), PARTY( selection.y )
						//		 , PARTW( selection.x, selection.w )
						//		 , PARTH( selection.y, selection.h ));
						// and to look really pretty select the outer edge on the bottom, also
						x = current_page.PARTX( c.grid_rect.X );
						y = current_page.PARTY( c.grid_rect.Y );
						int w = current_page.PARTW( c.grid_rect.X, c.grid_rect.Width );
						int h = current_page.PARTH( c.grid_rect.Y, c.grid_rect.Height );
						//e.Graphics.FillRectangle(selected_brush, rect);
						e.Graphics.FillRectangle( selected_brush, x, y, w, h );
						{
							selected_brush = new SolidBrush( Color.FromArgb( 84, 128, 0, 0 ) );
							e.Graphics.FillRectangle( selected_brush
								, x
								, y
								, 20
								, 20
								);
							e.Graphics.FillRectangle( selected_brush
								, x + w - 20
								, y
								, 20
								, 20
								);
							e.Graphics.FillRectangle( selected_brush
								, x
								, y + h - 20
								, 20
								, 20
								);
							e.Graphics.FillRectangle( selected_brush
								, x + w - 20
								, y + h - 20
								, 20
								, 20
								);
							e.Graphics.DrawString( c.o.ToString(), c_label, Brushes.White, new PointF( x, y ) );
							e.Graphics.DrawString( c.grid_rect.ToString(), c_label, Brushes.White, new PointF( x, y + 12 ) );
						}
					}
                    if (flags.selecting)
                    {
                        Brush selected_brush = new SolidBrush(Color.FromArgb(170, 0, 0, Color.Blue.B));
                        //lprintf( WIDE("Our fancy coords could be %d,%d %d,%d"), PARTX( selection.x ), PARTY( selection.y )
                        //		 , PARTW( selection.x, selection.w )
                        //		 , PARTH( selection.y, selection.h ));
                        // and to look really pretty select the outer edge on the bottom, also
                        e.Graphics.FillRectangle(selected_brush, current_page.PARTX(selection.X), current_page.PARTY(selection.Y)
                             , current_page.PARTW(selection.X, selection.Width) + 1
                             , current_page.PARTH(selection.Y, selection.Height) + 1
                             );
                    }

                }

            }
        }
		private void CanvasButtonDown( object sender, MouseEventArgs e )
		{
			buttons.Location = e.Location;
			if( !flags.editing )
                return;

			switch( e.Button )
			{
			case MouseButtons.Left:
				buttons.l = true;
				break;
			case MouseButtons.Right:
				buttons.r = true;
				break;
			case MouseButtons.Middle:
				buttons.m = true;
				break;
			}

		}

		private void CanvasButtonUp( object sender, MouseEventArgs e )
		{
			buttons.Location = e.Location;
			if( !flags.editing )
                return;
			switch( e.Button )
			{
			case MouseButtons.Left:
				if( buttons.l )
				{
					buttons.l = false;
					buttons.l_delta_up = true;
				}

				break;
			case MouseButtons.Right:
				if( buttons.r )
				{
					buttons.r = false;
					buttons.r_delta_up = true;
				}
				break;
			case MouseButtons.Middle:
				buttons.m = false;
				break;
			}
		}

		public void SavePages( XmlWriter w )
		{
			foreach( page p in pages )
			{
				w.WriteStartElement( "page" );
				p.save( w );
				w.WriteEndElement();
				w.WriteRaw( "\r\n" );
			}
		}
        public void SaveConfig()
        {
            SaveConfig( core_common.ConfigName );
        }
		public void SaveConfig(String filename)
		{
			Control p;
			Canvas top_canvas = this;
			for( p = this.Parent; p != null; p = p.Parent )
			{
				top_canvas = p as Canvas;
			}
			if( top_canvas != null )
			{
				// go to the top level and save there only.
				top_canvas.SaveConfig();
			}
			else
			{
				//xd = new XmlDocument(nt );
				filename = core_common.ConfigName;
				core_common.AutoBackup( filename );
				XmlWriter w = XmlWriter.Create( filename );
				w.WriteStartDocument( true );
				w.WriteDocType( "xperdex.configuration", null, null, null );
				//w.write
				w.WriteRaw( "\r\n" );
				w.WriteStartElement( "xperdex" );
				w.WriteRaw( "\r\n" );
				core_common.Save( w );
				((IReflectorPersistance)this).Save( w );
				// xperdex wrapper so we have one root.  local is it's own section.
				w.WriteEndElement();
				w.Close();
			}
		}


        public void LoadConfig(String file)
        {
			flags.loading = true;
			core_common.loading_canvas = this;
			try
			{
				XmlDocument xd = new XmlDocument();
				if( !System.IO.File.Exists( core_common.ConfigName ) )
					return;
				xd.Load( core_common.ConfigName );
				// the xd loader ends up with a full pathname with successful load
				// grab this so we can save to the same file.
				core_common.ConfigName = xd.BaseURI.Substring( 8 );

				XPathNavigator xn = xd.CreateNavigator();
				//XPathNavigator xn2 = xn.CreateNavigator();
				xn.MoveToFirst();
				xn.MoveToFirstChild();
				if( xn.NodeType == XPathNodeType.Element )
				{
                    if (String.Compare(xn.Name, "xperdex" ) == 0)
					{
						bool okay;
						pages.Clear();

						for( okay = xn.MoveToFirstChild(); okay; okay = xn.MoveToNext() )
						{
							//Log.log( "Handling node " + xn.Name );
							// local, being static cannot implement persistance...
							bool loaded = core_common.Load( xn );
							if( !loaded )
								foreach( object plugin in core_common.persistant_plugins )
								{
									// for all plugins that were loaded, if they have peristance
									// allow them to load...
									IReflectorPersistance persis = plugin as IReflectorPersistance;
									if( persis != null )
									{
										loaded = persis.Load( xn );
										if( loaded )
											break;
									}
								}
							if( !loaded )
								// should be at a place to handle canvas here...
								loaded = ((IReflectorPersistance)this).Load( xn );
							if( !loaded )
							{
								Log.log( "Element ignored:" + xn.Name + "=" + xn.Value );
							}
							//Log.log( "Done handling node " + xn.Name );
						}

						// parsing might totally fail, causing no data...
						// create a default page if one doesn't exist.
						if( pages.Count == 0 )
						{
							page new_page = new page( this );	
							change_page_context_menu.Items.Add( new ToolStripMenuItem( new_page.Name ) );
						}
						//current_page = pages[0];

						// all pages should be loaded from the XML from here..
						xn.MoveToParent();
						// should be at xperdex again.
					}
				}
			}
			catch( Exception e )
			{
				//e.Data.Values
				//System.Environment.StackTrace;
				//e.StackTrace;
				//Process.GetCurrentProcess().
				//Thread.CurrentContext
				//Thread.CurrentThread.
				if( e.InnerException != null )
					Log.log( "XML Parsing faulted... " + e.InnerException.Message );

				Log.log( "XML Parsing faulted... " + e.Message );
			}
			core_common.loading_canvas = null;

			flags.loading = false;

			// this should trigger security tag discovery.
			if( pages.Count == 0 )
			{
				// new page adds it to the canvas List<pages> 
				current_page = new page( this );
			}
			else
				current_page = pages[0];

			foreach( IReflectorPlugin irp in core_common.persistant_plugins )
			{
				try
				{
					irp.FinishInit();
				}
				catch( Exception ex )
				{
					Console.WriteLine( ex.Message );
				}
			}
		}

		public void LoadConfig()
		{
			LoadConfig( core_common.ConfigName );
			osalot.InvokeFinishInit();
        }

        //static bool alt;
#if asdf
        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
        }
        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            base.OnKeyPress(e);
        }
        protected override bool ProcessKeyMessage(ref Message m)
        {

            return base.ProcessKeyMessage(ref m);
        }
#endif

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
		{
            //return false;
            //return Parent.ProcessCmdKey(ref msg, keyData);
            //return false;
            if (msg.Msg == 0x104) // WMSYSKEYDOWN
            {
                if (keyData == (Keys.Alt | Keys.ShiftKey | Keys.RButton))
                {
                    //alt = true;
                    return true;
                }
            }
            else if (msg.Msg == 0x100) // KEYDOWN
            {
                if (keyData == Keys.Escape)
                {
                    EndEdit();
                    return true;
                }
            }

        //KeyDown += new KeyEventHandler(Canvas_KeyDown);
			switch( keyData )
			{
			case Keys.B | Keys.Alt:
				if( flags.active )
				{
					StartEdit();
					return true;
				}
				break;
			case Keys.V | Keys.Alt:
				if( flags.active )
				{
					StartEdit();
					return true;
				}
				break;
			case Keys.C | Keys.Alt | Keys.ShiftKey:
				if( flags.active )
				{
					StartEdit();
					return true;
				}
				break;
			/* there will be no Alt-Control keys for YOU, sir */
			case Keys.C | Keys.Alt | Keys.Control:
				if( flags.active )
				{
					StartEdit();
					return true;
				}
				break;
			case Keys.S | Keys.Alt | Keys.Control:
				break;
			case Keys.Escape:
				if( flags.active )
				{
					EndEdit();
					return true;
				}
				break;
				//return true;
			}
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void CanvasLeave( object sender, EventArgs e )
		{
//			flags.active = false;
			//Console.WriteLine("Left");
		}

		private void CanvasEnter( object sender, EventArgs e )
		{
			flags.active = true;

		}

		#region IReflectorPersistance Members

		bool IReflectorPersistance.Load( XPathNavigator r )
		{
			if( r.NodeType == XPathNodeType.Element )
			{
				string page_title = null;
				switch( r.Name )
				{
				case "page":
					//bool okay;
					bool everokay = false;
					bool okay;
					//page p = new page(canvas);
					for( okay = r.MoveToFirstAttribute(); okay; okay = r.MoveToNextAttribute() )
					{
						everokay = true;
						switch( r.Name )
						{
						case "title":
							page_title = r.Value;
							break;
						}
					}
					if( everokay )
						r.MoveToParent();
					
					page p;
					if( page_title != null )
					{
						findpage = page_title;
						p = FindPage( page_title );
						if( p == null )
							p = new page( this, page_title );
					}
					else
						p = new page( this, null );


					if( !p.Load( r ) )
					{
						p = null;
					}
					else
					{
						// allow controls on page that use fonts to update their scaling to current.
						p.SetScale( font_scale_x, font_scale_y );
						//p.Hide();
						//current_page = p;
					}
					//}
					return true;
				}
			}
			return false;
		}

		void IReflectorPersistance.Save( XmlWriter w )
		{
			if( pages != null )
			{
				foreach( page p in pages )
				{
					p.save( w );
				}
			}
		}

		void IReflectorPersistance.Properties()
		{
			//throw new Exception( "The method or operation is not implemented." );
		}

		#endregion


		private void Canvas_DragOver( object sender, DragEventArgs e )
		{
			String[] formats = e.Data.GetFormats();
			if( e.Data.GetDataPresent( "FileDrop" ) )
			{
				e.Effect = DragDropEffects.Link;
			}
			else
			{
				Log.log( "Rejecting drop..." );
				e.Effect = DragDropEffects.None;
			}
		}

		private void Canvas_DragDrop( object sender, DragEventArgs e )
		{
			//e.Effect 
			string[] s = e.Data.GetData( "FileDrop" ) as string[];
			foreach( String file in s )
			{
				bool success = false;
						
				core_common.partX = current_page.PARTOFX( e.X - this.Location.X - this.Parent.Location.X );
				core_common.partY = current_page.PARTOFY( e.Y - this.Location.Y - this.Parent.Location.Y );
				if( ( current_control = current_page.ControlAt( core_common.partX, core_common.partY ) ) != null )
				{
					IReflectorDropFileTarget dt = current_control.o as IReflectorDropFileTarget;
					if( dt != null )
						success = dt.Drop( this, file, this.buttons.Location.X, this.buttons.Location.Y );
					if( !success && !current_control.real )
					{
						dt = current_control.c as IReflectorDropFileTarget;
						if( dt != null )
							success = dt.Drop( this, file, this.buttons.Location.X, this.buttons.Location.Y );
					}
				}
#if what_do_with_default_images
				if( !success )
				try
				{
					Image image = Image.FromFile( file );
					success = true;
				}
				catch( Exception ex )
				{
					Log.log( ex.Message );
				}
#endif
				if( !success )
				foreach( IReflectorPluginDropFileTarget target in core_common.drop_acceptors )
				{
					try
					{
						if( target.Drop( sender, file, this.buttons.Location.X, this.buttons.Location.Y ) )
						{
							success = true;
							break;
						}
					}
					catch
					{

					}
				}

				//Log.log( file );
			}

#if asdfasdf
			MemoryStream ms = e.Data.GetData( "InShellDragLoop" ) as MemoryStream;
			byte[] buffer = new byte[ms.Length];
			ms.Read( buffer, 0, buffer.Length );
			String[] formats = e.Data.GetFormats();
			foreach( string s2 in formats )
			{
				object o = e.Data.GetData( s2 );
			}
#endif
			//e.Data
		}

		public delegate void OnScaleChange();
		public event OnScaleChange ScaleChanged;

		public Fraction font_scale_x;
		public Fraction font_scale_y;

		Size target_size = new Size( 1024, 768 );
		public Size TargetSize
		{
			get
			{
				return target_size;
			}
			set
			{
				target_size = value;
				Canvas_ClientSizeChanged( this, null );
			}
		}

		internal void Canvas_ClientSizeChanged( object sender, EventArgs e )
		{
			if( Width == 0 || Height == 0 )
				return;
			font_scale_x = new Fraction( Width, target_size.Width );
			font_scale_y = new Fraction( Height, target_size.Height );

			Graphics g = this.CreateGraphics();
			if( current_page != null )
				g.Clear( current_page.background_color );

			foreach( page p in pages )
			{
				p.rect.Width = this.Size.Width;
				p.rect.Height = this.Size.Height;

				// send the scale first
				p.SetScale( font_scale_x, font_scale_y );
				p.Resize();
			}

			if( ScaleChanged != null )
				ScaleChanged();
		}

		public void SetScale()
		{
			foreach( page check_page in pages )
				check_page.SetScale( font_scale_x, font_scale_y );
		}

		public void Canvas_LocationChanged( object sender, EventArgs e )
		{
			if( this.current_page != null )
			{
				foreach( ControlTracker c in this.current_page )
				{
					IReflectorWindow irw = c.o as IReflectorWindow;
					if( irw != null )
						irw.Move();
				}
			}
		}

		void Canvas_ControlAdded( object sender, ControlEventArgs e )
		{
			ListBox listbox = e.Control as ListBox;
			// have to set the item height to the scaled height... so that mouse clicking works.
			if( listbox != null )
			{

				listbox.ItemHeight = ( (int)( (float)listbox.Font.Height / this.font_scale_y.ToFloat() ) );
			}
		}
	}
}
