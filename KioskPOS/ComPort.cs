using System;
using System.IO.Ports;
using System.Text;
using System.Windows.Forms;
using CORE.Printing;

namespace MobilePOS
{
	class ComPort
	{
		SerialPort sp;
		
		//FileStream fs;
		//BinaryReader br;
		//BinaryWriter bw;

		StringBuilder collection;

		CORE.Printing.ReceiptPrinter lpt;
		//BinaryWriter lpt;
		//FileStream fs;

		public void Write( String s )
		{
			if( lpt != null )
			{
				//Console.WriteLine( s );
				lpt.Print( s );
				//lpt.Write( s );
			}
			else
			{
				try
				{
					sp.Write( s );
				}
				catch( Exception ex )
				{
					System.Diagnostics.Debug.WriteLine( ex.Message );
				}
			}
		}
		public void Flush()
		{
			if( lpt != null )
			{
				lpt.Flush();
			}
		}
		public delegate void CallThisWithData( string s );
		CallThisWithData callme;
		/// <summary>
		/// Event callback, what do you care?
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void sp_DataReceived( object sender, SerialDataReceivedEventArgs e )
		{
			while( sp.BytesToRead > 0 )
			{
				String s = sp.ReadExisting();
				collection.Append( s );
				//callme( s );
				//Console.WriteLine( sp.PortName + "Read : " + s );
			}
		}

		Timer t;
		/// <summary>
		/// Open with a string like "COM1", "COM8" ...
		/// </summary>
		/// <param name="port">the port name a string like "COM1", "COM8" ...</param>
		public ComPort( String port, CallThisWithData callthis )
		{
			if( String.Compare( port, "none", true ) == 0 )
				return;
			collection = new StringBuilder();
			last_length = 0;
			t = new Timer();
			t.Interval = 250;
			t.Tick += new EventHandler( t_Tick );
			t.Start();
			callme = callthis;
			try
			{
				if( String.Compare( port, 0, "lpt", 0, 3, true ) != 0 )
				{
					sp = new SerialPort( port );
					sp.BaudRate = 9600;
					sp.DataReceived += new SerialDataReceivedEventHandler( sp_DataReceived );
					sp.Open();
				}
				else
				{
					//Console.WriteLine( "Attempting open... ("+port+")" );
					lpt = new ReceiptPrinter();
					//fs = new FileStream( port, FileMode.Open );
					//lpt = new BinaryWriter( fs );
					
				}
			}
			catch( Exception ex )
			{
				Console.WriteLine( ex );
				//throw new Exception( "Failed to open " + port );
			}
		}

		int last_length;
		void t_Tick( object sender, EventArgs e )
		{
			if( collection.Length > 0 )
			{
				if( collection.Length == last_length )
				{
					callme( collection.ToString() );
					collection.Length = 0;
					last_length = 0;
				}
				else
				{
					last_length = collection.Length;
				}
			}
			else
				last_length = 0;
		}

		public bool IsOpen()
		{
			if( lpt != null )
			{
				return true;
			}
			else if( sp != null )
			{
				if( !sp.IsOpen )
					try
					{
						sp.Open();
					}
					catch( Exception ex )
					{
						//throw new Exception( "Failed to open " + sp.PortName );
						return false;
					}
				return sp.IsOpen;
			}
			return false;
		}
		~ComPort()
		{
			if( sp != null )
			{
				sp.Close();
				sp.Dispose();
				sp = null;
			}
			if( lpt != null )
			{
				lpt = null;
			}
		}
	}
}
