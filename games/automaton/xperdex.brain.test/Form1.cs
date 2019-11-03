using System.Windows.Forms;
using xperdex.brain.core;

namespace xperdex.brain.test
{
	public partial class Form1 : Form
	{
		Brain brain;
		public Form1()
		{
			InitializeComponent();
			brain = new Brain();

			NeuronProperties np = new NeuronProperties( brain.GetNeuron() );
			np.ShowDialog();

			brain.DefaultNeuron.Logic = new NeuronLogic( NeuronLogic.Algorithm.analog );
			brain.DefaultNeuron.min = -256;
			brain.DefaultNeuron.max = 256;
			brain.DefaultNeuron.threshold = 0;

			Neuron n1 = brain.GetNeuron("n1");
			n1.Logic = new Oscillator( 1000 );
			n1.threshold = 0;

#if asdfasdf
			Neuron n2 = brain.GetNeuron("n2");
			Synapse s1 = brain.GetSynapse("s1");
			Neuron n3 = brain.GetNeuron( "n3" );			
			Neuron n4 = brain.GetNeuron( "n4" );			
			Synapse s2 = brain.GetSynapse( "s2" );

			// try and use just the + operator alone...
			// fails ( ie, expression with no meaning )
//			n2 + s2 + n1 + s1 + n2;

			// manually link with external synapse...
			//n2 += s1 += n1 += s2 += n2;

			// automatically pull a synapse to link these
			n2 += n1 += n2;

			LevelLock l1 = new LevelLock( brain );
			FlipFlop f1 = new FlipFlop( brain );

			f1 += n3;
			n4 += f1;

			//n3.threshold = -50;

			n3.Log();
			n4.Log();

			n3.Logic = new NeuronLogic( NeuronLogic.Algorithm.digital );
#endif

			while( true )
			{
				brain.cycle++;
				n1.Log();
				
#if asdfasdf
				n3.Log();
				n4.Log();
				f1.Log();

				//n3.threshold = -50;
				if( n3.threshold < 0 )
					n3.threshold = 50;
				else
					n3.threshold = -50;
#endif
			 }
#if asdfasdf
			Console.WriteLine( "N3 = " + (int)n3 );
			Console.WriteLine( "N4 = " + (int)n4 );
			brain.cycle++;
			Console.WriteLine( "N3 = " + (int)n3 );
			Console.WriteLine( "N4 = " + (int)n4 );
			brain.cycle++;
			Console.WriteLine( "N3 = " + (int)n3 );
			Console.WriteLine( "N4 = " + (int)n4 );
			brain.cycle++;
			Console.WriteLine( "N3 = " + (int)n3 );
			Console.WriteLine( "N4 = " + (int)n4 );
			brain.cycle++;
			Console.WriteLine( "N3 = " + (int)n3 );
			Console.WriteLine( "N4 = " + (int)n4 );
			brain.cycle++;
			Console.WriteLine( "N3 = " + (int)n3 );
			Console.WriteLine( "N4 = " + (int)n4 );

			n3.threshold = 50;
			brain.cycle++;
			Console.WriteLine( "N3 = " + (int)n3 );
			Console.WriteLine( "N4 = " + (int)n4 );
			brain.cycle++;
			Console.WriteLine( "N3 = " + (int)n3 );
			Console.WriteLine( "N4 = " + (int)n4 );
			brain.cycle++;
			Console.WriteLine( "N3 = " + (int)n3 );
			Console.WriteLine( "N4 = " + (int)n4 );
			brain.cycle++;
			Console.WriteLine( "N3 = " + (int)n3 );
			Console.WriteLine( "N4 = " + (int)n4 );
			brain.cycle++;
			Console.WriteLine( "N3 = " + (int)n3 );
			Console.WriteLine( "N4 = " + (int)n4 );
			brain.cycle++;
			Console.WriteLine( "N3 = " + (int)n3 );
			Console.WriteLine( "N4 = " + (int)n4 );
			n3.threshold = -50;
			brain.cycle++;
			Console.WriteLine( "N3 = " + (int)n3 );
			Console.WriteLine( "N4 = " + (int)n4 );
			brain.cycle++;
			Console.WriteLine( "N3 = " + (int)n3 );
			Console.WriteLine( "N4 = " + (int)n4 );
			brain.cycle++;
			Console.WriteLine( "N3 = " + (int)n3 );
			Console.WriteLine( "N4 = " + (int)n4 );
			brain.cycle++;
			Console.WriteLine( "N3 = " + (int)n3 );
			Console.WriteLine( "N4 = " + (int)n4 );
			brain.cycle++;
			Console.WriteLine( "N3 = " + (int)n3 );
			Console.WriteLine( "N4 = " + (int)n4 );
			brain.cycle++;
			Console.WriteLine( "N3 = " + (int)n3 );
			Console.WriteLine( "N4 = " + (int)n4 );


			for( int xx = 0; xx < 100; xx++ )
			{
				brain.cycle = xx;
				Console.WriteLine( "output n1 = " + (int)n1 );
				Console.WriteLine( "output n2 = " + (int)n2 );
			}


			Console.WriteLine( "output n1 = " + (int)n1 );
			Console.WriteLine( "output n2 = " + (int)n2 );
#endif

			//Point[] atest = new Point[256];
			//atest[500] = new Point( 10, 10 );
		}

        private void Form1_Load(object sender, System.EventArgs e)
        {

        }
	}
}