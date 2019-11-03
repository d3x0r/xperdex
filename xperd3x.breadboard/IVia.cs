using System;
using System.Collections.Generic;
using System.Text;

namespace xperd3x.breadboard
{
	interface IVia: IPeice
	{
			//virtual ~IVIA();
	virtual String name()=0;
	virtual Image GetViaStart( int direction, int scale = 0 )=0;// { return NULL; }
	virtual Image GetViaEnd( int direction, int scale = 0 )=0;//{ return NULL; }
	// getviafromto will result in start or end if from or to is NOWHERE respectively
	virtual Image GetViaFromTo( int from, int to, int scale = 0 ){ return NULL; }

	virtual Image GetViaFill1( int *xofs, int *yofs, int direction, int scale = 0 ){ return NULL; }
	virtual Image GetViaFill2( int *xofs, int *yofs, int direction, int scale = 0 ){ return NULL; }
	virtual int Move() { return 0; } // Begin, Start
	virtual int Stop() { return 0; } // end
	PVIA_METHODS via_methods;

	}
}
