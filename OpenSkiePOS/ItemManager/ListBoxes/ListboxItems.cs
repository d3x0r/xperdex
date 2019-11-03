using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using xperdex.gui;
using xperdex.core.interfaces;
using System.Data;
using System.Windows.Forms;

namespace ItemManager
{
	[ControlAttribute( Name = "Current Items" )]
	public class ListboxItems: XListbox, IReflectorPersistance
	{
		public ListboxItems()
		{
			this.DataSource = ItemManagmentState.current_items;
			SelectedValueChanged += new EventHandler( ListboxItemDescriptions_SelectedValueChanged );
			ItemManagmentState.item_serial_listboxes.Add( this );
			TabStops = new int[] { 180 };
		}

		void ListboxItemDescriptions_SelectedValueChanged( object sender, EventArgs e )
		{
			if( SelectedValue != null )
			{
				ItemManagmentState.current_item_serial = ( SelectedValue as DataRowView ).Row;
			}
			else
			{
				ItemManagmentState.current_item_serial = null;
			}
		}



		bool IReflectorPersistance.Load( System.Xml.XPath.XPathNavigator r )
		{
			return false;
		}

		void IReflectorPersistance.Properties()
		{
			
		}

		void IReflectorPersistance.Save( System.Xml.XmlWriter w )
		{
			
		}
	}
}
