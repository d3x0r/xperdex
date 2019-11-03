using System;
using System.Collections.Generic;
using System.Text;

namespace particle_boy.Body
{
	public class Limb
	{
		internal List<Connection> joints;
		/// <summary>
		/// this joint goes up the hierarchy... other joints are anchored to this.
		/// </summary>
		protected Connection trunk_joint;
		/// <summary>
		/// this is the point that the trunk is anchored to this limb...
		/// </summary>
		protected Vector3 anchor_point;
		/// <summary>
		/// this is the 'roll' orientation of the limb extending from the anchor_point.
		/// </summary>
		protected double rotation;

		protected double from;
		protected double to;

		public Limb( double length )
		{
			to = length;
		}

#if need_destruction
		~Limb()
		{
			foreach( Connection c in joints )
				c.Dispose();
		}
#endif
	}
}
