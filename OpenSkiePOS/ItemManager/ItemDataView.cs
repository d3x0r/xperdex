using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace ItemManager
{
	class ItemDataView : DataView
	{
		internal ItemDataView(): base( ItemManagmentState.item_dataset.items
				, "retire=0"
				, "series"
				, DataViewRowState.CurrentRows )
		{
			
		}

	}
}
