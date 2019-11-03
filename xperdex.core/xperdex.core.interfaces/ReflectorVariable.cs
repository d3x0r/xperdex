using System;

namespace xperdex.core.interfaces
{
	/// <summary>
	/// Interface to enable resulting information as variable content.
	/// </summary>
	public interface IReflectorVariable
	{
		String Name { get; }
		String Text { get; set; }
	}
	public interface IReflectorVariableArray
	{
		String Name { get; }
		String this[int number] { get; }
		int Count{ get; }
	}
	public interface IReflectorVariableNamedArray
	{
		String Name { get; }
		String this[string index] { get; }
		String[] Members{ get; }
	}
}
