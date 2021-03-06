//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.3053
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Copyright (c) 2007-2008
// Available under the terms of the
// Eclipse Public License with GPL exception
// See enclosed license file for more information
namespace PhysX.NET
{
	using System;
	using System.Runtime.InteropServices;
	
	
	public class NxSweepCache : DoxyBindObject
	{
		
		internal NxSweepCache(IntPtr ptr) : 
				base(ptr)
		{
		}
		
		/// <summary></summary>
		protected NxSweepCache() : 
				base(IntPtr.Zero)
		{
			if ((GetType() != typeof(NxSweepCache)))
			{
				doSetFunctionPointers = true;
				SetPointer(new_NxSweepCache_INVOKE(doSetFunctionPointers));
				System.IntPtr[] pointers = CreateFunctionPointers().ToArray();
				set_pointers_INVOKE(ClassPointer, pointers, pointers.Length);
			}
			else
			{
				SetPointer(new_NxSweepCache_INVOKE(doSetFunctionPointers));
			}
			GC.ReRegisterForFinalize(this);
		}
		
		/// <summary></summary>
		public virtual void setVolume(NxBox box)
		{
			if (doSetFunctionPointers)
			{
				throw new System.NotSupportedException("Cannot call abstract base member");
			}
			NxSweepCache_setVolume_INVOKE(ClassPointer, doSetFunctionPointers, (box!=null ? box.ClassPointer : NullRef));
		}
		
		private void setVolume_virtual(IntPtr box)
		{
			setVolume(NxBox.GetClass(box));
		}
		
		delegate void setVolume_0_delegate(IntPtr box);
		
		
		
		
		
		
		private setVolume_0_delegate setVolume_0_delegatefield;
		
		#region Imports
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="new_NxSweepCache")]
        private extern static IntPtr new_NxSweepCache_INVOKE (System.Boolean do_override);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="NxSweepCache_setVolume")]
        private extern static void NxSweepCache_setVolume_INVOKE (HandleRef classPointer, System.Boolean call_explicit, HandleRef box);

		#endregion
		
		private static System.Collections.Generic.Dictionary<System.IntPtr, System.WeakReference> database = new System.Collections.Generic.Dictionary<System.IntPtr, System.WeakReference>();
		
		protected override void SetPointer(IntPtr ptr)
		{
			base.SetPointer(ptr);
			database[ptr] = new WeakReference(this);
		}
		
		public override void Dispose()
		{
			database.Remove(ClassPointer.Handle);
			base.Dispose();
		}
		
		public static NxSweepCache GetClass(IntPtr ptr)
		{
			if ((ptr == IntPtr.Zero))
			{
				return null;
			}
			System.WeakReference obj;
			if (database.TryGetValue(ptr, out obj))
			{
				if (obj.IsAlive)
				{
					return ((NxSweepCache)(obj.Target));
				}
			}
			return new NxSweepCache(ptr);
		}
		
		protected override System.Collections.Generic.List<System.IntPtr> CreateFunctionPointers()
		{
			System.Collections.Generic.List<System.IntPtr> list = base.CreateFunctionPointers();
			setVolume_0_delegatefield = new setVolume_0_delegate(this.setVolume_virtual);
			list.Add(Marshal.GetFunctionPointerForDelegate(setVolume_0_delegatefield));
			return list;
		}
	}
}
