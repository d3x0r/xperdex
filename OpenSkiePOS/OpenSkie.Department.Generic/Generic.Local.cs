using System;
using System.Collections.Generic;
using System.Data;
using xperdex.classes;

namespace OpenSkie.Department.Generic
{
	internal static class Local
	{
		static internal bool inited;
		static List<GenericItemGroup> groups;

		static Local()
		{
			DataTable tmp = new xperdex.classes.MySQLDataTable( StaticDsnConnection.dsn, "select misc_item.name as item_name,misc_item.dept as dept_name,* from misc_def join misc_item using(item_id) join misc_dept using(dept_id)" );
			foreach( DataRow row in tmp.Rows )
			{
				String dept = row["dept_name"].ToString();
				String item = row["item_name"].ToString();
				int item_id = Convert.ToInt32( row["item_id"] );
				int dept_id = Convert.ToInt32( row["dept_id"] );

				GenericItemGroup group = Local.GetItemGroup( dept );
				group.GetGenericItem( item );
			}

			inited = true;
		}


		static GenericItemGroup GetItemGroup( string name )
		{
			GenericItemGroup new_group;
			if( groups == null )
			{
				groups = new List<GenericItemGroup>();
			}
			else foreach( GenericItemGroup group in groups )
			{
				if( group.group_name == name )
					return group;
			}

			new_group = new GenericItemGroup( name );
			groups.Add( new_group );
			return new_group;
		}


	}
}
