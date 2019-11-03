using System.Xml;
using System.Xml.XPath;

namespace xperdex.core.interfaces
{
	/// <summary>
	/// This is used to define hooks to save/load and configure.
	/// If this is used also in a class which has IReflectorPlugin, then it will be added to 'more properties'...
	/// A Control should never be IReflectorPlugin, since a Plugin instance is created once on load.
	/// </summary>
	public interface IReflectorPersistance
	{
		bool Load( XPathNavigator r ); // on load common
		void Save( XmlWriter w ); // on save common (global)
		void Properties(); // global properties
	}
}
