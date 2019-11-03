using System.Data;

namespace BingoGameCore4.Controls.Patterns
{
	public class CurrentPatternScroller : ScollingPattern
	{
		public DataRow Current
		{
			set
			{
                Pattern = new Pattern( value, null );
			}
		}
		public CurrentPatternScroller()
		{
			//ControlList.patttern_scroll_controls.Add( this );
		}
		~CurrentPatternScroller()
		{
			//ControlList.patttern_scroll_controls.Remove( this );
		}
	}
}
