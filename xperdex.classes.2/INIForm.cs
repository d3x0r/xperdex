using System;
using System.Windows.Forms;

namespace xperdex.classes
{
	public partial class INIForm : Form
	{
		String result;

		public static Guid GetGUID( DsnConnection dsn )
		{
			if ( dsn == null )
				return Guid.NewGuid();
			if ( ( dsn.DbMode == DsnConnection.ConnectionMode.Odbc &&
				dsn.DbFlavor == DsnConnection.ConnectionFlavor.MySqlNative )
				)
			{
				Guid id = Guid.NewGuid();
				Byte[] bytes = id.ToByteArray();
				long ticks = DateTime.Now.Ticks / 10000;
				Byte[] tick_bytes = BitConverter.GetBytes( ticks );
				for ( int n = 0; n < 6; n++ )
					bytes[0] = tick_bytes[5-n];
				Guid COMB = new Guid( bytes );
				return COMB;

			}
			else if ( dsn.DbMode == DsnConnection.ConnectionMode.SQLServer ||
				 ( dsn.DbMode == DsnConnection.ConnectionMode.Odbc &&
				dsn.DbFlavor == DsnConnection.ConnectionFlavor.SQLServer ) )
			{
				Guid id = Guid.NewGuid();
				Byte[] bytes = id.ToByteArray();
				long ticks = DateTime.Now.Ticks / 10000;
				Byte[] tick_bytes = BitConverter.GetBytes( ticks );
				for ( int n = 0; n < 6; n++ )
					bytes[15 - n] = tick_bytes[n];
				Guid COMB = new Guid( bytes );
				return COMB;
			}
			else
			{
				Log.log( "Failed to recognize how to create optimal keys for database flavor and mode." );
			}
			return new Guid();
		}


		public override string ToString()
		{
			return result;
		}
		INIEntry _entry;
		String _Default;
		public INIForm( String file, String section, INIEntry entry, String Default, String Description )
		{
			_entry = entry;
			_Default = Default;
			InitializeComponent();
			this.label1.Text = file;
			this.label2.Text = "[" + section + "]";
			this.label3.Text = entry.Name + " =";
			this.textBox1.Text = Default;
			if( Description != null )
				this.labelDescription.Text = Description;
			else
				this.labelDescription.Text = "";
			this.label4.Text = "The value in the INI below has not been found\nPlease enter a good value or accept the default.";
		}

		public INIForm( String file, String section, INIEntry entry, String Default )
		{
			_entry = entry;
			_Default = Default;
			InitializeComponent();
			this.label1.Text = file;
			this.label2.Text = "[" + section + "]";
			this.label3.Text = entry.Name + " =";
			this.textBox1.Text = Default;
			this.label4.Text = "The value in the INI below has not been found\nPlease enter a good value or accept the default.";
		}

		public INIForm( String entry, String Default )
		{
			//_entry = entry;
			_Default = Default;
			InitializeComponent();
			this.label1.Text = null;
			this.label2.Text = null;
			this.label3.Text = null;

			this.label3.Text = entry + " =";
			this.textBox1.Text = Default;
			this.label4.Text = "The value in the INI below has not been found\nPlease enter a good value or accept the default.";
		}

		private void button1_Click( object sender, EventArgs e )
		{
			if( _entry != null )
				_entry.Value = this.textBox1.Text;
			result = this.textBox1.Text;
			this.Close();
		}
	}
}