using System;
using System.Collections.Generic;
using System.Text;

namespace particle_boy.Body
{
	class BasicBiped : Limb
	{
		Limb torso;
		Limb left_arm;
		Limb right_arm;
		Limb left_leg;
		Limb right_leg;

		BasicBiped(): base( 3) 
		{
			left_arm = new Limb( 1.7 );
			Limb forearm = new Limb( 1.6 );
			// there has to be a twist dimension also.
			new Shoulder( this
				, new Vector3( 0, 0, 0 )
				, new Vector3( 0, 90, 0 )  // so this, by default, extends out at the rolll, no offset.
				, left_arm );
			new Elbow( left_arm
				, new Vector3( 1.6, 0, 0 )
				, new Vector3( 0, 0, 0 )
				, forearm );


			right_arm = new Limb( 1.7 );
			forearm = new Limb( 1.6 );
			// there has to be a twist dimension also.
			new Shoulder( this
				, new Vector3( 0, 0, 0 )
				, new Vector3( 0, 0, 180 )  // so this, by default, extends out at the rolll, no offset.
				, right_arm );
			new Elbow( right_arm
				, new Vector3( 1.6, 0, 0 )
				, new Vector3( 0, 0, 0 )
				, forearm );


			left_leg = new Limb( 2.2 );
			forearm = new Limb( 2.0 );
			// there has to be a twist dimension also.
			new Shoulder( this
				, new Vector3( 3.0, 0, 0 )
				, new Vector3( 0, 90, 0 )  // so this, by default, extends out at the rolll, no offset.
				, left_leg );
			new Elbow( left_leg
				, new Vector3( 1.6, 0, 0 )
				, new Vector3( 0, 0, 0 )
				, forearm );


			right_leg = new Limb( 2.2 );
			forearm = new Limb( 2.0 );
			// there has to be a twist dimension also.
			new Shoulder( this
				, new Vector3( 3.0, 0, 0 )
				, new Vector3( 0, 0, 180 )  // so this, by default, extends out at the rolll, no offset.
				, right_leg );
			new Elbow( right_leg
				, new Vector3( 1.6, 0, 0 )
				, new Vector3( 0, 0, 0 )
				, forearm );


		}

	}
}
