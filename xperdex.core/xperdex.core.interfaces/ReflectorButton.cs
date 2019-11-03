using System;

namespace xperdex.core.interfaces
{
	/// <summary>
	/// Simplest object can just be a button event, these button events can be used in macro buttons or as buttons themselves.
	/// </summary>
	public interface IReflectorButton
	{
		/// return false to end further processing... may be used in a MACRO
		bool OnClick();
	}


}
