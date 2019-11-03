using System;
using System.Collections.Generic;
using System.Text;
using xperdex.classes;

namespace xperd3x.breadboard
{
	interface IPeiceMethods
	{
	//PPEICE_METHODS methods;
	//object psvCreate;
	void Destroy();
	Image getimage();
	Image getimage(int scale);
	Image getcell( Int32 x, Int32 y );
	Image getcell( Int32 x, Int32 y, int scale ) ;
	void gethotspot( ref Int32 x, ref Int32 y );
	void getsize( ref UInt32 rows, ref UInt32 cols );
	void SaveBegin( DsnConnection odbc, object psvInstance ) ;
	INDEX Save( DsnConnection odbc, object iParent, object psvInstance );
	object Load( DsnConnection odbc, object iInstance );
	}
}
