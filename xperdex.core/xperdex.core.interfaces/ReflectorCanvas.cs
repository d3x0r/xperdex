
namespace xperdex.core.interfaces
{
	/// <summary>
	/// This is a canvas.  This will be created seperate from the control that is the canvas, 
	/// then the OnCreate of the IReflectorCreate will be called with the canvas control object.
	/// </summary>
	public interface IReflectorCanvas: IReflectorCreate
	{
	}
}
