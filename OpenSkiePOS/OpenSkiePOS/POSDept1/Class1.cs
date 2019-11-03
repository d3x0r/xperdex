using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace POSDept1
{
	public class Class1: OpenSkiePOS.PosCore.iDepartment
	{
		void OpenSkiePOS.PosCore.iDepartment.LinkToTransaction( OpenSkiePOS.PosCore.TransactionDataSet ds )
		{
			DataTable class1_table = new DataTable();
			class1_table.TableName = "class1_trans";

			ds.Tables.Add( class1_table );


			ds.TransactionCleared += new OpenSkiePOS.PosCore.TransactionDataSet._Generic( ds_TransactionCleared );
			ds.ReloadTransactio
	
		}

		void ds_TransactionCleared()
		{
			//throw new Exception( "The method or operation is not implemented." );
		}

	}
}
