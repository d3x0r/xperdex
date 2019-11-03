using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using xperdex.classes;

namespace xperd3x.breadboard
{
	internal interface IPeice
	{
			//PIPEICE master;
			//String  ToString(); // I should get this already, right?
	 //void  SetPeice ( PIPEICE peice ) { master = peice; }
	 //Image  getimage ();// { return maste.getimage(); }
	 //Image  getcell ( Int32 x, Int32 y );// { return master->getcell(x,y); }
	 //Image getimage( int scale );// { return master->getimage(scale); }
	 //Image getcell( Int32 x, Int32 y, int scale );// { return master->getcell(x,y,scale); }
	 void gethotspot( out int x, out int y );// { master->gethotspot(x,y); }
	 void getsize( out uint rows, out uint cols );// { master->getsize(rows,cols); }

	// --- these are intended to be overridden.
	// the above are sufficient for static usage, and should not be
	// defined by derived peices...

	  object  Create ( object psv_userdata );
	void  Destroy ( object obj );
	// return 0 to disallow beginning of a connection, current path never really exists...
	  int  ConnectBegin ( object psv_to_instance, Int32 x, Int32 y
														, IPeice peice_from, object psv_from_instance );
	// return 0 to disallow connection, current path dissappears.
	  int  ConnectEnd ( object psv_to_instance, Int32 x, Int32 y
													 , IPeice peice_from, object psv_from_instance );
	// can return 0 to disallow disconnect...
	  int  Disconnect ( object psv_to_instance );
													 //, PIPEICE peice_to_disconnect, object psv_to_disconnect_instance );
	 void  OnMove ( object psvInstance );
	 int  OnClick ( object psvInstance, Int32 x, Int32 y );
	  int  OnRightClick ( object psvInstance, Int32 x, Int32 y );
	  int  OnDoubleClick ( object psvInstance, Int32 x, Int32 y );

	void  Update ( object psvInstance, UInt32 cycle );
	void Draw( Graphics surface, long x, long y, int s );

	// result with the instance ID in the database
	void  SaveBegin ( DsnConnection odbc, object psvInstance );
	uint Save( DsnConnection odbc, uint iParent, object psvInstance );
	object Load( DsnConnection odbc, uint iInstance );
	//virtual  void  Save ( FILE *file, object psvInstance );
	//virtual  void  Draw ( object psvInstance
	//										  , Image surface
	//										  , int x, int y );
	//virtual  void  Draw ( object psvInstance
	//										  , Image surface
	//										  , int x, int y
												// these two are the cell offset if cells
												// 2, 2 - 3, 3 are to be drawn at x, y
                                    // cellx = 2, celly = 2, rows = 1, cols = 1
	//										  , int cellx, int celly
	//										  );

	}
}
