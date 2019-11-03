using System;
using System.Collections.Generic;
using xperd3x.d3d;
using xperdex.classes;
// this is a thing that is not always available!
//C:\Windows\Microsoft.NET\DirectX for Managed Code\1.0.2902.0\Microsoft.DirectX.DirectDraw.dll
//Core DirectDraw classes for Managed DirectX
using Direct3D = Microsoft.DirectX.Direct3D;
using System.Drawing;
using System.Drawing.Imaging;

namespace xperdex.layout.board
{
	public class Layer : IDisposable
	{
		static ImageAttributes imageAttrTransparent = new ImageAttributes();

		static Layer()
		{
			//imageAttrTransparent.
		}

		// only need this for draw - maybe this should be passed to draw?
		Board board;

		internal struct LayerFlags {
			// if this is a route, then this marks
			// whether the first node on the route
			// must remain in this direction
			// of if it may be changed.
			internal bool bForced;
			internal bool bEnded; // layed an end peice.
			// is a set of vias, and pds_path is used
			// to hold how, what, and where to draw.
			// all segments represent a single object (psvInstance)
			internal bool bRoute;
			internal bool bRoot; // member 0 of pool is 'root'
		}
		internal LayerFlags flags;


		internal PeiceRepresentation peice;
		internal object peice_instance;
		//internal object peice_instance;
		// path might contain only a single anchor point.
		// otherwise the path is a linear list of path nodes along which
		// each cell is created.
		List<LayerPathNode> path;

		/// <summary>
		/// This is the origin point x, y of the route - for splotch type peices, this is where the hotspot is placed
		/// </summary>
		int x, y;
		internal int X{
			get
			{
				if( flags.bRoot )
					return board.CellOriginX;
				return x;
			}
			set
			{
				if( flags.bRoot )
					board.CellOriginX = value;
				else
					x = value;
			}
		}

		internal int Y
		{
			get
			{
				if( flags.bRoot )
					return board.CellOriginY;
				return y;
			}
			set
			{
				if( flags.bRoot )
					board.CellOriginY = value;
				else
					y = value;
			}
		} 

		int min_x;
		int min_y;
		int w;
		int h;

		Local.Dirs Opposite(Local.Dirs n) 
		{
			return (Local.Dirs)( ( ( (int)n ) + 4 ) & 7 );
		}
		Local.Dirs Left(Local.Dirs n)   
		{
			return (Local.Dirs)( ( ( (int)n ) - 1 ) & 7 );
		}
		Local.Dirs Right(Local.Dirs n)   
		{
			return (Local.Dirs)( ( ( (int)n ) + 1 ) & 7 );
		}


		Local.Dirs LeftOrRight(Local.Dirs n,Local.Dirs i)    
		{
			return ( ( ( ( (int)n ) & 1 ) != 0 ) 
				? ( ( i != Local.Dirs.Up ) 
					? Left( n ) 
					: Right( n ) ) 
				: ( ( i != Local.Dirs.Up ) ? Right( n ) : Left( n ) ) );	
		}
		Local.Dirs NearDir(Local.Dirs nNewDir,Local.Dirs nDir) 
		{
			return ( ( nNewDir == nDir ) ? (Local.Dirs)0 :
			( nNewDir == (Local.Dirs)( ( ( (int)nDir ) + 1 ) & 7 ) ) ? Local.Dirs.Nowhere :
			( nNewDir == (Local.Dirs)( ( ( (int)nDir ) - 1 ) & 7 ) ) ? (Local.Dirs)1 : (Local.Dirs)Local.Dirs.NotNear );
		}

		internal struct layer_path_flags
		{

			// Index into PEICE array is stored...
			// board contains an array of peices....
			// as a bitfield these do not expand correctly if signed.
			internal Local.Dirs BackDir;// : 4;
			internal Local.Dirs ForeDir;// : 4;
			// forced set on first node cannot be cleared!
			// other nodes other than the first may have forced.
			// which indicates that the foredir MUST be matched.
			// these nodes do not unlay either.  Need to compute
			// the NEXT layer with a LeftOrRight correction factor
			internal bool bForced;
			// if bLeft, and bForced
			// UnlayerPath sets bRight and results with this layer intact.
			// if bLeft AND bRight AND bForced
			// UnlayerPath removes this node (if BackDir != NOWHERE)
			internal bool bFlopped;// : 1; // starts at 0.  Moves ForDir +/- 1
			internal bool bTry;// : 1; // set if a hard direction tendancy was set ...
			// repeat above with right, setting left, moving left...
			internal bool bRight;// : 1; // starts at 0.  Moves ForDir +/- 1
			// foredir, backdir are unused if the peice is a filler
			// x, y of the data node will be an offset from the current
			// at which place the filler from viaset.GetViaFill1() and 2 will be done
			// actually x, y are unused, since the offset is resulted from the before
			// actually it looks like fillers don't need to be tracked, just drawn
			//int bFiller : 4;
		}


		public void SetColor( ImageAttributes imageAtt, Color c, Color secondary, Color tertiary )
		{
			ColorMatrix mask_colorMatrix = new ColorMatrix();
			mask_colorMatrix[4, 4] = 1;

			mask_colorMatrix[2, 0] = ( c.R + 1 ) / 256F;
			mask_colorMatrix[2, 1] = ( c.G + 1 ) / 256F;
			mask_colorMatrix[2, 2] = ( c.B + 1 ) / 256F;
			mask_colorMatrix[2, 3] = ( c.A + 1 ) / 256F;
			mask_colorMatrix[3, 3] = ( mask_colorMatrix[1, 3] * mask_colorMatrix[2, 3] );
			imageAtt.SetColorMatrix(
				mask_colorMatrix,
				ColorMatrixFlag.Default,
				ColorAdjustType.Bitmap );

			mask_colorMatrix[1, 0] = ( secondary.R + 1 ) / 256F;
			mask_colorMatrix[1, 1] = ( secondary.G + 1 ) / 256F;
			mask_colorMatrix[1, 2] = ( secondary.B + 1 ) / 256F;
			mask_colorMatrix[1, 3] = ( secondary.A + 1 ) / 256F;
			mask_colorMatrix[3, 3] = ( mask_colorMatrix[1, 3] * mask_colorMatrix[2, 3] );
			imageAtt.SetColorMatrix(
				mask_colorMatrix,
				ColorMatrixFlag.Default,
				ColorAdjustType.Bitmap );
			mask_colorMatrix[0, 0] = ( tertiary.R + 1 ) / 256F;
			mask_colorMatrix[0, 1] = ( tertiary.G + 1 ) / 256F;
			mask_colorMatrix[0, 2] = ( tertiary.B + 1 ) / 256F;
			mask_colorMatrix[0, 3] = ( tertiary.A + 1 ) / 256F;
			mask_colorMatrix[3, 3] = ( mask_colorMatrix[1, 3] * mask_colorMatrix[2, 3] * mask_colorMatrix[0, 3] );

			imageAtt.SetColorMatrix(
				mask_colorMatrix,
				ColorMatrixFlag.Default,
				ColorAdjustType.Bitmap );
		}



		public void ColorMask( Image src, Graphics d, Rectangle srcrect, Rectangle dstrect )
		{
			// Create an ImageAttributes object and set its color matrix.
			//d.CompositingMode = System.Drawing.Drawing2D.CompositingMode.SourceCopy;
			//d.Clear( Color.Transparent );
			//d.FillRectangle(Brushes.Transparent, 0, 0, dest.Width, dest.Height);
			//d.CompositingMode = System.Drawing.Drawing2D.CompositingMode.SourceOver;
			switch( peice.draw_mode )
			{
				case PeiceAttribute.DrawModes.Plain:
					d.DrawImage( src
						 , dstrect  // destination rectangle
						 , srcrect
						 , GraphicsUnit.Pixel
						 ); // no attribute matrix.
					break;
				case PeiceAttribute.DrawModes.MonoShade:
					{
						ImageAttributes imageAtt = new ImageAttributes();
						Color a;
						peice.GetShadeParameter( peice_instance, out a );
						ColorMatrix mask_monocolorMatrix = new ColorMatrix();
						mask_monocolorMatrix[2, 2] = ( a.B + 1 ) / 256F;
						mask_monocolorMatrix[1, 1] = ( a.G + 1 ) / 256F;
						mask_monocolorMatrix[0, 0] = ( a.R + 1 ) / 256F;
						mask_monocolorMatrix[3, 3] = ( a.A + 1 ) / 256F;
						mask_monocolorMatrix[4, 4] = 1;
						d.DrawImage( src
							 , dstrect
							 , 0.0f                          // source rectangle x 
							 , 0.0f                          // source rectangle y
							 , src.Width                        // source rectangle width
							 , src.Height                       // source rectangle height
							 , GraphicsUnit.Pixel
							 , imageAtt
							 );
					}
					break;
				case PeiceAttribute.DrawModes.MultiShaded:
					{
						ImageAttributes imageAtt;
						imageAtt = new ImageAttributes();
						Color a, b, c;
						peice.GetMultiShadeParameters( peice_instance, out a, out b, out c );
						SetColor( imageAtt, a, b, c );
						d.DrawImage( src
							 , dstrect  // destination rectangle
							 , (float)srcrect.Left                       // source rectangle height
							 , (float)srcrect.Top
							 , (float)srcrect.Right
							 , (float)srcrect.Bottom
							 , GraphicsUnit.Pixel
							 , imageAtt
							 );
					}
					break;
			}

		}


		void FormDrawBackground( Graphics g )
		{
			peice.LoadTexture();
			int origin_x = ( board.Width / 2 ) - ( board.CellWidth / 2 );
			int origin_y = ( board.Height / 2 ) - ( board.CellHeight / 2 );
			int offset_origin_x = origin_x - board.CellWidth * peice.HotspotX 
				+ ((board.CellOriginX % peice.Cols ) * board.CellWidth);
			int offset_origin_y = origin_y - board.CellHeight * peice.HotspotY 
				+ ((board.CellOriginY % peice.Rows )* board.CellHeight);
			int interval_x = board.CellWidth * peice.Cols;
			int interval_y = board.CellHeight * peice.Rows;

			while( offset_origin_x > 0 )
				offset_origin_x -= interval_x;
			while( offset_origin_y > 0 )
				offset_origin_y -= interval_y;

			for( int x = 0; ( offset_origin_x + x ) < board.Width; x += interval_x )
			{
				for( int y = 0; ( offset_origin_y + y ) < board.Height; y += interval_y )
				{
					if( peice.Image == null )
					{
						Rectangle points;
						g.FillRectangle( SystemBrushes.WindowFrame
							    , points = new Rectangle( x + offset_origin_x
									, y + offset_origin_y
									, peice.Cols * board.CellWidth
								, peice.Rows * board.CellHeight ) );
						g.DrawLine( Pens.Red, points.Left, points.Top, points.Right, points.Bottom );
						g.DrawLine( Pens.Red, points.Left, points.Bottom, points.Right, points.Top );
						g.DrawLine( Pens.Red, points.Left, points.Top, points.Left, points.Bottom );
						g.DrawLine( Pens.Red, points.Left, points.Top, points.Right, points.Top );
					}
					else
						g.DrawImage( peice.Image
							, new Rectangle( x + offset_origin_x
								, y + offset_origin_y
								, interval_x
								, interval_y )
							, new Rectangle( 0, 0, peice.Image.Width, peice.Image.Height ) 
							, GraphicsUnit.Pixel
							);
				}
			}

		}

		internal void FormDraw( Graphics g )
		{
			Int32 cellx, celly;
			Int32 boardx, boardy;
			int scale;

			if( flags.bRoot )
			{
				FormDrawBackground( g );
				return;
			}

			peice.LoadTexture();
			if( peice.Image == null )
			{
				if( flags.bRoute )
				{
					
				}
				else
				{
					Rectangle points = board.GetOutputRect( x - peice.HotspotX, y - peice.HotspotY, peice.Cols, peice.Rows );
					g.FillRectangle( SystemBrushes.Window, points );
					g.DrawLine( Pens.Red, points.Left, points.Top, points.Right, points.Bottom );
					g.DrawLine( Pens.Red, points.Left, points.Bottom, points.Right, points.Top );
					return;
				}
			}
			
			//Log.log( "Drawing a cell...%p at %d,%d", image, x, y );
			scale = board.Scale;
			boardx = board.Width;
			boardy = board.Height;
			cellx = board.CellWidth;
			celly = board.CellHeight;
			if( flags.bRoute )
			{
				int n;
				//DebugBreak();
				LayerPathNode node;
				ViaRepresentation viaset = peice as ViaRepresentation;
				for( n = 0; n < path.Count && ( ( node = path[n] ) != null ); n++ )
				{
					int xofs = 0;
					int yofs = 0;
					Cell fill;

					if( ( node.x + x ) < board.CellMinX ||
						( node.x + x ) > board.CellMaxX )
						continue;
					if( ( node.y + y ) < board.CellMinY ||
						( node.y + y ) > board.CellMaxY )
						continue;


					//Log.log( "Drawing route path node %p %d,%d  %d,%d"
					//		 , node, node.x, node.y
					//		 , node.flags.ForeDir, node.flags.BackDir );
					if( viaset.GetViaFromTo( node.flags.BackDir, node.flags.ForeDir, scale, out fill ) )
					if( fill != null )
					{
						if( peice.Image == null )
						{
							g.FillRectangle( new SolidBrush( Color.Blue )
								, board.GetOutputRect( node.x + x, node.y + y, 1, 1 )
								);
						}
						else
							g.DrawImage( peice.Image
								, board.GetOutputRect( node.x + x, node.y + y, 1, 1 )
								, new Rectangle( fill.x_ofs * peice.Image.Width / peice.Cols
									, fill.y_ofs * peice.Image.Height / peice.Rows
									, peice.Image.Width / peice.Cols
									, peice.Image.Height / peice.Rows )
											, GraphicsUnit.Pixel );
					}
					//else
					//   Log.log( "filler for %d,%d failed", node.flags.BackDir, node.flags.ForeDir );
					if( viaset.GetViaFill1( ref xofs, ref yofs, node.flags.ForeDir, scale, out fill ) )
					if( fill != null )
					{
						if( peice.Image == null )
						{
							g.FillRectangle( new SolidBrush( Color.Blue )
								, board.GetOutputRect( node.x + x, node.y + y, 1, 1 )
								);
						}
						else
							g.DrawImage( peice.Image
								, new Rectangle( fill.x_ofs * board.CellWidth
									, fill.y_ofs * board.CellHeight
									, board.CellWidth, board.CellHeight )
											, fill.image_rectangle( peice, peice.Image )
											, GraphicsUnit.Pixel );
					}
					//else
					//   Log.log( "filler for %d,%d failed", node.flags.BackDir, node.flags.ForeDir );
					if( viaset.GetViaFill2( ref xofs, ref yofs, node.flags.ForeDir, scale, out fill ) )
					if( fill != null )
					{
						if( peice.Image == null )
						{
							g.FillRectangle( new SolidBrush( Color.Blue )
								, board.GetOutputRect( node.x + x, node.y + y, 1, 1 )
								);
						}
						else
							g.DrawImage( peice.Image
								, new Rectangle( fill.x_ofs * board.CellWidth
									, fill.y_ofs * board.CellHeight
									, board.CellWidth, board.CellHeight )
											, fill.image_rectangle( peice, peice.Image )
											, GraphicsUnit.Pixel );
					}
					//else
					//   Log.log( "filler for %d,%d failed", node.flags.BackDir, node.flags.ForeDir );
				}
			}
			else
			{
				// this requires knowing cellsize, and the current offset/origin of the
				// layer/board...
				int hotx = peice.HotspotX;
				int hoty = peice.HotspotY;
				int rows = peice.Rows, cols = peice.Cols;
				int xofs, yofs;

				Rectangle points = board.GetOutputRect( x - peice.HotspotX, y - peice.HotspotY, peice.Cols, peice.Rows );
				if( peice.draw_mode == PeiceAttribute.DrawModes.MultiShaded )
				{
					ColorMask( peice.Image, g
						, new Rectangle( 0, 0, peice.Image.Width, peice.Image.Height )
						, points
					);
				}
				else if( peice.draw_mode == PeiceAttribute.DrawModes.MonoShade )
				{
					ColorMask( peice.Image, g
						, new Rectangle( 0, 0, peice.Image.Width, peice.Image.Height )
						, points
					);
				}
				else
				{
					g.DrawImage( peice.Image
						, new Rectangle( 0, 0, peice.Image.Width, peice.Image.Height )
						, points
						, GraphicsUnit.Pixel
					);
				}

			}
		}

		internal void Draw( D3DState state )
		{
			Int32 cellx, celly;
			Int32 boardx, boardy;
			int scale;
			if( flags.bRoot )
				return;

			state.graphics.SetTexture( 0, peice.texture );

			state.graphics.TextureState[0].AlphaOperation = Direct3D.TextureOperation.SelectArg1;
			state.graphics.TextureState[0].AlphaArgument1 = Direct3D.TextureArgument.TextureColor;

			state.graphics.VertexFormat = Direct3D.CustomVertex.PositionTextured.Format;

			//Log.log( "Drawing a cell...%p at %d,%d", image, x, y );
			scale = board.Scale;
			boardx = board.Width;
			boardy = board.Height;
			cellx = board.CellWidth;
			celly = board.CellHeight;
			if( flags.bRoute )
			{
				int n;
				//DebugBreak();
				LayerPathNode node;
				ViaRepresentation viaset = peice as ViaRepresentation;
				for( n = 0; n < path.Count && ( ( node = path[n] ) != null ); n++ )
				{
					int xofs = 0;
					int yofs = 0;
					Cell fill;
					//Log.log( "Drawing route path node %p %d,%d  %d,%d"
					//		 , node, node.x, node.y
					//		 , node.flags.ForeDir, node.flags.BackDir );
					if( viaset.GetViaFromTo( node.flags.BackDir, node.flags.ForeDir, scale, out fill ) )
					if( fill != null )
					{
						// need to set the current position offset in the translation matrix
						state.graphics.SetStreamSource( 0, fill.cell_verts, 0 );
						state.graphics.DrawPrimitives( Direct3D.PrimitiveType.TriangleStrip, 0, 2 );
					}
					//else
					//   Log.log( "filler for %d,%d failed", node.flags.BackDir, node.flags.ForeDir );
					if(  viaset.GetViaFill1( ref xofs, ref yofs, node.flags.ForeDir, scale, out fill ) )
					if( fill != null )
					{
						// need to set the current position offset in the translation matrix
						state.graphics.SetStreamSource( 0, fill.cell_verts, 0 );
						state.graphics.DrawPrimitives( Direct3D.PrimitiveType.TriangleStrip, 0, 2 );
						//, x + ( node.x + xofs ) * cellx
						//, y + ( node.y + yofs ) * celly );
					}
					//else
					//   Log.log( "filler for %d,%d failed", node.flags.BackDir, node.flags.ForeDir );
					if( viaset.GetViaFill2( ref xofs, ref yofs, node.flags.ForeDir, scale, out fill ) )
					if( fill != null )
					{
						// need to set the current position offset in the translation matrix
						state.graphics.SetStreamSource( 0, fill.cell_verts, 0 );
						state.graphics.DrawPrimitives( Direct3D.PrimitiveType.TriangleStrip, 0, 2 );
						//, x + ( node.x + xofs ) * cellx
						//, y + ( node.y + yofs ) * celly );

					}
					//else
					//   Log.log( "filler for %d,%d failed", node.flags.BackDir, node.flags.ForeDir );
				}
			}
			else
			{
				// this requires knowing cellsize, and the current offset/origin of the
				// layer/board...
				int hotx = peice.HotspotX;
				int hoty = peice.HotspotY;
				int rows = peice.Rows, cols = peice.Cols;
				int xofs, yofs;
				// maximum number of cells on the board...
				// so we don't over draw.
				// later, when I get more picky, only draw those cells that changed
				// which may include an offset
				//Log.log( "Drawing layer at %d,%d (%d,%d) origin at %d,%d", LAYER::x, LAYER::y, hotx, hoty, x, y );
				if( true )
				{

					for( xofs = -hotx; xofs < ( cols - hotx ); xofs++ )
						for( yofs = -hoty; yofs < ( rows - hoty ); yofs++ )
						{
							//state.graphics.SetStreamSource( 0, fill.cell_verts, 0 );
							state.graphics.DrawPrimitives( Direct3D.PrimitiveType.TriangleStrip, 0, 2 );
							//LayerData.peice.methods.Draw( LayerData.psvInstance
							//										  , image
							//										  , LayerData.peice.getcell( xofs + hotx, yofs + hoty, scale )
							//										  , x + xofs * cellx
							//										  , y + yofs * celly );
						}
				}
				else
				{
					//state.graphics.SetStreamSource(0, fill.cell_verts, 0);
					state.graphics.DrawPrimitives( Direct3D.PrimitiveType.TriangleStrip, 0, 2 );
					//LayerData.peice.methods.Draw( LayerData.psvInstance
					//										  , image
					//							  , LayerData.peice.getimage( scale )
					//										  , x, y );
				}
			}
		}



		internal class LayerPathNode{
			internal layer_path_flags flags; // 8 bits need 9 values (-1 being nowhere) 0-7, -1 ( 0xF )
			internal int x, y;
			internal Layer linked_layer;
			internal LayerPathNode( int x, int y, Local.Dirs foredir, Local.Dirs backdir )
			{
				this.x = x;
				this.y = y;
				this.flags.BackDir = backdir;
				if( foredir == Local.Dirs.Nowhere )
				{
					// there is no real peice which is
					// NOWHERE to NOWHERE, therefore, do not attempt to draw one
					// and instead set the exit direction as valid.
					this.flags.bForced = false;
					this.flags.ForeDir = foredir;
				}
				else
				{
					this.flags.bForced = true;
					this.flags.ForeDir = foredir;
				}
			}
		}


		//--------------------------------------------------------------------------



		void BeginPath( int x, int y, Local.Dirs direction )
		{
			LayerPathNode node;
			this.x = x;
			this.y = y;

			this.min_x = x;
			this.min_y = y;
			this.w = 1;
			this.h = 1;

			flags.bRoute = true;

			path = new List<LayerPathNode>();
			path.Add( new LayerPathNode( 0, 0, direction, Local.Dirs.Nowhere ) );

		}

		void BeginPath( int x, int y )
		{
			BeginPath( x, y, Local.Dirs.Nowhere );
		}

		//--------------------------------------------------------------------------

		void link_top()
		{
		}

		//--------------------------------------------------------------------------


		void isolate()
		{
			// can't isoloate root
			if( flags.bRoot )
				return ;
		}

		//--------------------------------------------------------------------------

		void Init()
		{
		   //LayerData = new LAYER_DATA(
			//LayerData.Other.dwAny = 0;
			//LayerData.DrawMethod = DRAW_RAW;
			//flags.BackDir = NOWHERE;
			//flags.ForeDir = NOWHERE;
			//Content = 0;  // should be FindPeice(NOT_BLANK)
			flags.bRoot = false;
			x = 0;
			y = 0;
			w = 0;
			h = 0;
			path = new List<LayerPathNode>();
		   //path = NULL;
			//shadows = NULL;
		}

		//--------------------------------------------------------------------------
#if asdfasdf
		public Layer()
		{
		   Init();
		}

		//--------------------------------------------------------------------------

		public Layer( PeiceRepresentation peice, int _x, int _y, int _w, int _h )
		{
			Init();
			x = _x;
			y = _y;
			min_x = _x;
			min_y = _y;
			w = _w;
			h = _h;
			this.peice = peice;
		}

		//--------------------------------------------------------------------------

		public Layer( PeiceRepresentation peice, int _x, int _y, int ofsx, int ofsy, int _w, int _h )
		{
			Init();
			x = _x;
			y = _y;
			min_x = _x - ofsx;
			min_y = _y - ofsy;
			w = _w;
			h = _h;
			this.peice = peice;
		}

		//--------------------------------------------------------------------------

		public Layer( Via peice )
		{
			// as a route, we have to expect some further information to
			// happen, and since we need to call create to generate the instance
			// of the peice, then do some user defined things, then
			// determine whether this even is valid to do, and if it is, where the
		   // position to start is...
			Init();
			flags.bRoute = true;
			this.peice = peice;
		}

		//--------------------------------------------------------------------------

		public Layer( Peice peice )
		{
			// as a route, we have to expect some further information to
			// happen, and since we need to call create to generate the instance
			// of the peice, then do some user defined things, then
			// determine whether this even is valid to do, and if it is, where the
		   // position to start is...
			Init();
			//this.peice = peice;
		}
#endif
		//--------------------------------------------------------------------------

		/// <summary>
		/// Place a Root PeiceRepresentation on a board.
		/// </summary>
		/// <param name="board"></param>
		/// <param name="peice"></param>
		public Layer( Board board, PeiceRepresentation peice )
		{
			// as a route, we have to expect some further information to
			// happen, and since we need to call create to generate the instance
			// of the peice, then do some user defined things, then
			// determine whether this even is valid to do, and if it is, where the
			// position to start is...
			Init();
			flags.bRoot = true;
			this.board = board;
			this.peice = peice;
			//peice.AddInstance( );
		}

		//--------------------------------------------------------------------------

		/// <summary>
		/// Place a normal peice on the board at X, Y
		/// </summary>
		/// <param name="board"></param>
		/// <param name="peice"></param>
		/// <param name="_x"></param>
		/// <param name="_y"></param>
		public Layer( Board board, PeiceRepresentation peice, int _x, int _y, object parent_instance )
		{
			Init();

			this.board = board;
			x = _x;
			y = _y;
			w = peice.Rows;
			h = peice.Cols;
			min_x = -peice.HotspotX;
			min_y = -peice.HotspotY;

			this.peice = peice;
			this.peice_instance = peice.CreateInstance( peice, parent_instance );
			if( peice.GetType().IsSubclassOf( typeof( ViaRepresentation ) ) )
			{
				BeginPath( x , y );
			}

		}

		//--------------------------------------------------------------------------

		object CheckIsLayer( object p, object psv )
		{
			Layer layer = (Layer)p;
			if( layer.iLayer == psv )
				return layer;
			return 0;
		}

		public Layer( DsnConnection odbc, List<iPeice> peices, UInt32 iLoadLayer )
		{
			if( this == null )
				return;
			if( iLayer != null )
			{
				//Log.log( "Recovering prior layer" );
				return;
			}
#if asdfasdf
			{
				BoardStorageDataSet.BoardLayersDataTable table = new BoardStorageDataSet.BoardLayersDataTable();
				DsnSQLUtil.FillDataTable( odbc, table, "board_layer_id='" + board.iBoard + "'" );
				DbDataReader reader = odbc.KindExecuteReader( "select x,y,min_x,min_y,width,height,linked_from_id,linked_from_x,linked_from_y,linked_to_id,linked_to_x,linked_to_y,route,peice_info_id,peice_type from board_layer where board_layer_id=" + iLoadLayer );
				if( reader != null && reader.HasRows ) while( reader.Read() )
				{
					PIPEICE peice_type = board.GetPeice( peices, reader["peice_type"] );
					
					LayerData.psvInstance = peice_type.Load( odbc, atoi( results[13] ) );//, LayerData.psvInstance );
					LayerData.SetPeice( peice_type );
					path = new List<LayerPathNode>();
					x = reader.GetInt32( 0 );
					y = reader.GetInt32( 1 );
					min_x = reader.GetInt32( 2 );
					min_y = reader.GetInt32( 3 );
					w = reader.GetUInt32( 4 );
					h = reader.GetUInt32( 5 );
					flags.bRoute = reader.GetInt32( 12 );

					iLayer = iLoadLayer;

					String iStart = reader.GetString( 6 );
					if( iStart !=  )
					{
						int x, y;
						x = atoi( results[7] );
						y = atoi( results[8] );
						Layer loaded_route_start_layer;
						loaded_route_start_layer = FindLayer( iStart );
						if( !loaded_route_start_layer )
							loaded_route_start_layer = GetFromSet( LAYER, pool ); //new(pool,LayerData.pool) LAYER( odbc, peices, iStart );
						loaded_route_start_layer.LayerData.peice.methods.ConnectBegin( loaded_route_start_layer.LayerData.psvInstance
														, x, y // connect x, y
														, LayerData.peice, LayerData.psvInstance );
						loaded_route_start_layer.Link( this, LINK_VIA_START, x, y);
					}

					INDEX iEnd = strtoul( results[9], NULL, 10 );
					if( iEnd != INVALID_INDEX )
					{
						int x, y;
						x = atoi( results[10] );
						y = atoi( results[11] );
						Layer loaded_route_end_layer;
						loaded_route_end_layer = FindLayer( iEnd );
						if( !loaded_route_end_layer )
							loaded_route_end_layer = GetFromSet( LAYER, pool ); //new(pool,LayerData.pool) LAYER( odbc, peices, iEnd );
						loaded_route_end_layer.LayerData.peice.methods.ConnectEnd( loaded_route_end_layer.LayerData.psvInstance
														, x, y // connect x, y
														, LayerData.peice, LayerData.psvInstance );
						loaded_route_end_layer.Link( this, LINK_VIA_END, x, y );
					}



					//}
				}
				for( SQLRecordQueryf( odbc, NULL, &results, NULL, "select x,y,fore,back from board_layer_path where board_layer_id=%lu order by board_layer_path_id desc", iLoadLayer );
					results;
					FetchSQLRecord( odbc, &results ) )
				{
					// add path node for a routed type peice
					LayerPathNode node;
					node.x = atoi( results[0] );
					node.y = atoi( results[1] );
					node.flags.ForeDir = atoi( results[2] );
					node.flags.BackDir = atoi( results[3] );
					PushData( &path, &node );
				}
				PopODBCEx( odbc );
			}
#endif
		   //return iLayer;
		}

		//--------------------------------------------------------------------------

		~Layer( )
		{
			//while( shadows )
		   //   delete shadows;
		   //delete LayerData;
		}

		//--------------------------------------------------------------------------


		PeiceRepresentation Peice {
			get 
			{
				return peice;
			}
		}


		void Unlink()
		{

		}

		List<Object> links = new List<object>();
		
		internal enum link_types
		{
			LINK_VIA_START,
			LINK_VIA_END
		}

		internal void Link( Layer via, link_types link_type, int x, int y )
		{
			// links via to this
			// or links via from this
			links.Add( via );
			via.links.Add( this );
			switch( link_type )
			{
			case link_types.LINK_VIA_START:
				//LayerPathNode lpn = new LayerPathNode( x, y, Local.Dirs.Nowhere, Local.Dirs.Nowhere );
				//via.route_start_layer.layer = this;
				//via.route_start_layer.x = x;
				//via.route_start_layer.y = y;
				
				break;
			case link_types.LINK_VIA_END:
				via.flags.bEnded = true;
				//via.route_end_layer.layer = this;
				//via.route_end_layer.x = x;
				//via.route_end_layer.y = y;
				break;
			}
			// and we need to consider how to recover the linked
			// state of the actual peices that are linked.
		}

		bool AllowLink( Layer other )
		{
			if( links.Contains( other ) )
				return false;
			if( other.links.Contains( this ) )
				return false;
			if( !peice.AllowLink( other.peice_instance ) )
				return false;
			if( !other.peice.AllowLink( peice_instance ) )
				return false;
			return true;
		}


		Local.Dirs GetLastBackDirection( )
		{
			LayerPathNode node;
			node = (LayerPathNode)path[path.Count-1];
			if( node != null )
			{
			  return node.flags.BackDir;
			}
			return Local.Dirs.Nowhere;
		}
		Local.Dirs GetLastForeDirection()
		{
			LayerPathNode node;
			node = path[path.Count-1];
			if( node != null )
			{
			  return node.flags.BackDir;
			}
			return Local.Dirs.Nowhere;
		}

		public bool IsLayerAt( ref int x, ref int y )
		{
			LayerPathNode node;
			int n;
			int relative_x = x - this.x;
			int relative_y = y - this.y;
			// width of 3.. offset 1, should be -1 and +1 of the x, y... not -1 and +2 (3)
			// difference is really only 2 when comparing as a corrdinate
			//Log.log( "layer test %d,%d within %d,%d-%d,%d", *x, *y, min_x, min_y, w, h );
			if( flags.bRoot 
				/*||
				( min_x + w ) <= relative_x ||
				( min_y + h ) <= relative_y ||
				( min_x > relative_x ) ||
				( min_y > relative_y ) */
			  )
				return false;
			if( !flags.bRoute )
			{
				if( ( min_x + w ) <= relative_x ||
					( min_y + h ) <= relative_y ||
					( min_x > relative_x ) ||
					( min_y > relative_y ) )
					return false;

				x = relative_x;
				y = relative_y;
				return true;
			}
			else
			{
			  //DebugBreak();
			}
			// otherwise, we need to check the path to see
			// if we're actually on this.
			for( n = 0; n < path.Count; n++ )
			{
				node = path[n];
				if( ( node.x + this.x ) == x && ( node.y + this.y ) == y )
				{
					x = node.x;
					y = node.y;
					return true;
				}
			}
			return false;
		}

		/// <summary>
		/// Returns the number of times this overlaps itself
		/// </summary>
		/// <param name="x"></param>
		/// <param name="y"></param>
		/// <returns></returns>
		int Overlaps( int x, int y )
		{
			int n;
			// just in case, don't check the top node
			// we may have been stupid...
			// and given current routing rules, there should never
			// be an opportunity which even the 5th segment might overlap.
			for( n = path.Count - 1; n >= 0; n-- )
			{
				LayerPathNode node = path[n];
				int xofs = 0;
				int yofs = 0;
				//Log.log( "checking overlap of %d,%d at %d,%d (%d)"
				//			 , x, y
				//		 , node.x, node.y, n );
				// should we test for overlap on via?
				// that's really the only way we can catch 50% of the intersections
				// of two diagonals, at shared via coordinate, instead of in-cell line overlap
				if( node.x == x && node.y == y )
				{
					return path.Count - n;
				}
				ViaRepresentation viaset = peice as ViaRepresentation;
				//if( n > 2 )
				Cell filler;
				if( viaset.GetViaFill1( ref xofs, ref yofs, node.flags.ForeDir, 0, out filler ) )
					if( ( ( node.x + xofs ) == x ) && ( ( node.y + yofs ) == y ) )
					{
						//Log.log("hit via fill1 of node %d,%d", xofs, yofs );
						return path.Count - n;
					}
				if( viaset.GetViaFill2( ref xofs, ref yofs, node.flags.ForeDir, 0, out filler ) )
					if( ( ( node.x + xofs ) == x ) && ( ( node.y + yofs ) == y ) )
					{
						//Log.log("hit via fill2 of node %d,%d", xofs, yofs );
						return path.Count - n;
					}
				if( viaset.GetViaFill1( ref xofs, ref yofs, node.flags.BackDir, 0, out filler ) )
					if( ( ( node.x + xofs ) == x ) && ( ( node.y + yofs ) == y ) )
					{
						//Log.log("hit via fill1 of node back %d,%d", xofs, yofs );
						return path.Count - n;
					}
				if( viaset.GetViaFill2( ref xofs, ref yofs, node.flags.BackDir, 0, out filler ) )
					if( ( ( node.x + xofs ) == x ) && ( ( node.y + yofs ) == y ) )
					{
						//Log.log("hit via fill2 of node back %d,%d", xofs, yofs );
						return path.Count - n;
					}
			}
			return 0;
		}

		// result is the last node (if any... which is a peekstack)
		LayerPathNode UnlayPath( int nLayers )
		{
			// unwind to, and including this current spot.
			// this is to handle when the line intersects itself.
			// other conditions of unlaying via pathways may require
			// other functionality.
			int n;
			LayerPathNode node = null;// = (LayerPathNode)PopData( &path );
			Log.log( "overlapped self at path segment %d" +  nLayers );
			for( n = nLayers; n != 0; n-- )
			{
				if( path.Count > 1 )
				{
					node = path[path.Count - 1];
					path.Remove( node );
					if( path.Count == 0 )
						throw new Exception( "Don't do that" );
					Log.log( "Popped node %d(%p)" + n + node );
				}
				if( path.Count > 0 )
				{
					// grab the NEXT node...
					// if it has bForced set... then this node must exist.
					LayerPathNode next = (LayerPathNode)path[path.Count - 1];
					if( next.flags.bForced )
					{
						Log.log( "DebugBreak" );
						//DebugBreak();
						node.flags.ForeDir = Local.Dirs.Nowhere;
						return node;
					}
					if( node.flags.bForced )
					{
						//DebugBreak();
						// this is SO bad.
					}
					//if( node.x == dest_x && node.y == dest_y )
					{
						//Log.log( "And then we find the node we overlaped..." );
					}
				}
				else
					node = null;
			}
			Log.log( "Okay done popping... "+n+", "+ node );
			if( node != null )
			{
				LayerPathNode next = path[path.Count-1];
				// set this as nowhere, so that we can easily just step forward here..
				if( next == null )
				{
					if( !node.flags.bForced )
					{
						node.flags.ForeDir = Local.Dirs.Nowhere;
					}
					path.Add( node );
					return node;
				}
				if( nLayers == 0 
					&& next.flags.bForced
					&& next.flags.BackDir != Local.Dirs.Nowhere )
				{
					// if it was forced, then this MUST be here.  There is a reason.
					// there is also a way to end this reason, and unlay 0 path.  This
					// releases the foredir to anything.  This may be used for error correction path
					// assumptions?
					//DebugBreak();
					if( next.flags.bTry )
					{
						node = path[path.Count-1];
						// this is the second attempt
						if( !node.flags.bFlopped )
						{
							node.flags.bFlopped = true;
							node.flags.ForeDir = LeftOrRight( Opposite( node.flags.BackDir ), (Local.Dirs)1 );
							return node;
						}
					}
					next.flags.bForced = false;
				}
				else
				{
					next.flags.ForeDir = Local.Dirs.Nowhere;
					Log.log( "this node itself is okay..." );
				}
				return next;
			}
			return null;
		}
		//------------------------------------------

		Local.Dirs FindDirection( int _x, int _y, int wX, int wY ) // From, To
		{
			Local.Dirs nDir;

			if( _x < wX ) 
			{
				if( _y > wY )
					nDir = Local.Dirs.UpRight;
				else if( _y < wY )
					nDir = Local.Dirs.DownRight;
				else
					nDir = Local.Dirs.Right;
			}
			else if( _x > wX )
			{
				if( _y > wY )
					nDir = Local.Dirs.UpLeft;
				else if( _y < wY )
					nDir = Local.Dirs.DownLeft;
				else
					nDir = Local.Dirs.Left;
			}
			else
			{
				if( _y > wY )
					nDir = Local.Dirs.Up;
				else if( _y == wY )
					nDir = Local.Dirs.Nowhere;
				else
					nDir = Local.Dirs.Down;
			}
			return nDir;
		}

#if asdfasdf
		void move( int del_x, int del_y )
		{
			x += del_x;
			y += del_y;
			min_x += del_x;
			min_y += del_y;
			{
				int idx;
				Layer layer;
				foreach( Layer layer in linked )
				{
					if( layer.flags.bRoute )
					{
						if( layer.route_end_layer.layer == this && layer.route_start_layer.layer != this )
						{
							LayerPathNode node = (LayerPathNode)PeekData( &layer.path );
							layer.LayPath( layer.x + ((!node)?0:node.x) + del_x
											  , layer.y + ((!node)?0:node.y) + del_y );
							// and here node is invalid!
						}
						if( layer.route_start_layer.layer == this )
						{
							LayerPathNode node = (LayerPathNode)PeekData( &layer.path );
							if( layer.route_end_layer.layer )
							{
								int destx = layer.route_end_layer.layer.x + layer.route_end_layer.x;
								int desty = layer.route_end_layer.layer.y + layer.route_end_layer.y;
								layer.BeginPath( layer.x + del_x, layer.y + del_y );
								layer.LayPath( destx, desty );
							}
							else
							{
								Log.log( "This via should have been deleted?!" );
							}
							//layer.UnlayPath(
							// RelayPathFrom( wX, wY );
						}
					}
				}
			}
		}
#endif
		internal void LayPath( int wX, int wY )
		{
			int DeltaDir;
			bool bLoop = false, bIsRetry;  // no looping....
			int tx, ty;
			int nPathLayed = 0;
			Local.Dirs nDir, nNewDir;
			bool bBackTrace = false,
				bFailed = false;

			LayerPathNode node;
			Log.log( "laying path From " + x + "," + y );
			Log.log( "Laying path " + this + " to "+ wX +","+ wY );

			node = path[path.Count - 1];
			// sanity validations...
			// being done already, etc...
			wX -= x;
			wY -= y;
			if( node != null )
			{
				if( node.x == wX && node.y == wY )
				{
					//Log.log( "Already at this end point, why are you telling me to end where I already did?" );
					return;
				}
				// should range check wX and wY to sane limits
				// but for now we'll trust the programmer...
				if( Math.Abs( node.x - wX ) > 100 || Math.Abs( node.y - wY ) > 100 )
				{
					throw new Exception( "Laying a LONG path - is this okay?!" );
					//DebugBreak();
					Log.log( "Laying a LONG path - is this okay?!" );
				}
			}

			Log.log( "Enter..." );
			
				//------------ FORWARD DRAWING NOW .....
			bIsRetry = false;
			DeltaDir = 0;
			{
				// get the last node in the path.
				node = path[path.Count - 1];
				while( node != null )
				{
					nNewDir = FindDirection( node.x
												  , node.y
												  , wX, wY );
					if( nNewDir == Local.Dirs.Nowhere )
					{
						// already have this node at the current spot...
						Log.log( "Node has ended here..." );
						break;
					}
					nDir = Local.Dirs.Nowhere; // intialize this, in case we missed a path below...
					if( node.flags.BackDir == Local.Dirs.Nowhere )
					{
						// if it is newdir, we're okay to go ahead with this plan.
						if( node.flags.ForeDir != nNewDir && flags.bForced )
						{
							Log.log( "Have a forced begin point, and no way to get there from here...." );
							//DebugBreak();
							if( NearDir( node.flags.ForeDir, nNewDir ) == Local.Dirs.NotNear )
							{
								Log.log( "MUST go %d , have to go %d from here.  Go nowhere."+ node.flags.ForeDir+ nNewDir );
								Log.log( "Okay - consider a arbitrary jump to go forward... until we can go backward." );
							}
							else
							{
								Log.log( "It's just not quite right... return, a less radical assumption may be made." );
							}
							return;
						}
						// else, just go ahead, we returned above here.
						node.flags.ForeDir = nNewDir;
					}
					else
					{
						// need to determine a valid foredir based on nNewDir desire, and nBackDir given.
						Log.log( "%d, %d = %d"
								 + Opposite( node.flags.BackDir ) +","
								 + nNewDir +"="
								 + NearDir( Opposite( node.flags.BackDir )
											 , nNewDir ) );
						Log.log( "newdir = %d backdir = %d" + nNewDir + ":" + node.flags.BackDir );
						//pold.ToLayer.ForeDir;
						if( NearDir( nNewDir, Opposite( node.flags.BackDir ) ) != Local.Dirs.NotNear )
						{
							// this is a valid direction to go.
							node.flags.ForeDir = nNewDir;
						}
						else
						{
							Log.log( "Unlay path cause we can't get there from here." );
							node = UnlayPath( nPathLayed + 1 );
							// at this point always unlay at least one more than we put down.
							nPathLayed = 1;
							continue;
		#if asdfsdaf
					   int nBase = Opposite( node.flags.BackDir );
							nDir = ( node.flags.BackDir + 2 ) & 7;
							if( NearDir( nNewDir, nDir ) != 10 )
							{
								//node.flags.ForeDir = (nBase + 6) &7;
								node.flags.ForeDir = Right( nBase );
							}
							else if( NearDir( nNewDir, Opposite( nDir ) ) != 10 )
							{
								node.flags.ForeDir = Left(nBase);
							}
							else
							{

								// this should be a random chance to go left or right...
								// maybe tend to the lower x or higher x ?
								Log.log( "Choosing an arbitrary directino of 1, and only on1" );
								//node.flags.ForeDir = Right( nBase + 1 );
								node.flags.bFlopped = 0;
								node.flags.bTry = 1;
								node.flags.bForced = 1;
								node.flags.ForeDir = LeftOrRight( nBase, node.flags.bFlopped );
								// set a flag in this node for which way to go...
								// but a left/right node needs the ability
								// to remain forced for a single unlay, and move in a direction...

							}
		#endif
						}
					}
					{
						int  n;
						tx = node.x + Local.DirDeltaMap[(int)node.flags.ForeDir].x;
						ty = node.y + Local.DirDeltaMap[(int)node.flags.ForeDir].y;
						Log.log( "New coordinate will be "+tx+"," +ty );
						if( ( n = Overlaps( tx, ty ) ) > 0 ) // aleady drew something here...
							// the distance of the overlap is n layers, including Nth layer
							// for( ; n; PopData(&pds_stack), n-- )
							// and some fixups which unlay path does.
						{
							Log.log( "Unlaying path %d steps to overlap" + n );
							node = UnlayPath( n );
							// at an unlay point of forced, unlay path should be 'smart' and 'wait'
							// otherwise we may unwind to our tail and be confused... specially when moving away
							// and coming back to reside at the center.
							// if the force direction to go from a forced node is excessive, that definatly
							// breaks force, and releases the path node.
							// there may be board conditions which also determine the pathing.
							// okay try this again from the top do {
							// startin laying path again.
							continue;
						}
						// otherwise we're good to go foreward.
						// at least we won't add this node if it would have
						// already been there, heck, other than that via's
						// don't exist, sometimes we'll even get the exact node
						// that this should be....
						{
							LayerPathNode newnode = new LayerPathNode( tx, ty, Local.Dirs.Nowhere, Opposite( node.flags.ForeDir ) );
							// this may be set intrinsically by being an excessive force
							// causing a large direction delta
							newnode.flags.bForced = false;
							{
								int xx = tx + x;
								int yy = ty + y;
								if( xx < min_x )
								{
									w += min_x - xx;
									min_x = xx;
								}
								if( xx >= ( min_x + (int)w ) )
									w = xx - min_x + 1;
								if( yy < min_y )
								{
									h += min_y - yy;
									min_y = yy;
								}
								if( yy >= ( min_y + (int)h ) )
									h = yy - min_y + 1;

							}
							Log.log( "Push path %d,%d  min=%d,%d size=%d,%d" + newnode.x + "," + newnode.y +"   "+ min_x + "," + min_y +"   "+ w + "," + h );
							path.Add( newnode );
							nPathLayed++;
							node = newnode; // okay this is now where we are.
						}
					}
				}
			}
		}

		object iLayer;

		object Save( DsnConnection odbc )
		{
			if( iLayer != null )
			{
				Log.log( "Recovering prior layer" );
				return iLayer;
			}

			{
#if asdfasdf
				object iStart = path[0].linked_layer.Save( odbc );
				object iEnd = path[path.Count - 1].linked_layer.Save( odbc );
				object iPeice;
				if( peice != null )
					iPeice = peice.Save( odbc, iLayer, LayerData.psvInstance );
				else
					iPeice = null;
				SQLInsert( odbc, "board_layer"
							  ,"x" , 2, x
							  ,"y", 2, y
							  ,"min_x", 2, min_x
							  ,"min_y", 2, min_y
							  ,"width", 2, w
							  ,"height", 2, h
							  ,"linked_from_id", 2, iStart
							  ,"linked_from_x", 2, route_start_layer.x
							  ,"linked_from_y", 2, route_start_layer.y
							  ,"linked_to_id", 2, iEnd
							  ,"linked_to_x", 2, route_end_layer.x
							  ,"linked_to_y",  2, route_end_layer.y
							  ,"route", 2, flags.bRoute
							  ,"peice_info_id", 2, iPeice
							  ,"peice_type", 1, LayerData.peice.Name 
							  , NULL, 0, NULL );
				iLayer = FetchLastInsertID( odbc, NULL, NULL );
				Log.log( "Saved %lu", iLayer );
#endif
			}

			if( flags.bRoute /*&& path*/ )
			{
			  int idx;
			  LayerPathNode path_node;
			  //for( idx = 0; path_node = (LayerPathNode)PeekDataEx( &path, idx ); idx++ )
				{
					//SQLCommandf( odbc
					//	, "insert into board_layer_path(board_layer_id,x,y,fore,back)values(%lu,%ld,%ld,%d,%d)"
					//	, iLayer
					//	, path_node.x, path_node.y
					//	, path_node.flags.ForeDir, path_node.flags.BackDir );

				}
			}
		   return iLayer;
		}

		internal bool EndsWhereItStarts()
		{
			if( path.Count == 0 )
				return false;

			if( path[path.Count - 1].x == 0 && path[path.Count - 1].y == 0 )
				return true;
			return false;
		}

		public void Dispose()
		{
			peice.Unlink( peice_instance );
			peice_instance = null;
		}

		internal bool EndIsNot( Point cell_click_origin )
		{
			if( ( x + path[path.Count - 1].x ) != cell_click_origin.X
				|| ( y + path[path.Count - 1].y ) != cell_click_origin.Y )
				return true;
			return false;
		}

		internal bool EndsAt( Point cell_click_origin )
		{
			LayerPathNode node = path[path.Count - 1];
			if( node.x == cell_click_origin.X && node.y == cell_click_origin.Y )
				return true;
			return false;
		}
	}
}
	