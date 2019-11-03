using System;
using OpenSkiePOS;

namespace OpenSkie.Department.Generic
{
	class GenericDepartment: OpenSkiePOS.DepartmentInterface
	{
		public override string ToString()
		{
			return "Generic Item";
		}

		public GenericDepartment()
		{
			if( !Local.inited )
				return;
		}

		object OpenSkiePOS.DepartmentInterface.GetItem( string name )
		{
			throw new NotImplementedException();
		}

		object OpenSkiePOS.DepartmentInterface.AllowSale( object item, int count )
		{
			throw new NotImplementedException();
		}

		object OpenSkiePOS.DepartmentInterface.SellItem( object item, int count )
		{
			throw new NotImplementedException();
		}

		POSButtonInterface OpenSkiePOS.DepartmentInterface.GetItemForButton( ButtonWithLabelAreas real_button )
		{
			return new GenericButton();
		}

		void DepartmentInterface.Configure()
		{

		}
	}
}
