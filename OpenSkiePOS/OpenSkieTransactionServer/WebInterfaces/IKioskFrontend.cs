using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;

namespace MobilePOS
{
    /// <summary>
    /// The electronic player unit types that can be sold to for electronic sales.
    /// </summary>
	public enum PlayerUnitType
	{
		PORTABLE = 1,
		STATIONARY = 2,
		COLOR =	128,
		TABLET = 1024,
		EDGE_EXPLORER = 4096, 
		EDGE_TRAVELER = 8192, 
		EDGE_STATIONARY = 16384,
		EDGE_TABLET = 32768
	};

	[ServiceContract]
	public interface IKioskFrontend
	{
		/// <summary>
		/// Received money from input device... post money to kiosk
		/// </summary>
		/// <param name="value">amount of money in smallest coin units</param>
		/// <returns>success/failure if money could not be added</returns>
        [OperationContract]
		bool AddMoney( long value );

		/// <summary>
		/// Add a product to display (add a sold item)
		/// </summary>
		/// <param name="item_id">arbitrary ID</param>
		/// <param name="receipt_line">Text to show on display</param>
		/// <param name="value">value to show on display</param>
        [OperationContract]
		void AddProduct( int dept_id, int item_id, String receipt_line, long value );

		/// <summary>
		/// Set the player card number
		/// </summary>
		/// <param name="card">player cardswipe</param>
        [OperationContract]
		void SetPlayer( String card );

		/// <summary>
		/// Posted when underlaying driver piece has restarted, allows re-configuration (send bingoday/session)
		/// </summary>
        [OperationContract]
		void Restart();

		/// <summary>
		/// Send information to receipt printer
		/// </summary>
		/// <param name="?"></param>
        [OperationContract]
		void SendReceiptPrinter( String receipt_line );

        /// <summary>
        /// Register a new department with the kiosk by name.
        /// </summary>
        /// <param name="name">name of the department</param>
        /// <returns>an ID used later to refer to this department.  If null, registration failed for some reason.</returns>
        [OperationContract]
        object RegisterDepartment( String name );


	}

	public class ClientIKioskFrontend : ClientBase<IKioskFrontend>, IKioskFrontend
	{
		public bool AddMoney( long param )
		{
			return base.Channel.AddMoney( param );
		}
		public void AddProduct( int dept_id, int item_id, string receipt_line, long value )
		{
			base.Channel.AddProduct( dept_id, item_id, receipt_line, value );
		}
		public void SetPlayer( string card )
		{
			base.Channel.SetPlayer( card );
		}
		public void Restart()
		{
			base.Channel.Restart();
		}
		public void SendReceiptPrinter( String receipt_line )
		{
			base.Channel.SendReceiptPrinter( receipt_line );
		}
        public object RegisterDepartment( String name )
        {
            return base.Channel.RegisterDepartment( name );
        }
	}
}
