using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using xperdex.core;
using xperdex.core.interfaces;
using System.Data;
using xperdex.classes;
using xperdex.gui;
using System.Windows.Forms;

namespace ItemManager
{
	[ButtonAttribute( Name = "Toggle Assigned Items" )]
	class ToggleAssignedItems : PSI_Button, IReflectorDirectionShow
	{
		public ToggleAssignedItems()
		{
			Click += new ClickProc( ButtonCreateItem_Click );
			Text = "Show Assigned_Items";
		}

		void ButtonCreateItem_Click( object sender, ReflectorButtonEventArgs e )
		{
			ItemManagmentState.flags.filter_assigned = !ItemManagmentState.flags.filter_assigned;
			ItemManagmentState.RefreshLists();
			this.Highlight = ItemManagmentState.flags.filter_assigned;

		}

		void IReflectorDirectionShow.PageChanged()
		{
		}

		void IReflectorDirectionShow.Shown()
		{
			this.Highlight = ItemManagmentState.flags.filter_assigned;
		}

		void IReflectorDirectionShow.Hidden()
		{
		}
	}


}
