using System;
using System.Windows.Forms;
using xperdex.core;

namespace OpenSkiePOS
{
	public partial class ConfigurePOSPlugins : Form
	{
		public ConfigurePOSPlugins()
		{
			InitializeComponent();
		}

		private void buttonDone_Click( object sender, EventArgs e )
		{
			this.Close();
		}

		private void buttonAddPlugin_Click( object sender, EventArgs e )
		{
			OpenFileDialog openFileDialog1 = new OpenFileDialog();

			openFileDialog1.InitialDirectory = Environment.CurrentDirectory;
			openFileDialog1.Filter = "Assembly files (*.exe;*.dll)|*.exe;*.dll|All files (*.*)|*.*";
			openFileDialog1.FilterIndex = 1;
			openFileDialog1.RestoreDirectory = true;
			//openFileDialog1.RestoreDirectory = true;

			if( openFileDialog1.ShowDialog() == DialogResult.OK )
			{
				try
				{
					xperdex.core.osalot.AssemblyTracker tracker;
					if( POS.Local.LoadAssembly( openFileDialog1.FileName, out tracker ) )
						ListPlugins.Items.Add( tracker );
				}
				catch( Exception e2 )
				{
					Console.WriteLine( e2.Message );
				}
			}			

		}

		private void buttonRemovePlugin_Click( object sender, EventArgs e )
		{
			object o = ListPlugins.SelectedItem;
			osalot.AssemblyTracker tracker = o as osalot.AssemblyTracker;
			tracker.removed = true;
			ListPlugins.Items.Remove( o );

		}

		private void ConfigurePOSPlugins_Load( object sender, EventArgs e )
		{
			ListPlugins.Items.Clear();
			foreach( osalot.AssemblyTracker o in POS.Local.assemblies )
			{
				if( !o.removed )
					ListPlugins.Items.Add( o );
			}

		}

	}
}
