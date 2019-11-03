
namespace xperdex.core.interfaces
{
	public interface IReflectorDropFileTarget
	{
		/// <summary>
		/// Return true if accept the filename... Process stops handing it to others
		/// </summary>
		/// <param name="sender">In theory this is the canvas</param>
		/// <param name="filename">This is a filename that was dropped</param>
		/// <returns>True (processed, stop dropping) false (ignored, continue with others)</returns>
		bool Drop( object sender, string filename, int X, int Y );
	}
	// this is for a global interface - canvas hook
	// the other is a control oriented hook for accepting drops on controls.
	// otherwise I don't know which istances to create.
	public interface IReflectorPluginDropFileTarget
	{
		/// <summary>
		/// Return true if accept the filename... Process stops handing it to others
		/// </summary>
		/// <param name="sender">In theory this is the canvas</param>
		/// <param name="filename">This is a filename that was dropped</param>
		/// <returns>True (processed, stop dropping) false (ignored, continue with others)</returns>
		bool Drop( object sender, string filename, int X, int Y );
	}
}
