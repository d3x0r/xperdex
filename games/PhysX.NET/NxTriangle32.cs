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
	
	
	public class NxTriangle32 : DoxyBindObject
	{
		
		internal NxTriangle32(IntPtr ptr) : 
				base(ptr)
		{
		}
		
		/// <summary></summary>
		public uint[] v
		{
			get
			{
				uint[] value = new uint[3];
				get_NxTriangle32_v_INVOKE(ClassPointer, value);
				return value;
			}
			set
			{
				set_NxTriangle32_v_INVOKE(ClassPointer, value);
			}
		}
		
		/// <summary></summary>
		public NxTriangle32() : 
				base(new_NxTriangle32_INVOKE(false))
		{
			GC.ReRegisterForFinalize(this);
		}
		
		/// <summary></summary>
		public NxTriangle32(uint a, uint b, uint c) : 
				base(new_NxTriangle32_1_INVOKE(false, a, b, c))
		{
			GC.ReRegisterForFinalize(this);
		}
		
		#region Imports
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="set_NxTriangle32_v")]
        private extern static void set_NxTriangle32_v_INVOKE (HandleRef classPointer, [MarshalAs(UnmanagedType.LPArray, SizeConst=3)] System.UInt32[] newvalue);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="get_NxTriangle32_v")]
        private extern static void get_NxTriangle32_v_INVOKE (HandleRef classPointer, [Out()] [MarshalAs(UnmanagedType.LPArray, SizeConst=3)] System.UInt32[] value);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="new_NxTriangle32")]
        private extern static IntPtr new_NxTriangle32_INVOKE (System.Boolean do_override);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="new_NxTriangle32_1")]
        private extern static IntPtr new_NxTriangle32_1_INVOKE (System.Boolean do_override, System.UInt32 a, System.UInt32 b, System.UInt32 c);

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
		
		public static NxTriangle32 GetClass(IntPtr ptr)
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
					return ((NxTriangle32)(obj.Target));
				}
			}
			return new NxTriangle32(ptr);
		}
		
		protected override System.Collections.Generic.List<System.IntPtr> CreateFunctionPointers()
		{
			System.Collections.Generic.List<System.IntPtr> list = base.CreateFunctionPointers();
			return list;
		}
	}
}
