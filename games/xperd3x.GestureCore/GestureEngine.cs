using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace xperd3x.GestureCore
{
	class GestureEngine
	{
		DateTime then;
		float[,] position;
		float[,] velocity;
		float[,] acceleration;

		public float[,] Velocity
		{
			get
			{
				return velocity.data;
			}
		}

		public void Add( float[,] data )
		{
		
			float[,] newvel;
			float[,] newacc;
			// current velocity is ... old position - data;
			// this actually results with acc?
			newvel = ControlMatrix.Diff( data, position );

			newacc = ControlMatrix.Diff( newvel, velocity );
			velocity = newvel;
			acceleration = newacc;
			position = data;
			then = DateTime.Now;
			ControlMatrix.Scale( data, 0.09 );
		}



	}
}
