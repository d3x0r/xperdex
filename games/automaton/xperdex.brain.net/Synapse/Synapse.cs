using System;
using System.Collections.Generic;
using System.Text;

namespace xperdex.brain.core
{
	public class Synapse: IBrainMatter
	{
		public string Name;
		// Neuron methods operate directly on these.
		internal Neuron from;
		internal Neuron to;
		Brain brain;
		int _cycle;
		int result;
		int _gain;  // scaled int 1024 ( >> 10 )

		public float gain
		{
			set { _gain = (int)(( 1 << 10 ) * value); }
			get { return ((float)_gain) / 1024.0F; }
		}

		public int cycle
		{
			set
			{
				if( _cycle != value )
				{
					_cycle = value;
					xperdex.classes.Log.log( "Synapse(" + Name + ") to update" );
					result = ( ( from * _gain ) >> 10 );
				}			 
			}
			get
			{
				return _cycle;
			}
		}

		public Synapse()
		{
			_gain = 1024;
		}


		public int this[Neuron n]
		{
			get
			{
				if( n.Equals( to ) )
				{
					cycle = n.cycle;
					return result;
				}
				return 0;
			}
		}

		public static Synapse operator +( Synapse s, Neuron n )
		{
			if( ( s.from == null ) && ( n.IndexOf( s ) < 0 ) )
			{
				s.from = n;
				n.Add( s );
				return s;
			}
			return null;
		}


		public static implicit operator int( Synapse n )
		{
			return n.result;
		}

		public Neuron From
		{
			set {
				if( from != null )
					from.Remove( this );
				if( value != null )
					value.Add( this );

				from = value;
			}

			get { return from; }
		}

		public Neuron To
		{
			set
			{
				if( to != null )
				{
					to.Remove( this );
				}
				if( value != null )
					value.Add( this );
				to = value;
			}

			get { return to; }
		}


		void Init( Brain b, Synapse _default )
		{
			brain = b;
			if( _default == null )
			{
				_gain = 1024;
			}
			else
			{
				Synapse s = _default;
				_gain = s._gain;
			}
			this.cycle = 0;
		}

		#region IBrainMatter Members

		void IBrainMatter.Clear()
		{
			_gain = 1 << 10;
		}

		void IBrainMatter.Init( Brain b )
		{
			Init( b, b.DefaultSynapse );
		}

		#endregion
	}
}
