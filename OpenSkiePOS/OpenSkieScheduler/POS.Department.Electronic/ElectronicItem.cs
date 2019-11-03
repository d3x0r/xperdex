using System;
using System.Collections.Generic;
using System.Text;
using OpenSkiePOS;

namespace POS.Department.Electronic
{
	class ElectronicItem : DepartmentInterface
	{
		public override string ToString()
		{
			return "Electronic Item";
		}
		object DepartmentInterface.GetItem( string name )
		{
			throw new NotImplementedException();
		}

		object DepartmentInterface.AllowSale( object item, int count )
		{
			throw new NotImplementedException();
		}

		object DepartmentInterface.SellItem( object item, int count )
		{
			throw new NotImplementedException();
		}

		POSButtonInterface DepartmentInterface.GetItemForButton( ButtonWithLabelAreas real_button )
		{
			return new ElectronicButton();
		}


		void DepartmentInterface.Configure()
		{
		}

	}
}
