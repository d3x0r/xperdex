using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using xperdex.gui;

namespace ItemManager
{
	public class GridMacroItemAssignment : XDataGridView
	{
		public GridMacroItemAssignment()
		{
			DataSource = ItemManagmentState.current_floor_paper_paper_items;
		}
	}
}
