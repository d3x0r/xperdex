using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using xperd3x.breadboard;

namespace xperd3x.breadboard.brain.peices
{
	[BoardAttributes.RequiredParent( typeof( BoardBrain ))]


	public class BoardNeuron : Peice
	{
		public BoardNeuron()
		{
			// we'll need a creation dialog to init?
			OnContextClick += new ContextClick( BoardNeuron_OnContextClick );
		}

		int BoardNeuron_OnContextClick( int x, int y )
		{
			return 0;			
		}

		public override System.Drawing.Size Size
		{
			get { return new System.Drawing.Size( 3, 3 ); }
		}

		 
	}
}
