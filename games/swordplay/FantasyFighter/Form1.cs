using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FantasyFighter
{
	public partial class Form1 : Form
	{
		ClientPort client;

		public Form1()
		{
			InitializeComponent();
		}

		private void button1_Click( object sender, EventArgs e )
		{
			client = new ClientPort();
			client.Start();
		}

		private void buttonLogin_Click( object sender, EventArgs e )
		{
			client.Login( textBoxUserName.Text );

		}

		class ListItem
		{
			public string name;
			public int value;
			public ListItem( string s, int val )
			{
				name = s;
				value = val;
			}
			public override string ToString()
			{
				return name;
			}
		}

		private void Form1_Load( object sender, EventArgs e )
		{
			foreach( int value in Enum.GetValues( typeof( FantasyFighterProtocol.FighterStates.Stance ) ) )
			{
				String s = Enum.GetName( typeof( FantasyFighterProtocol.FighterStates.Stance)
					, value );
				listBox1.Items.Add( new ListItem( s, value ) );
			}

			foreach( int value in Enum.GetValues( typeof( FantasyFighterProtocol.FighterStates.WieldedWeapon ) ) )
			{
				String s= Enum.GetName( typeof( FantasyFighterProtocol.FighterStates.WieldedWeapon )
					, value );
				listBox2.Items.Add( new ListItem( s, value ) );
			}
		}

		private void listBox1_SelectedIndexChanged( object sender, EventArgs e )
		{
			if( client != null ) 
				client.ChangeStance( ( listBox1.SelectedItem as ListItem ).value );
		}

		private void listBox2_SelectedIndexChanged( object sender, EventArgs e )
		{
			if( client != null )
				client.ChangeWeapon( ( listBox2.SelectedItem as ListItem ).value );

		}

	}
}
