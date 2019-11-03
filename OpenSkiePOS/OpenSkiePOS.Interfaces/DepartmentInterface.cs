using System;

namespace OpenSkiePOS
{
	public interface DepartmentInterface
	{
		object GetItem( String name );

		object AllowSale( object item, int count );

		object SellItem( object item, int count );

		/// <summary>
		/// Get a POS Button interface.  
		/// </summary>
		/// <param name="real_button">The real item button this will be assigned to</param>
		/// <returns>A new button interface</returns>
		POSButtonInterface GetItemForButton(ButtonWithLabelAreas real_button);
		
		/// <summary>
		/// Invoked when the department as a whole should be configured.
		/// </summary>
		void Configure();
	}
}

