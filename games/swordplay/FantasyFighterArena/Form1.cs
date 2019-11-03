using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FantasyFighterArena
{
	public partial class Form1 : Form
	{
		ServerPort server;
		public Form1()
		{
			InitializeComponent();
		}

		private void button1_Click( object sender, EventArgs e )
		{
			server = new ServerPort( this );
			server.Start();
		}

		private void Form1_Load( object sender, EventArgs e )
		{

		}

		delegate void AddEventType( String event_text );
		public void AddEvent( String name )
		{
			if( this.InvokeRequired )
			{
				this.Invoke( new AddEventType( AddEvent ), name );
			}
			else
			{
				listBox1.Items.Insert( 0, name );
			}
		}
	}
}
