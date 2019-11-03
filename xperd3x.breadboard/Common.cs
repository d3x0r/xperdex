using System;
using System.Collections.Generic;
using System.Text;

namespace xperd3x.breadboard
{
	public class Common
	{
		public enum Direction
		{

			NOWHERE = -1,
			UP = 0,
			UP_RIGHT = 1,
			RIGHT = 2,
			DOWN_RIGHT = 3,
			DOWN = 4,
			DOWN_LEFT = 5,
			LEFT = 6,
			UP_LEFT = 7
		}


        public struct DirDelta
		{
			int x, y;
            public DirDelta(int _x, int _y)
            {
                x = _x;
                y = _y;
            }
		};

		public static DirDelta[] DirDeltaMap;
		static Common()
		{
			DirDeltaMap = new DirDelta[8] { new DirDelta( 0, -1 ),
                             new DirDelta(  1, -1 ), 
								     new DirDelta(  1, 0 ), 
							        new DirDelta(  1, 1 ), 
								     new DirDelta(  0, 1 ) , 
							        new DirDelta(  -1, 1 ),  
								     new DirDelta(  -1, 0 ),
								     new DirDelta(  -1, -1 ) 
									};
		}

	}
}
