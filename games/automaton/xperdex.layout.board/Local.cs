namespace xperdex.layout.board
{
	static class Local
	{
		internal struct DirDelta
		{
			public int x;
			public int y;
			internal DirDelta( int x, int y )
			{
				this.x = x;
				this.y = y;
			}
		}

		internal static readonly DirDelta[] DirDeltaMap = { new DirDelta( 0, -1 ),
									new DirDelta(  1, -1 ), 
								     new DirDelta(  1, 0 ), 
							        new DirDelta(  1, 1 ), 
								     new DirDelta(  0, 1 ) , 
									new DirDelta(  -1, 1 ),  
								     new DirDelta(  -1, 0 ),
								     new DirDelta( -1, -1 ) 
		};

		internal enum Dirs
		{
			Nowhere = -1,
			Up,
			UpRight,
			Right,
			DownRight,
			Down,
			DownLeft,
			Left,
			UpLeft,
			NotNear = 9
		}



									
	}
}
