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
	
	
	public class NxDebugLine : DoxyBindObject
	{
		
		internal NxDebugLine(IntPtr ptr) : 
				base(ptr)
		{
		}
		
		/// <summary></summary>
		public NxVec3 p0
		{
			get
			{
				NxVec3 value = get_NxDebugLine_p0_INVOKE(ClassPointer);
				return value;
			}
			set
			{
				set_NxDebugLine_p0_INVOKE(ClassPointer, value);
			}
		}
		
		/// <summary></summary>
		public NxVec3 p1
		{
			get
			{
				NxVec3 value = get_NxDebugLine_p1_INVOKE(ClassPointer);
				return value;
			}
			set
			{
				set_NxDebugLine_p1_INVOKE(ClassPointer, value);
			}
		}
		
		/// <summary></summary>
		public uint color
		{
			get
			{
				uint value = get_NxDebugLine_color_INVOKE(ClassPointer);
				return value;
			}
			set
			{
				set_NxDebugLine_color_INVOKE(ClassPointer, value);
			}
		}
		
		#region Imports
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="set_NxDebugLine_p0")]
        private extern static void set_NxDebugLine_p0_INVOKE (HandleRef classPointer, NxVec3 newvalue);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="get_NxDebugLine_p0")]
        private extern static NxVec3 get_NxDebugLine_p0_INVOKE (HandleRef classPointer);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="set_NxDebugLine_p1")]
        private extern static void set_NxDebugLine_p1_INVOKE (HandleRef classPointer, NxVec3 newvalue);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="get_NxDebugLine_p1")]
        private extern static NxVec3 get_NxDebugLine_p1_INVOKE (HandleRef classPointer);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="set_NxDebugLine_color")]
        private extern static void set_NxDebugLine_color_INVOKE (HandleRef classPointer, System.UInt32 newvalue);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="get_NxDebugLine_color")]
        private extern static System.UInt32 get_NxDebugLine_color_INVOKE (HandleRef classPointer);

		#endregion
		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="new_NxDebugLine")]
        private extern static IntPtr new_NxDebugLine_INVOKE (bool do_override);

		
		public NxDebugLine() : 
				base(new_NxDebugLine_INVOKE(false))
		{
			GC.ReRegisterForFinalize(this);
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
		
		public static NxDebugLine GetClass(IntPtr ptr)
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
					return ((NxDebugLine)(obj.Target));
				}
			}
			return new NxDebugLine(ptr);
		}
		
		protected override System.Collections.Generic.List<System.IntPtr> CreateFunctionPointers()
		{
			System.Collections.Generic.List<System.IntPtr> list = base.CreateFunctionPointers();
			return list;
		}
	}
}
