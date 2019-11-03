
namespace xperdex.core.interfaces
{

	/// <summary>
	/// Security interface for standard base class buttons and their related extensions
	/// Implements IReflectorPerisistance also, because, if there is a configuration
	/// to apply security, it would be needed to retain this setting between launches.
	/// </summary>
	public interface IReflectorSecurity
	{
		// for properties, please implement reflector persistance
		bool Open(); 
		// close the open security context
		void Close();
		// return allow/deny (true/false)
		// Some interfaces may imply an Open with Test
		// Some interfaces may force Open before Test
		bool Test();
	}
}
