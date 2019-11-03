using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace OpenSkiePOS.PosCore
{
	public interface iDepartment
	{

		void LinkToTransaction( TransactionDataSet ds );
		
		
	}
}
