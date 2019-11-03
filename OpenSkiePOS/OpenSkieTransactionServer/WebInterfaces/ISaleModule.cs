using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;

namespace WebInterfaces
{
	/// <summary>
	/// Used to interface with external modules from kiosk/POS
	/// </summary>
	[ServiceContract]
	public interface ISaleModule
	{
		/// <summary>
		/// Used when interface is first brought online.  Does first time initialization.
		/// </summary>
		[OperationContract]
		void Start();

		/// <summary>
		/// Used to set the current bingoday
		/// </summary>
		/// <param name="date">what the date is today</param>
		[OperationContract]
		void SetBingoday( DateTime date );

		/// <summary>
		/// Used to set the current session
		/// </summary>
		/// <param name="session_number">session number</param>
		[OperationContract]
		void SetSession( int session_number );

		/// <summary>
		/// Start a new transaction using the specified transaction ID
		/// </summary>
		/// <param name="transaction_id">transaction identifier of the sale</param>
		[OperationContract]
		void BeginTransaction( object transaction_id );

		/// <summary>
		/// Commit a transaction.  Signifies the transaction is over, release all resources
		/// </summary>
		[OperationContract]
		void EndTransaction();

		/// <summary>
		/// Remove all items.  Start transaction over.
		/// </summary>
		[OperationContract]
		void ClearAll();

		/// <summary>
		/// Clear a individual item.  Item would have been posted with a unique identifier.
		/// </summary>
		/// <param name="item_id"></param>
		[OperationContract]
		void ClearItem( object item_id );

		/// <summary>
		/// Signals to void a transaction.
		/// </summary>
		/// <param name="transaction_id">The transaction number to void</param>
		[OperationContract]
		void VoidTransaction( object transaction_id );

		/// <summary>
		/// Signals to void a transaction item.
		/// </summary>
		/// <param name="transaction_id">The transaction number to void</param>
		/// <param name="item_id">The transaction item to void</param>
		[OperationContract]
		void VoidTransactionItem( object transaction_id, object item_id );

		/// <summary>
		/// Signals to set the electronic unit type being sold
		/// </summary>
		/// <param name="unit_type">The bitmap type for the unit type </param>
		/// Use the enumeration in MobilePOS.PlayerUnitType or the integer:
		/// PORTABLE = 1,
		/// STATIONARY = 2,
		/// COLOR =	128,
		/// TABLET = 1024,
		/// EDGE_EXPLORER = 4096, 
		/// EDGE_TRAVELER = 8192, 
		/// EDGE_STATIONARY = 16384,
		/// EDGE_TABLET = 32768
		[OperationContract]
		void SetElecUnit(object unit_type);
		
		/// <summary>
		/// Invoke processing a barcode.
		/// </summary>
		/// <param name="s">The barcode string to process</param>
		//[OperationContract]
		void HandleBarcode( String s );
	}

	public class ClientISalemodule : ClientBase<ISaleModule>, ISaleModule
	{
		void ISaleModule.Start()
		{
			base.Channel.Start();
		}

		void ISaleModule.SetBingoday( DateTime date )
		{
			base.Channel.SetBingoday( date );
		}

		void ISaleModule.SetSession( int session_number )
		{
			base.Channel.SetSession( session_number );
		}

		void ISaleModule.BeginTransaction( object transaction_id )
		{
			base.Channel.BeginTransaction( transaction_id );
		}

		void ISaleModule.EndTransaction()
		{
			base.Channel.EndTransaction();
		}

		void ISaleModule.ClearAll()
		{
			base.Channel.ClearAll();
		}

		void ISaleModule.ClearItem( object item_id )
		{
			base.Channel.ClearItem( item_id );
		}

		void ISaleModule.VoidTransaction( object transaction_id )
		{
			base.Channel.VoidTransaction( transaction_id );
		}

		void ISaleModule.VoidTransactionItem( object transaction_id, object item_id )
		{
			base.Channel.VoidTransactionItem( transaction_id, item_id );
		}

		void SetElecUnit(MobilePOS.PlayerUnitType unit)
		{
			base.Channel.SetElecUnit((object)((int)unit));
		}

		void ISaleModule.SetElecUnit(object unit_type)
		{
			base.Channel.SetElecUnit(unit_type);
		}

		void ISaleModule.HandleBarcode( string s )
		{
			base.Channel.HandleBarcode( s );
		}
	}

}
