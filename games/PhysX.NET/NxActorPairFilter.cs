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
	
	
	public class NxActorPairFilter : DoxyBindObject
	{
		
		internal NxActorPairFilter(IntPtr ptr) : 
				base(ptr)
		{
		}
		
		/// <summary>Pair of actors that are candidates for contact generation. </summary>
		public DoxyBindArray<NxActor> actor
		{
			get
			{
				IntPtr[] value = new IntPtr[2];
				get_NxActorPairFilter_actor_INVOKE(ClassPointer, value);
				return value;
			}
			set
			{
				set_NxActorPairFilter_actor_INVOKE(ClassPointer, value);
			}
		}
		
		/// <summary>Set to true in order to filter out this pair from contact generation. </summary>
		public bool filtered
		{
			get
			{
				bool value = get_NxActorPairFilter_filtered_INVOKE(ClassPointer);
				return value;
			}
			set
			{
				set_NxActorPairFilter_filtered_INVOKE(ClassPointer, value);
			}
		}
		
		#region Imports
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="set_NxActorPairFilter_actor")]
        private extern static void set_NxActorPairFilter_actor_INVOKE (HandleRef classPointer, [MarshalAs(UnmanagedType.LPArray, SizeConst=2)] IntPtr[] newvalue);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="get_NxActorPairFilter_actor")]
        private extern static void get_NxActorPairFilter_actor_INVOKE (HandleRef classPointer, [Out()] [MarshalAs(UnmanagedType.LPArray, SizeConst=2)] IntPtr[] value);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="set_NxActorPairFilter_filtered")]
        private extern static void set_NxActorPairFilter_filtered_INVOKE (HandleRef classPointer, System.Boolean newvalue);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="get_NxActorPairFilter_filtered")]
        private extern static System.Boolean get_NxActorPairFilter_filtered_INVOKE (HandleRef classPointer);

		#endregion
		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="new_NxActorPairFilter")]
        private extern static IntPtr new_NxActorPairFilter_INVOKE (bool do_override);

		
		public NxActorPairFilter() : 
				base(new_NxActorPairFilter_INVOKE(false))
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
		
		public static NxActorPairFilter GetClass(IntPtr ptr)
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
					return ((NxActorPairFilter)(obj.Target));
				}
			}
			return new NxActorPairFilter(ptr);
		}
		
		protected override System.Collections.Generic.List<System.IntPtr> CreateFunctionPointers()
		{
			System.Collections.Generic.List<System.IntPtr> list = base.CreateFunctionPointers();
			return list;
		}
	}
}
