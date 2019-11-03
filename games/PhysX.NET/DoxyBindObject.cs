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
	
	
	public class DoxyBindObject : IDisposable
	{
		
		internal HandleRef ClassPointer;
		
		internal DoxyBindObject(IntPtr ptr)
		{
			SetPointer(ptr);
			GC.SuppressFinalize(this);
		}
		
~DoxyBindObject() { Dispose(); }
		
		public virtual void Dispose()
		{
			delete_object_INVOKE(ClassPointer);
			GC.SuppressFinalize(this);
		}
		
		internal const string NATIVE_LIBRARY = "PhysX.dll";
		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="delete_object")]
        private extern static void delete_object_INVOKE (HandleRef ptr);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="set_pointers")]
        internal extern static void set_pointers_INVOKE (HandleRef ptr, System.IntPtr[] pointers, System.Int32 length);

		
		internal bool doSetFunctionPointers;
		
		protected virtual System.Collections.Generic.List<System.IntPtr> CreateFunctionPointers()
		{
			return new System.Collections.Generic.List<System.IntPtr>();
		}
		
		protected virtual void SetPointer(IntPtr ptr)
		{
			ClassPointer = new HandleRef(this, ptr);
		}
		
		internal static HandleRef NullRef = new HandleRef(null, IntPtr.Zero);
	}
}
