using System.Collections.Generic;
//using System.Linq;
using System.Data;

namespace OpenSkieScheduler3
{
	interface SellableItemType
	{
		void JoinDataSet( DataSet dataSet );

		List<SellableItem> GetItems();

		void RequestItem( SellableItem item, int count );
		void SellItem( SellableItem item, int count );

	}
}
