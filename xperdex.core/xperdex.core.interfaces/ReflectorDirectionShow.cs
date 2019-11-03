
namespace xperdex.core.interfaces
{
	/// <summary>
	/// Used to receive stage direction regarding reveal/hide/page change events.
	/// </summary>
	public interface IReflectorDirectionShow
	{
		void PageChanged();
		void Shown();
		void Hidden();
	}
}
