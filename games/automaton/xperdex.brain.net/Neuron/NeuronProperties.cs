using System;
using System.Collections.Generic;
using System.Reflection;
using System.Windows.Forms;

namespace xperdex.brain.core
{
	public partial class NeuronProperties : Form
	{
		NeuronAlgorithm original;
		Neuron _neuron;
		public NeuronProperties( Neuron n )
		{
			_neuron = n;
			original = n.Logic;
			InitializeComponent();
		}

		protected override void OnLoad( EventArgs e )
		{
			xperdex.classes.TypeMap.assemblies.Load( Assembly.GetExecutingAssembly() );
			List<Type> algos = xperdex.classes.TypeMap.Locate( typeof( NeuronAlgorithm ), false );
			//algos[0].Name
			listBox1.DataSource = algos;
			listBox1.DisplayMember = "Name";
			//base.OnLoad( e );
		}

		private void button1_Click( object sender, EventArgs e )
		{
			Type x = listBox1.SelectedItem as Type;
			if( x != null )
			{
				MethodInfo method = x.GetMethod( "Properties" );
				if( method != null )
					method.Invoke( _neuron.Logic, null );
			}
		}

		private void listBox1_SelectedIndexChanged( object sender, EventArgs e )
		{
			Type x = listBox1.SelectedItem as Type;
			if( x != null )
			{
				if( original.GetType() == x )
				{
					_neuron.Logic = original;
				}
				else
				{
					_neuron.Logic = Activator.CreateInstance( x ) as NeuronAlgorithm;
				}
			}
		}
	}
}