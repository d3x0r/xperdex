using System.Collections.Generic;
using System;
using System.Drawing;
using xperd3x.breadboard;

namespace xperdex.layout.board
{
	public class Board
	{
		int scale;
		public int Scale
		{
			get
			{
				return scale;
			}
		}

		int width, height;
		int cell_width = 16;
		int cell_height = 16;
		public int Width
		{
			get
			{
				return width;
			}
			set
			{
				width = value;
			}
		}
		public int Height
		{
			get
			{
				return height;
			}
			set
			{
				height = value;
			}
		}
		public int CellWidth
		{
			get
			{
				return cell_width;
			}
		}
		public int CellHeight
		{
			get
			{
				return cell_height;
			}
		}

		int cell_origin_x;

		/// <summary>
		/// Represents the X Position of the board.  This spot is 0, 0 negative is left
		/// </summary>
		public int CellOriginX
		{
			get
			{
				return cell_origin_x;
			}
			set
			{
				cell_origin_x = value;
			}
		}
		int cell_origin_y;
		/// <summary>
		/// Represents the Y Position of the board.  This spot is 0, 0  negative is up
		/// </summary>
		public int CellOriginY
		{
			get
			{
				return cell_origin_y;
			}
			set
			{
				cell_origin_y = value;
			}
		}

		int cell_max_x;
		public int CellMaxX
		{
			get
			{
				return ( ( width / 2 ) / cell_width ) - cell_origin_x;
			}
		}


		public int CellMaxY
		{
			get
			{
				return ( ( height / 2 ) / cell_height ) - cell_origin_y;
			}
		}
		public int CellMinX
		{
			get
			{
				return - cell_origin_x - ( ( width / 2 ) / cell_width );
			}
		}

		public int CellMinY
		{
			get
			{
				return - cell_origin_y - ( ( height / 2 ) / cell_height );
			}
		}

		internal LinkedList<Layer> layers;
		Layer background;
		internal List<PeiceRepresentation> peices;
		private Type root_type;


		public Board()
		{
			// yay we have a board.
		}

		public Board( Type root_type )
		{
			// TODO: Complete member initialization
			this.root_type = root_type;
			peices = BoardPlugin.PeiceTypes[root_type];
			layers = new LinkedList<Layer>();
			layers.AddLast( background = new Layer( this, peices[0] ) );
			background.flags.bRoot = true;
			background.peice_instance = background.peice.CreateInstance( null, null );
		}

		internal void Draw( D3DState state )
		{
			foreach( Layer layer in layers )
			{
				layer.Draw( state );
			}
		}

		public void CreatePeice( PeiceRepresentation parent, int x, int y, Type peice_type, object parameter )
		{
			foreach( PeiceRepresentation peice in peices )
			{
				if( peice.GetType().Equals( peice_type ) )
				{
					Layer layer = new Layer( this, peice, x, y, parameter );
					layers.AddLast( layer );
					break;
				}
			}
		}

		internal void ComputeCellFromPoint( Point point, out Point result )
		{
			result = new Point();
			int origin_x = ( width )  / 2;
			int origin_y = ( height ) / 2;
			if( ( point.X - origin_x ) < 0 )
				origin_x += ( cell_width / 2 );
			else
				origin_x -= ( cell_width / 2 );
			if( ( point.Y - origin_y ) < 0 )
				origin_y += ( cell_height / 2 );
			else
				origin_y -= ( cell_height / 2 );
			// here we subtract the origin_x, because this means the origin is out at that point... so we'd be closer to it if 
			// the cursor were also far.
			result.X = ( point.X - origin_x ) / cell_width - cell_origin_x;
			result.Y = ( point.Y - origin_y ) / cell_height - cell_origin_y;
		}

		internal void ComputeCellFromPoint( Point point, Layer relative_layer, out Point result )
		{
			result = new Point();
			int origin_x = ( width ) / 2;
			int origin_y = ( height ) / 2;
			if( ( point.X - origin_x ) < 0 )
				origin_x += ( cell_width / 2 );
			else
				origin_x -= ( cell_width / 2 );
			if( ( point.Y - origin_y ) < 0 )
				origin_y += ( cell_height / 2 );
			else
				origin_y -= ( cell_height / 2 );
			// here we subtract the origin_x, because this means the origin is out at that point... so we'd be closer to it if 
			// the cursor were also far.
			if( relative_layer.flags.bRoot )
			{
				result.X = ( point.X - origin_x ) / cell_width - ( relative_layer.X );
				result.Y = ( point.Y - origin_y ) / cell_height - ( relative_layer.Y );
			}
			else
			{	
				result.X = ( point.X - origin_x ) / cell_width - ( relative_layer.X + cell_origin_x );
				result.Y = ( point.Y - origin_y ) / cell_height - ( relative_layer.Y + cell_origin_y );
			}
		}

		internal Rectangle GetOutputRect( int x, int y, int width, int height )
		{
			return new Rectangle( ( Width / 2 - cell_width / 2 ) + ( x + cell_origin_x ) * cell_width
						, ( Height / 2 - cell_height / 2 ) + ( y + cell_origin_y ) * cell_height
						, width * cell_width
						, height * cell_height );
		}

		internal void FormDraw( System.Drawing.Graphics graphics )
		{
			foreach( Layer layer in layers )
			{
				layer.FormDraw( graphics );
			}
		}

		public bool Load( System.Xml.XPath.XPathNavigator r )
		{
			if( r.Name == "BoardInformation" )
			{
				foreach( Type root_type in BoardPlugin.RootPeiceTypes )
				{
					if( r.Value == root_type.ToString() )
					{
						// call the property to setup other stuff
						peices = BoardPlugin.PeiceTypes[root_type];
						if( layers == null )
							layers = new LinkedList<Layer>();
						layers.Clear();
						layers.AddLast( background = new Layer( this, peices[0] ) );
						background.flags.bRoot = true;
						background.peice_instance = background.peice.CreateInstance( null, null );
					}
				}
				if( r.MoveToFirstChild() )
				{
					
					do
					{
						if( r.Name == "Peice" )
						{
							foreach( PeiceRepresentation peice in peices )
							{
								if( r.Value == peice.GetType().ToString() )
								{
									r.MoveToFirstChild();
									peice.Load( r );
									r.MoveToParent();
									break;
								}
							}
						}
					}
					while( r.MoveToNext() );
					r.MoveToParent();
				}
				if( r.MoveToFirstAttribute() )
				{
					do
					{
						if( r.Name == "CellWidth" )
							cell_width = r.ValueAsInt;
						if( r.Name == "CellHeight" )
							cell_height = r.ValueAsInt;

					} while( r.MoveToNextAttribute() );
					r.MoveToParent();
				}
				return true;
			}
			return false;
		}

		public void Save( System.Xml.XmlWriter w )
		{
			if( root_type != null )
			{
				w.WriteStartElement( "BoardInformation" );
				w.WriteAttributeString( "CellWidth", cell_width.ToString() );
				w.WriteAttributeString( "CellHeight", cell_height.ToString() );
				foreach( PeiceRepresentation peice in peices )
				{
					w.WriteStartElement( "Peice" );
					w.WriteAttributeString( "Type", peice.GetType().ToString() );
					peice.Save( w );
					w.WriteEndElement();
				}
				w.WriteString( root_type.ToString() );
				w.WriteEndElement();
			}
		}



		internal Layer GetLayerAt( ref Point cell_click_origin, int level )
		{
			Layer default_layer = null;
			foreach( Layer layer in layers )
			{
				// touch
				if( layer.flags.bRoot )
					default_layer = layer;
				else
				{
					int x = cell_click_origin.X;
					int y = cell_click_origin.Y;
					if( layer.IsLayerAt( ref x, ref y ) )
					{
						if( --level == 0 )
						{
							cell_click_origin.X = x;
							cell_click_origin.Y = y;
							return layer;
						}
					}
				}
			}
			return default_layer;
		}

		internal Layer GetLayerAt( ref Point cell_click_origin )
		{
			return GetLayerAt( ref cell_click_origin, 1 );
		}


		internal Layer GetTopLayerAt( ref Point cell_click_origin, int level )
		{
			Layer default_layer = null;
			for( LinkedListNode<Layer> layer = layers.Last; layer != null; layer = layer.Previous )
			{
				// touch
				if( layer.Value.flags.bRoot )
					default_layer = layer.Value;
				else
				{
					int x = cell_click_origin.X;
					int y = cell_click_origin.Y;
					if( layer.Value.IsLayerAt( ref x, ref y ) )
					{
						if( --level == 0 )
						{
							cell_click_origin.X = x;
							cell_click_origin.Y = y;
							return layer.Value;
						}
					}
				}
			}
			return default_layer;
		}

		internal Layer GetTopLayerAt( ref Point cell_click_origin )
		{
			return GetTopLayerAt( ref cell_click_origin, 1 );
		}


		internal Layer GetBackgroundLayer( )
		{
			foreach( Layer layer in layers )
			{
				if( layer.flags.bRoot )
					return layer;
			}
			return null;
		}
		public Layer BeginVia( Layer parent, int x, int y, Type peice_type, object instance )
		{
			foreach( PeiceRepresentation peice in peices )
			{
				if( peice.GetType().Equals( peice_type ) )
				{
					// x and y coordinates were relative to the parent peice. the parent's position is aboslute always
					Layer layer = new Layer( this, peice, parent.X + x, parent.Y + y, instance );
					layers.AddLast( layer );
					return layer;
				}
			}
			return null;
			
		}
	}
}
