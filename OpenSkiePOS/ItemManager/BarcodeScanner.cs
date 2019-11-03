using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO.Ports;
using xperdex.classes;
using System.Windows.Forms;

namespace ItemManager
{
	class BarcodeScanner
	{
		String scanner_port = xperdex.classes.Options.Default["Barcode Paper"]["COM PORT", "COm5"];
		bool skip_leading_characters = false;
		SerialPort sp;
		
		//FileStream fs;
		//BinaryReader br;
		//BinaryWriter bw;

		StringBuilder collection;

		public void Write( String s )
		{
			try
			{
				sp.Write( s );
			}
			catch( Exception ex )
			{
				Log.log( ex.Message );
			}
		}

		public delegate void CallThisWithData( string s );
		public event CallThisWithData DataReceived;
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
		public BarcodeScanner( )
		{
			Log.log( "Opening barcode scanner on " + scanner_port );
			if( String.Compare( scanner_port, "none", true ) == 0 )
				return;
			collection = new StringBuilder();
			last_length = 0;
			t = new Timer();
			t.Interval = 250;
			t.Tick += new EventHandler( t_Tick );
			t.Start();
			try
			{
				sp = new SerialPort( scanner_port );
				sp.BaudRate = 9600;
				sp.DataReceived += new SerialDataReceivedEventHandler( sp_DataReceived );
				sp.Open();
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
					Log.log( "Dispatching buffer..." );
					if( DataReceived != null )
						DataReceived( collection.ToString() );
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
			if( sp != null )
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
		~BarcodeScanner()
		{
			if( sp != null )
			{
				sp.Close();
				sp.Dispose();
				sp = null;
			}
		}
}
}
