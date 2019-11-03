namespace xperdex.layout.board
{
	/// <summary>
	/// iPeice interface is a method to allow objects to be attached
	/// as layable peices on the board.
	/// </summary>
	public interface iPeice
	{
		void Destroy( object o );
		bool AllowConnectBegin( object o );
		bool AllowConnectEnd( object o );
#if asfasdf
		public Cell GetCell( int x, int y );
		public Cell GetCell( int x, int y, int scale );
		public int Rows { get; }
		public int Cols { get; }
		public int HotspotX { get; }
		public int HotspotY { get; }
#endif
	}
}
