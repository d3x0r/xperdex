using System;
using System.Collections.Generic;
using System.Text;

namespace particle_boy.Body
{
	public class Connection
	{
		/// <summary>
		/// this is the limb at the anchor side.
		/// </summary>
		protected Limb anchor;
		/// <summary>
		/// this point is the point the joint exists at relative to the limb's origin.
		/// </summary>
		protected Vector3 anchor_point;
		/// <summary>
		/// this is the direction relative to the root limb's direction and roll ....
		/// </summary>
		protected Vector3 anchor_orientation;

		/// <summary>
		/// this is the limb that is free to move from the connection the free limb's location on the limb is on the attached limb.
		/// </summary>
		protected Limb free;


		public Connection( Limb root, Vector3 anchor_on_root_at, Vector3 anchor_orientation, Limb limb )
		{
			anchor = root;
			root.joints.Add( this );
			free = limb;
			anchor_point = anchor_on_root_at;
			this.anchor_orientation = anchor_orientation;
		}

#if need_destruction
		public void Dispose( )
		{
			// remove references to the limbs... so the limbs
			// can remove references to joints and we can clean this thing.
			anchor = null;
			free = null;
		}
#endif
	}
}
