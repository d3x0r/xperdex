#define KioskPOS


using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Media;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Windows.Forms;
using xperdex.classes;
using WebInterfaces;

namespace MobilePOS
{
	public partial class Form1 : Form
	{
		int error_offset;
		int player_item_index;
		int total_item_index;
		long total_cash;
#if KioskPOS
		SoundPlayer sp;
#endif
		void PlaySound( string name )
		{
#if KioskPOS
			if( sp == null )
				sp = new SoundPlayer();
			sp.SoundLocation = "c:\\tmp\\Raw Bingo Wavesx\\O64.wav";
			try
			{
				sp.Play();
			}
			catch( System.IO.FileNotFoundException nf )
			{

				// en whatever (file load exeption??!!)
			}
			catch( System.IO.FileLoadException fnf )
			{
				// no file...
			}
			catch( InvalidOperationException ex )
			{
				// bad format
			}
#endif
#if !KioskPOS
			if( audioPlayer == null )
			{
				audioPlayer = new Process();
				audioPlayer.StartInfo = new ProcessStartInfo( "wmplayer", "\"\\Application Data\\Sounds\\" + name + "\"" );
				//audioPlayer.StartInfo.UseShellExecute = true;
				//audioPlayer.
				audioPlayer.Start();
				audioPlayer.Dispose();
				audioPlayer = null;
			}
#endif
		}
		void PrintHeader( Money cash, Money total )
		{
			Console.WriteLine( "Writing to print?" );
			Local.printer.Write( "                              " );
			Local.printer.Write( "\r\n" );
			Local.printer.Write( "         Welcome To           " );
			Local.printer.Write( "\r\n" );
			Local.printer.Write( "   Insert Casino Name Here    " );
			Local.printer.Write( "\r\n" );
			string s = DateTime.Now.ToShortDateString() + "  " + DateTime.Now.ToShortTimeString();

			Local.printer.Write( "                              ".Substring( 0, ( 30 - s.Length ) / 2 ) + s );
			Local.printer.Write( "\r\n" );

			foreach( Item i in Local.items )
			{
				Local.printer.Write( i.Level + "                              ".Substring( 0, 35 - i.Level.Length - ( (string)i.Price ).Length ) + i.Price );
				Local.printer.Write( "\r\n" );
			}

			Local.printer.Write( "Total" + "                              ".Substring( 0, 35 - "Total".Length - total.ToString().Length ) + total );
			Local.printer.Write( "\r\n" );

			Local.printer.Write( "Cash" + "                              ".Substring( 0, 35 - "Cash".Length -cash.ToString().Length) + cash );
			Local.printer.Write( "\r\n" );
			if( cash > total )
			{
				Local.printer.Write( "Change" + "                              ".Substring( 0, 35 - "Change".Length  - new Money(cash-total).ToString().Length ) + new Money( cash-total ));
				Local.printer.Write( "\r\n" );
			}

			Local.printer.Write( "\r\n" );
			Local.printer.Write( "\r\n" );
			Local.printer.Write( " Player ID:\r\n" );
			Local.printer.Write( "   " + Local.player.Name );
			Local.printer.Write( "\f\r\n\r\n\r\n\r\n" );
			//Local.printer.Write( "\r\n" );

			Local.printer.Write( "\x1b\x77" );
			Local.printer.Write( "\x1B\x61\x0A" );
			Local.printer.Write( "\x1B\x64\x30" );


			Local.printer.Flush();
			Local.player.Card = null;



		}

		internal void scanner_receive( string s )
		{
			// parse S into a thing...
			Console.WriteLine( "Recieved : " + s + " : " + s.Length );
			if( s.Length == 7 )
			{
				if( string.Compare( s, "quitnow" ) == 0 )
					Application.Exit();
				if( string.Compare( s, "exitnow" ) == 0 )
					Application.Exit();
				return;
			}
			else if( s.Length == 3 )
			{
				switch( s )
				{
				case "L1 ":
					ResetList();
					break;
				case "L1V":
					PrintHeader( 0, 0 );
					ResetList();
					break;
				}
			}
			else if( s.Length == 15 )
			{
				//Local.printer.Write( s );
				Console.WriteLine( "Recieved : " + s );
				InsertItem( new Item( s ) );
			}
			//Local.printer.Write( "\r\n" );
		}


		delegate void SetTextCallback( string text );


		public void printer_receive( string s )
		{

			// player card received...
			if( this.listBox1.InvokeRequired )
			{
				this.Invoke( new SetTextCallback( printer_receive ), new object[] { s } );
			}
			else
			{
				Local.player.MagStripe = s;

				listBox1.Items[player_item_index + error_offset] = "Card : " + Local.player.Name;

			}
		}

		internal bool AddMoney( long value )
		{
			total_cash += value;
			textBoxCash.Text = new Money( total_cash );
			return true;
		}

		internal void InsertItem( Item i )
		{

			Local.items.Add( i );
			listBox1.Items.Insert( total_item_index, i );
			total_item_index++;
			listBox1.Items[total_item_index] = "Total = " + new Money( Local.items.Total );
			player_item_index++;
			textBoxSaleTotal.Text = new Money( Local.items.Total );
		}

		void ResetList()
		{
			Local.items.Clear();
			listBox1.Items.Clear();
			total_item_index = 0;
			listBox1.Items.Add( "Total = " + new Money( 0 ) );
			player_item_index = 1;
			listBox1.Items.Add( "Card : No Player Scanned" );
			scanner_error = false;
			total_cash = 0;
			textBoxCash.Text = new Money( 0 ).ToString();
			textBoxSaleTotal.Text = new Money( 0 ).ToString();
		}
		Timer t;
		public Form1()
		{
			Local.form = this;
			InitializeComponent();
			ResetList();
			Local.player = new Player();
			Local.scanner = new ComPort( "NONE", scanner_receive );
			Local.cardswipe = new ComPort( "NONE", printer_receive );
			//Local.printer = new ComPort( "COM8", printer_receive );
			Local.printer = new ComPort( "LPT1", null );
			psI_Button1.gs.attrib.SetColors( Color.DarkBlue, Color.Black );
			psI_Button2.gs.attrib.SetColors( Color.Green, Color.Black );
			psI_Button1.gs.attrib.TextColor = Color.White;
			psI_Button2.gs.attrib.TextColor = Color.White;

            SetupServers();

			OpenChannel2();
            try
            {

                channel2.Start();
            }
            catch( Exception e )
            {
                Log.log( e.Message );
            }
			OpenTransactionServer();

			try
			{
				int global_transnum;
				int local_transnum;
				transaction_channel.OpenTransaction( transaction_client_token, out global_transnum, out local_transnum );

				channel2.SetBingoday( DateTime.Now );
				channel2.SetSession( 1 );

				channel2.BeginTransaction( global_transnum );
			}
			catch( Exception e )
			{
				Log.log( "Init Failure: " + e.Message );
			}
			t = new Timer();
			t.Interval = 250;
			t.Tick += new EventHandler( t_Tick );
			t.Enabled = true;

			//ComPort test = Local.printer;

		}

        private void SetupServers()
        {
            if( Local.KioskInterface == null )
            {
                string baseaddr = INI.Default["Web Interface"]["Kiosk Service Address", "http://0.0.0.0:8080/KioskService"];
                Uri baseAddress = new Uri( baseaddr );

                Local.KioskInterface = new ServiceHost( typeof( KioskFrontendInterface ), baseAddress );

                // Enable metadata publishing. 
                ServiceMetadataBehavior smb;
                smb = Local.KioskInterface.Description.Behaviors.Find<ServiceMetadataBehavior>();
                if( smb == null )
                    smb = new ServiceMetadataBehavior();
                smb.HttpGetEnabled = true;
                smb.MetadataExporter.PolicyVersion = PolicyVersion.Policy15;
                Local.KioskInterface.Description.Behaviors.Add( smb );

                Local.KioskInterface.AddServiceEndpoint( typeof( IKioskFrontend ), new BasicHttpBinding(), "" );

                try
                {

                    //for some reason a default endpoint does not get created here 
                    Local.KioskInterface.Open();
                }
                catch( Exception e2 )
                {
                    Log.log( e2.Message );
                    Local.KioskInterface = null;
                }
            }

            if( Local.BarcodeInterface == null )
            {
                string baseaddr = INI.Default["Web Interface"]["Barcode Service Address", "http://0.0.0.0:8080/BarcodeService"];
                Uri baseAddress = new Uri( baseaddr );

                Local.BarcodeInterface = new ServiceHost( typeof( KioskBarcodeInterface ), baseAddress );

                // Enable metadata publishing. 
                ServiceMetadataBehavior smb;
                smb = Local.BarcodeInterface.Description.Behaviors.Find<ServiceMetadataBehavior>();
                if( smb == null )
                    smb = new ServiceMetadataBehavior();
                smb.HttpGetEnabled = true;
                smb.MetadataExporter.PolicyVersion = PolicyVersion.Policy15;
                Local.BarcodeInterface.Description.Behaviors.Add( smb );

                Local.BarcodeInterface.AddServiceEndpoint( typeof( IBarcodeReceiver ), new BasicHttpBinding(), "" );

                try
                {
                    //for some reason a default endpoint does not get created here 
                    Local.BarcodeInterface.Open();
                }
                catch( Exception e2 )
                {
                    Log.log( e2.Message );
                    Local.BarcodeInterface = null;
                }
            }

            OpenChannel2();
            OpenTransactionServer();


            if( Local.SaleInterface == null )
            {
                string baseaddr = INI.Default["Web Interface"]["Kiosk Sales Service Address", "http://0.0.0.0:8080/KioskSalesService"];
                Uri baseAddress = new Uri( baseaddr );

                Local.SaleInterface = new ServiceHost( typeof( KioskFrontendSale ), baseAddress );

                // Enable metadata publishing. 
                ServiceMetadataBehavior smb;
                smb = Local.SaleInterface.Description.Behaviors.Find<ServiceMetadataBehavior>();
                if( smb == null )
                    smb = new ServiceMetadataBehavior();
                smb.HttpGetEnabled = true;
                smb.MetadataExporter.PolicyVersion = PolicyVersion.Policy15;
                Local.SaleInterface.Description.Behaviors.Add( smb );

                Local.SaleInterface.AddServiceEndpoint( typeof( ISaleModule ), new BasicHttpBinding(), "" );

                try
                {
                    //for some reason a default endpoint does not get created here 
                    Local.SaleInterface.Open();
                }
                catch( Exception e2 )
                {
                    Log.log( e2.Message );
                    Local.SaleInterface = null;
                }
            }
        }

		private void Form1_Load( object sender, EventArgs e )
		{
			psI_Button1.Text = "Cancel";
			psI_Button2.Text = "Tender";
			TabStops = new int[] { 150 };
		}

		int bypass;
		bool sounding;
		Process audioPlayer;
		bool scanner_error;

		ChannelFactory<ISaleModule> factory2;
		ISaleModule channel2;
		void OpenChannel2()
		{
			if( factory2 == null )
			{
				BasicHttpBinding binding = new BasicHttpBinding();
				EndpointAddress address = new EndpointAddress( INI.Default["Web Interface"]["Connect To Kiosk Sales Service Address", "http://127.0.0.1:8082/KioskSalesService"] );
                factory2 = new ChannelFactory<ISaleModule>( binding, address );
				channel2 = factory2.CreateChannel();
			}
		}

		ChannelFactory<ITransactionServer> transaction_factory;
		ITransactionServer transaction_channel;
		int transaction_client_token;
		void OpenTransactionServer()
		{
			if( transaction_factory == null )
			{
				//String address_string = "http://127.0.0.1:8080/TransactionService";
				String address_string = "http://127.0.0.1:8080/TransactionService";
				BasicHttpBinding binding = new BasicHttpBinding();
				EndpointAddress address = new EndpointAddress( address_string );
				transaction_factory = new ChannelFactory<ITransactionServer>( binding, address );
				transaction_channel = transaction_factory.CreateChannel();
				transaction_client_token = transaction_channel.Connect( DateTime.Now );
			}
		}

		void t_Tick(object sender, EventArgs e)
		{
			/*
			if( !Local.scanner.IsOpen() )
			{
				if( !scanner_error )
				{
					listBox1.Items.Insert( 0, "Failed to open scanner..." );
					error_offset++;
					scanner_error = true;
				}
			}
			 */
		}

		protected override void OnClosing( CancelEventArgs e )
		{
			Local.printer = null;
			Local.scanner = null;
			base.OnClosing( e );
		}

		private void Form1_Deactivate( object sender, EventArgs e )
		{
			if( sounding )
			{
				this.Activate();
				sounding = false;
			}
			else
				Application.Exit();
		}

		private void psI_Button1_Click( object sender, EventArgs e )
		{
			ResetList();
		}

		private void psI_Button2_Click( object sender, EventArgs e )
		{
			Money cash = new Money( textBoxCash.Text );
			Money total = new Money( textBoxSaleTotal.Text );
			if( total == 0 )
			{
				xperdex.gui.Banner.Show( "No items scanned\ncannot perform transaction" );
				return;
			}

			if( cash < total )
			{
				xperdex.gui.Banner.Show( "You need to put in at least as much cash as the sale total" );
				return;
			}

			{
				PrintHeader( cash, total );

				channel2.EndTransaction();
				transaction_channel.CloseTransaction( transaction_client_token );

				ResetList();

				int global_transnum;
				int local_transnum;
				transaction_channel.OpenTransaction( transaction_client_token, out global_transnum, out local_transnum );
				channel2.BeginTransaction( global_transnum );
			}

		}

		private const int LB_SETTABSTOPS = 0x192;
		// Declaration of external function
		[System.Runtime.InteropServices.DllImport( "user32.dll" )]
		private static extern int SendMessage( int hWnd, int wMsg, int wParam, ref int lParam );
		int[] tab_stops;
		public int[] TabStops
		{
			get
			{
				return tab_stops;
			}
			set
			{
				tab_stops = value;
				if( tab_stops != null )
				{
					int result;
					// Send LB_SETTABSTOPS message to ListBox
					result = SendMessage( listBox1.Handle.ToInt32(), LB_SETTABSTOPS, tab_stops.Length, ref tab_stops[0] );

					// Refresh the ListBox control.
					//this.R*efresh();
				}
			}
		}

		internal void BackendRestarted()
		{
			ResetList();
			channel2.SetSession( 1 );
			channel2.SetBingoday( DateTime.Now );
			channel2.BeginTransaction( 123557 );

		}
	}


	public class MyListBox : ListBox
	{

		private const int LB_SETTABSTOPS = 0x192;
		// Declaration of external function
		[System.Runtime.InteropServices.DllImport( "user32.dll" )]
		private static extern int SendMessage( int hWnd, int wMsg, int wParam, ref int lParam );
		int[] tab_stops;
		public int[] TabStops
		{
			get
			{
				return tab_stops;
			}
			set
			{
				tab_stops = value;
				if( tab_stops != null )
				{
					int result;
					// Send LB_SETTABSTOPS message to ListBox
					result = SendMessage( this.Handle.ToInt32(), LB_SETTABSTOPS, tab_stops.Length, ref tab_stops[0] );

					// Refresh the ListBox control.
					//this.Refresh();
				}
			}
		}

		public MyListBox()
		{
		}

	}

}
