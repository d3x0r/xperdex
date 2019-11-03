using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using xperdex.gui;
using xperdex.core.interfaces;
using System.Data;
using xperdex.classes;
using System.Windows.Forms;
using ItemManager.Forms;

namespace ItemManager
{
	public class ListboxItemDescriptions: XListbox, IReflectorCreate, IReflectorPersistance
	{
		DataView current_item_descriptions;

		string _inventory_type_filter;
		internal string inventory_type_filter
		{
			set
			{
				if( value != null && value.Length > 0 )
					current_item_descriptions.RowFilter = "inv_type='" + value + "'" 
						+ (!ItemManagmentState.flags.filter_assigned?" and MIN(Child(item_descriptions_floor_item_map).floor_item_map_id) is NULL":"")
						;
				else
					current_item_descriptions.RowFilter = 
						(!ItemManagmentState.flags.filter_assigned?"MIN(Child(item_descriptions_floor_item_map).floor_item_map_id) is NULL":"");

				_inventory_type_filter = value;
			}
			get
			{
				return _inventory_type_filter;
			}
		}

		public ListboxItemDescriptions()
		{
			current_item_descriptions = new DataView( ItemManagmentState.item_dataset.item_descriptions
				, ""
				, "item_name"
				, DataViewRowState.CurrentRows );

			this.DataSource = current_item_descriptions;
			SelectedValueChanged += new EventHandler( ListboxItemDescriptions_SelectedValueChanged );
			ItemManagmentState.item_listboxes.Add( this );
			ItemManagmentState.lists.Add( this );
			TabStops = new int[] { 210 };
		}

		void ListboxItemDescriptions_SelectedValueChanged( object sender, EventArgs e )
		{
			if( ItemManagmentState.current_inventory_type_filter == null )
			{
				ItemManagmentState.current_inventory_type_filter = this.inventory_type_filter;
				if( SelectedValue != null )
					ItemManagmentState.current_item = ( SelectedValue as DataRowView ).Row;
				else
					ItemManagmentState.current_item = null;
				ItemManagmentState.current_inventory_type_filter = null;
			}
		}

		public void OnCreate( System.Windows.Forms.Control pc )
		{
		}

		bool IReflectorPersistance.Load( System.Xml.XPath.XPathNavigator r )
		{
			if( r.Name == "listbox_filter" )
			{
				inventory_type_filter = r.Value;
				return true;
			}
			return false;
		}

		void IReflectorPersistance.Properties()
		{
			ConfigureItemList cil = new ConfigureItemList( this );
			cil.ShowDialog();
			cil.Dispose();
		}

		void IReflectorPersistance.Save( System.Xml.XmlWriter w )
		{
			if( _inventory_type_filter != null && _inventory_type_filter.Length > 0 )
				w.WriteElementString( "listbox_filter", _inventory_type_filter );
		}
	}
}
