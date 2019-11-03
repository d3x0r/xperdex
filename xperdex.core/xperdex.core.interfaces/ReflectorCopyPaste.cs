using System;

namespace xperdex.core.interfaces
{
	public interface IReflectorCopyPaste
	{
		void OnClone(); // when the control is selected to clone (copy) 
		void OnPaste( Object o ); // when the control is created from the copy(clone)
	}
}
