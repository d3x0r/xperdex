using System;
using System.Collections.Generic;
using System.Text;

namespace xperdex.brain.core
{
	internal class SynapsePool: GenericSet<Synapse>
	{
		Brain _brain;

		public SynapsePool( Brain brain )
			: base( 256 )
		{
			_brain = brain;
		}

		public static implicit operator Synapse( SynapsePool pool )
		{
			Synapse n = pool.Get();
			IBrainMatter matter = (IBrainMatter)n;
			matter.Init( pool._brain );
			return n;
		}

	}
}
