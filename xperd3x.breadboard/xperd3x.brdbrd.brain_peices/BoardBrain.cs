using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using xperdex.brain.core;
using System.Drawing;

namespace xperd3x.breadboard.brain.peices
{






	class BoardBrain: Peice
	{
		// this is a context of the brain to be editing.
		// a board is a visiualization of but a single brain, and
		// at that.... yeah one brain.
		Brain brain;

		BoardBrain()
		{
			brain = new xperdex.brain.core.Brain();
		}

		public override System.Drawing.Size Size
		{
			get { return new Size( 32, 32 ); }
		}

		

	}
}
