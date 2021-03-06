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
	
	
	public class NxInterface : DoxyBindObject
	{
		
		internal NxInterface(IntPtr ptr) : 
				base(ptr)
		{
		}
		
		/// <summary></summary>
		public virtual int getVersionNumber()
		{
			if (doSetFunctionPointers)
			{
				throw new System.NotSupportedException("Cannot call abstract base member");
			}
			return NxInterface_getVersionNumber_INVOKE(ClassPointer, doSetFunctionPointers);
		}
		
		private int getVersionNumber_virtual()
		{
			return getVersionNumber();
		}
		
		delegate int getVersionNumber_0_delegate();
		
		
		
		
		
		
		private getVersionNumber_0_delegate getVersionNumber_0_delegatefield;
		
		/// <summary></summary>
		public virtual NxInterfaceType getInterfaceType()
		{
			if (doSetFunctionPointers)
			{
				throw new System.NotSupportedException("Cannot call abstract base member");
			}
			return NxInterface_getInterfaceType_INVOKE(ClassPointer, doSetFunctionPointers);
		}
		
		private NxInterfaceType getInterfaceType_virtual()
		{
			return getInterfaceType();
		}
		
		delegate NxInterfaceType getInterfaceType_1_delegate();
		
		
		
		
		
		
		private getInterfaceType_1_delegate getInterfaceType_1_delegatefield;
		
		#region Imports
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="NxInterface_getVersionNumber")]
        private extern static System.Int32 NxInterface_getVersionNumber_INVOKE (HandleRef classPointer, System.Boolean call_explicit);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="NxInterface_getInterfaceType")]
        private extern static NxInterfaceType NxInterface_getInterfaceType_INVOKE (HandleRef classPointer, System.Boolean call_explicit);

		#endregion
		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="new_NxInterface")]
        private extern static IntPtr new_NxInterface_INVOKE (bool do_override);

		
		protected NxInterface() : 
				base(IntPtr.Zero)
		{
			GC.ReRegisterForFinalize(this);
			if ((GetType() != typeof(NxInterface)))
			{
				doSetFunctionPointers = true;
				SetPointer(new_NxInterface_INVOKE(doSetFunctionPointers));
				System.IntPtr[] pointers = CreateFunctionPointers().ToArray();
				set_pointers_INVOKE(ClassPointer, pointers, pointers.Length);
			}
			else
			{
				SetPointer(new_NxInterface_INVOKE(doSetFunctionPointers));
			}
		}
		
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
		
		public static NxInterface GetClass(IntPtr ptr)
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
					return ((NxInterface)(obj.Target));
				}
			}
			return new NxInterface(ptr);
		}
		
		protected override System.Collections.Generic.List<System.IntPtr> CreateFunctionPointers()
		{
			System.Collections.Generic.List<System.IntPtr> list = base.CreateFunctionPointers();
			getVersionNumber_0_delegatefield = new getVersionNumber_0_delegate(this.getVersionNumber_virtual);
			list.Add(Marshal.GetFunctionPointerForDelegate(getVersionNumber_0_delegatefield));
			getInterfaceType_1_delegatefield = new getInterfaceType_1_delegate(this.getInterfaceType_virtual);
			list.Add(Marshal.GetFunctionPointerForDelegate(getInterfaceType_1_delegatefield));
			return list;
		}
	}
}
