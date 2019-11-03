using System;
using System.Collections.Generic;

namespace OpenSkie.Department.Generic
{
	class GenericItemGroup
	{
		internal String group_name;
		List<GenericItem> items;
		LinkedList<GenericItem> sorted_items;

		public override string ToString()
		{
			return group_name + "(" + items.Count + ")";
		}

		void Init()
		{
			items = new List<GenericItem>();
			sorted_items = new LinkedList<GenericItem>();
		}

		public GenericItemGroup( String name )
		{
			Init();
			group_name = name;
		}

		internal GenericItem GetGenericItem( String name )
		{
			foreach( GenericItem item in items )
			{
				if( item.item_name == name )
					return item;
			}
			GenericItem new_item = new GenericItem( name );
			items.Add( new_item );
			return new_item;
		}

	}
}
