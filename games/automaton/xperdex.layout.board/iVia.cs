using System.Drawing;

namespace xperdex.layout.board
{
	interface iVia : iPeice
	{
		Image GetViaEnd( int direction, int scale );
	}
}
