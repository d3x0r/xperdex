using System.Windows.Forms;

namespace xperdex.core.interfaces
{
	public interface IReflectorWidget
	{
		bool CanShow { get; }
		void OnPaint( PaintEventArgs e );
		void OnKeyPress( KeyPressEventArgs e );
		void OnMouse( MouseEventArgs e );
	}
}
