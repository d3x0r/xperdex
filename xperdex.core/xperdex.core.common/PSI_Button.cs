using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Xml.XPath;
using xperdex.classes;
using xperdex.gui;
using System.Text.RegularExpressions;
using System.Collections;
using xperdex.core.interfaces;
using xperdex.core.common;

namespace xperdex.core
{
	[ButtonAttribute( hidden=true )]
	public partial class PSI_Button : PSI_Control, IReflectorButton, IReflectorPersistance, IReflectorWidget, IReflectorDropFileTarget, IReflectorCopyPaste
	{
		public virtual bool RenderText( Control c, Graphics g )
		{
			return false; // did not render text herer...
			// do nothing to start...
		}
		// different than local, but probably the same too
		// should check if in edit mode, dispatch to parent?
		Canvas canvas; // what canvas this button is on...
		internal buttons_class buttons; // mouse state buttons.
		internal bool disable_changes;
		public GlareSet gs;
		public List<object> security_tags; // security objects which have been attached to this object.

		IReflectorButton _click;
		public IReflectorButton click_hook {
			set { _click = value; }
		}
		public String NextPage;
		xperdex.gui.font_tracker _FontTracker;
		public font_tracker FontTracker
		{
			set
			{
				if( value != null )
				{
					_FontTracker = value;
					this.Font = _FontTracker.font;
				}
			}
			get
			{
				return _FontTracker;
			}
		}

		internal bool allowed_on_system;

		// public only for purposes of editing button properties...
		internal List<String> AllowShow;
		internal List<String> AllowShowUsers;
		internal List<String> DisallowShow;

		public void CheckAllowedShow()
		{
			allowed_on_system = true;
			IComparer<string> c = new CaseInsensitiveComparer() as IComparer<string>;
			AllowShow.Sort( c );
			DisallowShow.Sort( c );

			foreach( String system in DisallowShow )
			{
				Match m = Regex.Match( SystemInformation.ComputerName, system, RegexOptions.IgnoreCase );
				if( m.Success && m.Index == 0 && m.Length == system.Length )
				{
					allowed_on_system = false;
					break;
				}
			}

			if( allowed_on_system && AllowShowUsers.Count > 0 )
			{
				allowed_on_system = false;
				foreach( String user in AllowShowUsers )
				{
					Match m = Regex.Match( SystemInformation.UserName, user, RegexOptions.IgnoreCase );
					if( m.Success && m.Index == 0 && m.Length == user.Length )
					{
						allowed_on_system = true;
						break;
					}
				}
			}

			if( !allowed_on_system && AllowShow.Count > 0 )
			{
				//allowed_on_system = false;
				foreach( String system in AllowShow )
				{
					Match m = Regex.Match( SystemInformation.ComputerName, system, RegexOptions.IgnoreCase );
					if( m.Success && m.Index == 0 && m.Length == system.Length )
					{
						allowed_on_system = true;
						break;
					}
				}
			}
		}

		void IReflectorPersistance.Save( XmlWriter w )
		{
			if( gs != null )
				gs.Save( w );
			w.WriteStartElement( "PSI_Button" );
			if( NextPage != null )
				w.WriteAttributeString( "page", NextPage );
			w.WriteAttributeString( "text", Text );
			if( decal_name != null )
			{
				w.WriteAttributeString( "decal", decal_name );
				w.WriteAttributeString( "decal_Scale", DecalScale.ToString() );
			}
			//if( _FontTracker != null )
			//	w.WriteAttributeString( "font", _FontTracker.Name );
			foreach( String system in AllowShow )
			{
				w.WriteElementString( "allow", system );
			}
			foreach( String system in DisallowShow )
			{
				w.WriteElementString( "disallow", system );
			}

			foreach( Object o in security_tags )
			{
				w.WriteStartElement( "security" );
				w.WriteAttributeString( "type", o.ToString() );
				IReflectorPersistance p = o as IReflectorPersistance;
				if( p != null )
				{
					p.Save( w );
				}
				w.WriteEndElement();
				w.WriteRaw( "\r\n" );
			}

			w.WriteEndElement();
			w.WriteRaw( "\r\n" );
		}

		bool IReflectorPersistance.Load( XPathNavigator r )
		{
			// okay so the glareset attributes of a PSI_Button are 
			// saved before PSI Button information.
			gs.Load( r ); // just give this a chance...

			{
				// glareset will result in the same position as it started (almost)
				//r.MoveToNext();
				if( r.NodeType == XPathNodeType.Element )
				{
					if( String.Compare( r.Name, "PSI_Button", true ) == 0 )
					{
						bool ever_okay = false;
						bool okay;
						for( okay = r.MoveToFirstAttribute(); okay; okay = r.MoveToNextAttribute() )
						{
							ever_okay = true;
							switch( r.Name.ToLower() )
							{
							case "decal":
								SetDecalName( r.Value );
								break;
							case "decal_scale":
								DecalScale = Convert.ToInt32( r.Value );
								break;
							case "text":
								Text = r.Value;
								break;
							//case "font":
							//	FontTracker = FontEditor.GetFontTracker( r.Value );
							//	break;
							case "page":
								if( canvas != null )
									NextPage = r.Value;
								break;
							}
						}
						if( ever_okay )
							r.MoveToParent();
						// child elements within PSI_Button tag...
						bool everokay2 = false;
						for( okay = r.MoveToFirstChild(); okay; okay = r.MoveToNext() )
						{
							everokay2 = true;
							switch( r.Name.ToLower() )
							{
							case "allow":
								AllowShow.Add( r.Value );
								break;
							case "disallow":
								DisallowShow.Add( r.Value );
								break;
							case "security":
								{
									bool okay3;
									bool everokay3 = false;
									for( okay3 = r.MoveToFirstAttribute(); okay3; okay3 = r.MoveToNext() )
									{
										everokay3 = true;
										switch( r.Name.ToLower() )
										{
										case "type":
											foreach( TypeName n in core_common.security_modules )
											{
												if( String.Compare( n.Name, r.Value ) == 0 )
												{
													object o = Activator.CreateInstance( n.Type );
													this.security_tags.Add( o );
													IReflectorPersistance p = o as IReflectorPersistance;
													if( p != null )
													{
														XPathNavigator tmp = r.CreateNavigator();
														tmp.MoveToParent();
														tmp.MoveToFirstChild();
														p.Load( tmp );
														break;
													}
												}
											}
											break;
										}
									}
									if( everokay3 )
										r.MoveToParent();
								}
								break;
							}
						}
						CheckAllowedShow();
						if( everokay2 )
							r.MoveToParent();
						return true;
					}
				}
			}
			return false;
		}
		
		void IReflectorPersistance.Properties()
		{
			PSI_ButtonProperties d = new PSI_ButtonProperties( this, (Canvas)this.Parent );
			d.ShowDialog();
			if( d.DialogResult == DialogResult.OK )
			{
				d.Apply();
			}
			d.Dispose();
		}


		void Init( Canvas canvas, IReflectorButton click_interface )
		{
			AllowShowUsers = new List<string>();
			AllowShow = new List<string>();
			DisallowShow = new List<string>();
			this.canvas = canvas;
			buttons = new buttons_class();
			gs = new GlareSet( "default", "default" );

			FontTracker = FontEditor.GetFontTracker( "Default" );
			allowed_on_system = true;

			InitializeComponent();
			if( click_interface == null )
				_click = this as IReflectorButton;
			else
				_click = click_interface;
#if no_PSI_Base_class
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            //SetStyle(ControlStyles.Opaque, false);  // no background
            //SetStyle(ControlStyles.UserPaint, true); // generate paint
            //SetStyle(ControlStyles.AllPaintingInWmPaint, true); // skip paintbackground
            this.SetStyle(ControlStyles.Opaque, false);
            this.BackColor = Color.Transparent;
            this.DoubleBuffered = true;
#endif
			this.security_tags = new List<object>();
			this.MouseUp += new System.Windows.Forms.MouseEventHandler( this.CanvasButtonUp );
			this.MouseMove += new System.Windows.Forms.MouseEventHandler( this.CanvasClick );
			this.MouseDown += new System.Windows.Forms.MouseEventHandler( this.CanvasButtonDown );

			this.Paint += new PaintEventHandler( PSI_Button_Paint );
			//SetStyle(ControlStyles.
			//this.SetStyle(ControlStyles.
			//BackColor = Color.Transparent; // Color.FromArgb(0, 1, 0, 0);
		}

		public PSI_Button( Canvas canvas, IReflectorButton click_interface )
		{
			Init( canvas, click_interface );
		}
		public PSI_Button( Canvas canvas )
		{
			Init( canvas, this as IReflectorButton );
		}
		public PSI_Button()
		{
			Init( this.Parent as Canvas, this as IReflectorButton );
		}

		private void CanvasClick( object sender, MouseEventArgs e )
		{
			if( disable_changes )
				return;
			Canvas canvas = this.Parent as Canvas;
			//Log.log( "  --- CLICK ----- " );
			if( canvas != null && canvas.flags.editing )
			{
				MouseEventArgs e2 = new MouseEventArgs( MouseButtons, e.Clicks
					, this.Location.X + e.Location.X
					, this.Location.Y + e.Location.Y
					, e.Delta );
                
				//canvas.CanvasClick( sender, e );
				return;
			}

			if( e.Location.X > this.Width ||
				e.Location.Y > this.Height ||
				e.Location.X < 0 ||
				e.Location.Y < 0 )
			{
				Log.log( "Disabling click." );
				buttons.clicked = false;
				Refresh();
			}
			else
			{
				if( !buttons.clicked )
				{
					if( buttons.want_click )
					{
						Log.log( "enabling click." );
						buttons.clicked = true;
						Refresh();
					}
				}
			}

			buttons.Location = e.Location;

			if( buttons.l )
			{
			}
		}
		bool highlighted;
		public bool Highlight
		{
			set
			{
				if( highlighted != value )
				{
					highlighted = value;
					Refresh();
				}
			}
		}
		
		public void SetHighlighted( bool highlight )
		{
			if( highlighted != highlight )
			{
				highlighted = highlight;
				Refresh();
			}
		}
		void PSI_Button_Paint( object sender, PaintEventArgs e )
		{
			//Log.log( "output glare..." );
			if( highlighted )
				if( buttons.clicked )
					gs.OutputGlareSet( this, e, RenderText, GlareSet.GlareState.PressedHightlight );
				else
					gs.OutputGlareSet( this, e, RenderText, GlareSet.GlareState.NormalHightlight );
			else
				if( buttons.clicked )
				{
					//Log.log( "Click down" );
					gs.OutputGlareSet( this, e, RenderText, GlareSet.GlareState.Pressed );
				}
				else
				{
					//Log.log( "Normal" );
					gs.OutputGlareSet( this, e, RenderText, GlareSet.GlareState.Normal );
				}
		}

		private void CanvasButtonDown( object sender, MouseEventArgs e )
		{
			if( disable_changes )
				return;
			//Log.log( "  --- CLICK DOWN ----- " );
			buttons.Location = e.Location;
			switch( e.Button )
			{
			case MouseButtons.Left:
				buttons.want_click = true;
				buttons.l = true;
				break;
			case MouseButtons.Right:
				buttons.r = true;
				break;
			case MouseButtons.Middle:
				buttons.m = true;
				break;
			}



			Canvas canvas = this.Parent as Canvas;
			//Log.log( "  --- CLICK ----- " );
			if( canvas != null && canvas.flags.editing )
			{
				MouseEventArgs e2 = new MouseEventArgs( MouseButtons, e.Clicks
					, this.Location.X + e.Location.X
					, this.Location.Y + e.Location.Y
					, e.Delta );

				//canvas.CanvasClick( sender, e2 );
				return;
			}


			if( e.Location.X > this.Width ||
				e.Location.Y > this.Height ||
				e.Location.X < 0 ||
				e.Location.Y < 0 )
			{
				//Log.log( "Disabling click." );
				buttons.clicked = false;
				Refresh();
			}
			else
			{
				if( !buttons.clicked )
				{
					if( buttons.want_click )
					{
						//Log.log( "enabling click." );
						buttons.clicked = true;
						Refresh();
					}
				}
			}

			buttons.Location = e.Location;

			if( buttons.l )
			{
			}
			//Refresh();

		}

		private void CanvasButtonUp( object sender, MouseEventArgs e )
		{
			//Log.log( "  --- CLICK UP ----- " );
			if( disable_changes )
				return;
			buttons.Location = e.Location;
			switch( e.Button )
			{
			case MouseButtons.Left:
				if( buttons.l )
				{
					buttons.want_click = false;
					if( buttons.clicked )
					{
						buttons.l = false;
						buttons.l_delta_up = true;
						buttons.clicked = false;
						Refresh();

						foreach( IReflectorSecurity security in this.security_tags )
						{
							if( !security.Open() )
							{
								//foreach( IReflectorSecurity upto in local.security_modules )
								{
									//if( upto == security )
									//	break;
									security.Close();
								}
								return;
							}
						}

						foreach( IReflectorSecurity security in security_tags )
						{
							if( !security.Test() )
								return;
						}


						// if button success (failure will fail from macro, which will fail to here.)
						// consider multiple failure conditions, perhaps set a failure mode
						// so we can maybe unwind what has already been done?
						if( _click.OnClick() )
						{
							if( this.NextPage != null )
							{
								page page = canvas.FindPage( this.NextPage );
								page.Select();
							}
						}

						foreach( IReflectorSecurity security in security_tags )
						{
							// if it closes...
							security.Close();
						}
					}
				}

				break;
			case MouseButtons.Right:
				if( buttons.r )
				{
					buttons.r = false;
					buttons.r_delta_up = true;
					Refresh();
				}
				break;
			case MouseButtons.Middle:
				buttons.m = false;
				break;
			}
		}


		#region IReflectorButton Members

		public class ReflectorButtonEventArgs : EventArgs
		{
			public bool handled;			
		}

		public delegate void ClickProc( object sender, ReflectorButtonEventArgs args );
		new public event ClickProc Click;


		bool IReflectorButton.OnClick()
		{
			//InvokeOnClick( this, new EventArgs() );
			//throw new Exception( "The method or operation is not implemented." );
			ReflectorButtonEventArgs args = new ReflectorButtonEventArgs();
			if( Click != null )
				Click( this, args );
			
			return args.handled;
		}

		#endregion


		#region IReflectorWidget Members

		bool IReflectorWidget.CanShow
		{
			get { return allowed_on_system; }
		}

		void IReflectorWidget.OnPaint( PaintEventArgs e )
		{
		}

		void IReflectorWidget.OnKeyPress( KeyPressEventArgs e )
		{
		}
		void IReflectorWidget.OnMouse( MouseEventArgs e )
		{
		}
		#endregion

		#region IReflectorDropFileTarget Members

		bool IReflectorDropFileTarget.Drop( object sender, string filename, int X, int Y )
		{		
			bool success = SetDecalName( filename );
			if( success )
				Refresh();
			return success;
		}

		#endregion

		#region IReflectorCopyPaste Members

		//PSI_Button clone;

		void IReflectorCopyPaste.OnClone()
		{
			//clone = this;
			// save information about this thing that is going to be a clone...
			//throw new Exception( "The method or operation is not implemented." );
		}

		void IReflectorCopyPaste.OnPaste( Object o )
		{
			PSI_Button original = o as PSI_Button;
			if( original != null )
			{
				this.gs = new GlareSet( original.gs );
				this.FontTracker = original.FontTracker;
				this.Text = original.Text;
			}
			//throw new Exception( "The method or operation is not implemented." );
		}

		#endregion


		internal Image _decal;
		internal Rectangle _decal_rect;
		public String decal_name;
		public int DecalScale;
		public bool SetDecalName( String value )
		{
			if( String.Compare( value, decal_name, true ) != 0 )
			if( value.Length > 0 )
				try
				{
					Image image = Image.FromFile( value );
					decal_name = value;
					decal = image;
					if( DecalScale == 0 )
						DecalScale = 100;
					return true;
				}
				catch
				{
				}
			return false;
		}

		public Image decal
		{
			set
			{
				_decal = value;
				_decal_rect = new Rectangle( new Point( 0, 0 ), value.Size );
			}
		}
	}
}
