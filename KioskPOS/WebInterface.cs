using System;
using xperdex.classes;
using WebInterfaces;
using System.Windows.Forms;
using System.ServiceModel;

namespace MobilePOS
{
	public class KioskBarcodeInterface : IBarcodeReceiver
	{
		bool IBarcodeReceiver.HandleBarcode( string s )
		{
			Local.form.scanner_receive( s );
			return false;
		}
	}

    [ServiceBehavior( ConcurrencyMode = ConcurrencyMode.Reentrant, UseSynchronizationContext = false )]
    public class KioskFrontendInterface : IKioskFrontend
	{
		public void AddProduct( int dept_id, int item_id, string receipt_line, long value )
		{
			Local.form.InsertItem( new Item( receipt_line, value ) );	
		}
		public void SetPlayer( string card )
		{
			Local.form.printer_receive( card );
		}

		bool IKioskFrontend.AddMoney( long value )
		{
			return Local.form.AddMoney( value );
		}
		void IKioskFrontend.Restart()
		{
			Local.form.BackendRestarted();
		}
		void IKioskFrontend.SendReceiptPrinter( String receipt_line )
		{
			Local.printer.Write( receipt_line );
		}
        object IKioskFrontend.RegisterDepartment( String name )
        {
            Log.log( "Recieved register for dept:" + name );
            //MessageBox.Show( "Recieved register for dept:" + name );
            return "1234";
            return null;
        }
	}

	public class KioskFrontendSale : ISaleModule
	{

		void ISaleModule.Start()
		{
			Log.log( "Recieved Start" );
		}

		void ISaleModule.SetBingoday( DateTime date )
		{
			Log.log( "Recieved SetBingoday" );
		}

		void ISaleModule.SetSession( int session_number )
		{
			Log.log( "Recieved SetSession" );
		}

		void ISaleModule.BeginTransaction( object transaction_id )
		{
			Log.log( "Recieved BeginTransaction" );
		}

		void ISaleModule.EndTransaction()
		{
			Log.log( "Recieved EndTransaction" );
		}

		void ISaleModule.ClearAll()
		{
			Log.log( "Recieved ClearAll" );
		}

		void ISaleModule.ClearItem( object item_id )
		{
			Log.log( "Recieved ClearItem" );
		}

		void ISaleModule.VoidTransaction( object transaction_id )
		{
			Log.log( "Recieved VoidTransaction" );
		}

		void ISaleModule.VoidTransactionItem( object transaction_id, object item_id )
		{
			Log.log( "Recieved VoidTransactionItem" );
		}

		void ISaleModule.HandleBarcode( string barcode )
		{
			Log.log( "Barcode Recieved [" + barcode + "]" );
		}

        void ISaleModule.SetElecUnit( object unit_type )
        {
        }
	}
}
