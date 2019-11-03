using System;
using System.Collections.Generic;
using System.Text;

namespace BingoGameInterfaces
{
	public interface IPackSales
	{
		void Initialize();
		void BeginTransaction( object transnum );
		void Purchase( object pack_id );
}	
}
