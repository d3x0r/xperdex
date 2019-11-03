using System.Data;
using xperdex.classes;

namespace OpenSkiePOS
{
	class TransactionDataSet: DataSet
	{
		class TransactionTable : DataTable
		{
			public new static string TableName = "sales_transaction";
			public TransactionTable()
			{
				base.TableName = TransactionTable.TableName;
				MySQLDataTable.AddDefaultColumns( this, true, true, false );
			}
		}
	}
}
