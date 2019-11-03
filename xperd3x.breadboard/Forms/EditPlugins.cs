using System;
using Microsoft.VisualBasic;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.IO;

namespace xperd3x.breadboard
{
	public partial class EditPlugins: Form
	{
		Board board;
		public EditPlugins(Board board)
		{
			this.board = board;
			InitializeComponent();
		}

		private void FillLists()
		{
			ListPlugins.Items.Clear();
			foreach( Assembly o in board.assemblies )
			{
				ListPlugins.Items.Add( o );
			}
		}
		private void EditPlugins_Load( object sender, EventArgs e )
		{
			FillLists();
		}

		private void button1_Click( object sender, EventArgs e )
		{
			OpenFileDialog openFileDialog1 = new OpenFileDialog();

			openFileDialog1.InitialDirectory = ".";
			openFileDialog1.Filter = "Assembly files (*.exe;*.dll)|*.exe;*.dll|All files (*.*)|*.*";
			openFileDialog1.FilterIndex = 1;
			//openFileDialog1.RestoreDirectory = true;

			if( openFileDialog1.ShowDialog() == DialogResult.OK )
			{
				try
				{
					Assembly a = Assembly.LoadFile( openFileDialog1.FileName );
					board.LoadPeices( a );
					board.assemblies.Add( a );
					ListPlugins.Items.Add( a );
				}
				catch( Exception e2 )
				{
					Console.WriteLine( e2.Message );
				}
			}			

		}

		private void button5_Click( object sender, EventArgs e )
		{
			DialogResult = DialogResult.OK;
		}

		private void button2_Click( object sender, EventArgs e )
		{
			object o = ListPlugins.SelectedItem;
			Assembly tracker = o as Assembly;
			ListPlugins.Items.Remove( o );
		}

	}
}