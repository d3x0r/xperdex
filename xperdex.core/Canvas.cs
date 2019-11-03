using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Xml.XPath;
//using System.Windows.
//using My.Computer;
//using xperdex.loader;
using xperdex.classes;
using System.Diagnostics;
using System.Threading;
using System.IO;
namespace xperdex.core
{
    //UserControl
	public partial class Canvas: PSI_Control , IReflectorPersistance
	{
		// actual interface to this canavas object 
		// may be a child.
		IReflectorCanvas ICanvas;
		public List<page> pages;

		//Font defaultFont;
		
		page _current_page;

		public page current_page
		{
			set
			{
				if( _current_page != null )
					_current_page.Hide();

				if( (_current_page = value) != null )
				{
					if( !flags.loading )
					{
						// don't have to show page when loading...
						_current_page.Show();
						this.BackgroundImage = _current_page.background_image;
						this.BackColor = current_page.background_color;
						this.Refresh();
					}
				}
			
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

		public page FindPage( string name )
		{
			
			lock( syncroot )
			{
				findpage = name;
				return pages.Find( FindPageThing );
			}
		}


		Rectangle scaledr;
		Rectangle _selection;
		public Rectangle selection;
		public canvas_flags flags;
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
				cp.Style &= ~0x02000000; // turn off clip children(?) might be clip_siblings
				return cp;
			}
		}

		void EndEdit()
		{
			if( flags.editing )
			{
				flags.editing = false;
				foreach( IReflectorPluginDropFileTarget acceptor in local.drop_acceptors )
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
				foreach( IReflectorPluginDropFileTarget acceptor in local.drop_acceptors )
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
			local.clone_control = current_control;
			IReflectorCopyPaste copy = local.clone_control.o as IReflectorCopyPaste;
			if( copy != null )
				copy.OnClone();
			copy = local.clone_control.c as IReflectorCopyPaste;
			if( copy != null )
				copy.OnClone();
		}

		ControlTracker current_control;

		static void PropertyClick( Object s, EventArgs e )
		{
			bool did_property = false;
			if( local.current_mouse_control != null )
			{
				IReflectorPersistance pc = local.current_mouse_control.o as IReflectorPersistance;
				if( pc != null )
				{
					pc.Properties();
					did_property = true;
				}
				if( !did_property )
				{
					pc = local.current_mouse_control.c as IReflectorPersistance;
					if( pc != null )
					{
						pc.Properties();
						did_property = true;
					}
				}
			}
			if( !did_property )
			{
				Control c = local.current_mouse_control.o as Control;
				if( c != null )
				{
					new EditControl( c ).ShowDialog();
					did_property = true;
				}
			}
			if( !did_property )
			{
				if( local.current_mouse_page != null )
				{
					local.current_mouse_page.PropertyClick();
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
			if( local.clone_control != null )
			{
				Rectangle r = local.clone_control.grid_rect;
				r.X = local.partX;
				r.Y = local.partY;
				ControlTracker ct = current_page.MakeControl( local.clone_control.Type, local.clone_control.i, r );
				IReflectorCopyPaste copy = ct.o as IReflectorCopyPaste;
				if( copy != null )
					copy.OnPaste( local.clone_control.o );
				copy = ct.c as IReflectorCopyPaste;
				if( copy != null )
					copy.OnPaste( local.clone_control.c );
			}
		}

		void MakeAPage( Object s, EventArgs e )
		{
			// add the page to pages list
			// also adds page to change page menu
			current_page = new page( this );
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
					_my_context_menu.Items.Add( new ToolStripLabel( "Create Clone", null, false, CreateAClone ) );
					ToolStripMenuItem label;
					_my_context_menu.Items.Add( label = new ToolStripMenuItem( "Change Page" ) );
					label.DropDown = change_page_context_menu;

					if( local.plugin_drop.GetCurrentParent() != null )
						local.plugin_drop.GetCurrentParent().Dispose();
					_my_context_menu.Items.Add( local.plugin_drop );
					if( local.other_drop.GetCurrentParent() != null )
						local.other_drop.GetCurrentParent().Dispose();
					_my_context_menu.Items.Add( local.other_drop );
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

		void InitCanvas( IReflectorCanvas i )
		{
			StaticInit();
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

		public enum corners
		{
			// corners.None means not sizing by a corner...
			None, UpperLeft, UpperRight, LowerLeft,  LowerRight
		}

		public class canvas_flags
		{
			public bool editing;
			public bool active;
			public bool selecting;
			public bool loading;
			public bool dragging;
			public bool moved;
			public corners sizing_corner;
		}

		public class buttons_class
		{

			public Point Location;
			public bool l;
			public bool r;
			public bool m;
			public bool l_delta_down;
			public bool r_delta_down;
			public bool m_delta_down;
			public bool l_delta_up;
			public bool r_delta_up;
			public bool m_delta_up;

			public buttons_class()
			{
				l = false;
				r = false;
				m = false;
			}
		};
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

			int dx = px - local.partX;
			int dy = py - local.partY;

			local.partX = px;
			local.partY = py;

			if( !flags.dragging && !flags.selecting && (flags.sizing_corner == corners.None ) )
			{
				if( ( current_control = current_page.ControlAt( local.partX, local.partY ) ) != null )
				{
					ContextMenuStrip = control_context_menu;
				}
				else
					ContextMenuStrip = my_context_menu;
				local.current_mouse_control = current_control;
				local.current_mouse_page = current_page;
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
					if( (nw = (local.partX - _selection.X + 1)) <= 0 )
					{
						nx = _selection.X + (nw - 1);
						nw = -(nw - 2);
					}
					ny = _selection.Y;
					if( (nh = (local.partY - _selection.Y + 1)) <= 0 )
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
					//lprintf( WIDE("And now our selection is %d,%d %d,%d") );
					Refresh();
				}
				else if( flags.dragging )
				{
					if( dx == 0 && dy == 0 )
						return;
					current_control.grid_rect.X += dx;
					current_control.grid_rect.Y += dy;
					flags.moved = true;
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
						_selection.X = selection.X = local.partX;
						_selection.Y = selection.Y = local.partY;
						selection.Width = 1;
						selection.Height = 1;
						flags.selecting = true;
						Refresh();
					}
					else
					{
						int cx = local.partX - current_control.grid_rect.X;
						int cy = local.partY - current_control.grid_rect.Y;

						flags.sizing_corner = corners.None;

						if( cx == 0 && cy == 0 )
							flags.sizing_corner = corners.UpperLeft;
						else if( cx == 0 && cy == ( current_control.grid_rect.Height - 1 ) )
							flags.sizing_corner = corners.LowerLeft;
						else if( cy == 0 && cx == ( current_control.grid_rect.Width - 1 ) )
							flags.sizing_corner = corners.UpperRight;
						else if( cx == ( current_control.grid_rect.Width - 1 ) &&
							cy == ( current_control.grid_rect.Height - 1 ) )
							flags.sizing_corner = corners.LowerRight;
						else
							flags.dragging = true;
					}
				}

				if( flags.moved )
				{
					flags.moved = false;
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
			if( BackgroundImage != null ) // guess we can let it paint the image...
			{
				e.Graphics.DrawImage( this.BackgroundImage, this.ClientRectangle
					, new RectangleF( 0, 0, this.BackgroundImage.Size.Width, this.BackgroundImage.Size.Height ), GraphicsUnit.Pixel
					 );

				base.OnPaintBackground( e );
			}

            if (current_page == null)
                current_page = new page(this);

            if (current_page.Count == 0)
            {
				font_tracker ft = Xperdex.GetFontTracker( "Default" );				
                ft.DrawString(e.Graphics, "No Objects\nALT-V to Configure\nLeft click drag region\nRight click in region to add control"
				, new SolidBrush(Color.Azure)
				, new Point(0, 0)
				, font_scale_x, font_scale_y
				//, StringFormat.GenericTypographic
				);
            }

            if (flags.editing)
            {
                // hazy green edit...
                Brush b = new SolidBrush(Color.FromArgb(32, 0, 84, 84));
                Pen p = new Pen(Color.FromArgb(43, 255, 255, 255));
                Pen p2 = new Pen(Color.FromArgb(43, 0, 0, 0));
                // r is a global variable that determines scaling for parts.
                current_page.rect = this.ClientRectangle;

                e.Graphics.FillRectangle(b, this.ClientRectangle);


                {
                    int x, y;

                    for (x = 0; x <= current_page.partsX; x++)
                    {
                        e.Graphics.DrawLine(p
                             , current_page.PARTX(x), 0
                             , current_page.PARTX(x), current_page.PARTY(current_page.partsY));
                        e.Graphics.DrawLine(p2, current_page.PARTX(x) + 1, 0
                             , current_page.PARTX(x) + 1, current_page.PARTY(current_page.partsY));
                    }

                    for (y = 0; y <= current_page.partsY; y++)
                    {
                        e.Graphics.DrawLine(p, 0, current_page.PARTY(y)
                             , current_page.PARTX(current_page.partsX), current_page.PARTY(y));
                        e.Graphics.DrawLine(p2, 0, current_page.PARTY(y) + 1
                             , current_page.PARTX(current_page.partsX), current_page.PARTY(y) + 1);
                    }

					Font c_label = Xperdex.GetFontTracker( "Default Fixed(Fixed)", "Lucida Console", 10 );
                    foreach (ControlTracker c in current_page)
					{
						Brush selected_brush = new SolidBrush( Color.FromArgb( 80, 0, 128, 0 ) );
						//lprintf( WIDE("Our fancy coords could be %d,%d %d,%d"), PARTX( selection.x ), PARTY( selection.y )
						//		 , PARTW( selection.x, selection.w )
						//		 , PARTH( selection.y, selection.h ));
						// and to look really pretty select the outer edge on the bottom, also

						//e.Graphics.FillRectangle(selected_brush, rect);
						e.Graphics.FillRectangle( selected_brush, current_page.PARTX( c.grid_rect.X ), current_page.PARTY( c.grid_rect.Y )
							 , current_page.PARTW( c.grid_rect.X, c.grid_rect.Width ) + 1
							 , current_page.PARTH( c.grid_rect.Y, c.grid_rect.Height ) + 1
							 );
						{
							selected_brush = new SolidBrush( Color.FromArgb( 84, 128, 0, 0 ) );
							e.Graphics.FillRectangle( selected_brush
								, current_page.PARTX( c.grid_rect.X )
								, current_page.PARTY( c.grid_rect.Y )
								, current_page.PARTW( c.grid_rect.X, 1 ) + 1
								, current_page.PARTH( c.grid_rect.Y, 1 ) + 1
								);
							e.Graphics.FillRectangle( selected_brush
								, current_page.PARTX( c.grid_rect.Right - 1 )
								, current_page.PARTY( c.grid_rect.Top )
								, current_page.PARTW( c.grid_rect.Right - 1, 1 ) + 1
								, current_page.PARTH( c.grid_rect.Top, 1 ) + 1
								);
							e.Graphics.FillRectangle( selected_brush
								, current_page.PARTX( c.grid_rect.X )
								, current_page.PARTY( c.grid_rect.Bottom - 1 )
								, current_page.PARTW( c.grid_rect.X, 1 ) + 1
								, current_page.PARTH( c.grid_rect.Bottom - 1, 1 ) + 1
								);
							e.Graphics.FillRectangle( selected_brush
								, current_page.PARTX( c.grid_rect.Right - 1 )
								, current_page.PARTY( c.grid_rect.Bottom -1  )
								, current_page.PARTW( c.grid_rect.Right -1, 1 ) + 1
								, current_page.PARTH( c.grid_rect.Bottom -1 , 1 ) + 1
								);
							e.Graphics.DrawString( c.o.ToString(), c_label, Brushes.White, new PointF( c.c.Location.X, c.c.Location.Y ) );
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
            SaveConfig( local.ConfigName );
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
				filename = local.ConfigName;
				local.AutoBackup( filename );
				XmlWriter w = XmlWriter.Create( filename );
				w.WriteStartDocument( true );
				w.WriteDocType( "xperdex.configuration", null, null, null );
				//w.write
				w.WriteRaw( "\r\n" );
				w.WriteStartElement( "xperdex" );
				w.WriteRaw( "\r\n" );
				local.Save( w );
				((IReflectorPersistance)this).Save( w );
				// xperdex wrapper so we have one root.  local is it's own section.
				w.WriteEndElement();
				w.Close();
			}
		}


        public void LoadConfig(String file)
        {
			flags.loading = true;
			local.loading_canvas = this;
			try
			{
				XmlDocument xd = new XmlDocument();
				if( !System.IO.File.Exists( local.ConfigName ) )
					return;
				xd.Load( local.ConfigName );
				// the xd loader ends up with a full pathname with successful load
				// grab this so we can save to the same file.
				local.ConfigName = xd.BaseURI.Substring( 8 );

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
						current_page = new page( this );
						first_page = true;


						//xn.MoveToFirstChild();
						for( okay = xn.MoveToFirstChild(); okay; okay = xn.MoveToNext() )
						{
							// local, being static cannot implement persistance...
							bool loaded = local.Load( xn );
							if( !loaded )
								foreach( object plugin in local.persistant_plugins )
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
								Console.WriteLine( "Attribute ignored..." );
							}
						}

						// parsing might totally fail, causing no data...
						// create a default page if one doesn't exist.
						if( pages.Count == 0 )
						{
							page new_page;
							pages.Add( new_page = new page( this ) );
							change_page_context_menu.Items.Add( new ToolStripMenuItem( new_page.Name ) );
						}
						current_page = pages[0];

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
				Log.log( "XML Parsing faulted... "+ e.Message );
			}
			local.loading_canvas = null;

			flags.loading = false;
			if( pages.Count == 0 )
				current_page = new page( this );
			else
				current_page = pages[0];

			foreach( IReflectorPlugin irp in local.persistant_plugins )
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
			LoadConfig( local.ConfigName );
        }

        static bool alt;
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
                    alt = true;
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

		internal void Canvas_SizeChanged( object sender, EventArgs e )
		{
			foreach( page p in pages )
			{
				p.rect.Width = this.Size.Width;
				p.rect.Height = this.Size.Height;

				p.Resize();
			}
		}

		#region IReflectorPersistance Members

		bool first_page;
		bool IReflectorPersistance.Load( XPathNavigator r )
		{
			//XmlDocument xd = new XmlDocument();
			//XmlNode xn = xd.ReadNode(r);
			//r.ReadEl


			if( r.NodeType == XPathNodeType.Element )
			//if (r.IsStartElement())
			{
				switch( r.Name )
				{
				case "page":
					//bool okay;
					page p;
					if( first_page )
					{
						first_page = false;
						p = pages[0];
					}
					else
						p = new page( this );
					if( !p.Load( r ) )
					{
						p = null;
					}
					else
					{
						p.Hide();
						current_page = p;
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
					w.WriteStartElement( "page" );
					p.save( w );
					w.WriteEndElement();
					w.WriteRaw( "\r\n" );
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
						
				local.partX = current_page.PARTOFX( e.X - this.Location.X - this.Parent.Location.X );
				local.partY = current_page.PARTOFY( e.Y - this.Location.Y - this.Parent.Location.Y );
				if( ( current_control = current_page.ControlAt( local.partX, local.partY ) ) != null )
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
				foreach( IReflectorPluginDropFileTarget target in local.drop_acceptors )
				{
					try
					{
						if( target.Drop( sender, file, this.buttons.Location.X, this.buttons.Location.Y ) )
						{
							success = true;
							break;
						}
					}
					catch( Exception ex )
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
		
			
		private void Canvas_ClientSizeChanged( object sender, EventArgs e )
		{
#if look_at_font_families
			FontFamily[] families = FontFamily.Families;
			foreach( FontFamily f in families )
			{
				//Log.log( f.Name );
			}
#endif
			font_scale_x = new Fraction( Width, 1024 );
			font_scale_y = new Fraction( Height, 768 );
			if( ScaleChanged != null )
				ScaleChanged();


			font_tracker default_font = Xperdex.GetFontTracker( "Default" );
			// some 3/4 aspect ratio... the font scale is based against this... so we'd have double applied scaling
			// to the default font.
			SizeF target_size = new SizeF( 1024 / 40, 768 / 20 );
			int height = (int)target_size.Height;
			Font NewFont;
			Graphics g = this.CreateGraphics();
			if( current_page != null )
				g.Clear( current_page.background_color );
			NewFont = new Font( "Lucida Console", height, GraphicsUnit.Pixel );
			default_font.f = NewFont;
		}

		internal void Canvas_LocationChanged( object sender, EventArgs e )
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
