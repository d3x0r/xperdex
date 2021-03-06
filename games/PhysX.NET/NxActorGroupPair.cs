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
	
	
	public class NxActorGroupPair : DoxyBindObject
	{
		
		internal NxActorGroupPair(IntPtr ptr) : 
				base(ptr)
		{
		}
		
		/// <summary></summary>
		public ushort group0
		{
			get
			{
				ushort value = get_NxActorGroupPair_group0_INVOKE(ClassPointer);
				return value;
			}
			set
			{
				set_NxActorGroupPair_group0_INVOKE(ClassPointer, value);
			}
		}
		
		/// <summary></summary>
		public ushort group1
		{
			get
			{
				ushort value = get_NxActorGroupPair_group1_INVOKE(ClassPointer);
				return value;
			}
			set
			{
				set_NxActorGroupPair_group1_INVOKE(ClassPointer, value);
			}
		}
		
		/// <summary></summary>
		public uint flags
		{
			get
			{
				uint value = get_NxActorGroupPair_flags_INVOKE(ClassPointer);
				return value;
			}
			set
			{
				set_NxActorGroupPair_flags_INVOKE(ClassPointer, value);
			}
		}
		
		#region Imports
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="set_NxActorGroupPair_group0")]
        private extern static void set_NxActorGroupPair_group0_INVOKE (HandleRef classPointer, System.UInt16 newvalue);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="get_NxActorGroupPair_group0")]
        private extern static System.UInt16 get_NxActorGroupPair_group0_INVOKE (HandleRef classPointer);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="set_NxActorGroupPair_group1")]
        private extern static void set_NxActorGroupPair_group1_INVOKE (HandleRef classPointer, System.UInt16 newvalue);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="get_NxActorGroupPair_group1")]
        private extern static System.UInt16 get_NxActorGroupPair_group1_INVOKE (HandleRef classPointer);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="set_NxActorGroupPair_flags")]
        private extern static void set_NxActorGroupPair_flags_INVOKE (HandleRef classPointer, System.UInt32 newvalue);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="get_NxActorGroupPair_flags")]
        private extern static System.UInt32 get_NxActorGroupPair_flags_INVOKE (HandleRef classPointer);

		#endregion
		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="new_NxActorGroupPair")]
        private extern static IntPtr new_NxActorGroupPair_INVOKE (bool do_override);

		
		public NxActorGroupPair() : 
				base(new_NxActorGroupPair_INVOKE(false))
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
		
		public static NxActorGroupPair GetClass(IntPtr ptr)
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
					return ((NxActorGroupPair)(obj.Target));
				}
			}
			return new NxActorGroupPair(ptr);
		}
		
		protected override System.Collections.Generic.List<System.IntPtr> CreateFunctionPointers()
		{
			System.Collections.Generic.List<System.IntPtr> list = base.CreateFunctionPointers();
			return list;
		}
	}
}
