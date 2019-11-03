

using xperd3x.breadboard;

namespace xperdex.layout.board
{
	public class ViaRepresentation : PeiceRepresentation
	{
		Board board;

		Cell generic_cell = new Cell();

		internal Cell GetViaEnd( Local.Dirs direction, int scale )
		{
		  // to direction...
			switch( direction )
			{
			case Local.Dirs.UpLeft:
				return GetCell( 2, 2, scale );
			case Local.Dirs.Up:
				return GetCell( 3, 2, scale );
			case Local.Dirs.UpRight:
				return GetCell( 4, 2, scale );
			case Local.Dirs.Right:
				return GetCell( 4, 3, scale );
			case Local.Dirs.DownRight:
				return GetCell( 4, 4, scale );
			case Local.Dirs.Down:
				return GetCell( 3, 4, scale );
			case Local.Dirs.DownLeft:
				return GetCell( 2, 4, scale );
			case Local.Dirs.Left:
				return GetCell( 2, 3, scale );
			case Local.Dirs.Nowhere:
				return GetCell( 3, 3, scale );
			}
			return null;
		}

		//--------------------------------------------------------------

		internal bool GetViaFill1( ref int xofs, ref int yofs, Local.Dirs direction, int scale, out Cell result )
		{
			result = generic_cell;
			(xofs) = 0;
			(yofs) = 0;
			switch( direction )
			{
			case Local.Dirs.UpLeft:
				(xofs) = 0;
				(yofs) = -1;
				//result = GetCell( 5, 0, scale );
				return true;//
			case Local.Dirs.DownRight:
				(xofs) = 1;
				(yofs) = 0;
				return true;//GetCell( 5, 0, scale );
			case Local.Dirs.UpRight:
				(xofs) = 0;
				(yofs) = -1;
				return true;//GetCell( 1, 0, scale );
			case Local.Dirs.DownLeft:
				(xofs) = -1;
				(yofs) = 0;
				return true;//GetCell( 1, 0, scale );
			}
			return false;
		}
		// the diagonal fills are ... well position needs to
	   // be accounted for ...

		//--------------------------------------------------------------

		internal bool GetViaFill2( ref int xofs, ref int yofs, Local.Dirs direction, int scale, out Cell result )
		{
			// via vills are done when placing a cell that exits in 'direction'
			// the xofs should be applied to the x,y of the last cell - the one that
			// is exiting in 'direction'
			// layers will consider fills as temporary and auto trash them when unwinding.
			// Any cell may call GetViaFill, GetViaFill2 in exit direction,
			// a direction which does not require a fill will result in NULL
			// otherwise the information from this should be saved, and somewhat attached
		  // to the peice just layed.
			result = generic_cell;
			switch( direction )
			{
			case Local.Dirs.UpLeft:
				(xofs) = -1;
				(yofs) = 0;
				return true;//GetCell( 4, 1, scale );
			case Local.Dirs.DownRight:
				(xofs) = 0;
				(yofs) = 1;
				return true;//GetCell( 4, 1, scale );
			case Local.Dirs.UpRight:
				(xofs) = 1;
				(yofs) = 0;
				return true;//GetCell( 2, 1, scale );
			case Local.Dirs.DownLeft:
				(xofs) = 0;
				(yofs) = 1;
				return true;//GetCell( 2, 1, scale );
			}
			return false;
		}

		//--------------------------------------------------------------

		internal Cell GetViaStart( Local.Dirs direction, int scale )
		{
		  // from direction...
			switch( direction )
			{
			case Local.Dirs.UpLeft:
				return GetCell( 6, 6, scale );
			case Local.Dirs.Up:
				return GetCell( 3, 5, scale );
			case Local.Dirs.UpRight:
				return GetCell( 0, 6, scale );
			case Local.Dirs.Right:
				return GetCell( 1, 3, scale );
			case Local.Dirs.DownRight:
				return GetCell( 0, 0, scale );
			case Local.Dirs.Down:
				return GetCell( 3, 1, scale );
			case Local.Dirs.DownLeft:
				return GetCell( 6, 0, scale );
			case Local.Dirs.Left:
				return GetCell( 5, 3, scale );
			case Local.Dirs.Nowhere:
				return GetCell( 2, 2, scale );
			}
			return null;
		}

		//--------------------------------------------------------------

		internal bool GetViaFromTo( Local.Dirs from, Local.Dirs to, int scale, out Cell result )
		{
			result = generic_cell;
			if( from == Local.Dirs.Nowhere )
			{
				result = GetViaStart( to, scale );
				return true;// 
			}
			else if( to == Local.Dirs.Nowhere )
			{
				result = GetViaEnd( from, scale );
				return true;//
			}
			switch( (int)from | ( (int)to << 4 ) )
			{
			case (int)Local.Dirs.Left|((int)Local.Dirs.UpRight<<4):
			case (int)Local.Dirs.UpRight|((int)Local.Dirs.Left<<4):
				result = GetCell( 4, 6, scale );
				return true;//
			case (int)Local.Dirs.Left|((int)Local.Dirs.Right<<4):
			case (int)Local.Dirs.Right|((int)Local.Dirs.Left<<4):
				result = GetCell( 3, 0, scale );
				return true;//
			case (int)Local.Dirs.UpLeft|((int)Local.Dirs.Right<<4):
			case (int)Local.Dirs.Right|((int)Local.Dirs.UpLeft<<4):
				result = GetCell( 2, 6, scale );
				return true;//
			case (int)Local.Dirs.Left|((int)Local.Dirs.DownRight<<4):
			case (int)Local.Dirs.DownRight|((int)Local.Dirs.Left<<4):
				result = GetCell( 4, 0, scale );
				return true;//
			case (int)Local.Dirs.UpLeft|((int)Local.Dirs.DownRight<<4):
			case (int)Local.Dirs.DownRight|((int)Local.Dirs.UpLeft<<4):
				result = GetCell( 5, 1, scale );
				return true;//
			case (int)Local.Dirs.Up|((int)Local.Dirs.DownRight<<4):
			case (int)Local.Dirs.DownRight|((int)Local.Dirs.Up<<4):
				result = GetCell( 0, 4, scale );
				return true;//
			case (int)Local.Dirs.UpLeft|((int)Local.Dirs.Down<<4):
			case (int)Local.Dirs.Down|((int)Local.Dirs.UpLeft<<4):
				result = GetCell( 6, 2, scale );
				return true;//
			case (int)Local.Dirs.Up|((int)Local.Dirs.Down<<4):
			case (int)Local.Dirs.Down|((int)Local.Dirs.Up<<4):
				result = GetCell( 0, 3, scale );
				return true;//
			case (int)Local.Dirs.UpRight|((int)Local.Dirs.Down<<4):
			case (int)Local.Dirs.Down|((int)Local.Dirs.UpRight<<4):
				result = GetCell( 0, 2, scale );
				return true;//
			case (int)Local.Dirs.Up|((int)Local.Dirs.DownLeft<<4):
			case (int)Local.Dirs.DownLeft|((int)Local.Dirs.Up<<4):
				result = GetCell( 6, 4, scale );
				return true;//
			case (int)Local.Dirs.UpRight|((int)Local.Dirs.DownLeft<<4):
			case (int)Local.Dirs.DownLeft|((int)Local.Dirs.UpRight<<4):
				result = GetCell( 1, 1, scale );
				return true;//
			case (int)Local.Dirs.Right|((int)Local.Dirs.DownLeft<<4):
			case (int)Local.Dirs.DownLeft|((int)Local.Dirs.Right<<4):
				result = GetCell( 2, 0, scale );
				return true;//
			}
			return false;
		}

		public virtual void EndUnlink( object instance )
		{
			
		}

	}
}
