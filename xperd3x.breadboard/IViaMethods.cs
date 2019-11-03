using System;
using System.Collections.Generic;
using System.Text;

namespace xperd3x.breadboard
{
	class IViaMethods : IPeiceMethods
	{
			IVia via_master;
	//virtual int OnRelease( object psv );
	//virtual int OnRouteClick( object psv );
	//virtual int Reroute();
	void SetPeice( IVia peice ) { via_master = peice; 
		PEICE_METHODS::master = (PIPEICE)peice; 
	}
	int OnClick( object psvInstance, Int32 x, Int32 y );
	int OnRightClick( object psvInstance, Int32 x, Int32 y );
	int OnDoubleClick( object psvInstance, Int32 x, Int32 y );

	}
}
