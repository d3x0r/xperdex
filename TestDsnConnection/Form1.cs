using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using xperdex.classes;
using System.Data.Common;

namespace TestDsnConnection
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		DsnConnection dsn;
		Timer t;
		private void Form1_Load( object sender, EventArgs e )
		{
			dsn = new DsnConnection( "MySQL" );
			dsn.AllowFallback = true;
			dsn.DesiredMode = DsnConnection.ConnectionMode.MySqlNative;
			
			t = new Timer();
			t.Interval = 250;
			t.Tick += new EventHandler( t_Tick );
			t.Start();
		}

		void t_Tick( object sender, EventArgs e )
		{
			DbDataReader reader = dsn.ExecuteReader( "select 1" );
			if( reader.HasRows )
			{
				while( reader.Read() )
				{

				}
			}
		}
	}
}
