using System;
using System.Collections.Generic;
using System.Text;

namespace xperd3x.breadboard
{
	interface IBoard
	{

		 //void SetCloseHandler( void (*)(object,class IBOARD*), object );
	 void Close();
	// put a peice defined by PPEICE with part referenced by
	// row, col at the position x, y

	// add a avaiable peice to the board...
	// void AddPeice( IPeice peice );
	 IPeice CreatePeice( String name
										, Image image
										, int rows, int cols
										, int hotspot_x
										, int hotspot_y
										 // force images to this size
										, IPeiceMethods methods
										, object psvCreate );

	 IVia CreateVia( String name
											, Image image
											, IViaMethods methods
										, object psvCreate );
	 IPeice GetFirstPeice( INDEX *idx );
	 IPeice GetNextPeice( INDEX *idx );
	 void GetSize( PUInt32 cx, PUInt32 cy );
	 void SetCellSize( UInt32 cx, UInt32 cy );
	 void GetCellSize( PUInt32 cx, PUInt32 cy, int scale );

	// define the graphic for the background...
	// without a background the application can get no events.
	 void SetBackground( IPeice peice );
	 void SetScale( int scale );
	 int GetScale();

	 void PutPeice( IPeice peice, Int32 x, Int32 y, object psv );

	// begin path invokes some things like connect_to_peice...
	// failure can result from invalid conditions from the connection
	// methods... this reuslts back to the application here.
	 int BeginPath( IVia peice/*, Int32 x, Int32 y*/, object psv );
	 void EndPath( Int32 x, Int32 y );
	 void UnendPath();
	 PLAYER GetLayerAt( Int32 *wX, Int32 *wY, PLAYER notlayer );
	 PLAYER GetLayerAt( Int32 *wX, Int32 *wY );

	 void BoardRefresh();  // put current board on screen.

	// this method uses the currently selected peice passed to OnMouse method.
	// only valid from within an OnMouse event...
	 void LockDrag();

	// currently dispatched peiced is locked into a drag mode...
	// peices which are attached receive events?
	 void LockPeiceDrag();
	 INDEX Save( PODBC odbc, String name );
	 bool Load( PODBC odbc, String name );
};
#if asdfasdf
 PIBOARD  CreateBoard ();
 PIBOARD  CreateBoardControl (PSI_CONTROL, Int32,Int32,UInt32,UInt32);

IPeice GetPeice( PLIST peices, String peice_name );
#endif
	}
//}
