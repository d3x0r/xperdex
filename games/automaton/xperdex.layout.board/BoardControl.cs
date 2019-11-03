using xperdex.core.interfaces;
using xperdex.gui;
using System.Windows.Forms;
using System;
using System.Drawing;
using xperdex.classes;

// this is a thing that is not always available!
//C:\Windows\Microsoft.NET\DirectX for Managed Code\1.0.2902.0\Microsoft.DirectX.DirectDraw.dll
//Core DirectDraw classes for Managed DirectX


namespace xperdex.layout.board
{
	[ControlAttribute(Name="Layout Board" )]
	public class BoardControl : PSI_Control, IReflectorPersistance
	{
		internal Board board;

		public BoardControl( Control parent )
		{
			Paint += new System.Windows.Forms.PaintEventHandler( BoardControl_Paint );
			SizeChanged += new EventHandler( BoardControl_SizeChanged );
			MouseMove += new MouseEventHandler( BoardControl_MouseMove );
			MouseDown += new MouseEventHandler( BoardControl_MouseDown );
			MouseUp += new MouseEventHandler( BoardControl_MouseUp );
			//Mouse 
			//Update += new DoUpdate( BoardControl_Update );
		}

		void BoardControl_MouseUp( object sender, MouseEventArgs e )
		{
			if( board == null )
				return;
			if( e.Button == System.Windows.Forms.MouseButtons.Left )
			{
				if( routing )
				{
					Point current_location;
					board.ComputeCellFromPoint( e.Location, out current_location );
					Layer current_mouse_layer = board.GetLayerAt( ref current_location );
					if( current_mouse_layer.flags.bRoot || current_mouse_layer.Equals( routing_layer ) )
					{
						// allow routint to continue
						// but also allow drag operation
						// right click to cancel this routing.
						routing_mouseup = true;
						routing = false;
					}
					else
					{
						if( routing_layer != null && routing_layer.EndsWhereItStarts() )
						{
							board.layers.Remove( routing_layer );
							routing_layer.Dispose();
							routing_layer = null;
							routing = false;
							Refresh();
						}
						else if( current_mouse_layer.peice.AllowLink( mouse_layer.peice_instance ) )
						{
							mouse_layer.peice.EndLink( mouse_layer.peice_instance, current_mouse_layer.peice_instance );
							mouse_layer = null;
							routing = false;
							Refresh();
						}
					}
				}

				else if( !dragging )
				{
					Layer default_layer = null;
					// touch
					foreach( Layer layer in board.layers )
					{
						if( layer.flags.bRoot )
							default_layer = layer;
						else
						{
							int x = board_click_origin.X;
							int y = board_click_origin.Y;
							if( layer.IsLayerAt( ref x, ref y ) )
							{
								if( layer.flags.bRoute
									&& !layer.EndsAt( new Point( x, y ) ) )
									continue;
								if( layer.peice.InvokePeiceTouch( board, layer.peice, x, y, layer.peice_instance ) )
								{
									default_layer = null;
									break;
								}
							}
						}
					}
					if( default_layer != null )
					{
						default_layer.peice.InvokePeiceTouch( board, default_layer.peice, cell_click_origin.X, cell_click_origin.Y, default_layer.peice_instance );
						Refresh();
					}
				}
				if( routing_layer == null )
				{
					mouse_layer = null;
				}
				left = false;
				dragging = false;
			}
			if( e.Button == System.Windows.Forms.MouseButtons.Right )
			{
				if( !routing && !routing_mouseup && !dragging )
				{
					Layer default_layer = null;
					Layer fallback_layer = null;
					int fallback_x = 0, fallback_y = 0;
					Layer top_layer = null;
					int top_x = 0, top_y = 0;
					// touch
					foreach( Layer layer in board.layers )
					{
						if( layer.flags.bRoot )
							default_layer = layer;
						else
						{
							int x = board_click_origin.X;
							int y = board_click_origin.Y;
							if( layer.IsLayerAt( ref x, ref y ) )
							{
								if( layer.flags.bRoute
									&& !layer.EndsAt( new Point( x, y ) ) )
									continue;
								if( top_layer != null )
								{
									fallback_x = top_x;
									fallback_y = top_y;
									fallback_layer = top_layer;
								}
								top_x = x;
								top_y = y;
								top_layer = layer;

							}
						}
					}
					if( top_layer == null || !top_layer.peice.InvokePropertyTouch( board, top_layer.peice, top_x, top_y, top_layer.peice_instance ) )
					if( fallback_layer == null || !fallback_layer.peice.InvokePropertyTouch( board, fallback_layer.peice, fallback_x, fallback_y, fallback_layer.peice_instance ) )
					if( default_layer != null )
					{
						default_layer.peice.InvokePropertyTouch( board, default_layer.peice, cell_click_origin.X, cell_click_origin.Y, default_layer.peice_instance );
					}
				}
			}
		}

		bool left;
		bool dragging;
		bool routing;
		bool routing_mouseup;
		Point click_origin;
		Point board_click_origin; // this one is computed cell absolute based on just grid pos.
		Point cell_click_origin;

		Layer mouse_layer;
		Layer routing_layer;

		void BoardControl_MouseDown( object sender, MouseEventArgs e )
		{
			if( board == null )
				return;

			if( e.Button == System.Windows.Forms.MouseButtons.Left )
			{
				Layer temporary;
				click_origin = e.Location;
				board.ComputeCellFromPoint( click_origin, out board_click_origin );
				Log.log( "mouse at " + board_click_origin );
				cell_click_origin = board_click_origin;
				if( routing_mouseup )
				{
					Log.log( "Routing up" );
					if( routing_layer != null && routing_layer.EndsWhereItStarts() || routing_layer.EndIsNot( cell_click_origin ) )
					{
						board.layers.Remove( routing_layer );
						routing_layer.Dispose();
						routing_layer = null;
						routing_mouseup = false;
						routing = false;
						Refresh();
					}
					else
					{
						mouse_layer = board.GetLayerAt( ref cell_click_origin );
						if( !mouse_layer.flags.bRoot )
						{
							if( mouse_layer.peice.AllowLink( routing_layer.peice_instance ) )
							{
								mouse_layer.peice.EndLink( mouse_layer.peice_instance, routing_layer.peice_instance );

								routing_layer = null;
								routing_mouseup = false;
							}
						}
					}
				}
				else 
				{
					Log.log( "not routing..." );
					mouse_layer = board.GetTopLayerAt( ref cell_click_origin );
					Log.log( "Top layer is " + mouse_layer.peice.ToString() );

					if( mouse_layer.flags.bRoute )
					{
						if( mouse_layer.EndsAt( cell_click_origin ) )
						{
							routing = true;
							routing_layer = mouse_layer;
							( mouse_layer.peice as ViaRepresentation ).EndUnlink( mouse_layer.peice_instance );

						}
					}
					else
					{
						// this event results in a new layer at the current location, and we are now routing it.
						temporary = mouse_layer.peice.PeiceClick( board, mouse_layer, cell_click_origin.X
							, cell_click_origin.Y, mouse_layer.peice_instance );
						if( temporary != null )
						{
							Log.log( "temporary came back, we began a layer from click on peice." );
							routing = true;
							routing_layer = mouse_layer;
							routing_layer.Link( temporary, Layer.link_types.LINK_VIA_START, 0, 0 );
							routing_layer = temporary;
							cell_click_origin = new Point( mouse_layer.X + cell_click_origin.X, mouse_layer.Y + cell_click_origin.Y );
							Refresh();
						}
					}
				}
				left = true;
			}
			if( e.Button == System.Windows.Forms.MouseButtons.Right )
			{
				Log.log( "right button" );
				click_origin = e.Location;
				board.ComputeCellFromPoint( click_origin, out board_click_origin );
				Log.log( "mouse at " + board_click_origin );
				cell_click_origin = board_click_origin;

				if( routing_mouseup )
				{
					Log.log( "was routing up... this is cancel routing." );
					board.layers.Remove( routing_layer );
					routing_layer.Dispose();
					routing_layer = null;
					routing_mouseup = false;
					mouse_layer = null;
					Refresh();
				}
			}
		}

		void BoardControl_MouseMove( object sender, MouseEventArgs e )
		{
			Point current;
			if( mouse_layer != null )
			{
				board.ComputeCellFromPoint( e.Location, mouse_layer, out current );
				Point new_cell_click_origin = new Point( current.X + ( mouse_layer.flags.bRoot ? 0 : mouse_layer.X )
					, current.Y + ( mouse_layer.flags.bRoot ? 0 : mouse_layer.Y ) );
				Log.log( "cell origin " + cell_click_origin + " " + new_cell_click_origin + " " + board.CellOriginX + " " + board.CellOriginY + " : " + current );
				Log.log( "peice under cursor is " + mouse_layer.peice_instance.ToString() );
				//Rectangle points = board.GetOutputRect( current.X, current.Y, 1, 1 );
				//CreateGraphics().FillRectangle( SystemBrushes.GradientActiveCaption, points );

				if( new_cell_click_origin.X != cell_click_origin.X || new_cell_click_origin.Y != cell_click_origin.Y )
				{
					Log.log( "different" );
					if( left )
					{
						if( routing )
						{
							routing_layer.LayPath( new_cell_click_origin.X, new_cell_click_origin.Y );
						}
						else
						{
							Log.log( "Begin dragging the backgruond...." );
							dragging = true;
							if( mouse_layer.flags.bRoot )
							{
								mouse_layer.X += new_cell_click_origin.X - cell_click_origin.X;
								mouse_layer.Y += new_cell_click_origin.Y - cell_click_origin.Y;
								// if the background moves, then the origin is rebiased... so just use the old one.
								new_cell_click_origin = cell_click_origin;
							}
							else
							{
								mouse_layer.X = new_cell_click_origin.X;
								mouse_layer.Y = new_cell_click_origin.Y;
							}
						}
						Refresh();
					}
					else
					{
						if( routing_mouseup )
						{
							routing_layer.LayPath( new_cell_click_origin.X, new_cell_click_origin.Y );
							Refresh();
						}
					}
				}
				cell_click_origin = new_cell_click_origin;
			}
		}

		void BoardControl_SizeChanged( object sender, EventArgs e )
		{
			if( board != null )
			{
				board.Width = Width;
				board.Height = Height;
			}
		}

		void BoardControl_Paint( object sender, System.Windows.Forms.PaintEventArgs e )
		{
			if( board != null )
				board.FormDraw( e.Graphics );
		}

		Type root_type;
		public Type RootPeiceType
		{
			set
			{
				root_type = value;
				board = new Board( root_type );
				board.Width = Width;
				board.Height = Height;

				Refresh();
			}
			get
			{
				return root_type;
			}
		}

		bool IReflectorPersistance.Load( System.Xml.XPath.XPathNavigator r )
		{
			if( board == null )
			{
				board = new Board();
				board.Width = Width;
				board.Height = Height;
			}
			return board.Load( r );
		}

		void IReflectorPersistance.Save( System.Xml.XmlWriter w )
		{
			if( board != null )
				board.Save( w );
		}

		void IReflectorPersistance.Properties()
		{
			BoardProperties editor = new BoardProperties( this );
			editor.ShowDialog();
			if( editor.DialogResult == DialogResult.OK )
				RootPeiceType = editor.GetSelectedType();
			editor.Dispose();
		}
	}

	[ControlAttribute( Name = "Layout Board.d3d" )]
	public class BoardControl_d3d : PSI_VirtuaFrame
	{
		Board board;

		public BoardControl_d3d()
		{
			Render += new OnRender( BoardControl_Render );
			//Mouse 
			//Update += new DoUpdate( BoardControl_Update );
		}

		void BoardControl_Update()
		{
			// probabaly don't need update for this purpose
		}

		void BoardControl_Render( D3DState state )
		{
			board.Draw( state );
		}

		public void OnCreate( System.Windows.Forms.Control pc )
		{
		}
	}
}
