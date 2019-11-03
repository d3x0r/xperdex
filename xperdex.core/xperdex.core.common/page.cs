using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Xml;
using System.Xml.XPath;
//using xperdex.loader;
using xperdex.classes;
using xperdex.core.interfaces;
using xperdex.gui;
using xperdex.core.common;

namespace xperdex.core
{
	public class page: List<ControlTracker>
	{
		public Canvas canvas;
		//public string Name; // used or goto page, and for selecting pages.
		public string background_name;
		public Image background_image;
		public Color background_color;
		public int partsX;
		public int partsY;
		public Rectangle rect;
		private string title;
		public page PreviousPage;
		public List<IReflectorSecurity> security_tags; // security objects which have been attached to this object.
		public string Name
		{
			get
			{
				return title;
			}
			set
			{
				title = value;
			}
		}


		void ChangePage( object sender, EventArgs args )
		{
			ToolStripMenuItem tsmi = (sender as ToolStripMenuItem);
			page newpage = canvas.FindPage( tsmi.Text );
			if( newpage != null )
			{
				canvas.current_page = newpage;
			}
		}

		ToolStripMenuItem menu_item;																		

		void init_page( Canvas canvas, string title )
		{
			if( title == null || title.Length == 0 )
				title = "Page " + Convert.ToString( canvas.pages.Count );

			this.canvas = canvas;
			partsX = 40;
			partsY = 40;
			this.title = title;
			background_color = Color.Transparent;
			background_name = "sky.jpg";
			if( System.IO.File.Exists( background_name ) )
				background_image = Image.FromFile( background_name );
			else
				background_image = null;
			canvas.pages.Add( this );
			menu_item = new ToolStripMenuItem( this.Name, null, ChangePage );
			canvas.change_page_context_menu.Items.Add( menu_item );
			security_tags = new List<IReflectorSecurity>();
		}

		public page( Canvas canvas, string title )
		{
			init_page( canvas, title );
		}
		public page( Canvas canvas )
		{
			init_page( canvas, null );
		}

		public override string ToString()
		{
			return Name;
			//return base.ToString();
		}
		~page()
		{
			this.canvas.pages.Remove( this );
			if( this.canvas.current_page == this )
				if( this.canvas.pages.Count > 0 )
					this.canvas.current_page = this.canvas.pages[0];
				else
					Application.Exit();
			Clear(); // just make sure that we get rid of control trackers?
			canvas.pages.Remove( this );
			this.canvas = null;
		}
		internal void Resize()
		{
			foreach( ControlTracker c in this )
			{
				Rectangle where =  //this.GetScaledBounds(
						  new Rectangle( PARTX( c.grid_rect.X ), PARTY( c.grid_rect.Y )
						  , PARTW( c.grid_rect.X, c.grid_rect.Width ), PARTH( c.grid_rect.Y, c.grid_rect.Height ) )
					 ;

				c.c.Location = where.Location;
				c.c.Size = where.Size;

				IReflectorWindow irw = c.o as IReflectorWindow;
				if( irw != null )
					irw.Move();
			}

		}
		internal int PARTX( int part )
		{
			return (rect.Width) * part / partsX;
		}
		internal int PARTY( int part )
		{
			return (rect.Height) * part / partsY;
		}

		internal int PARTOFX( float coord )
		{
			return (int)(coord * partsX / (rect.Width));
		}
		internal int PARTOFY( float coord )
		{
			return (int)(coord * partsY / (rect.Height));
		}
		internal int PARTW( int from, int parts )
		{
			return (rect.Width * (from + parts)) / partsX - (rect.Width * (from)) / partsX;
		}
		internal int PARTH( int from, int parts )
		{
			return (rect.Height * (from + parts)) / partsY - (rect.Height * (from)) / partsY;
		}


		int UpdateGraphicsTransform()
		{
			return 0;
		}
		int ClearGraphicsTransform()
		{
			return 0;
		}

#if this_wasnt_a_bad_idea
		public class ControlOverload : Control
		{
			protected override void OnPaint( PaintEventArgs e )
			{
				//osalot.BeginControlPaint( e );
				base.OnPaint( e );
				//osalot.EndControlPaint( e );
			}
		}
#endif
		public void SetScale( Fraction font_scale_x, Fraction font_scale_y )
		{
			foreach( ControlTracker ct in this )
			{
				IReflectorScale scalable = ct.c as IReflectorScale;

				if( scalable == null )
					scalable = ct.o as IReflectorScale;
				if( scalable != null )
				{
					scalable.SetScale( font_scale_x, font_scale_y );
				}
			}

		}

		/// <summary>
		/// Create a control somwehere on the canvas...
		/// </summary>
		/// <param name="t">Type of the control to create ( should be either a Control type... )</param>
		/// <param name="i">(IReflectorCanvas, IReflectorButton, null...</param>
		/// <param name="rectangle">rectangle in canvas corrdinates</param>
		/// <returns>The control tracker that represents this control</returns>
		public ControlTracker MakeControl( Type t, Type i, Rectangle rectangle )
		{
			object widget_object = null;
			object o = null;
			rect.Width = canvas.Width;
			rect.Height = canvas.Height;
			Rectangle where =  //this.GetScaledBounds(
				 new Rectangle( PARTX( rectangle.X ), PARTY( rectangle.Y )
				 , PARTW( rectangle.X, rectangle.Width ), PARTH( rectangle.Y, rectangle.Height ) )
				//((Form)this.Parent).AutoScaleDimensions, BoundsSpecified.Location
				//)
			;
			{
				Type[] types = new Type[1];
				{
					//Type new_t = osalot.OverloadControl( t );
					types[0] = typeof( Canvas );
					ConstructorInfo m = t.GetConstructor( types );
					if( m != null )
					{
						object[] paramlist = new object[1];
						paramlist[0] = canvas;
						o = Activator.CreateInstance( t, paramlist );
					}
				}
				if( o == null )
				{
					types[0] = typeof( PSI_Button );
					ConstructorInfo m = t.GetConstructor( types );
					if( m != null )
					{
						object[] paramlist = new object[1];
						PSI_Button button = new PSI_Button( canvas );
						widget_object =
						paramlist[0] = button;
						o = Activator.CreateInstance( t, paramlist );
						button.click_hook = ( o as IReflectorButton );
					}
				}
			}
			if( o == null )
			{
				Type[] types = new Type[5];
				types[0] = typeof( Canvas ); // parent window handle
				types[1] = typeof( int );  // x, y, w, h...
				types[2] = typeof( int );  //
				types[3] = typeof( int );  //
				types[4] = typeof( int );  //
				ConstructorInfo m = t.GetConstructor( types );
				if( m != null )
				{
					object[] paramlist = new object[5];
					paramlist[0] = canvas;
					paramlist[1] = where.X;
					paramlist[2] = where.Y;
					paramlist[3] = where.Width;
					paramlist[4] = where.Height;
					o = Activator.CreateInstance( t, paramlist );
				}
			}

			if( o == null )
			{
				//Type real_type = osalot.OverloadControl( t );
				//t = real_type;
				ConstructorInfo m = t.GetConstructor( System.Type.EmptyTypes );
				if( m != null )
				{
					try
					{
						o = Activator.CreateInstance( t );
						if( t.IsSubclassOf( typeof( IReflectorScale ) ) )
						{
							IReflectorScale tmp = o as IReflectorScale;
							tmp.SetScale( canvas.font_scale_x, canvas.font_scale_y );
						}
						if( osalot.IsAControl( t ) )
							widget_object = o;
					}
					catch( Exception e )
					{
						Log.log( e.Message + "\n" + e.StackTrace );
					}
				}
			}

			//c = new System.Windows.Forms.Button();
			//System.Windows.Forms.
			//((ToolStrip)e.ClickedItem.Container)
			{
				Control created_object;
				if( o == null )
					return null;
				bool real = false;
				if( ( t != typeof( PSI_Button ) ) && ( i == typeof( IReflectorButton ) ) )
				{
					if( widget_object != null )
						created_object = widget_object as Control;
					else
					{
						created_object = new PSI_Button( canvas, o as IReflectorButton );
					}
				}
				else if( ( t != typeof( Canvas ) ) && i == typeof( IReflectorCanvas ) )
				{
					created_object = new Canvas( o as IReflectorCanvas );
				}
				else
				{
					created_object = o as Control;
					if( created_object == null )
					{
						if( i == typeof( IReflectorCreate ) )
						{
							created_object = new Control();
						}
					}
				}
				Form form = ( created_object as Form );
				if( form != null )
				{
					form.TopLevel = false;
				}


				//osalot.CreateWidget( where, "Button(1)", where.Size, c, 
				created_object.Location = where.Location;
				created_object.Size = where.Size;
				created_object.Name = o.GetType().ToString() + "(" + (canvas.Controls.Count+1) + ")";
				created_object.TabIndex = 0;
				try
				{
					// web browser, is a control, but overrides text to 'not supported' exception?
					if( created_object.Text == null || created_object.Text == "" )
						created_object.Text = "A Control";
				}
				catch
				{
				}
				canvas.Controls.Add( created_object );
				created_object.Parent = canvas;
				created_object.Visible = false;
				ControlTracker tracker;

				{
					Control c = o as Control;
					if( c != null )
					{
						c.Paint += new PaintEventHandler(c_Paint);			
					}
				}
				Add( tracker = new ControlTracker( created_object, rectangle, i, t, o, real ) );
				return tracker;
			}
		}

		void c_Paint( object sender, PaintEventArgs e )
		{
			//throw new Exception( "The method or operation is not implemented." );
		}

		internal bool Load( XPathNavigator r )
		{
			if( r.NodeType == XPathNodeType.Element )
			{
				if (String.Compare(r.Name, "page", true) == 0)
				{
					bool everokay;
					bool okay;
					//page p = new page(canvas);
					for( okay = r.MoveToFirstAttribute(); okay; okay = r.MoveToNextAttribute() )
					{
						switch( r.Name )
						{
								
						case "background":
							background_name = r.Value;
							try
							{
								if( background_name.Length > 0 && System.IO.File.Exists( background_name ) )
									background_image = Image.FromFile( background_name );
								else
									background_image = null;
							}
							catch
							{
								background_name = null;
							}
							break;
						case "title":
							title = r.Value;
							break;
						case "color":
							{
								try
								{
									background_color = Color.FromArgb( Convert.ToInt32( r.Value ) );
								}
								catch
								{
									// probably alright, just bad...
									// background was already defaulted... 
								}
							}
							break;
						case "x":
							partsX = r.ValueAsInt;
							break;
						case "y":
							partsY = r.ValueAsInt;
							break;
						}
					}
					r.MoveToParent();

					//return true;
					//r.ReadEndElement();
					everokay = false;
					for( okay = r.MoveToFirstChild(); okay; okay = r.MoveToNext() )
					{
						everokay = true;
						if( r.NodeType == XPathNodeType.Element )
						{
							switch( r.Name )
							{
							case "Security":
								foreach( TypeName module in core_common.security_modules )
								{
									IReflectorSecurity o = Activator.CreateInstance( module.Type ) as IReflectorSecurity;
									IReflectorPersistance p = o as IReflectorPersistance;
									r.MoveToFirstChild();
									if( p != null )
									{
										if( p.Load( r ) )
											security_tags.Add( o );
									}
									r.MoveToParent();
								}
								break;
							case "control":
								//page p = new page();
								Rectangle rect = new Rectangle();
								Assembly a;
								String a_name = null;
								Type t;
								font_tracker font = null;
								String t_name = null;
								String i_name = null;
								bool okay2;
								//page p = new page(canvas);
								for( okay2 = r.MoveToFirstAttribute(); okay2; okay2 = r.MoveToNextAttribute() )
								{
									switch( r.Name )
									{
									case "font":
										font = FontEditor.GetFontTracker( r.Value );
										break;
									case "X":
										rect.X = Convert.ToInt32( r.Value );
										break;
									case "Y":
										rect.Y = Convert.ToInt32( r.Value );
										break;
									case "width":
										rect.Width = Convert.ToInt32( r.Value );
										break;
									case "height":
										rect.Height = Convert.ToInt32( r.Value );
										break;
									case "assembly":
										if( r.Value.Length != 0 )
											a_name = r.Value;
										break;
									case "type":
										t_name = r.Value;
										break;
									case "interface":
										if( string.Compare( r.Value, "System.RuntimeType" ) == 0 )
											break;
										i_name = r.Value;
										break;
									}
								}
								// go back to element from attributes...
								r.MoveToParent();
								{
									a = osalot.LoadAssembly( a_name );
									if( t_name != null && a != null )
									{
										t = osalot.findtype( a, t_name );
										Type[] i_list;
										Type i = t;
										if( i_name != null )
										{
											if( t == null )
											{
												continue;
											}
											else
											{
												i_list = t.FindInterfaces( osalot.MyInterfaceFilter, i_name );
												if( i_list.Length > 0 )
													i = i_list[0];
											}
										}
										ControlTracker created_control = MakeControl( t, i, rect );

										if( font != null && created_control.c != null )
										{
											font.Controls.Add( created_control.c );
											created_control.c.Font = font;
										}
										bool success = false;
										IReflectorPersistance persis;
										bool okay3;
										bool everokay3 = false;
										for( okay3 = r.MoveToFirstChild(); okay3; okay3 = r.MoveToNext() )
										{
											everokay3 = true;
											success = false;
											persis = created_control.o as IReflectorPersistance;
											if( persis != null )
											{
												try
												{
													success = persis.Load( r );
												}
												catch( Exception e )
												{
													Console.WriteLine( e );
												}
											}
											if( !success )
											{
												persis = created_control.c as IReflectorPersistance;
												if( persis != null )
												{
													try
													{
														success = persis.Load( r );
													}
													catch( Exception e )
													{
														Console.WriteLine( e );
													}
												}
											}
											if( !success )
											{
												Console.WriteLine( "Ignored Element..." );
											}
											
										}
										if( everokay3 )
											r.MoveToParent();
									}
								}
								break;
							}
						}
					}
					if( everokay )
						r.MoveToParent();
					return true;
				}
			}
			return false;
		}
		internal void save( XmlWriter w )
		{
			w.WriteStartElement( "page" );
			w.WriteAttributeString( "background", background_name );
			w.WriteAttributeString( "title", Name );
			w.WriteAttributeString( "color", background_color.ToArgb().ToString() );
			w.WriteAttributeString( "x", this.partsX.ToString() );
			w.WriteAttributeString( "y", this.partsY.ToString() );
			w.WriteRaw( "\r\n" );
			foreach( ControlTracker c in this )
			{
				w.WriteStartElement( "control" );
				w.WriteAttributeString( "X", Convert.ToString( c.grid_rect.X ) );
				w.WriteAttributeString( "Y", Convert.ToString( c.grid_rect.Y ) );
				w.WriteAttributeString( "width", Convert.ToString( c.grid_rect.Width ) );
				w.WriteAttributeString( "height", Convert.ToString( c.grid_rect.Height ) );
				String s;
				if( String.Compare( s = c.Type.Assembly.FullName, Assembly.GetCallingAssembly().FullName ) == 0 )
					w.WriteAttributeString( "assembly", "" );
				else
					w.WriteAttributeString( "assembly", core.core_common.GetRelativePath( c.Type.Assembly.Location ) );
				w.WriteAttributeString( "type", c.Type.FullName );
				font_tracker ft = FontEditor.GetFontTracker( c.c.Font );
				if( ft != null )
					w.WriteAttributeString( "font", ft.ToString() );
				else
					w.WriteAttributeString( "font", "default" );
				if( c.i != null )
				{
					string s2 = c.i.FullName;
					w.WriteAttributeString( "interface", s2 );
				}

				w.WriteRaw( "\r\n" );

				IReflectorPersistance persis = c.o as IReflectorPersistance;
				if( persis != null )
					persis.Save( w );
				if( !c.real )
				{
					persis = c.c as IReflectorPersistance;
					if( persis != null )
						persis.Save( w );
				}
				w.WriteEndElement();
				w.WriteRaw( "\r\n" );
			}


			foreach( IReflectorSecurity s in this.security_tags )
			{
				IReflectorPersistance p = s as IReflectorPersistance;
				if( p != null )
				{
					w.WriteStartElement( "Security" );
					p.Save( w );
					w.WriteEndElement();
				}
			}

			w.WriteEndElement();
			w.WriteRaw( "\r\n" );
		}
		internal void Hide()
		{
			menu_item.Checked = false;
			foreach( ControlTracker c in this )
			{
				IReflectorDirectionShow direction = c.o as IReflectorDirectionShow;
				if( direction != null )
					direction.Hidden();
				c.c.Visible = false;
			}
		}
		internal void Show()
		{
			foreach( IReflectorDirectionShow director in core_common.directors )
			{
				director.PageChanged();
			}

			menu_item.Checked = true;
			foreach( ControlTracker c in this )
			{
				IReflectorWidget widget = c.o as IReflectorWidget;
				IReflectorDirectionShow direction = c.o as IReflectorDirectionShow;
				IReflectorWindow irw = c.o as IReflectorWindow;
				if( direction != null )
				{
					direction.Shown();
				}

				if( irw != null )
				{
					// we might not have moved... but, better safe than sorry.
					irw.Move();
				}

				if( widget != null )
				{
					if( widget.CanShow )
						c.c.Visible = true;
				}
				else
				{
					widget = c.c as IReflectorWidget;
					if( widget != null )
					{
						if( widget.CanShow )
						{
							// if no widget interface, assume it's visible.
							c.c.Visible = true;
						}
					}
					else
					{
						//if( direction != null )
						{
							//direction.Shown();
						}
						c.c.Visible = true;
					}
				}
			}
		}

		internal void PropertyClick()
		{
			//System.Windows.Form();
			PageProperties form = new PageProperties( this );

			form.ShowDialog();
			if( form.DialogResult == DialogResult.OK )
			{
				string tmp;
				int newPartsX = Convert.ToInt32( form.textBox1.Text );
				int newPartsY = Convert.ToInt32( form.textBox2.Text );
				if( partsX != newPartsX || partsY != newPartsY )
				{
					foreach( ControlTracker c in this )
					{
						int new_left = ( c.grid_rect.Left * newPartsX ) / partsX;
						int new_right = ( c.grid_rect.Right * newPartsX ) / partsX;
						int new_top = ( c.grid_rect.Top * newPartsY ) / partsY;
						int new_bottom = ( c.grid_rect.Bottom * newPartsY ) / partsY;
						c.grid_rect = new Rectangle( new_left, new_top, new_right - new_left, new_bottom - new_top );
					}
					partsX = newPartsX;
					partsY = newPartsY;
					foreach( ControlTracker c in this )
					{
						c.c.Left = PARTX( c.grid_rect.Left );
						c.c.Width = PARTW( c.grid_rect.X, c.grid_rect.Width );
						c.c.Top = PARTY( c.grid_rect.Top );
						c.c.Height = PARTH( c.grid_rect.Y, c.grid_rect.Height );
					}
				}
				tmp = form.textBox3.Text;
				if( tmp.Length == 0 )
				{
					if( background_image != null )
					{
						background_image.Dispose();
						background_image = null;
					}
					background_name = tmp;
				}
				else if( String.Compare( tmp, background_name ) != 0 )
				{
					background_name = tmp;
					try
					{
						background_image = Image.FromFile( tmp );
					}
					catch
					{
						background_name = null;
					}
				}
				background_color = form.colorWell1.color;

				//tmp = form.
			}
			form.Dispose();
			canvas.BackgroundImage = background_image;
			canvas.Refresh();

			//ShowDialog(new Form1());
		}



		internal ControlTracker ControlAt( int partX, int partY )
		{
			foreach( ControlTracker c in this )
			{
				if( c.grid_rect.Left <= partX && c.grid_rect.Right > partX &&
					c.grid_rect.Top <= partY && c.grid_rect.Bottom > partY )
					return c;
			}
			return null;
		}

		public bool Select()
		{
			this.canvas.current_page = this;
			if( this.canvas.current_page == this )
				return true;
			return false;
		}

		internal void GetSelectedControls( List<ControlTracker> selected, Rectangle selection )
		{
			selected.Clear();
			foreach( ControlTracker c in this )
			{
				c.selected = false;
				if( !( ( ( ( selection.X ) + selection.Width ) <= c.grid_rect.X )
					|| ( ( selection.X ) >= ( c.grid_rect.X + c.grid_rect.Width ) )
					|| ( ( ( selection.Y ) + selection.Height ) <= c.grid_rect.Y )
					|| ( ( selection.Y ) >= ( c.grid_rect.Y + c.grid_rect.Height ) )
					) )
				{
					c.selected = true;
					selected.Add( c );
				}

			}
		}
	}

}
