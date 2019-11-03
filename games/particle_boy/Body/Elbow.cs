using System;
using System.Collections.Generic;
using System.Text;

namespace particle_boy.Body
{
	public class Elbow: Connection
	{
		public Elbow( Limb root, Vector3 anchor_on_root_at, Vector3 anchor_orientation, Limb limb )
			: base( root, anchor_on_root_at, anchor_orientation, limb )
		{
			// setup extents of the joint too.
		}


	}
}
