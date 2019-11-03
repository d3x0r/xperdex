using System;
using System.Windows.Forms;

namespace xperdex.core
{
	public partial class EditPlugins: Form
	{
		public EditPlugins()
		{
			InitializeComponent();
		}

		private void FillCurrentPluginSystems()
		{
			SystemList.Items.Clear();
			osalot.AssemblyTracker o = ListPlugins.SelectedItem as osalot.AssemblyTracker;
			if( o != null )
			{
				foreach( string system in o.allow_on_system )
					SystemList.Items.Add( system );
			}
		}
		private void FillLists()
		{
			ListPlugins.Items.Clear();
			foreach( osalot.AssemblyTracker o in core_common.assemblies )
			{
				if( !o.removed )
					ListPlugins.Items.Add( o );
			}
			FillCurrentPluginSystems();
		}
		private void EditPlugins_Load( object sender, EventArgs e )
		{
			FillLists();
		}


		private void button1_Click( object sender, EventArgs e )
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
					if( core_common.LoadAssembly( openFileDialog1.FileName ) )
						FillLists();
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

		private void button4_Click( object sender, EventArgs e )
		{
			String s = textBox_NewSystem.Text;
				//Interaction.InputBox( "Enter System Name Mask"
				 //, "Add System", null, -1, -1 );
			if( s != null )
			{
				SystemList.Items.Add( s );
			}
		}

		private void button3_Click( object sender, EventArgs e )
		{
			object o = SystemList.SelectedItem;
			SystemList.Items.Remove( o );
		}

		private void button2_Click( object sender, EventArgs e )
		{
			object o = ListPlugins.SelectedItem;
			osalot.AssemblyTracker tracker = o as osalot.AssemblyTracker;
			tracker.removed = true;
			ListPlugins.Items.Remove( o );
		}

		private void ListPlugins_SelectedValueChanged( object sender, EventArgs e )
		{
			FillCurrentPluginSystems();
		}

	}
}