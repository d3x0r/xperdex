using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Collections.Specialized;
using System.Reflection;
using xperdex.classes;
using xperdex.core.interfaces;
using xperdex.gui;

namespace xperd3x.breadboard
{
	public class Board: PSI_Control, IReflectorPersistance
	{
        Point GridSize = new Point(32, 32);
        Point Origin = new Point(0,0);
		Point VisibleSize;
		Point Cursor;
		bool first;
		Size CursorDelta = new Size( 0, 0 );
		float Scale = 1.0F;
        List<Layer> Layers; // Peice instances are kept on layers, which define all positions that a thing is.
        List<Peice> Peices; // these are archtypes of graphic forms and interface to factory

		Peice default_peice;

		internal List<Assembly> assemblies = new List<Assembly>();

		ContextMenuStrip AddNewThing;

        void Init()
        {

			default_peice = new SimpleImagePeice( "Images/breadboard_back.png" );

			AddNewThing = new ContextMenuStrip();
			ContextMenuStrip = new ContextMenuStrip();
			ToolStripItem tsi = ContextMenuStrip.Items.Add( "Click Me" );
			ToolStripMenuItem sub = tsi as ToolStripMenuItem;
			sub = ContextMenuStrip.Items.Add( "Drop List" ) as ToolStripMenuItem;
			sub.DropDown = AddNewThing;



        }

		internal void LoadPeices( Assembly module )
		{
			Type[] types = module.GetTypes();
			foreach( Type type in types )
			{
				Type basetype = type;
				while( basetype != typeof( object ) )
				{

					if( basetype == typeof( Peice ) )
					{
						// okay this is a peice-like thing.
						Log.log( "Found a peice type" + type.ToString() );
					}
					basetype = basetype.BaseType;
				}
			}
		}

        Layer FindLayer(ref Point p)
        {
            foreach (Layer layer in Layers)
            {
                if (layer.Contains(p))
                    return layer;
            }
            return null;
        }

        Peice FindPeice(ref Point p)
        {
            return null;
        }

		void onClickMe( object o, EventArgs args )
		{
			//SetupBackground();
//			CreatePeiceAssociation();
		}
		

        bool Connecting;
        bool Moving;
		bool Dragging;

		void ComputeCursor( MouseEventArgs e )
		{
			Point _cursor = Cursor;
			// float calculation, requires conversion.
			int pt_x;
			int pt_y;
			if( e.Location.X < (this.Width/2) )
				pt_x = (int)( ( ( e.Location.X - this.Width / 2 - (GridSize.X/2)) / GridSize.X ) * Scale );
			else
				pt_x = (int)( ( ( e.Location.X - this.Width / 2 + GridSize.X/2 ) / GridSize.X ) * Scale );
			if( e.Location.Y < (this.Height/2) )
				pt_y = (int)( ( ( e.Location.Y - this.Height / 2 - GridSize.Y/2  ) / GridSize.Y ) * Scale );
			else
				pt_y = (int)( ( ( e.Location.Y - this.Height / 2 + GridSize.Y/2 ) / GridSize.Y ) * Scale );
			Cursor.X = pt_x - Origin.X;
			Cursor.Y = pt_y - Origin.Y;
			if( first )
			{
				CursorDelta.Width = Cursor.X - _cursor.X;
				CursorDelta.Height = Cursor.Y - _cursor.Y;
			}
			first = true;
		}

		void Board_MouseDown( object sender, MouseEventArgs e )
		{
			ComputeCursor( e );
			if( e.Button == MouseButtons.Left )
			{
				if( Connecting )
				{
					// drag the current end of the via connecting
				}
				else if( Moving )
				{
					// UPdate the position of the neuron.
				}
				else
				{
					Dragging = true;
				}
			}
		}

		void Board_MouseUp( object sender, MouseEventArgs e )
		{
			if( e.Button == MouseButtons.Left )
			{
				Dragging = false;
			}
		}

		void Board_MouseMove( object sender, MouseEventArgs e )
        {
			ComputeCursor( e );

			if( Dragging && !CursorDelta.IsEmpty )
			{
				// UPdate the position of the neuron.
				Origin = Point.Add( Origin, CursorDelta );
				Cursor = Point.Subtract( Cursor, CursorDelta );
				Refresh();
			}
			else
            if (e.Button == MouseButtons.Right)
            {
				Peice p = null;// FindPeice( ref Cursor );
                if (p != null)
                {
					ContextMenu menu = new ContextMenu();
					menu.MenuItems.Add( new MenuItem( "CLick me", onClickMe ) );
                }
            }
			
            //base.OnMouseMove(e);
        }
        public Board()
        {
			InitializeComponent();
        }


		

		private void InitializeComponent()
		{
			this.SuspendLayout();
			// 
			// Board
			// 
			this.Name = "Board";
			this.SizeChanged += new EventHandler( Board_SizeChanged );
			this.Size = new System.Drawing.Size( 435, 285 );
			this.MouseUp += new System.Windows.Forms.MouseEventHandler( this.Board_MouseUp );
			this.MouseMove += new System.Windows.Forms.MouseEventHandler( this.Board_MouseMove );
			this.MouseDown += new System.Windows.Forms.MouseEventHandler( this.Board_MouseDown );

			this.Paint += new PaintEventHandler( Board_Paint );
			this.Load += new EventHandler( Board_Load );
			this.ResumeLayout( false );
		}

		void Board_Load( object sender, EventArgs e )
		{
			Init();
		}


		const int SCREEN_PAD = 10;
		void Board_SizeChanged( object sender, EventArgs e )
		{
			// probably something like... calculate visible region from width/height
			VisibleSize = new Point( ( this.Width - (2*SCREEN_PAD) ) / GridSize.X
								, ( Height - (2*SCREEN_PAD) ) / GridSize.Y );
		}

		void PaintBackgroundLayer(Graphics g)
		{
			if( default_peice != null )
			{
				int sx, sy;
				Size s = default_peice.Size;

				if( Origin.X >= 0 )
					sx = Origin.X % s.Width;
				else
					sx = -( -Origin.X % s.Width );

				if( sx > 0 )
					sx -= s.Width;

				if( Origin.Y >= 0 )
					sy = Origin.Y % s.Height;
				else
					sy = -( -Origin.Y % s.Height );

				if( sy > 0 )
					sy -= s.Height;

				for( long x = sx; x < VisibleSize.X; x += s.Width )
					for( long y = sy; y < VisibleSize.Y; y += s.Height )
					{
						default_peice.Draw( g
											, x * GridSize.X
											, y * GridSize.Y
											, 0 // scale
											);
					}
			}
		}


		void Board_Paint( object sender, PaintEventArgs e )
		{
			e.Graphics.Clear( Color.Black );

			PaintBackgroundLayer(e.Graphics);				
			{
				//PLAYER layer = GetSetMember( LAYER, LayerPool, 0 );
				//while( layer && (layer = layer->prior) )
				//{
				//	DrawLayer( (PLAYER)layer );
				//}
			}
			//LayerPool->forall( faisDrawLayer, (PTRSZVAL)this );
			//ForAllInSet( LAYER, LayerPool, faisDrawLayer, (PTRSZVAL)this );
			//update->flush();
		}


		#region IReflectorPersistance Members

		bool IReflectorPersistance.Load( System.Xml.XPath.XPathNavigator r )
		{
			if( r.Name == "BoardPlugins" )
			{
				bool everokay = false;
				bool okay;
				for( okay = r.MoveToFirstAttribute(); okay; okay = r.MoveToNext() )
				{
					everokay = true;
					try
					{
						Assembly a = Assembly.LoadFile( r.Value );
						LoadPeices( a );
						assemblies.Add( a );
					}
					catch
					{
					}
				}
				if( everokay )
					r.MoveToParent();
				return true;
			}
			//throw new NotImplementedException();
			return false;
		}

		void IReflectorPersistance.Save( System.Xml.XmlWriter w )
		{
			//throw new NotImplementedException();
			w.WriteStartElement( "BoardPlugins" );
			int n = 0;
			foreach( Assembly a in assemblies )
				w.WriteAttributeString( "_" + ( n++ ).ToString(), a.Location );
			w.WriteEndElement();
		}

		void IReflectorPersistance.Properties()
		{
			EditPlugins ep = new EditPlugins( this );
			ep.ShowDialog();

			//throw new NotImplementedException();
		}

		#endregion
	}
}
#if asdfasdf
		// should be 8 pixels on each and every side
		// these will be the default color (black?)
		int SCREEN_PAD = 8;

		// I really do hate having circular dependancies....

		//----------------------------------------------------------------------

		class UPDATE {
			Int32 _x, _y;
	UInt32 _wd, _ht;
	Control pDisplay;
	Control pControl;

	public UPDATE( Control display )
	{
		pDisplay = display;
		pControl = null;
		_wd = 0;
		_ht = 0;
	}
	public UPDATE( Control pc )
	{
		pDisplay = null;
		pControl = pc;
		_wd = 0;
		_ht = 0;
	}
	~UPDATE()
	{
	}
	public void add( Int32 x, Int32 y, UInt32 w, UInt32 h )
	{
		//Log4( "Adding update region %d,%d -%d,%d", x, y, w, h );
		if( _wd == 0 && _ht == 0 )
		{
			_x = x;
			_y = y;
		}
		if( x < _x )
		{
			_wd += _x - x;
			_x = x;
		}
		if( y < _y )
		{
			_ht += _y - y;
			_y = y;
		}
		if( w > _wd )
			_wd = w;
		if( h > _ht )
			_ht = h;
	}
	public void flush()
	{
		if( _wd && _ht )
		{
			//Log4( "Flushing update to display... %d,%d - %d,%d", _x, _y, _wd, _ht );
         //if( pDisplay != null )
	//			UpdateDisplayPortion( pDisplay, _x, _y, _wd, _ht );
	//		else
	//			SmudgeCommon( pControl );
		}
		_wd = 0;
		_ht = 0;
	}
}

#if adsasdf
object  faisIsLayerAt( void *_layer, object psv )
{
	struct xy{
		Int32 x, y;
		Layer not_layer;
	} *pxy = (struct xy*)psv;
	PLAYER layer = (PLAYER)_layer;
	if( !layer->IsLayerAt( &pxy->x, &pxy->y ) )
		return 0;
	if( layer == pxy->not_layer )
      return 0; // lie, we need to return another...
   return (object)layer;
}
#endif


		UInt32 cell_width, cell_height;
	// original cell width/height
	// cell_width, height are updated to reflect scale
	UInt32 _cell_width, _cell_height;
	object default_peice_instance;
	PIPEICE default_peice;
	//void (*OnClose)(object,class IBOARD*);
	object psvClose;

	//public CRITICALSECTION cs;

	List<Peice> peices;
	INDEX iTimer; // this is the timer used for board refreshes...
	PUPDATE update;
	//{
		PRENDERER pDisplay;
		PSI_CONTROL pControl;
		Image pImage;  // this is implied to be pDipslay->surface or pControl->surface
	//}
	PLAYERSET LayerPool;
	PLAYER_DATASET LayerDataPool;

	// current layer which has a mouse event dispatched to it.
	PLAYER mouse_current_layer;
	PLAYER route_current_layer;
	PLAYER move_current_layer;
	Int32 xStart, yStart, wX, wY;
	UInt32 board_width, board_height;
	// cached based on current layer definitions...
	// when layers are updated, this is also updated
	// when board is scrolled...
	// it's a fairly tedious process so please keep these
	// updates down to as little as possible...
	// I suppose I should even hook into the update of the layer
	// module to update the current top-level cells on the board.
	// hmm drawing however is bottom-up, and hmm actually this
	// is a mouse phenomenon - display is a different basis.
	PCELL *board; //[64*64]; // manually have to compute offset from board_width
	Int32 board_origin_x, board_origin_y; // [0][0] == this coordinate.

		System.Collections.Specialized.BitVector32 flags;
 
		static struct BoardFlags
		 {
			public static int bSliding = BitVector32.CreateMask();
			public static int bDragging = BitVector32.CreateMask(bSliding);
			public static int bLockLeft = BitVector32.CreateMask(bDragging);
			public static int bLockRight = BitVector32.CreateMask(bLockLeft);
			public static int bLeft = BitVector32.CreateMask(bLockRight);
			public static int bRight = BitVector32.CreateMask(bLeft);
			// left changed happend both when a button is clicked
			// and when it is unclicked.
			public static int bLeftChanged = BitVector32.CreateMask(bRight);
			public static int bRightChanged = BitVector32.CreateMask(bLeftChanged);
		} 
		int scale;
	

	struct {
		PIPEICE viaset;
		Int32 _x, _y;
	} current_path;

	  public int GetScale()
	{
		return scale;
	}
public void SetScale( int scale )
	{
		if( scale < 0 || scale > 2 )
			return;
		cell_width = _cell_width >> scale;
		cell_height = _cell_height >> scale;
		scale = scale;
	}
	public void Close();

		void SetCloseHandler( void (*)(object,class IBOARD*), object );
	void SetBackground( PIPEICE peice )
	{
		default_peice = peice;
		default_peice_instance = default_peice->methods->Create(peice->psvCreate);
		BoardRefresh();
	}

	void SetCellSize( UInt32 cx, UInt32 cy )
	{
		cell_width = _cell_width = cx;
		cell_height = _cell_height = cy;
	}

	int BeginPath( PIVIA viaset/*, Int32 x, Int32 y*/, object psv )
	{
		if( mouse_current_layer )
		{
			EnterCriticalSec( &cs );
			PLAYER pl = new(&LayerPool,&LayerDataPool) LAYER( viaset );
			int connect_okay = mouse_current_layer
				->pLayerData
				->peice
				->methods
				->ConnectBegin( mouse_current_layer
									->pLayerData
									->psvInstance
								  , (wX - mouse_current_layer->x)
								  , (wY - mouse_current_layer->y)
								  , viaset
								  , pl->pLayerData->psvInstance );
			if( !connect_okay )
			{
				//DebugBreak();
				delete pl;
				LeaveCriticalSec( &cs );
				return false;
			}
			mouse_current_layer->Link( pl, LINK_VIA_START
         									, (wX - mouse_current_layer->x)
         									, (wY - mouse_current_layer->y) );
			route_current_layer = pl;
			// set the via layer type, and direction, and stuff..
			pl->BeginPath( wX, wY );
			LeaveCriticalSec( &cs );

			// otherwise change mode, now we are working on a new current layer...
			// we're working on dragging the connection, and... stuff...
		}
		//current_path.viaset = viaset;
		//current_path._x = x;
		//current_path._y = y;
		// lay peice does something like uhmm add to layer
		// to this point layers are single image entities...
		//LayPeice( viaset, x, y );
		return true;
	}

PLAYER GetLayerAt( Int32 *wX, Int32 *wY, PLAYER notlayer = NULL )
{
	PLAYER layer = GetSetMember( LAYER, LayerPool, 0 );
	while( layer )
	{
		if( layer != notlayer )
			if( layer->IsLayerAt( wX, wY ) )
			{
				lprintf( "Okay got a layer to return..." );
				return layer;
			}
		layer = layer->next;
	};

 //	if( ( layer = (PLAYER)LayerPool->forall( faisIsLayerAt, (object)&xy ) ) )
 //  {
 //     (*wX) = xy.x;
 //  	(*wY) = xy.y;
 //  }
	return layer;
}

PLAYER_DATA GetLayerDataAt( Int32 *wX, Int32 *wY, PLAYER notlayer = NULL )
{
	PLAYER layer = GetLayerAt( wX, wY, notlayer );
	if( layer )
		return layer->pLayerData;
	return NULL;
}
// viaset is implied by route_current_layer
	void EndPath( Int32 x, Int32 y )
	{
		// really this is lay path also...
		// however, this pays attention to mouse states
		// and data and layers and connections and junk like that
		// at this point I should have
		//   mouse flags.bRight, bLeft
		//   route_current_layer AND mouse_current_layer
		//
		PLAYER layer;
		PLAYER_DATA pld;
		// first layer should result and be me... check it.
		EnterCriticalSec( &cs );
		if( layer = GetLayerAt( &x, &y, route_current_layer ) )
		{
			if( flags.bLeftChanged )
			{
				pld = layer->pLayerData;
				int connect_okay = pld->peice->methods->ConnectEnd( pld->psvInstance
																				  , (wX - layer->x)
																				  , (wY - layer->y)
																				  , route_current_layer->pLayerData->peice
																				  , route_current_layer->pLayerData->psvInstance );
				if( connect_okay )
				{
					//DebugBreak();
					lprintf( "Heh guess we should do something when connect succeeds?" );
					// keep route_current_layer;
					layer->Link( route_current_layer, LINK_VIA_END, (wX-layer->x), (wY-layer->y) );
					route_current_layer = NULL;
					LeaveCriticalSec( &cs );
					return;
				}
				else
				{
					//DebugBreak();
					delete route_current_layer;
					route_current_layer = NULL;
					LeaveCriticalSec( &cs );
					return;
				}
			}
		}
		else
		{
         // right click anywhere to end this thing...
			if( route_current_layer &&
				flags.bRightChanged &&
				!flags.bRight )
			{
            //DebugBreak();
				// also have to delete this layer.
				delete route_current_layer;
				route_current_layer = NULL;
				LeaveCriticalSec( &cs );
				return;
			}
		}
		LayPathTo( wX, wY );
		LeaveCriticalSec( &cs );
	}
void UnendPath()
{
	EnterCriticalSec( &cs );
	int disconnect_okay = mouse_current_layer
		->pLayerData
		->peice
		->methods
		->Disconnect( mouse_current_layer
							->pLayerData
							->psvInstance );
						  //, (wX - mouse_current_layer->x)
						  //, (wY - mouse_current_layer->y)
						  //, viaset
						  //, pl->pLayerData->psvInstance );
	if( disconnect_okay )
	{
		mouse_current_layer->Unlink();
		mouse_current_layer->isolate();
		mouse_current_layer->link_top();
		route_current_layer = mouse_current_layer;
	}
	LeaveCriticalSec( &cs );
}

			public void timer(void);
	public PSI_CONTROL GetControl();
	public void DrawLayer( PLAYER layer );
	public void PutPeice( PIPEICE, Int32 x, Int32 y, object psv );
	public void BoardRefresh();  // put current board on screen.

void LayPathTo( int wX, int wY )
{
	route_current_layer->LayPath( wX, wY );
	BoardRefresh();
}

int SCRN_TO_GRID_X(int x) 
{ 
	return ((x - SCREEN_PAD)/(signed)cell_width - board_origin_x )
}
int SCRN_TO_GRID_Y(int y) 
{ 
	return ((y - SCREEN_PAD)/(signed)cell_height - board_origin_y);
}

public void DoMouse( int X, int Y, int b )
{
	//static _left, _right;

	wX = SCRN_TO_GRID_X( X );
	wY = SCRN_TO_GRID_Y( Y );
	//lprintf( "mouse at %d,%d", wX, wY );
	{
		Int32 x = wX, y = wY;
		PLAYER_DATA pld = GetLayerDataAt( &x, &y );
		//lprintf( "%s at %d,%d", pld?"something":"nothing", x, y );
	}

//#ifdef __WINDOWS__
//	SetCursor(LoadCursor(NULL, IDC_ARROW));
//#endif
	flags.bLeftChanged = flags.bLeft ^ ( (b & MK_LBUTTON) != 0 );
	flags.bRightChanged = flags.bRight ^ ( (b & MK_RBUTTON) != 0 );
	flags.bLeft = ( (b & MK_LBUTTON) != 0 );
	flags.bRight = ( (b & MK_RBUTTON) != 0 );

	if( flags.bRightChanged && !flags.bRight )
	{
	   if( !route_current_layer )
	   {
			Int32 x = wX, y = wY;
			lprintf( "right at %d,%d", wX, wY );
			PLAYER_DATA pld = GetLayerDataAt( &x, &y );
			if( pld )
			{
				lprintf( "Okay it's on a layer, and it's at %d,%d on the layer", wX, wY );
				if( !pld->peice->methods->OnRightClick( pld->psvInstance, wX, wY ) )
					return; // routine has done something to abort processing...
			}
			else if( default_peice )
			{
				if( !default_peice->methods->OnRightClick(NULL,wX,wY) )
					return; // routine has done something to abort processing...
			}
		}
	}
	else
	{
		//_right = flags.bRight;
	}


	if( flags.bSliding )
	{
		if( ( flags.bLockLeft && flags.bLeft ) ||
			( flags.bLockRight && flags.bRight ) )
		{
				if( wX != xStart ||
					wY != yStart )
				{
					lprintf( "updating board origin by %d,%d", wX-xStart, wY-yStart );
					board_origin_x += wX - xStart;
					board_origin_y += wY - yStart;
					wX = xStart;
					wY = yStart;
					BoardRefresh( );
				}
			}
			else
			{
				flags.bSliding = false;
				flags.bLockLeft = false;
				flags.bLockRight = false;
			}
		}
   else if( move_current_layer ) // moving a node/neuron/other...
   {
		if( flags.bLeft )
		{
			//DebugBreak();
			move_current_layer->move( wX - xStart, wY - yStart );
			xStart = wX;
			yStart = wY;
			BoardRefresh();
			move_current_layer
				->pLayerData
				->peice
				->methods
				->OnMove( move_current_layer
							->pLayerData->psvInstance
						  );
		}
		else
		{
			move_current_layer = NULL;
		}
	}
	else
	{
		if( flags.bLeft )  // not drawing, not doing anything...
		{
			// find neuron center...
			// first find something to do in this cell already
			// this is 'move neuron'
			// or disconnect from...

			Int32 x = wX, y = wY;
			PLAYER layer = GetLayerAt( &x, &y, route_current_layer );
			lprintf( "event at %d,%d", wX, wY );
			if( route_current_layer )
			{
				if( flags.bLeftChanged )
				{
					if( !layer )
					{
						// if it was a layer... then lay path to is probably
                  // going to invoke connection procedures.
						default_peice->methods->OnClick(NULL,wX,wY);
					}
				}
				LayPathTo( wX, wY );
			}
			else if( layer )
			{
				PLAYER_DATA pld = layer->pLayerData;
				mouse_current_layer = layer;
				lprintf( "Generate onclick method to peice." );
				pld->peice->methods->OnClick( pld->psvInstance, x, y );
				mouse_current_layer = NULL;
			}
			else if( default_peice )
			{
				lprintf( "Default peice click." );
				default_peice->methods->OnClick(NULL,wX,wY);
			}
		}
		else
		{
			if( route_current_layer )
			{
				// ignore current layer, and uhmm
				// get Next layer data... so we have something to connect to...
				// okay end path is where all the smarts of this is...
				// handles mouse changes in state, handles linking to the peice on the board under this route...
				EndPath( wX, wY );
			}
		}
	}
}


IMPORT void LockDrag()
{
	// this method is for locking the drag on the board...
   // cannot lock if neither button is down...??
	if( flags.bLeft || flags.bRight )
	{
		xStart = wX;
		yStart = wY;
		flags.bSliding = true;
		if( flags.bLeft )
		{
			flags.bLockRight = false;
			flags.bLockLeft = true;
		}
		else
		{
			flags.bLockRight = true;
			flags.bLockLeft = false;
		}
	}
	//Log( "Based on current OnMouse cell data message, lock that into cursor move..." );
}
IMPORT void LockPeiceDrag()
{
	// this method is for locking the drag on the board...
   // cannot lock if neither button is down...??
	if( flags.bLeft || flags.bRight )
	{
		xStart = wX;
		yStart = wY;
		flags.bDragging = true;
		move_current_layer = mouse_current_layer;
		if( flags.bLeft )
		{
			flags.bLockRight = false;
			flags.bLockLeft = true;
		}
		else
		{
			flags.bLockRight = true;
			flags.bLockLeft = false;
		}
	}
	//Log( "Based on current OnMouse cell data message, lock that into cursor move..." );
}
private:
   void Init();

public:

   BOARD();
   BOARD(PSI_CONTROL parent, Int32 x, Int32 y, UInt32 w, UInt32 h );
   ~BOARD();
	PIPEICE CreatePeice( String name //= "A Peice"
								  , Image image //= NULL
								  , int rows //= 1
								  , int cols //= 1
								  , int hotspot_x
								  , int hotspot_y
								  , PPEICE_METHODS methods //= NULL
								  , object psv
								  );
	PIVIA CreateVia( char *name //= "A Peice"
						, Image image //= NULL
						, PVIA_METHODS methods //= NULL
					  , object psv
						);
	PIPEICE GetFirstPeice( INDEX *idx );
	PIPEICE GetNextPeice( INDEX *idx );
   void GetSize( PUInt32 cx, PUInt32 cy )
	{
		// result with the current cell size, so we know
		// how much to multiply row/column counters by.
		// X is always passed correctly?
		if( cx )
			(*cx) = board_width;
		if( cy )
         (*cy) = board_height;
	}
	void GetCellSize( PUInt32 cx, PUInt32 cy, int scale )
	{
		// result with the current cell size, so we know
		// how much to multiply row/column counters by.
		// X is always passed correctly?
		if( !scale )
		{
			if( cx )
				(*cx) = cell_width;
			if( cy )
				(*cy) = cell_height;
		}
		else
		{
			if( cx )
				(*cx) = cell_width;
			if( cy )
				(*cy) = cell_height;
		}
	}

};

#if asdf
int  PSIBoardRefreshExtern( PCOMMON pc )
{
	ValidatedControlData( BOARD*, pb, , pc );
	if( pb )
	{
      pb->BoardRefresh();
	}
   return 1;
}
#endif

void  BoardRefreshExtern( object dwUser, PRENDERER renderer )
{
   BOARD *pb = (BOARD*)dwUser;
   pb->BoardRefresh();
}


int  DoMouseExtern( object dwUser, Int32 x, Int32 y, UInt32 b )
{
   BOARD *pb = (BOARD*)dwUser;
   pb->DoMouse( x, y, b );
	return 0;
}


#if asdf
void  BoardWindowClose( UInt32 dwUser )
{
	BOARD *pb;
	pb = (BOARD*)dwUser;
   //pb->pImage = NULL; // called FROM vidlib....

	if( !pb->bClosing )   // closing from BRAIN side...
		delete pb;  // okay?  maybe?
}
#endif

void timer()
{
	EnterCriticalSec( &cs );
	if( pControl )
		SmudgeCommon( pControl );
	LeaveCriticalSec( &cs );
}

void  BoardRefreshTimer( object psv )
{
	BOARD *board = (BOARD*)psv;
	board->timer();
}


PSI_CONTROL GetControl()
{
   return pControl;
}

void Init()
{
	peices = NULL;
	cell_width = 16;
	cell_height = 16;
	board_origin_x = 0;
	board_origin_y = 0;
	scale = 0;
	default_peice = NULL;
	board = NULL;
	mouse_current_layer = NULL;
	route_current_layer = NULL;
	move_current_layer = NULL;
	flags.bSliding = 0;
	flags.bDragging = 0;
	flags.bLockLeft = 0;
	flags.bLeftChanged = 0;
	flags.bLeft = 0;
	flags.bLockRight = 0;
	flags.bRightChanged = 0;
	flags.bRight = NULL;
	LayerPool = NULL; //new LAYERSET;
	LayerDataPool = NULL; //new LAYER_DATASET;
	pDisplay = NULL;
	pControl = NULL;
	pImage = NULL;
	InitializeCriticalSec( &cs );
}

BOARD()
{
	Init();

	{
		UInt32 w, h;
		GetDisplaySize( &w, &h );
		pDisplay = OpenDisplaySizedAt( 0, w, h, 0, 0 );
	}
	//PSI_CONTROL frame = CreateFrameFromRenderer( "Brain Editor", BORDER_RESIZABLE, pDisplay );
	update = new UPDATE( pDisplay );

	SetMouseHandler( pDisplay, DoMouseExtern, (UInt32)this );
	//SetCloseHandler( pDisplay, BoardWindowClose, (UInt32)this );

	SetRedrawHandler( pDisplay, BoardRefreshExtern, (UInt32)this );
   //AddCommonDraw( frame, PSIBoardRefreshExtern );

	SetBlotMethod( BLOT_MMX );

	AddTimer( 250, BoardRefreshTimer, (object)this );
	UpdateDisplay( pDisplay );
	//BoardRefresh();
	// may seem redundant but I think that this is
	// needed to unhide the initial window...
	//UpdateDisplay( pDisplay );
	//timerID = AddTimer( 1000, Timer, (object)this );
}

extern CONTROL_REGISTRATION
using System.Windows.Forms; board_control; // forward declaration so we have the control ID
//BOARD *creating_board;

/*
int  InitBrainEditorControl( PSI_CONTROL pc )
{
	ValidatedControlData( BOARD **, board_control.TypeID, ppBoard, pc );
	if( ppBoard )
	{
		if( creating_board )
		{
			(*ppBoard) = creating_board;
			creating_board = NULL;
		}
		else
		{
         (*ppBoard) = new BOARD();
		}
	}
	// hrm how do I set this data ?
   return true;
}
*/
int  DrawBrainEditorControl( PSI_CONTROL pc )
{
	ValidatedControlData( BOARD **, board_control.TypeID, ppBoard, pc );
	if( ppBoard )
	{
		(*ppBoard)->BoardRefresh();
	}
	return 1;
}

int  MouseBrainEditorControl( PSI_CONTROL pc, Int32 x, Int32 y, UInt32 b )
{
	ValidatedControlData( class BOARD * *, board_control.TypeID, ppBoard, pc );
	if( ppBoard )
	{
		(*ppBoard)->DoMouse( x, y, b );
		return 1;
	}
	return 0;
}

void  BoardPositionChanging( PSI_CONTROL pc, bool bStart )
{
	ValidatedControlData( class BOARD * *, board_control.TypeID, ppBoard, pc );
	if( ppBoard )
	{
		if( bStart )
			EnterCriticalSec( &(*ppBoard)->cs );
		else
			LeaveCriticalSec( &(*ppBoard)->cs );
	}
}
CONTROL_REGISTRATION board_control = { "Brain Edit Control", { { 256, 256 }, sizeof( class BOARD * ), BORDER_RESIZABLE }
												 , NULL /* InitBrainEditorControl /* int  init(PSI_CONTROL) */
												 , NULL /* load*/
												 , DrawBrainEditorControl
												 , MouseBrainEditorControl
												 , NULL // key
												 , NULL // destroy
												 , NULL // prop_page
												 , NULL // apply_page
												 , NULL // save
												 , NULL // Added a control
												 , NULL // changed caption
												 , NULL // focuschanged
                                     , BoardPositionChanging
                                     , 0 // typeID
};
PRELOAD( RegisterBoardControl )
{
   DoRegisterControl( &board_control );
}

BOARD(PSI_CONTROL parent, Int32 x, Int32 y, UInt32 w, UInt32 h )
{
	Init();
	pControl = MakeCaptionedControl( parent, board_control.TypeID
		, x, y, w, h
		, -1/*ID*/, "Brain Editor" );
	{
		ValidatedControlData( BOARD **, board_control.TypeID, ppBoard, pControl );
		if( ppBoard )
			(*ppBoard) = this;
	}
	update = new UPDATE( pControl );
	iTimer = AddTimer( 250, BoardRefreshTimer, (object)this );
	DisplayFrame( pControl );
}

~BOARD()
{
	if( OnClose )
		OnClose( psvClose, this );
	RemoveTimer( iTimer );
	delete update;
	DestroyFrame( &pControl );
}

void SetCloseHandler( void (*f)(object,class IBOARD*)
								, object psv )
{
	this->OnClose = f;
	this->psvClose = psv;
}
	


void DrawLayer( PLAYER layer )
{
	layer->Draw( this
				  , pDisplay?GetDisplayImage( pDisplay ):pControl?GetControlSurface( pControl ):NULL
				  , SCREEN_PAD + ( board_origin_x + (layer->x) ) * cell_width
				  , SCREEN_PAD + ( board_origin_y + (layer->y) ) * cell_height
				  );
	update->add( SCREEN_PAD + ( board_origin_x + (layer->x) ) * cell_width
		, SCREEN_PAD + ( board_origin_y + (layer->y) ) * cell_height
		, cell_width, cell_height );
	//Int32 hotx, hoty;
	//UInt32 rows, cols;
   //PIPEICE peice = layer->GetPeice();
	//peice->gethotspot( &hotx, &hoty );
	// later, when I get more picky, only draw those cells that changed
   // which may include an offset
	//peice->getsize( &rows, &cols );
   //lprintf( "Drawing layer at %d,%d (%d,%d) origin at %d,%d", layer->x, layer->y, hotx, hoty, board_origin_x, board_origin_y );
	//peice->methods->Draw( layer->pLayerData->psvInstance
	//						  , GetDisplayImage( pDisplay )
	//						  , SCREEN_PAD + ( board_origin_x + (layer->x) ) * cell_width
	//						  , SCREEN_PAD + ( board_origin_y + (layer->y) ) * cell_height
	//						  , rows, cols );
}

/*
object  faisDrawLayer( void *layer, object psv )
{
	BOARD *_this = (BOARD*)psv;
	_this->DrawLayer( (PLAYER)layer );
   return 0;
}
*/
void BoardRefresh()  // put current board on screen.
	{
		int x,y;
		EnterCriticalSec( &cs );
		pImage= pDisplay?GetDisplayImage( pDisplay ):pControl?GetControlSurface( pControl ):NULL;
		ClearImage( pImage );
		// 8 border top, bottom(16),left,right(16)
		{
			UInt32 old_width = board_width;
			UInt32 old_height = board_height;
			board_width = ( pImage->width - (2*SCREEN_PAD) ) / cell_width;
			board_height = ( pImage->height - (2*SCREEN_PAD) ) / cell_height;
			if( old_width != board_width || old_height != board_height )
			{
				if( board )
					Release( board );
				board = (PCELL*)Allocate( sizeof( CELL ) * board_width*board_height );
			}
		}
		if( default_peice )
		{
			UInt32 rows,cols;
			Int32 sx, sy;
			default_peice->getsize( &rows, &cols );

			if( board_origin_x >= 0 )
				sx = board_origin_x % cols;
			else
				sx = -(-board_origin_x % (Int32)cols);

			if( sx > 0 )
				sx -= cols;

			if( board_origin_y >= 0 )
				sy = board_origin_y % rows;
			else
				sy = -(-board_origin_y % (Int32)rows);

			if( sy > 0 )
				sy -= rows;

			update->add( SCREEN_PAD
						  , SCREEN_PAD
						  , (board_width+1) * cell_width, (board_height+1) * cell_height );
			for( x = sx; x < (signed)board_width; x += cols )
				for( y = sy; y < (signed)board_height; y += rows )
				{
					//lprintf( "background" );
					default_peice->methods->Draw( default_peice_instance
														 , pImage
														 , default_peice->getimage(scale)
														 , x * cell_width + SCREEN_PAD
														 , y * cell_height + SCREEN_PAD
														 );
				}
			//UpdateDisplay( pDisplay );
		}
		{
			PLAYER layer = GetSetMember( LAYER, LayerPool, 0 );
			while( layer && (layer = layer->prior) )
			{
				DrawLayer( (PLAYER)layer );
			}
		}
		//LayerPool->forall( faisDrawLayer, (object)this );
		//ForAllInSet( LAYER, LayerPool, faisDrawLayer, (object)this );
		update->flush();
		LeaveCriticalSec( &cs );
      //UpdateDisplay( pDisplay );
	}

void Close()
{
	// Implementation of IClose virtual function
	delete this;
}

void PutPeice( PIPEICE peice, Int32 x, Int32 y, object psv )
{
	//object psv = peice->Create();
   // at some point I have to instance the peice to have a neuron...
	UInt32 rows, cols;
	Int32 hotx, hoty;
	if( !peice ) {
		lprintf( "PEICE IS NULL!" );
		return;
	}
	EnterCriticalSec( &cs );
	peice->getsize( &rows, &cols );
	peice->gethotspot( &hotx, &hoty );
	lprintf( "hotspot offset of created cell is %d,%d so layer covers from %d,%d to %d,%d,"
			 , hotx, hoty
			 , x-hotx, y-hoty
			 , x-hotx+cols, y-hoty+rows );
	peice->psvCreate = psv; // kinda the wrong place for this but we abused this once upon a time.
	PLAYER pl = new(&LayerPool,&LayerDataPool) LAYER( peice, x, y, hotx, hoty, cols, rows );
	//pl->pLayerData = new(&LayerDataPool) LAYER_DATA(peice);
	// should be portioned...
	LeaveCriticalSec( &cs );
	BoardRefresh();
	//UpdateDisplay( pDisplay );
}

PIBOARD CreateBoard()
{
   return new BOARD();
}

PIBOARD CreateBoardControl( PSI_CONTROL parent, Int32 x, Int32 y, UInt32 w, UInt32 h )
{
   return new BOARD(parent, x, y, w, h);
}


PIPEICE CreatePeice( String name //= "A Peice"
								  , Image image //= NULL
								  , int rows //= 1
								  , int cols //= 1
								  , int hotspot_x
								  , int hotspot_y
								  , PPEICE_METHODS methods //= NULL
								  , object psv
								  )
{
	PIPEICE peice = DoCreatePeice( this, name, image, rows, cols, hotspot_x, hotspot_y, methods, psv );
	AddLink( &peices, peice );
	return peice; // should be able to auto cast this...
}

PIVIA CreateVia( char *name //= "A Peice"
											 , Image image //= NULL
											 , PVIA_METHODS methods //= NULL
											 , object psv
											 )
{
	PIVIA via = DoCreateVia( this, name, image, methods, psv );
	AddLink( &peices, (PIPEICE)via );
	return via;
}

PIPEICE GetFirstPeice( INDEX *idx )
{
	PIPEICE peice;
	if( !idx )
		return NULL;
	( *idx ) = 0;
	LIST_FORALL( peices, (*idx), PIPEICE, peice )
		return peice;
	return NULL;
}

PIPEICE GetNextPeice( INDEX *idx )
{
	PIPEICE peice;
	if( !idx )
		return NULL;
	LIST_NEXTALL( peices, (*idx), PIPEICE, peice )
		return peice;
	return NULL;
}


struct save_struct
{
	PODBC odbc;
   INDEX iBoard;
};


object  SaveLayer( POINTER p, object psv )
{
	PLAYER layer = (PLAYER)p;
	if( layer->pLayerData )
	{
		struct save_struct *save_struct = (struct save_struct*)psv;
		INDEX iLayer = layer->Save( save_struct->odbc );
		SQLCommandf( save_struct->odbc, "insert into board_layer_link (board_info_id,board_layer_id) values (%lu,%lu)"
					  , save_struct->iBoard
					  , iLayer );
	}
	return 0;
}

object  BeginSaveLayer( POINTER p, object psv )
{
	PLAYER layer = (PLAYER)p;
	struct save_struct *save_struct = (struct save_struct*)psv;
	if( layer->iLayer && layer->iLayer != INVALID_INDEX )
	{
		SQLCommandf( save_struct->odbc, "delete from board_layer_path where board_layer_id=%lu", layer->iLayer );
		layer->pLayerData->peice->SaveBegin( save_struct->odbc, layer->pLayerData->psvInstance );
	}
	layer->iLayer = 0; // or invalid_index
	return 0;
}

INDEX Save( PODBC odbc, String boardname )
{
	struct save_struct save_struct;
	String result;
	save_struct.odbc = odbc;
	if( SQLQueryf( odbc, &result, "select board_info_id from board_info where board_name=\'%s\'", EscapeString( boardname ) )
		&& result )
	{
		save_struct.iBoard = atoi( result );
		PopODBCEx(odbc);
	}
	else
	{
		SQLCommandf( odbc, "insert into board_info (board_name) values (\'%s\')", EscapeString( boardname ) );
		save_struct.iBoard = FetchLastInsertID( odbc, NULL, NULL );
	}
	//SQLCommandf( odbc, "update board_info " );
	SQLCommandf( odbc, "delete from board_layer_link where board_info_id = %lu", save_struct.iBoard );

	ForAllInSet( LAYER, LayerPool, BeginSaveLayer, (object)&save_struct );
	ForAllInSet( LAYER, LayerPool, SaveLayer, (object)&save_struct );

	//LayerPool->forall( BeginSaveLayer, (object)&save_struct );
	//LayerPool->forall( SaveLayer, (object)&save_struct );
	return save_struct.iBoard;
}

object  DeleteSaveLayer( POINTER p, object psv )
{
	PLAYER l = (PLAYER)p;
	delete l;
	return 0;
}

void reset()
{
	ForAllInSet( LAYER, LayerPool, DeleteSaveLayer, 0 );
	//LayerPool->forall( DeleteSaveLayer, 0 );

}

PIPEICE GetPeice( PLIST peices, String peice_name )
{
	foreach( Peice peice in peices )
	{
		if( strcmp( peice->name(), peice_name ) == 0 )
			break;
	}
	return peice_type;
}

bool ( PODBC odbc, String boardname )
{
	struct save_struct save_struct;
	String result;
	save_struct.odbc = odbc;
		
	if( SQLQueryf( odbc, &result, "select board_info_id from board_info where board_name=\'%s\'", EscapeString( boardname ) )
		&& result )
	{
		EnterCriticalSec( &cs );
		// okay found the board's index... now to load the board itself... 
		// probably need to generate a board reset...
		reset();
		{
			String *results;
			for( SQLRecordQueryf( odbc, NULL, &results, NULL
							, "select board_layer_id from board_layer_link where board_info_id=%s order by board_layer_id"
							, result );
				results;
				GetSQLRecord( &results ) )
			{
				//PIPEICE peice_type = GetPeice( peices, results[1] );
				INDEX iLayer = strtoul( results[0], NULL, 10 );
				PLAYER pl = (PLAYER)ForAllInSet( LAYER, this->LayerPool, CheckIsLayer, (object)iLayer );
				//(PLAYER)this->LayerPool->forall( CheckIsLayer, iLayer );
				if( !pl )
				{
					PushSQLQueryEx( odbc );
					pl = new(&LayerPool,&LayerDataPool) LAYER( odbc, peices, (INDEX)atoi(results[0]) );
					//LAYER( peice_type, psv );

					//pl->Load( odbc, atoi( results[0] ) );
					PopODBCEx( odbc );
				}
			}
		}
		LeaveCriticalSec( &cs );
		return true;
	}
	return false;
}



	}
}
#endif
